using UnityEngine;

namespace Pathfinding.RVO
{
	[AddComponentMenu("")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/rvosquareobstacle.html")]
	public class RVOSquareObstacle : RVOObstacle
	{
		public float height = 1f;

		public Vector2 size = Vector3.one;

		public Vector2 center = Vector3.zero;

		protected override bool StaticObstacle => false;

		protected override bool ExecuteInEditor => true;

		protected override bool LocalCoordinates => true;

		protected override float Height => height;
	}
}
