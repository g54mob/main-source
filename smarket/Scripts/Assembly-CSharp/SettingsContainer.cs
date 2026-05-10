public class SettingsContainer
{
	public SettingEntry<int> Language;

	public SettingEntry<float> MouseSensitivity;

	public SettingEntry<float> RotateSensitivity;

	public SettingEntry<bool> InvertYAxis;

	public SettingEntry<bool> InvertXAxis;

	public SettingEntry<bool> RunInBackground;

	public SettingEntry<bool> EnableShoplifters;

	public SettingEntry<int> CrosshairIndex;

	public SettingEntry<float> CrosshairScale;

	public SettingEntry<string> CrosshairColorHex;

	public SettingEntry<int> Quality;

	public SettingEntry<string> Resolution;

	public SettingEntry<bool> FullScreen;

	public SettingEntry<int> FOV;

	public SettingEntry<bool> VSync;

	public SettingEntry<bool> IsCustomSelected;

	public SettingEntry<int> AntiAliasing;

	public SettingEntry<float> MasterVolume;

	public SettingEntry<float> MusicVolume;

	public SettingEntry<float> SFXVolume;

	public SettingEntry<int> TargetFrameRateIndex;

	public SettingEntry<int> QualityBeforeCustomized;

	public SettingEntry<int> TextureQuality;

	public SettingEntry<int> ShadowQuality;

	public SettingEntry<int> UpscalingFilter;

	public SettingEntry<bool> HDR;

	public SettingEntry<bool> PostProcessing;

	public SettingsData Data => default(SettingsData);

	public SettingsContainer(SettingsData data)
	{
	}

	public void LoadFrom(SettingsData data)
	{
	}
}
