using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CountedItemProperty
{
	[Tooltip("Amount of the item property.")]
	[FormerlySerializedAs("AmountNeeded")]
	public int Amount;

	[Tooltip("Item property to keep count of.")]
	public ItemProperties ItemProperties;

	[NonSerialized]
	[HideInInspector]
	public int ReservedAmount;

	[NonSerialized]
	private static List<CountedItemProperty> _pool = new List<CountedItemProperty>();

	public CountedItemProperty(ItemProperties properties, int amount)
	{
		ItemProperties = properties;
		Amount = amount;
		ReservedAmount = 0;
	}

	public CountedItemProperty(CountedItemProperty other)
		: this(other.ItemProperties, other.Amount)
	{
	}

	public static CountedItemProperty Get(ItemProperties properties, int amount)
	{
		int count = _pool.Count;
		if (0 < count)
		{
			CountedItemProperty countedItemProperty = _pool[--count];
			countedItemProperty.ItemProperties = properties;
			_pool.RemoveAt(count);
			return countedItemProperty;
		}
		return new CountedItemProperty(properties, amount);
	}

	public void Repool()
	{
		ItemProperties = null;
		Amount = 0;
		ReservedAmount = 0;
		_pool.Add(this);
	}

	public override bool Equals(object other)
	{
		CountedItemProperty countedItemProperty = (CountedItemProperty)other;
		if (Amount != countedItemProperty.Amount)
		{
			return false;
		}
		if (ItemProperties != countedItemProperty.ItemProperties)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static int ReturnTotalAmount(IEnumerable<CountedItemProperty> countedItems)
	{
		int num = 0;
		foreach (CountedItemProperty countedItem in countedItems)
		{
			num += countedItem.Amount;
		}
		return num;
	}

	public string ReturnLocalizedString()
	{
		if (Amount == 0)
		{
			return "";
		}
		return $" {Amount} x {ItemProperties.LocalizedName}";
	}

	public bool ContainsTag(Item.Tags tag)
	{
		return (ItemProperties.Tags & tag) != 0;
	}

	public bool IsNullOrEmpty()
	{
		if (!(ItemProperties == null))
		{
			return Amount <= 0;
		}
		return true;
	}
}
