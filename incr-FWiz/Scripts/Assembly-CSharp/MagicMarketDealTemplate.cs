using System;

[Serializable]
public class MagicMarketDealTemplate
{
	public CostStack Cost;

	public ItemStack Result;

	public bool Valid => false;

	public MagicMarketDeal CreateDeal(bool special)
	{
		return null;
	}
}
