using System;
using Poncle.Schema.Attributes.Types;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class FormatAttribute : Attribute
	{
		public FormatAttribute(FormatType format)
		{
		}
	}
}
