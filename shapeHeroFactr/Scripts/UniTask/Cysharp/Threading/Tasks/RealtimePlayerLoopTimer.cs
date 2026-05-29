using System;
using System.Threading;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks
{
	internal sealed class RealtimePlayerLoopTimer : PlayerLoopTimer
	{
		private ValueStopwatch stopwatch;

		private long intervalTicks;

		public RealtimePlayerLoopTimer(TimeSpan interval, bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
			: base(periodic: false, default(PlayerLoopTiming), default(CancellationToken), null, null)
		{
		}

		protected override bool MoveNextCore()
		{
			return false;
		}

		protected override void ResetCore(TimeSpan? interval)
		{
		}
	}
}
