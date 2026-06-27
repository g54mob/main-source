using System;
using Restory.Data.Localization;
using Restory.Data.PC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps
{
	public class GUI_PcAppBase : MonoBehaviour
	{
		[SerializeField]
		private Image appIcon;

		[Header("Texts")]
		[SerializeField]
		private TextMeshProUGUI appName;

		[SerializeField]
		private Button exitButton;

		private LocalizationSystem localizationSystem;

		public PcAppInfo AppInfo { get; private set; }

		public Button ExitButton => exitButton;

		public event Action<GUI_PcAppBase> OnLaunched;

		public event Action<GUI_PcAppBase> OnStopped;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		private void OnDisable()
		{
			exitButton.onClick.RemoveAllListeners();
		}

		public void Launch(PcAppInfo appInfo)
		{
			AppInfo = appInfo;
			appIcon.sprite = appInfo.DesktopIcon;
			appName.text = localizationSystem.GetTranslation(appInfo.NameLocalizationKey);
			LaunchProcess(appInfo);
			this.OnLaunched?.Invoke(this);
		}

		protected virtual void LaunchProcess(PcAppInfo appInfo)
		{
		}

		public void Stop()
		{
			StopProcess();
			this.OnStopped?.Invoke(this);
		}

		protected virtual void StopProcess()
		{
		}
	}
}
