using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Save Profile Setting")]
	public class ProfileSetting : SettingObject<string>
	{
		private static ES3Settings _saveSettings;

		private static ES3Settings GetSaveSettings()
		{
			object obj = _saveSettings;
			if (obj == null)
			{
				obj = new ES3Settings
				{
					location = ES3.Location.File,
					directory = ES3.Directory.PersistentDataPath,
					path = "Saves/CurrentProfile.sav"
				};
				_saveSettings = (ES3Settings)obj;
			}
			return (ES3Settings)obj;
		}

		protected override void OnSaveCurrentValueToDisk()
		{
			if (_currentValue == null)
			{
				ES3.DeleteFile(GetSaveSettings());
			}
			ES3.Save("CurrentProfile", _currentValue, GetSaveSettings());
		}

		protected override string GetValueFromDisk()
		{
			if (!ES3.FileExists(GetSaveSettings()))
			{
				return null;
			}
			return ES3.Load<string>("CurrentProfile", GetSaveSettings());
		}
	}
}
