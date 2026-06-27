using Restory.UI.Presenters.MainMenu;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.MainMenu
{
	public class GUI_MainMenuInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject mainMenu;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_MainMenu>().FromComponentOn(mainMenu).AsSingle();
			base.Container.QueueAllComponentsForInject(mainMenu);
		}
	}
}
