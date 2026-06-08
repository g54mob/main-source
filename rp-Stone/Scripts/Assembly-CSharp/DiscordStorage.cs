using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DiscordStorage : AStorage
{
	private Dictionary<string, object> _dataDictionary = new Dictionary<string, object>();

	public override bool IsBusySaving()
	{
		return false;
	}

	public override void Save()
	{
		StreamWriter streamWriter = new StreamWriter(GetStoragePath(), append: false);
		string value = ToJson();
		streamWriter.WriteLine(value);
		streamWriter.Close();
	}

	public override void Load()
	{
		Utils.Log("Attempting to load saved data...");
		string storagePath = GetStoragePath();
		if (!File.Exists(storagePath))
		{
			Utils.Log("No saved data found, creating new save file in " + GetStoragePath());
			File.Create(GetStoragePath());
			return;
		}
		StreamReader streamReader = new StreamReader(storagePath);
		string sjson = streamReader.ReadToEnd();
		streamReader.Close();
		FromJson(sjson);
	}

	public override void Clear()
	{
		_dataDictionary.Clear();
	}

	private string GetStorageDir()
	{
		return Path.GetFullPath(".") + "/save/";
	}

	public override string GetStoragePath()
	{
		string text = Path.GetFullPath(".") + "/save";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + "/primary_save.txt";
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
				Utils.LogError("Unsuported type when serializing in DiscordStorage.ToJson(): " + item.Value);
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
		string[] array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				string value = SlimJson.Parse(sjson, key);
				_dataDictionary.Add(key, value);
			}
		}
		array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				int num = SlimJson.ParseInt(sjson, key2);
				_dataDictionary.Add(key2, num);
			}
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key3 in array)
			{
				bool flag = SlimJson.ParseBool(sjson, key3);
				_dataDictionary.Add(key3, flag);
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
		return File.GetCreationTime(Path.Combine(GetStorageDir(), relFilename));
	}

	public override DateTime GetModifiedTime(string relFilename)
	{
		return File.GetLastWriteTime(Path.Combine(GetStorageDir(), relFilename));
	}

	public override string LoadTextFile(string relFilename)
	{
		string path = Path.Combine(GetStorageDir(), relFilename);
		if (!File.Exists(path))
		{
			return null;
		}
		return File.ReadAllText(path);
	}

	public override void SaveTextFile(string relFilename, string text)
	{
		File.WriteAllText(Path.Combine(GetStorageDir(), relFilename), text);
	}

	public override void Delete(string relFilename)
	{
		string path = Path.Combine(GetStorageDir(), relFilename);
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	public override void StreamingCopy(string relSrc, string relDst, Utils.IncludeFilePredicate includePredicate = null)
	{
		string text = Path.Combine(Application.streamingAssetsPath, relSrc);
		string text2 = Path.Combine(GetStorageDir(), relDst);
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
