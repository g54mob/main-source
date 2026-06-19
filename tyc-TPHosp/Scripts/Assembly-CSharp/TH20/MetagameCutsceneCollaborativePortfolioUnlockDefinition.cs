namespace TH20
{
	public class MetagameCutsceneCollaborativePortfolioUnlockDefinition : MetagameCutsceneDefinition
	{
		public override MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map)
		{
			return new MetagameCutsceneCollaborativePortfolioUnlock(map, this);
		}
	}
}
