using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_door_controller.php")]
	public class DoorController : MonoBehaviour
	{
		private bool open;

		public int opentag;

		public int closedtag;

		public bool updateGraphsWithGUO;

		public float yOffset;

		private Bounds bounds;

		public void Start()
		{
		}

		private void OnGUI()
		{
		}

		public void SetState(bool open)
		{
		}
	}
}
