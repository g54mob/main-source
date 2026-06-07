using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
	public class DeprecatedAttribute : Attribute
	{
		public DeprecatedAttribute(bool deprecated = true)
		{
		}
	}
}
