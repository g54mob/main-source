using System;
using System.Collections.Generic;
using CRTFilter;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
	public ScriptableRendererData RendererData;

	public Toggle FullScreenToggle;

	public Toggle CRTToggle;

	public Toggle FontToggle;

	public Toggle TrashHoleToggle;

	public Toggle ViewStatsToggle;

	public Slider MasterVolumeSlider;

	public Slider MusicVolumeSlider;

	public Slider SfxVolumeSlider;

	public TMP_Text MasterVolumeText;

	public TMP_Text MusicVolumeText;

	public TMP_Text SfxVolumeText;

	public GameObject ResolutionRow;

	public TMP_Dropdown ResolutionDropDown;

	public AudioMixer Mixer;

	private bool _isLoading = true;

	private CRTRendererFeature _feature;

	private List<string> _resolutionOptions = new List<string> { "Fullscreen", "480x270", "960x540", "1280x720", "1440x810", "1920x1080", "2400x1350", "2560x1440", "2880x1620" };

	private const int RES_FULL_OPTION = 0;

	private const int RES_NORMAL_OPTION = 3;

	private void Start()
	{
		_resolutionOptions[0] = LanguageText.GetText("Fullscreen");
		if (FullScreenToggle != null)
		{
			if (Installation.IsWeb())
			{
				FullScreenToggle.gameObject.SetActive(value: true);
				ResolutionRow.gameObject.SetActive(value: false);
			}
			else
			{
				FullScreenToggle.gameObject.SetActive(value: false);
				ResolutionRow.gameObject.SetActive(value: true);
			}
			PopulateResolutionDropdown();
		}
		foreach (ScriptableRendererFeature rendererFeature in RendererData.rendererFeatures)
		{
			if (rendererFeature is CRTRendererFeature)
			{
				_feature = (CRTRendererFeature)rendererFeature;
			}
		}
		if (_feature != null)
		{
			_feature.UpdateNewBlack(new Vector4(0.03137255f, 0.03137255f, 0.03137255f, 1f));
			_feature.OnValidate();
			_feature.UpdateValues();
		}
		_isLoading = true;
		LoadSettings();
		_isLoading = false;
	}

	public void LoadSettings()
	{
		if (!(MasterVolumeSlider == null))
		{
			float num = 1f;
			CRTToggle.isOn = _feature.preset != CRTRendererFeature.Presets.none;
			TrashHoleToggle.isOn = Hole.KeepGarbage;
			FullScreenToggle.isOn = Screen.fullScreen;
			FontToggle.isOn = !TextFontManager.IsNormalFont;
			ViewStatsToggle.isOn = GameController.SeeStats;
			if (ViewStatsToggle != null)
			{
				ViewStatsToggle.isOn = GameController.SeeStats;
			}
			Mixer.GetFloat("MasterVolume", out var value);
			num = Mathf.Pow(10f, value / 20f);
			MasterVolumeSlider.value = num;
			MasterVolumeText.text = (int)(num * 100f) + "%";
			Mixer.GetFloat("MusicVolume", out value);
			num = Mathf.Pow(10f, value / 20f);
			MusicVolumeSlider.value = num;
			MusicVolumeText.text = (int)(num * 100f) + "%";
			Mixer.GetFloat("SfxVolume", out value);
			num = Mathf.Pow(10f, value / 20f);
			SfxVolumeSlider.value = num;
			SfxVolumeText.text = (int)(num * 100f) + "%";
			SetResolutionDropdownValue();
		}
	}

	public void ChangeFullScreen()
	{
		PlayCheckbox(FullScreenToggle.isOn);
		if (Screen.fullScreen != FullScreenToggle.isOn)
		{
			if (FullScreenToggle.isOn)
			{
				ProcessResolution(_resolutionOptions[0]);
			}
			else
			{
				ProcessResolution(_resolutionOptions[3]);
			}
		}
	}

	public void ChangeCRT()
	{
		PlayCheckbox(CRTToggle.isOn);
		if (CRTToggle.isOn)
		{
			_feature.preset = CRTRendererFeature.Presets.hole;
		}
		else
		{
			_feature.preset = CRTRendererFeature.Presets.none;
		}
		_feature.OnValidate();
		_feature.UpdateValues();
		SaveDefault();
	}

	public void ChangeFont()
	{
		PlayCheckbox(FontToggle.isOn);
		TextFontManager.UpdateFontType(!FontToggle.isOn);
		SaveDefault();
	}

	public void ChangeTrashHole()
	{
		PlayCheckbox(TrashHoleToggle.isOn);
		Hole.KeepGarbage = TrashHoleToggle.isOn;
		SaveDefault();
	}

	public void ChangeMasterVolume()
	{
		float value = MasterVolumeSlider.value;
		float value2 = ((value != 0f) ? (Mathf.Log10(value) * 20f) : 0f);
		Mixer.SetFloat("MasterVolume", value2);
		MasterVolumeText.text = (int)(value * 100f) + "%";
		PlayMasterTest();
		SaveDefault();
	}

	public void ChangeMusicVolume()
	{
		float value = MusicVolumeSlider.value;
		float value2 = ((value != 0f) ? (Mathf.Log10(value) * 20f) : 0f);
		Mixer.SetFloat("MusicVolume", value2);
		MusicVolumeText.text = (int)(value * 100f) + "%";
		SaveDefault();
	}

	public void ChangeSfxVolume()
	{
		float value = SfxVolumeSlider.value;
		float value2 = ((value != 0f) ? (Mathf.Log10(value) * 20f) : 0f);
		Mixer.SetFloat("SfxVolume", value2);
		SfxVolumeText.text = (int)(value * 100f) + "%";
		PlayTest();
		SaveDefault();
	}

	public void ChangeViewStats()
	{
		PlayCheckbox(ViewStatsToggle.isOn);
		GameController.SeeStats = ViewStatsToggle.isOn;
		SaveDefault();
	}

	public void LoadDefault(bool reset = false)
	{
		_isLoading = true;
		if (SaveManager.HasAppSaveData() && !reset)
		{
			SaveManager.LoadAppData();
			if (SaveManager.AppData == null)
			{
				SaveManager.AppData = new AppData();
				SaveManager.AppData.TimeCreated = DateTime.Now;
				SaveManager.AppData.VolumeVolume = 40;
				SaveManager.AppData.MusicVolume = 60;
				SaveManager.AppData.SFXVolume = 80;
				SaveManager.AppData.HasCRTEffect = true;
				SaveManager.AppData.HasHoleTrash = true;
				SaveManager.AppData.HasViewStats = false;
				SaveManager.AppData.HasIsNormalFont = false;
			}
		}
		else
		{
			SaveManager.AppData = new AppData();
			SaveManager.AppData.TimeCreated = DateTime.Now;
			SaveManager.AppData.VolumeVolume = 40;
			SaveManager.AppData.MusicVolume = 60;
			SaveManager.AppData.SFXVolume = 80;
			SaveManager.AppData.HasCRTEffect = true;
			SaveManager.AppData.HasHoleTrash = true;
			SaveManager.AppData.HasViewStats = false;
			SaveManager.AppData.HasIsNormalFont = false;
		}
		float num = (float)SaveManager.AppData.VolumeVolume / 100f;
		float value = ((num != 0f) ? (Mathf.Log10(num) * 20f) : (-80f));
		Mixer.SetFloat("MasterVolume", value);
		num = (float)SaveManager.AppData.MusicVolume / 100f;
		value = ((num != 0f) ? (Mathf.Log10(num) * 20f) : (-80f));
		Mixer.SetFloat("MusicVolume", value);
		num = (float)SaveManager.AppData.SFXVolume / 100f;
		value = ((num != 0f) ? (Mathf.Log10(num) * 20f) : (-80f));
		Mixer.SetFloat("SfxVolume", value);
		Hole.KeepGarbage = SaveManager.AppData.HasHoleTrash;
		GameController.SeeStats = SaveManager.AppData.HasViewStats;
		CRTToggle.isOn = SaveManager.AppData.HasCRTEffect;
		TrashHoleToggle.isOn = SaveManager.AppData.HasHoleTrash;
		ViewStatsToggle.isOn = SaveManager.AppData.HasViewStats;
		TextFontManager.UpdateFontType(SaveManager.AppData.HasIsNormalFont);
		LoadSettings();
		_isLoading = false;
	}

	public void SaveDefault()
	{
		if (SaveManager.AppData == null)
		{
			SaveManager.AppData = new AppData();
		}
		SaveManager.AppData.TimeCreated = DateTime.Now;
		SaveManager.AppData.VolumeVolume = (int)(MasterVolumeSlider.value * 100f);
		SaveManager.AppData.MusicVolume = (int)(MusicVolumeSlider.value * 100f);
		SaveManager.AppData.SFXVolume = (int)(SfxVolumeSlider.value * 100f);
		SaveManager.AppData.HasCRTEffect = CRTToggle.isOn;
		SaveManager.AppData.HasHoleTrash = TrashHoleToggle.isOn;
		SaveManager.AppData.HasViewStats = ViewStatsToggle.isOn;
		SaveManager.AppData.HasIsNormalFont = TextFontManager.IsNormalFont;
	}

	private void PlayCheckbox(bool isOn)
	{
		if (!_isLoading)
		{
			if (isOn)
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_checkbox_on);
			}
			else
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_checkbox_off);
			}
		}
	}

	private void PlayMasterTest()
	{
		if (!_isLoading)
		{
			GlobalSfx2Controller.Instance.PlayMasterTest();
		}
	}

	private void PlayTest()
	{
		if (!_isLoading)
		{
			GlobalSfx2Controller.Instance.PlayTest();
		}
	}

	private void PopulateResolutionDropdown()
	{
		ResolutionDropDown.ClearOptions();
		ResolutionDropDown.AddOptions(_resolutionOptions);
		ResolutionDropDown.RefreshShownValue();
	}

	private void SetResolutionDropdownValue()
	{
		int value = 0;
		if (Screen.fullScreen)
		{
			value = 0;
		}
		else
		{
			for (int i = 0; i < _resolutionOptions.Count; i++)
			{
				if (_resolutionOptions[i].StartsWith(Screen.width.ToString()))
				{
					value = i;
				}
			}
		}
		ResolutionDropDown.value = value;
		ResolutionDropDown.RefreshShownValue();
	}

	public void ProcesResolutionDropdownChange()
	{
		string text = ResolutionDropDown.options[ResolutionDropDown.value].text;
		ProcessResolution(text);
	}

	public void ProcessResolution(string resolution)
	{
		if (resolution == LanguageText.GetText("Fullscreen"))
		{
			Screen.fullScreen = true;
			return;
		}
		Screen.fullScreen = false;
		switch (resolution)
		{
		case "480x270":
			Screen.SetResolution(480, 270, fullscreen: false);
			break;
		case "960x540":
			Screen.SetResolution(960, 540, fullscreen: false);
			break;
		case "1280x720":
			Screen.SetResolution(1280, 720, fullscreen: false);
			break;
		case "1440x810":
			Screen.SetResolution(1440, 810, fullscreen: false);
			break;
		case "1920x1080":
			Screen.SetResolution(1920, 1080, fullscreen: false);
			break;
		case "2400x1350":
			Screen.SetResolution(2400, 1350, fullscreen: false);
			break;
		case "2560x1440":
			Screen.SetResolution(2560, 1440, fullscreen: false);
			break;
		case "2880x1620":
			Screen.SetResolution(2880, 1620, fullscreen: false);
			break;
		}
	}
}
