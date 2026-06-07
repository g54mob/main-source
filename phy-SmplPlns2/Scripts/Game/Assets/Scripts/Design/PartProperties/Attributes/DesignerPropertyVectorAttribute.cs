using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyVectorAttribute : DesignerPropertyAttribute
	{
		public bool AllowManualEntry { get; set; }

		public float ButtonRepeatDelay { get; set; }

		public float ButtonRepeatTime { get; set; }

		public bool ManualEntryIgnoresRange { get; set; }

		public decimal MaxValue { get; set; }

		public decimal MinValue { get; set; }

		public decimal StepValue { get; set; }

		public bool UseInlineLabel { get; set; }

		public DesignerPropertyVectorAttribute(decimal stepValue, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
		{
			StepValue = stepValue;
			MinValue = minValue;
			MaxValue = maxValue;
			AllowManualEntry = true;
			ManualEntryIgnoresRange = false;
			UseInlineLabel = true;
			ButtonRepeatDelay = 0f;
			ButtonRepeatTime = 0f;
		}

		public DesignerPropertyVectorAttribute(float stepValue, float minValue = -7.922816E+28f, float maxValue = 7.922816E+28f)
			: this((decimal)stepValue, (decimal)minValue, (decimal)maxValue)
		{
		}

		public DesignerPropertyVectorAttribute(double stepValue, double minValue = -7.922816251426433E+28, double maxValue = 7.922816251426433E+28)
			: this((decimal)stepValue, (decimal)minValue, (decimal)maxValue)
		{
		}

		public DesignerPropertyVectorAttribute(int stepValue, int minValue = int.MinValue, int maxValue = int.MaxValue)
			: this((decimal)stepValue, (decimal)minValue, (decimal)maxValue)
		{
		}
	}
}
