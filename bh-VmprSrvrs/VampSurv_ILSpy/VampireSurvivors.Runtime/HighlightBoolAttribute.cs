using System;

public class HighlightBoolAttribute(bool readOnlyInline = false) : Attribute
{
	public bool ReadOnlyInline = readOnlyInline;
}
