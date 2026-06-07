using System.Collections.Generic;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private int _minimumWorkerCount = 1;

	[SerializeField]
	private int _maximumWorkerCount = 3;

	[Header("UI Components")]
	[Tooltip("Drifter Counter")]
	[SerializeField]
	private DrifterCounter _drifterCounter;

	[Tooltip("Prefab for the inventory slots.")]
	public BuildItemSlot slotPrefab;

	[Tooltip("Transform containing the inventory slots.")]
	public Transform inventoryGrid;

	private Buildable _buildable;

	private Inventory _inventory;

	private List<BuildItemSlot> _slots = new List<BuildItemSlot>();

	private CountedItemProperty[] _requirements;

	private List<InventoryAuditor.CountedItem> _countedItems;

	private bool _shouldUpdateItemCount;

	private void OnEnable()
	{
		_shouldUpdateItemCount = true;
		_drifterCounter.OnValueChanged.AddListener(UpdateWorkerCount);
	}

	private void LateUpdate()
	{
		if (_shouldUpdateItemCount)
		{
			_countedItems = _inventory.ReturnInventoryCount(SubInventoryType.Resources).CountedItems;
			UpdateVisuals();
			_shouldUpdateItemCount = false;
		}
	}

	private void OnDisable()
	{
		_drifterCounter.OnValueChanged.RemoveListener(UpdateWorkerCount);
	}

	public void Initialize(Buildable buildable, CountedItemProperty[] requirements)
	{
		_buildable = buildable;
		_buildable.AssignmentLimit = Mathf.Clamp(_buildable.AssignmentLimit, _minimumWorkerCount, _maximumWorkerCount);
		_drifterCounter.Initialize(_minimumWorkerCount, _maximumWorkerCount, _buildable.AssignmentLimit);
		if (ReturnRequiresSlotUpdate(buildable, requirements))
		{
			if (_inventory != null)
			{
				_inventory.InventoryUpdatedEvent.RemoveListener(QueueUpdateItemCount);
			}
			_inventory = _buildable.Inventory;
			_inventory.InventoryUpdatedEvent.AddListener(QueueUpdateItemCount);
			_shouldUpdateItemCount = true;
			base.gameObject.SetActive(value: true);
		}
		_requirements = requirements;
	}

	public void Deactivate()
	{
		if (_inventory != null)
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(QueueUpdateItemCount);
			_inventory = null;
		}
		base.gameObject.SetActive(value: false);
	}

	private void QueueUpdateItemCount()
	{
		_shouldUpdateItemCount = true;
	}

	private void UpdateVisuals()
	{
		if (_countedItems == null)
		{
			return;
		}
		BuildItemSlot.SlotState slotState = BuildItemSlot.SlotState.None;
		switch (_buildable.BuildPhase)
		{
		case BuildPhase.HaulTo:
		case BuildPhase.UpgradeHaulTo:
			slotState = BuildItemSlot.SlotState.CountingUp;
			break;
		case BuildPhase.Build:
			slotState = BuildItemSlot.SlotState.Checked;
			break;
		case BuildPhase.Deconstructing:
			slotState = BuildItemSlot.SlotState.All;
			break;
		case BuildPhase.HaulFrom:
		case BuildPhase.UpgradeHaulFrom:
			slotState = BuildItemSlot.SlotState.CountingDown;
			break;
		}
		int num = _requirements.Length;
		int count = _slots.Count;
		int i = 0;
		for (int j = 0; j < num; j++)
		{
			CountedItemProperty countedItemProperty = _requirements[j];
			if (countedItemProperty.Amount > 0)
			{
				if (i < count)
				{
					_slots[i].UpdateSlot(ReturnItemCount(countedItemProperty.ItemProperties), countedItemProperty, slotState);
				}
				else
				{
					BuildItemSlot buildItemSlot = Object.Instantiate(slotPrefab, inventoryGrid);
					buildItemSlot.UpdateSlot(ReturnItemCount(countedItemProperty.ItemProperties), countedItemProperty, slotState);
					_slots.Add(buildItemSlot);
				}
				i++;
			}
		}
		for (; i < count; i++)
		{
			_slots[i].gameObject.SetActive(value: false);
		}
	}

	private void UpdateWorkerCount(int count)
	{
		_buildable.AssignmentLimit = count;
	}

	private bool ReturnRequiresSlotUpdate(Buildable buildable, CountedItemProperty[] requirements)
	{
		if (_inventory != _buildable.Inventory)
		{
			return true;
		}
		if (_requirements == null)
		{
			return true;
		}
		if (_requirements.Length != requirements.Length)
		{
			return true;
		}
		for (int i = 0; i < requirements.Length; i++)
		{
			if (!requirements[i].Equals(_requirements[i]))
			{
				return true;
			}
		}
		return false;
	}

	private int ReturnItemCount(ItemProperties itemProperties)
	{
		InventoryAuditor.CountedItem countedItem = _countedItems.Find((InventoryAuditor.CountedItem item) => item.ItemProperties == itemProperties);
		if (countedItem == null)
		{
			return 0;
		}
		return countedItem.UnreservedCount + countedItem.ReservedCount;
	}
}
