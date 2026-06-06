using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class Clipper64 : ClipperBase
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal new void AddPath(List<Point64> path, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new void AddReuseableData(ReuseableDataContainer64 reuseableData)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal new void AddPaths(List<List<Point64>> paths, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddSubject(List<List<Point64>> paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddOpenSubject(List<List<Point64>> paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddClip(List<List<Point64>> paths)
		{
		}

		public bool Execute(ClipType clipType, FillRule fillRule, List<List<Point64>> solutionClosed, List<List<Point64>> solutionOpen)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Execute(ClipType clipType, FillRule fillRule, List<List<Point64>> solutionClosed)
		{
			return false;
		}

		public bool Execute(ClipType clipType, FillRule fillRule, PolyTree64 polytree, List<List<Point64>> openPaths)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Execute(ClipType clipType, FillRule fillRule, PolyTree64 polytree)
		{
			return false;
		}
	}
}
