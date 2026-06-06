using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class ResourceManager : SceneBehaviour, IInventorySpaceLimiter
{
	private static Community _community;

	private static CommunityInventory _communityInventory;

	private Dictionary<ItemProperties, int> _resourceLimits = new Dictionary<ItemProperties, int>();

	private Dictionary<ItemProperties, int> _resourceCapacties = new Dictionary<ItemProperties, int>();

	private void Start()
	{
		Dictionary<ItemProperties, int>.Enumerator enumerator = _resourceLimits.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (0 < enumerator.Current.Value)
			{
				UpdateResourceCapacity(enumerator.Current.Key);
			}
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ItemFarmed, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ItemSalvagered, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.ItemsProduced, OnItemEvent);
		GameEventDispatcher.RemoveListener(GameEventType.StoredItemTaken, OnItemEvent);
	}

	public void Initialize()
	{
		_community = Community.PlayerCommunity;
		_communityInventory = _community.Inventory;
		GameEventDispatcher.AddListener(GameEventType.ItemFarmed, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.ItemSalvagered, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.ItemsProduced, OnItemEvent);
		GameEventDispatcher.AddListener(GameEventType.StoredItemTaken, OnItemEvent);
	}

	public static bool AreItemsAvailable(ItemProperties itemProperties, int amount)
	{
		return _communityInventory.ReturnContainsItem(itemProperties, amount);
	}

	public static bool AreItemsAvailable(CountedItemProperty countedItem)
	{
		return _communityInventory.ReturnContainsItem(countedItem.ItemProperties, countedItem.Amount);
	}

	public static bool AreItemsAvailable(IEnumerable<CountedItemProperty> countedItems)
	{
		return _communityInventory.ReturnContainsItems(countedItems);
	}

	public static bool AreCommunityResourcesAvailable(CountedItemProperty[] resources)
	{
		if (!BuildingDevTools.InstantBuild && !BuildingDevTools.AutoSpawnResources)
		{
			return Community.PlayerCommunity.Inventory.ReturnContainsItems(resources);
		}
		return true;
	}

	public static bool TryReserveItems(ItemProperties itemProperties, int amount, out List<Item> reservedItems)
	{
		reservedItems = null;
		if (AreItemsAvailable(itemProperties, amount))
		{
			return _communityInventory.TryReserveItems(itemProperties, amount, out reservedItems);
		}
		return false;
	}

	public static bool TryReserveClosestItems(IPathfindingNodeProvider destination, ItemProperties itemProperties, int amount, out List<Item> reservedItems)
	{
		reservedItems = null;
		if (AreItemsAvailable(itemProperties, amount))
		{
			return _communityInventory.TryReserveClosestItems(destination, itemProperties, amount, out reservedItems);
		}
		return false;
	}

	public static List<Item> ReserveClosestItems(IPathfindingNodeProvider destination, IReadOnlyList<CountedItemProperty> requiredResources)
	{
		if (requiredResources.IsNullOrEmpty())
		{
			return new List<Item>();
		}
		if (Community.PlayerCommunity.Inventory.TryReturnReserveClosestItems(destination, requiredResources, out var reservedItems))
		{
			return reservedItems;
		}
		throw new NotImplementedException();
	}

	public static List<Item> ReserveClosestItems(IPathfindingNodeProvider destination, CountedItemProperty[] requiredResources)
	{
		if (Community.PlayerCommunity.Inventory.TryReturnReserveClosestItems(destination, requiredResources, out var reservedItems))
		{
			return reservedItems;
		}
		throw new NotImplementedException();
	}

	public static int CountAvailableItems(ItemProperties itemProperties)
	{
		return Community.PlayerCommunity.Inventory.ReturnCount(itemProperties);
	}

	public void SpawnItemToInventory(Inventory inventory, Item item)
	{
		if (inventory == null)
		{
			Debugger.Warning($"Could not spawn item {item.Properties.name} because no valid inventory was passed.");
		}
		else
		{
			inventory.AddItem(item, SubInventoryType.Storage);
		}
	}

	public void RestoreResourceLimits(Dictionary<ItemProperties, int> limits)
	{
		int defaultProductionLimit = GameManager.Settings.ItemSettings.DefaultProductionLimit;
		_communityInventory = Community.PlayerCommunity.Inventory;
		foreach (KeyValuePair<ItemProperties, int> limit in limits)
		{
			if (limit.Value != defaultProductionLimit)
			{
				if (_resourceLimits.ContainsKey(limit.Key))
				{
					_resourceLimits[limit.Key] = limit.Value;
				}
				else
				{
					_resourceLimits.Add(limit.Key, limit.Value);
				}
			}
		}
	}

	public void AddResourceLimit(ItemProperties resource)
	{
		int defaultProductionLimit = GameManager.Settings.ItemSettings.DefaultProductionLimit;
		_resourceLimits.TryAdd(resource, defaultProductionLimit);
	}

	public void AddProductionLimits(IItemProducer producer)
	{
		if (producer.ProducedItems.IsNullOrEmpty())
		{
			return;
		}
		foreach (ItemProperties producedItem in producer.ProducedItems)
		{
			AddResourceLimit(producedItem);
		}
	}

	public void UpdateResourceLimit(ItemProperties resource, int limit)
	{
		if (_resourceLimits.ContainsKey(resource))
		{
			_resourceLimits[resource] = limit;
			UpdateResourceCapacity(resource);
		}
	}

	public bool IsResourceCapacityReached(ItemProperties properties)
	{
		if (_resourceCapacties.TryGetValue(properties, out var value))
		{
			return value <= 0;
		}
		return false;
	}

	public bool IsProductionLimitReached(ItemProperties itemProperties, int amount = 1)
	{
		if (_resourceCapacties.TryGetValue(itemProperties, out var value))
		{
			foreach (IItemProducer producer in _community.Producers)
			{
				value -= producer.GetItemsInProductionCount(itemProperties);
			}
			return value < amount;
		}
		return false;
	}

	private void UpdateResourceCapacity(ItemProperties itemProperties)
	{
		if (itemProperties == null || !_resourceLimits.TryGetValue(itemProperties, out var value))
		{
			return;
		}
		if (value < 0)
		{
			_resourceCapacties.Remove(itemProperties);
			return;
		}
		int num = _communityInventory.ReturnStoredItemCount(itemProperties);
		int value2 = value - num;
		if (!_resourceCapacties.TryAdd(itemProperties, value2))
		{
			_resourceCapacties[itemProperties] = value2;
		}
		ItemEvent.Dispatch(GameEventType.ItemResourceLimitUpdated, itemProperties);
	}

	public bool FitsItem(Item item)
	{
		if (!_resourceCapacties.TryGetValue(item.Properties, out var value) || 0 < value)
		{
			return _communityInventory.FitsItem(item);
		}
		return false;
	}

	public bool FitsItem(ItemProperties itemProperties)
	{
		if (!_resourceCapacties.TryGetValue(itemProperties, out var value) || 0 < value)
		{
			return _communityInventory.FitsItem(itemProperties);
		}
		return false;
	}

	public int GetCapacity(ItemProperties itemProperties)
	{
		return ReturnItemCapacity(itemProperties);
	}

	public bool HasResourceLimit()
	{
		return 0 < _resourceLimits.Count;
	}

	public Dictionary<ItemProperties, int> ReturnResourceLimits()
	{
		return _resourceLimits;
	}

	public int ReturnResourceLimit(ItemProperties resource)
	{
		if (_resourceLimits.TryGetValue(resource, out var value))
		{
			return value;
		}
		return -1;
	}

	public int ReturnItemCapacity(ItemProperties itemProperties)
	{
		if (_resourceCapacties.TryGetValue(itemProperties, out var value))
		{
			return Mathf.Min(value, _communityInventory.ReturnItemCapacity(itemProperties));
		}
		return _communityInventory.ReturnItemCapacity(itemProperties);
	}

	private void OnItemEvent(GameEvent gameEvent)
	{
		if (!(gameEvent is ItemEvent { EventType: var eventType } itemEvent))
		{
			return;
		}
		switch (eventType)
		{
		case GameEventType.ItemFarmed:
		case GameEventType.ItemSalvagered:
		case GameEventType.StoredItemTaken:
			UpdateResourceCapacity(itemEvent.ItemProperties);
			break;
		case GameEventType.ItemsProduced:
		{
			foreach (ItemProperties producedItem in itemEvent.ProducedItems)
			{
				_ = producedItem;
				UpdateResourceCapacity(itemEvent.ItemProperties);
			}
			break;
		}
		}
	}
}
