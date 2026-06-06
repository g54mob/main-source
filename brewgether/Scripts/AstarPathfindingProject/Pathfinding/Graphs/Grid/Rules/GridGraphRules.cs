using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Unity.Jobs;

namespace Pathfinding.Graphs.Grid.Rules
{
	[JsonOptIn]
	public class GridGraphRules
	{
		public class Context
		{
			public GridGraph graph;

			public GridGraphScanData data;

			public JobDependencyTracker tracker => null;
		}

		[CompilerGenerated]
		private sealed class _003CExecuteRule_003Ed__13 : IEnumerator<JobHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private JobHandle _003C_003E2__current;

			public GridGraphRules _003C_003E4__this;

			public GridGraphRule.Pass rule;

			public Context context;

			JobHandle IEnumerator<JobHandle>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(JobHandle);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CExecuteRule_003Ed__13(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private List<Action<Context>>[] jobSystemCallbacks;

		private List<Action<Context>>[] mainThreadCallbacks;

		[JsonMember]
		private List<GridGraphRule> rules;

		private long lastHash;

		public void AddRule(GridGraphRule rule)
		{
		}

		public void RemoveRule(GridGraphRule rule)
		{
		}

		public IReadOnlyList<GridGraphRule> GetRules()
		{
			return null;
		}

		private long Hash()
		{
			return 0L;
		}

		public void RebuildIfNecessary()
		{
		}

		public void Rebuild()
		{
		}

		public void DisposeUnmanagedData()
		{
		}

		private static void CallActions(List<Action<Context>> actions, Context context)
		{
		}

		[IteratorStateMachine(typeof(_003CExecuteRule_003Ed__13))]
		public IEnumerator<JobHandle> ExecuteRule(GridGraphRule.Pass rule, Context context)
		{
			return null;
		}

		public void ExecuteRuleMainThread(GridGraphRule.Pass rule, Context context)
		{
		}

		public void AddJobSystemPass(GridGraphRule.Pass pass, Action<Context> action)
		{
		}

		public void AddMainThreadPass(GridGraphRule.Pass pass, Action<Context> action)
		{
		}

		[Obsolete("Use AddJobSystemPass or AddMainThreadPass instead")]
		public void Add(GridGraphRule.Pass pass, Action<Context> action)
		{
		}
	}
}
