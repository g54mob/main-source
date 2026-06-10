using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class StripCarcassGoal : Goal
	{
		public StripCarcassGoal(Agent selfAgent)
			: base("StripCarcassGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanCarcassPileInstance>());
			AddInitStep(new ThreadSequenceStep(null, PickTarget));
		}

		public override bool CanStart(bool isForced = false)
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (humanoidInstance == null || humanoidInstance.HasFainted)
			{
				return false;
			}
			if (!HasValidPreferredReservable())
			{
				return MonoSingleton<ResourcePileManager>.Instance.CarcassesMarkedForStripping.Count > 0;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			GoapAction goapAction = new GoapAction("StripCarcassAction").FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			goapAction.OnInit = delegate
			{
				GetTarget(TargetIndex.A).GetObjectAs<HumanCarcassPileInstance>().Strip();
			};
			yield return goapAction;
		}

		private bool PickTarget()
		{
			if (HasValidPreferredReservable())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				HumanCarcassPileInstance objectAs = target.GetObjectAs<HumanCarcassPileInstance>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					QueueTarget(TargetIndex.A, target);
					if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
					{
						return true;
					}
				}
			}
			List<TargetObject> list = PathfinderResourcePile.FindHumanCarcassesForStripping((IPathfindingAgent)base.AgentOwner, (ResourcePileInstance body) => !body.IsForbidden && !body.IsOnFire);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool FailAtCondition()
		{
			HumanCarcassPileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanCarcassPileInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.IsForbidden)
			{
				return !objectAs.MarkedForStripping;
			}
			return true;
		}

		private bool HasValidPreferredReservable()
		{
			WorkerGoapAgent workerGoapAgent = base.Agent as WorkerGoapAgent;
			if (workerGoapAgent?.ExclusiveGoal == null || workerGoapAgent.ExclusiveGoal != this)
			{
				return false;
			}
			if (!base.PreferredReservableHandler.HasTarget())
			{
				return false;
			}
			HumanCarcassPileInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<HumanCarcassPileInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				base.PreferredReservableHandler.ClearTarget();
				return false;
			}
			return !objectAs.Stripped;
		}
	}
}
