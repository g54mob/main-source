using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioVideoSettingsUI : MonoBehaviour
{
	[Header("Video")]
	[SerializeField]
	private TMP_Dropdown resolutionDropdown;

	[SerializeField]
	private TMP_Dropdown screenModeDropdown;

	[SerializeField]
	private Toggle cursorLockedToWindowToggle;

	[SerializeField]
	private Toggle vSyncToggle;

	[SerializeField]
	private Slider limitFpsSlider;

	[Header("Audio")]
	[SerializeField]
	private Slider masterVolumeSlider;

	[SerializeField]
	private Slider musicVolumeSlider;

	[SerializeField]
	private Slider soundVolumeSlider;

	private Color limitFpsSliderColor;

	private void Awake()
	{
		limitFpsSliderColor = limitFpsSlider.targetGraphic.color;
	}

	private void Start()
	{
		FillResolutionsDropdown();
		UpdateScreenmodeDropdown();
		UpdateLimitFpsSlider();
		UpdateCursorLockedToWindowToggle();
		UpdateVsyncToggle();
		UpdateAudioSliderValues();
	}

	private void Update()
	{
		CheckFullScreenModeChanged();
	}

	private void CheckFullScreenModeChanged()
	{
		if ((Screen.fullScreenMode != FullScreenMode.FullScreenWindow || screenModeDropdown.value == 0) && (Screen.fullScreenMode != FullScreenMode.Windowed || screenModeDropdown.value == 1))
		{
			return;
		}
		bool flag = false;
		if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
		{
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				if (Screen.currentResolution.width == resolution.width && Screen.currentResolution.height == resolution.height)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				SettingsController.instance.SetScreenResolution(Screen.resolutions[Screen.resolutions.Length - 1].width, Screen.resolutions[Screen.resolutions.Length - 1].height, Screen.fullScreenMode);
			}
		}
		UpdateResolutionDorpdown();
		UpdateScreenmodeDropdown();
		UpdateVsyncToggle();
	}

	private void FillResolutionsDropdown()
	{
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = -1;
		int num2 = 0;
		for (int num3 = Screen.resolutions.Length - 1; num3 >= 0; num3--)
		{
			if (num3 == Screen.resolutions.Length - 1 || Screen.resolutions[num3].width != Screen.resolutions[num3 + 1].width || Screen.resolutions[num3].height != Screen.resolutions[num3 + 1].height)
			{
				list.Add(new TMP_Dropdown.OptionData(Screen.resolutions[num3].width + " x " + Screen.resolutions[num3].height));
				num2++;
			}
			if (num == -1 && Screen.currentResolution.width == Screen.resolutions[num3].width && Screen.currentResolution.height == Screen.resolutions[num3].height)
			{
				num = num2 - 1;
			}
		}
		resolutionDropdown.options = list;
		UpdateResolutionDorpdown();
	}

	private void UpdateResolutionDorpdown()
	{
		int num = 0;
		foreach (TMP_Dropdown.OptionData option in resolutionDropdown.options)
		{
			if (Screen.width == int.Parse(option.text.Split('x')[0]) && Screen.height == int.Parse(option.text.Split('x')[1]))
			{
				resolutionDropdown.value = num;
			}
			num++;
		}
	}

	public void UpdateScreenmodeDropdown()
	{
		switch (Screen.fullScreenMode)
		{
		case FullScreenMode.FullScreenWindow:
			screenModeDropdown.value = 0;
			break;
		case FullScreenMode.Windowed:
			screenModeDropdown.value = 1;
			break;
		}
	}

	private void UpdateCursorLockedToWindowToggle()
	{
		cursorLockedToWindowToggle.isOn = SettingsController.instance.CursorLockedToWindow;
	}

	private void UpdateVsyncToggle()
	{
		vSyncToggle.isOn = SettingsController.instance.IsVSyncEnabled();
		SetLimitFpsSliderEnabled(!SettingsController.instance.IsVSyncEnabled());
	}

	private void SetLimitFpsSliderEnabled(bool enable)
	{
		limitFpsSlider.interactable = enable;
		limitFpsSlider.GetComponent<CanvasGroup>().alpha = (enable ? 1f : 0.2f);
	}

	private void UpdateLimitFpsSlider()
	{
		limitFpsSlider.value = ((Application.targetFrameRate <= 0) ? limitFpsSlider.maxValue : ((float)Application.targetFrameRate));
	}

	private void UpdateAudioSliderValues()
	{
		masterVolumeSlider.value = SettingsController.instance.GetMasterVolume() * 100f;
		musicVolumeSlider.value = SettingsController.instance.GetMusicVolume() * 100f;
		soundVolumeSlider.value = SettingsController.instance.GetSFXVolume() * 100f;
	}

	public void OnResolutionChanged()
	{
		string[] array = resolutionDropdown.options[resolutionDropdown.value].text.Split('x');
		int width = int.Parse(array[0].Trim());
		int height = int.Parse(array[1].Trim());
		SettingsController.instance.SetScreenResolution(width, height, Screen.fullScreenMode);
	}

	public void OnScreenModeChanged()
	{
		switch (screenModeDropdown.value)
		{
		case 0:
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			break;
		case 1:
			Screen.fullScreenMode = FullScreenMode.Windowed;
			break;
		}
	}

	public void OnLockCursorToWindowChanged(bool locked)
	{
		SettingsController.instance.CursorLockedToWindow = locked;
	}

	public void OnVSyncChanged(bool enabled)
	{
		SettingsController.instance.SetVSync(enabled);
		SetLimitFpsSliderEnabled(!SettingsController.instance.IsVSyncEnabled());
	}

	public void OnLimitFPSChanged()
	{
		int num = (int)limitFpsSlider.value;
		SettingsController.instance.SetTargetFPS((!((float)num >= limitFpsSlider.maxValue)) ? num : 0);
	}

	public void OnMasterVolumeSliderChanged()
	{
		SettingsController.instance.SetMasterVolume(masterVolumeSlider.value * 0.01f);
	}

	public void OnMusicVolumeSliderChanged()
	{
		SettingsController.instance.SetMusicVolume(musicVolumeSlider.value * 0.01f);
	}

	public void OnSoundVolumeSliderChanged()
	{
		SettingsController.instance.SetSFXVolume(soundVolumeSlider.value * 0.01f);
		SettingsController.instance.SetUIVolume(soundVolumeSlider.value * 0.01f);
		SettingsController.instance.SetAmbienceVolume(soundVolumeSlider.value * 0.01f);
	}
}
