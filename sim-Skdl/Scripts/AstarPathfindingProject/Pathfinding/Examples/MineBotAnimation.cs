using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_mine_bot_animation.php")]
	public class MineBotAnimation : VersionedMonoBehaviour
	{
		public Animator anim;

		public GameObject endOfPathEffect;

		private bool isAtDestination;

		private IAstarAI ai;

		private Transform tr;

		protected Vector3 lastTarget;

		protected override void Awake()
		{
		}

		private void OnTargetReached()
		{
		}

		protected void Update()
		{
		}
	}
}
