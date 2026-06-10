using System.Collections.Generic;
using NSMedieval.Goap.Actions;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class NegotiateGoal : Goal
	{
		public NegotiateGoal(Agent selfAgent)
			: base("NegotiateGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(PrepareData));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.AgentOwner is CreatureBase { IsOnFire: not false })
			{
				return false;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToCreatureTarget(TargetIndex.A);
			goapAction.FailIfTargetDisposed(TargetIndex.A);
			goapAction.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
					if (objectAs != null && objectAs.ActiveBehaviour is INegotiator negotiator)
					{
						negotiator.OnInteractedWith((HumanoidInstance)base.AgentOwner);
					}
				}
			};
			yield return goapAction;
		}

		private bool PrepareData()
		{
			if (!base.PreferredReservableHandler.HasTarget())
			{
				return false;
			}
			TargetObject target = base.PreferredReservableHandler.GetTarget();
			if (target.GetObjectAs<HumanoidInstance>().IsOnFire)
			{
				return false;
			}
			QueueTarget(TargetIndex.A, target);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}
	}
}
