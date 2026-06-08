using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.S3.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3RedirectHandler : RedirectHandler
	{
		protected override void FinalizeForRedirect(IExecutionContext executionContext, string redirectedLocation)
		{
			IRequest request = executionContext.RequestContext.Request;
			if (request.UseChunkEncoding && request.Headers.ContainsKey("X-Amz-Decoded-Content-Length"))
			{
				request.Headers["Content-Length"] = request.Headers["X-Amz-Decoded-Content-Length"];
			}
			if (request.Headers.ContainsKey("host"))
			{
				request.Headers.Remove("host");
			}
			base.FinalizeForRedirect(executionContext, redirectedLocation);
			AmazonS3KmsHandler.EvaluateIfSigV4Required(executionContext.RequestContext.Request);
			AmazonS3Uri amazonS3Uri = new AmazonS3Uri(redirectedLocation);
			if (request.SignatureVersion == SignatureVersion.SigV4)
			{
				request.AuthenticationRegion = amazonS3Uri.Region.SystemName;
				Signer.SignRequest(executionContext.RequestContext);
			}
		}
	}
}
