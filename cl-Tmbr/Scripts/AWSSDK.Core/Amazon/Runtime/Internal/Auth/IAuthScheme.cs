using Amazon.Runtime.Identity;

namespace Amazon.Runtime.Internal.Auth
{
	public interface IAuthScheme<out T> where T : BaseIdentity
	{
		string SchemeId { get; }

		IIdentityResolver GetIdentityResolver(IIdentityResolverConfiguration configuration);

		ISigner Signer();
	}
}
