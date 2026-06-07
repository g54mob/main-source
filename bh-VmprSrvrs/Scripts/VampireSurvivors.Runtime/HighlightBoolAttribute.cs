using System;

public class HighlightBoolAttribute : Attribute
{
	public bool ReadOnlyInline;

	public HighlightBoolAttribute(bool readOnlyInline = false)
	{
	}
}
