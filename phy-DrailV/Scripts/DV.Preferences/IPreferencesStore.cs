using System;

public interface IPreferencesStore
{
	bool IsDirty { get; set; }

	T Get<T>(Preferences preferences);

	void Set<T>(Preferences preferences, T value);

	void RegisterValueUpdatedReceiver(Preferences p, Action callback);

	void UnregisterValueUpdatedReceiver(Preferences p, Action callback);

	void ResetPreferencesToDefault();

	void OverridePreferencesExternally(object[] overrideCollection);

	object[] RequestAllPreferences();
}
