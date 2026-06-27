using Restory.Gameplay.Tutorials;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TutorialRegistryInstaller : MonoInstaller
	{
		[SerializeField]
		private TutorialRegistry tutorialRegistryPrefab;

		public override void InstallBindings()
		{
			InstallTutorialRegistry();
		}

		private void InstallTutorialRegistry()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(tutorialRegistryPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<TutorialRegistry>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
