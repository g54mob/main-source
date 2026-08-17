using System;

public class ToggleBoolButtonAttribute : Attribute
{
	public float Width;

	public ToggleBoolButtonAttribute()
	{
		Width = -1f;
	}

	public ToggleBoolButtonAttribute(float width)
	{
		Width = width;
	}
}
