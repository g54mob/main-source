public abstract class InGameDevToolNumericParameter<ParamType, DerivedType> : InGameDevToolParameter<ParamType, DerivedType> where DerivedType : InGameDevToolNumericParameter<ParamType, DerivedType>
{
	public bool HasMinimumValue { get; protected set; }

	public ParamType MinimumValue { get; protected set; }

	public bool HasMaximumValue { get; protected set; }

	public ParamType MaximumValue { get; protected set; }

	public DerivedType SetMinimumValue(ParamType minimumValue)
	{
		HasMinimumValue = true;
		MinimumValue = minimumValue;
		return (DerivedType)this;
	}

	public DerivedType SetMaximumValue(ParamType maximumValue)
	{
		HasMaximumValue = true;
		MaximumValue = maximumValue;
		return (DerivedType)this;
	}

	protected InGameDevToolNumericParameter(InGameDevToolParameterType typeOfParameter)
		: base(typeOfParameter)
	{
		HasMinimumValue = false;
		HasMaximumValue = false;
	}
}
