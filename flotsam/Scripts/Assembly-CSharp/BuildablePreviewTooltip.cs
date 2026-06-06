using System.Collections.Generic;
using UnityEngine;

public class BuildablePreviewTooltip : MonoBehaviour
{
	[Tooltip("How high the tooltip floats above the cursor.")]
	public float VerticalOffset = 5f;

	[SerializeField]
	[Tooltip("The parent of the slot icons.")]
	private RectTransform _slotParent;

	[SerializeField]
	[Tooltip("Prefab for the mooring point slot.")]
	private BuildableTooltipItemSlot _tooltipItemSlotPrefab;

	[SerializeField]
	[Tooltip("The icon to indicate if the construction is intersecting anything.")]
	private GameObject _overlappingIcon;

	private Buildable _buildable;

	private List<BuildableTooltipItemSlot> _slots = new List<BuildableTooltipItemSlot>();

	private CountedItemProperty[] _slotItems;

	private List<CountedItemProperty> _countedSlotItems = new List<CountedItemProperty>();

	private int _amount;

	private void Start()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateSlots);
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateSlots);
	}

	public void EnableTooltip(Buildable buildable, int amount = 1)
	{
		_buildable = buildable;
		base.gameObject.SetActive(value: true);
		CreateItemSlots();
	}

	public void DisableTooltip()
	{
		_buildable = null;
		base.gameObject.SetActive(value: false);
		ClearSlots();
	}

	private void CreateItemSlots()
	{
		_slotItems = _buildable.Properties.RequiredResources;
		for (int i = 0; i < _slotItems.Length; i++)
		{
			_slots.Add(Object.Instantiate(_tooltipItemSlotPrefab, _slotParent));
			CountedItemProperty item = new CountedItemProperty(_slotItems[i].ItemProperties, _slotItems[i].Amount);
			_countedSlotItems.Add(item);
			_slots[i].Initialize(_countedSlotItems[i], showAvailable: false);
			_slots[i].DisableRaycasts();
		}
	}

	public void SetBuildableAmount(int amount)
	{
		_amount = amount;
		for (int i = 0; i < _slots.Count; i++)
		{
			_slots[i].SetBuildableAmount(amount);
		}
	}

	public void SetLocation(Vector3 position)
	{
		base.transform.position = position + Vector3.up * VerticalOffset;
	}

	public void SetOverlapping(bool isOverlapping)
	{
		_overlappingIcon.SetActive(isOverlapping);
	}

	private void UpdateSlots()
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			_slots[i].UpdateSlot();
		}
	}

	private void ClearSlots()
	{
		for (int i = 0; i < _slots.Count; i++)
		{
			Object.Destroy(_slots[i].gameObject);
		}
		_slots.Clear();
		_countedSlotItems.Clear();
	}
}
