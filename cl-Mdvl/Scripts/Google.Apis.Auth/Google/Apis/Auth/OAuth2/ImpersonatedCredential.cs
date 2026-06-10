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

			public Initializer(string targetPrincipal)
				: base((string)null)
			{
				TargetPrincipal = targetPrincipal.ThrowIfNull("targetPrincipal");
			}

			internal Initializer(string customTokenUrl, string maybeTargetPrincipal)
				: base(customTokenUrl.ThrowIfNullOrEmpty("customTokenUrl"))
			{
				TargetPrincipal = maybeTargetPrincipal;
			}

			internal Initializer(ImpersonatedCredential other)
				: base(other)
			{
				TargetPrincipal = other.TargetPrincipal;
				DelegateAccounts = other.DelegateAccounts;
				Lifetime = other.Lifetime;
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				TargetPrincipal = other.TargetPrincipal;
				DelegateAccounts = other.DelegateAccounts?.ToList().AsReadOnly() ?? Enumerable.Empty<string>();
				Lifetime = other.Lifetime;
			}
		}

		private readonly Lazy<Task<string>> _oidcTokenUrlCache;

		private readonly Lazy<Task<string>> _signBlobUrlCache;

		public GoogleCredential SourceCredential => base.HttpClientInitializers.OfType<GoogleCredential>().Single();

		public string TargetPrincipal { get; }

		public IEnumerable<string> DelegateAccounts { get; }

		public TimeSpan Lifetime { get; }

		internal Lazy<Task<bool>> HasCustomTokenUrlCache { get; }

		internal Lazy<Task<string>> EffectiveTokenUrlCache { get; }

		bool IGoogleCredential.HasExplicitScopes => base.Scopes?.Any() ?? false;

		bool IGoogleCredential.SupportsExplicitScopes => true;

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
			EffectiveTokenUrlCache = new Lazy<Task<string>>(GetEffectiveTokenUrlUncachedAsync);
			HasCustomTokenUrlCache = new Lazy<Task<bool>>(HasCustomTokenUrlUncachedAsync);
			_oidcTokenUrlCache = new Lazy<Task<string>>(GetIdTokenUrlUncachedAsync);
			_signBlobUrlCache = new Lazy<Task<string>>(GetSignBlobUrlUncachedAsync);
		}

		Task<string> IGoogleCredential.GetUniverseDomainAsync(CancellationToken cancellationToken)
		{
			return SourceCredential.GetUniverseDomainAsync(cancellationToken);
		}

		string IGoogleCredential.GetUniverseDomain()
		{
			return SourceCredential.GetUniverseDomain();
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

		IGoogleCredential IGoogleCredential.WithUniverseDomain(string universeDomain)
		{
			GoogleCredential sourceCredential = SourceCredential.CreateWithUniverseDomain(universeDomain);
			Initializer initializer = new Initializer(this);
			initializer.HttpClientInitializers.Remove(SourceCredential);
			return Create(sourceCredential, initializer);
		}

		public override async Task<bool> RequestAccessTokenAsync(CancellationToken taskCancellationToken)
		{
			ImpersonationAccessTokenRequest request = new ImpersonationAccessTokenRequest
			{
				DelegateAccounts = DelegateAccounts,
				Scopes = base.Scopes,
				Lifetime = $"{(int)Lifetime.TotalSeconds}s"
			};
			string url = await EffectiveTokenUrlCache.Value.WithCancellationToken(taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			base.Token = await request.PostJsonAsync(base.HttpClient, url, base.Clock, ServiceCredential.Logger, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public async Task<OidcToken> GetOidcTokenAsync(OidcTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			await ThrowIfCustomTokenUrlAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			options.ThrowIfNull("options");
			TokenRefreshManager tokenRefreshManager = null;
			tokenRefreshManager = new TokenRefreshManager((CancellationToken ct) => RefreshOidcTokenAsync(tokenRefreshManager, options, ct), base.Clock, ServiceCredential.Logger);
			return new OidcToken(tokenRefreshManager);
		}

		private async Task<bool> RefreshOidcTokenAsync(TokenRefreshManager caller, OidcTokenOptions oidcTokenOptions, CancellationToken cancellationToken)
		{
			await ThrowIfCustomTokenUrlAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			ImpersonationOIdCTokenRequest request = new ImpersonationOIdCTokenRequest
			{
				DelegateAccounts = DelegateAccounts,
				Audience = oidcTokenOptions.TargetAudience,
				IncludeEmail = true
			};
			string url = await _oidcTokenUrlCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			caller.Token = await request.PostJsonAsync(base.HttpClient, url, base.Clock, ServiceCredential.Logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public async Task<string> SignBlobAsync(byte[] blob, CancellationToken cancellationToken = default(CancellationToken))
		{
			await ThrowIfCustomTokenUrlAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			IamSignBlobRequest request = new IamSignBlobRequest
			{
				DelegateAccounts = DelegateAccounts,
				Payload = blob
			};
			string url = await _signBlobUrlCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return (await request.PostJsonAsync<IamSignBlobResponse>(base.HttpClient, url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).SignedBlob;
		}

		private async Task<string> GetEffectiveTokenUrlUncachedAsync()
		{
			if (base.TokenServerUrl != null)
			{
				return base.TokenServerUrl;
			}
			return GetDefaultTokenUrl(await ((IGoogleCredential)this).GetUniverseDomainAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false), TargetPrincipal);
		}

		private async Task<bool> HasCustomTokenUrlUncachedAsync()
		{
			return await EffectiveTokenUrlCache.Value.ConfigureAwait(continueOnCapturedContext: false) != GetDefaultTokenUrl(await ((IGoogleCredential)this).GetUniverseDomainAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false), TargetPrincipal);
		}

		private async Task<string> GetIdTokenUrlUncachedAsync()
		{
			await ThrowIfCustomTokenUrlAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false);
			return $"https://iamcredentials.{await ((IGoogleCredential)this).GetUniverseDomainAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false)}/v1/projects/-/serviceAccounts/{TargetPrincipal}:generateIdToken";
		}

		private async Task<string> GetSignBlobUrlUncachedAsync()
		{
			await ThrowIfCustomTokenUrlAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false);
			return $"https://iamcredentials.{await ((IGoogleCredential)this).GetUniverseDomainAsync(default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false)}/v1/projects/-/serviceAccounts/{TargetPrincipal}:signBlob";
		}

		private async Task ThrowIfCustomTokenUrlAsync(CancellationToken cancellationToken)
		{
			if (await HasCustomTokenUrlCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				throw new InvalidOperationException("Operation not supported when a custom access token URL has been specified.");
			}
		}

		private static string GetDefaultTokenUrl(string universeDomain, string targetPrincipal)
		{
			return $"https://iamcredentials.{universeDomain}/v1/projects/-/serviceAccounts/{targetPrincipal}:generateAccessToken";
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
