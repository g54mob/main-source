using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/String Prefs Setting")]
	public class StringSetting : PlayerPrefSetting<string>
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetString(_prefKey, _currentValue);
		}

		protected override string GetValueFromDisk()
		{
			return PlayerPrefs.GetString(_prefKey, _defaultValue);
		}
	}
}
