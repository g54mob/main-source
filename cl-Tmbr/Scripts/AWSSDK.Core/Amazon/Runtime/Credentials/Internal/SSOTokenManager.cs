using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.Util;

namespace Amazon.Runtime.Credentials.Internal
{
	public class SSOTokenManager : ISSOTokenManager
	{
		private class InMemoryCache
		{
			private readonly ConcurrentDictionary<string, CacheState> _inMemoryCache = new ConcurrentDictionary<string, CacheState>();

			public bool TryGetValue(SSOTokenManagerGetTokenOptions options, out CacheState inMemoryToken)
			{
				string key = BuildCacheKey(options);
				return _inMemoryCache.TryGetValue(key, out inMemoryToken);
			}

			public void AddOrUpdate(SSOTokenManagerGetTokenOptions options, CacheState newInMemoryToken)
			{
				string key = BuildCacheKey(options);
				_inMemoryCache.AddOrUpdate(key, newInMemoryToken, (string x, CacheState y) => newInMemoryToken);
			}

			private static string BuildCacheKey(SSOTokenManagerGetTokenOptions options)
			{
				if (string.IsNullOrEmpty(options.Session))
				{
					return options.StartUrl;
				}
				return options.Session;
			}
		}

		private class RefreshState
		{
			public bool FailedLastRefreshAttempt { get; set; }

			public DateTime? BlockRefreshUntil { get; set; }

			public bool IsInRefreshCoolDown()
			{
				if (!BlockRefreshUntil.HasValue)
				{
					return false;
				}
				return BlockRefreshUntil.Value < AWSSDKUtils.CorrectedUtcNow;
			}
		}

		private class CacheState
		{
			public SsoToken Token { get; set; }

			public RefreshState RefreshState { get; set; }
		}

		private readonly ILogger _logger = Logger.GetLogger(typeof(SSOTokenManager));

		private readonly ICoreAmazonSSOOIDC _ssooidcClient;

		private readonly ISSOTokenFileCache _ssoTokenFileCache;

		private readonly InMemoryCache _inMemoryCache;

		public SSOTokenManager(ICoreAmazonSSOOIDC ssooidcClient, ISSOTokenFileCache ssoTokenFileCache)
		{
			_ssooidcClient = ssooidcClient;
			_ssoTokenFileCache = ssoTokenFileCache;
			_inMemoryCache = new InMemoryCache();
		}

		protected virtual ICoreAmazonSSO_Logout CreateSSOLogoutClient(string region, IWebProxy proxySettings = null)
		{
			return SSOServiceClientHelpers.BuildSSOLogoutClient(RegionEndpoint.GetBySystemName(region), proxySettings);
		}

		protected virtual ICoreAmazonSSOOIDC_V2 CreateSSOOIDC_V2Client(string region, IWebProxy proxySettings = null)
		{
			return SSOServiceClientHelpers.BuildSSOIDC_V2Client(RegionEndpoint.GetBySystemName(region), proxySettings);
		}

		public async Task<SsoToken> GetTokenAsync(SSOTokenManagerGetTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			CacheState inMemoryToken = null;
			if (AWSConfigs.UseSdkCache && _inMemoryCache.TryGetValue(options, out inMemoryToken) && !inMemoryToken.Token.NeedsRefresh())
			{
				_logger.DebugFormat("In Memory cache has SSOToken for [" + options.StartUrl + "]");
				return inMemoryToken.Token;
			}
			TryResponse<SsoToken> tryResponse = await _ssoTokenFileCache.TryGetSsoTokenAsync(options, options.CacheFolderLocation, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (tryResponse.Success)
			{
				_logger.DebugFormat("File cache has SSOToken for [" + options.StartUrl + "]");
				SsoToken ssoToken = tryResponse.Value;
				if (!ssoToken.NeedsRefresh())
				{
					CacheState newInMemoryToken = new CacheState
					{
						Token = ssoToken,
						RefreshState = new RefreshState()
					};
					if (AWSConfigs.UseSdkCache)
					{
						_inMemoryCache.AddOrUpdate(options, newInMemoryToken);
					}
					return ssoToken;
				}
				if (ssoToken.CanRefresh())
				{
					_logger.DebugFormat("File cache SSOToken for [" + options.StartUrl + "] needs refresh");
					if (inMemoryToken?.RefreshState.FailedLastRefreshAttempt == true && ssoToken.IsExpired())
					{
						throw new AmazonClientException("SSO Token has expired and can not be refreshed");
					}
					if (ssoToken.RegisteredClientExpired() && options.SupportsGettingNewToken)
					{
						return await GenerateNewTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					if (inMemoryToken?.RefreshState.IsInRefreshCoolDown() == true)
					{
						if (!ssoToken.IsExpired())
						{
							return ssoToken;
						}
						if (options.SupportsGettingNewToken)
						{
							return await GenerateNewTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						throw new AmazonClientException("SSO Token has expired and can not be refreshed");
					}
					try
					{
						_logger.DebugFormat("Refreshing SSOToken for [" + options.Session + "]");
						SsoToken newToken = MapGetSsoTokenResponseToSsoToken(await _ssooidcClient.RefreshTokenAsync(MapSsoTokenToGetSsoTokenResponse(ssoToken)).ConfigureAwait(continueOnCapturedContext: false), options.Session);
						await _ssoTokenFileCache.SaveSsoTokenAsync(newToken, options.CacheFolderLocation, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						CacheState newInMemoryToken2 = new CacheState
						{
							Token = newToken,
							RefreshState = new RefreshState()
						};
						if (AWSConfigs.UseSdkCache)
						{
							_inMemoryCache.AddOrUpdate(options, newInMemoryToken2);
						}
						return newToken;
					}
					catch (Exception ex)
					{
						_logger.Error(ex, "Refreshing SSOToken for [" + options.Session + "] failed: " + ex.Message.Replace("{", "{{").Replace("}", "}}"));
						if (ssoToken.IsExpired() && options.SupportsGettingNewToken)
						{
							return await GenerateNewTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						if (!ssoToken.IsExpired())
						{
							CacheState newInMemoryToken3 = new CacheState
							{
								Token = ssoToken,
								RefreshState = new RefreshState
								{
									FailedLastRefreshAttempt = true,
									BlockRefreshUntil = AWSSDKUtils.CorrectedUtcNow.AddSeconds(30.0)
								}
							};
							if (AWSConfigs.UseSdkCache)
							{
								_inMemoryCache.AddOrUpdate(options, newInMemoryToken3);
							}
							return ssoToken;
						}
						throw new AmazonClientException("SSO Token has expired and failed to refresh", ex);
					}
				}
				if (ssoToken.IsExpired())
				{
					if (options.SupportsGettingNewToken)
					{
						return await GenerateNewTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					throw new AmazonClientException("SSO Token has expired and can not be refreshed");
				}
				return ssoToken;
			}
			if (options.SupportsGettingNewToken)
			{
				return await GenerateNewTokenAsync(options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			throw new AmazonClientException("No valid SSO Token could be found.");
		}

		public async Task LogoutAsync(string ssoCacheDirectory = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			foreach (SSOTokenFile cachedFileToken in await _ssoTokenFileCache.ScanSsoTokensAsync(ssoCacheDirectory, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				_ssoTokenFileCache.DeleteSsoToken(cachedFileToken.SsoTokenFilePath);
				if (cachedFileToken.SsoToken.Region != null)
				{
					try
					{
						await CreateSSOLogoutClient(cachedFileToken.SsoToken.Region).LogoutAsync(cachedFileToken.SsoToken.AccessToken, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception exception)
					{
						_logger.Error(exception, "Unable to Logout cached sso token from {0}", cachedFileToken.SsoTokenFilePath);
					}
				}
			}
		}

		public async Task LogoutAsync(SSOTokenManagerGetTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			TryResponse<SsoToken> tryResponse = await _ssoTokenFileCache.TryGetSsoTokenAsync(options, options.CacheFolderLocation, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (tryResponse.Success)
			{
				_logger.DebugFormat("File cache has SSOToken for [" + options.StartUrl + "]");
				SsoToken value = tryResponse.Value;
				_ssoTokenFileCache.DeleteSsoToken(options, options.CacheFolderLocation);
				try
				{
					await CreateSSOLogoutClient(options.Region).LogoutAsync(value.AccessToken, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				catch (Exception exception)
				{
					_logger.Error(exception, "Unable to Logout cached sso token for [" + options.StartUrl + "]");
					return;
				}
			}
			_logger.DebugFormat("No cached sso token found for [" + options.StartUrl + "]");
		}

		private async Task<SsoToken> GenerateNewTokenAsync(SSOTokenManagerGetTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			List<string> emptySSOTokenOptions = GetEmptySSOTokenOptions(options);
			if (emptySSOTokenOptions.Count > 0)
			{
				throw new AmazonClientException("Error generating new SSO token. Options properties cannot be empty: " + string.Join(", ", emptySSOTokenOptions));
			}
			GetSsoTokenRequest getSsoTokenRequest = new GetSsoTokenRequest
			{
				ClientName = GetSsoClientName(options.ClientName),
				ClientType = options.ClientType,
				StartUrl = options.StartUrl,
				SsoVerificationCallback = options.SsoVerificationCallback,
				Scopes = options.Scopes,
				PkceFlowOptions = options.PkceFlowOptions
			};
			ICoreAmazonSSOOIDC_V2 coreAmazonSSOOIDC_V = CreateSSOOIDC_V2Client(options.Region);
			GetSsoTokenResponse response = ((coreAmazonSSOOIDC_V == null) ? (await _ssooidcClient.GetSsoTokenAsync(getSsoTokenRequest).ConfigureAwait(continueOnCapturedContext: false)) : (await coreAmazonSSOOIDC_V.GetSsoTokenAsync(getSsoTokenRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
			SsoToken token = MapGetSsoTokenResponseToSsoToken(response, options.Session);
			await _ssoTokenFileCache.SaveSsoTokenAsync(token, options.CacheFolderLocation, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return token;
		}

		private static List<string> GetEmptySSOTokenOptions(SSOTokenManagerGetTokenOptions options)
		{
			List<string> list = new List<string>();
			if (string.IsNullOrEmpty(options.ClientName))
			{
				list.Add("ClientName");
			}
			if (options.PkceFlowOptions == null)
			{
				if (options.SsoVerificationCallback == null)
				{
					list.Add("SsoVerificationCallback");
				}
			}
			else if (options.PkceFlowOptions.RetrieveAuthorizationCodeCallbackAsync == null)
			{
				list.Add("RetrieveAuthorizationCodeCallbackAsync");
			}
			return list;
		}

		private static SsoToken MapGetSsoTokenResponseToSsoToken(GetSsoTokenResponse response, string session)
		{
			return new SsoToken
			{
				AccessToken = response.AccessToken,
				Region = response.Region,
				RefreshToken = response.RefreshToken,
				ClientId = response.ClientId,
				ClientSecret = response.ClientSecret,
				RegistrationExpiresAt = response.RegistrationExpiresAt,
				ExpiresAt = response.ExpiresAt,
				StartUrl = response.StartUrl,
				Session = session
			};
		}

		private static GetSsoTokenResponse MapSsoTokenToGetSsoTokenResponse(SsoToken token)
		{
			return new GetSsoTokenResponse
			{
				AccessToken = token.AccessToken,
				Region = token.Region,
				RefreshToken = token.RefreshToken,
				ClientId = token.ClientId,
				ClientSecret = token.ClientSecret,
				RegistrationExpiresAt = token.RegistrationExpiresAt,
				ExpiresAt = token.ExpiresAt,
				StartUrl = token.StartUrl
			};
		}

		private static string GetSsoClientName(string clientName)
		{
			string text = AWSSDKUtils.ConvertToUnixEpochSecondsString(AWSSDKUtils.CorrectedUtcNow);
			return clientName + "-" + text;
		}
	}
}
