using System.Collections.Generic;

public class ProgressFlags
{
	private static Dictionary<string, bool> cache = new Dictionary<string, bool>();

	private static List<string> flagsList = new List<string>();

	public static List<string> Flags => flagsList;

	public static void ClearProgress()
	{
		cache.Clear();
		flagsList.Clear();
	}

	public static void SetFlag(string flag, bool value = true)
	{
		if (flag.Contains(","))
		{
			Utils.LogError("ProgressFlags::SetFlag() Invalid parameter " + flag + " cannot contain commas.");
			return;
		}
		if (cache.ContainsKey(flag))
		{
			cache[flag] = value;
		}
		else
		{
			cache.Add(flag, value);
		}
		if (value)
		{
			if (!flagsList.Contains(flag))
			{
				flagsList.Add(flag);
			}
		}
		else
		{
			flagsList.Remove(flag);
		}
	}

	public static bool GetFlag(string flag)
	{
		if (cache.ContainsKey(flag))
		{
			return cache[flag];
		}
		cache.Add(flag, value: false);
		return false;
	}

	public static int GetFlagCount()
	{
		return flagsList.Count;
	}

	public static void Remove(string flag)
	{
		SetFlag(flag, value: false);
	}

	public static bool EvaluateRequiredAndBlockedBy(string requiresFlag, string blockedByFlag)
	{
		if (string.IsNullOrEmpty(requiresFlag) || GetFlag(requiresFlag) || EventController.singleton.IsEventActiveAndStarted(requiresFlag))
		{
			if (!string.IsNullOrEmpty(blockedByFlag))
			{
				return !GetFlag(blockedByFlag);
			}
			return true;
		}
		return false;
	}

	public static string Serialize()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, bool> item in cache)
		{
			if (item.Value)
			{
				list.Add(item.Key);
			}
		}
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("flags", list.ToArray());
		return SlimJson.EndSerialization();
	}

	public static void Parse(string sjson)
	{
		ClearProgress();
		string[] array = SlimJson.ParseArray(sjson, "flags");
		for (int i = 0; i < array.Length; i++)
		{
			cache.Add(array[i], value: true);
			flagsList.Add(array[i]);
		}
	}
}
