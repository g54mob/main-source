using System;

[Serializable]
public class FounderShareHolder : Company
{
	public Employee Founder;

	public SDateTime Expiration;

	public FounderShareHolder()
	{
	}

	public FounderShareHolder(Employee founder, SDateTime time, MarketSimulation sim, SDateTime expiration)
		: base("FounderShareCompany".Loc(founder.FullName), 100.0, time, sim)
	{
		Founder = founder;
		Expiration = expiration;
	}

	public override bool CanTakeStockFrom()
	{
		return false;
	}
}
