using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AssetFallbacks
{
	public TextAsset jsonFile;

	private Dictionary<string, string> mapping;

	public void Init()
	{
		if (mapping != null)
		{
			return;
		}
		mapping = new Dictionary<string, string>();
		string[] array = SlimJson.ParseArray(jsonFile.text, "entries");
		for (int i = 0; i < array.Length; i += 2)
		{
			string text = array[i];
			string value = array[i + 1];
			if (mapping.ContainsKey(text))
			{
				Utils.LogErrorIfEditor("Duplicate key '" + text + "' in asset fallbacks file '" + jsonFile.name + "'");
			}
			else
			{
				mapping.Add(text, value);
			}
		}
	}

	public string GetFallback(string key)
	{
		if (mapping.ContainsKey(key))
		{
			return mapping[key];
		}
		return null;
	}
}
