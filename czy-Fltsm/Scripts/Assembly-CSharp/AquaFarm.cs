using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

public class AquaFarm : BuildableExtendableBase, IPersistentReference, IItemProducer
{
	public class Fish : IItemConsumer
	{
		[Serializable]
		public class PersistentData
		{
			private int _fishPropertiesIndex;

			private float _consumed;

			private PersistentReference<Item>.Reference _broodItem;

			public PersistentData(Fish instance)
			{
				_fishPropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(instance.FishProperties);
				_consumed = instance.Consumed;
				_broodItem = instance.BroodItem;
			}

			public bool TryRestore(out Fish fish, AquaFarm aquaFarm, bool isBroodfish)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<FishProperties>(_fishPropertiesIndex, out var reference))
				{
					fish = new Fish(aquaFarm, reference, isBroodfish ? reference.FeedRequirementBrooding : reference.FeedRequirementGrowing);
					fish.Consumed = _consumed;
					fish.Progress = ((fish.Requirement <= 0f) ? 0f : (fish.Consumed / fish.Requirement));
					fish.BroodItem = _broodItem;
					if (1f <= fish.Progress)
					{
						if (isBroodfish)
						{
							fish.ResetBroodCycle();
						}
						else
						{
							aquaFarm.CountCompletedFish(fish);
						}
					}
					return true;
				}
				fish = null;
				return false;
			}
		}

		private AquaFarm _farm;

		private float _consumptionPerSecond;

		public FishProperties FishProperties { get; private set; }

		public ItemProperties ItemToConsumeProperties => FishProperties.FeedItemProperties;

		public float ConsumptionPerDay { get; private set; }

		public float Requirement { get; private set; }

		public float Consumed { get; private set; }

		public float Progress { get; private set; }

		public Item BroodItem { get; private set; }

		public bool Hungry { get; private set; }

		public Fish(AquaFarm farm, FishProperties fishProperties, float feedRequirement)
		{
			FishProperties = fishProperties;
			Requirement = feedRequirement;
			ConsumptionPerDay = ((FishProperties.FeedConsumptionPerDay < feedRequirement) ? FishProperties.FeedConsumptionPerDay : feedRequirement);
			Consumed = 0f;
			Progress = 0f;
			_farm = farm;
			_consumptionPerSecond = fishProperties.FeedConsumptionPerDay / TimeManager.CycleDuration;
		}

		public bool TryReserveBroodItem()
		{
			if (BroodItem == null)
			{
				if (!_farm.Buildable.Community.Inventory.TryReserveItems(FishProperties.BroodItemProperties, 1, out var reservedItems))
				{
					return false;
				}
				BroodItem = reservedItems[0];
				_farm.ItemDistributer.ImportItems(reservedItems);
			}
			return true;
		}

		public void ResetBroodCycle()
		{
			Requirement = FishProperties.FeedRequirementBrooding;
			ConsumptionPerDay = FishProperties.FeedConsumptionPerDay;
			Consumed = 0f;
		}

		public float Consume(float available)
		{
			if (Consumed < Requirement)
			{
				float num = Mathf.Min(_consumptionPerSecond * TimeManager.GetDeltaTime(), available);
				Consumed += num;
				if (Requirement <= Consumed)
				{
					Progress = 1f;
					if (BroodItem == null)
					{
						_farm.ItemDistributer.DetachConsumer(this);
						_farm.OnFishCompleted(this);
					}
					else
					{
						_farm.OnBroodCycleCompleted(this);
						ResetBroodCycle();
					}
				}
				else
				{
					Hungry = available <= 0f;
					Progress = Consumed / Requirement;
				}
				return num;
			}
			return 0f;
		}

		public LocalizedString GetName()
		{
			return FishProperties.HarvestProperties.LocalizedName;
		}

		public Sprite GetIcon()
		{
			return FishProperties.HarvestProperties.InventorySprite;
		}

		public bool IsWatingForBroodItem()
		{
			if (BroodItem != null && !(_farm == null))
			{
				return BroodItem.Inventory != _farm.Buildable.Inventory;
			}
			return true;
		}

		public PersistentData ReturnPersistentData()
		{
			return new PersistentData(this);
		}
	}

	[Serializable]
	public class PersistentData : BuildableExtendablePersistentData<AquaFarm>
	{
		private int _activeFishPropertiesIndex;

		private Fish.PersistentData[] _broodstock;

		private Fish.PersistentData[] _fishes;

		[NonSerialized]
		private AquaFarm _instance;

		public PersistentData(AquaFarm instance)
			: base(instance)
		{
			_instance = instance;
		}

		public override void PopulateReferences()
		{
			if (_instance == null)
			{
				return;
			}
			_activeFishPropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(_instance.ActiveFishProperties);
			if (!_instance.Broodstock.IsNullOrEmpty())
			{
				int count = _instance.Broodstock.Count;
				_broodstock = new Fish.PersistentData[count];
				for (int i = 0; i < count; i++)
				{
					_broodstock[i] = _instance.Broodstock[i].ReturnPersistentData();
				}
			}
			if (!_instance.Fishes.IsNullOrEmpty())
			{
				int count2 = _instance.Fishes.Count;
				_fishes = new Fish.PersistentData[count2];
				for (int i = 0; i < count2; i++)
				{
					_fishes[i] = _instance.Fishes[i].ReturnPersistentData();
				}
			}
		}

		public override void RestoreData(Buildable buildable)
		{
			buildable.TryReturnBuildableExtendable<AquaFarm>(out _instance);
		}

		public override void RestoreReferences()
		{
			if (_instance == null)
			{
				return;
			}
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<FishProperties>(_activeFishPropertiesIndex, out var reference))
			{
				_instance.ActiveFishProperties = reference;
			}
			if (!_broodstock.IsNullOrEmpty())
			{
				for (int i = 0; i < _broodstock.Length; i++)
				{
					if (_instance.Broodstock.Count < _instance.Broodstock.Capacity && _broodstock[i].TryRestore(out var fish, _instance, isBroodfish: true))
					{
						_instance.AddBroodFish(fish);
						if (fish.BroodItem != null && fish.BroodItem.Inventory == _instance.Buildable.Inventory)
						{
							_instance.ItemDistributer.AttachConsumer(fish);
						}
					}
				}
			}
			if (_fishes.IsNullOrEmpty())
			{
				return;
			}
			Fish.PersistentData[] fishes = _fishes;
			for (int j = 0; j < fishes.Length; j++)
			{
				if (fishes[j].TryRestore(out var fish2, _instance, isBroodfish: false))
				{
					_instance.Fishes.Add(fish2);
					if (fish2.Progress < 1f)
					{
						_instance.ItemDistributer.AttachConsumer(fish2);
					}
				}
			}
		}
	}

	[Serializable]
	public struct FishPersistentData
	{
		public int PropertiesIndex;

		public float[] Consumed;
	}

	[SerializeField]
	private FishProperties[] _availableFishes;

	[SerializeField]
	private ItemDistributer _itemDistributer;

	[SerializeField]
	private int _broodstockCapacity = 10;

	[SerializeField]
	private int _exportCapacity = 100;

	[Header("Malfunctions")]
	[SerializeField]
	private PlaceableAlertProperties _broodstockItemMissing;

	private List<ItemProperties> _broodStockPropertiesList;

	private List<Item> _itemList = new List<Item>();

	private List<CountedItemProperty> _itemsWaitingForExport = new List<CountedItemProperty>();

	private bool _updated;

	public UnityEvent UpdatedEvent { get; private set; } = new UnityEvent();

	public FishProperties[] AvailableFishProperties => _availableFishes;

	public ItemDistributer ItemDistributer => _itemDistributer;

	public FishProperties ActiveFishProperties { get; private set; }

	public List<Fish> Broodstock { get; private set; }

	public List<Fish> Fishes { get; private set; }

	public int FishCountMaximum => _broodstockCapacity;

	public List<ItemProperties> ProducedItems { get; private set; } = new List<ItemProperties>();

	public ResourceProvider ExportResourceProvider { get; private set; }

	public int PersistentIndex { get; set; }

	private void LateUpdate()
	{
		bool flag = false;
		foreach (Fish item in Broodstock)
		{
			if (!item.TryReserveBroodItem())
			{
				flag = true;
			}
		}
		if (flag)
		{
			AddMalfunction(_broodstockItemMissing ? _broodstockItemMissing : GameManager.Settings.BuildableSettings.ErrorItemsMissingProperties);
		}
		else
		{
			RemoveMalfunction(_broodstockItemMissing ? _broodstockItemMissing : GameManager.Settings.BuildableSettings.ErrorItemsMissingProperties);
		}
		if (_updated)
		{
			_updated = false;
			UpdatedEvent.Invoke();
		}
	}

	public override void Initialize(Buildable buildable, bool restored = false)
	{
		base.Initialize(buildable, restored);
		ActiveFishProperties = _availableFishes[0];
		Broodstock = new List<Fish>(_broodstockCapacity);
		Fishes = new List<Fish>();
		base.Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Storage);
		base.Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Export, _exportCapacity);
		ExportResourceProvider = ResourceProvider.Get(base.Buildable, SubInventoryType.Export, GameManager.ResourceManager, AssignmentType.AnimalHandling);
		ExportResourceProvider.Register();
		base.Buildable.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
		if (_broodStockPropertiesList == null)
		{
			_broodStockPropertiesList = new List<ItemProperties>();
		}
		else
		{
			_broodStockPropertiesList.Clear();
		}
		FishProperties[] availableFishes = _availableFishes;
		foreach (FishProperties fishProperties in availableFishes)
		{
			_broodStockPropertiesList.Add(fishProperties.BroodItemProperties);
		}
		GameEventDispatcher.AddListener(GameEventType.ItemResourceLimitUpdated, OnItemResourceLimitUpdated);
	}

	public override void Remove()
	{
		base.Remove();
		ExportResourceProvider.Unregister();
		base.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.ItemResourceLimitUpdated, OnItemResourceLimitUpdated);
	}

	public void SetActiveFishProperties(FishProperties fishProperties)
	{
		ActiveFishProperties = fishProperties;
		_updated = true;
	}

	public bool AddBroodFish()
	{
		if (Broodstock.Count < Broodstock.Capacity)
		{
			Fish fish = new Fish(this, ActiveFishProperties, ActiveFishProperties.FeedRequirementBrooding);
			fish.ResetBroodCycle();
			AddBroodFish(fish);
			_updated = true;
			return true;
		}
		Debug.LogFormat("Unable to add broodfish '{0}'!", ActiveFishProperties.BroodItemProperties);
		return false;
	}

	private void AddBroodFish(Fish broodfish)
	{
		Broodstock.Add(broodfish);
		if (ProducedItems.AddUnique(ActiveFishProperties.HarvestProperties))
		{
			GameManager.ResourceManager.AddProductionLimits(this);
		}
	}

	public void RemoveBroodFish()
	{
		int count = Broodstock.Count;
		while (0 < count--)
		{
			Fish fish = Broodstock[count];
			if (fish.FishProperties == ActiveFishProperties)
			{
				Broodstock.RemoveAt(count);
				_itemDistributer.DetachConsumer(fish);
				_updated = true;
				break;
			}
		}
	}

	private void OnBroodCycleCompleted(Fish broodfish)
	{
		for (int i = 0; i < broodfish.FishProperties.OffspringMaximum; i++)
		{
			Fish fish = new Fish(this, broodfish.FishProperties, broodfish.FishProperties.FeedRequirementGrowing);
			Fishes.Add(fish);
			_itemDistributer.AttachConsumer(fish);
		}
		_updated = true;
	}

	private void OnFishCompleted(Fish fish)
	{
		_itemDistributer.DetachConsumer(fish);
		base.Buildable.Inventory.AddItem(new Item(fish.FishProperties.HarvestProperties), SubInventoryType.Export);
		ItemEvent.Dispatch(GameEventType.ItemFarmed, fish.FishProperties.HarvestProperties);
		CountCompletedFish(fish);
	}

	private void CountCompletedFish(Fish fish)
	{
		_updated = true;
		foreach (CountedItemProperty item in _itemsWaitingForExport)
		{
			if (item.ItemProperties == fish.FishProperties.HarvestProperties)
			{
				item.Amount++;
				return;
			}
		}
		_itemsWaitingForExport.Add(new CountedItemProperty(fish.FishProperties.HarvestProperties, 1));
	}

	private void OnInventoryUpdated()
	{
		_itemList.Clear();
		base.Buildable.Inventory.ReturnAllItems(SubInventoryType.Import, _itemList);
		foreach (Item item in _itemList)
		{
			TrySetBroodItem(item);
		}
		foreach (CountedItemProperty item2 in _itemsWaitingForExport)
		{
			int num = base.Buildable.Inventory.ReturnCount(item2.ItemProperties, SubInventoryType.Export, includeReserved: true);
			int num2 = item2.Amount - num;
			while (0 < num2--)
			{
				foreach (Fish fish in Fishes)
				{
					if (1f <= fish.Progress && fish.FishProperties.HarvestProperties == item2.ItemProperties)
					{
						Fishes.Remove(fish);
						_updated = true;
						break;
					}
				}
			}
			item2.Amount = num;
		}
	}

	private void TrySetBroodItem(Item item)
	{
		foreach (Fish item2 in Broodstock)
		{
			if (item2.BroodItem == item)
			{
				if (!GameManager.ResourceManager.IsProductionLimitReached(item2.FishProperties.HarvestProperties))
				{
					_itemDistributer.AttachConsumer(item2);
				}
				base.Buildable.Inventory.MoveToSubInventory(item, SubInventoryType.Storage);
				_updated = true;
				break;
			}
		}
	}

	private void AttachFishes(List<Fish> fishes, FishProperties fishProperties)
	{
		foreach (Fish fish in fishes)
		{
			if (fish.Progress < 1f && fish.FishProperties == fishProperties)
			{
				_itemDistributer.AttachConsumer(fish);
			}
		}
	}

	private void DetachFishes(List<Fish> fishes, FishProperties fishProperties)
	{
		foreach (Fish fish in fishes)
		{
			if (fish.FishProperties == fishProperties)
			{
				_itemDistributer.DetachConsumer(fish);
			}
		}
	}

	int IItemProducer.GetItemsInProductionCount(ItemProperties itemProperties)
	{
		int num = 0;
		foreach (Fish fish in Fishes)
		{
			if (fish.FishProperties.HarvestProperties == itemProperties)
			{
				num++;
			}
		}
		return num;
	}

	public void ReturnDailyConsumption(out float dailyConsumption, out int itemCount)
	{
		_itemDistributer.ReturnDailyConsumption(ActiveFishProperties.FeedItemProperties, out dailyConsumption, out itemCount);
	}

	public int ReturnBroodstockCount(FishProperties fishProperties)
	{
		return ReturnFishCount(Broodstock, fishProperties);
	}

	public int ReturnConsumingBroodstockCount(FishProperties fishProperties)
	{
		return ReturnConsumingFishCount(Broodstock, fishProperties);
	}

	public int ReturnFishCount(FishProperties fishProperties)
	{
		return ReturnFishCount(Fishes, fishProperties);
	}

	public int ReturnConsumingFishCount(FishProperties fishProperties)
	{
		return ReturnConsumingFishCount(Fishes, fishProperties);
	}

	private int ReturnFishCount(List<Fish> fishes, FishProperties fishProperties)
	{
		int num = 0;
		foreach (Fish fish in fishes)
		{
			if (fish.FishProperties == fishProperties)
			{
				num++;
			}
		}
		return num;
	}

	private int ReturnConsumingFishCount(List<Fish> fishes, FishProperties fishProperties)
	{
		int num = 0;
		foreach (Fish fish in fishes)
		{
			if (fish.FishProperties == fishProperties && fish.Progress < 1f)
			{
				num++;
			}
		}
		return num;
	}

	private void OnItemResourceLimitUpdated(GameEvent gameEvent)
	{
		if (!(gameEvent is ItemEvent itemEvent) || !ProducedItems.Contains(itemEvent.ItemProperties))
		{
			return;
		}
		ResourceManager resourceManager = GameManager.ResourceManager;
		FishProperties[] availableFishes = _availableFishes;
		foreach (FishProperties fishProperties in availableFishes)
		{
			if (!resourceManager.IsProductionLimitReached(fishProperties.HarvestProperties))
			{
				AttachFishes(Broodstock, fishProperties);
			}
		}
	}

	public override IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}
}
