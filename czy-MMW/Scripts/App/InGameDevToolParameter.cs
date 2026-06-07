using System;
using System.Collections.Generic;

public abstract class InGameDevToolParameter<ParamType, DerivedType> where DerivedType : InGameDevToolParameter<ParamType, DerivedType>
{
	protected class ConditionallyShowOnBool
	{
		public string boolParameterName;

		public bool valueToMatch;
	}

	protected class ConditionallyShowOnEnum
	{
		public string enumParameterName;

		public string valueToMatch;
	}

	protected class ConditionallyShowOnFeature
	{
		public Feature featureToCheck;

		public bool valueToMatch;
	}

	protected List<ConditionallyShowOnBool> conditionallyShowOnBools = new List<ConditionallyShowOnBool>();

	protected List<ConditionallyShowOnEnum> conditionallyShowOnEnums = new List<ConditionallyShowOnEnum>();

	protected List<ConditionallyShowOnFeature> conditionallyShowOnFeatures = new List<ConditionallyShowOnFeature>();

	public InGameDevToolParameterType TypeOfParameter { get; protected set; }

	public string ParameterName { get; protected set; }

	public string ModelParameterFieldName { get; protected set; }

	public string ParameterEditorDisplayName { get; protected set; }

	public string ParameterEditorTooltip { get; protected set; }

	public ParamType ParameterValue { get; protected set; }

	public ParamType DefaultValue { get; protected set; }

	public bool ShouldSetValueOnField { get; protected set; }

	public DerivedType SetParameterName(string parameterName)
	{
		ParameterName = parameterName;
		return (DerivedType)this;
	}

	public DerivedType SetModelParameterFieldName(string modelParameterFieldName)
	{
		ModelParameterFieldName = modelParameterFieldName;
		return (DerivedType)this;
	}

	public DerivedType SetEditorDisplayName(string editorDisplayName)
	{
		ParameterEditorDisplayName = editorDisplayName;
		return (DerivedType)this;
	}

	public DerivedType SetEditorTooltip(string editorTooltip)
	{
		ParameterEditorTooltip = editorTooltip;
		return (DerivedType)this;
	}

	public DerivedType SetValue(ParamType newValue)
	{
		ParameterValue = newValue;
		return (DerivedType)this;
	}

	public DerivedType SetDefaultValueForHotkey(ParamType newValue)
	{
		DefaultValue = newValue;
		return (DerivedType)this;
	}

	public DerivedType ShowConditionallyOnBool(string boolParameterNameToCheck, bool valueToCheck)
	{
		conditionallyShowOnBools.Add(new ConditionallyShowOnBool
		{
			boolParameterName = boolParameterNameToCheck,
			valueToMatch = valueToCheck
		});
		return (DerivedType)this;
	}

	public DerivedType ShowConditionallyOnEnum(string enumParameterNameToCheck, Enum valueToCheck)
	{
		conditionallyShowOnEnums.Add(new ConditionallyShowOnEnum
		{
			enumParameterName = enumParameterNameToCheck,
			valueToMatch = valueToCheck.ToString()
		});
		return (DerivedType)this;
	}

	public DerivedType ShowConditionallyOnFeature(Feature featureToCompare, bool valueToCheck)
	{
		conditionallyShowOnFeatures.Add(new ConditionallyShowOnFeature
		{
			featureToCheck = featureToCompare,
			valueToMatch = valueToCheck
		});
		return (DerivedType)this;
	}

	public DerivedType DontSetValueOnApply()
	{
		ShouldSetValueOnField = false;
		return (DerivedType)this;
	}

	protected InGameDevToolParameter(InGameDevToolParameterType typeOfParameter)
	{
		TypeOfParameter = typeOfParameter;
		ShouldSetValueOnField = true;
	}
}
