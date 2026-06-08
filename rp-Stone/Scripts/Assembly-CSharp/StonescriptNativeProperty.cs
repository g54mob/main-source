using System;

[AttributeUsage(AttributeTargets.Property)]
public class StonescriptNativeProperty : Attribute
{
	public string name;

	public StonescriptNativeProperty()
	{
	}

	public StonescriptNativeProperty(string name)
	{
		this.name = name;
	}
}
