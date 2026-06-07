using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ReadOnlyAttribute : Attribute
	{
		public ReadOnlyAttribute(bool readOnly = true)
		{
		}
	}
}
