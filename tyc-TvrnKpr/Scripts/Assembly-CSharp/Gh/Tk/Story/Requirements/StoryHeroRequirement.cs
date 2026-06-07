namespace Gh.Tk.Story.Requirements
{
	public class StoryHeroRequirement : RequirementNode
	{
		public StoryPatronConfig heroConfig;

		public bool isIntroductionStory;

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}

		private bool IsHeroAvailableForHeroStory(HeroData data)
		{
			return false;
		}
	}
}
