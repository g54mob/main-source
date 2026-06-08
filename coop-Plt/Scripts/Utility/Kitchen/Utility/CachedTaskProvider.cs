using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Utility
{
	public class CachedTaskProvider<TSpec, TResult>
	{
		private Dictionary<TSpec, CachedTask<TResult>> Tasks = new Dictionary<TSpec, CachedTask<TResult>>();

		private Func<TSpec, bool, CancellationToken, Task<TResult>> Function;

		private List<ITaskDependency> Dependencies = new List<ITaskDependency>();

		public CachedTaskProvider(Func<TSpec, bool, CancellationToken, Task<TResult>> func)
		{
			Function = func;
		}

		public CachedTaskProvider<TSpec, TResult> DependsOn(ITaskDependency dep)
		{
			Dependencies.Add(dep);
			return this;
		}

		public CachedTask<TResult> Get(TSpec spec, bool begin = false, bool force_restart = false)
		{
			if (!Tasks.TryGetValue(spec, out var value))
			{
				value = new CachedTask<TResult>((bool force, CancellationToken token) => Function(spec, force, token));
				foreach (ITaskDependency dependency in Dependencies)
				{
					value.DependsOn(dependency);
				}
				Tasks[spec] = value;
			}
			if (begin)
			{
				value.Run(force_restart);
			}
			return value;
		}

		public void Clear()
		{
			foreach (KeyValuePair<TSpec, CachedTask<TResult>> task in Tasks)
			{
				task.Value.Cancel();
			}
			Tasks.Clear();
		}
	}
}
