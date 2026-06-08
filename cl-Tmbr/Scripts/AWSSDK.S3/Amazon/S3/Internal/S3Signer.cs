using Amazon.Runtime;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Internal
{
	public class S3Signer : AbstractAWSSigner
	{
		private readonly Amazon.Runtime.Internal.Auth.S3Signer _s3Signer;

		public override ClientProtocol Protocol => _s3Signer.Protocol;

		public S3Signer()
		{
			_s3Signer = new Amazon.Runtime.Internal.Auth.S3Signer(RegionDetectionUpdater);
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			_s3Signer.Sign(request, clientConfig, metrics, identity);
		}

		internal static void SignRequest(IRequest request, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			Amazon.Runtime.Internal.Auth.S3Signer.SignRequest(request, metrics, awsAccessKeyId, awsSecretAccessKey);
		}

		private static void RegionDetectionUpdater(IRequest request)
		{
			if (AmazonS3Uri.TryParseAmazonS3Uri(request.Endpoint, out var amazonS3Uri) && amazonS3Uri.Bucket != null && BucketRegionDetector.BucketRegionCache.TryGetValue(amazonS3Uri.Bucket, out var value))
			{
				request.AlternateEndpoint = value;
			}
		}
	}
}
