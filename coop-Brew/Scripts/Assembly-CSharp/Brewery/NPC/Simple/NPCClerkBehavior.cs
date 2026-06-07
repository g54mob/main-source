using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class NPCClerkBehavior
	{
		private readonly NPCContext ctx;

		private readonly NPCNavigationBehavior navigation;

		private readonly NPCBarSelectionBehavior barSelection;

		private readonly SimpleNPCController controller;

		private float walkingToWorkStartTime;

		private const float ArrivalTimeoutSeconds = 30f;

		private const float FallbackArrivalDistance = 3f;

		private const float EmergencyWarpDistance = 10f;

		private int _playerLayerMask;

		private static readonly Collider[] _proximityResults;

		public NPCClerkBehavior(NPCContext context, NPCNavigationBehavior nav, NPCBarSelectionBehavior barSel, SimpleNPCController ctrl)
		{
		}

		private bool ShouldSkipBarVisit()
		{
			return false;
		}

		public void UpdateClerkBehavior()
		{
		}

		public void DetermineInitialClerkState()
		{
		}

		public void ForceClerkLeaveWork()
		{
		}

		public void FindWorkLocation(string locationId)
		{
		}

		private void ReleaseWorkLocation()
		{
		}

		private bool IsWorkHours()
		{
			return false;
		}

		private bool CheckClerkLeaveTime()
		{
			return false;
		}

		private void UpdatePlayerProximityRotation()
		{
		}

		private void ArriveAtHomeAfterWork()
		{
		}

		private bool HasArrived()
		{
			return false;
		}

		private void CheckWalkingToWorkTimeout()
		{
		}

		private void ForceArrivalAtWork(string reason)
		{
		}
	}
}
