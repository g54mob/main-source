using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using NSMedieval.DebugEvents;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class GeneralExtensions
	{
		private static readonly FVLogger logger = FVLogger.New("GoapAction");

		public static GoapAction TickOnInterval(this GoapAction action, float interval, Action<GoapAction> tickFun)
		{
			float lastTickTime = 0f;
			action.OnInit = delegate
			{
				lastTickTime = 0f;
			};
			action.OnTick = delegate
			{
				if (action.TotalTickingTime - lastTickTime >= interval)
				{
					lastTickTime = action.TotalTickingTime;
					tickFun(action);
				}
			};
			return action;
		}

		public static GoapAction LogDebugEventOnInit(this GoapAction action, GoapDebugEventCode eventCode)
		{
			action.OnInit = delegate
			{
				DebugEventLog.WriteGoapEvent(action, eventCode);
			};
			return action;
		}

		public static GoapAction WithDebugLog(this GoapAction action, string message)
		{
			action.OnComplete = delegate(ActionCompletionStatus state)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(10, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GeneralExtensions.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(message);
					messageBuilder.AppendLiteral(" (state: ");
					messageBuilder.AppendFormatted(state);
					messageBuilder.AppendLiteral(")");
				}
				logger.Info(in messageBuilder);
			};
			return action;
		}

		public static GoapAction WithBbt(this GoapAction action, string message, ActionBbtMode mode)
		{
			switch (mode)
			{
			case ActionBbtMode.Begin:
				action.OnPostInit = delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(message);
				};
				break;
			case ActionBbtMode.End:
				action.OnComplete = delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(message);
				};
				break;
			case ActionBbtMode.Success:
				action.OnComplete = delegate(ActionCompletionStatus state)
				{
					if (state == ActionCompletionStatus.Success)
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(message);
					}
				};
				break;
			case ActionBbtMode.Fail:
				action.OnComplete = delegate(ActionCompletionStatus state)
				{
					if (state == ActionCompletionStatus.Fail)
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(message);
					}
				};
				break;
			default:
				Log.Warning("Invalid BBT mode " + mode, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GeneralExtensions.cs");
				break;
			}
			return action;
		}

		public static GoapAction WithProgressBar(this GoapAction action, TargetIndex targetIndex, OverlayProgressBarType type, Func<IProgressBarOwner, float> value)
		{
			action.OnTick = delegate
			{
				if (!action.HasCompleted)
				{
					IProgressBarOwner progressBarOwner = ((targetIndex == TargetIndex.None) ? (action.AgentOwner as IProgressBarOwner) : (action.Goal?.GetTarget(targetIndex).ObjectInstance as IProgressBarOwner));
					if (progressBarOwner == null)
					{
						Log.Warning("Tried to show progress bar on target which is not IProgressBarOwner", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GeneralExtensions.cs");
					}
					else
					{
						progressBarOwner.GetProgressBar(type)?.SetValue(value(progressBarOwner));
					}
				}
			};
			action.OnComplete = delegate
			{
				((targetIndex == TargetIndex.None) ? (action.AgentOwner as IProgressBarOwner) : (action.Goal?.GetTarget(targetIndex).ObjectInstance as IProgressBarOwner))?.DestroyProgressBar(type);
			};
			return action;
		}

		public static GoapAction ProgressBarDestroyOnCompletion(this GoapAction action, TargetIndex targetIndex, OverlayProgressBarType type, ActionCompletionStatus mode = ActionCompletionStatus.None)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (mode == ActionCompletionStatus.None || status == mode)
				{
					((targetIndex == TargetIndex.None) ? (action.AgentOwner as IProgressBarOwner) : (action.Goal.GetTarget(targetIndex).ObjectInstance as IProgressBarOwner))?.DestroyProgressBar(type);
				}
			};
			return action;
		}

		public static GoapAction WithPopupText(this GoapAction action, TargetIndex targetIndex, string text, Color color)
		{
			action.OnInit = delegate
			{
				if (targetIndex == TargetIndex.None)
				{
					DamagePopup.Create(action.AgentOwner.GetTransform().position, text, color);
				}
				else
				{
					DamagePopup.Create(GridUtils.GetWorldPosition(action.Goal.GetTarget(targetIndex).ReachablePosition), text, color);
				}
			};
			return action;
		}

		public static GoapAction SetMinimumDurationTime(this GoapAction action, float minTime)
		{
			Task taskToCancel = null;
			action.OnPostInit = delegate
			{
				taskToCancel = MonoSingleton<TaskController>.Instance.WaitFor(minTime).Then(action.AnimationUnblockCompletition);
				action.AnimationBlockCompletition();
			};
			action.OnComplete = delegate
			{
				MonoSingleton<TaskController>.Instance.Stop(taskToCancel);
			};
			return action;
		}

		public static GoapAction FireEffectorOnCompletion(this GoapAction action, string effectorName, ActionCompletionStatus status, float durationModifier = 1f)
		{
			action.OnComplete = delegate(ActionCompletionStatus state)
			{
				if (state == status && !string.IsNullOrEmpty(effectorName))
				{
					(action.AgentOwner as IStatsOwner)?.Stats.StartEffector(effectorName, durationModifier);
				}
			};
			return action;
		}
	}
}
