using System;
using System.Collections.Generic;

namespace ClipperLib
{
	public class ClipperOffset
	{
		private List<List<IntPoint>> m_destPolys;

		private List<IntPoint> m_srcPoly;

		private List<IntPoint> m_destPoly;

		private List<DoublePoint> m_normals;

		private double m_delta;

		private double m_sinA;

		private double m_sin;

		private double m_cos;

		private double m_miterLim;

		private double m_StepsPerRad;

		private IntPoint m_lowest;

		private PolyNode m_polyNodes;

		private const double two_pi = Math.PI * 2.0;

		private const double def_arc_tolerance = 0.25;

		public double ArcTolerance { get; set; }

		public double MiterLimit { get; set; }

		public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
		{
		}

		public void Clear()
		{
		}

		internal static long Round(double value)
		{
			return 0L;
		}

		public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
		{
		}

		public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
		{
		}

		private void FixOrientations()
		{
		}

		internal static DoublePoint GetUnitNormal(IntPoint pt1, IntPoint pt2)
		{
			return default(DoublePoint);
		}

		private void DoOffset(double delta)
		{
		}

		public void Execute(ref List<List<IntPoint>> solution, double delta)
		{
		}

		private void OffsetPoint(int j, ref int k, JoinType jointype)
		{
		}

		internal void DoSquare(int j, int k)
		{
		}

		internal void DoMiter(int j, int k, double r)
		{
		}

		internal void DoRound(int j, int k)
		{
		}
	}
}
