using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class OpenShelfGoal : Goal
	{
		private ShelfComponentManager shelfComponentManager;

		private VillageMap map;

		public OpenShelfGoal(Agent selfAgent)
			: base("OpenShelfGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<ShelfComponentInstance>());
			AddInitStep(new ThreadSequenceStep(DoPrechecks, PickTarget));
			map = VillageManager.ActiveVillage.Map;
			shelfComponentManager = map.ShelfComponentManager;
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			shelfComponentManager = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (shelfComponentManager == null)
			{
				return false;
			}
			foreach (ShelfComponentInstance hasShelvesWithOrder in shelfComponentManager.HasShelvesWithOrders)
			{
				if (!hasShelvesWithOrder.IsOnFire)
				{
					return true;
				}
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition == GoalCondition.Succeeded)
			{
				shelfComponentManager.HasShelvesWithOrders.Remove(GetTarget(TargetIndex.A).GetObjectAs<ShelfComponentInstance>());
			}
			MonoSingleton<ConstructionController>.Instance.ShelfOrderChangedEvent -= OnShelfOrderChange;
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			goapAction.OnInit = delegate
			{
				MonoSingleton<ConstructionController>.Instance.ShelfOrderChangedEvent += OnShelfOrderChange;
			};
			goapAction.OnTick = delegate
			{
				ShelfComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ShelfComponentInstance>();
				if (objectAs == null || objectAs.HasDisposed || objectAs.ShelfOrder == ShelfOrder.None || objectAs.IsOnFire || (!objectAs.ShouldLock() && !objectAs.ShouldAlwaysOpen()))
				{
					EndGoalWith(GoalCondition.Incompletable);
				}
			};
			yield return goapAction;
			ShelfComponentInstance shelfComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<ShelfComponentInstance>();
			GoapAction goapAction2 = new GoapAction("ChangeShelfOrder").FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			goapAction2.OnInit = delegate
			{
				shelfComponentInstance.Open();
			};
			yield return goapAction2;
		}

		private bool DoPrechecks()
		{
			shelfComponentManager.HasShelvesWithOrders.RemoveWhere((ShelfComponentInstance item) => !item.ShouldChangeLockState());
			return shelfComponentManager.HasShelvesWithOrders.Count > 0;
		}

		private bool PickTarget()
		{
			CreatureBase creatureBase = base.AgentOwner as CreatureBase;
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				ShelfComponentInstance objectAs = target.GetObjectAs<ShelfComponentInstance>();
				if (objectAs != null && !objectAs.HasDisposed && !objectAs.Frozen && objectAs.ShouldChangeLockState())
				{
					if (creatureBase != null)
					{
						TargetObject target2 = new TargetObject(objectAs, objectAs.ReachablePositions.FirstOrDefault());
						QueueTarget(TargetIndex.A, target2);
					}
					else
					{
						QueueTarget(TargetIndex.A, target);
					}
					if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
					{
						return true;
					}
				}
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.Furniture,
				Condition = delegate(WorldObject obj)
				{
					ShelfComponentInstance componentInstance = shelfComponentManager.GetComponentInstance(obj);
					return (componentInstance != null && componentInstance.ShouldChangeLockState() && !componentInstance.IsOnFire && !componentInstance.Frozen) ? true : false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
					ShelfComponentInstance componentInstance = shelfComponentManager.GetComponentInstance(item);
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(componentInstance, base.AgentOwner))
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					SetTarget(TargetIndex.A, new TargetObject(componentInstance, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
		}

		private void OnShelfOrderChange(ShelfComponentInstance shelfComponentInstance)
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<ShelfComponentInstance>() == shelfComponentInstance && !shelfComponentInstance.ShouldChangeLockState())
			{
				EndGoalWith(GoalCondition.Incompletable);
			}
		}

		private bool FailAtCondition()
		{
			ShelfComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ShelfComponentInstance>();
			if (objectAs == null || objectAs.HasDisposed || objectAs.OwnerBuilding == null || objectAs.OwnerBuilding.HasDisposed || objectAs.Frozen)
			{
				return true;
			}
			return false;
		}
	}
}
