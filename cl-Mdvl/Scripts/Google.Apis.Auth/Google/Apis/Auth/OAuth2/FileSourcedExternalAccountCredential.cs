using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Http;
using Google.Apis.Json;

namespace Google.Apis.Auth.OAuth2
{
	public sealed class FileSourcedExternalAccountCredential : ExternalAccountCredential, IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor
	{
		internal new class Initializer : ExternalAccountCredential.Initializer
		{
			internal string SubjectTokenFilePath { get; }

			internal string SubjectTokenJsonFieldName { get; set; }

			internal Initializer(string tokenUrl, string audience, string subjectTokenType, string subjectTokenFilePath)
				: base(tokenUrl, audience, subjectTokenType)
			{
				SubjectTokenFilePath = subjectTokenFilePath;
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				SubjectTokenFilePath = other.SubjectTokenFilePath;
				SubjectTokenJsonFieldName = other.SubjectTokenJsonFieldName;
			}

			internal Initializer(FileSourcedExternalAccountCredential other)
				: base(other)
			{
				SubjectTokenFilePath = other.SubjectTokenFilePath;
				SubjectTokenJsonFieldName = other.SubjectTokenJsonFieldName;
			}
		}

		public string SubjectTokenFilePath { get; }

		public string SubjectTokenJsonFieldName { get; }

		string IGoogleCredential.QuotaProject => base.QuotaProject;

		bool IGoogleCredential.HasExplicitScopes => base.HasExplicitScopes;

		bool IGoogleCredential.SupportsExplicitScopes => base.SupportsExplicitScopes;

		internal FileSourcedExternalAccountCredential(Initializer initializer)
			: base(initializer)
		{
			SubjectTokenFilePath = initializer.SubjectTokenFilePath;
			SubjectTokenJsonFieldName = initializer.SubjectTokenJsonFieldName;
		}

		private protected override GoogleCredential WithoutImpersonationConfigurationImpl()
		{
			if (base.ServiceAccountImpersonationUrl != null)
			{
				return new GoogleCredential(new FileSourcedExternalAccountCredential(new Initializer(this)
				{
					ServiceAccountImpersonationUrl = null
				}));
			}
			return new GoogleCredential(this);
		}

		protected override async Task<string> GetSubjectTokenAsyncImpl(CancellationToken taskCancellationToken)
		{
			string text = await ReadSubjectTokenFileContentAsync().ConfigureAwait(continueOnCapturedContext: false);
			return (!string.IsNullOrEmpty(SubjectTokenJsonFieldName)) ? NewtonsoftJsonSerializer.Instance.Deserialize<Dictionary<string, string>>(text)[SubjectTokenJsonFieldName] : text;
			async Task<string> ReadSubjectTokenFileContentAsync()
			{
				using StreamReader reader = File.OpenText(SubjectTokenFilePath);
				return await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
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
			return new FileSourcedExternalAccountCredential(new Initializer(this)
			{
				QuotaProject = quotaProject
			});
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return new FileSourcedExternalAccountCredential(new Initializer(this)
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
			return new FileSourcedExternalAccountCredential(new Initializer(this)
			{
				HttpClientFactory = httpClientFactory
			});
		}

		IGoogleCredential IGoogleCredential.WithUniverseDomain(string universeDomain)
		{
			return new FileSourcedExternalAccountCredential(new Initializer(this)
			{
				UniverseDomain = universeDomain
			});
		}
	}
}
