using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using DV.JObjectExtstensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveGameData
{
	private JObject dataObject;

	private List<(int Type, byte[] Data)> customChunks;

	public List<(int Type, byte[] Data)> CustomChunks => customChunks;

	public static SaveGameData LoadFromFile(string path, string decryptPassphrase = null)
	{
		if (!File.Exists(path))
		{
			Debug.LogError("Couldn't load, file doesn't exist");
			return null;
		}
		return LoadFromString(File.ReadAllText(path), decryptPassphrase);
	}

	public static SaveGameData LoadFromString(string json, string decryptPassphrase = null)
	{
		if (!string.IsNullOrEmpty(decryptPassphrase))
		{
			try
			{
				json = DataProtection.DecryptString(json, decryptPassphrase);
			}
			catch (FormatException)
			{
				Debug.LogError("Couldn't decrypt content (FormatException)");
				return null;
			}
			catch (CryptographicException)
			{
				Debug.LogError("Couldn't decrypt content (CryptographicException)");
				return null;
			}
		}
		JObject jObject;
		try
		{
			jObject = JObject.Parse(json);
		}
		catch (JsonReaderException)
		{
			Debug.LogError("Couldn't parse content");
			return null;
		}
		return new SaveGameData(jObject);
	}

	public static SaveGameData LoadFromJson(JObject json, List<(int Type, byte[] Data)> customChunks = null)
	{
		return new SaveGameData(json.DeepClone() as JObject, customChunks);
	}

	public static bool SaveToFile(SaveGameData data, string path, string encryptPassphrase = null)
	{
		if (File.Exists(path))
		{
			Debug.LogError("File already exists, not overwriting, will not be saved");
			return false;
		}
		string jsonString = data.GetJsonString();
		string contents = (string.IsNullOrEmpty(encryptPassphrase) ? jsonString : DataProtection.EncryptString(jsonString, encryptPassphrase));
		File.WriteAllText(path, contents);
		return true;
	}

	public SaveGameData()
	{
		dataObject = new JObject();
		customChunks = new List<(int, byte[])>();
	}

	public SaveGameData(JObject dataObject, List<(int Type, byte[] Data)> customChunks = null)
	{
		this.dataObject = dataObject;
		this.customChunks = new List<(int, byte[])>();
		if (customChunks == null)
		{
			return;
		}
		foreach (var (item, item2) in customChunks)
		{
			this.customChunks.Add((item, item2));
		}
	}

	public string GetJsonString()
	{
		return JsonConvert.SerializeObject(dataObject);
	}

	public JObject GetJsonObject()
	{
		return dataObject;
	}

	public int? GetInt(string key)
	{
		return dataObject.GetInt(key);
	}

	public void SetInt(string key, int value)
	{
		dataObject.SetInt(key, value);
	}

	public float? GetFloat(string key)
	{
		return dataObject.GetFloat(key);
	}

	public void SetFloat(string key, float value)
	{
		dataObject.SetFloat(key, value);
	}

	public double? GetDouble(string key)
	{
		return dataObject.GetDouble(key);
	}

	public void SetDouble(string key, double value)
	{
		dataObject.SetDouble(key, value);
	}

	public string GetString(string key)
	{
		return dataObject.GetString(key);
	}

	public void SetString(string key, string value)
	{
		dataObject.SetString(key, value);
	}

	public string[] GetStringArray(string key)
	{
		return dataObject.GetStringArray(key);
	}

	public void SetStringArray(string key, string[] value)
	{
		dataObject.SetStringArray(key, value);
	}

	public void AddToStringArray(string key, string value, bool enforceUnique)
	{
		dataObject.AddToStringArray(key, value, enforceUnique);
	}

	public bool? GetBool(string key)
	{
		return dataObject.GetBool(key);
	}

	public void SetBool(string key, bool value)
	{
		dataObject.SetBool(key, value);
	}

	public Vector3? GetVector3(string key)
	{
		return dataObject.GetVector3(key);
	}

	public void SetVector3(string key, Vector3 value)
	{
		dataObject.SetVector3(key, value);
	}

	public Vector3?[] GetVector3Array(string key)
	{
		return dataObject.GetVector3Array(key);
	}

	public void SetVector3Array(string key, Vector3[] value)
	{
		dataObject.SetVector3Array(key, value);
	}

	public void SetIntArray(string key, int[] value)
	{
		dataObject.SetIntArray(key, value);
	}

	public int[] GetIntArray(string key)
	{
		return dataObject.GetIntArray(key);
	}

	public JObject GetJObject(string key)
	{
		return dataObject.GetJObject(key);
	}

	public void SetJObject(string key, JObject value)
	{
		dataObject.SetJObject(key, value);
	}

	public void SetObject(string key, object value, JsonSerializerSettings serializerSettings = null)
	{
		dataObject.SetObjectViaJSON(key, value, serializerSettings);
	}

	public T GetObject<T>(string key, JsonSerializerSettings serializerSettings = null) where T : class
	{
		return dataObject.GetObjectViaJSON<T>(key, serializerSettings);
	}

	public void SetJObjectArray(string key, JObject[] value)
	{
		dataObject.SetJObjectArray(key, value);
	}

	public JObject[] GetJObjectArray(string key)
	{
		return dataObject.GetJObjectArray(key);
	}

	public bool RemoveData(string key)
	{
		return dataObject.Remove(key);
	}

	public void SetCustomChunkData(int chunkType, byte[] chunkData)
	{
		for (int i = 0; i < customChunks.Count; i++)
		{
			if (customChunks[i].Type == chunkType)
			{
				customChunks[i] = (chunkType, chunkData);
				return;
			}
		}
		customChunks.Add((chunkType, chunkData));
	}

	public byte[] GetCustomChunkData(int chunkType)
	{
		for (int i = 0; i < customChunks.Count; i++)
		{
			if (customChunks[i].Type == chunkType)
			{
				return customChunks[i].Data;
			}
		}
		return null;
	}

	public void Clear()
	{
		dataObject.RemoveAll();
	}
}
