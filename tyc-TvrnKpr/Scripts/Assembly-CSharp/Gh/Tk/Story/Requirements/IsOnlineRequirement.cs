namespace Gh.Tk.Story.Requirements
{
	public class IsOnlineRequirement : RequirementNode
	{
		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
