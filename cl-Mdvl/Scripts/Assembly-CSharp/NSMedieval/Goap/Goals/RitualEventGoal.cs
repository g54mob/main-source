using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.Goap.Goals
{
	public class RitualEventGoal : EventBaseGoal
	{
		public RitualEventGoal(Agent selfAgent)
			: base("RitualEventGoal", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return RitualAction();
		}

		private GoapAction RitualAction()
		{
			GoapAction action = new GoapAction("RitualAction");
			action.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			action.OnInit = delegate
			{
				AnimationTrigger = "RitualStanding";
				action.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			action.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			return action;
		}

		protected override bool FindTargets()
		{
			if (!(GetEventInstance() is RitualEventInstance ritualEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetTarget(TargetIndex.B, new TargetObject(ritualEventInstance.GetEventPosition(Participant)));
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is RitualEventInstance result))
			{
				return null;
			}
			return result;
		}
	}
}
