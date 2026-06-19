using System;

[AttributeUsage(AttributeTargets.Field)]
public class ScriptableDataDefaultHeaderAttribute : Attribute
{
	public string Header;

	public ScriptableDataDefaultHeaderAttribute(string header)
	{
		Header = header;
	}
}
