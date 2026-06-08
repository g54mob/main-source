using System.Collections.Generic;

public interface ISettingFile
{
	void BeginBatchEdit();

	void EndBatchEdit();

	void Erase();

	void RemoveGroupSettings(string groupKey);

	void RemoveSetting(string groupKey, string key);

	void RemoveSetting(string key);

	void RemoveSettings(string groupKey, string keyBase);

	bool GroupExists(string groupKey);

	void SaveSetting(string groupKey, string key, string settingValue);

	void SaveSetting(string key, string settingValue);

	List<KeyValuePair<string, string>> GetGroupData(string groupKey);

	string GetGroupWithSettings<T>(string groupKeyBase, string key, T matchingValue);

	List<string> GetGroupsWithSettings<T>(string groupKeyBase, string key, T matchingValue);

	List<string> GetGroupsByName(string groupKeyBase);

	List<KeyValuePair<string, T>> GetSettings<T>(string groupKey, string keyBase, T matchingValue);

	T GetSetting<T>(string groupKey, string key, T DefaultValue);

	T GetSetting<T>(string key, T DefaultValue);
}
