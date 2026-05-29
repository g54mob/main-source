using System;

namespace GameKit.Utilities.Types
{
	[Serializable]
	public struct FloatRange
	{
		public float Minimum;

		public float Maximum;

		public FloatRange(float minimum, float maximum)
		{
			Minimum = 0f;
			Maximum = 0f;
		}

		public float RandomInclusive()
		{
			return 0f;
		}

		public float Lerp(float percent)
		{
			return 0f;
		}
	}
}
