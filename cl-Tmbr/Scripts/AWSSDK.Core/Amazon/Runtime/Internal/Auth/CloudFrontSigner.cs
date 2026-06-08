using System;
using System.Globalization;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class CloudFrontSigner : AbstractAWSSigner
	{
		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			ImmutableCredentials credentials = ((identity as AWSCredentials) ?? throw new AmazonClientException("The identity parameter must be of type AWSCredentials for the signer CloudFrontSigner.")).GetCredentials();
			if (string.IsNullOrEmpty(credentials?.AccessKey))
			{
				throw new ArgumentOutOfRangeException("awsAccessKeyId", "The AWS Access Key ID cannot be NULL or a Zero length string");
			}
			DateTime correctedUtcNowForEndpoint = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(request.Endpoint.ToString());
			request.SignedAt = correctedUtcNowForEndpoint;
			string text = correctedUtcNowForEndpoint.ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
			request.Headers.Add("X-Amz-Date", text);
			string text2 = AbstractAWSSigner.ComputeHash(text, credentials.SecretKey, SigningAlgorithm.HmacSHA1);
			request.Headers.Add("Authorization", "AWS " + credentials.AccessKey + ":" + text2);
		}
	}
}
