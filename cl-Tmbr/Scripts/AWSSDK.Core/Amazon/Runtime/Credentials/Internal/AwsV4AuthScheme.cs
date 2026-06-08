using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Credentials.Internal
{
	public class AwsV4AuthScheme : IAuthScheme<AWSCredentials>
	{
		private static readonly ISigner _signer = new AWS4Signer();

		public string SchemeId => "aws.auth#sigv4";

		public IIdentityResolver GetIdentityResolver(IIdentityResolverConfiguration configuration)
		{
			return configuration.GetIdentityResolver<AWSCredentials>();
		}

		public ISigner Signer()
		{
			return _signer;
		}
	}
}
