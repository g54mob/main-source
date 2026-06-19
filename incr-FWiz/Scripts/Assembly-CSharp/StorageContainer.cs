using System.Collections.Generic;
using UnityEngine;

public class StorageContainer : BuildingBehaviour
{
	[SerializeField]
	private DropCollector _dropCollector;

	[SerializeField]
	private PickupSupplier _pickupSupplier;

	[SerializeField]
	private StorageContainerUI _storageContainerUI;

	public ItemType ItemConstriction { get; private set; }

	[field: SerializeField]
	public ItemStack ItemStack { get; private set; }

	[field: SerializeField]
	public int Capacity { get; private set; }

	public override void SetBuilding(Building building)
	{
	}

	public IEnumerable<ItemStack> GetStorageItemsForDeconstruction()
	{
		return null;
	}

	public override void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetItemConstriction(ItemType itemType)
	{
	}

	public bool CanCollect(ItemType itemType)
	{
		return false;
	}

	public bool IsItemPreferred(ItemType itemType)
	{
		return false;
	}

	public void AddItem(ItemType itemType)
	{
	}

	public ItemType Peek()
	{
		return null;
	}

	public bool RemoveItem()
	{
		return false;
	}

	private void InitiateNewStack(ItemType itemType)
	{
	}

	public void UpdateUI()
	{
	}

	public void AddCapacity(int capacity)
	{
	}
}
