using System;

namespace Pathfinding.Poly2Tri
{
	public static class DTSweep
	{
		private const double PI_div2 = Math.PI / 2.0;

		private const double PI_3div4 = Math.PI * 3.0 / 4.0;

		public static void Triangulate(DTSweepContext tcx)
		{
		}

		private static void Sweep(DTSweepContext tcx)
		{
		}

		private static void FinalizationConvexHull(DTSweepContext tcx)
		{
		}

		private static void TurnAdvancingFrontConvex(DTSweepContext tcx, AdvancingFrontNode b, AdvancingFrontNode c)
		{
		}

		private static void FinalizationPolygon(DTSweepContext tcx)
		{
		}

		private static AdvancingFrontNode PointEvent(DTSweepContext tcx, TriangulationPoint point)
		{
			return null;
		}

		private static AdvancingFrontNode NewFrontTriangle(DTSweepContext tcx, TriangulationPoint point, AdvancingFrontNode node)
		{
			return null;
		}

		private static void EdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillRightConcaveEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillRightConvexEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillRightBelowEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillRightAboveEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillLeftConvexEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillLeftConcaveEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillLeftBelowEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static void FillLeftAboveEdgeEvent(DTSweepContext tcx, DTSweepConstraint edge, AdvancingFrontNode node)
		{
		}

		private static bool IsEdgeSideOfTriangle(DelaunayTriangle triangle, TriangulationPoint ep, TriangulationPoint eq)
		{
			return false;
		}

		private static void EdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle triangle, TriangulationPoint point)
		{
		}

		private static void SplitEdge(TriangulationPoint ep, TriangulationPoint eq, TriangulationPoint p)
		{
		}

		private static void FlipEdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle t, TriangulationPoint p)
		{
		}

		private static TriangulationPoint NextFlipPoint(TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle ot, TriangulationPoint op)
		{
			return null;
		}

		private static DelaunayTriangle NextFlipTriangle(DTSweepContext tcx, Orientation o, DelaunayTriangle t, DelaunayTriangle ot, TriangulationPoint p, TriangulationPoint op)
		{
			return null;
		}

		private static void FlipScanEdgeEvent(DTSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq, DelaunayTriangle flipTriangle, DelaunayTriangle t, TriangulationPoint p)
		{
		}

		private static void FillAdvancingFront(DTSweepContext tcx, AdvancingFrontNode n)
		{
		}

		private static void FillBasin(DTSweepContext tcx, AdvancingFrontNode node)
		{
		}

		private static void FillBasinReq(DTSweepContext tcx, AdvancingFrontNode node)
		{
		}

		private static bool IsShallow(DTSweepContext tcx, AdvancingFrontNode node)
		{
			return false;
		}

		private static double HoleAngle(AdvancingFrontNode node)
		{
			return 0.0;
		}

		private static double BasinAngle(AdvancingFrontNode node)
		{
			return 0.0;
		}

		private static void Fill(DTSweepContext tcx, AdvancingFrontNode node)
		{
		}

		private static bool Legalize(DTSweepContext tcx, DelaunayTriangle t)
		{
			return false;
		}

		private static void RotateTrianglePair(DelaunayTriangle t, TriangulationPoint p, DelaunayTriangle ot, TriangulationPoint op)
		{
		}
	}
}
