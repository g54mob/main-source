using System;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public abstract class PlayerLoopTimer : IDisposable, IPlayerLoopItem
	{
		private readonly CancellationToken cancellationToken;

		private readonly Action<object> timerCallback;

		private readonly object state;

		private readonly PlayerLoopTiming playerLoopTiming;

		private readonly bool periodic;

		private bool isRunning;

		private bool tryStop;

		private bool isDisposed;

		protected PlayerLoopTimer(bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
		{
		}

		public static PlayerLoopTimer Create(TimeSpan interval, bool periodic, DelayType delayType, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
		{
			return null;
		}

		public static PlayerLoopTimer StartNew(TimeSpan interval, bool periodic, DelayType delayType, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
		{
			return null;
		}

		public void Restart()
		{
		}

		public void Restart(TimeSpan interval)
		{
		}

		public void Stop()
		{
		}

		protected abstract void ResetCore(TimeSpan? newInterval);

		public void Dispose()
		{
		}

		bool IPlayerLoopItem.MoveNext()
		{
			return false;
		}

		protected abstract bool MoveNextCore();
	}
}
