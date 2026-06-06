namespace Brewery.Bar.Brawl
{
	public class CandidateStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool BrawlStarted { get; set; }

		public bool TimedOut { get; set; }

		public bool Interrupted { get; set; }
	}
}
