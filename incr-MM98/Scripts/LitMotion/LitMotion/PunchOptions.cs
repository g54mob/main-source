using System;

namespace LitMotion
{
	[Serializable]
	public struct PunchOptions : IEquatable<PunchOptions>, IMotionOptions
	{
		public int Frequency;

		public float DampingRatio;

		public static PunchOptions Default => new PunchOptions
		{
			Frequency = 10,
			DampingRatio = 1f
		};

		public readonly bool Equals(PunchOptions other)
		{
			if (other.Frequency == Frequency)
			{
				return other.DampingRatio == DampingRatio;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is PunchOptions other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(Frequency, DampingRatio);
		}
	}
}
