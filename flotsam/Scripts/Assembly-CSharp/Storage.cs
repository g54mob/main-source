using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Construction))]
public class Storage : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	[Tooltip("Filter to check which items this storage can hold.")]
	[EnumFlag(1)]
	[SerializeField]
	[FormerlySerializedAs("Filter")]
	public Item.Tags _filter;

	[SerializeField]
	private bool _isGeneralStorage = true;

	[SerializeField]
	private int _capacity;

	[SerializeField]
	[Tooltip("The priority of the Storage. This is currently only used by the school, because the school only stores 1 item, books. If this should be expanded the priority should be set per item.")]
	private int _priority;

	[SerializeField]
	private bool _hideInventoryView;

	[SerializeField]
	private bool _hideFilterPanel;

	[FormerlySerializedAs("StorageSlots")]
	[SerializeField]
	private InventorySlots _storageSlots;

	private SubInventory _storageInventory;

	private StorageResourceProvider _resourceProvider;

	private ResourceProvider _shutDownResourceProvider;

	public Buildable Buildable { get; private set; }

	public BuildPhase BuildPhase => Buildable.BuildPhase;

	public Inventory Inventory { get; private set; }

	public ItemFilter Filter { get; private set; }

	public Item.Tags FilterTags => _filter;

	public bool Active { get; private set; }

	public int Priority => _priority;

	public bool ShowInventoryView => !_hideInventoryView;

	public bool ShowFilterPanel
	{
		get
		{
			if (!_hideFilterPanel)
			{
				return Filter.ShowFilterPanel;
			}
			return false;
		}
	}

	public int PersistentIndex { get; set; } = -1;

	public UnityEvent<Storage> e_FilterUpdated { get; private set; }

	public event UnityAction Updated;

	private void OnDestroy()
	{
		_storageSlots?.Remove();
		if (_storageInventory != null)
		{
			_storageInventory.ItemTakenEvent.AddListener(OnItemTaken);
		}
	}

	public virtual void Initialize(Buildable buildable, bool restored = false)
	{
		bool toggleItemFilters = !_isGeneralStorage || Settings.Instance.GameplayPlayerData.ToggleGeneralStorageFilters;
		Initialize(buildable, ((_filter & Item.Tags.Liquid) != Item.Tags.None) ? SubInventoryType.Liquid : SubInventoryType.Storage, toggleItemFilters);
	}

	protected void Initialize(Buildable buildable, SubInventoryType subInventory, bool toggleItemFilters = true)
	{
		Buildable = buildable;
		Inventory = buildable.Inventory;
		GameEventDispatcher.AddListener(GameEventType.NewItemDiscovered, OnNewItemDiscovered);
		_storageInventory = buildable.Inventory.GetOrAddSubInventory(subInventory, _capacity);
		_storageInventory.ItemTakenEvent.AddListener(OnItemTaken);
		_storageSlots?.Initialize(Buildable.Inventory, SubInventoryType.Storage, Buildable.OutlineRenderer);
		if (LoadingScreen.IsLoading)
		{
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		}
		Filter = ItemFilter.Get(_filter, toggleItemFilters);
		e_FilterUpdated = new UnityEvent<Storage>();
	}

	public virtual void Finish(bool restored = false)
	{
		Buildable.Community.AddStorage(this);
		if (_shutDownResourceProvider != null)
		{
			_shutDownResourceProvider.Unregister();
		}
		_storageInventory.Updated += OnStorageInventoryUpdated;
		Filter.OnUpdated.AddListener(OnFilterUpdated);
		GetComponentInChildren<LiquidShaderManager>()?.Initialize(Buildable.Inventory);
		Buildable.Inventory.Initialize(this);
		if (_resourceProvider == null)
		{
			_resourceProvider = new StorageResourceProvider(this, _storageInventory.Type);
		}
		_resourceProvider.Register();
	}

	public void OnDeconstruct()
	{
		if (_shutDownResourceProvider != null)
		{
			_shutDownResourceProvider.Unregister();
		}
	}

	public virtual void Remove()
	{
		if (Buildable.BuildPhase == BuildPhase.Finished)
		{
			Buildable.Community.RemoveStorage(this);
			_storageInventory.Updated -= OnStorageInventoryUpdated;
			Filter.OnUpdated.RemoveListener(OnFilterUpdated);
			GameEventDispatcher.RemoveListener(GameEventType.NewItemDiscovered, OnNewItemDiscovered);
			if (_shutDownResourceProvider != null)
			{
				_shutDownResourceProvider.Unregister();
			}
		}
	}

	public virtual void Count(InventoryAuditor auditor, SubInventoryType subInventoryType)
	{
		if (_storageInventory.Type == subInventoryType)
		{
			auditor.CountInventory(_storageInventory);
		}
	}

	public virtual void PopulateAllItems(List<Item> allItems, SubInventoryType subInventoryType)
	{
		if (_storageInventory.Type == subInventoryType)
		{
			_storageInventory.ReturnAllItems(allItems);
		}
	}

	public virtual bool TryReserveItem(ItemProperties itemProperties, out Item item)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		_storageInventory.ReserveItems(itemProperties, 1, list);
		if (list.Count > 0)
		{
			item = list[0];
			return true;
		}
		item = null;
		return false;
	}

	public virtual bool ReserveIncomingItem(Item item)
	{
		if (Buildable.BuildPhase == BuildPhase.Finished && AcceptsItem(item.Properties))
		{
			return Buildable.Inventory.ReserveIncomingItem(item, _storageInventory.Type);
		}
		return false;
	}

	protected virtual void UnreserveStuckItems()
	{
		Buildable.Community.UnreserveStuckItems(Buildable.Inventory, _storageInventory.Type);
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		if (gameEvent.EventType == GameEventType.GameStart)
		{
			GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
			UnreserveStuckItems();
		}
	}

	protected void OnStorageInventoryUpdated()
	{
		this.Updated?.Invoke();
	}

	private void OnFilterUpdated()
	{
		e_FilterUpdated.Invoke(this);
	}

	private void OnNewItemDiscovered(GameEvent gameEvent)
	{
		if (gameEvent is FoundItemPropertiesEvent foundItemPropertiesEvent && foundItemPropertiesEvent.Community == Buildable.Community && Filter.TryAddDiscoveredItem(foundItemPropertiesEvent.ItemProperties))
		{
			Debug.LogWarningFormat("Discovered item '{0}' was added to the filter of '{1}'", foundItemPropertiesEvent.ItemProperties, base.name);
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

	public virtual bool CanBeSalvaged()
	{
		if (_storageInventory.ReturnItemCount(includeReserved: true) <= 0)
		{
			return _storageInventory.IncomingItems.Count == 0;
		}
		return false;
	}

	public virtual void Shutdown()
	{
		Deactivate();
		Community.PlayerCommunity.RemoveStorage(this);
		if (_resourceProvider != null)
		{
			_resourceProvider.Unregister();
		}
		if (_shutDownResourceProvider == null)
		{
			_shutDownResourceProvider = ResourceProvider.Get(Buildable, _storageInventory.Type, AssignmentType.Constructing);
		}
		_shutDownResourceProvider.Register();
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

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public string ReturnDescription(string text)
	{
		Inventory component = GetComponent<Inventory>();
		text = Regex.Replace(text, "%STORAGEAMOUNT%", $"<b>{component.StorageCapacity.ToString()}</b>", RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%WATERSTORAGEAMOUNT%", $"<b>{component.LiquidCapacity.ToString()}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public virtual bool HasItemIncoming(Item item)
	{
		return _storageInventory.HasIncomingItem(item);
	}

	public bool AcceptsTags(Item.Tags tags)
	{
		return Filter.AcceptsTags(tags);
	}

	public virtual bool AcceptsItem(ItemProperties itemProperties)
	{
		return Filter.AcceptsItem(itemProperties);
	}

	public bool FitsItem(Item item)
	{
		if (item != null)
		{
			if (!(item.MoveToInventory == Inventory))
			{
				return 0 < ReturnAvailableCapacity(item.Properties);
			}
			return true;
		}
		return false;
	}

	public virtual int ReturnCount(SubInventoryType subInventoryType, bool includeReserved)
	{
		if (_storageInventory.Type != subInventoryType)
		{
			return 0;
		}
		return _storageInventory.ReturnItemCount(includeReserved);
	}

	public virtual int ReturnCount(Item.Tags itemTags, bool includeReserved)
	{
		if (!AcceptsTags(itemTags))
		{
			return 0;
		}
		return _storageInventory.ReturnItemCount(includeReserved);
	}

	public int ReturnStoredItemCount(ItemProperties itemProperties)
	{
		int num = _storageInventory.ReturnItemCount(itemProperties, includeReserved: true);
		foreach (Item incomingItem in _storageInventory.IncomingItems)
		{
			if (incomingItem.Properties == itemProperties)
			{
				num++;
			}
		}
		return num;
	}

	public virtual int ReturnAvailableCapacity(ItemProperties itemProperties)
	{
		if (AcceptsItem(itemProperties))
		{
			return _storageInventory.AvailableCapacity - _storageInventory.IncomingItems.Count;
		}
		return 0;
	}

	public virtual int ReturnCapacity(SubInventoryType subInventoryType)
	{
		if (_storageInventory.Type != subInventoryType)
		{
			return 0;
		}
		return _storageInventory.Capacity;
	}

	public virtual int ReturnCapacity(Item.Tags itemTags)
	{
		if (!AcceptsTags(itemTags))
		{
			return 0;
		}
		return _storageInventory.Capacity;
	}

	public virtual Item ReturnItem(ItemProperties itemProperties, SubInventoryType subInventoryType)
	{
		if (_storageInventory.Type != subInventoryType)
		{
			return null;
		}
		return _storageInventory.ReturnItemFromProperties(itemProperties);
	}

	public virtual int ReturnIncomingItemCount(SubInventoryType subInventoryType)
	{
		if (_storageInventory.Type != subInventoryType)
		{
			return 0;
		}
		return _storageInventory.IncomingItems.Count;
	}

	public virtual int ReturnIncomingItemCount(Item.Tags tags)
	{
		if ((Filter.Tags & tags) == 0)
		{
			return 0;
		}
		return _storageInventory.IncomingItems.Count;
	}

	private void OnItemTaken(Item item)
	{
		ItemEvent.Dispatch(GameEventType.StoredItemTaken, item);
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new StoragePersistentData(this);
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}
}
