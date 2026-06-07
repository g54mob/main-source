using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
	public string ConditionalSourceField = "";

	public string ConditionalSourceField2 = "";

	public string[] ConditionalSourceFields = new string[0];

	public bool[] ConditionalSourceFieldInverseBools = new bool[0];

	public bool HideInInspector;

	public bool Inverse;

	public bool UseOrLogic;

	public bool InverseCondition1;

	public bool InverseCondition2;

	public ConditionalHideAttribute(string conditionalSourceField)
	{
		ConditionalSourceField = conditionalSourceField;
		HideInInspector = false;
		Inverse = false;
	}

	public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
	{
		ConditionalSourceField = conditionalSourceField;
		HideInInspector = hideInInspector;
		Inverse = false;
	}

	public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector, bool inverse)
	{
		ConditionalSourceField = conditionalSourceField;
		HideInInspector = hideInInspector;
		Inverse = inverse;
	}

	public ConditionalHideAttribute(bool hideInInspector = false)
	{
		ConditionalSourceField = "";
		HideInInspector = hideInInspector;
		Inverse = false;
	}

	public ConditionalHideAttribute(string[] conditionalSourceFields, bool[] conditionalSourceFieldInverseBools, bool hideInInspector, bool inverse)
	{
		ConditionalSourceFields = conditionalSourceFields;
		ConditionalSourceFieldInverseBools = conditionalSourceFieldInverseBools;
		HideInInspector = hideInInspector;
		Inverse = inverse;
	}

	public ConditionalHideAttribute(string[] conditionalSourceFields, bool hideInInspector, bool inverse)
	{
		ConditionalSourceFields = conditionalSourceFields;
		HideInInspector = hideInInspector;
		Inverse = inverse;
	}
}
