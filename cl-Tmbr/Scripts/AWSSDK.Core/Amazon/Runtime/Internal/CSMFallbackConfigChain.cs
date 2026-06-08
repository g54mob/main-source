using System;
using System.Collections.Generic;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class CSMFallbackConfigChain
	{
		public delegate void ConfigurationSource();

		private readonly ILogger LOGGER = Logger.GetLogger(typeof(CSMFallbackConfigChain));

		private static CredentialProfileStoreChain credentialProfileChain = new CredentialProfileStoreChain(AWSConfigs.AWSProfilesLocation);

		public List<ConfigurationSource> AllGenerators { get; set; }

		internal bool IsConfigSet { get; set; }

		public string ConfigSource { get; set; }

		public CSMConfiguration CSMConfiguration { get; internal set; }

		public CSMFallbackConfigChain()
		{
			CSMConfiguration = new CSMConfiguration();
			AllGenerators = new List<ConfigurationSource>
			{
				delegate
				{
					new AppConfigCSMConfigs(this);
				},
				delegate
				{
					new EnvironmentVariableCSMConfigs(this);
				},
				delegate
				{
					new ProfileCSMConfigs(credentialProfileChain, this);
				}
			};
		}

		public CSMConfiguration GetCSMConfig()
		{
			foreach (ConfigurationSource allGenerator in AllGenerators)
			{
				try
				{
					allGenerator();
					if (IsConfigSet)
					{
						break;
					}
				}
				catch (Exception exception)
				{
					LOGGER.Error(exception, "Error looking for CSM configuration");
				}
			}
			return CSMConfiguration;
		}
	}
}
