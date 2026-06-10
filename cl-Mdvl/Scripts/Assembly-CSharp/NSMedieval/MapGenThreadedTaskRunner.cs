using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using UnityEngine;

namespace NSMedieval
{
	public class MapGenThreadedTaskRunner : MonoBehaviour
	{
		private readonly ConcurrentQueue<Action> taskDoneCallbacks = new ConcurrentQueue<Action>();

		protected virtual void OnDestroy()
		{
			taskDoneCallbacks?.Clear();
		}

		protected void ExecuteThreaded(Action threadedTask, Action callback)
		{
			Task.Run(delegate
			{
				threadedTask?.Invoke();
				if (callback != null)
				{
					taskDoneCallbacks.Enqueue(callback);
				}
			});
		}

		private void Update()
		{
			if (taskDoneCallbacks.IsEmpty)
			{
				return;
			}
			while (taskDoneCallbacks.Count > 0)
			{
				if (taskDoneCallbacks.TryDequeue(out var result))
				{
					result?.Invoke();
				}
			}
		}
	}
}
