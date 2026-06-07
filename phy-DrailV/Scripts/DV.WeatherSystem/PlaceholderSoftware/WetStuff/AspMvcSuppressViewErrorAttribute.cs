using System;

namespace PlaceholderSoftware.WetStuff
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class AspMvcSuppressViewErrorAttribute : Attribute
	{
	}
}
