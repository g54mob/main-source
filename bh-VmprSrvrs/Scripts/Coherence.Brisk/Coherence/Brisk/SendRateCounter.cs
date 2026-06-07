using System;
using System.Diagnostics;
using Coherence.Log;

namespace Coherence.Brisk
{
	public class SendRateCounter
	{
		private static readonly TimeSpan ValidationPeriod;

		private const double SendRateErrorMargin = 1.05;

		private readonly Logger logger;

		private int sendCount;

		private TimeSpan lastValidationTime;

		public SendRateCounter(Logger logger)
		{
		}

		[Conditional("COHERENCE_LOG_DEBUG")]
		public void Reset()
		{
		}

		[Conditional("COHERENCE_LOG_DEBUG")]
		public void Bump(double expectedSendRate, TimeSpan now)
		{
		}
	}
}
