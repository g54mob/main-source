using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_ItemDragCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_ItemDragCanvas itemDragCanvas;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_ItemDragCanvas>().FromComponentOn(itemDragCanvas.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(itemDragCanvas.gameObject);
		}
	}
}
