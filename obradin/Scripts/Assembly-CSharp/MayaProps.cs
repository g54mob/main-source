using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MayaProps
{
	public readonly string sourceAssetPath;

	public readonly string generatedAssetPath;

	public List<string> unnamed = new List<string>();

	private Dictionary<string, string> props = new Dictionary<string, string>();

	public MayaProps(string sourceAssetPath_, string generatedAssetPath_, string[] tokens, int tokensStart)
	{
		sourceAssetPath = sourceAssetPath_;
		generatedAssetPath = generatedAssetPath_;
		Regex regex = new Regex("^([^:]+):(.+)$");
		for (int i = tokensStart; i < tokens.Length; i++)
		{
			Match match = regex.Match(tokens[i]);
			if (match.Success)
			{
				props.Add(match.Groups[1].Value, match.Groups[2].Value);
			}
			else
			{
				unnamed.Add(tokens[i]);
			}
		}
	}

	public string Get(string name, string defaultValue)
	{
		string value;
		if (props.TryGetValue(name, out value))
		{
			return value;
		}
		return defaultValue;
	}

	public float Get(string name, float defaultValue)
	{
		return float.Parse(Get(name, defaultValue.ToString()));
	}

	public int Get(string name, int defaultValue)
	{
		return int.Parse(Get(name, defaultValue.ToString()));
	}

	public Vector3 Get(string name, Vector3 defaultValue)
	{
		return Util.ParseVector3(Get(name, string.Empty), defaultValue);
	}

	public bool Get(string name, bool defaultValue)
	{
		string text = Get(name, string.Empty);
		if (text == string.Empty)
		{
			return defaultValue;
		}
		text = text.ToLower();
		return text == "true" || text == "yes" || text == "1";
	}

	public void Fill(string name, ref string v)
	{
		v = Get(name, v);
	}

	public void Fill(string name, ref int v)
	{
		v = Get(name, v);
	}

	public void Fill(string name, ref float v)
	{
		v = Get(name, v);
	}

	public void Fill(string name, ref Vector3 v)
	{
		v = Get(name, v);
	}

	public void Fill(string name, ref bool v)
	{
		v = Get(name, v);
	}
}
