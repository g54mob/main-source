using System;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public class AdaptiveRetryPolicy : StandardRetryPolicy
	{
		protected TokenBucket TokenBucket { get; set; } = new TokenBucket();

		public AdaptiveRetryPolicy(int maxRetries)
			: base(maxRetries)
		{
		}

		public AdaptiveRetryPolicy(IClientConfig config)
			: base(config)
		{
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			TokenBucket.UpdateClientSendingRate(isThrottlingError);
			return base.OnRetry(executionContext, bypassAcquireCapacity, isThrottlingError);
		}

		public override void ObtainSendToken(IExecutionContext executionContext, Exception exception)
		{
			if (!TokenBucket.TryAcquireToken(1.0, executionContext.RequestContext.ClientConfig.FastFailRequests))
			{
				string text = ((exception == null) ? "The initial request cannot be attempted because capacity could not be obtained" : "While attempting to retry a request error capacity could not be obtained");
				if (executionContext.RequestContext.ClientConfig.FastFailRequests)
				{
					throw new AmazonClientException(text + ". The client is configured to fail fast and there is insufficient capacity to attempt the request.", exception);
				}
				throw new AmazonClientException(text + ". There is insufficient capacity to attempt the request after attempting to obtain capacity multiple times.", exception);
			}
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			TokenBucket.UpdateClientSendingRate(isThrottlingError: false);
			base.NotifySuccess(executionContext);
		}

		public override Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(RetryForExceptionSync(exception, executionContext));
		}

		public override Task WaitBeforeRetryAsync(IExecutionContext executionContext)
		{
			return Task.Delay(StandardRetryPolicy.CalculateRetryDelay(executionContext.RequestContext.Retries, base.MaxBackoffInMilliseconds), executionContext.RequestContext.CancellationToken);
		}

		public override async Task ObtainSendTokenAsync(IExecutionContext executionContext, Exception exception)
		{
			if (!(await TokenBucket.TryAcquireTokenAsync(1.0, executionContext.RequestContext.ClientConfig.FastFailRequests, executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
			{
				string text = ((exception == null) ? "The initial request cannot be attempted because capacity could not be obtained" : "While attempting to retry a request error capacity could not be obtained");
				if (executionContext.RequestContext.ClientConfig.FastFailRequests)
				{
					throw new AmazonClientException(text + ". The client is configured to fail fast and there is insufficient capacity to attempt the request.", exception);
				}
				throw new AmazonClientException(text + ". There is insufficient capacity to attempt the request after attempting to obtain capacity multiple times.", exception);
			}
		}
	}
}
