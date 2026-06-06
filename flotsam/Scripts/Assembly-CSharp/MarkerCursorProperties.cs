using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Marker")]
public class MarkerCursorProperties : CursorProperties
{
	[SerializeField]
	protected int _initialAgentLimit = 3;

	[SerializeField]
	[Tooltip("Default / initial interval radius to start at when placing the marker.")]
	protected int _initialRadiusIntervalIndex = 1;

	[SerializeField]
	[Tooltip("Minimum and maximum range of the radius of the marker.")]
	protected Vector2 _radiusRange;

	[SerializeField]
	[Tooltip("Amount of radius intervals that this marker can use.")]
	protected int _radiusIntervalAmount = 3;

	[SerializeField]
	[Tooltip("Minimum clearance (distance from construction) the marker needs to have before it can be placed.")]
	protected int _requiredClearance = 2;

	[Space]
	[SerializeField]
	protected ProjectProperties _projectProperties;

	[SerializeField]
	private RewiredAction _decreaseRadiusAction;

	[SerializeField]
	private RewiredAction _increaseRadiusAction;

	[Space]
	[Tooltip("Color of the radius shader whenever the marker can be placed.")]
	public Color _okColor = Color.green;

	[Tooltip("Color of the radius shader whenever the marker cannot be placed.")]
	public Color _errorColor = Color.red;

	[SerializeField]
	public Color _outsideSwimmingRangeHighlighterColor = new Vector4(0f, 0f, 1f, 1f);

	[Tooltip("Prefab of the marker.")]
	public Marker MarkerPrefab;

	[Tooltip("The icon next to the agent counter.")]
	public Sprite AgentIconSprite;

	[Header("Localization")]
	[Tooltip("Localized string for the text that pops up informing the user how to change the radius size.")]
	[SerializeField]
	protected LocalizedString _radiusString;

	[Tooltip("Localized string for the text that pops up informing the user that all items under the marker are being salvaged.")]
	[SerializeField]
	protected LocalizedString _allItemsBeingSalvaged;

	[Space]
	[SerializeField]
	[Tooltip("Key (in QWERTY) to decrease the radius of the marker.")]
	protected KeyCode _decreaseRadiusKey = KeyCode.Z;

	[SerializeField]
	[Tooltip("Key (in QWERTY) to increase the radius of the marker.")]
	protected KeyCode _increaseRadiusKey = KeyCode.X;

	[Space]
	[Tooltip("Tags of the items this marker is allowed to salvage. The item needs to contain all the tags listed.")]
	[EnumFlag(1)]
	public Item.Tags AllowedItemTags;

	[Header("Audio")]
	[Tooltip("Audio file to play when the marker is created.")]
	public AudioClipProperties audioOnCreation;

	[Tooltip("Audio file to play when the marker range is increased.")]
	public AudioClipProperties audioOnIncrease;

	[Tooltip("Audio file to play when the marker range is decreased.")]
	public AudioClipProperties audioOnDecrease;

	[Tooltip("Audio file to play when the marker range is selected.")]
	public AudioClipProperties audioOnSelect;

	[NonSerialized]
	protected float _radius;

	[NonSerialized]
	protected Vector3 _cursorPosition;

	[NonSerialized]
	protected bool _canPlace;

	protected List<Item> _items = new List<Item>();

	protected CircleWaveHighlighter _markerRangeHighlighter;

	protected WorldManager _worldManager;

	[NonSerialized]
	private int _agentLimit;

	[NonSerialized]
	private int _radiusIntervalIndex;

	public int RadiusIntervalAmount => _radiusIntervalAmount;

	public Vector2 RadiusRange => _radiusRange;

	protected virtual float Range => GameManager.Settings.GameplaySettings.InteractionRadius;

	private void OnEnable()
	{
		_agentLimit = _initialAgentLimit;
		_radiusIntervalIndex = _initialRadiusIntervalIndex;
	}

	public override void Activate()
	{
		SelectionLink selection = Selector.Selection;
		_worldManager = GameManager.WorldManager;
		if ((bool)selection && selection.Type == ObjectType.Marker)
		{
			Selector.Deselect(selection.gameObject);
		}
		ShowPlacementRange();
		_radius = Marker.ReturnIntervalRadius(_radiusRange, _radiusIntervalIndex, _radiusIntervalAmount);
		if (GameManager.PrefabManager.TryGetInstance<CircleWaveHighlighter>(PrefabManager.PrefabId.MarkerRangeHighlighter, out _markerRangeHighlighter))
		{
			_markerRangeHighlighter.gameObject.SetActive(value: true);
			_markerRangeHighlighter.Initialize(_radius, Range, Construction.Townheart.transform.position, _okColor, _outsideSwimmingRangeHighlighterColor);
		}
		else
		{
			Debug.LogException(new Exception("Marker range highlighter could not be initialized"));
		}
		for (int i = 0; i < Community.PlayerCommunity.Markers.Count; i++)
		{
			Community.PlayerCommunity.Markers[i].ShowMarkerHighlight(enable: true);
		}
		UIManager.AddRewiredActionInfoToContext(this, _decreaseRadiusAction, _increaseRadiusAction, base.Interact, base.Cancel);
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		UpdateRadius();
		UpdateSelection();
		ListPool<Item>.List list = ListPool<Item>.Get();
		using (list)
		{
			if (TryReturnItemsInRange(list))
			{
				InventoryAuditor.Global.Reset();
				InventoryAuditor.Global.CountItems(list);
				TooltipPanel.Instance.DisplayItemTooltip(InventoryAuditor.Global);
				if (FlotsamInputManager.GetButtonUp(93) && TryToPlaceMarker(cursor))
				{
					cursor.Deactivate();
				}
			}
			else
			{
				TooltipPanel.Instance.DisplayItemTooltip(null, _allItemsBeingSalvaged);
			}
		}
	}

	public override void DeactivateImmediately()
	{
		CameraController.Instance.enabled = true;
		TooltipPanel.Instance.HideItemTooltip();
		HidePlacementRange();
		_markerRangeHighlighter.gameObject.SetActive(value: false);
		UIManager.DisableRewiredActionInfoContext(this);
		for (int i = 0; i < Community.PlayerCommunity.Markers.Count; i++)
		{
			Community.PlayerCommunity.Markers[i].ShowMarkerHighlight(enable: false);
		}
	}

	public void SetAgentLimit(int agentLimit)
	{
		_agentLimit = agentLimit;
	}

	public void SetRadiusIntervalIndex(int radiusIntervalIndex)
	{
		_radiusIntervalIndex = radiusIntervalIndex;
	}

	protected virtual void ShowPlacementRange()
	{
		_worldManager.ShowBoatRange();
	}

	protected virtual void HidePlacementRange()
	{
		_worldManager.HideBoatRange();
	}

	protected void UpdateSelection()
	{
		_markerRangeHighlighter.SetRadius(_radius);
		Ray ray = Camera.main.ScreenPointToRay(FlotsamInputManager.MousePosition);
		_canPlace = false;
		if (Physics.Raycast(ray, out var hitInfo, 1000f, 1024))
		{
			_cursorPosition = hitInfo.point;
			_markerRangeHighlighter.gameObject.transform.position = _cursorPosition;
			GridNode gridNode = GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(hitInfo.point.Vector2TopDown());
			_canPlace = gridNode != null && _requiredClearance <= gridNode.Clearance;
		}
		_markerRangeHighlighter.SetColor(_canPlace ? _okColor : _errorColor);
	}

	protected virtual bool TryToPlaceMarker(CursorManager cursor)
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return false;
		}
		if (_canPlace)
		{
			Marker marker = UnityEngine.Object.Instantiate(MarkerPrefab, _worldManager.WorldParent);
			Project project = new Project(_projectProperties, marker.gameObject, marker);
			project.AssignmentLimit = _agentLimit;
			marker.Initialize(_cursorPosition, _radiusIntervalIndex, project, this);
			marker.Community = Community.PlayerCommunity;
			Community.PlayerCommunity.QueueProject(project);
			Community.PlayerCommunity.Markers.Add(marker);
			AudioManager.Play(audioOnCreation);
			return true;
		}
		return false;
	}

	protected void UpdateRadius()
	{
		if (_decreaseRadiusAction.GetButtonDown())
		{
			_radiusIntervalIndex = Mathf.Clamp(--_radiusIntervalIndex, 0, RadiusIntervalAmount - 1);
			AudioManager.Play(audioOnDecrease);
		}
		if (_increaseRadiusAction.GetButtonDown())
		{
			_radiusIntervalIndex = Mathf.Clamp(++_radiusIntervalIndex, 0, RadiusIntervalAmount - 1);
			AudioManager.Play(audioOnIncrease);
		}
		_radius = Marker.ReturnIntervalRadius(_radiusRange, _radiusIntervalIndex, _radiusIntervalAmount);
		_markerRangeHighlighter.SetRadius(_radius);
	}

	private bool TryReturnItemsInRange(List<Item> itemsInRange, bool includeReserved = false)
	{
		List<Flotsam> flotsamInWorld = _worldManager.FlotsamInWorld;
		int count = flotsamInWorld.Count;
		for (int i = 0; i < count; i++)
		{
			Flotsam flotsam = flotsamInWorld[i];
			if (flotsam.Position.IsInRange(_cursorPosition, _radius) && ReturnIsInWorldManagerRadius(flotsam.Position))
			{
				flotsam.Inventory.ReturnItemsWithTags(AllowedItemTags, itemsInRange, includeReserved);
			}
		}
		return 0 < itemsInRange.Count;
	}

	protected virtual bool ReturnIsInWorldManagerRadius(Vector3 position)
	{
		return _worldManager.IsInBoatRadius(position);
	}
}
