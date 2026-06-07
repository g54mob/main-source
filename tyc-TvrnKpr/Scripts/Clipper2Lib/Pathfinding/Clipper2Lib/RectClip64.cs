using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class RectClip64
	{
		protected enum Location
		{
			left = 0,
			top = 1,
			right = 2,
			bottom = 3,
			inside = 4
		}

		protected readonly Rect64 rect_;

		protected readonly Point64 mp_;

		protected readonly List<Point64> rectPath_;

		protected Rect64 pathBounds_;

		protected List<OutPt2?> results_;

		protected List<OutPt2?>[] edges_;

		protected int currIdx_;

		internal RectClip64(Rect64 rect)
		{
		}

		internal OutPt2 Add(Point64 pt, bool startingNewPath = false)
		{
			return null;
		}

		private static bool Path1ContainsPath2(List<Point64> path1, List<Point64> path2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsClockwise(Location prev, Location curr, Point64 prevPt, Point64 currPt, Point64 rectMidPoint)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool AreOpposites(Location prev, Location curr)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HeadingClockwise(Location prev, Location curr)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Location GetAdjacentLocation(Location loc, bool isClockwise)
		{
			return default(Location);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutPt2 UnlinkOp(OutPt2 op)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static OutPt2 UnlinkOpBack(OutPt2 op)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint GetEdgesForPt(Point64 pt, Rect64 rec)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHeadingClockwise(Point64 pt1, Point64 pt2, int edgeIdx)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasHorzOverlap(Point64 left1, Point64 right1, Point64 left2, Point64 right2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasVertOverlap(Point64 top1, Point64 bottom1, Point64 top2, Point64 bottom2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void AddToEdge(List<OutPt2?> edge, OutPt2 op)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void UncoupleEdge(OutPt2 op)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SetNewOwner(OutPt2 op, int newIdx)
		{
		}

		private void AddCorner(Location prev, Location curr)
		{
		}

		private void AddCorner(ref Location loc, bool isClockwise)
		{
		}

		protected static bool GetLocation(Rect64 rec, Point64 pt, out Location loc)
		{
			loc = default(Location);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsHorizontal(Point64 pt1, Point64 pt2)
		{
			return false;
		}

		private static bool GetSegmentIntersection(Point64 p1, Point64 p2, Point64 p3, Point64 p4, out Point64 ip)
		{
			ip = default(Point64);
			return false;
		}

		protected static bool GetIntersection(List<Point64> rectPath, Point64 p, Point64 p2, ref Location loc, out Point64 ip)
		{
			ip = default(Point64);
			return false;
		}

		protected void GetNextLocation(List<Point64> path, ref Location loc, ref int i, int highI)
		{
		}

		private bool StartLocsAreClockwise(List<Location> startLocs)
		{
			return false;
		}

		private void ExecuteInternal(List<Point64> path)
		{
		}

		public List<List<Point64>> Execute(List<List<Point64>> paths)
		{
			return null;
		}

		private void CheckEdges()
		{
		}

		private void TidyEdgePair(int idx, List<OutPt2?> cw, List<OutPt2?> ccw)
		{
		}

		private List<Point64> GetPath(OutPt2? op)
		{
			return null;
		}
	}
}
