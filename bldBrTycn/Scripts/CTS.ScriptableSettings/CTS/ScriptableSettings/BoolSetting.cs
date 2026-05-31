using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Bool Prefs Setting")]
	public class BoolSetting : PlayerPrefSetting<bool>
	{
		protected override bool GetValueFromDisk()
		{
			return PlayerPrefs.GetInt(_prefKey, BoolToInt(_defaultValue)) != 0;
		}

		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetInt(_prefKey, BoolToInt(_currentValue));
		}

		private static int BoolToInt(bool value)
		{
			if (value)
			{
				return 1;
			}
			return 0;
		}
	}
}
