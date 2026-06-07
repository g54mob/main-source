using System.Collections.Generic;
using UnityEngine;

public class ScavengePanel : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Prefab used to display items.")]
	private MarkerPanelItemSlot _itemSlotPrefab;

	[SerializeField]
	[Tooltip("Prefab spawned to show there are unknown resources on the landmark.")]
	private GameObject _unknownItemSlotPrefab;

	[SerializeField]
	[Tooltip("The parent for the displayed item slots.")]
	private RectTransform _itemSlotParent;

	[SerializeField]
	[Tooltip("If enabled, all the available items toggles will always be shown.")]
	private bool _showAllToggles = true;

	public ItemProperties.Event ItemSlotToggleEvent;

	private Project _project;

	private List<MarkerPanelItemSlot> _itemSlots;

	private GameObject _unknownItemSlot;

	private int _activeItemSlotCount;

	public void Enable(Project project)
	{
		if (0 < _activeItemSlotCount)
		{
			OnDisable();
		}
		_project = project;
		if (ItemSlotToggleEvent == null)
		{
			ItemSlotToggleEvent = new ItemProperties.Event();
		}
	}

	protected virtual void OnDisable()
	{
		_activeItemSlotCount = 0;
		if (_itemSlots == null)
		{
			return;
		}
		foreach (MarkerPanelItemSlot itemSlot in _itemSlots)
		{
			itemSlot.OnToggleEvent.RemoveAllListeners();
			itemSlot.gameObject.SetActive(value: false);
		}
		ItemSlotToggleEvent.RemoveAllListeners();
	}

	public void AddItemSlot(ItemProperties itemProperties, int itemCount, bool enabled = true, bool hideToggle = false)
	{
		if (_showAllToggles || 0 < itemCount)
		{
			if (_unknownItemSlot != null)
			{
				Object.Destroy(_unknownItemSlot);
			}
			if (_itemSlots == null)
			{
				_itemSlots = new List<MarkerPanelItemSlot>();
			}
			MarkerPanelItemSlot markerPanelItemSlot;
			if (_activeItemSlotCount < _itemSlots.Count)
			{
				markerPanelItemSlot = _itemSlots[_activeItemSlotCount];
			}
			else
			{
				markerPanelItemSlot = Object.Instantiate(_itemSlotPrefab);
				_itemSlots.Add(markerPanelItemSlot);
			}
			markerPanelItemSlot.Initialize(itemProperties, itemCount, enabled, hideToggle);
			markerPanelItemSlot.OnToggleEvent.AddListener(OnItemSlotToggle);
			markerPanelItemSlot.transform.SetParent(_itemSlotParent, worldPositionStays: false);
			markerPanelItemSlot.gameObject.SetActive(value: true);
			_activeItemSlotCount++;
		}
	}

	public void AddUnknownItemSlot()
	{
		if (!(_unknownItemSlot != null))
		{
			_unknownItemSlot = Object.Instantiate(_unknownItemSlotPrefab);
			_unknownItemSlot.transform.SetParent(_itemSlotParent, worldPositionStays: false);
		}
	}

	private void OnItemSlotToggle(ItemProperties itemProperties)
	{
		if (ItemSlotToggleEvent != null)
		{
			ItemSlotToggleEvent.Invoke(itemProperties);
		}
	}
}
