using System;

namespace FullSerializerSave
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class fsIgnoreAttribute : Attribute
	{
	}
}
