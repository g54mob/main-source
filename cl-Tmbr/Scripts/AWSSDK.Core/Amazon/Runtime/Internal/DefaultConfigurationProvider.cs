using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal
{
	public class DefaultConfigurationProvider : IDefaultConfigurationProvider
	{
		private const string AWS_DEFAULTS_MODE_ENVIRONMENT_VARIABLE = "AWS_DEFAULTS_MODE";

		private readonly IEnvironmentVariableRetriever _environmentVariableRetriever;

		private readonly IDefaultConfigurationAutoModeResolver _defaultConfigurationAutoModeResolver;

		private readonly IDefaultConfiguration[] _availableConfigurations;

		public DefaultConfigurationProvider(IEnumerable<IDefaultConfiguration> availableConfigurations)
			: this(EnvironmentVariableSource.Instance.EnvironmentVariableRetriever, new DefaultConfigurationAutoModeResolver(new RuntimeInformationProvider(), EnvironmentVariableSource.Instance.EnvironmentVariableRetriever), availableConfigurations)
		{
		}

		public DefaultConfigurationProvider(IEnvironmentVariableRetriever environmentVariableRetriever, IDefaultConfigurationAutoModeResolver defaultConfigurationAutoModeResolver, IEnumerable<IDefaultConfiguration> availableConfigurations)
			: this(environmentVariableRetriever, defaultConfigurationAutoModeResolver, availableConfigurations.ToArray())
		{
		}

		public DefaultConfigurationProvider(IEnvironmentVariableRetriever environmentVariableRetriever, IDefaultConfigurationAutoModeResolver defaultConfigurationAutoModeResolver, params IDefaultConfiguration[] availableConfigurations)
		{
			if (availableConfigurations == null || !availableConfigurations.Any())
			{
				throw new ArgumentException("Must provide at least one Default Configuration", "availableConfigurations");
			}
			_environmentVariableRetriever = environmentVariableRetriever;
			_defaultConfigurationAutoModeResolver = defaultConfigurationAutoModeResolver;
			_availableConfigurations = availableConfigurations;
		}

		public IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null)
		{
			string text = requestedConfigurationMode?.ToString() ?? _environmentVariableRetriever.GetEnvironmentVariable("AWS_DEFAULTS_MODE") ?? FallbackInternalConfigurationFactory.DefaultConfigurationModeName ?? DefaultConfigurationMode.Standard.ToString();
			Logger.GetLogger(GetType()).InfoFormat("Resolved DefaultConfigurationMode for RegionEndpoint [" + clientRegion?.SystemName + "] to [" + text + "].");
			try
			{
				DefaultConfigurationMode mode = (DefaultConfigurationMode)Enum.Parse(typeof(DefaultConfigurationMode), text, ignoreCase: true);
				if (mode == DefaultConfigurationMode.Auto)
				{
					mode = _defaultConfigurationAutoModeResolver.Resolve(clientRegion, () => EC2InstanceMetadata.Region);
				}
				return _availableConfigurations.First((IDefaultConfiguration x) => x.Name == mode);
			}
			catch (Exception)
			{
				throw new AmazonClientException("Failed to find requested Default Configuration Mode '" + text + "'.  Valid values are " + string.Join(",", Enum.GetNames(typeof(DefaultConfigurationMode))));
			}
		}
	}
}
