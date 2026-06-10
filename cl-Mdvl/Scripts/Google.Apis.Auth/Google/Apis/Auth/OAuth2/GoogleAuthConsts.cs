using System;

namespace Google.Apis.Auth.OAuth2
{
	public static class GoogleAuthConsts
	{
		public const string AuthorizationUrl = "https://accounts.google.com/o/oauth2/auth";

		public const string OidcAuthorizationUrl = "https://accounts.google.com/o/oauth2/v2/auth";

		public const string ApprovalUrl = "https://accounts.google.com/o/oauth2/approval";

		public const string TokenUrl = "https://accounts.google.com/o/oauth2/token";

		public const string OidcTokenUrl = "https://oauth2.googleapis.com/token";

		private const string DefaultMetadataAddress = "169.254.169.254";

		internal const string DefaultMetadataServerUrl = "http://169.254.169.254";

		private const string ComputeTokenUrlSuffix = "/computeMetadata/v1/instance/service-accounts/default/token";

		private const string ComputeOidcTokenUrlSuffix = "/computeMetadata/v1/instance/service-accounts/default/identity";

		private const string ComputeDefaultServiceAccountEmailSuffix = "/computeMetadata/v1/instance/service-accounts/default/email";

		private const string ComputeUniverseDomainUrlSuffix = "/computeMetadata/v1/universe/universe_domain";

		public const string ComputeTokenUrl = "http://169.254.169.254/computeMetadata/v1/instance/service-accounts/default/token";

		public const string RevokeTokenUrl = "https://oauth2.googleapis.com/revoke";

		public const string JsonWebKeySetUrl = "https://www.googleapis.com/oauth2/v3/certs";

		public const string IapKeySetUrl = "https://www.gstatic.com/iap/verify/public_key-jwk";

		public const string LocalhostRedirectUri = "http://localhost";

		internal const string IamServiceHostPrefix = "https://iamcredentials.";

		internal const string IamServiceAccountEndpointCommonPrefixFormat = "https://iamcredentials.{0}/v1/projects/-/serviceAccounts/";

		internal const string IamAccessTokenVerb = "generateAccessToken";

		internal const string IamAccessTokenEndpointFormatString = "https://iamcredentials.{0}/v1/projects/-/serviceAccounts/{1}:generateAccessToken";

		internal const string IamSignEndpointFormatString = "https://iamcredentials.{0}/v1/projects/-/serviceAccounts/{1}:signBlob";

		internal const string IamIdTokenEndpointFormatString = "https://iamcredentials.{0}/v1/projects/-/serviceAccounts/{1}:generateIdToken";

		internal const string IamScope = "https://www.googleapis.com/auth/iam";

		public const string QuotaProjectEnvironmentVariable = "GOOGLE_CLOUD_QUOTA_PROJECT";

		internal const string DefaultUniverseDomain = "googleapis.com";

		internal const string UniverseDomainKey = "__UniverseDomainKey";

		internal static string EnvironmentQuotaProject
		{
			get
			{
				string environmentVariable = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_QUOTA_PROJECT");
				if (environmentVariable == null || !(environmentVariable != ""))
				{
					return null;
				}
				return environmentVariable;
			}
		}

		internal static string EffectiveComputeTokenUrl => GetEffectiveMetadataUrl("/computeMetadata/v1/instance/service-accounts/default/token", "http://169.254.169.254/computeMetadata/v1/instance/service-accounts/default/token");

		internal static string EffectiveComputeOidcTokenUrl => GetEffectiveMetadataUrl("/computeMetadata/v1/instance/service-accounts/default/identity", "http://169.254.169.254/computeMetadata/v1/instance/service-accounts/default/identity");

		internal static string EffectiveComputeDefaultServiceAccountEmailUrl => GetEffectiveMetadataUrl("/computeMetadata/v1/instance/service-accounts/default/email", "http://169.254.169.254/computeMetadata/v1/instance/service-accounts/default/email");

		internal static string EffectiveComputeUniverDomainUrl => GetEffectiveMetadataUrl("/computeMetadata/v1/universe/universe_domain", "http://169.254.169.254/computeMetadata/v1/universe/universe_domain");

		internal static string EffectiveMetadataServerUrl => GetEffectiveMetadataUrl(null, "http://169.254.169.254");

		private static string GetEffectiveMetadataUrl(string suffix, string defaultValue)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("GCE_METADATA_HOST");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				return "http://" + environmentVariable + suffix;
			}
			return defaultValue;
		}

		internal static void CheckIsDefaultUniverseDomain(string universeDomain, string message)
		{
			if (universeDomain != "googleapis.com")
			{
				throw new InvalidOperationException(message);
			}
		}

		internal static void CheckIsDefaultUniverseDomain(string universeDomain, bool condition, string message)
		{
			if (universeDomain != "googleapis.com" && condition)
			{
				throw new InvalidOperationException(message);
			}
		}
	}
}
