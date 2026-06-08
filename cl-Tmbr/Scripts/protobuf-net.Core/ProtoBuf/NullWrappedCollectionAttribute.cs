using System;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class NullWrappedCollectionAttribute : Attribute
	{
		public bool AsGroup { get; set; }
	}
}
