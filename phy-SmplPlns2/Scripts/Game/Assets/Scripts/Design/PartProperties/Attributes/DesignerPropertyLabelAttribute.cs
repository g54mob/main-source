using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyLabelAttribute : DesignerPropertyAttribute
	{
		public enum LabelType
		{
			LabelOnly = 0,
			LabelAndValue = 1
		}

		public LabelType Type { get; set; }
	}
}
