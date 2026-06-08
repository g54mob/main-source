using System.Threading.Tasks;
using Amazon.Runtime.Internal.Compression;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry.Tracing;
using Amazon.Util;

namespace Amazon.Runtime.Internal
{
	public class CompressionHandler : PipelineHandler
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

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			long requestMinCompressionSizeBytes = clientConfig.RequestMinCompressionSizeBytes;
			bool disableRequestCompression = clientConfig.DisableRequestCompression;
			IRequest request = executionContext.RequestContext.Request;
			if (disableRequestCompression || request.CompressionAlgorithm == CompressionEncodingAlgorithm.NONE)
			{
				return;
			}
			if (request.CompressionAlgorithm == CompressionEncodingAlgorithm.gzip)
			{
				executionContext.RequestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.GZIP_REQUEST_COMPRESSION);
			}
			ICompressionAlgorithm compressionAlgorithm = CompressionFactory.GetCompressionAlgorithm(request.CompressionAlgorithm);
			if (request.ContentStream != null)
			{
				request.ContentStream = new CompressionWrapperStream(request.ContentStream, compressionAlgorithm);
				CompressionAlgorithmUtils.SetRequestHeader(request, compressionAlgorithm.AlgorithmId);
				request.Headers["transfer-encoding"] = "chunked";
				request.Headers.Remove("Content-Length");
				return;
			}
			byte[] requestPayloadBytes = AWSSDKUtils.GetRequestPayloadBytes(request);
			if (requestPayloadBytes.Length < requestMinCompressionSizeBytes)
			{
				return;
			}
			executionContext.RequestContext.Metrics.AddProperty(Metric.UncompressedRequestSize, requestPayloadBytes.Length);
			using (TracingUtilities.CreateSpan(executionContext.RequestContext, "RequestCompression"))
			{
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.RequestCompressionTime))
				{
					request.Content = compressionAlgorithm.Compress(requestPayloadBytes);
				}
			}
			CompressionAlgorithmUtils.SetRequestHeader(request, compressionAlgorithm.AlgorithmId);
		}
	}
}
