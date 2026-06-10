using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Http;

namespace Google.Apis.Auth.OAuth2
{
	public abstract class ExternalAccountCredential : ServiceCredential
	{
		internal new abstract class Initializer : ServiceCredential.Initializer
		{
			internal string Audience { get; }

			internal string SubjectTokenType { get; }

			internal string ServiceAccountImpersonationUrl { get; set; }

			internal string WorkforcePoolUserProject { get; set; }

			internal string ClientId { get; set; }

			internal string ClientSecret { get; set; }

			internal string UniverseDomain { get; set; }

			internal Initializer(string tokenUrl, string audience, string subjectTokenType)
				: base(tokenUrl)
			{
				Audience = audience;
				SubjectTokenType = subjectTokenType;
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				Audience = other.Audience;
				SubjectTokenType = other.SubjectTokenType;
				ServiceAccountImpersonationUrl = other.ServiceAccountImpersonationUrl;
				WorkforcePoolUserProject = other.WorkforcePoolUserProject;
				ClientId = other.ClientId;
				ClientSecret = other.ClientSecret;
				UniverseDomain = other.UniverseDomain;
			}

			internal Initializer(ExternalAccountCredential other)
				: base(other)
			{
				Audience = other.Audience;
				SubjectTokenType = other.SubjectTokenType;
				ServiceAccountImpersonationUrl = other.ServiceAccountImpersonationUrl;
				WorkforcePoolUserProject = other.WorkforcePoolUserProject;
				ClientId = other.ClientId;
				ClientSecret = other.ClientSecret;
				UniverseDomain = other.UniverseDomain;
			}
		}

		private const string GrantType = "urn:ietf:params:oauth:grant-type:token-exchange";

		private const string RequestedTokenType = "urn:ietf:params:oauth:token-type:access_token";

		public string Audience { get; }

		public string SubjectTokenType { get; }

		public string ServiceAccountImpersonationUrl { get; }

		public string WorkforcePoolUserProject { get; }

		public string ClientId { get; }

		public string ClientSecret { get; }

		public string UniverseDomain { get; }

		private protected bool SupportsExplicitScopes => true;

		internal Lazy<GoogleCredential> WithoutImpersonationConfiguration { get; }

		internal Lazy<ImpersonatedCredential> ImplicitlyImpersonated { get; }

		internal ExternalAccountCredential(Initializer initializer)
			: base(initializer)
		{
			Audience = initializer.Audience;
			SubjectTokenType = initializer.SubjectTokenType;
			ServiceAccountImpersonationUrl = initializer.ServiceAccountImpersonationUrl;
			WorkforcePoolUserProject = initializer.WorkforcePoolUserProject;
			ClientId = initializer.ClientId;
			ClientSecret = initializer.ClientSecret;
			WithoutImpersonationConfiguration = new Lazy<GoogleCredential>(WithoutImpersonationConfigurationImpl, LazyThreadSafetyMode.ExecutionAndPublication);
			ImplicitlyImpersonated = new Lazy<ImpersonatedCredential>(ImplicitlyImpersonatedImpl, LazyThreadSafetyMode.ExecutionAndPublication);
			UniverseDomain = initializer.UniverseDomain ?? "googleapis.com";
		}

		private protected abstract GoogleCredential WithoutImpersonationConfigurationImpl();

		private protected ImpersonatedCredential ImplicitlyImpersonatedImpl()
		{
			if (ServiceAccountImpersonationUrl == null)
			{
				return null;
			}
			ImpersonatedCredential.Initializer initializer = new ImpersonatedCredential.Initializer(ServiceAccountImpersonationUrl, ImpersonatedCredential.ExtractTargetPrincipal(ServiceAccountImpersonationUrl))
			{
				AccessMethod = base.AccessMethod,
				Clock = base.Clock,
				DefaultExponentialBackOffPolicy = base.DefaultExponentialBackOffPolicy,
				HttpClientFactory = base.HttpClientFactory,
				QuotaProject = base.QuotaProject,
				Scopes = base.Scopes
			};
			foreach (IConfigurableHttpClientInitializer httpClientInitializer in base.HttpClientInitializers)
			{
				initializer.HttpClientInitializers.Add(httpClientInitializer);
			}
			return ImpersonatedCredential.Create(WithoutImpersonationConfiguration.Value, initializer);
		}

		protected abstract Task<string> GetSubjectTokenAsyncImpl(CancellationToken taskCancellationToken);

		private async Task<string> GetSubjectTokenAsync(CancellationToken taskCancellationTokne)
		{
			try
			{
				return await GetSubjectTokenAsyncImpl(taskCancellationTokne).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception innerException)
			{
				throw new SubjectTokenException(this, innerException);
			}
		}

		private protected async Task<TokenResponse> RequestStsAccessTokenAsync(CancellationToken taskCancellationToken)
		{
			StsTokenRequestBuilder stsTokenRequestBuilder = new StsTokenRequestBuilder
			{
				Audience = Audience,
				GrantType = "urn:ietf:params:oauth:grant-type:token-exchange",
				RequestedTokenType = "urn:ietf:params:oauth:token-type:access_token",
				Scopes = base.Scopes
			};
			StsTokenRequestBuilder stsTokenRequestBuilder2 = stsTokenRequestBuilder;
			stsTokenRequestBuilder2.SubjectToken = await GetSubjectTokenAsync(taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			stsTokenRequestBuilder.SubjectTokenType = SubjectTokenType;
			stsTokenRequestBuilder.WorkforcePoolUserProject = WorkforcePoolUserProject;
			stsTokenRequestBuilder.ClientId = ClientId;
			stsTokenRequestBuilder.ClientSecret = ClientSecret;
			StsTokenRequest stsTokenRequest = stsTokenRequestBuilder.Build();
			return await stsTokenRequest.PostFormAsync(base.HttpClient, base.TokenServerUrl, stsTokenRequest.AuthenticationHeader, base.Clock, ServiceCredential.Logger, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override async Task<bool> RequestAccessTokenAsync(CancellationToken taskCancellationToken)
		{
			ImpersonatedCredential impersonated = ImplicitlyImpersonated.Value;
			if (impersonated == null)
			{
				base.Token = await RequestStsAccessTokenAsync(taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return true;
			}
			if (await impersonated.RequestAccessTokenAsync(taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				base.Token = impersonated.Token;
				return true;
			}
			return false;
		}

		private protected IGoogleCredential WithUserForDomainWideDelegation(string user)
		{
			throw new InvalidOperationException("ExternalAccountCredential does not support Domain-Wide Delegation");
		}
	}
}
