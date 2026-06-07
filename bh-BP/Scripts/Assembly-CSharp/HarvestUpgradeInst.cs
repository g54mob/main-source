using System;

[Serializable]
public class HarvestUpgradeInst
{
	public HarvestUpgradeType Type;

	public int Lvl;

	public HarvestUpgradeInst(HarvestUpgradeType type)
	{
	}

	public HarvestUpgradeInfo GetInfo()
	{
		return null;
	}

	public int GetBonusAmt()
	{
		return 0;
	}
}
