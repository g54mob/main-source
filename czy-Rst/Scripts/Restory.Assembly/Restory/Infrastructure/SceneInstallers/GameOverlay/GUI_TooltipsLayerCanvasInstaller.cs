using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_TooltipsLayerCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform tooltipsCanvas;

		public override void InstallBindings()
		{
			base.Container.Bind<Transform>().WithId("TooltipsCanvas").FromInstance(tooltipsCanvas)
				.AsCached();
			base.Container.Bind<GUI_TooltipsLayerCanvas>().FromComponentOn(tooltipsCanvas.gameObject).AsSingle();
		}
	}
}
