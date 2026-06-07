using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AwesomeTechnologies.BillboardSystem;
using AwesomeTechnologies.Billboards;
using AwesomeTechnologies.Extensions;
using AwesomeTechnologies.MeshTerrains;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Utility.Culling;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.Vegetation.Masks;
using AwesomeTechnologies.Vegetation.PersistentStorage;
using AwesomeTechnologies.VegetationStudio;
using AwesomeTechnologies.VegetationSystem.Wind;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace AwesomeTechnologies.VegetationSystem
{
	[AwesomeTechnologiesScriptOrder(100)]
	[ExecuteInEditMode]
	public class VegetationSystemPro : MonoBehaviour
	{
		public delegate void MultiOnAddCameraDelegate(VegetationStudioCamera vegetationStudioCamera);

		public delegate void MultiOnRemoveCameraDelegate(VegetationStudioCamera vegetationStudioCamera);

		public delegate void MultiOnVegetationStudioRefreshDelegate(VegetationSystemPro vegetationSystemPro);

		public delegate void MultiOnClearCacheDelegate(VegetationSystemPro vegetationSystemPro);

		public delegate void MultiOnClearCacheVegetationCellDelegate(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell);

		public delegate void MultiOnClearCacheVegetationItemDelegate(VegetationSystemPro vegetationSystemPro, int vegetationPackageIndex, int vegetationItemIndex);

		public delegate void MultiOnClearCacheVegetationCellVegetationItemDelegate(VegetationSystemPro vegetationSystemPro, VegetationCell vegetationCell, int vegetationPackageIndex, int vegetationItemIndex);

		public delegate void MultiOnVegetationCellSpawnedDelegate(VegetationCell vegetationCell);

		public delegate void MultOnRenderCompleteDelegate(VegetationSystemPro vegetationSystemPro);

		public QuadTree<VegetationCell> VegetationCellQuadTree;

		public QuadTree<BillboardCell> BillboardCellQuadTree;

		[NonSerialized]
		public readonly List<VegetationCell> VegetationCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<BillboardCell> BillboardCellList = new List<BillboardCell>();

		[NonSerialized]
		public readonly List<VegetationCell> LoadedVegetationCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<VegetationCell> ProcessInstancedIndirectCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<VegetationCell> CompactMemoryCellList = new List<VegetationCell>();

		[NonSerialized]
		public readonly List<VegetationCell> PredictiveCellLoaderList = new List<VegetationCell>();

		public VegetationCellSpawner VegetationCellSpawner = new VegetationCellSpawner();

		public Bounds VegetationSystemBounds;

		public bool AutomaticBoundsCalculation = true;

		public PersistentVegetationStorage PersistentVegetationStorage;

		public PredictiveCellLoader PredictiveCellLoader;

		public int PredictiveCellLoaderCellsPerFrame = 1;

		public bool LoadPotentialVegetationCells = true;

		public int CurrentTabIndex;

		public int VegetationPackageIndex;

		public float SeaLevel;

		public bool ExcludeSeaLevelCells;

		public float VegetationCellSize = 100f;

		public float BillboardCellSize = 500f;

		public bool UseCacheCompacter;

		[NonSerialized]
		public float AdditionalBoundingSphereRadius;

		public int SelectedTextureMaskGroupTextureIndex;

		public int SelectedTextureMaskGroupIndex;

		public TextureMask DebugTextureMask;

		[NonSerialized]
		public bool InitDone;

		private JobHandle _prepareVegetationHandle;

		public VegetationSettings VegetationSettings = new VegetationSettings();

		public VegetationRenderSettings VegetationRenderSettings = new VegetationRenderSettings();

		public EnvironmentSettings EnvironmentSettings = new EnvironmentSettings();

		public List<VegetationStudioCamera> VegetationStudioCameraList = new List<VegetationStudioCamera>();

		public bool ShowVegetationCells;

		public bool ShowBillboardCells;

		public bool ShowVisibleBillboardCells;

		public bool ShowPotentialVisibleCells;

		public bool ShowVisibleCells;

		public bool ShowBiomeCells;

		public bool ShowVegetationMaskCells;

		public bool ShowHeatMap;

		public bool ShowTerrainTextures = true;

		public bool ShowLODDebug;

		public bool ShowVegetationPackageGeneralSettingsMenu = true;

		public bool ShowVegetationPackageNoiseMenu = true;

		public bool ShowTerrainTextureRulesMenu = true;

		public bool ShowTextureMaskRulesMenu = true;

		public bool ShowVegetationMaskRulesMenu = true;

		public bool ShowShaderSettingsMenu = true;

		public bool ShowPositionMenu = true;

		public bool ShowDistanceFalloffMenu = true;

		public bool ShowBiomeRulesMenu = true;

		public bool ShowConcaveLocationRulesMenu = true;

		public bool ShowColliderRulesMenu = true;

		public bool ShowBillboardsMenu = true;

		public bool ShowVegetationItemSettingsMenu = true;

		public bool ShowTerrainSourceSettingsMenu = true;

		public bool ShowAddVegetationItemMenu = true;

		public bool ShowLODMenu = true;

		public List<IVegetationStudioTerrain> VegetationStudioTerrainList = new List<IVegetationStudioTerrain>();

		public List<GameObject> VegetationStudioTerrainObjectList = new List<GameObject>();

		public List<VegetationPackagePro> VegetationPackageProList = new List<VegetationPackagePro>();

		public List<VegetationPackageProModelInfo> VegetationPackageProModelsList = new List<VegetationPackageProModelInfo>();

		public List<WindControllerSettings> WindControllerSettingsList = new List<WindControllerSettings>();

		public MultiOnAddCameraDelegate OnAddCameraDelegate;

		public MultiOnRemoveCameraDelegate OnRemoveCameraDelegate;

		public MultiOnVegetationStudioRefreshDelegate OnRefreshVegetationSystemDelegate;

		public MultiOnVegetationStudioRefreshDelegate OnRefreshColliderSystemDelegate;

		public MultiOnVegetationStudioRefreshDelegate OnRefreshRuntimePrefabSpawnerDelegate;

		public MultiOnVegetationCellSpawnedDelegate OnVegetationCellLoaded;

		public MultiOnClearCacheDelegate OnClearCacheDelegate;

		public MultiOnClearCacheVegetationItemDelegate OnClearCacheVegetationItemDelegate;

		public MultiOnClearCacheVegetationCellDelegate OnClearCacheVegetationCellDelegate;

		public MultiOnClearCacheVegetationCellVegetationItemDelegate OnClearCacheVegetationCellVegetatonItemDelegate;

		public MultOnRenderCompleteDelegate OnRenderCompleteDelegate;

		[NonSerialized]
		private readonly List<IWindController> _windControllerList = new List<IWindController>();

		public WindZone SelectedWindZone;

		public float WindSpeedFactor = 1f;

		public Light SunDirectionalLight;

		private ComputeBuffer _dummyComputeBuffer;

		public int FrustumKernelHandle;

		public ComputeShader FrusumMatrixShader;

		private int _cameraFrustumPlan0;

		private int _cameraFrustumPlan1;

		private int _cameraFrustumPlan2;

		private int _cameraFrustumPlan3;

		private int _cameraFrustumPlan4;

		private int _cameraFrustumPlan5;

		public int MergeBufferKernelHandle;

		public ComputeShader MergeBufferShader;

		private int _floatingOriginOffsetID = -1;

		private int _mergeBufferID = -1;

		private int _mergeSourceBuffer0ID = -1;

		private int _mergeSourceBuffer1ID = -1;

		private int _mergeSourceBuffer2ID = -1;

		private int _mergeSourceBuffer3ID = -1;

		private int _mergeSourceBuffer4ID = -1;

		private int _mergeSourceBuffer5ID = -1;

		private int _mergeSourceBuffer6ID = -1;

		private int _mergeSourceBuffer7ID = -1;

		private int _mergeSourceBuffer8ID = -1;

		private int _mergeSourceBuffer9ID = -1;

		private int _mergeSourceBuffer10ID = -1;

		private int _mergeSourceBuffer11ID = -1;

		private int _mergeSourceBuffer12ID = -1;

		private int _mergeSourceBuffer13ID = -1;

		private int _mergeSourceBuffer14ID = -1;

		private int _mergeInstanceCount0ID = -1;

		private int _mergeInstanceCount1ID = -1;

		private int _mergeInstanceCount2ID = -1;

		private int _mergeInstanceCount3ID = -1;

		private int _mergeInstanceCount4ID = -1;

		private int _mergeInstanceCount5ID = -1;

		private int _mergeInstanceCount6ID = -1;

		private int _mergeInstanceCount7ID = -1;

		private int _mergeInstanceCount8ID = -1;

		private int _mergeInstanceCount9ID = -1;

		private int _mergeInstanceCount10ID = -1;

		private int _mergeInstanceCount11ID = -1;

		private int _mergeInstanceCount12ID = -1;

		private int _mergeInstanceCount13ID = -1;

		private int _mergeInstanceCount14ID = -1;

		private int _visibleBufferLod0ID = -1;

		private int _visibleBufferLod1ID = -1;

		private int _visibleBufferLod2ID = -1;

		private int _visibleBufferLod3ID = -1;

		private int _shadowBufferLod0ID = -1;

		private int _shadowBufferLod1ID = -1;

		private int _shadowBufferLod2ID = -1;

		private int _shadowBufferLod3ID = -1;

		private int _sourceBufferID = -1;

		private int _instanceCountID = -1;

		private int _boundingSphereRadiusID = -1;

		private int _useLodsID = -1;

		private int _noFrustumCullingID = -1;

		private int _shadowCullingID = -1;

		private int _cullFarStartID;

		private int _visibleShaderDataBufferID;

		private int _indirectShaderDataBufferID;

		private int _cameraPositionID;

		private int _cullDistanceID;

		private int _farCullDistanceID;

		private static readonly int _nearFadeDistanceID = Shader.PropertyToID("_NearFadeDistance");

		private int _unityLODFadeID;

		private int _lod1Distance = -1;

		private int _lod2Distance = -1;

		private int _lod3Distance = -1;

		private int _lightDirection = -1;

		private int _planeOrigin = -1;

		private int _boundsSize = -1;

		private int _lodFactor = -1;

		private int _lodBias = -1;

		private int _lodFadeDistance = -1;

		private int _lodCount = -1;

		private readonly List<VegetationCell> _hasBufferList = new List<VegetationCell>();

		private readonly Matrix4x4[] _renderArray = new Matrix4x4[1000];

		private readonly float[] _renderingLayerArray = new float[1000];

		private readonly Vector4[] _renderLodFadeArray = new Vector4[1000];

		public Transform FloatingOriginAnchor;

		public Vector3 FloatingOriginOffset;

		public Vector3 FloatingOriginStartPosition;

		private static readonly int UnityRenderingLayerID = Shader.PropertyToID("unity_RenderingLayer");

		private int lastLoadingListLength;

		[NonSerialized]
		private readonly List<VegetationCell> _billboardTempVegetationCellList = new List<VegetationCell>();

		[NonSerialized]
		private readonly List<BillboardCell> _loadBillboardCellList = new List<BillboardCell>();

		public bool IsLoading => lastLoadingListLength > 0;

		public Vector3 VegetationSystemPosition
		{
			get
			{
				Vector3 result = VegetationSystemBounds.center - VegetationSystemBounds.extents;
				result.y = 0f;
				return result;
			}
		}

		public void DetectPersistentVegetationStorage()
		{
			if (!PersistentVegetationStorage)
			{
				PersistentVegetationStorage = GetComponent<PersistentVegetationStorage>();
			}
		}

		private void Reset()
		{
			AutoSelectCamera();
			FindWindZone();
			FindDirectionalLight();
			DetectPersistentVegetationStorage();
		}

		private void FindDirectionalLight()
		{
			if ((bool)SunDirectionalLight)
			{
				return;
			}
			Light sunDirectionalLight = null;
			float num = float.MinValue;
			Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (array[i].type == LightType.Directional && array[i].intensity > num)
				{
					num = array[i].intensity;
					sunDirectionalLight = array[i];
				}
			}
			SunDirectionalLight = sunDirectionalLight;
		}

		private void AutoSelectCamera()
		{
			Camera camera = Camera.main;
			if (camera == null)
			{
				Camera[] array = UnityEngine.Object.FindObjectsOfType<Camera>();
				for (int i = 0; i <= array.Length - 1; i++)
				{
					if (array[i].gameObject.name.Contains("Main Camera") || array[i].gameObject.name.Contains("MainCamera"))
					{
						camera = array[i];
						break;
					}
				}
			}
			AddCamera(camera);
		}

		public void RefreshVegetationSystem()
		{
			SetupVegetationSystem();
		}

		public void RefreshColliderSystem()
		{
			OnRefreshColliderSystemDelegate?.Invoke(this);
		}

		public void RefreshRuntimePrefabSpawner()
		{
			OnRefreshRuntimePrefabSpawnerDelegate?.Invoke(this);
		}

		private void SetupVegetationSystem()
		{
			CompleteCellLoading();
			ProcessInstancedIndirectCellList.Clear();
			DisposeVegetationStudioCameras();
			DisposeVegetationCells();
			DisposeBillboardCells();
			if (!(VegetationSystemBounds.size.magnitude < 1f))
			{
				SetupWindSamplers();
				SetupVegetationItemModels();
				RefreshVegetationStudioTerrains();
				CreateVegetationCells();
				CreateBillboardCells();
				SetVegetationStudioCamerasDirty();
				RefreshMaterials();
				OnRefreshVegetationSystemDelegate?.Invoke(this);
			}
		}

		public void CompleteCellLoading()
		{
			_prepareVegetationHandle.Complete();
		}

		private void Awake()
		{
			SetupFloatingOrigin();
		}

		private void OnEnable()
		{
			VegetationStudioManager.RegisterVegetationSystem(this);
			DetectPersistentVegetationStorage();
			FindDirectionalLight();
			EnableEditorApi();
			LoadSettingsFromQualityManager();
			SetupPredictiveCellLoader();
			SetupVegetationCellSpawner();
			SetupSceneviewCamera();
			SetupComputeShaders();
			SetupBillboardShaderIDs();
			SetupInstancedRenderMaterialPropertiesIDs();
			SetupRenderingLayerData();
			SetupVegetationSystem();
			VegetationCellSpawner.Init();
			SetupWind();
			InitDone = true;
		}

		public void SetupRenderingLayerData()
		{
			float num = BitConverter.ToSingle(BitConverter.GetBytes(VegetationRenderSettings.RenderingLayerMask), 0);
			for (int i = 0; i < _renderingLayerArray.Length; i++)
			{
				_renderingLayerArray[i] = num;
			}
			Shader.SetGlobalFloat("VSPRenderingLayerMask", num);
		}

		private void LoadSettingsFromQualityManager()
		{
			if (Application.isPlaying)
			{
				QualityManager component = GetComponent<QualityManager>();
				if ((bool)component)
				{
					component.SetQualityLevel(forceRefresh: false);
				}
			}
		}

		private void EnableEditorApi()
		{
		}

		private void DisableEditorApi()
		{
		}

		private void OnSceneviewTransformChanged(Camera currentCamera)
		{
		}

		private void SetupSceneviewCamera()
		{
			for (int num = VegetationStudioCameraList.Count - 1; num >= 0; num--)
			{
				if (VegetationStudioCameraList[num].VegetationStudioCameraType == VegetationStudioCameraType.SceneView || VegetationStudioCameraList[num].SelectedCamera == null)
				{
					RemoveVegetationStudioCamera(VegetationStudioCameraList[num]);
				}
			}
			if (!Application.isPlaying)
			{
				VegetationStudioCamera vegetationStudioCamera = new VegetationStudioCamera(VegetationStudioCameraType.SceneView)
				{
					CameraCullingMode = CameraCullingMode.Frustum,
					RenderDirectToCamera = false,
					VegetationSystemPro = this
				};
				AddVegetationStudioCamera(vegetationStudioCamera);
			}
			if (Application.isPlaying && VegetationStudioCameraList.Count == 0)
			{
				AutoSelectCamera();
			}
		}

		private void SetupFloatingOrigin()
		{
			Transform floatingOriginAnchor = GetFloatingOriginAnchor();
			FloatingOriginStartPosition = floatingOriginAnchor.position;
		}

		private void UpdateFloatingOrigin()
		{
			if (Application.isPlaying)
			{
				Transform floatingOriginAnchor = GetFloatingOriginAnchor();
				FloatingOriginOffset = floatingOriginAnchor.transform.position - FloatingOriginStartPosition;
			}
			else
			{
				FloatingOriginOffset = Vector3.zero;
			}
		}

		private Transform GetFloatingOriginAnchor()
		{
			if ((bool)FloatingOriginAnchor)
			{
				return FloatingOriginAnchor;
			}
			return base.transform;
		}

		private void Update()
		{
			if (!InitDone)
			{
				return;
			}
			UpdateFloatingOrigin();
			if (VegetationCellList.Count <= 0)
			{
				return;
			}
			JobHandle dependsOn = default(JobHandle);
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].SetFloatingOriginOffset(FloatingOriginOffset);
				VegetationStudioCameraList[i].PreCullVegetation(forceUpdate: false);
				VegetationStudioCameraList[i].PrepareRenderLists(VegetationPackageProList);
			}
			for (int j = 0; j <= VegetationStudioCameraList.Count - 1; j++)
			{
				if (VegetationStudioCameraList[j].Enabled)
				{
					dependsOn = VegetationStudioCameraList[j].ScheduleCullVegetationJob(dependsOn);
				}
			}
			dependsOn.Complete();
			for (int k = 0; k <= VegetationStudioCameraList.Count - 1; k++)
			{
				if (VegetationStudioCameraList[k].Enabled)
				{
					VegetationStudioCameraList[k].ProcessEvents();
				}
			}
			VerifySplatmapAccess();
			VegetationCellSpawner.CellJobHandleList.Clear();
			float worldspaceSeaLevel = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y + SeaLevel;
			VegetationCellSpawner.WorldspaceSeaLevel = worldspaceSeaLevel;
			PredictiveCellLoaderList.Clear();
			PredictiveCellLoader.GetCellsToLoad(PredictiveCellLoaderList);
			lastLoadingListLength = PredictiveCellLoaderList.Count;
			for (int l = 0; l <= PredictiveCellLoaderList.Count - 1; l++)
			{
				VegetationCell vegetationCell = PredictiveCellLoaderList[l];
				bool num = vegetationCell.LoadedDistanceBand != 99;
				bool hasInstancedIndirect;
				JobHandle value = VegetationCellSpawner.SpawnVegetationCell(vegetationCell, 0, out hasInstancedIndirect, billboardsOnly: false);
				OnVegetationCellLoaded?.Invoke(vegetationCell);
				if (!num && !LoadedVegetationCellList.Contains(vegetationCell))
				{
					LoadedVegetationCellList.Add(vegetationCell);
				}
				if (hasInstancedIndirect)
				{
					ProcessInstancedIndirectCellList.Add(vegetationCell);
				}
				VegetationCellSpawner.CellJobHandleList.Add(value);
			}
			for (int m = 0; m <= VegetationStudioCameraList.Count - 1; m++)
			{
				if (!VegetationStudioCameraList[m].Enabled)
				{
					continue;
				}
				for (int n = 0; n <= VegetationStudioCameraList[m].JobCullingGroup.VisibleCellIndexList.Length - 1; n++)
				{
					int num2 = VegetationStudioCameraList[m].JobCullingGroup.VisibleCellIndexList[n];
					VegetationCell vegetationCell2 = VegetationStudioCameraList[m].PotentialVisibleVegetationCellList[num2];
					BoundingSphereInfo boundingSphereInfo = VegetationStudioCameraList[m].GetBoundingSphereInfo(num2);
					if (vegetationCell2.LoadedDistanceBand > boundingSphereInfo.CurrentDistanceBand)
					{
						lastLoadingListLength++;
						bool hasInstancedIndirect2;
						JobHandle value2 = VegetationCellSpawner.SpawnVegetationCell(vegetationCell2, boundingSphereInfo.CurrentDistanceBand, out hasInstancedIndirect2, billboardsOnly: false);
						OnVegetationCellLoaded?.Invoke(vegetationCell2);
						LoadedVegetationCellList.Add(vegetationCell2);
						if (hasInstancedIndirect2)
						{
							ProcessInstancedIndirectCellList.Add(vegetationCell2);
						}
						VegetationCellSpawner.CellJobHandleList.Add(value2);
					}
				}
			}
			_prepareVegetationHandle = JobHandle.CombineDependencies(VegetationCellSpawner.CellJobHandleList);
			JobHandle.ScheduleBatchedJobs();
			float lODBias = QualitySettings.lodBias * VegetationSettings.LODDistanceFactor;
			Vector3 lightDirection = (SunDirectionalLight ? SunDirectionalLight.transform.forward : new Vector3(0f, 0f, 0f));
			float y = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y;
			Vector3 planeOrigin = new Vector3(0f, y, 0f);
			bool flag = SunDirectionalLight != null;
			_ = Application.isPlaying;
			VegetationCellSpawner.CellJobHandleList.Clear();
			for (int num3 = 0; num3 <= VegetationStudioCameraList.Count - 1; num3++)
			{
				if (!VegetationStudioCameraList[num3].Enabled || VegetationStudioCameraList[num3].RenderBillboardsOnly)
				{
					continue;
				}
				for (int num4 = 0; num4 <= VegetationPackageProList.Count - 1; num4++)
				{
					for (int num5 = 0; num5 <= VegetationPackageProList[num4].VegetationInfoList.Count - 1; num5++)
					{
						NativeList<MatrixInstance> nativeList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemMergeMatrixList[num5];
						nativeList.Clear();
						VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[num4].VegetationItemModelList[num5];
						if (VegetationRenderSettings.UseInstancedIndirect() && vegetationItemModelInfo.VegetationItemInfo.VegetationRenderMode == VegetationRenderMode.InstancedIndirect)
						{
							continue;
						}
						JobHandle jobHandle = _prepareVegetationHandle;
						for (int num6 = 0; num6 <= VegetationStudioCameraList[num3].JobCullingGroup.VisibleCellIndexList.Length - 1; num6++)
						{
							int num7 = VegetationStudioCameraList[num3].JobCullingGroup.VisibleCellIndexList[num6];
							VegetationCell vegetationCell3 = VegetationStudioCameraList[num3].PotentialVisibleVegetationCellList[num7];
							BoundingSphereInfo boundingSphereInfo2 = VegetationStudioCameraList[num3].GetBoundingSphereInfo(num7);
							int distanceBand = vegetationItemModelInfo.DistanceBand;
							if (boundingSphereInfo2.CurrentDistanceBand <= distanceBand)
							{
								jobHandle = new MergeCellInstancesJob
								{
									OutputNativeList = nativeList,
									InputNativeList = vegetationCell3.VegetationPackageInstancesList[num4].VegetationItemMatrixList[num5]
								}.Schedule(jobHandle);
							}
						}
						NativeList<Matrix4x4> vegetationItemLOD0MatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD0MatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD1MatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD1MatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD2MatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD2MatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD3MatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD3MatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD0ShadowMatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD0ShadowMatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD1ShadowMatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD1ShadowMatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD2ShadowMatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD2ShadowMatrixList[num5];
						NativeList<Matrix4x4> vegetationItemLOD3ShadowMatrixList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD3ShadowMatrixList[num5];
						NativeList<Vector4> lOD0FadeList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD0LodFadeList[num5];
						NativeList<Vector4> lOD1FadeList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD1LodFadeList[num5];
						NativeList<Vector4> lOD2FadeList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD2LodFadeList[num5];
						NativeList<Vector4> lOD3FadeList = VegetationStudioCameraList[num3].VegetationStudioCameraRenderList[num4].VegetationItemLOD3LodFadeList[num5];
						vegetationItemLOD0MatrixList.Clear();
						vegetationItemLOD1MatrixList.Clear();
						vegetationItemLOD2MatrixList.Clear();
						vegetationItemLOD3MatrixList.Clear();
						vegetationItemLOD0ShadowMatrixList.Clear();
						vegetationItemLOD1ShadowMatrixList.Clear();
						vegetationItemLOD2ShadowMatrixList.Clear();
						vegetationItemLOD3ShadowMatrixList.Clear();
						lOD0FadeList.Clear();
						lOD1FadeList.Clear();
						lOD2FadeList.Clear();
						lOD3FadeList.Clear();
						float num8 = vegetationItemModelInfo.VegetationItemInfo.RenderDistanceFactor;
						if (VegetationSettings.DisableRenderDistanceFactor)
						{
							num8 = 1f;
						}
						float cullDistance = ((vegetationItemModelInfo.VegetationItemInfo.VegetationType != VegetationType.Tree && vegetationItemModelInfo.VegetationItemInfo.VegetationType != VegetationType.LargeObjects) ? (VegetationSettings.GetVegetationDistance() * num8) : (VegetationSettings.GetTreeDistance() * num8));
						ShadowCastingMode shadowCastingMode = VegetationSettings.GetShadowCastingMode(vegetationItemModelInfo.VegetationItemInfo.VegetationType);
						bool shadowCulling = flag && shadowCastingMode == ShadowCastingMode.On && vegetationItemModelInfo.DistanceBand == 1;
						if (VegetationStudioCameraList[num3].SelectedCamera == null)
						{
							VegetationCellSpawner.CellJobHandleList.Add(jobHandle);
							continue;
						}
						float lODFadeDistance = 0f;
						if (vegetationItemModelInfo.VegetationItemInfo.EnableCrossFade)
						{
							lODFadeDistance = VegetationRenderSettings.CrossFadeDistance;
						}
						jobHandle = new VegetationItemLODSplitAndFrustumCullingJob
						{
							BoundingSphereRadius = vegetationItemModelInfo.BoundingSphereRadius,
							BoundsSize = vegetationItemModelInfo.VegetationItemInfo.Bounds.size,
							VegetationItemDistanceBand = vegetationItemModelInfo.DistanceBand,
							VegetationItemMatrixList = nativeList,
							VegetationItemLOD0MatrixList = vegetationItemLOD0MatrixList,
							VegetationItemLOD1MatrixList = vegetationItemLOD1MatrixList,
							VegetationItemLOD2MatrixList = vegetationItemLOD2MatrixList,
							VegetationItemLOD3MatrixList = vegetationItemLOD3MatrixList,
							VegetationItemLOD0ShadowMatrixList = vegetationItemLOD0ShadowMatrixList,
							VegetationItemLOD1ShadowMatrixList = vegetationItemLOD1ShadowMatrixList,
							VegetationItemLOD2ShadowMatrixList = vegetationItemLOD2ShadowMatrixList,
							VegetationItemLOD3ShadowMatrixList = vegetationItemLOD3ShadowMatrixList,
							LOD0FadeList = lOD0FadeList,
							LOD1FadeList = lOD1FadeList,
							LOD2FadeList = lOD2FadeList,
							LOD3FadeList = lOD3FadeList,
							LightDirection = lightDirection,
							ShadowCulling = shadowCulling,
							PlaneOrigin = planeOrigin,
							FrustumPlanes = VegetationStudioCameraList[num3].JobCullingGroup.FrustumPlanes,
							CameraPosition = VegetationStudioCameraList[num3].SelectedCamera.transform.position,
							NoFrustumCulling = (VegetationStudioCameraList[num3].CameraCullingMode == CameraCullingMode.Complete360),
							CullDistance = cullDistance,
							LOD1Distance = vegetationItemModelInfo.LOD1Distance,
							LOD2Distance = vegetationItemModelInfo.LOD2Distance,
							LOD3Distance = vegetationItemModelInfo.LOD3Distance,
							LODFactor = vegetationItemModelInfo.VegetationItemInfo.LODFactor,
							LODBias = lODBias,
							LODCount = vegetationItemModelInfo.LODCount,
							LODFadeDistance = lODFadeDistance,
							LODFadePercentage = vegetationItemModelInfo.LODFadePercentage,
							LODFadeCrossfade = vegetationItemModelInfo.LODFadeCrossfade,
							FloatingOriginOffset = FloatingOriginOffset
						}.Schedule(jobHandle);
						VegetationCellSpawner.CellJobHandleList.Add(jobHandle);
					}
				}
			}
			if (VegetationCellSpawner.CellJobHandleList.Length > 0)
			{
				_prepareVegetationHandle = JobHandle.CombineDependencies(VegetationCellSpawner.CellJobHandleList);
			}
			JobHandle.ScheduleBatchedJobs();
		}

		private void SetShadowMapVariables()
		{
			if ((bool)SunDirectionalLight)
			{
				Vector3 vector = -SunDirectionalLight.transform.forward * 2.5f;
				Vector4 value = new Vector4(vector.x, vector.y, vector.z, SunDirectionalLight.intensity);
				Shader.SetGlobalVector("gVSSunDirection", value);
				Shader.SetGlobalVector("gVSSunSettings", new Vector4(SunDirectionalLight.shadowStrength, SunDirectionalLight.shadowBias, 0f, 0f));
			}
			else
			{
				Shader.SetGlobalVector("gVSSunDirection", Vector4.zero);
				Shader.SetGlobalVector("gVSSunSettings", new Vector4(0f, 0f, 0f, 0f));
			}
		}

		private void InitGlobalShaderProperties()
		{
			float x = Mathf.Clamp(VegetationSettings.GetVegetationDistance(), 20f, VegetationSettings.GetVegetationDistance() - 20f);
			Shader.SetGlobalVector("_VSGrassFade", new Vector4(x, 20f, 0f, 0f));
			Shader.SetGlobalVector("_VSShadowMapFadeScale", new Vector4(QualitySettings.shadowDistance - 30f, 20f, 1f, 1f));
		}

		public void LateUpdate()
		{
			if (InitDone)
			{
				UpdateWind();
				SetShadowMapVariables();
				InitGlobalShaderProperties();
				_prepareVegetationHandle.Complete();
				VerifySplatmapAccess();
				LoadBillboardCells();
				RenderBillboardCells();
				JobHandle jobHandle = default(JobHandle);
				bool flag = VegetationRenderSettings.UseInstancedIndirect();
				if (Application.isPlaying && flag)
				{
					jobHandle = PrepareInstancedIndirectSetupJobs();
				}
				RenderInstancedVegetation();
				if (Application.isPlaying && flag)
				{
					jobHandle.Complete();
					SetupInstancedIndirectComputeBuffers();
					RenderInstancedIndirectVegetation();
				}
				DisposeTemporaryTerrainMemory();
				ReturnVegetationCellTemporaryMemory();
				if (UseCacheCompacter)
				{
					CompactCache();
				}
				OnRenderCompleteDelegate?.Invoke(this);
			}
		}

		private JobHandle PrepareInstancedIndirectSetupJobs()
		{
			VegetationCellSpawner.CellJobHandleList.Clear();
			for (int i = 0; i <= ProcessInstancedIndirectCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = ProcessInstancedIndirectCellList[i];
				for (int j = 0; j <= vegetationCell.VegetationPackageInstancesList.Count - 1; j++)
				{
					for (int k = 0; k <= vegetationCell.VegetationPackageInstancesList[j].VegetationItemMatrixList.Count - 1; k++)
					{
						VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[j].VegetationInfoList[k];
						IndirectInstanceInfo indirectInstanceInfo = vegetationCell.VegetationPackageInstancesList[j].VegetationItemInstancedIndirectInstanceList[k];
						VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[j].VegetationItemModelList[k];
						bool flag = vegetationCell.LoadedBillboards && vegetationItemInfoPro.UseBillboards && vegetationItemInfoPro.VegetationType == VegetationType.Tree;
						if ((vegetationItemModelInfo.DistanceBand >= vegetationCell.LoadedDistanceBand || flag) && vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.InstancedIndirect && !indirectInstanceInfo.Created)
						{
							NativeArray<MatrixInstance> instanceList = vegetationCell.VegetationPackageInstancesList[j].VegetationItemMatrixList[k];
							indirectInstanceInfo.InstancedIndirectInstanceList = new NativeArray<InstancedIndirectInstance>(instanceList.Length, Allocator.Persistent);
							indirectInstanceInfo.Created = true;
							JobHandle value = new CreateInstancedIndirectInstancesJob
							{
								InstanceList = instanceList,
								IndirectInstanceList = indirectInstanceInfo.InstancedIndirectInstanceList
							}.Schedule(indirectInstanceInfo.InstancedIndirectInstanceList.Length, 32);
							VegetationCellSpawner.CellJobHandleList.Add(value);
						}
					}
				}
			}
			JobHandle result = JobHandle.CombineDependencies(VegetationCellSpawner.CellJobHandleList);
			VegetationCellSpawner.CellJobHandleList.Clear();
			JobHandle.ScheduleBatchedJobs();
			return result;
		}

		private void SetupInstancedIndirectComputeBuffers()
		{
			if (!VegetationRenderSettings.UseInstancedIndirect())
			{
				return;
			}
			for (int i = 0; i <= ProcessInstancedIndirectCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = ProcessInstancedIndirectCellList[i];
				for (int j = 0; j <= vegetationCell.VegetationPackageInstancesList.Count - 1; j++)
				{
					for (int k = 0; k <= vegetationCell.VegetationPackageInstancesList[j].VegetationItemMatrixList.Count - 1; k++)
					{
						VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[j].VegetationInfoList[k];
						IndirectInstanceInfo indirectInstanceInfo = vegetationCell.VegetationPackageInstancesList[j].VegetationItemInstancedIndirectInstanceList[k];
						ComputeBufferInfo computeBufferInfo = vegetationCell.VegetationPackageInstancesList[j].VegetationItemComputeBufferList[k];
						VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[j].VegetationItemModelList[k];
						bool flag = vegetationCell.LoadedBillboards && vegetationItemInfoPro.UseBillboards && vegetationItemInfoPro.VegetationType == VegetationType.Tree;
						if ((vegetationItemModelInfo.DistanceBand >= vegetationCell.LoadedDistanceBand || flag) && vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.InstancedIndirect && !computeBufferInfo.Created)
						{
							int num = indirectInstanceInfo.InstancedIndirectInstanceList.Length;
							if (num == 0)
							{
								num = 1;
							}
							computeBufferInfo.ComputeBuffer = new ComputeBuffer(num, 80);
							computeBufferInfo.ComputeBuffer.SetData(indirectInstanceInfo.InstancedIndirectInstanceList);
							computeBufferInfo.Created = true;
						}
					}
				}
			}
			ProcessInstancedIndirectCellList.Clear();
		}

		private void RenderInstancedIndirectVegetation()
		{
			DrawCellsIndirectComputeShader();
		}

		private void DisposeTemporaryTerrainMemory()
		{
			for (int i = 0; i <= VegetationStudioTerrainList.Count - 1; i++)
			{
				VegetationStudioTerrainList[i].DisposeTemporaryMemory();
			}
		}

		private void RenderInstancedVegetation()
		{
			_ = Application.isPlaying;
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].Enabled || VegetationStudioCameraList[i].RenderBillboardsOnly)
				{
					continue;
				}
				Camera targetCamera = (VegetationStudioCameraList[i].RenderDirectToCamera ? VegetationStudioCameraList[i].SelectedCamera : null);
				if (!Application.isPlaying)
				{
					targetCamera = null;
				}
				for (int j = 0; j <= VegetationPackageProList.Count - 1; j++)
				{
					for (int k = 0; k <= VegetationPackageProList[j].VegetationInfoList.Count - 1; k++)
					{
						VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[j].VegetationInfoList[k];
						if (VegetationRenderSettings.UseInstancedIndirect() && vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.InstancedIndirect)
						{
							continue;
						}
						ShadowCastingMode shadowCastingMode = VegetationSettings.GetShadowCastingMode(vegetationItemInfoPro.VegetationType);
						if (vegetationItemInfoPro.DisableShadows)
						{
							shadowCastingMode = ShadowCastingMode.Off;
						}
						LayerMask layer = VegetationSettings.GetLayer(vegetationItemInfoPro.VegetationType);
						VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[j].VegetationItemModelList[k];
						NativeList<Matrix4x4> matrixList = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD0MatrixList[k];
						NativeList<Matrix4x4> matrixList2 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD1MatrixList[k];
						NativeList<Matrix4x4> matrixList3 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD2MatrixList[k];
						NativeList<Matrix4x4> matrixList4 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD3MatrixList[k];
						NativeList<Vector4> lodFadeList = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD0LodFadeList[k];
						NativeList<Vector4> lodFadeList2 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD1LodFadeList[k];
						NativeList<Vector4> lodFadeList3 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD2LodFadeList[k];
						NativeList<Vector4> lodFadeList4 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD3LodFadeList[k];
						if (vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.Normal)
						{
							RenderVegetationItemLODDrawMesh(matrixList, lodFadeList, vegetationItemModelInfo, 0, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLODDrawMesh(matrixList2, lodFadeList2, vegetationItemModelInfo, 1, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLODDrawMesh(matrixList3, lodFadeList3, vegetationItemModelInfo, 2, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLODDrawMesh(matrixList4, lodFadeList4, vegetationItemModelInfo, 3, targetCamera, i, shadowCastingMode, layer);
						}
						else
						{
							RenderVegetationItemLOD(matrixList, lodFadeList, vegetationItemModelInfo, 0, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLOD(matrixList2, lodFadeList2, vegetationItemModelInfo, 1, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLOD(matrixList3, lodFadeList3, vegetationItemModelInfo, 2, targetCamera, i, shadowCastingMode, layer);
							RenderVegetationItemLOD(matrixList4, lodFadeList4, vegetationItemModelInfo, 3, targetCamera, i, shadowCastingMode, layer);
						}
						if (shadowCastingMode == ShadowCastingMode.On)
						{
							NativeList<Matrix4x4> matrixList5 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD0ShadowMatrixList[k];
							NativeList<Matrix4x4> matrixList6 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD1ShadowMatrixList[k];
							NativeList<Matrix4x4> matrixList7 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD2ShadowMatrixList[k];
							NativeList<Matrix4x4> matrixList8 = VegetationStudioCameraList[i].VegetationStudioCameraRenderList[j].VegetationItemLOD3ShadowMatrixList[k];
							if (vegetationItemInfoPro.VegetationRenderMode == VegetationRenderMode.Normal)
							{
								RenderVegetationItemLODDrawMesh(matrixList5, lodFadeList, vegetationItemModelInfo, 0, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLODDrawMesh(matrixList6, lodFadeList2, vegetationItemModelInfo, 1, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLODDrawMesh(matrixList7, lodFadeList3, vegetationItemModelInfo, 2, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLODDrawMesh(matrixList8, lodFadeList4, vegetationItemModelInfo, 3, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
							}
							else
							{
								RenderVegetationItemLOD(matrixList5, lodFadeList, vegetationItemModelInfo, 0, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLOD(matrixList6, lodFadeList2, vegetationItemModelInfo, 1, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLOD(matrixList7, lodFadeList3, vegetationItemModelInfo, 2, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
								RenderVegetationItemLOD(matrixList8, lodFadeList4, vegetationItemModelInfo, 3, targetCamera, i, ShadowCastingMode.ShadowsOnly, layer);
							}
						}
					}
				}
			}
		}

		private void SetupInstancedRenderMaterialPropertiesIDs()
		{
			_unityLODFadeID = Shader.PropertyToID("unity_LODFade");
		}

		private void RenderVegetationItemLODDrawMesh(NativeList<Matrix4x4> matrixList, NativeList<Vector4> lodFadeList, VegetationItemModelInfo vegetationItemModelInfo, int lodIndex, Camera targetCamera, int cameraIndex, ShadowCastingMode shadowCastingMode, LayerMask layer)
		{
			if (matrixList.Length == 0 || lodIndex >= vegetationItemModelInfo.LODCount)
			{
				return;
			}
			Mesh lODMesh = vegetationItemModelInfo.GetLODMesh(lodIndex);
			Material[] lODMaterials = vegetationItemModelInfo.GetLODMaterials(lodIndex);
			MaterialPropertyBlock lODMaterialPropertyBlock = vegetationItemModelInfo.GetLODMaterialPropertyBlock(lodIndex);
			lODMaterialPropertyBlock.Clear();
			if (vegetationItemModelInfo.ShaderControler != null && vegetationItemModelInfo.ShaderControler.Settings.SampleWind)
			{
				MeshRenderer meshRenderer = vegetationItemModelInfo.WindSamplerMeshRendererList[cameraIndex];
				if ((bool)meshRenderer)
				{
					meshRenderer.GetPropertyBlock(lODMaterialPropertyBlock);
				}
			}
			for (int i = 0; i <= matrixList.Length - 1; i++)
			{
				int num = Mathf.Min(lODMesh.subMeshCount, lODMaterials.Length);
				for (int j = 0; j <= num - 1; j++)
				{
					Graphics.DrawMesh(lODMesh, matrixList[i], lODMaterials[j], layer, targetCamera, j, lODMaterialPropertyBlock, shadowCastingMode, receiveShadows: true, null, LightProbeUsage.Off);
				}
			}
		}

		private void RenderVegetationItemLOD(NativeList<Matrix4x4> matrixList, NativeList<Vector4> lodFadeList, VegetationItemModelInfo vegetationItemModelInfo, int lodIndex, Camera targetCamera, int cameraIndex, ShadowCastingMode shadowCastingMode, LayerMask layer)
		{
			if (matrixList.Length == 0 || lodIndex >= vegetationItemModelInfo.LODCount)
			{
				return;
			}
			int num = Mathf.CeilToInt((float)matrixList.Length / 1000f);
			int num2 = matrixList.Length;
			for (int i = 0; i <= num - 1; i++)
			{
				int num3 = 1000;
				if (num2 < 1000)
				{
					num3 = num2;
				}
				new NativeSlice<Matrix4x4>(matrixList, i * 1000, num3).CopyToFast(_renderArray);
				Mesh lODMesh = vegetationItemModelInfo.GetLODMesh(lodIndex);
				Material[] lODMaterials = vegetationItemModelInfo.GetLODMaterials(lodIndex);
				MaterialPropertyBlock lODMaterialPropertyBlock = vegetationItemModelInfo.GetLODMaterialPropertyBlock(lodIndex);
				lODMaterialPropertyBlock.Clear();
				if (vegetationItemModelInfo.ShaderControler != null && vegetationItemModelInfo.ShaderControler.Settings.SampleWind)
				{
					MeshRenderer meshRenderer = vegetationItemModelInfo.WindSamplerMeshRendererList[cameraIndex];
					if ((bool)meshRenderer)
					{
						meshRenderer.GetPropertyBlock(lODMaterialPropertyBlock);
					}
				}
				if (shadowCastingMode != ShadowCastingMode.ShadowsOnly && lodFadeList.Length == matrixList.Length)
				{
					new NativeSlice<Vector4>(lodFadeList, i * 1000, num3).CopyToFast(_renderLodFadeArray);
					lODMaterialPropertyBlock.SetVectorArray(_unityLODFadeID, _renderLodFadeArray);
				}
				if (VegetationRenderSettings.EnableInstancedRenderingLayers)
				{
					lODMaterialPropertyBlock.SetFloatArray(UnityRenderingLayerID, _renderingLayerArray);
				}
				int num4 = Mathf.Min(lODMesh.subMeshCount, lODMaterials.Length);
				for (int j = 0; j <= num4 - 1; j++)
				{
					Graphics.DrawMeshInstanced(lODMesh, j, lODMaterials[j], _renderArray, num3, lODMaterialPropertyBlock, shadowCastingMode, receiveShadows: true, layer, targetCamera, LightProbeUsage.Off);
				}
				num2 -= 1000;
			}
		}

		private void OnDisable()
		{
			VegetationStudioManager.UnregisterVegetationSystem(this);
			DisableEditorApi();
			DisposeVegetationStudioCameras();
			RemoveVegetationStudioCameraDelegates();
			DisposeVegetationCells();
			DisposeBillboardCells();
			ClearVegetationItemModels();
			DisposeComputeShaders();
			VegetationCellSpawner.Dispose();
			InitDone = false;
		}

		private void DisposeBillboardCells()
		{
			_prepareVegetationHandle.Complete();
			for (int i = 0; i <= BillboardCellList.Count - 1; i++)
			{
				BillboardCellList[i].Dispose();
			}
			BillboardCellList.Clear();
		}

		public void UpdateBillboardCulling()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].UpdateBillboardCullingGroup();
			}
		}

		public void RefreshBillboards()
		{
		}

		private void LoadBillboardCells()
		{
			_loadBillboardCellList.Clear();
			_billboardTempVegetationCellList.Clear();
			VegetationCellSpawner.CellJobHandleList.Clear();
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].Enabled)
				{
					continue;
				}
				for (int j = 0; j <= VegetationStudioCameraList[i].BillboardJobCullingGroup.VisibleCellIndexList.Length - 1; j++)
				{
					int index = VegetationStudioCameraList[i].BillboardJobCullingGroup.VisibleCellIndexList[j];
					BillboardCell billboardCell = BillboardCellList[index];
					if (!billboardCell.Loaded)
					{
						billboardCell.OverlapVegetationCells.Clear();
						VegetationCellQuadTree.Query(billboardCell.Rectangle, billboardCell.OverlapVegetationCells);
						_billboardTempVegetationCellList.AddRange(billboardCell.OverlapVegetationCells);
						if (!_loadBillboardCellList.Contains(billboardCell))
						{
							_loadBillboardCellList.Add(billboardCell);
						}
					}
				}
			}
			for (int k = 0; k <= _billboardTempVegetationCellList.Count - 1; k++)
			{
				VegetationCell vegetationCell = _billboardTempVegetationCellList[k];
				if (vegetationCell.LoadedDistanceBand > 1 && !vegetationCell.LoadedBillboards)
				{
					if (!Application.isPlaying && !vegetationCell.Prepared)
					{
						VegetationCellSpawner.PrepareVegetationCell(vegetationCell);
					}
					bool hasInstancedIndirect;
					JobHandle value = VegetationCellSpawner.SpawnVegetationCell(vegetationCell, 1, out hasInstancedIndirect, billboardsOnly: true);
					CompactMemoryCellList.Add(vegetationCell);
					LoadedVegetationCellList.Add(vegetationCell);
					VegetationCellSpawner.CellJobHandleList.Add(value);
					if (hasInstancedIndirect)
					{
						ProcessInstancedIndirectCellList.Add(vegetationCell);
					}
				}
			}
			JobHandle jobHandle = JobHandle.CombineDependencies(VegetationCellSpawner.CellJobHandleList);
			VegetationCellSpawner.CellJobHandleList.Clear();
			for (int l = 0; l <= _loadBillboardCellList.Count - 1; l++)
			{
				BillboardCell billboardCell2 = _loadBillboardCellList[l];
				if (billboardCell2.Loaded)
				{
					continue;
				}
				for (int m = 0; m <= billboardCell2.VegetationPackageBillboardInstancesList.Count - 1; m++)
				{
					for (int n = 0; n <= billboardCell2.VegetationPackageBillboardInstancesList[m].BillboardInstanceList.Count - 1; n++)
					{
						VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[m].VegetationInfoList[n];
						if (vegetationItemInfoPro.VegetationType != VegetationType.Tree)
						{
							continue;
						}
						BillboardInstance billboardInstance = billboardCell2.VegetationPackageBillboardInstancesList[m].BillboardInstanceList[n];
						if (!billboardInstance.Loaded)
						{
							JobHandle dependsOn = jobHandle;
							for (int num = 0; num <= billboardCell2.OverlapVegetationCells.Count - 1; num++)
							{
								NativeList<MatrixInstance> inputNativeList = billboardCell2.OverlapVegetationCells[num].VegetationPackageInstancesList[m].VegetationItemMatrixList[n];
								dependsOn = new MergeCellInstancesJob
								{
									OutputNativeList = billboardInstance.InstanceList,
									InputNativeList = inputNativeList
								}.Schedule(dependsOn);
							}
							float vegetationItemSize = Mathf.Max(vegetationItemInfoPro.Bounds.extents.x, vegetationItemInfoPro.Bounds.extents.y, vegetationItemInfoPro.Bounds.extents.z) * 2f;
							dependsOn = new BillboardGenerator.CreateBillboardMeshJob
							{
								InstanceList = billboardInstance.InstanceList,
								VerticeList = billboardInstance.VerticeList,
								NormalList = billboardInstance.NormalList,
								UvList = billboardInstance.UvList,
								Uv2List = billboardInstance.Uv2List,
								Uv3List = billboardInstance.Uv3List,
								IndexList = billboardInstance.IndexList,
								BoundsYExtent = vegetationItemInfoPro.Bounds.extents.y,
								VegetationItemSize = vegetationItemSize
							}.Schedule(dependsOn);
							VegetationCellSpawner.CellJobHandleList.Add(dependsOn);
						}
					}
				}
			}
			JobHandle jobHandle2 = JobHandle.CombineDependencies(VegetationCellSpawner.CellJobHandleList);
			VegetationCellSpawner.CellJobHandleList.Clear();
			jobHandle.Complete();
			jobHandle2.Complete();
			for (int num2 = 0; num2 <= _loadBillboardCellList.Count - 1; num2++)
			{
				BillboardCell billboardCell3 = _loadBillboardCellList[num2];
				if (billboardCell3.Loaded)
				{
					continue;
				}
				for (int num3 = 0; num3 <= billboardCell3.VegetationPackageBillboardInstancesList.Count - 1; num3++)
				{
					for (int num4 = 0; num4 <= billboardCell3.VegetationPackageBillboardInstancesList[num3].BillboardInstanceList.Count - 1; num4++)
					{
						BillboardInstance billboardInstance2 = billboardCell3.VegetationPackageBillboardInstancesList[num3].BillboardInstanceList[num4];
						if (!billboardInstance2.Loaded)
						{
							billboardInstance2.InstanceCount = billboardInstance2.InstanceList.Length;
							if (billboardInstance2.InstanceCount > 0)
							{
								billboardInstance2.Mesh = BillboardGenerator.CreateMeshFromBillboardInstance(billboardInstance2);
							}
							billboardInstance2.Loaded = true;
						}
					}
				}
				billboardCell3.Loaded = true;
			}
			_loadBillboardCellList.Clear();
		}

		private void ClearBillboardCellsCache()
		{
			for (int i = 0; i <= BillboardCellList.Count - 1; i++)
			{
				BillboardCellList[i].ClearCache();
			}
		}

		private void ClearBillboardCellsCache(int vegetationPackageIndex, int vegetationItemIndex)
		{
			for (int i = 0; i <= BillboardCellList.Count - 1; i++)
			{
				BillboardCellList[i].ClearCache(vegetationPackageIndex, vegetationItemIndex);
			}
		}

		private void ClearBillboardCellsCache(Bounds bounds)
		{
			_prepareVegetationHandle.Complete();
			if (BillboardCellQuadTree != null)
			{
				Rect area = RectExtension.CreateRectFromBounds(bounds);
				List<BillboardCell> list = new List<BillboardCell>();
				BillboardCellQuadTree.Query(area, list);
				for (int i = 0; i <= list.Count - 1; i++)
				{
					list[i].ClearCache();
				}
			}
		}

		private void ClearBillboardCellsCache(Bounds bounds, int vegetationPackageIndex, int vegetationItemIndex)
		{
			Rect area = RectExtension.CreateRectFromBounds(bounds);
			_prepareVegetationHandle.Complete();
			List<BillboardCell> list = new List<BillboardCell>();
			BillboardCellQuadTree.Query(area, list);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				list[i].ClearCache(vegetationPackageIndex, vegetationItemIndex);
			}
		}

		private void SetupBillboardShaderIDs()
		{
			_cameraPositionID = Shader.PropertyToID("_CameraPosition");
			_cullDistanceID = Shader.PropertyToID("_CullDistance");
			_farCullDistanceID = Shader.PropertyToID("_FarCullDistance");
		}

		public void RenderBillboardCells()
		{
			int value = Mathf.RoundToInt(VegetationSettings.GetBillboardDistance());
			bool isPlaying = Application.isPlaying;
			ShadowCastingMode billboardShadowCastingMode = VegetationSettings.GetBillboardShadowCastingMode();
			LayerMask billboardLayer = VegetationSettings.GetBillboardLayer();
			Matrix4x4 matrix = Matrix4x4.TRS(FloatingOriginOffset, Quaternion.identity, Vector3.one);
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].Enabled)
				{
					continue;
				}
				Camera camera = (VegetationStudioCameraList[i].RenderDirectToCamera ? VegetationStudioCameraList[i].SelectedCamera : null);
				if (!isPlaying)
				{
					camera = null;
				}
				for (int j = 0; j <= VegetationStudioCameraList[i].BillboardJobCullingGroup.VisibleCellIndexList.Length - 1; j++)
				{
					int index = VegetationStudioCameraList[i].BillboardJobCullingGroup.VisibleCellIndexList[j];
					BillboardCell billboardCell = BillboardCellList[index];
					for (int k = 0; k <= billboardCell.VegetationPackageBillboardInstancesList.Count - 1; k++)
					{
						for (int l = 0; l <= billboardCell.VegetationPackageBillboardInstancesList[k].BillboardInstanceList.Count - 1; l++)
						{
							BillboardInstance billboardInstance = billboardCell.VegetationPackageBillboardInstancesList[k].BillboardInstanceList[l];
							if (!billboardInstance.Loaded || billboardInstance.InstanceCount <= 0 || VegetationStudioCameraList[i].SelectedCamera == null)
							{
								continue;
							}
							VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[k].VegetationItemModelList[l];
							VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[k].VegetationInfoList[l];
							if (vegetationItemInfoPro.UseBillboards)
							{
								Vector3 position = VegetationStudioCameraList[i].SelectedCamera.transform.position;
								float num = vegetationItemInfoPro.RenderDistanceFactor;
								if (VegetationSettings.DisableRenderDistanceFactor)
								{
									num = 1f;
								}
								int num2 = Mathf.RoundToInt(VegetationSettings.GetTreeDistance() * num);
								if (vegetationItemModelInfo.BillboardLODFadeCrossfade)
								{
									num2 -= 10;
								}
								MaterialPropertyBlock materialPropertyBlock = vegetationItemModelInfo.CameraBillboardMaterialPropertyBlockList[i];
								materialPropertyBlock.SetVector(_cameraPositionID, position);
								materialPropertyBlock.SetInt(_cullDistanceID, (!VegetationStudioCameraList[i].RenderBillboardsOnly) ? num2 : 0);
								materialPropertyBlock.SetInt(_farCullDistanceID, value);
								materialPropertyBlock.SetFloat(_nearFadeDistanceID, VegetationRenderSettings.CrossFadeDistance);
								Graphics.DrawMesh(billboardInstance.Mesh, matrix, vegetationItemModelInfo.BillboardMaterial, billboardLayer, camera, 0, materialPropertyBlock, billboardShadowCastingMode, receiveShadows: true);
							}
						}
					}
				}
			}
		}

		private void PrepareAllBillboardCells()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				for (int j = 0; j <= BillboardCellList.Count - 1; j++)
				{
					BillboardCell billboardCell = BillboardCellList[j];
					if (!billboardCell.Prepared)
					{
						billboardCell.PrepareBillboardCell(VegetationPackageProList);
					}
				}
			}
		}

		private void CreateBillboardCells()
		{
			DisposeBillboardCells();
			Bounds bounds = new Bounds(VegetationSystemBounds.center, VegetationSystemBounds.size);
			float num = BillboardCellSize;
			if (!Application.isPlaying)
			{
				num = 400f;
			}
			bounds.Expand(new Vector3(num * 2f, 0f, num * 2f));
			BillboardCellQuadTree = new QuadTree<BillboardCell>(RectExtension.CreateRectFromBounds(bounds));
			int num2 = Mathf.CeilToInt(VegetationSystemBounds.size.x / num);
			int num3 = Mathf.CeilToInt(VegetationSystemBounds.size.z / num);
			Vector2 vector = new Vector2(VegetationSystemBounds.center.x - VegetationSystemBounds.size.x / 2f, VegetationSystemBounds.center.z - VegetationSystemBounds.size.z / 2f);
			for (int i = 0; i <= num2 - 1; i++)
			{
				for (int j = 0; j <= num3 - 1; j++)
				{
					BillboardCell billboardCell = new BillboardCell(new Rect(new Vector2(num * (float)i + vector.x, num * (float)j + vector.y), new Vector2(num, num)), VegetationSystemBounds.center.y, VegetationSystemBounds.size.y);
					BillboardCellList.Add(billboardCell);
					billboardCell.Index = BillboardCellList.Count - 1;
					BillboardCellQuadTree.Insert(billboardCell);
				}
			}
			PrepareAllBillboardCells();
		}

		private void CompactCache()
		{
			CompactVegetationCellCache();
		}

		private void CompactVegetationCellCache()
		{
			for (int i = 0; i <= LoadedVegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = LoadedVegetationCellList[i];
				vegetationCell.FlagForRemoval = vegetationCell.Prepared;
			}
			for (int j = 0; j <= VegetationStudioCameraList.Count - 1; j++)
			{
				VegetationStudioCamera vegetationStudioCamera = VegetationStudioCameraList[j];
				if (vegetationStudioCamera.Enabled)
				{
					for (int k = 0; k <= vegetationStudioCamera.PotentialVisibleVegetationCellList.Count - 1; k++)
					{
						vegetationStudioCamera.PotentialVisibleVegetationCellList[k].FlagForRemoval = false;
					}
				}
			}
			PredictiveCellLoader.RemoveCellsFlaggedForRemoval();
			int num = 0;
			for (int num2 = LoadedVegetationCellList.Count - 1; num2 >= 0; num2--)
			{
				if (LoadedVegetationCellList[num2].FlagForRemoval)
				{
					num++;
					LoadedVegetationCellList[num2].ClearCache();
					OnClearCacheVegetationCellDelegate?.Invoke(this, LoadedVegetationCellList[num2]);
					LoadedVegetationCellList.RemoveAtSwapBack(num2);
				}
			}
			_ = 0;
		}

		private void CompactBillboardCellCache()
		{
		}

		public void AddCamera(Camera aCamera, bool noFrustumCulling = false, bool renderDirectToCamera = false, bool renderBillboardsOnly = false)
		{
			_prepareVegetationHandle.Complete();
			VegetationStudioCamera vegetationStudioCamera = GetVegetationStudioCamera(aCamera);
			if (vegetationStudioCamera == null)
			{
				vegetationStudioCamera = new VegetationStudioCamera(aCamera)
				{
					CameraCullingMode = CameraCullingMode.Frustum,
					RenderDirectToCamera = renderDirectToCamera,
					RenderBillboardsOnly = renderBillboardsOnly,
					VegetationSystemPro = this
				};
				AddVegetationStudioCamera(vegetationStudioCamera);
			}
			SetupWindSamplers();
			SetupVegetationItemModelsPerCameraBuffers();
		}

		private void AddVegetationStudioCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			VegetationStudioCameraList.Add(vegetationStudioCamera);
			OnAddCameraDelegate?.Invoke(vegetationStudioCamera);
			RefreshColliderSystem();
			RefreshRuntimePrefabSpawner();
		}

		public void RemoveCamera(Camera aCamera)
		{
			_prepareVegetationHandle.Complete();
			VegetationStudioCamera vegetationStudioCamera = GetVegetationStudioCamera(aCamera);
			if (vegetationStudioCamera != null)
			{
				RemoveVegetationStudioCamera(vegetationStudioCamera);
			}
			SetupWindSamplers();
			SetupVegetationItemModelsPerCameraBuffers();
			RefreshColliderSystem();
			RefreshRuntimePrefabSpawner();
		}

		private void RemoveVegetationStudioCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			vegetationStudioCamera.Dispose();
			VegetationStudioCameraList.Remove(vegetationStudioCamera);
			OnRemoveCameraDelegate?.Invoke(vegetationStudioCamera);
		}

		public VegetationStudioCamera GetVegetationStudioCamera(Camera aCamera)
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (VegetationStudioCameraList[i].SelectedCamera == aCamera)
				{
					return VegetationStudioCameraList[i];
				}
			}
			return null;
		}

		public VegetationStudioCamera GetSceneViewVegetationStudioCamera()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (VegetationStudioCameraList[i].VegetationStudioCameraType == VegetationStudioCameraType.SceneView)
				{
					return VegetationStudioCameraList[i];
				}
			}
			return null;
		}

		public void DisposeVegetationStudioCameras()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].Dispose();
			}
		}

		public void RemoveVegetationStudioCameraDelegates()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].Dispose();
			}
		}

		private void SetVegetationStudioCamerasDirty()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].SetDirty();
			}
		}

		private void SetFrustumCullingPlanes(Camera selectedCamera)
		{
			GeometryUtilityAllocFree.CalculateFrustrumPlanes(selectedCamera);
			Vector4 val = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[0].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[0].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[0].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[0].distance);
			Vector4 val2 = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[1].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[1].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[1].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[1].distance);
			Vector4 val3 = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[2].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[2].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[2].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[2].distance);
			Vector4 val4 = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[3].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[3].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[3].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[3].distance);
			Vector4 val5 = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[4].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[4].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[4].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[4].distance);
			Vector4 val6 = new Vector4(GeometryUtilityAllocFree.FrustrumPlanes[5].normal.x, GeometryUtilityAllocFree.FrustrumPlanes[5].normal.y, GeometryUtilityAllocFree.FrustrumPlanes[5].normal.z, GeometryUtilityAllocFree.FrustrumPlanes[5].distance);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan0, val);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan1, val2);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan2, val3);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan3, val4);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan4, val5);
			FrusumMatrixShader.SetVector(_cameraFrustumPlan5, val6);
			Vector3 position = selectedCamera.transform.position;
			Vector4 val7 = new Vector4(position.x, position.y, position.z, 1f);
			FrusumMatrixShader.SetVector("_WorldSpaceCameraPos", val7);
		}

		private void SetupComputeShaders()
		{
			_dummyComputeBuffer = new ComputeBuffer(1, 80, ComputeBufferType.Default);
			MergeBufferShader = (ComputeShader)Resources.Load("MergeInstancedIndirectBuffers");
			MergeBufferKernelHandle = MergeBufferShader.FindKernel("MergeInstancedIndirectBuffers");
			FrusumMatrixShader = (ComputeShader)Resources.Load("GPUFrustumCulling");
			FrustumKernelHandle = FrusumMatrixShader.FindKernel("GPUFrustumCulling");
			_mergeBufferID = Shader.PropertyToID("MergeBuffer");
			_floatingOriginOffsetID = Shader.PropertyToID("_FloatingOriginOffset");
			_mergeSourceBuffer0ID = Shader.PropertyToID("MergeSourceBuffer0");
			_mergeSourceBuffer1ID = Shader.PropertyToID("MergeSourceBuffer1");
			_mergeSourceBuffer2ID = Shader.PropertyToID("MergeSourceBuffer2");
			_mergeSourceBuffer3ID = Shader.PropertyToID("MergeSourceBuffer3");
			_mergeSourceBuffer4ID = Shader.PropertyToID("MergeSourceBuffer4");
			_mergeSourceBuffer5ID = Shader.PropertyToID("MergeSourceBuffer5");
			_mergeSourceBuffer6ID = Shader.PropertyToID("MergeSourceBuffer6");
			_mergeSourceBuffer7ID = Shader.PropertyToID("MergeSourceBuffer7");
			_mergeSourceBuffer8ID = Shader.PropertyToID("MergeSourceBuffer8");
			_mergeSourceBuffer9ID = Shader.PropertyToID("MergeSourceBuffer9");
			_mergeSourceBuffer10ID = Shader.PropertyToID("MergeSourceBuffer10");
			_mergeSourceBuffer11ID = Shader.PropertyToID("MergeSourceBuffer11");
			_mergeSourceBuffer12ID = Shader.PropertyToID("MergeSourceBuffer12");
			_mergeSourceBuffer13ID = Shader.PropertyToID("MergeSourceBuffer13");
			_mergeSourceBuffer14ID = Shader.PropertyToID("MergeSourceBuffer14");
			_mergeInstanceCount0ID = Shader.PropertyToID("MergeSourceBufferCount0");
			_mergeInstanceCount1ID = Shader.PropertyToID("MergeSourceBufferCount1");
			_mergeInstanceCount2ID = Shader.PropertyToID("MergeSourceBufferCount2");
			_mergeInstanceCount3ID = Shader.PropertyToID("MergeSourceBufferCount3");
			_mergeInstanceCount4ID = Shader.PropertyToID("MergeSourceBufferCount4");
			_mergeInstanceCount5ID = Shader.PropertyToID("MergeSourceBufferCount5");
			_mergeInstanceCount6ID = Shader.PropertyToID("MergeSourceBufferCount6");
			_mergeInstanceCount7ID = Shader.PropertyToID("MergeSourceBufferCount7");
			_mergeInstanceCount8ID = Shader.PropertyToID("MergeSourceBufferCount8");
			_mergeInstanceCount9ID = Shader.PropertyToID("MergeSourceBufferCount9");
			_mergeInstanceCount10ID = Shader.PropertyToID("MergeSourceBufferCount10");
			_mergeInstanceCount11ID = Shader.PropertyToID("MergeSourceBufferCount11");
			_mergeInstanceCount12ID = Shader.PropertyToID("MergeSourceBufferCount12");
			_mergeInstanceCount13ID = Shader.PropertyToID("MergeSourceBufferCount13");
			_mergeInstanceCount14ID = Shader.PropertyToID("MergeSourceBufferCount14");
			_cameraFrustumPlan0 = Shader.PropertyToID("_VS_CameraFrustumPlane0");
			_cameraFrustumPlan1 = Shader.PropertyToID("_VS_CameraFrustumPlane1");
			_cameraFrustumPlan2 = Shader.PropertyToID("_VS_CameraFrustumPlane2");
			_cameraFrustumPlan3 = Shader.PropertyToID("_VS_CameraFrustumPlane3");
			_cameraFrustumPlan4 = Shader.PropertyToID("_VS_CameraFrustumPlane4");
			_cameraFrustumPlan5 = Shader.PropertyToID("_VS_CameraFrustumPlane5");
			_instanceCountID = Shader.PropertyToID("_InstanceCount");
			_sourceBufferID = Shader.PropertyToID("SourceShaderDataBuffer");
			_visibleBufferLod0ID = Shader.PropertyToID("VisibleBufferLOD0");
			_visibleBufferLod1ID = Shader.PropertyToID("VisibleBufferLOD1");
			_visibleBufferLod2ID = Shader.PropertyToID("VisibleBufferLOD2");
			_visibleBufferLod3ID = Shader.PropertyToID("VisibleBufferLOD3");
			_shadowBufferLod0ID = Shader.PropertyToID("ShadowBufferLOD0");
			_shadowBufferLod1ID = Shader.PropertyToID("ShadowBufferLOD1");
			_shadowBufferLod2ID = Shader.PropertyToID("ShadowBufferLOD2");
			_shadowBufferLod3ID = Shader.PropertyToID("ShadowBufferLOD3");
			_lightDirection = Shader.PropertyToID("_LightDirection");
			_planeOrigin = Shader.PropertyToID("_PlaneOrigin");
			_boundsSize = Shader.PropertyToID("_BoundsSize");
			_cullFarStartID = Shader.PropertyToID("_CullFarStart");
			_visibleShaderDataBufferID = Shader.PropertyToID("VisibleShaderDataBuffer");
			_indirectShaderDataBufferID = Shader.PropertyToID("IndirectShaderDataBuffer");
			_useLodsID = Shader.PropertyToID("UseLODs");
			_noFrustumCullingID = Shader.PropertyToID("NoFrustumCulling");
			_shadowCullingID = Shader.PropertyToID("ShadowCulling");
			_boundingSphereRadiusID = Shader.PropertyToID("_BoundingSphereRadius");
			_lod1Distance = Shader.PropertyToID("_LOD1Distance");
			_lod2Distance = Shader.PropertyToID("_LOD2Distance");
			_lod3Distance = Shader.PropertyToID("_LOD3Distance");
			_lodFactor = Shader.PropertyToID("_LODFactor");
			_lodBias = Shader.PropertyToID("_LODBias");
			_lodFadeDistance = Shader.PropertyToID("_LODFadeDistance");
			_lodCount = Shader.PropertyToID("_LODCount");
		}

		private void DisposeComputeShaders()
		{
			_dummyComputeBuffer?.Dispose();
		}

		private void DrawCellsIndirectComputeShader()
		{
			float val = QualitySettings.lodBias * VegetationSettings.LODDistanceFactor;
			Vector4 val2 = new Vector4(FloatingOriginOffset.x, FloatingOriginOffset.y, FloatingOriginOffset.z, 0f);
			Vector3 vector = (SunDirectionalLight ? SunDirectionalLight.transform.forward : new Vector3(0f, 0f, 0f));
			float y = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y;
			Vector3 vector2 = new Vector3(0f, y, 0f);
			bool flag = SunDirectionalLight != null;
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].Enabled || VegetationStudioCameraList[i].RenderBillboardsOnly)
				{
					continue;
				}
				SetFrustumCullingPlanes(VegetationStudioCameraList[i].SelectedCamera);
				Camera selectedCamera = (VegetationStudioCameraList[i].RenderDirectToCamera ? VegetationStudioCameraList[i].SelectedCamera : null);
				for (int j = 0; j <= VegetationPackageProList.Count - 1; j++)
				{
					for (int k = 0; k <= VegetationPackageProList[j].VegetationInfoList.Count - 1; k++)
					{
						VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[j].VegetationInfoList[k];
						if (vegetationItemInfoPro.VegetationRenderMode != VegetationRenderMode.InstancedIndirect)
						{
							continue;
						}
						VegetationItemModelInfo vegetationItemModelInfo = VegetationPackageProModelsList[j].VegetationItemModelList[k];
						float num = vegetationItemModelInfo.VegetationItemInfo.RenderDistanceFactor;
						if (VegetationSettings.DisableRenderDistanceFactor)
						{
							num = 1f;
						}
						float num2 = ((vegetationItemModelInfo.VegetationItemInfo.VegetationType != VegetationType.Tree && vegetationItemModelInfo.VegetationItemInfo.VegetationType != VegetationType.LargeObjects) ? (VegetationSettings.GetVegetationDistance() * num) : (VegetationSettings.GetTreeDistance() * num));
						ShadowCastingMode shadowCastingMode = VegetationSettings.GetShadowCastingMode(vegetationItemInfoPro.VegetationType);
						if (vegetationItemInfoPro.DisableShadows)
						{
							shadowCastingMode = ShadowCastingMode.Off;
						}
						bool val3 = flag && shadowCastingMode == ShadowCastingMode.On && vegetationItemModelInfo.DistanceBand == 1;
						LayerMask layer = VegetationSettings.GetLayer(vegetationItemInfoPro.VegetationType);
						int num3 = 0;
						_hasBufferList.Clear();
						for (int l = 0; l <= VegetationStudioCameraList[i].JobCullingGroup.VisibleCellIndexList.Length - 1; l++)
						{
							int num4 = VegetationStudioCameraList[i].JobCullingGroup.VisibleCellIndexList[l];
							VegetationCell vegetationCell = VegetationStudioCameraList[i].PotentialVisibleVegetationCellList[num4];
							BoundingSphereInfo boundingSphereInfo = VegetationStudioCameraList[i].GetBoundingSphereInfo(num4);
							int distanceBand = vegetationItemModelInfo.DistanceBand;
							if (boundingSphereInfo.CurrentDistanceBand <= distanceBand && vegetationCell.VegetationPackageInstancesList[j].VegetationItemMatrixList[k].Length != 0 && vegetationCell.VegetationPackageInstancesList[j].VegetationItemComputeBufferList[k].Created)
							{
								_hasBufferList.Add(vegetationCell);
							}
						}
						if (_hasBufferList.Count == 0)
						{
							continue;
						}
						int num5 = 15;
						for (int m = 0; m <= _hasBufferList.Count - 1; m++)
						{
							num3 += _hasBufferList[m].VegetationPackageInstancesList[j].VegetationItemMatrixList[k].Length;
						}
						if (num3 == 0)
						{
							continue;
						}
						CameraComputeBuffers cameraComputeBuffers = vegetationItemModelInfo.CameraComputeBufferList[i];
						if (VegetationRenderSettings.EnableSinglePassInstancedVR)
						{
							if (num3 * 2 > cameraComputeBuffers.MergeBuffer.count)
							{
								cameraComputeBuffers.UpdateComputeBufferSize(num3 * 2 + 5000);
							}
						}
						else if (num3 > cameraComputeBuffers.MergeBuffer.count)
						{
							cameraComputeBuffers.UpdateComputeBufferSize(num3 + 5000);
						}
						cameraComputeBuffers.MergeBuffer.SetCounterValue(0u);
						MergeBufferShader.SetBuffer(MergeBufferKernelHandle, _mergeBufferID, cameraComputeBuffers.MergeBuffer);
						for (int n = 0; n <= _hasBufferList.Count - 1; n += num5)
						{
							int num6 = _hasBufferList[n].VegetationPackageInstancesList[j].VegetationItemMatrixList[k].Length;
							for (int num7 = 1; num7 <= num5 - 1; num7++)
							{
								if (n + num7 < _hasBufferList.Count)
								{
									int length = _hasBufferList[n + num7].VegetationPackageInstancesList[j].VegetationItemMatrixList[k].Length;
									if (length > num6)
									{
										num6 = length;
									}
								}
							}
							int num8 = Mathf.CeilToInt((float)num6 / 32f);
							if (num8 != 0)
							{
								SetComputeShaderBuffer(_mergeSourceBuffer0ID, _mergeInstanceCount0ID, n, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer1ID, _mergeInstanceCount1ID, n + 1, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer2ID, _mergeInstanceCount2ID, n + 2, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer3ID, _mergeInstanceCount3ID, n + 3, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer4ID, _mergeInstanceCount4ID, n + 4, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer5ID, _mergeInstanceCount5ID, n + 5, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer6ID, _mergeInstanceCount6ID, n + 6, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer7ID, _mergeInstanceCount7ID, n + 7, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer8ID, _mergeInstanceCount8ID, n + 8, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer9ID, _mergeInstanceCount9ID, n + 9, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer10ID, _mergeInstanceCount10ID, n + 10, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer11ID, _mergeInstanceCount11ID, n + 11, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer12ID, _mergeInstanceCount12ID, n + 12, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer13ID, _mergeInstanceCount13ID, n + 13, j, k);
								SetComputeShaderBuffer(_mergeSourceBuffer14ID, _mergeInstanceCount14ID, n + 14, j, k);
								MergeBufferShader.Dispatch(MergeBufferKernelHandle, num8, 1, 1);
							}
						}
						for (int num9 = 0; num9 <= vegetationItemModelInfo.VegetationMeshLod0.subMeshCount - 1; num9++)
						{
							ComputeBuffer.CopyCount(cameraComputeBuffers.MergeBuffer, cameraComputeBuffers.ArgsBufferMergedLOD0List[num9], 4);
						}
						int num10 = Mathf.CeilToInt((float)num3 / 32f);
						if (num10 == 0)
						{
							continue;
						}
						cameraComputeBuffers.VisibleBufferLOD0.SetCounterValue(0u);
						cameraComputeBuffers.VisibleBufferLOD1.SetCounterValue(0u);
						cameraComputeBuffers.VisibleBufferLOD2.SetCounterValue(0u);
						cameraComputeBuffers.VisibleBufferLOD3.SetCounterValue(0u);
						cameraComputeBuffers.ShadowBufferLOD0.SetCounterValue(0u);
						cameraComputeBuffers.ShadowBufferLOD1.SetCounterValue(0u);
						cameraComputeBuffers.ShadowBufferLOD2.SetCounterValue(0u);
						cameraComputeBuffers.ShadowBufferLOD3.SetCounterValue(0u);
						bool flag2 = true;
						FrusumMatrixShader.SetFloat(_cullFarStartID, num2);
						FrusumMatrixShader.SetVector(_floatingOriginOffsetID, val2);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _sourceBufferID, cameraComputeBuffers.MergeBuffer);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _visibleBufferLod0ID, cameraComputeBuffers.VisibleBufferLOD0);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _visibleBufferLod1ID, cameraComputeBuffers.VisibleBufferLOD1);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _visibleBufferLod2ID, cameraComputeBuffers.VisibleBufferLOD2);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _visibleBufferLod3ID, cameraComputeBuffers.VisibleBufferLOD3);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _shadowBufferLod0ID, cameraComputeBuffers.ShadowBufferLOD0);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _shadowBufferLod1ID, cameraComputeBuffers.ShadowBufferLOD1);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _shadowBufferLod2ID, cameraComputeBuffers.ShadowBufferLOD2);
						FrusumMatrixShader.SetBuffer(FrustumKernelHandle, _shadowBufferLod3ID, cameraComputeBuffers.ShadowBufferLOD3);
						FrusumMatrixShader.SetInt(_instanceCountID, num3);
						FrusumMatrixShader.SetBool(_useLodsID, flag2);
						FrusumMatrixShader.SetBool(_noFrustumCullingID, VegetationStudioCameraList[i].CameraCullingMode == CameraCullingMode.Complete360);
						FrusumMatrixShader.SetBool(_shadowCullingID, val3);
						FrusumMatrixShader.SetFloat(_boundingSphereRadiusID, vegetationItemModelInfo.BoundingSphereRadius);
						FrusumMatrixShader.SetFloat(_lod1Distance, vegetationItemModelInfo.LOD1Distance);
						FrusumMatrixShader.SetFloat(_lod2Distance, vegetationItemModelInfo.LOD2Distance);
						FrusumMatrixShader.SetFloat(_lod3Distance, vegetationItemModelInfo.LOD3Distance);
						FrusumMatrixShader.SetVector(_lightDirection, vector);
						FrusumMatrixShader.SetVector(_planeOrigin, vector2);
						FrusumMatrixShader.SetVector(_boundsSize, vegetationItemModelInfo.VegetationItemInfo.Bounds.size);
						FrusumMatrixShader.SetFloat(_lodFactor, vegetationItemInfoPro.LODFactor);
						FrusumMatrixShader.SetFloat(_lodBias, val);
						float val4 = 0f;
						if (vegetationItemModelInfo.VegetationItemInfo.EnableCrossFade)
						{
							val4 = VegetationRenderSettings.CrossFadeDistance;
						}
						FrusumMatrixShader.SetFloat(_lodFadeDistance, val4);
						FrusumMatrixShader.SetInt(_lodCount, vegetationItemModelInfo.LODCount);
						FrusumMatrixShader.Dispatch(FrustumKernelHandle, num10, 1, 1);
						if (VegetationRenderSettings.EnableSinglePassInstancedVR)
						{
							FrusumMatrixShader.Dispatch(FrustumKernelHandle, num10, 1, 1);
						}
						for (int num11 = 0; num11 <= vegetationItemModelInfo.VegetationMeshLod0.subMeshCount - 1; num11++)
						{
							ComputeBuffer.CopyCount(cameraComputeBuffers.VisibleBufferLOD0, cameraComputeBuffers.ArgsBufferMergedLOD0List[num11], 4);
							ComputeBuffer.CopyCount(cameraComputeBuffers.ShadowBufferLOD0, cameraComputeBuffers.ShadowArgsBufferMergedLOD0List[num11], 4);
						}
						if (flag2)
						{
							for (int num12 = 0; num12 <= vegetationItemModelInfo.VegetationMeshLod1.subMeshCount - 1; num12++)
							{
								ComputeBuffer.CopyCount(cameraComputeBuffers.VisibleBufferLOD1, cameraComputeBuffers.ArgsBufferMergedLOD1List[num12], 4);
								ComputeBuffer.CopyCount(cameraComputeBuffers.ShadowBufferLOD1, cameraComputeBuffers.ShadowArgsBufferMergedLOD1List[num12], 4);
							}
							for (int num13 = 0; num13 <= vegetationItemModelInfo.VegetationMeshLod2.subMeshCount - 1; num13++)
							{
								ComputeBuffer.CopyCount(cameraComputeBuffers.VisibleBufferLOD2, cameraComputeBuffers.ArgsBufferMergedLOD2List[num13], 4);
								ComputeBuffer.CopyCount(cameraComputeBuffers.ShadowBufferLOD2, cameraComputeBuffers.ShadowArgsBufferMergedLOD2List[num13], 4);
							}
							for (int num14 = 0; num14 <= vegetationItemModelInfo.VegetationMeshLod3.subMeshCount - 1; num14++)
							{
								ComputeBuffer.CopyCount(cameraComputeBuffers.VisibleBufferLOD3, cameraComputeBuffers.ArgsBufferMergedLOD3List[num14], 4);
								ComputeBuffer.CopyCount(cameraComputeBuffers.ShadowBufferLOD3, cameraComputeBuffers.ShadowArgsBufferMergedLOD3List[num14], 4);
							}
						}
						float num15 = num2 * 2f + vegetationItemModelInfo.BoundingSphereRadius;
						Bounds cellBounds = new Bounds(VegetationStudioCameraList[i].SelectedCamera.transform.position, new Vector3(num15, num15, num15));
						RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 0, i, selectedCamera, shadowCastingMode, layer, shadows: false);
						if (shadowCastingMode == ShadowCastingMode.On)
						{
							RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 0, i, selectedCamera, ShadowCastingMode.ShadowsOnly, layer, shadows: true);
						}
						if (!flag2)
						{
							continue;
						}
						if (vegetationItemModelInfo.LODCount > 1)
						{
							RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 1, i, selectedCamera, shadowCastingMode, layer, shadows: false);
							if (shadowCastingMode == ShadowCastingMode.On)
							{
								RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 1, i, selectedCamera, ShadowCastingMode.ShadowsOnly, layer, shadows: true);
							}
						}
						if (vegetationItemModelInfo.LODCount > 2)
						{
							RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 2, i, selectedCamera, shadowCastingMode, layer, shadows: false);
							if (shadowCastingMode == ShadowCastingMode.On)
							{
								RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 2, i, selectedCamera, ShadowCastingMode.ShadowsOnly, layer, shadows: true);
							}
						}
						if (vegetationItemModelInfo.LODCount > 3)
						{
							RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 3, i, selectedCamera, shadowCastingMode, layer, shadows: false);
							if (shadowCastingMode == ShadowCastingMode.On)
							{
								RenderVegetationItemLODIndirect(vegetationItemModelInfo, cellBounds, 3, i, selectedCamera, ShadowCastingMode.ShadowsOnly, layer, shadows: true);
							}
						}
					}
				}
			}
		}

		private void RenderVegetationItemLODIndirect(VegetationItemModelInfo vegetationItemModelInfo, Bounds cellBounds, int lodIndex, int cameraIndex, Camera selectedCamera, ShadowCastingMode shadowCastingMode, int layer, bool shadows)
		{
			MaterialPropertyBlock lODMaterialPropertyBlock = vegetationItemModelInfo.GetLODMaterialPropertyBlock(lodIndex);
			lODMaterialPropertyBlock.Clear();
			ComputeBuffer lODVisibleBuffer = vegetationItemModelInfo.GetLODVisibleBuffer(lodIndex, cameraIndex, shadows);
			Mesh lODMesh = vegetationItemModelInfo.GetLODMesh(lodIndex);
			Material[] lODMaterials = vegetationItemModelInfo.GetLODMaterials(lodIndex);
			if (vegetationItemModelInfo.ShaderControler != null && vegetationItemModelInfo.ShaderControler.Settings.SampleWind)
			{
				MeshRenderer meshRenderer = vegetationItemModelInfo.WindSamplerMeshRendererList[cameraIndex];
				if ((bool)meshRenderer)
				{
					meshRenderer.GetPropertyBlock(lODMaterialPropertyBlock);
				}
			}
			lODMaterialPropertyBlock.SetBuffer(_visibleShaderDataBufferID, lODVisibleBuffer);
			lODMaterialPropertyBlock.SetBuffer(_indirectShaderDataBufferID, lODVisibleBuffer);
			List<ComputeBuffer> lODArgsBufferList = vegetationItemModelInfo.GetLODArgsBufferList(lodIndex, cameraIndex, shadows);
			int num = Mathf.Min(lODMesh.subMeshCount, lODMaterials.Length);
			for (int i = 0; i <= num - 1; i++)
			{
				Graphics.DrawMeshInstancedIndirect(lODMesh, i, lODMaterials[i], cellBounds, lODArgsBufferList[i], 0, lODMaterialPropertyBlock, shadowCastingMode, receiveShadows: true, layer, selectedCamera, LightProbeUsage.Off);
			}
		}

		private void SetComputeShaderBuffer(int bufferID, int bufferCountID, int cellIndex, int vegetationPackageIndex, int vegetationItemIndex)
		{
			if (cellIndex < _hasBufferList.Count)
			{
				VegetationCell vegetationCell = _hasBufferList[cellIndex];
				int length = _hasBufferList[cellIndex].VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemMatrixList[vegetationItemIndex].Length;
				MergeBufferShader.SetBuffer(MergeBufferKernelHandle, bufferID, vegetationCell.VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemComputeBufferList[vegetationItemIndex].ComputeBuffer);
				MergeBufferShader.SetInt(bufferCountID, length);
			}
			else
			{
				MergeBufferShader.SetBuffer(MergeBufferKernelHandle, bufferID, _dummyComputeBuffer);
				MergeBufferShader.SetInt(bufferCountID, 0);
			}
		}

		public void RefreshAllPrefabs()
		{
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				for (int j = 0; j <= VegetationPackageProList[i].VegetationInfoList.Count - 1; j++)
				{
					VegetationPackageProList[i].RefreshVegetationItemPrefab(VegetationPackageProList[i].VegetationInfoList[j]);
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(VegetationSystemBounds.center, VegetationSystemBounds.size);
			if (CurrentTabIndex == 0)
			{
				DrawSeaLevel();
			}
			if (CurrentTabIndex == 8)
			{
				DrawTextureMaskAreas();
			}
		}

		private void DrawSeaLevel()
		{
			Gizmos.color = new Color(0f, 0f, 0.8f, 0.4f);
			float num = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y;
			Gizmos.DrawCube(new Vector3(VegetationSystemBounds.center.x, num + SeaLevel, VegetationSystemBounds.center.z), new Vector3(VegetationSystemBounds.size.x, 0f, VegetationSystemBounds.size.z));
			Gizmos.DrawWireCube(VegetationSystemBounds.center, VegetationSystemBounds.size);
		}

		private void DrawTextureMaskAreas()
		{
			if (DebugTextureMask != null)
			{
				Vector3 center = new Vector3(DebugTextureMask.TextureRect.center.x, VegetationSystemBounds.center.y, DebugTextureMask.TextureRect.center.y);
				Vector3 size = new Vector3(DebugTextureMask.TextureRect.width, VegetationSystemBounds.size.y, DebugTextureMask.TextureRect.height);
				Gizmos.color = new Color(0f, 0.8f, 0.8f, 0.4f);
				Gizmos.DrawCube(center, size);
			}
		}

		private void OnDrawGizmos()
		{
			if (!base.enabled)
			{
				return;
			}
			if (ShowVegetationCells)
			{
				Gizmos.color = Color.yellow;
				for (int i = 0; i <= VegetationCellList.Count - 1; i++)
				{
					if (VegetationCellList[i].Enabled)
					{
						Gizmos.DrawWireCube(VegetationCellList[i].VegetationCellBounds.center, VegetationCellList[i].VegetationCellBounds.size);
						float.IsNegativeInfinity(VegetationCellList[i].VegetationCellBounds.size.y);
					}
				}
			}
			if (ShowBiomeCells)
			{
				Gizmos.color = Color.blue;
				for (int j = 0; j <= VegetationCellList.Count - 1; j++)
				{
					if (VegetationCellList[j].Enabled && VegetationCellList[j].BiomeMaskList != null && VegetationCellList[j].BiomeMaskList.Count > 0)
					{
						Gizmos.DrawWireCube(VegetationCellList[j].VegetationCellBounds.center, VegetationCellList[j].VegetationCellBounds.size);
					}
				}
			}
			if (ShowVegetationMaskCells)
			{
				Gizmos.color = Color.magenta;
				for (int k = 0; k <= VegetationCellList.Count - 1; k++)
				{
					if (VegetationCellList[k].Enabled && VegetationCellList[k].VegetationMaskList != null && VegetationCellList[k].VegetationMaskList.Count > 0)
					{
						Gizmos.DrawWireCube(VegetationCellList[k].VegetationCellBounds.center, VegetationCellList[k].VegetationCellBounds.size);
					}
				}
			}
			if (ShowPotentialVisibleCells)
			{
				for (int l = 0; l <= VegetationStudioCameraList.Count - 1; l++)
				{
					VegetationStudioCameraList[l].DrawPotentialCellGizmos();
				}
			}
			if (ShowVisibleBillboardCells)
			{
				for (int m = 0; m <= VegetationStudioCameraList.Count - 1; m++)
				{
					VegetationStudioCameraList[m].DrawVisibleBillboardCellGizmos();
				}
			}
			if (ShowVisibleCells)
			{
				for (int n = 0; n <= VegetationStudioCameraList.Count - 1; n++)
				{
					VegetationStudioCameraList[n].DrawVisibleCellGizmos();
				}
			}
			if (ShowBillboardCells)
			{
				Gizmos.color = Color.blue;
				for (int num = 0; num <= BillboardCellList.Count - 1; num++)
				{
					Gizmos.DrawWireCube(BillboardCellList[num].BilllboardCellBounds.center, BillboardCellList[num].BilllboardCellBounds.size);
				}
			}
		}

		public void SetupVegetationItemModels()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				list.Add(VegetationStudioCameraList[i].WindSampler);
			}
			float num = 0f;
			ClearVegetationItemModels();
			for (int j = 0; j <= VegetationPackageProList.Count - 1; j++)
			{
				VegetationPackageProModelInfo vegetationPackageProModelInfo = new VegetationPackageProModelInfo(VegetationPackageProList[j], EnvironmentSettings, list, VegetationStudioCameraList.Count, VegetationRenderSettings, VegetationSettings);
				VegetationPackageProModelsList.Add(vegetationPackageProModelInfo);
				num = Mathf.Max(num, vegetationPackageProModelInfo.GetAdditionalBoundingSphereRadius());
			}
			AdditionalBoundingSphereRadius = num;
		}

		public void SetupVegetationItemModelsPerCameraBuffers()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				ClearWindSampler(VegetationStudioCameraList[i].WindSampler);
				list.Add(VegetationStudioCameraList[i].WindSampler);
			}
			for (int j = 0; j <= VegetationPackageProModelsList.Count - 1; j++)
			{
				VegetationPackageProModelsList[j].CreateCameraBuffers(VegetationStudioCameraList.Count);
				VegetationPackageProModelsList[j].CreateCameraWindSamplerItems(list);
			}
		}

		private void ClearWindSampler(GameObject windSampler)
		{
			if (Application.isPlaying)
			{
				foreach (Transform item in windSampler.transform)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				return;
			}
			foreach (Transform item2 in windSampler.transform)
			{
				UnityEngine.Object.DestroyImmediate(item2.gameObject);
			}
		}

		public VegetationItemModelInfo GetVegetationItemModelInfo(string vegetationItemID)
		{
			VegetationItemIndexes vegetationItemIndexes = GetVegetationItemIndexes(vegetationItemID);
			return GetVegetationItemModelInfo(vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
		}

		public VegetationItemModelInfo GetVegetationItemModelInfo(int vegetationPackageIndex, int vegetationItemIndex)
		{
			if (vegetationPackageIndex < VegetationPackageProModelsList.Count && vegetationItemIndex < VegetationPackageProModelsList[vegetationPackageIndex].VegetationItemModelList.Count)
			{
				return VegetationPackageProModelsList[vegetationPackageIndex].VegetationItemModelList[vegetationItemIndex];
			}
			return null;
		}

		public void RefreshMaterials()
		{
			for (int i = 0; i <= VegetationPackageProModelsList.Count - 1; i++)
			{
				for (int j = 0; j <= VegetationPackageProModelsList[i].VegetationItemModelList.Count - 1; j++)
				{
					VegetationPackageProModelsList[i].VegetationItemModelList[j].RefreshMaterials();
				}
			}
		}

		private void ClearVegetationItemModels()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].WindSampler)
				{
					continue;
				}
				foreach (Transform item in VegetationStudioCameraList[i].WindSampler.transform)
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(item.gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(item.gameObject);
					}
				}
			}
			for (int j = 0; j <= VegetationPackageProModelsList.Count - 1; j++)
			{
				VegetationPackageProModelsList[j].Dispose();
			}
			VegetationPackageProModelsList.Clear();
		}

		private void SetupPredictiveCellLoader()
		{
			PredictiveCellLoader = new PredictiveCellLoader(this);
		}

		public void PreloadArea(Rect rect, bool important)
		{
			PredictiveCellLoader?.PreloadArea(rect, important);
		}

		public void PreloadArea(Rect rect, List<VegetationCell> overlapVegetationCellList, bool important)
		{
			PredictiveCellLoader?.PreloadArea(rect, overlapVegetationCellList, important);
		}

		public void PreloadAllVegetationCells()
		{
			PredictiveCellLoader?.PreloadAllVegetationCells();
		}

		public void AddTerrain(GameObject go)
		{
			IVegetationStudioTerrain iVegetationStudioTerrain = VegetationStudioTerrain.GetIVegetationStudioTerrain(go);
			if (iVegetationStudioTerrain != null)
			{
				if (!VegetationStudioTerrainObjectList.Contains(go))
				{
					VegetationStudioTerrainObjectList.Add(go);
				}
				RefreshVegetationStudioTerrains();
				if (AutomaticBoundsCalculation)
				{
					CalculateVegetationSystemBounds();
				}
				else
				{
					RefreshTerrainArea(iVegetationStudioTerrain.TerrainBounds);
				}
			}
			VerifyVegetationStudioTerrains();
		}

		public void AddTerrains(List<GameObject> terrainList)
		{
			Bounds bounds = default(Bounds);
			for (int i = 0; i <= terrainList.Count - 1; i++)
			{
				IVegetationStudioTerrain iVegetationStudioTerrain = VegetationStudioTerrain.GetIVegetationStudioTerrain(terrainList[i]);
				if (iVegetationStudioTerrain != null && !VegetationStudioTerrainObjectList.Contains(terrainList[i]))
				{
					VegetationStudioTerrainObjectList.Add(terrainList[i]);
				}
				if (i == 0)
				{
					if (iVegetationStudioTerrain != null)
					{
						bounds = iVegetationStudioTerrain.TerrainBounds;
					}
				}
				else if (iVegetationStudioTerrain != null)
				{
					bounds.Encapsulate(iVegetationStudioTerrain.TerrainBounds);
				}
			}
			RefreshVegetationStudioTerrains();
			if (AutomaticBoundsCalculation)
			{
				CalculateVegetationSystemBounds();
			}
			else
			{
				RefreshTerrainArea(bounds);
			}
			VerifyVegetationStudioTerrains();
		}

		public void VerifySplatmapAccess()
		{
		}

		public void RefreshTerrainHeightmap()
		{
			for (int i = 0; i <= VegetationStudioTerrainList.Count - 1; i++)
			{
				VegetationStudioTerrainList[i].RefreshTerrainData();
			}
		}

		public void AddAllUnityTerrains()
		{
			Terrain[] array = UnityEngine.Object.FindObjectsOfType<Terrain>();
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (!array[i].gameObject.GetComponent<UnityTerrain>())
				{
					array[i].gameObject.AddComponent<UnityTerrain>();
				}
				list.Add(array[i].gameObject);
			}
			AddTerrains(list);
		}

		public void AddAllMeshTerrains()
		{
			MeshTerrain[] array = UnityEngine.Object.FindObjectsOfType<MeshTerrain>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				AddTerrain(array[i].gameObject);
			}
		}

		public void RemoveAllTerrains()
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(VegetationStudioTerrainObjectList);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				RemoveTerrain(list[i]);
			}
		}

		public void AddAllRaycastTerrains()
		{
			RaycastTerrain[] array = UnityEngine.Object.FindObjectsOfType<RaycastTerrain>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				AddTerrain(array[i].gameObject);
			}
		}

		public void RemoveTerrain(GameObject go)
		{
			if (VegetationStudioTerrainObjectList.Contains(go))
			{
				VegetationStudioTerrainObjectList.Remove(go);
			}
			RefreshVegetationStudioTerrains();
			IVegetationStudioTerrain iVegetationStudioTerrain = VegetationStudioTerrain.GetIVegetationStudioTerrain(go);
			if (AutomaticBoundsCalculation)
			{
				CalculateVegetationSystemBounds();
			}
			else if (iVegetationStudioTerrain != null)
			{
				RefreshTerrainArea(iVegetationStudioTerrain.TerrainBounds);
			}
			VerifyVegetationStudioTerrains();
		}

		private void RefreshVegetationStudioTerrains()
		{
			VerifyVegetationStudioTerrains();
			VegetationStudioTerrainList.Clear();
			for (int i = 0; i <= VegetationStudioTerrainObjectList.Count - 1; i++)
			{
				IVegetationStudioTerrain iVegetationStudioTerrain = VegetationStudioTerrain.GetIVegetationStudioTerrain(VegetationStudioTerrainObjectList[i]);
				if (iVegetationStudioTerrain != null)
				{
					VegetationStudioTerrainList.Add(iVegetationStudioTerrain);
				}
			}
		}

		public void VerifyVegetationStudioTerrains()
		{
			while (VegetationStudioTerrainObjectList.Contains(null))
			{
				VegetationStudioTerrainObjectList.Remove(null);
			}
		}

		public void CalculateVegetationSystemBounds()
		{
			for (int i = 0; i <= VegetationStudioTerrainObjectList.Count - 1; i++)
			{
				VegetationStudioTerrain.GetIVegetationStudioTerrain(VegetationStudioTerrainObjectList[i])?.RefreshTerrainData();
			}
			Bounds vegetationSystemBounds = new Bounds(Vector3.zero, Vector3.zero);
			if (AutomaticBoundsCalculation)
			{
				for (int j = 0; j <= VegetationStudioTerrainObjectList.Count - 1; j++)
				{
					IVegetationStudioTerrain iVegetationStudioTerrain = VegetationStudioTerrain.GetIVegetationStudioTerrain(VegetationStudioTerrainObjectList[j]);
					if (iVegetationStudioTerrain != null)
					{
						if (j == 0)
						{
							vegetationSystemBounds = iVegetationStudioTerrain.TerrainBounds;
						}
						else
						{
							vegetationSystemBounds.Encapsulate(iVegetationStudioTerrain.TerrainBounds);
						}
					}
				}
			}
			VegetationSystemBounds = vegetationSystemBounds;
			SetupVegetationSystem();
		}

		private void DisposeVegetationCells()
		{
			_prepareVegetationHandle.Complete();
			for (int i = 0; i <= VegetationCellList.Count - 1; i++)
			{
				VegetationCellList[i].Dispose();
			}
			VegetationCellList.Clear();
		}

		private void CreateVegetationCells()
		{
			DisposeVegetationCells();
			Bounds bounds = new Bounds(VegetationSystemBounds.center, VegetationSystemBounds.size);
			bounds.Expand(new Vector3(VegetationCellSize * 2f, 0f, VegetationCellSize * 2f));
			Rect rect = RectExtension.CreateRectFromBounds(bounds);
			VegetationCellQuadTree = new QuadTree<VegetationCell>(rect);
			int num = Mathf.CeilToInt(VegetationSystemBounds.size.x / VegetationCellSize);
			int num2 = Mathf.CeilToInt(VegetationSystemBounds.size.z / VegetationCellSize);
			Vector2 vector = new Vector2(VegetationSystemBounds.center.x - VegetationSystemBounds.size.x / 2f, VegetationSystemBounds.center.z - VegetationSystemBounds.size.z / 2f);
			for (int i = 0; i <= num - 1; i++)
			{
				for (int j = 0; j <= num2 - 1; j++)
				{
					VegetationCell vegetationCell = new VegetationCell(new Rect(new Vector2(VegetationCellSize * (float)i + vector.x, VegetationCellSize * (float)j + vector.y), new Vector2(VegetationCellSize, VegetationCellSize)));
					VegetationCellList.Add(vegetationCell);
					vegetationCell.Index = VegetationCellList.Count - 1;
					VegetationCellQuadTree.Insert(vegetationCell);
				}
			}
			LoadedVegetationCellList.Clear();
			LoadedVegetationCellList.Capacity = VegetationCellList.Count;
			NativeArray<Bounds> vegetationCellBoundsList = new NativeArray<Bounds>(VegetationCellList.Count, Allocator.Persistent);
			for (int k = 0; k <= VegetationCellList.Count - 1; k++)
			{
				vegetationCellBoundsList[k] = VegetationCellList[k].VegetationCellBounds;
			}
			float num3 = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y;
			float worldspaceHeightCutoff = num3 + SeaLevel;
			if (!ExcludeSeaLevelCells)
			{
				worldspaceHeightCutoff = num3;
			}
			JobHandle dependsOn = default(JobHandle);
			for (int l = 0; l <= VegetationStudioTerrainList.Count - 1; l++)
			{
				dependsOn = VegetationStudioTerrainList[l].SampleCellHeight(vegetationCellBoundsList, worldspaceHeightCutoff, rect, dependsOn);
			}
			dependsOn.Complete();
			for (int m = 0; m <= VegetationCellList.Count - 1; m++)
			{
				VegetationCellList[m].VegetationCellBounds = vegetationCellBoundsList[m];
			}
			vegetationCellBoundsList.Dispose();
			PrepareVegetationCells();
			VegetationStudioManager.OnVegetationCellRefresh(this);
		}

		public void RefreshTerrainArea()
		{
			RefreshTerrainArea(VegetationSystemBounds);
		}

		public void RefreshTerrainArea(Bounds bounds)
		{
			if (VegetationCellQuadTree != null)
			{
				List<VegetationCell> list = new List<VegetationCell>();
				Rect area = RectExtension.CreateRectFromBounds(bounds);
				VegetationCellQuadTree.Query(area, list);
				Bounds bounds2 = bounds;
				NativeArray<Bounds> vegetationCellBoundsList = new NativeArray<Bounds>(list.Count, Allocator.Persistent);
				for (int i = 0; i <= list.Count - 1; i++)
				{
					Bounds bounds3 = (vegetationCellBoundsList[i] = RectExtension.CreateBoundsFromRect(list[i].Rectangle, -100000f));
					bounds2.Encapsulate(bounds3);
				}
				area = RectExtension.CreateRectFromBounds(bounds2);
				float num = VegetationSystemBounds.center.y - VegetationSystemBounds.extents.y;
				float worldspaceHeightCutoff = num + SeaLevel;
				if (!ExcludeSeaLevelCells)
				{
					worldspaceHeightCutoff = num;
				}
				JobHandle dependsOn = default(JobHandle);
				for (int j = 0; j <= VegetationStudioTerrainList.Count - 1; j++)
				{
					dependsOn = VegetationStudioTerrainList[j].SampleCellHeight(vegetationCellBoundsList, worldspaceHeightCutoff, area, dependsOn);
				}
				dependsOn.Complete();
				for (int k = 0; k <= list.Count - 1; k++)
				{
					list[k].VegetationCellBounds = vegetationCellBoundsList[k];
				}
				vegetationCellBoundsList.Dispose();
				ForceCullingRefresh();
				ClearCache(bounds);
			}
		}

		private void ForceCullingRefresh()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCameraList[i].PreCullVegetation(forceUpdate: true);
			}
		}

		private void PrepareVegetationCells()
		{
			for (int i = 0; i <= VegetationCellList.Count - 1; i++)
			{
				VegetationCellSpawner.PrepareVegetationCell(VegetationCellList[i]);
			}
		}

		private void SetupVegetationCellSpawner()
		{
			VegetationCellSpawner.VegetationStudioTerrainList = VegetationStudioTerrainList;
			VegetationCellSpawner.VegetationPackageProList = VegetationPackageProList;
			VegetationCellSpawner.VegetationPackageProModelsList = VegetationPackageProModelsList;
			VegetationCellSpawner.VegetationSettings = VegetationSettings;
			VegetationCellSpawner.VegetationSystemPro = this;
			VegetationCellSpawner.PersistentVegetationStorage = PersistentVegetationStorage;
			VegetationCellSpawner.CompactMemoryCellList = CompactMemoryCellList;
		}

		private void ReturnVegetationCellTemporaryMemory()
		{
			for (int i = 0; i <= CompactMemoryCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = CompactMemoryCellList[i];
				for (int j = 0; j <= vegetationCell.VegetationInstanceDataList.Count - 1; j++)
				{
					VegetationInstanceData vegetationInstanceData = vegetationCell.VegetationInstanceDataList[j];
					VegetationCellSpawner.VegetationInstanceDataPool.ReturnObject(vegetationInstanceData);
				}
				vegetationCell.VegetationInstanceDataList.Clear();
			}
			CompactMemoryCellList.Clear();
		}

		private void ReturnVegetationCellTemporaryMemory(VegetationCell vegetationCell)
		{
			for (int i = 0; i <= vegetationCell.VegetationInstanceDataList.Count - 1; i++)
			{
				VegetationInstanceData vegetationInstanceData = vegetationCell.VegetationInstanceDataList[i];
				VegetationCellSpawner.VegetationInstanceDataPool.ReturnObject(vegetationInstanceData);
			}
			vegetationCell.VegetationInstanceDataList.Clear();
		}

		public void SpawnVegetationCell(VegetationCell vegetationCell)
		{
			CompleteCellLoading();
			if (!vegetationCell.Prepared)
			{
				VegetationCellSpawner.PrepareVegetationCell(vegetationCell);
			}
			VegetationCellSpawner.SpawnVegetationCell(vegetationCell, out var hasInstancedIndirect).Complete();
			if (hasInstancedIndirect && Application.isPlaying)
			{
				ProcessInstancedIndirectCellList.Add(vegetationCell);
				PrepareInstancedIndirectSetupJobs().Complete();
				SetupInstancedIndirectComputeBuffers();
				ReturnVegetationCellTemporaryMemory(vegetationCell);
			}
		}

		public void SpawnVegetationCell(VegetationCell vegetationCell, string vegetationItemID)
		{
			CompleteCellLoading();
			if (!vegetationCell.Prepared)
			{
				VegetationCellSpawner.PrepareVegetationCell(vegetationCell);
			}
			VegetationCellSpawner.SpawnVegetationCell(vegetationCell, vegetationItemID, out var hasInstancedIndirect).Complete();
			if (hasInstancedIndirect && Application.isPlaying)
			{
				ProcessInstancedIndirectCellList.Add(vegetationCell);
				PrepareInstancedIndirectSetupJobs().Complete();
				SetupInstancedIndirectComputeBuffers();
				ReturnVegetationCellTemporaryMemory(vegetationCell);
			}
		}

		public NativeList<MatrixInstance> GetVegetationItemInstances(VegetationCell vegetationCell, string vegetationItemID)
		{
			CompleteCellLoading();
			VegetationItemIndexes vegetationItemIndexes = GetVegetationItemIndexes(vegetationItemID);
			if (vegetationCell.Prepared)
			{
				return vegetationCell.VegetationPackageInstancesList[vegetationItemIndexes.VegetationPackageIndex].VegetationItemMatrixList[vegetationItemIndexes.VegetationItemIndex];
			}
			return default(NativeList<MatrixInstance>);
		}

		public VegetationItemIndexes GetVegetationItemIndexes(string vegetationItemID)
		{
			VegetationItemIndexes result = new VegetationItemIndexes
			{
				VegetationItemIndex = -1,
				VegetationPackageIndex = -1
			};
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				for (int j = 0; j <= VegetationPackageProList[i].VegetationInfoList.Count - 1; j++)
				{
					if (VegetationPackageProList[i].VegetationInfoList[j].VegetationItemID == vegetationItemID)
					{
						result.VegetationPackageIndex = i;
						result.VegetationItemIndex = j;
						return result;
					}
				}
			}
			return result;
		}

		public void ClearCache()
		{
			CompleteCellLoading();
			for (int i = 0; i <= LoadedVegetationCellList.Count - 1; i++)
			{
				LoadedVegetationCellList[i].ClearCache();
			}
			LoadedVegetationCellList.Clear();
			ClearBillboardCellsCache();
			OnClearCacheDelegate?.Invoke(this);
		}

		public void ClearCache(Bounds bounds)
		{
			Rect other = RectExtension.CreateRectFromBounds(bounds);
			CompleteCellLoading();
			for (int num = LoadedVegetationCellList.Count - 1; num >= 0; num--)
			{
				VegetationCell vegetationCell = LoadedVegetationCellList[num];
				if (vegetationCell.Rectangle.Overlaps(other))
				{
					vegetationCell.ClearCache();
					LoadedVegetationCellList.RemoveAtSwapBack(num);
					OnClearCacheVegetationCellDelegate?.Invoke(this, vegetationCell);
				}
			}
			ClearBillboardCellsCache(bounds);
		}

		public void ClearCache(VegetationCell vegetationCell)
		{
			CompleteCellLoading();
			vegetationCell.ClearCache();
			ClearBillboardCellsCache(vegetationCell.VegetationCellBounds);
			OnClearCacheVegetationCellDelegate?.Invoke(this, vegetationCell);
		}

		public void ClearCache(VegetationCell vegetationCell, string vegetationItemID)
		{
			VegetationItemIndexes vegetationItemIndexes = GetVegetationItemIndexes(vegetationItemID);
			if (vegetationItemIndexes.VegetationPackageIndex >= 0)
			{
				ClearCache(vegetationCell, vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
			}
		}

		public void ClearCache(VegetationCell vegetationCell, int vegetationPackageIndex, int vegetationItemIndex)
		{
			CompleteCellLoading();
			VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[vegetationPackageIndex].VegetationInfoList[vegetationItemIndex];
			bool tree = vegetationItemInfoPro.VegetationType == VegetationType.Tree || vegetationItemInfoPro.VegetationType == VegetationType.LargeObjects;
			vegetationCell.ClearCache(vegetationPackageIndex, vegetationItemIndex, tree);
			ClearBillboardCellsCache(vegetationCell.VegetationCellBounds, vegetationPackageIndex, vegetationItemIndex);
			OnClearCacheVegetationCellVegetatonItemDelegate?.Invoke(this, vegetationCell, vegetationPackageIndex, vegetationItemIndex);
		}

		public void ClearCache(string vegetationItemID)
		{
			CompleteCellLoading();
			VegetationItemIndexes vegetationItemIndexes = GetVegetationItemIndexes(vegetationItemID);
			if (vegetationItemIndexes.VegetationPackageIndex >= 0)
			{
				ClearCache(vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
			}
		}

		public void ClearCache(int vegetationPackageIndex, int vegetationItemIndex)
		{
			CompleteCellLoading();
			VegetationItemInfoPro vegetationItemInfoPro = VegetationPackageProList[vegetationPackageIndex].VegetationInfoList[vegetationItemIndex];
			bool tree = vegetationItemInfoPro.VegetationType == VegetationType.Tree || vegetationItemInfoPro.VegetationType == VegetationType.LargeObjects;
			for (int i = 0; i <= LoadedVegetationCellList.Count - 1; i++)
			{
				LoadedVegetationCellList[i].ClearCache(vegetationPackageIndex, vegetationItemIndex, tree);
			}
			ClearBillboardCellsCache(vegetationPackageIndex, vegetationItemIndex);
			OnClearCacheVegetationItemDelegate?.Invoke(this, vegetationPackageIndex, vegetationItemIndex);
		}

		public void AddVegetationPackage(VegetationPackagePro vegetationPackagePro)
		{
			if (!VegetationPackageProList.Contains(vegetationPackagePro))
			{
				VegetationPackageProList.Add(vegetationPackagePro);
			}
		}

		public void RemoveVegetationPackage(VegetationPackagePro vegetationPackagePro)
		{
			VegetationPackageProList.Remove(vegetationPackagePro);
		}

		public VegetationPackagePro GetVegetationPackageFromBiome(BiomeType biomeType)
		{
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				if (VegetationPackageProList[i].BiomeType == biomeType)
				{
					return VegetationPackageProList[i];
				}
			}
			return null;
		}

		public int GetMaxVegetationPackageItemCount()
		{
			int num = 0;
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				num = Mathf.Max(VegetationPackageProList[i].VegetationInfoList.Count, num);
			}
			return num;
		}

		public List<BiomeType> GetAdditionalBiomeList()
		{
			List<BiomeType> list = new List<BiomeType>();
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				if (VegetationPackageProList[i].BiomeType != BiomeType.Default)
				{
					list.Add(VegetationPackageProList[i].BiomeType);
				}
			}
			return list.Distinct().ToList();
		}

		public int GetBiomeSortOrder(BiomeType biomeType)
		{
			for (int i = 0; i <= VegetationPackageProList.Count - 1; i++)
			{
				if (VegetationPackageProList[i].BiomeType == biomeType)
				{
					return VegetationPackageProList[i].BiomeSortOrder;
				}
			}
			return 1;
		}

		public VegetationItemInfoPro GetVegetationItemInfo(string vegetationItemID)
		{
			VegetationItemIndexes vegetationItemIndexes = GetVegetationItemIndexes(vegetationItemID);
			if (vegetationItemIndexes.VegetationPackageIndex >= 0)
			{
				return VegetationPackageProList[vegetationItemIndexes.VegetationPackageIndex].VegetationInfoList[vegetationItemIndexes.VegetationItemIndex];
			}
			return null;
		}

		public void SetAllVegetationPackagesDirty()
		{
		}

		private void SetupWind()
		{
			_windControllerList.Clear();
			Type interfaceType = typeof(IWindController);
			foreach (IWindController item in (from x in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly x) => x.GetLoadableTypes())
				where interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract
				select x).Select(Activator.CreateInstance))
			{
				if (item != null)
				{
					string windControlerID = item.WindControlerID;
					WindControllerSettings windControllerSettings = GetWindControllerSettings(windControlerID);
					if (windControllerSettings == null)
					{
						windControllerSettings = item.CreateDefaultSettings();
						WindControllerSettingsList.Add(windControllerSettings);
					}
					else
					{
						item.Settings = windControllerSettings;
					}
					_windControllerList.Add(item);
				}
			}
		}

		private void FindWindZone()
		{
			if (!SelectedWindZone)
			{
				SelectedWindZone = (WindZone)UnityEngine.Object.FindObjectOfType(typeof(WindZone));
				if (!SelectedWindZone)
				{
					GameObject gameObject = new GameObject("WindZone");
					SelectedWindZone = gameObject.AddComponent<WindZone>();
				}
			}
		}

		public void UpdateWindSettings()
		{
			for (int i = 0; i <= _windControllerList.Count - 1; i++)
			{
				_windControllerList[i].RefreshSettings();
			}
		}

		private void SetupWindSamplers()
		{
			for (int i = 0; i <= VegetationStudioCameraList.Count - 1; i++)
			{
				if (!VegetationStudioCameraList[i].WindSampler)
				{
					Transform transform = base.transform.Find("WindSampler_" + i);
					if (!transform)
					{
						GameObject gameObject = new GameObject("WindSampler_" + i)
						{
							hideFlags = HideFlags.HideInHierarchy
						};
						gameObject.transform.SetParent(base.transform, worldPositionStays: false);
						gameObject.transform.position = Vector3.zero;
						VegetationStudioCameraList[i].WindSampler = gameObject;
					}
					else
					{
						VegetationStudioCameraList[i].WindSampler = transform.gameObject;
					}
				}
			}
		}

		public void UpdateWind()
		{
			for (int i = 0; i <= _windControllerList.Count - 1; i++)
			{
				_windControllerList[i].UpdateWind(SelectedWindZone, WindSpeedFactor);
			}
			for (int j = 0; j <= VegetationStudioCameraList.Count - 1; j++)
			{
				if (VegetationStudioCameraList[j].Enabled)
				{
					GameObject windSampler = VegetationStudioCameraList[j].WindSampler;
					Camera selectedCamera = VegetationStudioCameraList[j].SelectedCamera;
					if ((bool)selectedCamera)
					{
						windSampler.transform.position = selectedCamera.transform.position;
						windSampler.transform.rotation = selectedCamera.transform.rotation;
					}
				}
			}
		}

		private WindControllerSettings GetWindControllerSettings(string windControllerID)
		{
			for (int i = 0; i <= WindControllerSettingsList.Count - 1; i++)
			{
				if (WindControllerSettingsList[i] != null && WindControllerSettingsList[i].WindControlerID == windControllerID)
				{
					return WindControllerSettingsList[i];
				}
			}
			return null;
		}
	}
}
