using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Preferences
{
	public const string LastLaunchedVersion = "LastLaunchedVersion";

	public const string PrefCollapseVersionDetails = "CollapseVersionDetails";

	public const string PrefVideoKeyFramerate = "PrefVideoKeyFramerate";

	public const string PrefVideoKeyWindowMode = "PrefVideoKeyWindowMode";

	public const string PrefVideoKeyResolution = "PrefVideoKeyResolution";

	private const string PrefVideoOptionFramerateUnlimited = "PrefVideoOptionFramerateUnlimited";

	private const string PrefVideoOptionFramerate5 = "PrefVideoOptionFramerate5";

	private const string PrefVideoOptionFramerate30 = "PrefVideoOptionFramerate30";

	private const string PrefVideoOptionFramerate45 = "PrefVideoOptionFramerate45";

	private const string PrefVideoOptionFramerate56 = "PrefVideoOptionFramerate56";

	private const string PrefVideoOptionFramerate59 = "PrefVideoOptionFramerate59";

	private const string PrefVideoOptionFramerate60 = "PrefVideoOptionFramerate60";

	private const string PrefVideoOptionFramerate70 = "PrefVideoOptionFramerate70";

	private const string PrefVideoOptionFramerate72 = "PrefVideoOptionFramerate72";

	private const string PrefVideoOptionFramerate75 = "PrefVideoOptionFramerate75";

	private const string PrefVideoOptionFramerate100 = "PrefVideoOptionFramerate100";

	private const string PrefVideoOptionFramerate120 = "PrefVideoOptionFramerate120";

	private const string PrefVideoOptionFramerate144 = "PrefVideoOptionFramerate144";

	private const string PrefVideoOptionFramerate200 = "PrefVideoOptionFramerate200";

	private const string PrefVideoOptionFramerate240 = "PrefVideoOptionFramerate240";

	private const string PrefVideoOptionFramerate300 = "PrefVideoOptionFramerate300";

	public const string PrefVideoOptionWindowModeWindowed = "PrefVideoOptionWindowModeWindowed";

	private const string PrefVideoOptionWindowModeWindowedBorderless = "PrefVideoOptionWindowModeWindowedBorderless";

	public const string PrefVideoOptionWindowModeFullscreenWindowed = "PrefVideoOptionWindowModeFullscreenWindowed";

	public const string PrefVideoOptionWindowModeFullscreenExclusive = "PrefVideoOptionWindowModeFullscreenExclusive";

	private const string PrefVideoOptionWindowModeMaximizedWindow = "PrefVideoOptionWindowModeMaximizedWindow";

	public const string PrefInterfaceKeyScaling = "PrefInterfaceKeyScaling";

	public const string PrefInterfaceKeyAutosave = "PrefInterfaceKeyAutosave";

	public const string PrefInterfaceKeyRunInBackground = "PrefInterfaceKeyRunInBackground";

	public const string PrefInterfaceOptionScalingAuto = "PrefInterfaceOptionScalingAuto";

	private const string PrefInterfaceOptionScaling0_50x = "0_50x";

	private const string PrefInterfaceOptionScaling0_75x = "0_75x";

	private const string PrefInterfaceOptionScaling1x = "1x";

	private const string PrefInterfaceOptionScaling1_25x = "1_25x";

	private const string PrefInterfaceOptionScaling1_50x = "1_50x";

	private const string PrefInterfaceOptionScaling1_75x = "1_75x";

	private const string PrefInterfaceOptionScaling2x = "2x";

	public const string PrefAudioMasterVolume = "PrefAudioMasterVolume";

	public const string PrefAudioMusicVolume = "PrefAudioMusicVolume";

	public const string PrefAudioAmbientSoundVolume = "PrefAudioAmbientSoundVolume";

	public const string PrefAudioInterfaceVolume = "PrefAudioInterfaceVolume";

	public const string PrefInterfaceEnableGamepad = "PrefInterfaceDisableGamepad";

	public const string PrefGenericOptionOn = "On";

	public const string PrefGenericOptionOff = "Off";

	public const string PrefGenericOptionLow = "Low";

	public const string PrefGenericOptionMed = "Medium";

	public const string PrefGenericOptionHigh = "High";

	public const string PrefGenericOptionUltra = "Ultra";

	public const string PrefInterfaceKeyLanguage = "PrefInterfaceKeyLanguage";

	public const string PrefInterfaceOptionAutosaveInterval1 = "1";

	public const string PrefInterfaceOptionAutosaveInterval3 = "3";

	public const string PrefInterfaceOptionAutosaveInterval5 = "5";

	public const string PrefInterfaceOptionAutosaveInterval10 = "10";

	public const string PrefInterfaceOptionAutosaveInterval15 = "15";

	public const string PrefInterfaceOptionAutosaveInterval20 = "20";

	public const string PrefInterfaceOptionAutosaveInterval30 = "30";

	public const string PrefInterfaceOptionAutosaveInterval40 = "40";

	public const string PrefInterfaceOptionAutosaveInterval50 = "50";

	public const string PrefInterfaceOptionAutosaveInterval60 = "60";

	public const string PrefInterfaceOptionLanguageDefaultEnglish = "en";

	public const string PrefInterfaceOptionLanguageFrench = "fr";

	public const string PrefInterfaceOptionLanguageTurkish = "tr";

	public const string PrefInterfaceOptionLanguageGerman = "de";

	public const string PrefInterfaceOptionLanguageItalian = "it";

	public const string PrefInterfaceOptionLanguageSpanish = "es";

	public const string PrefInterfaceOptionLanguageRussian = "ru";

	public const string PrefInterfaceOptionLanguageJapanese = "ja";

	public const string PrefInterfaceOptionLanguagePolish = "pl";

	public const string PrefInterfaceOptionLanguagePortugueseBrazilian = "pt-br";

	public const string PrefInterfaceOptionLanguagePortugueseEuropean = "pt";

	public const string PrefInterfaceOptionLanguageSimplifiedChinese = "zh-CN";

	public const string PrefInterfaceOptionLanguageTraditionalChinese = "zh-TW";

	public const string PrefInterfaceOptionLanguageDutch = "nl";

	public const string PrefInterfaceOptionLanguageSwedish = "sv";

	public const string PrefInterfaceOptionLanguageCzech = "cz";

	public const string PrefInterfaceOptionLanguageUkrainian = "uk";

	public static float masterVolume;

	public static float musicVolume;

	public static float ambientVolume;

	public static float interfaceVolume;

	public static float drawDistanceSetting;

	public static bool DisableMeshInstancing;

	public static int safeModeIndex;

	public static bool isSafeMode;

	public static bool shouldShowAdminPanel;

	public static bool disableInstancingFromHardware;

	public static bool showObjectLabels;

	public static bool useGlobalHotbars;

	public static bool secondaryActionDelete;

	public static bool enableGamepad;

	public static bool animateWorkers;

	public static Dictionary<EntityId, string> hotkeyOverrides;

	public static bool IsRunningInitialSetup;

	public static void Init()
	{
		hotkeyOverrides = new Dictionary<EntityId, string>();
	}

	public static List<string> VideoPreferenceKeys()
	{
		return new List<string> { "PrefVideoKeyWindowMode", "PrefVideoKeyResolution", "PrefVideoKeyFramerate" };
	}

	public static List<string> InterfacePreferenceKeys()
	{
		return new List<string> { "PrefInterfaceKeyLanguage", "PrefInterfaceKeyScaling", "PrefInterfaceKeyAutosave", "PrefInterfaceKeyRunInBackground" };
	}

	public static List<string> PreferenceOptionsForKey(string key)
	{
		switch (key)
		{
		case "PrefInterfaceKeyLanguage":
			return new List<string> { "en", "fr", "de", "it", "es", "ru", "ja", "pt-br", "zh-CN", "tr" };
		case "PrefVideoKeyFramerate":
			return new List<string>
			{
				"PrefVideoOptionFramerateUnlimited", "PrefVideoOptionFramerate30", "PrefVideoOptionFramerate45", "PrefVideoOptionFramerate56", "PrefVideoOptionFramerate59", "PrefVideoOptionFramerate60", "PrefVideoOptionFramerate70", "PrefVideoOptionFramerate72", "PrefVideoOptionFramerate75", "PrefVideoOptionFramerate100",
				"PrefVideoOptionFramerate120", "PrefVideoOptionFramerate144", "PrefVideoOptionFramerate200", "PrefVideoOptionFramerate240", "PrefVideoOptionFramerate300"
			};
		case "PrefVideoKeyWindowMode":
			return new List<string> { "PrefVideoOptionWindowModeWindowed", "PrefVideoOptionWindowModeFullscreenWindowed", "PrefVideoOptionWindowModeFullscreenExclusive" };
		case "PrefVideoKeyResolution":
		{
			List<string> list = new List<string>();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution res = resolutions[i];
				string item = StringForResolution(res);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
				Debug.Log("res " + res.ToString() + " = " + ResolutionForString(StringForResolution(res)).ToString());
			}
			return list;
		}
		case "PrefInterfaceKeyScaling":
			return new List<string> { "PrefInterfaceOptionScalingAuto", "0_50x", "0_75x", "1x", "1_25x", "1_50x", "1_75x", "2x" };
		case "PrefInterfaceKeyAutosave":
			return new List<string>
			{
				"Off", "1", "3", "5", "10", "15", "20", "30", "40", "50",
				"60"
			};
		default:
			return new List<string> { "Off", "On" };
		}
	}

	public static string StringValueForBool(bool enabled)
	{
		if (!enabled)
		{
			return "Off";
		}
		return "On";
	}

	public static string ValueForKey(string key)
	{
		return PlayerPrefs.GetString(key, DefaultForKey(key));
	}

	public static string DefaultForKey(string key)
	{
		return key switch
		{
			"PrefVideoKeyFramerate" => "PrefVideoOptionFramerate60", 
			"PrefInterfaceKeyScaling" => "PrefInterfaceOptionScalingAuto", 
			"PrefVideoKeyWindowMode" => "PrefVideoOptionWindowModeFullscreenExclusive", 
			"PrefVideoKeyResolution" => StringForResolution(Screen.currentResolution), 
			"PrefInterfaceKeyAutosave" => "5", 
			"PrefInterfaceDisableGamepad" => "On", 
			"PrefInterfaceKeyLanguage" => LocalizationManager.LanguageCode(Platform.Instance.GetUserLanguage()), 
			_ => "On", 
		};
	}

	public static string StringForResolution(Resolution res)
	{
		return res.width.ToString(CultureInfo.InvariantCulture) + " x " + res.height.ToString(CultureInfo.InvariantCulture);
	}

	public static Resolution ResolutionForString(string str)
	{
		Resolution currentResolution = Screen.currentResolution;
		int result = currentResolution.width;
		int result2 = currentResolution.height;
		int result3 = currentResolution.refreshRate;
		int num = str.IndexOf(" x ");
		if (num >= 0)
		{
			if (int.TryParse(str.Substring(0, num), out result))
			{
				currentResolution.width = result;
			}
			num += 3;
			int num2 = str.IndexOf(" @ ");
			if (num2 >= 0)
			{
				if (int.TryParse(str.Substring(num, num2 - num), out result2))
				{
					currentResolution.height = result2;
				}
			}
			else
			{
				int num3 = num;
				if (int.TryParse(str.Substring(num3, str.Length - num3), out result2))
				{
					currentResolution.height = result2;
				}
			}
			num2 += 3;
			int num4 = str.IndexOf("Hz");
			if (num4 >= 0 && int.TryParse(str.Substring(num2, num4 - num2), out result3))
			{
				currentResolution.refreshRate = result3;
			}
			return currentResolution;
		}
		Debug.LogError("Invalid resolution string supplied: " + str);
		return currentResolution;
	}

	public static void ApplyAll()
	{
		IsRunningInitialSetup = true;
		foreach (string item in VideoPreferenceKeys())
		{
			ApplyValueForKey(item, ValueForKey(item));
		}
		foreach (string item2 in InterfacePreferenceKeys())
		{
			ApplyValueForKey(item2, ValueForKey(item2));
		}
		ApplyValueForKey("PrefInterfaceDisableGamepad", ValueForKey("PrefInterfaceDisableGamepad"));
		Apply("PrefAudioMasterVolume");
		Apply("PrefAudioMusicVolume");
		Apply("PrefAudioAmbientSoundVolume");
		Apply("PrefAudioInterfaceVolume");
		ApplyResolutionAndWindow();
		IsRunningInitialSetup = false;
		LoadHotkeyOverrides();
	}

	public static void ApplyResolutionAndWindow()
	{
		Resolution resolution = ResolutionForString(ValueForKey("PrefVideoKeyResolution"));
		switch (ValueForKey("PrefVideoKeyWindowMode"))
		{
		case "PrefVideoOptionWindowModeFullscreenExclusive":
			Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.ExclusiveFullScreen);
			break;
		case "PrefVideoOptionWindowModeFullscreenWindowed":
			Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.MaximizedWindow);
			break;
		case "PrefVideoOptionWindowModeWindowed":
			Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
			break;
		case "PrefVideoOptionWindowModeMaximizedWindow":
			Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.MaximizedWindow);
			break;
		}
		ApplyFrameRate();
	}

	private static void ApplyFrameRate()
	{
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
	}

	private static void ApplyValueForKey(string key, string value)
	{
		MenuManager instance = MenuManager.Instance;
		switch (key)
		{
		case "PrefVideoKeyFramerate":
			ApplyFrameRate();
			break;
		case "PrefInterfaceKeyRunInBackground":
			Application.runInBackground = GetBoolValue(key);
			break;
		case "PrefInterfaceDisableGamepad":
			enableGamepad = GetBoolValue(key);
			break;
		case "PrefVideoKeyResolution":
			if (!IsRunningInitialSetup)
			{
				ApplyResolutionAndWindow();
			}
			break;
		case "PrefVideoKeyWindowMode":
			if (!IsRunningInitialSetup)
			{
				ApplyResolutionAndWindow();
			}
			break;
		case "PrefInterfaceKeyScaling":
			if (value == "PrefInterfaceOptionScalingAuto")
			{
				instance.canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
				instance.canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
				instance.canvasScaler.matchWidthOrHeight = 0.5f;
			}
			else
			{
				float scaleFactor = ScalingForVideoOption(value);
				instance.canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
				instance.canvasScaler.scaleFactor = scaleFactor;
			}
			break;
		case "PrefInterfaceKeyLanguage":
			LocalizationManager.Instance.LoadCurrentLanguage();
			TextDisplay.ClearLocalizationCache();
			TextDisplay.ReloadLabels();
			if (null != instance.videoPreferencesPanel && instance.videoPreferencesPanel.IsVisible())
			{
				instance.videoPreferencesPanel.isStale = true;
			}
			if (StartupManager.Instance.startupPhase == StartupPhase.Complete)
			{
				MenuManager.Instance.ReloadLabels();
			}
			StartupManager.DebugNumberPrinting();
			break;
		case "PrefInterfaceKeyAutosave":
		{
			int num = IntervalForAutosaveOption(value);
			TimeManager.timeSinceAutosave = 0f;
			TimeManager.autosaveIntervalSeconds = (float)num * 60f;
			break;
		}
		}
	}

	public static void SetBoolValue(string prefKey, bool value)
	{
		SetValueForKey(prefKey, value ? "On" : "Off");
	}

	public static bool GetBoolValue(string prefKey)
	{
		return ValueForKey(prefKey) == "On";
	}

	public static void SetValueForKey(string key, int value)
	{
		Debug.Log("Setting value " + value + " for key " + key);
		PlayerPrefs.SetInt(key, value);
		Apply(key);
	}

	public static void SetValueForKey(string key, string value)
	{
		Debug.Log("Setting value " + value + " for key " + key);
		PlayerPrefs.SetString(key, value);
		ApplyValueForKey(key, value);
	}

	public static void Apply(string key)
	{
		switch (key)
		{
		case "PrefAudioMasterVolume":
			masterVolume = (float)PlayerPrefs.GetInt(key, 85) * 0.01f;
			if (!IsRunningInitialSetup)
			{
				MusicPlayer.Instance.OnVolumePreferencesChanged();
			}
			break;
		case "PrefAudioMusicVolume":
			musicVolume = (float)PlayerPrefs.GetInt(key, 65) * 0.01f;
			if (!IsRunningInitialSetup)
			{
				MusicPlayer.Instance.OnVolumePreferencesChanged();
			}
			break;
		case "PrefAudioAmbientSoundVolume":
			ambientVolume = (float)PlayerPrefs.GetInt(key, 85) * 0.01f;
			break;
		case "PrefAudioInterfaceVolume":
			interfaceVolume = (float)PlayerPrefs.GetInt(key, 85) * 0.01f;
			break;
		}
	}

	public static int FrameRateFromOption(string value)
	{
		return value switch
		{
			"PrefVideoOptionFramerate5" => 5, 
			"PrefVideoOptionFramerate30" => 30, 
			"PrefVideoOptionFramerate45" => 45, 
			"PrefVideoOptionFramerate56" => 56, 
			"PrefVideoOptionFramerate59" => 59, 
			"PrefVideoOptionFramerate60" => 60, 
			"PrefVideoOptionFramerate70" => 70, 
			"PrefVideoOptionFramerate72" => 72, 
			"PrefVideoOptionFramerate75" => 75, 
			"PrefVideoOptionFramerate100" => 100, 
			"PrefVideoOptionFramerate120" => 120, 
			"PrefVideoOptionFramerate144" => 144, 
			"PrefVideoOptionFramerate200" => 200, 
			"PrefVideoOptionFramerate240" => 240, 
			"PrefVideoOptionFramerate300" => 300, 
			_ => -1, 
		};
	}

	public static void SetEnumPreference<T>(string key, T valueToStore)
	{
		PlayerPrefs.SetString(key, valueToStore.ToString());
	}

	public static bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public static T GetEnumPreference<T>(string key, T defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			string text = PlayerPrefs.GetString(key);
			if (Enum.IsDefined(typeof(T), text))
			{
				return (T)Enum.Parse(typeof(T), text);
			}
			Debug.LogWarning("Could not parse stored value " + text + " into type " + typeof(T));
			return defaultValue;
		}
		return defaultValue;
	}

	public static int IntervalForAutosaveOption(string autosaveOption)
	{
		return autosaveOption switch
		{
			"1" => 1, 
			"3" => 3, 
			"5" => 5, 
			"10" => 10, 
			"15" => 15, 
			"20" => 20, 
			"30" => 30, 
			"40" => 40, 
			"50" => 50, 
			"60" => 60, 
			_ => 0, 
		};
	}

	public static float ScalingForVideoOption(string scalingOption)
	{
		return scalingOption switch
		{
			"0_50x" => 0.5f, 
			"0_75x" => 0.75f, 
			"1_25x" => 1.25f, 
			"1_50x" => 1.5f, 
			"1_75x" => 1.75f, 
			"2x" => 2f, 
			_ => 1f, 
		};
	}

	private static void LoadHotkeyOverrides()
	{
	}

	private static void StoreHotkeyOverrides()
	{
	}

	public static void SetHotkey(EntityId id, string hotkey)
	{
		hotkeyOverrides[id] = hotkey;
		StoreHotkeyOverrides();
	}

	public static void ResetHotkey(EntityId id, string hotkey)
	{
		hotkeyOverrides.Remove(id);
		StoreHotkeyOverrides();
	}

	public static string GetHotkey(EntityId id)
	{
		if (hotkeyOverrides.TryGetValue(id, out var value))
		{
			return value;
		}
		if (LocalizationManager.Instance.defaultHotkeys.TryGetValue(id, out var value2))
		{
			return value2;
		}
		return string.Empty;
	}
}
