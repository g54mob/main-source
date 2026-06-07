using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class MetricsStateDto
{
	[Key(0)]
	public int Releases;

	[Key(1)]
	public int BombdusterWins;

	[Key(2)]
	public double MoneyLifetime;

	[Key(3)]
	public double BugsSquashed;

	[Key(4)]
	public List<ComponentUnlockedStateDto> ComponentsUnlocked = new List<ComponentUnlockedStateDto>();

	[Key(5)]
	public int BombdusterAdvancedWins;

	[Key(6)]
	public int BombdusterExpertWins;

	[Key(7)]
	public double BugsStagedAuto;

	[Key(8)]
	public int DatacenterReprovisionedFromDegraded;

	[Key(9)]
	public int DatacenterReprovisionedFromCritical;

	[Key(10)]
	public int LootchestsOpened;

	[Key(11)]
	public double MoneySpendUpgrades;

	[Key(12)]
	public double MarketingBlastTotalTime;
}
