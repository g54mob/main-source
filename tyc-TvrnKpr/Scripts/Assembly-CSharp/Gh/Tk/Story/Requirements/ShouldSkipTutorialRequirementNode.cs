namespace Gh.Tk.Story.Requirements
{
	public class ShouldSkipTutorialRequirementNode : RequirementNode
	{
		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
