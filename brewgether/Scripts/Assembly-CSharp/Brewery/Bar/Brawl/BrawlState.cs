namespace Brewery.Bar.Brawl
{
	public enum BrawlState : byte
	{
		Idle = 0,
		Candidate = 1,
		Aggressor = 2,
		Defender = 3,
		Spectator = 4,
		Fleeing = 5,
		Exempt = 6,
		SelfDefense = 7
	}
}
