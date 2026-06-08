using System;

namespace MessagePack
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class AutoUnionAttribute : Attribute
	{
	}
}
