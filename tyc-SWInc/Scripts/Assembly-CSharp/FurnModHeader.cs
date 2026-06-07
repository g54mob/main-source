using System;

[AttributeUsage(AttributeTargets.Field)]
public class FurnModHeader : Attribute
{
	public string Header;

	public FurnModHeader(string header)
	{
		Header = header;
	}
}
