namespace Brewery.Bar.Brawl
{
	public class SpectatorStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool ShouldJoin { get; set; }

		public bool ShouldLeave { get; set; }

		public bool TimedOut { get; set; }

		public bool BrawlEnded { get; set; }

		public string Reason { get; set; }
	}
}
