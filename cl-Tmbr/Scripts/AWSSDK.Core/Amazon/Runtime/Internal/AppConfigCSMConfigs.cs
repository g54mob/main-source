using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class AppConfigCSMConfigs
	{
		public AppConfigCSMConfigs(CSMFallbackConfigChain cSMFallbackConfigChain)
		{
			CSMConfiguration cSMConfiguration = cSMFallbackConfigChain.CSMConfiguration;
			Logger logger = Logger.GetLogger(typeof(AppConfigCSMConfigs));
			if (!AWSConfigs.CSMConfig.CSMEnabled.HasValue)
			{
				return;
			}
			cSMFallbackConfigChain.IsConfigSet = true;
			if (AWSConfigs.CSMConfig.CSMEnabled != true)
			{
				return;
			}
			cSMFallbackConfigChain.ConfigSource = "app config";
			cSMConfiguration.Enabled = AWSConfigs.CSMConfig.CSMEnabled == true;
			if (cSMConfiguration.Enabled)
			{
				if (!string.IsNullOrEmpty(AWSConfigs.CSMConfig.CSMClientId))
				{
					cSMConfiguration.ClientId = AWSConfigs.CSMConfig.CSMClientId;
				}
				cSMConfiguration.Host = AWSConfigs.CSMConfig.CSMHost;
				cSMConfiguration.Port = AWSConfigs.CSMConfig.CSMPort;
				logger.DebugFormat(string.Format(CultureInfo.InvariantCulture, "CSM configurations found using application configuration file. values are CSM enabled = {0}, host = {1}, port = {2}, clientid = {3}", cSMConfiguration.Enabled, cSMConfiguration.Host, cSMConfiguration.Port, cSMConfiguration.ClientId));
			}
		}
	}
}
