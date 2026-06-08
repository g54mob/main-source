using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class StonescriptStorage
{
	private class DictionaryConverter : CustomCreationConverter<Dictionary<string, object>>
	{
		public override Dictionary<string, object> Create(Type objectType)
		{
			return new Dictionary<string, object>();
		}

		public override bool CanConvert(Type objectType)
		{
			if (!(objectType == typeof(object)))
			{
				return base.CanConvert(objectType);
			}
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.Null)
			{
				return base.ReadJson(reader, objectType, existingValue, serializer);
			}
			object obj = serializer.Deserialize(reader);
			if (reader.TokenType == JsonToken.Integer)
			{
				obj = Convert.ToInt32(obj);
			}
			else if (reader.TokenType == JsonToken.Float)
			{
				obj = (float)Convert.ToDouble(obj);
			}
			return obj;
		}
	}

	private AStorage storage;

	private string saveId;

	private Dictionary<string, object> cachedSave;

	private bool isDirty;

	private int iteration = -1;

	private bool useEncryption = true;

	private static string passphrase = "crO3QxMGFE5VQnXcj1P7";

	private static string formatVersion = "0.2";

	public StonescriptStorage(AStorage storage, string saveId)
	{
		this.storage = storage;
		this.saveId = saveId;
	}

	public void Set(string groupName, string key, object value)
	{
		ValidateSetValue(value);
		if (cachedSave == null)
		{
			Load();
		}
		if (!cachedSave.ContainsKey(groupName))
		{
			cachedSave.Add(groupName, new Dictionary<string, object>());
		}
		(cachedSave[groupName] as Dictionary<string, object>)[key] = value;
		isDirty = true;
	}

	private void ValidateSetValue(object value)
	{
		if (!(value is int) && !(value is string) && !(value is bool) && !(value is float))
		{
			throw new StonescriptRuntimeException("Storage only supports primitives (int, float, string, bool)");
		}
	}

	public object Get(string groupName, string key, object defaultValue = null)
	{
		if (cachedSave == null)
		{
			Load();
		}
		if (!cachedSave.ContainsKey(groupName))
		{
			return defaultValue;
		}
		Dictionary<string, object> dictionary = cachedSave[groupName] as Dictionary<string, object>;
		if (dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		return defaultValue;
	}

	public bool Exists(string groupName, string key)
	{
		if (cachedSave == null)
		{
			Load();
		}
		if (!cachedSave.ContainsKey(groupName))
		{
			return false;
		}
		return (cachedSave[groupName] as Dictionary<string, object>).ContainsKey(key);
	}

	public void Delete(string groupName, string key)
	{
		if (cachedSave == null)
		{
			Load();
		}
		if (cachedSave.ContainsKey(groupName))
		{
			Dictionary<string, object> dictionary = cachedSave[groupName] as Dictionary<string, object>;
			if (dictionary.ContainsKey(key))
			{
				dictionary.Remove(key);
			}
		}
	}

	public int Increment(string groupName, string key, int amount = 1)
	{
		if (cachedSave == null)
		{
			Load();
		}
		Dictionary<string, object> dictionary;
		if (!cachedSave.ContainsKey(groupName))
		{
			dictionary = new Dictionary<string, object>();
			cachedSave[groupName] = dictionary;
		}
		else
		{
			dictionary = cachedSave[groupName] as Dictionary<string, object>;
		}
		int num = 0;
		if (dictionary.ContainsKey(key))
		{
			object obj = dictionary[key];
			if (!(obj is int))
			{
				throw new StonescriptRuntimeException("Storage cannot increment key \"" + key + "\" because it is not an integer");
			}
			num = (int)obj;
		}
		num += amount;
		dictionary[key] = num;
		isDirty = true;
		return num;
	}

	public List<string> Keys(string groupName)
	{
		if (cachedSave == null)
		{
			Load();
		}
		Dictionary<string, object> dictionary;
		if (!cachedSave.ContainsKey(groupName))
		{
			dictionary = new Dictionary<string, object>();
			cachedSave[groupName] = dictionary;
		}
		else
		{
			dictionary = cachedSave[groupName] as Dictionary<string, object>;
		}
		return new List<string>(dictionary.Keys);
	}

	public void Load(bool forceReload = false)
	{
		if (!forceReload && cachedSave != null)
		{
			return;
		}
		try
		{
			string relFilename = "Stonescript/save_" + saveId + ".txt";
			if (storage.Exists(relFilename))
			{
				string text = storage.LoadTextFile(relFilename);
				Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>((text[0] == '{') ? text : StringCipher.Decrypt(text, passphrase), new JsonConverter[1]
				{
					new DictionaryConverter()
				});
				int num = Convert.ToInt32(dictionary["iteration"]);
				if (num > iteration)
				{
					iteration = num;
					cachedSave = dictionary["data"] as Dictionary<string, object>;
					isDirty = false;
				}
			}
			if (cachedSave == null)
			{
				cachedSave = new Dictionary<string, object>();
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public void Save()
	{
		if (isDirty)
		{
			Save(cachedSave);
		}
	}

	private void Save(Dictionary<string, object> data)
	{
		string relFilename = "Stonescript/save_" + saveId + ".txt";
		if (data == null || data.Count == 0)
		{
			if (storage.Exists(relFilename))
			{
				storage.Delete(relFilename);
			}
			cachedSave.Clear();
			isDirty = false;
		}
		else
		{
			iteration++;
			string text = JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{ "version", formatVersion },
				{ "iteration", iteration },
				{ "data", data }
			});
			string text2 = (useEncryption ? StringCipher.Encrypt(text, passphrase) : text);
			storage.SaveTextFile(relFilename, text2);
			cachedSave = data;
			isDirty = false;
		}
	}

	public static int FindAvailableSaveId(AStorage storage)
	{
		for (int i = 0; i < 1000; i++)
		{
			string relFilename = $"Stonescript/save_{i}.txt";
			if (!storage.Exists(relFilename))
			{
				return i;
			}
		}
		return -1;
	}
}
