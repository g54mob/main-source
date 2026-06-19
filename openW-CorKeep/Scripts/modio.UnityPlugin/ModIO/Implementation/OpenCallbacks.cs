using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal class OpenCallbacks
	{
		private Dictionary<TaskCompletionSource<bool>, Task> openCallbacks = new Dictionary<TaskCompletionSource<bool>, Task>();

		public TaskCompletionSource<bool> New()
		{
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			openCallbacks.Add(taskCompletionSource, null);
			return taskCompletionSource;
		}

		public TaskCompletionSource<bool> New(Task task)
		{
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			openCallbacks.Add(taskCompletionSource, task);
			return taskCompletionSource;
		}

		public async Task<T> Run<T>(TaskCompletionSource<bool> tcs, Task<T> task)
		{
			openCallbacks[tcs] = task;
			T result = await task;
			openCallbacks[tcs] = null;
			return result;
		}

		public void Remove(TaskCompletionSource<bool> tcs)
		{
			openCallbacks.Remove(tcs);
		}

		public void Complete(TaskCompletionSource<bool> tcs)
		{
			tcs.SetResult(result: true);
			openCallbacks.Remove(tcs);
		}

		public void Clear(TaskCompletionSource<bool> tcs)
		{
			openCallbacks[tcs] = null;
		}

		public void CancelAll()
		{
			foreach (KeyValuePair<TaskCompletionSource<bool>, Task> openCallback in openCallbacks)
			{
				openCallback.Key.TrySetCanceled();
			}
			openCallbacks.Clear();
		}

		public async Task ShutDown()
		{
			Dictionary<TaskCompletionSource<bool>, Task> dictionary = new Dictionary<TaskCompletionSource<bool>, Task>(openCallbacks);
			using (Dictionary<TaskCompletionSource<bool>, Task>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Value == null || enumerator.Current.Value.IsFaulted || enumerator.Current.Value.IsCanceled)
					{
						Logger.Log(LogLevel.Warning, "Invalid TCS stored in openCallbacks. The corresponding callback will never be invoked. Skipping this task (The shutdown method may complete before all jobs have been cancelled).");
						if (openCallbacks.ContainsKey(enumerator.Current.Key))
						{
							openCallbacks.Remove(enumerator.Current.Key);
						}
					}
					else
					{
						await enumerator.Current.Key.Task;
					}
				}
			}
			Logger.Log(LogLevel.Verbose, "Shutdown finished waiting for callbacks");
		}
	}
}
