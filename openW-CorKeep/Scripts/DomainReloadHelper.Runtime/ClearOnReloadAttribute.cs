using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event)]
public class ClearOnReloadAttribute : Attribute
{
	public readonly object valueToAssign;

	public readonly bool assignNewTypeInstance;

	public ClearOnReloadAttribute()
	{
		valueToAssign = null;
		assignNewTypeInstance = false;
	}

	public ClearOnReloadAttribute(object valueToAssign)
	{
		this.valueToAssign = valueToAssign;
		assignNewTypeInstance = false;
	}

	public ClearOnReloadAttribute(bool assignNewTypeInstance = false)
	{
		valueToAssign = null;
		this.assignNewTypeInstance = assignNewTypeInstance;
	}
}
