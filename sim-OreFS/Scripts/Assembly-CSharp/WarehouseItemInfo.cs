using System;
using UnityEngine;

[Serializable]
public struct WarehouseItemInfo
{
	public string itemId;

	public T_ItemSO itemSO;

	public int count;

	public string Name
	{
		get
		{
			if (!(itemSO != null))
			{
				return itemId;
			}
			return itemSO.Name;
		}
	}

	public Sprite Icon => itemSO?.Icon;

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(itemId))
			{
				return count > 0;
			}
			return false;
		}
	}

	public WarehouseItemInfo(string itemId, T_ItemSO itemSO, int count)
	{
		this.itemId = itemId;
		this.itemSO = itemSO;
		this.count = count;
	}
}
