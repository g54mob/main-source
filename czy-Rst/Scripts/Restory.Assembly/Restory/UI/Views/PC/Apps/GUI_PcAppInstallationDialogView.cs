using System;
using Restory.Data.PC;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Views.PC.Apps
{
	public class GUI_PcAppInstallationDialogView : MonoBehaviour
	{
		[SerializeField]
		private Image appIcon;

		[Header("Texts")]
		[SerializeField]
		private TextMeshProUGUI headerAppName;

		[SerializeField]
		private TextMeshProUGUI infoAppName;

		[SerializeField]
		private TextMeshProUGUI progressAppName;

		[SerializeField]
		private TextMeshProUGUI completeAppName;

		[SerializeField]
		private TextMeshProUGUI launchButtonAppName;

		[SerializeField]
		private TextMeshProUGUI appDescription;

		[Space]
		[Header("Buttons")]
		[SerializeField]
		private Button installAppButton;

		[SerializeField]
		private Button launchAppButton;

		[Space]
		[Header("Progress")]
		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		[Min(0.01f)]
		private float progressSpeed = 0.02f;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName inProgressPreset = PresetName.InProgress;

		[SerializeField]
		private PresetName completedPreset = PresetName.Completed;

		private PcAppInfo appInfo;

		private float installationProgress;

		private bool isInstalling;

		public event Action OnAppInstallClick;

		public event Action OnAppInstalled;

		public event Action OnAppLaunchClick;

		private void OnEnable()
		{
			installAppButton.onClick.AddListener(delegate
			{
				this.OnAppInstallClick?.Invoke();
			});
			launchAppButton.onClick.AddListener(delegate
			{
				this.OnAppLaunchClick?.Invoke();
			});
		}

		private void OnDisable()
		{
			installAppButton.onClick.RemoveAllListeners();
			launchAppButton.onClick.RemoveAllListeners();
		}

		private void Update()
		{
			if (isInstalling)
			{
				installationProgress += Time.deltaTime * progressSpeed;
				progressSlider.value = installationProgress;
				if (installationProgress >= progressSlider.maxValue)
				{
					CompleteAppInstallation();
				}
			}
		}

		public void Init(Sprite desktopIcon, string appLocalizedName, string appLocalizedDescription)
		{
			appIcon.sprite = desktopIcon;
			headerAppName.text = appLocalizedName;
			infoAppName.text = appLocalizedName;
			progressAppName.text = appLocalizedName;
			completeAppName.text = appLocalizedName;
			launchButtonAppName.text = appLocalizedName;
			appDescription.text = appLocalizedDescription;
			presetSwitcher.ActivatePreset(normalPreset);
		}

		public void PerformAppInstallation()
		{
			installationProgress = 0f;
			progressSlider.value = installationProgress;
			presetSwitcher.ActivatePreset(inProgressPreset);
			isInstalling = true;
		}

		private void CompleteAppInstallation()
		{
			isInstalling = false;
			presetSwitcher.ActivatePreset(completedPreset);
			this.OnAppInstalled?.Invoke();
		}
	}
}
