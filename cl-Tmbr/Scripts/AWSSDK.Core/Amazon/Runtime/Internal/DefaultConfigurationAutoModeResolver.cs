using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class DefaultConfigurationAutoModeResolver : IDefaultConfigurationAutoModeResolver
	{
		private readonly IRuntimeInformationProvider _runtimeInformationProvider;

		private readonly IEnvironmentVariableRetriever _environmentVariableRetriever;

		public DefaultConfigurationAutoModeResolver(IRuntimeInformationProvider runtimeInformationProvider, IEnvironmentVariableRetriever environmentVariableRetriever)
		{
			_runtimeInformationProvider = runtimeInformationProvider;
			_environmentVariableRetriever = environmentVariableRetriever;
		}

		public DefaultConfigurationMode Resolve(RegionEndpoint clientRegion, Func<RegionEndpoint> imdsRegion)
		{
			DefaultConfigurationMode defaultConfigurationMode = ResolveInternal(clientRegion, imdsRegion);
			Logger.GetLogger(GetType()).InfoFormat(string.Format("Resolved {0} for {1} [{2}] to [{3}].", "DefaultConfigurationMode", "RegionEndpoint", clientRegion?.SystemName, defaultConfigurationMode));
			return defaultConfigurationMode;
		}

		private DefaultConfigurationMode ResolveInternal(RegionEndpoint clientRegion, Func<RegionEndpoint> imdsRegion)
		{
			if (_runtimeInformationProvider.IsMobile())
			{
				return DefaultConfigurationMode.Mobile;
			}
			string text = null;
			if (!string.IsNullOrEmpty(_environmentVariableRetriever.GetEnvironmentVariable(InternalSDKUtils.EXECUTION_ENVIRONMENT_ENVVAR)))
			{
				text = _environmentVariableRetriever.GetEnvironmentVariable("AWS_REGION");
				if (string.IsNullOrEmpty(text))
				{
					text = _environmentVariableRetriever.GetEnvironmentVariable("AWS_DEFAULT_REGION");
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = imdsRegion()?.SystemName;
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (clientRegion.SystemName == text)
				{
					return DefaultConfigurationMode.InRegion;
				}
				return DefaultConfigurationMode.CrossRegion;
			}
			return DefaultConfigurationMode.Standard;
		}
	}
}
