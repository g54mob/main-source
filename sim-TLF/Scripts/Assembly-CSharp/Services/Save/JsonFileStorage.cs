using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.Save
{
	public class JsonFileStorage : IJsonFileStorage
	{
		private readonly string _directory;

		private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
			Formatting = Formatting.Indented,
			NullValueHandling = NullValueHandling.Ignore,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		};

		public JsonFileStorage(string saveDirectory = "SaveData")
		{
			_directory = Path.Combine(Application.persistentDataPath, saveDirectory);
			Directory.CreateDirectory(_directory);
		}

		public void Write<T>(string key, T data)
		{
			string contents = JsonConvert.SerializeObject(data, _settings);
			File.WriteAllText(FilePath(key), contents);
		}

		public bool TryRead<T>(string key, out T data)
		{
			string path = FilePath(key);
			if (!File.Exists(path))
			{
				data = default(T);
				return false;
			}
			try
			{
				string value = File.ReadAllText(path);
				data = JsonConvert.DeserializeObject<T>(value, _settings);
				return true;
			}
			catch (Exception ex)
			{
				Debug.LogError("[JsonFileStorage] Failed to read '" + key + "': " + ex.Message);
				data = default(T);
				return false;
			}
		}

		public void DeleteKey(string key)
		{
			string path = FilePath(key);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public void DeleteAll()
		{
			string[] files = Directory.GetFiles(_directory, "*.json");
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
		}

		private string FilePath(string key)
		{
			return Path.Combine(_directory, key + ".json");
		}
	}
}
