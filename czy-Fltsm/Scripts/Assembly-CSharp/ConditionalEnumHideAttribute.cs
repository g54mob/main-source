using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class ConditionalEnumHideAttribute : PropertyAttribute
{
	public string ConditionalSourceField = "";

	public string NestedField = "";

	public int EnumValue1;

	public int EnumValue2;

	public bool Flags;

	public bool HideInInspector;

	public bool Inverse;

	public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1, bool hideInInspector = false)
	{
		ConditionalSourceField = conditionalSourceField;
		EnumValue1 = enumValue1;
		EnumValue2 = enumValue1;
		HideInInspector = hideInInspector;
	}

	public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1, int enumValue2, bool hideInInspector = false)
	{
		ConditionalSourceField = conditionalSourceField;
		EnumValue1 = enumValue1;
		EnumValue2 = enumValue2;
		HideInInspector = hideInInspector;
	}
}
