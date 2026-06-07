using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_Truck : ItemContainerBase, IGameSave
{
	[Header("Rigidbody (for Save/Load)")]
	[SerializeField]
	private Rigidbody rb;

	[Header("Vehicle Network")]
	[SerializeField]
	private SCC_Network sccNetwork;

	[Header("Truck Settings")]
	public int baseTotalCapacity = 1000;

	[SyncVar(hook = "OnTotalCapacityChanged")]
	private int _totalCapacity;

	public List<int> totalCapacityLevels = new List<int>();

	[SyncVar]
	public int currentTotalCapacityIndex;

	[Header("Current State")]
	[SyncVar(hook = "OnCurrentItemCountChanged")]
	private int _currentItemCount;

	[SyncVar(hook = "OnSackCountChanged")]
	private int _sackCount;

	private List<SackData> storedSacks = new List<SackData>();

	[Header("Visual Fill Objects")]
	public List<GameObject> fillVisualObjects = new List<GameObject>();

	[Header("Sack Spawn")]
	[Tooltip("Çuval prefab'ı - Truck'tan item alındığında spawn edilecek çuval objesi (boşsa T_Bag'den alınır)")]
	[SerializeField]
	private GameObject sackPrefab;

	[Header("Interaction")]
	[Tooltip("Interactable referansı - HandleTruckInteraction için kullanılacak Interactable component'i (manuel atanır)")]
	[SerializeField]
	private Interactable caseInteractable;

	[Header("Network")]
	private bool isInitialized;

	[Header("Item Request Queue")]
	private Queue<PendingItemRequest> pendingRequests = new Queue<PendingItemRequest>();

	private bool isProcessingRequest;

	private bool _clientWaitingForSack;

	private Coroutine _clientWaitingTimeout;

	private static readonly WaitForSeconds _waitAutoPickup;

	private static readonly WaitForSeconds _waitClientTimeout;

	private HashSet<int> _pendingConnectionIds = new HashSet<int>();

	[Header("Events")]
	public UnityEvent OnSackAdded;

	private GameManager gameManager;

	public Action<int, int> _Mirror_SyncVarHookDelegate__totalCapacity;

	public Action<int, int> _Mirror_SyncVarHookDelegate__currentItemCount;

	public Action<int, int> _Mirror_SyncVarHookDelegate__sackCount;

	public override bool SupportsCapacity => true;

	public override int CurrentItemCount => _currentItemCount;

	public override int TotalCapacity => _totalCapacity;

	public int SackCount => _sackCount;

	public string SaveID => "truck";

	public bool IsShared => false;

	public Type SaveType => typeof(TruckSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public int Network_totalCapacity
	{
		get
		{
			return _totalCapacity;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _totalCapacity, 1uL, _Mirror_SyncVarHookDelegate__totalCapacity);
		}
	}

	public int NetworkcurrentTotalCapacityIndex
	{
		get
		{
			return currentTotalCapacityIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentTotalCapacityIndex, 2uL, null);
		}
	}

	public int Network_currentItemCount
	{
		get
		{
			return _currentItemCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentItemCount, 4uL, _Mirror_SyncVarHookDelegate__currentItemCount);
		}
	}

	public int Network_sackCount
	{
		get
		{
			return _sackCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _sackCount, 8uL, _Mirror_SyncVarHookDelegate__sackCount);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (gameManager == null)
		{
			gameManager = GameManager.Instance;
		}
		if (totalCapacityLevels != null && totalCapacityLevels.Count > 0)
		{
			ApplyTotalCapacityFromIndex();
		}
		else
		{
			Network_totalCapacity = baseTotalCapacity;
		}
		Network_currentItemCount = 0;
		Network_sackCount = 0;
		storedSacks.Clear();
		UpdateFillVisuals();
	}

	protected override void OnServerStarted()
	{
		isInitialized = true;
		UpdateFillVisuals();
	}

	protected override void OnClientStarted()
	{
		isInitialized = true;
		UpdateFillVisuals();
	}

	protected override void OnItemStacksUpdated(SyncList<ItemStack>.Operation op, int index, ItemStack oldStack, ItemStack newStack)
	{
		UpdateFillVisuals();
	}

	protected override void OnItemCountsUpdated()
	{
		UnityEngine.Debug.Log($"T_Truck: {itemCounts.Count} benzersiz item türü, toplam {ItemCount} item client'ta güncellendi");
	}

	public float GetFillRatio()
	{
		if (TotalCapacity <= 0)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)_currentItemCount / (float)_totalCapacity);
	}

	public float GetFillPercentage()
	{
		return GetFillRatio() * 100f;
	}

	private void ApplyTotalCapacityFromIndex()
	{
		if (totalCapacityLevels != null && totalCapacityLevels.Count != 0)
		{
			NetworkcurrentTotalCapacityIndex = Mathf.Clamp(currentTotalCapacityIndex, 0, totalCapacityLevels.Count - 1);
			int network_totalCapacity = Mathf.Max(1, totalCapacityLevels[currentTotalCapacityIndex]);
			Network_totalCapacity = network_totalCapacity;
		}
	}

	[Server]
	public void SetTotalCapacityIndex(int index)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::SetTotalCapacityIndex(System.Int32)' called when server was not active");
			return;
		}
		NetworkcurrentTotalCapacityIndex = index;
		ApplyTotalCapacityFromIndex();
	}

	[Server]
	public void NextTotalCapacityLevel()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::NextTotalCapacityLevel()' called when server was not active");
		}
		else
		{
			SetTotalCapacityIndex(currentTotalCapacityIndex + 1);
		}
	}

	[Server]
	public void PrevTotalCapacityLevel()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::PrevTotalCapacityLevel()' called when server was not active");
		}
		else
		{
			SetTotalCapacityIndex(currentTotalCapacityIndex - 1);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdSetTotalCapacityIndex(int index, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetTotalCapacityIndex__Int32__NetworkConnectionToClient(index, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void T_Truck::CmdSetTotalCapacityIndex(System.Int32,Mirror.NetworkConnectionToClient)", 1500787433, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdNextTotalCapacityLevel(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdNextTotalCapacityLevel__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Truck::CmdNextTotalCapacityLevel(Mirror.NetworkConnectionToClient)", 123453957, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdPrevTotalCapacityLevel(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdPrevTotalCapacityLevel__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Truck::CmdPrevTotalCapacityLevel(Mirror.NetworkConnectionToClient)", -1834127351, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnTotalCapacityChanged(int oldValue, int newValue)
	{
		UpdateFillVisuals();
	}

	private void OnCurrentItemCountChanged(int oldValue, int newValue)
	{
		UpdateFillVisuals();
	}

	private void OnSackCountChanged(int oldValue, int newValue)
	{
		UpdateFillVisuals();
	}

	private void UpdateFillVisuals()
	{
		if (fillVisualObjects == null || fillVisualObjects.Count == 0)
		{
			return;
		}
		int count = fillVisualObjects.Count;
		int num = Mathf.Clamp(_sackCount, 0, count);
		for (int i = 0; i < count; i++)
		{
			if (fillVisualObjects[i] != null)
			{
				fillVisualObjects[i].SetActive(i < num);
			}
		}
		UnityEngine.Debug.Log($"T_Truck: Sack sayısı: {_sackCount}, Item sayısı: {_currentItemCount}/{_totalCapacity}, Aktif görsel: {num}/{count}");
	}

	public bool CanAddItem(T_ItemSO item)
	{
		if (item == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: Item null, eklenemez!");
			return false;
		}
		if (_currentItemCount + 1 > _totalCapacity)
		{
			UnityEngine.Debug.Log($"T_Truck: Item eklenemez! Mevcut: {_currentItemCount}, Max: {_totalCapacity}");
			return false;
		}
		return true;
	}

	public bool CanAddItems(Dictionary<string, int> itemCountsToAdd)
	{
		if (itemCountsToAdd == null || itemCountsToAdd.Count == 0)
		{
			return false;
		}
		int num = itemCountsToAdd.Values.Sum();
		if (_currentItemCount + num > _totalCapacity)
		{
			UnityEngine.Debug.Log($"T_Truck: Item listesi eklenemez! Mevcut: {_currentItemCount}, Eklenecek: {num}, Max: {_totalCapacity}");
			return false;
		}
		return true;
	}

	[Server]
	public bool AddItem(T_ItemSO item)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::AddItem(T_ItemSO)' called when server was not active");
			return default(bool);
		}
		if (!CanAddItem(item))
		{
			if (gameManager != null && gameManager.notificationManager != null)
			{
				UnityEngine.Debug.LogWarning("T_Truck: Kamyon dolu, item eklenemedi!");
			}
			return false;
		}
		if (item == null || string.IsNullOrEmpty(item.GetItemID()))
		{
			UnityEngine.Debug.LogWarning("T_Truck: Item veya ItemID null!");
			return false;
		}
		string itemID = item.GetItemID();
		Network_currentItemCount = _currentItemCount + 1;
		bool flag = false;
		for (int i = 0; i < storedItemStacks.Count; i++)
		{
			if (storedItemStacks[i].itemId == itemID)
			{
				ItemStack itemStack = storedItemStacks[i];
				itemStack.AddCount(1);
				storedItemStacks.RemoveAt(i);
				storedItemStacks.Insert(i, itemStack);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			storedItemStacks.Add(new ItemStack(itemID, 1));
		}
		UpdateFillVisuals();
		UnityEngine.Debug.Log($"T_Truck: Item eklendi: {item.Name}, Mevcut: {_currentItemCount}/{_totalCapacity}");
		return true;
	}

	[Server]
	public bool AddItems(Dictionary<string, int> itemCountsToAdd)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::AddItems(System.Collections.Generic.Dictionary`2<System.String,System.Int32>)' called when server was not active");
			return default(bool);
		}
		if (itemCountsToAdd == null || itemCountsToAdd.Count == 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: Eklenmek istenen item dictionary'si boş!");
			return false;
		}
		if (!CanAddItems(itemCountsToAdd))
		{
			if (gameManager != null && gameManager.notificationManager != null)
			{
				UnityEngine.Debug.LogWarning("T_Truck: Kamyon dolu, item listesi eklenemedi!");
			}
			return false;
		}
		foreach (KeyValuePair<string, int> item in itemCountsToAdd)
		{
			string key = item.Key;
			int value = item.Value;
			if (value <= 0)
			{
				continue;
			}
			Network_currentItemCount = _currentItemCount + value;
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
		}
		int num = itemCountsToAdd.Values.Sum();
		UpdateFillVisuals();
		UnityEngine.Debug.Log($"T_Truck: {num} item eklendi, Mevcut: {_currentItemCount}/{_totalCapacity}");
		return true;
	}

	[Server]
	public bool RemoveItem(T_ItemSO item)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::RemoveItem(T_ItemSO)' called when server was not active");
			return default(bool);
		}
		if (item == null || string.IsNullOrEmpty(item.GetItemID()))
		{
			UnityEngine.Debug.LogWarning("T_Truck: Kaldırılmak istenen item veya ItemID null!");
			return false;
		}
		string itemID = item.GetItemID();
		for (int i = 0; i < storedItemStacks.Count; i++)
		{
			if (storedItemStacks[i].itemId == itemID)
			{
				ItemStack itemStack = storedItemStacks[i];
				if (itemStack.count <= 0)
				{
					UnityEngine.Debug.LogWarning("T_Truck: Item '" + item.Name + "' stack'i zaten boş!");
					return false;
				}
				itemStack.RemoveCount(1);
				Network_currentItemCount = Mathf.Max(0, _currentItemCount - 1);
				if (itemStack.count <= 0)
				{
					storedItemStacks.RemoveAt(i);
				}
				else
				{
					storedItemStacks.RemoveAt(i);
					storedItemStacks.Insert(i, itemStack);
				}
				UpdateFillVisuals();
				UnityEngine.Debug.Log($"T_Truck: Item kaldırıldı: {item.Name}, Mevcut: {_currentItemCount}/{_totalCapacity}");
				return true;
			}
		}
		UnityEngine.Debug.LogWarning("T_Truck: Kaldırılmak istenen item '" + item.Name + "' kamyonda bulunamadı!");
		return false;
	}

	[Server]
	public bool RemoveItemBySO(T_ItemSO itemSO)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::RemoveItemBySO(T_ItemSO)' called when server was not active");
			return default(bool);
		}
		return RemoveItem(itemSO);
	}

	[Server]
	public bool RemoveItemCount(T_ItemSO item, int count)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::RemoveItemCount(T_ItemSO,System.Int32)' called when server was not active");
			return default(bool);
		}
		if (item == null || string.IsNullOrEmpty(item.GetItemID()) || count <= 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: RemoveItemCount - Geçersiz parametreler!");
			return false;
		}
		string itemID = item.GetItemID();
		for (int i = 0; i < storedItemStacks.Count; i++)
		{
			if (storedItemStacks[i].itemId == itemID)
			{
				ItemStack itemStack = storedItemStacks[i];
				if (itemStack.count < count)
				{
					UnityEngine.Debug.LogWarning($"T_Truck: Yeterli item yok! Mevcut: {itemStack.count}, İstenen: {count}");
					return false;
				}
				itemStack.RemoveCount(count);
				Network_currentItemCount = Mathf.Max(0, _currentItemCount - count);
				if (itemStack.count <= 0)
				{
					storedItemStacks.RemoveAt(i);
				}
				else
				{
					storedItemStacks.RemoveAt(i);
					storedItemStacks.Insert(i, itemStack);
				}
				UpdateFillVisuals();
				UnityEngine.Debug.Log($"T_Truck: {count} adet '{item.Name}' kaldırıldı, Mevcut: {_currentItemCount}/{_totalCapacity}");
				return true;
			}
		}
		UnityEngine.Debug.LogWarning("T_Truck: Item '" + item.Name + "' kamyonda bulunamadı!");
		return false;
	}

	[Server]
	public void UpgradeTotalCapacity(int additionalCapacity)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::UpgradeTotalCapacity(System.Int32)' called when server was not active");
			return;
		}
		if (additionalCapacity <= 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: Upgrade değeri 0'dan büyük olmalı!");
			return;
		}
		Network_totalCapacity = _totalCapacity + additionalCapacity;
		UnityEngine.Debug.Log($"T_Truck: Toplam kapasite upgrade edildi! Yeni max: {_totalCapacity}");
	}

	[Server]
	public void SetTotalCapacity(int newTotalCapacity)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::SetTotalCapacity(System.Int32)' called when server was not active");
			return;
		}
		if (newTotalCapacity <= 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: Toplam kapasite 0'dan büyük olmalı!");
			return;
		}
		Network_totalCapacity = newTotalCapacity;
		if (_currentItemCount > _totalCapacity)
		{
			UnityEngine.Debug.LogWarning($"T_Truck: Dikkat! Mevcut item sayısı ({_currentItemCount}) toplam kapasiteyi ({_totalCapacity}) aşıyor!");
		}
	}

	[Server]
	public void Clear()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::Clear()' called when server was not active");
			return;
		}
		ServerClear();
		storedSacks.Clear();
		Network_currentItemCount = 0;
		Network_sackCount = 0;
		UpdateFillVisuals();
		UnityEngine.Debug.Log("T_Truck: Kamyon temizlendi!");
	}

	public bool HasSpaceFor(int count)
	{
		return _currentItemCount + count <= _totalCapacity;
	}

	public bool CanAddSack(int sackItemCount)
	{
		if (_currentItemCount + sackItemCount > _totalCapacity)
		{
			UnityEngine.Debug.Log($"T_Truck: Sack eklenemez! Item kapasitesi dolu. Mevcut: {_currentItemCount}, Sack: {sackItemCount}, Max: {_totalCapacity}");
			return false;
		}
		if (fillVisualObjects != null && fillVisualObjects.Count > 0 && _sackCount >= fillVisualObjects.Count)
		{
			UnityEngine.Debug.Log($"T_Truck: Sack eklenemez! Sack kapasitesi dolu. Mevcut sack: {_sackCount}, Max: {fillVisualObjects.Count}");
			return false;
		}
		return true;
	}

	[Server]
	public bool TransferItemsFromSack(T_Sack sack, NetworkConnectionToClient sender = null)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::TransferItemsFromSack(T_Sack,Mirror.NetworkConnectionToClient)' called when server was not active");
			return default(bool);
		}
		if (sack == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TransferItemsFromSack - Sack null!");
			return false;
		}
		UnityEngine.Debug.Log($"T_Truck: TransferItemsFromSack çağrıldı. Sack NetId: {sack.netId}, SackCount önce: {_sackCount}, Caller: {new StackTrace().GetFrame(1)?.GetMethod()?.Name}");
		Dictionary<string, int> storedItemCounts = sack.GetStoredItemCounts();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TransferItemsFromSack - Sack boş!");
			return false;
		}
		int num = storedItemCounts.Values.Sum();
		if (!CanAddSack(num))
		{
			UnityEngine.Debug.LogWarning("T_Truck: Kamyon dolu, sack eklenemedi!");
			if (sender != null)
			{
				if (_currentItemCount + num > _totalCapacity)
				{
					TargetRpcTruckFull(sender);
				}
				else if (fillVisualObjects != null && fillVisualObjects.Count > 0 && _sackCount >= fillVisualObjects.Count)
				{
					TargetRpcTruckSackSlotFull(sender);
				}
			}
			else if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
			{
				string translation = LocalizationManager.GetTranslation((_currentItemCount + num > _totalCapacity) ? "Notification_TruckFullKey" : "Notification_TruckSackSlotFullKey");
				GameManager.Instance.notificationManager.ShowNotification(translation);
			}
			return false;
		}
		SackData item = new SackData(storedItemCounts);
		storedSacks.Add(item);
		foreach (KeyValuePair<string, int> item2 in storedItemCounts)
		{
			string key = item2.Key;
			int value = item2.Value;
			if (value <= 0)
			{
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
		}
		Network_currentItemCount = _currentItemCount + num;
		Network_sackCount = _sackCount + 1;
		UpdateFillVisuals();
		UnityEngine.Debug.Log($"T_Truck: Sack eklendi! ({num} item). Toplam sack: {_sackCount}, Toplam item: {_currentItemCount}/{_totalCapacity}");
		return true;
	}

	public void TryTransferSackFromPlayer()
	{
		if (GameManager.Instance == null || GameManager.Instance.localEquipments == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TryTransferSackFromPlayer - GameManager veya localEquipments null!");
			return;
		}
		GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
		if (pickupItem == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TryTransferSackFromPlayer - Player'ın elinde item yok!");
			return;
		}
		T_Sack component = pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TryTransferSackFromPlayer - Elindeki item T_Sack değil!");
		}
		else if (component.ItemCount == 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: TryTransferSackFromPlayer - Sack boş!");
		}
		else if (base.isServer)
		{
			component.SetHasBeenPickedUp();
			if (TransferItemsFromSack(component))
			{
				GameManager.Instance.localEquipments.ClearPickupItem();
				GameManager.Instance.localEquipments.TryUnequip();
				NetworkServer.Destroy(pickupItem);
				RpcPlaySackPlacedEffects();
				TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutSackInVehicle);
			}
		}
		else
		{
			CmdTransferItemsFromSack(component.netId);
			TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutSackInVehicle);
		}
	}

	public bool CanTransferSackFromPlayer()
	{
		if (GameManager.Instance == null || GameManager.Instance.localEquipments == null)
		{
			return false;
		}
		GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
		if (pickupItem == null)
		{
			return false;
		}
		T_Sack component = pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return false;
		}
		if (component.ItemCount == 0)
		{
			return false;
		}
		if (!CanAddSack(component.ItemCount))
		{
			return false;
		}
		return true;
	}

	[Command(requiresAuthority = false)]
	public void CmdTransferItemsFromSack(uint sackNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(sackNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendCommandInternal("System.Void T_Truck::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", 1700872359, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcClearPlayerPickupItem(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Truck::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", 1194399296, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcTruckFull(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Truck::TargetRpcTruckFull(Mirror.NetworkConnectionToClient)", 1439847822, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcTruckSackSlotFull(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Truck::TargetRpcTruckSackSlotFull(Mirror.NetworkConnectionToClient)", 258212956, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void HandleTruckInteraction()
	{
		if (caseInteractable == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: HandleTruckInteraction - caseInteractable atanmamış! Inspector'dan atayın.");
			return;
		}
		switch (caseInteractable.currentPrimaryState)
		{
		case PrimaryState.Pickup:
			RequestItemsFromTruck();
			break;
		case PrimaryState.Place:
			TryTransferSackFromPlayer();
			break;
		default:
			UnityEngine.Debug.LogWarning($"T_Truck: HandleTruckInteraction - Desteklenmeyen PrimaryState: {caseInteractable.currentPrimaryState}");
			break;
		}
	}

	public void RequestItemsFromTruck()
	{
		if (_sackCount <= 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: RequestItemsFromTruck - Kamyonda sack yok!");
			return;
		}
		if (_clientWaitingForSack)
		{
			UnityEngine.Debug.Log("T_Truck: RequestItemsFromTruck - Zaten bir sack isteği bekleniyor, spam engellendi.");
			return;
		}
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null && pickupItem.GetComponent<T_Sack>() != null)
			{
				UnityEngine.Debug.Log("T_Truck: RequestItemsFromTruck - Elde zaten bir sack var, yeni sack alınamaz.");
				return;
			}
		}
		_clientWaitingForSack = true;
		if (_clientWaitingTimeout != null)
		{
			StopCoroutine(_clientWaitingTimeout);
		}
		_clientWaitingTimeout = StartCoroutine(ClientWaitingTimeout());
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
				UnityEngine.Debug.LogWarning("T_Truck: RequestItemsFromTruck - Server connection bulunamadı!");
				_clientWaitingForSack = false;
				return;
			}
			if (_pendingConnectionIds.Contains(localConnection.connectionId))
			{
				UnityEngine.Debug.Log("T_Truck: RequestItemsFromTruck - Host connection zaten queue'da, spam engellendi.");
				_clientWaitingForSack = false;
				return;
			}
			_pendingConnectionIds.Add(localConnection.connectionId);
			PendingItemRequest item = new PendingItemRequest(localConnection, requesterNetId);
			pendingRequests.Enqueue(item);
			UnityEngine.Debug.Log($"T_Truck: Sack alma isteği queue'ya eklendi (Server). Queue uzunluğu: {pendingRequests.Count}");
			if (!isProcessingRequest)
			{
				ProcessNextRequest();
			}
		}
		else
		{
			CmdRequestItemsFromTruck(requesterNetId);
			UnityEngine.Debug.Log("T_Truck: Sack alma isteği gönderildi (Client).");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestItemsFromTruck(uint requesterNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestItemsFromTruck__UInt32__NetworkConnectionToClient(requesterNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(requesterNetId);
		SendCommandInternal("System.Void T_Truck::CmdRequestItemsFromTruck(System.UInt32,Mirror.NetworkConnectionToClient)", 2055565082, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ProcessNextRequest()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::ProcessNextRequest()' called when server was not active");
			return;
		}
		if (pendingRequests.Count == 0)
		{
			isProcessingRequest = false;
			return;
		}
		isProcessingRequest = true;
		PendingItemRequest pendingItemRequest = pendingRequests.Dequeue();
		UnityEngine.Debug.Log($"T_Truck: Sack isteği işleniyor. İstek yapan: {pendingItemRequest.requester.connectionId}, Queue kalan: {pendingRequests.Count}");
		if (storedSacks.Count == 0)
		{
			UnityEngine.Debug.LogWarning($"T_Truck: Kamyonda sack yok! İstek yapan: {pendingItemRequest.requester.connectionId}");
			_pendingConnectionIds.Remove(pendingItemRequest.requester.connectionId);
			ProcessNextRequest();
			return;
		}
		bool flag = IsPlayerHoldingItem(pendingItemRequest.requester);
		UnityEngine.Debug.Log($"T_Truck: IsPlayerHoldingItem={flag}, İstek yapan: {pendingItemRequest.requester.connectionId}");
		if (flag)
		{
			UnityEngine.Debug.LogWarning($"T_Truck: Oyuncu zaten elde item tutuyor! İstek yapan: {pendingItemRequest.requester.connectionId}");
			_pendingConnectionIds.Remove(pendingItemRequest.requester.connectionId);
			ProcessNextRequest();
			return;
		}
		int index = storedSacks.Count - 1;
		SackData sackData = storedSacks[index];
		storedSacks.RemoveAt(index);
		Dictionary<string, int> itemsToRemove = sackData.ToDictionary();
		RemoveItemsFromTruck(itemsToRemove);
		Vector3 sackSpawnPosition = GetSackSpawnPosition();
		GameObject lastActiveFillVisual = GetLastActiveFillVisual();
		Network_sackCount = Mathf.Max(0, _sackCount - 1);
		if (lastActiveFillVisual != null)
		{
			int fillVisualIndex = fillVisualObjects.IndexOf(lastActiveFillVisual);
			lastActiveFillVisual.SetActive(value: true);
			RpcKeepFillVisualActive(fillVisualIndex);
		}
		Dictionary<string, int> items = sackData.ToDictionary();
		SpawnSackWithItems(items, pendingItemRequest.requester, sackSpawnPosition, lastActiveFillVisual);
		UnityEngine.Debug.Log($"T_Truck: Son sack verildi ({sackData.totalItemCount} item). Kalan sack: {_sackCount}, Kalan item: {_currentItemCount}");
	}

	[Server]
	private bool IsPlayerHoldingItem(NetworkConnectionToClient connection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean T_Truck::IsPlayerHoldingItem(Mirror.NetworkConnectionToClient)' called when server was not active");
			return default(bool);
		}
		if (connection == null || connection.identity == null)
		{
			return false;
		}
		foreach (NetworkIdentity item in connection.owned)
		{
			if (!(item == null) && !(item == connection.identity))
			{
				T_Pickup component = item.GetComponent<T_Pickup>();
				if (component != null && component.hasOwner && component.col != null && !component.col.enabled)
				{
					return true;
				}
			}
		}
		return false;
	}

	[Server]
	private T_Bag FindPlayerBag(NetworkConnectionToClient connection, uint requesterNetId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'T_Bag T_Truck::FindPlayerBag(Mirror.NetworkConnectionToClient,System.UInt32)' called when server was not active");
			return null;
		}
		T_Bag t_Bag = null;
		if (connection != null && connection.identity != null)
		{
			t_Bag = connection.identity.GetComponent<T_Bag>();
			if (t_Bag == null && connection.identity.transform.parent != null)
			{
				t_Bag = connection.identity.transform.parent.GetComponentInChildren<T_Bag>();
			}
		}
		if (t_Bag == null && requesterNetId != 0 && NetworkServer.spawned.TryGetValue(requesterNetId, out var value))
		{
			t_Bag = value.GetComponent<T_Bag>();
			if (t_Bag == null)
			{
				t_Bag = value.GetComponentInChildren<T_Bag>();
			}
		}
		if (t_Bag == null)
		{
			GamePlayer[] array = UnityEngine.Object.FindObjectsByType<GamePlayer>(FindObjectsSortMode.None);
			foreach (GamePlayer gamePlayer in array)
			{
				if (connection != null && gamePlayer.connectionToClient == connection)
				{
					t_Bag = gamePlayer.GetComponent<T_Bag>();
					if (t_Bag == null)
					{
						t_Bag = gamePlayer.GetComponentInChildren<T_Bag>();
					}
					break;
				}
			}
		}
		return t_Bag;
	}

	[Server]
	private void RemoveItemsFromTruck(Dictionary<string, int> itemsToRemove)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::RemoveItemsFromTruck(System.Collections.Generic.Dictionary`2<System.String,System.Int32>)' called when server was not active");
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
						Network_currentItemCount = Mathf.Max(0, _currentItemCount - num2);
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
			UpdateFillVisuals();
		}
	}

	[Server]
	private Vector3 GetSackSpawnPosition()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'UnityEngine.Vector3 T_Truck::GetSackSpawnPosition()' called when server was not active");
			return default(Vector3);
		}
		if (fillVisualObjects != null && fillVisualObjects.Count > 0)
		{
			for (int num = fillVisualObjects.Count - 1; num >= 0; num--)
			{
				if (fillVisualObjects[num] != null && fillVisualObjects[num].activeSelf)
				{
					return fillVisualObjects[num].transform.position + Vector3.up * 0.5f;
				}
			}
		}
		return base.transform.position + Vector3.up * 0.5f;
	}

	private GameObject GetLastActiveFillVisual()
	{
		if (fillVisualObjects == null || fillVisualObjects.Count == 0)
		{
			return null;
		}
		for (int num = fillVisualObjects.Count - 1; num >= 0; num--)
		{
			if (fillVisualObjects[num] != null && fillVisualObjects[num].activeSelf)
			{
				return fillVisualObjects[num];
			}
		}
		return null;
	}

	[Server]
	private void SpawnSackWithItems(Dictionary<string, int> items, NetworkConnectionToClient requester, Vector3 spawnPos, GameObject fillVisualToHide = null)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::SpawnSackWithItems(System.Collections.Generic.Dictionary`2<System.String,System.Int32>,Mirror.NetworkConnectionToClient,UnityEngine.Vector3,UnityEngine.GameObject)' called when server was not active");
			return;
		}
		if (items == null || items.Count == 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: SpawnSackWithItems - Item listesi boş!");
			return;
		}
		GameObject gameObject = sackPrefab;
		if (gameObject == null)
		{
			T_Bag t_Bag = UnityEngine.Object.FindFirstObjectByType<T_Bag>();
			if (t_Bag != null)
			{
				FieldInfo field = t_Bag.GetType().GetField("sackPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field != null)
				{
					gameObject = field.GetValue(t_Bag) as GameObject;
				}
			}
		}
		if (gameObject == null)
		{
			UnityEngine.Debug.LogError("T_Truck: Sack prefab bulunamadı! T_Bag'den de alınamadı.");
			return;
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, spawnPos, Quaternion.identity);
		T_Sack component = gameObject2.GetComponent<T_Sack>();
		if (component == null)
		{
			UnityEngine.Debug.LogError("T_Truck: Spawn edilen sack'te T_Sack component'i bulunamadı!");
			UnityEngine.Object.Destroy(gameObject2);
			return;
		}
		component.SetAsAutoPickupSack();
		NetworkServer.Spawn(gameObject2);
		List<T_ItemSO> list = new List<T_ItemSO>();
		if ((bool)ItemSOManager.Instance)
		{
			foreach (KeyValuePair<string, int> kvp in items)
			{
				T_ItemSO t_ItemSO = ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == kvp.Key);
				if (t_ItemSO != null)
				{
					for (int num = 0; num < kvp.Value; num++)
					{
						list.Add(t_ItemSO);
					}
				}
			}
		}
		if (list.Count > T_Sack.MaxItemsPerSack)
		{
			list = list.GetRange(0, T_Sack.MaxItemsPerSack);
		}
		component.ServerSetItems(list);
		UnityEngine.Debug.Log($"T_Truck: Sack spawn edildi ve {list.Count} item eklendi. İstek yapan: {requester.connectionId}");
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.ReturnToFactory, TutorialSubStepType.TakeItemFromTrunk);
		}
		StartCoroutine(DelayedAutoPickup(gameObject2, requester, fillVisualToHide));
	}

	private IEnumerator DelayedAutoPickup(GameObject sackInstance, NetworkConnectionToClient requester, GameObject fillVisualToHide)
	{
		int connectionId = requester?.connectionId ?? (-1);
		yield return _waitAutoPickup;
		if (sackInstance == null || requester == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: DelayedAutoPickup - Sack instance veya requester null!");
			HideFillVisual(fillVisualToHide);
			_pendingConnectionIds.Remove(connectionId);
			ProcessNextRequest();
			yield break;
		}
		T_Pickup component = sackInstance.GetComponent<T_Pickup>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: DelayedAutoPickup - Sack'te T_Pickup component'i bulunamadı!");
			HideFillVisual(fillVisualToHide);
			_pendingConnectionIds.Remove(connectionId);
			ProcessNextRequest();
			yield break;
		}
		HideFillVisual(fillVisualToHide);
		if (component.HandlePickupOnServer(requester))
		{
			component.RpcPickupResult(requester.connectionId, success: true);
			UnityEngine.Debug.Log($"T_Truck: Server'da auto-pickup başarılı. Requester: {requester.connectionId}, Sack NetId: {component.netId}");
		}
		else
		{
			T_Sack component2 = sackInstance.GetComponent<T_Sack>();
			if (component2 != null)
			{
				TransferItemsFromSack(component2);
			}
			NetworkServer.Destroy(sackInstance);
			UnityEngine.Debug.LogWarning($"T_Truck: Server'da auto-pickup başarısız! Sack truck'a geri eklendi. Requester: {requester.connectionId}");
		}
		RpcNotifySackPickupComplete(requester);
		_pendingConnectionIds.Remove(connectionId);
		UnityEngine.Debug.Log($"T_Truck: DelayedAutoPickup tamamlandı. ConnId: {connectionId}, Queue: {pendingRequests.Count}, StoredSacks: {storedSacks.Count}, SackCount: {_sackCount}");
		ProcessNextRequest();
	}

	[Server]
	private void HideFillVisual(GameObject fillVisual)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::HideFillVisual(UnityEngine.GameObject)' called when server was not active");
		}
		else if (fillVisual != null)
		{
			RpcHideFillVisual(fillVisualObjects.IndexOf(fillVisual));
		}
	}

	[ClientRpc]
	private void RpcKeepFillVisualActive(int fillVisualIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(fillVisualIndex);
		SendRPCInternal("System.Void T_Truck::RpcKeepFillVisualActive(System.Int32)", -1642920745, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideFillVisual(int fillVisualIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(fillVisualIndex);
		SendRPCInternal("System.Void T_Truck::RpcHideFillVisual(System.Int32)", 1567190224, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcNotifySackPickupComplete(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Truck::RpcNotifySackPickupComplete(Mirror.NetworkConnection)", -1956182655, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientWaitingTimeout()
	{
		yield return _waitClientTimeout;
		if (_clientWaitingForSack)
		{
			UnityEngine.Debug.LogWarning("T_Truck: ClientWaitingTimeout - RPC gelmedi, kilit serbest bırakılıyor.");
			_clientWaitingForSack = false;
		}
		_clientWaitingTimeout = null;
	}

	[Server]
	public void RpcPlaySackPlacedEffectsPublic()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Truck::RpcPlaySackPlacedEffectsPublic()' called when server was not active");
		}
		else
		{
			RpcPlaySackPlacedEffects();
		}
	}

	[ClientRpc]
	private void RpcPlaySackPlacedEffects()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Truck::RpcPlaySackPlacedEffects()", -388425113, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 2f);
		if (fillVisualObjects == null || fillVisualObjects.Count <= 0)
		{
			return;
		}
		for (int num = fillVisualObjects.Count - 1; num >= 0; num--)
		{
			if (fillVisualObjects[num] != null && fillVisualObjects[num].activeSelf)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(fillVisualObjects[num].transform.position + Vector3.up * 0.5f, 0.5f);
				break;
			}
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		SaveLoadManager.Subscribe(this, 60);
		if (rb == null)
		{
			rb = GetComponent<Rigidbody>();
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (rb != null)
		{
			SaveLoadGameManager.UnregisterKinematic(rb);
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return new TruckSaveData();
		}
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		if (rb != null)
		{
			position = rb.position;
			rotation = rb.rotation;
		}
		List<SackSaveEntry> list = new List<SackSaveEntry>();
		foreach (SackData storedSack in storedSacks)
		{
			SackSaveEntry sackSaveEntry = new SackSaveEntry();
			sackSaveEntry.items = new List<ItemStackData>(storedSack.items);
			list.Add(sackSaveEntry);
		}
		return new TruckSaveData
		{
			position = position,
			rotation = rotation,
			sacks = list,
			currentItemCount = _currentItemCount,
			totalCapacityIndex = currentTotalCapacityIndex,
			isInDigsite = (sccNetwork != null && sccNetwork.isInDigsite)
		};
	}

	public Task OnLoad(object value)
	{
		if (!(value is TruckSaveData data))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		StartCoroutine(Co_RestoreTruckState(data));
		return Task.CompletedTask;
	}

	private IEnumerator Co_RestoreTruckState(TruckSaveData data)
	{
		UnityEngine.Debug.Log($"[T_Truck] Co_RestoreTruckState başladı. Hedef pozisyon: {data.position}");
		yield return null;
		if (rb == null)
		{
			rb = GetComponent<Rigidbody>();
		}
		if (rb != null)
		{
			SaveLoadGameManager.RegisterKinematicForLoad(rb);
			rb.position = data.position;
			rb.rotation = data.rotation;
			base.transform.SetPositionAndRotation(data.position, data.rotation);
			UnityEngine.Debug.Log($"[T_Truck] Pozisyon restore edildi: {data.position}");
		}
		else
		{
			base.transform.SetPositionAndRotation(data.position, data.rotation);
			UnityEngine.Debug.LogWarning("[T_Truck] Rigidbody bulunamadı, direkt transform kullanıldı");
		}
		storedItemStacks.Clear();
		storedSacks.Clear();
		Network_currentItemCount = 0;
		Network_sackCount = 0;
		if (data.sacks != null && data.sacks.Count > 0)
		{
			foreach (SackSaveEntry sack in data.sacks)
			{
				if (sack.items == null || sack.items.Count == 0)
				{
					continue;
				}
				SackData sackData = new SackData();
				sackData.items = new List<ItemStackData>(sack.items);
				sackData.totalItemCount = 0;
				foreach (ItemStackData item in sack.items)
				{
					if (string.IsNullOrEmpty(item.itemId) || item.count <= 0)
					{
						continue;
					}
					sackData.totalItemCount += item.count;
					bool flag = false;
					for (int i = 0; i < storedItemStacks.Count; i++)
					{
						if (storedItemStacks[i].itemId == item.itemId)
						{
							ItemStack itemStack = storedItemStacks[i];
							itemStack.AddCount(item.count);
							storedItemStacks.RemoveAt(i);
							storedItemStacks.Insert(i, itemStack);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						storedItemStacks.Add(new ItemStack(item.itemId, item.count));
					}
				}
				storedSacks.Add(sackData);
				Network_currentItemCount = _currentItemCount + sackData.totalItemCount;
				Network_sackCount = _sackCount + 1;
			}
		}
		NetworkcurrentTotalCapacityIndex = data.totalCapacityIndex;
		UpdateFillVisuals();
		UnityEngine.Debug.Log($"[T_Truck] Envanter restore edildi: {_sackCount} sack, {_currentItemCount} item");
		if (sccNetwork != null)
		{
			sccNetwork.NetworkisInDigsite = data.isInDigsite;
			UnityEngine.Debug.Log($"[T_Truck] isInDigsite restore edildi: {data.isInDigsite}");
		}
	}

	public T_Truck()
	{
		_Mirror_SyncVarHookDelegate__totalCapacity = OnTotalCapacityChanged;
		_Mirror_SyncVarHookDelegate__currentItemCount = OnCurrentItemCountChanged;
		_Mirror_SyncVarHookDelegate__sackCount = OnSackCountChanged;
	}

	static T_Truck()
	{
		_waitAutoPickup = new WaitForSeconds(0.05f);
		_waitClientTimeout = new WaitForSeconds(1.5f);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Truck), "System.Void T_Truck::CmdSetTotalCapacityIndex(System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSetTotalCapacityIndex__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Truck), "System.Void T_Truck::CmdNextTotalCapacityLevel(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdNextTotalCapacityLevel__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Truck), "System.Void T_Truck::CmdPrevTotalCapacityLevel(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdPrevTotalCapacityLevel__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Truck), "System.Void T_Truck::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Truck), "System.Void T_Truck::CmdRequestItemsFromTruck(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestItemsFromTruck__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::RpcKeepFillVisualActive(System.Int32)", InvokeUserCode_RpcKeepFillVisualActive__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::RpcHideFillVisual(System.Int32)", InvokeUserCode_RpcHideFillVisual__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::RpcPlaySackPlacedEffects()", InvokeUserCode_RpcPlaySackPlacedEffects);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::TargetRpcTruckFull(Mirror.NetworkConnectionToClient)", InvokeUserCode_TargetRpcTruckFull__NetworkConnectionToClient);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::TargetRpcTruckSackSlotFull(Mirror.NetworkConnectionToClient)", InvokeUserCode_TargetRpcTruckSackSlotFull__NetworkConnectionToClient);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Truck), "System.Void T_Truck::RpcNotifySackPickupComplete(Mirror.NetworkConnection)", InvokeUserCode_RpcNotifySackPickupComplete__NetworkConnection);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetTotalCapacityIndex__Int32__NetworkConnectionToClient(int index, NetworkConnectionToClient sender)
	{
		SetTotalCapacityIndex(index);
	}

	protected static void InvokeUserCode_CmdSetTotalCapacityIndex__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetTotalCapacityIndex called on client.");
		}
		else
		{
			((T_Truck)obj).UserCode_CmdSetTotalCapacityIndex__Int32__NetworkConnectionToClient(reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_CmdNextTotalCapacityLevel__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		NextTotalCapacityLevel();
	}

	protected static void InvokeUserCode_CmdNextTotalCapacityLevel__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdNextTotalCapacityLevel called on client.");
		}
		else
		{
			((T_Truck)obj).UserCode_CmdNextTotalCapacityLevel__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdPrevTotalCapacityLevel__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		PrevTotalCapacityLevel();
	}

	protected static void InvokeUserCode_CmdPrevTotalCapacityLevel__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdPrevTotalCapacityLevel called on client.");
		}
		else
		{
			((T_Truck)obj).UserCode_CmdPrevTotalCapacityLevel__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(uint sackNetId, NetworkConnectionToClient sender)
	{
		if (sackNetId == 0)
		{
			UnityEngine.Debug.LogWarning("T_Truck: CmdTransferItemsFromSack - Sack NetId geçersiz!");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(sackNetId, out var value))
		{
			UnityEngine.Debug.LogWarning($"T_Truck: CmdTransferItemsFromSack - Sack NetId ({sackNetId}) bulunamadı!");
			return;
		}
		T_Sack component = value.GetComponent<T_Sack>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: CmdTransferItemsFromSack - Bulunan obje T_Sack değil!");
			return;
		}
		if (component.HasBeenPickedUp)
		{
			UnityEngine.Debug.LogWarning("T_Truck: CmdTransferItemsFromSack - Sack zaten alınmış/transfer edilmiş, işlem engellendi!");
			return;
		}
		component.SetHasBeenPickedUp();
		if (TransferItemsFromSack(component, sender))
		{
			NetworkServer.Destroy(value.gameObject);
			RpcPlaySackPlacedEffects();
			if (sender != null)
			{
				RpcClearPlayerPickupItem(sender);
			}
		}
	}

	protected static void InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTransferItemsFromSack called on client.");
		}
		else
		{
			((T_Truck)obj).UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkConnection target)
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC RpcClearPlayerPickupItem called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_RpcClearPlayerPickupItem__NetworkConnection(null);
		}
	}

	protected void UserCode_TargetRpcTruckFull__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
		{
			string translation = LocalizationManager.GetTranslation("Notification_TruckFullKey");
			GameManager.Instance.notificationManager.ShowNotification(translation);
		}
	}

	protected static void InvokeUserCode_TargetRpcTruckFull__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcTruckFull called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_TargetRpcTruckFull__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_TargetRpcTruckSackSlotFull__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
		{
			string translation = LocalizationManager.GetTranslation("Notification_TruckSackSlotFullKey");
			GameManager.Instance.notificationManager.ShowNotification(translation);
		}
	}

	protected static void InvokeUserCode_TargetRpcTruckSackSlotFull__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcTruckSackSlotFull called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_TargetRpcTruckSackSlotFull__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_CmdRequestItemsFromTruck__UInt32__NetworkConnectionToClient(uint requesterNetId, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			UnityEngine.Debug.LogWarning("T_Truck: CmdRequestItemsFromTruck - sender null!");
			return;
		}
		if (_pendingConnectionIds.Contains(sender.connectionId))
		{
			UnityEngine.Debug.Log($"T_Truck: CmdRequestItemsFromTruck - Connection {sender.connectionId} zaten queue'da, tekrar istek engellendi.");
			return;
		}
		_pendingConnectionIds.Add(sender.connectionId);
		PendingItemRequest item = new PendingItemRequest(sender, requesterNetId);
		pendingRequests.Enqueue(item);
		UnityEngine.Debug.Log($"T_Truck: Sack alma isteği queue'ya eklendi. İstek yapan: {sender.connectionId}, Queue uzunluğu: {pendingRequests.Count}");
		if (!isProcessingRequest)
		{
			ProcessNextRequest();
		}
	}

	protected static void InvokeUserCode_CmdRequestItemsFromTruck__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestItemsFromTruck called on client.");
		}
		else
		{
			((T_Truck)obj).UserCode_CmdRequestItemsFromTruck__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_RpcKeepFillVisualActive__Int32(int fillVisualIndex)
	{
		if (fillVisualIndex >= 0 && fillVisualIndex < fillVisualObjects.Count && fillVisualObjects[fillVisualIndex] != null)
		{
			fillVisualObjects[fillVisualIndex].SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_RpcKeepFillVisualActive__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcKeepFillVisualActive called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_RpcKeepFillVisualActive__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcHideFillVisual__Int32(int fillVisualIndex)
	{
		if (fillVisualIndex >= 0 && fillVisualIndex < fillVisualObjects.Count && fillVisualObjects[fillVisualIndex] != null)
		{
			fillVisualObjects[fillVisualIndex].SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_RpcHideFillVisual__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcHideFillVisual called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_RpcHideFillVisual__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcNotifySackPickupComplete__NetworkConnection(NetworkConnection target)
	{
		_clientWaitingForSack = false;
		if (_clientWaitingTimeout != null)
		{
			StopCoroutine(_clientWaitingTimeout);
			_clientWaitingTimeout = null;
		}
		UnityEngine.Debug.Log("T_Truck: RpcNotifySackPickupComplete - Client-side sack bekleme kilidi serbest bırakıldı.");
	}

	protected static void InvokeUserCode_RpcNotifySackPickupComplete__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC RpcNotifySackPickupComplete called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_RpcNotifySackPickupComplete__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcPlaySackPlacedEffects()
	{
		OnSackAdded?.Invoke();
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutSackInVehicle);
	}

	protected static void InvokeUserCode_RpcPlaySackPlacedEffects(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPlaySackPlacedEffects called on server.");
		}
		else
		{
			((T_Truck)obj).UserCode_RpcPlaySackPlacedEffects();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_totalCapacity);
			writer.WriteVarInt(currentTotalCapacityIndex);
			writer.WriteVarInt(_currentItemCount);
			writer.WriteVarInt(_sackCount);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_totalCapacity);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(currentTotalCapacityIndex);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(_currentItemCount);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarInt(_sackCount);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _totalCapacity, _Mirror_SyncVarHookDelegate__totalCapacity, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref currentTotalCapacityIndex, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _currentItemCount, _Mirror_SyncVarHookDelegate__currentItemCount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _sackCount, _Mirror_SyncVarHookDelegate__sackCount, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _totalCapacity, _Mirror_SyncVarHookDelegate__totalCapacity, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentTotalCapacityIndex, null, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentItemCount, _Mirror_SyncVarHookDelegate__currentItemCount, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _sackCount, _Mirror_SyncVarHookDelegate__sackCount, reader.ReadVarInt());
		}
	}
}
