using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class SiegeWeaponComponentManager : ComponentBaseManager<SiegeWeaponComponent, SiegeWeaponComponentInstance>
	{
		private ConcurrentDictionary<SiegeWeaponType, List<SiegeWeaponComponentInstance>> siegeWeaponTypeComponentInstance = new ConcurrentDictionary<SiegeWeaponType, List<SiegeWeaponComponentInstance>>();

		private SiegeWeaponCopySettingsData siegeWeaponCopySettingsData;

		public SiegeWeaponCopySettingsData SiegeWeaponCopySettingsData => siegeWeaponCopySettingsData;

		public SiegeWeaponComponentManager(VillageMap map)
			: base(map)
		{
			siegeWeaponTypeComponentInstance.TryAdd(SiegeWeaponType.Ballista, new List<SiegeWeaponComponentInstance>());
			siegeWeaponTypeComponentInstance.TryAdd(SiegeWeaponType.Onager, new List<SiegeWeaponComponentInstance>());
			siegeWeaponTypeComponentInstance.TryAdd(SiegeWeaponType.Trebuchet, new List<SiegeWeaponComponentInstance>());
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		public override void Dispose()
		{
			siegeWeaponTypeComponentInstance.Clear();
			siegeWeaponTypeComponentInstance = null;
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
			}
			base.Dispose();
		}

		public override void AddToCache(SiegeWeaponComponent component, SiegeWeaponComponentInstance instance)
		{
			base.AddToCache(component, instance);
			if (siegeWeaponTypeComponentInstance.TryGetValue(instance.Blueprint.SiegeWeaponType, out var value))
			{
				value.Add(instance);
			}
		}

		public override void RemoveFromCache(SiegeWeaponComponentInstance instance)
		{
			base.RemoveFromCache(instance);
			if (siegeWeaponTypeComponentInstance.TryGetValue(instance.Blueprint.SiegeWeaponType, out var value))
			{
				value.Remove(instance);
			}
		}

		public void ShowSiegeWeaponsRange(bool visible)
		{
			SiegeWeaponComponentInstance[] array = InstanceComponentDictionary.Keys.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ShowRange(visible);
			}
		}

		public void SetSiegeWeaponCopyFilter(SiegeWeaponCopySettingsData siegeWeaponCopySettingsData)
		{
			this.siegeWeaponCopySettingsData = siegeWeaponCopySettingsData;
		}

		public List<SiegeWeaponComponentInstance> GetSiegeWeaponComponentInstances(SiegeWeaponType siegeWeaponType)
		{
			return siegeWeaponTypeComponentInstance.GetValueOrDefault(siegeWeaponType);
		}

		public void UninstallAllPlayerSiegeWeapons()
		{
			foreach (SiegeWeaponComponentInstance key in InstanceComponentDictionary.Keys)
			{
				UninstallSiegeWeapon(key.OwnerBuilding);
				Map.BuildingsManagerMain.BuildingDeconstructed(key.OwnerBuilding);
			}
		}

		public void ProjectileImpactSpawnerVertical(PooledList<Vec3Int> orderedSpawnPoints, SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			if (orderedSpawnPoints.Count == 0)
			{
				return;
			}
			int y = orderedSpawnPoints.First().y;
			float num = 0f;
			foreach (Vec3Int v in orderedSpawnPoints)
			{
				if (v.y < y)
				{
					y = v.y;
					num += 0.1f;
				}
				MonoSingleton<TaskController>.Instance.WaitFor(num).Then(delegate
				{
					MapNode node = Map.GetNode(v);
					if (node != null)
					{
						if (projectileBlueprint.SpawnsOil)
						{
							Map.FireSimLogic.SetOilBlobHealth(node.Index, 1f, (byte)projectileBlueprint.OilType);
						}
						if (projectileBlueprint.SpawnsFire)
						{
							Map.FireSimLogic.SetFireData(node.Index, projectileBlueprint.FireIntensity);
							Map.FireSimLogic.SetFlameType(node.Index, projectileBlueprint.FireType);
						}
						if (projectileBlueprint.HasWetnessOnImpact)
						{
							byte value = (byte)Math.Clamp(projectileBlueprint.WetnessOnImpact * 255f, 0f, 255f);
							node.Map.SnowGrassWetnessManager.SetWetness(node.Index, value);
						}
					}
				});
			}
		}

		public void ProjectileImpactSpawnerHorizontal(PooledList<Vec3Int> positions, SiegeWeaponProjectileBlueprint projectileBlueprint)
		{
			float num = 0f;
			foreach (Vec3Int pos in positions)
			{
				MonoSingleton<TaskController>.Instance.WaitFor(num).Then(delegate
				{
					MapNode node = Map.GetNode(pos);
					if (node != null)
					{
						if (projectileBlueprint.SpawnsOil)
						{
							Map.FireSimLogic.SetOilBlobHealth(node.Index, 1f, (byte)projectileBlueprint.OilType);
						}
						if (projectileBlueprint.SpawnsFire)
						{
							Map.FireSimLogic.SetFireData(node.Index, projectileBlueprint.FireIntensity);
							Map.FireSimLogic.SetFlameType(node.Index, projectileBlueprint.FireType);
						}
						if (projectileBlueprint.HasWetnessOnImpact)
						{
							byte value = (byte)Math.Clamp(projectileBlueprint.WetnessOnImpact * 255f, 0f, 255f);
							node.Map.SnowGrassWetnessManager.SetWetness(node.Index, value);
						}
					}
				});
				num += 0.02f;
			}
		}

		private void UninstallSiegeWeapon(BaseBuildingInstance uninstalledBuilding)
		{
			if (uninstalledBuilding == null || uninstalledBuilding.HasDisposed)
			{
				return;
			}
			string blueprintId = uninstalledBuilding.BlueprintId;
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\SiegeWeapons\\SiegeWeaponComponentManager.cs");
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

		private void OnMapLoaded(bool fromSave)
		{
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
		}

		private void OnRaidEnded(ActiveRaidInfo info)
		{
		}
	}
}
