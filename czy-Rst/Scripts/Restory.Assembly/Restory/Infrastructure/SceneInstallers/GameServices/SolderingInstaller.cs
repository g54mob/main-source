using Restory.Data.Soldering;
using Restory.Gameplay.Soldering;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class SolderingInstaller : MonoInstaller
	{
		[SerializeField]
		private BurntTraceGenerator burntTraceGeneratorPrefab;

		[SerializeField]
		private SolderPoint solderPointPrefab;

		[SerializeField]
		private SolderTraceFactorySettings solderTraceFactorySettings;

		public override void InstallBindings()
		{
			InstallSolderPointFactory();
			InstallSolderTraceFactory();
			InstallBurntTraceGenerator();
		}

		private void InstallSolderPointFactory()
		{
			base.Container.Bind<SolderPointPool>().FromNew().AsSingle()
				.WithArguments(solderPointPrefab.gameObject)
				.WhenInjectedInto<SolderPointFactory>();
			base.Container.Bind<SolderPointFactory>().FromNew().AsSingle();
		}

		private void InstallBurntTraceGenerator()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(burntTraceGeneratorPrefab.gameObject);
			base.Container.Bind<BurntTraceGenerator>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallSolderTraceFactory()
		{
			base.Container.Bind<SolderTraceFactorySettings>().FromInstance(solderTraceFactorySettings).AsSingle()
				.WhenInjectedInto<SolderTraceFactory>();
			base.Container.Bind<SolderTraceFactory>().FromNew().AsSingle();
		}
	}
}
