using System.Runtime.CompilerServices;

namespace NSMedieval.Tools.Math
{
	public static class MathfUtils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Min(float a, float b)
		{
			if (!(a < b))
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Min(int a, int b)
		{
			if (a >= b)
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Max(float a, float b)
		{
			if (!(a > b))
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Max(int a, int b)
		{
			if (a <= b)
			{
				return b;
			}
			return a;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Sign(float a)
		{
			return (!(a < 0f)) ? 1 : (-1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp01(float a)
		{
			if ((double)a < 0.0)
			{
				return 0f;
			}
			if (!((double)a > 1.0))
			{
				return a;
			}
			return 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			return value;
		}
	}
}
