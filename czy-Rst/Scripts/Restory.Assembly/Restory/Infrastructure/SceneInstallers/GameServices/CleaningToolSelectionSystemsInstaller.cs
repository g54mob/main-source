using Restory.Gameplay.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class CleaningToolSelectionSystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject systemsPrefab;

		[SerializeField]
		private GameObject testToolPrefab;

		public override void InstallBindings()
		{
			InstallSystems();
			InstallTester();
		}

		private void InstallSystems()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(systemsPrefab);
			base.Container.Bind<AvailableToolsTrackingService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<CleaningToolSelectionService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<UnscrewingToolSelectionService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallTester()
		{
			base.Container.InstantiateAndQueueForInject(testToolPrefab.gameObject);
		}
	}
}
