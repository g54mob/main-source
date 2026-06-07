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
			return 0f;
		}

		public OptionalMinMax(bool minIsSet, bool maxIsSet, float min, float max)
		{
			MinIsSet = false;
			MaxIsSet = false;
			Min = 0f;
			Max = 0f;
		}
	}
}
