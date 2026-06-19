using System;

namespace Sentry.Infrastructure
{
	public interface ISystemClock
	{
		DateTimeOffset GetUtcNow();
	}
}
