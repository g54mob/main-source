using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class TriangleMeshNode : MeshNode
	{
		public int v0;

		public int v1;

		public int v2;

		protected static INavmeshHolder[] _navmeshHolders;

		protected static readonly object lockObject;

		public TriangleMeshNode(AstarPath astar)
			: base(null)
		{
		}

		public static INavmeshHolder GetNavmeshHolder(uint graphIndex)
		{
			return null;
		}

		public static void SetNavmeshHolder(int graphIndex, INavmeshHolder graph)
		{
		}

		public void UpdatePositionFromVertices()
		{
		}

		public int GetVertexIndex(int i)
		{
			return 0;
		}

		public int GetVertexArrayIndex(int i)
		{
			return 0;
		}

		public void GetVertices(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			v0 = default(Int3);
			v1 = default(Int3);
			v2 = default(Int3);
		}

		public void GetVerticesInGraphSpace(out Int3 v0, out Int3 v1, out Int3 v2)
		{
			v0 = default(Int3);
			v1 = default(Int3);
			v2 = default(Int3);
		}

		public override Int3 GetVertex(int i)
		{
			return default(Int3);
		}

		public Int3 GetVertexInGraphSpace(int i)
		{
			return default(Int3);
		}

		public override int GetVertexCount()
		{
			return 0;
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		internal Int3 ClosestPointOnNodeXZInGraphSpace(Vector3 p)
		{
			return default(Int3);
		}

		public override Vector3 ClosestPointOnNodeXZ(Vector3 p)
		{
			return default(Vector3);
		}

		public override bool ContainsPoint(Vector3 p)
		{
			return false;
		}

		public override bool ContainsPointInGraphSpace(Int3 p)
		{
			return false;
		}

		public override void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void Open(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public int SharedEdge(GraphNode other)
		{
			return 0;
		}

		public override bool GetPortal(GraphNode toNode, List<Vector3> left, List<Vector3> right, bool backwards)
		{
			return false;
		}

		public bool GetPortal(GraphNode toNode, List<Vector3> left, List<Vector3> right, bool backwards, out int aIndex, out int bIndex)
		{
			aIndex = default(int);
			bIndex = default(int);
			return false;
		}

		public override float SurfaceArea()
		{
			return 0f;
		}

		public override Vector3 RandomPointOnSurface()
		{
			return default(Vector3);
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}
	}
}
