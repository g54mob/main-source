using System;

namespace PlaceholderSoftware.WetStuff
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	public sealed class NoReorderAttribute : Attribute
	{
	}
}
