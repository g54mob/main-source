using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/turnbasedai.html")]
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
