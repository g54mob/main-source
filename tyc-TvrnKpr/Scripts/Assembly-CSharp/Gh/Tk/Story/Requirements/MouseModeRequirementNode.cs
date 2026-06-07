namespace Gh.Tk.Story.Requirements
{
	public class MouseModeRequirementNode : RequirementNode
	{
		public GameController.MODE targetState;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
