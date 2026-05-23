using System;
using Pathfinding.Util;
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
			ai = GetComponent<IAstarAI>();
			if (ai != null)
			{
				IAstarAI astarAI = ai;
				astarAI.onSearchPath = (Action)Delegate.Combine(astarAI.onSearchPath, new Action(UpdateDestination));
			}
			BatchedEvents.Add(this, BatchedEvents.Event.Update, OnUpdate);
		}

		private void OnDisable()
		{
			if (ai != null)
			{
				IAstarAI astarAI = ai;
				astarAI.onSearchPath = (Action)Delegate.Remove(astarAI.onSearchPath, new Action(UpdateDestination));
			}
			BatchedEvents.Remove(this);
		}

		private static void OnUpdate(AIDestinationSetter[] components, int count)
		{
			for (int i = 0; i < count; i++)
			{
				components[i].UpdateDestination();
			}
		}

		private void UpdateDestination()
		{
			if (target != null && ai != null)
			{
				ai.destination = target.position;
			}
		}
	}
}
