using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
	public static string MASTER_VOLUME = "MASTER_VOLUME_KEY";

	public static string SFX_VOLUME = "SFX_VOLUME_KEY";

	public static string MUSIC_VOLUME = "MUSIC_VOLUME_KEY";

	public static string MESSAGE_VOLUME = "MESSAGE_VOLUME_KEY";

	public static string CURRENT_WALLPAPER = "CURRENT_WALLPAPER";

	public static string IS_ASSISTANT_DISABLED = "IS_ASSISTANT_DISABLED";

	public static string NOTEPAD_COLOR = "NOTEPAD_COLOR";

	public static string CRT_ENABLEMENT = "CRT_ENABLEMENT";

	public static string CRT_CA_INDEX = "CRT_CA_INDEX";

	public static string CRT_SL_INDEX = "CRT_SL_INDEX";

	public static float? GetVolume(string key)
	{
		if (!PlayerPrefs.HasKey(key))
		{
			return null;
		}
		return PlayerPrefs.GetFloat(key);
	}

	public static Settings.Wallpaper GetSavedWallpaper()
	{
		if (!PlayerPrefs.HasKey(CURRENT_WALLPAPER))
		{
			return Settings.Wallpaper.DEFAULT;
		}
		return (Settings.Wallpaper)PlayerPrefs.GetInt(CURRENT_WALLPAPER);
	}

	public static bool GetBool(string key, bool defaultValue = false)
	{
		if (!PlayerPrefs.HasKey(key))
		{
			return defaultValue;
		}
		return PlayerPrefs.GetInt(key) == 1;
	}

	public static void SetBool(string key, bool value)
	{
		Debug.Log($"Setting {key} to {value}");
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}
}
