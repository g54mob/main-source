using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class DefaultRetryPolicy : RetryPolicy
	{
		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		private static readonly CapacityManager _capacityManagerInstance = new CapacityManager(100, 5, 1);

		private static readonly HashSet<string> _netStandardRetryErrorMessages = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "The server returned an invalid or unrecognized response", "The connection with the server was terminated abnormally", "An error occurred while sending the request.", "Failed sending data to the peer" };

		public int MaxBackoffInMilliseconds { get; set; } = 30000;

		public DefaultRetryPolicy(int maxRetries)
		{
			base.MaxRetries = maxRetries;
		}

		public DefaultRetryPolicy(IClientConfig config)
		{
			base.MaxRetries = config.MaxErrorRetry;
			if (config.ThrottleRetries)
			{
				base.RetryCapacity = _capacityManagerInstance.GetRetryCapacity(RetryPolicy.GetRetryCapacityKey(config));
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
				return _capacityManagerInstance.TryAcquireCapacity(base.RetryCapacity, executionContext.RequestContext.LastCapacityType);
			}
			return true;
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			if (executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				_capacityManagerInstance.ReleaseCapacity(executionContext.RequestContext.LastCapacityType, base.RetryCapacity);
			}
		}

		private bool RetryForExceptionSync(Exception exception)
		{
			return RetryForExceptionSync(exception, null);
		}

		private bool RetryForExceptionSync(Exception exception, IExecutionContext executionContext)
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

		private static int CalculateRetryDelay(int retries, int maxBackoffInMilliseconds)
		{
			int num = ((retries >= 12) ? int.MaxValue : Convert.ToInt32(Math.Pow(4.0, retries) * 100.0));
			if (retries > 0 && (num > maxBackoffInMilliseconds || num <= 0))
			{
				num = maxBackoffInMilliseconds;
			}
			return num;
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
