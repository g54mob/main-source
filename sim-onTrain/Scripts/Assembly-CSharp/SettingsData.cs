using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsData", menuName = "TrainSurvival/Settings Data")]
public class SettingsData : ScriptableObject
{
	public enum TextureOption
	{
		FullRes = 0,
		HalfRes = 1,
		QuarterRes = 2,
		EighthRes = 3
	}

	public enum AnisotropicOption
	{
		None = 0,
		PerTexture = 1,
		ForcedOn = 2
	}

	[Header("Language Settings")]
	public string languageCode = "en";

	[Header("Input Settings")]
	[Range(0.1f, 5f)]
	public float mouseSensitivity = 1f;

	public bool invertMouse;

	[Header("Gameplay Settings")]
	public bool showTutorial = true;

	public bool showPlayerNames = true;

	public bool showCompass = true;

	[Header("Audio Settings")]
	[Range(0f, 1f)]
	public float masterVolume = 1f;

	[Range(0f, 1f)]
	public float musicVolume = 1f;

	[Range(0f, 1f)]
	public float sfxVolume = 1f;

	[Range(0f, 1f)]
	public float uiVolume = 1f;

	[Range(0f, 1f)]
	public float ambienceVolume = 1f;

	public bool muteAudio;

	[Header("Voice Chat Settings")]
	[Range(0f, 1f)]
	public float voiceInputVolume = 1f;

	[Range(0f, 1f)]
	public float voiceOutputVolume = 1f;

	public string voiceInputDevice = "";

	public bool voiceChatEnabled = true;

	public bool voicePushToTalk;

	[Header("Display Settings")]
	public Resolution currentResolution = new Resolution
	{
		width = 1920,
		height = 1080,
		refreshRate = 60
	};

	public FullScreenMode fullscreenMode = FullScreenMode.FullScreenWindow;

	public int targetDisplay;

	[Header("Post-Processing")]
	public bool vignette;

	public bool depthOfField;

	public bool motionBlur;

	public bool chromaticAberration;

	public bool filmGrain;

	public bool ambientOcclusion;

	[Header("URP Quality")]
	public int aaMode = 1;

	public int aaQuality = 1;

	public int msaa = 2;

	[Range(0.5f, 1.5f)]
	public float renderScale = 1f;

	[Header("Display / Performance")]
	public bool vSync = true;

	public int targetFrameRate = -1;

	public int resolutionIndex = -1;

	[Header("Quality (Textures)")]
	public TextureOption textureQuality;

	public AnisotropicOption anisotropic = AnisotropicOption.PerTexture;

	[Header("Render Quality Preset")]
	public int qualityPreset = 1;

	[NonSerialized]
	public Resolution[] availableResolutions;

	private void OnEnable()
	{
		RefreshAvailableResolutions();
	}

	public void RefreshAvailableResolutions()
	{
		Resolution[] resolutions = Screen.resolutions;
		Dictionary<long, Resolution> dictionary = new Dictionary<long, Resolution>();
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution value = resolutions[i];
			long key = ((long)value.width << 32) | value.height;
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = value;
			}
			else if (value.refreshRateRatio.value > dictionary[key].refreshRateRatio.value)
			{
				dictionary[key] = value;
			}
		}
		List<Resolution> list = new List<Resolution>(dictionary.Values);
		list.Sort(delegate(Resolution a, Resolution b)
		{
			int num2 = a.width.CompareTo(b.width);
			return (num2 == 0) ? a.height.CompareTo(b.height) : num2;
		});
		availableResolutions = list.ToArray();
		if (currentResolution.width == 0 || currentResolution.height == 0)
		{
			currentResolution = Screen.currentResolution;
		}
		if (availableResolutions == null || availableResolutions.Length == 0 || (resolutionIndex >= 0 && resolutionIndex < availableResolutions.Length))
		{
			return;
		}
		resolutionIndex = 0;
		for (int num = 0; num < availableResolutions.Length; num++)
		{
			Resolution resolution = availableResolutions[num];
			if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
			{
				resolutionIndex = num;
				break;
			}
		}
	}

	public void ApplySettings()
	{
		Screen.SetResolution(currentResolution.width, currentResolution.height, fullscreenMode, currentResolution.refreshRate);
		Debug.Log("Settings applied");
	}

	public void ResetToDefaults()
	{
		languageCode = "en";
		masterVolume = 1f;
		musicVolume = 1f;
		sfxVolume = 1f;
		uiVolume = 1f;
		ambienceVolume = 1f;
		muteAudio = false;
		voiceInputVolume = 1f;
		voiceOutputVolume = 1f;
		voiceInputDevice = "";
		voiceChatEnabled = true;
		voicePushToTalk = false;
		mouseSensitivity = 1f;
		invertMouse = false;
		showPlayerNames = true;
		showCompass = true;
		currentResolution = Screen.currentResolution;
		fullscreenMode = FullScreenMode.FullScreenWindow;
		targetDisplay = 0;
		vignette = (depthOfField = (motionBlur = (chromaticAberration = (filmGrain = (ambientOcclusion = false)))));
		aaMode = 1;
		aaQuality = 1;
		msaa = 2;
		renderScale = 1f;
		textureQuality = TextureOption.FullRes;
		anisotropic = AnisotropicOption.PerTexture;
		qualityPreset = 1;
		Debug.Log("Settings reset to defaults");
	}
}
