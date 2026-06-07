using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_Warehouse : NetworkBehaviour
{
	[Header("Warehouse Settings")]
	[Tooltip("Periyodik doğrulama aralığı (saniye). 0 = devre dışı")]
	[SerializeField]
	private float validationInterval = 5f;

	[Header("References")]
	[Tooltip("Zone trigger bileşeni - Inspector'dan atanmalı")]
	[SerializeField]
	public T_WarehouseZoneTrigger zoneTrigger;

	[Header("Debug Display (Runtime)")]
	[SerializeField]
	private int _palletCountDisplay;

	[SerializeField]
	private int _totalItemCountDisplay;

	[SerializeField]
	private int _uniqueItemTypesDisplay;

	[SerializeField]
	private List<string> _inventoryDisplay = new List<string>();

	private readonly SyncList<uint> palletNetIds = new SyncList<uint>();

	private readonly SyncList<ItemStack> cachedInventory = new SyncList<ItemStack>();

	private Dictionary<string, int> inventoryCache = new Dictionary<string, int>();

	private HashSet<uint> palletIdSet = new HashSet<uint>();

	[Header("Events")]
	public UnityEvent<T_Pallet> OnPalletEntered;

	public UnityEvent<T_Pallet> OnPalletExited;

	public UnityEvent OnInventoryChanged;

	private int _cachedTotalItemCount;

	private int _cachedUniqueItemTypes;

	public static T_Warehouse Instance { get; private set; }

	public int PalletCount => palletNetIds.Count;

	public int TotalItemCount => _cachedTotalItemCount;

	public int UniqueItemTypes => _cachedUniqueItemTypes;

	public IReadOnlyList<uint> PalletIds => palletNetIds;

	public bool IsPalletInWarehouse(uint palletNetId)
	{
		return palletIdSet.Contains(palletNetId);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.LogWarning("[Warehouse] Birden fazla T_Warehouse instance'ı tespit edildi! Bu instance yok ediliyor.");
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		SyncList<uint> syncList = palletNetIds;
		syncList.Callback = (Action<SyncList<uint>.Operation, int, uint, uint>)Delegate.Combine(syncList.Callback, new Action<SyncList<uint>.Operation, int, uint, uint>(OnPalletNetIdsChanged));
		SyncList<ItemStack> syncList2 = cachedInventory;
		syncList2.Callback = (Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>)Delegate.Combine(syncList2.Callback, new Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>(OnCachedInventoryChanged));
		if (zoneTrigger != null)
		{
			zoneTrigger.SetWarehouse(this);
			return;
		}
		zoneTrigger = GetComponentInChildren<T_WarehouseZoneTrigger>();
		if (zoneTrigger != null)
		{
			zoneTrigger.SetWarehouse(this);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (validationInterval > 0f)
		{
			InvokeRepeating("ServerValidateInventory", validationInterval, validationInterval);
		}
		Debug.Log("[Warehouse] OnStartServer");
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		CancelInvoke("ServerValidateInventory");
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		RebuildLocalCache();
		UpdateDebugDisplay();
		Debug.Log($"[Warehouse] OnStartClient - Pallets: {PalletCount}, Items: {TotalItemCount}");
	}

	[Server]
	public void NotifyPalletPlaced(uint palletNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::NotifyPalletPlaced(System.UInt32)' called when server was not active");
		}
		else
		{
			if (zoneTrigger == null || !zoneTrigger.IsPalletInTrigger(palletNetId))
			{
				return;
			}
			if (palletIdSet.Contains(palletNetId))
			{
				Debug.LogWarning($"[Warehouse] HandlePalletPlaced - Palet zaten depoda! NetId: {palletNetId}");
				return;
			}
			if (!NetworkServer.spawned.TryGetValue(palletNetId, out var value))
			{
				Debug.LogWarning($"[Warehouse] HandlePalletPlaced - Palet bulunamadı! NetId: {palletNetId}");
				return;
			}
			T_Pallet component = value.GetComponent<T_Pallet>();
			if (component == null)
			{
				Debug.LogWarning($"[Warehouse] HandlePalletPlaced - T_Pallet component bulunamadı! NetId: {palletNetId}");
				return;
			}
			ServerOnPalletEnter(component);
			Debug.Log($"[Warehouse] NotifyPalletPlaced - Palet depoya eklendi. NetId: {palletNetId}");
		}
	}

	[Server]
	public void NotifyPalletLifted(uint palletNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::NotifyPalletLifted(System.UInt32)' called when server was not active");
		}
		else
		{
			if (!palletIdSet.Contains(palletNetId))
			{
				return;
			}
			if (!NetworkServer.spawned.TryGetValue(palletNetId, out var value))
			{
				ServerRemovePalletFromTracking(palletNetId);
				return;
			}
			T_Pallet component = value.GetComponent<T_Pallet>();
			if (component == null)
			{
				ServerRemovePalletFromTracking(palletNetId);
				return;
			}
			ServerOnPalletExit(component);
			Debug.Log($"[Warehouse] NotifyPalletLifted - Palet depodan çıkarıldı. NetId: {palletNetId}");
		}
	}

	[Server]
	public void NotifyPalletItemsAdded(uint palletNetId, string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::NotifyPalletItemsAdded(System.UInt32,System.String,System.Int32)' called when server was not active");
		}
		else if (palletIdSet.Contains(palletNetId))
		{
			AddItemsToCache(itemId, count);
			Debug.Log($"[Warehouse] Items added to pallet in warehouse - ItemId: {itemId}, Count: {count}");
		}
	}

	[Server]
	public void NotifyPalletItemsRemoved(uint palletNetId, string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::NotifyPalletItemsRemoved(System.UInt32,System.String,System.Int32)' called when server was not active");
		}
		else if (palletIdSet.Contains(palletNetId))
		{
			RemoveItemsFromCache(itemId, count);
			Debug.Log($"[Warehouse] Items removed from pallet in warehouse - ItemId: {itemId}, Count: {count}");
		}
	}

	[Server]
	public void NotifyPalletDestroyed(uint palletNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::NotifyPalletDestroyed(System.UInt32)' called when server was not active");
		}
		else if (palletIdSet.Contains(palletNetId))
		{
			ServerRemovePalletFromTracking(palletNetId);
			ServerRecalculateInventory();
			if (zoneTrigger != null)
			{
				zoneTrigger.OnPalletDestroyed(palletNetId);
			}
			Debug.Log($"[Warehouse] Pallet destroyed while in warehouse - NetId: {palletNetId}");
		}
	}

	[Server]
	public void ServerOnPalletEnter(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ServerOnPalletEnter(T_Pallet)' called when server was not active");
		}
		else
		{
			if (pallet == null)
			{
				return;
			}
			uint num = pallet.netId;
			if (palletIdSet.Contains(num))
			{
				Debug.LogWarning($"[Warehouse] ServerOnPalletEnter - Palet zaten depoda! NetId: {num}");
				return;
			}
			palletNetIds.Add(num);
			palletIdSet.Add(num);
			AddPalletContentsToCache(pallet);
			OnPalletEntered?.Invoke(pallet);
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Warehouse, TutorialStepType.PutPalletInWarehouse, TutorialSubStepType.PutPalletInWarehouseSub);
			}
			UpdateDebugDisplay();
			Debug.Log($"[Warehouse] Pallet entered - NetId: {num}, " + $"ItemId: {pallet.PaletItemId}, Count: {pallet.PaletItemCount}, " + $"Total pallets: {PalletCount}");
		}
	}

	[Server]
	public void ServerOnPalletExit(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ServerOnPalletExit(T_Pallet)' called when server was not active");
		}
		else if (!(pallet == null))
		{
			uint num = pallet.netId;
			if (!palletIdSet.Contains(num))
			{
				Debug.LogWarning($"[Warehouse] ServerOnPalletExit - Palet depoda değil! NetId: {num}");
				return;
			}
			RemovePalletContentsFromCache(pallet);
			palletNetIds.Remove(num);
			palletIdSet.Remove(num);
			OnPalletExited?.Invoke(pallet);
			UpdateDebugDisplay();
			Debug.Log($"[Warehouse] Pallet exited - NetId: {num}, " + $"Remaining pallets: {PalletCount}");
		}
	}

	[Server]
	private void ServerRemovePalletFromTracking(uint palletNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ServerRemovePalletFromTracking(System.UInt32)' called when server was not active");
		}
		else if (palletIdSet.Contains(palletNetId))
		{
			palletNetIds.Remove(palletNetId);
			palletIdSet.Remove(palletNetId);
			UpdateDebugDisplay();
			Debug.Log($"[Warehouse] Pallet removed from tracking - NetId: {palletNetId}");
		}
	}

	[Server]
	private void AddPalletContentsToCache(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::AddPalletContentsToCache(T_Pallet)' called when server was not active");
		}
		else if (!(pallet == null) && !pallet.IsEmpty)
		{
			string paletItemId = pallet.PaletItemId;
			int paletItemCount = pallet.PaletItemCount;
			if (!string.IsNullOrEmpty(paletItemId) && paletItemCount > 0)
			{
				AddItemsToCache(paletItemId, paletItemCount);
			}
		}
	}

	[Server]
	private void RemovePalletContentsFromCache(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::RemovePalletContentsFromCache(T_Pallet)' called when server was not active");
		}
		else if (!(pallet == null) && !pallet.IsEmpty)
		{
			string paletItemId = pallet.PaletItemId;
			int paletItemCount = pallet.PaletItemCount;
			if (!string.IsNullOrEmpty(paletItemId) && paletItemCount > 0)
			{
				RemoveItemsFromCache(paletItemId, paletItemCount);
			}
		}
	}

	[Server]
	private void AddItemsToCache(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::AddItemsToCache(System.String,System.Int32)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(itemId) || count <= 0)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < cachedInventory.Count; i++)
			{
				if (cachedInventory[i].itemId == itemId)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				ItemStack itemStack = cachedInventory[num];
				itemStack.AddCount(count);
				cachedInventory.RemoveAt(num);
				cachedInventory.Insert(num, itemStack);
			}
			else
			{
				cachedInventory.Add(new ItemStack(itemId, count));
			}
			OnInventoryChanged?.Invoke();
			UpdateDebugDisplay();
		}
	}

	[Server]
	public bool RemoveItemsFromCache(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Warehouse::RemoveItemsFromCache(System.String,System.Int32)' called when server was not active");
			return default(bool);
		}
		if (string.IsNullOrEmpty(itemId) || count <= 0)
		{
			return false;
		}
		bool flag = false;
		for (int i = 0; i < cachedInventory.Count; i++)
		{
			if (!(cachedInventory[i].itemId == itemId))
			{
				continue;
			}
			ItemStack itemStack = cachedInventory[i];
			if (itemStack.count < count)
			{
				return false;
			}
			itemStack.RemoveCount(count);
			flag = true;
			if (itemStack.count <= 0)
			{
				cachedInventory.RemoveAt(i);
				break;
			}
			cachedInventory.RemoveAt(i);
			cachedInventory.Insert(i, itemStack);
			break;
		}
		if (flag)
		{
			OnInventoryChanged?.Invoke();
			UpdateDebugDisplay();
		}
		return flag;
	}

	[Server]
	private void ServerValidateInventory()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ServerValidateInventory()' called when server was not active");
			return;
		}
		List<uint> list = new List<uint>();
		foreach (uint palletNetId in palletNetIds)
		{
			if (!NetworkServer.spawned.TryGetValue(palletNetId, out var value) || value == null || value.GetComponent<T_Pallet>() == null)
			{
				list.Add(palletNetId);
			}
		}
		bool flag = list.Count > 0;
		foreach (uint item in list)
		{
			palletNetIds.Remove(item);
			palletIdSet.Remove(item);
			Debug.Log($"[Warehouse] Validation - Stale palet temizlendi: {item}");
		}
		if (zoneTrigger != null)
		{
			zoneTrigger.ValidatePalletReferences();
		}
		if (flag)
		{
			ServerRecalculateInventory();
		}
	}

	[Server]
	public void ServerRecalculateInventory()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ServerRecalculateInventory()' called when server was not active");
			return;
		}
		cachedInventory.Clear();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (uint palletNetId in palletNetIds)
		{
			if (!NetworkServer.spawned.TryGetValue(palletNetId, out var value))
			{
				continue;
			}
			T_Pallet component = value.GetComponent<T_Pallet>();
			if (!(component != null) || component.IsEmpty)
			{
				continue;
			}
			string paletItemId = component.PaletItemId;
			int paletItemCount = component.PaletItemCount;
			if (!string.IsNullOrEmpty(paletItemId) && paletItemCount > 0)
			{
				if (dictionary.ContainsKey(paletItemId))
				{
					dictionary[paletItemId] += paletItemCount;
				}
				else
				{
					dictionary[paletItemId] = paletItemCount;
				}
			}
		}
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			cachedInventory.Add(new ItemStack(item.Key, item.Value));
		}
		OnInventoryChanged?.Invoke();
		UpdateDebugDisplay();
		Debug.Log($"[Warehouse] Inventory recalculated - {cachedInventory.Count} item types, " + $"{TotalItemCount} total items");
	}

	private void OnPalletNetIdsChanged(SyncList<uint>.Operation op, int index, uint oldValue, uint newValue)
	{
		switch (op)
		{
		case SyncList<uint>.Operation.OP_ADD:
			palletIdSet.Add(newValue);
			break;
		case SyncList<uint>.Operation.OP_REMOVEAT:
			palletIdSet.Remove(oldValue);
			break;
		case SyncList<uint>.Operation.OP_CLEAR:
			palletIdSet.Clear();
			break;
		case SyncList<uint>.Operation.OP_SET:
			palletIdSet.Remove(oldValue);
			palletIdSet.Add(newValue);
			break;
		}
		UpdateDebugDisplay();
	}

	private void OnCachedInventoryChanged(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
		if (!base.isServer)
		{
			RebuildLocalCache();
		}
		RecalculateCounters();
		UpdateDebugDisplay();
		OnInventoryChanged?.Invoke();
	}

	private void RecalculateCounters()
	{
		int num = 0;
		int num2 = 0;
		foreach (ItemStack item in cachedInventory)
		{
			if (item != null && item.IsValid())
			{
				num += item.count;
				num2++;
			}
		}
		_cachedTotalItemCount = num;
		_cachedUniqueItemTypes = num2;
	}

	private void RebuildLocalCache()
	{
		inventoryCache.Clear();
		foreach (ItemStack item in cachedInventory)
		{
			if (item != null && item.IsValid())
			{
				if (inventoryCache.ContainsKey(item.itemId))
				{
					inventoryCache[item.itemId] += item.count;
				}
				else
				{
					inventoryCache[item.itemId] = item.count;
				}
			}
		}
		UpdateDebugDisplay();
	}

	private void UpdateDebugDisplay()
	{
		_palletCountDisplay = PalletCount;
		_totalItemCountDisplay = TotalItemCount;
		_uniqueItemTypesDisplay = UniqueItemTypes;
		_inventoryDisplay.Clear();
		foreach (ItemStack item in cachedInventory)
		{
			if (item != null && item.IsValid())
			{
				_inventoryDisplay.Add($"{item.itemId}: {item.count}");
			}
		}
	}

	public Dictionary<string, int> GetInventory()
	{
		if (base.isServer)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			{
				foreach (ItemStack item in cachedInventory)
				{
					if (item != null && item.IsValid())
					{
						dictionary[item.itemId] = item.count;
					}
				}
				return dictionary;
			}
		}
		return new Dictionary<string, int>(inventoryCache);
	}

	public int GetItemCount(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return 0;
		}
		if (base.isServer)
		{
			foreach (ItemStack item in cachedInventory)
			{
				if (item != null && item.itemId == itemId)
				{
					return item.count;
				}
			}
			return 0;
		}
		if (!inventoryCache.TryGetValue(itemId, out var value))
		{
			return 0;
		}
		return value;
	}

	public int GetItemCount(T_ItemSO itemSO)
	{
		if (itemSO == null)
		{
			return 0;
		}
		return GetItemCount(itemSO.GetItemID());
	}

	public bool ContainsPallet(uint palletNetId)
	{
		return palletIdSet.Contains(palletNetId);
	}

	public bool ContainsPallet(T_Pallet pallet)
	{
		if (pallet == null)
		{
			return false;
		}
		return palletIdSet.Contains(pallet.netId);
	}

	[Server]
	public List<T_Pallet> GetPalletsInWarehouse()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.List`1<T_Pallet> T_Warehouse::GetPalletsInWarehouse()' called when server was not active");
			return null;
		}
		List<T_Pallet> list = new List<T_Pallet>();
		foreach (uint palletNetId in palletNetIds)
		{
			if (NetworkServer.spawned.TryGetValue(palletNetId, out var value))
			{
				T_Pallet component = value.GetComponent<T_Pallet>();
				if (component != null)
				{
					list.Add(component);
				}
			}
		}
		return list;
	}

	[Server]
	public void ClearWarehouse()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Warehouse::ClearWarehouse()' called when server was not active");
			return;
		}
		palletNetIds.Clear();
		palletIdSet.Clear();
		cachedInventory.Clear();
		OnInventoryChanged?.Invoke();
		UpdateDebugDisplay();
		Debug.Log("[Warehouse] Warehouse cleared");
	}

	public List<WarehouseItemInfo> GetAllWarehouseItems()
	{
		List<WarehouseItemInfo> list = new List<WarehouseItemInfo>();
		if (base.isServer)
		{
			foreach (ItemStack item in cachedInventory)
			{
				if (item != null && item.IsValid())
				{
					T_ItemSO itemSO = ItemSOManager.Instance?.GetItemSOById(item.itemId);
					list.Add(new WarehouseItemInfo(item.itemId, itemSO, item.count));
				}
			}
		}
		else
		{
			foreach (KeyValuePair<string, int> item2 in inventoryCache)
			{
				if (!string.IsNullOrEmpty(item2.Key) && item2.Value > 0)
				{
					T_ItemSO itemSO2 = ItemSOManager.Instance?.GetItemSOById(item2.Key);
					list.Add(new WarehouseItemInfo(item2.Key, itemSO2, item2.Value));
				}
			}
		}
		return list;
	}

	public void AdminAddItems(string itemId, int count)
	{
		if (!string.IsNullOrEmpty(itemId) && count > 0)
		{
			if (base.isServer)
			{
				AddItemsToCache(itemId, count);
				Debug.Log($"[Warehouse-Admin] {count}x {itemId} eklendi (cache only)");
			}
			else
			{
				CmdAdminAddItems(itemId, count);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAdminAddItems(string itemId, int count)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAdminAddItems__String__Int32(itemId, count);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_Warehouse::CmdAdminAddItems(System.String,System.Int32)", -1077934004, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public T_Warehouse()
	{
		InitSyncObject(palletNetIds);
		InitSyncObject(cachedInventory);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAdminAddItems__String__Int32(string itemId, int count)
	{
		AddItemsToCache(itemId, count);
		Debug.Log($"[Warehouse-Admin] {count}x {itemId} eklendi (cache only)");
	}

	protected static void InvokeUserCode_CmdAdminAddItems__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAdminAddItems called on client.");
		}
		else
		{
			((T_Warehouse)obj).UserCode_CmdAdminAddItems__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	static T_Warehouse()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Warehouse), "System.Void T_Warehouse::CmdAdminAddItems(System.String,System.Int32)", InvokeUserCode_CmdAdminAddItems__String__Int32, requiresAuthority: false);
	}
}
