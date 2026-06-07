using System;

namespace LitMotion
{
	[Serializable]
	public struct ShakeOptions : IEquatable<ShakeOptions>, IMotionOptions
	{
		public int Frequency;

		public float DampingRatio;

		public uint RandomSeed;

		public static ShakeOptions Default => new ShakeOptions
		{
			Frequency = 10,
			DampingRatio = 1f
		};

		public readonly bool Equals(ShakeOptions other)
		{
			if (other.Frequency == Frequency && other.DampingRatio == DampingRatio)
			{
				return other.RandomSeed == RandomSeed;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is ShakeOptions other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(Frequency, DampingRatio, RandomSeed);
		}
	}
}
