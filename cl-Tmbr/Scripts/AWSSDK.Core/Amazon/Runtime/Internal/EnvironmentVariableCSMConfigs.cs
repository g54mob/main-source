using System.Globalization;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class EnvironmentVariableCSMConfigs
	{
		private const string CSM_ENABLED = "AWS_CSM_ENABLED";

		private const string CSM_CLIENTID = "AWS_CSM_CLIENT_ID";

		private const string CSM_HOST = "AWS_CSM_HOST";

		private const string CSM_PORT = "AWS_CSM_PORT";

		private IEnvironmentVariableRetriever environmentRetriever { get; set; } = EnvironmentVariableSource.Instance.EnvironmentVariableRetriever;

		public EnvironmentVariableCSMConfigs(IEnvironmentVariableRetriever environmentRetriever, CSMFallbackConfigChain cSMFallbackConfigChain)
		{
			this.environmentRetriever = environmentRetriever;
			SetupConfiguration(cSMFallbackConfigChain);
		}

		public EnvironmentVariableCSMConfigs(CSMFallbackConfigChain cSMFallbackConfigChain)
		{
			SetupConfiguration(cSMFallbackConfigChain);
		}

		private void SetupConfiguration(CSMFallbackConfigChain cSMFallbackConfigChain)
		{
			CSMConfiguration cSMConfiguration = cSMFallbackConfigChain.CSMConfiguration;
			Logger logger = Logger.GetLogger(typeof(EnvironmentVariableCSMConfigs));
			string environmentVariable = environmentRetriever.GetEnvironmentVariable("AWS_CSM_ENABLED");
			if (string.IsNullOrEmpty(environmentVariable))
			{
				return;
			}
			cSMFallbackConfigChain.IsConfigSet = true;
			cSMFallbackConfigChain.ConfigSource = "environment variable";
			if (bool.TryParse(environmentVariable, out var result))
			{
				cSMConfiguration.Enabled = result;
				if (cSMConfiguration.Enabled)
				{
					cSMConfiguration.ClientId = environmentRetriever.GetEnvironmentVariable("AWS_CSM_CLIENT_ID") ?? cSMConfiguration.ClientId;
					string environmentVariable2 = environmentRetriever.GetEnvironmentVariable("AWS_CSM_PORT");
					if (!string.IsNullOrEmpty(environmentVariable2))
					{
						if (!int.TryParse(environmentVariable2, out var result2))
						{
							throw new AmazonClientException("Unexpected environment variable value type AWS_CSM_PORT. Set a valid integer value.");
						}
						cSMConfiguration.Port = result2;
					}
					string environmentVariable3 = environmentRetriever.GetEnvironmentVariable("AWS_CSM_HOST");
					if (!string.IsNullOrEmpty(environmentVariable3))
					{
						cSMConfiguration.Host = environmentVariable3;
					}
				}
				logger.DebugFormat(string.Format(CultureInfo.InvariantCulture, "CSM configurations found using environment variable. values are CSM enabled = {0}, host = {1}, port = {2}, clientid = {3}", cSMConfiguration.Enabled, cSMConfiguration.Host, cSMConfiguration.Port, cSMConfiguration.ClientId));
				return;
			}
			throw new AmazonClientException("Unexpected environment variable value type AWS_CSM_ENABLED. Set a valid boolean value.");
		}
	}
}
