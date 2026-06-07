using System;
using UnityEngine;

public class StringEnumSearchAttribute : PropertyAttribute
{
	public Type enumType;

	public StringEnumSearchAttribute(Type enumType)
	{
		this.enumType = enumType;
	}
}
