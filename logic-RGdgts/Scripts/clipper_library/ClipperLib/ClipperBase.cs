using System.Collections.Generic;

namespace ClipperLib
{
	public class ClipperBase
	{
		internal LocalMinima m_MinimaList;

		internal LocalMinima m_CurrentLM;

		internal List<List<TEdge>> m_edges;

		internal Scanbeam m_Scanbeam;

		internal List<OutRec> m_PolyOuts;

		internal TEdge m_ActiveEdges;

		internal bool m_UseFullRange;

		internal bool m_HasOpenPaths;

		public bool PreserveCollinear { get; set; }

		internal static bool near_zero(double val)
		{
			return false;
		}

		public void Swap(ref long val1, ref long val2)
		{
		}

		internal static bool IsHorizontal(TEdge e)
		{
			return false;
		}

		internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
		{
			return false;
		}

		internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
		{
			return false;
		}

		internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
		{
			return false;
		}

		internal ClipperBase()
		{
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

		private TEdge FindNextLocMin(TEdge E)
		{
			return null;
		}

		private TEdge ProcessBound(TEdge E, bool LeftBoundIsForward)
		{
			return null;
		}

		public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
		{
			return false;
		}

		public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
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

		private void SetDx(TEdge e)
		{
		}

		private void InsertLocalMinima(LocalMinima newLm)
		{
		}

		internal bool PopLocalMinima(long Y, out LocalMinima current)
		{
			current = null;
			return false;
		}

		private void ReverseHorizontal(TEdge e)
		{
		}

		internal virtual void Reset()
		{
		}

		public static IntRect GetBounds(List<List<IntPoint>> paths)
		{
			return default(IntRect);
		}

		internal void InsertScanbeam(long Y)
		{
		}

		internal bool PopScanbeam(out long Y)
		{
			Y = default(long);
			return false;
		}

		internal bool LocalMinimaPending()
		{
			return false;
		}

		internal OutRec CreateOutRec()
		{
			return null;
		}

		internal void DisposeOutRec(int index)
		{
		}

		internal void UpdateEdgeIntoAEL(ref TEdge e)
		{
		}

		internal void SwapPositionsInAEL(TEdge edge1, TEdge edge2)
		{
		}

		internal void DeleteFromAEL(TEdge e)
		{
		}
	}
}
