using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Http;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2
{
	public sealed class ImpersonatedCredential : ServiceCredential, IOidcTokenProvider, IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor, IBlobSigner
	{
		public new sealed class Initializer : ServiceCredential.Initializer
		{
			private static readonly TimeSpan DefaultLifetime = TimeSpan.FromHours(1.0);

			public string TargetPrincipal { get; }

			public IEnumerable<string> DelegateAccounts { get; set; }

			public TimeSpan Lifetime { get; set; } = DefaultLifetime;

			internal bool HasCustomTokenUrl { get; }

			public Initializer(string targetPrincipal)
				: base(GetDefaultTokenUrl(targetPrincipal.ThrowIfNull("targetPrincipal")))
			{
				TargetPrincipal = targetPrincipal;
			}

			internal Initializer(string customTokenUrl, string maybeTargetPrincipal)
				: base(customTokenUrl.ThrowIfNullOrEmpty("customTokenUrl"))
			{
				TargetPrincipal = maybeTargetPrincipal;
				HasCustomTokenUrl = maybeTargetPrincipal == null || GetDefaultTokenUrl(maybeTargetPrincipal) != customTokenUrl;
			}

			internal Initializer(ImpersonatedCredential other)
				: base(other)
			{
				TargetPrincipal = other.TargetPrincipal;
				DelegateAccounts = other.DelegateAccounts;
				Lifetime = other.Lifetime;
				HasCustomTokenUrl = other.HasCustomTokenUrl;
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				TargetPrincipal = other.TargetPrincipal;
				DelegateAccounts = other.DelegateAccounts?.ToList().AsReadOnly() ?? Enumerable.Empty<string>();
				Lifetime = other.Lifetime;
				HasCustomTokenUrl = other.HasCustomTokenUrl;
			}

			private static string GetDefaultTokenUrl(string targetPrincipal)
			{
				return string.Format(GoogleAuthConsts.IamAccessTokenEndpointFormatString, targetPrincipal);
			}
		}

		public GoogleCredential SourceCredential => base.HttpClientInitializers.OfType<GoogleCredential>().Single();

		public string TargetPrincipal { get; }

		public IEnumerable<string> DelegateAccounts { get; }

		public TimeSpan Lifetime { get; }

		bool IGoogleCredential.HasExplicitScopes => base.Scopes?.Any() ?? false;

		bool IGoogleCredential.SupportsExplicitScopes => true;

		internal bool HasCustomTokenUrl { get; }

		internal static ImpersonatedCredential Create(GoogleCredential sourceCredential, Initializer initializer)
		{
			initializer.ThrowIfNull("initializer");
			sourceCredential.ThrowIfNull("sourceCredential");
			if (initializer.Lifetime < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("Lifetime", "Must be greater or equal to Zero");
			}
			if (!(sourceCredential.UnderlyingCredential is ServiceAccountCredential) && !(sourceCredential.UnderlyingCredential is UserCredential) && !(sourceCredential.UnderlyingCredential is ExternalAccountCredential) && !(sourceCredential.UnderlyingCredential is ComputeCredential))
			{
				throw new InvalidOperationException("Only ServiceAccountCredential,UserCredential, ExternalAccountCredential and ComputeCredential support impersonation.");
			}
			if (sourceCredential.UnderlyingCredential is ExternalAccountCredential { ServiceAccountImpersonationUrl: not null })
			{
				throw new InvalidOperationException("Only ExternalAccountCredentials that have no impersonation configured via service_account_impersonation_url support explicit impersonation.");
			}
			initializer = new Initializer(initializer);
			initializer.HttpClientInitializers.Add(sourceCredential.CreateScoped("https://www.googleapis.com/auth/iam"));
			return new ImpersonatedCredential(initializer);
		}

		private ImpersonatedCredential(Initializer initializer)
			: base(initializer)
		{
			TargetPrincipal = initializer.TargetPrincipal;
			DelegateAccounts = initializer.DelegateAccounts;
			Lifetime = initializer.Lifetime;
			HasCustomTokenUrl = initializer.HasCustomTokenUrl;
		}

		IGoogleCredential IGoogleCredential.WithQuotaProject(string quotaProject)
		{
			return new ImpersonatedCredential(new Initializer(this)
			{
				QuotaProject = quotaProject
			});
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return new ImpersonatedCredential(new Initializer(this)
			{
				Scopes = scopes
			});
		}

		IGoogleCredential IGoogleCredential.WithUserForDomainWideDelegation(string user)
		{
			throw new InvalidOperationException("ImpersonatedCredential does not support Domain-Wide Delegation");
		}

		IGoogleCredential IGoogleCredential.WithHttpClientFactory(IHttpClientFactory httpClientFactory)
		{
			return new ImpersonatedCredential(new Initializer(this)
			{
				HttpClientFactory = httpClientFactory
			});
		}

		public override async Task<bool> RequestAccessTokenAsync(CancellationToken taskCancellationToken)
		{
			base.Token = await new ImpersonationAccessTokenRequest
			{
				DelegateAccounts = DelegateAccounts,
				Scopes = base.Scopes,
				Lifetime = $"{(int)Lifetime.TotalSeconds}s"
			}.PostJsonAsync(base.HttpClient, base.TokenServerUrl, base.Clock, ServiceCredential.Logger, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public Task<OidcToken> GetOidcTokenAsync(OidcTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			ThrowIfCustomTokenUrl();
			options.ThrowIfNull("options");
			TokenRefreshManager tokenRefreshManager = null;
			tokenRefreshManager = new TokenRefreshManager((CancellationToken ct) => RefreshOidcTokenAsync(tokenRefreshManager, options, ct), base.Clock, ServiceCredential.Logger);
			return Task.FromResult(new OidcToken(tokenRefreshManager));
		}

		private async Task<bool> RefreshOidcTokenAsync(TokenRefreshManager caller, OidcTokenOptions oidcTokenOptions, CancellationToken cancellationToken)
		{
			ThrowIfCustomTokenUrl();
			ImpersonationOIdCTokenRequest request = new ImpersonationOIdCTokenRequest
			{
				DelegateAccounts = DelegateAccounts,
				Audience = oidcTokenOptions.TargetAudience,
				IncludeEmail = true
			};
			string url = string.Format(GoogleAuthConsts.IamIdTokenEndpointFormatString, TargetPrincipal);
			caller.Token = await request.PostJsonAsync(base.HttpClient, url, base.Clock, ServiceCredential.Logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public async Task<string> SignBlobAsync(byte[] blob, CancellationToken cancellationToken = default(CancellationToken))
		{
			ThrowIfCustomTokenUrl();
			return (await new IamSignBlobRequest
			{
				DelegateAccounts = DelegateAccounts,
				Payload = blob
			}.PostJsonAsync<IamSignBlobResponse>(url: string.Format(GoogleAuthConsts.IamSignEndpointFormatString, TargetPrincipal), httpClient: base.HttpClient, cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).SignedBlob;
		}

		private void ThrowIfCustomTokenUrl()
		{
			if (HasCustomTokenUrl)
			{
				throw new InvalidOperationException("Operation not supported when a custom access token URL has been specified.");
			}
		}

		internal static string ExtractTargetPrincipal(string url)
		{
			int num = url.LastIndexOf('/') + 1;
			if (num == 0 || num >= url.Length)
			{
				return null;
			}
			int num2 = url.IndexOf(":generateAccessToken", StringComparison.Ordinal);
			if (num2 == -1 || num2 <= num)
			{
				return null;
			}
			return url.Substring(num, num2 - num);
		}
	}
}
