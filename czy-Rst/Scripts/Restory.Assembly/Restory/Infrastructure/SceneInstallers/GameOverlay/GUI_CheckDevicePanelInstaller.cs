using Restory.UI.Presenters.CheckDevice;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_CheckDevicePanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_CheckDevicePanel checkDevicePanel;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_CheckDevicePanel>().FromComponentOn(checkDevicePanel.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(checkDevicePanel.gameObject);
		}
	}
}
