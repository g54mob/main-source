using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class PreferencesStore : IPreferencesStore
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

	private readonly PreferenceValueUpdateTracker[] preferencesUpdateEvents;

	private readonly IPreferenceTypeResolver preferenceTypeResolver;

	private readonly PreferencesExclusivity exclusivity;

	public bool IsDirty { get; set; }

	public PreferencesStore(PreferencesExclusivity preferencesExclusivity)
	{
		if (preferencesExclusivity == PreferencesExclusivity.Any)
		{
			Debug.LogError("PreferencesStore doesn't have preference exclusivity. This is not the intended behavior.");
		}
		if (preferencesExclusivity != PreferencesExclusivity.VR && preferencesExclusivity != PreferencesExclusivity.NonVR)
		{
			throw new Exception(string.Format("Unexpected exclusivity '{0}' for {1}. It only supports '{2}' and '{3}'.", exclusivity, "PreferencesStore", PreferencesExclusivity.VR, PreferencesExclusivity.NonVR));
		}
		exclusivity = preferencesExclusivity;
		preferenceTypeResolver = new PreferencesTypeResolver();
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
		if (PreferencesUtils.IsExcluded(p, exclusivity))
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
			return (T)obj;
		}
		Debug.LogError($"There is no stored value for preference '{p}'. Returning default.");
		return default(T);
	}

	public void Set<T>(Preferences p, T value)
	{
		if (PreferencesUtils.IsExcluded(p, exclusivity))
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
		foreach (Preferences allPreference in PreferencesUtils.GetAllPreferences())
		{
			if (!PreferencesUtils.IsExcluded(allPreference, exclusivity))
			{
				FieldInfo field = typeof(Preferences).GetField(allPreference.ToString());
				if (field.GetCustomAttribute<PreferenceAttribute>(inherit: true) == null)
				{
					throw new Exception($"Preference '{allPreference}' doesn't have a preference type attribute attached. Reset to default value is not possible.");
				}
				object valueFromAttribute = GetValueFromAttribute(allPreference, field);
				storedPrefs[(int)allPreference] = valueFromAttribute;
			}
		}
	}

	private object GetValueFromAttribute(Preferences p, FieldInfo fieldInfo)
	{
		PreferenceAttribute customAttribute = fieldInfo.GetCustomAttribute<PreferenceAttribute>();
		if (customAttribute == null)
		{
			throw new Exception(string.Format("Preference {0} doesn't have a {1}. Getting the default value from attribute is not possible.", p, "PreferenceAttribute"));
		}
		if (exclusivity != PreferencesExclusivity.VR)
		{
			return customAttribute.DefaultValueNonVR;
		}
		return customAttribute.DefaultValueVR;
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
		PreferenceValueUpdateTracker preferenceValueUpdateTracker = preferencesUpdateEvents[(int)p];
		if (preferenceValueUpdateTracker != null)
		{
			preferenceValueUpdateTracker.Updated += callback;
		}
		else
		{
			Debug.LogError(string.Format("Couldn't find {0} for preference {1}. Event subscription failed.", "PreferenceValueUpdateTracker", p));
		}
	}

	public void UnregisterValueUpdatedReceiver(Preferences p, Action callback)
	{
		PreferenceValueUpdateTracker preferenceValueUpdateTracker = preferencesUpdateEvents[(int)p];
		if (preferenceValueUpdateTracker != null)
		{
			preferenceValueUpdateTracker.Updated -= callback;
		}
		else
		{
			Debug.LogError(string.Format("Couldn't find {0} for preference {1}. Event unsubscription failed.", "PreferenceValueUpdateTracker", p));
		}
	}
}
