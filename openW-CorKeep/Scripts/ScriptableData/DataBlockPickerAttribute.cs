using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field)]
public class DataBlockPickerAttribute : PropertyAttribute
{
	public DataBlockPickerAttribute(DataBlockPickerType type)
	{
	}
}
