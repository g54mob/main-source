using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class SSOTokenProvider : IAWSTokenProvider
	{
		private readonly ILogger _logger = Logger.GetLogger(typeof(SSOTokenProvider));

		private readonly ISSOTokenManager _ssoTokenManager;

		private readonly string _sessionName;

		private readonly string _startUrl;

		private readonly string _region;

		private readonly string _ssoCacheDirectory;

		public SSOTokenProvider(ISSOTokenManager ssoTokenManager, string sessionName, string startUrl, string region, string ssoCacheDirectory = null)
		{
			if (string.IsNullOrWhiteSpace(sessionName))
			{
				throw new ArgumentNullException("sessionName");
			}
			if (string.IsNullOrWhiteSpace(startUrl))
			{
				throw new ArgumentNullException("startUrl");
			}
			if (string.IsNullOrEmpty(region))
			{
				throw new ArgumentNullException("region");
			}
			_ssoTokenManager = ssoTokenManager;
			_sessionName = sessionName;
			_startUrl = startUrl;
			_region = region;
			_ssoCacheDirectory = ssoCacheDirectory;
		}

		public async Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				SSOTokenManagerGetTokenOptions options = BuildSsoTokenManagerGetTokenOptions();
				SsoToken token = await _ssoTokenManager.GetTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return new TryResponse<AWSToken>
				{
					Success = true,
					Value = MapSsoTokenToAwsToken(token)
				};
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Exception trying to resolve SSO Token");
				throw;
			}
		}

		private SSOTokenManagerGetTokenOptions BuildSsoTokenManagerGetTokenOptions()
		{
			SSOTokenManagerGetTokenOptions sSOTokenManagerGetTokenOptions = new SSOTokenManagerGetTokenOptions
			{
				Session = _sessionName,
				StartUrl = _startUrl,
				Region = _region,
				SupportsGettingNewToken = false
			};
			if (!string.IsNullOrEmpty(_ssoCacheDirectory))
			{
				sSOTokenManagerGetTokenOptions.CacheFolderLocation = _ssoCacheDirectory;
			}
			return sSOTokenManagerGetTokenOptions;
		}

		private AWSToken MapSsoTokenToAwsToken(SsoToken token)
		{
			return new AWSToken
			{
				Token = token.AccessToken,
				Expiration = token.ExpiresAt
			};
		}
	}
}
