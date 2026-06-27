using Restory.Gameplay.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class InteractiveObjectServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private InteractiveObjectService interactiveObjectServicePrefab;

		public override void InstallBindings()
		{
			InstallInteractiveObjectSaveLoadService();
			InstallInteractiveObjectFactory();
			InstallInteractiveObjectRegistry();
			InstallBoxesCreationService();
			InstallInteractiveObjectContainersObserver();
		}

		private void InstallInteractiveObjectSaveLoadService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(interactiveObjectServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<InteractiveObjectService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallInteractiveObjectFactory()
		{
			base.Container.BindInterfacesAndSelfTo<InteractiveObjectFactory>().FromNew().AsSingle();
		}

		private void InstallInteractiveObjectRegistry()
		{
			base.Container.BindInterfacesAndSelfTo<InteractiveObjectRegistry>().FromNew().AsSingle();
		}

		private void InstallBoxesCreationService()
		{
			base.Container.Bind<BoxContainersCreationService>().FromNew().AsSingle();
		}

		private void InstallInteractiveObjectContainersObserver()
		{
			base.Container.BindInterfacesAndSelfTo<InteractiveObjectContainersObserver>().FromNew().AsSingle();
		}
	}
}
