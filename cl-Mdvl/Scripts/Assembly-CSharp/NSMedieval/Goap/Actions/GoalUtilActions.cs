using System;
using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.Goap.Actions
{
	public static class GoalUtilActions
	{
		public static GoapAction ClearDisposedNullForbiddenQueuedTargets()
		{
			GoapAction action = new GoapAction("ClearDisposedNullForbiddenQueuedTargets");
			action.OnInit = delegate
			{
				foreach (List<TargetObject> value in action.Goal.GetQueues().Values)
				{
					if (value != null && value.Count != 1)
					{
						List<TargetObject> list = new List<TargetObject>();
						list.AddRange(value);
						foreach (TargetObject item in list)
						{
							if (!item.IsInitialized || (item.ObjectInstance != null && item.ObjectInstance.HasDisposed) || item.ObjectInstance is IForbidable { IsForbidden: not false })
							{
								value.Remove(item);
							}
						}
					}
				}
			};
			return action;
		}

		public static GoapAction CompleteIfNoTargetsInQueue(TargetIndex index)
		{
			GoapAction action = new GoapAction("CompleteIfNoTargetsInQueue");
			action.AddGoalEndingCondition(delegate
			{
				List<TargetObject> targetQueue = action.Goal.GetTargetQueue(index);
				return (targetQueue != null && targetQueue.Count != 0) ? GoalCondition.OnGoing : GoalCondition.Succeeded;
			});
			return action;
		}

		public static GoapAction SetCustomTarget(TargetIndex index, Func<TargetObject> func)
		{
			GoapAction action = new GoapAction("SetCustomTarget");
			action.OnInit = delegate
			{
				TargetObject target = func();
				if (!target.IsInitialized)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					action.Goal.ForceTarget(index, target);
				}
			};
			return action;
		}

		public static GoapAction SelectNextTargetFromQueue(TargetIndex index)
		{
			GoapAction action = new GoapAction("SelectNextTargetFromQueue");
			action.OnInit = delegate
			{
				action.Goal.SelectNextTarget(index);
			};
			return action;
		}

		public static GoapAction SelectClosestTargetFromQueue(TargetIndex index)
		{
			GoapAction action = new GoapAction("SelectClosestTargetFromQueue");
			action.OnInit = delegate
			{
				List<TargetObject> targetQueue = action.Goal.GetTargetQueue(index);
				if (targetQueue != null && targetQueue.Count != 0 && action.AgentOwner is IPathfindingAgent pathfindingAgent)
				{
					float num = float.MaxValue;
					TargetObject target = default(TargetObject);
					for (int i = 0; i < targetQueue.Count; i++)
					{
						float num2 = Vec3Int.Distance(targetQueue[i].ReachablePosition, pathfindingAgent.GetPosition());
						if (num > num2)
						{
							num = num2;
							target = targetQueue[i];
						}
					}
					if (num >= float.MaxValue || !target.IsInitialized)
					{
						action.Goal.SelectNextTarget(index);
					}
					else
					{
						action.Goal.SelectTarget(index, target);
					}
				}
			};
			return action;
		}

		public static GoapAction EndGoalWith(GoalCondition condition)
		{
			GoapAction action = new GoapAction("EndGoalWith");
			action.OnInit = delegate
			{
				action.Goal.EndGoalWith(condition);
			};
			return action;
		}
	}
}
