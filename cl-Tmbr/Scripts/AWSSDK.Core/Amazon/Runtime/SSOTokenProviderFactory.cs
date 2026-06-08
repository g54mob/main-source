using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal;

namespace Amazon.Runtime
{
	public class SSOTokenProviderFactory : ISSOTokenProviderFactory
	{
		private readonly ISSOTokenFileCache _ssoTokenFileCache;

		public SSOTokenProviderFactory(ISSOTokenFileCache ssoTokenFileCache)
		{
			_ssoTokenFileCache = ssoTokenFileCache;
		}

		public SSOTokenProvider Build(CredentialProfile profile)
		{
			return new SSOTokenProvider(new SSOTokenManager(SSOServiceClientHelpers.BuildSSOIDCClient(profile.Region), _ssoTokenFileCache), profile.Options.SsoSession, profile.Options.SsoStartUrl, profile.Options.SsoRegion);
		}
	}
}
