using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class WriteOnlyAttribute : Attribute
	{
		public WriteOnlyAttribute(bool writeOnly = true)
		{
		}
	}
}
