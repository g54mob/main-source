using System;
using UnityEngine;

[Serializable]
public class ItemStack
{
	public string itemId;

	public int count;

	public ItemStack()
	{
		itemId = string.Empty;
		count = 0;
	}

	public ItemStack(string id, int itemCount)
	{
		itemId = id;
		count = itemCount;
	}

	public bool IsValid()
	{
		if (!string.IsNullOrEmpty(itemId))
		{
			return count > 0;
		}
		return false;
	}

	public void AddCount(int amount)
	{
		count = Mathf.Max(0, count + amount);
	}

	public void RemoveCount(int amount)
	{
		count = Mathf.Max(0, count - amount);
	}
}
