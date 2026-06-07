using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

[ExecutionOrder(-25)]
public class GamePreferences : SingletonBehaviour<GamePreferences>
{
	public bool useMock;

	public APreferencesProvider provider;

	private static IPreferencesStore preferencesStore;

	private static IPreferencesPersistence preferencesPersistence;

	public bool IsDirty => preferencesStore.IsDirty;

	public static void RegisterToUpdateIfEligible(Preferences p, Action callback, bool on)
	{
		if (!PreferencesUtils.IsExcluded(p))
		{
			if (on)
			{
				preferencesStore.RegisterValueUpdatedReceiver(p, callback);
			}
			else
			{
				preferencesStore.UnregisterValueUpdatedReceiver(p, callback);
			}
		}
	}

	public static void RegisterToPreferenceUpdated(Preferences p, Action callback)
	{
		preferencesStore.RegisterValueUpdatedReceiver(p, callback);
	}

	public static void UnregisterFromPreferenceUpdated(Preferences p, Action callback)
	{
		preferencesStore.UnregisterValueUpdatedReceiver(p, callback);
	}

	public static T Get<T>(Preferences p)
	{
		return preferencesStore.Get<T>(p);
	}

	public static void Set<T>(Preferences p, T value)
	{
		if (typeof(Enum).IsAssignableFrom(typeof(T)))
		{
			PreferencesUtils.SetEnumPreference(p, value as Enum);
		}
		else
		{
			preferencesStore.Set(p, value);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!useMock)
		{
			PreferencesStore preferencesStore = new PreferencesStore(PreferencesExclusivity.VR);
			PreferencesStore preferencesStore2 = new PreferencesStore(PreferencesExclusivity.NonVR);
			object[] array = preferencesStore.RequestAllPreferences();
			object[] array2 = preferencesStore2.RequestAllPreferences();
			if (array.Length == 0 || array2.Length == 0)
			{
				Debug.LogError("'GamePreferences' could not load defaults. Upgrading skipped.");
			}
			else
			{
				PreferencesPersistence vrPersistence = new PreferencesPersistence(preferencesStore, PreferencesExclusivity.VR, provider);
				PreferencesPersistence nonVrPersistence = new PreferencesPersistence(preferencesStore2, PreferencesExclusivity.NonVR, provider);
				provider.UpgradePreferences(preferencesStore, vrPersistence, preferencesStore2, nonVrPersistence);
			}
		}
		ChoosePreferencesStrategy();
	}

	private void ChoosePreferencesStrategy()
	{
		if (PreferencesUtils.CurrentExclusivity == PreferencesExclusivity.Any)
		{
			PreferencesUtils.SetExclusivity(provider.GetExclusivity());
		}
		if (useMock)
		{
			Debug.Log("GamePreferences setting up for mock");
			preferencesStore = new MockPreferencesStore(PreferencesUtils.CurrentExclusivity);
			preferencesPersistence = new MockPreferencePersistence(preferencesStore, PreferencesUtils.CurrentExclusivity);
		}
		else
		{
			preferencesStore = new PreferencesStore(PreferencesUtils.CurrentExclusivity);
			preferencesPersistence = new PreferencesPersistence(preferencesStore, PreferencesUtils.CurrentExclusivity, provider);
		}
		ReadAndWritePreferences();
	}

	private void ReadAndWritePreferences()
	{
		preferencesPersistence.ReadPreferences();
		preferencesPersistence.WritePreferences();
		preferencesStore.IsDirty = false;
	}

	public static void SavePreferences()
	{
		preferencesPersistence.WritePreferences();
		preferencesStore.IsDirty = false;
	}

	public static void LoadPreferences()
	{
		preferencesPersistence.ReadPreferences();
	}

	public Dictionary<Preferences, Type> GetEnumerablePreferencesMapping()
	{
		return provider.GetEnumerablePreferencesMapping();
	}
}
