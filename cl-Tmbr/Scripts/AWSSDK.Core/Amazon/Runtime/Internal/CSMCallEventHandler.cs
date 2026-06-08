using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public class CSMCallEventHandler : PipelineHandler
	{
		private Stopwatch stopWatch;

		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				PreInvoke(executionContext);
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				CaptureCSMCallEventExceptionData(executionContext.RequestContext, exception);
				throw;
			}
			finally
			{
				CSMCallEventMetricsCapture(executionContext);
				CSMUtilities.SerializetoJsonAndPostOverUDP(executionContext.RequestContext.CSMCallEvent);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				PreInvoke(executionContext);
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				CaptureCSMCallEventExceptionData(executionContext.RequestContext, exception);
				throw;
			}
			finally
			{
				CSMCallEventMetricsCapture(executionContext);
				CSMUtilities.SerializetoJsonAndPostOverUDPAsync(executionContext.RequestContext.CSMCallEvent);
			}
		}

		private void CSMCallEventMetricsCapture(IExecutionContext executionContext)
		{
			stopWatch.Stop();
			executionContext.RequestContext.CSMCallEvent.AttemptCount = executionContext.RequestContext.Retries + 1;
			executionContext.RequestContext.CSMCallEvent.Service = executionContext.RequestContext.ServiceMetaData.ServiceId;
			executionContext.RequestContext.CSMCallEvent.Api = executionContext.RequestContext.CSMCallAttempt.Api;
			executionContext.RequestContext.CSMCallEvent.Region = executionContext.RequestContext.CSMCallAttempt.Region;
			executionContext.RequestContext.CSMCallEvent.Latency = stopWatch.ElapsedMilliseconds;
			executionContext.RequestContext.CSMCallEvent.FinalHttpStatusCode = executionContext.RequestContext.CSMCallAttempt.HttpStatusCode;
			bool flag = (executionContext.RequestContext.ClientConfig as ClientConfig)?.UseAlternateUserAgentHeader ?? false;
			executionContext.RequestContext.CSMCallEvent.UserAgent = executionContext.RequestContext.Request.GetHeaderValue(flag ? "x-amz-user-agent" : "User-Agent");
		}

		private static void CaptureCSMCallEventExceptionData(IRequestContext requestContext, Exception exception)
		{
			requestContext.CSMCallEvent.IsLastExceptionRetryable = requestContext.IsLastExceptionRetryable;
			if (exception is AmazonServiceException)
			{
				requestContext.CSMCallEvent.FinalAWSException = requestContext.CSMCallAttempt.AWSException;
				requestContext.CSMCallEvent.FinalAWSExceptionMessage = requestContext.CSMCallAttempt.AWSExceptionMessage;
			}
			else
			{
				requestContext.CSMCallEvent.FinalSdkException = requestContext.CSMCallAttempt.SdkException;
				requestContext.CSMCallEvent.FinalSdkExceptionMessage = requestContext.CSMCallAttempt.SdkExceptionMessage;
			}
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			stopWatch = Stopwatch.StartNew();
		}
	}
}
