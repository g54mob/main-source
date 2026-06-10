using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Externals.Lebug;

public static class Lebug
{
	public static readonly object mutex = new object();

	public static readonly Dictionary<string, Dictionary<string, object>> lebugDict = new Dictionary<string, Dictionary<string, object>>();

	public static readonly Dictionary<string, bool> categoriesExpanded = new Dictionary<string, bool>();

	public static readonly Dictionary<string, List<float>> seriesDict = new Dictionary<string, List<float>>();

	public static readonly Dictionary<string, LebugSeriesStats> seriesStats = new Dictionary<string, LebugSeriesStats>();

	[Conditional("UNITY_EDITOR")]
	public static void Log(string key, object value, string category = "Default", bool expanded = true)
	{
		if (value == null)
		{
			value = "NULL";
		}
		if (key == null)
		{
			new StackTrace();
			return;
		}
		lock (mutex)
		{
			if (!lebugDict.ContainsKey(category))
			{
				categoriesExpanded.Add(category, expanded);
				lebugDict.Add(category, new Dictionary<string, object>());
			}
			if (lebugDict[category].ContainsKey(key))
			{
				lebugDict[category][key] = value.ToString();
			}
			else
			{
				lebugDict[category].Add(key, value.ToString());
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void Del(string key, string category = "Default", bool keepEmptyCategory = false)
	{
		lock (mutex)
		{
			if (lebugDict.ContainsKey(category) && lebugDict[category].ContainsKey(key))
			{
				lebugDict[category].Remove(key);
				if (lebugDict[category].Count == 0 && !keepEmptyCategory)
				{
					lebugDict.Remove(category);
					categoriesExpanded.Remove(category);
				}
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void DelCategory(string category = "Default", bool onlyContents = false)
	{
		lock (mutex)
		{
			if (lebugDict.ContainsKey(category))
			{
				if (onlyContents)
				{
					lebugDict[category].Clear();
					return;
				}
				lebugDict.Remove(category);
				categoriesExpanded.Remove(category);
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void ExpandCategory(string category = "Default")
	{
		lock (mutex)
		{
			if (lebugDict.ContainsKey(category))
			{
				categoriesExpanded[category] = true;
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void CollapseCategory(string category = "Default")
	{
		lock (mutex)
		{
			if (lebugDict.ContainsKey(category))
			{
				categoriesExpanded[category] = false;
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogSeries(float value, string category)
	{
		lock (mutex)
		{
			if (!seriesDict.ContainsKey(category))
			{
				seriesDict[category] = new List<float>();
			}
			seriesDict[category].Add(value);
		}
	}

	public static void RefreshSeries(string seriesKey)
	{
		lock (mutex)
		{
			if (!seriesStats.ContainsKey(seriesKey))
			{
				seriesStats[seriesKey] = new LebugSeriesStats();
			}
			if (seriesDict.TryGetValue(seriesKey, out var value))
			{
				if (value.Count > 0)
				{
					value.Sort();
				}
				LebugSeriesStats lebugSeriesStats = seriesStats[seriesKey];
				lebugSeriesStats.Average = ((value.Count > 0) ? value.Average() : 0f);
				lebugSeriesStats.Min = ((value.Count > 0) ? value.Min() : 0f);
				lebugSeriesStats.Max = ((value.Count > 0) ? value.Max() : 0f);
				lebugSeriesStats.Median = ((value.Count > 0) ? value[value.Count / 2] : 0f);
				lebugSeriesStats.ValueCount = (uint)value.Count;
				lebugSeriesStats.DistinctCount = (uint)value.Distinct().Count();
			}
		}
	}
}
