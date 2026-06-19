using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.Save
{
	public class JsonSaveBackend : IJsonSaveBackend
	{
		private readonly string _filePath;

		private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
			Formatting = Formatting.Indented,
			NullValueHandling = NullValueHandling.Ignore
		};

		private Dictionary<string, string> _cache;

		public JsonSaveBackend(string fileName = "save.json")
		{
			_filePath = Path.Combine(Application.persistentDataPath, fileName);
			LoadFile();
		}

		public void WriteKey(string key, string json)
		{
			_cache[key] = json;
			FlushFile();
		}

		public string ReadKey(string key)
		{
			if (!_cache.TryGetValue(key, out var value))
			{
				return null;
			}
			return value;
		}

		public bool HasKey(string key)
		{
			return _cache.ContainsKey(key);
		}

		public void DeleteKey(string key)
		{
			if (_cache.Remove(key))
			{
				FlushFile();
			}
		}

		public void DeleteAll()
		{
			_cache.Clear();
			FlushFile();
		}

		private void LoadFile()
		{
			if (!File.Exists(_filePath))
			{
				_cache = new Dictionary<string, string>();
				return;
			}
			try
			{
				string value = File.ReadAllText(_filePath);
				_cache = JsonConvert.DeserializeObject<Dictionary<string, string>>(value) ?? new Dictionary<string, string>();
			}
			catch
			{
				Debug.LogWarning("[JsonSaveBackend] Failed to load " + _filePath + ", starting fresh.");
				_cache = new Dictionary<string, string>();
			}
		}

		private void FlushFile()
		{
			string contents = JsonConvert.SerializeObject(_cache, _settings);
			File.WriteAllText(_filePath, contents);
		}
	}
}
