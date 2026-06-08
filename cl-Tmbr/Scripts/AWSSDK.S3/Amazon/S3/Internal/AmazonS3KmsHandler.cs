using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3KmsHandler : PipelineHandler
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
			EvaluateIfSigV4Required(executionContext.RequestContext.Request);
		}

		internal static void EvaluateIfSigV4Required(IRequest request)
		{
			if (request.SignatureVersion != SignatureVersion.SigV4a && request.OriginalRequest is GetObjectRequest && AmazonS3Uri.TryParseAmazonS3Uri(request.Endpoint, out var amazonS3Uri) && amazonS3Uri.Region?.SystemName != RegionEndpoint.USEast1.SystemName)
			{
				request.SignatureVersion = SignatureVersion.SigV4;
			}
		}
	}
}
