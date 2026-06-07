namespace Gh.Tk.Story.Requirements
{
	public class LevelRequirementNode : RequirementNode
	{
		public enum FreeplayFilter
		{
			All = 0,
			OnlyFreeplay = 1,
			OnlyCampaign = 2
		}

		public GameLevel level;

		public FreeplayFilter freeplayFilter;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
