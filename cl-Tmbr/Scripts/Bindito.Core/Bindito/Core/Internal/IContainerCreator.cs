using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IContainerCreator
	{
		IContainer CreateContainer(IEnumerable<IConfigurator> configurators);

		IContainer CreateChildContainer(IEnumerable<IConfigurator> configurators);
	}
}
