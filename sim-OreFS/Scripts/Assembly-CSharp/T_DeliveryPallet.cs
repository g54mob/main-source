using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using UnityEngine;

public class T_DeliveryPallet : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class DeliveryPalletSaveData
	{
		public string activeContractId;

		public string[] itemIds;

		public int[] itemCounts;

		public int[] maxCounts;
	}

	[Header("References")]
	[Tooltip("Forklift attach/detach için trigger")]
	public GameObject forkliftTrigger;

	[Tooltip("Palet detection trigger (delivery zone için)")]
	public GameObject palletTrigger;

	[Tooltip("Önceden spawn edilmiş görsel objeler (max adet kadar)")]
	[SerializeField]
	private List<GameObject> preSpawnedVisuals = new List<GameObject>();

	[Tooltip("Paletin kabul edebileceği maksimum toplam item sayısı")]
	[SerializeField]
	private int maxItemCount = 40;

	[Header("Placement Validation")]
	[Tooltip("Palet yerleştirme doğrulama ve düzeltme sistemi")]
	[SerializeField]
	private PalletPlacementValidator placementValidator;

	[SyncVar(hook = "OnPalletDataChanged")]
	private DeliveryPalletSyncData _syncData;

	[SyncVar(hook = "OnActiveVisualCountChanged")]
	private int _activeVisualCount;

	[SyncVar]
	private bool _isLifted;

	[SyncVar]
	private string _uniqueId;

	public Action<DeliveryPalletSyncData, DeliveryPalletSyncData> _Mirror_SyncVarHookDelegate__syncData;

	public Action<int, int> _Mirror_SyncVarHookDelegate__activeVisualCount;

	public int MaxItemCount => maxItemCount;

	public string UniqueId => _uniqueId;

	public string ActiveContractId => _syncData.activeContractId;

	public bool IsLifted => _isLifted;

	public bool IsEmpty => _syncData.IsEmpty;

	public int TotalItemCount => _syncData.TotalItemCount;

	public int ActiveVisualCount => _activeVisualCount;

	public int MaterialCount
	{
		get
		{
			string[] itemIds = _syncData.itemIds;
			if (itemIds == null)
			{
				return 0;
			}
			return itemIds.Length;
		}
	}

	public string SaveID => "delivery-pallet-" + _uniqueId;

	public bool IsShared => false;

	public Type SaveType => typeof(DeliveryPalletSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public DeliveryPalletSyncData Network_syncData
	{
		get
		{
			return _syncData;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncData, 1uL, _Mirror_SyncVarHookDelegate__syncData);
		}
	}

	public int Network_activeVisualCount
	{
		get
		{
			return _activeVisualCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _activeVisualCount, 2uL, _Mirror_SyncVarHookDelegate__activeVisualCount);
		}
	}

	public bool Network_isLifted
	{
		get
		{
			return _isLifted;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isLifted, 4uL, null);
		}
	}

	public string Network_uniqueId
	{
		get
		{
			return _uniqueId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _uniqueId, 8uL, null);
		}
	}

	public void SetUniqueId(string id)
	{
		Network_uniqueId = id;
	}

	public int GetItemCount(int index)
	{
		if (_syncData.itemCounts == null || index < 0 || index >= _syncData.itemCounts.Length)
		{
			return 0;
		}
		return _syncData.itemCounts[index];
	}

	public string GetItemId(int index)
	{
		if (_syncData.itemIds == null || index < 0 || index >= _syncData.itemIds.Length)
		{
			return string.Empty;
		}
		return _syncData.itemIds[index];
	}

	public int GetMaxCount(int index)
	{
		if (_syncData.maxCounts == null || index < 0 || index >= _syncData.maxCounts.Length)
		{
			return 0;
		}
		return _syncData.maxCounts[index];
	}

	public bool TryGetMaterialData(int index, out string itemId, out int count, out int maxCount)
	{
		itemId = string.Empty;
		count = 0;
		maxCount = 0;
		if (_syncData.itemIds == null || index < 0 || index >= _syncData.itemIds.Length)
		{
			return false;
		}
		itemId = _syncData.itemIds[index];
		count = _syncData.itemCounts[index];
		maxCount = _syncData.maxCounts[index];
		return true;
	}

	public int GetRemainingCapacity(string itemId)
	{
		if (string.IsNullOrEmpty(itemId) || _syncData.itemIds == null)
		{
			return 0;
		}
		int num = maxItemCount - _syncData.TotalItemCount;
		if (num <= 0)
		{
			return 0;
		}
		for (int i = 0; i < _syncData.itemIds.Length; i++)
		{
			if (_syncData.itemIds[i] == itemId)
			{
				int num2 = _syncData.itemCounts[i];
				return Mathf.Min(_syncData.maxCounts[i] - num2, num);
			}
		}
		return 0;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (string.IsNullOrEmpty(_uniqueId))
		{
			Network_uniqueId = Guid.NewGuid().ToString();
		}
		DynamicObjectSpawner.Instance?.RegisterDeliveryPallet(this);
		SaveLoadManager.Subscribe(this, 50);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		DynamicObjectSpawner.Instance?.UnregisterDeliveryPallet(_uniqueId);
		SaveLoadManager.Unsubscribe(this);
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		UpdateVisuals();
	}

	public void OnPlaced()
	{
		if (placementValidator == null)
		{
			placementValidator = GetComponent<PalletPlacementValidator>();
			Debug.Log("[DeliveryPallet] placementValidator otomatik bulundu: " + ((placementValidator != null) ? "VAR" : "HALA NULL"));
		}
		Debug.Log(string.Format("[DeliveryPallet] OnPlaced BAŞLADI - isServer: {0}, placementValidator: {1}", base.isServer, (placementValidator != null) ? "VAR" : "NULL"));
		if (palletTrigger != null)
		{
			palletTrigger.SetActive(value: true);
		}
		if (forkliftTrigger != null)
		{
			forkliftTrigger.SetActive(value: true);
		}
		if (base.isServer)
		{
			Network_isLifted = false;
			if (placementValidator != null && !placementValidator.HasReferenceHeight)
			{
				placementValidator.SaveReferenceHeight();
				Debug.Log("[DeliveryPallet] Referans yükseklik kaydedildi");
			}
			if (placementValidator != null)
			{
				Debug.Log("[DeliveryPallet] Yamukluk düzeltme uygulanıyor...");
				placementValidator.ApplyPlacementCorrection();
			}
			Debug.Log($"[DeliveryPallet] OnPlaced TAMAMLANDI - NetId: {base.netId}");
		}
	}

	public void OnLifted()
	{
		if (palletTrigger != null)
		{
			palletTrigger.SetActive(value: false);
		}
		if (forkliftTrigger != null)
		{
			forkliftTrigger.SetActive(value: false);
		}
		if (!base.isServer)
		{
			return;
		}
		Network_isLifted = true;
		BuildingObject component = GetComponent<BuildingObject>();
		if (component != null)
		{
			uint targetSocketNetId = component.TargetSocketNetId;
			if (targetSocketNetId != 0 && NetworkServer.spawned.TryGetValue(targetSocketNetId, out var value))
			{
				T_Socket t_Socket = value.GetComponent<T_Socket>();
				if (t_Socket == null)
				{
					t_Socket = value.GetComponentInChildren<T_Socket>();
				}
				if (t_Socket != null)
				{
					t_Socket.OnBuildingRemoved(component.buildingPrefab);
					Debug.Log("[DeliveryPallet] OnLifted - Socket serbest bırakıldı: " + t_Socket.gameObject.name);
				}
			}
		}
		Debug.Log($"[DeliveryPallet] OnLifted - NetId: {base.netId}");
	}

	[Server]
	public void ServerInitialize(string contractId, string[] itemIds, int[] maxCounts)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DeliveryPallet::ServerInitialize(System.String,System.String[],System.Int32[])' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(contractId) || itemIds == null || maxCounts == null)
		{
			Debug.LogWarning("[DeliveryPallet] ServerInitialize - Geçersiz parametreler!");
			return;
		}
		if (itemIds.Length != maxCounts.Length)
		{
			Debug.LogWarning("[DeliveryPallet] ServerInitialize - itemIds ve maxCounts uzunlukları eşleşmiyor!");
			return;
		}
		Network_syncData = new DeliveryPalletSyncData
		{
			activeContractId = contractId,
			itemIds = itemIds,
			itemCounts = new int[itemIds.Length],
			maxCounts = maxCounts
		};
		Debug.Log($"[DeliveryPallet] ServerInitialize - ContractId: {contractId}, Materials: {itemIds.Length}");
	}

	[Server]
	public int ServerAddItem(string itemId, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 T_DeliveryPallet::ServerAddItem(System.String,System.Int32)' called when server was not active");
			return default(int);
		}
		if (string.IsNullOrEmpty(itemId) || amount <= 0)
		{
			return 0;
		}
		if (_syncData.itemIds == null)
		{
			Debug.LogWarning("[DeliveryPallet] ServerAddItem - Palet initialize edilmemiş!");
			return 0;
		}
		int num = -1;
		for (int i = 0; i < _syncData.itemIds.Length; i++)
		{
			if (_syncData.itemIds[i] == itemId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.LogWarning("[DeliveryPallet] ServerAddItem - Material bulunamadı: " + itemId);
			return 0;
		}
		int num2 = _syncData.itemCounts[num];
		int num3 = _syncData.maxCounts[num];
		int a = num3 - num2;
		int b = maxItemCount - _syncData.TotalItemCount;
		int b2 = Mathf.Min(a, b);
		int num4 = Mathf.Min(amount, b2);
		if (num4 <= 0)
		{
			Debug.Log("[DeliveryPallet] ServerAddItem - Material dolu: " + itemId);
			return 0;
		}
		DeliveryPalletSyncData syncData = _syncData;
		syncData.itemCounts = (int[])_syncData.itemCounts.Clone();
		syncData.itemCounts[num] = num2 + num4;
		Network_syncData = syncData;
		Debug.Log($"[DeliveryPallet] ServerAddItem - {itemId}: {num2} -> {num2 + num4} (max: {num3})");
		return num4;
	}

	[Server]
	public Dictionary<string, int> ServerExtractAllItems()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.Dictionary`2<System.String,System.Int32> T_DeliveryPallet::ServerExtractAllItems()' called when server was not active");
			return null;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (_syncData.itemIds != null && _syncData.itemCounts != null)
		{
			for (int i = 0; i < _syncData.itemIds.Length; i++)
			{
				if (_syncData.itemCounts[i] > 0)
				{
					dictionary[_syncData.itemIds[i]] = _syncData.itemCounts[i];
				}
			}
		}
		DeliveryPalletSyncData syncData = _syncData;
		if (syncData.itemCounts != null)
		{
			syncData.itemCounts = new int[syncData.itemCounts.Length];
		}
		Network_syncData = syncData;
		Debug.Log($"[DeliveryPallet] ServerExtractAllItems - {dictionary.Count} material türü extract edildi");
		return dictionary;
	}

	private void OnPalletDataChanged(DeliveryPalletSyncData oldValue, DeliveryPalletSyncData newValue)
	{
		UpdateVisuals();
	}

	private void OnActiveVisualCountChanged(int oldValue, int newValue)
	{
		ApplyVisuals(newValue);
	}

	private void UpdateVisuals()
	{
		if (preSpawnedVisuals != null && preSpawnedVisuals.Count != 0)
		{
			int totalItemCount = _syncData.TotalItemCount;
			float num = (float)totalItemCount / (float)maxItemCount;
			int num2;
			if (totalItemCount <= 0)
			{
				num2 = 0;
			}
			else
			{
				num2 = Mathf.Max(1, Mathf.CeilToInt(num * (float)preSpawnedVisuals.Count));
				num2 = Mathf.Min(num2, preSpawnedVisuals.Count);
			}
			if (base.isServer)
			{
				Network_activeVisualCount = num2;
			}
			ApplyVisuals(num2);
		}
	}

	private void ApplyVisuals(int activeCount)
	{
		if (preSpawnedVisuals == null)
		{
			return;
		}
		for (int i = 0; i < preSpawnedVisuals.Count; i++)
		{
			if (preSpawnedVisuals[i] != null)
			{
				preSpawnedVisuals[i].SetActive(i < activeCount);
			}
		}
		Debug.Log($"[DeliveryPallet] ApplyVisuals - {activeCount}/{preSpawnedVisuals.Count} visual aktif");
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		DeliveryPalletSaveData deliveryPalletSaveData = new DeliveryPalletSaveData
		{
			activeContractId = _syncData.activeContractId,
			itemIds = ((_syncData.itemIds != null) ? ((string[])_syncData.itemIds.Clone()) : null),
			itemCounts = ((_syncData.itemCounts != null) ? ((int[])_syncData.itemCounts.Clone()) : null),
			maxCounts = ((_syncData.maxCounts != null) ? ((int[])_syncData.maxCounts.Clone()) : null)
		};
		Debug.Log($"[T_DeliveryPallet] Save - ID: {_uniqueId}, ContractId: {deliveryPalletSaveData.activeContractId}, TotalItems: {TotalItemCount}");
		return deliveryPalletSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is DeliveryPalletSaveData deliveryPalletSaveData))
		{
			Debug.LogWarning("[T_DeliveryPallet] OnLoad - Invalid data type for delivery pallet: " + _uniqueId);
			return Task.CompletedTask;
		}
		Network_syncData = new DeliveryPalletSyncData
		{
			activeContractId = deliveryPalletSaveData.activeContractId,
			itemIds = deliveryPalletSaveData.itemIds,
			itemCounts = deliveryPalletSaveData.itemCounts,
			maxCounts = deliveryPalletSaveData.maxCounts
		};
		UpdateVisuals();
		Debug.Log($"[T_DeliveryPallet] Load - ID: {_uniqueId}, ContractId: {deliveryPalletSaveData.activeContractId}, TotalItems: {TotalItemCount}");
		return Task.CompletedTask;
	}

	public T_DeliveryPallet()
	{
		_Mirror_SyncVarHookDelegate__syncData = OnPalletDataChanged;
		_Mirror_SyncVarHookDelegate__activeVisualCount = OnActiveVisualCountChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_DeliveryPalletSyncData(writer, _syncData);
			writer.WriteVarInt(_activeVisualCount);
			writer.WriteBool(_isLifted);
			writer.WriteString(_uniqueId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_DeliveryPalletSyncData(writer, _syncData);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_activeVisualCount);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(_isLifted);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteString(_uniqueId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncData, _Mirror_SyncVarHookDelegate__syncData, GeneratedNetworkCode._Read_DeliveryPalletSyncData(reader));
			GeneratedSyncVarDeserialize(ref _activeVisualCount, _Mirror_SyncVarHookDelegate__activeVisualCount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _isLifted, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _uniqueId, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncData, _Mirror_SyncVarHookDelegate__syncData, GeneratedNetworkCode._Read_DeliveryPalletSyncData(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _activeVisualCount, _Mirror_SyncVarHookDelegate__activeVisualCount, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isLifted, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _uniqueId, null, reader.ReadString());
		}
	}
}
