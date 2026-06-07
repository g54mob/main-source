using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace tripolygon.UModeler
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class UModeler : MonoBehaviour, ISerializationCallbackReceiver
	{
		public delegate void ModelerDelegate(UModeler modeler);

		public delegate bool OnCheckMesh(UModeler modeler);

		public static bool enableDelegate = true;

		public static ModelerDelegate OnAwakeDelegate = null;

		public static ModelerDelegate OnDestroyDelegate = null;

		public static ModelerDelegate OnDisableDelegate = null;

		public static ModelerDelegate OnEnableDelegate = null;

		public static ModelerDelegate OnStartDelegate = null;

		public static OnCheckMesh OnCheckMeshDelegate = null;

		public static ModelerDelegate OnChangeMeshDelegate = null;

		public static ulong latestID_ = 0uL;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("editable_mesh_")]
		private EditableMesh editableMesh_;

		[SerializeField]
		[HideInInspector]
		private bool backfaces_;

		[HideInInspector]
		public List<Material> materials = new List<Material>();

		[HideInInspector]
		public Material[] originalMaterials = new Material[0];

		[HideInInspector]
		public bool editMode = true;

		[HideInInspector]
		public bool recalculateTangents = true;

		[HideInInspector]
		public string serializedGuid;

		[HideInInspector]
		public string assetPath;

		[HideInInspector]
		public bool isInvisibleObject;

		[HideInInspector]
		public Mesh mainRenderableMesh;

		[HideInInspector]
		public HotspotLayout hotspotLayout;

		[HideInInspector]
		public float hotspotScale = 1f;

		[HideInInspector]
		public int hotspotPadding;

		[HideInInspector]
		public float hotspotPriority = 0.5f;

		[HideInInspector]
		public bool autoHotspotLayout;

		[HideInInspector]
		public bool hotspotGroup;

		private EngineResourceManager engineResources_;

		private int totalTriangleCount_ = -1;

		private int totalPolygonCount_ = -1;

		private bool isLockSerialize = true;

		private MeshFilter renderableMeshFilter_;

		private MeshRenderer meshRenderer_;

		public EngineResourceManager engineResources
		{
			get
			{
				_ = engineResources_;
				return engineResources_;
			}
		}

		public string AssetFileName
		{
			get
			{
				if (!IsAssetPathValid())
				{
					return null;
				}
				return assetPath.Remove(0, assetPath.LastIndexOf('/') + 1);
			}
		}

		public string MeshName
		{
			get
			{
				if (!IsAssetPathValid())
				{
					return null;
				}
				return AssetFileName.Remove(AssetFileName.IndexOf('.'));
			}
		}

		public EditableMesh editableMesh
		{
			get
			{
				if (editableMesh_ == null)
				{
					editableMesh_ = new EditableMesh();
				}
				return editableMesh_;
			}
		}

		public bool backfaces
		{
			get
			{
				return backfaces_;
			}
			set
			{
				backfaces_ = value;
			}
		}

		public bool IsInvisibleObject
		{
			get
			{
				return isInvisibleObject;
			}
			set
			{
				isInvisibleObject = value;
				if (isInvisibleObject)
				{
					originalMaterials = materials.ToArray();
				}
			}
		}

		public bool IsLockSerialize => isLockSerialize;

		public Matrix4x4 worldTM => base.transform.localToWorldMatrix;

		public Matrix4x4 worldToLocalTM => base.transform.worldToLocalMatrix;

		public string objectName => UMContext.activeModeler.gameObject.name;

		public MeshFilter renderableMeshFilter
		{
			get
			{
				if (renderableMeshFilter_ == null)
				{
					CreateMeshFilter();
				}
				return renderableMeshFilter_;
			}
		}

		public MeshRenderer meshRenderer
		{
			get
			{
				if (meshRenderer_ == null)
				{
					CreateMeshRenderer();
				}
				return meshRenderer_;
			}
		}

		public static ulong GenerateID()
		{
			return ++latestID_;
		}

		public static void UpdateLatestID(UModeler modeler)
		{
			ulong num = modeler.CollectLatestID();
			if (num > latestID_)
			{
				latestID_ = num;
			}
		}

		public int GetTotalTriangleCount(bool IncludeSubMeshTriangles = true)
		{
			if (totalTriangleCount_ == -1)
			{
				totalTriangleCount_ = Util.CountTriangle(renderableMeshFilter);
				if (IncludeSubMeshTriangles)
				{
					totalTriangleCount_ += Util.CountTriangle(engineResources.RenderableMesh);
				}
			}
			return totalTriangleCount_;
		}

		public int GetTotalPolygonCount()
		{
			if (totalPolygonCount_ == -1)
			{
				totalPolygonCount_ = 0;
				using (new ShelfHolder())
				{
					for (int i = 0; i < 2; i++)
					{
						editableMesh.shelf = i;
						totalPolygonCount_ += editableMesh.GetPolygonCount();
					}
				}
			}
			return totalPolygonCount_;
		}

		public bool IsAssetPathValid()
		{
			if (assetPath != null)
			{
				return assetPath.Length > 0;
			}
			return false;
		}

		public bool IsCorruptModeler()
		{
			return editableMesh_.IsCorruptMesh();
		}

		public bool Repair()
		{
			return editableMesh_.Repair();
		}

		public void ResetAssetPath()
		{
			assetPath = string.Empty;
		}

		private void SetColliderObject()
		{
		}

		private void Start()
		{
			if (OnStartDelegate != null && enableDelegate)
			{
				OnStartDelegate(this);
			}
		}

		public void RefreshResources()
		{
			using (new ActiveModelerHolder(this))
			{
				if (editableMesh.uvIslandManager != null)
				{
					editableMesh.uvIslandManager.Refresh();
				}
				if (editableMesh.smoothingGroups != null)
				{
					editableMesh.smoothingGroups.Refresh();
				}
			}
		}

		public void Build(int shelf = -1, bool updateToGraphicsAPIImmediately = false)
		{
			if (!StopModelerBuild.CheckBuild(shelf, updateToGraphicsAPIImmediately))
			{
				return;
			}
			using (new ActiveModelerHolder(this))
			{
				if ((shelf == 0 || shelf == -1) && renderableMeshFilter != null)
				{
					if (!mainRenderableMesh.isReadable)
					{
						mainRenderableMesh = new Mesh
						{
							name = "um_" + Mathf.Abs(GetInstanceID())
						};
					}
					if ((renderableMeshFilter.sharedMesh == null || renderableMeshFilter.sharedMesh != mainRenderableMesh) && mainRenderableMesh != null)
					{
						renderableMeshFilter.sharedMesh = mainRenderableMesh;
					}
					Mesh sharedMesh = renderableMeshFilter.sharedMesh;
					if ((object)sharedMesh != null && sharedMesh.isReadable)
					{
						MeshCollider component = GetComponent<MeshCollider>();
						if (component != null && component.sharedMesh != renderableMeshFilter.sharedMesh)
						{
							component.sharedMesh = renderableMeshFilter.sharedMesh;
						}
					}
				}
				RefreshResources();
				BuildEdMesh(shelf);
				if (updateToGraphicsAPIImmediately && (shelf == 0 || shelf == -1))
				{
					MeshFilter meshFilter = renderableMeshFilter;
					if ((object)meshFilter != null && meshFilter.sharedMesh?.isReadable == true)
					{
						renderableMeshFilter.sharedMesh.UploadMeshData(markNoLongerReadable: false);
					}
				}
			}
		}

		public void BuildEdMesh(int shelf = -1)
		{
			if (!StopModelerBuild.CheckBuildEdMesh(shelf))
			{
				return;
			}
			using (new ActiveModelerHolder(this))
			{
				if (!mainRenderableMesh.isReadable)
				{
					mainRenderableMesh = new Mesh
					{
						name = "um_" + Mathf.Abs(GetInstanceID())
					};
					if ((renderableMeshFilter.sharedMesh == null || renderableMeshFilter.sharedMesh != mainRenderableMesh) && mainRenderableMesh != null)
					{
						renderableMeshFilter.sharedMesh = mainRenderableMesh;
					}
				}
				Builder.Build(this, shelf);
			}
			InvalideCounting();
		}

		public void SetPrefabInstance(bool isPrefabInstance)
		{
			if (isLockSerialize && !isPrefabInstance)
			{
				isLockSerialize = isPrefabInstance;
				OnAfterDeserialize();
			}
			else
			{
				isLockSerialize = isPrefabInstance;
			}
		}

		public void OnBeforeSerialize()
		{
			if (!isLockSerialize)
			{
				editableMesh.BeforeSerialize();
			}
		}

		public void OnAfterDeserialize()
		{
			if (!isLockSerialize)
			{
				editableMesh.AfterDeserialize();
				editableMesh.InvalidateCache();
				UpdateLatestID(this);
			}
		}

		public void Awake()
		{
			if (OnAwakeDelegate != null && enableDelegate)
			{
				OnAwakeDelegate(this);
			}
			if (isInvisibleObject && Application.isPlaying)
			{
				Renderer component = GetComponent<Renderer>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
		}

		private ulong CollectLatestID()
		{
			ulong result = 0uL;
			if (editableMesh_ != null)
			{
				result = editableMesh_.CollectLatestID();
			}
			return result;
		}

		public void CheckInstanceID()
		{
			List<ulong> instanceIDs = new List<ulong>();
			if (editableMesh_ != null)
			{
				editableMesh_.CheckInstanceID(instanceIDs);
			}
		}

		public void OnDestroy()
		{
			if (OnDestroyDelegate != null && enableDelegate)
			{
				OnDestroyDelegate(this);
			}
		}

		public void OnDisable()
		{
			if (OnDisableDelegate != null && enableDelegate)
			{
				OnDisableDelegate(this);
			}
		}

		public void OnEnable()
		{
			if (OnEnableDelegate != null && enableDelegate)
			{
				OnEnableDelegate(this);
			}
		}

		public void OnRenderObject()
		{
			if (!(Camera.current != null) || engineResources == null || !(engineResources.RenderableMesh != null) || engineResources.RenderableMaterials.Count <= 0 || (Camera.current.name != "SceneCamera" && Camera.current.name != "Main Camera" && Camera.current.name != "Preview Scene Camera"))
			{
				return;
			}
			for (int i = 0; i < engineResources.RenderableMesh.subMeshCount; i++)
			{
				if (engineResources.RenderableMesh.GetIndexCount(i) != 0)
				{
					Graphics.DrawMesh(engineResources.RenderableMesh, worldTM, engineResources.RenderableMaterials[i], 0, null, i);
				}
			}
		}

		public void InvalideCounting()
		{
			totalTriangleCount_ = -1;
			totalPolygonCount_ = -1;
		}

		public void CopySubData(UModeler originalModeler)
		{
			backfaces_ = originalModeler.backfaces_;
			materials.Clear();
			materials.AddRange(originalModeler.materials);
		}

		public void InvalidateMeshResources()
		{
			renderableMeshFilter_ = null;
			meshRenderer_ = null;
		}

		public void CreateEngineResource()
		{
			if (engineResources_ == null)
			{
				engineResources_ = new EngineResourceManager();
				engineResources_.Init();
			}
		}

		public void CreateMeshFilter()
		{
			MeshFilter meshFilter = base.transform.gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				Debug.LogError("Error: MeshFilter Not Created");
				meshFilter = base.transform.gameObject.AddComponent<MeshFilter>();
			}
			if (mainRenderableMesh == null)
			{
				Debug.LogError("Error : mainRenderableMesh is null.");
				mainRenderableMesh = new Mesh
				{
					name = "um_" + Mathf.Abs(GetInstanceID())
				};
			}
			meshFilter.hideFlags = HideFlags.None;
			renderableMeshFilter_ = meshFilter;
			if (meshFilter.sharedMesh == null || meshFilter.sharedMesh != mainRenderableMesh)
			{
				meshFilter.sharedMesh = mainRenderableMesh;
				Build(0);
			}
		}

		public void CreateMeshRenderer()
		{
			MeshRenderer meshRenderer = base.transform.gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				Debug.LogError("Error: MeshRenderer Not Created");
				meshRenderer = base.transform.gameObject.AddComponent<MeshRenderer>();
			}
			meshRenderer.sortingOrder = 0;
			meshRenderer_ = meshRenderer;
		}
	}
}
