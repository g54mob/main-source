using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.Goap.Goals
{
	public class MasterClassEventGoal : EventBaseGoal
	{
		public MasterClassEventGoal(Agent selfAgent)
			: base("MasterClassEventGoal", selfAgent)
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
			yield return EventAction();
		}

		private GoapAction EventAction()
		{
			GoapAction goapAction = new GoapAction("MasterClassAction");
			goapAction.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			goapAction.OnInit = delegate
			{
				AnimationTrigger = "MasterClassSitting";
				goapAction.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			return goapAction;
		}

		protected override bool FindTargets()
		{
			if (!(GetEventInstance() is MasterClassEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetEventPositionTarget();
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is MasterClassEventInstance result))
			{
				return null;
			}
			return result;
		}
	}
}
