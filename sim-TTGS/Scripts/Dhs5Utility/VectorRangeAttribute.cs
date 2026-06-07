using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class VectorRangeAttribute : PropertyAttribute
{
	public readonly float min;

	public readonly float max;

	public VectorRangeAttribute(float min, float max)
	{
		this.min = min;
		this.max = Mathf.Max(min, max);
	}
}
