using System;

public class BlnPrefAttribute : PreferenceAttribute
{
	public override Type PreferenceType => typeof(bool);

	public BlnPrefAttribute(bool valueVR, bool valueNonVR, PreferenceCategory category, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any)
	{
		Initialize(valueVR, valueNonVR, category, exclusiveTo);
	}

	public BlnPrefAttribute(bool value, PreferenceCategory category, PreferencesExclusivity exclusiveTo)
	{
		Initialize(value, category, exclusiveTo);
	}
}
