using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class APreferencesProvider : MonoBehaviour
{
	protected const string OLD_PREFERENCES_SUFFIX = "_old_version";

	public static event Action PreferencesUpgraded;

	public static event Action PreferencesPurged;

	public abstract PreferencesExclusivity GetExclusivity();

	public abstract APreferencesCustomizer[] GetCustomizers();

	public abstract Dictionary<Preferences, Type> GetEnumerablePreferencesMapping();

	protected void PreferencesUpgraded_Fire()
	{
		APreferencesProvider.PreferencesUpgraded?.Invoke();
	}

	protected void PreferencesPurged_Fire()
	{
		APreferencesProvider.PreferencesPurged?.Invoke();
	}

	public abstract bool UpgradePreferences(PreferencesStore vrStore, PreferencesPersistence vrPersistence, PreferencesStore nonVrStore, PreferencesPersistence nonVrPersistence);
}
