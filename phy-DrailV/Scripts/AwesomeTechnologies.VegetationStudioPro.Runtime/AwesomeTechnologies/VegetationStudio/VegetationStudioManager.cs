using System;
using System.Collections.Generic;
using AwesomeTechnologies.BillboardSystem;
using AwesomeTechnologies.TerrainSystem;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation.PersistentStorage;
using AwesomeTechnologies.VegetationSystem;
using AwesomeTechnologies.VegetationSystem.Biomes;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AwesomeTechnologies.VegetationStudio
{
	[ExecuteInEditMode]
	public class VegetationStudioManager : MonoBehaviour
	{
		public delegate void MultiAddVegetationSystemDelegate(VegetationSystemPro vegetationSystem);

		public delegate void MultiRemoveVegetationSystemDelegate(VegetationSystemPro vegetationSystem);

		public int CurrentTabIndex;

		public static VegetationStudioManager Instance;

		public List<VegetationSystemPro> VegetationSystemList = new List<VegetationSystemPro>();

		public MultiAddVegetationSystemDelegate OnAddVegetationSystemDelegate;

		public MultiRemoveVegetationSystemDelegate OnRemoveVegetationSystemDelegate;

		[NonSerialized]
		private VegetationItemInfoPro _clippboardvegetationItemInfo;

		[NonSerialized]
		private AnimationCurve _clippboardAnimationCurve;

		public List<PostProcessProfileInfo> PostProcessProfileInfoList = new List<PostProcessProfileInfo>();

		public LayerMask PostProcessingLayer = 0;

		private readonly List<PolygonBiomeMask> _biomeMaskList = new List<PolygonBiomeMask>();

		private static bool _showBiomes;

		private readonly List<BaseMaskArea> _vegetationMaskList = new List<BaseMaskArea>();

		public static bool isLevelUnloading = false;

		private static int attemptedToFindFrame = -1;

		public static bool ShowBiomes
		{
			get
			{
				return _showBiomes;
			}
			set
			{
				_ = _showBiomes;
				_showBiomes = value;
			}
		}

		public static void RegisterVegetationSystem(VegetationSystemPro vegetationSystem)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RegisterVegetationSystem(vegetationSystem);
			}
		}

		protected void Instance_RegisterVegetationSystem(VegetationSystemPro vegetationSystem)
		{
			if (!VegetationSystemList.Contains(vegetationSystem))
			{
				VegetationSystemList.Add(vegetationSystem);
				OnAddVegetationSystem(vegetationSystem);
				if (OnAddVegetationSystemDelegate != null)
				{
					OnAddVegetationSystemDelegate(vegetationSystem);
				}
			}
		}

		protected static void FindInstance()
		{
			if (!isLevelUnloading && attemptedToFindFrame != Time.frameCount)
			{
				attemptedToFindFrame = Time.frameCount;
				Instance = (VegetationStudioManager)UnityEngine.Object.FindObjectOfType(typeof(VegetationStudioManager));
			}
		}

		protected void Instance_UnregisterVegetationSystem(VegetationSystemPro vegetationSystem)
		{
			VegetationSystemList.Remove(vegetationSystem);
			OnRemoveVegetationSystem(vegetationSystem);
			OnRemoveVegetationSystemDelegate?.Invoke(vegetationSystem);
		}

		public static void UnregisterVegetationSystem(VegetationSystemPro vegetationSystem)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_UnregisterVegetationSystem(vegetationSystem);
			}
		}

		public void OnAddVegetationSystem(VegetationSystemPro vegetationSystem)
		{
		}

		public void OnRemoveVegetationSystem(VegetationSystemPro vegetationSystem)
		{
		}

		public static void OnVegetationCellRefresh(VegetationSystemPro vegetationSystem)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Internal_OnVegetationCellRefresh(vegetationSystem);
			}
		}

		public void Internal_OnVegetationCellRefresh(VegetationSystemPro vegetationSystem)
		{
			for (int i = 0; i <= _biomeMaskList.Count - 1; i++)
			{
				AddBiomeMaskToVegetationSystem(vegetationSystem, _biomeMaskList[i]);
			}
			for (int j = 0; j <= _vegetationMaskList.Count - 1; j++)
			{
				AddVegetationMaskToVegetationSystem(vegetationSystem, _vegetationMaskList[j]);
			}
		}

		public static void AddAnimationCurveToClipboard(AnimationCurve animationCurve)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Internal_AddAnimationCurveToClipboard(animationCurve);
			}
		}

		private void Internal_AddAnimationCurveToClipboard(AnimationCurve animationCurve)
		{
			_clippboardAnimationCurve = animationCurve;
		}

		public static AnimationCurve GetAnimationCurveFromClippboard()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.Internal_GetAnimationCurveFromClippboard();
			}
			return null;
		}

		public AnimationCurve Internal_GetAnimationCurveFromClippboard()
		{
			return _clippboardAnimationCurve;
		}

		public void Internal_ClearCache()
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].ClearCache();
			}
		}

		public void Internal_ClearCache(Bounds bounds)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].ClearCache();
			}
		}

		public static void ClearCache()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Internal_ClearCache();
			}
		}

		public static void ClearCache(Bounds bounds)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Internal_ClearCache(bounds);
			}
		}

		private void OnDisable()
		{
			DisposeBiomeMasks();
			DisposeVegetationMasksMasks();
		}

		protected void Internal_AddVegetationItemToClipboard(VegetationItemInfoPro vegetationItemInfo)
		{
			_clippboardvegetationItemInfo = new VegetationItemInfoPro(vegetationItemInfo);
		}

		private VegetationItemInfoPro Internal_GetVegetationItemFromClipboard()
		{
			return _clippboardvegetationItemInfo;
		}

		public static void AddVegetationItemToClipboard(VegetationItemInfoPro vegetationItemInfo)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Internal_AddVegetationItemToClipboard(vegetationItemInfo);
			}
		}

		public static VegetationItemInfoPro GetVegetationItemFromClipboard()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.Internal_GetVegetationItemFromClipboard();
			}
			return null;
		}

		public static void RefreshTerrainHeightMap()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RefreshTerrainHeightmap();
			}
			RefreshTerrainArea();
		}

		public static void RefreshTerrainHeightMap(Bounds bounds)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RefreshTerrainHeightmap(bounds);
			}
			RefreshTerrainArea(bounds);
		}

		public void Instance_RefreshTerrainHeightmap()
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].RefreshTerrainHeightmap();
			}
		}

		public void Instance_RefreshTerrainHeightmap(Bounds bounds)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].RefreshTerrainHeightmap();
			}
		}

		public void Instance_AddTerrain(GameObject go, bool forceAdd)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if (!VegetationSystemList[i].AutomaticBoundsCalculation || forceAdd)
				{
					VegetationSystemList[i].AddTerrain(go);
				}
			}
		}

		public void Instance_RemoveTerrain(GameObject go)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if (!VegetationSystemList[i].AutomaticBoundsCalculation)
				{
					VegetationSystemList[i].RemoveTerrain(go);
				}
			}
		}

		public static void AddTerrain(GameObject go, bool forceAdd)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_AddTerrain(go, forceAdd);
			}
		}

		public static void AddCamera(Camera camera, bool noFrustumCulling = false, bool renderDirectToCamera = false, bool renderBillboardsOnly = false)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_AddCamera(camera, noFrustumCulling, renderDirectToCamera, renderBillboardsOnly);
			}
		}

		public void Instance_AddCamera(Camera aCamera, bool noFrustumCulling = false, bool renderDirectToCamera = false, bool renderBillboardsOnly = false)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].AddCamera(aCamera, noFrustumCulling, renderDirectToCamera, renderBillboardsOnly);
			}
		}

		public static void RemoveCamera(Camera camera)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RemoveCamera(camera);
			}
		}

		public void Instance_RemoveCamera(Camera aCamera)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].RemoveCamera(aCamera);
			}
		}

		public static void RemoveTerrain(GameObject go)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RemoveTerrain(go);
			}
		}

		public void Instance_RefreshTerrainArea(Bounds bounds)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if (VegetationSystemList[i].InitDone)
				{
					VegetationSystemList[i].RefreshTerrainArea(bounds);
				}
			}
		}

		public void Instance_RefreshTerrainArea()
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if (VegetationSystemList[i].InitDone)
				{
					VegetationSystemList[i].RefreshTerrainArea();
				}
			}
		}

		public static void RefreshTerrainArea(Bounds bounds)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RefreshTerrainArea(bounds);
			}
		}

		public static void RefreshTerrainArea()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RefreshTerrainArea();
			}
		}

		public Vector3 Instance_GetFloatingOriginOffset()
		{
			if (VegetationSystemList.Count > 0)
			{
				return VegetationSystemList[0].FloatingOriginOffset;
			}
			return Vector3.zero;
		}

		public static Vector3 GetFloatingOriginOffset()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.Instance_GetFloatingOriginOffset();
			}
			return Vector3.zero;
		}

		public static void SetSunDirectionalLight(Light light)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_SetSunDirectionalLight(light);
			}
		}

		public void Instance_SetSunDirectionalLight(Light alight)
		{
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemList[i].SunDirectionalLight = alight;
			}
		}

		public static void RemoveBiomeMask(PolygonBiomeMask maskArea)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RemoveBiomeMask(maskArea);
			}
		}

		public static void AddBiomeMask(PolygonBiomeMask maskArea)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_AddBiomeMask(maskArea);
			}
		}

		public static List<PolygonBiomeMask> GetBiomeMasks(BiomeType biomeType)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.Instance_GetBiomeMasks(biomeType);
			}
			return new List<PolygonBiomeMask>();
		}

		public List<PolygonBiomeMask> Instance_GetBiomeMasks(BiomeType biomeType)
		{
			List<PolygonBiomeMask> list = new List<PolygonBiomeMask>();
			for (int i = 0; i <= _biomeMaskList.Count - 1; i++)
			{
				if (_biomeMaskList[i].BiomeType == biomeType)
				{
					list.Add(_biomeMaskList[i]);
				}
			}
			return list;
		}

		private void DisposeBiomeMasks()
		{
			for (int i = 0; i <= _biomeMaskList.Count - 1; i++)
			{
				_biomeMaskList[i].CallDeleteEvent();
				_biomeMaskList[i].Dispose();
			}
			_biomeMaskList.Clear();
		}

		protected void Instance_AddBiomeMask(PolygonBiomeMask maskArea)
		{
			if (!_biomeMaskList.Contains(maskArea))
			{
				_biomeMaskList.Add(maskArea);
			}
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				AddBiomeMaskToVegetationSystem(VegetationSystemList[i], maskArea);
			}
		}

		protected void Instance_RemoveBiomeMask(PolygonBiomeMask maskArea)
		{
			_biomeMaskList.Remove(maskArea);
			Rect area = RectExtension.CreateRectFromBounds(maskArea.MaskBounds);
			List<BillboardCell> list = new List<BillboardCell>();
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemPro vegetationSystemPro = VegetationSystemList[i];
				vegetationSystemPro.CompleteCellLoading();
				vegetationSystemPro.BillboardCellQuadTree.Query(area, list);
				for (int j = 0; j <= list.Count - 1; j++)
				{
					list[j].ClearCache();
				}
			}
			maskArea.CallDeleteEvent();
			maskArea.Dispose();
		}

		private static void AddBiomeMaskToVegetationSystem(VegetationSystemPro vegetationSystem, PolygonBiomeMask maskArea)
		{
			int biomeSortOrder = vegetationSystem.GetBiomeSortOrder(maskArea.BiomeType);
			maskArea.BiomeSortOrder = biomeSortOrder;
			Rect area = RectExtension.CreateRectFromBounds(maskArea.MaskBounds);
			if (vegetationSystem.VegetationCellQuadTree != null && vegetationSystem.BillboardCellQuadTree != null)
			{
				List<VegetationCell> list = new List<VegetationCell>();
				vegetationSystem.VegetationCellQuadTree.Query(area, list);
				for (int i = 0; i <= list.Count - 1; i++)
				{
					list[i].AddBiomeMask(maskArea);
				}
				List<BillboardCell> list2 = new List<BillboardCell>();
				vegetationSystem.BillboardCellQuadTree.Query(area, list2);
				for (int j = 0; j <= list2.Count - 1; j++)
				{
					list2[j].ClearCache();
				}
			}
		}

		public static void GenerateSplatMap()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				TerrainSystemPro component = Instance.VegetationSystemList[i].gameObject.GetComponent<TerrainSystemPro>();
				if ((bool)component)
				{
					component.GenerateSplatMap(clearLockedTextures: false);
					component.ShowTerrainHeatmap(value: false);
				}
			}
		}

		public BiomeType Instance_GetBiomeType(Vector3 position)
		{
			int num = -1;
			BiomeType result = BiomeType.Default;
			for (int i = 0; i <= _biomeMaskList.Count - 1; i++)
			{
				if (_biomeMaskList[i].Contains(position) && _biomeMaskList[i].BiomeSortOrder > num)
				{
					num = _biomeMaskList[i].BiomeSortOrder;
					result = _biomeMaskList[i].BiomeType;
				}
			}
			return result;
		}

		public static BiomeType GetBiomeType(Vector3 position)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_GetBiomeType(position);
			}
			return BiomeType.Default;
		}

		private void Awake()
		{
			isLevelUnloading = false;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			attemptedToFindFrame = -1;
		}

		public void RefreshPostProcessVolumes()
		{
			BiomeMaskArea[] array = UnityEngine.Object.FindObjectsOfType<BiomeMaskArea>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				PostProcessProfileInfo postProcessProfileInfo = Instance_GetPostProcessProfileInfo(array[i].BiomeType);
				array[i].RefreshPostProcessVolume(postProcessProfileInfo, PostProcessingLayer);
			}
		}

		public PostProcessProfileInfo Instance_GetPostProcessProfileInfo(BiomeType biomeType)
		{
			for (int i = 0; i <= PostProcessProfileInfoList.Count - 1; i++)
			{
				if (PostProcessProfileInfoList[i].BiomeType == biomeType)
				{
					return PostProcessProfileInfoList[i];
				}
			}
			return null;
		}

		public static LayerMask GetPostProcessingLayer()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.PostProcessingLayer;
			}
			return 0;
		}

		public static PostProcessProfileInfo GetPostProcessProfileInfo(BiomeType biomeType)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				return Instance.Instance_GetPostProcessProfileInfo(biomeType);
			}
			return null;
		}

		public void AddPostProcessProfile(PostProcessProfile postProcessProfile)
		{
			PostProcessProfileInfo item = new PostProcessProfileInfo
			{
				PostProcessProfile = postProcessProfile
			};
			PostProcessProfileInfoList.Add(item);
			RefreshPostProcessVolumes();
		}

		public void RemovePostProcessProfile(int index)
		{
			PostProcessProfileInfoList.RemoveAt(index);
			RefreshPostProcessVolumes();
		}

		public static string AddVegetationItem(GameObject prefab, VegetationType vegetationType, bool enableRuntimeSpawn, BiomeType biomeType = BiomeType.Default)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				string text = Guid.NewGuid().ToString();
				List<VegetationPackagePro> vegetationPackageList = GetVegetationPackageList(biomeType);
				for (int i = 0; i <= vegetationPackageList.Count - 1; i++)
				{
					vegetationPackageList[i].AddVegetationItem(prefab, vegetationType, enableRuntimeSpawn, text);
				}
				RefreshVegetationSystem();
				return text;
			}
			return "";
		}

		public static void RefreshVegetationSystem()
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
				{
					Instance.VegetationSystemList[i].RefreshVegetationSystem();
				}
			}
		}

		public static string GetVegetationItemID(string assetGuid)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				List<VegetationPackagePro> allVegetationPackageList = GetAllVegetationPackageList();
				for (int i = 0; i <= allVegetationPackageList.Count - 1; i++)
				{
					string vegetationItemID = allVegetationPackageList[i].GetVegetationItemID(assetGuid);
					if (vegetationItemID != "")
					{
						return vegetationItemID;
					}
				}
			}
			return "";
		}

		public static string AddVegetationItem(Texture2D texture, VegetationType vegetationType, bool enableRuntimeSpawn, BiomeType biomeType = BiomeType.Default)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				string text = Guid.NewGuid().ToString();
				List<VegetationPackagePro> vegetationPackageList = GetVegetationPackageList(biomeType);
				for (int i = 0; i <= vegetationPackageList.Count - 1; i++)
				{
					vegetationPackageList[i].AddVegetationItem(texture, vegetationType, enableRuntimeSpawn, text);
				}
				RefreshVegetationSystem();
				return text;
			}
			return "";
		}

		public static void AddVegetationItemInstance(string vegetationItemID, Vector3 worldPosition, Vector3 scale, Quaternion rotation, bool applyMeshRotation, byte vegetationSourceID, float distanceFalloff, bool clearCellCache = true)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.AddVegetationItemInstance(vegetationItemID, worldPosition, scale, rotation, applyMeshRotation, vegetationSourceID, distanceFalloff, clearCellCache);
				}
			}
		}

		public static void RemoveVegetationItemInstance(string vegetationItemID, Vector3 worldPosition, float minimumDistance, bool clearCellCache = true)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.RemoveVegetationItemInstance(vegetationItemID, worldPosition, minimumDistance, clearCellCache);
				}
			}
		}

		public static void RemoveVegetationItemInstance2D(string vegetationItemID, Vector3 worldPosition, float minimumDistance, bool clearCellCache = true)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.RemoveVegetationItemInstance2D(vegetationItemID, worldPosition, minimumDistance, clearCellCache);
				}
			}
		}

		public static void RemoveVegetationItemInstances(string vegetationItemID, byte vegetationSourceID)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.RemoveVegetationItemInstances(vegetationItemID, vegetationSourceID);
				}
			}
		}

		public static void RemoveVegetationItemInstances(string vegetationItemID)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.RemoveVegetationItemInstances(vegetationItemID);
				}
			}
		}

		public static void AddVegetationItemInstanceEx(string vegetationItemID, Vector3 worldPosition, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float minimumDistance, float distanceFalloff, bool clearCellCache = true)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				PersistentVegetationStorage persistentVegetationStorage = Instance.VegetationSystemList[i].PersistentVegetationStorage;
				if ((bool)persistentVegetationStorage)
				{
					persistentVegetationStorage.AddVegetationItemInstanceEx(vegetationItemID, worldPosition, scale, rotation, vegetationSourceID, minimumDistance, distanceFalloff, clearCellCache);
				}
			}
		}

		public static List<VegetationPackagePro> GetVegetationPackageList(BiomeType biomeType)
		{
			List<VegetationPackagePro> list = new List<VegetationPackagePro>();
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return list;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemPro vegetationSystemPro = Instance.VegetationSystemList[i];
				if ((bool)vegetationSystemPro)
				{
					VegetationPackagePro vegetationPackageFromBiome = vegetationSystemPro.GetVegetationPackageFromBiome(biomeType);
					if ((bool)vegetationPackageFromBiome)
					{
						list.Add(vegetationPackageFromBiome);
					}
				}
			}
			return list;
		}

		public static List<VegetationPackagePro> GetAllVegetationPackageList()
		{
			List<VegetationPackagePro> list = new List<VegetationPackagePro>();
			if (!Instance)
			{
				FindInstance();
			}
			if (!Instance)
			{
				return list;
			}
			for (int i = 0; i <= Instance.VegetationSystemList.Count - 1; i++)
			{
				VegetationSystemPro vegetationSystemPro = Instance.VegetationSystemList[i];
				if ((bool)vegetationSystemPro)
				{
					list.AddRange(vegetationSystemPro.VegetationPackageProList);
				}
			}
			return list;
		}

		public static void ClearVegetationItemInstancesArea(string vegetationItemID, Bounds bounds)
		{
			Debug.Log("Not implemented");
		}

		public static void ClearVegetationItemInstancesArea(string vegetationItemID, byte vegetationSourceID, Bounds bounds)
		{
			Debug.Log("Not implemented");
		}

		public static void AddVegetationMask(BaseMaskArea maskArea)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_AddVegetationMask(maskArea);
			}
		}

		public static void RemoveVegetationMask(BaseMaskArea maskArea)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.Instance_RemoveVegetationMask(maskArea);
			}
		}

		public void Instance_AddVegetationMask(BaseMaskArea maskArea)
		{
			if (!_vegetationMaskList.Contains(maskArea))
			{
				_vegetationMaskList.Add(maskArea);
			}
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if ((bool)VegetationSystemList[i])
				{
					AddVegetationMaskToVegetationSystem(VegetationSystemList[i], maskArea);
				}
			}
		}

		public void Instance_RemoveVegetationMask(BaseMaskArea maskArea)
		{
			_vegetationMaskList.Remove(maskArea);
			Rect area = RectExtension.CreateRectFromBounds(maskArea.MaskBounds);
			List<BillboardCell> list = new List<BillboardCell>();
			for (int i = 0; i <= VegetationSystemList.Count - 1; i++)
			{
				if ((bool)VegetationSystemList[i])
				{
					VegetationSystemPro vegetationSystemPro = VegetationSystemList[i];
					vegetationSystemPro.CompleteCellLoading();
					vegetationSystemPro.BillboardCellQuadTree.Query(area, list);
					for (int j = 0; j <= list.Count - 1; j++)
					{
						list[j].ClearCache();
					}
				}
			}
			maskArea.CallDeleteEvent();
			maskArea.Dispose();
		}

		private void DisposeVegetationMasksMasks()
		{
			for (int i = 0; i <= _vegetationMaskList.Count - 1; i++)
			{
				_vegetationMaskList[i].CallDeleteEvent();
				_vegetationMaskList[i].Dispose();
			}
			_vegetationMaskList.Clear();
		}

		private static void AddVegetationMaskToVegetationSystem(VegetationSystemPro vegetationSystem, BaseMaskArea maskArea)
		{
			vegetationSystem.CompleteCellLoading();
			VegetationItemIndexes vegetationItemIndexes = default(VegetationItemIndexes);
			if (maskArea.VegetationItemID != "")
			{
				vegetationItemIndexes = vegetationSystem.GetVegetationItemIndexes(maskArea.VegetationItemID);
			}
			else
			{
				vegetationItemIndexes.VegetationPackageIndex = -1;
				vegetationItemIndexes.VegetationItemIndex = -1;
			}
			Rect area = RectExtension.CreateRectFromBounds(maskArea.MaskBounds);
			if (vegetationSystem.VegetationCellQuadTree == null || vegetationSystem.BillboardCellQuadTree == null)
			{
				return;
			}
			List<VegetationCell> list = new List<VegetationCell>();
			vegetationSystem.VegetationCellQuadTree.Query(area, list);
			if (vegetationItemIndexes.VegetationPackageIndex > -1)
			{
				for (int i = 0; i <= list.Count - 1; i++)
				{
					list[i].AddVegetationMask(maskArea, vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
				List<BillboardCell> list2 = new List<BillboardCell>();
				vegetationSystem.BillboardCellQuadTree.Query(area, list2);
				for (int j = 0; j <= list2.Count - 1; j++)
				{
					list2[j].ClearCache(vegetationItemIndexes.VegetationPackageIndex, vegetationItemIndexes.VegetationItemIndex);
				}
			}
			else
			{
				for (int k = 0; k <= list.Count - 1; k++)
				{
					list[k].AddVegetationMask(maskArea);
				}
				List<BillboardCell> list3 = new List<BillboardCell>();
				vegetationSystem.BillboardCellQuadTree.Query(area, list3);
				for (int l = 0; l <= list3.Count - 1; l++)
				{
					list3[l].ClearCache();
				}
			}
		}
	}
}
