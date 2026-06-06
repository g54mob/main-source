using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public static class Clipper
	{
		private static Rect64 invalidRect64;

		private static RectD invalidRectD;

		public static Rect64 InvalidRect64 => default(Rect64);

		public static RectD InvalidRectD => default(RectD);

		public static List<List<Point64>> Intersect(List<List<Point64>> subject, List<List<Point64>> clip, FillRule fillRule)
		{
			return null;
		}

		public static PathsD Intersect(PathsD subject, PathsD clip, FillRule fillRule, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> Union(List<List<Point64>> subject, FillRule fillRule)
		{
			return null;
		}

		public static List<List<Point64>> Union(List<List<Point64>> subject, List<List<Point64>> clip, FillRule fillRule)
		{
			return null;
		}

		public static PathsD Union(PathsD subject, FillRule fillRule)
		{
			return null;
		}

		public static PathsD Union(PathsD subject, PathsD clip, FillRule fillRule, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> Difference(List<List<Point64>> subject, List<List<Point64>> clip, FillRule fillRule)
		{
			return null;
		}

		public static PathsD Difference(PathsD subject, PathsD clip, FillRule fillRule, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> Xor(List<List<Point64>> subject, List<List<Point64>> clip, FillRule fillRule)
		{
			return null;
		}

		public static PathsD Xor(PathsD subject, PathsD clip, FillRule fillRule, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> BooleanOp(ClipType clipType, List<List<Point64>>? subject, List<List<Point64>>? clip, FillRule fillRule)
		{
			return null;
		}

		public static void BooleanOp(ClipType clipType, List<List<Point64>>? subject, List<List<Point64>>? clip, PolyTree64 polytree, FillRule fillRule)
		{
		}

		public static PathsD BooleanOp(ClipType clipType, PathsD subject, PathsD? clip, FillRule fillRule, int precision = 2)
		{
			return null;
		}

		public static void BooleanOp(ClipType clipType, PathsD? subject, PathsD? clip, PolyTreeD polytree, FillRule fillRule, int precision = 2)
		{
		}

		public static List<List<Point64>> InflatePaths(List<List<Point64>> paths, double delta, JoinType joinType, EndType endType, double miterLimit = 2.0)
		{
			return null;
		}

		public static PathsD InflatePaths(PathsD paths, double delta, JoinType joinType, EndType endType, double miterLimit = 2.0, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> RectClip(Rect64 rect, List<List<Point64>> paths)
		{
			return null;
		}

		public static List<List<Point64>> RectClip(Rect64 rect, List<Point64> path)
		{
			return null;
		}

		public static PathsD RectClip(RectD rect, PathsD paths, int precision = 2)
		{
			return null;
		}

		public static PathsD RectClip(RectD rect, PathD path, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> RectClipLines(Rect64 rect, List<List<Point64>> paths)
		{
			return null;
		}

		public static List<List<Point64>> RectClipLines(Rect64 rect, List<Point64> path)
		{
			return null;
		}

		public static PathsD RectClipLines(RectD rect, PathsD paths, int precision = 2)
		{
			return null;
		}

		public static PathsD RectClipLines(RectD rect, PathD path, int precision = 2)
		{
			return null;
		}

		public static List<List<Point64>> MinkowskiSum(List<Point64> pattern, List<Point64> path, bool isClosed)
		{
			return null;
		}

		public static PathsD MinkowskiSum(PathD pattern, PathD path, bool isClosed)
		{
			return null;
		}

		public static List<List<Point64>> MinkowskiDiff(List<Point64> pattern, List<Point64> path, bool isClosed)
		{
			return null;
		}

		public static PathsD MinkowskiDiff(PathD pattern, PathD path, bool isClosed)
		{
			return null;
		}

		public static double Area(List<Point64> path)
		{
			return 0.0;
		}

		public static double Area(List<List<Point64>> paths)
		{
			return 0.0;
		}

		public static double Area(PathD path)
		{
			return 0.0;
		}

		public static double Area(PathsD paths)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPositive(List<Point64> poly)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPositive(PathD poly)
		{
			return false;
		}

		public static string Path64ToString(List<Point64> path)
		{
			return null;
		}

		public static string Paths64ToString(List<List<Point64>> paths)
		{
			return null;
		}

		public static string PathDToString(PathD path)
		{
			return null;
		}

		public static string PathsDToString(PathsD paths)
		{
			return null;
		}

		public static List<Point64> OffsetPath(List<Point64> path, long dx, long dy)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Point64 ScalePoint64(Point64 pt, double scale)
		{
			return default(Point64);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PointD ScalePointD(Point64 pt, double scale)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rect64 ScaleRect(RectD rec, double scale)
		{
			return default(Rect64);
		}

		public static List<Point64> ScalePath(List<Point64> path, double scale)
		{
			return null;
		}

		public static List<List<Point64>> ScalePaths(List<List<Point64>> paths, double scale)
		{
			return null;
		}

		public static PathD ScalePath(PathD path, double scale)
		{
			return null;
		}

		public static PathsD ScalePaths(PathsD paths, double scale)
		{
			return null;
		}

		public static List<Point64> ScalePath64(PathD path, double scale)
		{
			return null;
		}

		public static List<List<Point64>> ScalePaths64(PathsD paths, double scale)
		{
			return null;
		}

		public static PathD ScalePathD(List<Point64> path, double scale)
		{
			return null;
		}

		public static PathsD ScalePathsD(List<List<Point64>> paths, double scale)
		{
			return null;
		}

		public static List<Point64> Path64(PathD path)
		{
			return null;
		}

		public static List<List<Point64>> Paths64(PathsD paths)
		{
			return null;
		}

		public static PathsD PathsD(List<List<Point64>> paths)
		{
			return null;
		}

		public static PathD PathD(List<Point64> path)
		{
			return null;
		}

		public static List<Point64> TranslatePath(List<Point64> path, long dx, long dy)
		{
			return null;
		}

		public static List<List<Point64>> TranslatePaths(List<List<Point64>> paths, long dx, long dy)
		{
			return null;
		}

		public static PathD TranslatePath(PathD path, double dx, double dy)
		{
			return null;
		}

		public static PathsD TranslatePaths(PathsD paths, double dx, double dy)
		{
			return null;
		}

		public static List<Point64> ReversePath(List<Point64> path)
		{
			return null;
		}

		public static PathD ReversePath(PathD path)
		{
			return null;
		}

		public static List<List<Point64>> ReversePaths(List<List<Point64>> paths)
		{
			return null;
		}

		public static PathsD ReversePaths(PathsD paths)
		{
			return null;
		}

		public static Rect64 GetBounds(List<Point64> path)
		{
			return default(Rect64);
		}

		public static Rect64 GetBounds(List<List<Point64>> paths)
		{
			return default(Rect64);
		}

		public static RectD GetBounds(PathD path)
		{
			return default(RectD);
		}

		public static RectD GetBounds(PathsD paths)
		{
			return default(RectD);
		}

		public static List<Point64> MakePath(int[] arr)
		{
			return null;
		}

		public static List<Point64> MakePath(long[] arr)
		{
			return null;
		}

		public static PathD MakePath(double[] arr)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Sqr(double val)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Sqr(long val)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double DistanceSqr(Point64 pt1, Point64 pt2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Point64 MidPoint(Point64 pt1, Point64 pt2)
		{
			return default(Point64);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PointD MidPoint(PointD pt1, PointD pt2)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InflateRect(ref Rect64 rec, int dx, int dy)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InflateRect(ref RectD rec, double dx, double dy)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool PointsNearEqual(PointD pt1, PointD pt2, double distanceSqrd)
		{
			return false;
		}

		public static PathD StripNearDuplicates(PathD path, double minEdgeLenSqrd, bool isClosedPath)
		{
			return null;
		}

		public static List<Point64> StripDuplicates(List<Point64> path, bool isClosedPath)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void AddPolyNodeToPaths(PolyPath64 polyPath, List<List<Point64>> paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<List<Point64>> PolyTreeToPaths64(PolyTree64 polyTree)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPolyNodeToPathsD(PolyPathD polyPath, PathsD paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PathsD PolyTreeToPathsD(PolyTreeD polyTree)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double PerpendicDistFromLineSqrd(PointD pt, PointD line1, PointD line2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double PerpendicDistFromLineSqrd(Point64 pt, Point64 line1, Point64 line2)
		{
			return 0.0;
		}

		internal static void RDP(List<Point64> path, int begin, int end, double epsSqrd, List<bool> flags)
		{
		}

		public static List<Point64> RamerDouglasPeucker(List<Point64> path, double epsilon)
		{
			return null;
		}

		public static List<List<Point64>> RamerDouglasPeucker(List<List<Point64>> paths, double epsilon)
		{
			return null;
		}

		internal static void RDP(PathD path, int begin, int end, double epsSqrd, List<bool> flags)
		{
		}

		public static PathD RamerDouglasPeucker(PathD path, double epsilon)
		{
			return null;
		}

		public static PathsD RamerDouglasPeucker(PathsD paths, double epsilon)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetNext(int current, int high, ref bool[] flags)
		{
			return 0;
		}

		private static int GetPrior(int current, int high, ref bool[] flags)
		{
			return 0;
		}

		public static List<Point64> SimplifyPath(List<Point64> path, double epsilon, bool isClosedPath = true)
		{
			return null;
		}

		public static List<List<Point64>> SimplifyPaths(List<List<Point64>> paths, double epsilon, bool isClosedPaths = true)
		{
			return null;
		}

		public static PathD SimplifyPath(PathD path, double epsilon, bool isClosedPath = true)
		{
			return null;
		}

		public static PathsD SimplifyPaths(PathsD paths, double epsilon, bool isClosedPath = true)
		{
			return null;
		}

		public static List<Point64> TrimCollinear(List<Point64> path, bool isOpen = false)
		{
			return null;
		}

		public static PathD TrimCollinear(PathD path, int precision, bool isOpen = false)
		{
			return null;
		}

		public static PointInPolygonResult PointInPolygon(Point64 pt, List<Point64> polygon)
		{
			return default(PointInPolygonResult);
		}

		public static PointInPolygonResult PointInPolygon(PointD pt, PathD polygon, int precision = 2)
		{
			return default(PointInPolygonResult);
		}

		public static List<Point64> Ellipse(Point64 center, double radiusX, double radiusY = 0.0, int steps = 0)
		{
			return null;
		}

		public static PathD Ellipse(PointD center, double radiusX, double radiusY = 0.0, int steps = 0)
		{
			return null;
		}
	}
}
