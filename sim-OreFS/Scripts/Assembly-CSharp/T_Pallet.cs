using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using UnityEngine;

public class T_Pallet : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class PalletSaveData
	{
		public string itemId;

		public int itemCount;
	}

	[Header("Pallet Settings")]
	[SerializeField]
	private float paletGenisligi = 2f;

	[SerializeField]
	private float paletDerinligi = 2f;

	[SerializeField]
	private float itemSpacing = 0.1f;

	[SerializeField]
	private float yukseklikArtisi = 0.1f;

	[Tooltip("Item'ların palet üzerindeki maksimum yüksekliği")]
	[SerializeField]
	private float maxItemHeight = 1.5f;

	[Header("References")]
	public GameObject palletTrigger;

	public GameObject forkliftTrigger;

	[SerializeField]
	private Transform visualParent;

	[Header("Leg Colliders")]
	[Tooltip("Palet ayak collider'ları objesi - makine içindeyken kapatılır")]
	[SerializeField]
	private GameObject legCollidersObject;

	[Header("Placement Validation")]
	[Tooltip("Palet yerleştirme doğrulama ve düzeltme sistemi")]
	[SerializeField]
	private PalletPlacementValidator placementValidator;

	[SyncVar(hook = "OnItemIdChanged")]
	private string paletItemId = string.Empty;

	[SyncVar(hook = "OnItemCountChanged")]
	public int paletItemCount;

	[SyncVar]
	private bool isLifted;

	[SyncVar]
	private bool isBeingProcessed;

	private List<GameObject> spawnedVisuals = new List<GameObject>();

	private string _lastVisualItemId;

	private T_ItemSO currentItemSO;

	private int itemsPerRow;

	private int itemsPerColumn;

	[HideInInspector]
	public BuildingObject buildingObject;

	private Interactable _interactable;

	public Action<string, string> _Mirror_SyncVarHookDelegate_paletItemId;

	public Action<int, int> _Mirror_SyncVarHookDelegate_paletItemCount;

	public string PaletItemId => paletItemId;

	public int PaletItemCount => paletItemCount;

	public bool IsEmpty => paletItemCount <= 0;

	public bool IsFull => GetMaxItemCount() <= paletItemCount;

	public bool IsLifted => isLifted;

	public bool IsBeingProcessed => isBeingProcessed;

	private string UniquePalletId
	{
		get
		{
			if (!(buildingObject != null))
			{
				return string.Empty;
			}
			return buildingObject.UniqueBuildingId;
		}
	}

	public string SaveID => "pallet-" + UniquePalletId;

	public bool IsShared => false;

	public Type SaveType => typeof(PalletSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public string NetworkpaletItemId
	{
		get
		{
			return paletItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref paletItemId, 1uL, _Mirror_SyncVarHookDelegate_paletItemId);
		}
	}

	public int NetworkpaletItemCount
	{
		get
		{
			return paletItemCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref paletItemCount, 2uL, _Mirror_SyncVarHookDelegate_paletItemCount);
		}
	}

	public bool NetworkisLifted
	{
		get
		{
			return isLifted;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isLifted, 4uL, null);
		}
	}

	public bool NetworkisBeingProcessed
	{
		get
		{
			return isBeingProcessed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isBeingProcessed, 8uL, null);
		}
	}

	private void Awake()
	{
		if (visualParent == null)
		{
			visualParent = base.transform;
		}
		if (GetComponent<BuildingObject>() != null)
		{
			buildingObject = GetComponent<BuildingObject>();
		}
		_interactable = GetComponent<Interactable>();
		if (_interactable == null)
		{
			_interactable = GetComponentInChildren<Interactable>();
		}
		if (_interactable != null)
		{
			_interactable.RegisterResaleCondition(CheckPalletNotEmptyCondition);
			_interactable.RegisterRelocateCondition(CheckPalletNotEmptyCondition);
			_interactable.RegisterResaleCondition(CheckPalletLiftedCondition);
			_interactable.RegisterRelocateCondition(CheckPalletLiftedCondition);
		}
		Debug.Log($"[Palet] Awake - Genişlik: {paletGenisligi}, Derinlik: {paletDerinligi}, MaxHeight: {maxItemHeight}");
	}

	private string CheckPalletNotEmptyCondition()
	{
		if (!IsEmpty)
		{
			string text = LocalizationManager.GetTranslation("Notification_PalletNotEmpty");
			if (string.IsNullOrEmpty(text))
			{
				text = "Palet boşaltılmalı";
			}
			return text;
		}
		return null;
	}

	private string CheckPalletLiftedCondition()
	{
		if (isLifted)
		{
			string text = LocalizationManager.GetTranslation("Notification_NotAvailableAtThisStage");
			if (string.IsNullOrEmpty(text))
			{
				text = "Bu aşamada kullanılamaz";
			}
			return text;
		}
		return null;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		StartCoroutine(Co_SubscribeToSaveSystem());
		Debug.Log($"[Palet] OnStartServer - ItemId: {paletItemId}, Count: {paletItemCount}");
	}

	private IEnumerator Co_SubscribeToSaveSystem()
	{
		while (buildingObject == null || string.IsNullOrEmpty(buildingObject.UniqueBuildingId))
		{
			yield return null;
		}
		SaveLoadManager.Subscribe(this, 50);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
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
			Debug.Log("[Pallet] placementValidator otomatik bulundu: " + ((placementValidator != null) ? "VAR" : "HALA NULL"));
		}
		Debug.Log(string.Format("[Pallet] OnPlaced BAŞLADI - isServer: {0}, placementValidator: {1}", base.isServer, (placementValidator != null) ? "VAR" : "NULL"));
		palletTrigger.SetActive(value: true);
		forkliftTrigger.SetActive(value: true);
		if (!base.isServer)
		{
			return;
		}
		NetworkisLifted = false;
		if (placementValidator != null && !placementValidator.HasReferenceHeight)
		{
			placementValidator.SaveReferenceHeight();
			Debug.Log("[Pallet] Referans yükseklik kaydedildi");
		}
		bool flag = false;
		Debug.Log("[Pallet] Socket snap kontrolü başlıyor...");
		if (placementValidator != null && placementValidator.TryGetSocketSnap(out var socket))
		{
			Debug.Log("[Pallet] Socket bulundu: " + socket.gameObject.name);
			if (buildingObject != null && socket.GetSocketPosition(buildingObject.buildingPrefab, out var position, out var rotation))
			{
				placementValidator.ApplySocketSnap(position, rotation);
				socket.OnBuildingPlaced(buildingObject.buildingPrefab, base.netId);
				buildingObject.ServerSetSocketReference(socket);
				flag = true;
				Debug.Log("[Pallet] OnPlaced - Socket snap uygulandı: " + socket.gameObject.name);
			}
			else
			{
				Debug.Log("[Pallet] Socket pozisyonu alınamadı! buildingObject: " + ((buildingObject != null) ? "VAR" : "NULL"));
			}
		}
		else
		{
			Debug.Log("[Pallet] Socket bulunamadı veya validator null");
		}
		if (!flag && placementValidator != null)
		{
			Debug.Log("[Pallet] Yamukluk düzeltme uygulanıyor...");
			placementValidator.ApplyPlacementCorrection();
		}
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.NotifyPalletPlaced(base.netId);
		}
		Debug.Log($"[Pallet] OnPlaced TAMAMLANDI - NetId: {base.netId}");
	}

	public void OnLifted()
	{
		palletTrigger.SetActive(value: false);
		forkliftTrigger.SetActive(value: false);
		if (!base.isServer)
		{
			return;
		}
		NetworkisLifted = true;
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.NotifyPalletLifted(base.netId);
		}
		NetworkIdentity component = GetComponent<NetworkIdentity>();
		if (component == null)
		{
			Debug.LogWarning("[WarehouseZoneTrigger] OnTriggerExit - NetworkIdentity bulunamadı!");
			return;
		}
		uint item = component.netId;
		if (T_Warehouse.Instance != null && T_Warehouse.Instance.zoneTrigger.palletsInTrigger.Contains(item))
		{
			T_Warehouse.Instance.zoneTrigger.palletsInTrigger.Remove(item);
		}
		if (buildingObject != null)
		{
			uint targetSocketNetId = buildingObject.TargetSocketNetId;
			if (targetSocketNetId != 0 && NetworkServer.spawned.TryGetValue(targetSocketNetId, out var value))
			{
				T_Socket t_Socket = value.GetComponent<T_Socket>();
				if (t_Socket == null)
				{
					t_Socket = value.GetComponentInChildren<T_Socket>();
				}
				if (t_Socket != null)
				{
					t_Socket.OnBuildingRemoved(buildingObject.buildingPrefab);
					Debug.Log("[Pallet] OnLifted - Socket serbest bırakıldı: " + t_Socket.gameObject.name);
				}
			}
		}
		Debug.Log($"[Pallet] OnLifted - NetId: {base.netId}");
	}

	[Server]
	public void ServerSetBeingProcessed(bool value)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Pallet::ServerSetBeingProcessed(System.Boolean)' called when server was not active");
		}
		else
		{
			NetworkisBeingProcessed = value;
		}
	}

	[Server]
	public bool ServerTryAddItemFromBelt(T_Item item)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Pallet::ServerTryAddItemFromBelt(T_Item)' called when server was not active");
			return default(bool);
		}
		if (item == null)
		{
			return false;
		}
		string itemId = item.itemId;
		if (string.IsNullOrEmpty(itemId))
		{
			return false;
		}
		if (IsFull)
		{
			return false;
		}
		if (IsEmpty)
		{
			NetworkpaletItemId = itemId;
			NetworkpaletItemCount = 1;
			NetworkServer.Destroy(item.gameObject);
			return true;
		}
		if (paletItemId != itemId)
		{
			return false;
		}
		NetworkpaletItemCount = paletItemCount + 1;
		NetworkServer.Destroy(item.gameObject);
		return true;
	}

	[Server]
	public bool ServerTryAddItemFromSack(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Pallet::ServerTryAddItemFromSack(System.String,System.Int32)' called when server was not active");
			return default(bool);
		}
		if (string.IsNullOrEmpty(itemId) || count <= 0)
		{
			return false;
		}
		int num = GetMaxItemCountForItem(itemId) - paletItemCount;
		if (num <= 0)
		{
			return false;
		}
		int num2 = Mathf.Min(count, num);
		if (IsEmpty)
		{
			NetworkpaletItemId = itemId;
			NetworkpaletItemCount = num2;
			return true;
		}
		if (paletItemId != itemId)
		{
			return false;
		}
		NetworkpaletItemCount = paletItemCount + num2;
		return true;
	}

	[Server]
	public bool ServerTakeItem(out string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Pallet::ServerTakeItem(System.String&)' called when server was not active");
			itemId = null;
			return default(bool);
		}
		itemId = string.Empty;
		if (IsEmpty)
		{
			return false;
		}
		itemId = paletItemId;
		NetworkpaletItemCount = paletItemCount - 1;
		if (paletItemCount <= 0)
		{
			NetworkpaletItemId = string.Empty;
			NetworkpaletItemCount = 0;
		}
		return true;
	}

	[Server]
	public bool ServerRemoveItems(int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_Pallet::ServerRemoveItems(System.Int32)' called when server was not active");
			return default(bool);
		}
		if (IsEmpty || count <= 0)
		{
			return false;
		}
		int num = Mathf.Min(count, paletItemCount);
		NetworkpaletItemCount = paletItemCount - num;
		if (paletItemCount <= 0)
		{
			NetworkpaletItemId = string.Empty;
			NetworkpaletItemCount = 0;
		}
		Debug.Log($"[Pallet] ServerRemoveItems - Removed: {num}, Remaining: {paletItemCount}");
		return true;
	}

	[Server]
	public void ServerClearPallet()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Pallet::ServerClearPallet()' called when server was not active");
			return;
		}
		string arg = paletItemId;
		int num = paletItemCount;
		NetworkpaletItemId = string.Empty;
		NetworkpaletItemCount = 0;
		Debug.Log($"[Pallet] ServerClearPallet - Cleared {num} items of {arg}");
	}

	[Server]
	public int ServerTakeItems(int count, out string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 T_Pallet::ServerTakeItems(System.Int32,System.String&)' called when server was not active");
			itemId = null;
			return default(int);
		}
		itemId = string.Empty;
		if (IsEmpty || count <= 0)
		{
			return 0;
		}
		itemId = paletItemId;
		int num = Mathf.Min(count, paletItemCount);
		NetworkpaletItemCount = paletItemCount - num;
		if (paletItemCount <= 0)
		{
			NetworkpaletItemId = string.Empty;
			NetworkpaletItemCount = 0;
		}
		return num;
	}

	[Server]
	public int ServerAddPartialItemFromSack(string itemId, int requestedCount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 T_Pallet::ServerAddPartialItemFromSack(System.String,System.Int32)' called when server was not active");
			return default(int);
		}
		if (string.IsNullOrEmpty(itemId) || requestedCount <= 0)
		{
			return 0;
		}
		int num = GetMaxItemCountForItem(itemId) - paletItemCount;
		if (num <= 0)
		{
			return 0;
		}
		if (!IsEmpty && paletItemId != itemId)
		{
			return 0;
		}
		int num2 = Mathf.Min(requestedCount, num);
		if (IsEmpty)
		{
			NetworkpaletItemId = itemId;
		}
		NetworkpaletItemCount = paletItemCount + num2;
		return num2;
	}

	public int GetMaxItemCount()
	{
		return GetMaxItemCountForItem(paletItemId);
	}

	public int GetMaxItemCountForItem(string itemId)
	{
		T_ItemSO itemSO = null;
		if (!string.IsNullOrEmpty(itemId) && ItemSOManager.Instance != null)
		{
			itemSO = ItemSOManager.Instance.GetItemSOById(itemId);
		}
		return GetMaxItemCountForItem(itemSO);
	}

	public int GetMaxItemCountForItem(T_ItemSO itemSO)
	{
		Bounds bounds;
		if (itemSO != null && itemSO.VisualPrefab != null)
		{
			bounds = GetItemBoundsFromPrefab(itemSO.VisualPrefab);
			if (bounds.size == Vector3.zero)
			{
				bounds = new Bounds(Vector3.zero, new Vector3(0.3f, 0.3f, 0.3f));
			}
		}
		else
		{
			bounds = new Bounds(Vector3.zero, new Vector3(0.3f, 0.3f, 0.3f));
		}
		float x = bounds.size.x;
		float z = bounds.size.z;
		float y = bounds.size.y;
		float num = x + itemSpacing;
		float num2 = z + itemSpacing;
		itemsPerColumn = Mathf.FloorToInt(paletGenisligi / num);
		itemsPerRow = Mathf.FloorToInt(paletDerinligi / num2);
		if (itemsPerColumn <= 0)
		{
			itemsPerColumn = 1;
		}
		if (itemsPerRow <= 0)
		{
			itemsPerRow = 1;
		}
		int num3 = Mathf.Max(1, Mathf.FloorToInt(maxItemHeight / y));
		return itemsPerRow * itemsPerColumn * num3;
	}

	private Bounds GetItemBoundsFromPrefab(GameObject prefab)
	{
		if (prefab == null)
		{
			return new Bounds(Vector3.zero, Vector3.one * 0.5f);
		}
		Bounds result = default(Bounds);
		bool flag = false;
		Collider[] componentsInChildren = prefab.GetComponentsInChildren<Collider>(includeInactive: true);
		foreach (Collider collider in componentsInChildren)
		{
			if (!(collider == null))
			{
				Bounds colliderLocalBounds = GetColliderLocalBounds(collider);
				Vector3 hierarchyScale = GetHierarchyScale(collider.transform, prefab.transform);
				colliderLocalBounds.size = Vector3.Scale(colliderLocalBounds.size, hierarchyScale);
				colliderLocalBounds.center = Vector3.Scale(colliderLocalBounds.center, hierarchyScale);
				if (!flag)
				{
					result = colliderLocalBounds;
					flag = true;
				}
				else
				{
					result.Encapsulate(colliderLocalBounds);
				}
			}
		}
		if (!flag)
		{
			MeshFilter[] componentsInChildren2 = prefab.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter meshFilter in componentsInChildren2)
			{
				if (!(meshFilter == null) && !(meshFilter.sharedMesh == null))
				{
					Bounds bounds = meshFilter.sharedMesh.bounds;
					Vector3 hierarchyScale2 = GetHierarchyScale(meshFilter.transform, prefab.transform);
					bounds.size = Vector3.Scale(bounds.size, hierarchyScale2);
					bounds.center = Vector3.Scale(bounds.center, hierarchyScale2);
					if (!flag)
					{
						result = bounds;
						flag = true;
					}
					else
					{
						result.Encapsulate(bounds);
					}
				}
			}
		}
		if (!flag)
		{
			result = new Bounds(Vector3.zero, Vector3.one * 0.5f);
		}
		return result;
	}

	private Bounds GetColliderLocalBounds(Collider col)
	{
		if (col is BoxCollider boxCollider)
		{
			return new Bounds(boxCollider.center, boxCollider.size);
		}
		if (col is SphereCollider sphereCollider)
		{
			float num = sphereCollider.radius * 2f;
			return new Bounds(sphereCollider.center, new Vector3(num, num, num));
		}
		if (col is CapsuleCollider capsuleCollider)
		{
			float num2 = capsuleCollider.radius * 2f;
			float height = capsuleCollider.height;
			Vector3 size = capsuleCollider.direction switch
			{
				0 => new Vector3(height, num2, num2), 
				2 => new Vector3(num2, num2, height), 
				_ => new Vector3(num2, height, num2), 
			};
			return new Bounds(capsuleCollider.center, size);
		}
		if (col is MeshCollider meshCollider && meshCollider.sharedMesh != null)
		{
			return meshCollider.sharedMesh.bounds;
		}
		return new Bounds(Vector3.zero, Vector3.one * 0.5f);
	}

	private Vector3 GetHierarchyScale(Transform child, Transform root)
	{
		Vector3 vector = child.localScale;
		Transform parent = child.parent;
		while (parent != null && parent != root)
		{
			vector = Vector3.Scale(vector, parent.localScale);
			parent = parent.parent;
		}
		if (root != null)
		{
			vector = Vector3.Scale(vector, root.localScale);
		}
		return vector;
	}

	private void UpdateVisuals()
	{
		if (IsEmpty || string.IsNullOrEmpty(paletItemId))
		{
			ClearAllVisuals();
			_lastVisualItemId = null;
			return;
		}
		if (_lastVisualItemId != paletItemId)
		{
			ClearAllVisuals();
			_lastVisualItemId = paletItemId;
		}
		if (ItemSOManager.Instance == null)
		{
			Debug.LogError("[Palet] ItemSOManager.Instance null!");
			return;
		}
		currentItemSO = ItemSOManager.Instance.GetItemSOById(paletItemId);
		if (currentItemSO == null || currentItemSO.VisualPrefab == null)
		{
			Debug.LogWarning("[Palet] ItemSO veya VisualPrefab bulunamadı! ItemId: " + paletItemId);
			return;
		}
		Bounds itemBoundsFromPrefab = GetItemBoundsFromPrefab(currentItemSO.VisualPrefab);
		if (itemBoundsFromPrefab.size == Vector3.zero)
		{
			Debug.LogWarning("[Palet] Item bounds alınamadı!");
			return;
		}
		float x = itemBoundsFromPrefab.size.x;
		float z = itemBoundsFromPrefab.size.z;
		float y = itemBoundsFromPrefab.size.y;
		float num = x + itemSpacing;
		float num2 = z + itemSpacing;
		itemsPerColumn = Mathf.Max(1, Mathf.FloorToInt(paletGenisligi / num));
		itemsPerRow = Mathf.Max(1, Mathf.FloorToInt(paletDerinligi / num2));
		int num3 = itemsPerRow * itemsPerColumn;
		float num4 = (float)itemsPerColumn * x + (float)(itemsPerColumn - 1) * itemSpacing;
		float num5 = (float)itemsPerRow * z + (float)(itemsPerRow - 1) * itemSpacing;
		float num6 = (0f - num4) * 0.5f + x * 0.5f;
		float num7 = (0f - num5) * 0.5f + z * 0.5f;
		int num8 = paletItemCount;
		int count = spawnedVisuals.Count;
		if (num8 > count)
		{
			for (int i = count; i < num8; i++)
			{
				int num9 = i / num3;
				int num10 = i % num3;
				int num11 = num10 / itemsPerColumn;
				int num12 = num10 % itemsPerColumn;
				float x2 = num6 + (float)num12 * num;
				float z2 = num7 + (float)num11 * num2;
				float y2 = (float)num9 * y + y * 0.5f;
				GameObject gameObject = UnityEngine.Object.Instantiate(currentItemSO.VisualPrefab, visualParent);
				gameObject.transform.SetLocalPositionAndRotation(new Vector3(x2, y2, z2), Quaternion.identity);
				gameObject.transform.localScale = Vector3.one;
				spawnedVisuals.Add(gameObject);
			}
		}
		else
		{
			if (num8 >= count)
			{
				return;
			}
			for (int num13 = count - 1; num13 >= num8; num13--)
			{
				if (spawnedVisuals[num13] != null)
				{
					UnityEngine.Object.Destroy(spawnedVisuals[num13]);
				}
				spawnedVisuals.RemoveAt(num13);
			}
		}
	}

	private void ClearAllVisuals()
	{
		foreach (GameObject spawnedVisual in spawnedVisuals)
		{
			if (spawnedVisual != null)
			{
				UnityEngine.Object.Destroy(spawnedVisual);
			}
		}
		spawnedVisuals.Clear();
	}

	public void SetLegCollidersEnabled(bool enabled)
	{
		if (legCollidersObject != null)
		{
			legCollidersObject.SetActive(enabled);
			Debug.Log("[Pallet] Leg colliders object " + (enabled ? "açıldı" : "kapandı"));
		}
	}

	private void OnItemIdChanged(string oldValue, string newValue)
	{
		UpdateVisuals();
	}

	private void OnItemCountChanged(int oldValue, int newValue)
	{
		UpdateVisuals();
		if (base.isServer && !string.IsNullOrEmpty(paletItemId) && T_Warehouse.Instance != null)
		{
			int num = newValue - oldValue;
			if (num > 0)
			{
				T_Warehouse.Instance.NotifyPalletItemsAdded(base.netId, paletItemId, num);
				Debug.Log($"[Pallet] Items added - NetId: {base.netId}, ItemId: {paletItemId}, Delta: {num}");
			}
			else if (num < 0)
			{
				T_Warehouse.Instance.NotifyPalletItemsRemoved(base.netId, paletItemId, -num);
				Debug.Log($"[Pallet] Items removed - NetId: {base.netId}, ItemId: {paletItemId}, Delta: {-num}");
			}
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (_interactable != null)
		{
			_interactable.UnregisterResaleCondition(CheckPalletNotEmptyCondition);
			_interactable.UnregisterRelocateCondition(CheckPalletNotEmptyCondition);
			_interactable.UnregisterResaleCondition(CheckPalletLiftedCondition);
			_interactable.UnregisterRelocateCondition(CheckPalletLiftedCondition);
		}
		if (base.isServer && T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.NotifyPalletDestroyed(base.netId);
			Debug.Log($"[Pallet] Destroyed - NetId: {base.netId}");
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		PalletSaveData result = new PalletSaveData
		{
			itemId = paletItemId,
			itemCount = paletItemCount
		};
		Debug.Log($"[T_Pallet] Save - ID: {UniquePalletId}, ItemId: {paletItemId}, Count: {paletItemCount}");
		return result;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is PalletSaveData palletSaveData))
		{
			Debug.LogWarning("[T_Pallet] OnLoad - Invalid data type for pallet: " + UniquePalletId);
			return Task.CompletedTask;
		}
		NetworkpaletItemId = palletSaveData.itemId;
		NetworkpaletItemCount = palletSaveData.itemCount;
		UpdateVisuals();
		Debug.Log($"[T_Pallet] Load - ID: {UniquePalletId}, ItemId: {paletItemId}, Count: {paletItemCount}");
		return Task.CompletedTask;
	}

	public T_Pallet()
	{
		_Mirror_SyncVarHookDelegate_paletItemId = OnItemIdChanged;
		_Mirror_SyncVarHookDelegate_paletItemCount = OnItemCountChanged;
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
			writer.WriteString(paletItemId);
			writer.WriteVarInt(paletItemCount);
			writer.WriteBool(isLifted);
			writer.WriteBool(isBeingProcessed);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(paletItemId);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(paletItemCount);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isLifted);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(isBeingProcessed);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref paletItemId, _Mirror_SyncVarHookDelegate_paletItemId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref paletItemCount, _Mirror_SyncVarHookDelegate_paletItemCount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isLifted, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isBeingProcessed, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref paletItemId, _Mirror_SyncVarHookDelegate_paletItemId, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref paletItemCount, _Mirror_SyncVarHookDelegate_paletItemCount, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isLifted, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isBeingProcessed, null, reader.ReadBool());
		}
	}
}
