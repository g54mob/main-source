using System;

[AttributeUsage(AttributeTargets.Method)]
public class StonescriptNativeMethod : Attribute
{
	public string name;

	public StonescriptNativeMethod()
	{
	}

	public StonescriptNativeMethod(string name)
	{
		this.name = name;
	}
}
