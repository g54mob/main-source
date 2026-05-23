using System;

namespace NJsonSchema.Annotations
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue)]
	public class CanBeNullAttribute : Attribute
	{
	}
}
