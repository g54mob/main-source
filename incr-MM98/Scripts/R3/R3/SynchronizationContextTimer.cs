using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class SynchronizationContextTimer : ITimer, IDisposable, IAsyncDisposable
	{
		private static readonly TimerCallback wrappedCallback = InvokeCallback;

		private static readonly SendOrPostCallback postCallback = PostCallback;

		private readonly ITimer timer;

		private readonly SynchronizationContext? synchronizationContext;

		private readonly TimerCallback callback;

		private readonly object? state;

		public SynchronizationContextTimer(TimeProvider timeProvider, SynchronizationContext? synchronizationContext, TimerCallback callback, object? state, TimeSpan dueTime, TimeSpan period)
		{
			this.synchronizationContext = synchronizationContext;
			this.callback = callback;
			this.state = state;
			timer = timeProvider.CreateTimer(wrappedCallback, this, dueTime, period);
		}

		private static void InvokeCallback(object? state)
		{
			SynchronizationContextTimer synchronizationContextTimer = (SynchronizationContextTimer)state;
			if (synchronizationContextTimer.synchronizationContext == null)
			{
				synchronizationContextTimer.callback(synchronizationContextTimer.state);
			}
			else
			{
				synchronizationContextTimer.synchronizationContext.Post(postCallback, synchronizationContextTimer);
			}
		}

		private static void PostCallback(object? state)
		{
			SynchronizationContextTimer synchronizationContextTimer = (SynchronizationContextTimer)state;
			synchronizationContextTimer.callback(synchronizationContextTimer.state);
		}

		public bool Change(TimeSpan dueTime, TimeSpan period)
		{
			return timer.Change(dueTime, period);
		}

		public void Dispose()
		{
			timer.Dispose();
		}

		public ValueTask DisposeAsync()
		{
			timer.Dispose();
			return default(ValueTask);
		}
	}
}
