using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AltDeprecate : Attribute
{
	public string Name;

	public Type type;

	public AltDeprecate(string name, Type type)
	{
		Name = name;
		this.type = type;
	}
}
