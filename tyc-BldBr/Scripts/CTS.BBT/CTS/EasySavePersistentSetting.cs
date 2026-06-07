using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public abstract class EasySavePersistentSetting<T> : SettingObject<T>
	{
		[SerializeField]
		protected string _savePath;

		[SerializeField]
		protected string _key;

		private static ES3Settings _settings;

		protected ES3Settings GetSaveSettings()
		{
			if (_settings == null)
			{
				_settings = new ES3Settings
				{
					location = ES3.Location.File,
					directory = ES3.Directory.PersistentDataPath
				};
			}
			_settings.path = "Saves/" + _savePath;
			return _settings;
		}
	}
}
