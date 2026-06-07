using System;

namespace BestHTTP.SignalRCore
{
	public struct RetryContext
	{
		public uint PreviousRetryCount;

		public TimeSpan ElapsedTime;

		public string RetryReason;
	}
}
