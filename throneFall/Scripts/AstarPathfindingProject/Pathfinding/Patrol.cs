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

		private int index = -1;

		private IAstarAI agent;

		private float switchTime = float.NegativeInfinity;

		protected override void Awake()
		{
			base.Awake();
			agent = GetComponent<IAstarAI>();
		}

		private void Update()
		{
			if (targets.Length != 0)
			{
				if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
				{
					switchTime = Time.time + delay;
				}
				if (Time.time >= switchTime)
				{
					index++;
					switchTime = float.PositiveInfinity;
					index %= targets.Length;
					agent.destination = targets[index].position;
					agent.SearchPath();
				}
				else if (updateDestinationEveryFrame)
				{
					index %= targets.Length;
					agent.destination = targets[index].position;
				}
			}
		}
	}
}
