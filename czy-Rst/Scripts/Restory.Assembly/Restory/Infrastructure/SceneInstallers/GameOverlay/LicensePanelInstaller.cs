using Restory.Gameplay.Licenses;
using Restory.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class LicensePanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_LicensePanel licensePanelPrefab;

		public override void InstallBindings()
		{
			InstallLicensePanelActivator();
		}

		private void InstallLicensePanelActivator()
		{
			base.Container.BindInterfacesAndSelfTo<LicensePanelActivator>().FromNew().AsSingle()
				.WithArguments(licensePanelPrefab);
		}
	}
}
