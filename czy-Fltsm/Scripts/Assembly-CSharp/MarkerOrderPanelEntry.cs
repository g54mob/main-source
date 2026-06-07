using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Draggable))]
public class MarkerOrderPanelEntry : UIInteractable
{
	[Space]
	[Header("Visuals")]
	[Tooltip("The parent under which we spawn the markerIcons.")]
	[SerializeField]
	private Transform _itemIconParent;

	[Tooltip("The text component that we use to display the amount of drifters.")]
	[SerializeField]
	private TextMeshProUGUI _drifterCount;

	[Tooltip("The image component that we use to display the type of the marker.")]
	[SerializeField]
	private Image _markerIcon;

	[Tooltip("GameObject that we turn on when object is selected.")]
	[SerializeField]
	private GameObject _border;

	[Tooltip("GameObject that we turn on when object is selected and/or hovered.")]
	[SerializeField]
	private GameObject _highlight;

	private MarkerOrderPanel _markerOrderPanel;

	private Dictionary<ItemProperties, MarkerIcon> _generatedIcons = new Dictionary<ItemProperties, MarkerIcon>();

	private DoubleClickDetector _doubleClickDetector = new DoubleClickDetector();

	private Draggable _dragElement;

	private List<ItemProperties> _activeIcons = new List<ItemProperties>();

	private bool _updateDrifterCount;

	public Marker Marker { get; private set; }

	public void Initialize(Marker marker, MarkerOrderPanel markerOrderPanel)
	{
		Marker = marker;
		_markerOrderPanel = markerOrderPanel;
		UpdateIcons();
		UpdateDrifterCount();
		GameEventDispatcher.AddListener(GameEventType.AgentStartAssignment, UpdateDrifterCount);
		GameEventDispatcher.AddListener(GameEventType.AgentFinishAssignment, UpdateDrifterCount);
		_markerOrderPanel.OnEntryChangedPositionEvent.AddListener(UpdateProjectOrder);
		Marker.UpdatedItemsInRadius.AddListener(UpdateIcons);
		_markerIcon.sprite = marker.MarkerCursorProperties.AgentIconSprite;
		_dragElement = GetComponent<Draggable>();
		_dragElement.BeginDrag.AddListener(SelectMarker);
		_dragElement.UseHoverSprites = true;
		Selector.SelectedObjectsUpdatedEvent += CheckHighlightEntry;
	}

	protected override void Start()
	{
		base.Start();
		CheckHighlightEntry();
	}

	private void LateUpdate()
	{
		if (_updateDrifterCount)
		{
			_drifterCount.text = $"{Marker.Project.Assignments.Count}/{Marker.Project.AssignmentLimit}";
			_updateDrifterCount = false;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.AgentStartAssignment, UpdateDrifterCount);
		GameEventDispatcher.RemoveListener(GameEventType.AgentFinishAssignment, UpdateDrifterCount);
	}

	public void SelectMarker()
	{
		Selector.Select(Marker.gameObject, ObjectType.CommunityMember);
		if (_doubleClickDetector.IsDoubleClick())
		{
			CameraController.Instance.Lock(Marker.gameObject);
		}
	}

	public void FocusMarker()
	{
		CameraController.Instance.Lock(Marker.gameObject);
	}

	private void UpdateIcons()
	{
		List<ItemProperties> list = _generatedIcons.Keys.ToList();
		foreach (ItemProperties item in Marker.ItemTypesInRange)
		{
			MarkerIcon markerIcon = (_generatedIcons.ContainsKey(item) ? _generatedIcons[item] : CreateIcon(item));
			Marker.ItemFilter.TryGetValue(item, out var value);
			if (value)
			{
				markerIcon.gameObject.SetActive(value: true);
				list.Remove(item);
			}
		}
		foreach (ItemProperties item2 in list)
		{
			_generatedIcons[item2].gameObject.SetActive(value: false);
		}
	}

	private void UpdateDrifterCount(GameEvent gameEvent = null)
	{
		_updateDrifterCount = gameEvent == null || gameEvent.EventType == GameEventType.AgentStartAssignment || gameEvent.EventType == GameEventType.AgentFinishAssignment;
	}

	private MarkerIcon CreateIcon(ItemProperties itemProperties)
	{
		MarkerIcon markerIcon = Object.Instantiate(GameManager.Settings.UISettings.MarkerIconPrefab, _itemIconParent);
		markerIcon.Initialize(itemProperties);
		_generatedIcons.Add(itemProperties, markerIcon);
		markerIcon.gameObject.SetActive(value: false);
		return markerIcon;
	}

	private void CheckHighlightEntry()
	{
		_ = Color.white;
		if (Selector.Selection != null)
		{
			SelectionLink selection = Selector.Selection;
			if (selection.Type == ObjectType.Marker && !(selection.ObjectToSelect != Marker.gameObject))
			{
				_border.SetActive(value: true);
				_highlight.SetActive(value: true);
				_dragElement.CanExitHover = false;
			}
		}
		else
		{
			_border.SetActive(value: false);
			_highlight.SetActive(value: false);
			_dragElement.CanExitHover = true;
		}
	}

	private void UpdateProjectOrder()
	{
		int index = _markerOrderPanel.ReturnProjectOrderFromPanelIndex(ReturnPanelIndex());
		Community.PlayerCommunity.Projects[index] = Marker.Project;
	}

	public void UnsubscribeAll()
	{
		Marker.UpdatedItemsInRadius.RemoveListener(UpdateIcons);
		_dragElement.BeginDrag.RemoveListener(SelectMarker);
		_markerOrderPanel.OnEntryChangedPositionEvent.RemoveListener(UpdateProjectOrder);
		Selector.SelectedObjectsUpdatedEvent -= CheckHighlightEntry;
	}

	public int ReturnPanelIndex()
	{
		return base.transform.GetSiblingIndex();
	}
}
