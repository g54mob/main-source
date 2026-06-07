using System;

public class FltPrefAttribute : PreferenceAttribute
{
	public override Type PreferenceType => typeof(float);

	public FltPrefAttribute(float valueVR, float valueNonVR, PreferenceCategory category, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any)
	{
		Initialize(valueVR, valueNonVR, category, exclusiveTo);
	}

	public FltPrefAttribute(float value, PreferenceCategory category, PreferencesExclusivity exclusiveTo)
	{
		Initialize(value, category, exclusiveTo);
	}
}
