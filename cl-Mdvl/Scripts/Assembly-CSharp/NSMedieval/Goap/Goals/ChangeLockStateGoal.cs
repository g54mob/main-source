using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class ChangeLockStateGoal : Goal
	{
		private readonly WindowComponentManager windowComponentManager;

		public ChangeLockStateGoal(Agent selfAgent)
			: base("ChangeLockStateGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<WindowComponentInstance>());
			AddInitStep(new ThreadSequenceStep(DoPrechecks, PickTarget));
			windowComponentManager = VillageManager.ActiveVillage.Map.WindowComponentManager;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (windowComponentManager == null)
			{
				return false;
			}
			foreach (WindowComponentInstance item in windowComponentManager.HasWindowsWithOrder)
			{
				if (!item.IsOnFire)
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
				windowComponentManager.HasWindowsWithOrder.Remove(GetTarget(TargetIndex.A).GetObjectAs<WindowComponentInstance>());
			}
			MonoSingleton<ConstructionController>.Instance.WindowLockOrderChangedEvent -= OnOrderChange;
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A);
			goapAction.OnInit = delegate
			{
				MonoSingleton<ConstructionController>.Instance.WindowLockOrderChangedEvent += OnOrderChange;
			};
			goapAction.OnTick = delegate
			{
				WindowComponentInstance windowComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WindowComponentInstance>();
				if (windowComponentInstance == null || windowComponentInstance.WindowOrder == WindowOrder.None || windowComponentInstance.IsOnFire || (!windowComponentInstance.ShouldClose() && !windowComponentInstance.ShouldOpen()))
				{
					EndGoalWith(GoalCondition.Incompletable);
				}
			};
			yield return goapAction;
			GoapAction changeLockOrder = new GoapAction("ChangeLockOrder").FailIfTargetDisposedOrNull(TargetIndex.A);
			changeLockOrder.OnInit = delegate
			{
				WindowComponentInstance windowComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WindowComponentInstance>();
				if (windowComponentInstance == null)
				{
					changeLockOrder.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					bool flag = windowComponentInstance.WindowOrder == WindowOrder.Open;
					bool num = windowComponentInstance.WindowOrder == WindowOrder.Close;
					if (flag)
					{
						windowComponentInstance.OpenWindow();
					}
					if (num)
					{
						windowComponentInstance.CloseWindow();
					}
				}
			};
			yield return changeLockOrder;
		}

		private bool DoPrechecks()
		{
			windowComponentManager.HasWindowsWithOrder.RemoveWhere((WindowComponentInstance item) => !item.ShouldChangeLockState());
			return windowComponentManager.HasWindowsWithOrder.Count > 0;
		}

		private bool PickTarget()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				WindowComponentInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<WindowComponentInstance>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					BaseBuildingInstance ownerBuilding = objectAs.OwnerBuilding;
					if (ownerBuilding != null && !ownerBuilding.HasDisposed && objectAs.OwnerBuilding.OwnedByPlayer() && (objectAs.ShouldClose() || objectAs.ShouldOpen()))
					{
						List<WorldObject> targets = new List<WorldObject> { objectAs.OwnerBuilding };
						List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(base.AgentOwner as IPathfindingAgent, targets);
						if (list != null && list.Count > 0)
						{
							TargetObject target = list[0];
							if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
							{
								SetTarget(TargetIndex.A, target);
								return true;
							}
						}
					}
				}
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = (GridDataType.BuildingFinished | GridDataType.Furniture),
				Condition = delegate(WorldObject obj)
				{
					WindowComponentInstance componentInstance = windowComponentManager.GetComponentInstance(obj);
					return componentInstance != null && componentInstance.ShouldChangeLockState() && componentInstance.OwnerBuilding.OwnedByPlayer();
				},
				OnFound = delegate(WorldObject obj, Vec3Int pos)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(obj, base.AgentOwner);
					WindowComponentInstance componentInstance = windowComponentManager.GetComponentInstance(obj);
					if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(componentInstance, base.AgentOwner))
					{
						SetTarget(TargetIndex.A, new TargetObject(componentInstance, pos));
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
				}
			});
		}

		private void OnOrderChange(WindowComponentInstance windowComponentInstance)
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<WindowComponentInstance>() == windowComponentInstance && !windowComponentInstance.ShouldClose() && !windowComponentInstance.ShouldOpen())
			{
				windowComponentManager.HasWindowsWithOrder.Remove(GetTarget(TargetIndex.A).GetObjectAs<WindowComponentInstance>());
				EndGoalWith(GoalCondition.Succeeded);
			}
		}
	}
}
