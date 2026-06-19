using System;

namespace MyBox
{
	[Serializable]
	public struct OptionalMinMax
	{
		public bool MinIsSet;

		public bool MaxIsSet;

		public float Min;

		public float Max;

		public float GetFixed(float value)
		{
			if (MinIsSet && value < Min)
			{
				value = Min;
			}
			if (MaxIsSet && value > Max)
			{
				value = Max;
			}
			return value;
		}

		public OptionalMinMax(bool minIsSet, bool maxIsSet, float min, float max)
		{
			MinIsSet = minIsSet;
			MaxIsSet = maxIsSet;
			Min = min;
			Max = max;
		}
	}
}
