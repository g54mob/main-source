using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class SettingsFile : ISettingFile
{
	private const char DELIMITER = '=';

	private IDictionary<string, string> _settings = new Dictionary<string, string>();

	private IDictionary<string, List<KeyValuePair<string, string>>> _settingsGroup;

	private readonly string[] DELIMITER_EOL = new string[1] { "\r\n" };

	private readonly char[] DELIMITER_EQUAL = new char[1] { '=' };

	private readonly char[] DELIMITER_PIPE = new char[1] { '|' };

	private readonly char[] DELIMITER_COLON = new char[1] { ':' };

	protected string sourceFile = string.Empty;

	private int batchStartCount;

	private StringBuilder sbSaveBuffer;

	public bool isBatch { get; private set; }

	public void BeginBatchEdit()
	{
		isBatch = true;
		batchStartCount++;
	}

	public void EndBatchEdit()
	{
		batchStartCount--;
		if (batchStartCount <= 0)
		{
			isBatch = false;
			batchStartCount = 0;
			Save();
		}
	}

	public List<KeyValuePair<string, string>> GetGroupData(string groupKey)
	{
		return GetSavedGroupData(groupKey);
	}

	public List<string> GetGroupsByName(string groupKeyBase)
	{
		return GetSavedGroupsByName(groupKeyBase);
	}

	public string GetGroupWithSettings<T>(string groupKeyBase, string key, T matchingValue)
	{
		return GetSavedGroupWithSetting(groupKeyBase, key, matchingValue);
	}

	public List<string> GetGroupsWithSettings<T>(string groupKeyBase, string key, T matchingValue)
	{
		return GetSavedGroupsWithSetting(groupKeyBase, key, matchingValue);
	}

	public List<KeyValuePair<string, T>> GetSettings<T>(string groupKey, string keyBase, T matchingValue)
	{
		return GetSavedSettings(groupKey, keyBase, matchingValue);
	}

	public T GetSetting<T>(string groupKey, string key, T DefaultValue)
	{
		return GetSavedSetting(groupKey, key, DefaultValue);
	}

	public T GetSetting<T>(string key, T DefaultValue)
	{
		return GetSavedSetting(key, DefaultValue);
	}

	public bool IsEmpty()
	{
		if (_settings != null && _settings.Count > 0)
		{
			return false;
		}
		if (_settingsGroup != null && _settingsGroup.Count > 0)
		{
			return false;
		}
		return true;
	}

	protected void AddSetting(string key, string settingValue)
	{
		string text = GetSetting(key, string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (!array[i].Equals(settingValue, StringComparison.CurrentCultureIgnoreCase))
				{
					continue;
				}
				if (i == num - 1)
				{
					return;
				}
				array[i] = string.Empty;
				text = string.Empty;
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ",";
						}
						text += text2;
					}
				}
				break;
			}
			text += string.Format(",{0}", settingValue);
			SaveSetting(key, text);
		}
		else
		{
			SaveSetting(key, settingValue);
		}
	}

	protected void AddSetting(string groupKey, string key, string settingValue)
	{
		string text = GetSetting(groupKey, key, string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (!array[i].Equals(settingValue, StringComparison.CurrentCultureIgnoreCase))
				{
					continue;
				}
				if (i == num - 1)
				{
					return;
				}
				array[i] = string.Empty;
				text = string.Empty;
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ",";
						}
						text += text2;
					}
				}
				break;
			}
			text += string.Format(",{0}", settingValue);
			SaveSetting(groupKey, key, text);
		}
		else
		{
			SaveSetting(groupKey, key, settingValue);
		}
	}

	public bool GroupExists(string groupKey)
	{
		if (_settingsGroup != null)
		{
			return _settingsGroup.ContainsKey(groupKey);
		}
		return false;
	}

	public void SaveSetting(string groupKey, string key, string settingValue)
	{
		SetSavedSetting(groupKey, key, settingValue);
		Save();
	}

	public void SaveSetting(string key, string settingValue)
	{
		SetSavedSetting(key, settingValue);
		Save();
	}

	public void Erase()
	{
		InternalClearDictionary();
		Save();
	}

	public void RemoveGroupSettings(string groupKey)
	{
		if (_settingsGroup != null && _settingsGroup.ContainsKey(groupKey))
		{
			_settingsGroup.Remove(groupKey);
			Save();
		}
	}

	public void RemoveSetting(string groupKey, string key)
	{
		if (_settingsGroup == null || !_settingsGroup.ContainsKey(groupKey))
		{
			return;
		}
		int count = _settingsGroup[groupKey].Count;
		for (int i = 0; i < count; i++)
		{
			if (_settingsGroup[groupKey][i].Key == key)
			{
				_settingsGroup[groupKey].RemoveAt(i);
				Save();
				break;
			}
		}
	}

	public void RemoveSetting(string key)
	{
		if (_settings.ContainsKey(key))
		{
			_settings.Remove(key);
			Save();
		}
	}

	public void RemoveSettings(string groupKey, string keyBase)
	{
		if (_settingsGroup == null || !_settingsGroup.ContainsKey(groupKey))
		{
			return;
		}
		int count = _settingsGroup[groupKey].Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (_settingsGroup[groupKey][num].Key.ToLower().StartsWith(keyBase.ToLower()))
			{
				_settingsGroup[groupKey].RemoveAt(num);
			}
		}
		Save();
	}

	public bool DoesValueExist(string groupKey, string valueKey)
	{
		if (_settingsGroup != null && _settingsGroup.ContainsKey(groupKey))
		{
			IEnumerator<KeyValuePair<string, string>> enumerator = _settingsGroup[groupKey].GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key == valueKey)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal void InternalClearDictionary()
	{
		_settings.Clear();
		if (_settingsGroup != null)
		{
			_settingsGroup.Clear();
			_settingsGroup = null;
		}
	}

	internal bool ValueExistsInDictionary(string key)
	{
		return _settings.ContainsKey(key);
	}

	protected void Save()
	{
		if (!isBatch)
		{
			SaveSettingFile(sourceFile);
		}
	}

	protected void Clone(string cloneFileName)
	{
		if (!isBatch)
		{
			SaveSettingFile(cloneFileName);
		}
	}

	protected bool LoadSettingFile(string gameSaveFilename)
	{
		bool flag = true;
		_settings.Clear();
		if (_settingsGroup != null)
		{
			_settingsGroup.Clear();
			_settingsGroup = null;
		}
		flag = ((!File.Exists(gameSaveFilename)) ? SaveSettingFile(gameSaveFilename) : ReadSettingFile(gameSaveFilename));
		sourceFile = gameSaveFilename;
		return flag;
	}

	private List<KeyValuePair<string, string>> GetSavedGroupData(string groupKey)
	{
		if (_settingsGroup != null && _settingsGroup.ContainsKey(groupKey))
		{
			return _settingsGroup[groupKey];
		}
		return null;
	}

	private string GetSavedGroupWithSetting<T>(string groupKeyBase, string key, T matchingValue)
	{
		if (_settingsGroup != null)
		{
			IEnumerator<KeyValuePair<string, List<KeyValuePair<string, string>>>> enumerator = _settingsGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key.Length >= groupKeyBase.Length && enumerator.Current.Key.StartsWith(groupKeyBase))
				{
					T setting = GetSetting(enumerator.Current.Key, key, default(T));
					if (setting != null && !setting.Equals(default(T)) && setting.Equals(matchingValue))
					{
						return enumerator.Current.Key;
					}
				}
			}
		}
		return string.Empty;
	}

	private List<string> GetSavedGroupsWithSetting<T>(string groupKeyBase, string key, T matchingValue)
	{
		List<string> list = new List<string>();
		if (_settingsGroup != null)
		{
			IEnumerator<KeyValuePair<string, List<KeyValuePair<string, string>>>> enumerator = _settingsGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string key2 = enumerator.Current.Key;
				if (!string.IsNullOrEmpty(groupKeyBase))
				{
					if (key2.Length < groupKeyBase.Length || key2[0] != groupKeyBase[0])
					{
						continue;
					}
					bool flag = true;
					int length = groupKeyBase.Length;
					for (int i = 1; i < length; i++)
					{
						if (key2[i] != groupKeyBase[i])
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					T setting = GetSetting(key2, key, default(T));
					try
					{
						if (!setting.Equals(default(T)) && setting.Equals(matchingValue))
						{
							list.Add(key2);
						}
					}
					catch (Exception)
					{
						int num = 0;
						num++;
					}
				}
				else
				{
					T setting2 = GetSetting(key2, key, default(T));
					if (setting2 != null && !setting2.Equals(default(T)) && setting2.Equals(matchingValue))
					{
						list.Add(key2);
					}
				}
			}
		}
		return list;
	}

	private List<string> GetSavedGroupsByName(string groupKeyBase)
	{
		List<string> list = new List<string>();
		if (_settingsGroup != null)
		{
			IEnumerator<KeyValuePair<string, List<KeyValuePair<string, string>>>> enumerator = _settingsGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key.Length >= groupKeyBase.Length && enumerator.Current.Key.StartsWith(groupKeyBase))
				{
					list.Add(enumerator.Current.Key);
				}
			}
		}
		return list;
	}

	private List<KeyValuePair<string, T>> GetSavedSettings<T>(string groupKey, string keyBase, T matchingValue)
	{
		List<KeyValuePair<string, T>> list = new List<KeyValuePair<string, T>>();
		if (_settingsGroup != null && _settingsGroup.ContainsKey(groupKey))
		{
			bool flag = matchingValue.Equals(default(T));
			int count = _settingsGroup[groupKey].Count;
			for (int i = 0; i < count; i++)
			{
				KeyValuePair<string, string> keyValuePair = _settingsGroup[groupKey][i];
				if (!string.IsNullOrEmpty(keyBase) && !keyValuePair.Key.StartsWith(keyBase))
				{
					continue;
				}
				try
				{
					if (flag || matchingValue.Equals(keyValuePair.Value))
					{
						list.Add(new KeyValuePair<string, T>(keyValuePair.Key, (T)Convert.ChangeType(keyValuePair.Value, typeof(T))));
					}
				}
				catch (FormatException)
				{
				}
				catch (Exception)
				{
				}
			}
		}
		return list;
	}

	private T GetSavedSetting<T>(string groupKey, string key, T DefaultValue)
	{
		T result = DefaultValue;
		if (_settingsGroup != null && _settingsGroup.ContainsKey(groupKey))
		{
			List<KeyValuePair<string, string>> list = _settingsGroup[groupKey];
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				KeyValuePair<string, string> keyValuePair = list[i];
				if (keyValuePair.Key == key)
				{
					try
					{
						result = (T)Convert.ChangeType(keyValuePair.Value, typeof(T));
					}
					catch (FormatException)
					{
						int num = 0;
						num++;
					}
					catch (Exception)
					{
					}
					break;
				}
			}
		}
		return result;
	}

	private T GetSavedSetting<T>(string key, T DefaultValue)
	{
		T result = DefaultValue;
		if (_settings.ContainsKey(key))
		{
			try
			{
				result = (T)Convert.ChangeType(_settings[key], typeof(T));
			}
			catch (Exception)
			{
				Debug.LogError("Could not convert stored value to requested type in SettingsFile.GetSavedSetting()");
				return default(T);
			}
		}
		return result;
	}

	private void SetSavedSetting(string key, string settingValue)
	{
		if (_settings.ContainsKey(key))
		{
			_settings[key] = settingValue;
		}
		else
		{
			_settings.Add(key, settingValue);
		}
	}

	private void SetSavedSetting(string groupKey, string key, string settingValue)
	{
		if (_settingsGroup == null)
		{
			_settingsGroup = new Dictionary<string, List<KeyValuePair<string, string>>>();
		}
		if (!_settingsGroup.ContainsKey(groupKey))
		{
			_settingsGroup.Add(groupKey, new List<KeyValuePair<string, string>>());
		}
		List<KeyValuePair<string, string>>.Enumerator enumerator = _settingsGroup[groupKey].GetEnumerator();
		int num = 0;
		bool flag = false;
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Key == key)
			{
				KeyValuePair<string, string> value = new KeyValuePair<string, string>(_settingsGroup[groupKey][num].Key, settingValue);
				_settingsGroup[groupKey][num] = value;
				flag = true;
				break;
			}
			num++;
		}
		if (!flag)
		{
			_settingsGroup[groupKey].Add(new KeyValuePair<string, string>(key, settingValue));
		}
	}

	private bool ReadSettingFile(string filename)
	{
		bool result = true;
		_settings.Clear();
		try
		{
			string text = File.ReadAllText(filename);
			string[] array = text.Split(DELIMITER_EOL, StringSplitOptions.None);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string text2 = array[i];
				if (text2.Length > 0 && text2[0] == '+')
				{
					if (_settingsGroup == null)
					{
						_settingsGroup = new Dictionary<string, List<KeyValuePair<string, string>>>();
					}
					string[] array2 = text2.Split(DELIMITER_PIPE, StringSplitOptions.RemoveEmptyEntries);
					if (array2 == null || array2.Length != 2)
					{
						continue;
					}
					string key = array2[0].Substring(1);
					string[] array3 = array2[1].Split(DELIMITER_COLON, StringSplitOptions.RemoveEmptyEntries);
					int num2 = array3.Length;
					for (int j = 0; j < num2; j++)
					{
						string text3 = array3[j];
						string[] array4 = text3.Split(DELIMITER_EQUAL, StringSplitOptions.RemoveEmptyEntries);
						if (array4 != null && array4.Length == 2)
						{
							if (!_settingsGroup.ContainsKey(key))
							{
								_settingsGroup.Add(key, new List<KeyValuePair<string, string>>());
							}
							_settingsGroup[key].Add(new KeyValuePair<string, string>(array4[0], array4[1]));
						}
					}
				}
				else if (text2.Contains('='.ToString()))
				{
					string[] array5 = text2.Split(DELIMITER_EQUAL, 2);
					if (array5 != null && array5.Length == 2)
					{
						_settings.Add(array5[0].Trim(), array5[1].Trim());
					}
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			Debug.LogWarning("Error reading setting file.  Message: " + ex.Message);
		}
		return result;
	}

	private bool SaveSettingFile(string filename)
	{
		bool result = true;
		try
		{
			if (sbSaveBuffer == null)
			{
				sbSaveBuffer = new StringBuilder(10000);
			}
			else
			{
				sbSaveBuffer.Remove(0, sbSaveBuffer.Length);
			}
			int count = _settings.Count;
			if (_settingsGroup != null)
			{
				count += _settingsGroup.Count;
			}
			int count2 = _settings.Count;
			foreach (KeyValuePair<string, string> setting in _settings)
			{
				sbSaveBuffer.AppendLine(setting.Key + '=' + setting.Value);
			}
			if (_settingsGroup != null && _settingsGroup.Count > 0)
			{
				IEnumerator<KeyValuePair<string, List<KeyValuePair<string, string>>>> enumerator2 = _settingsGroup.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					StringBuilder stringBuilder = new StringBuilder("+");
					stringBuilder.Append(enumerator2.Current.Key);
					stringBuilder.Append("|");
					bool flag = true;
					foreach (KeyValuePair<string, string> item in enumerator2.Current.Value)
					{
						if (!flag)
						{
							stringBuilder.Append(":");
						}
						stringBuilder.Append(item.Key);
						stringBuilder.Append("=");
						stringBuilder.Append(item.Value);
						flag = false;
					}
					string value = stringBuilder.ToString();
					sbSaveBuffer.AppendLine(value);
				}
			}
			File.WriteAllText(filename, sbSaveBuffer.ToString());
		}
		catch (Exception ex)
		{
			result = false;
			Debug.LogWarning("Error saving setting file.  Message: " + ex.Message);
		}
		return result;
	}

	private bool SaveSettingFileOld(string filename)
	{
		bool result = true;
		try
		{
			int num = _settings.Count;
			if (_settingsGroup != null)
			{
				num += _settingsGroup.Count;
			}
			string[] array = new string[num];
			int num2 = 0;
			int count = _settings.Count;
			for (int i = 0; i < count; i++)
			{
				KeyValuePair<string, string> keyValuePair = _settings.ElementAt(i);
				string text = string.Format("{0}{1}{2}", keyValuePair.Key, '=', keyValuePair.Value);
				array[num2++] = text;
			}
			if (_settingsGroup != null && _settingsGroup.Count > 0)
			{
				IEnumerator<KeyValuePair<string, List<KeyValuePair<string, string>>>> enumerator = _settingsGroup.GetEnumerator();
				while (enumerator.MoveNext())
				{
					StringBuilder stringBuilder = new StringBuilder("+");
					stringBuilder.Append(enumerator.Current.Key);
					stringBuilder.Append("|");
					bool flag = true;
					int count2 = enumerator.Current.Value.Count;
					for (int j = 0; j < count2; j++)
					{
						KeyValuePair<string, string> keyValuePair2 = enumerator.Current.Value.ElementAt(j);
						if (!flag)
						{
							stringBuilder.Append(":");
						}
						stringBuilder.Append(keyValuePair2.Key);
						stringBuilder.Append("=");
						stringBuilder.Append(keyValuePair2.Value);
						flag = false;
					}
					string text2 = stringBuilder.ToString();
					array[num2++] = text2;
				}
			}
			File.WriteAllLines(filename, array);
		}
		catch (Exception ex)
		{
			result = false;
			Debug.LogWarning("Error saving setting file.  Message: " + ex.Message);
		}
		return result;
	}
}
