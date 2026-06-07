using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConfigFile
{
	public Dictionary<string, List<string>> Values = new Dictionary<string, List<string>>();

	public List<string> this[string key]
	{
		get
		{
			return Values.GetOrNull(key);
		}
		set
		{
			Values[key] = value;
		}
	}

	public static ConfigFile FromDictionary(Dictionary<string, string> dict)
	{
		ConfigFile configFile = new ConfigFile();
		foreach (KeyValuePair<string, string> item in dict)
		{
			configFile[item.Key] = new List<string> { item.Value };
		}
		return configFile;
	}

	public void Combine(ConfigFile f)
	{
		foreach (KeyValuePair<string, List<string>> value in f.Values)
		{
			Values[value.Key] = value.Value;
		}
	}

	public void Add(string key, string value)
	{
		if (Values.ContainsKey(key))
		{
			Values[key].Add(value);
			return;
		}
		Values[key] = new List<string> { value };
	}

	public void AddRange(string key, IEnumerable<string> values)
	{
		if (Values.ContainsKey(key))
		{
			Values[key].AddRange(values);
		}
		else
		{
			Values[key] = values.ToList();
		}
	}

	public string Get(string key)
	{
		return GetOrDefault(key, "Error");
	}

	public string Get(string key, string def)
	{
		return GetOrDefault(key, def);
	}

	public string GetOrDefault(string key, string def)
	{
		List<string> list = this[key];
		if (list != null && list.Count > 0)
		{
			return list[0];
		}
		return def;
	}

	public bool TryGet(string key, out string val)
	{
		List<string> list = this[key];
		if (list != null && list.Count > 0)
		{
			val = list[0];
			return true;
		}
		val = null;
		return false;
	}

	public static ConfigFile Load(string lines)
	{
		return Load(lines.SplitByNewLines());
	}

	public static ConfigFile Load(string[] lines)
	{
		ConfigFile configFile = new ConfigFile();
		string text = null;
		List<string> list = new List<string>();
		foreach (string text2 in lines)
		{
			if (text2.Length > 0 && text2[0] == '[' && text != null)
			{
				configFile[text] = list.ToList();
				list.Clear();
				text = null;
			}
			if (text == null)
			{
				int num = text2.LastIndexOf(']');
				if (text2.Length > 0 && text2[0] == '[' && num > 1)
				{
					text = text2.Substring(1, num - 1);
				}
			}
			else
			{
				list.Add(text2);
			}
		}
		if (text != null)
		{
			configFile[text] = list;
		}
		return configFile;
	}

	public string Serialize()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, List<string>> value in Values)
		{
			stringBuilder.AppendLine("[" + value.Key + "]");
			foreach (string item in value.Value)
			{
				stringBuilder.AppendLine(item);
			}
		}
		return stringBuilder.ToString();
	}
}
