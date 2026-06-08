using System;
using System.Collections.Generic;

public class GameSaveFile : SettingsFile
{
	private static GameSaveFile _settingFileInstance;

	public static void BeginBatch()
	{
		_settingFileInstance.BeginBatchEdit();
	}

	public static void EndBatch()
	{
		_settingFileInstance.EndBatchEdit();
	}

	public static bool IsFileEmpty()
	{
		InitSetting();
		return _settingFileInstance.IsEmpty();
	}

	public static void EraseFile()
	{
		InitSetting();
		_settingFileInstance.Erase();
	}

	public static void Clear(string groupKey, string key)
	{
		InitSetting();
		_settingFileInstance.ClearValue(groupKey, key);
	}

	public static void ClearGroup(string groupKey, string parentKey)
	{
		InitSetting();
		if (Get(groupKey, "P", string.Empty) == parentKey)
		{
			_settingFileInstance.ClearGroupValues(groupKey);
		}
	}

	public static void ClearGroup(string groupKey)
	{
		InitSetting();
		_settingFileInstance.ClearGroupValues(groupKey);
	}

	public static void ClearGroupAndChildren(string groupKeyBase)
	{
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
		InitSetting();
		_settingFileInstance.ClearValue(key);
	}

	public static void ClearAll(string groupKey, string keyBase)
	{
		InitSetting();
		_settingFileInstance.ClearAllValues(groupKey, keyBase);
	}

	public static bool Exists(string groupKey)
	{
		InitSetting();
		return _settingFileInstance.GroupExists(groupKey);
	}

	public static void Add(string key, string value)
	{
		_settingFileInstance.AddSetting(key, value);
	}

	public static void Add(string groupKey, string key, string value)
	{
		InitSetting();
		_settingFileInstance.AddSetting(groupKey, key, value);
	}

	public static void Save<T>(string groupKey, string parentKey, string key, T value)
	{
		InitSetting();
		Save(groupKey, "P", parentKey);
		_settingFileInstance.SaveValue(groupKey, key, value);
	}

	public static void Save<T>(string groupKey, string key, T value)
	{
		InitSetting();
		_settingFileInstance.SaveValue(groupKey, key, value);
	}

	public static void Save<T>(string key, T value)
	{
		InitSetting();
		_settingFileInstance.SaveValue(key, value);
	}

	public static string FindGroup<T>(string groupKeyBase, string key, T matchingValue)
	{
		InitSetting();
		return _settingFileInstance.GetGroup(groupKeyBase, key, matchingValue);
	}

	public static List<KeyValuePair<string, string>> GetGroupDataItems(string groupKey)
	{
		InitSetting();
		return _settingFileInstance.GetGroupData(groupKey);
	}

	public static List<string> GetAllGroups(string groupKeyBase)
	{
		return GetAllGroups(groupKeyBase, string.Empty, string.Empty);
	}

	public static List<string> GetAllGroups<T>(string groupKeyBase, string key, T matchingValue)
	{
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
		InitSetting();
		return _settingFileInstance.GetAllValues(groupKey, keyBase, matchingValue);
	}

	public static T Get<T>(string groupKey, string key)
	{
		InitSetting();
		return _settingFileInstance.GetValue<T>(groupKey, key);
	}

	public static T Get<T>(string groupKey, string key, T DefaultValue)
	{
		InitSetting();
		return _settingFileInstance.GetValue(groupKey, key, DefaultValue);
	}

	public static T Get<T>(string key)
	{
		return Get(key, default(T));
	}

	public static T Get<T>(string key, T DefaultValue)
	{
		InitSetting();
		return _settingFileInstance.GetValue(key, DefaultValue);
	}

	public static T GetThatWorksInTutorial<T>(string key, T DefaultValue)
	{
		InitSetting();
		return _settingFileInstance.GetValue(key, DefaultValue);
	}

	public static void SaveDiscoveredUpgradesList(List<DroneUpgradeType> knownUpgrades)
	{
		List<string> stringList = new List<string>();
		knownUpgrades.ForEach(delegate(DroneUpgradeType x)
		{
			stringList.Add(x.ToString());
		});
		SaveStringList("DiscoveredUpgrades", stringList);
	}

	public static List<DroneUpgradeType> GetDiscoveredUpgradesList()
	{
		List<DroneUpgradeType> list = new List<DroneUpgradeType>();
		foreach (string item in ReadStringList("DiscoveredUpgrades"))
		{
			DroneUpgradeType enumFromString = CommonMethods.GetEnumFromString(item, DroneUpgradeType.Undefined);
			if (enumFromString != DroneUpgradeType.Undefined)
			{
				list.Add(enumFromString);
			}
		}
		return list;
	}

	public static void SaveDiscoveredUpgradesExploringList(List<DroneUpgradeType> knownUpgrades)
	{
		List<string> stringList = new List<string>();
		knownUpgrades.ForEach(delegate(DroneUpgradeType x)
		{
			stringList.Add(x.ToString());
		});
		SaveStringList("DiscoveredUpgradesExploring", stringList);
	}

	public static List<DroneUpgradeType> GetDiscoveredUpgradesExploringList()
	{
		List<DroneUpgradeType> list = new List<DroneUpgradeType>();
		foreach (string item in ReadStringList("DiscoveredUpgradesExploring"))
		{
			DroneUpgradeType enumFromString = CommonMethods.GetEnumFromString(item, DroneUpgradeType.Undefined);
			if (enumFromString != DroneUpgradeType.Undefined)
			{
				list.Add(enumFromString);
			}
		}
		return list;
	}

	public static void SaveStoryFilesReadList(List<string> storyFilesReadList)
	{
		SaveStringList("StoryFilesReadSoFar", storyFilesReadList);
	}

	public static List<string> GetStoryFilesReadList()
	{
		return ReadStringList("StoryFilesReadSoFar");
	}

	public static void SaveBestDaysSurvived(int daysSurvived)
	{
		InitSetting();
		_settingFileInstance.SaveSetting("BestDaysSurvived", daysSurvived.ToString());
	}

	public static int GetBestDaysSurvived()
	{
		InitSetting();
		string text = Get<string>("BestDaysSurvived");
		int result;
		if (!string.IsNullOrEmpty(text) && int.TryParse(text, out result))
		{
			return result;
		}
		return 0;
	}

	private static void SaveStringList(string key, List<string> allStrings)
	{
		string text = string.Empty;
		foreach (string allString in allStrings)
		{
			if (text != string.Empty)
			{
				text += ",";
			}
			text += allString;
		}
		InitSetting();
		_settingFileInstance.SaveSetting(key, text);
	}

	private static List<string> ReadStringList(string key)
	{
		InitSetting();
		List<string> list = new List<string>();
		string text = Get<string>(key);
		if (string.IsNullOrEmpty(text))
		{
			return list;
		}
		string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
		}
		return list;
	}

	public static void ReInitSetting()
	{
		_settingFileInstance = null;
		InitSetting();
	}

	public static void InitSetting()
	{
		if (_settingFileInstance == null)
		{
			_settingFileInstance = new GameSaveFile();
			_settingFileInstance.LoadSettingFile(GameFileHelper.GameSaveFullPath(GameModeEnum.Normal));
		}
	}

	public static void InitForWeeklyChallenge()
	{
		_settingFileInstance = new GameSaveFile();
		_settingFileInstance.LoadSettingFile(GameFileHelper.GameSaveFullPath(GameModeEnum.WeeklyChallenge));
	}

	public static void InitForDailyChallenge()
	{
		_settingFileInstance = new GameSaveFile();
		_settingFileInstance.LoadSettingFile(GameFileHelper.GameSaveFullPath(GameModeEnum.DailyChallenge));
	}
}
