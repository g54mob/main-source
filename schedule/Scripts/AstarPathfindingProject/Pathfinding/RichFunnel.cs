using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class RichFunnel : RichPathPart
	{
		private readonly List<Vector3> left;

		private readonly List<Vector3> right;

		private List<TriangleMeshNode> nodes;

		public Vector3 exactStart;

		public Vector3 exactEnd;

		private NavmeshBase graph;

		private int currentNode;

		private Vector3 currentPosition;

		private int checkForDestroyedNodesCounter;

		private RichPath path;

		private int[] triBuffer;

		public bool funnelSimplification;

		private static Queue<TriangleMeshNode> navmeshClampQueue;

		private static List<TriangleMeshNode> navmeshClampList;

		private static Dictionary<TriangleMeshNode, TriangleMeshNode> navmeshClampDict;

		public TriangleMeshNode CurrentNode => null;

		public float DistanceToEndOfPath => 0f;

		public RichFunnel Initialize(RichPath path, NavmeshBase graph)
		{
			return null;
		}

		public override void OnEnterPool()
		{
		}

		public void BuildFunnelCorridor(List<GraphNode> nodes, int start, int end)
		{
		}

		private void SimplifyPath(IRaycastableGraph graph, List<GraphNode> nodes, int start, int end, List<GraphNode> result, Vector3 startPoint, Vector3 endPoint)
		{
		}

		private void UpdateFunnelCorridor(int splitIndex, List<TriangleMeshNode> prefix)
		{
		}

		private bool CheckForDestroyedNodes()
		{
			return false;
		}

		public Vector3 ClampToNavmesh(Vector3 position)
		{
			return default(Vector3);
		}

		public Vector3 Update(Vector3 position, List<Vector3> buffer, int numCorners, out bool lastCorner, out bool requiresRepath)
		{
			lastCorner = default(bool);
			requiresRepath = default(bool);
			return default(Vector3);
		}

		private bool ClampToNavmeshInternal(ref Vector3 position)
		{
			return false;
		}

		public void FindWalls(List<Vector3> wallBuffer, float range)
		{
		}

		private void FindWalls(int nodeIndex, List<Vector3> wallBuffer, Vector3 position, float range)
		{
		}

		private bool FindNextCorners(Vector3 origin, int startIndex, List<Vector3> funnelPath, int numCorners, out bool lastCorner)
		{
			lastCorner = default(bool);
			return false;
		}
	}
}
