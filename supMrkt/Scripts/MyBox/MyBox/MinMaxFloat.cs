using System;

namespace MyBox
{
	[Serializable]
	public struct MinMaxFloat
	{
		public float Min;

		public float Max;

		public MinMaxFloat(float min, float max)
		{
			Min = 0f;
			Max = 0f;
		}
	}
}
