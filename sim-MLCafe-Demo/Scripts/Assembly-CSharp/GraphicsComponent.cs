using System.Collections;
using System.Collections.Generic;
using Game;
using Game.Graphics;
using MLCN_Localization;
using UnityEngine;

public class GraphicsComponent : SettingsComponent
{
	[SerializeField]
	private GraphicsContainer loadedGraphics;

	[Header("Direct Refs")]
	[SerializeField]
	private DropdownField dropdownResolution;

	[SerializeField]
	private DropdownField dropdownMonitor;

	[SerializeField]
	private DropdownField dropdownFullscreen;

	[SerializeField]
	private DropdownField dropdownVSync;

	[SerializeField]
	private DropdownField dropdownMainQuality;

	[SerializeField]
	private DropdownField dropdownShadowQuality;

	[SerializeField]
	private SliderField sliderRenderScale;

	[SerializeField]
	private SliderField sliderBrightness;

	private List<string> fullscreenLocalization = new List<string> { "ui_menu_options_tab_video_screen_exclusivefullscreen", "ui_menu_options_tab_video_screen_fullscreenwindow", "ui_menu_options_tab_video_screen_maximizedwindow", "ui_menu_options_tab_video_screen_windowed" };

	private List<string> vsyncLocalization = new List<string> { "ui_menu_options_tab_video_sync_dontsync", "ui_menu_options_tab_video_sync_everyblank", "ui_menu_options_tab_video_sync_everysecondblank" };

	private List<string> commonOptionsLocalization = new List<string> { "ui_menu_options_tab_graphics_option_ultra", "ui_menu_options_tab_graphics_option_high", "ui_menu_options_tab_graphics_option_medium", "ui_menu_options_tab_graphics_option_low" };

	private List<string> onOffOptionsLocalization = new List<string> { "ui_menu_options_tab_graphics_option_on", "ui_menu_options_tab_graphics_option_off" };

	public override void OnConfigDestroy()
	{
		base.OnConfigDestroy();
		LocalizationManager.OnLanguageChange.RemoveListener(delegate
		{
			OnLoadFullscreen(dropdownFullscreen);
			OnLoadVSync(dropdownVSync);
			OnLoadMainQuality(dropdownMainQuality);
			OnLoadShadowQuality(dropdownShadowQuality);
		});
	}

	public override void OnConfigLoad(GameSettingsConfig config)
	{
		loadedGraphics = config.graphics;
		base.OnConfigLoad(config);
		LoadProperties();
		LocalizationManager.OnLanguageChange.AddListener(delegate
		{
			OnLoadFullscreen(dropdownFullscreen);
			OnLoadVSync(dropdownVSync);
			OnLoadVSync(dropdownVSync);
			OnLoadMainQuality(dropdownMainQuality);
			OnLoadShadowQuality(dropdownShadowQuality);
		});
	}

	public override void OnConfigUpdate(GameSettingsConfig config)
	{
		loadedGraphics = config.graphics;
		UpdateProperties();
	}

	private void LoadProperties()
	{
		OnLoadResolution(dropdownResolution);
		OnLoadMonitor(dropdownMonitor);
		OnLoadFullscreen(dropdownFullscreen);
		OnLoadVSync(dropdownVSync);
		OnLoadMainQuality(dropdownMainQuality);
		OnLoadShadowQuality(dropdownShadowQuality);
		OnLoadRenderScale(sliderRenderScale);
		UpdateProperties();
	}

	private void UpdateProperties()
	{
		dropdownResolution.SetValueWithoutNotify(loadedGraphics.resolutionIndex);
		dropdownMonitor.SetValueWithoutNotify(loadedGraphics.monitor);
		dropdownFullscreen.SetValueWithoutNotify(loadedGraphics.fullscreenMode);
		dropdownVSync.SetValueWithoutNotify(loadedGraphics.vSync);
		dropdownMainQuality.SetValueWithoutNotify(loadedGraphics.quality);
		dropdownShadowQuality.SetValueWithoutNotify(loadedGraphics.shadowQuality);
		sliderRenderScale.SetValueWithoutNotify(loadedGraphics.renderScale);
		sliderBrightness.SetValueWithoutNotify(loadedGraphics.brightness);
	}

	public GraphicsContainer GetLoadedGraphics()
	{
		return loadedGraphics;
	}

	public void OnLoadResolution(DropdownField dropdown)
	{
		int value = 0;
		List<string> list = new List<string>();
		for (int i = 0; i < Screen.resolutions.Length; i++)
		{
			if (Screen.resolutions[i].refreshRateRatio.value < loadedGraphics.refreshRate + 0.05000000074505806 && Screen.resolutions[i].refreshRateRatio.value > loadedGraphics.refreshRate - 0.05000000074505806)
			{
				list.Add(Screen.resolutions[i].ToString());
			}
			if (Screen.resolutions[i].width == loadedGraphics.resolutionX && Screen.resolutions[i].height == loadedGraphics.resolutionY && Screen.resolutions[i].refreshRateRatio.value == loadedGraphics.refreshRate)
			{
				value = i;
			}
		}
		dropdown.Init(value, list);
		GraphicsSettings.SetResolution(loadedGraphics.resolutionX, loadedGraphics.resolutionY, loadedGraphics.refreshRate);
		StartCoroutine(SetResolutionDropdown(dropdown));
	}

	private IEnumerator SetResolutionDropdown(DropdownField dropdown)
	{
		yield return new WaitForSeconds(1f);
		List<Resolution> list = new List<Resolution>();
		for (int i = 0; i < Screen.resolutions.Length; i++)
		{
			if (Screen.resolutions[i].refreshRateRatio.value < loadedGraphics.refreshRate + 0.05000000074505806 && Screen.resolutions[i].refreshRateRatio.value > loadedGraphics.refreshRate - 0.05000000074505806)
			{
				list.Add(Screen.resolutions[i]);
			}
		}
		loadedGraphics.resolutionIndex = list.FindIndex((Resolution resolution) => resolution.width == loadedGraphics.resolutionX && resolution.height == loadedGraphics.resolutionY);
		dropdown.SetValueWithoutNotify(loadedGraphics.resolutionIndex);
		GameSettings.SetGraphicsSettings(loadedGraphics);
		StopCoroutine(SetResolutionDropdown(dropdown));
	}

	public void OnLoadMonitor(DropdownField dropdown)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < Display.displays.Length; i++)
		{
			list.Add("Monitor " + (i + 1));
		}
		dropdown.Init(loadedGraphics.monitor, list);
		GraphicsSettings.SetMonitor(loadedGraphics.monitor);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadFullscreen(DropdownField dropdown)
	{
		dropdown.Init(loadedGraphics.fullscreenMode, LocalizationManager.GetLocalizedList(fullscreenLocalization, LocalizationDataTable.Tables.UI));
		GraphicsSettings.SetFullscreen(loadedGraphics.fullscreenMode);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadVSync(DropdownField dropdown)
	{
		dropdown.Init(loadedGraphics.vSync, LocalizationManager.GetLocalizedList(vsyncLocalization, LocalizationDataTable.Tables.UI));
		GraphicsSettings.SetVSync(loadedGraphics.vSync);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadRenderScale(SliderField slider)
	{
		slider.Init(loadedGraphics.renderScale);
		GraphicsSettings.SetRenderScale(loadedGraphics.renderScale);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadBrightness(SliderField slider)
	{
		slider.Init(loadedGraphics.brightness);
		GraphicsSettings.SetBrightness(loadedGraphics.brightness);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadMainQuality(DropdownField dropdown)
	{
		dropdown.Init(loadedGraphics.quality, LocalizationManager.GetLocalizedList(commonOptionsLocalization, LocalizationDataTable.Tables.UI));
		GraphicsSettings.SetMainQuality(loadedGraphics.quality);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnLoadShadowQuality(DropdownField dropdown)
	{
		dropdown.Init(loadedGraphics.shadowQuality, LocalizationManager.GetLocalizedList(commonOptionsLocalization, LocalizationDataTable.Tables.UI));
		GraphicsSettings.SetShadowQuality(loadedGraphics.shadowQuality);
		GameSettings.SetGraphicsSettings(loadedGraphics);
	}

	public void OnResolutionChanged(int value)
	{
		List<Resolution> list = new List<Resolution>();
		for (int i = 0; i < Screen.resolutions.Length; i++)
		{
			if (Screen.resolutions[i].refreshRateRatio.value < loadedGraphics.refreshRate + 0.05000000074505806 && Screen.resolutions[i].refreshRateRatio.value > loadedGraphics.refreshRate - 0.05000000074505806)
			{
				list.Add(Screen.resolutions[i]);
			}
		}
		Resolution resolution = list[value];
		loadedGraphics.resolutionX = resolution.width;
		loadedGraphics.resolutionY = resolution.height;
		loadedGraphics.resolutionIndex = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetResolution(loadedGraphics.resolutionX, loadedGraphics.resolutionY, loadedGraphics.refreshRate);
	}

	public void OnMonitorChanged(int value)
	{
		loadedGraphics.monitor = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetMonitor(loadedGraphics.monitor);
	}

	public void OnFullscreenChanged(int value)
	{
		loadedGraphics.fullscreenMode = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetFullscreen(loadedGraphics.fullscreenMode);
		dropdownFullscreen.Init(value, LocalizationManager.GetLocalizedList(fullscreenLocalization, LocalizationDataTable.Tables.UI));
	}

	public void OnVSyncChanged(int value)
	{
		loadedGraphics.vSync = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetVSync(loadedGraphics.vSync);
		dropdownVSync.Init(value, LocalizationManager.GetLocalizedList(vsyncLocalization, LocalizationDataTable.Tables.UI));
	}

	public void OnRenderScaleChanged(float value)
	{
		loadedGraphics.renderScale = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetRenderScale(loadedGraphics.renderScale);
	}

	public void OnBrightnessChanged(float value)
	{
		loadedGraphics.brightness = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetBrightness(loadedGraphics.brightness);
	}

	public void OnMainQualityChanged(int value)
	{
		loadedGraphics.quality = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetMainQuality(loadedGraphics.quality);
		dropdownFullscreen.Init(value, LocalizationManager.GetLocalizedList(commonOptionsLocalization, LocalizationDataTable.Tables.UI));
	}

	public void OnShadowQualityChanged(int value)
	{
		loadedGraphics.shadowQuality = value;
		GameSettings.UpdateGraphicsSettings(loadedGraphics);
		GraphicsSettings.SetShadowQuality(loadedGraphics.shadowQuality);
		dropdownFullscreen.Init(value, LocalizationManager.GetLocalizedList(commonOptionsLocalization, LocalizationDataTable.Tables.UI));
	}
}
