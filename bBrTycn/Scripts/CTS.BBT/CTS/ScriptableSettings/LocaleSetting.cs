using UnityEngine;
using UnityEngine.Localization;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Locale Prefs Setting")]
	public class LocaleSetting : PlayerPrefSetting<LocaleIdentifier>
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetString(_prefKey, _currentValue.Code);
		}

		protected override LocaleIdentifier GetValueFromDisk()
		{
			if (string.IsNullOrEmpty(_defaultValue.Code))
			{
				return PlayerPrefs.GetString(_prefKey);
			}
			return PlayerPrefs.GetString(_prefKey, _defaultValue.Code);
		}
	}
}
