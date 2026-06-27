using Restory.Gameplay.UserInterface.DeviceCustomizations;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_DeviceCustomizationPanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_DeviceCustomizationPanel elementCleanerPanel;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_DeviceCustomizationPanel>().FromComponentOn(elementCleanerPanel.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(elementCleanerPanel.gameObject);
		}
	}
}
