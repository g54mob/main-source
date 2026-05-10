using System;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	internal sealed class DeltaTimePlayerLoopTimer : PlayerLoopTimer
	{
		private int initialFrame;

		private float elapsed;

		private float interval;

		public DeltaTimePlayerLoopTimer(TimeSpan interval, bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
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
