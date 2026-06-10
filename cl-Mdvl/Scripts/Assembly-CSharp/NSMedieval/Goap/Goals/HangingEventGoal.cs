using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.Goap.Goals
{
	public class HangingEventGoal : EventBaseGoal
	{
		public HangingEventGoal(Agent selfAgent)
			: base("HangingEventGoal", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return HangingAction();
		}

		private GoapAction HangingAction()
		{
			GoapAction action = new GoapAction("HangingAction");
			action.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			action.OnInit = delegate
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HangingEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral(" is starting hanging event action");
				}
				Log.Debug(messageBuilder);
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
			if (!(GetEventInstance() is HangingEventInstance hangingEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetTarget(TargetIndex.B, new TargetObject(hangingEventInstance.GetEventPosition(Participant)));
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is HangingEventInstance result))
			{
				return null;
			}
			return result;
		}
	}
}
