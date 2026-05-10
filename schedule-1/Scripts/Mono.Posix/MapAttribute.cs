using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Delegate)]
internal class MapAttribute : Attribute
{
	private string nativeType;

	public MapAttribute()
	{
	}

	public MapAttribute(string nativeType)
	{
	}
}
