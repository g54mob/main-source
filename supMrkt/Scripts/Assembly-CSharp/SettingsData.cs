using System;

[Serializable]
public struct SettingsData
{
	public int Language;

	public float MouseSensitivity;

	public float RotateSensitivity;

	public bool InvertYAxis;

	public bool InvertXAxis;

	public bool RunInBackground;

	public bool EnableShoplifters;

	public int CrosshairIndex;

	public float CrosshairScale;

	public string CrosshairColorHex;

	public int Quality;

	public string Resolution;

	public bool FullScreen;

	public int FOV;

	public bool VSync;

	public bool IsCustomSelected;

	public int AntiAliasing;

	public float MasterVolume;

	public float MusicVolume;

	public float SFXVolume;

	public int TargetFrameRateIndex;
}
