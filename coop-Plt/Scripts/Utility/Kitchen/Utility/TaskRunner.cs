using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Utility
{
	public class TaskRunner<TGroupKey, TTaskKey> where TTaskKey : IEquatable<TTaskKey>
	{
		private struct ActiveTask
		{
			public TTaskKey Key;

			public Task Task;

			public CancellationTokenSource Cancel;
		}

		private ConcurrentDictionary<TGroupKey, ActiveTask> ActiveTasks = new ConcurrentDictionary<TGroupKey, ActiveTask>();

		public void Cancel(TGroupKey key, TTaskKey task_key)
		{
			Run(key, task_key, null, force_cancel: true);
		}

		public Task Run(TGroupKey key, TTaskKey task_key, Func<CancellationToken, Task> func, bool force_cancel = false)
		{
			if (ActiveTasks.TryGetValue(key, out var value))
			{
				if (!force_cancel)
				{
					ref TTaskKey reference = ref task_key;
					TTaskKey key2 = value.Key;
					if (reference.Equals(key2))
					{
						return value.Task;
					}
				}
				value.Cancel.Cancel();
				ActiveTasks.TryRemove(key, out var _);
			}
			if (func == null)
			{
				return Task.CompletedTask;
			}
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			Task task = func(cancellationTokenSource.Token);
			task.ContinueWith(delegate(Task t)
			{
				if (!t.IsCanceled)
				{
					Cancel(key, task_key);
				}
			}, cancellationTokenSource.Token);
			ActiveTasks.GetOrAdd(key, new ActiveTask
			{
				Key = task_key,
				Task = task,
				Cancel = cancellationTokenSource
			});
			return task;
		}
	}
}
