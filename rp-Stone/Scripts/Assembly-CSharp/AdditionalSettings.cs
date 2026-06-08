using System;
using UnityEngine;

public class AdditionalSettings
{
	public static bool isPlayerNameSet
	{
		get
		{
			return PlayerPrefs.GetInt("settings_player_name_is_set", 0) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("settings_player_name_is_set", value ? 1 : 0);
		}
	}

	[Obsolete("Use HeroSettings.name instead")]
	public static string playerName
	{
		get
		{
			return PlayerPrefs.GetString("settings_player_name", "simple one");
		}
		set
		{
			PlayerPrefs.SetString("settings_player_name", value);
			isPlayerNameSet = true;
		}
	}

	public static string selectedLanguage
	{
		get
		{
			return PlayerPrefs.GetString("settings_language", "");
		}
		set
		{
			PlayerPrefs.SetString("settings_language", value);
		}
	}

	public static bool isAntiAlias
	{
		get
		{
			return PlayerPrefs.GetInt("settings_anti_alias", 1) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("settings_anti_alias", value ? 1 : 0);
		}
	}

	public static bool isScreenFlash
	{
		get
		{
			return PlayerPrefs.GetInt("settings_screen_flash", 1) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("settings_screen_flash", value ? 1 : 0);
		}
	}

	public static bool isCameraShake
	{
		get
		{
			return PlayerPrefs.GetInt("settings_camera_shake", 1) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("settings_camera_shake", value ? 1 : 0);
		}
	}

	public static bool isBackgroundSfx
	{
		get
		{
			return PlayerPrefs.GetInt("settings_bg_sfx", 1) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("settings_bg_sfx", value ? 1 : 0);
		}
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}
}
