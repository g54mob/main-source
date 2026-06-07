using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopMapNodeData : MapNodeData
{
	public bool IsCreatedShopContent;

	[SerializeField]
	private List<CardData> list_ShopContent;

	[SerializeField]
	private List<bool> list_IsCardBought;

	[SerializeField]
	private List<bool> list_IsDiscount;

	[SerializeField]
	private int rerollCost;

	[SerializeField]
	private bool isHealSold;

	public static ShopMapNodeData TurnToShopMapNodeData(MapNodeData mapNodeData)
	{
		return null;
	}

	public ShopMapNodeData(int index, int step, int indexInStep, eStageType mapNodeType, eMapNodeState state)
		: base(0, 0, 0, default(eStageType), default(eMapNodeState))
	{
	}

	public void SetShopContent(List<CardData> list_CardData, List<bool> list_IsDiscount)
	{
	}

	public void ClearBoughtRecord()
	{
	}

	public bool IsAllItemBought()
	{
		return false;
	}

	public void SetItemBought(CardData itemData)
	{
	}

	public bool IsItemBought(CardData itemData)
	{
		return false;
	}

	public bool IsItemDiscount(CardData itemData)
	{
		return false;
	}

	public void SetHealSold(bool isSold)
	{
	}

	public bool IsHealSold()
	{
		return false;
	}

	public List<CardData> GetShopContent()
	{
		return null;
	}

	public void SetRerollCost(int cost)
	{
	}

	public int GetRerollCost()
	{
		return 0;
	}
}
