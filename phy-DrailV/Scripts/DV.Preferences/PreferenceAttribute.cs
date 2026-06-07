using System;

[AttributeUsage(AttributeTargets.Field)]
public abstract class PreferenceAttribute : Attribute
{
	protected object defaultValueVR;

	protected object defaultValueNonVR;

	protected PreferenceCategory category;

	protected PreferencesExclusivity exclusiveTo;

	public abstract Type PreferenceType { get; }

	public PreferencesExclusivity ExclusiveTo => exclusiveTo;

	public PreferenceCategory Category => category;

	public object DefaultValueVR => defaultValueVR;

	public object DefaultValueNonVR => defaultValueNonVR;

	protected void Initialize(object valueVR, object valueNonVR, PreferenceCategory category, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any)
	{
		this.exclusiveTo = exclusiveTo;
		this.category = category;
		defaultValueVR = valueVR;
		defaultValueNonVR = valueNonVR;
	}

	protected void Initialize(object value, PreferenceCategory category, PreferencesExclusivity exclusiveTo)
	{
		this.exclusiveTo = exclusiveTo;
		this.category = category;
		switch (exclusiveTo)
		{
		case PreferencesExclusivity.NonVR:
			defaultValueNonVR = value;
			break;
		case PreferencesExclusivity.VR:
			defaultValueVR = value;
			break;
		case PreferencesExclusivity.Any:
			defaultValueNonVR = value;
			defaultValueVR = value;
			break;
		}
	}
}
