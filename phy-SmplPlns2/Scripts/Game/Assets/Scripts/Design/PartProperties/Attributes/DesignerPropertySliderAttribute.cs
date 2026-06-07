using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertySliderAttribute : DesignerPropertyAttribute
	{
		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public int NumberOfSteps { get; set; }

		public DesignerPropertySliderAttribute()
			: this(0f, 1f, 11)
		{
		}

		public DesignerPropertySliderAttribute(float min, float max, int numberOfSteps)
		{
			MinValue = min;
			MaxValue = max;
			NumberOfSteps = numberOfSteps;
		}
	}
}
