using System;
using System.Diagnostics;

namespace Sentry.Internal
{
	internal struct SentryStopwatch
	{
		private static readonly double StopwatchTicksPerTimeSpanTick = (double)Stopwatch.Frequency / 10000000.0;

		private static readonly double StopwatchTicksPerNs = (double)Stopwatch.Frequency / 1000000000.0;

		private long _startTimestamp;

		private DateTimeOffset _startDateTimeOffset;

		public DateTimeOffset StartDateTimeOffset => _startDateTimeOffset;

		public DateTimeOffset CurrentDateTimeOffset => _startDateTimeOffset + Elapsed;

		public TimeSpan Elapsed => TimeSpan.FromTicks((long)((double)Diff() / StopwatchTicksPerTimeSpanTick));

		public ulong ElapsedNanoseconds => (ulong)((double)Diff() / StopwatchTicksPerNs);

		public static SentryStopwatch StartNew()
		{
			return new SentryStopwatch
			{
				_startTimestamp = Stopwatch.GetTimestamp(),
				_startDateTimeOffset = DateTimeOffset.UtcNow
			};
		}

		private long Diff()
		{
			return Stopwatch.GetTimestamp() - _startTimestamp;
		}
	}
}
