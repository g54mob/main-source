using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Common
{
	public interface IClock
	{
		void Delay(TimeSpan timeToDelay);

		Task DelayAsync(TimeSpan delay, CancellationToken cancellationToken);

		ITimer StartTimer();
	}
}
