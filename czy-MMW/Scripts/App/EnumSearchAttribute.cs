using System;
using UnityEngine;

public class EnumSearchAttribute : PropertyAttribute
{
	public Type enumType;

	public bool isString;

	public EnumSearchAttribute(Type enumType, bool isString = false)
	{
		this.enumType = enumType;
		this.isString = isString;
	}
}
