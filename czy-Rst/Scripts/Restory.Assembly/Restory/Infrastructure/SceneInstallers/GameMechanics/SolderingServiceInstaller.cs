using Restory.Data.Soldering;
using Restory.Gameplay.Soldering;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class SolderingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private SolderingVfxController solderingVfxControllerPrefab;

		[SerializeField]
		private SolderingProcessSettings solderingProcessSettings;

		public override void InstallBindings()
		{
			InstallSolderingService();
			InstallSolderingProcessController();
			InstallSolderingVfxController();
			InstallSolderingProcessSettings();
		}

		private void InstallSolderingService()
		{
			base.Container.BindInterfacesAndSelfTo<SolderingService>().FromNew().AsSingle();
		}

		private void InstallSolderingProcessController()
		{
			base.Container.BindInterfacesAndSelfTo<SolderingProcessController>().FromNew().AsSingle()
				.WhenInjectedInto<SolderingService>();
		}

		private void InstallSolderingVfxController()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(solderingVfxControllerPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<SolderingVfxController>().FromComponentOn(gameObject).AsSingle()
				.WhenInjectedInto<SolderingService>();
		}

		private void InstallSolderingProcessSettings()
		{
			base.Container.Bind<SolderingProcessSettings>().FromInstance(solderingProcessSettings).AsSingle()
				.WhenInjectedInto<SolderingProcessController>();
		}
	}
}
