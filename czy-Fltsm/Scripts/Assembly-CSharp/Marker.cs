using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

public class Marker : SceneBehaviour, IPersistentReference, ISelectable, ISalvageTarget, IPanelContext, IOutlineRenderControllerProvider, IWorldMapMarkerTarget
{
	[Tooltip("PlopProperties for deployment splash.")]
	public PlopProperties PlopProperties;

	[Tooltip("The outline render controller of the marker mesh.")]
	public OutlineRenderController OutlineRenderController;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private WorldIconHandler _worldIconHandler;

	[HideInInspector]
	public Community Community;

	[HideInInspector]
	public MarkerCursorProperties MarkerCursorProperties;

	protected PhysicsController _physicsController;

	protected bool _isSelected;

	protected SelectionLink _selectionLink;

	protected Item.Tags _allowedTags;

	protected Item.Tags _salvageableTags;

	protected CircleWaveHighlighter _markerRangeHighlighter;

	private OutlineRendererComponent _outlineRenderComponent;

	private Vector3 _position;

	public UnityEvent UpdatedAllowedItemPropertiesEvent;

	public UnityEvent UpdatedItemsInRadius;

	public Project Project { get; private set; }

	public Dictionary<ItemProperties, bool> ItemFilter { get; private set; }

	public float Radius { get; private set; }

	public List<Flotsam> FlotsamInRadius { get; private set; }

	public List<Item> AllowedItemsInRadius { get; private set; }

	public List<Item> SalvageableItemsInRadius { get; private set; }

	public ObjectType ObjectType => ObjectType.Marker;

	public GameObject RelatedGameObject => base.gameObject;

	public int CurrentRadiusIntervalIndex { get; private set; }

	public bool ManuallyRemoved { get; private set; }

	public List<ItemProperties> ItemTypesInRange { get; private set; } = new List<ItemProperties>();

	protected virtual float _range => GameManager.Settings.GameplaySettings.InteractionRadius;

	public PanelID PanelID => PanelID.MarkerPanel;

	Vector3 IWorldMapMarkerTarget.LocalPosition => base.transform.position;

	Sprite IWorldMapMarkerTarget.Icon => _icon;

	public int PersistentIndex { get; set; } = -1;

	OutlineRenderController IOutlineRenderControllerProvider.OutlineController => OutlineRenderController;

	public void Initialize(Vector3 position, int radiusIntervalIndex, Project project, MarkerCursorProperties properties)
	{
		base.transform.position = position;
		LinkProject(project);
		Initialize(radiusIntervalIndex, properties);
	}

	public void Restore(MarkerCursorProperties properties, int radiusIntervalIndex, Dictionary<ItemProperties, bool> allowedItemProperties)
	{
		Initialize(radiusIntervalIndex, properties);
		if (allowedItemProperties != null)
		{
			Dictionary<ItemProperties, bool>.Enumerator enumerator = allowedItemProperties.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (ItemFilter.ContainsKey(enumerator.Current.Key))
				{
					ItemFilter[enumerator.Current.Key] = enumerator.Current.Value;
				}
			}
		}
		UpdatedAllowedItemPropertiesEvent.Invoke();
	}

	private void Initialize(int radiusIntervalIndex, MarkerCursorProperties properties)
	{
		MarkerCursorProperties = properties;
		CurrentRadiusIntervalIndex = radiusIntervalIndex;
		Radius = ReturnIntervalRadius(radiusIntervalIndex);
		_outlineRenderComponent = GetComponent<OutlineRendererComponent>();
		_physicsController = GetComponentInChildren<PhysicsController>();
		_physicsController.Initialize(null, -0.1f);
		if ((bool)PlopProperties)
		{
			PlopProperties.Initiate(CameraController.Instance.transform);
		}
		if ((bool)PlopProperties)
		{
			EffectsManager.ActivateEffect(EffectTrigger.Splash, base.transform, Vector3.zero);
		}
		FlotsamInRadius = ListPool<Flotsam>.Get();
		AllowedItemsInRadius = ListPool<Item>.Get();
		SalvageableItemsInRadius = ListPool<Item>.Get();
		InitializeAllowedItemProperties(properties);
		_markerRangeHighlighter = UnityEngine.Object.Instantiate(GameManager.Settings.FXSettings.CircleHighlighterPrefab.gameObject).GetComponent<CircleWaveHighlighter>();
		_markerRangeHighlighter.Initialize(Radius, _range, base.transform.position, MarkerCursorProperties._okColor, MarkerCursorProperties._outsideSwimmingRangeHighlighterColor);
		_markerRangeHighlighter.gameObject.SetActive(value: false);
	}

	protected void Start()
	{
		_selectionLink = GetComponentInChildren<SelectionLink>();
		_selectionLink.SetObjectToSelect(base.gameObject, ObjectType.Marker);
		_position = base.transform.position;
		UpdateFlotsamInRadius();
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		WorldMapManager.InstantiateMarker(this);
		MarkerEvent.Dispatch(GameEventType.MarkerPlaced, this);
	}

	protected void Update()
	{
		_position = base.transform.position;
		UpdateSalvageableItemsInRadius();
		if (_isSelected)
		{
			UpdateSelection();
		}
		_markerRangeHighlighter.gameObject.transform.position = _position.Leveled();
		if (AllowedItemsInRadius.Count == 0)
		{
			Project?.Stop(ProjectFlags.Finished);
		}
	}

	protected void OnDestroy()
	{
		if (Project != null)
		{
			Project.FinishedEvent.RemoveListener(OnProjectFinished);
			Project.Stop(ProjectFlags.Exception);
			Debug.LogException(new Exception("'" + base.name + "' was destroyed while it had an active project!"));
		}
		ManuallyRemoved = SalvageableItemsInRadius.Count > 0;
		FlotsamInRadius?.Dispose();
		AllowedItemsInRadius?.Dispose();
		SalvageableItemsInRadius?.Dispose();
		if ((bool)_markerRangeHighlighter)
		{
			UnityEngine.Object.Destroy(_markerRangeHighlighter.gameObject);
		}
		Community.PlayerCommunity?.Markers.RemoveSafely(this);
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		WorldMapManager.DestroyMarker(this);
		MarkerEvent.Dispatch(GameEventType.MarkerDestroyed, this);
	}

	protected virtual void ShowPlacementRange()
	{
		GameManager.WorldManager.ShowBoatRange();
	}

	protected virtual void HidePlacementRange()
	{
		GameManager.WorldManager.HideBoatRange();
	}

	private void OnTownheartMoved(GameEvent evt)
	{
		if (evt is MovementEvent movementEvent)
		{
			movementEvent.ApplyMovementToTransformLocal(base.transform);
			_position = base.transform.position;
			UpdateFlotsamInRadius();
		}
	}

	protected void InitializeAllowedItemProperties(MarkerCursorProperties properties)
	{
		ItemSettings itemSettings = GameManager.Settings.ItemSettings;
		ItemFilter = new Dictionary<ItemProperties, bool>();
		_allowedTags = properties.AllowedItemTags;
		for (int i = 0; i < itemSettings.ItemProperties.Length; i++)
		{
			ItemProperties itemProperties = itemSettings.ItemProperties[i];
			if (itemProperties.Tags.HasFlag(_allowedTags))
			{
				ItemFilter.Add(itemProperties, value: true);
			}
		}
		_salvageableTags = ReturnSalvageableTags();
	}

	public void SetAgentAmount(int amount)
	{
		Project.AssignmentLimit = amount;
		if ((bool)MarkerCursorProperties)
		{
			MarkerCursorProperties.SetAgentLimit(amount);
		}
	}

	protected virtual void UpdateFlotsamInRadius()
	{
		List<Flotsam> flotsamInWorld = GameManager.WorldManager.FlotsamInWorld;
		int count = flotsamInWorld.Count;
		FlotsamInRadius.Clear();
		for (int i = 0; i < count; i++)
		{
			Flotsam flotsam = flotsamInWorld[i];
			if (flotsam.Position.IsInRange(_position, Radius) && ReturnIsInWorldManagerRadius(flotsam.Position))
			{
				FlotsamInRadius.Add(flotsam);
			}
		}
		UpdateSalvageableItemsInRadius();
	}

	protected virtual void UpdateSalvageableItemsInRadius()
	{
		AllowedItemsInRadius.Clear();
		SalvageableItemsInRadius.Clear();
		ItemTypesInRange.Clear();
		int count = FlotsamInRadius.Count;
		while (0 < count--)
		{
			Flotsam flotsam = FlotsamInRadius[count];
			if ((bool)flotsam)
			{
				flotsam.Inventory.ReturnItemsWithTags(_allowedTags, AllowedItemsInRadius);
			}
			else
			{
				FlotsamInRadius.RemoveAt(count);
			}
		}
		foreach (Item item in AllowedItemsInRadius)
		{
			ItemTypesInRange.AddUnique(item.Properties);
		}
		foreach (Item item2 in AllowedItemsInRadius)
		{
			if (ItemFilter.TryGetValue(item2.Properties, out var value) && value)
			{
				SalvageableItemsInRadius.Add(item2);
			}
		}
		UpdatedItemsInRadius.Invoke();
	}

	protected void UpdateSelection()
	{
		_markerRangeHighlighter.SetRadius(Radius);
	}

	protected void OnProjectFinished(Project project, bool success = false)
	{
		Project.FinishedEvent.RemoveListener(OnProjectFinished);
		Project.MalfunctionsUpdated -= OnProjectMalfunctionUpdated;
		Project = null;
		EffectsManager.ActivateEffect(EffectTrigger.Splash, null, base.transform.position);
		if (success)
		{
			MarkerEvent.Dispatch(GameEventType.MarkerFinished, this);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void LinkProject(Project project)
	{
		Project = project;
		Project.SalvageTarget = this;
		Project.FinishedEvent.AddListener(OnProjectFinished);
		Project.MalfunctionsUpdated += OnProjectMalfunctionUpdated;
	}

	public void SetSizeIndex(int sizeIndex)
	{
		CurrentRadiusIntervalIndex = Mathf.Clamp(sizeIndex, 0, MarkerCursorProperties.RadiusIntervalAmount - 1);
		Radius = ReturnIntervalRadius(CurrentRadiusIntervalIndex);
		UpdateFlotsamInRadius();
		if ((bool)MarkerCursorProperties)
		{
			MarkerCursorProperties.SetRadiusIntervalIndex(CurrentRadiusIntervalIndex);
		}
	}

	public void ShowMarkerHighlight(bool enable, bool selected = false)
	{
		_markerRangeHighlighter.gameObject.SetActive(enable);
		if (enable && !selected)
		{
			_markerRangeHighlighter.SetColor(GameManager.Settings.FXSettings.MarkerNotSelectedInsideSwimmingHighlightRadiusColor, GameManager.Settings.FXSettings.MarkerNotSelectedOutsideSwimmingHighlightRadiusColor);
		}
		else
		{
			_markerRangeHighlighter.SetColor(MarkerCursorProperties._okColor, MarkerCursorProperties._outsideSwimmingRangeHighlighterColor);
		}
	}

	public void Remove()
	{
		Project?.Stop(ProjectFlags.Cancelled);
	}

	public void PopulateItemsToHaul(ProjectAssignment assignment)
	{
		Vector3 position = assignment.Agent.transform.position;
		Item closestItem;
		while (TryReturnClosestSalvageableItem(out closestItem, position) && assignment.AddItemToHaul(closestItem))
		{
			position = closestItem.Inventory.transform.position;
		}
	}

	public int PopulateItemList(Itemlist itemList)
	{
		if (SalvageableItemsInRadius.IsNullOrEmpty())
		{
			return 0;
		}
		int num = 0;
		foreach (Item item in SalvageableItemsInRadius)
		{
			if (itemList.TryAddUniqueItemSlot(num, item.Properties))
			{
				num++;
			}
		}
		return num;
	}

	public void ToggleItemFilter(ItemProperties itemProperties)
	{
		if (ItemFilter.TryGetValue(itemProperties, out var value))
		{
			ItemFilter[itemProperties] = !value;
			_salvageableTags = ReturnSalvageableTags();
			UpdatedAllowedItemPropertiesEvent.Invoke();
		}
	}

	public bool ReturnIsSalvageableItem(Item item)
	{
		return SalvageableItemsInRadius.Contains(item);
	}

	public bool ReturnIsItemFilterToggled(ItemProperties itemProperties)
	{
		if (ItemFilter.TryGetValue(itemProperties, out var value))
		{
			return value;
		}
		return false;
	}

	public bool ReturnHasSalvageableItems(Project project, Agent agent)
	{
		return true;
	}

	public ProjectBlocker ReturnProjectBlockers(Project project)
	{
		UpdateSalvageableItemsInRadius();
		if (SalvageableItemsInRadius.Count == 0)
		{
			return ProjectBlocker.SharableEmptyItemList;
		}
		int num = 0;
		foreach (Item item in SalvageableItemsInRadius)
		{
			if (item.IsReserved)
			{
				num++;
			}
			else if ((bool)item.Inventory && item.Inventory.Type == InventoryType.Flotsam && item.Project == null && ReturnItemHasStorageSpace(item))
			{
				return ProjectBlocker.None;
			}
		}
		if (num >= SalvageableItemsInRadius.Count)
		{
			return ProjectBlocker.SharableEmptyItemList;
		}
		return ProjectBlocker.StorageSpace;
	}

	public bool ReturnIsSalvaged()
	{
		return AllowedItemsInRadius.Count == 0;
	}

	public float ReturnSalvageItemExperience(Item item)
	{
		return 0f;
	}

	public void OnDeselected()
	{
		GameManager.UIManager.ClosePanel(PanelID.MarkerPanel);
		_outlineRenderComponent.ResetHighlightOutline();
		HidePlacementRange();
		_isSelected = false;
	}

	public void OnSelected()
	{
		GameManager.UIManager.DisplayPanel(this);
		UpdateSelection();
		_isSelected = true;
		ShowPlacementRange();
		AudioManager.Play(MarkerCursorProperties.audioOnSelect);
	}

	private void OnProjectMalfunctionUpdated()
	{
		_worldIconHandler.ClearAllIcons();
		using ListPool<PlaceableAlertProperties>.List list = ListPool<PlaceableAlertProperties>.Get();
		Project.PopulateMalfunctions(list);
		foreach (PlaceableAlertProperties item in list)
		{
			_worldIconHandler.AddIcon(item);
		}
	}

	public static float ReturnIntervalRadius(Vector2 range, int intervalIndex, int totalIntervals)
	{
		float num = (float)intervalIndex / (float)(totalIntervals - 1);
		return range.x + (range.y - range.x) * num;
	}

	private float ReturnIntervalRadius(int intervalIndex)
	{
		return ReturnIntervalRadius(MarkerCursorProperties.RadiusRange, CurrentRadiusIntervalIndex, MarkerCursorProperties.RadiusIntervalAmount);
	}

	private bool TryReturnClosestSalvageableItem(out Item closestItem, Vector3 position)
	{
		int count = SalvageableItemsInRadius.Count;
		float num = float.MaxValue;
		closestItem = null;
		for (int i = 0; i < count; i++)
		{
			Item item = SalvageableItemsInRadius[i];
			if (!item.IsReserved && item.Project == null)
			{
				float num2 = position.DistanceToLeveledSquared(item.Owner.transform.position);
				if (num2 < num && ReturnItemHasStorageSpace(item))
				{
					closestItem = item;
					num = num2;
				}
			}
		}
		return closestItem != null;
	}

	protected virtual bool ReturnIsInWorldManagerRadius(Vector3 position)
	{
		return GameManager.WorldManager.IsInBoatRadius(position);
	}

	protected virtual bool ReturnItemHasStorageSpace(Item item)
	{
		return true;
	}

	private Item.Tags ReturnSalvageableTags()
	{
		Dictionary<ItemProperties, bool>.Enumerator enumerator = ItemFilter.GetEnumerator();
		Item.Tags tags = Item.Tags.Resource;
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value)
			{
				tags |= enumerator.Current.Key.Tags;
			}
		}
		return tags;
	}
}
