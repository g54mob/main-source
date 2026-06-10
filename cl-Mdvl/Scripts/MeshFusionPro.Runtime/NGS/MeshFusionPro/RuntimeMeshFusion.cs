using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class RuntimeMeshFusion : MonoBehaviour
	{
		private static class DomainReloader
		{
			public static void Reload()
			{
				_Instances = null;
				MeshSeparatorSimple.ClearCache();
			}
		}

		private static List<RuntimeMeshFusion> _Instances;

		[SerializeField]
		private int _controllerIndex;

		[SerializeField]
		private bool _drawGizmo;

		[SerializeField]
		private int _cellSize = 5;

		[SerializeField]
		private int _maxVerticesPerObject = 65535;

		[SerializeField]
		private int _maxBonesPerObject = 1000;

		[SerializeField]
		private MeshType _meshType;

		[SerializeField]
		private MoveMethod _moveMethod = MoveMethod.Jobs;

		private CombineTree _combineTree;

		private bool _sourceAdded;

		private BinaryTreeDrawer<ICombineSource> _treeDrawer;

		public int ControllerIndex
		{
			get
			{
				return _controllerIndex;
			}
			set
			{
				_controllerIndex = value;
			}
		}

		public bool DrawGizmo
		{
			get
			{
				return _drawGizmo;
			}
			set
			{
				_drawGizmo = value;
			}
		}

		public int CellSize
		{
			get
			{
				return _cellSize;
			}
			set
			{
				_cellSize = Mathf.Max(1, value);
			}
		}

		public bool LimitVertices
		{
			get
			{
				return _maxVerticesPerObject <= 65535;
			}
			set
			{
				if (!Application.isPlaying)
				{
					if (value)
					{
						_maxVerticesPerObject = 65535;
					}
					else
					{
						_maxVerticesPerObject = int.MaxValue;
					}
				}
			}
		}

		public int BonesLimit
		{
			get
			{
				return _maxBonesPerObject;
			}
			set
			{
				_maxBonesPerObject = Mathf.Max(value, 1);
			}
		}

		public MeshType MeshType
		{
			get
			{
				return _meshType;
			}
			set
			{
				if (!Application.isPlaying)
				{
					_meshType = value;
				}
			}
		}

		public MoveMethod MoveMethod
		{
			get
			{
				return _moveMethod;
			}
			set
			{
				if (!Application.isPlaying)
				{
					_moveMethod = value;
				}
			}
		}

		public event Action<CombinedObject> onStaticCombinedObjectCreated
		{
			add
			{
				_combineTree.onStaticCombinedObjectCreated += value;
			}
			remove
			{
				_combineTree.onStaticCombinedObjectCreated -= value;
			}
		}

		public event Action<DynamicCombinedObject> onDynamicCombinedObjectCreated
		{
			add
			{
				_combineTree.onDynamicCombinedObjectCreated += value;
			}
			remove
			{
				_combineTree.onDynamicCombinedObjectCreated -= value;
			}
		}

		public event Action<CombinedLODGroup> onCombinedLODGroupCreated
		{
			add
			{
				_combineTree.onCombinedLODGroupCreated += value;
			}
			remove
			{
				_combineTree.onCombinedLODGroupCreated -= value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ReloadDomains()
		{
			DomainReloader.Reload();
		}

		private void Awake()
		{
			if (_Instances == null)
			{
				_Instances = new List<RuntimeMeshFusion>();
			}
			_Instances.Add(this);
			ICombinedMeshFactory factory = new CombinedMeshFactory(_meshType, CombineMethod.Simple, _moveMethod);
			_combineTree = new CombineTree(factory, _cellSize, _maxVerticesPerObject, _maxBonesPerObject);
			_treeDrawer = new BinaryTreeDrawer<ICombineSource>();
			Transform parent = new GameObject("CombinedObjects").transform;
			_combineTree.onStaticCombinedObjectCreated += delegate(CombinedObject r)
			{
				r.transform.parent = parent;
			};
			_combineTree.onSkinnedCombinedObjectCreated += delegate(SkinnedCombinedObject r)
			{
				r.transform.parent = parent;
			};
			_combineTree.onDynamicCombinedObjectCreated += delegate(DynamicCombinedObject r)
			{
				r.transform.parent = parent;
			};
			_combineTree.onCombinedLODGroupCreated += delegate(CombinedLODGroup r)
			{
				r.transform.parent = parent;
			};
		}

		private void Update()
		{
			if (_sourceAdded)
			{
				_combineTree.Combine();
				_sourceAdded = false;
			}
		}

		private void OnDrawGizmos()
		{
			if (Application.isPlaying && _drawGizmo && _combineTree != null && _combineTree.Root != null)
			{
				_treeDrawer.DrawGizmo(_combineTree.Root, Color.white);
			}
		}

		private void OnDestroy()
		{
			_Instances.Remove(this);
		}

		public static RuntimeMeshFusion FindByIndex(int index)
		{
			for (int i = 0; i < _Instances.Count; i++)
			{
				RuntimeMeshFusion runtimeMeshFusion = _Instances[i];
				if (runtimeMeshFusion.ControllerIndex == index)
				{
					return runtimeMeshFusion;
				}
			}
			throw new KeyNotFoundException("MeshFusionController with index : " + index + " not found");
		}

		public void AddSource(ICombineSource source)
		{
			_combineTree.Add(source);
			_sourceAdded = true;
		}

		public void RemoveSource(ICombineSource source)
		{
			_combineTree.Remove(source);
		}
	}
}
