using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorDelayedAttribute : Attribute
	{
	}
}
