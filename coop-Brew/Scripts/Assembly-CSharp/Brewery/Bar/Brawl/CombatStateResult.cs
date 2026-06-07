namespace Brewery.Bar.Brawl
{
	public class CombatStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool TargetLost { get; set; }

		public bool WasKnockedOut { get; set; }

		public bool TargetKnockedOut { get; set; }

		public bool BrawlEnded { get; set; }

		public bool ShouldFlee { get; set; }
	}
}
