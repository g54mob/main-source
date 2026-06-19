using System;
using System.Threading;

namespace Sentry
{
	public class SentrySession : ISentrySession
	{
		private int _errorCount;

		private int _sequenceNumber = -1;

		public SentryId Id { get; }

		public string? DistinctId { get; }

		public DateTimeOffset StartTimestamp { get; }

		public string Release { get; }

		public string? Environment { get; }

		public string? IpAddress { get; }

		public string? UserAgent { get; }

		public int ErrorCount => _errorCount;

		internal SentrySession(SentryId id, string? distinctId, DateTimeOffset startTimestamp, string release, string? environment, string? ipAddress, string? userAgent)
		{
			Id = id;
			DistinctId = distinctId;
			StartTimestamp = startTimestamp;
			Release = release;
			Environment = environment;
			IpAddress = ipAddress;
			UserAgent = userAgent;
		}

		public SentrySession(string? distinctId, string release, string? environment)
			: this(SentryId.Create(), distinctId, DateTimeOffset.Now, release, environment, null, null)
		{
		}

		public void ReportError()
		{
			Interlocked.Increment(ref _errorCount);
		}

		internal SessionUpdate CreateUpdate(bool isInitial, DateTimeOffset timestamp, SessionEndStatus? endStatus = null)
		{
			return new SessionUpdate(this, isInitial, timestamp, Interlocked.Increment(ref _sequenceNumber), endStatus);
		}
	}
}
