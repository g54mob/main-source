using Restory.Gameplay.UserInterface;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_GameplayOverlayCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform mainCanvas;

		[SerializeField]
		private GUI_GameWarningDialogue gameWarningDialogue;

		public override void InstallBindings()
		{
			InstallMainCanvas();
			InstallGameWarningDialogue();
		}

		private void InstallMainCanvas()
		{
			base.Container.Bind<Transform>().WithId("GameplayOverlayCanvas").FromInstance(mainCanvas)
				.AsCached();
			base.Container.BindInterfacesAndSelfTo<GUI_GameplayOverlayCanvas>().FromComponentOn(mainCanvas.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(mainCanvas.gameObject);
		}

		private void InstallGameWarningDialogue()
		{
			base.Container.Bind<GUI_GameWarningDialogue>().FromComponentOn(gameWarningDialogue.gameObject).AsSingle();
		}
	}
}
