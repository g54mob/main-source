using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DefaultAttribute : Attribute
	{
		public DefaultAttribute(int defaultValue)
		{
		}

		public DefaultAttribute(float defaultValue)
		{
		}

		public DefaultAttribute(bool defaultValue)
		{
		}

		public DefaultAttribute(string defaultValue)
		{
		}
	}
}
