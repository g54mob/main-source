using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ExclusiveMinimumAttribute : Attribute
	{
		public ExclusiveMinimumAttribute(float min)
		{
		}
	}
}
