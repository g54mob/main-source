using System;

namespace MemoryPack
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class SuppressDefaultInitializationAttribute : Attribute
	{
	}
}
