using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class BearerTokenSigner : AbstractAWSSigner
	{
		public override bool RequiresCredentials { get; }

		public override ClientProtocol Protocol { get; } = ClientProtocol.Unknown;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			if (request.Endpoint.Scheme == "http")
			{
				throw new AmazonClientException($"The configured endpoint [{request.Endpoint}] is invalid for the bearer authorization scheme. " + "Endpoint must not use 'http'.");
			}
			if (!(identity is AWSToken aWSToken) || string.IsNullOrEmpty(aWSToken.Token))
			{
				throw new AmazonClientException("No Token found. Operation requires a Bearer token.");
			}
			request.Headers["Authorization"] = "Bearer " + aWSToken.Token;
		}
	}
}
