using System;
using Restory.Data.Licenses;
using Restory.Data.Localization;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Licenses
{
	public class LicensePanelActivator : IDisposable
	{
		private readonly Transform parentCanvas;

		private readonly GUI_LicensePanel licensePanelPrefab;

		private readonly LocalizationSystem localizationSystem;

		private readonly DiContainer diContainer;

		private GUI_LicensePanel licensePanelInstance;

		[Inject]
		public LicensePanelActivator([Inject(Id = "GameplayOverlayCanvas")] Transform parentCanvas, GUI_LicensePanel licensePanelPrefab, LocalizationSystem localizationSystem, IPlayerInput playerInput, DiContainer diContainer)
		{
			this.parentCanvas = parentCanvas;
			this.licensePanelPrefab = licensePanelPrefab;
			this.localizationSystem = localizationSystem;
			this.diContainer = diContainer;
		}

		public void Dispose()
		{
			if (licensePanelInstance.MonoShellExists())
			{
				licensePanelInstance.OnClosePanelRequested -= ResolvePanelRequestedClosing;
			}
		}

		public void ShowLicensePanel(LicenseInfo licenseInfo)
		{
			DestroyLicensePanelInstance();
			licensePanelInstance = diContainer.InstantiatePrefabForComponent<GUI_LicensePanel>(licensePanelPrefab.gameObject, parentCanvas);
			licensePanelInstance.Init(licenseInfo.Icon, licenseInfo.DeviceInfo.Icon, localizationSystem.GetTranslation(licenseInfo.DeviceInfo.NameLocalizationKey));
			licensePanelInstance.OnClosePanelRequested += ResolvePanelRequestedClosing;
		}

		private void DestroyLicensePanelInstance()
		{
			if ((bool)licensePanelInstance)
			{
				licensePanelInstance.OnClosePanelRequested -= ResolvePanelRequestedClosing;
				UnityEngine.Object.Destroy(licensePanelInstance.gameObject);
				licensePanelInstance = null;
			}
		}

		private void ResolvePanelRequestedClosing()
		{
			DestroyLicensePanelInstance();
		}
	}
}
