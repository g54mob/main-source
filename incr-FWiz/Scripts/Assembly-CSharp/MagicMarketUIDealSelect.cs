using System.Collections.Generic;
using UnityEngine;

public class MagicMarketUIDealSelect : MonoBehaviour
{
	public MagicMarketUIDeal DealUIPrefab;

	public Transform DealParent;

	private List<MagicMarketUIDeal> _dealUIs;

	private MagicMarket _magicMarket;

	public void Hide()
	{
	}

	public void ClearDeals()
	{
	}

	public void ShowDeals(MagicMarket magicMarket, List<MagicMarketDeal> deals)
	{
	}

	public void OnSelectDeal(MagicMarketDeal deal)
	{
	}
}
