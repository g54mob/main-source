using System.Collections.Generic;
using UnityEngine;

public class Properties : ICollectionItem
{
	private Dictionary<string, string> properties;

	public int Count => properties.Count;

	public Properties()
	{
		properties = new Dictionary<string, string>();
	}

	public void AddProperty(string key, string value)
	{
		properties.Add(key, value);
	}

	public void SetProperty(string key, string value)
	{
		if (properties.ContainsKey(key))
		{
			properties[key] = value;
		}
		else
		{
			properties.Add(key, value);
		}
	}

	public bool HasProperty(string key)
	{
		return properties.ContainsKey(key);
	}

	public string GetProperty(string key, string defaultValue = "")
	{
		if (!properties.ContainsKey(key))
		{
			return defaultValue;
		}
		return properties[key];
	}

	public bool GetPropertyAsBool(string key, bool defaultValue = false)
	{
		if (!properties.ContainsKey(key))
		{
			return defaultValue;
		}
		return bool.Parse(properties[key]);
	}

	public int GetPropertyAsInt(string key, int defaultValue = 0)
	{
		if (!properties.ContainsKey(key))
		{
			return defaultValue;
		}
		return int.Parse(properties[key]);
	}

	public float GetPropertyAsFloat(string key, float defaultValue = 0f)
	{
		if (!properties.ContainsKey(key))
		{
			return defaultValue;
		}
		return float.Parse(properties[key]);
	}

	public Vector2 GetPropertyAsVector2(string key)
	{
		if (!properties.ContainsKey(key))
		{
			return Vector2.zero;
		}
		return Util.Vector2Parser(properties[key]);
	}

	public Vector3 GetPropertyAsVector3(string key)
	{
		if (!properties.ContainsKey(key))
		{
			return Vector3.zero;
		}
		return Util.Vector3Parser(properties[key]);
	}

	public ICollection<string> GetAllKeys()
	{
		return properties.Keys;
	}

	public string GetId()
	{
		string[] array = new string[4] { "Id", "id", "Name", "name" };
		foreach (string key in array)
		{
			if (properties.ContainsKey(key))
			{
				return properties[key];
			}
		}
		return null;
	}

	public void RemoveAllProperties()
	{
		properties.Clear();
	}

	public Properties Clone()
	{
		Properties properties = new Properties();
		foreach (string key in this.properties.Keys)
		{
			properties.AddProperty(key, this.properties[key]);
		}
		return properties;
	}
}
