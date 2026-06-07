using System;
using IniParser;
using IniParser.Configuration;
using IniParser.Model;
using UnityEngine;

public class IniFile
{
	public class NoAlphaAttribute : Attribute
	{
	}

	private IniData data;

	private IniDataFormatter formatter;

	private IniFormattingConfiguration formatConfig;

	public string path { get; private set; }

	public IniFile(string path)
	{
	}

	private static string ReadAllText(string file)
	{
		return null;
	}

	private IniData ReadDataFromFile()
	{
		return null;
	}

	public void Clean()
	{
	}

	public bool Save()
	{
		return false;
	}

	public bool SaveAs(string path)
	{
		return false;
	}

	private Property GetProperty(string section, string name, bool create = false)
	{
		return null;
	}

	public string GetString(string section, string name, string defaultValue = "")
	{
		return null;
	}

	public bool GetBoolean(string section, string name, bool defaultValue = false)
	{
		return false;
	}

	public int GetInteger(string section, string name, int defaultValue = 0)
	{
		return 0;
	}

	public float GetFloat(string section, string name, float defaultValue = 0f)
	{
		return 0f;
	}

	public Color GetColor(string section, string name, bool alpha, Color defaultValue = default(Color))
	{
		return default(Color);
	}

	public void GetClass<T>(ref T data, string section = null)
	{
	}

	public void GetDictionaryClass<T, DICT_KEY_T, DICT_VALUE_T>(ref T data) where DICT_VALUE_T : new()
	{
	}

	public void SetString(string section, string name, string value)
	{
	}

	public void SetBoolean(string section, string name, bool value)
	{
	}

	public void SetInteger(string section, string name, int value)
	{
	}

	public void SetFloat(string section, string name, float value)
	{
	}

	public void SetColor(string section, string name, Color value, bool alpha)
	{
	}

	public void SetClass<T>(T data, string section = null)
	{
	}

	public void SetDictionaryClass<T, DICT_KEY_T, DICT_VALUE_T>(T data) where DICT_VALUE_T : new()
	{
	}

	private string SectionFromFieldName(string name)
	{
		return null;
	}

	private string NameFromFieldName(string name)
	{
		return null;
	}
}
