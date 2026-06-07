using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Inventory : InventoryBase, ICommunalInventory, IPathfindingNodeProvider
{
	[Tooltip("The type of the inventory.")]
	public InventoryType InventoryType;

	[Space]
	[Tooltip("Maximum amount of slots (capacity) of this inventory's storage inventory.")]
	[SerializeField]
	[ConditionalEnumHide("InventoryType", 5, false, HideInInspector = false, Inverse = true)]
	[FormerlySerializedAs("Capacity")]
	public int StorageCapacity;

	[Tooltip("Maximum amount of slots (capacity) of this inventory's liquid inventory.")]
	[ConditionalEnumHide("InventoryType", 5, false, HideInInspector = true, Inverse = true)]
	public int LiquidCapacity;

	[Tooltip("Maximum amount of slots(capacity) of this inventory's export inventory.")]
	[SerializeField]
	[ConditionalEnumHide("InventoryType", 5, 6, false, HideInInspector = false)]
	public int ExportCapacity;

	[Space]
	[SerializeField]
	private List<DropOffPoint> _dropOffPoints = new List<DropOffPoint>();

	[Header("Transfers")]
	public int TransferAnimationCycles = 1;

	public Activity Pickup = Activity.ItemTaking;

	public Activity Dropoff = Activity.ItemDropping;

	private bool _initialized;

	private Dictionary<SubInventoryType, SubInventory> _subInventories = new Dictionary<SubInventoryType, SubInventory>();

	private SubInventory _storage;

	private SubInventory _liquid;

	private SubInventory _export;

	private CompositionInventory _composition;

	private bool _invokeInventoryUpdatedEvent;

	private bool _invokeCompositionUpdatedEvent;

	private Target _target;

	private static InventoryAuditor _counter;

	private static SubInventoryType[] _subInventoryTypes;

	public Storage Storage { get; private set; }

	public override InventoryType Type => InventoryType;

	public override Target Target
	{
		get
		{
			if (_target == null)
			{
				_target = GetComponentInChildren<Target>();
			}
			return _target;
		}
	}

	public override Activity PickupActivity => Pickup;

	public override Activity DropoffActivity => Dropoff;

	public override int AnimationCycles => TransferAnimationCycles;

	public float Weight { get; private set; }

	public IEnumerable<SubInventoryType> SubInventoryTypes => _subInventories.Keys;

	public static InventoryAuditor Auditor
	{
		get
		{
			if (_counter == null)
			{
				_counter = new InventoryAuditor();
			}
			return _counter;
		}
	}

	public UnityEvent InventoryUpdatedEvent { get; private set; }

	public UnityEvent<Item> ItemTakenEvent { get; private set; }

	Transform IPathfindingNodeProvider.transform => base.transform;

	public event UnityAction<float> CompositionUpdatedEvent;

	public void OnInventoryUpdated()
	{
		_invokeInventoryUpdatedEvent = true;
	}

	public void OnCompositionUpdated(float progress)
	{
		_invokeCompositionUpdatedEvent = true;
	}

	public void Initialize(InventoryType inventoryType)
	{
		if (!_initialized)
		{
			InventoryType = inventoryType;
			InventoryUpdatedEvent = new UnityEvent();
			ItemTakenEvent = new UnityEvent<Item>();
			_invokeInventoryUpdatedEvent = false;
			_invokeCompositionUpdatedEvent = false;
			_initialized = true;
		}
	}

	public void Initialize(Storage storage)
	{
		if (_initialized)
		{
			InventoryType = InventoryType.Storage;
		}
		else
		{
			Initialize(InventoryType.Storage);
		}
		Storage = storage;
	}

	private void LateUpdate()
	{
		if (_invokeInventoryUpdatedEvent && InventoryUpdatedEvent != null)
		{
			InventoryUpdatedEvent.Invoke();
			Weight = ReturnWeight();
		}
		if (_invokeCompositionUpdatedEvent && this.CompositionUpdatedEvent != null)
		{
			CallCompositionUpdatedEvent();
		}
		_invokeInventoryUpdatedEvent = false;
		_invokeCompositionUpdatedEvent = false;
	}

	public void Destroy()
	{
		Clear();
	}

	public void OnDestroy()
	{
		if (_composition != null)
		{
			_composition.UpdatedEvent -= OnCompositionUpdated;
		}
		Destroy();
	}

	public SubInventory GetOrAddSubInventory(SubInventoryType subInventoryType, int capacity = int.MaxValue)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return value;
		}
		value = new SubInventory(subInventoryType, capacity);
		AddSubInventory(value);
		return value;
	}

	private void AddSubInventory(SubInventory subInventory)
	{
		if (_subInventories.ContainsKey(subInventory.Type))
		{
			Debug.LogException(new Exception($"trying to add subInventory of type '{subInventory.Type}' to '{base.name}' its inventory, but it already has a subInventory of this type"));
			return;
		}
		_subInventories.Add(subInventory.Type, subInventory);
		switch (subInventory.Type)
		{
		case SubInventoryType.Storage:
			_storage = subInventory;
			_storage.OnSlotReservationUpdated.AddListener(OnSubInventorySlotReservationUpdated);
			break;
		case SubInventoryType.Liquid:
			_liquid = subInventory;
			break;
		case SubInventoryType.Export:
			_export = subInventory;
			break;
		}
	}

	public void MoveToSubInventory(Item item, SubInventoryType subInventory)
	{
		Item item2 = TakeItem(item);
		if (item2 != null)
		{
			AddItem(item2, subInventory);
		}
	}

	public Item PeekAtFirstItem(SubInventoryType subInventory)
	{
		return ReturnInventory(subInventory).PeekAtFirstItem();
	}

	public override Item TakeItem(Item item)
	{
		Item item2 = ReturnInventory(item.SubInventory).TakeItem(item);
		if (item2 == item)
		{
			OnInventoryUpdated();
			UnityEvent<Item> itemTakenEvent = ItemTakenEvent;
			if (itemTakenEvent == null)
			{
				return item2;
			}
			itemTakenEvent.Invoke(item);
		}
		return item2;
	}

	public override bool AddItem(Item item, SubInventoryType subInventory)
	{
		return AddItem(item, ReturnInventory(subInventory));
	}

	protected virtual bool AddItem(Item item, SubInventory subInventory)
	{
		if (subInventory.Type == SubInventoryType.Storage || subInventory.Type == SubInventoryType.Liquid)
		{
			subInventory = ReturnSubInventory(item.Properties.Tags, subInventory);
			if (!subInventory.IncomingItems.Contains(item) && !ReturnAcceptsItem(item.Properties))
			{
				if (ReturnAvailableSubInventoryCapacity(subInventory) == 0)
				{
					Debugger.Error("Unable to add item " + item?.ToString() + " to " + subInventory.Type.ToString() + ". No capacity available and no capacity was reserved!");
				}
				return false;
			}
		}
		if (subInventory.AddItem(item))
		{
			item.SetInventory(this, subInventory.Type);
			if (subInventory.RemoveIncomingItem(item))
			{
				item.MoveToInventory = null;
			}
			if (subInventory.Type == SubInventoryType.Storage || subInventory.Type == SubInventoryType.Liquid)
			{
				Community.PlayerCommunity.AddFoundItem(item.Properties);
			}
			OnInventoryUpdated();
			return true;
		}
		return false;
	}

	public void AddItems(List<Item> items, SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Composition)
		{
			throw new NotImplementedException();
		}
		int count = items.Count;
		SubInventory subInventory = ReturnInventory(subInventoryType);
		for (int i = 0; i < count; i++)
		{
			AddItem(items[i], subInventory);
		}
	}

	public bool ExportItem(Item item)
	{
		if (_export == null)
		{
			return false;
		}
		if (item.Inventory == null)
		{
			_export.AddItemIgnoreCapacity(item);
			return true;
		}
		if (item.Inventory != this)
		{
			return false;
		}
		switch (item.SubInventory)
		{
		case SubInventoryType.Export:
			return true;
		default:
			Debug.LogErrorFormat("There is currently no behaviour implemented to export items stored in the '{0}' subinventory", item.SubInventory);
			return false;
		case SubInventoryType.Import:
			if (TakeItem(item) == item)
			{
				_export.AddItemIgnoreCapacity(item);
				item.SetInventory(this, SubInventoryType.Export);
				return true;
			}
			Debug.LogErrorFormat("Unable to take item '{0}' form '{1}' its '{2}' subinventory", item.Properties.name, base.name, item.SubInventory);
			return false;
		}
	}

	public void ExportItems(IEnumerable<Item> items)
	{
		foreach (Item item in items)
		{
			ExportItem(item);
		}
	}

	public bool ReserveIncomingItem(Item item, SubInventoryType type)
	{
		return ReserveIncomingItem(item, restore: false, type);
	}

	public bool RestoreIncomingItem(Item item, SubInventoryType type)
	{
		return ReserveIncomingItem(item, restore: true, type);
	}

	private bool ReserveIncomingItem(Item item, bool restore, SubInventoryType subInventoryType)
	{
		if ((bool)item.MoveToInventory)
		{
			Debug.LogWarningFormat("Trying to reserve inventory space for '{0}' which already has MoveToInventory assigned with '{1}'", item.Properties.name, item.MoveToInventory.name);
			return true;
		}
		if (item.Inventory == this && item.SubInventory == subInventoryType)
		{
			return false;
		}
		if (subInventoryType != SubInventoryType.Storage && subInventoryType != SubInventoryType.Composition && subInventoryType != SubInventoryType.Liquid)
		{
			Debug.LogError($"Reserving incomings for subinventory '{subInventoryType}' is currently not supported!");
			return false;
		}
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			int num = value.AvailableCapacity - value.IncomingItems.Count;
			if ((restore || item.IsQuestItem || (0 < num && ReturnAcceptsItem(item.Properties))) && value.AddIncomingItem(item))
			{
				item.MoveToInventory = this;
				OnInventoryUpdated();
				return true;
			}
		}
		else
		{
			Debug.LogException(new Exception($"Unable to reserve incomings for '{this}->{subInventoryType}', it has not been added"));
		}
		return false;
	}

	public bool UnreserveIncomingItem(Item item)
	{
		foreach (SubInventory value in _subInventories.Values)
		{
			if (value.RemoveIncomingItem(item))
			{
				item.MoveToInventory = null;
				OnInventoryUpdated();
				return true;
			}
		}
		return false;
	}

	public bool TryGetIncomingItemReservedSubInventoryType(out SubInventoryType subInventoryType, Item item)
	{
		foreach (SubInventory value in _subInventories.Values)
		{
			if (value.HasIncomingItem(item))
			{
				subInventoryType = value.Type;
				return true;
			}
		}
		subInventoryType = SubInventoryType.Storage;
		return false;
	}

	public bool HasIncomingItems(SubInventoryType subInventoryType)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return !value.IncomingItems.IsNullOrEmpty();
		}
		return false;
	}

	public void CallCompositionUpdatedEvent()
	{
		this.CompositionUpdatedEvent(_composition.ReturnProgress());
	}

	public void Count(InventoryAuditor counter, SubInventoryType subInventoryType)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			counter.CountInventory(value);
		}
	}

	public bool FitsInInventory(Item item, SubInventoryType subInventory = SubInventoryType.Storage)
	{
		if (!(item.MoveToInventory == this))
		{
			if (ReturnAcceptsItem(item.Properties))
			{
				return ReturnSubInventory(item.Properties.Tags, ReturnInventory(subInventory)).ReturnHasCapacity();
			}
			return false;
		}
		return true;
	}

	public bool FitsInInventory(IReadOnlyList<CountedItemProperty> countedItemProperties, SubInventoryType subInventoryType = SubInventoryType.Storage)
	{
		for (int i = 0; i < countedItemProperties.Count; i++)
		{
			if (subInventoryType == SubInventoryType.Storage && !ReturnAcceptsItem(countedItemProperties[i].ItemProperties))
			{
				return false;
			}
			if (!ReturnSubInventory(countedItemProperties[i].ItemProperties.Tags, ReturnInventory(subInventoryType)).CanAddCountedItemProperties(countedItemProperties[i]))
			{
				return false;
			}
		}
		return true;
	}

	public bool HasItems(SubInventoryType subInventory, bool includeReserved = false)
	{
		return ReturnCount(subInventory, includeReserved) > 0;
	}

	public void InitializeComposition(IEnumerable<CountedItemProperty> countedItems)
	{
		InitializeComposition(new CompositionInventory(countedItems));
	}

	public void InitializeComposition(List<Item> items)
	{
		InitializeComposition(new CompositionInventory(items));
	}

	private void InitializeComposition(CompositionInventory compositionInventory)
	{
		if (_composition != null)
		{
			return;
		}
		_composition = compositionInventory;
		_composition.UpdatedEvent += OnCompositionUpdated;
		foreach (Item item in _composition.ReturnAllItems())
		{
			item.SetInventory(this, SubInventoryType.Composition);
		}
		_subInventories.Add(SubInventoryType.Composition, compositionInventory);
	}

	public void FillComposition(CountedItemProperty[] countedItems = null)
	{
		if (countedItems == null)
		{
			_composition.Fill(this);
		}
		else
		{
			_composition.Fill(this, countedItems);
		}
		if (this.CompositionUpdatedEvent != null)
		{
			this.CompositionUpdatedEvent(_composition.ReturnProgress());
		}
	}

	private void OnSubInventorySlotReservationUpdated(SubInventory inventory)
	{
		OnInventoryUpdated();
	}

	public void Clear(SubInventoryType subInventory)
	{
		ReturnInventory(subInventory).Clear();
	}

	public void Clear()
	{
		if (_storage != null)
		{
			_storage.Clear();
			_storage.OnSlotReservationUpdated.RemoveListener(OnSubInventorySlotReservationUpdated);
		}
		if (_composition != null)
		{
			_composition.Clear();
		}
		foreach (SubInventory value in _subInventories.Values)
		{
			value.Clear();
		}
		_subInventories.Clear();
	}

	public bool HasSubInventory(SubInventoryType subInventoryType)
	{
		return _subInventories.ContainsKey(subInventoryType);
	}

	private SubInventory ReturnSubInventory(Item.Tags tags, SubInventory subInventory)
	{
		if ((tags & Item.Tags.Liquid) != Item.Tags.None && subInventory.Type == SubInventoryType.Storage && InventoryType == InventoryType.Storage)
		{
			return _liquid;
		}
		return subInventory;
	}

	public bool ReturnAcceptsTag(Item.Tags tag)
	{
		if (!(Storage == null))
		{
			return Storage.AcceptsTags(tag);
		}
		return true;
	}

	public bool ReturnAcceptsItem(ItemProperties item)
	{
		if (!(Storage == null))
		{
			return Storage.AcceptsItem(item);
		}
		return true;
	}

	public int ReturnCapacity(SubInventoryType inventoryType = SubInventoryType.Storage)
	{
		return ReturnInventory(inventoryType).Capacity;
	}

	public int ReturnCapacity(Item.Tags tag)
	{
		if (!(Storage != null))
		{
			return 0;
		}
		return Storage.ReturnCapacity(tag);
	}

	public int ReturnCount(SubInventoryType inventoryType = SubInventoryType.Storage, bool includeReserved = false)
	{
		if (_subInventories.TryGetValue(inventoryType, out var value))
		{
			return value.ReturnItemCount(includeReserved);
		}
		Debug.LogException(new Exception($"Unable to return count of subInventory '{inventoryType}' of inventory '{base.name}'"));
		return 0;
	}

	public int ReturnCount(Item.Tags tag, bool includeReserved = false)
	{
		if (!(Storage != null))
		{
			return 0;
		}
		return Storage.ReturnCount(tag, includeReserved);
	}

	public float ReturnFilledPercentage(SubInventoryType subInventory = SubInventoryType.Storage, bool includeReserved = false)
	{
		return (float)ReturnCount(subInventory, includeReserved) / (float)ReturnCapacity(subInventory);
	}

	public bool ReturnIsEmpty(SubInventoryType subInventory = SubInventoryType.Storage)
	{
		return ReturnInventory(subInventory).IsEmpty;
	}

	public bool ReturnIsFull(SubInventoryType inventoryType = SubInventoryType.Storage)
	{
		return !ReturnInventory(inventoryType).HasCapacity;
	}

	public List<Item> ReturnAllItems(SubInventoryType subInventoryType, List<Item> listToPopulate = null, bool includeReserved = true)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return value.ReturnAllItems(listToPopulate, includeReserved);
		}
		Debug.LogException(new Exception($"Unable to ReturnAllItems for '{this}->{subInventoryType}'"));
		return listToPopulate;
	}

	public int ReturnCount(ItemProperties itemProperties, SubInventoryType inventoryType, bool includeReserved = false)
	{
		return ReturnSubInventory(itemProperties.Tags, ReturnInventory(inventoryType)).ReturnItemCount(itemProperties, includeReserved);
	}

	public Item ReturnItem(ItemProperties itemProperties, SubInventoryType subInventory)
	{
		OnInventoryUpdated();
		return ReturnInventory(subInventory).ReturnItemFromProperties(itemProperties);
	}

	public Item RemoveItem(ItemProperties itemProperties, SubInventoryType subInventory)
	{
		OnInventoryUpdated();
		return ReturnInventory(subInventory).TakeItem(itemProperties);
	}

	public bool TryReturnItemContainingTag(Item.Tags tag, out Item item)
	{
		if ((tag & Item.Tags.Liquid) == 0)
		{
			return _storage.TryReturnItemContainingTag(tag, out item);
		}
		return _liquid.TryReturnItemContainingTag(tag, out item);
	}

	public bool TryReturnItem(ItemProperties itemProperties, out Item item)
	{
		if ((itemProperties.Tags & Item.Tags.Liquid) == 0)
		{
			return _storage.TryReturnItem(itemProperties, out item);
		}
		return _liquid.TryReturnItem(itemProperties, out item);
	}

	public List<Item> SelectUntilFull(List<Item> itemsToSelectFrom, bool reservePlayerCommunity, bool simulateEmpty = false)
	{
		List<Item> list = new List<Item>();
		int count = itemsToSelectFrom.Count;
		int num = (simulateEmpty ? _storage.Capacity : _storage.AvailableCapacity);
		for (int i = 0; i < count; i++)
		{
			Item item = itemsToSelectFrom[i];
			if (item.Inventory == this)
			{
				if (!reservePlayerCommunity || Community.PlayerCommunity.ReserveIncomingItems(item, SubInventoryType.Storage))
				{
					list.Add(item);
					if (simulateEmpty)
					{
						num--;
					}
				}
			}
			else if (0 < num && (!reservePlayerCommunity || Community.PlayerCommunity.ReserveIncomingItems(item, SubInventoryType.Storage)))
			{
				list.Add(item);
				num--;
			}
		}
		return list;
	}

	public bool ReturnCompositionHasItemMatchingTags(Item.Tags tags)
	{
		return 0 < _composition.ReturnItemMatchingTagsCount(tags);
	}

	public float ReturnCompositionProgress()
	{
		return _composition.ReturnProgress();
	}

	public float ReturnWeight(SubInventoryType type)
	{
		if (_subInventories.TryGetValue(type, out var value))
		{
			return value.Weight;
		}
		return 0f;
	}

	private float ReturnWeight()
	{
		float num = 0f;
		foreach (SubInventory value in _subInventories.Values)
		{
			num += value.ReturnWeight();
		}
		return num;
	}

	public int ReturnItemContainingTagCount(Item.Tags tag, SubInventoryType subInventory)
	{
		return ReturnInventory(subInventory).ReturnItemContainingTagCount(tag);
	}

	public int ReturnItemMatchingTagsCount(Item.Tags tags, SubInventoryType subInventory)
	{
		return ReturnInventory(subInventory).ReturnItemMatchingTagsCount(tags);
	}

	public InventoryAuditor ReturnInventoryCount(SubInventoryType subInventoryToAudit = SubInventoryType.Storage)
	{
		InventoryAuditor auditor = Auditor;
		auditor.Reset();
		Count(auditor, subInventoryToAudit);
		return auditor;
	}

	public SubInventory ReturnInventory(SubInventoryType subInventoryType)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return value;
		}
		Debug.LogException(new Exception($"'{base.name}' does not have an inventory of type: {subInventoryType}"));
		return null;
	}

	public int ReturnStorageCapacity()
	{
		return _storage.Capacity;
	}

	public int ReturnAvailableStorageCapacity()
	{
		return ReturnAvailableSubInventoryCapacity(_storage);
	}

	public int ReturnAvailableSubInventoryCapacity(SubInventory subInventory)
	{
		return subInventory.AvailableCapacity - subInventory.IncomingItems.Count;
	}

	public Transform ReturnDropOffTarget(SubInventoryType subInventoryType)
	{
		Transform target = _dropOffPoints.Find((DropOffPoint point) => point.Type == subInventoryType).Target;
		if (!(target == null))
		{
			return target;
		}
		return base.transform;
	}

	public SubInventoryType ReturnCorrectItemSubInventory(Item item, SubInventoryType subInventory)
	{
		if (InventoryType == InventoryType.Storage && subInventory == SubInventoryType.Storage && item.ContainsTagSet(Item.Tags.Liquid))
		{
			return SubInventoryType.Liquid;
		}
		return subInventory;
	}

	public bool ReturnContainsItems(IEnumerable<CountedItemProperty> items, SubInventoryType subInventory = SubInventoryType.Storage)
	{
		return ReturnInventory(subInventory).ReturnContainsItems(items);
	}

	public bool ReturnContainsItem(ItemProperties itemProperties, int amount = 1, SubInventoryType subInventory = SubInventoryType.Storage)
	{
		return ReturnInventory(subInventory).ReturnContainsItems(itemProperties, amount);
	}

	public int ReturnIncomingItemsAmount(SubInventoryType subInventoryType)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return value.IncomingItems.Count;
		}
		Debug.LogException(new Exception($"Unable to return incoming item amount for '{this}->{subInventoryType}'."));
		return 0;
	}

	public int ReturnIncomingItemsAmount(Item.Tags tags)
	{
		if (!(Storage != null))
		{
			return 0;
		}
		return Storage.ReturnIncomingItemCount(tags);
	}

	public List<Item> ReturnIncomingItems(SubInventoryType subInventoryType)
	{
		if (_subInventories.TryGetValue(subInventoryType, out var value))
		{
			return value.IncomingItems;
		}
		Debug.LogException(new Exception($"Unable to return incoming items for SubInventoryType.{subInventoryType}"));
		return null;
	}

	public bool TryReturnFirstAvailableItem(SubInventoryType subInventory, out Item item, IInventorySpaceLimiter limiter = null)
	{
		return ReturnInventory(subInventory).ReturnFirstAvailableItem(subInventory, out item, limiter);
	}

	public PathfindingNode ReturnPathfindingNode(Navigator navigator = null)
	{
		InventoryType type = Type;
		if ((uint)(type - 3) > 1u && type != InventoryType.Decoration)
		{
			Debug.LogError("Inventory.ReturnPathfindingNode not implemented for InventoryType: " + Type);
			return null;
		}
		if ((bool)Target)
		{
			if ((bool)Target.PrimaryMarker && Target.PrimaryMarker.Node != null)
			{
				return Target.PrimaryMarker.Node;
			}
			return Target.ReturnNode(Graph.Type.Constructions);
		}
		return null;
	}
}
