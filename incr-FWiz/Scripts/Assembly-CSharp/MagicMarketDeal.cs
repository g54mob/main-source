using System;

[Serializable]
public class MagicMarketDeal
{
	public CostStack Cost;

	public ItemStack Result;

	public bool Special;

	public bool Valid => false;
}
