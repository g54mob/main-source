using System.Threading.Tasks;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class ChecksumHandler : PipelineHandler
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
			IRequestContext requestContext = executionContext.RequestContext;
			IRequest request = executionContext.RequestContext.Request;
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			if ((executionContext.RequestContext.Identity is AnonymousAWSCredentials && executionContext.RequestContext.Signer.RequiresCredentials) || request.ChecksumData == null)
			{
				return;
			}
			if (request.ChecksumData.IsMD5Checksum)
			{
				ChecksumUtils.SetRequestChecksumMD5(request);
				return;
			}
			ChecksumUtils.SetRequestChecksumV2(request, clientConfig);
			switch (request.SelectedChecksum)
			{
			case CoreChecksumAlgorithm.CRC32C:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_CRC32C);
				break;
			case CoreChecksumAlgorithm.CRC32:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_CRC32);
				break;
			case CoreChecksumAlgorithm.SHA256:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_SHA256);
				break;
			case CoreChecksumAlgorithm.SHA1:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_SHA1);
				break;
			case CoreChecksumAlgorithm.CRC64NVME:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_CRC64);
				break;
			}
			switch (clientConfig.RequestChecksumCalculation)
			{
			case RequestChecksumCalculation.WHEN_SUPPORTED:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_WHEN_SUPPORTED);
				break;
			case RequestChecksumCalculation.WHEN_REQUIRED:
				requestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_WHEN_REQUIRED);
				break;
			}
		}
	}
}
