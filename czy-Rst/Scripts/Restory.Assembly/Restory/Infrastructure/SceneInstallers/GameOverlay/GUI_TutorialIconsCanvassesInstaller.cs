using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_TutorialIconsCanvassesInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform gameWorldTutorialIconsCanvas;

		public override void InstallBindings()
		{
			base.Container.Bind<Transform>().WithId("GameWorldTutorialIconsCanvas").FromInstance(gameWorldTutorialIconsCanvas)
				.AsCached();
			base.Container.Bind<GUI_GameWorldTutorialIconsLayerCanvas>().FromComponentOn(gameWorldTutorialIconsCanvas.gameObject).AsSingle();
		}
	}
}
