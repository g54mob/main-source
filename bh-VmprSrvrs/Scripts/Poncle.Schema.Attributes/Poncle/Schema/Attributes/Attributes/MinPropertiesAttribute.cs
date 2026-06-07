using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MinPropertiesAttribute : Attribute
	{
		public MinPropertiesAttribute(int min)
		{
		}
	}
}
