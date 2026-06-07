using System;
using System.Collections.Generic;
using System.Reflection;

public class IngameDevToolEnumParameter<EnumType> : InGameDevToolParameter<EnumType, IngameDevToolEnumParameter<EnumType>>, IInGameDevToolEnumParameter where EnumType : struct
{
	protected List<Enum> allowedValues;

	public string ParameterSerializationValue
	{
		get
		{
			return base.ParameterValue.ToString();
		}
		set
		{
			if (Enum.TryParse<EnumType>(value, out var result))
			{
				base.ParameterValue = result;
			}
		}
	}

	public string ParameterSerializationDefaultValue
	{
		get
		{
			return base.DefaultValue.ToString();
		}
		set
		{
			if (Enum.TryParse<EnumType>(value, out var result))
			{
				base.DefaultValue = result;
			}
		}
	}

	public IngameDevToolEnumParameter<EnumType> SetAllowedValues(List<EnumType> valuesToAllow)
	{
		allowedValues = new List<Enum>();
		foreach (EnumType item2 in valuesToAllow)
		{
			Enum item = (Enum)(object)item2;
			if (!allowedValues.Contains(item))
			{
				allowedValues.Add(item);
			}
		}
		return this;
	}

	public static IngameDevToolEnumParameter<EnumType> DefineEnumParameter(string withParameterName)
	{
		return new IngameDevToolEnumParameter<EnumType>().SetParameterName(withParameterName);
	}

	public IngameDevToolEnumParameter()
		: base(InGameDevToolParameterType.Enum)
	{
	}

	public void UpdateParameterValueFromModelField<ModelType>(ModelType modelInstance)
	{
		FieldInfo field = typeof(ModelType).GetField(base.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field != null)
		{
			EnumType value = (EnumType)field.GetValue(modelInstance);
			SetValue(value);
			return;
		}
		PropertyInfo property = typeof(ModelType).GetProperty(base.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (Diagnostics.Verify(property != null))
		{
			EnumType value2 = (EnumType)property.GetValue(modelInstance);
			SetValue(value2);
		}
	}

	public void UpdateModelFieldFromParameterValue<ModelType>(ModelType modelInstance)
	{
		if (string.IsNullOrEmpty(base.ModelParameterFieldName))
		{
			return;
		}
		FieldInfo field = typeof(ModelType).GetField(base.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field != null)
		{
			field.SetValue(modelInstance, base.ParameterValue);
			return;
		}
		PropertyInfo property = typeof(ModelType).GetProperty(base.ModelParameterFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (Diagnostics.Verify(property != null))
		{
			property.SetValue(modelInstance, base.ParameterValue);
		}
	}
}
