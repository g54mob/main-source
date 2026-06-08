using System;
using System.Collections.Generic;
using System.IO;

public class GalaxySaveFile : SettingsFile
{
	private static GalaxySaveFile _settingFileInstance;

	private static string galaxyPath = string.Empty;

	public static int CurrentGalaxyID { get; private set; }

	public static void BeginBatch()
	{
		_settingFileInstance.BeginBatchEdit();
	}

	public static void EndBatch()
	{
		_settingFileInstance.EndBatchEdit();
	}

	public static List<string> GetListOfGalaxyFolders(bool includeEasyGalaxies)
	{
		List<string> list = new List<string>();
		List<string> list2 = null;
		if (!includeEasyGalaxies)
		{
			list2 = new List<string>();
			list2.Add("Galaxy 13_sm");
			list2.Add("Galaxy 13_sm_f");
			list2.Add("Galaxy14_sm");
			list2.Add("Galaxy14_sm_f");
			list2.Add("Galaxy 15_sm");
			list2.Add("Galaxy 15_sm_f");
			list2.Add("Galaxy 16_sm");
			list2.Add("Galaxy 16_sm_f");
		}
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		if (Directory.Exists(dataGalaxyLocation))
		{
			string[] directories = Directory.GetDirectories(dataGalaxyLocation, "*.*", SearchOption.TopDirectoryOnly);
			if (directories.Length > 0)
			{
				string[] array = directories;
				foreach (string text in array)
				{
					string[] files = Directory.GetFiles(text, "_mDM*", SearchOption.TopDirectoryOnly);
					if (files.Length > 0)
					{
						string directoryName = Path.GetDirectoryName(text);
						string item = text.Remove(0, directoryName.Length + 1);
						if (includeEasyGalaxies || !list2.Contains(item))
						{
							list.Add(item);
						}
					}
				}
			}
		}
		return list;
	}

	public static void DeleteAllClones()
	{
		if (Directory.Exists(galaxyPath))
		{
			string[] files = Directory.GetFiles(galaxyPath, string.Format("{0}*.txt", "~sd_"), SearchOption.TopDirectoryOnly);
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
		string text = Path.Combine(galaxyPath, string.Format("{0}{1}.txt", "~sd_", DateTime.Now.ToString("yyyddMM_hhmmss")));
		CloneFile(text);
		string[] files = Directory.GetFiles(galaxyPath, string.Format("{0}*.txt", "~sd_"), SearchOption.TopDirectoryOnly);
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
			galaxyPath = Path.Combine(GameFileHelper.GetDataUniverseLocation(), path);
			string gameSaveFilename = Path.Combine(galaxyPath, "galaxydata.txt");
			_settingFileInstance = new GalaxySaveFile();
			_settingFileInstance.LoadSettingFile(gameSaveFilename);
			CurrentGalaxyID = 0;
		}
	}

	public static void InitSetting(int galaxyID)
	{
		string text = GameSaveFile.Get<string>("UNIVERSE_ID");
		if (!string.IsNullOrEmpty(text))
		{
			galaxyPath = Path.Combine(GameFileHelper.GetDataUniverseLocation(), text);
			string gameSaveFilename = Path.Combine(galaxyPath, string.Format("gd_{0}.txt", galaxyID));
			_settingFileInstance = new GalaxySaveFile();
			_settingFileInstance.LoadSettingFile(gameSaveFilename);
		}
		CurrentGalaxyID = galaxyID;
	}

	public static void ClearGalaxySeed()
	{
		InitSetting();
		_settingFileInstance.RemoveSetting("GALAXY_SEED");
	}

	public static void SaveGalaxySeed(int seed)
	{
		_settingFileInstance.SaveSetting("GALAXY_SEED", seed.ToString());
	}

	public static int GetGalaxySeed(int originalSeed)
	{
		int result = originalSeed;
		string text = Get<string>("GALAXY_SEED");
		if (!string.IsNullOrEmpty(text))
		{
			int.TryParse(text, out result);
		}
		return result;
	}

	public static void SaveSystemSeed(string groupKey, int seed)
	{
		_settingFileInstance.SaveSetting(groupKey, "SEED", seed.ToString());
	}

	public static int GetSystemSeed(string groupKey, int originalSeed)
	{
		int result = originalSeed;
		string text = Get<string>(groupKey, "SEED");
		if (!string.IsNullOrEmpty(text))
		{
			int.TryParse(text, out result);
		}
		return result;
	}

	public static void ClearStarSystemPath()
	{
		if (!GlobalSettings.IsTutorial)
		{
			InitSetting();
			_settingFileInstance.RemoveSetting("VISITED_STAR_SYSTEMS");
		}
	}

	public static void AppendStarSystemToPath(int starSystemID)
	{
		_settingFileInstance.AddSetting("VISITED_STAR_SYSTEMS", starSystemID.ToString());
	}

	public static void StartStarSystemPath(int starSystemID)
	{
		_settingFileInstance.SaveSetting("VISITED_STAR_SYSTEMS", starSystemID.ToString());
	}

	public static int GetLastEntryStarSystemPath()
	{
		int result = -1;
		string text = Get<string>("VISITED_STAR_SYSTEMS");
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length > 0)
			{
				int.TryParse(array[array.Length - 1], out result);
			}
		}
		return result;
	}

	public static List<int> GetListStarSystemPath()
	{
		List<int> list = null;
		string text = Get<string>("VISITED_STAR_SYSTEMS");
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length > 0)
			{
				string[] array2 = array;
				foreach (string s in array2)
				{
					int result = -1;
					if (int.TryParse(s, out result))
					{
						if (list == null)
						{
							list = new List<int>();
						}
						list.Add(result);
					}
				}
			}
		}
		return list;
	}

	public static int GetStarSystemPathCount()
	{
		List<int> listStarSystemPath = GetListStarSystemPath();
		if (listStarSystemPath == null)
		{
			return 0;
		}
		return listStarSystemPath.Count;
	}
}
