using Restory.UI.Presenters.DayStartScreen;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_DayStartScreenCanvasInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_DayStartScreen dayStartScreen;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_DayStartScreen>().FromComponentOn(dayStartScreen.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(dayStartScreen.gameObject);
		}
	}
}
