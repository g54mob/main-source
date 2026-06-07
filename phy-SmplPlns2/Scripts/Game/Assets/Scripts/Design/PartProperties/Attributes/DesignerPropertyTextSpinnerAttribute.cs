using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyTextSpinnerAttribute : DesignerPropertyAttribute
	{
		public bool AllowManualEntry { get; set; }

		public int ExtraWidth { get; set; }

		public bool ShrinkText { get; set; }

		public string[] Values { get; }

		public bool WrapText { get; set; }

		public DesignerPropertyTextSpinnerAttribute(params string[] values)
		{
			Values = values;
		}
	}
}
