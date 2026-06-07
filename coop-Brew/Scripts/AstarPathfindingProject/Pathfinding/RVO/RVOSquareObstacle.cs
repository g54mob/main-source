using UnityEngine;

namespace Pathfinding.RVO
{
	[AddComponentMenu(null)]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/rvosquareobstacle.html")]
	public class RVOSquareObstacle : RVOObstacle
	{
		public float height;

		public Vector2 size;

		public Vector2 center;

		protected override bool StaticObstacle => false;

		protected override bool ExecuteInEditor => false;

		protected override bool LocalCoordinates => false;

		protected override float Height => 0f;
	}
}
