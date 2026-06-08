using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class StandardRetryPolicy : RetryPolicy
	{
		private static Random _randomJitter = new Random();

		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		protected static CapacityManager CapacityManagerInstance { get; set; } = new CapacityManager(100, 5, 1, 10);

		public int MaxBackoffInMilliseconds { get; set; } = 20000;

		public StandardRetryPolicy(int maxRetries)
		{
			base.MaxRetries = maxRetries;
		}

		public StandardRetryPolicy(IClientConfig config)
		{
			base.MaxRetries = config.MaxErrorRetry;
			if (config.ThrottleRetries)
			{
				base.RetryCapacity = CapacityManagerInstance.GetRetryCapacity(RetryPolicy.GetRetryCapacityKey(config));
			}
		}

		public override bool CanRetry(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Request.IsRequestStreamRewindable();
		}

		public override bool RetryForException(IExecutionContext executionContext, Exception exception)
		{
			return RetryForExceptionSync(exception, executionContext);
		}

		public override bool OnRetry(IExecutionContext executionContext)
		{
			return OnRetry(executionContext, bypassAcquireCapacity: false, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity)
		{
			return OnRetry(executionContext, bypassAcquireCapacity, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			if (!bypassAcquireCapacity && executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				return CapacityManagerInstance.TryAcquireCapacity(base.RetryCapacity, executionContext.RequestContext.LastCapacityType);
			}
			return true;
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			if (executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				IRequestContext requestContext = executionContext.RequestContext;
				CapacityManagerInstance.ReleaseCapacity(requestContext.LastCapacityType, base.RetryCapacity);
			}
		}

		protected bool RetryForExceptionSync(Exception exception)
		{
			return RetryForExceptionSync(exception, null);
		}

		protected bool RetryForExceptionSync(Exception exception, IExecutionContext executionContext)
		{
			AmazonServiceException ex = exception as AmazonServiceException;
			if (IsThrottlingError(exception))
			{
				return true;
			}
			if (IsTransientError(executionContext, exception) || IsServiceTimeoutError(exception))
			{
				return true;
			}
			if (ex != null && ex.StatusCode == HttpStatusCode.MisdirectedRequest)
			{
				if (executionContext.RequestContext.EndpointDiscoveryRetries < 1)
				{
					executionContext.RequestContext.EndpointDiscoveryRetries++;
					return true;
				}
				return false;
			}
			return false;
		}

		public override bool RetryLimitReached(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Retries >= base.MaxRetries;
		}

		public override void WaitBeforeRetry(IExecutionContext executionContext)
		{
			WaitBeforeRetry(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds);
		}

		public static void WaitBeforeRetry(int retries, int maxBackoffInMilliseconds)
		{
			AWSSDKUtils.Sleep(CalculateRetryDelay(retries, maxBackoffInMilliseconds));
		}

		protected static int CalculateRetryDelay(int retries, int maxBackoffInMilliseconds)
		{
			double num;
			lock (_randomJitter)
			{
				num = _randomJitter.NextDouble();
			}
			return Convert.ToInt32(Math.Min(num * Math.Pow(2.0, retries - 1) * 1000.0, maxBackoffInMilliseconds));
		}

		public override Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(RetryForExceptionSync(exception, executionContext));
		}

		public override Task WaitBeforeRetryAsync(IExecutionContext executionContext)
		{
			return Task.Delay(CalculateRetryDelay(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds), executionContext.RequestContext.CancellationToken);
		}
	}
}
