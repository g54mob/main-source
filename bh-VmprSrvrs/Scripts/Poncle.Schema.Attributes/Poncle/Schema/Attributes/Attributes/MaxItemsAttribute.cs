using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MaxItemsAttribute : Attribute
	{
		public MaxItemsAttribute(int max)
		{
		}
	}
}
