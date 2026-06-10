using System;
using System.Collections;
using System.Threading;

namespace ParadoxNotion.Services
{
	public static class Threader
	{
		public static bool applicationIsPlaying { get; private set; }

		public static bool isMainThread => Thread.CurrentThread.ManagedThreadId == 1;

		static Threader()
		{
			applicationIsPlaying = true;
		}

		public static Thread StartAction(Thread thread, Action function, Action callback = null)
		{
			if (thread != null && thread.IsAlive)
			{
				thread.Abort();
			}
			thread = new Thread((ThreadStart)delegate
			{
				function();
			});
			Begin(thread, callback);
			return thread;
		}

		public static Thread StartFunction<TResult>(Thread thread, Func<TResult> function, Action<TResult> callback = null)
		{
			if (thread != null && thread.IsAlive)
			{
				thread.Abort();
			}
			TResult result = default(TResult);
			thread = new Thread((ThreadStart)delegate
			{
				result = function();
			});
			Begin(thread, delegate
			{
				callback(result);
			});
			return thread;
		}

		private static void Begin(Thread thread, Action callback)
		{
			thread.Start();
			MonoManager.current.StartCoroutine(ThreadMonitor(thread, callback));
		}

		private static IEnumerator ThreadMonitor(Thread thread, Action callback)
		{
			while (thread.IsAlive)
			{
				yield return null;
			}
			yield return null;
			if ((thread.ThreadState & ThreadState.AbortRequested) != ThreadState.AbortRequested)
			{
				thread.Join();
				callback?.Invoke();
			}
		}
	}
}
