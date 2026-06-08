using System.Collections.Generic;
using System.Globalization;
using Dorfromantik;
using Dorfromantik.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenuInitializer : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown resolutionDropdown;

	[SerializeField]
	private Toggle fullscreenToggle;

	[SerializeField]
	private Toggle postProcessingToggle;

	[SerializeField]
	private Toggle decorationToggle;

	[SerializeField]
	private TMP_Dropdown antialiasingDropdown;

	[SerializeField]
	private TMP_Dropdown qualityDropdown;

	[SerializeField]
	private TMP_Dropdown meshQualityDropdown;

	[SerializeField]
	[FormerlySerializedAs("fpsCapDropdown")]
	private TMP_Dropdown vsyncDropdown;

	[SerializeField]
	private TMP_Dropdown uiScaleDropdown;

	[SerializeField]
	private Toggle translucentUiToggle;

	[SerializeField]
	private Toggle dynamicBackgroundToggle;

	[SerializeField]
	private Toggle disableAAWhileMovingCamToggle;

	[SerializeField]
	private Slider masterVolumeSlider;

	[SerializeField]
	private Slider musicVolumeSlider;

	[SerializeField]
	private Slider fxVolumeSlider;

	[SerializeField]
	private Toggle placeTilesWithClickToggle;

	[SerializeField]
	private Slider cameraSpeedLevelSlider;

	[SerializeField]
	private Slider cameraRotationSpeedSlider;

	[SerializeField]
	private Slider cameraZoomSpeedSlider;

	[SerializeField]
	private TMP_Dropdown languageDropdown;

	[SerializeField]
	private TMP_Dropdown tooltipDropdown;

	[SerializeField]
	private Toggle debugUiToggle;

	[SerializeField]
	private Toggle runInBackgroundToggle;

	[SerializeField]
	private Toggle highlightMatchingEdgesToggle;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private List<Resolution> resolutions;

	private void Start()
	{
		resolutions = settingsRouter.AvailableResolutions;
		if ((bool)resolutionDropdown)
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (Resolution resolution in resolutions)
			{
				list.Add(new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}"));
			}
			resolutionDropdown.options = list;
			resolutionDropdown.SetValueWithoutNotify(resolutions.IndexOf(Screen.currentResolution));
		}
		if ((bool)fullscreenToggle)
		{
			fullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
		}
		masterVolumeSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetFloat("MasterVolume2", settingsRouter.defaultSettings.masterVolume));
		musicVolumeSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetFloat("MusicVolume2", settingsRouter.defaultSettings.musicVolume));
		fxVolumeSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetFloat("FxVolume2", settingsRouter.defaultSettings.masterVolume));
		if ((bool)placeTilesWithClickToggle)
		{
			placeTilesWithClickToggle.isOn = PlayerPrefsAccessor.GetInt("PlacingTilesWithClick", settingsRouter.defaultSettings.placingTilesWithClick) == 1;
		}
		if ((bool)cameraSpeedLevelSlider)
		{
			cameraSpeedLevelSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("CameraSpeed", settingsRouter.defaultSettings.cameraSpeedLevel));
		}
		if ((bool)cameraRotationSpeedSlider)
		{
			cameraRotationSpeedSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("CameraRotationSpeed", settingsRouter.defaultSettings.cameraRotationSpeedLevel));
		}
		if ((bool)cameraZoomSpeedSlider)
		{
			cameraZoomSpeedSlider.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("CameraZoomSpeed", settingsRouter.defaultSettings.cameraZoomSpeedLevel));
		}
		if ((bool)postProcessingToggle)
		{
			postProcessingToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt("PostProcessingEnabled", settingsRouter.defaultSettings.postProcessingEnabled) == 1);
		}
		if ((bool)decorationToggle)
		{
			decorationToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt("DecorationSystemEnabled", settingsRouter.defaultSettings.decorationEnabled) == 1);
		}
		if ((bool)translucentUiToggle)
		{
			translucentUiToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt("TranslucentUiEnabled", settingsRouter.defaultSettings.translucentUiEnabled) == 1);
		}
		if ((bool)dynamicBackgroundToggle)
		{
			dynamicBackgroundToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.DynamicBackgroundEnabled, settingsRouter.defaultSettings.dynamicBackgroundEnabled) == 1);
		}
		if ((bool)disableAAWhileMovingCamToggle)
		{
			disableAAWhileMovingCamToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.DisableAAWhileMovingCam, settingsRouter.defaultSettings.disableAAWhileMovingCam) == 1);
		}
		if ((bool)uiScaleDropdown)
		{
			uiScaleDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt(Constants.Settings.Graphics.UiScale, 0));
		}
		if ((bool)languageDropdown)
		{
			List<TMP_Dropdown.OptionData> list2 = new List<TMP_Dropdown.OptionData>();
			foreach (Language availableLanguage in LocalizationManager.Instance.AvailableLanguages)
			{
				string text = (LocalizationManager.LanguageNameByLanguage.ContainsKey(availableLanguage) ? LocalizationManager.LanguageNameByLanguage[availableLanguage] : availableLanguage.ToString());
				list2.Add(new TMP_Dropdown.OptionData(text));
			}
			languageDropdown.options = list2;
			languageDropdown.SetValueWithoutNotify(LocalizationManager.Instance.AvailableLanguages.IndexOf(LocalizationManager.Instance.Language));
		}
		if ((bool)debugUiToggle)
		{
			debugUiToggle.SetIsOnWithoutNotify(value: false);
		}
		if ((bool)runInBackgroundToggle)
		{
			runInBackgroundToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt("RunInBackground", settingsRouter.defaultSettings.runInBackground) == 1);
		}
		if ((bool)highlightMatchingEdgesToggle)
		{
			highlightMatchingEdgesToggle.SetIsOnWithoutNotify(PlayerPrefsAccessor.GetInt("HighlightMatchingEdges", settingsRouter.defaultSettings.highlightMatchingEdges) == 1);
		}
		if ((bool)resolutionDropdown)
		{
			settingsRouter.OnResolutionChanged += UpdateResolutionDropdown;
		}
		if ((bool)antialiasingDropdown)
		{
			settingsRouter.OnAntiAliasingChanged += UpdateAntiAliasingDropdown;
		}
		if ((bool)meshQualityDropdown)
		{
			settingsRouter.OnMeshQualityLevelChanged += UpdateMeshQualityDropdown;
		}
		if ((bool)decorationToggle)
		{
			settingsRouter.OnEnableDecorationSystem += UpdateDecorationToggle;
		}
		if ((bool)postProcessingToggle)
		{
			settingsRouter.OnPostProcessingEnabled += UpdatePostProcessingToggle;
		}
		if ((bool)vsyncDropdown)
		{
			settingsRouter.OnVsyncLevelChanged += UpdateVsyncDropdown;
		}
		if ((bool)languageDropdown)
		{
			settingsRouter.OnLanguageChanged += UpdateLanguage;
		}
		if ((bool)translucentUiToggle)
		{
			settingsRouter.OnTranslucentUiEnabled += UpdateTranslucentUiToggle;
		}
		if ((bool)uiScaleDropdown)
		{
			settingsRouter.OnUiScaleChanged += UpdateUiScaleDropdown;
		}
		UpdateLanguage(LocalizationManager.Instance.Language);
	}

	private void UpdateLanguage(Language newLanguage)
	{
		if ((bool)languageDropdown)
		{
			languageDropdown.SetValueWithoutNotify(LocalizationManager.Instance.AvailableLanguages.IndexOf(LocalizationManager.Instance.Language));
		}
		if ((bool)antialiasingDropdown)
		{
			List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("8x"),
				new TMP_Dropdown.OptionData("4x"),
				new TMP_Dropdown.OptionData("2x"),
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("off", useFallbackText: true)))
			};
			UpdateDropdownTextMesh(antialiasingDropdown);
			antialiasingDropdown.options = options;
			antialiasingDropdown.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("Antialiasing", settingsRouter.defaultSettings.antiAliasingLevel));
		}
		if ((bool)qualityDropdown)
		{
			List<TMP_Dropdown.OptionData> options2 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_high", useFallbackText: true)),
				new TMP_Dropdown.OptionData(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_medium", useFallbackText: true)),
				new TMP_Dropdown.OptionData(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_low", useFallbackText: true))
			};
			UpdateDropdownTextMesh(qualityDropdown);
			qualityDropdown.options = options2;
			qualityDropdown.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("QualityLevel", settingsRouter.defaultSettings.qualityLevel));
		}
		if ((bool)meshQualityDropdown)
		{
			List<TMP_Dropdown.OptionData> options3 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_high", useFallbackText: true)),
				new TMP_Dropdown.OptionData(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_low", useFallbackText: true))
			};
			UpdateDropdownTextMesh(meshQualityDropdown);
			meshQualityDropdown.options = options3;
			meshQualityDropdown.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt(Constants.Settings.Graphics.MeshQualityLevel, settingsRouter.defaultSettings.meshQualityLevel));
		}
		if ((bool)vsyncDropdown)
		{
			List<TMP_Dropdown.OptionData> options4 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_high", useFallbackText: true))),
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("options_graphics_quality_low", useFallbackText: true))),
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("off", useFallbackText: true)))
			};
			UpdateDropdownTextMesh(vsyncDropdown);
			vsyncDropdown.options = options4;
			vsyncDropdown.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("VsyncCount", settingsRouter.defaultSettings.vsyncLevel));
		}
		if ((bool)tooltipDropdown)
		{
			List<TMP_Dropdown.OptionData> options5 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("settings_accessibility_tooltips_all", useFallbackText: true))),
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("settings_accessibility_tooltips_some", useFallbackText: true))),
				new TMP_Dropdown.OptionData(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("settings_accessibility_tooltips_none", useFallbackText: true)))
			};
			UpdateDropdownTextMesh(tooltipDropdown);
			tooltipDropdown.options = options5;
			tooltipDropdown.SetValueWithoutNotify(PlayerPrefsAccessor.GetInt("TooltipLevel", settingsRouter.defaultSettings.tooltipLevel));
		}
	}

	private void UpdateDropdownTextMesh(TMP_Dropdown tmpDropdown)
	{
		tmpDropdown.captionText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.Bold);
		tmpDropdown.itemText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.Bold);
	}

	private void UpdateResolutionDropdown(Resolution newResolution)
	{
		resolutionDropdown.SetValueWithoutNotify(resolutions.IndexOf(newResolution));
	}

	private void UpdateAntiAliasingDropdown(int newLevel)
	{
		antialiasingDropdown.SetValueWithoutNotify(newLevel);
	}

	private void UpdateMeshQualityDropdown(int newLevel)
	{
		meshQualityDropdown.SetValueWithoutNotify(newLevel);
	}

	private void UpdateUiScaleDropdown(UiScalingLevelId obj)
	{
		uiScaleDropdown.SetValueWithoutNotify((int)obj);
	}

	private void UpdateDecorationToggle(bool newEnabled)
	{
		decorationToggle.SetIsOnWithoutNotify(newEnabled);
	}

	private void UpdatePostProcessingToggle(bool newEnabled)
	{
		postProcessingToggle.SetIsOnWithoutNotify(newEnabled);
	}

	private void UpdateVsyncDropdown(int newLevel)
	{
		vsyncDropdown.SetValueWithoutNotify(newLevel);
	}

	private void UpdateTranslucentUiToggle(bool newEnabled)
	{
		translucentUiToggle.SetIsOnWithoutNotify(newEnabled);
	}

	private void UpdateRunInBackgroundToggle(bool runningInBackground)
	{
		runInBackgroundToggle.SetIsOnWithoutNotify(runningInBackground);
	}

	private void OnDestroy()
	{
		settingsRouter.OnResolutionChanged -= UpdateResolutionDropdown;
		settingsRouter.OnAntiAliasingChanged -= UpdateAntiAliasingDropdown;
		settingsRouter.OnEnableDecorationSystem -= UpdateDecorationToggle;
		settingsRouter.OnPostProcessingEnabled -= UpdatePostProcessingToggle;
		settingsRouter.OnFpsCapChanged -= UpdateVsyncDropdown;
		settingsRouter.OnLanguageChanged -= UpdateLanguage;
		settingsRouter.OnTranslucentUiEnabled -= UpdateTranslucentUiToggle;
		settingsRouter.OnUiScaleChanged -= UpdateUiScaleDropdown;
	}
}
