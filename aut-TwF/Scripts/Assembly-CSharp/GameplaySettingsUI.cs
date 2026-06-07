using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class GameplaySettingsUI : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown languageDropdown;

	[SerializeField]
	private Slider cameraSpeedSlider;

	[SerializeField]
	private Toggle screenBorderCameraMovementToggle;

	[SerializeField]
	private Toggle screenShakeToggle;

	[SerializeField]
	private Toggle seasonalContentToggle;

	[SerializeField]
	private Toggle autoLootChestsToggle;

	private void Start()
	{
		FillLanguageDropdown();
		UpdateCameraSpeedSliderValue();
		UpdateToggles();
	}

	private void FillLanguageDropdown()
	{
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int value = 0;
		for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
		{
			Locale locale = LocalizationSettings.AvailableLocales.Locales[i];
			list.Add(new TMP_Dropdown.OptionData(GetLocaleName(locale)));
			if (LocalizationSettings.SelectedLocale == locale)
			{
				value = i;
			}
		}
		languageDropdown.ClearOptions();
		languageDropdown.options = list;
		languageDropdown.value = value;
		UpdateSelectedLanguageDropdown();
	}

	private void UpdateSelectedLanguageDropdown()
	{
		for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
		{
			Locale locale = LocalizationSettings.AvailableLocales.Locales[i];
			if (LocalizationSettings.SelectedLocale == locale)
			{
				languageDropdown.value = i;
				break;
			}
		}
	}

	private void UpdateCameraSpeedSliderValue()
	{
		cameraSpeedSlider.value = SettingsController.instance.CameraSpeedMultiplier;
	}

	private void UpdateToggles()
	{
		screenBorderCameraMovementToggle.isOn = SettingsController.instance.ScreenBorderCameraMovementEnabled;
		seasonalContentToggle.isOn = SettingsController.instance.SeasonalContentEnabled;
		screenShakeToggle.isOn = SettingsController.instance.ScreenShakeEnabled;
		autoLootChestsToggle.isOn = SettingsController.instance.AutoLootChests;
	}

	private string GetLocaleName(Locale locale)
	{
		return locale.Identifier.Code switch
		{
			"de" => "Deutsch (Beta)", 
			"en" => "English", 
			"es" => "Español", 
			"fr" => "Français (Bêta)", 
			"it" => "Italiano", 
			"ru" => "Русский (Бета)", 
			"zh-Hans" => "中文 (贝塔)", 
			"ja" => "日本語 (ベータ)", 
			"ko" => "한국어 (베타)", 
			_ => "?", 
		};
	}

	public void OnLanguageChanged(int index)
	{
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
	}

	public void OnCameraSpeedSliderChanged()
	{
		SettingsController.instance.CameraSpeedMultiplier = cameraSpeedSlider.value;
	}

	public void OnScreenBorderCameraMovementChanged(bool enabled)
	{
		SettingsController.instance.ScreenBorderCameraMovementEnabled = enabled;
	}

	public void OnSeasonalContentChanged(bool enabled)
	{
		SettingsController.instance.SeasonalContentEnabled = enabled;
	}

	public void OnScreenShakeChanged(bool enabled)
	{
		SettingsController.instance.ScreenShakeEnabled = enabled;
	}

	public void OnAutoLootChestsChanged(bool enabled)
	{
		SettingsController.instance.AutoLootChests = enabled;
	}
}
