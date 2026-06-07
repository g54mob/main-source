using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryView : MonoBehaviour, IBuildablePanelElement, IInventoryView
{
	[Header("Settings")]
	[Tooltip("Should all known items be shown or only items that are held by the inventory?")]
	[SerializeField]
	private bool _displayKnownItems;

	[Header("UI Components")]
	[Tooltip("Prefab for the inventory slots.")]
	public InventoryPanelItemSlot slotPrefab;

	[Tooltip("Transform containing the inventory slots.")]
	public Transform inventoryGrid;

	[Tooltip("List of capacity bars for this inventory panel.")]
	[SerializeField]
	private InventoryPanelCapacityBar[] _capacityBars = new InventoryPanelCapacityBar[0];

	[Tooltip("If enabled, you can eject items from the inventory view.")]
	[FormerlySerializedAs("_allowEject")]
	public bool AllowEject;

	[SerializeField]
	[Tooltip("What sub-inventory should be audited.")]
	private SubInventoryType _subInventoryType;

	[Header("Buildable Panel Element")]
	[SerializeField]
	private BuildablePanelElementId _buildablePanelElementId;

	[Header("Navigation")]
	[SerializeField]
	private bool _navigable;

	[SerializeField]
	[ConditionalHide("_navigable", true)]
	private SelectableGroup _selectableGroup;

	[SerializeField]
	[ConditionalHide("_navigable", true)]
	private RewiredAction _throw;

	private bool _initialized;

	private Inventory _inventory;

	private List<InventoryPanelItemSlot> _slots;

	private bool _shouldUpdateItemCount;

	private List<InventoryAuditor.CountedItem> _countedItems;

	public BuildablePanelElementId Id => _buildablePanelElementId;

	public void Initialize()
	{
		if (!_initialized)
		{
			_slots = new List<InventoryPanelItemSlot>();
			_initialized = true;
		}
	}

	public void Initialize(Inventory inventory, Item.Tags filter = Item.Tags.None)
	{
		Initialize();
		if (_inventory != inventory)
		{
			if (_inventory != null)
			{
				_inventory.InventoryUpdatedEvent.RemoveListener(QueueUpdateItemCount);
			}
			_inventory = inventory;
			_inventory.InventoryUpdatedEvent.AddListener(QueueUpdateItemCount);
			for (int i = 0; i < _capacityBars.Length && !_capacityBars[i].Initialize(inventory, filter); i++)
			{
			}
			_shouldUpdateItemCount = true;
			base.gameObject.SetActive(value: true);
		}
	}

	public void Initialize(Inventory inventory, SubInventoryType subInventoryToView)
	{
		Initialize(inventory);
		_subInventoryType = subInventoryToView;
	}

	private void OnEnable()
	{
		_shouldUpdateItemCount = true;
	}

	private void LateUpdate()
	{
		if (_shouldUpdateItemCount && _inventory != null)
		{
			_countedItems = _inventory.ReturnInventoryCount(_subInventoryType).CountedItems;
			UpdateVisuals(_countedItems);
			_shouldUpdateItemCount = false;
			if (_navigable)
			{
				_selectableGroup.Initialize();
			}
		}
		UpdateNavigation();
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && ((buildable.TryReturnBuildableExtendable<Storage>(out var buildableExtendable) && buildableExtendable.ShowInventoryView) || buildable.Properties.ReturnShowElement(this, finished)))
		{
			Item.Tags filter = Item.Tags.None;
			if ((bool)buildableExtendable)
			{
				filter = buildableExtendable.FilterTags;
				Item.Tags filterTags = buildableExtendable.FilterTags;
				if (filterTags == Item.Tags.Drink || filterTags == Item.Tags.Liquid || filterTags == (Item.Tags.Drink | Item.Tags.Liquid))
				{
					_subInventoryType = SubInventoryType.Liquid;
				}
				else
				{
					_subInventoryType = SubInventoryType.Storage;
				}
			}
			DeactivateCapacityBars();
			Initialize(buildable.Inventory, filter);
			AllowEject = buildable.Properties.CanEjectFromStorage;
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		if (_inventory != null)
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(QueueUpdateItemCount);
			_inventory = null;
		}
		DeactivateCapacityBars();
		base.gameObject.SetActive(value: false);
	}

	private void DeactivateCapacityBars()
	{
		for (int i = 0; i < _capacityBars.Length; i++)
		{
			_capacityBars[i].gameObject.SetActive(value: false);
		}
	}

	private void QueueUpdateItemCount()
	{
		_shouldUpdateItemCount = true;
	}

	public void UpdateVisuals(List<InventoryAuditor.CountedItem> countedItems)
	{
		if (countedItems == null)
		{
			return;
		}
		int count = countedItems.Count;
		int count2 = _slots.Count;
		int i = 0;
		Sorting.SlowSort(countedItems);
		for (int j = 0; j < count; j++)
		{
			InventoryAuditor.CountedItem countedItem = countedItems[j];
			if (_displayKnownItems || 0 < countedItem.ReservedCount + countedItem.UnreservedCount)
			{
				if (i < count2)
				{
					InitializeSlot(_slots[i], countedItem);
				}
				else
				{
					InventoryPanelItemSlot inventoryPanelItemSlot = Object.Instantiate(slotPrefab, inventoryGrid);
					InitializeSlot(inventoryPanelItemSlot, countedItem);
					_slots.Add(inventoryPanelItemSlot);
				}
				i++;
			}
		}
		for (; i < count2; i++)
		{
			_slots[i].gameObject.SetActive(value: false);
		}
	}

	private void InitializeSlot(InventoryPanelItemSlot slot, InventoryAuditor.CountedItem countedItem)
	{
		slot.Initialize(countedItem.ItemProperties, countedItem.UnreservedCount + countedItem.ReservedCount);
	}

	public void ThrowItem(ItemProperties itemProperties)
	{
		if (AllowEject)
		{
			UIEvent.Dispatch(UIEvent.Type.EjectItem);
			Item item = _inventory.ReturnItem(itemProperties, SubInventoryType.Storage);
			item?.Inventory.TakeItem(item);
		}
	}

	private void UpdateNavigation()
	{
		if (_navigable && !(_selectableGroup == null) && _throw.GetButtonUp() && _selectableGroup.Selected is InventoryViewSelectable inventoryViewSelectable)
		{
			ThrowItem(inventoryViewSelectable.ItemProperties);
		}
	}
}
