using Restory.Gameplay.Tutorials;
using Restory.Gameplay.Tutorials.Handlers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class TutorialServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private TutorialService tutorialServicePrefab;

		public override void InstallBindings()
		{
			InstallTutorialService();
		}

		private void InstallTutorialService()
		{
			base.Container.Bind<TutorialHandlerFactory>().FromNew().AsSingle()
				.WhenInjectedInto<TutorialService>();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(tutorialServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<TutorialService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
