using System;

namespace MyBox
{
	[Serializable]
	public struct RangedFloat
	{
		public float Min;

		public float Max;

		public RangedFloat(float min, float max)
		{
			Min = 0f;
			Max = 0f;
		}
	}
}
