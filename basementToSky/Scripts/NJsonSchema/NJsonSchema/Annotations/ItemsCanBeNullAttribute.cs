using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public class ItemsCanBeNullAttribute : Attribute
	{
	}
}
