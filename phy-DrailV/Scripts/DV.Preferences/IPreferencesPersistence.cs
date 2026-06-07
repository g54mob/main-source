public interface IPreferencesPersistence
{
	int WrittenPreferencesVersion { get; }

	bool ReadPreferences();

	void WritePreferences();

	void PurgeWrittenPreferences();

	void CreateBackupFile(string fileSuffix);

	string GetIncompatiblePreferenceRawValue(string key);

	void DeleteIncompatiblePreference(string key);

	bool LoadedAsDefaultValue(Preferences preference);
}
