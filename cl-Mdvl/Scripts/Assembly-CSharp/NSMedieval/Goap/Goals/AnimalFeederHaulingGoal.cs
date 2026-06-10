using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class AnimalFeederHaulingGoal : HaulingBaseGoal
	{
		public AnimalFeederHaulingGoal(Agent selfAgent)
			: base("AnimalFeederHaulingGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<IStorage>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, FindAndProcessTargets));
		}

		protected override bool ValidatePile(ResourcePileInstance pile)
		{
			if (pile.IsReserveAll)
			{
				return false;
			}
			if (MonoSingleton<ReservationManager>.Instance.GetReserversCount(pile) > 0)
			{
				return false;
			}
			if (pile.PlacedOnAnimalFeeder)
			{
				return false;
			}
			if (pile.IsForbidden)
			{
				return false;
			}
			ResourceInstance resource = pile.GetStoredResource();
			ZonePriority minimumStoragePriority = ZonePriority.None;
			if (pile.CanBeHauled && pile.PlacedOnStorage != null && pile.PlacedOnStorage.ResourcesFilter.IsValid(resource))
			{
				minimumStoragePriority = pile.StoragePriority;
			}
			bool checkIfGoalIsForced = base.Agent.LastForceStartedGoal == this;
			return PathfinderUtil.GetClosestReachable((IPathfindingAgent)base.AgentOwner, MonoSingleton<StorageCommonManager>.Instance.AllStorages, delegate(IGoapTargetable x)
			{
				IStorage storage = (IStorage)x;
				if (!(storage is ShelfComponentInstance { AnimalFeeder: not false, Underwater: false, IsOnFire: false } shelfComponentInstance))
				{
					return false;
				}
				if (checkIfGoalIsForced)
				{
					if (storage.CanStore(resource, (CreatureBase)base.AgentOwner) && storage.Priority > minimumStoragePriority && !shelfComponentInstance.AllStorage.Any((UniversalStorage s) => s.IsForbidden))
					{
						return storage.IsPlayerOwned;
					}
					return false;
				}
				return storage.CanStore(resource, (CreatureBase)base.AgentOwner) && storage.Priority > minimumStoragePriority && !shelfComponentInstance.AllStorage.All((UniversalStorage s) => s.IsForbidden) && storage.IsPlayerOwned;
			}, (IGoapTargetable o) => (float)((IStorage)o).Priority) != null;
		}

		protected override bool HasAnywhereToStore()
		{
			return GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>() != null;
		}

		protected override bool FindAndProcessTargets()
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			PickedCount = 0;
			TotalTargetedCount = 0;
			ResourcePileHaulingManager instance = MonoSingleton<ResourcePileHaulingManager>.Instance;
			PickClosestPileToHaul(out var minimumStoragePriority, out var targetPile);
			if (targetPile == null)
			{
				return false;
			}
			QueueTarget(TargetIndex.A, new TargetObject(targetPile));
			targetPile.ReserveAll();
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(targetPile, base.AgentOwner))
			{
				return false;
			}
			ResourceInstance toStore = targetPile.GetStoredResource();
			int num = 0;
			IPathfindingAgent pathfindingAgent2 = (IPathfindingAgent)base.AgentOwner;
			foreach (IStorage allStorage in MonoSingleton<StorageCommonManager>.Instance.AllStorages)
			{
				if (!allStorage.AnimalFeeder || allStorage.Underwater || allStorage.IsOnFire || !(allStorage is ShelfComponentInstance shelfComponentInstance) || !PathfinderUtil.IsPathPossible(pathfindingAgent2, allStorage.GetGridPosition()))
				{
					continue;
				}
				foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
				{
					num += item.GetFreeSpace(toStore.Blueprint);
				}
			}
			MaxCaryAmount = ((IStorageAgent)pathfindingAgent).Storage.GetMaximumStorableCount(toStore.Blueprint);
			if (MaxCaryAmount > num)
			{
				MaxCaryAmount = num;
			}
			TotalTargetedCount += toStore.Amount;
			if (MaxCaryAmount > toStore.Amount)
			{
				ListPool<WorldObject>.Return(PathfinderUtil.FindNearbyObject(pathfindingAgent, targetPile.GridDataPosition, 9f, delegate(WorldObject o)
				{
					if (TotalTargetedCount >= MaxCaryAmount)
					{
						return -1;
					}
					if (!(o is ResourcePileInstance resourcePileInstance) || resourcePileInstance.Blueprint != toStore.Blueprint)
					{
						return 0;
					}
					if (o == targetPile)
					{
						return 0;
					}
					resourcePileInstance.ReserveAll();
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
					{
						return 0;
					}
					TotalTargetedCount += resourcePileInstance.GetStoredResource().Amount;
					QueueTarget(TargetIndex.A, new TargetObject(resourcePileInstance));
					return 1;
				}));
			}
			if (TotalTargetedCount > MaxCaryAmount)
			{
				TotalTargetedCount = MaxCaryAmount;
			}
			IStorage storage = null;
			if (base.PreferredReservableHandler.HasTarget())
			{
				IStorage objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<IStorage>();
				if (!objectAs.HasDisposed && objectAs.IsPlayerOwned)
				{
					storage = objectAs;
				}
			}
			bool checkIfGoalIsForced = base.Agent.LastForceStartedGoal == this;
			if (storage == null)
			{
				storage = (IStorage)PathfinderUtil.GetClosestReachable(pathfindingAgent, targetPile.GridDataPosition, MonoSingleton<StorageCommonManager>.Instance.AllStorages, delegate(IGoapTargetable x)
				{
					IStorage storage2 = (IStorage)x;
					if (!(storage2 is ShelfComponentInstance shelfComponentInstance2))
					{
						return false;
					}
					if (checkIfGoalIsForced)
					{
						if (storage2.AnimalFeeder && storage2.CanStore(toStore, (CreatureBase)base.AgentOwner) && storage2.Priority > minimumStoragePriority && !shelfComponentInstance2.AllStorage.Any((UniversalStorage s) => s.IsForbidden))
						{
							return storage2.IsPlayerOwned;
						}
						return false;
					}
					return storage2.AnimalFeeder && storage2.CanStore(toStore, (CreatureBase)base.AgentOwner) && storage2.Priority > minimumStoragePriority && !shelfComponentInstance2.AllStorage.All((UniversalStorage s) => s.IsForbidden) && storage2.IsPlayerOwned;
				}, (IGoapTargetable o) => (float)((IStorage)o).Priority);
			}
			if (storage == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(66, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\AnimalFeederHaulingGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Find 0 storages to store ");
					messageBuilder.AppendFormatted(targetPile.Blueprint.GetID());
					messageBuilder.AppendLiteral(" : ");
					messageBuilder.AppendFormatted(targetPile.Positions);
					messageBuilder.AppendLiteral(" - pile on. Triggering piles reprocess");
				}
				Log.Warning(messageBuilder);
				instance.TriggerLazyReProcessAll();
				return false;
			}
			QueueTarget(TargetIndex.B, new TargetObject(storage));
			return true;
		}

		protected override void PickClosestPileToHaul(out ZonePriority minimumStoragePriority, out ResourcePileInstance targetPile)
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			targetPile = null;
			minimumStoragePriority = ZonePriority.None;
			MonoSingleton<ResourcePileManager>.Instance.CategoryInstanceDictionaryTryGetValue(ResourceCategory.CtgFodder, out var resourcePileInstances);
			IEnumerable<IGoapTargetable> searchSet = resourcePileInstances;
			targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(pathfindingAgent, searchSet, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
		}

		protected override int GetMaxPickupAmount()
		{
			return TotalTargetedCount;
		}
	}
}
