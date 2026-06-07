using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MaxPropertiesAttribute : Attribute
	{
		public MaxPropertiesAttribute(int max)
		{
		}
	}
}
