using Restory.Data.PC;
using Restory.UI.Views.PC.Apps;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.UI.Presenters.PC.Apps
{
	public class GUI_PcAppInstallationDialog : MonoBehaviour
	{
		public readonly UnityEvent<GUI_PcAppInstallationDialog> OnAppInstalled = new UnityEvent<GUI_PcAppInstallationDialog>();

		public readonly UnityEvent<GUI_PcAppInstallationDialog> OnAppLaunched = new UnityEvent<GUI_PcAppInstallationDialog>();

		[SerializeField]
		private GUI_PcAppInstallationDialogView view;

		public PcAppInfo AppInfo { get; private set; }

		private void OnEnable()
		{
			view.OnAppInstallClick += ResolveInstallAppButtonClick;
			view.OnAppInstalled += ResolveAppInstalled;
			view.OnAppLaunchClick += ResolveLaunchAppButtonClick;
		}

		private void OnDisable()
		{
			view.OnAppInstallClick -= ResolveInstallAppButtonClick;
			view.OnAppInstalled -= ResolveAppInstalled;
			view.OnAppLaunchClick -= ResolveLaunchAppButtonClick;
			OnAppInstalled.RemoveAllListeners();
			AppInfo = null;
		}

		public void Init(PcAppInfo appInfo, string appLocalizedName, string appLocalizedDescription)
		{
			AppInfo = appInfo;
			view.Init(appInfo.DesktopIcon, appLocalizedName, appLocalizedDescription);
		}

		private void ResolveInstallAppButtonClick()
		{
			view.PerformAppInstallation();
		}

		private void ResolveAppInstalled()
		{
			OnAppInstalled?.Invoke(this);
		}

		private void ResolveLaunchAppButtonClick()
		{
			OnAppLaunched?.Invoke(this);
		}
	}
}
