using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_astar_smooth_follow2.php")]
	public class AstarSmoothFollow2 : MonoBehaviour
	{
		public Transform target;

		public float distance;

		public float height;

		public float damping;

		public bool smoothRotation;

		public bool followBehind;

		public float rotationDamping;

		public bool staticOffset;

		private void LateUpdate()
		{
		}
	}
}
