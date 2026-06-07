using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class TypeAttribute : Attribute
	{
		public TypeAttribute(params Type[] types)
		{
		}
	}
}
