using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry.Metrics;

namespace Amazon.Runtime.Internal
{
	public class RetryHandler : PipelineHandler
	{
		private ILogger _logger;

		public override ILogger Logger
		{
			get
			{
				return _logger;
			}
			set
			{
				_logger = value;
				RetryPolicy.Logger = value;
			}
		}

		public RetryPolicy RetryPolicy { get; private set; }

		public RetryHandler(RetryPolicy retryPolicy)
		{
			RetryPolicy = retryPolicy;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			switch (requestContext.ClientConfig.RetryMode)
			{
			case RequestRetryMode.Standard:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RETRY_MODE_STANDARD);
				break;
			case RequestRetryMode.Adaptive:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RETRY_MODE_ADAPTIVE);
				break;
			}
			bool flag = false;
			RetryPolicy.ObtainSendToken(executionContext, null);
			do
			{
				try
				{
					SetRetryHeaders(requestContext);
					base.InvokeSync(executionContext);
					RetryPolicy.NotifySuccess(executionContext);
					break;
				}
				catch (Exception exception)
				{
					flag = RetryPolicy.Retry(executionContext, exception);
					if (!flag)
					{
						LogForError(requestContext, exception);
						throw;
					}
					requestContext.Retries++;
					requestContext.Metrics.SetCounter(Metric.AttemptCount, requestContext.Retries);
					MetricsUtilities.AddMonotonicCounterValue(requestContext, "client.call.attempts", "{attempt}", 1L);
					LogForRetry(requestContext, exception);
					RetryPolicy.ObtainSendToken(executionContext, exception);
				}
				PrepareForRetry(requestContext);
				using (requestContext.Metrics.StartEvent(Metric.RetryPauseTime))
				{
					RetryPolicy.WaitBeforeRetry(executionContext);
				}
			}
			while (flag);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			switch (requestContext.ClientConfig.RetryMode)
			{
			case RequestRetryMode.Standard:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RETRY_MODE_STANDARD);
				break;
			case RequestRetryMode.Adaptive:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.RETRY_MODE_ADAPTIVE);
				break;
			}
			bool shouldRetry = false;
			await RetryPolicy.ObtainSendTokenAsync(executionContext, null).ConfigureAwait(continueOnCapturedContext: false);
			do
			{
				ExceptionDispatchInfo capturedException;
				try
				{
					SetRetryHeaders(requestContext);
					T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
					RetryPolicy.NotifySuccess(executionContext);
					return result;
				}
				catch (Exception source)
				{
					capturedException = ExceptionDispatchInfo.Capture(source);
				}
				if (capturedException != null)
				{
					shouldRetry = await RetryPolicy.RetryAsync(executionContext, capturedException.SourceException).ConfigureAwait(continueOnCapturedContext: false);
					if (!shouldRetry)
					{
						LogForError(requestContext, capturedException.SourceException);
						capturedException.Throw();
					}
					else
					{
						requestContext.Retries++;
						requestContext.Metrics.SetCounter(Metric.AttemptCount, requestContext.Retries);
						MetricsUtilities.AddMonotonicCounterValue(requestContext, "client.call.attempts", "{attempt}", 1L);
						LogForRetry(requestContext, capturedException.SourceException);
					}
					await RetryPolicy.ObtainSendTokenAsync(executionContext, capturedException.SourceException).ConfigureAwait(continueOnCapturedContext: false);
				}
				PrepareForRetry(requestContext);
				using (requestContext.Metrics.StartEvent(Metric.RetryPauseTime))
				{
					await RetryPolicy.WaitBeforeRetryAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			while (shouldRetry);
			throw new AmazonClientException("Neither a response was returned nor an exception was thrown in the Runtime RetryHandler.");
		}

		internal static void PrepareForRetry(IRequestContext requestContext)
		{
			if (requestContext.Request.ContentStream != null && requestContext.Request.OriginalStreamPosition >= 0)
			{
				Stream stream2;
				Stream stream = (stream2 = requestContext.Request.ContentStream);
				if (stream is CompressionWrapperStream compressionWrapperStream)
				{
					compressionWrapperStream.Reset();
					stream2 = compressionWrapperStream.GetSeekableBaseStream();
				}
				if (stream is HashStream hashStream)
				{
					hashStream.Reset();
					stream2 = hashStream.GetSeekableBaseStream();
				}
				stream2.Position = requestContext.Request.OriginalStreamPosition;
			}
		}

		private void LogForRetry(IRequestContext requestContext, Exception exception)
		{
			Logger.InfoFormat("{0} making request {1} to {2}. Attempting retry {3} of {4}.", exception.GetType().Name, requestContext.RequestName, requestContext.Request.Endpoint.ToString(), requestContext.Retries, RetryPolicy.MaxRetries);
		}

		private void LogForError(IRequestContext requestContext, Exception exception)
		{
			Logger.Error(exception, "{0} making request {1} to {2}. Attempt {3}.", exception.GetType().Name, requestContext.RequestName, requestContext.Request.Endpoint.ToString(), requestContext.Retries + 1);
		}

		private void SetRetryHeaders(IRequestContext requestContext)
		{
			IRequest request = requestContext.Request;
			if (!request.Headers.ContainsKey("amz-sdk-invocation-id"))
			{
				request.Headers.Add("amz-sdk-invocation-id", requestContext.InvocationId.ToString());
			}
			string value = $"attempt={requestContext.Retries + 1}; max={RetryPolicy.MaxRetries + 1}";
			if (request.Headers.ContainsKey("amz-sdk-request"))
			{
				request.Headers["amz-sdk-request"] = value;
			}
			else
			{
				request.Headers.Add("amz-sdk-request", value);
			}
		}
	}
}
