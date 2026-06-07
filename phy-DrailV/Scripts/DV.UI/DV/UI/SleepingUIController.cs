using System;
using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class SleepingUIController : NullCheckingMonoBehaviour
	{
		public AudioClip openSound;

		private SleepingData data;

		private const string LOC_TRAIN_IS_MOVING = "sleeping/train_is_moving";

		private const string LOC_TOO_SOON_SINCE = "sleeping/too_soon";

		private const string LOC_CONFIRMATION_QUESTION = "sleeping/confirm_question";

		[Header("Buttons")]
		[NullCheck]
		public ButtonDV initiateSleepButton;

		[NullCheck]
		public ButtonDV confirmSleepButton;

		[NullCheck]
		public ButtonDV cancelSleepButton;

		[NullCheck]
		public ButtonDV initialScreenCloseButton;

		[NullCheck]
		public ButtonDV confirmDialogCloseButton;

		[NullCheck]
		public ButtonDV deniedDialogCloseButton;

		[NullCheck]
		public ButtonDV confirmDialogCancelButton;

		[NullCheck]
		public ButtonDV deniedDialogOKButton;

		[Header("Other")]
		[NullCheck]
		public UIMenuController menuController;

		[NullCheck]
		public TextMeshProUGUI confirmDialogLabelTMPro;

		[NullCheck]
		public TextMeshProUGUI deniedDialogLabelTMPro;

		[NullCheck]
		public SliderDV durationSlider;

		private TMP_Text durationSliderLabelTMPro;

		public event Action<float> SleepRequested;

		public event Action CloseRequested;

		public void Show(SleepingData data)
		{
			this.data = data;
			openSound.Play2D();
			RefreshInterface();
		}

		public void Hide()
		{
			menuController.CloseAllMenus();
		}

		protected override void Awake()
		{
			base.Awake();
			durationSliderLabelTMPro = durationSlider.GetComponentInChildren<TMP_Text>(includeInactive: true);
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				initiateSleepButton.Clicked += GoToConfirmDialog;
				confirmSleepButton.Clicked += OnConfirmSleepClicked;
				cancelSleepButton.Clicked += OnCloseClicked;
				initialScreenCloseButton.Clicked += OnCloseClicked;
				confirmDialogCloseButton.Clicked += OnCloseClicked;
				deniedDialogCloseButton.Clicked += OnCloseClicked;
				confirmDialogCancelButton.Clicked += OnCloseClicked;
				deniedDialogOKButton.Clicked += OnCloseClicked;
				durationSlider.onValueChanged.AddListener(OnDurationSliderValueChanged);
			}
			else
			{
				initiateSleepButton.Clicked -= GoToConfirmDialog;
				confirmSleepButton.Clicked -= OnConfirmSleepClicked;
				cancelSleepButton.Clicked -= OnCloseClicked;
				initialScreenCloseButton.Clicked -= OnCloseClicked;
				confirmDialogCloseButton.Clicked -= OnCloseClicked;
				deniedDialogCloseButton.Clicked -= OnCloseClicked;
				confirmDialogCancelButton.Clicked -= OnCloseClicked;
				deniedDialogOKButton.Clicked -= OnCloseClicked;
				durationSlider.onValueChanged.RemoveListener(OnDurationSliderValueChanged);
			}
		}

		private void RefreshInterface()
		{
			string text = "Current time: " + data.currentTime.ToString("MM/dd HH:mm") + "\n" + $"Next sleep available at {data.nextSleepMinTime:HH:mm}\n" + $"Is in moving car: {data.sleepPermissionState == SleepingData.SleepPermissionState.DeniedTrainIsMoving}";
			switch (data.sleepPermissionState)
			{
			case SleepingData.SleepPermissionState.Allowed:
				Debug.Log("Sleeping allowed.\n" + text);
				menuController.SwitchMenu(0);
				OnDurationSliderValueChanged();
				break;
			case SleepingData.SleepPermissionState.DeniedTooSoon:
				Debug.Log("Sleeping denied because not enough time had passed since last sleep.\n" + text);
				menuController.SwitchMenu(2);
				deniedDialogLabelTMPro.text = LocalizationAPI.L("sleeping/too_soon", data.nextSleepMinTime.ToString("HH:mm"));
				break;
			case SleepingData.SleepPermissionState.DeniedTrainIsMoving:
				Debug.Log("Sleeping denied because train is moving.\n" + text);
				menuController.SwitchMenu(2);
				deniedDialogLabelTMPro.text = LocalizationAPI.L("sleeping/train_is_moving");
				break;
			case SleepingData.SleepPermissionState.DeniedSleepDisabled:
				Debug.LogError("SleepingUIController: Sleeping disabled! This call should not have been reached! Skipping.");
				break;
			}
		}

		private void OnCloseClicked(IClickable clickable)
		{
			this.CloseRequested?.Invoke();
		}

		private void OnDurationSliderValueChanged(float _ = 0f)
		{
			DateTime dateTime = data.currentTime + TimeSpan.FromHours(durationSlider.value);
			durationSliderLabelTMPro.text = FormatDateTime(dateTime);
		}

		private string FormatDateTime(DateTime dateTime)
		{
			return dateTime.ToString("MM/dd HH:mm");
		}

		private void GoToConfirmDialog(IClickable clickable)
		{
			int num = Mathf.FloorToInt(durationSlider.value);
			confirmDialogLabelTMPro.text = LocalizationAPI.L("sleeping/confirm_question", num.ToString());
			menuController.SwitchMenu(1);
		}

		private void OnConfirmSleepClicked(IClickable _)
		{
			this.SleepRequested?.Invoke(durationSlider.value * 3600f);
			this.CloseRequested?.Invoke();
		}
	}
}
