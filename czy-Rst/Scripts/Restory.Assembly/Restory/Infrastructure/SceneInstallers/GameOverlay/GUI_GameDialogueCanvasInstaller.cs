using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_GameDialogueCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_GameDialogueCanvas gameDialogueCanvas;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_GameDialogueCanvas>().FromComponentOn(gameDialogueCanvas.gameObject).AsSingle();
		}
	}
}
