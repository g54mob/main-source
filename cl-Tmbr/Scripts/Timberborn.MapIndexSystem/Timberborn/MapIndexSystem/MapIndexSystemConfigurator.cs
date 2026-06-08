using Bindito.Core;

namespace Timberborn.MapIndexSystem
{
	[Context("Game")]
	[Context("MapEditor")]
	internal class MapIndexSystemConfigurator : Configurator
	{
		protected override void Configure()
		{
			Bind<MapIndexService>().AsSingleton();
			Bind<FloatPackedListSerializer>().AsSingleton();
			Bind<IntPackedListSerializer>().AsSingleton();
			Bind<BoolPackedListSerializer>().AsSingleton();
		}
	}
}
