using System;
using UnityEngine;

[Serializable]
public struct ItemPriceModifier : IEquatable<ItemPriceModifier>
{
	public string itemId;

	public float priceMultiplier;

	public ItemPriceModifier(string itemId, float priceMultiplier = 1f)
	{
		this.itemId = itemId;
		this.priceMultiplier = priceMultiplier;
	}

	public bool Equals(ItemPriceModifier other)
	{
		if (itemId == other.itemId)
		{
			return Mathf.Approximately(priceMultiplier, other.priceMultiplier);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ItemPriceModifier other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (17 * 31 + (itemId?.GetHashCode() ?? 0)) * 31 + priceMultiplier.GetHashCode();
	}

	public static bool operator ==(ItemPriceModifier left, ItemPriceModifier right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ItemPriceModifier left, ItemPriceModifier right)
	{
		return !left.Equals(right);
	}
}
