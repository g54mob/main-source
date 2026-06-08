using System.Collections.Generic;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class ProfileInternalConfiguration : InternalConfiguration
	{
		private Logger _logger = Logger.GetLogger(typeof(ProfileInternalConfiguration));

		public ProfileInternalConfiguration(ICredentialProfileSource source)
		{
			string profileName = DefaultAWSCredentialsIdentityResolver.GetProfileName();
			Setup(source, profileName);
		}

		public ProfileInternalConfiguration(ICredentialProfileSource source, string profileName)
		{
			Setup(source, profileName);
		}

		private void Setup(ICredentialProfileSource source, string profileName)
		{
			if (source.TryGetProfile(profileName, out var profile))
			{
				base.DefaultConfigurationModeName = profile.DefaultConfigurationModeName;
				base.EndpointDiscoveryEnabled = profile.EndpointDiscoveryEnabled;
				base.RetryMode = profile.RetryMode;
				base.MaxAttempts = profile.MaxAttempts;
				base.EC2MetadataServiceEndpoint = profile.EC2MetadataServiceEndpoint;
				base.EC2MetadataServiceEndpointMode = profile.EC2MetadataServiceEndpointMode;
				base.UseDualstackEndpoint = profile.UseDualstackEndpoint;
				base.UseFIPSEndpoint = profile.UseFIPSEndpoint;
				base.IgnoreConfiguredEndpointUrls = profile.IgnoreConfiguredEndpointUrls;
				base.DisableRequestCompression = profile.DisableRequestCompression;
				base.RequestMinCompressionSizeBytes = profile.RequestMinCompressionSizeBytes;
				base.ClientAppId = profile.ClientAppId;
				base.AccountIdEndpointMode = profile.AccountIdEndpointMode;
				base.RequestChecksumCalculation = profile.RequestChecksumCalculation;
				base.ResponseChecksumValidation = profile.ResponseChecksumValidation;
				KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[16]
				{
					new KeyValuePair<string, object>("defaults_mode", profile.DefaultConfigurationModeName),
					new KeyValuePair<string, object>("endpoint_discovery_enabled", profile.EndpointDiscoveryEnabled),
					new KeyValuePair<string, object>("retry_mode", profile.RetryMode),
					new KeyValuePair<string, object>("max_attempts", profile.MaxAttempts),
					new KeyValuePair<string, object>("ec2_metadata_service_endpoint", profile.EC2MetadataServiceEndpoint),
					new KeyValuePair<string, object>("ec2_metadata_service_endpoint_mode", profile.EC2MetadataServiceEndpointMode),
					new KeyValuePair<string, object>("use_dualstack_endpoint", profile.UseDualstackEndpoint),
					new KeyValuePair<string, object>("use_fips_endpoint", profile.UseFIPSEndpoint),
					new KeyValuePair<string, object>("ignore_configured_endpoint_urls", profile.IgnoreConfiguredEndpointUrls),
					new KeyValuePair<string, object>("endpoint_url", profile.EndpointUrl),
					new KeyValuePair<string, object>("disable_request_compression", profile.DisableRequestCompression),
					new KeyValuePair<string, object>("request_min_compression_size_bytes", profile.RequestMinCompressionSizeBytes),
					new KeyValuePair<string, object>("sdk_ua_app_id", profile.ClientAppId),
					new KeyValuePair<string, object>("account_id_endpoint_mode", profile.AccountIdEndpointMode),
					new KeyValuePair<string, object>("request_checksum_calculation", profile.RequestChecksumCalculation),
					new KeyValuePair<string, object>("response_checksum_validation", profile.ResponseChecksumValidation)
				};
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, object> keyValuePair = array[i];
					_logger.DebugFormat((keyValuePair.Value == null) ? $"There is no {keyValuePair.Key} set in the profile named '{profileName}' in store {source.GetType()}" : $"{keyValuePair.Key} found in profile '{profileName}' in store {source.GetType()}");
				}
			}
			else
			{
				_logger.InfoFormat("Unable to find a profile named '" + profileName + "' in store " + source.GetType());
			}
		}
	}
}
