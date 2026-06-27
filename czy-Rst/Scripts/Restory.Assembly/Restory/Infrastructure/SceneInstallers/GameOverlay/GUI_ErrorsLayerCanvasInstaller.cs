using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_ErrorsLayerCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform errorsCanvas;

		public override void InstallBindings()
		{
			base.Container.Bind<Transform>().WithId("ErrorsCanvas").FromInstance(errorsCanvas)
				.AsCached();
			base.Container.Bind<GUI_ErrorsLayerCanvas>().FromComponentOn(errorsCanvas.gameObject).AsSingle();
		}
	}
}
