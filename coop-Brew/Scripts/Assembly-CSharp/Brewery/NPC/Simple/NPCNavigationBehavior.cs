using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class NPCNavigationBehavior
	{
		private readonly NPCContext ctx;

		private bool _cachedArrivalResult;

		private float _lastArrivalCheckTime;

		private float _lastArrivalCheckDistance;

		private const float ARRIVAL_CACHE_DURATION = 0.1f;

		public float RemainingDistance => 0f;

		public NPCNavigationBehavior(NPCContext context)
		{
		}

		public bool EnsureAgentReady()
		{
			return false;
		}

		public bool SetDestination(Vector3 destination, NPCState newState, string debugTag = "")
		{
			return false;
		}

		public bool SafeSetDestination(Vector3 destination)
		{
			return false;
		}

		public bool HasArrived(float customDistance = -1f)
		{
			return false;
		}

		public void Stop()
		{
		}

		public void ForceNextArrivalCheck()
		{
		}
	}
}
