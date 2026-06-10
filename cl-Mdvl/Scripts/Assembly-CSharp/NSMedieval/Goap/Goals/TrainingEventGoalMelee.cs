using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap.Goals
{
	public class TrainingEventGoalMelee : EventBaseGoal
	{
		protected AnimatedAgentView AnimatedAgentView
		{
			get
			{
				if (Participant is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					AnimatedAgentView view = MonoSingleton<WorkerManager>.Instance.GetView(humanoidInstance);
					if ((object)view != null)
					{
						return view;
					}
				}
				if (Participant is HumanoidInstance instance)
				{
					AnimatedAgentView view2 = MonoSingleton<NPCManager>.Instance.GetView(instance);
					if ((object)view2 != null)
					{
						return view2;
					}
				}
				return null;
			}
		}

		public TrainingEventGoalMelee(Agent selfAgent)
			: base("TrainingEventGoalMelee", selfAgent)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return GoToEventPosition();
			yield return EventAction();
		}

		private GoapAction EventAction()
		{
			GoapAction goapAction = new GoapAction("TrainingAction");
			goapAction.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			goapAction.OnInit = delegate
			{
				AnimationTrigger = "MeleeTraining";
				EquipProp(equipped: true);
				goapAction.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				EquipProp(equipped: false);
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
			if (!(GetEventInstance() is TrainingEventInstance trainingEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetTarget(TargetIndex.B, new TargetObject(trainingEventInstance.GetEventPosition(Participant)));
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is TrainingEventInstance result))
			{
				return null;
			}
			return result;
		}

		protected void EquipProp(bool equipped)
		{
			if (!(AnimatedAgentView is HumanoidView humanoidView))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\TrainingEventGoalMelee.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Something went wrong, ");
					messageBuilder.AppendFormatted(AnimatedAgentView);
					messageBuilder.AppendLiteral(" is not HumanoidView.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				humanoidView.BodyPreview.SetMeleePropEnabled(equipped);
			}
		}
	}
}
