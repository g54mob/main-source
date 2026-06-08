using JetBrains.Annotations;

namespace KitchenData
{
	public struct Factor
	{
		public float Value;

		public static float operator *(float value, Factor factor)
		{
			return value * (1f + factor.Value);
		}

		public static float operator /(float value, Factor factor)
		{
			return value * (1f - factor.Value);
		}

		public static Factor operator +(Factor f1, Factor f2)
		{
			return f1.Value + f2.Value;
		}

		public static Factor operator -(Factor f1, Factor f2)
		{
			return f1.Value - f2.Value;
		}

		public static bool operator >(Factor f1, Factor f2)
		{
			return f1.Value > f2.Value;
		}

		public static bool operator <(Factor f1, Factor f2)
		{
			return f1.Value < f2.Value;
		}

		public float AsMultiplier()
		{
			return 1f + Value;
		}

		[Pure]
		public Factor Repeat(float mul)
		{
			return Value * mul;
		}

		public static implicit operator Factor(float f)
		{
			return new Factor
			{
				Value = f
			};
		}
	}
}
