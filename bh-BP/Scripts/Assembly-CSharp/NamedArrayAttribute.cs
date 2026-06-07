using System;
using UnityEngine;

public class NamedArrayAttribute : PropertyAttribute
{
	public Type TargetEnum;

	public NamedArrayAttribute(Type TargetEnum)
	{
	}
}
