using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_bezier_mover.php")]
	public class BezierMover : MonoBehaviour
	{
		public Transform[] points;

		public float speed;

		public float tiltAmount;

		private float time;

		private Vector3 Position(float t)
		{
			return default(Vector3);
		}

		private void Update()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
