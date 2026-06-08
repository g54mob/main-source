using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerPrefsStorage : AStorage
{
	private readonly string CREATED_TIME_KEY = "createdTime";

	private readonly string MODIFIED_TIME_KEY = "modifiedTime";

	public override bool IsBusySaving()
	{
		return false;
	}

	public override void Save()
	{
		string value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
		if (!PlayerPrefs.HasKey(CREATED_TIME_KEY))
		{
			PlayerPrefs.SetString(CREATED_TIME_KEY, value);
		}
		PlayerPrefs.SetString(MODIFIED_TIME_KEY, value);
		PlayerPrefs.Save();
	}

	public override void Load()
	{
		currentState = State.Success;
	}

	public override void Clear()
	{
		PlayerPrefs.DeleteAll();
	}

	public override bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public override void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public override string GetString(string key, string defaultValue = "")
	{
		return PlayerPrefs.GetString(key, defaultValue);
	}

	public override void SetString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public override int GetInt(string key, int defaultValue = 0)
	{
		return PlayerPrefs.GetInt(key, defaultValue);
	}

	public override void SetInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public override bool GetBool(string key, bool defaultValue = false)
	{
		if (HasKey(key))
		{
			return GetInt(key) != 0;
		}
		return defaultValue;
	}

	public override void SetBool(string key, bool value)
	{
		SetInt(key, value ? 1 : 0);
	}

	public override string ExportAsString()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		int num = GetInt("save_file_last_id");
		for (int i = 0; i <= num; i++)
		{
			string key = "save_file_" + i;
			if (HasKey(key))
			{
				string value = GetString(key);
				dictionary[key] = value;
			}
		}
		bool identationEnabled = SlimJson.identationEnabled;
		SlimJson.identationEnabled = false;
		SlimJson.BeginSerialization();
		int count = dictionary.Count;
		List<string> list = new List<string>(count);
		List<string> list2 = new List<string>(count);
		List<string> list3 = new List<string>(count);
		foreach (KeyValuePair<string, object> item in dictionary)
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
				Utils.LogError("Unsuported type when serializing in PlayerPrefsStorage.ExportAsString(): " + item.Value);
			}
		}
		SlimJson.AddProperty("STRING_KEYS", list.ToArray());
		SlimJson.AddProperty("INT_KEYS", list2.ToArray());
		SlimJson.AddProperty("BOOL_KEYS", list3.ToArray());
		string inValue = SlimJson.EndSerialization();
		SlimJson.identationEnabled = identationEnabled;
		return AStorage.ReplaceQuotes(inValue);
	}

	public override void ImportFromString(string sjson)
	{
		Clear();
		sjson = AStorage.UnplaceQuotes(sjson);
		string[] array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				string value = SlimJson.Parse(sjson, key);
				SetString(key, value);
			}
		}
		array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				int value2 = SlimJson.ParseInt(sjson, key2);
				SetInt(key2, value2);
			}
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key3 in array)
			{
				bool value3 = SlimJson.ParseBool(sjson, key3);
				SetBool(key3, value3);
			}
		}
	}

	public override string GetStoragePath()
	{
		return Application.persistentDataPath;
	}

	public override List<string> ListDir(string relDir)
	{
		throw new NotImplementedException();
	}

	public override bool Exists(string relFilename)
	{
		return PlayerPrefs.HasKey(GetStoragePath() + "/" + relFilename);
	}

	public override DateTime GetCreatedTime(string relFilename)
	{
		if (PlayerPrefs.HasKey(CREATED_TIME_KEY))
		{
			return DateTime.Parse(PlayerPrefs.GetString(CREATED_TIME_KEY), CultureInfo.InvariantCulture);
		}
		return new DateTime(0L);
	}

	public override DateTime GetModifiedTime(string relFilename)
	{
		if (PlayerPrefs.HasKey(MODIFIED_TIME_KEY))
		{
			return DateTime.Parse(PlayerPrefs.GetString(MODIFIED_TIME_KEY), CultureInfo.InvariantCulture);
		}
		return new DateTime(0L);
	}

	public override string LoadTextFile(string relFilename)
	{
		string key = GetStoragePath() + "/" + relFilename;
		if (!PlayerPrefs.HasKey(key))
		{
			return null;
		}
		return PlayerPrefs.GetString(key);
	}

	public override void SaveTextFile(string relFilename, string text)
	{
		PlayerPrefs.SetString(GetStoragePath() + "/" + relFilename, text);
	}

	public override void Delete(string relFilename)
	{
		string key = GetStoragePath() + "/" + relFilename;
		if (PlayerPrefs.HasKey(key))
		{
			PlayerPrefs.DeleteKey(key);
		}
	}

	public override void StreamingCopy(string relSrc, string relDst, Utils.IncludeFilePredicate includePredicate = null)
	{
	}
}
