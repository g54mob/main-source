using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pathfinding.Clipper2Lib
{
	public class ClipperBase
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		private struct IntersectListSort : IComparer<IntersectNode>
		{
			public readonly int Compare(IntersectNode a, IntersectNode b)
			{
				return 0;
			}
		}

		private ClipType _cliptype;

		private FillRule _fillrule;

		private Active? _actives;

		private Active? _sel;

		private readonly List<LocalMinima> _minimaList;

		private readonly List<IntersectNode> _intersectList;

		private readonly List<Vertex> _vertexList;

		private readonly List<OutRec> _outrecList;

		private readonly List<long> _scanlineList;

		private readonly List<HorzSegment> _horzSegList;

		private readonly List<HorzJoin> _horzJoinList;

		private readonly VertexPool _vertexPool;

		private readonly GCArena<Active> _activeArena;

		private int _currentLocMin;

		private long _currentBotY;

		private bool _isSortedMinimaList;

		private bool _hasOpenPaths;

		internal bool _using_polytree;

		internal bool _succeeded;

		public bool PreserveCollinear { get; set; }

		public bool ReverseSolution { get; set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsOdd(int val)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHotEdge(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsOpen(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsOpenEnd(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsOpenEnd(Vertex v)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Active GetPrevHotEdge(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsFront(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static double GetDx(Point64 pt1, Point64 pt2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static long TopX(Active ae, long currentY)
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHorizontal(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHeadingRightHorz(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHeadingLeftHorz(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SwapActives(ref Active ae1, ref Active ae2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PathType GetPolyType(Active ae)
		{
			return default(PathType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsSamePolyType(Active ae1, Active ae2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SetDx(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vertex NextVertex(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vertex PrevPrevVertex(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsMaxima(Vertex vertex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsMaxima(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Active GetMaximaPair(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vertex GetCurrYMaximaVertex_Open(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vertex GetCurrYMaximaVertex(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SetSides(OutRec outrec, Active startEdge, Active endEdge)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SwapOutrecs(Active ae1, Active ae2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SetOwner(OutRec outrec, OutRec newOwner)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static double Area(OutPt op)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static double AreaTriangle(Point64 pt1, Point64 pt2, Point64 pt3)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutRec? GetRealOutRec(OutRec? outRec)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsValidOwner(OutRec? outRec, OutRec? testOwner)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void UncoupleOutRec(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool OutrecIsAscending(Active hotEdge)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SwapFrontBackSides(OutRec outrec)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool EdgesAdjacentInAEL(IntersectNode inode)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void ClearSolutionOnly()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InsertScanline(long y)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool PopScanline(out long y)
		{
			y = default(long);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasLocMinAtY(long y)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private LocalMinima PopLocalMinima()
		{
			return default(LocalMinima);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddSubject(List<Point64> path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddOpenSubject(List<Point64> path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddClip(List<Point64> path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void AddPath(List<Point64> path, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void AddPaths(List<List<Point64>> paths, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void AddPath(Point64* path, int length, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void AddReuseableData(ReuseableDataContainer64 reuseableData)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsContributingClosed(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsContributingOpen(Active ae)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetWindCountForClosedPathEdge(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetWindCountForOpenPathEdge(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsValidAelOrder(Active resident, Active newcomer)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InsertLeftEdge(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void InsertRightEdge(Active ae, Active ae2)
		{
		}

		private void InsertLocalMinimaIntoAEL(long botY)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PushHorz(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool PopHorz(out Active? ae)
		{
			ae = null;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private OutPt AddLocalMinPoly(Active ae1, Active ae2, Point64 pt, bool isNew = false)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private OutPt AddLocalMaxPoly(Active ae1, Active ae2, Point64 pt)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void JoinOutrecPaths(Active ae1, Active ae2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutPt AddOutPt(Active ae, Point64 pt)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private OutRec NewOutRec()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private OutPt StartOpenPath(Active ae, Point64 pt)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateEdgeIntoAEL(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Active FindEdgeWithMatchingLocMin(Active e)
		{
			return null;
		}

		private void IntersectEdges(Active ae1, Active ae2, Point64 pt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeleteFromAEL(Active ae)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AdjustCurrXAndCopyToSEL(long topY)
		{
		}

		protected void ExecuteInternal(ClipType ct, FillRule fillRule)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoIntersections(long topY)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DisposeIntersectNodes()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddNewIntersectNode(Active ae1, Active ae2, long topY)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Active ExtractFromSEL(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Insert1Before2InSEL(Active ae1, Active ae2)
		{
		}

		private bool BuildIntersectList(long topY)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ProcessIntersectList()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SwapPositionsInAEL(Active ae1, Active ae2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ResetHorzDirection(Active horz, Vertex? vertexMax, out long leftX, out long rightX)
		{
			leftX = default(long);
			rightX = default(long);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TrimHorz(Active horzEdge, bool preserveCollinear)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddToHorzSegList(OutPt op)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private OutPt GetLastOp(Active hotEdge)
		{
			return null;
		}

		private void DoHorizontal(Active horz)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoTopOfScanbeam(long y)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Active DoMaxima(Active ae)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsJoined(Active e)
		{
			return false;
		}

		private void Split(Active e, Point64 currPt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckJoinLeft(Active e, Point64 pt, bool checkCurrX = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckJoinRight(Active e, Point64 pt, bool checkCurrX = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void FixOutRecPts(OutRec outrec)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool SetHorzSegHeadingForward(HorzSegment hs, OutPt opP, OutPt opN)
		{
			return false;
		}

		private static bool UpdateHorzSegment(HorzSegment hs)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutPt DuplicateOp(OutPt op, bool insert_after)
		{
			return null;
		}

		private int HorzSegSort(HorzSegment? hs1, HorzSegment? hs2)
		{
			return 0;
		}

		private void ConvertHorzSegsToJoins()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static List<Point64> GetCleanPath(OutPt op)
		{
			return null;
		}

		private static PointInPolygonResult PointInOpPolygon(Point64 pt, OutPt op)
		{
			return default(PointInPolygonResult);
		}

		private static bool Path1InsidePath2(OutPt op1, OutPt op2)
		{
			return false;
		}

		private void MoveSplits(OutRec fromOr, OutRec toOr)
		{
		}

		private void ProcessHorzJoins()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool PtsReallyClose(Point64 pt1, Point64 pt2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsVerySmallTriangle(OutPt op)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsValidClosedPath(OutPt? op)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutPt DisposeOutPt(OutPt op)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CleanCollinear(OutRec? outrec)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoSplitOp(OutRec outrec, OutPt splitOp)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void FixSelfIntersects(OutRec outrec)
		{
		}

		internal static bool BuildPath(OutPt? op, bool reverse, bool isOpen, List<Point64> path)
		{
			return false;
		}

		protected bool BuildPaths(List<List<Point64>> solutionClosed, List<List<Point64>> solutionOpen)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Rect64 GetBounds(List<Point64> path)
		{
			return default(Rect64);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool CheckBounds(OutRec outrec)
		{
			return false;
		}

		private bool CheckSplitOwner(OutRec outrec, List<int>? splits)
		{
			return false;
		}

		private void RecursiveCheckOwners(OutRec outrec, PolyPathBase polypath)
		{
		}

		protected void BuildTree(PolyPathBase polytree, List<List<Point64>> solutionOpen)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect64 GetBounds()
		{
			return default(Rect64);
		}
	}
}
