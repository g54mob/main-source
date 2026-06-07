using UnityEngine;

namespace Pathfinding.RVO
{
	[AddComponentMenu("Pathfinding/Local Avoidance/Square Obstacle")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_r_v_o_1_1_r_v_o_square_obstacle.php")]
	public class RVOSquareObstacle : RVOObstacle
	{
		public float height;

		public Vector2 size;

		public Vector2 center;

		protected override bool StaticObstacle => false;

		protected override bool ExecuteInEditor => false;

		protected override bool LocalCoordinates => false;

		protected override float Height => 0f;

		protected override bool AreGizmosDirty()
		{
			return false;
		}

		protected override void CreateObstacles()
		{
		}
	}
}
