using System;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DesignerPropertySliderAttribute : DesignerPropertyAttribute
	{
		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public int NumberOfSteps { get; set; }

		public string TechTreeIdForMaxValue { get; set; }

		public DesignerPropertySliderAttribute()
			: this(0f, 1f, 11, null)
		{
		}

		public DesignerPropertySliderAttribute(float min, float max, int numberOfSteps)
			: this(min, max, numberOfSteps, null)
		{
		}

		public DesignerPropertySliderAttribute(float min, float max, int numberOfSteps, string techTreeIdForMaxValue)
		{
			MinValue = min;
			MaxValue = max;
			NumberOfSteps = numberOfSteps;
			TechTreeIdForMaxValue = techTreeIdForMaxValue;
		}
	}
}
