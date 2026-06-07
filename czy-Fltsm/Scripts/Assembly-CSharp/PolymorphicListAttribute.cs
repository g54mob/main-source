using System;
using UnityEngine;

public class PolymorphicListAttribute : PropertyAttribute
{
	public string ListProperty;

	public Type ListType;

	public string Label;

	public PolymorphicListAttribute(string listProperty, Type listType, string label = "task")
	{
		ListProperty = listProperty;
		ListType = listType;
		Label = label;
	}
}
