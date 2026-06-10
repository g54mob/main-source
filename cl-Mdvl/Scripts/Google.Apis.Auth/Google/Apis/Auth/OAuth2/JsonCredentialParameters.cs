using System.Collections.Generic;
using Newtonsoft.Json;

namespace Google.Apis.Auth.OAuth2
{
	public class JsonCredentialParameters
	{
		public class CredentialSource
		{
			public class SubjectTokenFormat
			{
				[JsonProperty("type")]
				public string Type { get; set; }

				[JsonProperty("subject_token_field_name")]
				public string SubjectTokenFieldName { get; set; }
			}

			[JsonProperty("environment_id")]
			public string EnvironmentId { get; set; }

			[JsonProperty("region_url")]
			public string RegionUrl { get; set; }

			[JsonProperty("url")]
			public string Url { get; set; }

			[JsonProperty("regional_cred_verification_url")]
			public string RegionalCredentialVerificationUrl { get; set; }

			[JsonProperty("imdsv2_session_token_url")]
			public string ImdsV2SessionTokenUrl { get; set; }

			[JsonProperty("headers")]
			public Dictionary<string, string> Headers { get; set; }

			[JsonProperty("file")]
			public string File { get; set; }

			[JsonProperty("format")]
			public SubjectTokenFormat Format { get; set; }
		}

		public const string AuthorizedUserCredentialType = "authorized_user";

		public const string ServiceAccountCredentialType = "service_account";

		public const string ImpersonatedServiceAccountCredentialType = "impersonated_service_account";

		public const string ExternalAccountCredentialType = "external_account";

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("project_id")]
		public string ProjectId { get; set; }

		[JsonProperty("quota_project_id")]
		public string QuotaProject { get; set; }

		[JsonProperty("universe_domain")]
		public string UniverseDomain { get; set; }

		[JsonProperty("client_id")]
		public string ClientId { get; set; }

		[JsonProperty("client_secret")]
		public string ClientSecret { get; set; }

		[JsonProperty("client_email")]
		public string ClientEmail { get; set; }

		[JsonProperty("private_key")]
		public string PrivateKey { get; set; }

		[JsonProperty("private_key_id")]
		public string PrivateKeyId { get; set; }

		[JsonProperty("token_uri")]
		public string TokenUri { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("service_account_impersonation_url")]
		public string ServiceAccountImpersonationUrl { get; set; }

		[JsonProperty("delegates")]
		public string[] Delegates { get; set; }

		[JsonProperty("source_credentials")]
		public JsonCredentialParameters SourceCredential { get; set; }

		[JsonProperty("audience")]
		public string Audience { get; set; }

		[JsonProperty("subject_token_type")]
		public string SubjectTokenType { get; set; }

		[JsonProperty("token_url")]
		public string TokenUrl { get; set; }

		[JsonProperty("workforce_pool_user_project")]
		public string WorkforcePoolUserProject { get; set; }

		[JsonProperty("credential_source")]
		public CredentialSource CredentialSourceConfig { get; set; }
	}
}
