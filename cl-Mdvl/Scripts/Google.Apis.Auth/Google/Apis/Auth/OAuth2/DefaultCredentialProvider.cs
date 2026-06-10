using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Json;
using Google.Apis.Logging;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2
{
	internal class DefaultCredentialProvider
	{
		private static readonly ILogger Logger = ApplicationContext.Logger.ForType<DefaultCredentialProvider>();

		public const string CredentialEnvironmentVariable = "GOOGLE_APPLICATION_CREDENTIALS";

		private const string WellKnownCredentialsFile = "application_default_credentials.json";

		private const string AppdataEnvironmentVariable = "APPDATA";

		private const string HomeEnvironmentVariable = "HOME";

		private const string CloudSDKConfigDirectoryWindows = "gcloud";

		private const string HelpPermalink = "https://cloud.google.com/docs/authentication/external/set-up-adc";

		private static readonly string CloudSDKConfigDirectoryUnix = Path.Combine(".config", "gcloud");

		private readonly Lazy<Task<GoogleCredential>> cachedCredentialTask;

		public DefaultCredentialProvider()
		{
			cachedCredentialTask = new Lazy<Task<GoogleCredential>>(CreateDefaultCredentialAsync);
		}

		public Task<GoogleCredential> GetDefaultCredentialAsync()
		{
			return cachedCredentialTask.Value;
		}

		private async Task<GoogleCredential> CreateDefaultCredentialAsync()
		{
			GoogleCredential googleCredential = await GetAdcFromEnvironmentVariableAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (googleCredential == null)
			{
				GoogleCredential googleCredential2 = await GetAdcFromWellKnownFileAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (googleCredential2 == null)
				{
					googleCredential2 = (await GetAdcFromComputeAsync().ConfigureAwait(continueOnCapturedContext: false)) ?? throw new InvalidOperationException("Your default credentials were not found. To set up Application Default Credentials, see https://cloud.google.com/docs/authentication/external/set-up-adc.");
				}
				googleCredential = googleCredential2;
			}
			return googleCredential.CreateWithEnvironmentQuotaProject();
			static async Task<GoogleCredential> GetAdcFromComputeAsync()
			{
				Logger.Debug("Checking whether the application is running on ComputeEngine.");
				if (await ComputeCredential.IsRunningOnComputeEngine().ConfigureAwait(continueOnCapturedContext: false))
				{
					Logger.Debug("ComputeEngine check passed. Using ComputeEngine Credentials.");
					return new GoogleCredential(new ComputeCredential());
				}
				return null;
			}
			async Task<GoogleCredential> GetAdcFromEnvironmentVariableAsync()
			{
				string credentialPath = GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
				if (!string.IsNullOrWhiteSpace(credentialPath))
				{
					try
					{
						return await CreateDefaultCredentialFromFileAsync(credentialPath, default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex)
					{
						throw new InvalidOperationException("Error reading credential file from location " + credentialPath + ": " + ex.Message + Environment.NewLine + "Please check the value of the Environment Variable GOOGLE_APPLICATION_CREDENTIALS.", ex);
					}
				}
				return null;
			}
			async Task<GoogleCredential> GetAdcFromWellKnownFileAsync()
			{
				string credentialPath = GetWellKnownCredentialFilePath();
				if (!string.IsNullOrWhiteSpace(credentialPath))
				{
					try
					{
						return await CreateDefaultCredentialFromFileAsync(credentialPath, default(CancellationToken)).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
					{
						Logger.Debug("Well-known credential file " + credentialPath + " not found.");
					}
					catch (Exception ex2)
					{
						throw new InvalidOperationException("Error reading credential file from location " + credentialPath + ": " + ex2.Message + Environment.NewLine + "Please rerun 'gcloud auth login' to regenerate credentials file.", ex2);
					}
				}
				return null;
			}
		}

		private async Task<GoogleCredential> CreateDefaultCredentialFromFileAsync(string credentialPath, CancellationToken cancellationToken)
		{
			Logger.Debug("Loading Credential from file {0}", credentialPath);
			using Stream stream = GetStream(credentialPath);
			return await CreateDefaultCredentialFromStreamAsync(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal GoogleCredential CreateDefaultCredentialFromStream(Stream stream)
		{
			JsonCredentialParameters credentialParameters;
			try
			{
				credentialParameters = NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Error deserializing JSON credential data.", innerException);
			}
			return CreateDefaultCredentialFromParameters(credentialParameters);
		}

		internal async Task<GoogleCredential> CreateDefaultCredentialFromStreamAsync(Stream stream, CancellationToken cancellationToken)
		{
			JsonCredentialParameters credentialParameters;
			try
			{
				credentialParameters = await NewtonsoftJsonSerializer.Instance.DeserializeAsync<JsonCredentialParameters>(stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Error deserializing JSON credential data.", innerException);
			}
			return CreateDefaultCredentialFromParameters(credentialParameters);
		}

		internal GoogleCredential CreateDefaultCredentialFromJson(string json)
		{
			JsonCredentialParameters credentialParameters;
			try
			{
				credentialParameters = NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(json);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Error deserializing JSON credential data.", innerException);
			}
			return CreateDefaultCredentialFromParameters(credentialParameters);
		}

		internal GoogleCredential CreateDefaultCredentialFromParameters(JsonCredentialParameters credentialParameters)
		{
			return credentialParameters.ThrowIfNull("credentialParameters").Type switch
			{
				"authorized_user" => new GoogleCredential(CreateUserCredentialFromParameters(credentialParameters)), 
				"service_account" => GoogleCredential.FromServiceAccountCredential(CreateServiceAccountCredentialFromParameters(credentialParameters)), 
				"external_account" => new GoogleCredential(CreateExternalCredentialFromParameters(credentialParameters)), 
				"impersonated_service_account" => new GoogleCredential(CreateImpersonatedServiceAccountCredentialFromParameters(credentialParameters)), 
				_ => throw new InvalidOperationException("Error creating credential from JSON or JSON parameters. Unrecognized credential type " + credentialParameters.Type + "."), 
			};
		}

		private static UserCredential CreateUserCredentialFromParameters(JsonCredentialParameters credentialParameters)
		{
			if (credentialParameters.Type != "authorized_user" || string.IsNullOrEmpty(credentialParameters.ClientId) || string.IsNullOrEmpty(credentialParameters.ClientSecret))
			{
				throw new InvalidOperationException("JSON data does not represent a valid user credential.");
			}
			if (credentialParameters.UniverseDomain != null && credentialParameters.UniverseDomain != "googleapis.com")
			{
				throw new InvalidOperationException("UserCredential is not supported in universe domains other than googleapis.com");
			}
			TokenResponse token = new TokenResponse
			{
				RefreshToken = credentialParameters.RefreshToken
			};
			return new UserCredential(new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
			{
				ClientSecrets = new ClientSecrets
				{
					ClientId = credentialParameters.ClientId,
					ClientSecret = credentialParameters.ClientSecret
				},
				ProjectId = credentialParameters.ProjectId
			}), "ApplicationDefaultCredentials", token, credentialParameters.QuotaProject);
		}

		private static ServiceAccountCredential CreateServiceAccountCredentialFromParameters(JsonCredentialParameters credentialParameters)
		{
			if (credentialParameters.Type != "service_account" || string.IsNullOrEmpty(credentialParameters.ClientEmail) || string.IsNullOrEmpty(credentialParameters.PrivateKey))
			{
				throw new InvalidOperationException("JSON data does not represent a valid service account credential.");
			}
			return new ServiceAccountCredential(new ServiceAccountCredential.Initializer(credentialParameters.ClientEmail, credentialParameters.TokenUri)
			{
				ProjectId = credentialParameters.ProjectId,
				QuotaProject = credentialParameters.QuotaProject,
				KeyId = credentialParameters.PrivateKeyId,
				UniverseDomain = credentialParameters.UniverseDomain,
				UseJwtAccessWithScopes = (credentialParameters.UniverseDomain != null && credentialParameters.UniverseDomain != "googleapis.com")
			}.FromPrivateKey(credentialParameters.PrivateKey));
		}

		private static IGoogleCredential CreateExternalCredentialFromParameters(JsonCredentialParameters parameters)
		{
			if (parameters.Type != "external_account" || parameters.CredentialSourceConfig == null)
			{
				throw new InvalidOperationException("JSON data does not represent a valid external account credential.");
			}
			if (!string.IsNullOrEmpty(parameters.CredentialSourceConfig.EnvironmentId))
			{
				if (!parameters.CredentialSourceConfig.EnvironmentId.Equals("aws1", StringComparison.OrdinalIgnoreCase))
				{
					throw new InvalidOperationException("Only aws1 version of AWS external account credentials is supported by this library.");
				}
				return new AwsExternalAccountCredential(new AwsExternalAccountCredential.Initializer(parameters.TokenUrl, parameters.Audience, parameters.SubjectTokenType, parameters.CredentialSourceConfig.RegionalCredentialVerificationUrl)
				{
					QuotaProject = parameters.QuotaProject,
					ServiceAccountImpersonationUrl = parameters.ServiceAccountImpersonationUrl,
					WorkforcePoolUserProject = parameters.WorkforcePoolUserProject,
					ClientId = parameters.ClientId,
					ClientSecret = parameters.ClientSecret,
					RegionUrl = parameters.CredentialSourceConfig.RegionUrl,
					SecurityCredentialsUrl = parameters.CredentialSourceConfig.Url,
					ImdsV2SessionTokenUrl = parameters.CredentialSourceConfig.ImdsV2SessionTokenUrl,
					UniverseDomain = parameters.UniverseDomain
				});
			}
			if (!string.IsNullOrEmpty(parameters.CredentialSourceConfig.File))
			{
				return new FileSourcedExternalAccountCredential(new FileSourcedExternalAccountCredential.Initializer(parameters.TokenUrl, parameters.Audience, parameters.SubjectTokenType, parameters.CredentialSourceConfig.File)
				{
					QuotaProject = parameters.QuotaProject,
					ServiceAccountImpersonationUrl = parameters.ServiceAccountImpersonationUrl,
					WorkforcePoolUserProject = parameters.WorkforcePoolUserProject,
					ClientId = parameters.ClientId,
					ClientSecret = parameters.ClientSecret,
					SubjectTokenJsonFieldName = parameters.ExtractSubjectTokenFieldName(),
					UniverseDomain = parameters.UniverseDomain
				});
			}
			if (!string.IsNullOrEmpty(parameters.CredentialSourceConfig.Url))
			{
				UrlSourcedExternalAccountCredential.Initializer initializer = new UrlSourcedExternalAccountCredential.Initializer(parameters.TokenUrl, parameters.Audience, parameters.SubjectTokenType, parameters.CredentialSourceConfig.Url)
				{
					QuotaProject = parameters.QuotaProject,
					ServiceAccountImpersonationUrl = parameters.ServiceAccountImpersonationUrl,
					WorkforcePoolUserProject = parameters.WorkforcePoolUserProject,
					ClientId = parameters.ClientId,
					ClientSecret = parameters.ClientSecret,
					SubjectTokenJsonFieldName = parameters.ExtractSubjectTokenFieldName(),
					UniverseDomain = parameters.UniverseDomain
				};
				if (parameters.CredentialSourceConfig.Headers != null)
				{
					foreach (KeyValuePair<string, string> header in parameters.CredentialSourceConfig.Headers)
					{
						initializer.Headers.Add(header);
					}
				}
				return new UrlSourcedExternalAccountCredential(initializer);
			}
			throw new InvalidOperationException("Unrecognized external credential configuration");
		}

		private ImpersonatedCredential CreateImpersonatedServiceAccountCredentialFromParameters(JsonCredentialParameters parameters)
		{
			if (parameters.Type != "impersonated_service_account" || parameters.SourceCredential == null || string.IsNullOrEmpty(parameters.ServiceAccountImpersonationUrl))
			{
				throw new InvalidOperationException("JSON data does not represent a valid impersonated service account credential.");
			}
			GoogleCredential sourceCredential = CreateDefaultCredentialFromParameters(parameters.SourceCredential);
			ImpersonatedCredential.Initializer obj = new ImpersonatedCredential.Initializer(maybeTargetPrincipal: ImpersonatedCredential.ExtractTargetPrincipal(parameters.ServiceAccountImpersonationUrl), customTokenUrl: parameters.ServiceAccountImpersonationUrl);
			string[] delegates = parameters.Delegates;
			obj.DelegateAccounts = ((delegates != null && delegates.Length != 0) ? parameters.Delegates.ToList() : null);
			obj.QuotaProject = parameters.QuotaProject;
			ImpersonatedCredential.Initializer initializer = obj;
			ImpersonatedCredential impersonatedCredential = ImpersonatedCredential.Create(sourceCredential, initializer);
			if (parameters.UniverseDomain != parameters.SourceCredential.UniverseDomain)
			{
				return ((IGoogleCredential)impersonatedCredential).WithUniverseDomain(parameters.UniverseDomain) as ImpersonatedCredential;
			}
			return impersonatedCredential;
		}

		private string GetWellKnownCredentialFilePath()
		{
			string environmentVariable = GetEnvironmentVariable("APPDATA");
			if (environmentVariable != null)
			{
				return Path.Combine(environmentVariable, "gcloud", "application_default_credentials.json");
			}
			string environmentVariable2 = GetEnvironmentVariable("HOME");
			if (environmentVariable2 != null)
			{
				return Path.Combine(environmentVariable2, CloudSDKConfigDirectoryUnix, "application_default_credentials.json");
			}
			return Path.Combine("gcloud", "application_default_credentials.json");
		}

		protected virtual string GetEnvironmentVariable(string variableName)
		{
			return Environment.GetEnvironmentVariable(variableName);
		}

		protected virtual Stream GetStream(string filePath)
		{
			return new FileStream(filePath, FileMode.Open, FileAccess.Read);
		}
	}
}
