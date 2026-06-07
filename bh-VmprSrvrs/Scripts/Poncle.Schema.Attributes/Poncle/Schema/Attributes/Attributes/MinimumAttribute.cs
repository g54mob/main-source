using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MinimumAttribute : Attribute
	{
		public MinimumAttribute(float min)
		{
		}
	}
}
