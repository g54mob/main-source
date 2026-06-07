using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	internal static class ClipperEngine
	{
		internal static void AddLocMin(Vertex vert, PathType polytype, bool isOpen, List<LocalMinima> minimaList)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void EnsureCapacity<T>(this List<T> list, int minCapacity) where T : notnull
		{
		}

		internal static void AddPathsToVertexList(List<List<Point64>> paths, PathType polytype, bool isOpen, List<LocalMinima> minimaList, List<Vertex> vertexList, VertexPool vertexPool)
		{
		}

		internal static void AddPathToVertexList(SpanCompat<Point64> path, PathType polytype, bool isOpen, List<LocalMinima> minimaList, List<Vertex> vertexList, VertexPool vertexPool)
		{
		}
	}
}
