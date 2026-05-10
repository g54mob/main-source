using System.Collections.Generic;

namespace Pathfinding.ClipperLib
{
	public class ClipperBase
	{
		protected const double horizontal = -3.4E+38;

		protected const int Skip = -2;

		protected const int Unassigned = -1;

		protected const double tolerance = 1E-20;

		internal const long loRange = 1073741823L;

		internal const long hiRange = 4611686018427387903L;

		internal LocalMinima m_MinimaList;

		internal LocalMinima m_CurrentLM;

		internal List<List<TEdge>> m_edges;

		internal bool m_UseFullRange;

		internal bool m_HasOpenPaths;

		public bool PreserveCollinear { get; set; }

		internal ClipperBase()
		{
		}

		internal static bool near_zero(double val)
		{
			return false;
		}

		internal static bool IsHorizontal(TEdge e)
		{
			return false;
		}

		internal bool PointIsVertex(IntPoint pt, OutPt pp)
		{
			return false;
		}

		internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange)
		{
			return false;
		}

		internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
		{
			return false;
		}

		internal bool PointInPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
		{
			return false;
		}

		internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
		{
			return false;
		}

		protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
		{
			return false;
		}

		protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
		{
			return false;
		}

		public virtual void Clear()
		{
		}

		private void DisposeLocalMinimaList()
		{
		}

		private void RangeTest(IntPoint Pt, ref bool useFullRange)
		{
		}

		private void InitEdge(TEdge e, TEdge eNext, TEdge ePrev, IntPoint pt)
		{
		}

		private void InitEdge2(TEdge e, PolyType polyType)
		{
		}

		public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
		{
			return false;
		}

		public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
		{
			return false;
		}

		public bool AddPolygon(List<IntPoint> pg, PolyType polyType)
		{
			return false;
		}

		public bool AddPolygons(List<List<IntPoint>> ppg, PolyType polyType)
		{
			return false;
		}

		internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3)
		{
			return false;
		}

		private TEdge RemoveEdge(TEdge e)
		{
			return null;
		}

		private TEdge GetLastHorz(TEdge Edge)
		{
			return null;
		}

		private bool SharedVertWithPrevAtTop(TEdge Edge)
		{
			return false;
		}

		private bool SharedVertWithNextIsBot(TEdge Edge)
		{
			return false;
		}

		private bool MoreBelow(TEdge Edge)
		{
			return false;
		}

		private bool JustBeforeLocMin(TEdge Edge)
		{
			return false;
		}

		private bool MoreAbove(TEdge Edge)
		{
			return false;
		}

		private bool AllHorizontal(TEdge Edge)
		{
			return false;
		}

		private void SetDx(TEdge e)
		{
		}

		private void DoMinimaLML(TEdge E1, TEdge E2, bool IsClosed)
		{
		}

		private TEdge DescendToMin(ref TEdge E)
		{
			return null;
		}

		private void AscendToMax(ref TEdge E, bool Appending, bool IsClosed)
		{
		}

		private TEdge AddBoundsToLML(TEdge E, bool Closed)
		{
			return null;
		}

		private void InsertLocalMinima(LocalMinima newLm)
		{
		}

		protected void PopLocalMinima()
		{
		}

		private void ReverseHorizontal(TEdge e)
		{
		}

		protected virtual void Reset()
		{
		}

		public IntRect GetBounds()
		{
			return default(IntRect);
		}
	}
}
