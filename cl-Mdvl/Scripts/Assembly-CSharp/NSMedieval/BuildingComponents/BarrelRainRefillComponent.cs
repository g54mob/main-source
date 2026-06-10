using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class BarrelRainRefillComponent : BaseComponent
	{
		[NonSerialized]
		private ShelfComponent shelfComponent;

		private bool overlappingWithRoofEdge;

		private int roofLowerPointCount;

		private ShelfComponentInstance ShelfComponentInstance => shelfComponent.ComponentInstance;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			shelfComponent = null;
		}

		public override void PreSpawnInitialization()
		{
			shelfComponent = GetComponent<ShelfComponent>();
			shelfComponent.ComponentEnterFinishedStateEvent += OnEnterFinishedState;
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnBuildingConstructed;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnBuildingDestroyed;
				MonoSingleton<ConstructionController>.Instance.RoofDestroyedEvent += OnRoofDestroyed;
				MonoSingleton<ConstructionController>.Instance.RoofConstructedEvent += OnRoofConstructed;
			}
		}

		private void OnEnterFinishedState(bool afterLoading = false)
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			ShelfComponentInstance.OnDisposedEvent += OnDispose;
			CheckForRoofs();
		}

		private void OnDispose(IGameDisposable disposable)
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnBuildingConstructed;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnBuildingDestroyed;
				MonoSingleton<ConstructionController>.Instance.RoofDestroyedEvent -= OnRoofDestroyed;
				MonoSingleton<ConstructionController>.Instance.RoofConstructedEvent -= OnRoofConstructed;
			}
		}

		private void OnBuildingConstructed(BaseBuildingInstance baseBuildingInstance)
		{
			CheckForRoofs();
		}

		private void OnBuildingDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			CheckForRoofs();
		}

		private void OnRoofConstructed(RoofComponentInstance roofComponentInstance)
		{
			CheckForRoofs();
		}

		private void OnRoofDestroyed(RoofComponentInstance roofComponentInstance)
		{
			CheckForRoofs();
		}

		private void CheckForRoofs()
		{
			if (shelfComponent == null || shelfComponent.ComponentInstance == null || shelfComponent.ComponentInstance.HasDisposed || shelfComponent.ComponentInstance.OwnerBuilding == null || shelfComponent.ComponentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			int num = 0;
			RoofComponentManager roofComponentManager = ShelfComponentInstance.Map.RoofComponentManager;
			BuildingsManagerMain buildingsManagerMain = ShelfComponentInstance.Map.BuildingsManagerMain;
			BuildingType buildingType = BuildingType.Wall | BuildingType.Window | BuildingType.Door | BuildingType.Merlon | BuildingType.BarnDoor;
			foreach (Vec3Int position in ShelfComponentInstance.Positions)
			{
				Vec3Int vec3Int = position + Vec3Int.up;
				if (!roofComponentManager.RoofEdgeExists(vec3Int))
				{
					continue;
				}
				bool flag = false;
				using PooledList<BaseBuildingInstance> pooledList = buildingsManagerMain.GetBuildings(vec3Int, (BaseBuildingInstance x) => x.ConstructionPhase == ConstructionPhase.Finished);
				foreach (BaseBuildingInstance item in pooledList)
				{
					if (buildingType.HasFlag(item.BuildingType))
					{
						flag = true;
						break;
					}
					if (item.BuildingType == BuildingType.Floor && !item.Blueprint.PassthroughFloor)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num++;
				}
			}
			roofLowerPointCount = num;
		}

		private void OnHourUpdate()
		{
			if (ShelfComponentInstance == null || ShelfComponentInstance.HasDisposed || ShelfComponentInstance.OwnerBuilding == null || ShelfComponentInstance.OwnerBuilding.HasDisposed || !(MonoSingleton<WeatherManager>.Instance.RainEffectWeight > 0f))
			{
				return;
			}
			bool flag = false;
			int num = 0;
			foreach (Vec3Int position in ShelfComponentInstance.Positions)
			{
				MapNode node = ShelfComponentInstance.Map.GetNode(position);
				if (node != null && node.Coverage != CoverageType.Roofed)
				{
					num++;
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			int num2 = 2 * num + roofLowerPointCount;
			foreach (UniversalStorage item in ShelfComponentInstance.AllStorage)
			{
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					ResourceInstance resourceInstance = storageSlot.Pile?.GetStoredResource();
					if (resourceInstance != null)
					{
						int num3 = resourceInstance.StackingLimit - resourceInstance.Amount;
						if (num2 > num3)
						{
							num2 = num3;
						}
						ResourceInstance resource = resourceInstance.Clone(num2);
						item.StoreResourcePile(resource, storageSlot);
						return;
					}
					ResourceInstance resource2 = new ResourceInstance(Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket"), num2);
					item.StoreResourcePile(resource2, storageSlot);
				}
			}
		}
	}
}
