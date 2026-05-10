using System;
using Pathfinding.Util;

namespace Pathfinding
{
	public class NavmeshTile : INavmeshHolder, ITransformedGraph, INavmesh
	{
		public int[] tris;

		public Int3[] verts;

		public Int3[] vertsInGraphSpace;

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

		public Int3 GetVertexInGraphSpace(int index)
		{
			return default(Int3);
		}

		public void GetNodes(Action<GraphNode> action)
		{
		}
	}
}
