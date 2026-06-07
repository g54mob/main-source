using System;

[AttributeUsage(AttributeTargets.Class)]
public class AllowScopeListAttribute : Attribute
{
	public bool Allow = true;
}
