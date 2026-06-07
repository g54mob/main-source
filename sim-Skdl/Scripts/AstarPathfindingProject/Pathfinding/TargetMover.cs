using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_target_mover.php")]
	public class TargetMover : MonoBehaviour
	{
		public LayerMask mask;

		public Transform target;

		private IAstarAI[] ais;

		public bool onlyOnDoubleClick;

		public bool use2D;

		private Camera cam;

		public void Start()
		{
		}

		public void OnGUI()
		{
		}

		private void Update()
		{
		}

		public void UpdateTargetPosition()
		{
		}
	}
}
