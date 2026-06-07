using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildDecorationPanel : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private int _minimumWorkerCount = 1;

	[SerializeField]
	private int _maximumWorkerCount = 3;

	[Header("UI Components")]
	[SerializeField]
	private DrifterCounter _drifterCounter;

	[SerializeField]
	private Slider _progressSlider;

	[SerializeField]
	private ChildBehaviourCache<BuildItemSlot> _buildItemSlots = new ChildBehaviourCache<BuildItemSlot>();

	private Decoration _decoration;

	private Inventory _inventory;

	private CountedItemProperty[] _requirements;

	private bool _shouldUpdateItemCount = true;

	private void OnEnable()
	{
		_shouldUpdateItemCount = true;
		_drifterCounter.OnValueChanged.AddListener(UpdateWorkerCount);
	}

	private void LateUpdate()
	{
		_progressSlider.value = _decoration.ConstructionHandler.Progress;
		if (!_shouldUpdateItemCount)
		{
			return;
		}
		if (_inventory != null)
		{
			IReadOnlyList<InventoryAuditor.CountedItem> countedItems = _inventory.ReturnInventoryCount(SubInventoryType.Resources).CountedItems;
			if (countedItems != null)
			{
				UpdateVisuals(countedItems);
			}
		}
		_shouldUpdateItemCount = false;
	}

	private void OnDisable()
	{
		_drifterCounter.OnValueChanged.RemoveListener(UpdateWorkerCount);
	}

	public void Initialize(Decoration decoration, CountedItemProperty[] requirements)
	{
		_decoration = decoration;
		_decoration.AssignmentLimit = Mathf.Clamp(_decoration.AssignmentLimit, _minimumWorkerCount, _maximumWorkerCount);
		_drifterCounter.Initialize(_minimumWorkerCount, _maximumWorkerCount, _decoration.AssignmentLimit);
		if (RequiresSlotsUpdate(requirements))
		{
			if (_inventory != null)
			{
				_inventory.InventoryUpdatedEvent.RemoveListener(QueueUpdateItemCount);
			}
			_inventory = _decoration.Inventory;
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

	private void UpdateVisuals(IReadOnlyList<InventoryAuditor.CountedItem> countedItems)
	{
		BuildItemSlot.SlotState slotState;
		switch (_decoration.ConstructionHandler.BuildPhase)
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
			slotState = BuildItemSlot.SlotState.CountingDown;
			break;
		default:
			slotState = BuildItemSlot.SlotState.None;
			break;
		}
		BuildItemSlot.SlotState slotState2 = slotState;
		_buildItemSlots.Reset();
		CountedItemProperty[] requirements = _requirements;
		foreach (CountedItemProperty countedItemProperty in requirements)
		{
			if (countedItemProperty.Amount > 0)
			{
				_buildItemSlots.Get().UpdateSlot(GetItemCount(countedItemProperty.ItemProperties, countedItems), countedItemProperty, slotState2);
			}
		}
		_buildItemSlots.Trim();
	}

	private void UpdateWorkerCount(int count)
	{
		_decoration.AssignmentLimit = count;
	}

	private bool RequiresSlotsUpdate(CountedItemProperty[] requirements)
	{
		if (_inventory != _decoration.Inventory)
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

	private int GetItemCount(ItemProperties itemProperties, IReadOnlyList<InventoryAuditor.CountedItem> countedItems)
	{
		InventoryAuditor.CountedItem countedItem = countedItems.Find((InventoryAuditor.CountedItem item) => item.ItemProperties == itemProperties);
		if (countedItem == null)
		{
			return 0;
		}
		return countedItem.UnreservedCount + countedItem.ReservedCount;
	}
}
