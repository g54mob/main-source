using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyCustomWidgetAttribute : DesignerPropertyAttribute
	{
		public string WidgetTemplate { get; set; }

		public DesignerPropertyCustomWidgetAttribute()
		{
			base.SupportsLists = false;
		}
	}
}
