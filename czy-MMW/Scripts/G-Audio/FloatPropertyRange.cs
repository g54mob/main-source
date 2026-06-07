using System;

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
public class FloatPropertyRange : Attribute
{
	public float Min { get; protected set; }

	public float Max { get; protected set; }

	public FloatPropertyRange(float min, float max)
	{
		Min = min;
		Max = max;
	}
}
