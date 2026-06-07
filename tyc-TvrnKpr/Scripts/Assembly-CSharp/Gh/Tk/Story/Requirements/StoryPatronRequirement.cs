namespace Gh.Tk.Story.Requirements
{
	public class StoryPatronRequirement : RequirementNode
	{
		public StoryPatronConfig patronConfig;

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}

		public Patron GetPatronForStory()
		{
			return null;
		}

		private bool IsPatronAvailableForStory(Patron patron)
		{
			return false;
		}
	}
}
