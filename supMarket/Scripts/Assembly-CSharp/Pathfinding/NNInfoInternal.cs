using UnityEngine;

namespace Pathfinding
{
	public struct NNInfoInternal
	{
		public GraphNode node;

		public GraphNode constrainedNode;

		public Vector3 clampedPosition;

		public Vector3 constClampedPosition;

		public NNInfoInternal(GraphNode node)
		{
			this.node = null;
			constrainedNode = null;
			clampedPosition = default(Vector3);
			constClampedPosition = default(Vector3);
		}

		public void UpdateInfo()
		{
		}
	}
}
