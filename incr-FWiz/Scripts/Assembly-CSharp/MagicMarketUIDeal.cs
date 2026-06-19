using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;

public class MagicMarketUIDeal : ClickListener
{
	public ItemStackUI CostItemStack;

	public ItemStackUI ResultItemStack;

	private MagicMarketDeal _deal;

	public GameObject SpecialDealSymbol;

	public event Action<MagicMarketDeal> AnnounceSelect
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate(MagicMarketDeal deal)
	{
	}

	public override void Click()
	{
	}
}
