using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class MockPreferencesStore : IPreferencesStore
{
	private class PreferenceValueUpdateTracker
	{
		public event Action Updated;

		public void FireUpdated()
		{
			this.Updated?.Invoke();
		}
	}

	private object[] storedPrefs;

	private PreferenceValueUpdateTracker[] preferencesUpdateEvents;

	private readonly IPreferenceTypeResolver preferenceTypeResolver;

	private readonly PreferencesExclusivity exclusivity;

	public bool IsDirty { get; set; }

	public MockPreferencesStore(PreferencesExclusivity preferencesExclusivity)
	{
		exclusivity = preferencesExclusivity;
		preferenceTypeResolver = new MockPreferencesTypeResolver();
		int length = Enum.GetValues(typeof(Preferences)).GetLength(0);
		storedPrefs = new object[length];
		preferencesUpdateEvents = new PreferenceValueUpdateTracker[length];
		foreach (Preferences item in PreferencesUtils.GetPreferencesByExclusivity(exclusivity))
		{
			preferencesUpdateEvents[(int)item] = new PreferenceValueUpdateTracker();
		}
		ResetPreferencesToDefault();
	}

	public T Get<T>(Preferences p)
	{
		if (PreferencesUtils.IsExcluded(p))
		{
			Debug.LogError($"Preference {p} is not included in {exclusivity}. Returning default.");
			return default(T);
		}
		if (!preferenceTypeResolver.IsOfType<T>(p))
		{
			Debug.LogError($"Type mismatch for preference '{p}'. Returning default value.");
			return default(T);
		}
		object obj = storedPrefs[(int)p];
		if (obj != null)
		{
			if (typeof(T).IsAssignableFrom(obj.GetType()))
			{
				Debug.Log($"Getting preference '{p}' value: '{obj}'");
				return (T)obj;
			}
			Debug.LogError($"Stored value type mismatch for '{p}' ({obj.GetType()} stored, should be {typeof(T)}). Returning default value.");
			return default(T);
		}
		Debug.LogError($"There is no stored value for preference '{p}'. Returning default.");
		return default(T);
	}

	public void Set<T>(Preferences p, T value)
	{
		if (PreferencesUtils.IsExcluded(p))
		{
			Debug.LogError($"Preference {p} is not included in {exclusivity}. New value '{value}' not set.");
			return;
		}
		if (!preferenceTypeResolver.IsOfType<T>(p))
		{
			Debug.LogError($"Type mismatch for preference '{p}'. It is not of type '{typeof(T)}'. New value '{value}' not set.");
			return;
		}
		object obj = storedPrefs[(int)p];
		if (obj != null)
		{
			Debug.Log($"Setting value for preference '{p}' to '{value}'");
			storedPrefs[(int)p] = value;
			if (!obj.Equals(value))
			{
				IsDirty = true;
			}
			preferencesUpdateEvents[(int)p].FireUpdated();
		}
		else
		{
			Debug.LogError($"Preference '{p}' was not initialized properly. New value '{value}' not set.");
		}
	}

	public void ResetPreferencesToDefault()
	{
		foreach (Preferences item in PreferencesUtils.GetPreferencesByExclusivity(exclusivity))
		{
			PreferenceAttribute customAttribute = typeof(Preferences).GetField(item.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
			if (customAttribute == null)
			{
				throw new Exception($"Preference '{item}' doesn't have a preference type attribute attached.");
			}
			object obj = ((exclusivity == PreferencesExclusivity.NonVR) ? customAttribute.DefaultValueNonVR : customAttribute.DefaultValueVR);
			storedPrefs[(int)item] = obj;
		}
	}

	public void OverridePreferencesExternally(object[] overrideCollection)
	{
		if (overrideCollection == null || overrideCollection.Length != storedPrefs.Length)
		{
			Debug.LogError("Preference override not possible. Override collection is either null or has a different length than existing.");
		}
		else
		{
			storedPrefs = overrideCollection.ToArray();
		}
	}

	public object[] RequestAllPreferences()
	{
		return storedPrefs.ToArray();
	}

	public void RegisterValueUpdatedReceiver(Preferences p, Action callback)
	{
		if (!PreferencesUtils.GetPreferencesByExclusivity(exclusivity).Contains(p))
		{
			Debug.LogError($"Cannot register to value update event. Preference {p} is excluded in the current setup");
		}
		else
		{
			preferencesUpdateEvents[(int)p].Updated += callback;
		}
	}

	public void UnregisterValueUpdatedReceiver(Preferences p, Action callback)
	{
		if (!PreferencesUtils.GetPreferencesByExclusivity(exclusivity).Contains(p))
		{
			Debug.LogError($"Cannot unregister from value update event. Preference {p} is excluded in the current setup");
		}
		else
		{
			preferencesUpdateEvents[(int)p].Updated -= callback;
		}
	}
}
