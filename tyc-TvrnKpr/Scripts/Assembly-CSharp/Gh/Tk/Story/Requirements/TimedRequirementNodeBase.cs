namespace Gh.Tk.Story.Requirements
{
	public abstract class TimedRequirementNodeBase : RequirementNode
	{
		public float secondsToComplete;

		private string StoryKey => null;

		public override int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		protected abstract bool IsRequirementMetInternal(ActiveStory story);

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
