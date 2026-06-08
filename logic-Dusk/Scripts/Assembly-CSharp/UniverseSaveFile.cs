using System;
using System.Collections.Generic;
using System.IO;

public class UniverseSaveFile : SettingsFile
{
	private static UniverseSaveFile _settingFileInstance;

	private static string dataPath = string.Empty;

	public static string CurrentUniversePath
	{
		get
		{
			return Path.GetFileName(dataPath);
		}
	}

	public static void BeginBatch()
	{
		_settingFileInstance.BeginBatchEdit();
	}

	public static void EndBatch()
	{
		_settingFileInstance.EndBatchEdit();
	}

	public static void DeleteAllSupportingDataFiles(bool deleteTextureData)
	{
		if (!Directory.Exists(dataPath))
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			string[] array = null;
			switch (i)
			{
			case 0:
				array = Directory.GetFiles(dataPath, string.Format("gd_*.txt", "~sd_"), SearchOption.TopDirectoryOnly);
				break;
			case 1:
				array = Directory.GetFiles(dataPath, string.Format("*.png", "~sd_"), SearchOption.TopDirectoryOnly);
				break;
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (deleteTextureData && text.EndsWith(".txt"))
				{
					string[] array3 = text.Split('_');
					string[] array4 = array3[1].Split('.');
					int result = 0;
					if (int.TryParse(array4[0], out result))
					{
						GalaxySaveFile.InitSetting(result);
						string path = Path.Combine(GameFileHelper.GetDataGalaxyLocation(), GalaxySaveFile.Get("DATA", string.Empty));
						if (Directory.Exists(path))
						{
							string[] files = Directory.GetFiles(path, "_d*.png");
							if (files.Length > 0)
							{
								string[] array5 = files;
								foreach (string path2 in array5)
								{
									File.Delete(path2);
								}
							}
						}
					}
				}
				File.Delete(text);
			}
		}
	}

	public static void DeleteAllClones()
	{
		if (Directory.Exists(dataPath))
		{
			string[] files = Directory.GetFiles(dataPath, string.Format("{0}*.txt", "~sd_"), SearchOption.TopDirectoryOnly);
			string[] array = files;
			foreach (string path in array)
			{
				File.Delete(path);
			}
		}
	}

	public static string CloneFile()
	{
		if (GlobalSettings.IsTutorial)
		{
			return string.Empty;
		}
		InitSetting();
		string text = Path.Combine(dataPath, string.Format("{0}{1}.txt", "~sd_", DateTime.Now.ToString("yyyddMM_hhmmss")));
		CloneFile(text);
		string[] files = Directory.GetFiles(dataPath, string.Format("{0}*.txt", "~sd_"), SearchOption.TopDirectoryOnly);
		string[] array = files;
		foreach (string text2 in array)
		{
			if (text2.ToLower() != text.ToLower())
			{
				File.Delete(text2);
			}
		}
		return text;
	}

	public static void CloneFile(string destFileName)
	{
		_settingFileInstance.Clone(destFileName);
	}

	public static void EraseFile()
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.Erase();
		}
	}

	public static void Clear(string groupKey, string key)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.ClearValue(groupKey, key);
		}
	}

	public static void ClearGroup(string groupKey, string parentKey)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			if (Get(groupKey, "P", string.Empty) == parentKey)
			{
				_settingFileInstance.ClearGroupValues(groupKey);
			}
		}
	}

	public static void ClearGroup(string groupKey)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.ClearGroupValues(groupKey);
		}
	}

	public static void ClearGroupAndChildren(string groupKeyBase)
	{
		if (GlobalSettings.IsTutorial)
		{
			return;
		}
		List<string> allGroups = GetAllGroups(groupKeyBase);
		foreach (string item in allGroups)
		{
			List<string> allGroups2 = GetAllGroups(string.Empty, "P", item);
			foreach (string item2 in allGroups2)
			{
				ClearGroup(item2);
			}
			ClearGroup(item);
		}
	}

	public static void Clear(string key)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.ClearValue(key);
		}
	}

	public static void ClearAll(string groupKey, string keyBase)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.ClearAllValues(groupKey, keyBase);
		}
	}

	public static bool Exists(string groupKey)
	{
		if (GlobalSettings.IsTutorial)
		{
			return false;
		}
		InitSetting();
		return _settingFileInstance.GroupExists(groupKey);
	}

	public static void Add(string key, string value)
	{
		_settingFileInstance.AddSetting(key, value);
	}

	public static void Add(string groupKey, string key, string value)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.AddSetting(groupKey, key, value);
		}
	}

	public static void Save<T>(string groupKey, string parentKey, string key, T value)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			Save(groupKey, "P", parentKey);
			_settingFileInstance.SaveValue(groupKey, key, value);
		}
	}

	public static void Save<T>(string groupKey, string key, T value)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.SaveValue(groupKey, key, value);
		}
	}

	public static void Save<T>(string key, T value)
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.SaveValue(key, value);
		}
	}

	public static string FindGroup<T>(string groupKeyBase, string key, T matchingValue)
	{
		if (GlobalSettings.IsTutorial)
		{
			return null;
		}
		InitSetting();
		return _settingFileInstance.GetGroup(groupKeyBase, key, matchingValue);
	}

	public static List<KeyValuePair<string, string>> GetGroupDataItems(string groupKey)
	{
		if (GlobalSettings.IsTutorial)
		{
			return null;
		}
		InitSetting();
		return _settingFileInstance.GetGroupData(groupKey);
	}

	public static List<string> GetAllGroups(string groupKeyBase)
	{
		return GetAllGroups(groupKeyBase, string.Empty, string.Empty);
	}

	public static List<string> GetAllGroups<T>(string groupKeyBase, string key, T matchingValue)
	{
		if (GlobalSettings.IsTutorial)
		{
			return null;
		}
		InitSetting();
		return _settingFileInstance.GetGroups(groupKeyBase, key, matchingValue);
	}

	public static List<KeyValuePair<string, T>> GetAll<T>(string groupKey, T matchingValue)
	{
		return GetAll(groupKey, string.Empty, matchingValue);
	}

	public static List<KeyValuePair<string, T>> GetAll<T>(string groupKey, string keyBase)
	{
		return GetAll(groupKey, keyBase, default(T));
	}

	public static List<KeyValuePair<string, T>> GetAll<T>(string groupKey, string keyBase, T matchingValue)
	{
		if (GlobalSettings.IsTutorial)
		{
			return null;
		}
		InitSetting();
		return _settingFileInstance.GetAllValues(groupKey, keyBase, matchingValue);
	}

	public static T Get<T>(string groupKey, string key)
	{
		if (GlobalSettings.IsTutorial)
		{
			return default(T);
		}
		InitSetting();
		return _settingFileInstance.GetValue<T>(groupKey, key);
	}

	public static T Get<T>(string groupKey, string key, T DefaultValue)
	{
		if (GlobalSettings.IsTutorial)
		{
			return default(T);
		}
		InitSetting();
		return _settingFileInstance.GetValue(groupKey, key, DefaultValue);
	}

	public static T Get<T>(string key)
	{
		if (GlobalSettings.IsTutorial)
		{
			return default(T);
		}
		return Get(key, default(T));
	}

	public static T Get<T>(string key, T DefaultValue)
	{
		if (GlobalSettings.IsTutorial)
		{
			return DefaultValue;
		}
		InitSetting();
		return _settingFileInstance.GetValue(key, DefaultValue);
	}

	public static string GetLastSetting(string key)
	{
		if (GlobalSettings.IsTutorial)
		{
			return string.Empty;
		}
		InitSetting();
		string value = _settingFileInstance.GetValue(key, string.Empty);
		string[] array = value.Split(',');
		return array[array.Length - 1];
	}

	public static void Reset()
	{
		_settingFileInstance = null;
		InitSetting();
	}

	public static void ReInitSetting()
	{
		_settingFileInstance = null;
		InitSetting();
	}

	protected static void InitSetting()
	{
		if (!GlobalSettings.IsTutorial && _settingFileInstance == null)
		{
			string path = GameSaveFile.Get("UNIVERSE_ID", "DEFAULT");
			dataPath = Path.Combine(GameFileHelper.GetDataUniverseLocation(), path);
			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			string gameSaveFilename = Path.Combine(dataPath, "universedata.txt");
			_settingFileInstance = new UniverseSaveFile();
			_settingFileInstance.LoadSettingFile(gameSaveFilename);
		}
	}
}
