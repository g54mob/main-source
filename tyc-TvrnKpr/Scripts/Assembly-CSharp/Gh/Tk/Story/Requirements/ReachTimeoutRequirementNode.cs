namespace Gh.Tk.Story.Requirements
{
	public class ReachTimeoutRequirementNode : RequirementNode
	{
		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		private float GetTargetTimeFromChallengeNode(ActiveStory story)
		{
			return 0f;
		}
	}
}
