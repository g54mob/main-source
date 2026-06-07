using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV.Utils;
using UnityEngine;

public static class PreferencesUtils
{
	private static Dictionary<PreferencesExclusivity, List<Preferences>> preferenceCacheByExclusivity;

	private static Dictionary<PreferencesExclusivity, List<Preferences>> nonFixedPreferenceCasheByExclusivity;

	private static Dictionary<PreferenceCategory, List<Preferences>> preferencesByCategory;

	private static Dictionary<Preferences, PreferenceAttribute> attributeByPreference;

	private static bool[][] preferencesInclusionState;

	public static PreferencesExclusivity CurrentExclusivity { get; private set; }

	static PreferencesUtils()
	{
		preferenceCacheByExclusivity = new Dictionary<PreferencesExclusivity, List<Preferences>>();
		nonFixedPreferenceCasheByExclusivity = new Dictionary<PreferencesExclusivity, List<Preferences>>();
		preferencesByCategory = new Dictionary<PreferenceCategory, List<Preferences>>();
		attributeByPreference = null;
		CurrentExclusivity = PreferencesExclusivity.Any;
		int length = Enum.GetValues(typeof(PreferencesExclusivity)).GetLength(0);
		int length2 = Enum.GetValues(typeof(Preferences)).GetLength(0);
		preferencesInclusionState = new bool[length][];
		for (int i = 0; i < length; i++)
		{
			preferencesInclusionState[i] = new bool[length2];
			for (int j = 0; j < length2; j++)
			{
				preferencesInclusionState[i][j] = !IsExcludedByReflection((Preferences)j, (PreferencesExclusivity)i);
			}
		}
	}

	public static void SetExclusivity(PreferencesExclusivity exclusivity)
	{
		CurrentExclusivity = exclusivity;
	}

	public static List<Preferences> GetAllPreferences()
	{
		if (preferenceCacheByExclusivity.TryGetValue(PreferencesExclusivity.Any, out var value))
		{
			return value;
		}
		value = Enum.GetValues(typeof(Preferences)).Cast<Preferences>().ToList();
		preferenceCacheByExclusivity.Add(PreferencesExclusivity.Any, value);
		return value;
	}

	public static PreferenceAttribute GetAttribute(this Preferences myPref)
	{
		if (attributeByPreference == null)
		{
			attributeByPreference = new Dictionary<Preferences, PreferenceAttribute>();
			Type typeFromHandle = typeof(Preferences);
			Preferences[] array = (Preferences[])Enum.GetValues(typeFromHandle);
			for (int i = 0; i < array.Length; i++)
			{
				Preferences key = array[i];
				PreferenceAttribute customAttribute = typeFromHandle.GetField(key.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
				attributeByPreference.Add(key, customAttribute);
			}
		}
		if (attributeByPreference.TryGetValue(myPref, out var value))
		{
			return value;
		}
		return null;
	}

	public static List<Preferences> GetPreferencesInCategory(PreferenceCategory cat)
	{
		if (preferencesByCategory.TryGetValue(cat, out var value))
		{
			return value;
		}
		List<Preferences> allPreferences = GetAllPreferences();
		List<Preferences> list = new List<Preferences>();
		foreach (Preferences item in allPreferences)
		{
			if (item.GetAttribute().Category == cat)
			{
				list.Add(item);
			}
		}
		preferencesByCategory.Add(cat, list);
		return list;
	}

	public static List<Preferences> GetPreferencesByExclusivity(PreferencesExclusivity exclusivity)
	{
		if (preferenceCacheByExclusivity.TryGetValue(exclusivity, out var value))
		{
			return value;
		}
		value = (from Preferences t in Enum.GetValues(typeof(Preferences))
			where !IsExcludedByReflection(t, exclusivity)
			select t).ToList();
		preferenceCacheByExclusivity.Add(exclusivity, value);
		return value;
	}

	public static List<Preferences> GetNonFixedPreferencesByExclusivity(PreferencesExclusivity exclusivity)
	{
		if (nonFixedPreferenceCasheByExclusivity.TryGetValue(exclusivity, out var value))
		{
			return value;
		}
		value = (from Preferences t in Enum.GetValues(typeof(Preferences))
			where !IsExcludedByReflection(t, exclusivity)
			select t).ToList();
		nonFixedPreferenceCasheByExclusivity.Add(exclusivity, value);
		return value;
	}

	private static bool IsExcludedByReflection(Preferences preference, PreferencesExclusivity criteria)
	{
		if (criteria == PreferencesExclusivity.Any)
		{
			return false;
		}
		PreferenceAttribute customAttribute = typeof(Preferences).GetField(preference.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
		if (customAttribute != null)
		{
			if (customAttribute.ExclusiveTo != PreferencesExclusivity.Any)
			{
				return customAttribute.ExclusiveTo != criteria;
			}
			return false;
		}
		Debug.LogWarning($"Preference {preference} doesn't have exclusivity attribute attached. Assuming non-exclusivity");
		return false;
	}

	public static bool IsExcluded(Preferences p)
	{
		return !preferencesInclusionState[(int)CurrentExclusivity][(int)p];
	}

	public static bool IsExcluded(Preferences p, PreferencesExclusivity x)
	{
		return !preferencesInclusionState[(int)x][(int)p];
	}

	public static T GetTypeStrictDefaultPreferenceValue<T>(Preferences p, bool vr)
	{
		PreferenceAttribute customAttribute = typeof(Preferences).GetField(p.ToString()).GetCustomAttribute<PreferenceAttribute>();
		if (customAttribute == null)
		{
			Debug.LogError(string.Format("Preference '{0}' doesn't have '{1}' attached. Returning default value of '{2}' for type'{3}'.", p, "PreferenceAttribute", default(T), typeof(T)));
			return default(T);
		}
		object obj = (vr ? customAttribute.DefaultValueVR : customAttribute.DefaultValueNonVR);
		if (obj != null && typeof(T).IsAssignableFrom(obj.GetType()))
		{
			return (T)obj;
		}
		Debug.LogError($"Requested default value for preference '{p}' is either null or cannot be cast to desired type. Returning default value of '{default(T)}' for type'{typeof(T)}'.");
		return default(T);
	}

	public static void SetEnumPreference<T>(Preferences p, T e) where T : Enum
	{
		if (SingletonBehaviour<GamePreferences>.Instance.GetEnumerablePreferencesMapping().TryGetValue(p, out var value))
		{
			if (e.GetType() != value)
			{
				Debug.LogError($"Preference '{p}' supports enum of type '{value}', but given type was '{e.GetType()}'. Setting preference value skipped.");
			}
			else
			{
				GamePreferences.Set(p, (int)(object)e);
			}
		}
		else
		{
			Debug.LogError(string.Format("Preference '{0}' does not support any enum as value. Have you forgot to add values to '{1}.{2}' dictionary? Setting preference value skipped.", p, "APreferencesProvider", "GetEnumerablePreferencesMapping"));
		}
	}

	public static T GetNextEnumValue<T>(T currentValue, bool forward) where T : Enum
	{
		return GetNextEnumValue(Enum.GetValues(typeof(T)).Cast<T>().ToList(), currentValue, forward);
	}

	public static T GetNextEnumValue<T>(T currentValue, T valueToIgnore, bool forward) where T : Enum
	{
		List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
		list.Remove(valueToIgnore);
		return GetNextEnumValue(list, currentValue, forward);
	}

	private static T GetNextEnumValue<T>(List<T> values, T currentValue, bool forward) where T : Enum
	{
		if (values == null || values.Count <= 0)
		{
			Debug.LogError($"Total number of desired '{typeof(T)}' enum values is zero. This should not happen. Returning default value.");
			return default(T);
		}
		int num = values.IndexOf(currentValue);
		if (num == -1)
		{
			Debug.LogError($"Could not find the index of `{currentValue}` in the list of given values. Returning default value for enum `{typeof(T)}`.");
			return default(T);
		}
		int num2 = num + (forward ? 1 : (-1));
		if (num2 >= values.Count)
		{
			num2 = 0;
		}
		else if (num2 < 0)
		{
			num2 = values.Count - 1;
		}
		return values[num2];
	}
}
