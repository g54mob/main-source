using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_single_node_blocker.php")]
	public class SingleNodeBlocker : VersionedMonoBehaviour
	{
		public BlockManager manager;

		public GraphNode lastBlocked { get; private set; }

		public void BlockAtCurrentPosition()
		{
		}

		public void BlockAt(Vector3 position)
		{
		}

		public void Block(GraphNode node)
		{
		}

		public void Unblock()
		{
		}
	}
}
