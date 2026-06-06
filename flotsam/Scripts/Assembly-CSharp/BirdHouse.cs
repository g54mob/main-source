using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdHouse : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	public enum BirdHouseState
	{
		None = 0,
		Working = 1,
		Sleeping = 2
	}

	[Header("Bird Food")]
	[FormerlySerializedAs("_foodSource")]
	[Tooltip("Food ingredient to convert to bird food.")]
	public ItemProperties FoodSource;

	[Tooltip("Amount of bird food 1 ingredient gives.")]
	public int ConversionRate = 2;

	[SerializeField]
	[Tooltip("Percentage of stored food that needs to be reached before the storage will be refilled.")]
	[Range(0f, 1f)]
	private float _refillThreshold = 0.5f;

	[SerializeField]
	[Tooltip("Import project to collect fish.")]
	[FormerlySerializedAs("_fishImportProject")]
	private ProjectProperties _fishImportProjectProperties;

	[SerializeField]
	private FoodRationVisual _foodRationPrefab;

	[SerializeField]
	private List<Transform> _foodRationPositions = new List<Transform>();

	[Header("Salvaging")]
	[SerializeField]
	private ItemPropertiesGroup[] _itemGroups;

	[Header("Other")]
	[Tooltip("Where birds will move to when approaching this construction.")]
	public Transform BirdTarget;

	[Tooltip("Positions where the birds will sit when sleeping / eating.")]
	public AttachableSlots PerchSpots;

	[Tooltip("Maximum amount of birds that can reside here.")]
	[FormerlySerializedAs("Capacity")]
	public int BirdCapacity = 5;

	[Space]
	[SerializeField]
	[EnumFlag(1)]
	[Tooltip("Assignment type for hauling away items.")]
	public AssignmentType _haulingAssignmentType;

	[SerializeField]
	private int _storageCapacity = 50;

	[FormerlySerializedAs("StorageSlots")]
	[SerializeField]
	private InventorySlots _storageSlots;

	private Project _importProject;

	private ResourceProvider _exportResourceProvider;

	private int _fishNeeded;

	private FoodRationVisual[] _foodRationVisuals;

	private List<Item> _cachedIngredients = new List<Item>();

	private bool _processIngredients;

	private WorldManager _worldManager;

	public ItemPropertiesGroup[] ItemGroups => _itemGroups;

	public bool RefillFood { get; set; } = true;

	public Buildable Buildable { get; private set; }

	public BirdHouseState State { get; private set; }

	public List<Bird> Birds { get; private set; } = new List<Bird>();

	public List<Item> SalvageableItems { get; private set; } = new List<Item>();

	public bool Active { get; private set; }

	public int FoodStore { get; private set; }

	public bool Moving { get; private set; }

	public FoodRation[] FoodRations { get; private set; }

	public bool ExportItems { get; set; } = true;

	public int PersistentIndex { get; set; } = -1;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.Community.AddBirdhouse(this);
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Storage, _storageCapacity);
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Import);
		EnableItemExport(exportItems: true);
		_storageSlots.Initialize(Buildable.Inventory, SubInventoryType.Storage, Buildable.OutlineRenderer);
		GameEventDispatcher.AddListener(GameEventType.DaytimeStarted, OnDaytimeStarted);
		GameEventDispatcher.AddListener(GameEventType.NighttimeStarted, OnNighttimeStarted);
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		Buildable.Community.Inventory.InventoryUpdatedEvent.AddListener(TryToQueueFood);
		_worldManager = GameManager.WorldManager;
	}

	public void Finish(bool restored = false)
	{
		if (!restored)
		{
			State = BirdHouseState.Working;
			TryToQueueFood();
			RefillFood = true;
		}
		UpdateFoodRations();
		UpdateItemsInRadius();
		Buildable.Community.BirdhouseFinished();
	}

	private void LateUpdate()
	{
		if (Buildable.BuildPhase == BuildPhase.Finished)
		{
			if (0 < GameManager.WorldManager.FlotsamInWorld.Count)
			{
				UpdateItemsInRadius();
			}
			if (_processIngredients)
			{
				ProcessIngredients();
			}
			UpdateBirdFullfillment();
			if (ReturnStorageIsFull())
			{
				Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorExportStorageFullProperties);
			}
			else
			{
				Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorExportStorageFullProperties);
			}
		}
	}

	public void Remove()
	{
		Buildable.Community.RemoveBirdhouse(this);
		EnableItemExport(exportItems: false);
	}

	public void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		GameEventDispatcher.RemoveListener(GameEventType.DaytimeStarted, OnDaytimeStarted);
		GameEventDispatcher.RemoveListener(GameEventType.NighttimeStarted, OnNighttimeStarted);
		_storageSlots.Remove();
	}

	private void OnDaytimeStarted(GameEvent gameEvent)
	{
		State = BirdHouseState.Working;
	}

	private void OnNighttimeStarted(GameEvent gameEvent)
	{
		State = BirdHouseState.Sleeping;
	}

	public bool AddBird(Bird bird)
	{
		if (Birds.Contains(bird))
		{
			return false;
		}
		if (Birds.Count >= BirdCapacity)
		{
			Debugger.Log($"{bird.Name} can't join this birdhouse because it's full.", this);
			return false;
		}
		Birds.Add(bird);
		TryToQueueFood();
		return true;
	}

	public bool RemoveBird(Bird bird)
	{
		if (!Birds.Contains(bird))
		{
			return false;
		}
		Birds.Remove(bird);
		return true;
	}

	public bool SalvageableItemAvailable(out Item item)
	{
		float num = float.MaxValue;
		item = null;
		if (!Active || ReturnStorageIsFull())
		{
			return false;
		}
		foreach (Item salvageableItem in SalvageableItems)
		{
			if (!salvageableItem.IsReserved && salvageableItem.InventoryType == InventoryType.Flotsam && salvageableItem.Project == null)
			{
				float sqrMagnitude = salvageableItem.Owner.transform.position.sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					item = salvageableItem;
				}
			}
		}
		if (item == null)
		{
			return false;
		}
		if (item.Reserve())
		{
			if (Buildable.Inventory.ReserveIncomingItem(item, SubInventoryType.Storage))
			{
				return true;
			}
			item.CancelReservation();
		}
		item = null;
		return false;
	}

	public void ReleaseItem(Item item)
	{
		item.CancelReservation();
		item.UnreserveMoveToInventory();
	}

	public void OnTownheartMoved(GameEvent gameEvent)
	{
		UpdateItemsInRadius();
		for (int i = 0; i < Birds.Count; i++)
		{
			Birds[i].WorldStoppedMoving();
		}
	}

	public void ToggleFoodRefilling(bool isOn)
	{
		RefillFood = isOn;
		if (RefillFood)
		{
			TryToQueueFood();
		}
	}

	private bool ShouldRequestIngredients()
	{
		if (!RefillFood)
		{
			return false;
		}
		if (Birds.Count == 0)
		{
			return false;
		}
		if (_importProject != null)
		{
			return false;
		}
		int num = Mathf.CeilToInt(FoodStore / ConversionRate);
		int num2 = Mathf.FloorToInt(_refillThreshold * (float)Buildable.Inventory.ReturnCapacity(SubInventoryType.Import));
		if (num >= num2)
		{
			return false;
		}
		if (Buildable.Inventory.HasItems(SubInventoryType.Import, includeReserved: true))
		{
			_processIngredients = true;
			return false;
		}
		float num3 = BirdCapacity * ConversionRate - FoodStore;
		_fishNeeded = Mathf.FloorToInt(num3 / (float)ConversionRate);
		return true;
	}

	private void TryToQueueFood()
	{
		if (!ShouldRequestIngredients())
		{
			return;
		}
		int num = Mathf.Min(Community.PlayerCommunity.Inventory.ReturnCount(FoodSource), _fishNeeded);
		if (num > 0 && ResourceManager.TryReserveClosestItems(Buildable, FoodSource, num, out var reservedItems))
		{
			if (_fishImportProjectProperties == null)
			{
				Debug.LogError("Fish import project properties are null!");
			}
			_importProject = new Project(_fishImportProjectProperties, base.gameObject, reservedItems);
			Buildable.Community.QueueProject(_importProject);
			_importProject.FinishedEvent.AddListener(OnImportProjectFinished);
			_fishNeeded -= num;
		}
	}

	private void OnImportProjectFinished(Project project, bool success)
	{
		_importProject.FinishedEvent.RemoveListener(OnImportProjectFinished);
		_importProject = null;
		_processIngredients = true;
	}

	private void ProcessIngredients()
	{
		Buildable.Inventory.ReturnAllItems(SubInventoryType.Import, _cachedIngredients);
		foreach (Item cachedIngredient in _cachedIngredients)
		{
			FoodStore += ConversionRate;
			Buildable.Inventory.TakeItem(cachedIngredient);
		}
		_cachedIngredients.Clear();
		UpdateFoodRations();
		_processIngredients = false;
	}

	public void ConsumeFood()
	{
		FoodStore--;
		UpdateFoodRations();
		TryToQueueFood();
	}

	private void UpdateItemsInRadius()
	{
		List<Flotsam> flotsamInWorld = GameManager.WorldManager.FlotsamInWorld;
		int count = flotsamInWorld.Count;
		ItemPropertiesGroup[] itemGroups = _itemGroups;
		for (int i = 0; i < itemGroups.Length; i++)
		{
			itemGroups[i].ClearItems();
		}
		for (int j = 0; j < count; j++)
		{
			PopulateItemLists(flotsamInWorld[j]);
		}
		SalvageableItems.Clear();
		itemGroups = _itemGroups;
		foreach (ItemPropertiesGroup itemPropertiesGroup in itemGroups)
		{
			if (itemPropertiesGroup.Enabled)
			{
				SalvageableItems.AddRange(itemPropertiesGroup.Items);
			}
		}
		if (SalvageableItems.Count == 0)
		{
			Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorNoItemsToSalvageProperties);
		}
		else
		{
			Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorNoItemsToSalvageProperties);
		}
	}

	private void PopulateItemLists(Flotsam flotsam)
	{
		if (!_worldManager.IsInBoatRadius(flotsam.Position))
		{
			return;
		}
		foreach (Item item in flotsam.Inventory.ReturnAllItems())
		{
			ItemPropertiesGroup[] itemGroups = _itemGroups;
			for (int i = 0; i < itemGroups.Length && !itemGroups[i].TryAddItem(item); i++)
			{
			}
		}
	}

	private int ReturnIncomingItems()
	{
		int num = 0;
		foreach (Bird bird in Birds)
		{
			Bird.BirdState state = bird.State;
			if ((uint)(state - 5) <= 1u)
			{
				num++;
			}
		}
		return num;
	}

	private void UpdateBirdFullfillment()
	{
		if (FoodStore < Birds.Count)
		{
			for (int i = 0; i < Birds.Count; i++)
			{
				if (!Birds[i].IsFed)
				{
					Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorSeagullsHungryProperties);
					return;
				}
			}
		}
		Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorSeagullsHungryProperties);
	}

	private void UpdateFoodRations()
	{
		if (FoodRations == null)
		{
			FoodRations = new FoodRation[BirdCapacity];
			for (int i = 0; i < FoodRations.Length; i++)
			{
				FoodRations[i] = new FoodRation(ConversionRate);
			}
		}
		if (Buildable.BuildPhase == BuildPhase.Finished)
		{
			int result;
			int num = Math.DivRem(FoodStore, ConversionRate, out result);
			for (int j = 0; j < FoodRations.Length; j++)
			{
				FoodRation foodRation = FoodRations[j];
				if (j < num)
				{
					foodRation.Count = ConversionRate;
				}
				else if (j == num)
				{
					foodRation.Count = result;
				}
				else
				{
					foodRation.Count = 0;
				}
			}
		}
		else
		{
			FoodRation[] foodRations = FoodRations;
			for (int k = 0; k < foodRations.Length; k++)
			{
				foodRations[k].Count = 0;
			}
		}
		UpdateFoodVisuals();
	}

	private void UpdateFoodVisuals()
	{
		if (_foodRationVisuals == null)
		{
			_foodRationVisuals = new FoodRationVisual[BirdCapacity];
			for (int i = 0; i < BirdCapacity; i++)
			{
				_foodRationVisuals[i] = UnityEngine.Object.Instantiate(_foodRationPrefab, _foodRationPositions[i]);
			}
		}
		for (int j = 0; j < _foodRationVisuals.Length; j++)
		{
			FoodRation foodRation = FoodRations[j];
			if (foodRation != null)
			{
				_foodRationVisuals[j].UpdateVisual(foodRation.Count);
			}
			else
			{
				_foodRationVisuals[j].UpdateVisual(0);
			}
		}
	}

	public void EnableItemExport(bool exportItems)
	{
		ExportItems = exportItems;
		if (ExportItems)
		{
			if (_exportResourceProvider == null)
			{
				_exportResourceProvider = ResourceProvider.Get(Buildable, SubInventoryType.Storage, _haulingAssignmentType);
			}
			_exportResourceProvider.Register();
		}
		else if (!ExportItems && _exportResourceProvider != null)
		{
			_exportResourceProvider.Unregister();
		}
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
		if (Birds.Count > 0)
		{
			return false;
		}
		if (Buildable.Inventory.ReturnCount(SubInventoryType.Storage, includeReserved: true) > 0)
		{
			return false;
		}
		return true;
	}

	public void Shutdown()
	{
		_exportResourceProvider.AddAssignmentType(AssignmentType.Constructing);
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
		UpdateFoodRations();
	}

	public void Deactivate()
	{
		Active = false;
		Buildable.RemoveAllMalfunctions();
		UpdateFoodRations();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new BirdHousePersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		BirdHousePersistentData birdHousePersistentData = persistentData as BirdHousePersistentData;
		ToggleFoodRefilling(birdHousePersistentData.RefillFood);
		if (PersistenceManager.DoesSaveInfoVersionComeBefore(0, 3, 4))
		{
			EnableItemExport(exportItems: true);
		}
		else
		{
			EnableItemExport(birdHousePersistentData.ExportItems);
		}
		State = birdHousePersistentData.State;
		FoodStore = birdHousePersistentData.FoodStore;
		UpdateFoodRations();
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		BirdHousePersistentData birdHousePersistentData = persistentData as BirdHousePersistentData;
		ItemPropertiesGroup[] itemGroups = _itemGroups;
		foreach (ItemPropertiesGroup itemPropertiesGroup in itemGroups)
		{
			itemPropertiesGroup.Enabled = birdHousePersistentData.IsItemGroupEnabled(itemPropertiesGroup);
		}
		if (birdHousePersistentData.ImportProject != null && birdHousePersistentData.ImportProject.TryReturn(out var instance))
		{
			_importProject = instance;
			_importProject.FinishedEvent.AddListener(OnImportProjectFinished);
		}
		for (int j = 0; j < birdHousePersistentData.Birds.Length; j++)
		{
			if (birdHousePersistentData.Birds[j].TryReturn(out var instance2))
			{
				instance2.JoinBirdHouse(this, restored: true);
			}
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		BirdHousePersistentData birdHousePersistentData = persistentData as BirdHousePersistentData;
		birdHousePersistentData.ImportProject = _importProject;
		birdHousePersistentData.Birds = new PersistentReference<Bird>.Reference[Birds.Count];
		for (int i = 0; i < Birds.Count; i++)
		{
			birdHousePersistentData.Birds[i] = Birds[i];
		}
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

	public string ReturnDescription(string text)
	{
		return text;
	}

	private bool ReturnStorageIsFull()
	{
		return Buildable.Inventory.ReturnCapacity() <= Buildable.Inventory.ReturnCount(SubInventoryType.Storage, includeReserved: true) + ReturnIncomingItems();
	}

	public bool HasVacancies()
	{
		if (IsEnabled())
		{
			return Birds.Count < BirdCapacity;
		}
		return false;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
