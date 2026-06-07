using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public static class InternalClipper
	{
		public struct MultiplyUInt64Result
		{
			public ulong lo64;

			public ulong hi64;
		}

		internal const long MaxInt64 = 9223372036854775807L;

		internal const long MaxCoord = 2305843009213693951L;

		internal const double max_coord = 2.305843009213694E+18;

		internal const double min_coord = -2.305843009213694E+18;

		internal const long Invalid64 = 9223372036854775807L;

		internal const double defaultArcTolerance = 0.25;

		internal const double floatingPointTolerance = 1E-12;

		internal const double defaultMinimumEdgeLength = 0.1;

		private static readonly string precision_range_error;

		public static double CrossProduct(Point64 pt1, Point64 pt2, Point64 pt3)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void CheckPrecision(int precision)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsAlmostZero(double value)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int TriSign(long x)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MultiplyUInt64Result MultiplyUInt64(ulong a, ulong b)
		{
			return default(MultiplyUInt64Result);
		}

		internal static bool ProductsAreEqual(long a, long b, long c, long d)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsCollinear(Point64 pt1, Point64 sharedPt, Point64 pt2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double DotProduct(Point64 pt1, Point64 pt2, Point64 pt3)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double CrossProduct(PointD vec1, PointD vec2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double DotProduct(PointD vec1, PointD vec2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static long CheckCastInt64(double val)
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool GetSegmentIntersectPt(Point64 ln1a, Point64 ln1b, Point64 ln2a, Point64 ln2b, out Point64 ip)
		{
			ip = default(Point64);
			return false;
		}

		internal static bool SegsIntersect(Point64 seg1a, Point64 seg1b, Point64 seg2a, Point64 seg2b, bool inclusive = false)
		{
			return false;
		}

		public static Point64 GetClosestPtOnSegment(Point64 offPt, Point64 seg1, Point64 seg2)
		{
			return default(Point64);
		}

		public static PointInPolygonResult PointInPolygon(Point64 pt, List<Point64> polygon)
		{
			return default(PointInPolygonResult);
		}
	}
}
