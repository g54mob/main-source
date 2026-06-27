using System;

namespace Mandragora.Utils
{
	public class VectorSliderAttribute : Attribute
	{
		public readonly float MinValue;

		public readonly float MaxValue;

		public string Label;

		public VectorSliderAttribute(float min, float max)
		{
			MinValue = min;
			MaxValue = max;
		}
	}
}
