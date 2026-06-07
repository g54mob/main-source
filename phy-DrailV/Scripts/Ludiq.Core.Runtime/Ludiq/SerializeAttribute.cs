using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class SerializeAttribute : Attribute
	{
	}
}
