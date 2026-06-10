using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Http;
using Google.Apis.Json;

namespace Google.Apis.Auth.OAuth2
{
	public sealed class UrlSourcedExternalAccountCredential : ExternalAccountCredential, IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor
	{
		internal new class Initializer : ExternalAccountCredential.Initializer
		{
			internal string SubjectTokenUrl { get; }

			internal IDictionary<string, string> Headers { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			internal string SubjectTokenJsonFieldName { get; set; }

			internal Initializer(string tokenUrl, string audience, string subjectTokenType, string subjectTokenUrl)
				: base(tokenUrl, audience, subjectTokenType)
			{
				SubjectTokenUrl = subjectTokenUrl;
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				SubjectTokenUrl = other.SubjectTokenUrl;
				Headers = ((other.Headers == null) ? null : new Dictionary<string, string>(other.Headers, StringComparer.OrdinalIgnoreCase));
				SubjectTokenJsonFieldName = other.SubjectTokenJsonFieldName;
			}

			internal Initializer(UrlSourcedExternalAccountCredential other)
				: base(other)
			{
				SubjectTokenUrl = other.SubjectTokenUrl;
				Headers = ((other.Headers == null) ? null : new Dictionary<string, string>(other.Headers.ToDictionary((KeyValuePair<string, string> pair) => pair.Key, (KeyValuePair<string, string> pair) => pair.Value, StringComparer.OrdinalIgnoreCase)));
				SubjectTokenJsonFieldName = other.SubjectTokenJsonFieldName;
			}
		}

		public string SubjectTokenUrl { get; }

		public IReadOnlyDictionary<string, string> Headers { get; }

		public string SubjectTokenJsonFieldName { get; }

		string IGoogleCredential.QuotaProject => base.QuotaProject;

		bool IGoogleCredential.HasExplicitScopes => base.HasExplicitScopes;

		bool IGoogleCredential.SupportsExplicitScopes => base.SupportsExplicitScopes;

		internal UrlSourcedExternalAccountCredential(Initializer initializer)
			: base(initializer)
		{
			SubjectTokenUrl = initializer.SubjectTokenUrl;
			Headers = ((initializer.Headers == null) ? new ReadOnlyDictionary<string, string>(new Dictionary<string, string>()) : new ReadOnlyDictionary<string, string>(initializer.Headers));
			SubjectTokenJsonFieldName = initializer.SubjectTokenJsonFieldName;
		}

		private protected override GoogleCredential WithoutImpersonationConfigurationImpl()
		{
			if (base.ServiceAccountImpersonationUrl != null)
			{
				return new GoogleCredential(new UrlSourcedExternalAccountCredential(new Initializer(this)
				{
					ServiceAccountImpersonationUrl = null
				}));
			}
			return new GoogleCredential(this);
		}

		protected override async Task<string> GetSubjectTokenAsyncImpl(CancellationToken taskCancellationToken)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, SubjectTokenUrl);
			foreach (KeyValuePair<string, string> header in Headers)
			{
				httpRequestMessage.Headers.Add(header.Key, header.Value);
			}
			HttpResponseMessage obj = await base.HttpClient.SendAsync(httpRequestMessage, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			obj.EnsureSuccessStatusCode();
			string text = await obj.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (string.IsNullOrEmpty(SubjectTokenJsonFieldName))
			{
				return text;
			}
			return NewtonsoftJsonSerializer.Instance.Deserialize<Dictionary<string, string>>(text)[SubjectTokenJsonFieldName];
		}

		Task<string> IGoogleCredential.GetUniverseDomainAsync(CancellationToken _)
		{
			return Task.FromResult(base.UniverseDomain);
		}

		string IGoogleCredential.GetUniverseDomain()
		{
			return base.UniverseDomain;
		}

		IGoogleCredential IGoogleCredential.WithQuotaProject(string quotaProject)
		{
			return new UrlSourcedExternalAccountCredential(new Initializer(this)
			{
				QuotaProject = quotaProject
			});
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return new UrlSourcedExternalAccountCredential(new Initializer(this)
			{
				Scopes = scopes
			});
		}

		IGoogleCredential IGoogleCredential.WithUserForDomainWideDelegation(string user)
		{
			return WithUserForDomainWideDelegation(user);
		}

		IGoogleCredential IGoogleCredential.WithHttpClientFactory(IHttpClientFactory httpClientFactory)
		{
			return new UrlSourcedExternalAccountCredential(new Initializer(this)
			{
				HttpClientFactory = httpClientFactory
			});
		}

		IGoogleCredential IGoogleCredential.WithUniverseDomain(string universeDomain)
		{
			return new UrlSourcedExternalAccountCredential(new Initializer(this)
			{
				UniverseDomain = universeDomain
			});
		}
	}
}
