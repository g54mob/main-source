using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigFileCTG
{
	private const char DELIMITER = '=';

	private IDictionary<string, string> _settings = new Dictionary<string, string>();

	private static ConfigFileCTG _configFile;

	public static bool HasSetting(string key)
	{
		if (_configFile == null)
		{
			_configFile = new ConfigFileCTG();
			_configFile.LoadConfig(GameFileHelper.ConfigFileFullPath());
		}
		return _configFile.ValueExistsInDictionary(key);
	}

	public static string GetSetting(string key)
	{
		if (_configFile == null)
		{
			_configFile = new ConfigFileCTG();
			_configFile.LoadConfig(GameFileHelper.ConfigFileFullPath());
		}
		return _configFile.GetConfigSetting(key);
	}

	public static void SaveSetting(string key, string settingValue)
	{
		if (_configFile == null)
		{
			_configFile = new ConfigFileCTG();
			_configFile.LoadConfig(GameFileHelper.ConfigFileFullPath());
		}
		_configFile.SetConfigSetting(key, settingValue);
		_configFile.SaveConfigFile(GameFileHelper.ConfigFileFullPath());
	}

	internal bool ValueExistsInDictionary(string key)
	{
		return _settings.ContainsKey(key);
	}

	private bool LoadConfig(string configFilename)
	{
		bool flag = true;
		_settings.Clear();
		if (File.Exists(configFilename))
		{
			return ReadConfigFile(configFilename);
		}
		return SaveConfigFile(configFilename);
	}

	private string GetConfigSetting(string key)
	{
		string result = string.Empty;
		if (_settings.ContainsKey(key))
		{
			result = _settings[key];
		}
		return result;
	}

	private void SetConfigSetting(string key, string settingValue)
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

	private bool ReadConfigFile(string configFilename)
	{
		bool result = true;
		_settings.Clear();
		try
		{
			string[] array = File.ReadAllLines(configFilename);
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Contains('='.ToString()))
				{
					string[] array3 = text.Split(new char[1] { '=' }, 2);
					if (array3 != null && array3.Length == 2)
					{
						_settings.Add(array3[0].Trim(), array3[1].Trim());
					}
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			Debug.Log("Error reading config file.  Message: " + ex.Message);
		}
		return result;
	}

	private bool SaveConfigFile(string configFilename)
	{
		bool result = true;
		try
		{
			string[] array = new string[_settings.Count];
			int num = 0;
			foreach (KeyValuePair<string, string> setting in _settings)
			{
				array[num++] = setting.Key + '=' + setting.Value;
			}
			File.WriteAllLines(configFilename, array);
		}
		catch (Exception ex)
		{
			result = false;
			Debug.Log("Error saving config file.  Message: " + ex.Message);
		}
		return result;
	}
}
