using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class StorageManager : NetworkBehaviour, IGameSave
{
	[Header("Storage Settings")]
	[Tooltip("Depolama listesi - Oyun içinden server(host) + client ürün ekleyebilir")]
	private SyncList<ItemStack> storedItemStacks = new SyncList<ItemStack>();

	private Dictionary<string, int> itemCounts = new Dictionary<string, int>();

	[Header("Storage Info (Runtime)")]
	[Tooltip("Toplam item sayısı - Play Mode'da güncellenir")]
	[SerializeField]
	private int _itemCountDisplay;

	[Tooltip("Benzersiz item türü sayısı - Play Mode'da güncellenir")]
	[SerializeField]
	private int _uniqueItemCountDisplay;

	[Header("Network")]
	private bool isInitialized;

	[Header("Operation Queue")]
	private Queue<PendingStorageOperation> pendingOperations = new Queue<PendingStorageOperation>();

	private bool isProcessingOperation;

	[Header("Events")]
	public UnityEvent<T_ItemSO, int> OnItemAdded;

	public UnityEvent<T_ItemSO, int> OnItemRemoved;

	public UnityEvent OnStorageChanged;

	private int _cachedTotalItemCount;

	private int _cachedUniqueItemCount;

	public int ItemCount => _cachedTotalItemCount;

	public int UniqueItemCount => _cachedUniqueItemCount;

	public SyncList<ItemStack> StoredItemStacks => storedItemStacks;

	public Dictionary<string, int> ItemCounts => new Dictionary<string, int>(itemCounts);

	public string SaveID => "storage-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(StorageSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	private void Awake()
	{
		SyncList<ItemStack> syncList = storedItemStacks;
		syncList.Callback = (Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>)Delegate.Combine(syncList.Callback, new Action<SyncList<ItemStack>.Operation, int, ItemStack, ItemStack>(OnItemStacksChanged));
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		isInitialized = true;
		SaveLoadManager.Subscribe(this, 30);
		Debug.Log("[StorageManager] SaveLoadManager'a kayıt olundu");
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		SaveLoadManager.Unsubscribe(this);
		Debug.Log("[StorageManager] SaveLoadManager'dan çıkıldı");
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		isInitialized = true;
		UpdateItemCounts();
		UpdateEditorDisplay();
	}

	private void OnItemStacksChanged(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
		if (!base.isServer)
		{
			UpdateItemCounts();
		}
		else
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
		UpdateEditorDisplay();
		OnStorageChanged?.Invoke();
	}

	private void UpdateItemCounts()
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
		UpdateEditorDisplay();
		Debug.Log($"StorageManager: {_cachedUniqueItemCount} benzersiz item türü, toplam {_cachedTotalItemCount} item client'ta güncellendi");
	}

	private void UpdateEditorDisplay()
	{
		_itemCountDisplay = ItemCount;
		_uniqueItemCountDisplay = UniqueItemCount;
	}

	public void RequestAddItem(T_ItemSO item, int count = 1)
	{
		if (item == null || string.IsNullOrEmpty(item.GetItemID()))
		{
			Debug.LogWarning("StorageManager: RequestAddItem - Item veya ItemID null!");
			return;
		}
		if (count <= 0)
		{
			Debug.LogWarning($"StorageManager: RequestAddItem - Geçersiz count: {count}");
			return;
		}
		string itemID = item.GetItemID();
		uint requesterNetId = 0u;
		if (NetworkClient.localPlayer != null)
		{
			requesterNetId = NetworkClient.localPlayer.netId;
		}
		if (base.isServer)
		{
			NetworkConnectionToClient localConnection = NetworkServer.localConnection;
			if (localConnection == null)
			{
				Debug.LogWarning("StorageManager: RequestAddItem - Server connection bulunamadı!");
				return;
			}
			PendingStorageOperation item2 = new PendingStorageOperation(localConnection, PendingStorageOperation.OperationType.Add, itemID, count, requesterNetId);
			pendingOperations.Enqueue(item2);
			Debug.Log($"StorageManager: Ürün ekleme isteği queue'ya eklendi (Server). Item: {item.Name}, Count: {count}, Queue uzunluğu: {pendingOperations.Count}");
			if (!isProcessingOperation)
			{
				ProcessNextOperation();
			}
		}
		else
		{
			CmdRequestAddItem(itemID, count, requesterNetId);
			Debug.Log($"StorageManager: Ürün ekleme isteği gönderildi (Client). Item: {item.Name}, Count: {count}");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAddItem(string itemId, int count, uint requesterNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAddItem__String__Int32__UInt32__NetworkConnectionToClient(itemId, count, requesterNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		writer.WriteVarUInt(requesterNetId);
		SendCommandInternal("System.Void StorageManager::CmdRequestAddItem(System.String,System.Int32,System.UInt32,Mirror.NetworkConnectionToClient)", -672101402, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void RequestAddItemsFromSack(T_Sack sack)
	{
		if (sack == null)
		{
			Debug.LogWarning("StorageManager: RequestAddItemsFromSack - Sack null!");
			return;
		}
		uint requesterNetId = 0u;
		if (NetworkClient.localPlayer != null)
		{
			requesterNetId = NetworkClient.localPlayer.netId;
		}
		uint num = sack.netId;
		if (num == 0)
		{
			Debug.LogWarning("StorageManager: RequestAddItemsFromSack - Sack NetId geçersiz!");
		}
		else if (base.isServer)
		{
			NetworkConnectionToClient localConnection = NetworkServer.localConnection;
			if (localConnection == null)
			{
				Debug.LogWarning("StorageManager: RequestAddItemsFromSack - Server connection bulunamadı!");
				return;
			}
			PendingStorageOperation item = new PendingStorageOperation(localConnection, PendingStorageOperation.OperationType.AddItems, num, requesterNetId);
			pendingOperations.Enqueue(item);
			Debug.Log($"StorageManager: Sack'ten ürün ekleme isteği queue'ya eklendi (Server). Sack NetId: {num}, Queue uzunluğu: {pendingOperations.Count}");
			if (!isProcessingOperation)
			{
				ProcessNextOperation();
			}
		}
		else
		{
			CmdRequestAddItemsFromSack(num, requesterNetId);
			Debug.Log($"StorageManager: Sack'ten ürün ekleme isteği gönderildi (Client). Sack NetId: {num}");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAddItemsFromSack(uint sackNetId, uint requesterNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAddItemsFromSack__UInt32__UInt32__NetworkConnectionToClient(sackNetId, requesterNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		writer.WriteVarUInt(requesterNetId);
		SendCommandInternal("System.Void StorageManager::CmdRequestAddItemsFromSack(System.UInt32,System.UInt32,Mirror.NetworkConnectionToClient)", -961748762, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void RequestAddItems(Dictionary<string, int> itemCounts)
	{
		if (itemCounts == null || itemCounts.Count == 0)
		{
			Debug.LogWarning("StorageManager: RequestAddItems - ItemCounts dictionary boş veya null!");
			return;
		}
		uint requesterNetId = 0u;
		if (NetworkClient.localPlayer != null)
		{
			requesterNetId = NetworkClient.localPlayer.netId;
		}
		string[] array = new string[itemCounts.Count];
		int[] array2 = new int[itemCounts.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> itemCount in itemCounts)
		{
			array[num] = itemCount.Key;
			array2[num] = itemCount.Value;
			num++;
		}
		if (base.isServer)
		{
			if (NetworkServer.localConnection == null)
			{
				Debug.LogWarning("StorageManager: RequestAddItems - Server connection bulunamadı!");
			}
			else
			{
				ServerAddItems(itemCounts);
			}
		}
		else
		{
			CmdRequestAddItems(array, array2, requesterNetId);
			Debug.Log($"StorageManager: Dictionary'den ürün ekleme isteği gönderildi (Client). Item türü sayısı: {itemCounts.Count}");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAddItems(string[] itemIds, int[] counts, uint requesterNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAddItems__String_005B_005D__Int32_005B_005D__UInt32__NetworkConnectionToClient(itemIds, counts, requesterNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002EString_005B_005D(writer, itemIds);
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, counts);
		writer.WriteVarUInt(requesterNetId);
		SendCommandInternal("System.Void StorageManager::CmdRequestAddItems(System.String[],System.Int32[],System.UInt32,Mirror.NetworkConnectionToClient)", 1455078455, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void RequestRemoveItem(T_ItemSO item, int count = 0)
	{
		if (item == null || string.IsNullOrEmpty(item.GetItemID()))
		{
			Debug.LogWarning("StorageManager: RequestRemoveItem - Item veya ItemID null!");
			return;
		}
		string itemID = item.GetItemID();
		if (count == 0)
		{
			count = 1;
		}
		uint requesterNetId = 0u;
		if (NetworkClient.localPlayer != null)
		{
			requesterNetId = NetworkClient.localPlayer.netId;
		}
		if (base.isServer)
		{
			NetworkConnectionToClient localConnection = NetworkServer.localConnection;
			if (localConnection == null)
			{
				Debug.LogWarning("StorageManager: RequestRemoveItem - Server connection bulunamadı!");
				return;
			}
			PendingStorageOperation item2 = new PendingStorageOperation(localConnection, PendingStorageOperation.OperationType.Remove, itemID, count, requesterNetId);
			pendingOperations.Enqueue(item2);
			string arg = ((count == -1) ? "Tüm adet" : count.ToString());
			Debug.Log($"StorageManager: Ürün çıkarma isteği queue'ya eklendi (Server). Item: {item.Name}, Count: {arg}, Queue uzunluğu: {pendingOperations.Count}");
			if (!isProcessingOperation)
			{
				ProcessNextOperation();
			}
		}
		else
		{
			CmdRequestRemoveItem(itemID, count, requesterNetId);
			string text = ((count == -1) ? "Tüm adet" : count.ToString());
			Debug.Log("StorageManager: Ürün çıkarma isteği gönderildi (Client). Item: " + item.Name + ", Count: " + text);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestRemoveItem(string itemId, int count, uint requesterNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestRemoveItem__String__Int32__UInt32__NetworkConnectionToClient(itemId, count, requesterNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		writer.WriteVarUInt(requesterNetId);
		SendCommandInternal("System.Void StorageManager::CmdRequestRemoveItem(System.String,System.Int32,System.UInt32,Mirror.NetworkConnectionToClient)", 1158255813, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ProcessNextOperation()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::ProcessNextOperation()' called when server was not active");
			return;
		}
		if (pendingOperations.Count == 0)
		{
			isProcessingOperation = false;
			return;
		}
		isProcessingOperation = true;
		PendingStorageOperation pendingStorageOperation = pendingOperations.Dequeue();
		Debug.Log($"StorageManager: İşlem işleniyor. İstek yapan: {pendingStorageOperation.requester.connectionId}, İşlem türü: {pendingStorageOperation.operationType}, ItemId: {pendingStorageOperation.itemId}, Count: {pendingStorageOperation.count}");
		switch (pendingStorageOperation.operationType)
		{
		case PendingStorageOperation.OperationType.Add:
			ServerAddItem(pendingStorageOperation.itemId, pendingStorageOperation.count);
			break;
		case PendingStorageOperation.OperationType.Remove:
			ServerRemoveItem(pendingStorageOperation.itemId, pendingStorageOperation.count);
			break;
		case PendingStorageOperation.OperationType.AddItems:
			ServerAddItemsFromSack(pendingStorageOperation.sackNetId);
			break;
		default:
			Debug.LogWarning($"StorageManager: Bilinmeyen işlem türü: {pendingStorageOperation.operationType}");
			break;
		}
		ProcessNextOperation();
	}

	[Server]
	private void ServerAddItem(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::ServerAddItem(System.String,System.Int32)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(itemId) || count <= 0)
		{
			Debug.LogWarning($"StorageManager: ServerAddItem - Geçersiz parametreler! ItemId: {itemId}, Count: {count}");
			return;
		}
		T_ItemSO t_ItemSO = ResolveItem(itemId);
		if (t_ItemSO == null)
		{
			Debug.LogWarning("StorageManager: ServerAddItem - Item resolve edilemedi! ItemId: " + itemId);
			return;
		}
		bool flag = false;
		for (int i = 0; i < storedItemStacks.Count; i++)
		{
			if (storedItemStacks[i].itemId == itemId)
			{
				ItemStack itemStack = storedItemStacks[i];
				itemStack.AddCount(count);
				storedItemStacks.RemoveAt(i);
				storedItemStacks.Insert(i, itemStack);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			storedItemStacks.Add(new ItemStack(itemId, count));
		}
		for (int j = 0; j < count; j++)
		{
			OnItemAdded?.Invoke(t_ItemSO, count);
		}
		Debug.Log($"StorageManager: {count} adet '{t_ItemSO.Name}' eklendi. Yeni toplam: {GetItemCount(t_ItemSO)}");
	}

	[Server]
	private void ServerAddItemsFromSack(uint sackNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::ServerAddItemsFromSack(System.UInt32)' called when server was not active");
			return;
		}
		if (sackNetId == 0)
		{
			Debug.LogWarning($"StorageManager: ServerAddItemsFromSack - Geçersiz Sack NetId: {sackNetId}");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(sackNetId, out var value))
		{
			Debug.LogWarning($"StorageManager: ServerAddItemsFromSack - Sack NetId ({sackNetId}) bulunamadı!");
			return;
		}
		T_Sack component = value.GetComponent<T_Sack>();
		if (component == null)
		{
			Debug.LogWarning("StorageManager: ServerAddItemsFromSack - Bulunan obje T_Sack değil!");
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			Debug.LogWarning("StorageManager: ServerAddItemsFromSack - Sack boş!");
			return;
		}
		ServerAddItems(storedItemCounts);
		Debug.Log($"StorageManager: Sack'ten {storedItemCounts.Values.Sum()} item eklendi. Sack NetId: {sackNetId}");
	}

	[Server]
	private void ServerAddItems(Dictionary<string, int> itemCountsToAdd)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::ServerAddItems(System.Collections.Generic.Dictionary`2<System.String,System.Int32>)' called when server was not active");
			return;
		}
		if (itemCountsToAdd == null || itemCountsToAdd.Count == 0)
		{
			Debug.LogWarning("StorageManager: ServerAddItems - ItemCounts dictionary boş veya null!");
			return;
		}
		int num = 0;
		foreach (KeyValuePair<string, int> item in itemCountsToAdd)
		{
			string key = item.Key;
			int value = item.Value;
			if (value <= 0 || string.IsNullOrEmpty(key))
			{
				continue;
			}
			T_ItemSO t_ItemSO = ResolveItem(key);
			if (t_ItemSO == null)
			{
				Debug.LogWarning("StorageManager: ServerAddItems - Item resolve edilemedi! ItemId: " + key);
				continue;
			}
			bool flag = false;
			for (int i = 0; i < storedItemStacks.Count; i++)
			{
				if (storedItemStacks[i].itemId == key)
				{
					ItemStack itemStack = storedItemStacks[i];
					itemStack.AddCount(value);
					storedItemStacks.RemoveAt(i);
					storedItemStacks.Insert(i, itemStack);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				storedItemStacks.Add(new ItemStack(key, value));
			}
			for (int j = 0; j < value; j++)
			{
				OnItemAdded?.Invoke(t_ItemSO, value);
			}
			num += value;
		}
		Debug.Log($"StorageManager: {itemCountsToAdd.Count} farklı item türü, toplam {num} item eklendi.");
	}

	[Server]
	private void ServerRemoveItem(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::ServerRemoveItem(System.String,System.Int32)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("StorageManager: ServerRemoveItem - Geçersiz ItemId: " + itemId);
			return;
		}
		T_ItemSO t_ItemSO = ResolveItem(itemId);
		if (t_ItemSO == null)
		{
			Debug.LogWarning("StorageManager: ServerRemoveItem - Item resolve edilemedi! ItemId: " + itemId);
			return;
		}
		for (int i = 0; i < storedItemStacks.Count; i++)
		{
			if (!(storedItemStacks[i].itemId == itemId))
			{
				continue;
			}
			ItemStack itemStack = storedItemStacks[i];
			if (itemStack.count <= 0)
			{
				Debug.LogWarning("StorageManager: Item '" + t_ItemSO.Name + "' stack'i zaten boş!");
				return;
			}
			int num = ((count == -1) ? itemStack.count : Mathf.Min(count, itemStack.count));
			itemStack.RemoveCount(num);
			if (itemStack.count <= 0)
			{
				storedItemStacks.RemoveAt(i);
			}
			else
			{
				storedItemStacks.RemoveAt(i);
				storedItemStacks.Insert(i, itemStack);
			}
			for (int j = 0; j < num; j++)
			{
				OnItemRemoved?.Invoke(t_ItemSO, num);
			}
			Debug.Log($"StorageManager: {num} adet '{t_ItemSO.Name}' çıkarıldı. Kalan: {GetItemCount(t_ItemSO)}");
			return;
		}
		Debug.LogWarning("StorageManager: Çıkarılmak istenen item '" + t_ItemSO.Name + "' depolamada bulunamadı!");
	}

	private T_ItemSO ResolveItem(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetItemSOById(itemId);
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == itemId);
		}
		Debug.LogWarning("StorageManager: ResolveItem - ItemSOManager ve T_ItemAreaSpawner bulunamadı! ItemId: " + itemId);
		return null;
	}

	public int GetItemCount(T_ItemSO itemSO)
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

	public Dictionary<string, int> GetStoredItemCounts()
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
		if (itemCounts == null || itemCounts.Count == 0)
		{
			Debug.LogWarning("StorageManager: Client'ta itemCounts boş, storedItemStacks'ten direkt okuyorum...");
			UpdateItemCounts();
			if (itemCounts == null || itemCounts.Count == 0)
			{
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				foreach (ItemStack storedItemStack2 in storedItemStacks)
				{
					if (storedItemStack2 != null && storedItemStack2.IsValid())
					{
						if (dictionary2.ContainsKey(storedItemStack2.itemId))
						{
							dictionary2[storedItemStack2.itemId] += storedItemStack2.count;
						}
						else
						{
							dictionary2[storedItemStack2.itemId] = storedItemStack2.count;
						}
					}
				}
				Debug.Log($"StorageManager: Client'ta storedItemStacks'ten {dictionary2.Count} item türü bulundu.");
				return dictionary2;
			}
		}
		return new Dictionary<string, int>(itemCounts);
	}

	[Server]
	public void Clear()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StorageManager::Clear()' called when server was not active");
			return;
		}
		storedItemStacks.Clear();
		OnStorageChanged?.Invoke();
		Debug.Log("StorageManager: Depolama temizlendi!");
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			Debug.Log("[StorageManager] Client - save atlanıyor");
			return new StorageSaveData();
		}
		StorageSaveData storageSaveData = new StorageSaveData(storedItemStacks);
		Debug.Log($"[StorageManager] Save - {storageSaveData.itemStacks.Count} item stack kaydedildi");
		return storageSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is StorageSaveData storageSaveData))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[StorageManager] Client - load atlanıyor, network üzerinden senkronize olacak");
			return Task.CompletedTask;
		}
		if (storageSaveData.itemStacks == null || storageSaveData.itemStacks.Count == 0)
		{
			Debug.Log("[StorageManager] Load - Kaydedilmiş item yok.");
			return Task.CompletedTask;
		}
		storedItemStacks.Clear();
		foreach (ItemStack itemStack in storageSaveData.itemStacks)
		{
			if (itemStack != null && itemStack.IsValid())
			{
				storedItemStacks.Add(new ItemStack(itemStack.itemId, itemStack.count));
			}
		}
		Debug.Log($"[StorageManager] Load - {storedItemStacks.Count} item stack yüklendi");
		OnStorageChanged?.Invoke();
		return Task.CompletedTask;
	}

	public StorageManager()
	{
		InitSyncObject(storedItemStacks);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestAddItem__String__Int32__UInt32__NetworkConnectionToClient(string itemId, int count, uint requesterNetId, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("StorageManager: CmdRequestAddItem - sender null!");
			return;
		}
		if (string.IsNullOrEmpty(itemId) || count <= 0)
		{
			Debug.LogWarning($"StorageManager: CmdRequestAddItem - Geçersiz parametreler! ItemId: {itemId}, Count: {count}");
			return;
		}
		PendingStorageOperation item = new PendingStorageOperation(sender, PendingStorageOperation.OperationType.Add, itemId, count, requesterNetId);
		pendingOperations.Enqueue(item);
		Debug.Log($"StorageManager: Ürün ekleme isteği queue'ya eklendi. İstek yapan: {sender.connectionId}, ItemId: {itemId}, Count: {count}, Queue uzunluğu: {pendingOperations.Count}");
		if (!isProcessingOperation)
		{
			ProcessNextOperation();
		}
	}

	protected static void InvokeUserCode_CmdRequestAddItem__String__Int32__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAddItem called on client.");
		}
		else
		{
			((StorageManager)obj).UserCode_CmdRequestAddItem__String__Int32__UInt32__NetworkConnectionToClient(reader.ReadString(), reader.ReadVarInt(), reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestAddItemsFromSack__UInt32__UInt32__NetworkConnectionToClient(uint sackNetId, uint requesterNetId, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("StorageManager: CmdRequestAddItemsFromSack - sender null!");
			return;
		}
		if (sackNetId == 0)
		{
			Debug.LogWarning($"StorageManager: CmdRequestAddItemsFromSack - Geçersiz Sack NetId: {sackNetId}");
			return;
		}
		PendingStorageOperation item = new PendingStorageOperation(sender, PendingStorageOperation.OperationType.AddItems, sackNetId, requesterNetId);
		pendingOperations.Enqueue(item);
		Debug.Log($"StorageManager: Sack'ten ürün ekleme isteği queue'ya eklendi. İstek yapan: {sender.connectionId}, Sack NetId: {sackNetId}, Queue uzunluğu: {pendingOperations.Count}");
		if (!isProcessingOperation)
		{
			ProcessNextOperation();
		}
	}

	protected static void InvokeUserCode_CmdRequestAddItemsFromSack__UInt32__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAddItemsFromSack called on client.");
		}
		else
		{
			((StorageManager)obj).UserCode_CmdRequestAddItemsFromSack__UInt32__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestAddItems__String_005B_005D__Int32_005B_005D__UInt32__NetworkConnectionToClient(string[] itemIds, int[] counts, uint requesterNetId, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("StorageManager: CmdRequestAddItems - sender null!");
			return;
		}
		if (itemIds == null || counts == null || itemIds.Length == 0 || counts.Length == 0)
		{
			Debug.LogWarning($"StorageManager: CmdRequestAddItems - Geçersiz parametreler! ItemIds: {((itemIds != null) ? itemIds.Length : 0)}, Counts: {((counts != null) ? counts.Length : 0)}");
			return;
		}
		if (itemIds.Length != counts.Length)
		{
			Debug.LogWarning($"StorageManager: CmdRequestAddItems - Array uzunlukları eşit değil! ItemIds: {itemIds.Length}, Counts: {counts.Length}");
			return;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < itemIds.Length; i++)
		{
			if (!string.IsNullOrEmpty(itemIds[i]) && counts[i] > 0)
			{
				if (dictionary.ContainsKey(itemIds[i]))
				{
					dictionary[itemIds[i]] += counts[i];
				}
				else
				{
					dictionary[itemIds[i]] = counts[i];
				}
			}
		}
		if (dictionary.Count == 0)
		{
			Debug.LogWarning("StorageManager: CmdRequestAddItems - Geçerli item bulunamadı!");
		}
		else
		{
			ServerAddItems(dictionary);
		}
	}

	protected static void InvokeUserCode_CmdRequestAddItems__String_005B_005D__Int32_005B_005D__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAddItems called on client.");
		}
		else
		{
			((StorageManager)obj).UserCode_CmdRequestAddItems__String_005B_005D__Int32_005B_005D__UInt32__NetworkConnectionToClient(GeneratedNetworkCode._Read_System_002EString_005B_005D(reader), GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader), reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestRemoveItem__String__Int32__UInt32__NetworkConnectionToClient(string itemId, int count, uint requesterNetId, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("StorageManager: CmdRequestRemoveItem - sender null!");
			return;
		}
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("StorageManager: CmdRequestRemoveItem - Geçersiz ItemId: " + itemId);
			return;
		}
		if (count == 0)
		{
			count = 1;
		}
		PendingStorageOperation item = new PendingStorageOperation(sender, PendingStorageOperation.OperationType.Remove, itemId, count, requesterNetId);
		pendingOperations.Enqueue(item);
		string text = ((count == -1) ? "Tüm adet" : count.ToString());
		Debug.Log($"StorageManager: Ürün çıkarma isteği queue'ya eklendi. İstek yapan: {sender.connectionId}, ItemId: {itemId}, Count: {text}, Queue uzunluğu: {pendingOperations.Count}");
		if (!isProcessingOperation)
		{
			ProcessNextOperation();
		}
	}

	protected static void InvokeUserCode_CmdRequestRemoveItem__String__Int32__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestRemoveItem called on client.");
		}
		else
		{
			((StorageManager)obj).UserCode_CmdRequestRemoveItem__String__Int32__UInt32__NetworkConnectionToClient(reader.ReadString(), reader.ReadVarInt(), reader.ReadVarUInt(), senderConnection);
		}
	}

	static StorageManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(StorageManager), "System.Void StorageManager::CmdRequestAddItem(System.String,System.Int32,System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestAddItem__String__Int32__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StorageManager), "System.Void StorageManager::CmdRequestAddItemsFromSack(System.UInt32,System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestAddItemsFromSack__UInt32__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StorageManager), "System.Void StorageManager::CmdRequestAddItems(System.String[],System.Int32[],System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestAddItems__String_005B_005D__Int32_005B_005D__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(StorageManager), "System.Void StorageManager::CmdRequestRemoveItem(System.String,System.Int32,System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestRemoveItem__String__Int32__UInt32__NetworkConnectionToClient, requiresAuthority: false);
	}
}
