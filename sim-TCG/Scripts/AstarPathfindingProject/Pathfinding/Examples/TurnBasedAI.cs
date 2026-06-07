using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/turnbasedai.html")]
	public class TurnBasedAI : VersionedMonoBehaviour
	{
		public int movementPoints = 2;

		public BlockManager blockManager;

		public SingleNodeBlocker blocker;

		public GraphNode targetNode;

		public BlockManager.TraversalProvider traversalProvider;

		private void Start()
		{
			blocker.BlockAtCurrentPosition();
		}

		protected override void Awake()
		{
			base.Awake();
			traversalProvider = new BlockManager.TraversalProvider(blockManager, BlockManager.BlockMode.AllExceptSelector, new List<SingleNodeBlocker> { blocker });
		}
	}
}
