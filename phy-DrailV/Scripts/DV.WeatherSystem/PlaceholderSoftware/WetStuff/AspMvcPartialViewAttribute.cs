using System;

namespace PlaceholderSoftware.WetStuff
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
	public sealed class AspMvcPartialViewAttribute : Attribute
	{
	}
}
