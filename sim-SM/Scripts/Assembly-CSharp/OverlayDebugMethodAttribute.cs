using System;

public class OverlayDebugMethodAttribute : Attribute
{
	public readonly string CategoryName;

	public readonly int Priority;

	public OverlayDebugMethodAttribute(string categoryName, int priority = 0)
	{
	}
}
