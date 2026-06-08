using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class SSOAWSCredentials : RefreshingAWSCredentials
	{
		private readonly Logger _logger = Logger.GetLogger(typeof(SSOAWSCredentials));

		private readonly ISSOTokenManager _ssoTokenManager;

		public string AccountId { get; private set; }

		public string Region { get; private set; }

		public string RoleName { get; private set; }

		public string StartUrl { get; private set; }

		public SSOAWSCredentialsOptions Options { get; private set; }

		public SSOAWSCredentials(string accountId, string region, string roleName, string startUrl)
			: this(accountId, region, roleName, startUrl, new SSOAWSCredentialsOptions())
		{
		}

		public SSOAWSCredentials(string accountId, string region, string roleName, string startUrl, SSOAWSCredentialsOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (string.IsNullOrEmpty(region))
			{
				throw new ArgumentNullException("region");
			}
			AccountId = accountId;
			Region = region;
			RoleName = roleName;
			StartUrl = startUrl;
			Options = options;
			base.FeatureIdSources.Add(string.IsNullOrEmpty(options.SessionName) ? UserAgentFeatureId.CREDENTIALS_SSO_LEGACY : UserAgentFeatureId.CREDENTIALS_SSO);
			_ssoTokenManager = new SSOTokenManager(SSOServiceClientHelpers.BuildSSOIDCClient(RegionEndpoint.GetBySystemName(region), options.ProxySettings), new SSOTokenFileCache(CryptoUtilFactory.CryptoInstance, new FileRetriever(), new DirectoryRetriever()));
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			return GenerateNewCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter().GetResult();
		}

		protected override async Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			ValidateCredentialsInputs();
			ICoreAmazonSSO sso = SSOServiceClientHelpers.BuildSSOClient(RegionEndpoint.GetBySystemName(Region), Options.ProxySettings);
			if (!(await GetSsoCredentialsAsync(sso).ConfigureAwait(continueOnCapturedContext: false) is SSOImmutableCredentials sSOImmutableCredentials))
			{
				throw new NotSupportedException("Unable to get credentials from SSO");
			}
			_logger.DebugFormat("New SSO credentials created that expire at {0}", sSOImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(sSOImmutableCredentials, sSOImmutableCredentials.Expiration);
		}

		private void ValidateCredentialsInputs()
		{
			List<string> list = (from propNameToValue in new Dictionary<string, string>
				{
					{ "AccountId", AccountId },
					{ "Region", Region },
					{ "RoleName", RoleName },
					{ "StartUrl", StartUrl }
				}
				where string.IsNullOrWhiteSpace(propNameToValue.Value)
				select propNameToValue.Key).ToList();
			if (list.Any())
			{
				throw new ArgumentNullException("Property cannot be empty: " + string.Join(", ", list));
			}
		}

		private async Task<ImmutableCredentials> GetSsoCredentialsAsync(ICoreAmazonSSO sso)
		{
			SSOTokenManagerGetTokenOptions options = new SSOTokenManagerGetTokenOptions
			{
				ClientName = Options.ClientName,
				Region = Region,
				SsoVerificationCallback = Options.SsoVerificationCallback,
				StartUrl = StartUrl,
				Session = Options.SessionName,
				Scopes = Options.Scopes,
				SupportsGettingNewToken = Options.SupportsGettingNewToken,
				PkceFlowOptions = Options.PkceFlowOptions
			};
			return await GetSsoRoleCredentialsAsync(sso, (await _ssoTokenManager.GetTokenAsync(options).ConfigureAwait(continueOnCapturedContext: false)).AccessToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<ImmutableCredentials> GetSsoRoleCredentialsAsync(ICoreAmazonSSO sso, string accessToken)
		{
			return await sso.CredentialsFromSsoAccessTokenAsync(AccountId, RoleName, accessToken, null).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
