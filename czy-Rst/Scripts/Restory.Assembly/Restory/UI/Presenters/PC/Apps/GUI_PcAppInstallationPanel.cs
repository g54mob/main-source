using System;
using Restory.Data.Localization;
using Restory.Data.PC;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps
{
	public class GUI_PcAppInstallationPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_PcAppInstallationDialog dialogPrefab;

		private DiContainer diContainer;

		private LocalizationSystem localizationSystem;

		public event Action<PcAppInfo> OnAppInstalled;

		public event Action<PcAppInfo> OnAppLaunched;

		[Inject]
		private void Construct(DiContainer diContainer, LocalizationSystem localizationSystem)
		{
			this.diContainer = diContainer;
			this.localizationSystem = localizationSystem;
		}

		public void LaunchAppInstallation(PcAppInfo appInfo)
		{
			GUI_PcAppInstallationDialog gUI_PcAppInstallationDialog = diContainer.InstantiatePrefabForComponent<GUI_PcAppInstallationDialog>(dialogPrefab, base.transform);
			gUI_PcAppInstallationDialog.Init(appInfo, localizationSystem.GetTranslation(appInfo.NameLocalizationKey), localizationSystem.GetTranslation(appInfo.InstallDescriptionLocalizationKey));
			gUI_PcAppInstallationDialog.OnAppInstalled.AddListener(ResolveAppInstalled);
		}

		private void ResolveAppInstalled(GUI_PcAppInstallationDialog dialog)
		{
			if (!dialog.AppInfo)
			{
				Debug.LogError("Installed app reference was lost");
				return;
			}
			dialog.OnAppInstalled.RemoveAllListeners();
			dialog.OnAppLaunched.AddListener(ResolveAppLaunched);
			this.OnAppInstalled?.Invoke(dialog.AppInfo);
		}

		private void ResolveAppLaunched(GUI_PcAppInstallationDialog dialog)
		{
			if (!dialog.AppInfo)
			{
				Debug.LogError("Launched app reference was lost");
				return;
			}
			dialog.OnAppLaunched.RemoveAllListeners();
			this.OnAppLaunched?.Invoke(dialog.AppInfo);
			UnityEngine.Object.Destroy(dialog.gameObject);
		}
	}
}
