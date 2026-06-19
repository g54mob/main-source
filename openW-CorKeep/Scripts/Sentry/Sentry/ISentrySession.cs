using System;

namespace Sentry
{
	public interface ISentrySession
	{
		SentryId Id { get; }

		string? DistinctId { get; }

		DateTimeOffset StartTimestamp { get; }

		string Release { get; }

		string? Environment { get; }

		string? IpAddress { get; }

		string? UserAgent { get; }

		int ErrorCount { get; }
	}
}
