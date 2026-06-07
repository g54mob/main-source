using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ExclusiveMaximumAttribute : Attribute
	{
		public ExclusiveMaximumAttribute(float max)
		{
		}
	}
}
