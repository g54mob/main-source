using System;

[AttributeUsage(AttributeTargets.Method)]
public class StonescriptNativeSetter : Attribute
{
	public string name;

	public StonescriptNativeSetter()
	{
	}

	public StonescriptNativeSetter(string name)
	{
		this.name = name;
	}
}
