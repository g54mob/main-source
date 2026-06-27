using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_ElementCleanerPanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_ElementCleanerPanel elementCleanerPanel;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_ElementCleanerPanel>().FromComponentOn(elementCleanerPanel.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(elementCleanerPanel.gameObject);
		}
	}
}
