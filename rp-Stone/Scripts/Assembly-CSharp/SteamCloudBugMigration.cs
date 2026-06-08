using System;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using UnityEngine;

public class SteamCloudBugMigration
{
	private string userId;

	private static string LAST_STEAM_ID_KEY = "last_steam_id_for_saves";

	private static string SAVE_FILE_NAME = "primary_save.txt";

	public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

	public static long Timestamp => (long)DateTime.UtcNow.Subtract(Epoch).TotalSeconds;

	private string CloudPath
	{
		get
		{
			if (userId == null)
			{
				return Application.persistentDataPath;
			}
			return Path.Combine(Application.persistentDataPath, userId);
		}
	}

	private string OldPath
	{
		get
		{
			if (userId == null)
			{
				return Application.persistentDataPath;
			}
			return Path.Combine(Application.persistentDataPath, userId);
		}
	}

	public bool IsMigrationRequired
	{
		get
		{
			string oldPath = OldPath;
			string cloudPath = CloudPath;
			Debug.Log("Steam Cloud Bug Migration: old path = " + oldPath);
			Debug.Log("Steam Cloud Bug Migration: new path = " + cloudPath);
			if (oldPath == cloudPath)
			{
				return false;
			}
			return File.Exists(Path.Combine(oldPath, SAVE_FILE_NAME));
		}
	}

	public SteamCloudBugMigration()
	{
		if (SteamManager.Initialized)
		{
			userId = SteamUser.GetSteamID().ToString();
		}
		else if (PlayerPrefs.HasKey(LAST_STEAM_ID_KEY))
		{
			userId = PlayerPrefs.GetString(LAST_STEAM_ID_KEY);
		}
	}

	public void Perform()
	{
		string oldPath = OldPath;
		string cloudPath = CloudPath;
		string path = Path.Combine(oldPath, SAVE_FILE_NAME);
		string path2 = Path.Combine(cloudPath, SAVE_FILE_NAME);
		if (!File.Exists(path))
		{
			Debug.Log("Steam Cloud Bug Migration: No local save, skipping");
			return;
		}
		GameplayActionMessages.SetMessage("\n Merging local save file w/Steam Cloud.", Color.yellow, 5f);
		Debug.Log("Steam Cloud Bug Migration: Performing");
		BackupDirectory(oldPath);
		if (Directory.Exists(cloudPath))
		{
			BackupDirectory(cloudPath);
		}
		if (!File.Exists(path2))
		{
			Debug.Log("Steam Cloud Bug Migration: No cloud files, copying local to cloud");
			if (Directory.Exists(cloudPath))
			{
				Directory.Delete(cloudPath, recursive: true);
			}
			Directory.Move(oldPath, cloudPath);
		}
		else
		{
			if (!Directory.Exists(cloudPath))
			{
				Directory.CreateDirectory(cloudPath);
			}
			Dictionary<string, SaveFiles.SaveFileMeta> dictionary = LoadSaveFiles(path);
			Dictionary<string, SaveFiles.SaveFileMeta> dictionary2 = LoadSaveFiles(path2);
			foreach (string key2 in dictionary.Keys)
			{
				string key = key2;
				SaveFiles.SaveFileMeta saveFileMeta = dictionary[key2];
				while (dictionary2.ContainsKey(key))
				{
					int num = int.Parse(saveFileMeta.saveId);
					num++;
					saveFileMeta.saveId = num.ToString();
					key = "save_file_" + num;
				}
				dictionary2.Add(key, saveFileMeta);
			}
			int num2 = -1;
			foreach (string key3 in dictionary2.Keys)
			{
				int num3 = int.Parse(dictionary2[key3].saveId);
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			string contents = ToJson(dictionary2, num2);
			File.WriteAllText(path2, contents);
		}
		string text = Path.Combine(oldPath, "Stonescript");
		string destDirName = Path.Combine(cloudPath, "Stonescript");
		if (Directory.Exists(text))
		{
			Utils.DirectoryCopy(text, destDirName, copySubDirs: true);
		}
		if (Directory.Exists(oldPath))
		{
			Directory.Delete(oldPath, recursive: true);
		}
		Debug.Log("Steam Cloud Bug Migration: Complete!");
	}

	private void BackupDirectory(string path, bool move = false)
	{
		long num = Timestamp;
		string text = path + "_" + num;
		while (Directory.Exists(text))
		{
			num++;
			text = path + "_" + num;
		}
		if (move)
		{
			Debug.Log("Steam Cloud Bug Migration: Moving " + path + " to " + text);
			Directory.Move(path, text);
		}
		else
		{
			Debug.Log("Steam Cloud Bug Migration: Backing up " + path + " to " + text);
			Utils.DirectoryCopy(path, text, copySubDirs: true);
		}
	}

	private Dictionary<string, SaveFiles.SaveFileMeta> LoadSaveFiles(string path)
	{
		string sjson = File.ReadAllText(path);
		Dictionary<string, SaveFiles.SaveFileMeta> dictionary = new Dictionary<string, SaveFiles.SaveFileMeta>();
		Dictionary<string, object> dictionary2 = FromJson(sjson);
		foreach (string key in dictionary2.Keys)
		{
			string text = dictionary2[key] as string;
			if (!string.IsNullOrEmpty(text))
			{
				SaveFiles.SaveFileMeta saveFileMeta = new SaveFiles.SaveFileMeta();
				saveFileMeta.FromString(text);
				dictionary.Add(key, saveFileMeta);
			}
		}
		return dictionary;
	}

	private Dictionary<string, object> FromJson(string sjson)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string[] array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				string value = SlimJson.Parse(sjson, key);
				dictionary.Add(key, value);
			}
		}
		array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				int num = SlimJson.ParseInt(sjson, key2);
				dictionary.Add(key2, num);
			}
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key3 in array)
			{
				bool flag = SlimJson.ParseBool(sjson, key3);
				dictionary.Add(key3, flag);
			}
		}
		return dictionary;
	}

	private string ToJson(Dictionary<string, SaveFiles.SaveFileMeta> saveFiles, int lastSaveId)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (string key in saveFiles.Keys)
		{
			dictionary.Add(key, saveFiles[key].ToString());
		}
		dictionary.Add("save_file_last_id", lastSaveId);
		return ToJson(dictionary);
	}

	private string ToJson(Dictionary<string, object> data)
	{
		SlimJson.BeginSerialization();
		int count = data.Count;
		List<string> list = new List<string>(count);
		List<string> list2 = new List<string>(count);
		List<string> list3 = new List<string>(count);
		foreach (KeyValuePair<string, object> datum in data)
		{
			if (datum.Value is string)
			{
				SlimJson.AddProperty(datum.Key, (string)datum.Value);
				list.Add(datum.Key);
			}
			else if (datum.Value is int)
			{
				SlimJson.AddProperty(datum.Key, (int)datum.Value);
				list2.Add(datum.Key);
			}
			else if (datum.Value is bool)
			{
				SlimJson.AddProperty(datum.Key, (bool)datum.Value);
				list3.Add(datum.Key);
			}
			else
			{
				Utils.LogError("Unsuported type when serializing in SteamCloudStorage.ToJson(): " + datum.Value);
			}
		}
		SlimJson.AddProperty("STRING_KEYS", list.ToArray());
		SlimJson.AddProperty("INT_KEYS", list2.ToArray());
		SlimJson.AddProperty("BOOL_KEYS", list3.ToArray());
		return SlimJson.EndSerialization();
	}
}
