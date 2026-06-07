using System;
using System.Collections.Generic;
using UnityEngine;

public class Diet
{
	public class Entry
	{
		public ItemProperties ItemProperties { get; private set; }

		public AssignmentPriority Priority { get; private set; } = AssignmentPriority.Lowest;

		public Entry(ItemProperties itemProperties)
		{
			ItemProperties = itemProperties;
		}

		public bool SetPriority(AssignmentPriority priority)
		{
			if (Priority != priority)
			{
				Priority = priority;
				return true;
			}
			return false;
		}
	}

	[Serializable]
	public class PD
	{
		[Serializable]
		private struct E
		{
			public int I;

			public AssignmentPriority P;
		}

		private E[] _entries;

		private int _favourite;

		private static Dictionary<ItemProperties, AssignmentPriority> _restoredPriorities;

		public PD(List<Entry> entries, Entry favourite)
		{
			if (0 < entries.Count)
			{
				_entries = new E[entries.Count];
				for (int i = 0; i < _entries.Length; i++)
				{
					Entry entry = entries[i];
					_entries[i] = new E
					{
						I = GameManager.PersistenceManager.ReturnPropertiesIndex(entry.ItemProperties),
						P = entry.Priority
					};
				}
			}
			_favourite = ((favourite == null) ? (-1) : GameManager.PersistenceManager.ReturnPropertiesIndex(favourite.ItemProperties));
		}

		public void Restore(List<Entry> entries)
		{
			if (_entries == null)
			{
				return;
			}
			if (_restoredPriorities == null)
			{
				_restoredPriorities = new Dictionary<ItemProperties, AssignmentPriority>();
			}
			else
			{
				_restoredPriorities.Clear();
			}
			E[] entries2 = _entries;
			for (int i = 0; i < entries2.Length; i++)
			{
				E e = entries2[i];
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(e.I, out var reference))
				{
					_restoredPriorities.Add(reference, e.P);
				}
			}
			foreach (Entry entry in entries)
			{
				if (_restoredPriorities.TryGetValue(entry.ItemProperties, out var value))
				{
					entry.SetPriority(value);
				}
			}
		}

		public bool TryRestoreFavourite(out ItemProperties itemProperties)
		{
			itemProperties = null;
			if (-1 < _favourite)
			{
				return GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(_favourite, out itemProperties);
			}
			return false;
		}
	}

	private int _length;

	private Item _itemToConsume;

	private int _consumedItemCount;

	public Vital Vital { get; private set; }

	public List<Entry> Entries { get; private set; }

	public AssignmentPriority Priority
	{
		get
		{
			if (!Entries.IsNullOrEmpty())
			{
				return Entries[0].Priority;
			}
			return AssignmentPriority.None;
		}
	}

	public ItemProperties LastReservedItemToConsume { get; private set; }

	public ProjectProperties ConsumeProjectProperties { get; private set; }

	public GameEventType FailedEvent { get; private set; }

	public bool HasItemToConsume => _itemToConsume != null;

	public Entry Favourite { get; private set; }

	public List<ItemProperties> ConsumedItems { get; private set; } = new List<ItemProperties>();

	public Item.Tags Tags { get; private set; }

	private Diet(Vital vital, Item.Tags itemTag, ProjectProperties consumeProjectProperties, GameEventType failedEvent, int consumedItemCount = 5)
	{
		Vital = vital;
		ConsumeProjectProperties = consumeProjectProperties;
		FailedEvent = failedEvent;
		Tags = itemTag;
		_consumedItemCount = consumedItemCount;
		List<ItemProperties> list = GameManager.Settings.ItemSettings.ReturnItemPropertiesWithTag(itemTag);
		_length = list.Count;
		Entries = new List<Entry>(_length);
		foreach (ItemProperties item in list)
		{
			Entries.Add(new Entry(item));
		}
	}

	public static Diet GetInstance(Vital vital)
	{
		return vital.VitalType switch
		{
			VitalType.Hunger => new Diet(vital, Item.Tags.Food, GameManager.Settings.ProjectSettings.GetAndEatProperties, GameEventType.AgentAteNoFood), 
			VitalType.Thirst => new Diet(vital, Item.Tags.Drink, GameManager.Settings.ProjectSettings.GetAndDrinkProperties, GameEventType.AgentDrankNoDrink), 
			_ => null, 
		};
	}

	public void SetPriority(ItemProperties itemProperties, AssignmentPriority priority)
	{
		if (TryReturnEntry(itemProperties, out var entry) && entry.SetPriority(priority))
		{
			GameEventDispatcher.Dispatch(GameEventType.AgentDietUpdated);
		}
	}

	public void SetFavourite(ItemProperties itemProperties = null)
	{
		if (TryReturnEntry(itemProperties, out var entry))
		{
			Favourite = entry;
			return;
		}
		Favourite = Entries.GetRandom();
		if ((bool)itemProperties)
		{
			Debug.LogException(new Exception($"Unable to apply '{itemProperties.name}' as favourite, no entry found in diet for this item. '{Favourite.ItemProperties}' was assigned as replacement."));
		}
	}

	public bool TryReserveItemToConsume(AssignmentPriority priority)
	{
		if (TryReserveItemToConsume(Favourite, priority))
		{
			return true;
		}
		int length = _length;
		while (0 < length--)
		{
			if (TryReserveItemToConsume(Entries[length], priority))
			{
				return true;
			}
		}
		_itemToConsume = null;
		return false;
	}

	private bool TryReserveItemToConsume(Entry entry, AssignmentPriority priority)
	{
		if (entry != null && priority <= entry.Priority && Vital.Agent.Community.Inventory.TryReserveItem(entry.ItemProperties, out _itemToConsume))
		{
			LastReservedItemToConsume = _itemToConsume.Properties;
			return true;
		}
		return false;
	}

	public bool TryReturnAndClearItemToConsume(out Item itemToConsume)
	{
		itemToConsume = _itemToConsume;
		_itemToConsume = null;
		return itemToConsume != null;
	}

	public void ClearItemToConsume()
	{
		if (_itemToConsume != null)
		{
			_itemToConsume.CancelReservation();
			_itemToConsume = null;
		}
	}

	public void ClearLastReservedItemToCosume()
	{
		LastReservedItemToConsume = null;
	}

	public void OnDayStarted()
	{
		ConsumedItems.Insert(0, null);
		int count = ConsumedItems.Count;
		while (_consumedItemCount < count--)
		{
			ConsumedItems.RemoveAt(count);
		}
	}

	public void ConsumeItem(Item item)
	{
		if (ConsumedItems.Count == 0)
		{
			ConsumedItems.Add(item.Properties);
			return;
		}
		ItemProperties itemProperties = ConsumedItems[0];
		if (itemProperties == null || HasGreaterQuality(itemProperties.Quality, item.Properties.Quality))
		{
			ConsumedItems[0] = item.Properties;
		}
	}

	public ItemProperties ReturnItemConsumedToday()
	{
		ItemProperties itemProperties = ((ConsumedItems.Count == 0) ? null : ConsumedItems[0]);
		Project project = Vital.Project;
		if (itemProperties == null && project != null)
		{
			if (0 < project.GeneralItems.Count)
			{
				itemProperties = project.GeneralItems[0].Properties;
			}
			else if (0 < project.Assignments.Count && 0 < project.Assignments[0].ItemsToHaul.Count)
			{
				itemProperties = project.Assignments[0].ItemsToHaul[0].Item.Properties;
			}
		}
		return itemProperties;
	}

	public int GetConsumableCount()
	{
		return Vital.Agent.Community.Inventory.ReturnCount(Tags);
	}

	public bool TryReturnPriority(ItemProperties itemProperties, out AssignmentPriority priority)
	{
		if (TryReturnEntry(itemProperties, out var entry))
		{
			priority = entry.Priority;
			return true;
		}
		priority = AssignmentPriority.None;
		return false;
	}

	private bool TryReturnEntry(ItemProperties itemProperties, out Entry entry)
	{
		for (int i = 0; i < _length; i++)
		{
			entry = Entries[i];
			if (entry.ItemProperties == itemProperties)
			{
				return true;
			}
		}
		entry = null;
		return false;
	}

	private bool HasGreaterQuality(ItemQuality currentQuality, ItemQuality consumedQuality)
	{
		if (currentQuality != null && consumedQuality != null)
		{
			return currentQuality.Value < consumedQuality.Value;
		}
		return false;
	}

	public bool TryReturnPersistentData(out PD persistentData)
	{
		using ListPool<Entry>.List list = ListPool<Entry>.Get(_length);
		foreach (Entry entry in Entries)
		{
			if (entry.Priority != AssignmentPriority.Lowest)
			{
				list.Add(entry);
			}
		}
		persistentData = new PD(list, Favourite);
		return true;
	}

	public void Restore(PD persistentData)
	{
		if (persistentData != null)
		{
			persistentData.Restore(Entries);
			if (persistentData.TryRestoreFavourite(out var itemProperties))
			{
				SetFavourite(itemProperties);
			}
			else
			{
				SetFavourite();
			}
		}
	}
}
