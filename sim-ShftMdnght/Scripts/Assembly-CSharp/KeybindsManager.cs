using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class KeybindsManager : MonoBehaviour
{
	public TextMeshProUGUI[] buttonLabels;

	public GameObject[] buttonBGs;

	public int keyIndex;

	private bool picking;

	public Slider sensSlider;

	public TextMeshProUGUI sensValue;

	public TextMeshProUGUI sfxValue;

	public TextMeshProUGUI musicValue;

	public TextMeshProUGUI playerVolValue;

	public Toggle invertX;

	public Toggle invertY;

	public Toggle epilepsyMode;

	public Light[] shootLights;

	public SpriteRenderer[] shootSprites;

	public Slider fovSlider;

	public TextMeshProUGUI fovValue;

	public Slider brightnessSlider;

	public TextMeshProUGUI brightnessValue;

	public Volume globalVolume;

	private ColorAdjustments colorAdj;

	public Toggle camShakeToggle;

	public Toggle camBobbingToggle;

	public TMP_Dropdown fullscreenDropdown;

	public TMP_Dropdown frameRateDropdown;

	public Toggle vSyncToggle;

	public GameObject lostConnectionWarning;

	public Slider sfxSlider;

	public Slider musicSlider;

	public Slider playerVolSlider;

	public AudioMixer audioMixer;

	private const string SFXVolumeParameter = "SFX";

	private const string MusicVolumeParameter = "Music";

	private const string PlayerVolumeParameter = "PlayerVoice";

	private void Start()
	{
		TMP_Dropdown[] array = UnityEngine.Object.FindObjectsOfType<TMP_Dropdown>(includeInactive: true);
		foreach (TMP_Dropdown tMP_Dropdown in array)
		{
			tMP_Dropdown.captionText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			if (tMP_Dropdown.itemText != null)
			{
				tMP_Dropdown.itemText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			}
			tMP_Dropdown.RefreshShownValue();
		}
		UpdateAllLanguageChanges();
		InitializeKeybinds();
		LoadSettings();
		fullscreenDropdown.onValueChanged.AddListener(ApplyFullscreenMode);
		frameRateDropdown.onValueChanged.AddListener(ApplyFrameRate);
		vSyncToggle.onValueChanged.AddListener(ApplyVSync);
		sfxSlider.onValueChanged.AddListener(SetSFXVolume);
		musicSlider.onValueChanged.AddListener(SetMusicVolume);
		playerVolSlider.onValueChanged.AddListener(SetPlayerVoiceVolume);
		if (PlayerPrefs.GetInt("InvertX", 0) == 1)
		{
			invertX.isOn = true;
		}
		if (PlayerPrefs.GetInt("InvertY", 0) == 1)
		{
			invertY.isOn = true;
		}
		if (PlayerPrefs.GetInt("Epilepsy", 0) == 1)
		{
			epilepsyMode.isOn = true;
		}
		ChangeInvertY();
		ChangeInvertX();
		ChangeEpilepsyMode();
	}

	public void LoadKeybindsMenu()
	{
		sensSlider.value = PlayerPrefs.GetFloat("Sensitivity") / 10f;
		for (int i = 0; i < buttonLabels.Length; i++)
		{
			buttonLabels[i].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			buttonLabels[i].text = PlayerPrefs.GetString("Keybind" + i);
		}
	}

	public void ChangeInvertX()
	{
		if (invertX.isOn)
		{
			PlayerPrefs.SetInt("InvertX", 1);
		}
		else
		{
			PlayerPrefs.SetInt("InvertX", 0);
		}
	}

	public void ChangeInvertY()
	{
		if (invertY.isOn)
		{
			PlayerPrefs.SetInt("InvertY", 1);
		}
		else
		{
			PlayerPrefs.SetInt("InvertY", 0);
		}
	}

	public void ChangeEpilepsyMode()
	{
		if (epilepsyMode.isOn)
		{
			PlayerPrefs.SetInt("Epilepsy", 1);
			if (shootLights.Length != 0)
			{
				Light[] array = shootLights;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = false;
				}
				SpriteRenderer[] array2 = shootSprites;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].enabled = false;
				}
			}
		}
		else
		{
			PlayerPrefs.SetInt("Epilepsy", 0);
			if (shootLights.Length != 0)
			{
				Light[] array = shootLights;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = true;
				}
				SpriteRenderer[] array2 = shootSprites;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].enabled = true;
				}
			}
		}
		EpilepsyHandler[] array3 = UnityEngine.Object.FindObjectsOfType<EpilepsyHandler>();
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i].OnEnable();
		}
	}

	private void InitializeKeybinds()
	{
		if (PlayerPrefs.GetInt("InitializedKeybindsSteam_") != 1)
		{
			PlayerPrefs.SetInt("InitializedKeybindsSteam_", 1);
			PlayerPrefs.SetFloat("Sensitivity", 1f);
			PlayerPrefs.SetString("Keybind0", "W");
			PlayerPrefs.SetString("Keybind1", "A");
			PlayerPrefs.SetString("Keybind2", "S");
			PlayerPrefs.SetString("Keybind3", "D");
			PlayerPrefs.SetString("Keybind4", "Space");
			PlayerPrefs.SetString("Keybind5", "left ctrl");
			PlayerPrefs.SetString("Keybind6", "left shift");
			PlayerPrefs.SetString("Keybind7", "E");
			PlayerPrefs.SetString("Keybind8", "F");
			PlayerPrefs.SetString("Keybind9", "G");
			PlayerPrefs.SetString("Keybind10", "R");
			PlayerPrefs.SetString("Keybind11", "V");
			PlayerPrefs.SetFloat("FOV", 70f);
			PlayerPrefs.SetFloat("SFXVolume", 1f);
			PlayerPrefs.SetFloat("MusicVolume", 1f);
			PlayerPrefs.SetFloat("PlayerVolume", 1f);
			SetSFXVolume(1f);
			SetMusicVolume(1f);
		}
		sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
		fovSlider.value = PlayerPrefs.GetFloat("FOV", 70f);
		brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 50f);
		musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
		playerVolSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1f);
		sfxValue.text = PlayerPrefs.GetFloat("SFXVolume").ToString("0.0");
		sfxValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		musicValue.text = PlayerPrefs.GetFloat("MusicVolume").ToString("0.0");
		musicValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		playerVolValue.text = PlayerPrefs.GetFloat("PlayerVolume").ToString("0.0");
		playerVolValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20f);
		audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20f);
		audioMixer.SetFloat("PlayerVoice", Mathf.Log10(PlayerPrefs.GetFloat("PlayerVolume")) * 20f);
		if (PlayerPrefs.GetInt("CamShake", 1) == 0)
		{
			camShakeToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("CamBobbing", 1) == 0)
		{
			camBobbingToggle.isOn = false;
		}
		if ((bool)StoreManager.Instance)
		{
			globalVolume = StoreManager.Instance.globalVolume;
		}
		if (globalVolume != null && globalVolume.profile.TryGet<ColorAdjustments>(out colorAdj))
		{
			ApplyEV(Mathf.Lerp(-2f, 2f, PlayerPrefs.GetFloat("Brightness", 50f) / 100f));
		}
	}

	public void UpdateSensitivity()
	{
		PlayerPrefs.SetFloat("Sensitivity", sensSlider.value * 10f);
		sensValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		sensValue.text = PlayerPrefs.GetFloat("Sensitivity").ToString("0.0");
		sfxValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		sfxValue.text = PlayerPrefs.GetFloat("SFXVolume").ToString("0.0");
		musicValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		musicValue.text = PlayerPrefs.GetFloat("MusicVolume").ToString("0.0");
		playerVolValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		playerVolValue.text = PlayerPrefs.GetFloat("PlayerVolume").ToString("0.0");
	}

	public void UpdateFOV()
	{
		PlayerPrefs.SetFloat("FOV", fovSlider.value);
		fovValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		fovValue.text = PlayerPrefs.GetFloat("FOV").ToString("0");
	}

	public void UpdateBrightness()
	{
		PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
		brightnessValue.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		brightnessValue.text = PlayerPrefs.GetFloat("Brightness").ToString("0");
		ApplyEV(Mathf.Lerp(-2f, 2f, PlayerPrefs.GetFloat("Brightness", 50f) / 100f));
	}

	private void ApplyEV(float ev)
	{
		if (colorAdj != null)
		{
			colorAdj.postExposure.Override(ev);
		}
	}

	public void ToggleCamShake()
	{
		if (camShakeToggle.isOn)
		{
			PlayerPrefs.SetInt("CamShake", 1);
		}
		else
		{
			PlayerPrefs.SetInt("CamShake", 0);
		}
	}

	public void ToggleCamBobbing()
	{
		if (camBobbingToggle.isOn)
		{
			PlayerPrefs.SetInt("CamBobbing", 1);
		}
		else
		{
			PlayerPrefs.SetInt("CamBobbing", 0);
		}
	}

	private void Update()
	{
		if (!picking)
		{
			return;
		}
		foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
		{
			if (!Input.GetKey(value))
			{
				continue;
			}
			picking = false;
			buttonLabels[keyIndex].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			buttonLabels[keyIndex].text = value.ToString();
			buttonBGs[keyIndex].SetActive(value: false);
			PlayerPrefs.SetString("Keybind" + keyIndex, value.ToString());
			PlayerPrefs.Save();
			ChangeTextToKeybind[] array = UnityEngine.Object.FindObjectsOfType<ChangeTextToKeybind>(includeInactive: true);
			foreach (ChangeTextToKeybind changeTextToKeybind in array)
			{
				if (changeTextToKeybind.gameObject.activeInHierarchy)
				{
					changeTextToKeybind.Refresh();
				}
			}
		}
	}

	public void ChangeKey(int num)
	{
		keyIndex = num;
		buttonBGs[num].SetActive(value: true);
		buttonLabels[num].text = " ";
		picking = true;
	}

	public void UpdateAllLanguageChanges()
	{
		TMP_Dropdown[] array = UnityEngine.Object.FindObjectsOfType<TMP_Dropdown>(includeInactive: true);
		foreach (TMP_Dropdown tMP_Dropdown in array)
		{
			tMP_Dropdown.captionText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			if (tMP_Dropdown.itemText != null)
			{
				tMP_Dropdown.itemText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			}
			tMP_Dropdown.RefreshShownValue();
		}
		fullscreenDropdown.options[0].text = JSONAccess.Instance.GetMiscText("UI Text 4", "Fullscreen");
		fullscreenDropdown.options[1].text = JSONAccess.Instance.GetMiscText("UI Text 4", "Windowed");
		fullscreenDropdown.options[2].text = JSONAccess.Instance.GetMiscText("UI Text 4", "Windowed Borderless");
		string miscText = JSONAccess.Instance.GetMiscText("UI Text 4", "<FPS> FPS");
		frameRateDropdown.options[0].text = JSONAccess.Instance.GetMiscText("UI Text 4", "Unlimited");
		frameRateDropdown.options[1].text = miscText.Replace("<FPS>", "30");
		frameRateDropdown.options[2].text = miscText.Replace("<FPS>", "44");
		frameRateDropdown.options[3].text = miscText.Replace("<FPS>", "60");
		frameRateDropdown.options[4].text = miscText.Replace("<FPS>", "90");
		frameRateDropdown.options[5].text = miscText.Replace("<FPS>", "120");
		frameRateDropdown.options[6].text = miscText.Replace("<FPS>", "144");
		frameRateDropdown.options[7].text = miscText.Replace("<FPS>", "165");
		frameRateDropdown.options[8].text = miscText.Replace("<FPS>", "240");
		frameRateDropdown.RefreshShownValue();
		fullscreenDropdown.RefreshShownValue();
	}

	public void ApplyFullscreenMode(int modeIndex)
	{
		switch (modeIndex)
		{
		case 0:
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
			break;
		case 1:
			Screen.fullScreenMode = FullScreenMode.Windowed;
			break;
		case 2:
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			break;
		}
		SaveSettings("FullscreenMode", modeIndex);
		LoadSettings();
	}

	private void SaveSettings(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}

	public void OpenFeedback()
	{
		CustomNetworkManager.singleton.ReturnClientToMainMenu("idk");
	}

	public void ApplyVSync(bool isOn)
	{
		if (isOn)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		SaveSettings("VSync", isOn ? 1 : 0);
		LoadSettings();
	}

	public void ApplyFrameRate(int index)
	{
		switch (index)
		{
		case 0:
			Application.targetFrameRate = -1;
			break;
		case 1:
			Application.targetFrameRate = 30;
			break;
		case 2:
			Application.targetFrameRate = 44;
			break;
		case 3:
			Application.targetFrameRate = 60;
			break;
		case 4:
			Application.targetFrameRate = 90;
			break;
		case 5:
			Application.targetFrameRate = 120;
			break;
		case 6:
			Application.targetFrameRate = 144;
			break;
		case 7:
			Application.targetFrameRate = 165;
			break;
		case 8:
			Application.targetFrameRate = 240;
			break;
		}
		SaveSettings("FrameRateIndex", index);
		LoadSettings();
	}

	private void LoadSettings()
	{
		int num = (PlayerPrefs.HasKey("FullscreenMode") ? PlayerPrefs.GetInt("FullscreenMode") : 2);
		fullscreenDropdown.value = num;
		SetFullscreenMode(num);
		int num2 = PlayerPrefs.GetInt("FrameRateIndex", 0);
		frameRateDropdown.value = num2;
		SetFrameRate(num2);
		bool flag = PlayerPrefs.GetInt("VSync", 1) == 1;
		vSyncToggle.isOn = flag;
		SetVSync(flag);
	}

	public void SetFullscreenMode(int modeIndex)
	{
		switch (modeIndex)
		{
		case 0:
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
			break;
		case 1:
			Screen.fullScreenMode = FullScreenMode.Windowed;
			break;
		case 2:
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			break;
		}
	}

	public void SetVSync(bool isOn)
	{
		if (isOn)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
	}

	public void SetFrameRate(int index)
	{
		switch (index)
		{
		case 0:
			Application.targetFrameRate = -1;
			break;
		case 1:
			Application.targetFrameRate = 30;
			break;
		case 2:
			Application.targetFrameRate = 44;
			break;
		case 3:
			Application.targetFrameRate = 60;
			break;
		case 4:
			Application.targetFrameRate = 90;
			break;
		case 5:
			Application.targetFrameRate = 120;
			break;
		case 6:
			Application.targetFrameRate = 144;
			break;
		case 7:
			Application.targetFrameRate = 165;
			break;
		case 8:
			Application.targetFrameRate = 240;
			break;
		}
	}

	public void SetSFXVolume(float volume)
	{
		audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20f);
		PlayerPrefs.SetFloat("SFXVolume", volume);
		sfxValue.text = volume.ToString("0.0");
		PlayerPrefs.Save();
	}

	public void SetMusicVolume(float volume)
	{
		audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20f);
		PlayerPrefs.SetFloat("MusicVolume", volume);
		musicValue.text = volume.ToString("0.0");
		PlayerPrefs.Save();
	}

	public void SetPlayerVoiceVolume(float volume)
	{
		audioMixer.SetFloat("PlayerVoice", Mathf.Log10(volume) * 20f);
		PlayerPrefs.SetFloat("PlayerVolume", volume);
		playerVolValue.text = volume.ToString("0.0");
		PlayerPrefs.Save();
	}
}
