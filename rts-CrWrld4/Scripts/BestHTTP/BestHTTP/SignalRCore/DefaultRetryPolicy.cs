using System;

namespace BestHTTP.SignalRCore
{
	public sealed class DefaultRetryPolicy : IRetryPolicy
	{
		private static TimeSpan?[] DefaultBackoffTimes;

		private TimeSpan?[] backoffTimes;

		public DefaultRetryPolicy()
		{
		}

		public DefaultRetryPolicy(TimeSpan?[] customBackoffTimes)
		{
		}

		public TimeSpan? GetNextRetryDelay(RetryContext context)
		{
			return null;
		}
	}
}
