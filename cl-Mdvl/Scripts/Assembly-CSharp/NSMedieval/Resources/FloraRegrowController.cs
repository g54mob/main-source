using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Resources
{
	public class FloraRegrowController : MonoSingleton<FloraRegrowController>
	{
		private readonly Dictionary<PlantMapResource, HashSet<VoxelType>> plantResourceGrowsOn = new Dictionary<PlantMapResource, HashSet<VoxelType>>();

		private PlantMapResource[,] fieldUsedBy;

		private readonly Dictionary<string, int> plantsToAddCount = new Dictionary<string, int>();

		private readonly Dictionary<string, int> plantCountByType = new Dictionary<string, int>();

		private float minPlantsPercent;

		private int hoursInDay = 24;

		private readonly List<Vec3Int> randomNeighbors = new List<Vec3Int>();

		private float plantSpawnRateByMapSize;

		private Dictionary<string, float> growNewPlant => GlobalSaveController.CurrentVillageData.PlantsGrowValue;

		public Dictionary<string, int> PlantCountByType => plantCountByType;

		public bool CanPlantGrowOnVoxelType(PlantMapResource plantMapResource, VoxelType voxelType)
		{
			if (plantMapResource == null)
			{
				return false;
			}
			if (plantResourceGrowsOn.Count == 0)
			{
				InitPlantResourceGrowsOn();
			}
			if (plantResourceGrowsOn[plantMapResource].Count == 0)
			{
				return true;
			}
			return plantResourceGrowsOn[plantMapResource].Contains(voxelType);
		}

		private PlantMapResource GetPositionUsedBy(Vec3Int gridDataPosition)
		{
			return fieldUsedBy[gridDataPosition.x, gridDataPosition.z];
		}

		public PlantMapResource GetPositionUsedBy(int x, int y)
		{
			return fieldUsedBy[x, y];
		}

		internal void OnPlantInstantiated(PlantMapResourceInstance resourceInstance)
		{
			_ = GetPositionUsedBy(resourceInstance.GridDataPosition) != null;
			AddToPlantCount(resourceInstance.Blueprint, 1);
			MarkPositionUsedBy(resourceInstance.GridDataPosition, resourceInstance.Blueprint);
		}

		internal void OnPlantDestroyed(PlantMapResourceInstance resourceInstance)
		{
			MarkPositionUsedBy(resourceInstance.GridDataPosition, null);
			AddToPlantCount(resourceInstance.Blueprint, -1);
		}

		internal void InitMapSize(VillageMap map)
		{
			if (fieldUsedBy == null || fieldUsedBy.GetLength(0) != map.Size.x || fieldUsedBy.GetLength(1) != map.Size.z)
			{
				fieldUsedBy = new PlantMapResource[map.Size.x, map.Size.z];
			}
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitialize;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			hoursInDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
			plantSpawnRateByMapSize = GlobalSaveController.CurrentVillageData.MapSizeInstance.PlantSpawnRateMultiplier;
		}

		private void OnDateTimeInitialize()
		{
			CountPlants();
			InitializePlantsMinimumCount();
			CountPlantsToAdd();
		}

		private void CountPlants()
		{
			plantCountByType.Clear();
			foreach (PlantMapResource allItem in Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems())
			{
				if (!plantCountByType.ContainsKey(allItem.GetID()))
				{
					plantCountByType.Add(allItem.GetID(), 0);
				}
			}
			foreach (string item in from resource in VillageManager.ActiveVillage.Map.GetWorldObjectsList<PlantMapResourceInstance>(GridDataType.PlantMapResource)
				select resource.Blueprint.GetID())
			{
				if (!plantCountByType.TryAdd(item, 1))
				{
					plantCountByType[item]++;
				}
			}
			foreach (string key in GlobalSaveController.CurrentVillageData.MinNumberOfPlants.Keys)
			{
				plantCountByType.TryAdd(key, 0);
			}
		}

		private void InitializePlantsMinimumCount()
		{
			if (GlobalSaveController.CurrentVillageData.MinNumberOfPlants.Count > 0)
			{
				return;
			}
			minPlantsPercent = GlobalSaveController.CurrentVillageData.MapBlueprint.MinPlantsPercent;
			foreach (string key in plantCountByType.Keys)
			{
				if (plantCountByType.TryGetValue(key, out var value))
				{
					float num = minPlantsPercent * (float)value / 100f;
					GlobalSaveController.CurrentVillageData.MinNumberOfPlants[key] = (int)num;
				}
			}
		}

		private void OnDateUpdate()
		{
			CountPlantsToAdd();
		}

		private void OnHourUpdate()
		{
			TryPlanting();
		}

		private void CountPlantsToAdd()
		{
			foreach (KeyValuePair<string, int> item in plantCountByType)
			{
				string key = item.Key;
				int value = item.Value;
				GlobalSaveController.CurrentVillageData.MinNumberOfPlants.TryAdd(key, 0);
				int num = GlobalSaveController.CurrentVillageData.MinNumberOfPlants[key];
				PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(key);
				if (byID != null)
				{
					num = Math.Max(num, byID.MaxCount);
				}
				growNewPlant.TryAdd(key, 0f);
				if (value < num)
				{
					plantsToAddCount.TryAdd(key, 0);
					plantsToAddCount[key] = num - value;
				}
				else
				{
					growNewPlant[key] = 0f;
				}
			}
		}

		private void TryPlanting()
		{
			string[] array = plantsToAddCount.Keys.ToArray();
			foreach (string text in array)
			{
				if (plantsToAddCount[text] > 0)
				{
					PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(text);
					if (byID != null)
					{
						if (!byID.CanSpawnOnZeroCount && plantCountByType.ContainsKey(text) && plantCountByType[text] <= 0)
						{
							continue;
						}
						growNewPlant[text] += byID.NewPlantsPerDay * plantSpawnRateByMapSize / (float)hoursInDay;
					}
				}
				if (growNewPlant[text] >= 1f)
				{
					int num = Mathf.FloorToInt(growNewPlant[text]);
					growNewPlant[text] -= num;
					plantsToAddCount[text] -= num;
					for (int j = 0; j < num; j++)
					{
						SpawnPlant(text);
					}
				}
			}
		}

		private bool SpawnPlant(string blueprintId)
		{
			PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\FloraRegrowController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Plant blueprint ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" does not exist.");
				}
				Log.Error(messageBuilder);
				return false;
			}
			return SpawnPlant(byID);
		}

		private bool SpawnPlant(PlantMapResource blueprint)
		{
			if (GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius < blueprint.NewPlantTemperatureLimit)
			{
				Log.Debug("Can't place a plant: temperature is too low.", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\FloraRegrowController.cs");
				return false;
			}
			if (!GetPositionForNewPlant(blueprint, -1, out var plantPosition))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(52, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\FloraRegrowController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't get place for plant ");
					messageBuilder.AppendFormatted(blueprint.GetID());
					messageBuilder.AppendLiteral(" (neighbor check mode = ");
					messageBuilder.AppendFormatted(blueprint.NeighborCheck);
					messageBuilder.AppendLiteral(").");
				}
				Log.Debug(messageBuilder);
				if (!GetRandomPositionForNewPlant(blueprint, out plantPosition))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\FloraRegrowController.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can't get a random place for plant ");
						messageBuilder.AppendFormatted(blueprint.GetID());
						messageBuilder.AppendLiteral(".");
					}
					Log.Debug(messageBuilder);
					return false;
				}
			}
			SpawnYoungPlant(blueprint, plantPosition.x, plantPosition.y, plantPosition.z);
			return true;
		}

		private void ShuffleNeighbors()
		{
			if (randomNeighbors.Count == 0)
			{
				randomNeighbors.AddRange(MapNodeUtils.NeighborsXZ);
				randomNeighbors.AddRange(MapNodeUtils.NeighborsXZRadius2);
			}
			randomNeighbors.ShuffleInPlace();
		}

		private bool GetPositionForNewPlant(PlantMapResource blueprint, int neighborCheckMode, out Vec3Int plantPosition)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			int num = ((neighborCheckMode != -1) ? neighborCheckMode : blueprint.NeighborCheck);
			if (num == 0 || (blueprint.PlaceAnywhereChance > 0f && UnityEngine.Random.Range(0f, 1f) < blueprint.PlaceAnywhereChance))
			{
				return GetRandomPositionForNewPlant(blueprint, out plantPosition);
			}
			ShuffleNeighbors();
			using PooledHashSet<Vec3Int> pooledHashSet = HashSetPool<Vec3Int>.GetJanitor();
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			foreach (WorldObject worldObject in map.GetWorldObjects(GridDataType.PlantMapResource))
			{
				if (worldObject is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint == blueprint)
				{
					pooledList.Insert(UnityEngine.Random.Range(0, pooledList.Count + 1), plantMapResourceInstance.GridDataPosition);
					pooledHashSet.Add(plantMapResourceInstance.GridDataPosition);
				}
			}
			while (pooledList.Count > 0)
			{
				Vec3Int b = pooledList[0];
				pooledList.Remove(b);
				pooledHashSet.Add(b);
				foreach (Vec3Int randomNeighbor in randomNeighbors)
				{
					Vec3Int a = randomNeighbor + b;
					if (GridDataIndexTools.FastTo1DIndex(a) == -1 || !pooledHashSet.Add(a))
					{
						continue;
					}
					MapNode node = map.GetNode(a);
					if (node == null || node.VoxelType != null)
					{
						continue;
					}
					pooledList.Add(a);
					if (node.DataType == GridDataType.None && !node.CheckIsDataType(GridDataType.Slope) && CanPlantGrowOnVoxelType(blueprint, node.GetNodeBelow().VoxelType) && MonoSingleton<CropsManager>.Instance.WaterConditionsMet(blueprint, node.Position))
					{
						bool flag = true;
						switch (num)
						{
						case 2:
						{
							Vec3Int pos = a + Vec3Int.left * UnityEngine.Random.Range(-1, 2) + Vec3Int.forward * UnityEngine.Random.Range(-1, 2);
							flag = !IsAnyPlantAround(pos, MapNodeUtils.NeighborsXZ) && IsPlantTypeAround(a, blueprint, MapNodeUtils.NeighborsXZRadius2);
							break;
						}
						case 1:
							flag = IsPlantTypeAround(a, blueprint, MapNodeUtils.NeighborsXZ);
							break;
						}
						if (flag)
						{
							plantPosition = a;
							return true;
						}
					}
				}
			}
			plantPosition = Vec3Int.zero;
			return false;
		}

		private bool GetRandomPositionForNewPlant(PlantMapResource blueprint, out Vec3Int plantPosition)
		{
			Heightmap heightmap = MonoSingleton<Heightmap>.Instance;
			VillageMap map = VillageManager.ActiveVillage.Map;
			Vec3Int zero = Vec3Int.zero;
			int num = 0;
			while (num++ < 300)
			{
				zero.x = UnityEngine.Random.Range(0, map.Size.x);
				zero.z = UnityEngine.Random.Range(0, map.Size.z);
				zero.y = heightmap.GetHeightAt(zero.x, zero.z);
				MapNode node = map.GetNode(zero);
				if (node != null && !(node.VoxelType != null) && !node.CheckIsDataType(GridDataType.Slope) && node.DataType == GridDataType.None)
				{
					MapNode nodeBelow = node.GetNodeBelow();
					if (nodeBelow != null && CanPlantGrowOnVoxelType(blueprint, nodeBelow.VoxelType) && MonoSingleton<CropsManager>.Instance.WaterConditionsMet(blueprint, node.Position))
					{
						plantPosition = zero;
						return true;
					}
				}
			}
			plantPosition = new Vec3Int(0, 0, 0);
			return false;
		}

		private void SpawnYoungPlant(PlantMapResource blueprint, int x, int y, int z)
		{
			if (blueprint == null)
			{
				Log.Info("Cannot place plant; blueprint missing.", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\FloraRegrowController.cs");
				return;
			}
			string prefabId = blueprint.PrefabIDs.PickRandom();
			Vector3 position = new Vector3(x, y * World.MapBlockHeight, z);
			MonoSingleton<PlantResourceManager>.Instance.SpawnPlantMapResource(blueprint.GetID(), position, prefabId, 0, domestic: false, randomPhaseHours: false);
		}

		private bool IsAnyPlantAround(Vec3Int pos, IEnumerable<Vec3Int> neighbors)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (Vec3Int neighbor in neighbors)
			{
				Vec3Int vec3Int = pos + neighbor;
				if (GridDataIndexTools.InRange(vec3Int))
				{
					MapNode node = map.GetNode(vec3Int);
					if (node != null && node.CheckIsDataType(GridDataType.PlantMapResource))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsPlantTypeAround(Vec3Int pos, PlantMapResource plantType, IEnumerable<Vec3Int> neighbors)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (Vec3Int neighbor in neighbors)
			{
				Vec3Int vec3Int = pos + neighbor;
				if (GridDataIndexTools.InRange(vec3Int))
				{
					MapNode node = map.GetNode(vec3Int);
					if (node != null && node.CheckIsDataType(GridDataType.PlantMapResource) && node.GetWorldObject(GridDataType.PlantMapResource) is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint.Equals(plantType))
					{
						return true;
					}
				}
			}
			return false;
		}

		private void AddToPlantCount(PlantMapResource blueprint, int countAdd)
		{
			string iD = blueprint.GetID();
			plantCountByType.TryAdd(iD, 0);
			plantCountByType[iD] += countAdd;
		}

		private void MarkPositionUsedBy(Vec3Int gridDataPosition, PlantMapResource usedBy)
		{
			fieldUsedBy[gridDataPosition.x, gridDataPosition.z] = usedBy;
		}

		private void InitPlantResourceGrowsOn()
		{
			foreach (PlantMapResource allItem in Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetAllItems())
			{
				if (!plantResourceGrowsOn.ContainsKey(allItem))
				{
					plantResourceGrowsOn.Add(allItem, new HashSet<VoxelType>());
				}
				foreach (string item in allItem.GrowsOn)
				{
					VoxelType byID = Repository<VoxelTypeRepository, VoxelType>.Instance.GetByID(item);
					if (byID != null && !plantResourceGrowsOn[allItem].Contains(byID))
					{
						plantResourceGrowsOn[allItem].Add(byID);
					}
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
				MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitialize;
			}
		}
	}
}
