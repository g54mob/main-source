using UnityEngine.Localization.Settings;

public class SettingsSavefile : Savefile
{
	public bool IsVSyncEnabled;

	public bool IsMotionBlurEnabled;

	public bool IsFreeCameraEnabled;

	public bool IsBloomEnabled;

	public bool IsCameraShakeEnabled;

	public bool IsDataTrackingEnabled;

	public float VolumeMaster;

	public float VolumeMusic;

	public float VolumeSFX;

	public int ResolutionIndex;

	public int WindowModeIndex;

	public int ChosenLanguage;

	public int ChosenGameSpeed;

	public string P1Color;

	public string P2Color;

	public bool ShowRoofOnEmptyWagons;

	public bool ShowResourcePickupText;

	public bool ShowHullDamageText;

	public SettingsSavefile()
	{
		version = GameManager.Instance.Version;
		IsVSyncEnabled = true;
		IsMotionBlurEnabled = true;
		IsFreeCameraEnabled = true;
		IsBloomEnabled = true;
		IsCameraShakeEnabled = true;
		IsDataTrackingEnabled = false;
		VolumeMaster = 0.5f;
		VolumeMusic = 0.5f;
		VolumeSFX = 0.5f;
		ResolutionIndex = 11;
		WindowModeIndex = 0;
		for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
		{
			if (LocalizationSettings.AvailableLocales.Locales[i] == LocalizationSettings.SelectedLocale)
			{
				ChosenLanguage = i;
				break;
			}
			ChosenLanguage = 0;
		}
		ChosenGameSpeed = 2;
		ShowRoofOnEmptyWagons = false;
		P1Color = "#FF0000";
		P2Color = "#0000FF";
		ShowResourcePickupText = true;
		ShowHullDamageText = true;
	}
}
