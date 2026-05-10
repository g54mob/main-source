using System;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public sealed class TimeoutController : IDisposable
	{
		private static readonly Action<object> CancelCancellationTokenSourceStateDelegate;

		private CancellationTokenSource timeoutSource;

		private CancellationTokenSource linkedSource;

		private PlayerLoopTimer timer;

		private bool isDisposed;

		private readonly DelayType delayType;

		private readonly PlayerLoopTiming delayTiming;

		private readonly CancellationTokenSource originalLinkCancellationTokenSource;

		private static void CancelCancellationTokenSourceState(object state)
		{
		}

		public TimeoutController(DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
		{
		}

		public TimeoutController(CancellationTokenSource linkCancellationTokenSource, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
		{
		}

		public CancellationToken Timeout(int millisecondsTimeout)
		{
			return default(CancellationToken);
		}

		public CancellationToken Timeout(TimeSpan timeout)
		{
			return default(CancellationToken);
		}

		public bool IsTimeout()
		{
			return false;
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
