using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Metrics.NoOp;
using Amazon.Runtime.Telemetry.Tracing.NoOp;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class Marshaller : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			using (MetricsUtilities.MeasureDuration(executionContext.RequestContext, "client.call.serialization_duration"))
			{
				IRequestContext requestContext = executionContext.RequestContext;
				if (requestContext.OriginalRequest.CoreChecksumMode != CoreChecksumResponseBehavior.ENABLED && requestContext.ClientConfig.ResponseChecksumValidation == ResponseChecksumValidation.WHEN_SUPPORTED)
				{
					requestContext.OriginalRequest.CoreChecksumMode = CoreChecksumResponseBehavior.ENABLED;
				}
				switch (requestContext.ClientConfig.ResponseChecksumValidation)
				{
				case ResponseChecksumValidation.WHEN_SUPPORTED:
					requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_RES_WHEN_SUPPORTED);
					break;
				case ResponseChecksumValidation.WHEN_REQUIRED:
					requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_RES_WHEN_REQUIRED);
					break;
				}
				requestContext.Request = requestContext.Marshaller.Marshall(requestContext.OriginalRequest);
				requestContext.Request.AuthenticationRegion = requestContext.ClientConfig.AuthenticationRegion;
				if (requestContext.Request.HasRequestBody() && !requestContext.Request.Headers.ContainsKey("Content-Type"))
				{
					if (requestContext.Request.UseQueryString)
					{
						requestContext.Request.Headers["Content-Type"] = "application/x-amz-json-1.0";
					}
					else
					{
						requestContext.Request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=utf-8";
					}
				}
				SetRecursionDetectionHeader(requestContext.Request.Headers);
				UpdateUserAgentDetails(requestContext);
			}
		}

		private static void SetRecursionDetectionHeader(IDictionary<string, string> headers)
		{
			if (!headers.ContainsKey("x-amzn-trace-id"))
			{
				string environmentVariable = Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME");
				string environmentVariable2 = Environment.GetEnvironmentVariable("_X_AMZN_TRACE_ID");
				if (!string.IsNullOrEmpty(environmentVariable) && !string.IsNullOrEmpty(environmentVariable2))
				{
					headers["x-amzn-trace-id"] = AWSSDKUtils.EncodeTraceIdHeaderValue(environmentVariable2);
				}
			}
		}

		private static void UpdateUserAgentDetails(IRequestContext requestContext)
		{
			switch (requestContext.ClientConfig.AccountIdEndpointMode)
			{
			case AccountIdEndpointMode.DISABLED:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.ACCOUNT_ID_MODE_DISABLED);
				break;
			case AccountIdEndpointMode.PREFERRED:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.ACCOUNT_ID_MODE_PREFERRED);
				break;
			case AccountIdEndpointMode.REQUIRED:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.ACCOUNT_ID_MODE_REQUIRED);
				break;
			}
			requestContext.UserAgentDetails.AddUserAgentComponent(InternalSDKUtils.ReplaceInvalidUserAgentCharacters(requestContext.ClientConfig.UserAgent));
			string clientAppId = requestContext.ClientConfig.ClientAppId;
			if (!string.IsNullOrEmpty(clientAppId))
			{
				requestContext.UserAgentDetails.AddUserAgentComponent("app/" + InternalSDKUtils.ReplaceInvalidUserAgentCharacters(clientAppId));
			}
			requestContext.UserAgentDetails.AddUserAgentComponent("md/" + (requestContext.IsAsync ? "ClientAsync" : "ClientSync"));
			requestContext.UserAgentDetails.AddUserAgentComponent($"cfg/init-coll#{(AWSConfigs.InitializeCollections ? '1' : '0')}");
			SetObservabilityFeatureIds(requestContext);
		}

		private static void SetObservabilityFeatureIds(IRequestContext requestContext)
		{
			IClientConfig clientConfig = requestContext.ClientConfig;
			if (!(clientConfig.TelemetryProvider.TracerProvider is NoOpTracerProvider))
			{
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.OBSERVABILITY_TRACING);
				if (clientConfig.TelemetryProvider.TracerProvider.GetType().Namespace.StartsWith("OpenTelemetry.Instrumentation.AWS"))
				{
					requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.OBSERVABILITY_OTEL_TRACING);
				}
			}
			if (!(clientConfig.TelemetryProvider.MeterProvider is NoOpMeterProvider))
			{
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.OBSERVABILITY_METRICS);
				if (clientConfig.TelemetryProvider.MeterProvider.GetType().Namespace.StartsWith("OpenTelemetry.Instrumentation.AWS"))
				{
					requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.OBSERVABILITY_OTEL_METRICS);
				}
			}
		}
	}
}
