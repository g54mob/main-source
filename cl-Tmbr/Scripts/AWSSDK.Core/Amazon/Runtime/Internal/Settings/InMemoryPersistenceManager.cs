using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Settings
{
	public class InMemoryPersistenceManager : IPersistenceManager
	{
		private readonly Dictionary<string, SettingsCollection> _settingsDictionary = new Dictionary<string, SettingsCollection>();

		public SettingsCollection GetSettings(string type)
		{
			if (_settingsDictionary.ContainsKey(type))
			{
				return _settingsDictionary[type];
			}
			return new SettingsCollection();
		}

		public void SaveSettings(string type, SettingsCollection settings)
		{
			_settingsDictionary[type] = settings;
		}
	}
}
