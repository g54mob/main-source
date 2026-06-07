using System.Collections.Generic;
using UnityEngine;

public class MarkerPanel : Panel
{
	[Header("Project settings")]
	[SerializeField]
	private ProjectMalfunctionPanel _projectMalfunctionPanel;

	[Tooltip("The minimum limit of assignees that can be assigned to the marker project.")]
	[SerializeField]
	private int _assignLimitMinimum;

	[Tooltip("The maximum limit of assignees that can be assigned to the marker project.")]
	[SerializeField]
	private int _assignLimitMaximum = 5;

	[Header("Marker Panel Settings")]
	[SerializeField]
	private DrifterCounter _drifterCounter;

	[SerializeField]
	private RadiusResizer _radiusResizer;

	[SerializeField]
	[Tooltip("Prefab used to display items.")]
	private MarkerPanelItemSlot _itemSlotPrefab;

	[SerializeField]
	[Tooltip("The parent for the displayed item slots.")]
	private RectTransform _itemSlotParent;

	private Marker _marker;

	private Community _playerCommunity;

	private InventoryAuditor _auditor;

	private List<MarkerPanelItemSlot> _itemSlots;

	private void Update()
	{
		UpdateItemSlots();
		if (_marker == null)
		{
			Close();
		}
	}

	private void OnDestroy()
	{
		foreach (MarkerPanelItemSlot itemSlot in _itemSlots)
		{
			itemSlot.OnToggleEvent.RemoveListener(OnItemSlotToggle);
			Object.Destroy(itemSlot);
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Marker marker && base.Open(id, context))
		{
			if (_auditor == null)
			{
				_auditor = new InventoryAuditor();
			}
			if (_playerCommunity == null)
			{
				_playerCommunity = Community.PlayerCommunity;
			}
			if (_itemSlots == null)
			{
				_itemSlots = new List<MarkerPanelItemSlot>();
			}
			_marker = marker;
			_projectMalfunctionPanel.Initialize(_marker.Project);
			_drifterCounter.Initialize(_assignLimitMinimum, _assignLimitMaximum, marker.Project.AssignmentLimit);
			_drifterCounter.OnValueChanged.AddListener(OnAgentUpdate);
			_radiusResizer.Initialize(marker.CurrentRadiusIntervalIndex);
			_radiusResizer.OnValueChanged.AddListener(OnRadiusResized);
			UpdateItemSlots();
			_playerCommunity.ShowMarkerHighlights(enabled: true);
			_marker.ShowMarkerHighlight(enable: true, selected: true);
			return true;
		}
		return false;
	}

	public override void Close()
	{
		base.Close();
		if (!(_marker == null))
		{
			_drifterCounter.OnValueChanged.RemoveListener(OnAgentUpdate);
			_radiusResizer.OnValueChanged.RemoveListener(OnRadiusResized);
			Selector.Deselect(_marker.gameObject);
			_playerCommunity.ShowMarkerHighlights(enabled: false);
			_projectMalfunctionPanel.Uninitialize();
			_marker = null;
		}
	}

	private void OnAgentUpdate(int count)
	{
		_marker.SetAgentAmount(_drifterCounter.Count);
	}

	private void OnRadiusResized(int index)
	{
		_marker.SetSizeIndex(index);
	}

	public void RemoveMarker()
	{
		MarkerEvent.Dispatch(GameEventType.MarkerManuallyRemoved, _marker);
		_marker.Remove();
		Close();
	}

	private void OnItemSlotToggle(ItemProperties properties)
	{
		_marker.ToggleItemFilter(properties);
	}

	private void UpdateItemSlots()
	{
		int i = 0;
		_auditor.Reset();
		_auditor.CountItems(_marker.AllowedItemsInRadius);
		foreach (InventoryAuditor.CountedItem countedItem in _auditor.CountedItems)
		{
			if (countedItem.UnreservedCount == 0)
			{
				continue;
			}
			MarkerPanelItemSlot markerPanelItemSlot;
			if (i < _itemSlots.Count)
			{
				markerPanelItemSlot = _itemSlots[i];
				if (!markerPanelItemSlot.gameObject.activeSelf)
				{
					markerPanelItemSlot.gameObject.SetActive(value: true);
				}
			}
			else
			{
				markerPanelItemSlot = Object.Instantiate(_itemSlotPrefab, _itemSlotParent);
				_itemSlots.Add(markerPanelItemSlot);
			}
			markerPanelItemSlot.Initialize(countedItem.ItemProperties, countedItem.UnreservedCount, _marker.ReturnIsItemFilterToggled(countedItem.ItemProperties));
			markerPanelItemSlot.OnToggleEvent.AddListener(OnItemSlotToggle);
			i++;
		}
		for (; i < _itemSlots.Count; i++)
		{
			_itemSlots[i].gameObject.SetActive(value: false);
		}
	}

	public void CycleMarker(int indexAddition)
	{
		List<Marker> markers = _playerCommunity.Markers;
		int num = markers.IndexOf(_marker);
		int count = markers.Count;
		num += indexAddition;
		if (num < 0)
		{
			num = count - 1;
		}
		else if (num >= count)
		{
			num = 0;
		}
		GameObject gameObject = markers[num].gameObject;
		CameraController.Instance.Lock(gameObject, CameraController.Instance.CurrentZoomLevel);
		Selector.Select(gameObject, ObjectType.Marker);
	}
}
