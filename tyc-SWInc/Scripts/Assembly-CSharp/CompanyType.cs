using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;

[Serializable]
public class CompanyType
{
	public readonly string Name;

	public readonly Dictionary<KeyValuePair<string, string>, float> Types;

	public readonly Dictionary<KeyValuePair<string, string>, float> Addons;

	public readonly float PerYear;

	public readonly int Min;

	public readonly int Max;

	public readonly string ForceType;

	public readonly string ForceCat;

	public readonly string NameGen;

	public readonly bool LatestTech;

	public readonly bool Frameworks;

	[NonSerialized]
	private SoftwareType[] _distinctTypes;

	private int _lastTypeRefresh = -1;

	public CompanyType(string name, Dictionary<KeyValuePair<string, string>, float> types, int min, int max, float perYear, string forceType, string forceCat, string nameGen)
	{
		Name = name;
		Types = types;
		Min = min;
		Max = max;
		PerYear = perYear;
		ForceType = forceType;
		ForceCat = forceCat;
		NameGen = nameGen;
	}

	public SoftwareType[] GetDistinctTypes(SDateTime t)
	{
		if (_distinctTypes == null || _lastTypeRefresh != t.Year)
		{
			_lastTypeRefresh = t.Year;
			_distinctTypes = (from x in Types.Keys.SelectNotNull((KeyValuePair<string, string> x) => MarketSimulation.Active.SoftwareTypes.GetOrDefault(x.Key)).Distinct()
				where x.IsUnlocked(t.Year) && x.Categories.Values.Any((SoftwareCategory z) => !z.Hidden && z.IsUnlocked(t.Year))
				select x).ToArray();
		}
		return _distinctTypes;
	}

	public CompanyType(TydCollection node)
	{
		Name = node.GetChildValue("Specialization");
		Min = node.GetChildValue("Min", true, 0);
		Max = node.GetChildValue("Max", true, 0);
		PerYear = node.GetChildValue("PerYear", true, 0f);
		Frameworks = node.GetChildValue("Frameworks", false, true);
		Dictionary<KeyValuePair<string, string>, float> dictionary = new Dictionary<KeyValuePair<string, string>, float>();
		List<TydNode> nodes = node.GetChild<TydCollection>("Types").Nodes;
		for (int i = 0; i < nodes.Count; i++)
		{
			TydCollection tydCollection = nodes[i] as TydCollection;
			if (tydCollection != null)
			{
				KeyValuePair<string, string> key = new KeyValuePair<string, string>(tydCollection.GetChildValue("Software"), tydCollection.GetChildValue("Category", false));
				dictionary.Add(key, tydCollection.GetChildValue("Chance", true, 0f));
				if (tydCollection.GetChildValue("Force", false, false))
				{
					ForceType = key.Key;
					ForceCat = key.Value;
				}
			}
		}
		Types = dictionary;
		TydCollection child = node.GetChild<TydCollection>("Addons");
		if (child != null)
		{
			dictionary = new Dictionary<KeyValuePair<string, string>, float>();
			for (int j = 0; j < child.Nodes.Count; j++)
			{
				TydCollection tydCollection2 = child.Nodes[j] as TydCollection;
				if (tydCollection2 != null)
				{
					KeyValuePair<string, string> key2 = new KeyValuePair<string, string>(tydCollection2.GetChildValue("Software"), tydCollection2.GetChildValue("Addon"));
					dictionary.Add(key2, tydCollection2.GetChildValue("Chance", true, 0f));
				}
			}
			Addons = dictionary;
		}
		NameGen = node.GetChildValue("NameGen", false);
	}

	public CompanyType()
	{
	}

	public float GetEffort(string software, string category)
	{
		float value = 0f;
		if (Types.TryGetValue(new KeyValuePair<string, string>(software, category), out value))
		{
			return value;
		}
		if (Types.TryGetValue(new KeyValuePair<string, string>(software, null), out value))
		{
			return value;
		}
		return 1f;
	}

	public Dictionary<string, string[]> GetTypes()
	{
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
		foreach (KeyValuePair<string, string> key in Types.Keys)
		{
			SoftwareType value;
			SoftwareCategory value2;
			if (MarketSimulation.Active.SoftwareTypes.TryGetValue(key.Key, out value) && (key.Value == null || (value.Categories.TryGetValue(key.Value, out value2) && !value2.Hidden)))
			{
				dictionary.Append(key.Key, key.Value);
			}
		}
		foreach (KeyValuePair<string, HashSet<string>> item in dictionary.ToList())
		{
			if (item.Value.Contains(null))
			{
				dictionary[item.Key] = new SHashSet<string> { null };
			}
		}
		return dictionary.ToDictionary((KeyValuePair<string, HashSet<string>> x) => x.Key, (KeyValuePair<string, HashSet<string>> x) => x.Value.ToArray());
	}

	public bool IsValid(int year)
	{
		foreach (KeyValuePair<KeyValuePair<string, string>, float> type in Types)
		{
			SoftwareType value;
			if (!MarketSimulation.Active.SoftwareTypes.TryGetValue(type.Key.Key, out value) || !value.IsUnlocked(year))
			{
				continue;
			}
			SoftwareCategory value2;
			if (type.Key.Value == null)
			{
				if (value.Categories.Values.Any((SoftwareCategory x) => !x.Hidden && x.IsUnlocked(year)))
				{
					return true;
				}
			}
			else if (value.Categories.TryGetValue(type.Key.Value, out value2) && value2.IsUnlocked(year))
			{
				return true;
			}
		}
		return false;
	}

	public bool OSSupport(SoftwareType sw)
	{
		foreach (KeyValuePair<KeyValuePair<string, string>, float> type in Types)
		{
			if (type.Key.Key.Equals("Operating System"))
			{
				if (type.Key.Value == null)
				{
					return true;
				}
				if (sw.SupportsOS(type.Key.Value))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool HasAddons()
	{
		if (Addons != null && Addons.Count > 0)
		{
			return true;
		}
		foreach (KeyValuePair<KeyValuePair<string, string>, float> type in Types)
		{
			SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes[type.Key.Key];
			if (type.Key.Value == null)
			{
				if (softwareType.AddOns.Any())
				{
					return true;
				}
			}
			else if (softwareType.AddOns.Values.Any((SoftwareAddOn x) => x.Categories.Contains(type.Key.Value)))
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		return Name;
	}
}
