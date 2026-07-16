using System.Collections.Generic;
using System.Linq;
using Game;
using Game.General;
using MLCN_Localization;
using UnityEngine;

public class GeneralGameSettingsComponent : SettingsComponent
{
	[SerializeField]
	private GeneralSettingsContainer loadedSettings;

	[Header("Direct Refs")]
	[SerializeField]
	private SliderField sliderCameraSensitivity;

	[SerializeField]
	private DropdownField dropdownLanguage;

	[SerializeField]
	private ToggleSwitch toggleShowHints;

	[SerializeField]
	private ToggleSwitch toggleTutorialAvailable;

	[SerializeField]
	private ToggleSwitch toggleDialogAnimation;

	[SerializeField]
	private SliderField sliderDialogTextSpeed;

	[SerializeField]
	private ToggleSwitch toggleDialogAutoplay;

	[SerializeField]
	private SliderField sliderDialogStayduration;

	public override void OnConfigLoad(GameSettingsConfig config)
	{
		loadedSettings = config.generalSettings;
		base.OnConfigLoad(config);
		LoadProperties();
	}

	public override void OnConfigUpdate(GameSettingsConfig config)
	{
		loadedSettings = config.generalSettings;
		UpdateProperties();
	}

	private void LoadProperties()
	{
		OnLoadCameraSensitivity(sliderCameraSensitivity);
		OnLoadLanguage(dropdownLanguage);
		OnLoadShowHints(toggleShowHints);
		if (toggleTutorialAvailable != null)
		{
			OnLoadIsTutorialAvailable(toggleTutorialAvailable);
		}
		OnLoadDialogAnimation(toggleDialogAnimation);
		OnLoadDialogTextSpeed(sliderDialogTextSpeed);
		OnLoadDialogAutoplay(toggleDialogAutoplay);
		OnLoadDialogStayDuration(sliderDialogStayduration);
		UpdateProperties();
	}

	private void UpdateProperties()
	{
		sliderCameraSensitivity.SetValueWithoutNotify(loadedSettings.cameraSensitivity);
		dropdownLanguage.SetValueWithoutNotify(loadedSettings.language);
		toggleShowHints.SetValueWithoutNotify(loadedSettings.showHintBoxes);
		if (toggleTutorialAvailable != null)
		{
			toggleTutorialAvailable.SetValueWithoutNotify(loadedSettings.tutorialAvailable);
		}
		toggleDialogAnimation.SetValueWithoutNotify(loadedSettings.dialogTextAnimation);
		sliderDialogTextSpeed.SetValueWithoutNotify(loadedSettings.dialogTextSpeed);
		toggleDialogAutoplay.SetValueWithoutNotify(loadedSettings.dialogAutoplay);
		sliderDialogStayduration.SetValueWithoutNotify(loadedSettings.dialogStayDuration);
	}

	public void OnLoadCameraSensitivity(SliderField slider)
	{
		slider.Init(loadedSettings.cameraSensitivity);
		GeneralSettings.SetCameraSensitivity(loadedSettings.cameraSensitivity);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadLanguage(DropdownField dropdown)
	{
		List<string> options = LocalizationManager.GetInstance().languageOptions.Select((LocalizationOption x) => x.GetLocalizedName(LocalizationDataTable.Tables.UI)).ToList();
		dropdown.Init(loadedSettings.language, options);
		GeneralSettings.SetLanguage(loadedSettings.language);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadShowHints(ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.showHintBoxes);
		GeneralSettings.SetShowHintBoxes(loadedSettings.showHintBoxes);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadIsTutorialAvailable(ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.tutorialAvailable);
		GeneralSettings.SetShowHintBoxes(loadedSettings.tutorialAvailable);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadDialogAnimation(ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.dialogAutoplay);
		GeneralSettings.SetDialogAnimation(loadedSettings.dialogTextAnimation);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadDialogTextSpeed(SliderField slider)
	{
		slider.Init(loadedSettings.dialogTextSpeed);
		GeneralSettings.SetDialogTextSpeed(loadedSettings.dialogTextSpeed);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadDialogAutoplay(ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.dialogAutoplay);
		GeneralSettings.SetDialogAutoplay(loadedSettings.dialogAutoplay);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnLoadDialogStayDuration(SliderField slider)
	{
		slider.Init(loadedSettings.dialogStayDuration);
		GeneralSettings.SetDialogStayDuration(loadedSettings.dialogStayDuration);
		GameSettings.SetGeneralSettings(loadedSettings);
	}

	public void OnCameraSensitivityChanged(float value)
	{
		loadedSettings.cameraSensitivity = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetCameraSensitivity(loadedSettings.cameraSensitivity);
	}

	public void OnLanguageChanged(int value)
	{
		loadedSettings.language = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetLanguage(loadedSettings.language);
		List<string> options = LocalizationManager.GetInstance().languageOptions.Select((LocalizationOption x) => x.GetLocalizedName(LocalizationDataTable.Tables.UI)).ToList();
		dropdownLanguage.Init(loadedSettings.language, options);
	}

	public void OnShowHintsChanged(bool value)
	{
		loadedSettings.showHintBoxes = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetShowHintBoxes(loadedSettings.showHintBoxes);
	}

	public void OnIsTutorialAvailableChanged(bool value)
	{
		loadedSettings.tutorialAvailable = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetShowHintBoxes(loadedSettings.tutorialAvailable);
	}

	public void OnUpdateDialogAnimation(bool value)
	{
		loadedSettings.dialogTextAnimation = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetDialogAnimation(loadedSettings.dialogTextAnimation);
	}

	public void OnUpdateDialogTextSpeed(float value)
	{
		loadedSettings.dialogTextSpeed = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetDialogTextSpeed(loadedSettings.dialogTextSpeed);
	}

	public void OnUpdateDialogAutoplay(bool value)
	{
		loadedSettings.dialogAutoplay = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetDialogAutoplay(loadedSettings.dialogAutoplay);
	}

	public void OnUpdateDialogStayDuration(float value)
	{
		loadedSettings.dialogStayDuration = value;
		GameSettings.UpdateGeneralSettings(loadedSettings);
		GeneralSettings.SetDialogStayDuration(loadedSettings.dialogStayDuration);
	}
}
