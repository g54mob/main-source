using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Managers;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Resources
{
	public class FishRegrowController : MonoSingleton<FishRegrowController>
	{
		private FishMapResource[,] fieldUsedBy;

		private readonly Dictionary<string, int> fishToAddCount = new Dictionary<string, int>();

		private readonly Dictionary<string, int> fishCountByType = new Dictionary<string, int>();

		private float minFishPercent;

		private int hoursInDay = 24;

		private readonly List<Vec3Int> randomNeighbors = new List<Vec3Int>();

		private Dictionary<string, float> growNewFish => GlobalSaveController.CurrentVillageData.FishGrowValue;

		public Dictionary<string, int> FishCountByType => fishCountByType;

		private FishMapResource GetPositionUsedBy(Vec3Int gridDataPosition)
		{
			return fieldUsedBy[gridDataPosition.x, gridDataPosition.z];
		}

		public FishMapResource GetPositionUsedBy(int x, int y)
		{
			return fieldUsedBy[x, y];
		}

		internal void OnFishInstantiated(FishMapResourceInstance resourceInstance)
		{
			_ = GetPositionUsedBy(resourceInstance.GridDataPosition) != null;
			AddToFishCount(resourceInstance.Blueprint, 1);
			MarkPositionUsedBy(resourceInstance.GridDataPosition, resourceInstance.Blueprint);
		}

		internal void OnFishDestroyed(FishMapResourceInstance resourceInstance)
		{
			MarkPositionUsedBy(resourceInstance.GridDataPosition, null);
			AddToFishCount(resourceInstance.Blueprint, -1);
		}

		internal void InitMapSize(VillageMap map)
		{
			if (fieldUsedBy == null || fieldUsedBy.GetLength(0) != map.Size.x || fieldUsedBy.GetLength(1) != map.Size.z)
			{
				fieldUsedBy = new FishMapResource[map.Size.x, map.Size.z];
			}
		}

		private void Start()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			hoursInDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
		}

		private float CalculateWaterMultiplier()
		{
			float num = GlobalSaveController.CurrentVillageData.WaterAmountAtNewGame;
			return Mathf.Clamp((float)VillageManager.ActiveVillage.Map.WaterManager.WaterSimLogic.CurrentWaterSurface * 100f / num / 100f, 0f, 2f);
		}

		private void OnGameLoaded(bool fromSave)
		{
			CountFish();
			InitializeFishMinimumCount();
			CountFishToAdd();
		}

		private void CountFish()
		{
			fishCountByType.Clear();
			foreach (FishMapResource allItem in Repository<FishMapResourceRepository, FishMapResource>.Instance.GetAllItems())
			{
				if (!fishCountByType.ContainsKey(allItem.GetID()))
				{
					fishCountByType.Add(allItem.GetID(), 0);
				}
			}
			foreach (string item in from resource in VillageManager.ActiveVillage.Map.GetWorldObjectsList<FishMapResourceInstance>(GridDataType.FishMapResource)
				select resource.Blueprint.GetID())
			{
				if (!fishCountByType.ContainsKey(item))
				{
					fishCountByType.Add(item, 1);
				}
				else
				{
					fishCountByType[item]++;
				}
			}
			foreach (string key in GlobalSaveController.CurrentVillageData.MinNumberOfFish.Keys)
			{
				if (!fishCountByType.ContainsKey(key))
				{
					fishCountByType.Add(key, 0);
				}
			}
		}

		private void InitializeFishMinimumCount()
		{
			if (GlobalSaveController.CurrentVillageData.MinNumberOfFish.Count > 0)
			{
				return;
			}
			minFishPercent = GlobalSaveController.CurrentVillageData.MapBlueprint.MinFishPercentage;
			foreach (string key in fishCountByType.Keys)
			{
				if (fishCountByType.ContainsKey(key))
				{
					float num = minFishPercent * (float)fishCountByType[key] / 100f;
					GlobalSaveController.CurrentVillageData.MinNumberOfFish[key] = (int)num;
				}
			}
		}

		private void OnDateUpdate()
		{
			CountFishToAdd();
		}

		private void OnHourUpdate()
		{
			TryFishSpawning();
		}

		private void CountFishToAdd()
		{
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			foreach (KeyValuePair<string, int> item in fishCountByType)
			{
				string key = item.Key;
				int value = item.Value;
				if (!GlobalSaveController.CurrentVillageData.MinNumberOfFish.ContainsKey(key))
				{
					GlobalSaveController.CurrentVillageData.MinNumberOfFish.Add(key, 0);
				}
				int num = (int)((float)GlobalSaveController.CurrentVillageData.MinNumberOfFish[key] * mapBlueprint.MinFishPercentage / 100f * CalculateWaterMultiplier());
				FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(key);
				if (byID != null)
				{
					num = Math.Max(num, byID.MaxCount);
				}
				if (!growNewFish.ContainsKey(key))
				{
					growNewFish.Add(key, 0f);
				}
				if (value < num)
				{
					if (!fishToAddCount.ContainsKey(key))
					{
						fishToAddCount.Add(key, 0);
					}
					fishToAddCount[key] = num - value;
				}
				else
				{
					growNewFish[key] = 0f;
				}
			}
		}

		private void TryFishSpawning()
		{
			string[] array = fishToAddCount.Keys.ToArray();
			foreach (string text in array)
			{
				if (fishToAddCount[text] > 0)
				{
					FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(text);
					if (byID != null)
					{
						if (!byID.CanSpawnOnZeroCount && fishCountByType.ContainsKey(text) && fishCountByType[text] <= 0)
						{
							continue;
						}
						growNewFish[text] += byID.NewFishPerDay / (float)hoursInDay;
					}
				}
				if (growNewFish[text] >= 1f)
				{
					int num = Mathf.FloorToInt(growNewFish[text]);
					growNewFish[text] -= num;
					fishToAddCount[text] -= num;
					for (int j = 0; j < num; j++)
					{
						SpawnFish(text);
					}
				}
			}
		}

		public void DebugTryFishSpawning()
		{
			CountFishToAdd();
			string[] array = fishToAddCount.Keys.ToArray();
			foreach (string text in array)
			{
				if (fishToAddCount[text] > 0)
				{
					FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(text);
					if (byID != null)
					{
						if (!byID.CanSpawnOnZeroCount && fishCountByType.ContainsKey(text) && fishCountByType[text] <= 0)
						{
							continue;
						}
						growNewFish[text] += byID.NewFishPerDay;
					}
				}
				if (growNewFish[text] >= 1f)
				{
					int num = Mathf.FloorToInt(growNewFish[text]);
					growNewFish[text] -= num;
					fishToAddCount[text] -= num;
					for (int j = 0; j < num; j++)
					{
						SpawnFish(text);
					}
				}
			}
		}

		private bool SpawnFish(string blueprintId)
		{
			FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				Debug.LogError("Fish blueprint " + blueprintId + " does not exist.");
				return false;
			}
			return SpawnFish(byID);
		}

		private bool SpawnFish(FishMapResource blueprint)
		{
			if (GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius < blueprint.NewFishTemperatureLimit)
			{
				Debug.Log("[Regrow] Can't place a fish: temperature is too low.");
				return false;
			}
			if (!GetPositionForNewFish(blueprint, -1, out var fishPosition))
			{
				Debug.Log($"[Regrow] Can't get place for fish {blueprint.GetID()} (neighbor check mode = {blueprint.NeighborCheck}).");
				if (!GetRandomPositionForNewFish(blueprint, out fishPosition))
				{
					Debug.Log("[Regrow] Can't get a random place for fish " + blueprint.GetID() + ".");
					return false;
				}
			}
			SpawnYoungFish(blueprint, fishPosition.x, fishPosition.y, fishPosition.z);
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

		private bool GetPositionForNewFish(FishMapResource blueprint, int neighborCheckMode, out Vec3Int fishPosition)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			int num = ((neighborCheckMode != -1) ? neighborCheckMode : blueprint.NeighborCheck);
			if (num == 0 || (blueprint.PlaceAnywhereChance > 0f && UnityEngine.Random.Range(0f, 1f) < blueprint.PlaceAnywhereChance))
			{
				return GetRandomPositionForNewFish(blueprint, out fishPosition);
			}
			ShuffleNeighbors();
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			List<Vec3Int> list = new List<Vec3Int>();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.FishMapResource))
			{
				if (worldObject is FishMapResourceInstance fishMapResourceInstance && fishMapResourceInstance.Blueprint == blueprint)
				{
					list.Insert(UnityEngine.Random.Range(0, list.Count + 1), fishMapResourceInstance.GridDataPosition);
					hashSet.Add(fishMapResourceInstance.GridDataPosition);
				}
			}
			while (list.Count > 0)
			{
				Vec3Int b = list[0];
				list.Remove(b);
				hashSet.Add(b);
				foreach (Vec3Int randomNeighbor in randomNeighbors)
				{
					Vec3Int a = randomNeighbor + b;
					if (GridDataIndexTools.FastTo1DIndex(a) == -1 || !hashSet.Add(a))
					{
						continue;
					}
					MapNode node = map.GetNode(a);
					if (node == null)
					{
						continue;
					}
					list.Add(a);
					if (node.DataType == GridDataType.None && !node.CheckIsDataType(GridDataType.Slope))
					{
						bool flag = true;
						switch (num)
						{
						case 2:
						{
							Vec3Int pos = a + Vec3Int.left * UnityEngine.Random.Range(-1, 2) + Vec3Int.forward * UnityEngine.Random.Range(-1, 2);
							flag = !IsAnyFishAround(pos, MapNodeUtils.NeighborsXZ) && IsFishTypeAround(a, blueprint, MapNodeUtils.NeighborsXZRadius2);
							break;
						}
						case 1:
							flag = IsFishTypeAround(a, blueprint, MapNodeUtils.NeighborsXZ);
							break;
						}
						if (flag && FishResourceManager.CanSpawnFishAtPos(a))
						{
							fishPosition = a;
							return true;
						}
					}
				}
			}
			fishPosition = Vec3Int.zero;
			return false;
		}

		private bool GetRandomPositionForNewFish(FishMapResource blueprint, out Vec3Int fishPosition)
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
				if (node != null && !node.CheckIsDataType(GridDataType.Slope) && node.DataType == GridDataType.None && FishResourceManager.CanSpawnFishAtPos(node.Position))
				{
					fishPosition = zero;
					return true;
				}
			}
			fishPosition = new Vec3Int(0, 0, 0);
			return false;
		}

		private void SpawnYoungFish(FishMapResource blueprint, int x, int y, int z)
		{
			if (blueprint == null)
			{
				Debug.Log("Cannot place fish; blueprint missing.");
				return;
			}
			string prefabId = blueprint.PrefabIDs.PickRandom();
			Vector3 vector = new Vector3(x, y * World.MapBlockHeight, z);
			if (UnityEngine.Random.Range(0f, 1f) < 0.7f)
			{
				Vec3Int gridPosition = vector.ToGridVec3Int();
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
				if (node != null)
				{
					vector = MonoSingleton<ResourceSpawner>.Instance.GetPositionCloserToTheCoast(node).ToVector3World();
				}
			}
			MonoSingleton<FishResourceManager>.Instance.SpawnFishMapResource(blueprint.GetID(), vector, prefabId);
		}

		private bool IsAnyFishAround(Vec3Int pos, IEnumerable<Vec3Int> neighbors)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (Vec3Int neighbor in neighbors)
			{
				Vec3Int vec3Int = pos + neighbor;
				if (GridDataIndexTools.InRange(vec3Int))
				{
					MapNode node = map.GetNode(vec3Int);
					if (node != null && node.CheckIsDataType(GridDataType.FishMapResource))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsFishTypeAround(Vec3Int pos, FishMapResource fishType, IEnumerable<Vec3Int> neighbors)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (Vec3Int neighbor in neighbors)
			{
				Vec3Int vec3Int = pos + neighbor;
				if (GridDataIndexTools.InRange(vec3Int))
				{
					MapNode node = map.GetNode(vec3Int);
					if (node != null && node.CheckIsDataType(GridDataType.FishMapResource) && node.GetWorldObject(GridDataType.FishMapResource) is FishMapResourceInstance fishMapResourceInstance && fishMapResourceInstance.Blueprint.Equals(fishType))
					{
						return true;
					}
				}
			}
			return false;
		}

		private void AddToFishCount(FishMapResource blueprint, int countAdd)
		{
			string iD = blueprint.GetID();
			if (!fishCountByType.ContainsKey(iD))
			{
				fishCountByType.Add(iD, 0);
			}
			fishCountByType[iD] += countAdd;
		}

		private void MarkPositionUsedBy(Vec3Int gridDataPosition, FishMapResource usedBy)
		{
			fieldUsedBy[gridDataPosition.x, gridDataPosition.z] = usedBy;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
		}
	}
}
