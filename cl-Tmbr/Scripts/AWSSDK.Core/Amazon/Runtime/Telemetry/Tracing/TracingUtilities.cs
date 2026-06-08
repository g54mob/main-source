using System;
using Amazon.Util;

namespace Amazon.Runtime.Telemetry.Tracing
{
	internal static class TracingUtilities
	{
		public static TraceSpan CreateSpan(IRequestContext requestContext, string spanName, Attributes initialAttributes = null, SpanKind spanKind = SpanKind.INTERNAL, SpanContext parentContext = null)
		{
			string serviceId = requestContext.ClientConfig.ServiceId;
			if (initialAttributes == null)
			{
				initialAttributes = new Attributes();
			}
			string value = AWSSDKUtils.ExtractOperationName(requestContext.RequestName);
			initialAttributes.Set("rpc.method", value);
			initialAttributes.Set("rpc.system", "aws-api");
			initialAttributes.Set("rpc.service", serviceId);
			TracerProvider tracerProvider = requestContext.ClientConfig.TelemetryProvider.TracerProvider;
			string scope = "AWSSDK." + serviceId;
			return tracerProvider.GetTracer(scope).CreateSpan(spanName, initialAttributes, spanKind, parentContext);
		}

		public static void CaptureException(this TraceSpan span, Exception exception)
		{
			span.RecordException(exception);
			span.SetAttribute("exception.type", exception.GetType().ToString());
			span.SetAttribute("exception.message", exception.Message);
			span.SetAttribute("exception.stacktrace", exception.StackTrace);
			if (exception is AmazonServiceException ex)
			{
				span.SetAttribute("aws.error_code", ex.ErrorCode);
				span.SetAttribute("http.status_code", (int)ex.StatusCode);
				span.SetAttribute("aws.request_id", ex.RequestId);
			}
		}
	}
}
