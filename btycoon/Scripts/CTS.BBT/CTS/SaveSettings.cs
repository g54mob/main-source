namespace CTS
{
	public static class SaveSettings
	{
		private static readonly ES3Settings LocalSave = new ES3Settings
		{
			location = ES3.Location.File,
			directory = ES3.Directory.DataPath,
			path = "Resources/Saves/"
		};

		private static readonly ES3Settings LocalLoad = new ES3Settings
		{
			location = ES3.Location.Resources,
			path = "Saves/"
		};

		private static ES3Settings _globalSaveAndLoad = new ES3Settings
		{
			location = ES3.Location.File,
			directory = ES3.Directory.PersistentDataPath,
			path = "Saves/"
		};

		public static readonly ES3Settings Cache = new ES3Settings
		{
			location = ES3.Location.Cache
		};

		public static ES3Settings GetGlobalFolderSettings()
		{
			if (_globalSaveAndLoad == null)
			{
				_globalSaveAndLoad = new ES3Settings();
			}
			_globalSaveAndLoad.location = ES3.Location.File;
			_globalSaveAndLoad.directory = ES3.Directory.PersistentDataPath;
			_globalSaveAndLoad.path = "Saves/";
			return _globalSaveAndLoad;
		}

		public static ES3Settings GetGlobalFolderSettings(string saveName)
		{
			if (_globalSaveAndLoad == null)
			{
				_globalSaveAndLoad = new ES3Settings();
			}
			_globalSaveAndLoad.location = ES3.Location.File;
			_globalSaveAndLoad.directory = ES3.Directory.PersistentDataPath;
			_globalSaveAndLoad.path = "Saves/" + saveName + ".sav";
			return _globalSaveAndLoad;
		}

		public static string GetFullSavePath(string saveName, ES3Settings settings)
		{
			return settings.path + saveName + ".sav";
		}
	}
}
