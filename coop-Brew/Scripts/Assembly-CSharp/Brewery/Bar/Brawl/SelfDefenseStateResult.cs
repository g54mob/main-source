namespace Brewery.Bar.Brawl
{
	public class SelfDefenseStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool TargetLost { get; set; }

		public bool TimedOut { get; set; }

		public bool WasKnockedOut { get; set; }

		public bool TargetFled { get; set; }
	}
}
