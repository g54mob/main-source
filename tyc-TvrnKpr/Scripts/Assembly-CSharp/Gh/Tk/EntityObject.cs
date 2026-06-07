using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using LitJson;
using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class EntityObject : IPersistable, ICustomSaveState
	{
		[CompilerGenerated]
		private sealed class _003CGetAllEntityObjects_003Ed__17 : IEnumerable<EntityObject>, IEnumerable, IEnumerator<EntityObject>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EntityObject _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public EntityObject _003C_003E4__this;

			private List<EntityObject>.Enumerator _003C_003E7__wrap1;

			private IEnumerator<EntityObject> _003C_003E7__wrap2;

			EntityObject IEnumerator<EntityObject>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetAllEntityObjects_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<EntityObject> IEnumerable<EntityObject>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsLocal;

		private GameObject _go;

		public List<EntityObject> AttachedEntityObjects;

		public EntityObject BrokenEntityObject;

		private string _prefabId;

		private BuildableTemplate _buildableTemplate;

		private bool _useBuildCostOverride;

		private int _buildCostOverride;

		[PersistenceOptIn]
		private string _name;

		public int World;

		public const string _groupID = "GROUP";

		public static readonly int _groupIdHash;

		public static string _idKey;

		public static string _snapPointIdKey;

		public static string _snapEntityObjectIdKey;

		public static string _snapCustomRotationKey;

		private PrefabObjectPool _highlightPool;

		protected List<Renderer> _highlightableRenderers;

		protected List<GameObject> _currentSelectionOutlines;

		private GameObject _particleObject;

		private ParticleSystem[] _particleSystems;

		private float3 _particleOffset;

		private float3 _particleScale;

		private quaternion _particleRotation;

		private bool _isParticleTransformDirty;

		private string _styleId;

		private static readonly string _instanceString;

		private int _meshId;

		private const float MAXBrokenRotationDiff = 10f;

		private const float MAXBrokenPositionDiff = 0.1f;

		private float3? _currentPosDiff;

		private Quaternion? _currentRotationDiff;

		private PropModelTypes _currentTypeShowing;

		private bool? _hasBrokenVersion;

		private static int[] _validLayersToMerge_Decoration;

		private List<GameObject> _currentMeshObjs;

		private GameObject _combinedMeshParent;

		private readonly List<BakeMeshRendererData> _mergedRenderers;

		public string Id { get; private set; }

		public GameObject GO
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public (string Id, EntityObject EntityObject, Quaternion SnappingCustomRotation) DefaultSnappingPoint { get; set; }

		public int WorldIndex => 0;

		[JsonIgnore]
		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float3 Translation
		{
			get
			{
				return default(float3);
			}
			set
			{
			}
		}

		public Vector3 WorldPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public quaternion Rotation
		{
			get
			{
				return default(quaternion);
			}
			set
			{
			}
		}

		public Vector3 LocalScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float3 LossyScale
		{
			get
			{
				return default(float3);
			}
			set
			{
			}
		}

		public event EventHandler NameChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool IsGroup()
		{
			return false;
		}

		protected EntityObject()
		{
		}

		protected EntityObject(int world)
		{
		}

		public static EntityObject FromDataStore(DataStore data)
		{
			return null;
		}

		public EntityObject(GameObject go, int world)
		{
		}

		public void SetAttachedEntityObjectOrder(EntityObject obj, int newIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CGetAllEntityObjects_003Ed__17))]
		public IEnumerable<EntityObject> GetAllEntityObjects()
		{
			return null;
		}

		public bool IsEnabled()
		{
			return false;
		}

		public void Disable()
		{
		}

		public void Enable()
		{
		}

		public void Attach(EntityObject obj)
		{
		}

		public void Remove(EntityObject obj)
		{
		}

		public void RemoveEntity(GameObject go)
		{
		}

		private void DestroyEntity()
		{
		}

		public void Destroy()
		{
		}

		public string GetPrefabId()
		{
			return null;
		}

		public BuildableTemplate GetBuildableTemplate()
		{
			return null;
		}

		public void SetBuildCostOverride(int buildCostOverride)
		{
		}

		public int GetBuildCost()
		{
			return 0;
		}

		public int GetBuildCostIncludingChildren()
		{
			return 0;
		}

		public void UpdateWorld(int world)
		{
		}

		public static string GetPrefabIdForEntityObject(EntityObject entityObject)
		{
			return null;
		}

		public static string GetPrefabIdForEntity(GameObject go)
		{
			return null;
		}

		public static BuildableTemplate GetBuildableTemplateForEntity(GameObject go, int world)
		{
			return null;
		}

		public static GameObject CreateGroupEntity(int world)
		{
			return null;
		}

		private void CreateGroupParent(int world)
		{
		}

		private void DestroyBrokenEntity()
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		private void RestoreState(IDataStore data, EntityObject parent)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public EntityObject Clone(EntityObject parent = null, bool withParentRelation = true)
		{
			return null;
		}

		public static void UpdateDefaultSnappingPoint(EntityObject orig, EntityObject clone)
		{
		}

		private static EntityObject FindNewEntity(EntityObject entityObject, EntityObject oldObj, EntityObject newObj)
		{
			return null;
		}

		public void SetEntityPosition(float3 position)
		{
		}

		public void SetEntityRotation(quaternion rotation)
		{
		}

		public void SetEntityRotation(float x, float y, float z)
		{
		}

		public void SetEntityScale(float3 scale)
		{
		}

		public int GetParentGoxId()
		{
			return 0;
		}

		public GameObjectX GetParentGox()
		{
			return null;
		}

		public void SetParentGoxId(int id)
		{
		}

		public void RemoveParentGoxId()
		{
		}

		public EntityObject GetRootEntityObject()
		{
			return null;
		}

		public GameObject CreateUIModel(Transform parent, string swatchMaterialOverride = null)
		{
			return null;
		}

		public void ShowOutline(Color color, bool isEditMode = false)
		{
		}

		public Quaternion GetRotationWithoutScale()
		{
			return default(Quaternion);
		}

		public Quaternion GetRotationWithoutScaleLocal()
		{
			return default(Quaternion);
		}

		public void HideOutline()
		{
		}

		private void InitParticleSystem()
		{
		}

		private void UpdateParticleTransform()
		{
		}

		public void InvalidateParticleTransform(bool includeChildren = true)
		{
		}

		public void SetStyle(string id, string materialKeyOverride = null)
		{
		}

		public Style GetCurrentStyle()
		{
			return null;
		}

		public List<Style> GetAvailableStyles()
		{
			return null;
		}

		public void ApplyStyle(string materialKeyOverride = null)
		{
		}

		public string GetMaterialTemplateId()
		{
			return null;
		}

		public int GetPriceDifferenceToSwitchMaterial(string oldStyle, string newStyle)
		{
			return 0;
		}

		public void EnterDecorPlacementGameMode()
		{
		}

		public void ExitDecorPlacementGameMode()
		{
		}

		public void Show(PropModelTypes type, IRng rng)
		{
		}

		public bool Exists()
		{
			return false;
		}

		public bool HasParent()
		{
			return false;
		}

		private void PrepareToCombineMesh()
		{
		}

		public void MergeAsDecorationMesh()
		{
		}

		private void MergeRenderers(IEnumerable<BakeMeshRendererData> validRenderers, bool includeVertexStreams)
		{
		}

		private void ClearCombineMesh()
		{
		}

		public void UnmergeMeshes()
		{
		}

		public void PrepareForReplay()
		{
		}

		public void OnReplayFinished()
		{
		}
	}
}
