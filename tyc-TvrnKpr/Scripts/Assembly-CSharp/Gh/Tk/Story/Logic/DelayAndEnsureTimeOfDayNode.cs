namespace Gh.Tk.Story.Logic
{
	public class DelayAndEnsureTimeOfDayNode : DelayNode
	{
		public int hourRangeStart;

		public int hourRangeEnd;

		protected override bool AreFurtherRequirementsMet(ActiveStory story)
		{
			return false;
		}
	}
}
