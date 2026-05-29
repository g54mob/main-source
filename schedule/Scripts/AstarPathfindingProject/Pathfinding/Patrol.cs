using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_patrol.php")]
	[UniqueComponent(tag = "ai.destination")]
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
