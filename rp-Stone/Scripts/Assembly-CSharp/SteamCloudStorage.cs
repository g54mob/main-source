using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Steamworks;
using UnityEngine;

public class SteamCloudStorage : AStorage
{
	private Dictionary<string, object> _dataDictionary = new Dictionary<string, object>();

	private string LAST_STEAM_ID_KEY = "last_steam_id_for_saves";

	public override bool IsBusySaving()
	{
		return false;
	}

	public override void Save()
	{
		string primaryPath = GetPrimaryPath();
		string contents = ToJson();
		try
		{
			File.WriteAllText(primaryPath, contents);
			Utils.LogIfEditor("Saved file at: " + primaryPath);
			string backupPath = GetBackupPath();
			try
			{
				File.Copy(primaryPath, backupPath, overwrite: true);
			}
			catch (IOException ex)
			{
				GameplayActionMessages.SetMessage("\n Failed to backup save file.", Color.red, 8f);
				Utils.LogError("Failed to backup at: " + backupPath);
				Utils.LogError(ex.Message);
			}
		}
		catch (IOException ex2)
		{
			GameplayActionMessages.SetMessage("\n Failed to save file.", Color.red, 8f);
			Utils.LogError("Failed to save file at: " + primaryPath);
			Utils.LogError(ex2.Message);
			File.Delete(primaryPath);
		}
	}

	public override void Load()
	{
		string text = GetPrimaryPath();
		Utils.Log("Loading from primary path: " + text);
		if (!File.Exists(text))
		{
			string backupPath = GetBackupPath();
			if (!File.Exists(backupPath))
			{
				Utils.Log("No saved data found, creating new save file at " + GetPrimaryPath());
				File.Create(GetPrimaryPath());
				return;
			}
			GameplayActionMessages.SetMessage("\n Loading saves from backup.", Color.yellow, 5f);
			Utils.LogWarning("No save file at: " + text);
			Utils.LogWarning("Loading from backup: " + backupPath);
			text = backupPath;
		}
		string text2 = File.ReadAllText(text);
		FromJson(text2);
		if (_dataDictionary.Count == 0 && !text2.StartsWith("{"))
		{
			Utils.LogError("Error case where the save file probably got corrupted.");
			string backupPath2 = GetBackupPath();
			if (File.Exists(backupPath2))
			{
				GameplayActionMessages.SetMessage("\n Loading saves from backup.", Color.yellow, 5f);
				string text3 = File.ReadAllText(backupPath2);
				FromJson(text3);
				if (_dataDictionary.Count == 0 && !text3.StartsWith("{"))
				{
					Utils.LogError("The backup also seems to be corrupted.");
				}
			}
		}
		else
		{
			CreateHistoricalBackup(text2);
		}
	}

	public override void Clear()
	{
		_dataDictionary.Clear();
	}

	private void CreateHistoricalBackup(string json)
	{
		string text = ".txt.backup";
		int num = PlayerPrefs.GetInt("historical_backup_last_number", 0);
		string text2 = Path.Combine(GetStoragePath(), "historical_");
		if (num > 0 && PlayerPrefs.HasKey("historical_backup_date") && PlayerPrefs.HasKey("historical_backup_version") && PlayerPrefs.GetString("historical_backup_version") == Features.VERSION.ToString() && File.Exists(text2 + num + text))
		{
			int num2 = 1;
			if (num == 2)
			{
				num2 = 3;
			}
			if (num >= 3)
			{
				num2 = 7;
			}
			if (num >= 5)
			{
				num2 = 14;
			}
			DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString("historical_backup_date"), CultureInfo.InvariantCulture);
			if ((DateTime.Now - dateTime).TotalDays < (double)num2)
			{
				return;
			}
		}
		Utils.Log("Creating historical backup");
		num++;
		while (File.Exists(text2 + num + text))
		{
			num++;
		}
		text2 = text2 + num + text;
		try
		{
			File.WriteAllText(text2, json);
			PlayerPrefs.SetInt("historical_backup_last_number", num);
			PlayerPrefs.SetString("historical_backup_version", Features.VERSION.ToString());
			string value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
			PlayerPrefs.SetString("historical_backup_date", value);
			PlayerPrefs.Save();
		}
		catch (Exception ex)
		{
			GameplayActionMessages.SetMessage("\n Failed to make historical backup.", ColorConstants.orange, 8f);
			Utils.LogError("Failed to save file at: " + text2);
			Utils.LogError(ex.Message);
			File.Delete(text2);
		}
	}

	private string GetPrimaryPath()
	{
		return Path.Combine(GetStoragePath(), "primary_save.txt");
	}

	private string GetBackupPath()
	{
		return Path.Combine(GetStoragePath(), "backup.txt");
	}

	public override string GetStoragePath()
	{
		string text = null;
		if (SteamManager.Initialized)
		{
			text = SteamUser.GetSteamID().ToString();
		}
		else if (PlayerPrefs.HasKey(LAST_STEAM_ID_KEY))
		{
			text = PlayerPrefs.GetString(LAST_STEAM_ID_KEY);
			Utils.Log("Fall back to cached userId");
		}
		if (text == null)
		{
			Utils.Log("No Steam Id. Default path");
			return Application.persistentDataPath;
		}
		PlayerPrefs.SetString(LAST_STEAM_ID_KEY, text);
		string text2 = Path.Combine(Application.persistentDataPath, text);
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		return text2;
	}

	public static string GetOsxApplicationSupportDirectory()
	{
		string persistentDataPath = Application.persistentDataPath;
		if (!persistentDataPath.Contains("/Application Support/"))
		{
			return persistentDataPath;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(persistentDataPath);
		while (directoryInfo.Exists && directoryInfo.Name != "Application Support")
		{
			directoryInfo = Directory.GetParent(directoryInfo.FullName);
		}
		return directoryInfo.FullName;
	}

	private string ToJson()
	{
		SlimJson.BeginSerialization();
		int count = _dataDictionary.Count;
		List<string> list = new List<string>(count);
		List<string> list2 = new List<string>(count);
		List<string> list3 = new List<string>(count);
		foreach (KeyValuePair<string, object> item in _dataDictionary)
		{
			if (item.Value is string)
			{
				SlimJson.AddProperty(item.Key, (string)item.Value);
				list.Add(item.Key);
			}
			else if (item.Value is int)
			{
				SlimJson.AddProperty(item.Key, (int)item.Value);
				list2.Add(item.Key);
			}
			else if (item.Value is bool)
			{
				SlimJson.AddProperty(item.Key, (bool)item.Value);
				list3.Add(item.Key);
			}
			else
			{
				Utils.LogError("Unsuported type when serializing in SteamCloudStorage.ToJson(): " + item.Value);
			}
		}
		SlimJson.AddProperty("STRING_KEYS", list.ToArray());
		SlimJson.AddProperty("INT_KEYS", list2.ToArray());
		SlimJson.AddProperty("BOOL_KEYS", list3.ToArray());
		return SlimJson.EndSerialization();
	}

	private void FromJson(string sjson)
	{
		_dataDictionary.Clear();
		sjson = AStorage.UnplaceQuotes(sjson);
		string[] array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				int num = SlimJson.ParseInt(sjson, key);
				_dataDictionary.Add(key, num);
			}
		}
		bool flag = _dataDictionary.ContainsKey("save_file_last_id");
		int num2 = -1;
		array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string text in array)
			{
				string value = SlimJson.Parse(sjson, text);
				_dataDictionary.Add(text, value);
				if (!flag && text.StartsWith("save_file_"))
				{
					int num3 = Utils.ParseInt(text.Substring(10));
					if (num2 < num3)
					{
						num2 = num3;
					}
				}
			}
		}
		if (!flag)
		{
			_dataDictionary.Add("save_file_last_id", num2);
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				bool flag2 = SlimJson.ParseBool(sjson, key2);
				_dataDictionary.Add(key2, flag2);
			}
		}
	}

	public override bool HasKey(string key)
	{
		return _dataDictionary.ContainsKey(key);
	}

	public override void DeleteKey(string key)
	{
		if (_dataDictionary.ContainsKey(key))
		{
			_dataDictionary.Remove(key);
		}
	}

	public override string GetString(string key, string defaultValue = "")
	{
		if (_dataDictionary.ContainsKey(key))
		{
			return (string)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetString(string key, string value)
	{
		_dataDictionary[key] = value;
	}

	public override int GetInt(string key, int defaultValue = 0)
	{
		if (_dataDictionary.ContainsKey(key))
		{
			return (int)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetInt(string key, int value)
	{
		_dataDictionary[key] = value;
	}

	public override bool GetBool(string key, bool defaultValue = false)
	{
		if (_dataDictionary.ContainsKey(key))
		{
			return (bool)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetBool(string key, bool value)
	{
		_dataDictionary[key] = value;
	}

	public override string ExportAsString()
	{
		return ToJson();
	}

	public override void ImportFromString(string sjson)
	{
		FromJson(sjson);
	}

	public override List<string> ListDir(string relDir)
	{
		throw new NotImplementedException();
	}

	public override bool Exists(string relFilename)
	{
		string path = Path.Combine(GetStoragePath(), relFilename);
		if (File.Exists(path))
		{
			return true;
		}
		if (Directory.Exists(path))
		{
			return true;
		}
		return false;
	}

	public override DateTime GetCreatedTime(string relFilename)
	{
		return File.GetCreationTime(Path.Combine(GetStoragePath(), relFilename));
	}

	public override DateTime GetModifiedTime(string relFilename)
	{
		return File.GetLastWriteTime(Path.Combine(GetStoragePath(), relFilename));
	}

	public override string LoadTextFile(string relFilename)
	{
		string path = Path.Combine(GetStoragePath(), relFilename);
		if (!File.Exists(path))
		{
			return null;
		}
		return File.ReadAllText(path);
	}

	public override void SaveTextFile(string relFilename, string text)
	{
		File.WriteAllText(Path.Combine(GetStoragePath(), relFilename), text);
	}

	public override void Delete(string relFilename)
	{
		string path = Path.Combine(GetStoragePath(), relFilename);
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	public override void StreamingCopy(string relSrc, string relDst, Utils.IncludeFilePredicate includePredicate = null)
	{
		string text = Path.Combine(Application.streamingAssetsPath, relSrc);
		string text2 = Path.Combine(GetStoragePath(), relDst);
		bool flag = File.Exists(text);
		bool flag2 = Directory.Exists(text);
		if (!flag && !flag2)
		{
			throw new Exception("Invalid streaming file copy src");
		}
		FileAttributes attributes = File.GetAttributes(text);
		if (attributes.HasFlag(FileAttributes.Directory))
		{
			Utils.DirectoryCopy(text, text2, copySubDirs: true, includePredicate);
		}
		else
		{
			File.Copy(text, text2, overwrite: true);
		}
	}
}
