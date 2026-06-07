using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
	public class Patrol : VersionedMonoBehaviour
	{
		public Transform[] targets;

		public float delay;

		private int index;

		private IAstarAI agent;

		private float switchTime;

		protected override void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
