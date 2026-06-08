using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Credentials.Internal
{
	public class AnonymousAuthScheme : IAuthScheme<AnonymousAWSCredentials>
	{
		private static readonly ISigner _signer = new NullSigner();

		public string SchemeId => "smithy.api#noAuth";

		public IIdentityResolver GetIdentityResolver(IIdentityResolverConfiguration configuration)
		{
			return configuration.GetIdentityResolver<AnonymousAWSCredentials>();
		}

		public ISigner Signer()
		{
			return _signer;
		}
	}
}
