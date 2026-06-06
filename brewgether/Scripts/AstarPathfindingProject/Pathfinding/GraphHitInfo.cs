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

		public readonly float distance => 0f;
	}
}
