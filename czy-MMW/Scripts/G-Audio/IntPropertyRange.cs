using System;

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
public class IntPropertyRange : Attribute
{
	public int Min { get; protected set; }

	public int Max { get; protected set; }

	public IntPropertyRange(int min, int max)
	{
		Min = min;
		Max = max;
	}
}
