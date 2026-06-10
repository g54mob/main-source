using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NSMedieval.Goap
{
	public class GoalExecutionManager : IDisposable
	{
		private const float InterruptCheckInterval = 1f;

		private GoalScheduler goalScheduler;

		private readonly List<Goal> startableGoals;

		private float lastInterruptCheckTime;

		public GoalScheduler GoalScheduler => goalScheduler;

		public GoalExecutionManager(IGoapAgentOwner agent)
		{
			startableGoals = new List<Goal>();
			goalScheduler = new GoalScheduler(agent);
		}

		public void Dispose()
		{
			goalScheduler?.Dispose();
			goalScheduler = null;
			startableGoals.Clear();
		}

		internal Goal CheckForInterruption(Goal goal)
		{
			if (goal == null || goal.State != GoalState.Running || goal.InterruptMode == GoalInterruptMode.Never)
			{
				return null;
			}
			float time = Time.time;
			if (lastInterruptCheckTime <= 0f)
			{
				lastInterruptCheckTime = time;
			}
			if (time - lastInterruptCheckTime < 1f)
			{
				return null;
			}
			if (!goal.CanBeInterrupted())
			{
				return null;
			}
			lastInterruptCheckTime = time;
			GatherStartableGoalsForInterrupt(goalScheduler.IsEnabled(goal.Id) ? goalScheduler.GetGoalPriority(goal) : 999f);
			while (startableGoals.Count > 0 && !CanBeInterrupted(goal, startableGoals[0]))
			{
				startableGoals.RemoveAt(0);
			}
			if (startableGoals.Count == 0)
			{
				return null;
			}
			Goal result = startableGoals[0];
			startableGoals.RemoveAt(0);
			return result;
		}

		internal void Reset()
		{
			startableGoals.Clear();
			lastInterruptCheckTime = Time.time;
		}

		internal virtual Goal GetNextToStart()
		{
			GatherStartableGoals();
			Goal goal = startableGoals.FirstOrDefault();
			if (goal == null)
			{
				return null;
			}
			startableGoals.Remove(goal);
			return goal;
		}

		internal void SetStartableGoalMaximumPriority(float priority)
		{
			GoalScheduler.SetStartableGoalMaximumPriority(priority);
		}

		protected void GatherStartableGoals()
		{
			if (startableGoals.Count == 0)
			{
				goalScheduler.GatherStartableGoals();
				if (goalScheduler.StartableGoals.Count <= 0)
				{
					return;
				}
				{
					foreach (GoalPriorityData startableGoal in goalScheduler.StartableGoals)
					{
						startableGoals.Add(startableGoal.Goal);
					}
					return;
				}
			}
			startableGoals.RemoveAll((Goal item) => goalScheduler.StartableGoals.FirstOrDefault((GoalPriorityData goalPriorityData) => goalPriorityData.Goal == item) == null);
		}

		protected virtual bool CanBeInterrupted(Goal goalToInterrupt, Goal goalToInterruptWith)
		{
			if (goalToInterrupt?.Agent == null)
			{
				return false;
			}
			if (goalToInterrupt == goalToInterrupt.Agent.GoalToStart)
			{
				return false;
			}
			return true;
		}

		private void GatherStartableGoalsForInterrupt(float maxPriority)
		{
			if (startableGoals.Count > 0)
			{
				return;
			}
			goalScheduler.GatherStartableGoals();
			for (int i = 0; i < goalScheduler.StartableGoals.Count; i++)
			{
				GoalPriorityData goalPriorityData = goalScheduler.StartableGoals[i];
				if (goalPriorityData.FinalPriority < maxPriority)
				{
					startableGoals.Add(goalPriorityData.Goal);
					continue;
				}
				break;
			}
		}
	}
}
