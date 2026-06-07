using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class NPCBarVisitBehavior
	{
		private readonly NPCContext ctx;

		private readonly NPCNavigationBehavior navigation;

		private readonly NPCDrinkingBehavior drinking;

		public bool IsSitting => false;

		public NPCBarVisitBehavior(NPCContext context, NPCNavigationBehavior nav, NPCDrinkingBehavior drink)
		{
		}

		public void ArriveAtBarService()
		{
		}

		public void ArriveAtBarSpot()
		{
		}

		private void EnterSittingMode()
		{
		}

		public void ExitSittingMode()
		{
		}

		public void WanderAroundStandingSpot()
		{
		}

		public bool IsPositionReachable(Vector3 targetPosition, float maxPathLengthRatio = 3f)
		{
			return false;
		}
	}
}
