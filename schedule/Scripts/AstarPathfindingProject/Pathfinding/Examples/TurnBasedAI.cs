using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_turn_based_a_i.php")]
	public class TurnBasedAI : VersionedMonoBehaviour
	{
		public int movementPoints;

		public BlockManager blockManager;

		public SingleNodeBlocker blocker;

		public GraphNode targetNode;

		public BlockManager.TraversalProvider traversalProvider;

		private void Start()
		{
		}

		protected override void Awake()
		{
		}
	}
}
