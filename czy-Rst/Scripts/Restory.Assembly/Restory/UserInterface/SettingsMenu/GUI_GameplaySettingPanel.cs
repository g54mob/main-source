using System;
using System.Collections.Generic;
using Restory.Data.GameConfigs;
using Restory.Data.Localization;
using Restory.Gameplay.GameSettings;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_GameplaySettingPanel : GUI_ParentControlsSettingPanel
	{
		private static class Style
		{
			public const string CameraRotationSettings = "Camera Sensivity";

			public const string CameraZoomSettings = "Camera Zoom";

			public const string DifficultySettings = "Difficulty Settings";
		}

		[SerializeField]
		private GUI_DifficultySettingsPanel difficultySettingsPanel;

		[Space]
		[SerializeField]
		private GUI_DropdownWithData languageDropdown;

		[SerializeField]
		private GUI_SliderVariant cameraRotationSensitivitySlider;

		[SerializeField]
		[Tooltip("Central value of the slider. Values lower are 1 to 1 with final values linked to the slider. Values higher are modified using 'Camera Zoom Higher Than Center Step Multiplier'")]
		private float cameraRotationCenterValue = 1f;

		[SerializeField]
		[Tooltip("Multiplier for values, that are higher than center. For example, if center is 1 and multiplier is 2, then setting the slider to 1.4 will result in final value of ((1.4 - 1) * 2) + 1 = 1.8")]
		private float cameraRotationHigherThanCenterStepMultiplier = 2f;

		[SerializeField]
		private GUI_SliderVariant cameraZoomSensitivitySlider;

		[SerializeField]
		[Tooltip("Central value of the slider. Values lower are 1 to 1 with final values linked to the slider. Values higher are modified using 'Camera Zoom Higher Than Center Step Multiplier'")]
		private float cameraZoomCenterValue = 1f;

		[SerializeField]
		[Tooltip("Multiplier for values, that are higher than center. For example, if center is 1 and multiplier is 2, then setting the slider to 1.4 will result in final value of ((1.4 - 1) * 2) + 1 = 1.8")]
		private float cameraZoomHigherThanCenterStepMultiplier = 2f;

		[SerializeField]
		private GUI_Toggle cameraRotationIsInvertedToggle;

		[SerializeField]
		private GUI_Toggle cameraSmoothingToggle;

		[SerializeField]
		private GUI_CozyLevelSlider cozyLevelSlider;

		[SerializeField]
		private Button difficultySettingsButton;

		[SerializeField]
		private GUI_Toggle showPathMinionsToggle;

		[SerializeField]
		private GameConfig gameConfig;

		[Header("Language Settings")]
		[SerializeField]
		private string languageSelectorValueKey = "UI_LANGUAGE_SELECTOR";

		private LocalizationSystem localizationSystem;

		public GUI_DropdownWithData LanguageDropdown => languageDropdown;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			if (localizationSystem == null)
			{
				Debug.LogException(new Exception("[Type] got injected with a null LocalizationSystem!"));
			}
		}

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			languageDropdown.onValueChanged.AddListener(languageDropdown_onValueChanged);
			languageDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			cameraRotationSensitivitySlider.OnValueChanged += cameraRotationSensitivitySlider_onValueChanged;
			cameraZoomSensitivitySlider.OnValueChanged += cameraZoomSensitivitySlider_onValueChanged;
			cameraRotationIsInvertedToggle.OnValueChanged.AddListener(cameraRotationIsInvertedToggle_onValueChanged);
			cameraSmoothingToggle.OnValueChanged.AddListener(cameraSmoothingToggle_onValueChanged);
			cozyLevelSlider.OnValueChanged += cozyLevelSlider_onValueChanged;
			difficultySettingsButton.onClick.AddListener(ResolveDifficultySettingsButtonOnClick);
			showPathMinionsToggle.OnValueChanged.AddListener(showPathMinionsToggle_onValueChanged);
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.AddListener(OnLocalisationChanged);
			}
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			languageDropdown.onValueChanged.RemoveListener(languageDropdown_onValueChanged);
			languageDropdown.IsShownChanged -= ResolveDropdownIsShownChanged;
			cameraRotationSensitivitySlider.OnValueChanged -= cameraRotationSensitivitySlider_onValueChanged;
			cameraZoomSensitivitySlider.OnValueChanged -= cameraZoomSensitivitySlider_onValueChanged;
			cameraRotationIsInvertedToggle.OnValueChanged.RemoveListener(cameraRotationIsInvertedToggle_onValueChanged);
			cameraSmoothingToggle.OnValueChanged.RemoveListener(cameraSmoothingToggle_onValueChanged);
			cozyLevelSlider.OnValueChanged -= cozyLevelSlider_onValueChanged;
			difficultySettingsButton.onClick.RemoveListener(ResolveDifficultySettingsButtonOnClick);
			showPathMinionsToggle.OnValueChanged.RemoveListener(showPathMinionsToggle_onValueChanged);
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.RemoveListener(OnLocalisationChanged);
			}
		}

		public override void Show()
		{
			firstNavigationSetter.SetTargetNavigation(languageDropdown.interactable ? languageDropdown.gameObject : cameraRotationSensitivitySlider.gameObject);
			base.Show();
			SetCurrentPanel(null);
		}

		public override void Hide()
		{
			base.Hide();
			SetCurrentPanel(null);
		}

		public override void Load()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.Load();
				return;
			}
			languageDropdown.SetValueWithoutNotifyByData(gameSettingsManager.Localization);
			SetCameraRotationSensitivityValue(gameSettingsManager.CameraSettings.RotationSensitivity);
			SetCameraZoomSensitivityValue(gameSettingsManager.CameraSettings.ZoomSensitivity);
			cameraRotationIsInvertedToggle.SetIsOnWithoutNotify(gameSettingsManager.CameraSettings.IsRotationInverted);
			cameraSmoothingToggle.SetIsOnWithoutNotify(gameSettingsManager.CameraSettings.IsFollowingSmoothed);
			cozyLevelSlider.SetValueWithoutNotify(gameSettingsManager.DifficultySettings.GetCozyLevel());
			showPathMinionsToggle.SetIsOnWithoutNotify(gameSettingsManager.ShowPathMinions);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.SetDefault();
				return;
			}
			if (languageDropdown.interactable)
			{
				languageDropdown.SetValueWithoutNotifyByData(SystemLanguage.English);
			}
			SetCameraRotationSensitivityValue(gameSettingsManager.DefaultData.CameraSettings.RotationSensitivity);
			SetCameraZoomSensitivityValue(gameSettingsManager.DefaultData.CameraSettings.ZoomSensitivity);
			cameraRotationIsInvertedToggle.SetIsOnWithoutNotify(gameSettingsManager.DefaultData.CameraSettings.IsRotationInverted);
			cameraSmoothingToggle.SetIsOnWithoutNotify(gameSettingsManager.DefaultData.CameraSettings.IsFollowingSmoothed);
			cozyLevelSlider.SetValueWithoutNotify(gameSettingsManager.DefaultData.DifficultySettings.GetCozyLevel());
			showPathMinionsToggle.SetIsOnWithoutNotify(gameSettingsManager.DefaultData.ShowPathMinions);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.Apply();
				return;
			}
			gameSettingsManager.Localization = languageDropdown.GetData(SystemLanguage.English);
			gameSettingsManager.CameraSettings.RotationSensitivity = GetCameraRotationSensitivityValue();
			gameSettingsManager.CameraSettings.ZoomSensitivity = GetCameraZoomSensitivityValue();
			gameSettingsManager.CameraSettings.IsRotationInverted = cameraRotationIsInvertedToggle.IsOn;
			gameSettingsManager.CameraSettings.IsFollowingSmoothed = cameraSmoothingToggle.IsOn;
			if (gameSettingsManager.DifficultySettings.GetCozyLevel() != cozyLevelSlider.Value)
			{
				gameSettingsManager.DifficultySettings.SetCozyLevel(cozyLevelSlider.Value);
			}
			gameSettingsManager.ShowPathMinions = showPathMinionsToggle.IsOn;
			gameSettingsSaver.Save();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void UpdateView()
		{
			base.UpdateView();
			UpdateLanguageDropdownValues();
		}

		private void UpdateLanguageDropdownValues()
		{
			SystemLanguage data = languageDropdown.GetData(SystemLanguage.English);
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>(gameConfig.SupportedLocalizations.Count);
			foreach (SystemLanguage supportedLocalization in gameConfig.SupportedLocalizations)
			{
				string translation = localizationSystem.GetTranslation(languageSelectorValueKey, supportedLocalization.ToString());
				list.Add(new GUI_DropdownWithData.OptionData<SystemLanguage>(supportedLocalization, translation));
			}
			languageDropdown.ClearOptions();
			languageDropdown.AddOptions(list);
			languageDropdown.SetValueWithoutNotifyByData(data);
		}

		protected override void UpdateHasChanges()
		{
			if (!(gameSettingsManager == null))
			{
				int num = Mathf.RoundToInt(ConvertToZoomSensitivityValue(gameSettingsManager.CameraSettings.ZoomSensitivity));
				int num2 = Mathf.RoundToInt(ConvertToZoomSensitivityValue(gameSettingsManager.CameraSettings.RotationSensitivity));
				SetHasChange(languageDropdown.GetData(SystemLanguage.English) != gameSettingsManager.Localization || cameraRotationIsInvertedToggle.IsOn != gameSettingsManager.CameraSettings.IsRotationInverted || cameraSmoothingToggle.IsOn != gameSettingsManager.CameraSettings.IsFollowingSmoothed || cozyLevelSlider.Value != gameSettingsManager.DifficultySettings.GetCozyLevel() || showPathMinionsToggle.IsOn != gameSettingsManager.ShowPathMinions || Mathf.RoundToInt(cameraZoomSensitivitySlider.Value) != num || Mathf.RoundToInt(cameraRotationSensitivitySlider.Value) != num2);
			}
		}

		protected override void UpdateIsDefaultValues()
		{
			if (!(gameSettingsManager == null))
			{
				int num = Mathf.RoundToInt(ConvertToZoomSensitivityValue(gameSettingsManager.DefaultData.CameraSettings.ZoomSensitivity));
				int num2 = Mathf.RoundToInt(ConvertToZoomSensitivityValue(gameSettingsManager.DefaultData.CameraSettings.RotationSensitivity));
				SetIsDefaultValues(languageDropdown.GetData(SystemLanguage.English) == gameSettingsManager.DefaultData.Localization && cameraRotationIsInvertedToggle.IsOn == gameSettingsManager.DefaultData.CameraSettings.IsRotationInverted && cameraSmoothingToggle.IsOn == gameSettingsManager.DefaultData.CameraSettings.IsFollowingSmoothed && cozyLevelSlider.Value == gameSettingsManager.DefaultData.DifficultySettings.GetCozyLevel() && showPathMinionsToggle.IsOn == gameSettingsManager.DefaultData.ShowPathMinions && Mathf.RoundToInt(cameraZoomSensitivitySlider.Value) == num && Mathf.RoundToInt(cameraRotationSensitivitySlider.Value) == num2);
			}
		}

		public void ResolveDifficultySettingsButtonOnClick()
		{
			SetCurrentPanel(difficultySettingsPanel);
		}

		private void ResolveCurrentPanelOnBack(GUI_BaseSettingPanel panel)
		{
			if (!panel.HasChanges)
			{
				SetCurrentPanel(null);
				return;
			}
			panel.ConfirmApply(delegate
			{
				SetCurrentPanel(null);
			});
		}

		private void ResolveDropdownIsShownChanged(Dropdown dropdown, bool isShown)
		{
			canvasGroup.interactable = !isShown;
			dropdown.GetComponent<CanvasGroup>().ignoreParentGroups = isShown;
		}

		private void OnLocalisationChanged(SystemLanguage parLanguage)
		{
			languageDropdown.SetValueWithoutNotifyByData(gameSettingsManager.Localization);
			UpdateView();
		}

		private void cozyLevelSlider_onValueChanged(CozyLevel cozyLevel)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void languageDropdown_onValueChanged(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}

		private void cameraRotationSensitivitySlider_onValueChanged(float value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void cameraZoomSensitivitySlider_onValueChanged(float value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void cameraRotationIsInvertedToggle_onValueChanged(bool value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnToggleSwitchedToNewValue?.Invoke(value);
		}

		private void cameraSmoothingToggle_onValueChanged(bool value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnToggleSwitchedToNewValue?.Invoke(value);
		}

		private void showPathMinionsToggle_onValueChanged(bool value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnToggleSwitchedToNewValue?.Invoke(value);
		}

		private float GetCameraRotationSensitivityValue()
		{
			return ConvertFromValue(cameraRotationSensitivitySlider.Value * 0.01f, cameraRotationCenterValue, cameraRotationHigherThanCenterStepMultiplier);
		}

		private void SetCameraRotationSensitivityValue(float value)
		{
			cameraRotationSensitivitySlider.SetValueWithoutNotify(ConvertToRotationSensitivityValue(value));
		}

		private float ConvertToRotationSensitivityValue(float value)
		{
			return ConvertToValue(value, cameraRotationCenterValue, cameraRotationHigherThanCenterStepMultiplier) * 100f;
		}

		private float GetCameraZoomSensitivityValue()
		{
			return ConvertFromValue(cameraZoomSensitivitySlider.Value * 0.01f, cameraZoomCenterValue, cameraZoomHigherThanCenterStepMultiplier);
		}

		private void SetCameraZoomSensitivityValue(float value)
		{
			cameraZoomSensitivitySlider.SetValueWithoutNotify(ConvertToZoomSensitivityValue(value));
		}

		private float ConvertToZoomSensitivityValue(float value)
		{
			return ConvertToValue(value, cameraZoomCenterValue, cameraZoomHigherThanCenterStepMultiplier) * 100f;
		}

		private static float ConvertToValue(float value, float centerValue, float higherThanCenterStepMultiplier)
		{
			if (!(value <= centerValue))
			{
				return centerValue + (value - centerValue) / higherThanCenterStepMultiplier;
			}
			return value;
		}

		private static float ConvertFromValue(float value, float centerValue, float higherThanCenterStepMultiplier)
		{
			if (!(value <= centerValue))
			{
				return centerValue + (value - centerValue) * higherThanCenterStepMultiplier;
			}
			return value;
		}
	}
}
