using Restory.Gameplay.PC;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public sealed class PcAppManagerInstaller : MonoInstaller
	{
		[SerializeField]
		private PcAppManager pcAppManagerPrefab;

		public override void InstallBindings()
		{
			InstallPcAppManager();
			InstallPcAppFactory();
		}

		private void InstallPcAppManager()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(pcAppManagerPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<PcAppManager>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallPcAppFactory()
		{
			base.Container.BindInterfacesAndSelfTo<PcAppFactory>().FromNew().AsSingle()
				.WhenInjectedInto<PcAppManager>();
		}
	}
}
