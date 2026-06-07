using System;

namespace Jundroo.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class UiVisibilityAttribute : Attribute
	{
		public UiVisibility Visibility { get; }

		public UiVisibilityAttribute(UiVisibility visibility = UiVisibility.Visible)
		{
			Visibility = visibility;
		}
	}
}
