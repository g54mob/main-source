using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class SetupTrapGoal : Goal
	{
		private const float MinTrapRange = 8f;

		private VillageMap map;

		public SetupTrapGoal(Agent selfAgent)
			: base("SetupTrapGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<TrapComponentInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (map != null)
			{
				return map.TrapComponentsManager.NonOperationalTrapsExist();
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IToolAgent;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailAtCondition);
			TrapComponentInstance componentInstance = null;
			GoapAction activateTrapAction = null;
			IToolAgent agent = (IToolAgent)base.AgentOwner;
			activateTrapAction = new GoapAction("ActivateTrapAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			float setupTime = 0f;
			activateTrapAction.OnInit = delegate
			{
				componentInstance = GetTarget(TargetIndex.A).GetObjectAs<TrapComponentInstance>();
				setupTime = componentInstance.Blueprint.SetupTime;
				AttributeInstance attribute = ((IProductionAgent)base.AgentOwner).GetAttribute(AttributeType.GlobalWorkSpeed);
				if (attribute != null)
				{
					setupTime /= attribute.Value;
				}
				activateTrapAction.CompleteAfterTimeExpires(setupTime);
			};
			activateTrapAction.OnComplete = delegate
			{
				agent.HideTool();
				if (componentInstance != null && !componentInstance.HasDisposed)
				{
					componentInstance.Reactivate();
				}
			};
			activateTrapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			activateTrapAction.TriggerAnimation("ResetTrap", ActionAnimationMode.Interrupt);
			activateTrapAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => activateTrapAction.TotalTickingTime / setupTime).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
			activateTrapAction.FailAtCondition(FailAtCondition);
			yield return activateTrapAction;
		}

		private bool PrepareData()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				TrapComponentInstance objectAs = target.GetObjectAs<TrapComponentInstance>();
				if (!objectAs.Operational && !objectAs.Underwater && !objectAs.IsOnFire && MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			List<WorldObject> targets = map.TrapComponentsManager.IterateComponentWorldObjects((TrapComponentInstance x) => !x.Operational && !x.Underwater).ToList();
			List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(obj, targets);
			if (list == null || list.Count <= 0)
			{
				return false;
			}
			using PooledList<TargetObject> pooledList = ListPool<TargetObject>.GetJanitor();
			using PooledList<HumanoidInstance> pooledList2 = MonoSingleton<NPCManager>.Instance.GetNPCsPooled();
			TargetObject[] array = list.ToArray();
			for (int num = 0; num < array.Length; num++)
			{
				TargetObject targetObject = array[num];
				WorldObject objectAs2 = targetObject.GetObjectAs<WorldObject>();
				if (objectAs2 == null || objectAs2.HasDisposed)
				{
					continue;
				}
				TrapComponentInstance componentInstance = map.TrapComponentsManager.GetComponentInstance(objectAs2);
				if (componentInstance == null || componentInstance.HasDisposed)
				{
					continue;
				}
				Vector3 worldPosition = GridUtils.GetWorldPosition(targetObject.ReachablePosition);
				bool flag = true;
				foreach (HumanoidInstance item in pooledList2)
				{
					if (!item.HasFainted && Vector3.Distance(worldPosition, item.GetPosition()) < 8f)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					pooledList.Add(new TargetObject(componentInstance, targetObject.ReachablePosition));
				}
			}
			if (pooledList.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, pooledList);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool FailAtCondition()
		{
			TrapComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<TrapComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.Underwater && !objectAs.Operational)
			{
				return objectAs.IsOnFire;
			}
			return true;
		}
	}
}
