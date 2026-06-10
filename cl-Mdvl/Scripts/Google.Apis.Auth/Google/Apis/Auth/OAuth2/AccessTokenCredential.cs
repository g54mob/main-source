using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Http;

namespace Google.Apis.Auth.OAuth2
{
	internal class AccessTokenCredential : IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor
	{
		private readonly string _accessToken;

		private readonly IAccessMethod _accessMethod;

		private readonly string _universeDomain;

		public string QuotaProject { get; }

		bool IGoogleCredential.HasExplicitScopes => false;

		bool IGoogleCredential.SupportsExplicitScopes => false;

		public AccessTokenCredential(string accessToken, IAccessMethod accessMethod, string quotaProject = null, string universeDomain = null)
		{
			_accessToken = accessToken;
			_accessMethod = accessMethod;
			QuotaProject = quotaProject;
			_universeDomain = universeDomain ?? "googleapis.com";
		}

		Task<string> IGoogleCredential.GetUniverseDomainAsync(CancellationToken _)
		{
			return Task.FromResult(_universeDomain);
		}

		string IGoogleCredential.GetUniverseDomain()
		{
			return _universeDomain;
		}

		IGoogleCredential IGoogleCredential.WithQuotaProject(string quotaProject)
		{
			return new AccessTokenCredential(_accessToken, _accessMethod, quotaProject, _universeDomain);
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return this;
		}

		IGoogleCredential IGoogleCredential.WithUserForDomainWideDelegation(string user)
		{
			throw new InvalidOperationException("AccessTokenCredential does not support Domain-Wide Delegation");
		}

		IGoogleCredential IGoogleCredential.WithHttpClientFactory(IHttpClientFactory httpClientFactory)
		{
			return this;
		}

		IGoogleCredential IGoogleCredential.WithUniverseDomain(string universeDomain)
		{
			return new AccessTokenCredential(_accessToken, _accessMethod, QuotaProject, universeDomain);
		}

		public void Initialize(ConfigurableHttpClient httpClient)
		{
			httpClient.MessageHandler.Credential = this;
		}

		public Task<string> GetAccessTokenForRequestAsync(string authUri = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(_accessToken);
		}

		public Task<AccessTokenWithHeaders> GetAccessTokenWithHeadersForRequestAsync(string authUri = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.FromResult(new AccessTokenWithHeaders.Builder
			{
				QuotaProject = QuotaProject
			}.Build(_accessToken));
		}

		public Task InterceptAsync(HttpRequestMessage request, CancellationToken taskCancellationToken)
		{
			AccessTokenWithHeaders accessTokenWithHeaders = new AccessTokenWithHeaders.Builder
			{
				QuotaProject = QuotaProject
			}.Build(_accessToken);
			_accessMethod.Intercept(request, accessTokenWithHeaders.AccessToken);
			accessTokenWithHeaders.AddHeaders(request);
			return Task.FromResult(result: true);
		}
	}
}
