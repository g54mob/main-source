using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.Water;
using UnityEngine;

public class ItemToDistribute
{
	[Serializable]
	public class PersistentData
	{
		private int _itemPropertiesIndex;

		private float _available;

		[OptionalField(VersionAdded = 2)]
		private float _consumedToday;

		private float _refillThreshold;

		private float _refillAmount;

		private float _refillPercentage;

		public PersistentData(ItemToDistribute instance)
		{
			_itemPropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(instance.ItemProperties);
			_available = instance.Available;
			_consumedToday = instance.ConsumedToday;
			_refillThreshold = instance.RefillThreshold;
			_refillAmount = instance.RefillAmount;
			_refillPercentage = instance._refillPercentage;
		}

		public bool TryRestore(out ItemToDistribute instance, ItemDistributer itemDistributer)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(_itemPropertiesIndex, out var reference))
			{
				if (itemDistributer.TryReturnItemToDistribute(reference, out instance))
				{
					instance.Available = Mathf.Max(_available, instance.Available);
					instance.ConsumedToday = _consumedToday;
					instance.RefillThreshold = _refillThreshold;
					instance.RefillAmount = _refillAmount;
					instance._refillPercentage = _refillPercentage;
					return false;
				}
				instance = new ItemToDistribute(itemDistributer, reference)
				{
					Available = _available,
					ConsumedToday = _consumedToday,
					RefillThreshold = _refillThreshold,
					RefillAmount = _refillAmount,
					_refillPercentage = _refillPercentage
				};
				return true;
			}
			instance = null;
			return false;
		}
	}

	private readonly List<IItemConsumer> _consumers = new List<IItemConsumer>();

	private float _refillPercentage = 1f;

	public ItemDistributer ItemDistributer { get; private set; }

	public ItemProperties ItemProperties { get; private set; }

	public int UnitsPerItem => ItemDistributer.UnitsPerItem;

	public float Capacity { get; private set; }

	public float Available { get; private set; }

	public float Consumption { get; private set; }

	public int ConsumptionItemCount => Mathf.CeilToInt(Consumption / (float)UnitsPerItem);

	public float ConsumedToday { get; private set; }

	public float RefillThreshold { get; private set; }

	public float RefillAmount { get; private set; }

	public bool IsUnableToImport { get; private set; }

	public ItemToDistribute(ItemDistributer itemDistributer, ItemProperties itemProperties)
	{
		ItemDistributer = itemDistributer;
		ItemProperties = itemProperties;
		Capacity = itemDistributer.ItemCapacity * UnitsPerItem;
		Available = 0f;
	}

	public void Update()
	{
		int count = _consumers.Count;
		while (0 < count--)
		{
			float num = _consumers[count].Consume(Available);
			Available -= num;
			ConsumedToday += num;
		}
	}

	public void LateUpdate(bool dayEnded)
	{
		if (dayEnded)
		{
			ConsumedToday = 0f;
		}
		if (Available <= RefillThreshold && ItemDistributer.ReturnItemImportCount(ItemProperties) == 0)
		{
			int a = Mathf.CeilToInt(RefillAmount / (float)UnitsPerItem);
			int b = ItemDistributer.Buildable.Community.Inventory.ReturnCount(ItemProperties);
			int num = Mathf.Min(a, b);
			if (0 < num && ResourceManager.TryReserveItems(ItemProperties, num, out var reservedItems))
			{
				IsUnableToImport = false;
				ItemDistributer.ImportItems(reservedItems);
			}
			else if (!IsUnableToImport)
			{
				IsUnableToImport = true;
				ItemDistributer.UpdateUnableToImport();
			}
		}
	}

	public bool AttachConsumer(IItemConsumer consumer)
	{
		if (ItemProperties == consumer.ItemToConsumeProperties)
		{
			if (_consumers.AddUnique(consumer))
			{
				UpdateConsumption();
			}
			return true;
		}
		return false;
	}

	public bool DetachConsumer(IItemConsumer consumer)
	{
		if (ItemProperties == consumer.ItemToConsumeProperties)
		{
			if (_consumers.Remove(consumer))
			{
				UpdateConsumption();
			}
			return true;
		}
		return false;
	}

	public void DetachAllConsumers()
	{
		for (int num = _consumers.Count - 1; num >= 0; num--)
		{
			DetachConsumer(_consumers[num]);
		}
	}

	public void SetRefillThrehold(float value)
	{
		RefillThreshold = Mathf.Clamp(value, 0f, Capacity);
	}

	public void SetRefillAmount(float value)
	{
		RefillAmount = Mathf.Clamp(value, 0f, Capacity);
		_refillPercentage = ((Consumption == 0f) ? 1f : (RefillAmount / Consumption));
	}

	public void OnInventoryUpdated(Inventory inventory)
	{
		SubInventory subInventory = inventory.ReturnInventory(SubInventoryType.Import);
		Item item;
		while (subInventory.TryReturnItem(ItemProperties, out item))
		{
			inventory.TakeItem(item);
			Available = Mathf.Min(Available + (float)UnitsPerItem, Capacity);
		}
	}

	private void UpdateConsumption()
	{
		Consumption = 0f;
		foreach (IItemConsumer consumer in _consumers)
		{
			Consumption += consumer.ConsumptionPerDay;
		}
		RefillThreshold = Consumption * 0.1f;
		RefillAmount = Consumption * _refillPercentage;
	}

	public PersistentData ReturnPersitentData()
	{
		return new PersistentData(this);
	}

	public void Restore(WaterDistributer.PersistentData waterDistributerPD)
	{
		Available = Mathf.Max(Available, waterDistributerPD.Available);
		RefillThreshold = waterDistributerPD.RefillThreshold;
		RefillAmount = waterDistributerPD.RefillAmount;
	}
}
