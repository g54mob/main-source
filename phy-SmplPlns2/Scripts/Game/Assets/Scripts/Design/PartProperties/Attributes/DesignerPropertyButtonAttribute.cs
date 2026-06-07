using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyButtonAttribute : DesignerPropertyAttribute
	{
		public ButtonStyle Style { get; set; }

		public DesignerPropertyButtonAttribute()
		{
			base.PreserveState = false;
		}
	}
}
