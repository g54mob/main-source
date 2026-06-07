using System;
using System.Collections;
using System.Threading;

namespace ParadoxNotion.Services
{
	public static class Threader
	{
		public static bool applicationIsPlaying { get; private set; }

		public static bool isMainThread => false;

		static Threader()
		{
		}

		public static Thread StartAction(Thread thread, Action function, Action callback = null)
		{
			return null;
		}

		public static Thread StartAction<T1>(Thread thread, Action<T1> function, T1 parameter1, Action callback = null)
		{
			return null;
		}

		public static Thread StartAction<T1, T2>(Thread thread, Action<T1, T2> function, T1 parameter1, T2 parameter2, Action callback = null)
		{
			return null;
		}

		public static Thread StartAction<T1, T2, T3>(Thread thread, Action<T1, T2, T3> function, T1 parameter1, T2 parameter2, T3 parameter3, Action callback = null)
		{
			return null;
		}

		public static Thread StartFunction<TResult>(Thread thread, Func<TResult> function, Action<TResult> callback = null)
		{
			return null;
		}

		public static Thread StartFunction<TResult, T1>(Thread thread, Func<T1, TResult> function, T1 parameter1, Action<TResult> callback = null)
		{
			return null;
		}

		public static Thread StartFunction<TResult, T1, T2>(Thread thread, Func<T1, T2, TResult> function, T1 parameter1, T2 parameter2, Action<TResult> callback = null)
		{
			return null;
		}

		public static Thread StartFunction<TResult, T1, T2, T3>(Thread thread, Func<T1, T2, T3, TResult> function, T1 parameter1, T2 parameter2, T3 parameter3, Action<TResult> callback = null)
		{
			return null;
		}

		private static void Begin(Thread thread, Action callback)
		{
		}

		private static IEnumerator ThreadMonitor(Thread thread, Action callback)
		{
			return null;
		}
	}
}
