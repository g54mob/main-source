using System;

namespace LitMotion
{
	[Serializable]
	public struct IntegerOptions : IMotionOptions, IEquatable<IntegerOptions>
	{
		public RoundingMode RoundingMode;

		public readonly bool Equals(IntegerOptions other)
		{
			return other.RoundingMode == RoundingMode;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is IntegerOptions other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return (int)RoundingMode;
		}
	}
}
