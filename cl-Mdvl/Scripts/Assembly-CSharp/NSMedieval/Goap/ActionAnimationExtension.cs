using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.Goap
{
	public static class ActionAnimationExtension
	{
		public static GoapAction TriggerAnimation(this GoapAction action, string triggerName, ActionAnimationMode mode, bool isSequenced = false)
		{
			AnimationController.AgentOnlyHandler handler = null;
			action.OnPostInit = delegate
			{
				action.Goal.AddEndListener(HandleGoalFailCallback);
				if (!isSequenced)
				{
					if (MonoSingleton<AnimationController>.IsInstantiated())
					{
						MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(action.AgentOwner);
					}
					if (MonoSingleton<TaskController>.IsInstantiated())
					{
						MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
						{
							if (MonoSingleton<AnimationController>.IsInstantiated())
							{
								MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(action.AgentOwner, triggerName);
							}
						});
					}
				}
				else if (MonoSingleton<AnimationController>.IsInstantiated())
				{
					MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(action.AgentOwner, triggerName);
				}
			};
			action.OnComplete = delegate
			{
				action.Goal.RemoveEndListener(HandleGoalFailCallback);
			};
			switch (mode)
			{
			case ActionAnimationMode.Interrupt:
				action.OnComplete = delegate
				{
					MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(action.AgentOwner);
				};
				break;
			case ActionAnimationMode.WaitForCompletion:
				handler = delegate(IGoapAgentOwner agentOwner)
				{
					if (agentOwner == action.AgentOwner)
					{
						action.AnimationUnblockCompletition();
						action.Complete(ActionCompletionStatus.Success);
					}
				};
				action.OnPostInit = delegate
				{
					action.AnimationBlockCompletition();
					MonoSingleton<AnimationController>.Instance.AnimationEndedEvent += handler;
				};
				action.OnComplete = delegate
				{
					MonoSingleton<AnimationController>.Instance.AnimationEndedEvent -= handler;
					if (action.Goal.State != GoalState.Running && action.WaitingForAnimation)
					{
						MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(action.AgentOwner);
					}
				};
				break;
			case ActionAnimationMode.WaitForEvent:
				action.OnPostInit = action.AnimationBlockCompletition;
				break;
			default:
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionAnimationExtension.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Invalid ActionAnimationMode ");
					messageBuilder.AppendFormatted(mode);
				}
				Log.Error(messageBuilder);
				break;
			}
			case ActionAnimationMode.Ignore:
				break;
			}
			return action;
			void HandleGoalFailCallback(GoalCondition condition)
			{
				if (isSequenced)
				{
					action.AnimationUnblockCompletition();
				}
				if (condition != GoalCondition.Succeeded && MonoSingleton<AnimationController>.IsInstantiated())
				{
					MonoSingleton<AnimationController>.Instance.AnimationEndedEvent -= handler;
					MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(action.AgentOwner);
				}
			}
		}

		public static GoapAction ForceQuitAnimation(this GoapAction action)
		{
			action.OnPostInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(action.Goal.AgentOwner);
			};
			return action;
		}

		public static GoapAction SetAnimationParameter(this GoapAction action, string parameterName, bool parameterValue)
		{
			action.OnPostInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.Goal.AgentOwner, parameterName, parameterValue);
			};
			return action;
		}

		public static GoapAction SetAnimationParameter(this GoapAction action, string parameterName, float parameterValue)
		{
			action.OnPostInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.Goal.AgentOwner, parameterName, parameterValue);
			};
			return action;
		}

		public static GoapAction SetAnimationParameter(this GoapAction action, string parameterName, int parameterValue)
		{
			action.OnPostInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.Goal.AgentOwner, parameterName, parameterValue);
			};
			return action;
		}

		public static GoapAction WithDynamicAnimatorParameter(this GoapAction action, string parameter, Func<int> func)
		{
			action.OnPostInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.Goal.AgentOwner, parameter, func());
			};
			return action;
		}

		public static GoapAction CompleteActionOnAnimationGoapEvent(this GoapAction action, string eventName, ActionCompletionStatus status)
		{
			action.OnInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent += Handler;
			};
			action.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent -= Handler;
			};
			return action;
			void Handler(IGoapAgentOwner agent, string name)
			{
				if (action.Goal.AgentOwner == agent && name.Equals(eventName))
				{
					action.AnimationUnblockCompletition();
					action.Complete(status);
				}
			}
		}

		public static GoapAction OnAnimationGoapEvent(this GoapAction action, string eventName, Action callback)
		{
			action.OnInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent += Handler;
			};
			action.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent -= Handler;
			};
			return action;
			void Handler(IGoapAgentOwner agent, string name)
			{
				if (action.Goal.AgentOwner == agent && name.Equals(eventName))
				{
					callback?.Invoke();
				}
			}
		}
	}
}
