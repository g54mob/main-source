using Bindito.Core;

namespace Timberborn.DuplicationSystem
{
	[Context("Game")]
	[Context("MapEditor")]
	internal class DuplicationSystemConfigurator : Configurator
	{
		protected override void Configure()
		{
			Bind<DuplicationBlocker>().AsTransient();
			Bind<Duplicator>().AsSingleton();
		}
	}
}
