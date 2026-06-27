using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Common
{
	internal class Clock : IClock
	{
		public void Delay(TimeSpan timeToDelay)
		{
			Task.Delay(timeToDelay).GetAwaiter().GetResult();
		}

		public Task DelayAsync(TimeSpan delay, CancellationToken cancellationToken)
		{
			return Task.Delay(delay, cancellationToken);
		}

		public ITimer StartTimer()
		{
			return new StopwatchTimer();
		}
	}
}
