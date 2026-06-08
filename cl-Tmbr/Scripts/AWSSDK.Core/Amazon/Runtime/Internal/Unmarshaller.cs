using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Telemetry.Metrics;

namespace Amazon.Runtime.Internal
{
	public class Unmarshaller : PipelineHandler
	{
		private bool _supportsResponseLogging;

		public Unmarshaller(bool supportsResponseLogging)
		{
			_supportsResponseLogging = supportsResponseLogging;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			base.InvokeSync(executionContext);
			if (executionContext.ResponseContext.HttpResponse.IsSuccessStatusCode)
			{
				Unmarshall(executionContext);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			await UnmarshallAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			return (T)executionContext.ResponseContext.Response;
		}

		private void Unmarshall(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IResponseContext responseContext = executionContext.ResponseContext;
			using (requestContext.Metrics.StartEvent(Metric.ResponseProcessingTime))
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				try
				{
					bool readEntireResponse = _supportsResponseLogging && (requestContext.ClientConfig.LogResponse || AWSConfigs.LoggingConfig.LogResponses != ResponseLoggingOption.Never);
					UnmarshallerContext unmarshallerContext = unmarshaller.CreateContext(responseContext.HttpResponse, readEntireResponse, responseContext.HttpResponse.ResponseBody.OpenResponse(), requestContext.Metrics, isException: false, requestContext);
					try
					{
						AmazonWebServiceResponse response = UnmarshallResponse(unmarshallerContext, requestContext);
						responseContext.Response = response;
					}
					catch (Exception ex)
					{
						if (ex is AmazonServiceException || ex is AmazonClientException)
						{
							throw;
						}
						string headerValue = responseContext.HttpResponse.GetHeaderValue("x-amzn-RequestId");
						string responseBody = unmarshallerContext.ResponseBody;
						throw new AmazonUnmarshallingException(headerValue, null, responseBody, ex, responseContext.HttpResponse.StatusCode);
					}
				}
				finally
				{
					if (!unmarshaller.HasStreamingProperty)
					{
						responseContext.HttpResponse.ResponseBody.Dispose();
					}
				}
			}
		}

		private async Task UnmarshallAsync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IResponseContext responseContext = executionContext.ResponseContext;
			using (requestContext.Metrics.StartEvent(Metric.ResponseProcessingTime))
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				try
				{
					bool readEntireResponse = _supportsResponseLogging && (requestContext.ClientConfig.LogResponse || AWSConfigs.LoggingConfig.LogResponses != ResponseLoggingOption.Never);
					Stream stream = await responseContext.HttpResponse.ResponseBody.OpenResponseAsync().ConfigureAwait(continueOnCapturedContext: false);
					UnmarshallerContext context = unmarshaller.CreateContext(responseContext.HttpResponse, readEntireResponse, stream, requestContext.Metrics, isException: false, requestContext);
					AmazonWebServiceResponse response = UnmarshallResponse(context, requestContext);
					responseContext.Response = response;
				}
				finally
				{
					if (!unmarshaller.HasStreamingProperty)
					{
						responseContext.HttpResponse.ResponseBody.Dispose();
					}
				}
			}
		}

		private AmazonWebServiceResponse UnmarshallResponse(UnmarshallerContext context, IRequestContext requestContext)
		{
			try
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				AmazonWebServiceResponse amazonWebServiceResponse = null;
				using (requestContext.Metrics.StartEvent(Metric.ResponseUnmarshallTime))
				{
					using (MetricsUtilities.MeasureDuration(requestContext, "client.call.deserialization_duration"))
					{
						amazonWebServiceResponse = unmarshaller.UnmarshallResponse(context);
						InitializeEventInputStream(amazonWebServiceResponse, requestContext);
					}
				}
				requestContext.Metrics.AddProperty(Metric.StatusCode, amazonWebServiceResponse.HttpStatusCode);
				requestContext.Metrics.AddProperty(Metric.BytesProcessed, amazonWebServiceResponse.ContentLength);
				if (amazonWebServiceResponse.ResponseMetadata != null)
				{
					requestContext.Metrics.AddProperty(Metric.AWSRequestID, amazonWebServiceResponse.ResponseMetadata.RequestId);
				}
				context.ValidateCRC32IfAvailable();
				context.ValidateFlexibleCheckumsIfAvailable(amazonWebServiceResponse.ResponseMetadata);
				return amazonWebServiceResponse;
			}
			finally
			{
				if (ShouldLogResponseBody(_supportsResponseLogging, requestContext))
				{
					Logger.DebugFormat("Received response (truncated to {0} bytes): [{1}]", AWSConfigs.LoggingConfig.LogResponsesSizeLimit, context.ResponseBody);
				}
			}
		}

		private static bool ShouldLogResponseBody(bool supportsResponseLogging, IRequestContext requestContext)
		{
			if (supportsResponseLogging)
			{
				if (!requestContext.ClientConfig.LogResponse)
				{
					return AWSConfigs.LoggingConfig.LogResponses == ResponseLoggingOption.Always;
				}
				return true;
			}
			return false;
		}

		private static void InitializeEventInputStream(AmazonWebServiceResponse response, IRequestContext requestContext)
		{
			if (response is IEventInputStreamContextOwner eventInputStreamContextOwner)
			{
				eventInputStreamContextOwner.SetEventInputStreamContext(new EventInputStreamContext
				{
					RequestStreamHandle = requestContext.RequestStreamHandle
				});
			}
		}
	}
}
