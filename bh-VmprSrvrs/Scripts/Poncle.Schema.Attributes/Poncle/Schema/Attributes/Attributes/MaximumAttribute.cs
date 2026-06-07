using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MaximumAttribute : Attribute
	{
		public MaximumAttribute(float max)
		{
		}
	}
}
