using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemFilter
{
	private static Dictionary<Item.Tags, HashSet<ItemProperties>> _filterCache = new Dictionary<Item.Tags, HashSet<ItemProperties>>();

	public Item.Tags Tags { get; private set; }

	public Item.Tags AcceptedTags { get; private set; }

	public HashSet<ItemProperties> AllItems { get; private set; }

	public HashSet<ItemProperties> AcceptedItems { get; private set; }

	public bool ShowFilterPanel { get; private set; }

	public static Dictionary<Item.Tags, ItemFilter> ItemFiltersToCopy { get; private set; } = new Dictionary<Item.Tags, ItemFilter>();

	public UnityEvent OnUpdated { get; private set; }

	private ItemFilter(Item.Tags tags, HashSet<ItemProperties> allItems, bool toggleItemFilters = true)
	{
		Tags = tags;
		AcceptedTags = tags;
		AllItems = allItems;
		ShowFilterPanel = allItems.Count > 1;
		if (toggleItemFilters)
		{
			AcceptedItems = new HashSet<ItemProperties>(allItems);
		}
		else
		{
			AcceptedItems = new HashSet<ItemProperties>(allItems.Count);
			foreach (ItemProperties allItem in allItems)
			{
				if (allItem.ExcludeFromItemFilter)
				{
					AcceptedItems.Add(allItem);
				}
			}
		}
		OnUpdated = new UnityEvent();
	}

	public static ItemFilter Get(Item.Tags tags, bool toggleItemFilters = true)
	{
		if (!_filterCache.TryGetValue(tags, out var value))
		{
			value = Community.PlayerCommunity.Inventory.ReturnItemFilter(tags);
			_filterCache.Add(tags, value);
		}
		return new ItemFilter(tags, value, toggleItemFilters);
	}

	public void AddAcceptedTags(Item.Tags tags)
	{
		AcceptedTags |= Tags & tags;
		OnUpdated.Invoke();
	}

	public void RemoveAcceptedTags(Item.Tags tags)
	{
		AcceptedTags &= ~tags;
		OnUpdated.Invoke();
	}

	public void AddAcceptedItem(ItemProperties itemProperties)
	{
		if ((AcceptedTags & itemProperties.Tags) != Item.Tags.None && AcceptedItems.Add(itemProperties))
		{
			OnUpdated.Invoke();
		}
	}

	public void RemoveAcceptedItem(ItemProperties itemProperties)
	{
		if ((AcceptedTags & itemProperties.Tags) != Item.Tags.None && AcceptedItems.Remove(itemProperties))
		{
			OnUpdated.Invoke();
		}
	}

	public bool TryAddDiscoveredItem(ItemProperties itemProperties)
	{
		if ((itemProperties.Tags & Tags) != Item.Tags.None && AllItems.Add(itemProperties))
		{
			Debug.Log("New item discovered: " + itemProperties.LocalizedName);
			AddAcceptedItem(itemProperties);
			return true;
		}
		return false;
	}

	public void Copy()
	{
		if (!ItemFiltersToCopy.TryAdd(Tags, this))
		{
			ItemFiltersToCopy[Tags] = this;
		}
	}

	public bool Paste()
	{
		if (ItemFiltersToCopy.TryGetValue(Tags, out var value) && value != this)
		{
			AcceptedTags = Tags & value.AcceptedTags;
			AcceptedItems.Clear();
			foreach (ItemProperties acceptedItem in value.AcceptedItems)
			{
				if ((acceptedItem.Tags & AcceptedTags) != Item.Tags.None)
				{
					AcceptedItems.Add(acceptedItem);
				}
			}
			return true;
		}
		return false;
	}

	public static void ResetCopyPaste()
	{
		ItemFiltersToCopy.Clear();
	}

	public bool AcceptsTags(Item.Tags tags)
	{
		return (AcceptedTags & tags) != 0;
	}

	public bool AcceptsItem(ItemProperties itemProperties)
	{
		if ((AcceptedTags & itemProperties.Tags) != Item.Tags.None)
		{
			return AcceptedItems.Contains(itemProperties);
		}
		return false;
	}

	public bool CanPaste()
	{
		return ItemFiltersToCopy.ContainsKey(Tags);
	}

	public void Restore(Item.Tags acceptedTags, int[] acceptedItemIndices)
	{
		AcceptedTags = Item.Tags.None;
		AcceptedItems.Clear();
		AddAcceptedTags(acceptedTags);
		if (acceptedItemIndices == null)
		{
			foreach (ItemProperties allItem in AllItems)
			{
				AcceptedItems.Add(allItem);
			}
		}
		else
		{
			foreach (int index in acceptedItemIndices)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(index, out var reference) && (reference.Tags & AcceptedTags) != Item.Tags.None)
				{
					AcceptedItems.Add(reference);
				}
			}
		}
		OnUpdated.Invoke();
	}
}
