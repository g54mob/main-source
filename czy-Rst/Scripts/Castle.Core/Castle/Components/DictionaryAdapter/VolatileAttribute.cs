using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false)]
	public class VolatileAttribute : Attribute
	{
	}
}
