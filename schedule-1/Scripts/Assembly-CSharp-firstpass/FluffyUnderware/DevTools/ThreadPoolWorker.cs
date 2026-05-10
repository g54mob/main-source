using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using JetBrains.Annotations;

namespace FluffyUnderware.DevTools
{
	public class ThreadPoolWorker<T> : IDisposable
	{
		private readonly SimplePool<QueuedCallback> queuedCallbackPool;

		private readonly SimplePool<LoopState<T>> loopStatePool;

		private int _remainingWorkItems;

		private ManualResetEvent _done;

		private readonly WaitCallback handleWorkItemCallBack;

		private readonly WaitCallback handleLoopCallBack;

		private static int ThreadsToUseCount => 0;

		[Obsolete("Use ParallelFor(Action<T,int,int> action, IEnumerable<T> list) instead")]
		[UsedImplicitly]
		public void ParralelFor(Action<T> action, List<T> list)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ParallelFor(Action<T, int, int> action, IEnumerable<T> list)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ParallelFor(Action<T, int, int> action, IEnumerable<T> list, int elementsCount)
		{
		}

		public void Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[System.Diagnostics.Conditional("THREADING_SUPPORTED")]
		private void DoParallelFor(Action<T, int, int> action, IEnumerable<T> list, int elementsCount)
		{
		}

		private bool WaitAll(int millisecondsTimeout, bool exitContext)
		{
			return false;
		}

		private void ThrowIfDisposed()
		{
		}

		private void DoneWorkItem()
		{
		}
	}
	[Obsolete("Use ThreadPoolWorker<T> instead")]
	public class ThreadPoolWorker : IDisposable
	{
		private int _remainingWorkItems;

		private ManualResetEvent _done;

		public void QueueWorkItem(WaitCallback callback)
		{
		}

		public void QueueWorkItem(Action act)
		{
		}

		public void ParralelFor<T>(Action<T> action, List<T> list)
		{
		}

		private void QueueWorkItem(QueuedCallback callback)
		{
		}

		public void QueueWorkItem(WaitCallback callback, object state)
		{
		}

		public void QueueWorkItem(Action act, object state)
		{
		}

		public bool WaitAll()
		{
			return false;
		}

		public bool WaitAll(TimeSpan timeout, bool exitContext)
		{
			return false;
		}

		public bool WaitAll(int millisecondsTimeout, bool exitContext)
		{
			return false;
		}

		private void HandleWorkItem(object state)
		{
		}

		private void DoneWorkItem()
		{
		}

		private void ThrowIfDisposed()
		{
		}

		public void Dispose()
		{
		}
	}
}
