using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class ProfileTokenProvider : IAWSTokenProvider
	{
		private readonly ISSOTokenProviderFactory _ssoTokenProviderFactory;

		private readonly ICredentialProfileSource _credentialProfileSource;

		private readonly string _profileName;

		public ProfileTokenProvider(ISSOTokenProviderFactory ssoTokenProviderFactory, ICredentialProfileSource credentialProfileSource, string profileName = null)
		{
			_ssoTokenProviderFactory = ssoTokenProviderFactory;
			_credentialProfileSource = credentialProfileSource;
			_profileName = profileName;
		}

		public ProfileTokenProvider(string profileName = null)
			: this(new SSOTokenProviderFactory(new SSOTokenFileCache(CryptoUtilFactory.CryptoInstance, new FileRetriever(), new DirectoryRetriever())), new CredentialProfileStoreChain(), profileName)
		{
		}

		public Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (LoadAndValidateProfile(out var profile))
			{
				return _ssoTokenProviderFactory.Build(profile).TryResolveTokenAsync(cancellationToken);
			}
			return Task.FromResult(TryResponse<AWSToken>.Failure);
		}

		private bool LoadAndValidateProfile(out CredentialProfile profile)
		{
			string profileName = ((!string.IsNullOrEmpty(_profileName)) ? _profileName : DefaultAWSCredentialsIdentityResolver.GetProfileName());
			if (!_credentialProfileSource.TryGetProfile(profileName, out profile))
			{
				return false;
			}
			if (string.IsNullOrEmpty(profile.Options.SsoSession))
			{
				return false;
			}
			if (string.IsNullOrEmpty(profile.Options.SsoStartUrl))
			{
				throw new AmazonClientException("Invalid Configuration.  SSO Session [" + profile.Options.SsoSession + "] is missing sso_start_url.");
			}
			if (string.IsNullOrEmpty(profile.Options.SsoRegion))
			{
				throw new AmazonClientException("Invalid Configuration.  SSO Session [" + profile.Options.SsoSession + "] is missing sso_region.");
			}
			return true;
		}
	}
}
