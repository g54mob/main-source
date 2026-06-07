using System;

namespace NGenerics.Extensions
{
	public static class DoubleExtensions
	{
		public const double DefaultPrecision = 1E-11;

		public static bool IsSimilarTo(this double arg1, double arg2)
		{
			return arg1.IsSimilarTo(arg2, 1E-11);
		}

		public static bool IsSimilarTo(this double arg1, double arg2, double precision)
		{
			return Math.Abs(arg1 - arg2) < precision;
		}
	}
}
