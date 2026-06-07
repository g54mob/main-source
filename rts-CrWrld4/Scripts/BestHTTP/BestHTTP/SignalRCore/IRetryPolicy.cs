using System;

namespace BestHTTP.SignalRCore
{
	public interface IRetryPolicy
	{
		TimeSpan? GetNextRetryDelay(RetryContext context);
	}
}
