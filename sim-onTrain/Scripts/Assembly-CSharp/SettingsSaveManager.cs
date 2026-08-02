using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class SettingsSaveManager : Singleton<SettingsSaveManager>
{
	private string settingsFilePath;

	private const string SETTINGS_FILE_NAME = "Settings.es3";

	public static UnityEvent OnSettingsManagerReady = new UnityEvent();

	private void Start()
	{
		InitializeSettingsPath();
		OnSettingsManagerReady.Invoke();
	}

	public void InitializeSettingsPath()
	{
		settingsFilePath = Path.Combine(GetSettingsPath(), "Settings.es3");
	}

	private string GetSettingsPath()
	{
		string text = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Users", "DB", "Settings");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	public void SaveSetting(string key, object value)
	{
		if (!string.IsNullOrEmpty(settingsFilePath))
		{
			ES3.Save(key, value, settingsFilePath);
		}
	}

	public T LoadSetting<T>(string key, T defaultValue = default(T))
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			return ES3.Load(key, settingsFilePath, defaultValue);
		}
		return defaultValue;
	}

	public bool HasSetting(string key)
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			return ES3.KeyExists(key, settingsFilePath);
		}
		return false;
	}

	public void DeleteSetting(string key)
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			ES3.DeleteKey(key, settingsFilePath);
		}
	}

	public void DeleteAllSettings()
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			ES3.DeleteFile(settingsFilePath);
		}
	}

	public string[] GetAllSettingKeys()
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			return ES3.GetKeys(settingsFilePath);
		}
		return new string[0];
	}

	public void SaveSettingsData(SettingsData settings)
	{
		if (!string.IsNullOrEmpty(settingsFilePath))
		{
			ES3File eS3File = new ES3File(settingsFilePath);
			eS3File.Save("languageCode", settings.languageCode);
			eS3File.Save("mouseSensitivity", settings.mouseSensitivity);
			eS3File.Save("invertMouse", settings.invertMouse);
			eS3File.Save("showTutorial", settings.showTutorial);
			eS3File.Save("showPlayerNames", settings.showPlayerNames);
			eS3File.Save("showCompass", settings.showCompass);
			eS3File.Save("masterVolume", settings.masterVolume);
			eS3File.Save("musicVolume", settings.musicVolume);
			eS3File.Save("sfxVolume", settings.sfxVolume);
			eS3File.Save("uiVolume", settings.uiVolume);
			eS3File.Save("ambienceVolume", settings.ambienceVolume);
			eS3File.Save("muteAudio", settings.muteAudio);
			eS3File.Save("voiceInputVolume", settings.voiceInputVolume);
			eS3File.Save("voiceOutputVolume", settings.voiceOutputVolume);
			eS3File.Save("voiceInputDevice", settings.voiceInputDevice);
			eS3File.Save("voiceChatEnabled", settings.voiceChatEnabled);
			eS3File.Save("voicePushToTalk", settings.voicePushToTalk);
			eS3File.Save("resolutionWidth", settings.currentResolution.width);
			eS3File.Save("resolutionHeight", settings.currentResolution.height);
			eS3File.Save("resolutionRefreshRate", settings.currentResolution.refreshRate);
			eS3File.Save("fullscreenMode", (int)settings.fullscreenMode);
			eS3File.Save("targetDisplay", settings.targetDisplay);
			eS3File.Save("vignette", settings.vignette);
			eS3File.Save("depthOfField", settings.depthOfField);
			eS3File.Save("motionBlur", settings.motionBlur);
			eS3File.Save("chromaticAberration", settings.chromaticAberration);
			eS3File.Save("filmGrain", settings.filmGrain);
			eS3File.Save("ambientOcclusion", settings.ambientOcclusion);
			eS3File.Save("aaMode", settings.aaMode);
			eS3File.Save("aaQuality", settings.aaQuality);
			eS3File.Save("msaa", settings.msaa);
			eS3File.Save("renderScale", settings.renderScale);
			eS3File.Save("vSync", settings.vSync);
			eS3File.Save("targetFrameRate", settings.targetFrameRate);
			eS3File.Save("resolutionIndex", settings.resolutionIndex);
			eS3File.Save("textureQuality", (int)settings.textureQuality);
			eS3File.Save("anisotropic", (int)settings.anisotropic);
			eS3File.Save("qualityPreset", settings.qualityPreset);
			eS3File.Sync();
		}
	}

	public void LoadSettingsData(SettingsData settings)
	{
		if (!string.IsNullOrEmpty(settingsFilePath) && ES3.FileExists(settingsFilePath))
		{
			ES3File eS3File = new ES3File(settingsFilePath);
			settings.languageCode = eS3File.Load("languageCode", settings.languageCode);
			settings.mouseSensitivity = eS3File.Load("mouseSensitivity", settings.mouseSensitivity);
			settings.invertMouse = eS3File.Load("invertMouse", settings.invertMouse);
			settings.showTutorial = eS3File.Load("showTutorial", settings.showTutorial);
			settings.showPlayerNames = eS3File.Load("showPlayerNames", settings.showPlayerNames);
			settings.showCompass = eS3File.Load("showCompass", settings.showCompass);
			settings.masterVolume = eS3File.Load("masterVolume", settings.masterVolume);
			settings.musicVolume = eS3File.Load("musicVolume", settings.musicVolume);
			settings.sfxVolume = eS3File.Load("sfxVolume", settings.sfxVolume);
			settings.uiVolume = eS3File.Load("uiVolume", settings.uiVolume);
			settings.ambienceVolume = eS3File.Load("ambienceVolume", settings.ambienceVolume);
			settings.muteAudio = eS3File.Load("muteAudio", settings.muteAudio);
			settings.voiceInputVolume = eS3File.Load("voiceInputVolume", settings.voiceInputVolume);
			settings.voiceOutputVolume = eS3File.Load("voiceOutputVolume", settings.voiceOutputVolume);
			settings.voiceInputDevice = eS3File.Load("voiceInputDevice", settings.voiceInputDevice);
			settings.voiceChatEnabled = eS3File.Load("voiceChatEnabled", settings.voiceChatEnabled);
			settings.voicePushToTalk = eS3File.Load("voicePushToTalk", settings.voicePushToTalk);
			int width = eS3File.Load("resolutionWidth", settings.currentResolution.width);
			int height = eS3File.Load("resolutionHeight", settings.currentResolution.height);
			int refreshRate = eS3File.Load("resolutionRefreshRate", settings.currentResolution.refreshRate);
			settings.currentResolution = new Resolution
			{
				width = width,
				height = height,
				refreshRate = refreshRate
			};
			settings.fullscreenMode = (FullScreenMode)eS3File.Load("fullscreenMode", (int)settings.fullscreenMode);
			settings.targetDisplay = eS3File.Load("targetDisplay", settings.targetDisplay);
			settings.vignette = eS3File.Load("vignette", settings.vignette);
			settings.depthOfField = eS3File.Load("depthOfField", settings.depthOfField);
			settings.motionBlur = eS3File.Load("motionBlur", settings.motionBlur);
			settings.chromaticAberration = eS3File.Load("chromaticAberration", settings.chromaticAberration);
			settings.filmGrain = eS3File.Load("filmGrain", settings.filmGrain);
			settings.ambientOcclusion = eS3File.Load("ambientOcclusion", settings.ambientOcclusion);
			settings.aaMode = eS3File.Load("aaMode", settings.aaMode);
			settings.aaQuality = eS3File.Load("aaQuality", settings.aaQuality);
			settings.msaa = eS3File.Load("msaa", settings.msaa);
			settings.renderScale = eS3File.Load("renderScale", settings.renderScale);
			settings.vSync = eS3File.Load("vSync", settings.vSync);
			settings.targetFrameRate = eS3File.Load("targetFrameRate", settings.targetFrameRate);
			settings.resolutionIndex = eS3File.Load("resolutionIndex", settings.resolutionIndex);
			settings.textureQuality = (SettingsData.TextureOption)eS3File.Load("textureQuality", (int)settings.textureQuality);
			settings.anisotropic = (SettingsData.AnisotropicOption)eS3File.Load("anisotropic", (int)settings.anisotropic);
			settings.qualityPreset = eS3File.Load("qualityPreset", settings.qualityPreset);
		}
	}
}
