using System;
using NSMedieval.Pathfinding;

namespace NSMedieval.Goap.Actions
{
	public static class EventActions
	{
		public static GoapAction GoToGatherPosition(TargetIndex targetIndex, PathCompleteMode pathCompleteMode, Func<bool> failAction, Action onCompleteAction)
		{
			GoapAction goapAction = GoToActions.GoToTarget(targetIndex, pathCompleteMode).FailAtCondition(failAction);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					onCompleteAction?.Invoke();
				}
			};
			return goapAction;
		}
	}
}
