using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Credentials.Internal
{
	public class BearerAuthScheme : IAuthScheme<AWSToken>
	{
		private static readonly ISigner _signer = new BearerTokenSigner();

		public string SchemeId => "smithy.api#httpBearerAuth";

		public IIdentityResolver GetIdentityResolver(IIdentityResolverConfiguration configuration)
		{
			return configuration.GetIdentityResolver<AWSToken>();
		}

		public ISigner Signer()
		{
			return _signer;
		}
	}
}
