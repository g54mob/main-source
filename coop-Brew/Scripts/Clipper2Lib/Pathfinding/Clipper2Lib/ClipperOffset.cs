using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class ClipperOffset
	{
		private class Group
		{
			internal List<List<Point64>> inPaths;

			internal JoinType joinType;

			internal EndType endType;

			internal bool pathsReversed;

			internal int lowestPathIdx;

			public Group(List<List<Point64>> paths, JoinType joinType, EndType endType = EndType.Polygon)
			{
			}
		}

		public delegate double DeltaCallback64(List<Point64> path, PathD path_norms, int currPt, int prevPt);

		private static readonly double Tolerance;

		private readonly List<Group> _groupList;

		private List<Point64> pathOut;

		private readonly PathD _normals;

		private List<List<Point64>> _solution;

		private PolyTree64? _solutionTree;

		private double _groupDelta;

		private double _delta;

		private double _mitLimSqr;

		private double _stepsPerRad;

		private double _stepSin;

		private double _stepCos;

		private JoinType _joinType;

		private EndType _endType;

		public double ArcTolerance { get; set; }

		public bool MergeGroups { get; set; }

		public double MiterLimit { get; set; }

		public bool PreserveCollinear { get; set; }

		public bool ReverseSolution { get; set; }

		public DeltaCallback64? DeltaCallback { get; set; }

		public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.0, bool preserveCollinear = false, bool reverseSolution = false)
		{
		}

		public void Clear()
		{
		}

		public void AddPath(List<Point64> path, JoinType joinType, EndType endType)
		{
		}

		public void AddPaths(List<List<Point64>> paths, JoinType joinType, EndType endType)
		{
		}

		private int CalcSolutionCapacity()
		{
			return 0;
		}

		internal bool CheckPathsReversed()
		{
			return false;
		}

		private void ExecuteInternal(double delta)
		{
		}

		public void Execute(double delta, List<List<Point64>> solution)
		{
		}

		public void Execute(double delta, PolyTree64 solutionTree)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static PointD GetUnitNormal(Point64 pt1, Point64 pt2)
		{
			return default(PointD);
		}

		public void Execute(DeltaCallback64 deltaCallback, List<List<Point64>> solution)
		{
		}

		internal static int GetLowestPathIdx(List<List<Point64>> paths)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PointD TranslatePoint(PointD pt, double dx, double dy)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PointD ReflectPoint(PointD pt, PointD pivot)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool AlmostZero(double value, double epsilon = 0.001)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static double Hypotenuse(double x, double y)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PointD NormalizeVector(PointD vec)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PointD GetAvgUnitVector(PointD vec1, PointD vec2)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PointD IntersectPoint(PointD pt1a, PointD pt1b, PointD pt2a, PointD pt2b)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Point64 GetPerpendic(Point64 pt, PointD norm)
		{
			return default(Point64);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private PointD GetPerpendicD(Point64 pt, PointD norm)
		{
			return default(PointD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoBevel(List<Point64> path, int j, int k)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoSquare(List<Point64> path, int j, int k)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoMiter(List<Point64> path, int j, int k, double cosA)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoRound(List<Point64> path, int j, int k, double angle)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void BuildNormals(List<Point64> path)
		{
		}

		private void OffsetPoint(Group group, List<Point64> path, int j, ref int k)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OffsetPolygon(Group group, List<Point64> path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OffsetOpenJoined(Group group, List<Point64> path)
		{
		}

		private void OffsetOpenPath(Group group, List<Point64> path)
		{
		}

		private void DoGroupOffset(Group group)
		{
		}
	}
}
