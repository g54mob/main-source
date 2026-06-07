using UnityEngine;

public class SettingSaveData
{
	public float BGMVolume;

	public float SFXVolume;

	public bool IsFullScreen;

	public int ResolutionScreenWidth;

	public int ResolutionScreenHeight;

	public string LanguageCode;

	public FullScreenMode FullScreenModeValue;

	public SettingSaveData(float bgmVolume, float sfxVolume, bool isFullScreen, int resolutionScreenWidth, int resolutionScreenHeight, string languageCode, FullScreenMode fullScreenModeValue)
	{
		BGMVolume = bgmVolume;
		SFXVolume = sfxVolume;
		IsFullScreen = isFullScreen;
		ResolutionScreenWidth = resolutionScreenWidth;
		ResolutionScreenHeight = resolutionScreenHeight;
		LanguageCode = languageCode;
		FullScreenModeValue = fullScreenModeValue;
	}
}
