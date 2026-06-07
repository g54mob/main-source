using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MaxLengthAttribute : Attribute
	{
		public MaxLengthAttribute(int maxLength)
		{
		}
	}
}
