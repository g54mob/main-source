using System;
using System.Net;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public class CSMCallAttemptHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				PreInvoke(executionContext);
				base.InvokeSync(executionContext);
			}
			catch (AmazonServiceException e)
			{
				CaptureAmazonException(executionContext.RequestContext.CSMCallAttempt, e);
				throw;
			}
			catch (Exception e2)
			{
				CaptureSDKExceptionMessage(executionContext.RequestContext.CSMCallAttempt, e2);
				throw;
			}
			finally
			{
				CSMCallAttemptMetricsCapture(executionContext.RequestContext, executionContext.ResponseContext);
				CSMUtilities.SerializetoJsonAndPostOverUDP(executionContext.RequestContext.CSMCallAttempt);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				PreInvoke(executionContext);
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (AmazonServiceException e)
			{
				CaptureAmazonException(executionContext.RequestContext.CSMCallAttempt, e);
				throw;
			}
			catch (Exception e2)
			{
				CaptureSDKExceptionMessage(executionContext.RequestContext.CSMCallAttempt, e2);
				throw;
			}
			finally
			{
				CSMCallAttemptMetricsCapture(executionContext.RequestContext, executionContext.ResponseContext);
				CSMUtilities.SerializetoJsonAndPostOverUDPAsync(executionContext.RequestContext.CSMCallAttempt);
			}
		}

		protected static void CSMCallAttemptMetricsCapture(IRequestContext requestContext, IResponseContext responseContext)
		{
			requestContext.CSMCallAttempt.Service = requestContext.CSMCallEvent.Service;
			requestContext.CSMCallAttempt.Fqdn = requestContext.Request.GetHeaderValue("host");
			bool flag = (requestContext.ClientConfig as ClientConfig)?.UseAlternateUserAgentHeader ?? false;
			requestContext.CSMCallAttempt.UserAgent = requestContext.Request.GetHeaderValue(flag ? "x-amz-user-agent" : "User-Agent");
			requestContext.CSMCallAttempt.SessionToken = requestContext.Request.GetHeaderValue("x-amz-security-token");
			requestContext.CSMCallAttempt.Region = requestContext.Request.DeterminedSigningRegion;
			requestContext.CSMCallAttempt.Api = CSMUtilities.GetApiNameFromRequest(requestContext.Request.RequestName, requestContext.ServiceMetaData.OperationNameMapping, requestContext.CSMCallAttempt.Service);
			if (requestContext.Identity is AWSCredentials aWSCredentials)
			{
				requestContext.CSMCallAttempt.AccessKey = aWSCredentials.GetCredentials().AccessKey;
			}
			requestContext.CSMCallAttempt.AttemptLatency = (long)requestContext.Metrics.StopEvent(Metric.CSMAttemptLatency).ElapsedTime.TotalMilliseconds;
			if (responseContext.HttpResponse != null)
			{
				if (responseContext.HttpResponse.StatusCode > (HttpStatusCode)0)
				{
					requestContext.CSMCallAttempt.HttpStatusCode = (int)responseContext.HttpResponse.StatusCode;
				}
				requestContext.CSMCallAttempt.XAmznRequestId = responseContext.HttpResponse.GetHeaderValue("x-amzn-RequestId");
				requestContext.CSMCallAttempt.XAmzRequestId = responseContext.HttpResponse.GetHeaderValue("x-amz-request-id");
				requestContext.CSMCallAttempt.XAmzId2 = responseContext.HttpResponse.GetHeaderValue("x-amz-id-2");
			}
		}

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			executionContext.RequestContext.CSMCallAttempt = new MonitoringAPICallAttempt(executionContext.RequestContext);
			executionContext.RequestContext.Metrics.StartEvent(Metric.CSMAttemptLatency);
		}

		private static void CaptureSDKExceptionMessage(MonitoringAPICallAttempt monitoringAPICallAttempt, Exception e)
		{
			monitoringAPICallAttempt.SdkException = ((e.GetType().Name.ToString().Length <= 128) ? e.GetType().Name.ToString() : string.Empty);
			monitoringAPICallAttempt.SdkExceptionMessage = ((e.Message.Length <= 512) ? e.Message : string.Empty);
		}

		private static void CaptureAmazonException(MonitoringAPICallAttempt monitoringAPICallAttempt, AmazonServiceException e)
		{
			if (e.StatusCode > (HttpStatusCode)0)
			{
				monitoringAPICallAttempt.HttpStatusCode = (int)e.StatusCode;
			}
			if (e.ErrorCode == null)
			{
				CaptureSDKExceptionMessage(monitoringAPICallAttempt, e);
				return;
			}
			monitoringAPICallAttempt.AWSException = ((e.ErrorCode.Length <= 128) ? e.ErrorCode : string.Empty);
			monitoringAPICallAttempt.AWSExceptionMessage = ((e.Message.Length <= 512) ? e.Message : string.Empty);
		}
	}
}
