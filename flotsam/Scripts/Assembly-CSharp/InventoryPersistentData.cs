using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryPersistentData
{
	[OptionalField]
	private SubInventoryPersistentData[] _subInventories;

	public ItemPersistentData[] Storage;

	public int[] IncomingStorage;

	public ItemPersistentData[] Composition;

	public int[] IncomingComposition;

	public ItemPersistentData[] Resources;

	public int[] IncomingResources;

	public ItemPersistentData[] Import;

	public int[] IncomingImport;

	public ItemPersistentData[] Export;

	public int[] IncomingExport;

	public ItemPersistentData[] Liquid;

	public int[] IncomingLiquid;

	public ItemPersistentData[] Upgrade;

	public int[] IncomingUpgrade;

	public int[] FilterItemPropertyIndices;

	[NonSerialized]
	private Inventory _instance;

	public static List<InventoryPersistentData> RestoredInventories;

	public static UnityEvent RestoreReferencesEvent;

	public static List<InventoryPersistentData> SavedInventories;

	public static UnityEvent PopulateReferencesEvent;

	public static void InitializeRestoredInventories()
	{
		if (RestoredInventories == null)
		{
			RestoredInventories = new List<InventoryPersistentData>();
		}
		else
		{
			RestoredInventories.Clear();
		}
		if (RestoreReferencesEvent == null)
		{
			RestoreReferencesEvent = new UnityEvent();
		}
		else
		{
			RestoreReferencesEvent.RemoveAllListeners();
		}
	}

	public static void InitialzeSavedInventories()
	{
		if (SavedInventories == null)
		{
			SavedInventories = new List<InventoryPersistentData>();
		}
		else
		{
			SavedInventories.Clear();
		}
		if (PopulateReferencesEvent == null)
		{
			PopulateReferencesEvent = new UnityEvent();
		}
		else
		{
			PopulateReferencesEvent.RemoveAllListeners();
		}
	}

	public InventoryPersistentData(Inventory inventory)
	{
		if (inventory == null)
		{
			return;
		}
		_instance = inventory;
		using ListPool<SubInventoryPersistentData>.List list = ListPool<SubInventoryPersistentData>.Get(8);
		foreach (SubInventoryType subInventoryType in inventory.SubInventoryTypes)
		{
			SubInventoryPersistentData subInventoryPersistentData = SubInventoryPersistentData.Get(inventory, subInventoryType);
			if (subInventoryPersistentData != null)
			{
				list.Add(subInventoryPersistentData);
			}
		}
		_subInventories = list.ToArray();
	}

	public static void PopulateAllReferences()
	{
		PopulateReferencesEvent?.Invoke();
	}

	public void Restore(Inventory inventory, GameObject owner)
	{
		_instance = inventory;
		if (_subInventories == null)
		{
			RestoreList(inventory, SubInventoryType.Storage, Storage);
			RestoreList(inventory, SubInventoryType.Composition, Composition);
			RestoreList(inventory, SubInventoryType.Resources, Resources);
			RestoreList(inventory, SubInventoryType.Import, Import);
			RestoreList(inventory, SubInventoryType.Export, Export);
			RestoreList(inventory, SubInventoryType.Liquid, Liquid);
		}
		else
		{
			SubInventoryPersistentData[] subInventories = _subInventories;
			for (int i = 0; i < subInventories.Length; i++)
			{
				subInventories[i].Restore(inventory);
			}
		}
		if (RestoredInventories != null)
		{
			RestoredInventories.Add(this);
		}
	}

	public static void RestoreAllReferences()
	{
		for (int i = 0; i < RestoredInventories.Count; i++)
		{
			RestoredInventories[i].RestoreReferences();
		}
		RestoreReferencesEvent?.Invoke();
	}

	private void RestoreReferences()
	{
		if (_subInventories == null)
		{
			RestoreIncomingReferences(_instance, IncomingStorage, SubInventoryType.Storage);
			RestoreIncomingReferences(_instance, IncomingComposition, SubInventoryType.Composition);
			RestoreIncomingReferences(_instance, IncomingResources, SubInventoryType.Resources);
			RestoreIncomingReferences(_instance, IncomingImport, SubInventoryType.Import);
			RestoreIncomingReferences(_instance, IncomingExport, SubInventoryType.Export);
			RestoreIncomingReferences(_instance, IncomingLiquid, SubInventoryType.Liquid);
		}
	}

	private void RestoreList(Inventory inventory, SubInventoryType subInventory, ItemPersistentData[] items)
	{
		inventory.GetOrAddSubInventory(subInventory);
		if (items == null)
		{
			return;
		}
		int num = items.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (items[i].TryRestore(subInventory != SubInventoryType.Composition, inventory, subInventory, out var item))
			{
				inventory.AddItem(item, subInventory);
				num2++;
			}
		}
		if (num2 != num)
		{
			Debugger.Warning("Not all items could be restored to inventory: " + inventory.name);
		}
	}

	private void RestoreIncomingReferences(Inventory inventory, int[] indices, SubInventoryType type)
	{
		if (indices == null)
		{
			return;
		}
		for (int i = 0; i < indices.Length; i++)
		{
			if (PersistentReference<Item>.TryReturnReference(indices[i], out var reference))
			{
				_instance.RestoreIncomingItem(reference, type);
			}
		}
	}

	public CountedItemProperty[] ReturnCountedItems(SubInventoryType subInventoryType)
	{
		if (_subInventories == null)
		{
			if (subInventoryType == SubInventoryType.Composition)
			{
				return ReturnCountedItems(Composition);
			}
		}
		else
		{
			SubInventoryPersistentData[] subInventories = _subInventories;
			foreach (SubInventoryPersistentData subInventoryPersistentData in subInventories)
			{
				if (subInventoryPersistentData.SubInventoryType == subInventoryType)
				{
					return ReturnCountedItems(subInventoryPersistentData.Items);
				}
			}
		}
		Debug.LogException(new NotImplementedException());
		return null;
	}

	private CountedItemProperty[] ReturnCountedItems(ItemPersistentData[] items)
	{
		using ListPool<int>.List list = ListPool<int>.Get();
		if (!items.IsNullOrEmpty())
		{
			ItemPersistentData[] array = items;
			foreach (ItemPersistentData itemPersistentData in array)
			{
				if (!list.Contains(itemPersistentData.PropertiesIndex))
				{
					list.Add(itemPersistentData.PropertiesIndex);
				}
			}
		}
		CountedItemProperty[] array2 = new CountedItemProperty[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			int num = list[j];
			if (!GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(num, out var reference))
			{
				Debug.LogError("Unable to count ItemPersistentData, because ItemProperties could not be restored!");
				continue;
			}
			int num2 = 0;
			ItemPersistentData[] array = items;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].PropertiesIndex == num)
				{
					num2++;
				}
			}
			array2[j] = new CountedItemProperty(reference, num2);
		}
		return array2;
	}
}
