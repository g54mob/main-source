using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.StatsSystem;

namespace NSMedieval.Goap
{
	public class GoalScheduler
	{
		private readonly List<GoalPriorityData> enabledGoals;

		private readonly IDictionary<string, GoalPriorityData> goalsPool;

		private readonly IDictionary<string, bool> goalBaseEnableStatus;

		private readonly IDictionary<string, bool> goalForceEnableStatus;

		private readonly List<GoalPriorityData> startableGoals;

		[NonSerialized]
		private IGoapAgentOwner agent;

		private float startableGoalMaxPriority = float.MaxValue;

		public float StartableGoalMaxPriority => startableGoalMaxPriority;

		public List<GoalPriorityData> StartableGoals => startableGoals;

		public List<GoalPriorityData> EnabledGoals => enabledGoals;

		public GoalScheduler(IGoapAgentOwner agent)
		{
			goalsPool = new Dictionary<string, GoalPriorityData>();
			enabledGoals = new List<GoalPriorityData>();
			startableGoals = new List<GoalPriorityData>();
			goalBaseEnableStatus = new Dictionary<string, bool>();
			goalForceEnableStatus = new Dictionary<string, bool>();
			this.agent = agent;
		}

		public float GetJobPriority(string goalId)
		{
			if (!goalsPool.TryGetValue(goalId, out var value))
			{
				return float.MaxValue;
			}
			return value.JobPriority;
		}

		public float GetGoalPriority(Goal goal)
		{
			if (goalsPool.ContainsKey(goal.Id))
			{
				return goalsPool[goal.Id].FinalPriority;
			}
			return float.MaxValue;
		}

		public void AddToPool(Goal goal, bool enableGoal = false)
		{
			if (goalsPool.ContainsKey(goal.Id))
			{
				GoalPriorityData goalPriorityData = goalsPool[goal.Id];
				goalPriorityData.Dispose();
				goalsPool[goal.Id] = null;
				enabledGoals.Remove(goalPriorityData);
			}
			goalsPool[goal.Id] = new GoalPriorityData(goal, (float)goalsPool.Count + 1f);
			if (enableGoal)
			{
				EnableGoal(goal.Id);
			}
		}

		public void AddToPool(GoalPriorityData data)
		{
			if (goalsPool.ContainsKey(data.Goal.Id))
			{
				GoalPriorityData goalPriorityData = goalsPool[data.Goal.Id];
				goalPriorityData.Dispose();
				goalsPool[data.Goal.Id] = null;
				if (enabledGoals.Contains(goalPriorityData))
				{
					enabledGoals.Remove(goalPriorityData);
					enabledGoals.Add(data);
				}
			}
			goalsPool[data.Goal.Id] = data;
		}

		public bool ExistInPool(string id)
		{
			return goalsPool.ContainsKey(id);
		}

		public bool IsEnabled(string id)
		{
			return enabledGoals.FindIndex((GoalPriorityData item) => item.Goal.Id.Equals(id)) > -1;
		}

		public void EnableGoal(string id)
		{
			goalBaseEnableStatus[id] = true;
			if (CheckGoalState(id))
			{
				SetGoalEnabled(id, state: true);
			}
		}

		public void DisableGoal(string id)
		{
			goalBaseEnableStatus[id] = false;
			if (!CheckGoalState(id))
			{
				SetGoalEnabled(id, state: false);
			}
		}

		public void AddForceEnableState(string id, bool state)
		{
			goalForceEnableStatus[id] = state;
			SetGoalEnabled(id, state);
		}

		public void RemoveForceEnableState(string id)
		{
			if (goalForceEnableStatus.ContainsKey(id))
			{
				goalForceEnableStatus.Remove(id);
				SetGoalEnabled(id, CheckGoalState(id));
			}
		}

		private void SetGoalEnabled(string id, bool state)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(32, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoalScheduler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetGoalEnabled '");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral("' -> ");
				messageBuilder.AppendFormatted(state);
				messageBuilder.AppendLiteral(" for agent ");
				messageBuilder.AppendFormatted(agent);
			}
			Log.Trace(messageBuilder);
			if (!goalsPool.TryGetValue(id, out var value))
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoalScheduler.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Could not enable goal '");
					messageBuilder2.AppendFormatted(id);
					messageBuilder2.AppendLiteral("' since it is not in pool");
				}
				Log.Warning(messageBuilder2);
				return;
			}
			if (state)
			{
				if (enabledGoals.Contains(value))
				{
					return;
				}
				enabledGoals.Add(value);
			}
			else
			{
				if (!enabledGoals.Contains(value))
				{
					return;
				}
				enabledGoals.Remove(value);
				if (startableGoals.Contains(value))
				{
					startableGoals.Remove(value);
				}
			}
			UpdatePrioritiesDelayed();
		}

		public bool CheckGoalState(string id)
		{
			if (goalForceEnableStatus.TryGetValue(id, out var value))
			{
				return value;
			}
			if (goalBaseEnableStatus.TryGetValue(id, out var value2))
			{
				return value2;
			}
			return false;
		}

		public void DisableAllGoals()
		{
			startableGoals.Clear();
			enabledGoals.Clear();
		}

		public void ModifyJobPriority(string goalId, float priority)
		{
			if (!goalsPool.ContainsKey(goalId))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(71, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoalScheduler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to modify goal priority, but agent dose not have goal specified: ");
					messageBuilder.AppendFormatted(goalId);
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				goalsPool[goalId].JobPriority += priority;
				UpdatePrioritiesDelayed();
			}
		}

		public void UpdatePrioritiesDelayed()
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "PrioUpdate", UpdatePriorities);
		}

		public void GatherStartableGoals()
		{
			startableGoals.Clear();
			for (int i = 0; i < enabledGoals.Count; i++)
			{
				GoalPriorityData goalPriorityData = enabledGoals[i];
				if (goalPriorityData != null && goalPriorityData.Goal != null && !(goalPriorityData.FinalPriority >= startableGoalMaxPriority) && goalPriorityData.Goal.CanStart())
				{
					startableGoals.Add(goalPriorityData);
				}
			}
		}

		public void SetStartableGoalMaximumPriority(float priority)
		{
			startableGoalMaxPriority = priority;
		}

		internal void SetBasePriority(string goalId, float priority)
		{
			if (!goalsPool.ContainsKey(goalId))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(73, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoalScheduler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to set goal base priority, but agent dose not have goal specified: ");
					messageBuilder.AppendFormatted(goalId);
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				goalsPool[goalId].BasePriority = priority;
				UpdatePrioritiesDelayed();
			}
		}

		internal Goal GetFromPool(string id)
		{
			if (!ExistInPool(id))
			{
				return null;
			}
			return goalsPool[id].Goal;
		}

		private void UpdatePriorities()
		{
			UpdateStatPriorities();
			enabledGoals.Sort((GoalPriorityData x, GoalPriorityData y) => x.FinalPriority.CompareTo(y.FinalPriority));
		}

		private void UpdateStatPriorities()
		{
			Goal goal = enabledGoals?.FirstOrDefault()?.Goal;
			if (!(goal?.AgentOwner is IStatsOwner statsOwner) || goal.Agent is CombatAiAgent || statsOwner.Stats == null)
			{
				return;
			}
			foreach (GoalPriorityData enabledGoal in enabledGoals)
			{
				enabledGoal.StatsPriorityModifier = statsOwner.Stats.GetGoalPriorityModifierValue(enabledGoal.GoalId);
				enabledGoal.FixedPriority = statsOwner.Stats.GetGoalFixedPriority(enabledGoal.GoalId);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(81, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\GoalScheduler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Goal stats priority changed for goal '");
					messageBuilder.AppendFormatted(enabledGoal.GoalId);
					messageBuilder.AppendLiteral("', StatsPriorityModifier: ");
					messageBuilder.AppendFormatted(enabledGoal.StatsPriorityModifier);
					messageBuilder.AppendLiteral(", FixedPriority: ");
					messageBuilder.AppendFormatted(enabledGoal.FixedPriority);
				}
				Log.Trace(messageBuilder);
			}
		}

		public void Dispose()
		{
			agent = null;
			startableGoals.Clear();
			enabledGoals.Clear();
			foreach (GoalPriorityData value in goalsPool.Values)
			{
				value.Goal?.Dispose();
				value.Dispose();
			}
			goalsPool.Clear();
		}
	}
}
