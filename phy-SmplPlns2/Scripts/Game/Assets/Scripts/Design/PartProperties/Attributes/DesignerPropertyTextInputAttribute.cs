using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyTextInputAttribute : DesignerPropertyAttribute
	{
		public int ExtraWidth { get; set; }

		public bool SupportsInputDialog { get; set; }

		public DesignerPropertyTextInputAttribute()
			: this(supportsInputDialog: false)
		{
		}

		public DesignerPropertyTextInputAttribute(bool supportsInputDialog)
		{
			SupportsInputDialog = supportsInputDialog;
		}
	}
}
