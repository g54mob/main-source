using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class NodeLink3Node : PointNode
	{
		public NodeLink3 link;

		public Vector3 portalA;

		public Vector3 portalB;

		public NodeLink3Node(AstarPath active)
			: base(null)
		{
		}

		public override bool GetPortal(GraphNode other, List<Vector3> left, List<Vector3> right, bool backwards)
		{
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
