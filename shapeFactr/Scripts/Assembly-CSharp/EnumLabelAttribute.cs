using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class EnumLabelAttribute : PropertyAttribute
{
	public string[] EnumNames { get; private set; }

	public EnumLabelAttribute(Type enumType)
	{
	}
}
