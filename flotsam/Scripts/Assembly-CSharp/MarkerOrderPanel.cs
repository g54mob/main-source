using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MarkerOrderPanel : Panel
{
	[Tooltip("The parent transform under which we will spawn all the entries.")]
	public Transform EntryParent;

	[Tooltip("A reference to the draggableScrollRect on the scrollrect component.")]
	public DraggableScrollRect MarkerScrollRect;

	private List<MarkerOrderPanelEntry> _entries = new List<MarkerOrderPanelEntry>();

	private bool _scrollRectLinked;

	private MarkerOrderPanelEntry[] _previousProjectOrder;

	[HideInInspector]
	public UnityEvent OnEntryChangedPositionEvent;

	private void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.MarkerDestroyed, RemoveMarkerEntry);
		GameEventDispatcher.AddListener(GameEventType.MarkerManuallyRemoved, RemoveMarkerEntry);
		GameEventDispatcher.AddListener(GameEventType.MarkerPlaced, AddMarkerEntry);
		UpdatePanel();
		if (OnEntryChangedPositionEvent == null)
		{
			OnEntryChangedPositionEvent = new UnityEvent();
		}
	}

	private void Update()
	{
		if (MarkerScrollRect.Initialized && !_scrollRectLinked)
		{
			MarkerScrollRect.OnDraggableChangedPositionEvent.AddListener(UpdateMarkerEntriesProjectOrder);
			_scrollRectLinked = true;
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MarkerDestroyed, RemoveMarkerEntry);
		GameEventDispatcher.RemoveListener(GameEventType.MarkerManuallyRemoved, RemoveMarkerEntry);
		GameEventDispatcher.RemoveListener(GameEventType.MarkerPlaced, AddMarkerEntry);
		MarkerScrollRect.OnDraggableChangedPositionEvent.RemoveListener(UpdateMarkerEntriesProjectOrder);
	}

	private void UpdatePanel()
	{
		IEnumerable<Marker> enumerable = _entries.Select((MarkerOrderPanelEntry markerEntry) => markerEntry.Marker);
		List<Marker> markers = Community.PlayerCommunity.Markers;
		foreach (Marker item in markers.Except(enumerable))
		{
			CreateEntry(item);
		}
		foreach (Marker item2 in enumerable.Except(markers))
		{
			RemoveEntry(item2);
		}
		UpdateEntriesProjectIndexes();
	}

	private void UpdateMarkerEntriesProjectOrder()
	{
		OnEntryChangedPositionEvent.Invoke();
		UpdateEntriesProjectIndexes();
	}

	private void AddMarkerEntry(GameEvent gameEvent)
	{
		Marker marker = (gameEvent as MarkerEvent).Marker;
		CreateEntry(marker);
		UpdateEntriesProjectIndexes();
	}

	private void RemoveMarkerEntry(GameEvent gameEvent)
	{
		Marker marker = (gameEvent as MarkerEvent).Marker;
		RemoveEntry(marker);
		UpdateEntriesProjectIndexes();
	}

	private void CreateEntry(Marker marker)
	{
		MarkerOrderPanelEntry markerOrderPanelEntry = Object.Instantiate(GameManager.Settings.UISettings.MarkerOrderPanelEntryPrefab, EntryParent);
		markerOrderPanelEntry.Initialize(marker, this);
		_entries.Add(markerOrderPanelEntry);
	}

	private void RemoveEntry(Marker marker)
	{
		MarkerOrderPanelEntry markerOrderPanelEntry = _entries.Find((MarkerOrderPanelEntry entry) => entry.Marker == marker);
		if (!(markerOrderPanelEntry == null))
		{
			markerOrderPanelEntry.transform.GetSiblingIndex();
			_entries.Remove(markerOrderPanelEntry);
			markerOrderPanelEntry.UnsubscribeAll();
			markerOrderPanelEntry.transform.SetParent(null);
			Object.Destroy(markerOrderPanelEntry.gameObject);
		}
	}

	private void UpdateEntriesProjectIndexes()
	{
		_previousProjectOrder = new MarkerOrderPanelEntry[_entries.Count];
		for (int i = 0; i < _entries.Count; i++)
		{
			_previousProjectOrder[_entries[i].ReturnPanelIndex()] = _entries[i];
		}
	}

	public int ReturnProjectOrderFromPanelIndex(int panelIndex)
	{
		return Community.PlayerCommunity.Projects.FindIndex((Project x) => x == _previousProjectOrder[panelIndex].Marker.Project);
	}
}
