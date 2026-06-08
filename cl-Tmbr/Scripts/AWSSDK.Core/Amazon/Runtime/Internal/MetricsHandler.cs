using System;
using System.Threading.Tasks;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Tracing;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class MetricsHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, false);
			string text = AWSSDKUtils.ExtractOperationName(executionContext.RequestContext.RequestName);
			string spanName = executionContext.RequestContext.ServiceMetaData.ServiceId + "." + text;
			TraceSpan traceSpan = TracingUtilities.CreateSpan(executionContext.RequestContext, spanName, null, SpanKind.CLIENT);
			IDisposable disposable = null;
			try
			{
				disposable = MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.duration");
				executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
				base.InvokeSync(executionContext);
				string text2 = executionContext.ResponseContext.Response.ResponseMetadata?.RequestId;
				if (text2 != null)
				{
					traceSpan.SetAttribute("aws.request_id", text2);
				}
			}
			catch (Exception exception)
			{
				traceSpan.CaptureException(exception);
				MetricsUtilities.RecordError(executionContext.RequestContext, exception);
				throw;
			}
			finally
			{
				executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
				LogMetrics(executionContext);
				disposable?.Dispose();
				traceSpan.Dispose();
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, true);
			string text = AWSSDKUtils.ExtractOperationName(executionContext.RequestContext.RequestName);
			string spanName = executionContext.RequestContext.ServiceMetaData.ServiceId + "." + text;
			TraceSpan span = TracingUtilities.CreateSpan(executionContext.RequestContext, spanName, null, SpanKind.CLIENT);
			IDisposable callDurationMetricsMeasurer = null;
			try
			{
				callDurationMetricsMeasurer = MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.duration");
				executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
				T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
				string text2 = executionContext.ResponseContext.Response.ResponseMetadata?.RequestId;
				if (text2 != null)
				{
					span.SetAttribute("aws.request_id", text2);
				}
				return result;
			}
			catch (Exception exception)
			{
				span.CaptureException(exception);
				MetricsUtilities.RecordError(executionContext.RequestContext, exception);
				throw;
			}
			finally
			{
				executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
				LogMetrics(executionContext);
				callDurationMetricsMeasurer?.Dispose();
				span.Dispose();
			}
		}
	}
}
