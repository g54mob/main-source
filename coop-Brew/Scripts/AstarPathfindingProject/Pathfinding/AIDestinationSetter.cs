using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/AIDestinationSetter")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/aidestinationsetter.html")]
	public class AIDestinationSetter : VersionedMonoBehaviour
	{
		public Transform target;

		public bool useRotation;

		private IAstarAI ai;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private static void OnUpdate(AIDestinationSetter[] components, int count)
		{
		}

		private void UpdateDestination()
		{
		}
	}
}
