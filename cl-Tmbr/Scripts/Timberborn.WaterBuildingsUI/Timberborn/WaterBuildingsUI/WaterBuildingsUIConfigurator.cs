using Bindito.Core;
using Timberborn.EntityPanelSystem;
using Timberborn.TemplateInstantiation;
using Timberborn.WaterBuildings;

namespace Timberborn.WaterBuildingsUI
{
	[Context("Game")]
	internal class WaterBuildingsUIConfigurator : Configurator
	{
		private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
		{
			private readonly FloodgateFragment _floodgateFragment;

			private readonly ValveFragment _valveFragment;

			private readonly ValveDebugFragment _valveDebugFragment;

			private readonly FillValveFragment _fillValveFragment;

			private readonly StreamGaugeFragment _streamGaugeFragment;

			private readonly WaterMoverFragment _waterMoverFragment;

			private readonly WaterInputDepthFragment _waterInputDepthFragment;

			private readonly SluiceFragment _sluiceFragment;

			public EntityPanelModuleProvider(FloodgateFragment floodgateFragment, ValveFragment valveFragment, ValveDebugFragment valveDebugFragment, FillValveFragment fillValveFragment, StreamGaugeFragment streamGaugeFragment, WaterMoverFragment waterMoverFragment, WaterInputDepthFragment waterInputDepthFragment, SluiceFragment sluiceFragment)
			{
				_floodgateFragment = floodgateFragment;
				_valveFragment = valveFragment;
				_valveDebugFragment = valveDebugFragment;
				_fillValveFragment = fillValveFragment;
				_streamGaugeFragment = streamGaugeFragment;
				_waterMoverFragment = waterMoverFragment;
				_waterInputDepthFragment = waterInputDepthFragment;
				_sluiceFragment = sluiceFragment;
			}

			public EntityPanelModule Get()
			{
				EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
				builder.AddTopFragment(_floodgateFragment);
				builder.AddTopFragment(_valveFragment);
				builder.AddDiagnosticFragment(_valveDebugFragment);
				builder.AddTopFragment(_fillValveFragment);
				builder.AddTopFragment(_streamGaugeFragment);
				builder.AddTopFragment(_waterMoverFragment);
				builder.AddTopFragment(_waterInputDepthFragment);
				builder.AddTopFragment(_sluiceFragment);
				return builder.Build();
			}
		}

		protected override void Configure()
		{
			Bind<SluiceMarker>().AsTransient();
			Bind<FillValveMarker>().AsTransient();
			Bind<WaterOutputParticleLength>().AsTransient();
			Bind<FloodedBuildingStatus>().AsTransient();
			Bind<NeedsWaterBuildingStatus>().AsTransient();
			Bind<WaterDirectionPreviewMarker>().AsTransient();
			Bind<WaterBuildingDescriber>().AsTransient();
			Bind<WaterInputSpecDescriber>().AsTransient();
			Bind<WaterOutputParticle>().AsTransient();
			Bind<WaterOutputParticleColorer>().AsTransient();
			Bind<FloodgateFragment>().AsSingleton();
			Bind<ValveFragment>().AsSingleton();
			Bind<ValveDebugFragment>().AsSingleton();
			Bind<FillValveFragment>().AsSingleton();
			Bind<StreamGaugeFragment>().AsSingleton();
			Bind<WaterMoverToggleFactory>().AsSingleton();
			Bind<WaterMoverFragment>().AsSingleton();
			Bind<WaterInputDepthFragment>().AsSingleton();
			Bind<SluiceFragment>().AsSingleton();
			Bind<SluiceToggleFactory>().AsSingleton();
			Bind<WaterOutputParticleColors>().AsSingleton();
			MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
			MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
		}

		private static TemplateModule ProvideTemplateModule()
		{
			TemplateModule.Builder builder = new TemplateModule.Builder();
			builder.AddDecorator<FloodableBuilding, FloodedBuildingStatus>();
			builder.AddDecorator<IWaterNeedingBuilding, NeedsWaterBuildingStatus>();
			builder.AddDecorator<IWaterNeedingBuilding, WaterBuildingDescriber>();
			builder.AddDecorator<WaterInput, WaterBuildingDescriber>();
			builder.AddDecorator<WaterInputSpec, WaterInputSpecDescriber>();
			builder.AddDecorator<StreamGauge, WaterBuildingDescriber>();
			builder.AddDecorator<WaterWheelSpec, WaterBuildingDescriber>();
			builder.AddDecorator<WaterOutputParticleSpec, WaterOutputParticle>();
			builder.AddDecorator<WaterOutputParticle, WaterOutputParticleColorer>();
			builder.AddDecorator<WaterOutputParticle, WaterOutputParticleLength>();
			builder.AddDecorator<Sluice, SluiceMarker>();
			builder.AddDecorator<Sluice, WaterDirectionPreviewMarker>();
			builder.AddDecorator<Valve, WaterDirectionPreviewMarker>();
			builder.AddDecorator<FillValve, WaterDirectionPreviewMarker>();
			builder.AddDecorator<FillValve, FillValveMarker>();
			return builder.Build();
		}
	}
}
