using Bindito.Core;
using Timberborn.EntityPanelSystem;

namespace Timberborn.HaulingUI
{
	[Context("Game")]
	internal class HaulingUIConfigurator : Configurator
	{
		private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
		{
			private readonly HaulCandidateDebugFragment _haulCandidateDebugFragment;

			private readonly HaulCandidateFragment _haulCandidateFragment;

			public EntityPanelModuleProvider(HaulCandidateDebugFragment haulCandidateDebugFragment, HaulCandidateFragment haulCandidateFragment)
			{
				_haulCandidateDebugFragment = haulCandidateDebugFragment;
				_haulCandidateFragment = haulCandidateFragment;
			}

			public EntityPanelModule Get()
			{
				EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
				builder.AddDiagnosticFragment(_haulCandidateDebugFragment);
				builder.AddMiddleFragment(_haulCandidateFragment, 10);
				return builder.Build();
			}
		}

		protected override void Configure()
		{
			Bind<HaulCandidateDebugFragment>().AsSingleton();
			Bind<HaulCandidateFragment>().AsSingleton();
			Bind<HaulCandidateBatchControlRowItemFactory>().AsSingleton();
			MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
		}
	}
}
