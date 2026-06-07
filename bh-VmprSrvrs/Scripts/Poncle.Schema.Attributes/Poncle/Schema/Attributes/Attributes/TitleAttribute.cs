using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
	public class TitleAttribute : Attribute
	{
		public TitleAttribute(string title)
		{
		}
	}
}
