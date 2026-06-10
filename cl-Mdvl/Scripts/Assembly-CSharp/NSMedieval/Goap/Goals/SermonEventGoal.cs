using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.Goap.Goals
{
	public class SermonEventGoal : EventBaseGoal
	{
		public SermonEventGoal(Agent selfAgent)
			: base("SermonEventGoal", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return FindEventPosition();
			if (TargetChairReserved)
			{
				yield return SitAction();
			}
			yield return SermonAction();
		}

		private GoapAction SermonAction()
		{
			GoapAction sermonAction = new GoapAction("SermonAction");
			sermonAction.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			sermonAction.OnInit = delegate
			{
				AnimationTrigger = "SermonStanding";
				sermonAction.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			sermonAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			return sermonAction;
		}

		protected override bool FindTargets()
		{
			if (!(GetEventInstance() is SermonEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetEventPositionTarget();
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is SermonEventInstance result))
			{
				return null;
			}
			return result;
		}
	}
}
