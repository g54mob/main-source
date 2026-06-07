using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertySpinnerAttribute : DesignerPropertyAttribute
	{
		public bool AllowManualEntry { get; set; }

		public int ExtraWidth { get; set; }

		public bool ManualEntryIgnoresRange { get; set; }

		public decimal MaxValue { get; set; }

		public decimal MinValue { get; set; }

		public bool ShrinkText { get; set; }

		public decimal StepSize { get; set; }

		public bool WrapText { get; set; }

		public DesignerPropertySpinnerAttribute()
			: this(-10m, 10m, 1m)
		{
		}

		public DesignerPropertySpinnerAttribute(double min, double max, double stepSize)
			: this((decimal)min, (decimal)max, (decimal)stepSize)
		{
		}

		public DesignerPropertySpinnerAttribute(float min, float max, float stepSize)
			: this((decimal)min, (decimal)max, (decimal)stepSize)
		{
		}

		protected DesignerPropertySpinnerAttribute(decimal min, decimal max, decimal stepSize)
		{
			MinValue = min;
			MaxValue = max;
			StepSize = stepSize;
		}
	}
}
