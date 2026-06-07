namespace Gh.Tk.Story.Requirements
{
	public class ReachGameTimeOrClickOnButtonRequirementNode : CheckListItemClickRequirementNode
	{
		public float daysInTheFuture;

		private bool IgnoreTimeRequirement => false;

		private string TargetTimeKey => null;

		public override string GetLabelPostfixKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		private float GetTargetTime(ActiveStory story)
		{
			return 0f;
		}
	}
}
