using Pathfinding.Util;
using Unity.Entities;
using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/AIDestinationSetter")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/aidestinationsetter.html")]
	public class AIDestinationSetter : VersionedMonoBehaviour, IRuntimeBaker
	{
		public Transform target;

		public bool useRotation;

		private IAstarAI ai;

		private Entity entity;

		private World world;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		void IRuntimeBaker.OnCreatedEntity(World world, Entity entity)
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
