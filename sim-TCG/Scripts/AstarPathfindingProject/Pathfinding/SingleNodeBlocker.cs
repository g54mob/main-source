using System;
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
			BlockAt(base.transform.position);
		}

		public void BlockAt(Vector3 position)
		{
			Unblock();
			GraphNode node = AstarPath.active.GetNearest(position, NNConstraint.None).node;
			if (node != null)
			{
				Block(node);
			}
		}

		public void Block(GraphNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			manager.InternalBlock(node, this);
			lastBlocked = node;
		}

		public void Unblock()
		{
			if (lastBlocked == null || lastBlocked.Destroyed)
			{
				lastBlocked = null;
				return;
			}
			manager.InternalUnblock(lastBlocked, this);
			lastBlocked = null;
		}
	}
}
