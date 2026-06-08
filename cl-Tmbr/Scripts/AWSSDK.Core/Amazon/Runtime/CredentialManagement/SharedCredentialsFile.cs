using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.CredentialManagement
{
	public class SharedCredentialsFile : ICredentialProfileStore, ICredentialProfileSource
	{
		public const string DefaultProfileName = "default";

		public const string SharedCredentialsFileEnvVar = "AWS_SHARED_CREDENTIALS_FILE";

		public const string SharedConfigFileEnvVar = "AWS_CONFIG_FILE";

		private const string ToolkitArtifactGuidField = "toolkit_artifact_guid";

		private const string RegionField = "region";

		private const string EndpointDiscoveryEnabledField = "endpoint_discovery_enabled";

		private const string ConfigFileName = "config";

		private const string DefaultDirectoryName = ".aws";

		private const string DefaultFileName = "credentials";

		private const string DefaultConfigurationModeField = "defaults_mode";

		private const string CredentialProcess = "credential_process";

		private const string S3UseArnRegionField = "s3_use_arn_region";

		private const string S3DisableExpressSessionAuthField = "s3_disable_express_session_auth";

		private const string S3RegionalEndpointField = "s3_us_east_1_regional_endpoint";

		private const string S3DisableMultiRegionAccessPointsField = "s3_disable_multiregion_access_points";

		private const string RetryModeField = "retry_mode";

		private const string MaxAttemptsField = "max_attempts";

		private const string SsoAccountId = "sso_account_id";

		private const string SsoRegion = "sso_region";

		private const string SsoRegistrationScopes = "sso_registration_scopes";

		private const string SsoRoleName = "sso_role_name";

		private const string SsoStartUrl = "sso_start_url";

		private const string SsoSession = "sso_session";

		private const string EC2MetadataServiceEndpointField = "ec2_metadata_service_endpoint";

		private const string EC2MetadataServiceEndpointModeField = "ec2_metadata_service_endpoint_mode";

		private const string UseDualstackEndpointField = "use_dualstack_endpoint";

		private const string UseFIPSEndpointField = "use_fips_endpoint";

		private const string EndpointUrlField = "endpoint_url";

		private const string ServicesField = "services";

		private const string IgnoreConfiguredEndpointUrlsField = "ignore_configured_endpoint_urls";

		private const string DisableRequestCompressionField = "disable_request_compression";

		private const string RequestMinCompressionSizeBytesField = "request_min_compression_size_bytes";

		private const string ClientAppIdField = "sdk_ua_app_id";

		private const string AccountIdEndpointModeField = "account_id_endpoint_mode";

		private const string RequestChecksumCalculationField = "request_checksum_calculation";

		private const string ResponseChecksumValidationField = "response_checksum_validation";

		private const string AwsAccountIdField = "aws_account_id";

		private readonly Logger _logger = Logger.GetLogger(typeof(SharedCredentialsFile));

		private static readonly HashSet<string> ReservedPropertyNames;

		private static readonly HashSet<CredentialProfileType> ProfileTypeWhitelist;

		private static readonly CredentialProfilePropertyMapping PropertyMapping;

		public static readonly string DefaultDirectory;

		public static readonly string DefaultConfigDirectory;

		private ProfileIniFile _credentialsFile;

		private ProfileIniFile _configFile;

		public static string DefaultFilePath { get; private set; }

		public static string DefaultConfigFilePath { get; private set; }

		public string FilePath { get; private set; }

		public string ConfigFilePath { get; private set; }

		static SharedCredentialsFile()
		{
			ReservedPropertyNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				"toolkit_artifact_guid", "region", "endpoint_discovery_enabled", "credential_process", "s3_use_arn_region", "s3_disable_express_session_auth", "s3_us_east_1_regional_endpoint", "s3_disable_multiregion_access_points", "retry_mode", "max_attempts",
				"sso_account_id", "sso_region", "sso_registration_scopes", "sso_role_name", "sso_start_url", "sso_session", "ec2_metadata_service_endpoint", "ec2_metadata_service_endpoint_mode", "use_dualstack_endpoint", "use_fips_endpoint",
				"defaults_mode", "endpoint_url", "services", "ignore_configured_endpoint_urls", "disable_request_compression", "request_min_compression_size_bytes", "sdk_ua_app_id", "account_id_endpoint_mode", "request_checksum_calculation", "response_checksum_validation",
				"aws_account_id"
			};
			ProfileTypeWhitelist = new HashSet<CredentialProfileType>
			{
				CredentialProfileType.AssumeRole,
				CredentialProfileType.AssumeRoleCredentialSource,
				CredentialProfileType.AssumeRoleExternal,
				CredentialProfileType.AssumeRoleExternalMFA,
				CredentialProfileType.AssumeRoleMFA,
				CredentialProfileType.AssumeRoleWithWebIdentity,
				CredentialProfileType.AssumeRoleWithWebIdentitySessionName,
				CredentialProfileType.Basic,
				CredentialProfileType.Session,
				CredentialProfileType.CredentialProcess,
				CredentialProfileType.AssumeRoleSessionName,
				CredentialProfileType.AssumeRoleCredentialSourceSessionName,
				CredentialProfileType.AssumeRoleExternalSessionName,
				CredentialProfileType.AssumeRoleExternalMFASessionName,
				CredentialProfileType.AssumeRoleMFASessionName,
				CredentialProfileType.SSO
			};
			PropertyMapping = new CredentialProfilePropertyMapping(new Dictionary<string, string>
			{
				{ "AccessKey", "aws_access_key_id" },
				{ "CredentialSource", "credential_source" },
				{ "EndpointName", null },
				{ "ExternalID", "external_id" },
				{ "MfaSerial", "mfa_serial" },
				{ "RoleArn", "role_arn" },
				{ "RoleSessionName", "role_session_name" },
				{ "SecretKey", "aws_secret_access_key" },
				{ "SourceProfile", "source_profile" },
				{ "Token", "aws_session_token" },
				{ "UserIdentity", null },
				{ "CredentialProcess", "credential_process" },
				{ "WebIdentityTokenFile", "web_identity_token_file" },
				{ "AwsAccountId", "aws_account_id" },
				{ "SsoAccountId", "sso_account_id" },
				{ "SsoRegion", "sso_region" },
				{ "SsoRegistrationScopes", "sso_registration_scopes" },
				{ "SsoRoleName", "sso_role_name" },
				{ "SsoSession", "sso_session" },
				{ "SsoStartUrl", "sso_start_url" }
			});
			string environmentVariable = Environment.GetEnvironmentVariable("AWS_SHARED_CREDENTIALS_FILE");
			string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_CONFIG_FILE");
			if (!string.IsNullOrEmpty(environmentVariable2) && File.Exists(environmentVariable2))
			{
				DefaultConfigDirectory = Directory.GetParent(environmentVariable2).FullName;
				DefaultConfigFilePath = environmentVariable2;
			}
			if (!string.IsNullOrEmpty(environmentVariable) && File.Exists(environmentVariable))
			{
				DefaultDirectory = Directory.GetParent(environmentVariable).FullName;
				DefaultFilePath = environmentVariable;
			}
			if (DefaultFilePath == null || DefaultConfigFilePath == null)
			{
				string text = Environment.GetEnvironmentVariable("HOME");
				if (string.IsNullOrEmpty(text))
				{
					text = Environment.GetEnvironmentVariable("USERPROFILE");
				}
				if (string.IsNullOrEmpty(text))
				{
					text = Directory.GetCurrentDirectory();
				}
				if (DefaultFilePath == null)
				{
					DefaultDirectory = Path.Combine(text, ".aws");
					DefaultFilePath = Path.Combine(DefaultDirectory, "credentials");
				}
				if (DefaultConfigFilePath == null)
				{
					DefaultConfigDirectory = Path.Combine(text, ".aws");
					DefaultConfigFilePath = Path.Combine(DefaultConfigDirectory, "config");
				}
			}
		}

		public SharedCredentialsFile()
		{
			SetUpFilePath(null);
			Refresh();
		}

		public SharedCredentialsFile(string filePath)
		{
			SetUpFilePath(filePath);
			Refresh();
		}

		private void SetUpFilePath(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				if (string.IsNullOrEmpty(AWSConfigs.AWSProfilesLocation))
				{
					FilePath = DefaultFilePath;
					ConfigFilePath = DefaultConfigFilePath;
				}
				else
				{
					FilePath = AWSConfigs.AWSProfilesLocation;
					ConfigFilePath = DefaultConfigFilePath;
				}
			}
			else
			{
				FilePath = filePath;
				ConfigFilePath = DefaultConfigFilePath;
			}
		}

		public List<string> ListProfileNames()
		{
			Refresh();
			return (from p in ListProfiles()
				select p.Name).ToList();
		}

		public List<CredentialProfile> ListProfiles()
		{
			Refresh();
			List<CredentialProfile> list = new List<CredentialProfile>();
			foreach (string item in ListAllProfileNames())
			{
				CredentialProfile profile = null;
				if (TryGetProfile(item, doRefresh: false, isSsoSession: false, isServicesSection: false, out profile) && profile.CanCreateAWSCredentials)
				{
					list.Add(profile);
				}
			}
			return list;
		}

		public bool TryGetProfile(string profileName, out CredentialProfile profile)
		{
			return TryGetProfile(profileName, doRefresh: true, isSsoSession: false, isServicesSection: false, out profile);
		}

		public void RegisterProfile(CredentialProfile profile)
		{
			Refresh();
			if (profile.CanCreateAWSCredentials || profile.Options.IsEmpty)
			{
				if (!IsSupportedProfileType(profile.ProfileType))
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to update profile {0}. The CredentialProfile object provided represents a {1} profile but {2} does not support the {1} profile type.", profile.Name, profile.ProfileType, GetType().Name));
				}
				RegisterProfileInternal(profile);
				return;
			}
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to update profile {0}.  The CredentialProfile provided is not a valid profile.", profile.Name));
		}

		private void RegisterProfileInternal(CredentialProfile profile)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (profile.UniqueKey.HasValue)
			{
				dictionary["toolkit_artifact_guid"] = profile.UniqueKey.Value.ToString("D");
			}
			if (profile.Region != null)
			{
				dictionary["region"] = profile.Region.SystemName;
			}
			if (profile.EndpointDiscoveryEnabled.HasValue)
			{
				dictionary["endpoint_discovery_enabled"] = profile.EndpointDiscoveryEnabled.Value.ToString().ToLowerInvariant();
			}
			if (profile.S3UseArnRegion.HasValue)
			{
				dictionary["s3_use_arn_region"] = profile.S3UseArnRegion.Value.ToString().ToLowerInvariant();
			}
			if (profile.S3DisableExpressSessionAuth.HasValue)
			{
				dictionary["s3_disable_express_session_auth"] = profile.S3DisableExpressSessionAuth.Value.ToString().ToLowerInvariant();
			}
			if (profile.S3RegionalEndpoint.HasValue)
			{
				dictionary["s3_us_east_1_regional_endpoint"] = profile.S3RegionalEndpoint.ToString().ToLowerInvariant();
			}
			if (profile.S3DisableMultiRegionAccessPoints.HasValue)
			{
				dictionary["s3_disable_multiregion_access_points"] = profile.S3DisableMultiRegionAccessPoints.ToString().ToLowerInvariant();
			}
			if (profile.RetryMode.HasValue)
			{
				dictionary["retry_mode"] = profile.RetryMode.ToString().ToLowerInvariant();
			}
			if (profile.MaxAttempts.HasValue)
			{
				dictionary["max_attempts"] = profile.MaxAttempts.ToString().ToLowerInvariant();
			}
			if (profile.EC2MetadataServiceEndpoint != null)
			{
				dictionary["ec2_metadata_service_endpoint"] = profile.EC2MetadataServiceEndpoint.ToString().ToLowerInvariant();
			}
			if (profile.EC2MetadataServiceEndpointMode.HasValue)
			{
				dictionary["ec2_metadata_service_endpoint_mode"] = profile.EC2MetadataServiceEndpointMode.ToString().ToLowerInvariant();
			}
			if (profile.UseDualstackEndpoint.HasValue)
			{
				dictionary["use_dualstack_endpoint"] = profile.UseDualstackEndpoint.ToString().ToLowerInvariant();
			}
			if (profile.UseFIPSEndpoint.HasValue)
			{
				dictionary["use_fips_endpoint"] = profile.UseFIPSEndpoint.ToString().ToLowerInvariant();
			}
			if (profile.IgnoreConfiguredEndpointUrls.HasValue)
			{
				dictionary["ignore_configured_endpoint_urls"] = profile.IgnoreConfiguredEndpointUrls.ToString().ToLowerInvariant();
			}
			if (profile.EndpointUrl != null)
			{
				dictionary["endpoint_url"] = profile.EndpointUrl.ToString().ToLowerInvariant();
			}
			if (profile.DisableRequestCompression.HasValue)
			{
				dictionary["disable_request_compression"] = profile.DisableRequestCompression.ToString().ToLowerInvariant();
			}
			if (profile.RequestMinCompressionSizeBytes.HasValue)
			{
				dictionary["request_min_compression_size_bytes"] = profile.RequestMinCompressionSizeBytes.ToString().ToLowerInvariant();
			}
			if (profile.RequestChecksumCalculation.HasValue)
			{
				dictionary["request_checksum_calculation"] = profile.RequestChecksumCalculation.ToString().ToLowerInvariant();
			}
			if (profile.ResponseChecksumValidation.HasValue)
			{
				dictionary["response_checksum_validation"] = profile.ResponseChecksumValidation.ToString().ToLowerInvariant();
			}
			if (profile.ClientAppId != null)
			{
				dictionary["sdk_ua_app_id"] = profile.ClientAppId;
			}
			if (profile.AccountIdEndpointMode.HasValue)
			{
				dictionary["account_id_endpoint_mode"] = profile.AccountIdEndpointMode.ToString().ToLowerInvariant();
			}
			if (profile.Services != null)
			{
				dictionary["services"] = profile.Services.ToString().ToLowerInvariant();
			}
			Dictionary<string, string> dictionary2 = PropertyMapping.CombineProfileParts(profile.Options, ReservedPropertyNames, dictionary, profile.Properties);
			UpdateConfigSectionsFromProfile(profile, dictionary2);
			_credentialsFile.EditSection(profile.Name, new SortedDictionary<string, string>(dictionary2));
			_credentialsFile.Persist();
			profile.CredentialProfileStore = this;
		}

		private void UpdateConfigSectionsFromProfile(CredentialProfile profile, Dictionary<string, string> profileDictionary)
		{
			if (_configFile == null || !_configFile.TryGetSection(profile.Name, isSsoSession: false, isServicesSection: false, out var properties, out var nestedProperties))
			{
				return;
			}
			string[] array = properties.Keys.ToArray();
			foreach (string key in array)
			{
				if (profileDictionary.ContainsKey(key))
				{
					properties[key] = profileDictionary[key];
					profileDictionary.Remove(key);
				}
				else
				{
					properties[key] = null;
				}
			}
			_configFile.EditSection(profile.Name, new SortedDictionary<string, string>(properties));
			_configFile.Persist();
			if (properties.TryGetValue("sso_session", out var value) && _configFile.TryGetSection(value, isSsoSession: true, isServicesSection: false, out var properties2, out nestedProperties))
			{
				array = properties2.Keys.ToArray();
				foreach (string key2 in array)
				{
					profileDictionary.Remove(key2);
				}
			}
		}

		public void UnregisterProfile(string profileName)
		{
			Refresh();
			_credentialsFile.DeleteSection(profileName);
			_credentialsFile.Persist();
		}

		public void RenameProfile(string oldProfileName, string newProfileName)
		{
			RenameProfile(oldProfileName, newProfileName, force: false);
		}

		public void RenameProfile(string oldProfileName, string newProfileName, bool force)
		{
			Refresh();
			_credentialsFile.RenameSection(oldProfileName, newProfileName, force);
			_credentialsFile.Persist();
		}

		public void CopyProfile(string fromProfileName, string toProfileName)
		{
			CopyProfile(fromProfileName, toProfileName, force: false);
		}

		public void CopyProfile(string fromProfileName, string toProfileName, bool force)
		{
			Refresh();
			_credentialsFile.CopySection(fromProfileName, toProfileName, new Dictionary<string, string> { 
			{
				"toolkit_artifact_guid",
				Guid.NewGuid().ToString()
			} }, force);
			_credentialsFile.Persist();
		}

		private void Refresh()
		{
			_credentialsFile = new ProfileIniFile(FilePath, profileMarkerRequired: false);
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_CONFIG_FILE")))
			{
				_configFile = new ProfileIniFile(ConfigFilePath, profileMarkerRequired: true);
				return;
			}
			string text = Path.Combine(Path.GetDirectoryName(FilePath), "config");
			if (File.Exists(text))
			{
				_configFile = new ProfileIniFile(text, profileMarkerRequired: true);
			}
		}

		private HashSet<string> ListAllProfileNames()
		{
			HashSet<string> hashSet = _credentialsFile.ListSectionNames();
			if (_configFile != null)
			{
				hashSet.UnionWith(_configFile.ListSectionNames());
			}
			return hashSet;
		}

		private bool TryGetProfile(string profileName, bool doRefresh, bool isSsoSession, bool isServicesSection, out CredentialProfile profile)
		{
			if (doRefresh)
			{
				Refresh();
			}
			Dictionary<string, Dictionary<string, string>> nestedProperties = null;
			Dictionary<string, string> iniProperties = null;
			if (TryGetSection(profileName, isSsoSession, isServicesSection, out iniProperties, out nestedProperties))
			{
				PropertyMapping.ExtractProfileParts(iniProperties, ReservedPropertyNames, out var profileOptions, out var reservedProperties, out var userProperties);
				Guid? result = null;
				if (reservedProperties.TryGetValue("toolkit_artifact_guid", out var value) && !GuidUtils.TryParseNullableGuid(value, out result))
				{
					Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. GUID expected.", value, "toolkit_artifact_guid", profileName);
					profile = null;
					return false;
				}
				bool? flag = false;
				if (reservedProperties.TryGetValue("ignore_configured_endpoint_urls", out var value2))
				{
					if (!bool.TryParse(value2, out var result2))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected", value2, "ignore_configured_endpoint_urls", profileName);
						profile = null;
						return false;
					}
					flag = result2;
				}
				string endpointUrl = null;
				if (flag == false)
				{
					string value4;
					if (iniProperties.TryGetValue("services", out var value3))
					{
						_configFile.TryGetSection(value3, isSsoSession: false, isServicesSection: true, out userProperties, out nestedProperties);
					}
					else if (iniProperties.TryGetValue("endpoint_url", out value4))
					{
						endpointUrl = value4;
					}
				}
				RegionEndpoint region = null;
				if (reservedProperties.TryGetValue("region", out var value5))
				{
					region = RegionEndpoint.GetBySystemName(value5);
				}
				bool? endpointDiscoveryEnabled = null;
				if (reservedProperties.TryGetValue("endpoint_discovery_enabled", out var value6))
				{
					if (!bool.TryParse(value6, out var result3))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected.", value6, "endpoint_discovery_enabled", profileName);
						profile = null;
						return false;
					}
					endpointDiscoveryEnabled = result3;
				}
				bool? s3UseArnRegion = null;
				if (reservedProperties.TryGetValue("s3_use_arn_region", out var value7))
				{
					if (!bool.TryParse(value7, out var result4))
					{
						profile = null;
						return false;
					}
					s3UseArnRegion = result4;
				}
				bool? s3DisableExpressSessionAuth = null;
				if (reservedProperties.TryGetValue("s3_disable_express_session_auth", out var value8))
				{
					if (!bool.TryParse(value8, out var result5))
					{
						profile = null;
						return false;
					}
					s3DisableExpressSessionAuth = result5;
				}
				S3UsEast1RegionalEndpointValue? s3RegionalEndpoint = null;
				if (reservedProperties.TryGetValue("s3_us_east_1_regional_endpoint", out var value9))
				{
					if (!Enum.TryParse<S3UsEast1RegionalEndpointValue>(value9, ignoreCase: true, out var result6))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string regional/legacy is expected.", value9, "s3_us_east_1_regional_endpoint", profileName);
						profile = null;
						return false;
					}
					s3RegionalEndpoint = result6;
				}
				bool? s3DisableMultiRegionAccessPoints = null;
				if (reservedProperties.TryGetValue("s3_disable_multiregion_access_points", out var value10))
				{
					if (!bool.TryParse(value10, out var result7))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected.", value10, "s3_disable_multiregion_access_points", profileName);
						profile = null;
						return false;
					}
					s3DisableMultiRegionAccessPoints = result7;
				}
				RequestRetryMode? retryMode = null;
				if (reservedProperties.TryGetValue("retry_mode", out var value11))
				{
					if (!Enum.TryParse<RequestRetryMode>(value11, ignoreCase: true, out var result8))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string standard/adaptive is expected.", value11, "retry_mode", profileName);
						profile = null;
						return false;
					}
					retryMode = result8;
				}
				int? maxAttempts = null;
				if (reservedProperties.TryGetValue("max_attempts", out var value12))
				{
					if (!int.TryParse(value12, out var result9) || result9 <= 0)
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A positive integer is expected.", value12, "max_attempts", profileName);
						profile = null;
						return false;
					}
					maxAttempts = result9;
				}
				reservedProperties.TryGetValue("defaults_mode", out var value13);
				if (reservedProperties.TryGetValue("ec2_metadata_service_endpoint", out var value14) && !Uri.IsWellFormedUriString(value14, UriKind.Absolute))
				{
					throw new AmazonClientException("Invalid value " + value14 + " for ec2_metadata_service_endpoint in profile " + profileName + ". A well-formed Uri is expected.");
				}
				EC2MetadataServiceEndpointMode? eC2MetadataServiceEndpointMode = null;
				if (reservedProperties.TryGetValue("ec2_metadata_service_endpoint_mode", out var value15))
				{
					if (!Enum.TryParse<EC2MetadataServiceEndpointMode>(value15, ignoreCase: true, out var result10))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string IPv4 or IPV6 is expected.", value15, "ec2_metadata_service_endpoint_mode", profileName);
						profile = null;
						return false;
					}
					eC2MetadataServiceEndpointMode = result10;
				}
				if (iniProperties.TryGetValue("sso_session", out var value16))
				{
					profileOptions.SsoSession = value16;
					if (!TryGetProfile(value16, doRefresh: false, isSsoSession: true, isServicesSection: false, out var profile2))
					{
						_logger.InfoFormat("Failed to find sso_session [" + value16 + "]");
						throw new AmazonClientException("Invalid Configuration.  Failed to find sso_session [" + value16 + "]");
					}
					profileOptions.SsoRegion = profile2.Options.SsoRegion;
					profileOptions.SsoRegistrationScopes = profile2.Options.SsoRegistrationScopes;
					profileOptions.SsoStartUrl = profile2.Options.SsoStartUrl;
				}
				bool? useDualstackEndpoint = null;
				if (reservedProperties.TryGetValue("use_dualstack_endpoint", out var value17))
				{
					if (!bool.TryParse(value17, out var result11))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected.", value17, "use_dualstack_endpoint", profileName);
						profile = null;
						return false;
					}
					useDualstackEndpoint = result11;
				}
				bool? useFIPSEndpoint = null;
				if (reservedProperties.TryGetValue("use_fips_endpoint", out var value18))
				{
					if (!bool.TryParse(value18, out var result12))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected.", value18, "use_fips_endpoint", profileName);
						profile = null;
						return false;
					}
					useFIPSEndpoint = result12;
				}
				bool? disableRequestCompression = null;
				if (reservedProperties.TryGetValue("disable_request_compression", out var value19))
				{
					if (!bool.TryParse(value19, out var result13))
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A boolean true/false is expected.", value19, "disable_request_compression", profileName);
						profile = null;
						return false;
					}
					disableRequestCompression = result13;
				}
				long? requestMinCompressionSizeBytes = null;
				if (reservedProperties.TryGetValue("request_min_compression_size_bytes", out var value20))
				{
					if (!long.TryParse(value20, out var result14) || result14 < 0 || result14 > 10485760)
					{
						Logger.GetLogger(GetType()).InfoFormat("Invalid value {0} for {1} in profile {2}. A long value between 0 and {3} bytes inclusive is expected.", value20, "request_min_compression_size_bytes", profileName, 10485760L);
						profile = null;
						return false;
					}
					requestMinCompressionSizeBytes = result14;
				}
				string value21 = null;
				if (reservedProperties.TryGetValue("sdk_ua_app_id", out value21) && value21 != null && value21.Length > 50)
				{
					Logger.GetLogger(GetType()).InfoFormat("Warning: Client app id in profile {0} exceeds recommended maximum length of {1} characters: \"{2}\"", profileName, 50, value21);
				}
				string value22 = null;
				reservedProperties.TryGetValue("services", out value22);
				AccountIdEndpointMode? accountIdEndpointMode = null;
				if (reservedProperties.TryGetValue("account_id_endpoint_mode", out var value23))
				{
					if (!Enum.TryParse<AccountIdEndpointMode>(value23, ignoreCase: true, out var result15))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string  preferred/disabled/required is expected.", value23, "account_id_endpoint_mode", profileName);
						profile = null;
						return false;
					}
					accountIdEndpointMode = result15;
				}
				RequestChecksumCalculation? requestChecksumCalculation = null;
				if (reservedProperties.TryGetValue("request_checksum_calculation", out var value24))
				{
					if (!Enum.TryParse<RequestChecksumCalculation>(value24, ignoreCase: true, out var result16))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string WHEN_SUPPORTED or WHEN_REQUIRED is expected.", value24, "request_checksum_calculation", profileName);
						profile = null;
						return false;
					}
					requestChecksumCalculation = result16;
				}
				ResponseChecksumValidation? responseChecksumValidation = null;
				if (reservedProperties.TryGetValue("response_checksum_validation", out var value25))
				{
					if (!Enum.TryParse<ResponseChecksumValidation>(value25, ignoreCase: true, out var result17))
					{
						_logger.InfoFormat("Invalid value {0} for {1} in profile {2}. A string WHEN_SUPPORTED or WHEN_REQUIRED is expected.", value25, "response_checksum_validation", profileName);
						profile = null;
						return false;
					}
					responseChecksumValidation = result17;
				}
				profile = new CredentialProfile(profileName, profileOptions)
				{
					UniqueKey = result,
					Properties = userProperties,
					Region = region,
					CredentialProfileStore = this,
					DefaultConfigurationModeName = value13,
					EndpointDiscoveryEnabled = endpointDiscoveryEnabled,
					S3UseArnRegion = s3UseArnRegion,
					S3DisableExpressSessionAuth = s3DisableExpressSessionAuth,
					S3RegionalEndpoint = s3RegionalEndpoint,
					S3DisableMultiRegionAccessPoints = s3DisableMultiRegionAccessPoints,
					RetryMode = retryMode,
					MaxAttempts = maxAttempts,
					EC2MetadataServiceEndpoint = value14,
					EC2MetadataServiceEndpointMode = eC2MetadataServiceEndpointMode,
					UseDualstackEndpoint = useDualstackEndpoint,
					UseFIPSEndpoint = useFIPSEndpoint,
					NestedProperties = nestedProperties,
					IgnoreConfiguredEndpointUrls = flag,
					EndpointUrl = endpointUrl,
					DisableRequestCompression = disableRequestCompression,
					RequestMinCompressionSizeBytes = requestMinCompressionSizeBytes,
					ClientAppId = value21,
					AccountIdEndpointMode = accountIdEndpointMode,
					RequestChecksumCalculation = requestChecksumCalculation,
					ResponseChecksumValidation = responseChecksumValidation,
					Services = value22
				};
				if (!IsSupportedProfileType(profile.ProfileType))
				{
					_logger.InfoFormat("The profile type {0} is not supported by SharedCredentialsFile.", profile.ProfileType);
					profile = null;
					return false;
				}
				return true;
			}
			profile = null;
			return false;
		}

		private bool TryGetSection(string sectionName, bool isSsoSession, bool isServicesSection, out Dictionary<string, string> iniProperties, out Dictionary<string, Dictionary<string, string>> nestedProperties)
		{
			Dictionary<string, string> properties = null;
			Dictionary<string, string> properties2 = null;
			nestedProperties = null;
			bool flag = _credentialsFile.TryGetSection(sectionName, isSsoSession, isServicesSection, out properties, out nestedProperties);
			bool flag2 = false;
			if (_configFile != null)
			{
				_configFile.ProfileMarkerRequired = sectionName != "default";
				flag2 = _configFile.TryGetSection(sectionName, isSsoSession, isServicesSection, out properties2, out nestedProperties);
			}
			if (flag2)
			{
				iniProperties = properties2;
				if (flag)
				{
					foreach (KeyValuePair<string, string> item in properties)
					{
						iniProperties[item.Key] = item.Value;
					}
				}
				return true;
			}
			iniProperties = properties;
			return flag;
		}

		private static bool IsSupportedProfileType(CredentialProfileType? profileType)
		{
			if (profileType.HasValue)
			{
				return ProfileTypeWhitelist.Contains(profileType.Value);
			}
			return true;
		}
	}
}
