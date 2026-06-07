using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

public class ResourceProvider : ItemDataItemProvider, IComparable<ResourceProvider>
{
	public class Event : UnityEvent<ResourceProvider>
	{
	}

	private readonly Community _community;

	private readonly IConstructible _constructible;

	private readonly InventoryAuditor _inventoryAuditor = new InventoryAuditor(InventoryAuditor.Mode.NotAssignedToProject);

	private readonly Dictionary<ItemProperties, float> _blockedItemTimeStamps = new Dictionary<ItemProperties, float>();

	private readonly IInventorySpaceLimiter _inventorySpaceLimiter;

	private readonly LocalizedString _debugName;

	private int _inventoryCapcity;

	public SubInventoryType SubInventoryType { get; private set; }

	public AssignmentType AssignmentType { get; private set; }

	public bool Locked { get; set; }

	public bool IsEmpty { get; private set; }

	public bool CanEmpty { get; private set; } = true;

	protected Community RegisteredCommunity { get; private set; }

	public int Priority { get; private set; }

	public int AssignmentPriority { get; private set; }

	public int CapacityPriority { get; private set; }

	public bool IsStorage => base.Inventory.Type == InventoryType.Storage;

	public ResourceProvider(IConstructible constructible, SubInventoryType subInventory, AssignmentType assignmentType = AssignmentType.None)
		: this(constructible, subInventory, constructible.Community.Inventory, assignmentType)
	{
	}

	public ResourceProvider(IConstructible constructible, SubInventoryType subInventory, IInventorySpaceLimiter inventorySpaceLimiter, AssignmentType assignmentType = AssignmentType.None)
		: base(constructible.Inventory, subInventory)
	{
		SubInventoryType = subInventory;
		AssignmentType = assignmentType;
		base.SubInventory.Updated += OnInventoryUpdate;
		_constructible = constructible;
		_community = constructible.Community;
		_inventorySpaceLimiter = inventorySpaceLimiter;
		_debugName = constructible.Name;
		_inventoryCapcity = base.SubInventory.Capacity;
	}

	public static ResourceProvider Get(IConstructible constructible, SubInventoryType subInventoryType, AssignmentType assignmentType = AssignmentType.None)
	{
		return Get(constructible, subInventoryType, constructible.Community.Inventory, assignmentType);
	}

	public static ResourceProvider Get(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter, AssignmentType assignmentType = AssignmentType.None)
	{
		return assignmentType switch
		{
			AssignmentType.Constructing => new ConstructingResourceProvider(constructible, subInventoryType, inventorySpaceLimiter), 
			AssignmentType.Cooking => new CookingResourceProvider(constructible, subInventoryType, inventorySpaceLimiter), 
			AssignmentType.Crafting => new CraftingResourceProvider(constructible, subInventoryType, inventorySpaceLimiter), 
			AssignmentType.Farming => new FarmingResourceProvider(constructible, subInventoryType, inventorySpaceLimiter), 
			_ => new ResourceProvider(constructible, subInventoryType, inventorySpaceLimiter, assignmentType), 
		};
	}

	public virtual bool HasExportableItems()
	{
		Item item;
		return TryReturnFirstExportableItem(out item, _inventorySpaceLimiter);
	}

	public virtual bool TryReturnFirstExportableItem(out Item item)
	{
		return TryReturnFirstExportableItem(out item, _inventorySpaceLimiter);
	}

	public virtual bool TryReturnFirstExportableItem(out Item item, IInventorySpaceLimiter limiter)
	{
		item = null;
		if (!Locked && !base.SubInventory.IsEmpty)
		{
			return base.SubInventory.ReturnFirstAvailableItem(SubInventoryType, out item, limiter);
		}
		return false;
	}

	public virtual void PopulateUnreservedItems(List<ItemProperties> itemProperties)
	{
		if (Locked || base.SubInventory.IsEmpty)
		{
			return;
		}
		foreach (IInventorySlot slot in base.SubInventory.Slots)
		{
			if (slot.ReturnHasUnreservedItem())
			{
				itemProperties.AddUnique(slot.ItemProperties);
			}
		}
	}

	public virtual void Register()
	{
		if (RegisteredCommunity != null)
		{
			Debug.LogWarningFormat("Registering resource provider for '{0}', but it is already registered", _debugName);
			if (RegisteredCommunity == _community)
			{
				return;
			}
			Unregister();
		}
		if (LoadingScreen.IsLoading)
		{
			GameEventDispatcher.AddListener(GameEventType.LoadingCompleted, OnLoadingCompleted);
			return;
		}
		RegisteredCommunity = _community;
		RegisteredCommunity.UnreserveStuckItems(base.Inventory, SubInventoryType);
		base.SubInventory.ItemTakenEvent.AddListener(OnItemTaken);
		RegisteredCommunity.Inventory.AddResourceProvider(this);
	}

	public virtual void Unregister()
	{
		if (RegisteredCommunity != null)
		{
			base.SubInventory.ItemTakenEvent.RemoveListener(OnItemTaken);
			RegisteredCommunity.Inventory.RemoveResourceProvider(this);
			RegisteredCommunity = null;
			RemoveMalfunction();
		}
	}

	public void Update()
	{
		CanEmpty = HasExportableItems();
		UpdateBlocked();
	}

	protected virtual void UpdateBlocked()
	{
		bool flag = false;
		_inventoryAuditor.Reset();
		_inventoryAuditor.CountInventory(base.SubInventory);
		foreach (InventoryAuditor.CountedItem countedItem in _inventoryAuditor.CountedItems)
		{
			if (countedItem.UnreservedCount == 0 || CanExportItem(countedItem.ItemProperties))
			{
				_blockedItemTimeStamps.Remove(countedItem.ItemProperties);
				continue;
			}
			float time = Time.time;
			if (!_blockedItemTimeStamps.TryGetValue(countedItem.ItemProperties, out var value))
			{
				value = time;
				_blockedItemTimeStamps.Add(countedItem.ItemProperties, value);
			}
			if (GameManager.Settings.BuildableSettings.ItemBlockedMalFunctionDelay < time - value)
			{
				flag = true;
			}
		}
		if (_constructible != null)
		{
			if (flag)
			{
				AddMalfunction();
			}
			else
			{
				RemoveMalfunction();
			}
		}
	}

	public void UpdatePriority(int multiplier)
	{
	}

	public void UpdatePriority(Agent agent, int haulingPriority)
	{
		Priority = GetAssignmentPriority(agent, haulingPriority);
	}

	public void UpdatePriorityWithCapacity(Agent agent, int haulingPriority)
	{
		Priority = GetAssignmentPriority(agent, haulingPriority) + CapacityPriority;
	}

	public void AddAssignmentType(AssignmentType assignmentType)
	{
		AssignmentType |= assignmentType;
	}

	public void OverrideCapacity(int capacity)
	{
		if (capacity <= 0)
		{
			Debug.LogException(new ArgumentException());
		}
		else
		{
			_inventoryCapcity = capacity;
		}
	}

	private void AddMalfunction()
	{
		if (_constructible != null)
		{
			_constructible.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorResourceProviderBlocked);
		}
	}

	private void RemoveMalfunction()
	{
		if (_constructible != null)
		{
			_constructible.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorResourceProviderBlocked);
		}
	}

	public virtual void Count(InventoryAuditor counter)
	{
		counter.CountInventory(base.SubInventory);
	}

	public virtual int ReturnCount(bool includeReserved)
	{
		return base.SubInventory.ReturnItemCount(includeReserved);
	}

	public virtual float ReturnNutritionalValue(Item.Tags tag, bool includeReserved)
	{
		return base.SubInventory.ReturnItemContainingTagNutritionalValue(tag, includeReserved);
	}

	public Item ReturnItem(ItemProperties itemProperties)
	{
		return base.SubInventory.ReturnItemFromProperties(itemProperties);
	}

	private bool CanExportItem(ItemProperties item)
	{
		if (!_constructible.IsInConstruction())
		{
			return _inventorySpaceLimiter.FitsItem(item);
		}
		return _community.Inventory.FitsItem(item);
	}

	public virtual int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		if (base.SubInventory.IsEmpty || _inventoryCapcity == 0)
		{
			return 0;
		}
		if (AssignmentType == AssignmentType.None || AssignmentType == AssignmentType.Hauling)
		{
			return haulingPriority;
		}
		foreach (Assignment assignment in agent.Assignments)
		{
			if ((AssignmentType & assignment.Type) != AssignmentType.None && haulingPriority < assignment.ResourceProviderWeight)
			{
				haulingPriority = assignment.ResourceProviderWeight;
			}
		}
		return haulingPriority;
	}

	public virtual int GetCapacityPriority()
	{
		if (base.SubInventory.IsEmpty || _inventoryCapcity == 0 || LoadingScreen.IsLoading)
		{
			return 0;
		}
		int num = 0;
		foreach (IInventorySlot slot in base.SubInventory.Slots)
		{
			num += ((slot.UnreservedCount > 0) ? Mathf.Min(slot.UnreservedCount, _inventorySpaceLimiter.GetCapacity(slot.ItemProperties)) : 0);
		}
		return Mathf.Clamp(num * 100 / _inventoryCapcity, 0, 100);
	}

	protected virtual float ReturnPriority()
	{
		if (base.SubInventory.IsEmpty || _inventoryCapcity == 0)
		{
			return 0f;
		}
		float num = 0f;
		foreach (IInventorySlot slot in base.SubInventory.Slots)
		{
			num += (float)((slot.UnreservedCount > 0) ? Mathf.Min(slot.UnreservedCount, _inventorySpaceLimiter.GetCapacity(slot.ItemProperties)) : 0);
		}
		return Mathf.Clamp01(num / (float)_inventoryCapcity);
	}

	protected override void OnInventoryUpdate()
	{
		IsEmpty = base.SubInventory.ReturnItemCount() <= 0;
		CapacityPriority = GetCapacityPriority();
		base.OnInventoryUpdate();
	}

	private void OnLoadingCompleted(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.LoadingCompleted, OnLoadingCompleted);
		if (_constructible != null)
		{
			Register();
		}
	}

	private void OnItemTaken(Item item)
	{
		if (RegisteredCommunity != null)
		{
			ItemEvent.Dispatch(GameEventType.StoredItemTaken, item);
		}
	}

	public int CompareTo(ResourceProvider other)
	{
		return other.Priority - Priority;
	}
}
