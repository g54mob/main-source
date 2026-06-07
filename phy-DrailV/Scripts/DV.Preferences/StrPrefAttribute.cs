using System;

public class StrPrefAttribute : PreferenceAttribute
{
	public override Type PreferenceType => typeof(string);

	public StrPrefAttribute(string valueVR, string valueNonVR, PreferenceCategory category, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any)
	{
		Initialize(valueVR, valueNonVR, category, exclusiveTo);
	}

	public StrPrefAttribute(string value, PreferenceCategory category, PreferencesExclusivity exclusiveTo)
	{
		Initialize(value, category, exclusiveTo);
	}
}
