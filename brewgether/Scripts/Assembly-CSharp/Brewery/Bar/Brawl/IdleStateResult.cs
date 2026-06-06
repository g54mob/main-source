namespace Brewery.Bar.Brawl
{
	public class IdleStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool ShouldBecomeCandidate { get; set; }

		public bool ShouldWatchBrawl { get; set; }

		public bool WasAttacked { get; set; }
	}
}
