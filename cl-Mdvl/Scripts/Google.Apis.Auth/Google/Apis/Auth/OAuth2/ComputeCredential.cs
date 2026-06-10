using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Http;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2
{
	public class ComputeCredential : ServiceCredential, IOidcTokenProvider, IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor, IBlobSigner
	{
		public new class Initializer : ServiceCredential.Initializer
		{
			public string OidcTokenUrl { get; }

			internal string UniverseDomain { get; set; }

			public Initializer()
				: this(GoogleAuthConsts.EffectiveComputeTokenUrl)
			{
			}

			public Initializer(string tokenUrl)
				: this(tokenUrl, GoogleAuthConsts.EffectiveComputeOidcTokenUrl)
			{
			}

			public Initializer(string tokenUrl, string oidcTokenUrl)
				: base(tokenUrl)
			{
				OidcTokenUrl = oidcTokenUrl;
			}

			internal Initializer(ComputeCredential other)
				: base(other)
			{
				OidcTokenUrl = other.OidcTokenUrl;
				UniverseDomain = other.ExplicitUniverseDomain;
			}
		}

		public const string MetadataServerUrl = "http://169.254.169.254";

		private static readonly Lazy<Task<bool>> isRunningOnComputeEngineCache = new Lazy<Task<bool>>(IsRunningOnComputeEngineUncachedAsync);

		private static readonly Lazy<Task<string>> computeEngineUniverseDomainCache = new Lazy<Task<string>>(GetComputeEngineUniverseDomainUncachedAsync);

		private const int MetadataServerPingTimeoutInMilliseconds = 500;

		private const int MetadataServerPingAttempts = 3;

		internal const string MetadataFlavor = "Metadata-Flavor";

		internal const string GoogleMetadataHeader = "Google";

		private readonly Lazy<Task<string>> _defaultServiceAccountEmailCache;

		private readonly Lazy<ConfigurableHttpClient> _authenticatedHttpClient;

		public string OidcTokenUrl { get; }

		internal string ExplicitUniverseDomain { get; }

		bool IGoogleCredential.HasExplicitScopes => base.HasExplicitScopes;

		bool IGoogleCredential.SupportsExplicitScopes => true;

		internal string EffectiveTokenServerUrl { get; }

		public ComputeCredential()
			: this(new Initializer())
		{
		}

		public ComputeCredential(Initializer initializer)
			: base(initializer)
		{
			OidcTokenUrl = initializer.OidcTokenUrl;
			ExplicitUniverseDomain = initializer.UniverseDomain;
			if (base.HasExplicitScopes)
			{
				UriBuilder uriBuilder = new UriBuilder(base.TokenServerUrl);
				string text = "scopes=" + string.Join(",", base.Scopes);
				if (uriBuilder.Query == null || uriBuilder.Query.Length <= 1)
				{
					uriBuilder.Query = text;
				}
				else
				{
					uriBuilder.Query = uriBuilder.Query.Substring(1) + "&" + text;
				}
				EffectiveTokenServerUrl = uriBuilder.Uri.AbsoluteUri;
			}
			else
			{
				EffectiveTokenServerUrl = base.TokenServerUrl;
			}
			_defaultServiceAccountEmailCache = new Lazy<Task<string>>(FetchDefaultServiceAccountEmailAsync, LazyThreadSafetyMode.ExecutionAndPublication);
			_authenticatedHttpClient = new Lazy<ConfigurableHttpClient>(BuildAuthenticatedHttpClient, LazyThreadSafetyMode.ExecutionAndPublication);
		}

		async Task<string> IGoogleCredential.GetUniverseDomainAsync(CancellationToken cancellationToken)
		{
			string text = ExplicitUniverseDomain;
			if (text == null)
			{
				text = await computeEngineUniverseDomainCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return text;
		}

		string IGoogleCredential.GetUniverseDomain()
		{
			return ExplicitUniverseDomain ?? Task.Run(() => computeEngineUniverseDomainCache.Value).Result;
		}

		IGoogleCredential IGoogleCredential.WithQuotaProject(string quotaProject)
		{
			return new ComputeCredential(new Initializer(this)
			{
				QuotaProject = quotaProject
			});
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return new ComputeCredential(new Initializer(this)
			{
				Scopes = scopes
			});
		}

		IGoogleCredential IGoogleCredential.WithUserForDomainWideDelegation(string user)
		{
			throw new InvalidOperationException("ComputeCredential does not support Domain-Wide Delegation");
		}

		IGoogleCredential IGoogleCredential.WithHttpClientFactory(IHttpClientFactory httpClientFactory)
		{
			return new ComputeCredential(new Initializer(this)
			{
				HttpClientFactory = httpClientFactory
			});
		}

		IGoogleCredential IGoogleCredential.WithUniverseDomain(string universeDomain)
		{
			return new ComputeCredential(new Initializer(this)
			{
				UniverseDomain = universeDomain
			});
		}

		public Task<string> GetDefaultServiceAccountEmailAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.Run(() => _defaultServiceAccountEmailCache.Value, cancellationToken);
		}

		public override async Task<bool> RequestAccessTokenAsync(CancellationToken taskCancellationToken)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, EffectiveTokenServerUrl);
			httpRequestMessage.Headers.Add("Metadata-Flavor", "Google");
			base.Token = await TokenResponse.FromHttpResponseAsync(await base.HttpClient.SendAsync(httpRequestMessage, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false), base.Clock, ServiceCredential.Logger).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public Task<OidcToken> GetOidcTokenAsync(OidcTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			options.ThrowIfNull("options");
			TokenRefreshManager tokenRefreshManager = null;
			tokenRefreshManager = new TokenRefreshManager((CancellationToken ct) => RefreshOidcTokenAsync(tokenRefreshManager, options, ct), base.Clock, ServiceCredential.Logger);
			return Task.FromResult(new OidcToken(tokenRefreshManager));
		}

		private async Task<bool> RefreshOidcTokenAsync(TokenRefreshManager caller, OidcTokenOptions options, CancellationToken cancellationToken)
		{
			string text = OidcTokenUrl + "?audience=" + options.TargetAudience;
			if (options.TokenFormat == OidcTokenFormat.Full || options.TokenFormat == OidcTokenFormat.FullWithLicences)
			{
				text += "&format=full";
				if (options.TokenFormat == OidcTokenFormat.FullWithLicences)
				{
					text += "&licenses=true";
				}
			}
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, text);
			httpRequestMessage.Headers.Add("Metadata-Flavor", "Google");
			caller.Token = await TokenResponse.FromHttpResponseAsync(await base.HttpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), base.Clock, ServiceCredential.Logger).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public async Task<string> SignBlobAsync(byte[] blob, CancellationToken cancellationToken = default(CancellationToken))
		{
			IamSignBlobRequest request = new IamSignBlobRequest
			{
				Payload = blob
			};
			string url = string.Format(arg1: await GetDefaultServiceAccountEmailAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), format: "https://iamcredentials.{0}/v1/projects/-/serviceAccounts/{1}:signBlob", arg0: await ((IGoogleCredential)this).GetUniverseDomainAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			return (await request.PostJsonAsync<IamSignBlobResponse>(_authenticatedHttpClient.Value, url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).SignedBlob;
		}

		private async Task<string> FetchDefaultServiceAccountEmailAsync()
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, GoogleAuthConsts.EffectiveComputeDefaultServiceAccountEmailUrl);
			httpRequestMessage.Headers.Add("Metadata-Flavor", "Google");
			HttpResponseMessage obj = await base.HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);
			obj.EnsureSuccessStatusCode();
			return await obj.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		private ConfigurableHttpClient BuildAuthenticatedHttpClient()
		{
			CreateHttpClientArgs createHttpClientArgs = BuildCreateHttpClientArgs();
			IGoogleCredential item = ((IGoogleCredential)this).MaybeWithScopes((IEnumerable<string>)new string[1] { "https://www.googleapis.com/auth/iam" });
			createHttpClientArgs.Initializers.Add(item);
			return base.HttpClientFactory.CreateHttpClient(createHttpClientArgs);
		}

		public static Task<bool> IsRunningOnComputeEngine()
		{
			return isRunningOnComputeEngineCache.Value;
		}

		private static async Task<bool> IsRunningOnComputeEngineUncachedAsync()
		{
			bool flag = await IsMetadataServerAvailableAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (!flag)
			{
				flag = await IsGoogleBiosAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			return flag;
		}

		private static async Task<bool> IsMetadataServerAvailableAsync()
		{
			ServiceCredential.Logger.Info("Checking connectivity to ComputeEngine metadata server.");
			using (HttpClient httpClient = new HttpClient())
			{
				for (int i = 0; i < 3; i++)
				{
					CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
					cancellationTokenSource.CancelAfter(500);
					try
					{
						HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, GoogleAuthConsts.EffectiveMetadataServerUrl);
						httpRequestMessage.Headers.Add("Metadata-Flavor", "Google");
						if ((await httpClient.SendAsync(httpRequestMessage, cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false)).Headers.TryGetValues("Metadata-Flavor", out var values) && values.Contains("Google"))
						{
							return true;
						}
						ServiceCredential.Logger.Info("Response came from a source other than the Google Compute Engine metadata server.");
						return false;
					}
					catch (Exception ex) when (ex is HttpRequestException || ex is WebException || ex is OperationCanceledException)
					{
						ServiceCredential.Logger.Debug("An exception ocurred while attempting to reach Google's metadata service on attempt {0}. A total of {1} attempts will be made. The exception was: {2}.", i + 1, 3, ex);
					}
				}
			}
			ServiceCredential.Logger.Debug("Could not reach the Google Compute Engine metadata service. That is expected if this application is not running on GCE or on some cases where the metadata service is not available during application startup.");
			return false;
		}

		private static async Task<bool> IsGoogleBiosAsync()
		{
			ServiceCredential.Logger.Info("Checking BIOS values to determine GCE residency.");
			try
			{
				if (IsLinux())
				{
					return await IsLinuxGoogleBiosAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				if (IsWindows())
				{
					return IsWindowsGoogleBios();
				}
				ServiceCredential.Logger.Info("GCE residency detection through BIOS checking is only supported on Windows and Linux platforms.");
				return false;
			}
			catch (Exception arg)
			{
				ServiceCredential.Logger.Debug($"Could not read BIOS: {arg}");
				return false;
			}
			static bool IsLinux()
			{
				return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
			}
			static async Task<bool> IsLinuxGoogleBiosAsync()
			{
				ServiceCredential.Logger.Info("Checking BIOS values on Linux.");
				string text = "/sys/class/dmi/id/product_name";
				if (!File.Exists(text))
				{
					ServiceCredential.Logger.Debug("Couldn't read file " + text + " containing BIOS mapped values.");
					return false;
				}
				string text2;
				using (StreamReader streamReader = new StreamReader(new FileStream("/sys/class/dmi/id/product_name", FileMode.Open, FileAccess.Read)))
				{
					text2 = await streamReader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				text2 = text2?.Trim();
				return text2 == "Google" || text2 == "Google Compute Engine";
			}
			static bool IsWindows()
			{
				return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
			}
			static bool IsWindowsGoogleBios()
			{
				ServiceCredential.Logger.Info("Checking BIOS values on Windows.");
				using ManagementObjectCollection managementObjectCollection = new ManagementClass("Win32_BIOS").GetInstances();
				bool flag = false;
				foreach (ManagementBaseObject item in managementObjectCollection)
				{
					using (item)
					{
						try
						{
							flag = flag || item["Manufacturer"]?.ToString() == "Google";
						}
						catch (Exception arg2)
						{
							ServiceCredential.Logger.Debug($"Error checking Win32_BIOS management object: {arg2}.");
						}
					}
				}
				if (!flag)
				{
					ServiceCredential.Logger.Debug("No Win32_BIOS management object found.");
				}
				return flag;
			}
		}

		private static async Task<string> GetComputeEngineUniverseDomainUncachedAsync()
		{
			ServiceCredential.Logger.Info("Attempting to fetch the universe domain from the metadata server.");
			using (HttpClient httpClient = new HttpClient())
			{
				int attempts = 0;
				TimeSpan[] refreshTimeouts = TokenRefreshManager.RefreshTimeouts;
				Unsafe.SkipInit(out HttpResponseMessage httpResponseMessage);
				foreach (TimeSpan delay in refreshTimeouts)
				{
					attempts++;
					CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(delay);
					HttpResponseMessage response = null;
					try
					{
						HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, GoogleAuthConsts.EffectiveComputeUniverDomainUrl);
						httpRequestMessage.Headers.Add("Metadata-Flavor", "Google");
						response = await httpClient.SendAsync(httpRequestMessage, cancellationTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false);
						response.EnsureSuccessStatusCode();
						return await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception) when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						httpResponseMessage = response;
						return httpResponseMessage != null && httpResponseMessage.StatusCode == HttpStatusCode.NotFound;
					}).Invoke())
					{
						ServiceCredential.Logger.Info($"The metadata server replied {HttpStatusCode.NotFound} when attempting to fetch the universe domain. " + "Assuming default univer domain.");
						return "googleapis.com";
					}
					catch (OperationCanceledException)
					{
						ServiceCredential.Logger.Debug($"Fetching the universe domain from the metadata server timed out on attempt number {attempts} " + $"out of a total of {TokenRefreshManager.RefreshTimeouts.Length} attempts.");
						if (attempts == TokenRefreshManager.RefreshTimeouts.Length)
						{
							throw;
						}
					}
				}
			}
			throw new InvalidOperationException("There's a bug in code. We should never reach this point.");
		}
	}
}
