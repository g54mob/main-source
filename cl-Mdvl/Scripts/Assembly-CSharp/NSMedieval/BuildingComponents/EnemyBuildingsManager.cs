using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class EnemyBuildingsManager
	{
		private VillageMap map;

		private ConcurrentDictionary<Vec3Int, BaseBuildingInstance> buildings = new ConcurrentDictionary<Vec3Int, BaseBuildingInstance>();

		private ConcurrentDictionary<Vec3Int, PlantMapResourceInstance> plantsToChopDict = new ConcurrentDictionary<Vec3Int, PlantMapResourceInstance>();

		private ConcurrentDictionary<Vec3Int, BaseBuildingInstance> enemySiegeWeapons = new ConcurrentDictionary<Vec3Int, BaseBuildingInstance>();

		public ConcurrentDictionary<Vec3Int, BaseBuildingInstance> Buildings => buildings;

		public EnemyBuildingsManager(VillageMap map)
		{
			this.map = map;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
		}

		public void Dispose()
		{
			buildings.Clear();
			buildings = null;
			plantsToChopDict.Clear();
			plantsToChopDict = null;
			enemySiegeWeapons.Clear();
			enemySiegeWeapons = null;
			map = null;
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent -= OnWorkersWonRaid;
				MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent -= OnWorkersLostRaid;
				MonoSingleton<RaidController>.Instance.RaidTieEvent -= OnRaidTie;
			}
		}

		public BaseBuildingInstance SelectRandomSiegeWeapon()
		{
			using PooledList<BaseBuildingInstance> pooledList = ListPool<BaseBuildingInstance>.GetJanitor(buildings.Values);
			if (pooledList.Count == 0)
			{
				return null;
			}
			int index = new Random().Next(pooledList.Count);
			return pooledList[index];
		}

		public void ConvertEnemyBuildingsToPlayerBuildings()
		{
			foreach (BaseBuildingInstance value in buildings.Values)
			{
				if (value != null && !value.HasDisposed)
				{
					value.SetFaction(FactionOwnership.Player);
				}
			}
			buildings.Clear();
			enemySiegeWeapons.Clear();
			MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEnemySiegeWeaponsMessageVisible(visible: false);
		}

		public PlantMapResourceInstance GetPlantToChop(Vec3Int pos)
		{
			return plantsToChopDict.GetValueOrDefault(pos);
		}

		public BaseBuildingInstance GetBuilding(Vec3Int gridPos)
		{
			return buildings.GetValueOrDefault(gridPos);
		}

		public void CacheEnemyBuilding(BaseBuildingInstance building)
		{
			bool isEnabled;
			if (!buildings.TryAdd(building.GridDataPosition, building))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(57, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Managers\\EnemyBuildingsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Dictionary already contains enemy building ");
					messageBuilder.AppendFormatted(building.BlueprintId);
					messageBuilder.AppendLiteral(" at position ");
					messageBuilder.AppendFormatted(building.GridDataPosition);
					messageBuilder.AppendLiteral("!");
				}
				Log.Debug(messageBuilder);
			}
			if (!string.IsNullOrEmpty(building.Blueprint.SiegeWeaponComponentID) && !enemySiegeWeapons.TryAdd(building.GridDataPosition, building))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(61, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Managers\\EnemyBuildingsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Dictionary already contains enemy siege weapon ");
					messageBuilder.AppendFormatted(building.BlueprintId);
					messageBuilder.AppendLiteral(" at position ");
					messageBuilder.AppendFormatted(building.GridDataPosition);
					messageBuilder.AppendLiteral("!");
				}
				Log.Debug(messageBuilder);
			}
		}

		public void RemoveEnemyBuilding(BaseBuildingInstance building)
		{
			buildings.Remove(building.GridDataPosition, out var _);
			enemySiegeWeapons.Remove(building.GridDataPosition, out var _);
		}

		public void CachePlantToChop(PlantMapResourceInstance plantToChop)
		{
			if (plantToChop != null && !plantToChop.HasDied && !plantToChop.HasDisposed && !plantsToChopDict.ContainsKey(plantToChop.GetGridPosition()))
			{
				plantsToChopDict.TryAdd(plantToChop.GetGridPosition(), plantToChop);
			}
		}

		public void RemovePlantToChop(PlantMapResourceInstance plantToChop)
		{
			if (plantToChop != null)
			{
				plantsToChopDict.TryRemove(plantToChop.GetGridPosition(), out var _);
			}
		}

		private void OnGameLoaded(bool fromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent += OnWorkersWonRaid;
			MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent += OnWorkersLostRaid;
			MonoSingleton<RaidController>.Instance.RaidTieEvent += OnRaidTie;
			if (!map.RaidManager.RaidInProgress() && !GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				OnWorkersWonRaid();
			}
		}

		private void OnWorkersWonRaid()
		{
			ConvertEnemySiegeWeaponsToPlayer();
			ConvertNonSiegeWeaponsToPlayerBuildings();
			buildings.Clear();
			enemySiegeWeapons.Clear();
			MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEnemySiegeWeaponsMessageVisible(visible: false);
		}

		private void OnWorkersLostRaid()
		{
			DestroyAllEnemySiegeWeapons();
			ConvertNonSiegeWeaponsToPlayerBuildings();
			buildings.Clear();
			enemySiegeWeapons.Clear();
			MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEnemySiegeWeaponsMessageVisible(visible: false);
		}

		private void OnRaidTie()
		{
			DestroyAllEnemySiegeWeapons();
			ConvertNonSiegeWeaponsToPlayerBuildings();
			buildings.Clear();
			enemySiegeWeapons.Clear();
			MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEnemySiegeWeaponsMessageVisible(visible: false);
		}

		private void DestroyAllEnemySiegeWeapons()
		{
			foreach (BaseBuildingInstance value in buildings.Values)
			{
				if (value != null && !value.HasDisposed && !string.IsNullOrEmpty(value.Blueprint.SiegeWeaponComponentID))
				{
					map.BuildingsManagerMain.DestroyBuilding(value);
				}
			}
		}

		private void ConvertNonSiegeWeaponsToPlayerBuildings()
		{
			foreach (BaseBuildingInstance value in buildings.Values)
			{
				if (value != null && !value.HasDisposed && string.IsNullOrEmpty(value.Blueprint.SiegeWeaponComponentID))
				{
					value.SetFaction(FactionOwnership.Player);
				}
			}
		}

		private void ConvertEnemySiegeWeaponsToPlayer()
		{
			foreach (BaseBuildingInstance value in buildings.Values)
			{
				if (value == null || value.HasDisposed || string.IsNullOrEmpty(value.Blueprint.SiegeWeaponComponentID))
				{
					continue;
				}
				value.SetFaction(FactionOwnership.Player);
				bool flag = false;
				foreach (Vec3Int position in value.Positions)
				{
					if (GridDataIndexTools.IsForbiddenEdge(position.x, position.z))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					UninstallEnemyBuilding(value);
					map.BuildingsManagerMain.BuildingDeconstructed(value);
				}
			}
		}

		private void UninstallEnemyBuilding(BaseBuildingInstance uninstalledBuilding)
		{
			string blueprintId = uninstalledBuilding.BlueprintId;
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Managers\\EnemyBuildingsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Building resource with id ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" not found.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				MovableBuildingPileInstance movableBuildingPileInstance = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(byID, uninstalledBuilding.WorldPosition, blueprintId).MovableBuildingPileInstance;
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetTargetBuilding(null);
				movableBuildingPileInstance.Stats.GetStat(StatType.Health).SetCurrent(uninstalledBuilding.Stats.GetStat(StatType.Health).Current);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetBuildingId(uninstalledBuilding.BlueprintId);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SaveComponentData(uninstalledBuilding);
				movableBuildingPileInstance.MoveBuildingResourceInstance.CloneMeshVariations(uninstalledBuilding?.MovableBuildingPileInstance?.MoveBuildingResourceInstance?.MeshVariations);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetProducerUniqueId(uninstalledBuilding.ProducerUniqueId);
			}
		}
	}
}
