using System;
using System.Runtime.CompilerServices;

namespace External.Zalgo2462.VoronoiLib
{
	public static class ParabolaMath
	{
		public const double EPSILON = 4.940656458412466E-224;

		public static double EvalParabola(double focusX, double focusY, double directrix, double x)
		{
			return 0.5 * ((x - focusX) * (x - focusX) / (focusY - directrix) + focusY + directrix);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double IntersectParabolaX(double focus1X, double focus1Y, double focus2X, double focus2Y, double directrix)
		{
			if (!focus1Y.ApproxEqual(focus2Y))
			{
				return (focus1X * (directrix - focus2Y) + focus2X * (focus1Y - directrix) + Math.Sqrt((directrix - focus1Y) * (directrix - focus2Y) * ((focus1X - focus2X) * (focus1X - focus2X) + (focus1Y - focus2Y) * (focus1Y - focus2Y)))) / (focus1Y - focus2Y);
			}
			return (focus1X + focus2X) / 2.0;
		}

		public static bool ApproxEqual(this double value1, double value2)
		{
			return Math.Abs(value1 - value2) <= 4.940656458412466E-224;
		}

		public static bool ApproxGreaterThanOrEqualTo(this double value1, double value2)
		{
			if (!(value1 > value2))
			{
				return value1.ApproxEqual(value2);
			}
			return true;
		}

		public static bool ApproxLessThanOrEqualTo(this double value1, double value2)
		{
			if (!(value1 < value2))
			{
				return value1.ApproxEqual(value2);
			}
			return true;
		}
	}
}
