using System.Collections.Generic;

public static class SettingsFileExtensions
{
	public static void Erase(this ISettingFile settings)
	{
		settings.Erase();
	}

	public static void ClearValue(this ISettingFile settings, string groupKey, string key)
	{
		settings.RemoveSetting(groupKey, key);
	}

	public static void ClearValue(this ISettingFile settings, string key)
	{
		settings.RemoveSetting(key);
	}

	public static void ClearGroupValues(this ISettingFile settings, string groupKey)
	{
		settings.RemoveGroupSettings(groupKey);
	}

	public static void ClearAllValues(this ISettingFile settings, string groupKey, string keyBase)
	{
		settings.RemoveSettings(groupKey, keyBase);
	}

	public static bool GroupExists(this ISettingFile settings, string groupKey)
	{
		return settings.GroupExists(groupKey);
	}

	public static void SaveValue<T>(this ISettingFile settings, string key, T value)
	{
		if (value != null)
		{
			settings.SaveSetting(key, value.ToString());
		}
	}

	public static void SaveValue<T>(this ISettingFile settings, string groupKey, string key, T value)
	{
		if (value != null)
		{
			settings.SaveSetting(groupKey, key, value.ToString());
		}
	}

	public static List<KeyValuePair<string, T>> GetAllValues<T>(this ISettingFile settings, string groupKey, T matchingValue)
	{
		return settings.GetSettings(groupKey, string.Empty, matchingValue);
	}

	public static List<KeyValuePair<string, T>> GetAllValues<T>(this ISettingFile settings, string groupKey, string keyBase, T matchingValue)
	{
		return settings.GetSettings(groupKey, keyBase, matchingValue);
	}

	public static string GetGroup<T>(this ISettingFile settings, string groupKeyBase, string key, T matchingValue)
	{
		return settings.GetGroupWithSettings(groupKeyBase, key, matchingValue);
	}

	public static List<string> GetGroups<T>(this ISettingFile settings, string groupKeyBase, string key, T matchingValue)
	{
		if (string.IsNullOrEmpty(key))
		{
			return settings.GetGroupsByName(groupKeyBase);
		}
		return settings.GetGroupsWithSettings(groupKeyBase, key, matchingValue);
	}

	public static T GetValue<T>(this ISettingFile settings, string groupKey, string key)
	{
		return settings.GetValue(groupKey, key, default(T));
	}

	public static T GetValue<T>(this ISettingFile settings, string groupKey, string key, T DefaultValue)
	{
		return settings.GetSetting(groupKey, key, DefaultValue);
	}

	public static T GetValue<T>(this ISettingFile settings, string key, T DefaultValue)
	{
		return settings.GetSetting(key, DefaultValue);
	}
}
