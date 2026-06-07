using System;

namespace Ludiq.FullSerializer
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class fsIgnoreAttribute : Attribute
	{
	}
}
