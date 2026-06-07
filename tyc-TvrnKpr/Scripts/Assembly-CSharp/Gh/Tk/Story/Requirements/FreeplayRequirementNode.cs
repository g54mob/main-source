namespace Gh.Tk.Story.Requirements
{
	public class FreeplayRequirementNode : RequirementNode
	{
		public bool isFreeplayMode;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
