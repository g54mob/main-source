using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
	[Serializable]
	public class GameSetting
	{
		public string identifier;

		public int intDefault;

		public int intValue;

		public string strDefault;

		public string strValue;

		public ToggleController toggle;

		public SliderController slider;

		public DropdownController dropdown;

		public DropdownController secondaryDropdown;

		public MultiSelectController multiselect;

		public TextMeshProUGUI valueDisplayText;

		public bool lateLoad;

		public bool useDropdownInt;

		[Space(7f)]
		public List<PlatformSpecificDefault> platformSpecificDefaults;

		public bool onlyDisplayInDevMode;

		public List<Game.BuildConfig> dontDisplayOnPlatforms;

		public int GetDefaultInt()
		{
			return 0;
		}

		public string GetDefaultStr()
		{
			return null;
		}
	}

	[Serializable]
	public class PlatformSpecificDefault
	{
		public bool lowEndHardware;

		[DisableIf("lowEndHardware")]
		public Game.BuildConfig platform;

		public int intDefault;

		public string strDefault;
	}

	public List<GameSetting> gameSettingControls;

	public bool playedBefore;

	public bool acceptedEULA;

	public bool loadedPlayerPrefs;

	public bool initialiseAsLowEndHardware;

	private static PlayerPrefsController _instance;

	public static PlayerPrefsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void LoadPlayerPrefs(bool lateLoad = false)
	{
	}

	public void ResetPlayerPrefsToDefaults()
	{
	}

	public int GetSettingInt(string id)
	{
		return 0;
	}

	public string GetSettingStr(string id)
	{
		return null;
	}

	public void OnToggleChanged(string id, bool fetchValueFromControls, MonoBehaviour elementScript = null)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetFirstPlay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetLowEndHardware()
	{
	}
}
