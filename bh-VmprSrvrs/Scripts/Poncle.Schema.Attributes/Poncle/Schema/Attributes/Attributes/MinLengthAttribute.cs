using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MinLengthAttribute : Attribute
	{
		public MinLengthAttribute(int minLength)
		{
		}
	}
}
