using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MultipleOfAttribute : Attribute
	{
		public MultipleOfAttribute(float mult)
		{
		}
	}
}
