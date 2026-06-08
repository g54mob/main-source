using System.Collections.Generic;
using System.IO;

public class DataFile : SettingsFile
{
	private static DataFile _settingFileInstance;

	private static string dataPath = string.Empty;

	public static void BeginBatch()
	{
		_settingFileInstance.BeginBatchEdit();
	}

	public static void EndBatch()
	{
		_settingFileInstance.EndBatchEdit();
	}

	public static void EraseFile()
	{
		_settingFileInstance.Erase();
	}

	public static void Clear(string groupKey, string key)
	{
		_settingFileInstance.ClearValue(groupKey, key);
	}

	public static void ClearGroup(string groupKey, string parentKey)
	{
		if (Get(groupKey, "P", string.Empty) == parentKey)
		{
			_settingFileInstance.ClearGroupValues(groupKey);
		}
	}

	public static void ClearGroup(string groupKey)
	{
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
		_settingFileInstance.ClearValue(key);
	}

	public static void ClearAll(string groupKey, string keyBase)
	{
		_settingFileInstance.ClearAllValues(groupKey, keyBase);
	}

	public static bool Exists(string groupKey)
	{
		return _settingFileInstance.GroupExists(groupKey);
	}

	public static void Add(string key, string value)
	{
		_settingFileInstance.AddSetting(key, value);
	}

	public static void Save<T>(string groupKey, string parentKey, string key, T value)
	{
		Save(groupKey, "P", parentKey);
		_settingFileInstance.SaveValue(groupKey, key, value);
	}

	public static void Save<T>(string groupKey, string key, T value)
	{
		_settingFileInstance.SaveValue(groupKey, key, value);
	}

	public static void Save<T>(string key, T value)
	{
		_settingFileInstance.SaveValue(key, value);
	}

	public static string FindGroup<T>(string groupKeyBase, string key, T matchingValue)
	{
		return _settingFileInstance.GetGroup(groupKeyBase, key, matchingValue);
	}

	public static List<KeyValuePair<string, string>> GetGroupDataItems(string groupKey)
	{
		return _settingFileInstance.GetGroupData(groupKey);
	}

	public static List<string> GetAllGroups(string groupKeyBase)
	{
		return GetAllGroups(groupKeyBase, string.Empty, string.Empty);
	}

	public static List<string> GetAllGroups<T>(string groupKeyBase, string key, T matchingValue)
	{
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
		return _settingFileInstance.GetAllValues(groupKey, keyBase, matchingValue);
	}

	public static T Get<T>(string groupKey, string key)
	{
		return _settingFileInstance.GetValue<T>(groupKey, key);
	}

	public static T Get<T>(string groupKey, string key, T DefaultValue)
	{
		return _settingFileInstance.GetValue(groupKey, key, DefaultValue);
	}

	public static T Get<T>(string key)
	{
		return Get(key, default(T));
	}

	public static T Get<T>(string key, T DefaultValue)
	{
		return _settingFileInstance.GetValue(key, DefaultValue);
	}

	public static void Reset()
	{
		_settingFileInstance = null;
	}

	public static void InitSetting(string dataPath, string fileName)
	{
		if (_settingFileInstance == null)
		{
			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			InitSetting(Path.Combine(dataPath, fileName));
		}
	}

	public static void InitSetting(string fullPath)
	{
		if (_settingFileInstance == null)
		{
			_settingFileInstance = new DataFile();
			_settingFileInstance.LoadSettingFile(fullPath);
		}
	}

	public static void Detach()
	{
		_settingFileInstance = null;
	}

	public void InitSettingInstance(string dataPath, string fileName)
	{
		if (!Directory.Exists(dataPath))
		{
			Directory.CreateDirectory(dataPath);
		}
		InitSettingInstance(Path.Combine(dataPath, fileName));
	}

	public void InitSettingInstance(string fullPath)
	{
		LoadSettingFile(fullPath);
	}
}
