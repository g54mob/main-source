using System;
using System.Collections.Generic;
using System.Threading;

namespace TH20
{
	public static class ThreadingUtils
	{
		private static bool _initialised;

		private static Thread _mainThread;

		private static readonly List<Action> ActionsToRunOnMainThread = new List<Action>();

		public static void Initialise()
		{
			if (_initialised)
			{
				return;
			}
			_initialised = true;
			_mainThread = Thread.CurrentThread;
			lock (ActionsToRunOnMainThread)
			{
				ActionsToRunOnMainThread.Clear();
			}
		}

		public static void Destroy()
		{
			_initialised = false;
		}

		public static bool IsOnMainThread()
		{
			if (_mainThread != null)
			{
				return _mainThread.Equals(Thread.CurrentThread);
			}
			return false;
		}

		public static void EnqueueActionForMainThread(Action action)
		{
			if (_initialised)
			{
				lock (ActionsToRunOnMainThread)
				{
					ActionsToRunOnMainThread.Add(action);
				}
			}
		}

		public static void EnqueueActionForMainThreadOrRunRightNow(Action action)
		{
			if (_initialised)
			{
				if (IsOnMainThread())
				{
					action();
				}
				else
				{
					EnqueueActionForMainThread(action);
				}
			}
		}

		public static void Update()
		{
			lock (ActionsToRunOnMainThread)
			{
				for (int i = 0; i < ActionsToRunOnMainThread.Count; i++)
				{
					ActionsToRunOnMainThread[i]();
				}
				ActionsToRunOnMainThread.Clear();
			}
		}
	}
}
