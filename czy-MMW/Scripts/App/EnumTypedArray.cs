using System;
using UnityEngine;

public class EnumTypedArray : PropertyAttribute
{
	public Type TargetEnum;

	public EnumTypedArray(Type TargetEnum)
	{
		this.TargetEnum = TargetEnum;
	}
}
