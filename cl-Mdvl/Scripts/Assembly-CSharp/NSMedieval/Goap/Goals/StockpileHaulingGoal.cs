using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.MovableBuildings;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class StockpileHaulingGoal : HaulingBaseGoal
	{
		public StockpileHaulingGoal(Agent selfAgent)
			: base("StockpileHaulingGoal", selfAgent)
		{
			Init();
		}

		protected StockpileHaulingGoal(string goalId, Agent selfAgent)
			: base(goalId, selfAgent)
		{
			Init();
		}

		private void Init()
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<ResourcePileInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, FindAndProcessTargets));
		}

		protected override bool ValidatePile(ResourcePileInstance pile)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Validating ");
				messageBuilder.AppendFormatted(pile);
			}
			Log.Trace(messageBuilder);
			if (pile is MovableBuildingPileInstance { PlacementModeActive: not false })
			{
				return false;
			}
			if (!ShouldConsiderPile(pile))
			{
				Log.Trace("ShouldConsiderPile = false, failing", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				return false;
			}
			if (pile.IsReserveAll)
			{
				Log.Trace("Pile already reserved, failing", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				return false;
			}
			if (MonoSingleton<ReservationManager>.Instance.GetReserversCount(pile) > 0)
			{
				Log.Trace("Pile ahs more than 1 reserver, failing", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				return false;
			}
			if (pile.IsOnFire)
			{
				return false;
			}
			if (pile is HumanCarcassPileInstance { MarkedForStripping: not false })
			{
				return false;
			}
			if (base.AgentOwner is AnimalInstance && pile.Map.WaterManager.GetWaterLevelAsDepth(pile.GridDataPosition) == WaterDepthLevel.High)
			{
				Log.Trace("Animals can't haul in deep water, failing", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				return false;
			}
			ResourceInstance resource = pile.GetStoredResource();
			ZonePriority minimumStoragePriority = ZonePriority.None;
			if (pile.CanBeHauled && pile.PlacedOnStorage != null && pile.PlacedOnStorage.ResourcesFilter.IsValid(resource))
			{
				minimumStoragePriority = pile.StoragePriority;
				Log.Trace("Pile already on storage, only relocation is possible, taking storage priority into account", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
			}
			IGoapTargetable closestReachable = PathfinderUtil.GetClosestReachable((IPathfindingAgent)base.AgentOwner, MonoSingleton<StorageCommonManager>.Instance.AllStorages, delegate(IGoapTargetable x)
			{
				IStorage storage = (IStorage)x;
				return !storage.AnimalFeeder && !storage.PrisonFeeder && storage.CanStore(resource, (CreatureBase)base.AgentOwner) && storage.Priority > minimumStoragePriority && !storage.Underwater && !storage.IsOnFire && storage.IsPlayerOwned;
			}, (IGoapTargetable o) => (float)((IStorage)o).Priority);
			if (closestReachable == null)
			{
				Log.Trace("Storage not found, failing", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
			}
			return closestReachable != null;
		}

		protected override bool HasAnywhereToStore()
		{
			return GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>()?.CanBeHauled ?? false;
		}

		protected override bool FindAndProcessTargets()
		{
			Log.Trace("FindAndProcessTargets Start", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
			IPathfindingAgent agent = (IPathfindingAgent)base.AgentOwner;
			PickedCount = 0;
			TotalTargetedCount = 0;
			ResourcePileHaulingManager instance = MonoSingleton<ResourcePileHaulingManager>.Instance;
			ResourcePileInstance targetPile = null;
			ZonePriority minimumStoragePriority = ZonePriority.None;
			if (base.PreferredReservableHandler.HasTarget())
			{
				ResourcePileInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<ResourcePileInstance>();
				if (PathfinderUtil.IsPathPossible(agent, objectAs) && instance.IsMarkedForHauling(objectAs))
				{
					Log.Trace("TargetPile = preferred pile", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
					targetPile = objectAs;
				}
			}
			FVLogTraceInterpolationHandler messageBuilder;
			bool isEnabled;
			if (targetPile == null)
			{
				PickClosestPileToHaul(out minimumStoragePriority, out targetPile);
				if (targetPile != null)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("TargetPile = closest pile (");
						messageBuilder.AppendFormatted(targetPile);
						messageBuilder.AppendLiteral(")");
					}
					Log.Trace(messageBuilder);
				}
			}
			if (targetPile == null)
			{
				Log.Trace("Found nothing to haul, aborting", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				return false;
			}
			QueueTarget(TargetIndex.A, new TargetObject(targetPile));
			targetPile.ReserveAll();
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(targetPile, base.AgentOwner))
			{
				messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to reserve ");
					messageBuilder.AppendFormatted(targetPile);
					messageBuilder.AppendLiteral(", aborting");
				}
				Log.Trace(messageBuilder);
				return false;
			}
			ResourceInstance toStore = targetPile.GetStoredResource();
			MaxCaryAmount = ((IStorageAgent)agent).Storage.GetMaximumStorableCount(toStore.Blueprint);
			TotalTargetedCount += toStore.Amount;
			if (MaxCaryAmount > toStore.Amount)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can carry more than ");
					messageBuilder.AppendFormatted(toStore.Amount);
					messageBuilder.AppendLiteral(", looking for nearby piles of same type to queue them as well");
				}
				Log.Trace(messageBuilder);
				ListPool<WorldObject>.Return(PathfinderUtil.FindNearbyObject(agent, targetPile.GridDataPosition, 9f, delegate(WorldObject o)
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
					if (!resourcePileInstance.CanBeHauled)
					{
						return -1;
					}
					resourcePileInstance.ReserveAll();
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
					{
						return 0;
					}
					bool isEnabled2;
					FVLogTraceInterpolationHandler messageBuilder3 = new FVLogTraceInterpolationHandler(9, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
					if (isEnabled2)
					{
						messageBuilder3.AppendLiteral("Queueing ");
						messageBuilder3.AppendFormatted(resourcePileInstance);
					}
					Log.Trace(messageBuilder3);
					TotalTargetedCount += resourcePileInstance.GetStoredResource().Amount;
					QueueTarget(TargetIndex.A, new TargetObject(resourcePileInstance));
					return 1;
				}));
			}
			if (TotalTargetedCount > MaxCaryAmount)
			{
				TotalTargetedCount = MaxCaryAmount;
			}
			IStorage storage = (IStorage)PathfinderUtil.GetClosestReachable(agent, targetPile.GridDataPosition, MonoSingleton<StorageCommonManager>.Instance.AllStorages, delegate(IGoapTargetable o)
			{
				IStorage storage2 = (IStorage)o;
				return !storage2.AnimalFeeder && !storage2.PrisonFeeder && storage2.CanStore(toStore, (CreatureBase)agent) && storage2.Priority > minimumStoragePriority && !storage2.Underwater && !storage2.IsOnFire && storage2.IsPlayerOwned;
			}, (IGoapTargetable o) => (float)((IStorage)o).Priority);
			if (storage == null)
			{
				FVLogger fVLogger = logger;
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(66, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Find 0 storages to store ");
					messageBuilder2.AppendFormatted(targetPile.Blueprint.GetID());
					messageBuilder2.AppendLiteral(" : ");
					messageBuilder2.AppendFormatted(targetPile.Positions);
					messageBuilder2.AppendLiteral(" - pile on. Triggering piles reprocess");
				}
				fVLogger.Warning(in messageBuilder2);
				instance.TriggerLazyReProcessAll();
				return false;
			}
			FVLogger fVLogger2 = logger;
			messageBuilder = new FVLogTraceInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\StockpileHaulingGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Target storage = (Id = ");
				messageBuilder.AppendFormatted(storage.ObjectId);
				messageBuilder.AppendLiteral(", Name = ");
				messageBuilder.AppendFormatted(storage.StorageName);
				messageBuilder.AppendLiteral(")");
			}
			fVLogger2.Trace(in messageBuilder);
			QueueTarget(TargetIndex.B, new TargetObject(storage));
			return true;
		}
	}
}
