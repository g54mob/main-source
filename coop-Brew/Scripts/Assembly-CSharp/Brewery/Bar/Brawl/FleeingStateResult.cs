namespace Brewery.Bar.Brawl
{
	public class FleeingStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool ReachedHome { get; set; }

		public bool TimedOut { get; set; }

		public bool NavAgentStuck { get; set; }
	}
}
