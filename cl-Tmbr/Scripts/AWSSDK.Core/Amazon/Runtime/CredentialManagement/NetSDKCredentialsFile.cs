using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.CredentialManagement
{
	public class NetSDKCredentialsFile : ICredentialProfileStore, ICredentialProfileSource
	{
		public const string DefaultProfileName = "Default";

		private const string AWSCredentialsProfileType = "AWS";

		private const string SAMLRoleProfileType = "SAML";

		private const string DefaultConfigurationModeNameField = "DefaultsMode";

		private const string RegionField = "Region";

		private const string EndpointDiscoveryEnabledField = "EndpointDiscoveryEnabled";

		private const string S3UseArnRegionField = "S3UseArnRegion";

		private const string S3DisableExpressSessionAuthField = "S3DisableExpressSessionAuth";

		private const string S3RegionalEndpointField = "S3RegionalEndpoint";

		private const string S3DisableMultiRegionAccessPointsField = "S3DisableMultiRegionAccessPoints";

		private const string RetryModeField = "RetryMode";

		private const string MaxAttemptsField = "MaxAttempts";

		private const string SsoAccountId = "sso_account_id";

		private const string SsoRegion = "sso_region";

		private const string SsoRegistrationScopes = "sso_registration_scopes";

		private const string SsoRoleName = "sso_role_name";

		private const string SsoStartUrl = "sso_start_url";

		private const string SsoSession = "sso_session";

		private const string EndpointUrlField = "endpoint_url";

		private const string ServicesField = "services";

		private const string IgnoreConfiguredEndpointUrlsField = "ignore_configured_endpoint_urls";

		private static readonly HashSet<string> ReservedPropertyNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"DisplayName", "ProfileType", "DefaultsMode", "Region", "EndpointDiscoveryEnabled", "S3UseArnRegion", "S3DisableExpressSessionAuth", "S3RegionalEndpoint", "S3DisableMultiRegionAccessPoints", "RetryMode",
			"MaxAttempts", "sso_account_id", "sso_region", "sso_registration_scopes", "sso_role_name", "sso_start_url", "endpoint_url", "services", "ignore_configured_endpoint_urls"
		};

		private static readonly CredentialProfilePropertyMapping PropertyMapping = new CredentialProfilePropertyMapping(new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{ "AccessKey", "AWSAccessKey" },
			{ "CredentialSource", "CredentialSource" },
			{ "EndpointName", "EndpointName" },
			{ "ExternalID", "ExternalId" },
			{ "MfaSerial", "MfaSerial" },
			{ "RoleArn", "RoleArn" },
			{ "RoleSessionName", "RoleSessionName" },
			{ "SecretKey", "AWSSecretKey" },
			{ "SourceProfile", "SourceProfile" },
			{ "Token", "SessionToken" },
			{ "UserIdentity", "UserIdentity" },
			{ "AwsAccountId", "aws_account_id" },
			{ "CredentialProcess", "credential_process" },
			{ "WebIdentityTokenFile", "WebIdentityTokenFile" },
			{ "SsoAccountId", "sso_account_id" },
			{ "SsoRegion", "sso_region" },
			{ "SsoRegistrationScopes", "sso_registration_scopes" },
			{ "SsoRoleName", "sso_role_name" },
			{ "SsoStartUrl", "sso_start_url" },
			{ "SsoSession", "sso_session" }
		});

		private readonly NamedSettingsManager _settingsManager;

		public NetSDKCredentialsFile()
		{
			_settingsManager = new NamedSettingsManager("RegisteredAccounts");
		}

		public List<string> ListProfileNames()
		{
			return (from p in ListProfiles()
				select p.Name).ToList();
		}

		public List<CredentialProfile> ListProfiles()
		{
			List<CredentialProfile> list = new List<CredentialProfile>();
			foreach (string item in _settingsManager.ListObjectNames())
			{
				CredentialProfile profile = null;
				if (TryGetProfile(item, out profile) && profile.CanCreateAWSCredentials)
				{
					list.Add(profile);
				}
			}
			return list;
		}

		public bool TryGetProfile(string profileName, out CredentialProfile profile)
		{
			if (_settingsManager.TryGetObject(profileName, out var uniqueKey, out var properties))
			{
				try
				{
					PropertyMapping.ExtractProfileParts(properties, ReservedPropertyNames, out var profileOptions, out var reservedProperties, out var userProperties);
					reservedProperties.TryGetValue("DefaultsMode", out var value);
					RegionEndpoint region = null;
					if (reservedProperties.TryGetValue("Region", out var value2))
					{
						region = RegionEndpoint.GetBySystemName(value2);
					}
					Guid? result = null;
					if (!GuidUtils.TryParseNullableGuid(uniqueKey, out result))
					{
						profile = null;
						return false;
					}
					bool? endpointDiscoveryEnabled = null;
					if (reservedProperties.TryGetValue("EndpointDiscoveryEnabled", out var value3))
					{
						if (!bool.TryParse(value3, out var result2))
						{
							profile = null;
							return false;
						}
						endpointDiscoveryEnabled = result2;
					}
					bool? s3UseArnRegion = null;
					if (reservedProperties.TryGetValue("S3UseArnRegion", out var value4))
					{
						if (!bool.TryParse(value4, out var result3))
						{
							profile = null;
							return false;
						}
						s3UseArnRegion = result3;
					}
					bool? s3DisableExpressSessionAuth = null;
					if (reservedProperties.TryGetValue("S3DisableExpressSessionAuth", out var value5))
					{
						if (!bool.TryParse(value5, out var result4))
						{
							profile = null;
							return false;
						}
						s3DisableExpressSessionAuth = result4;
					}
					bool? s3DisableMultiRegionAccessPoints = null;
					if (reservedProperties.TryGetValue("S3DisableMultiRegionAccessPoints", out var value6))
					{
						if (!bool.TryParse(value6, out var result5))
						{
							profile = null;
							return false;
						}
						s3DisableMultiRegionAccessPoints = result5;
					}
					S3UsEast1RegionalEndpointValue? s3RegionalEndpoint = null;
					if (reservedProperties.TryGetValue("S3RegionalEndpoint", out var value7))
					{
						if (!Enum.TryParse<S3UsEast1RegionalEndpointValue>(value7, ignoreCase: true, out var result6))
						{
							profile = null;
							return false;
						}
						s3RegionalEndpoint = result6;
					}
					RequestRetryMode? retryMode = null;
					if (reservedProperties.TryGetValue("RetryMode", out var value8))
					{
						if (!Enum.TryParse<RequestRetryMode>(value8, ignoreCase: true, out var result7))
						{
							profile = null;
							return false;
						}
						retryMode = result7;
					}
					int? maxAttempts = null;
					if (reservedProperties.TryGetValue("MaxAttempts", out var value9))
					{
						if (!int.TryParse(value9, out var result8) || result8 <= 0)
						{
							Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A positive integer is expected.", value9, "MaxAttempts", profileName);
							profile = null;
							return false;
						}
						maxAttempts = result8;
					}
					profile = new CredentialProfile(profileName, profileOptions)
					{
						UniqueKey = result,
						Properties = userProperties,
						Region = region,
						CredentialProfileStore = this,
						DefaultConfigurationModeName = value,
						EndpointDiscoveryEnabled = endpointDiscoveryEnabled,
						S3UseArnRegion = s3UseArnRegion,
						S3DisableExpressSessionAuth = s3DisableExpressSessionAuth,
						S3RegionalEndpoint = s3RegionalEndpoint,
						S3DisableMultiRegionAccessPoints = s3DisableMultiRegionAccessPoints,
						RetryMode = retryMode,
						MaxAttempts = maxAttempts
					};
					return true;
				}
				catch (ArgumentException)
				{
					profile = null;
					return false;
				}
			}
			profile = null;
			return false;
		}

		public void RegisterProfile(CredentialProfile profile)
		{
			if (profile.CanCreateAWSCredentials || profile.Options.IsEmpty)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				if (profile.CanCreateAWSCredentials)
				{
					SetProfileTypeField(dictionary, profile.ProfileType.Value);
				}
				if (profile.Region != null)
				{
					dictionary["Region"] = profile.Region.SystemName;
				}
				if (profile.EndpointDiscoveryEnabled.HasValue)
				{
					dictionary["EndpointDiscoveryEnabled"] = profile.EndpointDiscoveryEnabled.Value.ToString().ToLowerInvariant();
				}
				if (profile.S3UseArnRegion.HasValue)
				{
					dictionary["S3UseArnRegion"] = profile.S3UseArnRegion.Value.ToString().ToLowerInvariant();
				}
				if (profile.S3DisableExpressSessionAuth.HasValue)
				{
					dictionary["S3DisableExpressSessionAuth"] = profile.S3DisableExpressSessionAuth.Value.ToString().ToLowerInvariant();
				}
				if (profile.S3RegionalEndpoint.HasValue)
				{
					dictionary["S3RegionalEndpoint"] = profile.S3RegionalEndpoint.ToString().ToLowerInvariant();
				}
				if (profile.S3DisableMultiRegionAccessPoints.HasValue)
				{
					dictionary["S3DisableMultiRegionAccessPoints"] = profile.S3DisableMultiRegionAccessPoints.ToString().ToLowerInvariant();
				}
				if (profile.RetryMode.HasValue)
				{
					dictionary["RetryMode"] = profile.RetryMode.ToString().ToLowerInvariant();
				}
				if (profile.MaxAttempts.HasValue)
				{
					dictionary["MaxAttempts"] = profile.MaxAttempts.ToString().ToLowerInvariant();
				}
				if (profile.IgnoreConfiguredEndpointUrls.HasValue)
				{
					dictionary["ignore_configured_endpoint_urls"] = profile.IgnoreConfiguredEndpointUrls.ToString().ToLowerInvariant();
				}
				if (profile.EndpointUrl != null)
				{
					dictionary["endpoint_url"] = profile.EndpointUrl.ToString().ToLowerInvariant();
				}
				Dictionary<string, string> properties = PropertyMapping.CombineProfileParts(profile.Options, ReservedPropertyNames, dictionary, profile.Properties);
				if (GuidUtils.TryParseNullableGuid(_settingsManager.RegisterObject(profile.Name, properties), out var result))
				{
					profile.UniqueKey = result;
				}
				profile.CredentialProfileStore = this;
				return;
			}
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to register profile {0}.  The CredentialProfileOptions provided is not valid.", profile.Name));
		}

		public void UnregisterProfile(string profileName)
		{
			_settingsManager.UnregisterObject(profileName);
		}

		public void RenameProfile(string oldProfileName, string newProfileName)
		{
			RenameProfile(oldProfileName, newProfileName, force: false);
		}

		public void RenameProfile(string oldProfileName, string newProfileName, bool force)
		{
			_settingsManager.RenameObject(oldProfileName, newProfileName, force);
		}

		public void CopyProfile(string fromProfileName, string toProfileName)
		{
			CopyProfile(fromProfileName, toProfileName, force: false);
		}

		public void CopyProfile(string fromProfileName, string toProfileName, bool force)
		{
			_settingsManager.CopyObject(fromProfileName, toProfileName, force);
		}

		private static void SetProfileTypeField(IDictionary<string, string> properties, CredentialProfileType profileType)
		{
			switch (profileType)
			{
			case CredentialProfileType.Basic:
				properties["ProfileType"] = "AWS";
				break;
			case CredentialProfileType.SAMLRole:
			case CredentialProfileType.SAMLRoleUserIdentity:
				properties["ProfileType"] = "SAML";
				break;
			default:
				properties["ProfileType"] = profileType.ToString();
				break;
			}
		}
	}
}
