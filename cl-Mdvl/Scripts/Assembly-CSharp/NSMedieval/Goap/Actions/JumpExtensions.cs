using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.Goap.Actions
{
	public static class JumpExtensions
	{
		public static GoapAction JumpIf(this GoapAction action, GoapAction nextAction, Func<bool> condition)
		{
			action.OnPostInit = delegate
			{
				if (condition())
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			action.OnTick = delegate
			{
				if (condition())
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpOnCompletion(this GoapAction action, GoapAction nextAction, ActionCompletionStatus mode)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (mode == ActionCompletionStatus.None || mode == status)
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpOnCompletionIfNotStatus(this GoapAction action, GoapAction nextAction, ActionCompletionStatus mode)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (mode != status)
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpOnCompletionIfHaveTargetsInQueue(this GoapAction action, GoapAction nextAction, TargetIndex queue, ActionCompletionStatus mode)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if ((mode == ActionCompletionStatus.None || mode == status) && action.Goal.GetTargetQueue(queue).Count > 0)
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpOnCompletionIfHaveNoTargetsInQueue(this GoapAction action, GoapAction nextAction, TargetIndex queue, ActionCompletionStatus mode)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if ((mode == ActionCompletionStatus.None || mode == status) && action.Goal.GetTargetQueue(queue).Count <= 0)
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpIfTargetDisposedForbiddenOrNull(this GoapAction action, GoapAction nextAction, TargetIndex index)
		{
			return action.JumpIf(nextAction, delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				return target.ObjectInstance == null || target.ObjectInstance.HasDisposed || (target.ObjectInstance is IForbidable forbidable && forbidable.IsForbidden);
			});
		}

		public static GoapAction JumpIfTargetDisposedForbiddenOrNull(this GoapAction action, GoapAction nextAction, TargetIndex index, bool checkIfForbidden)
		{
			return action.JumpIf(nextAction, delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				return target.ObjectInstance == null || target.ObjectInstance.HasDisposed || (checkIfForbidden && target.ObjectInstance is IForbidable forbidable && forbidable.IsForbidden);
			});
		}

		public static GoapAction JumpIfTargetDisposedOrNull(this GoapAction action, GoapAction nextAction, TargetIndex index)
		{
			return action.JumpIf(nextAction, delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				return target.ObjectInstance == null || target.ObjectInstance.HasDisposed;
			});
		}

		public static GoapAction SkipIfCondition(this GoapAction action, Func<bool> condition)
		{
			action.OnPreInit = delegate
			{
				if (condition())
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			action.OnTick = delegate
			{
				if (condition())
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			return action;
		}

		public static GoapAction SkipIfTargetDisposedForbidenOrNull(this GoapAction action, TargetIndex targetIndex)
		{
			action.OnPreInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || target.ObjectInstance is IForbidable { IsForbidden: not false })
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			action.OnTick = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || target.ObjectInstance is IForbidable { IsForbidden: not false })
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			return action;
		}

		public static GoapAction SkipIfTargetDisposedForbiddenOrNull(this GoapAction action, TargetIndex targetIndex, bool checkForbidden)
		{
			action.OnPreInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || (checkForbidden && target.ObjectInstance is IForbidable { IsForbidden: not false }))
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			action.OnTick = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				if (target.ObjectInstance == null || target.ObjectInstance.HasDisposed || (checkForbidden && target.ObjectInstance is IForbidable { IsForbidden: not false }))
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
			};
			return action;
		}

		public static GoapAction SkipIfTargetReservationReleases(this GoapAction action, TargetIndex targetIndex)
		{
			action.OnPreInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				IReservable asReservable = target.GetAsReservable();
				if (!MonoSingleton<ReservationManager>.Instance.IsReservedBy(target.GetAsReservable(), action.AgentOwner))
				{
					action.Complete(ActionCompletionStatus.Jump);
				}
				else
				{
					Action<IReservable, IGoapAgentOwner> callback = null;
					callback = delegate(IReservable reservableObject, IGoapAgentOwner agent)
					{
						if (agent == action.Goal.AgentOwner && reservableObject == target.ObjectInstance)
						{
							asReservable.OnReservedEvent -= callback;
							action.Complete(ActionCompletionStatus.Jump);
						}
					};
					asReservable.OnReservedEvent += callback;
					action.OnComplete = delegate
					{
						asReservable.OnReservedEvent -= callback;
					};
				}
			};
			return action;
		}

		public static GoapAction SkipOnFailure(this GoapAction action)
		{
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success && status != ActionCompletionStatus.Jump)
				{
					GoapAction nextAction = action.Goal.NextAction;
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpIfTargetReservationReleases(this GoapAction action, GoapAction nextAction, TargetIndex targetIndex)
		{
			action.OnPreInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				IReservable asReservable = target.GetAsReservable();
				if (!MonoSingleton<ReservationManager>.Instance.IsReservedBy(target.GetAsReservable(), action.AgentOwner))
				{
					action.Goal.JumpToAction(nextAction);
				}
				else
				{
					Action<IReservable, IGoapAgentOwner> callback = null;
					callback = delegate(IReservable reservableObject, IGoapAgentOwner agent)
					{
						if (agent == action.Goal.AgentOwner && reservableObject == target.ObjectInstance)
						{
							asReservable.OnReservedEvent -= callback;
							action.Goal.JumpToAction(nextAction);
						}
					};
					asReservable.OnReservedEvent += callback;
					action.OnComplete = delegate
					{
						asReservable.OnReservedEvent -= callback;
					};
				}
			};
			return action;
		}
	}
}
