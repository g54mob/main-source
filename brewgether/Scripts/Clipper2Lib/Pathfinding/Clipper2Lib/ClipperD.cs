using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class ClipperD : ClipperBase
	{
		private readonly string precision_range_error;

		private readonly double _scale;

		private readonly double _invScale;

		public ClipperD(int roundingDecimalPrecision = 2)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPath(PathD path, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddPaths(PathsD paths, PathType polytype, bool isOpen = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddSubject(PathD path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddOpenSubject(PathD path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddClip(PathD path)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddSubject(PathsD paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddOpenSubject(PathsD paths)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddClip(PathsD paths)
		{
		}

		public bool Execute(ClipType clipType, FillRule fillRule, PathsD solutionClosed, PathsD solutionOpen)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Execute(ClipType clipType, FillRule fillRule, PathsD solutionClosed)
		{
			return false;
		}

		public bool Execute(ClipType clipType, FillRule fillRule, PolyTreeD polytree, PathsD openPaths)
		{
			return false;
		}

		public bool Execute(ClipType clipType, FillRule fillRule, PolyTreeD polytree)
		{
			return false;
		}
	}
}
