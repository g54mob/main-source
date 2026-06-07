using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class DoNotSerializeAttribute : Attribute
	{
	}
}
