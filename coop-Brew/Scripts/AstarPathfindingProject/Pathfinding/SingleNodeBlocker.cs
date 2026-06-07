using UnityEngine;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/singlenodeblocker.html")]
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
