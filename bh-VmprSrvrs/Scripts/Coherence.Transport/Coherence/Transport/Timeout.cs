using System;
using Coherence.Common;
using Coherence.Connection;

namespace Coherence.Transport
{
	public class Timeout
	{
		private readonly IDateTimeProvider dateTimeProvider;

		private readonly Action<ConnectionTimeoutException> onTimeout;

		private TimeSpan? timeout;

		private DateTime lastResetTime;

		public Timeout(IDateTimeProvider dateTimeProvider, Action<ConnectionTimeoutException> onTimeout)
		{
		}

		public void SetTimeout(in TimeSpan newTimeout)
		{
		}

		public void Check(bool reset)
		{
		}
	}
}
