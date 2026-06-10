using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Actions
{
	public static class ActionEndingConditions
	{
		public static GoapAction FailAtCondition(this GoapAction action, Func<bool> condition, bool spamLogs = false)
		{
			action.AddGoalEndingCondition(delegate
			{
				if (condition())
				{
					if (spamLogs)
					{
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("[AFD] FailAtCondition, action.Id: ");
							messageBuilder.AppendFormatted(action.Id);
							messageBuilder.AppendLiteral(", action.Goal.Id: ");
							messageBuilder.AppendFormatted(action.Goal.Id);
						}
						Log.Debug(messageBuilder);
					}
					return GoalCondition.Incompletable;
				}
				return GoalCondition.OnGoing;
			});
			return action;
		}

		public static GoapAction FailIfTargetDisposedForbidenOrNull(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || target.ObjectInstance is IForbidable { IsForbidden: not false })
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(88, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("[AFD] FailIfTargetDisposedForbidenOrNull, action '");
						messageBuilder.AppendFormatted(action.Id);
						messageBuilder.AppendLiteral("', target.ObjectInstance: '");
						messageBuilder.AppendFormatted(target.ObjectInstance);
						messageBuilder.AppendLiteral("', agent '");
						messageBuilder.AppendFormatted(action.AgentOwner);
						messageBuilder.AppendLiteral("'");
					}
					Log.Trace(messageBuilder);
					return GoalCondition.Incompletable;
				}
				return GoalCondition.OnGoing;
			});
			return action;
		}

		public static GoapAction FailIfTargetDisposedOrNull(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				return (target.ObjectInstance != null && !target.ObjectInstance.HasDisposed) ? GoalCondition.OnGoing : GoalCondition.Incompletable;
			});
			return action;
		}

		public static GoapAction FailIfTargetDisposed(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				return (!target.IsInitialized || target.ObjectInstance == null || !target.ObjectInstance.HasDisposed) ? GoalCondition.OnGoing : GoalCondition.Incompletable;
			});
			return action;
		}

		public static GoapAction FailIfTargetReservationReleases(this GoapAction action, TargetIndex targetIndex)
		{
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				IReservable asReservable = target.GetAsReservable();
				if (!MonoSingleton<ReservationManager>.Instance.IsReservedBy(asReservable, action.AgentOwner))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(56, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("FailIfTargetReservationReleases, action '");
						messageBuilder.AppendFormatted(action.Id);
						messageBuilder.AppendLiteral("', '");
						messageBuilder.AppendFormatted(target.ObjectInstance);
						messageBuilder.AppendLiteral("', agent '");
						messageBuilder.AppendFormatted(action.AgentOwner);
						messageBuilder.AppendLiteral("'");
					}
					Log.Trace(messageBuilder);
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					Action<IReservable, IGoapAgentOwner> callback = null;
					callback = delegate(IReservable reservableObject, IGoapAgentOwner agent)
					{
						if (agent == action.Goal.AgentOwner && reservableObject == target.ObjectInstance)
						{
							asReservable.OnReleasedEvent -= callback;
							bool isEnabled2;
							FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(56, 3, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("FailIfTargetReservationReleases, action '");
								messageBuilder2.AppendFormatted(action.Id);
								messageBuilder2.AppendLiteral("', '");
								messageBuilder2.AppendFormatted(target.ObjectInstance);
								messageBuilder2.AppendLiteral("', agent '");
								messageBuilder2.AppendFormatted(action.AgentOwner);
								messageBuilder2.AppendLiteral("'");
							}
							Log.Trace(messageBuilder2);
							action.Complete(ActionCompletionStatus.Fail);
						}
					};
					asReservable.OnReleasedEvent += callback;
					action.OnComplete = delegate
					{
						asReservable.OnReleasedEvent -= callback;
					};
				}
			};
			return action;
		}

		public static GoapAction FailIfResourcePileHasNoResources(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				if (!(action.Goal.GetTarget(targetIndex).ObjectInstance is ResourcePileInstance resourcePileInstance))
				{
					return GoalCondition.Incompletable;
				}
				return (resourcePileInstance.GetStoredResource() != null) ? GoalCondition.OnGoing : GoalCondition.Incompletable;
			});
			return action;
		}

		public static GoapAction FailIfTargetBecomesUnreachable(this GoapAction action)
		{
			action.OnPostInit = delegate
			{
				PathfinderAgentDriver pathfinderAgentDriver = (action.AgentOwner as IPathfindingAgent)?.PathDriver;
				if (pathfinderAgentDriver != null)
				{
					pathfinderAgentDriver.OnClearPathEvent += OnFailedCallback;
				}
			};
			action.OnComplete = delegate
			{
				PathfinderAgentDriver pathfinderAgentDriver = (action.AgentOwner as IPathfindingAgent)?.PathDriver;
				if (pathfinderAgentDriver != null)
				{
					pathfinderAgentDriver.OnClearPathEvent -= OnFailedCallback;
				}
			};
			return action;
			void OnFailedCallback(PathfinderAgentDriver driver, PathDriverCompletionState state)
			{
				if (state == PathDriverCompletionState.FailedToReachDestination)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
			}
		}

		public static GoapAction FailIfTargetBecomesFireDangerous(this GoapAction action, TargetIndex targetIndex)
		{
			action.TickOnInterval(0.25f, delegate(GoapAction goapAction)
			{
				TargetObject target = goapAction.Goal.GetTarget(targetIndex);
				if (goapAction.AgentOwner.Map.FirePresenceGrid.HasFirePresence(target.ReachablePosition))
				{
					goapAction.Complete(ActionCompletionStatus.Fail);
				}
			});
			return action;
		}

		private static void FailIfTargetInFireDanger(GoapAction goapAction)
		{
			IDamageTakingAgent damageTakingAgent = (goapAction.AgentOwner as IDamageDealAgent)?.GetTarget();
			if (!CombatUtils.IsNullOrDisposed(damageTakingAgent) && goapAction.AgentOwner.Map.FirePresenceGrid.HasFirePresence(damageTakingAgent.GetNode()))
			{
				goapAction.Complete(ActionCompletionStatus.Fail);
			}
		}

		public static GoapAction FailIfTargetBecomesFireDangerous(this GoapAction action)
		{
			action.OnPreInit = delegate
			{
				FailIfTargetInFireDanger(action);
			};
			action.TickOnInterval(0.25f, FailIfTargetInFireDanger);
			return action;
		}

		public static GoapAction FailIfTargetIsNotType<T>(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || !(target.ObjectInstance is T))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(49, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("FailIfTargetIsNotType '");
						messageBuilder.AppendFormatted(typeof(T).Name);
						messageBuilder.AppendLiteral("', action '");
						messageBuilder.AppendFormatted(action.Id);
						messageBuilder.AppendLiteral("', '");
						messageBuilder.AppendFormatted(target.ObjectInstance);
						messageBuilder.AppendLiteral("', agent '");
						messageBuilder.AppendFormatted(action.AgentOwner);
						messageBuilder.AppendLiteral("'");
					}
					Log.Trace(messageBuilder);
					return GoalCondition.Incompletable;
				}
				return GoalCondition.OnGoing;
			});
			return action;
		}

		public static GoapAction CompleteAfterTimeExpires(this GoapAction action, float time)
		{
			action.Duration = time;
			action.CompleteMode = ActionCompleteMode.Delay;
			return action;
		}

		public static GoapAction FailAfterTimeMinutesTotal(this GoapAction action, long expireMinutesTimestamp)
		{
			action.OnTick = delegate
			{
				if (GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware >= expireMinutesTimestamp)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
			};
			return action;
		}

		public static GoapAction CompleteAtCondition(this GoapAction action, Func<bool> condition)
		{
			action.OnTick = delegate
			{
				if (condition())
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(52, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ActionEndingConditions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("GoapAction '");
						messageBuilder.AppendFormatted(action.Id);
						messageBuilder.AppendLiteral("' CompleteAtCondition in type ");
						messageBuilder.AppendFormatted(condition.Method.DeclaringType?.Name);
						messageBuilder.AppendLiteral(", agent '");
						messageBuilder.AppendFormatted(action.AgentOwner);
						messageBuilder.AppendLiteral("'");
					}
					Log.Trace(messageBuilder);
					action.Complete(ActionCompletionStatus.Success);
				}
			};
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static GoapAction FailIfTargetResourcePileInstanceFailsPrisonConditions(this GoapAction action, TargetIndex targetIndex)
		{
			action.AddGoalEndingCondition(delegate
			{
				if (!(action.Goal.GetTarget(targetIndex).ObjectInstance is ResourcePileInstance resourcePileInstance))
				{
					return GoalCondition.Incompletable;
				}
				if (!(action.AgentOwner is HumanoidInstance human))
				{
					return GoalCondition.Incompletable;
				}
				return CommonGoalMethods.CheckPrisonConditions(human, resourcePileInstance.GetRoom()) ? GoalCondition.OnGoing : GoalCondition.Incompletable;
			});
			return action;
		}
	}
}
