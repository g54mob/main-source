namespace Brewery.Bar.Brawl
{
	public class ExemptStateResult : IBrawlStateResult
	{
		public bool Continue { get; set; }

		public bool CooldownExpired { get; set; }
	}
}
