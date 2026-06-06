using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Salvager : SceneBehaviour, IBuildableExtendable, IItemProducer, IPersistentReference
{
	public enum State
	{
		None = 0,
		Salvaging = 1,
		SalvagingFinished = 2,
		SalvagingInterupted = 3,
		Salvaged = 4
	}

	[Serializable]
	public class SalvageableCategory : IToggleable
	{
		[SerializeField]
		[Tooltip("The main item properties. Other tha for checks these properties are used for visualization in the UI.")]
		private ItemProperties _mainItemProperties;

		[SerializeField]
		private ItemProperties[] _subItemProperties;

		[SerializeField]
		private float _salvageTime = 30f;

		public ItemProperties MainItemProperties => _mainItemProperties;

		public List<Item> Items { get; private set; } = new List<Item>();

		public float SalvageTime => _salvageTime;

		public bool Enabled { get; set; } = true;

		public bool IsInteractable => true;

		public bool IsCompleted => false;

		public bool IsToggled => Enabled;

		public void Toggle()
		{
			Enabled = !Enabled;
		}

		public bool TryAddItem(Item item)
		{
			if (_mainItemProperties == item.Properties || _subItemProperties.Contains(item.Properties))
			{
				Items.Add(item);
				return true;
			}
			return false;
		}

		public void PopulateAllItemProperties(List<ItemProperties> itemPropertiesList)
		{
			itemPropertiesList.Add(MainItemProperties);
			if (!_subItemProperties.IsNullOrEmpty())
			{
				itemPropertiesList.AddRange(_subItemProperties);
			}
		}
	}

	[SerializeField]
	[Tooltip("The item filter increases performance by filtering the flotsam items before they are assigned to a salvageable category.")]
	private Item.Tags _itemFilter = Item.Tags.FishMarker;

	[SerializeField]
	private SalvageableCategory[] _salvageableCategories;

	[SerializeField]
	private ProjectProperties _projectProperties;

	[SerializeField]
	private AttachableSlots _salvageSlots;

	[SerializeField]
	private InventorySlots _exportSlots;

	[SerializeField]
	private Activity _drifterActivity = Activity.Working;

	[SerializeField]
	private DrifterAttributes.AttributeType _drifterAttribute = DrifterAttributes.AttributeType.Salvaging;

	[SerializeField]
	[EnumFlag(1)]
	private AssignmentType _assignmentType = AssignmentType.BuoySalvaging;

	private List<Flotsam> _flotsamInRange = new List<Flotsam>();

	private Item _cachedClosestAvailableItem;

	private Target _target;

	public SalvageableCategory[] SalvageableCategories => _salvageableCategories;

	public State SalvageableState { get; private set; }

	public Agent SalvagingAgent { get; private set; }

	public Item CurrentItem { get; private set; }

	public float SalvageTime { get; private set; }

	public float SalvageProgress { get; private set; }

	public float NormalizedSalvageProgress
	{
		get
		{
			if (SalvageTime != 0f)
			{
				return SalvageProgress / SalvageTime;
			}
			return 0f;
		}
	}

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public DrifterAttributes.AttributeType DrifterAttribute => _drifterAttribute;

	public ResourceProvider ExportResourceProvider { get; private set; }

	public List<ItemProperties> ProducedItems { get; private set; }

	public event UnityAction SalvageableItemsUpdated;

	private void Start()
	{
		_target = GetComponentInChildren<Target>();
		UpdateFlotsamInRange();
		UpdateSalvageableItems();
	}

	private void OnDestroy()
	{
		ExportResourceProvider?.Unregister();
		ExportResourceProvider = null;
		_exportSlots.Remove();
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Export);
		if (ExportResourceProvider == null)
		{
			ExportResourceProvider = ResourceProvider.Get(Buildable, SubInventoryType.Export);
			ExportResourceProvider.AddAssignmentType(_assignmentType);
			ExportResourceProvider.Register();
			ExportResourceProvider.Register();
		}
		if (ProducedItems == null)
		{
			ProducedItems = new List<ItemProperties>();
			SalvageableCategory[] salvageableCategories = _salvageableCategories;
			for (int i = 0; i < salvageableCategories.Length; i++)
			{
				salvageableCategories[i].PopulateAllItemProperties(ProducedItems);
			}
		}
		if (!restored)
		{
			Project project = new Project(_projectProperties, base.gameObject);
			Buildable.Community.QueueProject(project);
		}
		_exportSlots.Initialize(Buildable.Inventory, SubInventoryType.Export, Buildable.OutlineRenderer);
		UpdateFlotsamInRange();
		UpdateSalvageableItems();
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnGameEvent);
		GameEventDispatcher.AddListener(GameEventType.FlotsamSalvage, OnGameEvent);
		GameEventDispatcher.AddListener(GameEventType.FlotsamItemSalvage, OnGameEvent);
	}

	public void Finish(bool restored = false)
	{
		Buildable.Community.AddProducer(this);
	}

	public void Remove()
	{
		Buildable.Community.RemoveProducer(this);
		ExportResourceProvider?.Unregister();
		ExportResourceProvider = null;
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnGameEvent);
		GameEventDispatcher.RemoveListener(GameEventType.FlotsamSalvage, OnGameEvent);
		GameEventDispatcher.RemoveListener(GameEventType.FlotsamItemSalvage, OnGameEvent);
	}

	public void StartSalvage(Item item, Agent agent)
	{
		CurrentItem = item;
		SalvagingAgent = agent;
		if (_salvageSlots.AreSlotsAvailable())
		{
			_salvageSlots.Attach(agent.transform);
			agent.UpdateActivity(_drifterActivity);
			Buildable.Animator_SetInteger("IsWorking", 1);
		}
		if (CurrentItem != null)
		{
			CurrentItem.Reserve();
		}
		SalvageTime = ReturnSalvageTime(CurrentItem);
		SalvageableState = State.Salvaging;
	}

	public void Salvage(Agent agent)
	{
		if (SalvageableState != State.Salvaging)
		{
			Debug.LogException(new NotSupportedException());
		}
		else if (CanRun() && IsCurrentItemSalvageable())
		{
			float num = agent.Attributes.ReturnAttributeModifier(_drifterAttribute);
			SalvageProgress += Time.deltaTime * num;
			if (SalvageProgress >= SalvageTime)
			{
				SalvageableState = State.SalvagingFinished;
			}
		}
		else
		{
			SalvageableState = State.SalvagingInterupted;
		}
	}

	public void SalvageItem()
	{
		Item currentItem = CurrentItem;
		ResetSalvageProgress();
		if (currentItem.TryTakeFromInventory(out var takenItem))
		{
			Buildable.Inventory.AddItem(takenItem, SubInventoryType.Export);
		}
		else
		{
			Debug.LogException(new Exception("Salvager '" + Buildable.Name + "' was unable to salvage '" + currentItem.Properties.name + "'."));
		}
		ItemEvent.Dispatch(GameEventType.FlotsamItemSalvage, currentItem);
	}

	public void StopSalvage(Agent agent)
	{
		if (!IsCurrentItemSalvageable())
		{
			ResetSalvageProgress();
		}
		_salvageSlots.Detach(agent.transform, GameManager.AgentManager.AgentParent);
		agent.ReturnNavigator().AttachToTarget(_target);
		Buildable.Animator_SetInteger("IsWorking", 0);
		SalvagingAgent = null;
		SalvageableState = State.None;
	}

	private void ResetSalvageProgress()
	{
		SalvageProgress = 0f;
		SalvageableState = State.None;
		if (CurrentItem != null)
		{
			CurrentItem.CancelReservation();
			CurrentItem = null;
		}
		_cachedClosestAvailableItem = null;
	}

	public void CountSalvageableItemsInRange(InventoryAuditor auditor)
	{
		foreach (Flotsam item in _flotsamInRange)
		{
			item.Inventory.Count(auditor);
		}
	}

	private void OnGameEvent(GameEvent gameEvent)
	{
		switch (gameEvent.EventType)
		{
		case GameEventType.TownheartMoved:
			UpdateFlotsamInRange();
			UpdateSalvageableItems();
			break;
		case GameEventType.FlotsamSalvage:
			if (gameEvent is FlotsamEvent flotsamEvent)
			{
				_flotsamInRange.Remove(flotsamEvent.Flotsam);
			}
			break;
		case GameEventType.FlotsamItemSalvage:
			UpdateSalvageableItems();
			break;
		}
	}

	private void UpdateFlotsamInRange()
	{
		WorldManager worldManager = GameManager.WorldManager;
		_flotsamInRange.Clear();
		foreach (Flotsam item in worldManager.FlotsamInWorld)
		{
			if ((item.Inventory.Tags & _itemFilter) == _itemFilter && worldManager.IsInSwimmingRadius(item.Position))
			{
				_flotsamInRange.Add(item);
			}
		}
	}

	private void UpdateSalvageableItems()
	{
		SalvageableCategory[] salvageableCategories = _salvageableCategories;
		for (int i = 0; i < salvageableCategories.Length; i++)
		{
			salvageableCategories[i]?.Items.Clear();
		}
		foreach (Flotsam item in _flotsamInRange)
		{
			foreach (Item item2 in item.Inventory.ReturnAllItems())
			{
				salvageableCategories = _salvageableCategories;
				for (int i = 0; i < salvageableCategories.Length && !salvageableCategories[i].TryAddItem(item2); i++)
				{
				}
			}
		}
		this.SalvageableItemsUpdated?.Invoke();
	}

	public bool IsCurrentItemSalvageable()
	{
		return IsSalvageableItem(CurrentItem);
	}

	public bool CanRun()
	{
		if (Active && TimeManager.ReturnIsDayTime())
		{
			return Buildable.Inventory.ReturnCount(SubInventoryType.Export, includeReserved: true) < Buildable.Inventory.ExportCapacity;
		}
		return false;
	}

	public bool TryReturnClosestAvailableItem(out Item item)
	{
		if (IsSalvageableItem(CurrentItem))
		{
			item = CurrentItem;
		}
		else if (IsItemAvailableForSalvage(_cachedClosestAvailableItem))
		{
			item = _cachedClosestAvailableItem;
		}
		else
		{
			SalvageableCategory[] salvageableCategories = _salvageableCategories;
			foreach (SalvageableCategory salvageableCategory in salvageableCategories)
			{
				if (salvageableCategory == null || !salvageableCategory.Enabled || salvageableCategory.Items.IsNullOrEmpty())
				{
					continue;
				}
				for (int j = 0; j < salvageableCategory.Items.Count; j++)
				{
					item = salvageableCategory.Items[j];
					if (item.IsAvailable() && !GameManager.ResourceManager.IsProductionLimitReached(item.Properties))
					{
						_cachedClosestAvailableItem = item;
						return true;
					}
				}
			}
			item = null;
		}
		return item != null;
	}

	private bool IsItemAvailableForSalvage(Item item)
	{
		if (IsSalvageableItem(item) && !item.IsReserved)
		{
			return item.Project == null;
		}
		return false;
	}

	private bool IsSalvageableItem(Item item)
	{
		if (item == null || item.Owner == null || item.InventoryType != InventoryType.Flotsam || GameManager.ResourceManager.IsProductionLimitReached(item.Properties))
		{
			return false;
		}
		SalvageableCategory[] salvageableCategories = _salvageableCategories;
		foreach (SalvageableCategory salvageableCategory in salvageableCategories)
		{
			if (salvageableCategory != null && salvageableCategory.Enabled && salvageableCategory.Items.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	private float ReturnSalvageTime(Item item)
	{
		SalvageableCategory[] salvageableCategories = _salvageableCategories;
		foreach (SalvageableCategory salvageableCategory in salvageableCategories)
		{
			if (salvageableCategory.Items.Contains(item))
			{
				return salvageableCategory.SalvageTime;
			}
		}
		Debug.LogException(new NotSupportedException($"Unable to return salvage time for {item.Properties}, this item is not salvageable!"));
		return 60f;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return SalvagingAgent == null;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new SalvagerPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		SalvagerPersistentData salvagerPersistentData = persistentData as SalvagerPersistentData;
		SalvageProgress = salvagerPersistentData.SalvageProgress;
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		if (persistentData is SalvagerPersistentData salvagerPersistentData)
		{
			if (salvagerPersistentData.CurrentItem != null && salvagerPersistentData.CurrentItem.TryReturn(out var instance))
			{
				CurrentItem = instance;
			}
			salvagerPersistentData.RestoreSalvageableCategories(_salvageableCategories);
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		(persistentData as SalvagerPersistentData).CurrentItem = CurrentItem;
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	private bool IsAllowed(ItemProperties itemProperties)
	{
		return (itemProperties.Tags & Item.Tags.FishMarker) != 0;
	}

	public int GetItemsInProductionCount(ItemProperties itemProperties)
	{
		if (CurrentItem == null || !(CurrentItem.Properties == itemProperties))
		{
			return 0;
		}
		return 1;
	}
}
