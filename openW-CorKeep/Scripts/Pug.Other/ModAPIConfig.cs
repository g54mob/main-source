using System;
using System.IO;
using System.Text;
using PugMod;
using UnityEngine;

public class ModAPIConfig : IConfig
{
	[Serializable]
	private class ModConfigFile<T>
	{
		public string mod;

		public string section;

		public string description;

		public string key;

		public T defaultValue;

		public T value;
	}

	private class ModConfigEntry<T> : IConfigEntry<T>
	{
		private ModAPIConfig _apiConfig;

		private string _path;

		private string _directory;

		private ModConfigFile<T> _file;

		public T Value
		{
			get
			{
				if (_apiConfig.TryGet(_path, out _file))
				{
					return _file.value;
				}
				return default(T);
			}
			set
			{
				_file.value = value;
				if (!_apiConfig._filesystem.DirectoryExists(_directory))
				{
					_apiConfig._filesystem.CreateDirectory(_directory);
				}
				string s = JsonUtility.ToJson(_file, prettyPrint: true);
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				_apiConfig._filesystem.Write(_path, bytes);
			}
		}

		public ModConfigEntry(ModAPIConfig apiConfig, string path, string directory, ModConfigFile<T> file)
		{
			_apiConfig = apiConfig;
			_path = path;
			_directory = directory;
			_file = file;
		}
	}

	private IConfigFilesystem _filesystem;

	public ModAPIConfig(IConfigFilesystem filesystem)
	{
		_filesystem = filesystem;
	}

	public IConfigEntry<T> Register<T>(string mod, string section, string description, string key, T defaultValue)
	{
		string directory;
		string path = GetPath(mod, section, key, out directory);
		ModConfigFile<T> file;
		if (!_filesystem.FileExists(path))
		{
			Set(mod, section, key, defaultValue);
			file = new ModConfigFile<T>
			{
				mod = mod,
				section = section,
				description = description,
				key = key,
				defaultValue = defaultValue,
				value = defaultValue
			};
		}
		else
		{
			file = Get<T>(path);
		}
		return new ModConfigEntry<T>(this, path, directory, file);
	}

	public bool TryGet<T>(string mod, string section, string key, out T value)
	{
		string directory;
		string path = GetPath(mod, section, key, out directory);
		ModConfigFile<T> modConfigFile;
		bool flag = TryGet(path, out modConfigFile);
		value = (flag ? modConfigFile.value : default(T));
		return flag;
	}

	public T Get<T>(string mod, string section, string key)
	{
		string directory;
		string path = GetPath(mod, section, key, out directory);
		return Get<T>(path).value;
	}

	public void Set<T>(string mod, string section, string key, T value)
	{
		string directory;
		string path = GetPath(mod, section, key, out directory);
		if (!TryGet(path, out ModConfigFile<T> modConfigFile))
		{
			modConfigFile = new ModConfigFile<T>
			{
				mod = mod,
				section = section,
				key = key,
				value = value
			};
		}
		modConfigFile.value = value;
		if (!_filesystem.DirectoryExists(directory))
		{
			_filesystem.CreateDirectory(directory);
		}
		string s = JsonUtility.ToJson(modConfigFile, prettyPrint: true);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		_filesystem.Write(path, bytes);
	}

	private string GetPath(string mod, string section, string key, out string directory)
	{
		EnsureNoPathSeparator(mod, "mod");
		EnsureNoPathSeparator(section, "section");
		EnsureNoPathSeparator(key, "key");
		directory = mod;
		return Path.Combine(mod, section + "-" + key + ".json");
	}

	private void EnsureNoPathSeparator(string input, string paramName)
	{
		if (input.Contains('/') || input.Contains('\\'))
		{
			throw new InvalidOperationException(paramName + " contains path separator");
		}
	}

	private bool TryGet<T>(string path, out ModConfigFile<T> modConfigFile)
	{
		if (!_filesystem.FileExists(path))
		{
			modConfigFile = null;
			return false;
		}
		try
		{
			byte[] bytes = _filesystem.Read(path);
			string json = Encoding.UTF8.GetString(bytes);
			modConfigFile = new ModConfigFile<T>();
			JsonUtility.FromJsonOverwrite(json, modConfigFile);
			return true;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			modConfigFile = null;
			return false;
		}
	}

	private ModConfigFile<T> Get<T>(string path)
	{
		if (!_filesystem.FileExists(path))
		{
			throw new InvalidOperationException("no value at " + path);
		}
		ModConfigFile<T> modConfigFile = new ModConfigFile<T>();
		byte[] bytes = _filesystem.Read(path);
		JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(bytes), modConfigFile);
		return modConfigFile;
	}
}
