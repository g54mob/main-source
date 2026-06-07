using System;

public class IntPrefAttribute : PreferenceAttribute
{
	public override Type PreferenceType => typeof(int);

	public IntPrefAttribute(int valueVR, int valueNonVR, PreferenceCategory category, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any)
	{
		Initialize(valueVR, valueNonVR, category, exclusiveTo);
	}

	public IntPrefAttribute(int value, PreferenceCategory category, PreferencesExclusivity exclusiveTo)
	{
		Initialize(value, category, exclusiveTo);
	}
}
