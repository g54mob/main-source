using Restory.UserInterface.Disclaimer;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Disclaimer
{
	public class DisclaimerPanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_DisclaimerPanel disclaimerPanel;

		public override void InstallBindings()
		{
			InstallDisclaimerPanel();
		}

		private void InstallDisclaimerPanel()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_DisclaimerPanel>().FromComponentOn(disclaimerPanel.gameObject).AsSingle();
		}
	}
}
