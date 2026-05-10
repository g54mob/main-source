using UnityEngine;

namespace Pathfinding
{
	public struct GraphHitInfo
	{
		public Vector3 origin;

		public Vector3 point;

		public GraphNode node;

		public Vector3 tangentOrigin;

		public Vector3 tangent;

		public float distance => 0f;

		public GraphHitInfo(Vector3 point)
		{
			origin = default(Vector3);
			this.point = default(Vector3);
			node = null;
			tangentOrigin = default(Vector3);
			tangent = default(Vector3);
		}
	}
}
