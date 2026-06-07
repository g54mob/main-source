using System;

namespace Tantawowa.Extensions
{
	public static class PrimitiveExtensions
	{
		public static int ClampIndex(this int value, int min, int max)
		{
			return 0;
		}

		public static bool IsValidAsType(this string input, Type type)
		{
			return false;
		}

		public static T ConvertToType<T>(this string input)
		{
			return default(T);
		}

		public static double RoundUpToNearest(this double passednumber, double roundto)
		{
			return 0.0;
		}

		public static double RoundDownToNearest(this double passednumber, double roundto)
		{
			return 0.0;
		}

		public static float RoundUpToNearest(this float passednumber, float roundto)
		{
			return 0f;
		}

		public static float RoundDownToNearest(this float passednumber, float roundto)
		{
			return 0f;
		}

		public static int RoundUpToNearest(this int passednumber, int roundto)
		{
			return 0;
		}

		public static int RoundDownToNearest(this int passednumber, int roundto)
		{
			return 0;
		}

		public static int Flip(this int value)
		{
			return 0;
		}
	}
}
