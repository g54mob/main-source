using Bindito.Core;
using Timberborn.Carrying;
using Timberborn.GameDistricts;
using Timberborn.TemplateInstantiation;

namespace Timberborn.ResourceCountingSystem
{
	[Context("Game")]
	internal class ResourceCountingSystemConfigurator : Configurator
	{
		protected override void Configure()
		{
			Bind<DistrictResourceCounter>().AsTransient();
			Bind<GoodProcessorRegistrar>().AsTransient();
			Bind<GoodCarrierRegistrar>().AsTransient();
			Bind<ResourceCountingService>().AsSingleton();
			MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
		}

		private static TemplateModule ProvideTemplateModule()
		{
			TemplateModule.Builder builder = new TemplateModule.Builder();
			builder.AddDecorator<DistrictCenter, DistrictResourceCounter>();
			builder.AddDecorator<IGoodProcessor, GoodProcessorRegistrar>();
			builder.AddDecorator<GoodCarrier, GoodCarrierRegistrar>();
			return builder.Build();
		}
	}
}
