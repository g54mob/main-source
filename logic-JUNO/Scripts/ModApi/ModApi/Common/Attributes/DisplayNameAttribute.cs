using System;

namespace ModApi.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DisplayNameAttribute : Attribute
	{
		public string DisplayName { get; private set; }

		public DisplayNameAttribute(string displayName)
		{
			DisplayName = displayName;
		}
	}
}
