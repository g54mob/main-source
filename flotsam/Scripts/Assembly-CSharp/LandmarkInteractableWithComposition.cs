using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LandmarkInteractableWithComposition : LandmarkInteractable
{
	[FormerlySerializedAs("_items")]
	[SerializeField]
	private List<CountedItemProperty> _composition;

	[SerializeField]
	private Activity _activity = Activity.ItemTaking;

	[SerializeField]
	private int _animationCycles = 1;

	protected CompositionInventory _compositionInventory;

	public Inventory Inventory { get; private set; }

	public List<CountedItemProperty> Composition { get; protected set; }

	public event UnityAction<float> CompositionUpdatedEvent;

	public override void Initialize(LandmarkBehaviour landmarkBehaviour = null)
	{
		Composition = _composition;
	}

	protected void InitializeInventory(CountedItemProperty[] composition)
	{
		if (InstantiateInventory())
		{
			Inventory.FillComposition(composition);
		}
	}

	public void RestoreInventory(InventoryPersistentData inventoryToPersist)
	{
		if (InstantiateInventory())
		{
			inventoryToPersist.Restore(Inventory, base.gameObject);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if ((bool)Inventory)
		{
			Inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
		}
	}

	public override bool Validate()
	{
		foreach (CountedItemProperty item in _composition)
		{
			if (item.ItemProperties == null)
			{
				return false;
			}
		}
		return true;
	}

	public void PopulateCompositionCount(CountedItemProperty[] compositionCount)
	{
		_compositionInventory.PopulateCountedItemPropertyArray(compositionCount);
	}

	public void CountComposition(InventoryAuditor auditor)
	{
		auditor.CountItemProperties(_composition);
	}

	public void CountItemsInComposition(InventoryAuditor auditor)
	{
		if (Application.isPlaying)
		{
			if (_compositionInventory == null)
			{
				auditor.CountItemProperties(Composition);
			}
			else
			{
				auditor.CountInventory(_compositionInventory);
			}
		}
		else
		{
			auditor.CountItemProperties(_composition);
		}
	}

	public void UpdateComposition(ItemProperties itemProperties, int change)
	{
		if (TryReturnCompositionItem(itemProperties, out var compositionItem))
		{
			compositionItem.Amount += change;
		}
	}

	private bool InstantiateInventory()
	{
		if (Inventory == null)
		{
			Inventory = base.gameObject.AddComponent<Inventory>();
			Inventory.InitializeComposition(Composition);
			Inventory.CompositionUpdatedEvent += OnCompositionUpdated;
			Inventory.InventoryType = InventoryType.Flotsam;
			Inventory.Pickup = _activity;
			Inventory.TransferAnimationCycles = _animationCycles;
			_compositionInventory = Inventory.ReturnInventory(SubInventoryType.Composition) as CompositionInventory;
			return true;
		}
		return false;
	}

	protected virtual void OnCompositionUpdated(float progress)
	{
		if (this.CompositionUpdatedEvent != null)
		{
			this.CompositionUpdatedEvent(progress);
		}
	}

	public List<Item> ReturnCompositionItems()
	{
		return _compositionInventory.ReturnAllItems();
	}

	public CountedItemProperty[] ReturnComposition()
	{
		return _compositionInventory.ReturnAsCounteItemPropertyArray();
	}

	public int ReturnCompositionCapacity()
	{
		int num = 0;
		foreach (CountedItemProperty item in _composition)
		{
			num += item.Amount;
		}
		return num;
	}

	public bool ReturnIsEmpty()
	{
		return _compositionInventory.IsEmpty;
	}

	public bool TryReturnItemCount(ItemProperties itemProperties, out int itemCount)
	{
		if (TryReturnCompositionItem(itemProperties, out var compositionItem))
		{
			itemCount = compositionItem.Amount;
			return true;
		}
		itemCount = 0;
		return false;
	}

	protected List<CountedItemProperty> ReturnAssetComposition()
	{
		return _composition;
	}

	private bool TryReturnCompositionItem(ItemProperties itemProperties, out CountedItemProperty compositionItem)
	{
		foreach (CountedItemProperty item in Composition)
		{
			if (item.ItemProperties == itemProperties)
			{
				compositionItem = item;
				return true;
			}
		}
		compositionItem = null;
		return false;
	}
}
