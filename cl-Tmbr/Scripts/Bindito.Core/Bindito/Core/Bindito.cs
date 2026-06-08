using System.Collections.Generic;
using System.Linq;
using Bindito.Core.Internal;

namespace Bindito.Core
{
	public static class Bindito
	{
		public static IContainer CreateContainer(params IConfigurator[] configurators)
		{
			return CreateContainer(configurators.AsEnumerable());
		}

		public static IContainer CreateContainer(IEnumerable<IConfigurator> configurators)
		{
			return new ContainerCreator().CreateContainer(configurators);
		}
	}
}
