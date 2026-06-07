using System;
using Pathfinding.Collections;
using Pathfinding.Util;
using Unity.Profiling;

namespace Pathfinding.Graphs.Navmesh
{
	public class NavmeshTile : INavmeshHolder, ITransformedGraph
	{
		public UnsafeSpan<Int3> vertsInGraphSpace;

		public UnsafeSpan<Int3> verts;

		public UnsafeSpan<int> tris;

		public bool isCut;

		public UnsafeSpan<Int3> preCutVertsInTileSpace;

		public UnsafeSpan<int> preCutTris;

		public UnsafeSpan<uint> preCutTags;

		public int x;

		public int z;

		public int w;

		public int d;

		public TriangleMeshNode[] nodes;

		public BBTree bbTree;

		public bool flag;

		public NavmeshBase graph;

		public GraphTransform transform => null;

		public void GetTileCoordinates(int tileIndex, out int x, out int z)
		{
			x = default(int);
			z = default(int);
		}

		public int GetVertexArrayIndex(int index)
		{
			return 0;
		}

		public Int3 GetVertex(int index)
		{
			return default(Int3);
		}

		[IgnoredByDeepProfiler]
		public Int3 GetVertexInGraphSpace(int index)
		{
			return default(Int3);
		}

		public void GetNodes(Action<GraphNode> action)
		{
		}

		public void Dispose()
		{
		}
	}
}
