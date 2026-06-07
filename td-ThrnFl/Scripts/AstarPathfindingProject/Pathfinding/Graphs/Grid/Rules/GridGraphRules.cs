using System;
using System.Collections.Generic;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Rules
{
	[JsonOptIn]
	public class GridGraphRules
	{
		public class Context
		{
			public GridGraph graph;

			public GridGraphScanData data;

			public JobDependencyTracker tracker => data.dependencyTracker;
		}

		private List<Action<Context>>[] jobSystemCallbacks;

		private List<Action<Context>>[] mainThreadCallbacks;

		[JsonMember]
		private List<GridGraphRule> rules = new List<GridGraphRule>();

		private long lastHash;

		public void AddRule(GridGraphRule rule)
		{
			rules.Add(rule);
			lastHash = -1L;
		}

		public void RemoveRule(GridGraphRule rule)
		{
			rules.Remove(rule);
			lastHash = -1L;
		}

		public IReadOnlyList<GridGraphRule> GetRules()
		{
			if (rules == null)
			{
				rules = new List<GridGraphRule>();
			}
			return rules.AsReadOnly();
		}

		private long Hash()
		{
			long num = 196613L;
			for (int i = 0; i < rules.Count; i++)
			{
				if (rules[i] != null && rules[i].enabled)
				{
					num = (num * 1572869) ^ rules[i].Hash;
				}
			}
			return num;
		}

		public void RebuildIfNecessary()
		{
			long num = Hash();
			if (num != lastHash || jobSystemCallbacks == null || mainThreadCallbacks == null)
			{
				lastHash = num;
				Rebuild();
			}
		}

		public void Rebuild()
		{
			rules = rules ?? new List<GridGraphRule>();
			jobSystemCallbacks = jobSystemCallbacks ?? new List<Action<Context>>[6];
			for (int i = 0; i < jobSystemCallbacks.Length; i++)
			{
				if (jobSystemCallbacks[i] != null)
				{
					jobSystemCallbacks[i].Clear();
				}
			}
			mainThreadCallbacks = mainThreadCallbacks ?? new List<Action<Context>>[6];
			for (int j = 0; j < mainThreadCallbacks.Length; j++)
			{
				if (mainThreadCallbacks[j] != null)
				{
					mainThreadCallbacks[j].Clear();
				}
			}
			for (int k = 0; k < rules.Count; k++)
			{
				if (rules[k].enabled)
				{
					rules[k].Register(this);
				}
			}
		}

		public void DisposeUnmanagedData()
		{
			if (rules == null)
			{
				return;
			}
			for (int i = 0; i < rules.Count; i++)
			{
				if (rules[i] != null)
				{
					rules[i].DisposeUnmanagedData();
					rules[i].SetDirty();
				}
			}
		}

		private static void CallActions(List<Action<Context>> actions, Context context)
		{
			if (actions == null)
			{
				return;
			}
			try
			{
				for (int i = 0; i < actions.Count; i++)
				{
					actions[i](context);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public IEnumerator<JobHandle> ExecuteRule(GridGraphRule.Pass rule, Context context)
		{
			if (jobSystemCallbacks == null)
			{
				Rebuild();
			}
			CallActions(jobSystemCallbacks[(int)rule], context);
			if (mainThreadCallbacks[(int)rule] != null && mainThreadCallbacks[(int)rule].Count > 0)
			{
				if (!context.tracker.forceLinearDependencies)
				{
					yield return context.tracker.AllWritesDependency;
				}
				CallActions(mainThreadCallbacks[(int)rule], context);
			}
		}

		public void ExecuteRuleMainThread(GridGraphRule.Pass rule, Context context)
		{
			if (jobSystemCallbacks == null)
			{
				Rebuild();
			}
			if (jobSystemCallbacks[(int)rule] != null && jobSystemCallbacks[(int)rule].Count > 0)
			{
				throw new Exception("A job system pass has been added for the " + rule.ToString() + " pass. " + rule.ToString() + " only supports main thread callbacks.");
			}
			if (context.tracker != null)
			{
				context.tracker.AllWritesDependency.Complete();
			}
			CallActions(mainThreadCallbacks[(int)rule], context);
		}

		public void AddJobSystemPass(GridGraphRule.Pass pass, Action<Context> action)
		{
			if (jobSystemCallbacks[(int)pass] == null)
			{
				jobSystemCallbacks[(int)pass] = new List<Action<Context>>();
			}
			jobSystemCallbacks[(int)pass].Add(action);
		}

		public void AddMainThreadPass(GridGraphRule.Pass pass, Action<Context> action)
		{
			if (mainThreadCallbacks[(int)pass] == null)
			{
				mainThreadCallbacks[(int)pass] = new List<Action<Context>>();
			}
			mainThreadCallbacks[(int)pass].Add(action);
		}

		[Obsolete("Use AddJobSystemPass or AddMainThreadPass instead")]
		public void Add(GridGraphRule.Pass pass, Action<Context> action)
		{
			AddJobSystemPass(pass, action);
		}
	}
}
