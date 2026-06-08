using System.Collections.Generic;
using System.Globalization;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class ProfileCSMConfigs
	{
		private const string CSM_ENABLED = "csm_enabled";

		private const string CSM_CLIENTID = "csm_clientid";

		private const string CSM_HOST = "csm_host";

		private const string CSM_PORT = "csm_port";

		private const string CSM_PROFILE_ERROR_MSG = "CSM configurations not found using profile store.";

		private string ProfileName { get; set; }

		public ProfileCSMConfigs(CSMFallbackConfigChain cSMFallbackConfigChain, string profileName, IDictionary<string, string> profileProperties)
		{
			ProfileName = profileName;
			Setup(cSMFallbackConfigChain, profileProperties);
		}

		public ProfileCSMConfigs(ICredentialProfileSource source, CSMFallbackConfigChain cSMFallbackConfigChain)
		{
			ProfileName = DefaultAWSCredentialsIdentityResolver.GetProfileName();
			if (source.TryGetProfile(ProfileName, out var profile))
			{
				Setup(cSMFallbackConfigChain, profile.Properties);
			}
		}

		private void Setup(CSMFallbackConfigChain cSMFallbackConfigChain, IDictionary<string, string> profileProperties)
		{
			Logger logger = Logger.GetLogger(typeof(ProfileCSMConfigs));
			CSMConfiguration cSMConfiguration = cSMFallbackConfigChain.CSMConfiguration;
			if (!profileProperties.TryGetValue("csm_enabled", out var value))
			{
				return;
			}
			cSMFallbackConfigChain.IsConfigSet = true;
			cSMFallbackConfigChain.ConfigSource = "shared profile";
			if (bool.TryParse(value, out var result))
			{
				cSMConfiguration.Enabled = result;
				if (cSMConfiguration.Enabled)
				{
					if (profileProperties.TryGetValue("csm_clientid", out var value2))
					{
						cSMConfiguration.ClientId = value2;
					}
					if (profileProperties.TryGetValue("csm_port", out var value3))
					{
						if (!int.TryParse(value3, out var result2))
						{
							throw new AmazonClientException("Unexpected profile variable value type csm_port. Set a valid integer value.");
						}
						cSMConfiguration.Port = result2;
					}
					if (profileProperties.TryGetValue("csm_host", out var value4) && !string.IsNullOrEmpty(value4))
					{
						cSMConfiguration.Host = value4;
					}
				}
				logger.DebugFormat(string.Format(CultureInfo.InvariantCulture, "CSM configurations found using profile store for the profile = {0}: values are CSM enabled = {1}, host = {2}, port = {3}, clientid = {4}", ProfileName, cSMConfiguration.Enabled, cSMConfiguration.Host, cSMConfiguration.Port, cSMConfiguration.ClientId));
				return;
			}
			throw new AmazonClientException("Unexpected profile variable value type csm_enabled. Set a valid boolean value.");
		}
	}
}
