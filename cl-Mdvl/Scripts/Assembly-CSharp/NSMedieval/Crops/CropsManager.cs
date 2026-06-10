using System;
using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.MeshTools;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Crops
{
	public class CropsManager : MonoSingleton<CropsManager>, IObserver
	{
		[NonSerialized]
		private List<CropfieldInstance> cropfields;

		[NonSerialized]
		private Dictionary<Vec3Int, CropfieldInstance> cropfieldsByNodeId;

		[NonSerialized]
		private MeshAreaMaker meshAreaMaker;

		[NonSerialized]
		private WaterManager waterManager;

		[NonSerialized]
		private StockpileColors stockpileColorsData;

		private const string ColorsPath = "Cropfields/CropfieldColor.json";

		[NonSerialized]
		private Dictionary<CropfieldInstance, CropView> instanceToView;

		[NonSerialized]
		private CropfieldInstance cropfieldToModify;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private Timer resetCanPlantCropsTimer;

		private bool canPlantCrops;

		private bool canPlantCropsRefreshDone;

		private bool forcePlantCrops;

		public List<CropfieldInstance> Cropfields => cropfields;

		public static bool UseSeeds => Math.Abs(GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("useSeeds") - 1f) < 0.01f;

		private WaterManager WaterManager => waterManager;

		public bool ForcePlantCrops
		{
			get
			{
				return forcePlantCrops;
			}
			set
			{
				forcePlantCrops = value;
			}
		}

		public void ForcePlantCropsToggle()
		{
			forcePlantCrops = !forcePlantCrops;
		}

		public CropView GetView(CropfieldInstance instance)
		{
			instanceToView.TryGetValue(instance, out var value);
			return value;
		}

		public bool HasCropfieldsForPlanting()
		{
			foreach (CropfieldInstance cropfield in cropfields)
			{
				if (cropfield.HasFreeSpace())
				{
					return true;
				}
			}
			return false;
		}

		private void OnResetCanPlantCropsTimerTick()
		{
			canPlantCropsRefreshDone = false;
		}

		public bool AnyCropfieldsWithSpacesWithoutPlants()
		{
			foreach (CropfieldInstance cropfield in cropfields)
			{
				if (cropfield.Positions.Count > cropfield.CropsCount)
				{
					return true;
				}
			}
			return false;
		}

		public bool AreAllCropfieldsHarvested()
		{
			foreach (CropfieldInstance cropfield in cropfields)
			{
				foreach (PlantMapResourceInstance value in cropfield.Crops.Values)
				{
					if (cropfield.HarvestPhase > 0 && cropfield.HarvestPhase == value.CurrentPhase)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool AreAllCropfieldsCut()
		{
			foreach (CropfieldInstance cropfield in cropfields)
			{
				if (cropfield.CropsCount > 0)
				{
					return false;
				}
			}
			return true;
		}

		public bool CanPlantCrops()
		{
			if (canPlantCropsRefreshDone)
			{
				return canPlantCrops;
			}
			if (map == null)
			{
				return false;
			}
			canPlantCropsRefreshDone = true;
			if (UseSeeds)
			{
				ResourcePileTracker resourcePileTracker = MonoSingleton<ResourcePileTracker>.Instance;
				foreach (CropfieldInstance cropfield in cropfields)
				{
					if (cropfield.HasFreeSpace() && resourcePileTracker.GetCount(cropfield.Blueprint.SeedBlueprint).AllowedCount > 0 && !cropfield.IsOnFire)
					{
						canPlantCrops = true;
						return true;
					}
				}
				canPlantCrops = false;
				return false;
			}
			foreach (CropfieldInstance cropfield2 in cropfields)
			{
				if (cropfield2.HasFreeSpace() && !cropfield2.IsOnFire)
				{
					canPlantCrops = true;
					return true;
				}
			}
			canPlantCrops = false;
			return false;
		}

		public bool HasPlant(Vec3Int gridPosition)
		{
			return GetCropfieldInstance(gridPosition)?.HasPlant(gridPosition) ?? false;
		}

		public CropfieldInstance GetCropfieldInstance(Vec3Int gridPosition)
		{
			return cropfieldsByNodeId.GetValueOrDefault(gridPosition);
		}

		public bool CanPlaceCropfield(Vec3Int v)
		{
			if (GridDataIndexTools.IsForbiddenEdge(v.x, v.z))
			{
				return false;
			}
			if (MonoSingleton<GroundManager>.Instance.GroundExists(v - Vec3Int.up))
			{
				if (MonoSingleton<GroundManager>.Instance.GroundExists(v) || !map.BuildingsManagerMain.CanPlaceCropBuildingCheck(v) || CropfieldExists(v) || !WaterConditionsMet(cropfieldToModify.Blueprint.DefaultPlant, v))
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public bool WaterConditionsMet(PlantMapResource blueprint, Vec3Int pos)
		{
			return blueprint.WaterDepthLevel.HasFlag(WaterManager.GetWaterLevelAsDepth(pos));
		}

		public bool CanPlaceCropfield(Vec3Int v, PlantMapResource plantMapResource, bool ignoreExistingCropfields = false)
		{
			MapNode node = map.GetNode(v);
			if (node == null || !node.IsVoxelAir() || node.GetNodeBelow().IsVoxelAir())
			{
				return false;
			}
			if (!ValidGround(plantMapResource, v - Vec3Int.up))
			{
				return false;
			}
			if (!WaterConditionsMet(plantMapResource, v))
			{
				return false;
			}
			if (!node.HasWorldObjects())
			{
				return true;
			}
			foreach (WorldObject worldObject in node.WorldObjects)
			{
				if (worldObject is BaseBuildingInstance baseBuildingInstance && !baseBuildingInstance.Blueprint.Socketable)
				{
					return false;
				}
				if ((!(worldObject is BaseBuildingInstance baseBuildingInstance2) || (baseBuildingInstance2.BuildingType != BuildingType.Beam && !baseBuildingInstance2.Blueprint.Socketable)) && (worldObject.Type == WorldObjectType.Building || worldObject.Type == WorldObjectType.Slope || worldObject.Type == WorldObjectType.Stockpile))
				{
					return false;
				}
			}
			foreach (WorldObject worldObject2 in node.WorldObjects)
			{
				if (worldObject2.Type == WorldObjectType.Cropfield)
				{
					return ignoreExistingCropfields;
				}
			}
			if (cropfieldsByNodeId.ContainsKey(v))
			{
				return ignoreExistingCropfields;
			}
			return true;
		}

		public bool CropfieldExists(Vec3Int v)
		{
			GridDataType gridDataType = map.GetNode(v)?.DataType ?? GridDataType.None;
			return gridDataType.HasFlag(GridDataType.Cropfield);
		}

		public void Destroy(CropfieldInstance cropfield)
		{
			if (instanceToView.ContainsKey(cropfield))
			{
				UnityEngine.Object.Destroy(instanceToView[cropfield].gameObject);
				instanceToView.Remove(cropfield);
			}
			cropfields.Remove(cropfield);
			foreach (Vec3Int position in cropfield.Positions)
			{
				cropfieldsByNodeId.Remove(position);
			}
			RemoveFromSave(cropfield);
		}

		public void SpawnProfileCropfields()
		{
			using PooledList<WorldObject> pooledList = ListPool<WorldObject>.GetJanitor(map.GetWorldObjects(GridDataType.Cropfield));
			foreach (WorldObject item in pooledList)
			{
				Load((CropfieldInstance)item);
			}
		}

		public void SetCropfieldToModify(CropfieldInstance cropfieldToModify)
		{
			this.cropfieldToModify = cropfieldToModify;
		}

		public void ModifyCropfield(Vec3Int start, Vec3Int end, OrderType orderType)
		{
			if (cropfieldToModify == null)
			{
				return;
			}
			CropfieldInstance adjacentCropfieldForExpansion = GetAdjacentCropfieldForExpansion(start, end);
			if (cropfieldToModify == adjacentCropfieldForExpansion)
			{
				if (orderType.Equals(OrderType.ShrinkZone))
				{
					ShrinkCropfield(cropfieldToModify, GetShrinkValidPositions(start, end));
				}
				else
				{
					ExpandCropfield(cropfieldToModify, GetExpandValidPositions(start, end));
				}
			}
		}

		public void RefreshCropPlantsAfterPlantSpawning()
		{
			foreach (CropfieldInstance cropfield in cropfields)
			{
				cropfield.RefreshPlantsAfterLoading();
			}
		}

		public void CropPlantTypeChanged(CropfieldInstance cropfieldInstance)
		{
			List<Vec3Int> list = ListPool<Vec3Int>.Get();
			foreach (Vec3Int position in cropfieldInstance.Positions)
			{
				list.Add(position);
			}
			cropfieldToModify = cropfieldInstance;
			ExpandCropfield(cropfieldInstance, list);
			ListPool<Vec3Int>.Return(list);
			cropfieldToModify = null;
		}

		private void ShrinkCropfield(CropfieldInstance cropfieldInstance, List<Vec3Int> validPositions)
		{
			if (cropfieldInstance != null && instanceToView.ContainsKey(cropfieldInstance))
			{
				PlantMapResource cultivablePlant = cropfieldInstance.CultivablePlant;
				Vec3Int[,] modifiedCropsMeshArea = meshAreaMaker.GetModifiedCropsMeshArea(cropfieldInstance.Start, cropfieldInstance.End, validPositions, cultivablePlant, CanPlaceCropfield);
				ClearCropfieldByNodeId(cropfieldInstance);
				cropfieldInstance.UpdateArea(modifiedCropsMeshArea);
				UpdateCropfieldByNodeId(cropfieldInstance);
				cropfieldInstance.UpdateDomesticPlants();
				if (modifiedCropsMeshArea.AllEquals(Vec3Int.zero))
				{
					cropfieldInstance.Dispose();
					return;
				}
				CropView cropView = instanceToView[cropfieldInstance];
				Mesh mesh2D = Singleton<GreedyMeshGenerator>.Instance.GetMesh2D(cropfieldInstance.Start, cropfieldInstance.End, modifiedCropsMeshArea, Vec3Int.zero);
				cropView.Setup(mesh2D);
			}
		}

		private List<Vec3Int> GetShrinkValidPositions(Vec3Int start, Vec3Int end)
		{
			int num = Mathf.Min(start.x, end.x);
			int num2 = Mathf.Max(start.x, end.x);
			int num3 = Mathf.Min(start.z, end.z);
			int num4 = Mathf.Max(start.z, end.z);
			List<Vec3Int> list = new List<Vec3Int>();
			foreach (Vec3Int position in cropfieldToModify.Positions)
			{
				if (position.x < num || position.x > num2 || position.z < num3 || position.z > num4)
				{
					list.Add(position);
				}
			}
			return list;
		}

		private void ExpandCropfield(CropfieldInstance cropfieldInstance, List<Vec3Int> validPositions)
		{
			Vec3Int vec3Int = validPositions.MinX();
			Vec3Int vec3Int2 = validPositions.MaxX();
			Vec3Int vec3Int3 = validPositions.MinZ();
			Vec3Int vec3Int4 = validPositions.MaxZ();
			int y = vec3Int.y * World.MapBlockHeight;
			Vec3Int lhs = new Vec3Int(vec3Int.x, y, vec3Int3.z);
			Vec3Int rhs = new Vec3Int(vec3Int2.x, y, vec3Int4.z);
			Vec3Int vec3Int5 = Vec3Int.Min(in lhs, in rhs);
			Vec3Int vec3Int6 = Vec3Int.Max(in lhs, in rhs);
			PlantMapResource cultivablePlant = cropfieldInstance.CultivablePlant;
			Vec3Int[,] modifiedCropsMeshArea = meshAreaMaker.GetModifiedCropsMeshArea(vec3Int5, vec3Int6, validPositions, cultivablePlant, CanPlaceCropfield);
			foreach (Vec3Int validPosition in validPositions)
			{
				Vec3Int a = validPosition;
				if (!cropfieldInstance.Positions.Contains(a) && !ValidGround(cropfieldInstance.CultivablePlant, a + Vec3Int.down))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_cropfield_placement"));
					break;
				}
			}
			if (modifiedCropsMeshArea.AllEquals(Vec3Int.zero))
			{
				cropfieldInstance.Dispose();
			}
			else
			{
				if (!cropfieldInstance.IsExpandValid(modifiedCropsMeshArea))
				{
					return;
				}
				cropfieldInstance.Start = vec3Int5;
				cropfieldInstance.End = vec3Int6;
				CropView cropView = instanceToView[cropfieldInstance];
				Mesh mesh2D = Singleton<GreedyMeshGenerator>.Instance.GetMesh2D(cropfieldInstance.Start, cropfieldInstance.End, modifiedCropsMeshArea, Vec3Int.zero);
				cropView.Setup(mesh2D);
				cropView.transform.position = (Vector3)Vec3Int.Min(cropfieldInstance.Start, cropfieldInstance.End) + new Vector3(-0.5f, 0.03f, -0.5f);
				ClearCropfieldByNodeId(cropfieldInstance);
				cropfieldInstance.UpdateArea(modifiedCropsMeshArea);
				UpdateCropfieldByNodeId(cropfieldInstance);
				cropfieldInstance.UpdateDomesticPlants();
				map.OnWorldObjectSizeChanged(cropfieldInstance);
				MonoSingleton<CropsController>.Instance.CropfieldPlaced(cropfieldInstance);
				if (!ForcePlantCrops)
				{
					return;
				}
				Vec3Int[,] area = cropfieldInstance.Area;
				foreach (Vec3Int gridPos in area)
				{
					cropfieldInstance.PlantCrop(gridPos);
				}
			}
		}

		private List<Vec3Int> GetExpandValidPositions(Vec3Int newAreaStart, Vec3Int newAreaEnd)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			int num = Mathf.Min(newAreaStart.x, newAreaEnd.x);
			int num2 = Mathf.Max(newAreaStart.x, newAreaEnd.x);
			int num3 = Mathf.Min(newAreaStart.z, newAreaEnd.z);
			int num4 = Mathf.Max(newAreaStart.z, newAreaEnd.z);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					pooledList.Add(new Vec3Int(i, newAreaStart.y, j));
				}
			}
			foreach (Vec3Int item in pooledList.IterateInReverseDynamic())
			{
				if (cropfieldToModify.ContainsGridspace(item))
				{
					pooledList.Remove(item);
				}
				if (!CanPlaceCropfield(new Vec3Int(item.x, item.y / World.MapBlockHeight, item.z)))
				{
					pooledList.Remove(item);
				}
			}
			foreach (Vec3Int position in cropfieldToModify.Positions)
			{
				list.Add(position);
			}
			foreach (Vec3Int item2 in pooledList)
			{
				list.Add(((Vector3)item2).ToGridVec3Int());
			}
			return list;
		}

		private CropfieldInstance GetAdjacentCropfieldForExpansion(Vec3Int start, Vec3Int end)
		{
			int y = start.y / World.MapBlockHeight;
			int num = Mathf.Min(start.x, end.x);
			int num2 = Mathf.Max(start.x, end.x);
			int num3 = Mathf.Min(start.z, end.z);
			int num4 = Mathf.Max(start.z, end.z);
			for (int i = num - 1; i <= num2 + 1; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					CropfieldInstance byPosition = GetByPosition(new Vec3Int(i, y, j));
					if (cropfieldToModify == byPosition)
					{
						return byPosition;
					}
				}
			}
			for (int k = num; k <= num2; k++)
			{
				for (int l = num3 - 1; l <= num4 + 1; l++)
				{
					CropfieldInstance byPosition2 = GetByPosition(new Vec3Int(k, y, l));
					if (cropfieldToModify == byPosition2)
					{
						return byPosition2;
					}
				}
			}
			return null;
		}

		private CropfieldInstance GetByPosition(Vec3Int position)
		{
			return cropfieldsByNodeId.GetValueOrDefault(position);
		}

		private bool ValidGround(PlantMapResource plantMapResource, Vec3Int position)
		{
			if (plantMapResource == null)
			{
				return true;
			}
			VoxelType voxelType = map.GetNode(position)?.VoxelType;
			if (voxelType == null)
			{
				return false;
			}
			foreach (string item in plantMapResource.GrowsOn)
			{
				if (voxelType.GetID().Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public void SpawnCropfield(Vec3Int start, Vec3Int end, string cropfieldID)
		{
			Cropfield byID = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(cropfieldID);
			PlantMapResource defaultPlant = byID.DefaultPlant;
			Vec3Int vec3Int = Vec3Int.Min(in start, in end);
			Vec3Int vec3Int2 = Vec3Int.Max(in start, in end);
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt))
			{
				for (int i = vec3Int.x; i <= vec3Int2.x; i++)
				{
					for (int j = vec3Int.z; j <= vec3Int2.z; j++)
					{
						UnstuckGhostCrops(new Vec3Int(i, vec3Int.y / World.MapBlockHeight, j));
					}
				}
			}
			if (cropfieldToModify != null)
			{
				CropfieldInstance adjacentCropfieldForExpansion = GetAdjacentCropfieldForExpansion(start, end);
				if (cropfieldToModify == adjacentCropfieldForExpansion && cropfieldToModify.CultivablePlant.Equals(defaultPlant))
				{
					ExpandCropfield(cropfieldToModify, GetExpandValidPositions(start, end));
					return;
				}
			}
			Vec3Int[,] meshAreaCrops = meshAreaMaker.GetMeshAreaCrops(start, end, defaultPlant, CanPlaceCropfield);
			foreach (Vec3Int item in meshAreaCrops.ConvertToList())
			{
				if (!ValidGround(defaultPlant, item + Vec3Int.down))
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_cropfield_placement"));
					break;
				}
			}
			if (meshAreaCrops.AllEquals(Vec3Int.zero))
			{
				return;
			}
			Vector3 vector = (Vector3)Vec3Int.Min(in start, in end);
			Vector3 vector2 = (Vector3)Vec3Int.Max(in start, in end);
			CropView component = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByID("CropField").Value, vector + new Vector3(-0.5f, 0.01f, -0.5f), Quaternion.identity).GetComponent<CropView>();
			CropfieldInstance cropfieldInstance = new CropfieldInstance(byID, vector, meshAreaCrops, start, end);
			Mesh mesh2D = Singleton<GreedyMeshGenerator>.Instance.GetMesh2D((Vec3Int)vector, (Vec3Int)vector2, meshAreaCrops, Vec3Int.zero);
			component.Setup(mesh2D);
			component.Setup(cropfieldInstance, stockpileColorsData.GetNextColor());
			Save(cropfieldInstance, component);
			MonoSingleton<CropsController>.Instance.CropfieldPlaced(cropfieldInstance);
			cropfieldToModify = cropfieldInstance;
			if (!WorkerManager.WorkerExistsCheckJobAndSkill(SkillType.Botanical, JobType.PlantCropfields, cropfieldInstance.Blueprint.DefaultPlant.MinBotanicalSkill))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_skilled_botany_worker"));
			}
			if (!ForcePlantCrops)
			{
				return;
			}
			Vec3Int[,] area = cropfieldInstance.Area;
			foreach (Vec3Int gridPos in area)
			{
				cropfieldInstance.PlantCrop(gridPos);
			}
		}

		private void RefreshCropfield(CropfieldInstance cropInstance)
		{
			if (cropInstance == null || !instanceToView.ContainsKey(cropInstance))
			{
				return;
			}
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			foreach (Vec3Int position in cropInstance.Positions)
			{
				pooledList.Add(position);
			}
			PlantMapResource cultivablePlant = cropInstance.CultivablePlant;
			Vec3Int[,] modifiedCropsMeshArea = meshAreaMaker.GetModifiedCropsMeshArea(cropInstance.Start, cropInstance.End, pooledList, cultivablePlant, CanPlaceCropfield);
			if (modifiedCropsMeshArea.AllEquals(Vec3Int.zero))
			{
				cropInstance.Dispose();
				return;
			}
			CropView cropView = instanceToView[cropInstance];
			Mesh mesh2D = Singleton<GreedyMeshGenerator>.Instance.GetMesh2D(cropInstance.Start, cropInstance.End, modifiedCropsMeshArea, Vec3Int.zero);
			cropView.Setup(mesh2D);
			ClearCropfieldByNodeId(cropInstance);
			cropInstance.UpdateArea(modifiedCropsMeshArea);
			UpdateCropfieldByNodeId(cropInstance);
			cropInstance.UpdateDomesticPlants();
		}

		public void Initialize(VillageMap villageMap)
		{
			map = villageMap;
			waterManager = map.WaterManager;
			cropfields = new List<CropfieldInstance>();
			cropfieldsByNodeId = new Dictionary<Vec3Int, CropfieldInstance>();
			instanceToView = new Dictionary<CropfieldInstance, CropView>();
		}

		private void Start()
		{
			string json = FileUtils.SafeReadAllText(Path.Combine(Application.streamingAssetsPath, "Cropfields/CropfieldColor.json"));
			stockpileColorsData = JsonUtility.FromJson<StockpileColors>(json);
			meshAreaMaker = new MeshAreaMaker();
			MonoSingleton<CropsController>.Instance.CreateCropfieldEvent += SpawnCropfield;
			MonoSingleton<SelectionManager>.Instance.ResetOrderEvent += OnSelectionToolReset;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyedSingle;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			MonoSingleton<ConstructionController>.Instance.ObjectDestroyedCheckFallDownEvent += OnObjectDestroyedCheckFallDown;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedCarveAreasEvent += OnBlueprintPlacedCarveCrops;
			resetCanPlantCropsTimer = new Timer(0.5f, restartOnEnd: true);
			resetCanPlantCropsTimer.AddCallback(OnResetCanPlantCropsTimerTick);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<CropsController>.IsInstantiated())
			{
				MonoSingleton<CropsController>.Instance.CreateCropfieldEvent -= SpawnCropfield;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.ResetOrderEvent -= OnSelectionToolReset;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.BlueprintPlacedCarveAreasEvent -= OnBlueprintPlacedCarveCrops;
				MonoSingleton<ConstructionController>.Instance.ObjectDestroyedCheckFallDownEvent -= OnObjectDestroyedCheckFallDown;
			}
			base.OnDestroy();
			map = null;
			resetCanPlantCropsTimer?.Dispose();
			resetCanPlantCropsTimer = null;
			cropfields?.Clear();
			cropfields = null;
			instanceToView?.Clear();
			instanceToView = null;
			cropfieldToModify = null;
			cropfieldsByNodeId?.Clear();
			cropfieldsByNodeId = null;
			meshAreaMaker = null;
		}

		private void ClearCropfieldByNodeId(CropfieldInstance cropInstance)
		{
			foreach (Vec3Int position in cropInstance.Positions)
			{
				cropfieldsByNodeId.Remove(position);
			}
		}

		private void UpdateCropfieldByNodeId(CropfieldInstance cropInstance)
		{
			foreach (Vec3Int position in cropInstance.Positions)
			{
				cropfieldsByNodeId.TryAdd(position, cropInstance);
			}
		}

		private void Save(CropfieldInstance cropfield, CropView view)
		{
			map.AddAreaToTheWorld(cropfield);
			cropfields.Add(cropfield);
			instanceToView.Add(cropfield, view);
			foreach (Vec3Int position in cropfield.Positions)
			{
				if (!cropfieldsByNodeId.TryAdd(position, cropfield))
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropsManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Key ");
						messageBuilder.AppendFormatted(position);
						messageBuilder.AppendLiteral(" already added to the dictionary for ");
						messageBuilder.AppendFormatted(cropfield.BlueprintId);
					}
					Log.Warning(messageBuilder);
				}
			}
		}

		private void RemoveFromSave(CropfieldInstance cropfield)
		{
			map.RemoveAreaFromWorld(cropfield);
		}

		private void Load(CropfieldInstance instance)
		{
			if (Repository<CropfieldRepository, Cropfield>.Instance.GetByID(instance.BlueprintId) == null)
			{
				RemoveFromSave(instance);
			}
			else
			{
				if (instanceToView.ContainsKey(instance))
				{
					return;
				}
				if (instance.Positions == null || instance.Positions.Count == 0)
				{
					instance.Dispose();
					return;
				}
				foreach (Vec3Int position in instance.Positions)
				{
					if (cropfieldsByNodeId.ContainsKey(position))
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(67, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropsManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Found overlapping cropfield ");
							messageBuilder.AppendFormatted(instance.BlueprintId);
							messageBuilder.AppendLiteral(" at position ");
							messageBuilder.AppendFormatted(position);
							messageBuilder.AppendLiteral(". Disposing the cropfield.");
						}
						Log.Warning(messageBuilder);
						instance.Dispose();
						return;
					}
				}
				Vec3Int lhs = instance.Start;
				Vec3Int rhs = instance.End;
				PlantMapResource cultivablePlant = instance.CultivablePlant;
				Vec3Int[,] modifiedCropsMeshArea = meshAreaMaker.GetModifiedCropsMeshArea(lhs, rhs, instance.Positions, cultivablePlant, CanPlaceCropfield);
				if (modifiedCropsMeshArea.AllEquals(Vec3Int.zero))
				{
					RemoveFromSave(instance);
					return;
				}
				Vec3Int vec3Int = Vec3Int.Min(in lhs, in rhs);
				Vec3Int end = Vec3Int.Max(in lhs, in rhs);
				CropView component = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByID("CropField").Value, (Vector3)vec3Int + new Vector3(-0.5f, 0.01f, -0.5f), Quaternion.identity).GetComponent<CropView>();
				Mesh mesh2D = Singleton<GreedyMeshGenerator>.Instance.GetMesh2D(vec3Int, end, modifiedCropsMeshArea, Vec3Int.zero);
				component.Setup(mesh2D);
				component.Setup(instance, stockpileColorsData.GetNextColor());
				Save(instance, component);
				instance.ReInstantiate();
				instance.UpdateDomesticPlants();
				instance.OnLoaded();
			}
		}

		private void UnstuckGhostCrops(Vec3Int gridPosition)
		{
			MapNode node = map.GetNode(gridPosition);
			if (node == null)
			{
				return;
			}
			foreach (WorldObject item in node.WorldObjects.IterateInReverseDynamic())
			{
				if (!(item is CropfieldInstance cropfieldInstance))
				{
					continue;
				}
				bool isEnabled;
				if (instanceToView.ContainsKey(cropfieldInstance))
				{
					if (!cropfieldInstance.Positions.Contains(gridPosition))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropsManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Deleting ghost crop ");
							messageBuilder.AppendFormatted(cropfieldInstance.BlueprintId);
							messageBuilder.AppendLiteral(" at position ");
							messageBuilder.AppendFormatted(gridPosition);
						}
						Log.Error(messageBuilder);
						node.RemoveObject(cropfieldInstance);
					}
				}
				else
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropsManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Deleting ghost crop ");
						messageBuilder.AppendFormatted(cropfieldInstance.BlueprintId);
						messageBuilder.AppendLiteral(" at position ");
						messageBuilder.AppendFormatted(gridPosition);
					}
					Log.Error(messageBuilder);
					node.RemoveObject(cropfieldInstance);
				}
			}
		}

		private void OnBlueprintPlacedCarveCrops(List<BaseBuildingInstance> buildings)
		{
			using PooledList<CropfieldInstance> pooledList = ListPool<CropfieldInstance>.GetJanitor();
			foreach (BaseBuildingInstance building in buildings)
			{
				foreach (Vec3Int position in building.Positions)
				{
					CropfieldInstance byPosition = GetByPosition(position);
					if (!pooledList.Contains(byPosition))
					{
						pooledList.Add(byPosition);
					}
				}
			}
			foreach (CropfieldInstance item in pooledList)
			{
				RefreshCropfield(item);
			}
		}

		private void OnGroundDestroyedSingle(Vec3Int position)
		{
			if (CropfieldExists(position + Vec3Int.up))
			{
				RefreshCropfield(GetByPosition(position));
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			HashSet<CropfieldInstance> hashSet = new HashSet<CropfieldInstance>();
			foreach (Vec3Int position in positions)
			{
				Vec3Int a = position;
				if (CropfieldExists(a + Vec3Int.up))
				{
					hashSet.Add(GetByPosition(a + Vec3Int.up));
				}
			}
			foreach (CropfieldInstance item in hashSet)
			{
				RefreshCropfield(item);
			}
		}

		private void OnObjectDestroyedCheckFallDown(Vec3Int gridPosition)
		{
			foreach (CropfieldInstance item2 in cropfields.IterateInReverseDynamic())
			{
				Vec3Int item = gridPosition + Vec3Int.up;
				if (item2.Positions.Contains(item) && !MonoSingleton<GroundManager>.Instance.GroundExists(gridPosition))
				{
					RefreshCropfield(item2);
				}
			}
		}

		private void OnSelectionToolReset()
		{
			cropfieldToModify = null;
		}
	}
}
