using UnityEngine;

namespace Pathfinding.RVO
{
	public class ObstacleVertex
	{
		public bool ignore;

		public Vector3 position;

		public Vector2 dir;

		public float height;

		public RVOLayer layer;

		public ObstacleVertex next;

		public ObstacleVertex prev;
	}
}
