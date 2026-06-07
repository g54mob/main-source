using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_block_manager.php")]
	public class BlockManager : VersionedMonoBehaviour
	{
		public enum BlockMode
		{
			AllExceptSelector = 0,
			OnlySelector = 1
		}

		public class TraversalProvider : ITraversalProvider
		{
			private readonly BlockManager blockManager;

			private readonly List<SingleNodeBlocker> selector;

			public BlockMode mode { get; private set; }

			public TraversalProvider(BlockManager blockManager, BlockMode mode, List<SingleNodeBlocker> selector)
			{
			}

			public bool CanTraverse(Path path, GraphNode node)
			{
				return false;
			}

			public uint GetTraversalCost(Path path, GraphNode node)
			{
				return 0u;
			}
		}

		private Dictionary<GraphNode, List<SingleNodeBlocker>> blocked;

		private void Start()
		{
		}

		public bool NodeContainsAnyOf(GraphNode node, List<SingleNodeBlocker> selector)
		{
			return false;
		}

		public bool NodeContainsAnyExcept(GraphNode node, List<SingleNodeBlocker> selector)
		{
			return false;
		}

		public void InternalBlock(GraphNode node, SingleNodeBlocker blocker)
		{
		}

		public void InternalUnblock(GraphNode node, SingleNodeBlocker blocker)
		{
		}
	}
}
