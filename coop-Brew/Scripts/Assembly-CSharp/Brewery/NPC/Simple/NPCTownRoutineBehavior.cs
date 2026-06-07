namespace Brewery.NPC.Simple
{
	internal class NPCTownRoutineBehavior
	{
		private readonly NPCContext ctx;

		private readonly NPCNavigationBehavior navigation;

		private readonly NPCBarSelectionBehavior barSelection;

		private readonly NPCBarExitBehavior barExit;

		public NPCTownRoutineBehavior(NPCContext context, NPCNavigationBehavior nav, NPCBarSelectionBehavior barSel, NPCBarExitBehavior barExitBehavior)
		{
		}

		public void UpdateAtHome()
		{
		}

		public void UpdateAtHotspot()
		{
		}

		private void StartWalkingToHotspot()
		{
		}

		public void ArriveAtHotspot()
		{
		}

		private void StartWalkingToBar()
		{
		}

		public void StartWalkingHome()
		{
		}

		public void ArriveAtHome()
		{
		}
	}
}
