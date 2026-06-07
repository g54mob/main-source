namespace Gh.Tk.Story.Requirements
{
	public class FoodOnMenuRequirement : RequirementNode
	{
		public bool ignoreOrderableStatus;

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
