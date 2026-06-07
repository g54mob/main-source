using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class DelaunayTriangle
	{
		public FixedArray3<TriangulationPoint> Points;

		public FixedArray3<DelaunayTriangle> Neighbors;

		private FixedBitArray3 mEdgeIsConstrained;

		public FixedBitArray3 EdgeIsDelaunay;

		public FixedBitArray3 EdgeIsConstrained => default(FixedBitArray3);

		public bool IsInterior { get; set; }

		public DelaunayTriangle(TriangulationPoint p1, TriangulationPoint p2, TriangulationPoint p3)
		{
		}

		public int IndexOf(TriangulationPoint p)
		{
			return 0;
		}

		public int IndexCWFrom(TriangulationPoint p)
		{
			return 0;
		}

		public int IndexCCWFrom(TriangulationPoint p)
		{
			return 0;
		}

		public bool Contains(TriangulationPoint p)
		{
			return false;
		}

		private void MarkNeighbor(TriangulationPoint p1, TriangulationPoint p2, DelaunayTriangle t)
		{
		}

		public void MarkNeighbor(DelaunayTriangle t)
		{
		}

		public void ClearNeighbors()
		{
		}

		public void ClearNeighbor(DelaunayTriangle triangle)
		{
		}

		public void Clear()
		{
		}

		public TriangulationPoint OppositePoint(DelaunayTriangle t, TriangulationPoint p)
		{
			return null;
		}

		public DelaunayTriangle NeighborCWFrom(TriangulationPoint point)
		{
			return null;
		}

		public DelaunayTriangle NeighborCCWFrom(TriangulationPoint point)
		{
			return null;
		}

		public DelaunayTriangle NeighborAcrossFrom(TriangulationPoint point)
		{
			return null;
		}

		public TriangulationPoint PointCCWFrom(TriangulationPoint point)
		{
			return null;
		}

		public TriangulationPoint PointCWFrom(TriangulationPoint point)
		{
			return null;
		}

		private void RotateCW()
		{
		}

		public void Legalize(TriangulationPoint oPoint, TriangulationPoint nPoint)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void MarkNeighborEdges()
		{
		}

		public void MarkEdge(DelaunayTriangle triangle)
		{
		}

		public void MarkEdge(List<DelaunayTriangle> tList)
		{
		}

		public void MarkConstrainedEdge(int index)
		{
		}

		public void MarkConstrainedEdge(DTSweepConstraint edge)
		{
		}

		public void MarkConstrainedEdge(TriangulationPoint p, TriangulationPoint q)
		{
		}

		public double Area()
		{
			return 0.0;
		}

		public TriangulationPoint Centroid()
		{
			return null;
		}

		public int EdgeIndex(TriangulationPoint p1, TriangulationPoint p2)
		{
			return 0;
		}

		public bool GetConstrainedEdgeCCW(TriangulationPoint p)
		{
			return false;
		}

		public bool GetConstrainedEdgeCW(TriangulationPoint p)
		{
			return false;
		}

		public bool GetConstrainedEdgeAcross(TriangulationPoint p)
		{
			return false;
		}

		protected void SetConstrainedEdge(int idx, bool ce)
		{
		}

		public void SetConstrainedEdgeCCW(TriangulationPoint p, bool ce)
		{
		}

		public void SetConstrainedEdgeCW(TriangulationPoint p, bool ce)
		{
		}

		public void SetConstrainedEdgeAcross(TriangulationPoint p, bool ce)
		{
		}

		public bool GetDelaunayEdgeCCW(TriangulationPoint p)
		{
			return false;
		}

		public bool GetDelaunayEdgeCW(TriangulationPoint p)
		{
			return false;
		}

		public bool GetDelaunayEdgeAcross(TriangulationPoint p)
		{
			return false;
		}

		public void SetDelaunayEdgeCCW(TriangulationPoint p, bool ce)
		{
		}

		public void SetDelaunayEdgeCW(TriangulationPoint p, bool ce)
		{
		}

		public void SetDelaunayEdgeAcross(TriangulationPoint p, bool ce)
		{
		}

		public bool GetEdge(int idx, out DTSweepConstraint edge)
		{
			edge = null;
			return false;
		}

		public bool GetEdgeCCW(TriangulationPoint p, out DTSweepConstraint edge)
		{
			edge = null;
			return false;
		}

		public bool GetEdgeCW(TriangulationPoint p, out DTSweepConstraint edge)
		{
			edge = null;
			return false;
		}

		public bool GetEdgeAcross(TriangulationPoint p, out DTSweepConstraint edge)
		{
			edge = null;
			return false;
		}
	}
}
