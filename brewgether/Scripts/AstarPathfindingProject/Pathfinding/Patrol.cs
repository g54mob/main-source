using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/Patrol")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/patrol.html")]
	public class Patrol : VersionedMonoBehaviour
	{
		public Transform[] targets;

		public float delay;

		public bool updateDestinationEveryFrame;

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
