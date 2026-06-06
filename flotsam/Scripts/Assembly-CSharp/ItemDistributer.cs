using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.Water;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class ItemDistributer : BuildableExtendableBase
{
	public enum Units
	{
		Mililiter = 0,
		Gram = 1
	}

	[Serializable]
	private struct ItemMalfunctions
	{
		public ItemProperties ItemProperties;

		public PlaceableAlertProperties Missing;
	}

	[Serializable]
	public class PersistentData : IBuildableExtendablePersistentData
	{
		private ItemToDistribute.PersistentData[] _itemsToDistribute;

		private PersistentReference<Project>.Reference _importProject;

		[NonSerialized]
		private ItemDistributer _instance;

		public PersistentData(ItemDistributer instance)
		{
			_instance = instance;
			_itemsToDistribute = new ItemToDistribute.PersistentData[instance.ItemsToDistribute.Count];
			for (int i = 0; i < _itemsToDistribute.Length; i++)
			{
				_itemsToDistribute[i] = instance.ItemsToDistribute[i].ReturnPersitentData();
			}
		}

		public void PopulateReferences()
		{
			if (!(_instance == null))
			{
				_importProject = _instance._importProject;
			}
		}

		public void Restore()
		{
		}

		public void RestoreData(Buildable buildable)
		{
			if (!buildable.TryReturnBuildableExtendable<ItemDistributer>(out var buildableExtendable))
			{
				return;
			}
			_instance = buildableExtendable;
			if (_itemsToDistribute.IsNullOrEmpty())
			{
				return;
			}
			ItemToDistribute.PersistentData[] itemsToDistribute = _itemsToDistribute;
			for (int i = 0; i < itemsToDistribute.Length; i++)
			{
				if (itemsToDistribute[i].TryRestore(out var instance, _instance))
				{
					_instance.AddItemToDistribute(instance);
				}
			}
		}

		public void RestoreReferences()
		{
			if (_instance != null && _importProject.TryReturn(out var instance))
			{
				_instance._importProject = instance;
			}
		}
	}

	[SerializeField]
	private int _defaultItemCapacity = 1;

	[SerializeField]
	private int _defaultUnitsPerItem = 1000;

	[Header("Projects")]
	[SerializeField]
	private ProjectProperties _importProjectProperties;

	[SerializeField]
	private AssignmentType _importAssignmentType = AssignmentType.AnimalHandling;

	[SerializeField]
	private PlaceableAlertProperties _itemImportError;

	[Header("Mallfunctions")]
	[SerializeField]
	[NamedArrayElement(new string[] { "ItemProperties" })]
	private ItemMalfunctions[] _itemMallfunctions;

	private Project _importProject;

	private bool _dayEnded;

	private static List<ItemDistributer> _instances = new List<ItemDistributer>();

	public List<ItemToDistribute> ItemsToDistribute { get; } = new List<ItemToDistribute>();

	public int ItemCapacity => _defaultItemCapacity;

	public int UnitsPerItem => _defaultUnitsPerItem;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
		_instances.Add(this);
	}

	private void Update()
	{
		if (!IsEnabled())
		{
			return;
		}
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			item.Update();
		}
	}

	private void LateUpdate()
	{
		if (!IsEnabled())
		{
			return;
		}
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			item.LateUpdate(_dayEnded);
		}
		_dayEnded = false;
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
		_instances.Remove(this);
	}

	private void OnDestroy()
	{
		if ((bool)base.Buildable)
		{
			base.Buildable.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
		}
	}

	public override void Initialize(Buildable buildable, bool restored = false)
	{
		base.Initialize(buildable, restored);
		ItemsToDistribute.Clear();
		buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Import);
		buildable.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
	}

	public override void Activate()
	{
		base.Activate();
		if (_importProject == null)
		{
			_importProject = new Project(_importProjectProperties, base.gameObject);
			_importProject.AddAssignmentType(_importAssignmentType);
			base.Buildable.Community.QueueProject(_importProject);
		}
	}

	public override bool CanBeSalvaged()
	{
		return base.CanBeSalvaged();
	}

	public override void Deactivate()
	{
		base.Deactivate();
		StopImportProject();
	}

	public override void Remove()
	{
		StopImportProject();
	}

	public override void OnDeconstruct()
	{
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			item.DetachAllConsumers();
		}
		ItemsToDistribute.Clear();
	}

	public void AttachConsumer(IItemConsumer consumer)
	{
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			if (item.AttachConsumer(consumer))
			{
				return;
			}
		}
		ItemToDistribute itemToDistribute = new ItemToDistribute(this, consumer.ItemToConsumeProperties);
		itemToDistribute.AttachConsumer(consumer);
		AddItemToDistribute(itemToDistribute);
	}

	public void DetachConsumer(IItemConsumer consumer)
	{
		using List<ItemToDistribute>.Enumerator enumerator = ItemsToDistribute.GetEnumerator();
		while (enumerator.MoveNext() && !enumerator.Current.DetachConsumer(consumer))
		{
		}
	}

	public void ImportItems(List<Item> items)
	{
		if (_importProject != null)
		{
			_importProject.AddItems(items);
		}
		UpdateUnableToImport();
	}

	public void UpdateUnableToImport()
	{
		RemoveAllMalfunctions();
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			if (item.IsUnableToImport)
			{
				AddMalfunction(ReturnItemMissingMalfunction(item));
			}
		}
	}

	private void OnInventoryUpdated()
	{
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			item.OnInventoryUpdated(base.Buildable.Inventory);
		}
	}

	private bool AddItemToDistribute(ItemToDistribute itemToDistributeToAdd)
	{
		foreach (ItemToDistribute item in ItemsToDistribute)
		{
			if (item.ItemProperties == itemToDistributeToAdd.ItemProperties)
			{
				Debug.LogException(new Exception($"Trying to add ItemToDistribute {item.ItemProperties}, but it is already added!"));
				return false;
			}
		}
		ItemsToDistribute.Add(itemToDistributeToAdd);
		return true;
	}

	private void StopImportProject()
	{
		if (_importProject != null)
		{
			_importProject.Stop(ProjectFlags.Cancelled);
			_importProject = null;
		}
	}

	private void OnDayEnded(GameEvent gameEvent)
	{
		_dayEnded = true;
	}

	public bool TryReturnItemToDistribute(ItemProperties itemProperties, out ItemToDistribute itemToDistribute)
	{
		for (int i = 0; i < ItemsToDistribute.Count; i++)
		{
			itemToDistribute = ItemsToDistribute[i];
			if (itemToDistribute.ItemProperties == itemProperties)
			{
				return true;
			}
		}
		itemToDistribute = null;
		return false;
	}

	public int ReturnItemImportCount(ItemProperties itemProperties)
	{
		int num = base.Buildable.Inventory.ReturnCount(itemProperties, SubInventoryType.Import);
		if (_importProject != null)
		{
			num += _importProject.ReturnItemCount(itemProperties);
		}
		return num;
	}

	public void ReturnDailyConsumption(ItemProperties itemProperties, out float dailyConsumption, out int itemCount)
	{
		if (TryReturnItemtoDistribute(out var itemToDistribute, itemProperties))
		{
			dailyConsumption = itemToDistribute.Consumption;
			itemCount = itemToDistribute.ConsumptionItemCount;
		}
		dailyConsumption = 0f;
		itemCount = 0;
	}

	public static float ReturnConsumedToday(ItemProperties itemProperties)
	{
		foreach (ItemDistributer instance in _instances)
		{
			if (instance.TryReturnItemtoDistribute(out var itemToDistribute, itemProperties))
			{
				return itemToDistribute.ConsumedToday;
			}
		}
		return 0f;
	}

	public static int ReturnConsumedTodayItemCount(ItemProperties itemProperties)
	{
		return Mathf.FloorToInt(ReturnConsumedToday(itemProperties));
	}

	private bool TryReturnItemtoDistribute(out ItemToDistribute itemToDistribute, ItemProperties itemProperties)
	{
		int count = ItemsToDistribute.Count;
		while (0 < count--)
		{
			itemToDistribute = ItemsToDistribute[count];
			if (itemToDistribute.ItemProperties == itemProperties)
			{
				return true;
			}
		}
		itemToDistribute = null;
		return false;
	}

	private PlaceableAlertProperties ReturnItemMissingMalfunction(ItemToDistribute itemToDistribute)
	{
		PlaceableAlertProperties placeableAlertProperties = null;
		ItemMalfunctions[] itemMallfunctions = _itemMallfunctions;
		for (int i = 0; i < itemMallfunctions.Length; i++)
		{
			ItemMalfunctions itemMalfunctions = itemMallfunctions[i];
			if (itemMalfunctions.ItemProperties == itemToDistribute.ItemProperties)
			{
				placeableAlertProperties = itemMalfunctions.Missing;
				break;
			}
		}
		if ((bool)placeableAlertProperties)
		{
			return placeableAlertProperties;
		}
		if ((bool)_itemImportError)
		{
			return _itemImportError;
		}
		return GameManager.Settings.BuildableSettings.ErrorItemsMissingProperties;
	}

	public override IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}

	public void RestoreWaterDistributer(WaterDistributer instance, WaterDistributer.PersistentData data)
	{
		if (!TryReturnItemToDistribute(instance.Water, out var itemToDistribute))
		{
			itemToDistribute = new ItemToDistribute(this, instance.Water);
			AddItemToDistribute(itemToDistribute);
		}
		itemToDistribute.Restore(data);
	}
}
