using System;
using System.Collections.Generic;
using System.Reflection;

public class PreferencesTypeResolver : IPreferenceTypeResolver
{
	private Dictionary<Preferences, Type> lookupCache;

	public PreferencesTypeResolver()
	{
		lookupCache = new Dictionary<Preferences, Type>();
		foreach (Preferences allPreference in PreferencesUtils.GetAllPreferences())
		{
			PreferenceAttribute customAttribute = typeof(Preferences).GetField(allPreference.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
			if (customAttribute == null)
			{
				throw new Exception(string.Format("Preference '{0}' doesn't have a '{1}' attached. Type cannot be resolved.", allPreference, "PreferenceAttribute"));
			}
			lookupCache.Add(allPreference, customAttribute.PreferenceType);
		}
	}

	public Type GetPreferenceType(Preferences preference)
	{
		return lookupCache[preference];
	}

	public bool IsOfType<T>(Preferences preference)
	{
		return GetPreferenceType(preference) == typeof(T);
	}
}
