using System;

namespace GameKit.Utilities.Types
{
	[Serializable]
	public struct IntRange
	{
		public int Minimum;

		public int Maximum;

		public IntRange(int minimum, int maximum)
		{
			Minimum = 0;
			Maximum = 0;
		}

		public float RandomExclusive()
		{
			return 0f;
		}

		public float RandomInclusive()
		{
			return 0f;
		}

		public int Clamp(int value)
		{
			return 0;
		}
	}
}
