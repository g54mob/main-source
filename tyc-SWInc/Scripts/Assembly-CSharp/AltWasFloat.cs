using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class AltWasFloat : Attribute
{
	public int Version;

	public AltWasFloat(int version = 0)
	{
		Version = version;
	}
}
