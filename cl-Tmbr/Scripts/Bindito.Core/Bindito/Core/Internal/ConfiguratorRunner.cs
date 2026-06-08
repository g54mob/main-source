using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class ConfiguratorRunner
	{
		private readonly IContainerDefinition _containerDefinition;

		public ConfiguratorRunner(IContainerDefinition containerDefinition)
		{
			_containerDefinition = containerDefinition;
		}

		public void RunConfigurators(IEnumerable<IConfigurator> configurators)
		{
			foreach (IConfigurator configurator in configurators)
			{
				configurator.Configure(_containerDefinition);
			}
		}
	}
}
