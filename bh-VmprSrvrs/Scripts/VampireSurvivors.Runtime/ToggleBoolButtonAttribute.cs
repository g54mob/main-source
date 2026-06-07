using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ToggleBoolButtonAttribute : Attribute
{
	public float Width;

	public ToggleBoolButtonAttribute()
	{
	}

	public ToggleBoolButtonAttribute(float width)
	{
	}
}
