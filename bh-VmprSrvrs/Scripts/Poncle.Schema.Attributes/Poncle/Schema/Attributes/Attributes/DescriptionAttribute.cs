using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
	public class DescriptionAttribute : Attribute
	{
		public DescriptionAttribute(string description)
		{
		}
	}
}
