using System;
using System.Collections.Generic;
using DV.ThingTypes;
using IniParser.Model;

public abstract class APreferencesCustomizer
{
	protected const string TRUE = "True";

	protected const string FALSE = "False";

	public abstract void Customize(PreferencesPersistence persistence, IniData data, PreferencesExclusivity currentExclusivity);

	protected void Set(PreferencesPersistence persistence, IniData data, Preferences preference, string value, PreferencesExclusivity exclusivity)
	{
		persistence.WriteCustomizedPreference(preference, value, exclusivity, data);
	}

	protected void ApplyPreset(PreferencesPersistence persistence, SettingsPreset preset, IniData data, PreferencesExclusivity exclusivity)
	{
		foreach (KeyValuePair<string, object> value in preset.Values)
		{
			if (Enum.TryParse<Preferences>(value.Key, out var result))
			{
				Set(persistence, data, result, value.Value.ToString(), exclusivity);
			}
		}
	}
}
