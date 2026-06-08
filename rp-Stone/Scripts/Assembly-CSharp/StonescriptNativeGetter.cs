using System;

[AttributeUsage(AttributeTargets.Method)]
public class StonescriptNativeGetter : Attribute
{
	public string name;

	public StonescriptNativeGetter()
	{
	}

	public StonescriptNativeGetter(string name)
	{
		this.name = name;
	}
}
