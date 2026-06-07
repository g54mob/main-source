using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public abstract class ItemContainerBase : NetworkBehaviour, IItemContainer
{
	[Header("Item Storage")]
	protected SyncList<ItemStack> storedItemStacks = new SyncList<ItemStack>();

	protected Dictionary<string, int> itemCounts = new Dictionary<string, int>();

	protected int _cachedTotalItemCount;

	protected int _cachedUniqueItemCount;

	public virtual int ItemCount => _cachedTotalItemCount;

	public virtual int UniqueItemCount => _cachedUniqueItemCount;

	public virtual bool SupportsCapacity => false;

	public virtual int CurrentItemCount => -1;

	public virtual int TotalCapacity => -1;

	public SyncList<ItemStack> StoredItemStacks => storedItemStacks;

	public Dictionary<string, int> ItemCountsDebug => new Dictionary<string, int>(itemCounts);

	public virtual Dictionary<string, int> GetStoredItemCounts()
	{
		if (base.isServer)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			{
				foreach (ItemStack storedItemStack in storedItemStacks)
				{
					if (storedItemStack != null && storedItemStack.IsValid())
					{
						if (dictionary.ContainsKey(storedItemStack.itemId))
						{
							dictionary[storedItemStack.itemId] += storedItemStack.count;
						}
						else
						{
							dictionary[storedItemStack.itemId] = storedItemStack.count;
						}
					}
				}
				return dictionary;
			}
		}
		return new Dictionary<string, int>(itemCounts);
	}

	protected virtual void Awake()
	{
		SyncList<ItemStack> syncList = storedItemStacks;
		syncList.Callback = (Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>)Delegate.Combine(syncList.Callback, new Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>(OnItemStacksChanged));
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		OnServerStarted();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		UpdateItemCounts();
		OnClientStarted();
	}

	protected virtual void OnServerStarted()
	{
	}

	protected virtual void OnClientStarted()
	{
	}

	protected virtual void OnItemStacksChanged(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
		if (!base.isServer)
		{
			UpdateItemCounts();
		}
		else
		{
			RecalculateServerCounts();
		}
		OnItemStacksUpdated(op, index, oldStack, newStack);
	}

	protected void RecalculateServerCounts()
	{
		int num = 0;
		int num2 = 0;
		foreach (ItemStack storedItemStack in storedItemStacks)
		{
			if (storedItemStack != null && storedItemStack.IsValid())
			{
				num += storedItemStack.count;
				num2++;
			}
		}
		_cachedTotalItemCount = num;
		_cachedUniqueItemCount = num2;
	}

	protected virtual void OnItemStacksUpdated(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
	}

	protected virtual void UpdateItemCounts()
	{
		itemCounts.Clear();
		int num = 0;
		foreach (ItemStack storedItemStack in storedItemStacks)
		{
			if (storedItemStack != null && storedItemStack.IsValid())
			{
				num += storedItemStack.count;
				if (itemCounts.ContainsKey(storedItemStack.itemId))
				{
					itemCounts[storedItemStack.itemId] += storedItemStack.count;
				}
				else
				{
					itemCounts[storedItemStack.itemId] = storedItemStack.count;
				}
			}
		}
		_cachedTotalItemCount = num;
		_cachedUniqueItemCount = itemCounts.Count;
		OnItemCountsUpdated();
	}

	protected virtual void OnItemCountsUpdated()
	{
	}

	[Server]
	public virtual void ServerSetItems(List<T_ItemSO> items)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ItemContainerBase::ServerSetItems(System.Collections.Generic.List`1<T_ItemSO>)' called when server was not active");
			return;
		}
		if (items == null)
		{
			Debug.LogWarning(GetType().Name + ": Items listesi null!");
			return;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (T_ItemSO item in items)
		{
			if (item != null && !string.IsNullOrEmpty(item.GetItemID()))
			{
				string itemID = item.GetItemID();
				if (dictionary.ContainsKey(itemID))
				{
					dictionary[itemID]++;
				}
				else
				{
					dictionary[itemID] = 1;
				}
			}
		}
		storedItemStacks.Clear();
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			storedItemStacks.Add(new ItemStack(item2.Key, item2.Value));
		}
		OnItemsSet(items.Count, dictionary.Count);
	}

	protected virtual void OnItemsSet(int totalCount, int uniqueCount)
	{
		Debug.Log($"{GetType().Name}: {uniqueCount} benzersiz item türü, toplam {totalCount} item eklendi (Server)");
	}

	[Server]
	public virtual void ServerRemoveItems(Dictionary<string, int> itemsToRemove)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ItemContainerBase::ServerRemoveItems(System.Collections.Generic.Dictionary`2<System.String,System.Int32>)' called when server was not active");
		}
		else
		{
			if (itemsToRemove == null || itemsToRemove.Count == 0)
			{
				return;
			}
			for (int num = storedItemStacks.Count - 1; num >= 0; num--)
			{
				ItemStack itemStack = storedItemStacks[num];
				if (itemStack.IsValid() && itemsToRemove.ContainsKey(itemStack.itemId) && itemsToRemove[itemStack.itemId] > 0)
				{
					int a = itemsToRemove[itemStack.itemId];
					int count = itemStack.count;
					int num2 = Mathf.Min(a, count);
					if (num2 > 0)
					{
						itemStack.RemoveCount(num2);
						if (itemStack.count <= 0)
						{
							storedItemStacks.RemoveAt(num);
						}
						else
						{
							storedItemStacks.RemoveAt(num);
							storedItemStacks.Insert(num, itemStack);
						}
						itemsToRemove[itemStack.itemId] -= num2;
						if (itemsToRemove[itemStack.itemId] <= 0)
						{
							itemsToRemove.Remove(itemStack.itemId);
						}
					}
				}
			}
			OnItemsRemoved();
		}
	}

	protected virtual void OnItemsRemoved()
	{
		Debug.Log($"{GetType().Name}: Item'lar kaldırıldı, kalan item sayısı: {ItemCount}");
	}

	[Server]
	public virtual void ServerClear()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ItemContainerBase::ServerClear()' called when server was not active");
			return;
		}
		storedItemStacks.Clear();
		OnCleared();
	}

	protected virtual void OnCleared()
	{
		Debug.Log(GetType().Name + ": Container temizlendi!");
	}

	public virtual int GetItemCount(T_ItemSO itemSO)
	{
		if (itemSO == null || string.IsNullOrEmpty(itemSO.GetItemID()))
		{
			return 0;
		}
		string itemID = itemSO.GetItemID();
		if (base.isServer)
		{
			foreach (ItemStack storedItemStack in storedItemStacks)
			{
				if (storedItemStack != null && storedItemStack.itemId == itemID)
				{
					return storedItemStack.count;
				}
			}
		}
		else if (itemCounts.ContainsKey(itemID))
		{
			return itemCounts[itemID];
		}
		return 0;
	}

	public virtual int GetItemCountById(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return 0;
		}
		if (base.isServer)
		{
			foreach (ItemStack storedItemStack in storedItemStacks)
			{
				if (storedItemStack != null && storedItemStack.itemId == itemId)
				{
					return storedItemStack.count;
				}
			}
		}
		else if (itemCounts.ContainsKey(itemId))
		{
			return itemCounts[itemId];
		}
		return 0;
	}

	protected ItemContainerBase()
	{
		InitSyncObject(storedItemStacks);
	}

	public override bool Weaved()
	{
		return true;
	}
}
