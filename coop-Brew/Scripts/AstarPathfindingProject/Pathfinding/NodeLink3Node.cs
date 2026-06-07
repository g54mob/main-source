using UnityEngine;

namespace Pathfinding
{
	public class NodeLink3Node : PointNode
	{
		public NodeLink3 link;

		public Vector3 portalA;

		public Vector3 portalB;

		public NodeLink3Node(AstarPath astar)
		{
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = default(Vector3);
			right = default(Vector3);
			return false;
		}

		public GraphNode GetOther(GraphNode a)
		{
			return null;
		}

		private GraphNode GetOtherInternal(GraphNode a)
		{
			return null;
		}
	}
}
