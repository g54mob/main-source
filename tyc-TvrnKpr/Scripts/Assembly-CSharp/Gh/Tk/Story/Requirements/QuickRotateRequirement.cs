namespace Gh.Tk.Story.Requirements
{
	public class QuickRotateRequirement : TimedRequirementNodeBase
	{
		protected override bool IsRequirementMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
