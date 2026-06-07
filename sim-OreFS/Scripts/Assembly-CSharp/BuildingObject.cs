using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class BuildingObject : NetworkBehaviour
{
	[Header("Save/Load")]
	[SyncVar]
	[SerializeField]
	private string uniqueBuildingId = string.Empty;

	[Header("Network")]
	[SyncVar(hook = "OnPreviewStateChanged")]
	private bool isPreviewValid;

	[SyncVar(hook = "OnIsInPreviewModeChanged")]
	private bool isInPreviewMode;

	[SyncVar]
	[SerializeField]
	private bool isPlaced;

	[Header("Preview Settings")]
	public GameObject previewGameObject;

	public GameObject stripesGameObject;

	public Collider previewCollider;

	public Material previewPositiveMaterial;

	public Material previewNegativeMaterial;

	[Tooltip("Çarpışma kontrolünde ignore edilecek layer'lar - Inspector'da seçin. Kalan tüm layer'lar çarpışma kontrolünde kullanılacak")]
	public LayerMask ignoreLayers;

	private LayerMask originalIgnoreLayers;

	[Header("Layer Settings")]
	[Tooltip("Preview mode'da geçilecek layer - Inspector'da seçin")]
	public LayerMask previewLayer;

	[Tooltip("Build edildikten sonra geçilecek layer - Inspector'da seçin")]
	public LayerMask buildingLayer;

	[Tooltip("Socket layer - Bu layer'daki objeler building layer'ına geçmeyecek")]
	public LayerMask socketLayer;

	[Header("Collider Layer Settings")]
	[Tooltip("Build mode'a geçildiğinde layer'ı preview olarak değiştirilecek collider'lar - Inspector'da seçin")]
	public Collider[] collidersToChangeLayer;

	private int originalLayer;

	private int[] originalColliderLayers;

	private Dictionary<GameObject, int> originalChildLayers;

	[Header("Preview Renderers")]
	public Renderer[] previewRenderers;

	[Header("Interactables")]
	[Tooltip("Preview modda devre dışı bırakılacak, place edildiğinde aktif edilecek Interactable bileşenleri")]
	public Interactable[] buildingInteractables;

	[Header("Socket Settings")]
	[Tooltip("Eğer true ise, bu building sadece Socket layer'ına sahip objelere yerleştirilebilir")]
	public bool socketOnly;

	[Tooltip("Eğer true ise, bu building hibrit modda çalışır: Hem normal yerlere yerleştirilebilir, hem de yakınlarda socket varsa otomatik olarak socket'e yerleştirilir. socketOnly false olmalı.")]
	public bool hybridMode;

	[Tooltip("Eğer true ise, bu building preview modunda rotate edilebilir. SocketOnly building'ler için false ise rotate edilemez.")]
	public bool canRotate = true;

	[Header("Building Prefab Reference")]
	[Tooltip("Bu building instance'ının prefab referansı - socket kontrolü için kullanılır")]
	public GameObject buildingPrefab;

	[Header("Building Item SO Reference")]
	[Tooltip("Bu building instance'ının ScriptableObject referansı - socket kontrolü için kullanılır (prefab yerine SO kullanılır)")]
	public T_BuildingItemSO buildingItemSO;

	[SyncVar(hook = "OnBuildingItemSOIndexChanged")]
	private int buildingItemSOIndex = -1;

	[SyncVar]
	private uint pickupItemNetId;

	[SyncVar]
	private BuildingModeSource buildingModeSource;

	[Header("Socket Reference")]
	[Tooltip("Socket referansı - socketOnly building'ler için kullanılır (client-side, network senkronize edilmez)")]
	private T_Socket targetSocket;

	[SyncVar]
	private uint targetSocketNetId;

	[Header("Relocate Settings")]
	[Tooltip("Relocate sırasında gizlenecek GameObject'ler - Place veya Cancel'da tekrar açılır")]
	public GameObject[] objectsToHideOnRelocate;

	[Header("Relocate State")]
	private Vector3 relocateOriginalPosition;

	private Quaternion relocateOriginalRotation;

	private T_Socket relocateOriginalSocket;

	[Header("Events")]
	[Tooltip("Building objesi place edildiğinde tetiklenecek event (tüm client'larda)")]
	public UnityEvent OnBuildingPlaced;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	private Material[] originalMaterials;

	private NetworkTransformReliable networkTransform;

	private const bool ENABLE_DEBUG_LOGS = true;

	private Collider[] cachedOwnColliders;

	private HashSet<Collider> cachedOwnCollidersSet;

	private Vector3 lastCheckedPosition;

	private Quaternion lastCheckedRotation;

	private bool lastCollisionResult;

	private float lastCollisionCheckTime;

	private const float COLLISION_CHECK_COOLDOWN = 0.1f;

	private const float POSITION_CHANGE_THRESHOLD = 0.01f;

	private const float ROTATION_CHANGE_THRESHOLD = 0.1f;

	private bool lastNetworkedValidity;

	private float lastNetworkUpdateTime;

	private const float NETWORK_UPDATE_INTERVAL = 0.2f;

	[Header("Debug Gizmos")]
	public bool showRestoreSocketGizmos = true;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isPreviewValid;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isInPreviewMode;

	public Action<int, int> _Mirror_SyncVarHookDelegate_buildingItemSOIndex;

	public string UniqueBuildingId => uniqueBuildingId;

	public bool IsPreviewValid => isPreviewValid;

	public bool IsPlaced => isPlaced;

	public uint TargetSocketNetId => targetSocketNetId;

	public string NetworkuniqueBuildingId
	{
		get
		{
			return uniqueBuildingId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref uniqueBuildingId, 1uL, null);
		}
	}

	public bool NetworkisPreviewValid
	{
		get
		{
			return isPreviewValid;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isPreviewValid, 2uL, _Mirror_SyncVarHookDelegate_isPreviewValid);
		}
	}

	public bool NetworkisInPreviewMode
	{
		get
		{
			return isInPreviewMode;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isInPreviewMode, 4uL, _Mirror_SyncVarHookDelegate_isInPreviewMode);
		}
	}

	public bool NetworkisPlaced
	{
		get
		{
			return isPlaced;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isPlaced, 8uL, null);
		}
	}

	public int NetworkbuildingItemSOIndex
	{
		get
		{
			return buildingItemSOIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref buildingItemSOIndex, 16uL, _Mirror_SyncVarHookDelegate_buildingItemSOIndex);
		}
	}

	public uint NetworkpickupItemNetId
	{
		get
		{
			return pickupItemNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref pickupItemNetId, 32uL, null);
		}
	}

	public BuildingModeSource NetworkbuildingModeSource
	{
		get
		{
			return buildingModeSource;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref buildingModeSource, 64uL, null);
		}
	}

	public uint NetworktargetSocketNetId
	{
		get
		{
			return targetSocketNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref targetSocketNetId, 128uL, null);
		}
	}

	[Server]
	public void SetUniqueBuildingId(string id)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::SetUniqueBuildingId(System.String)' called when server was not active");
		}
		else
		{
			NetworkuniqueBuildingId = id;
		}
	}

	private void EnsureUniqueBuildingId()
	{
		if (string.IsNullOrEmpty(uniqueBuildingId))
		{
			NetworkuniqueBuildingId = Guid.NewGuid().ToString();
		}
	}

	public void SetPickupItemNetId(uint netId)
	{
		NetworkpickupItemNetId = netId;
	}

	public void SetBuildingModeSource(BuildingModeSource source)
	{
		NetworkbuildingModeSource = source;
	}

	public BuildingModeSource GetBuildingModeSource()
	{
		return buildingModeSource;
	}

	public void SetTargetSocket(T_Socket socket)
	{
		targetSocket = socket;
	}

	private T_Socket GetTargetSocketFromNetId()
	{
		if (targetSocketNetId == 0)
		{
			return null;
		}
		if (NetworkServer.spawned.TryGetValue(targetSocketNetId, out var value))
		{
			T_Socket t_Socket = value.GetComponent<T_Socket>();
			if (t_Socket == null)
			{
				t_Socket = value.GetComponentInChildren<T_Socket>();
			}
			return t_Socket;
		}
		return null;
	}

	[Server]
	private void SetTargetSocketNetId(T_Socket socket)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::SetTargetSocketNetId(T_Socket)' called when server was not active");
		}
		else if (socket != null)
		{
			NetworkIdentity networkIdentity = socket.GetComponent<NetworkIdentity>();
			if (networkIdentity == null)
			{
				networkIdentity = socket.GetComponentInParent<NetworkIdentity>();
			}
			if (networkIdentity != null)
			{
				NetworktargetSocketNetId = networkIdentity.netId;
				return;
			}
			NetworktargetSocketNetId = 0u;
			Debug.LogWarning("[BuildingObject] SetTargetSocketNetId: Socket'te ve parent'ta NetworkIdentity yok! Socket: " + socket.gameObject.name);
		}
		else
		{
			NetworktargetSocketNetId = 0u;
		}
	}

	[Server]
	public void ServerSetSocketReference(T_Socket socket)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ServerSetSocketReference(T_Socket)' called when server was not active");
		}
		else if (!(socket == null))
		{
			DebugLog("ServerSetSocketReference: Socket=" + socket.gameObject.name + ", Building=" + base.gameObject.name);
			targetSocket = socket;
			SetTargetSocketNetId(socket);
		}
	}

	public void ResetIgnoreLayers()
	{
		ignoreLayers = originalIgnoreLayers;
	}

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			Debug.Log("[BuildingObject] " + message);
		}
	}

	private void Awake()
	{
		networkTransform = GetComponent<NetworkTransformReliable>();
		if (networkTransform != null)
		{
			if (networkTransform.target == null)
			{
				networkTransform.target = base.transform;
			}
			networkTransform.coordinateSpace = CoordinateSpace.World;
		}
		originalIgnoreLayers = ignoreLayers;
		originalLayer = base.gameObject.layer;
		if (collidersToChangeLayer != null && collidersToChangeLayer.Length != 0)
		{
			originalColliderLayers = new int[collidersToChangeLayer.Length];
			for (int i = 0; i < collidersToChangeLayer.Length; i++)
			{
				if (collidersToChangeLayer[i] != null)
				{
					originalColliderLayers[i] = collidersToChangeLayer[i].gameObject.layer;
				}
			}
		}
		originalChildLayers = new Dictionary<GameObject, int>();
		StoreChildLayersRecursively(base.transform);
		if (previewRenderers != null && previewRenderers.Length != 0)
		{
			originalMaterials = new Material[previewRenderers.Length];
			for (int j = 0; j < previewRenderers.Length; j++)
			{
				if (previewRenderers[j] != null)
				{
					originalMaterials[j] = previewRenderers[j].material;
				}
			}
		}
		if (previewCollider != null)
		{
			previewCollider.enabled = false;
		}
		CacheOwnColliders();
	}

	private void CacheOwnColliders()
	{
		cachedOwnColliders = GetComponentsInChildren<Collider>();
		cachedOwnCollidersSet = new HashSet<Collider>(cachedOwnColliders);
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (networkTransform != null && base.isOwned)
		{
			networkTransform.syncDirection = SyncDirection.ClientToServer;
		}
		if (buildingItemSOIndex != -1)
		{
			OnBuildingItemSOIndexChanged(-1, buildingItemSOIndex);
		}
		if (buildingPrefab == null && buildingItemSO != null && buildingItemSO.Prefab != null)
		{
			buildingPrefab = buildingItemSO.Prefab;
		}
		if (isInPreviewMode)
		{
			if (base.isOwned)
			{
				ApplyPreviewModeVisuals();
			}
			else
			{
				ApplyPreviewModeVisuals();
			}
		}
		else if (isPlaced)
		{
			ApplyNormalModeVisuals();
			DisableNetworkTransformAfterPlacement();
			OnBuildingPlaced?.Invoke();
		}
		else
		{
			ApplyNormalModeVisuals();
		}
	}

	public void SetBuildingItemSOIndex(int index)
	{
		if (base.isServer)
		{
			NetworkbuildingItemSOIndex = index;
		}
	}

	private void OnBuildingItemSOIndexChanged(int oldIndex, int newIndex)
	{
		if (newIndex == -1)
		{
			return;
		}
		IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
		if (newIndex < 0 || newIndex >= allBuildingItemSOs.Count)
		{
			Debug.LogWarning($"[BuildingObject] OnBuildingItemSOIndexChanged: Geçersiz SO index! Index: {newIndex}, List Count: {allBuildingItemSOs.Count}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = allBuildingItemSOs[newIndex];
		if (t_BuildingItemSO != null)
		{
			buildingItemSO = t_BuildingItemSO;
			if (t_BuildingItemSO.Prefab != null)
			{
				buildingPrefab = t_BuildingItemSO.Prefab;
			}
			else
			{
				Debug.LogWarning($"[BuildingObject] OnBuildingItemSOIndexChanged (CLIENT): SO'dan Prefab null! SO: {t_BuildingItemSO.Name}, Index: {newIndex}");
			}
		}
		else
		{
			Debug.LogWarning($"[BuildingObject] OnBuildingItemSOIndexChanged (CLIENT): Seçilen SO null! Index: {newIndex}");
		}
	}

	private void ApplyPreviewModeVisuals()
	{
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: true);
			if (stripesGameObject != null)
			{
				stripesGameObject.SetActive(value: false);
			}
		}
		if (previewCollider != null && base.isOwned)
		{
			previewCollider.enabled = true;
		}
		else if (previewCollider != null && !base.isOwned)
		{
			previewCollider.enabled = false;
		}
		UpdatePreviewMaterials(isPreviewValid);
		int firstLayerFromMask = GetFirstLayerFromMask(previewLayer);
		if (firstLayerFromMask != -1 && collidersToChangeLayer != null)
		{
			for (int i = 0; i < collidersToChangeLayer.Length; i++)
			{
				if (collidersToChangeLayer[i] != null)
				{
					collidersToChangeLayer[i].gameObject.layer = firstLayerFromMask;
				}
			}
		}
		int firstLayerFromMask2 = GetFirstLayerFromMask(socketLayer);
		if (firstLayerFromMask != -1 && firstLayerFromMask2 != -1 && originalChildLayers != null)
		{
			foreach (KeyValuePair<GameObject, int> originalChildLayer in originalChildLayers)
			{
				if (originalChildLayer.Key != null && originalChildLayer.Value == firstLayerFromMask2)
				{
					originalChildLayer.Key.layer = firstLayerFromMask;
				}
			}
		}
		SetInteractablesEnabled(enabled: false);
	}

	private void ApplyNormalModeVisuals()
	{
		RestoreOriginalMaterials();
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: false);
			if (stripesGameObject != null)
			{
				stripesGameObject.SetActive(value: true);
			}
		}
		if (previewCollider != null)
		{
			previewCollider.enabled = false;
		}
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer != null && renderer.gameObject != previewGameObject)
			{
				renderer.enabled = true;
			}
		}
		int firstLayerFromMask = GetFirstLayerFromMask(buildingLayer);
		if (collidersToChangeLayer != null && originalColliderLayers != null)
		{
			for (int j = 0; j < collidersToChangeLayer.Length && j < originalColliderLayers.Length; j++)
			{
				if (collidersToChangeLayer[j] != null)
				{
					if (firstLayerFromMask != -1)
					{
						collidersToChangeLayer[j].gameObject.layer = firstLayerFromMask;
					}
					else
					{
						collidersToChangeLayer[j].gameObject.layer = originalColliderLayers[j];
					}
				}
			}
		}
		if (originalChildLayers != null)
		{
			int firstLayerFromMask2 = GetFirstLayerFromMask(socketLayer);
			if (firstLayerFromMask2 != -1)
			{
				foreach (KeyValuePair<GameObject, int> originalChildLayer in originalChildLayers)
				{
					if (originalChildLayer.Key != null && originalChildLayer.Value == firstLayerFromMask2)
					{
						originalChildLayer.Key.layer = firstLayerFromMask2;
					}
				}
			}
		}
		SetInteractablesEnabled(enabled: true);
	}

	private void SetInteractablesEnabled(bool enabled)
	{
		if (buildingInteractables == null)
		{
			return;
		}
		for (int i = 0; i < buildingInteractables.Length; i++)
		{
			if (buildingInteractables[i] != null)
			{
				buildingInteractables[i].enabled = enabled;
			}
		}
	}

	private void OnIsInPreviewModeChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			ApplyPreviewModeVisuals();
		}
		else
		{
			ApplyNormalModeVisuals();
		}
	}

	public void EnablePreviewMode()
	{
		if (!isInPreviewMode)
		{
			if (base.isServer)
			{
				NetworkisInPreviewMode = true;
			}
			else if (base.isOwned)
			{
				CmdSetPreviewMode(enabled: true);
			}
			ApplyPreviewModeVisuals();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetPreviewMode(bool enabled)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetPreviewMode__Boolean(enabled);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(enabled);
		SendCommandInternal("System.Void BuildingObject::CmdSetPreviewMode(System.Boolean)", 1702754168, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private int GetFirstLayerFromMask(LayerMask mask)
	{
		if (mask.value == 0)
		{
			return -1;
		}
		for (int i = 0; i < 32; i++)
		{
			if ((mask.value & (1 << i)) != 0)
			{
				return i;
			}
		}
		return -1;
	}

	private void StoreChildLayersRecursively(Transform parent)
	{
		foreach (Transform item in parent)
		{
			if (!originalChildLayers.ContainsKey(item.gameObject))
			{
				originalChildLayers[item.gameObject] = item.gameObject.layer;
			}
			StoreChildLayersRecursively(item);
		}
	}

	private void SetLayerToBuildingLayer()
	{
		int firstLayerFromMask = GetFirstLayerFromMask(buildingLayer);
		int firstLayerFromMask2 = GetFirstLayerFromMask(socketLayer);
		if (firstLayerFromMask == -1)
		{
			Debug.LogWarning("[BuildingObject] Building layer ayarlanmamış!");
			return;
		}
		DebugLog(string.Format("SetLayerToBuildingLayer: Building={0}, TargetLayer={1} ({2}), SocketLayer={3}", base.gameObject.name, LayerMask.LayerToName(firstLayerFromMask), firstLayerFromMask, (firstLayerFromMask2 != -1) ? LayerMask.LayerToName(firstLayerFromMask2) : "none"));
		if (firstLayerFromMask2 == -1 || base.gameObject.layer != firstLayerFromMask2)
		{
			base.gameObject.layer = firstLayerFromMask;
		}
		if (previewRenderers != null)
		{
			Renderer[] array = previewRenderers;
			foreach (Renderer renderer in array)
			{
				if (renderer != null && renderer.gameObject != null)
				{
					GameObject gameObject = renderer.gameObject;
					if (firstLayerFromMask2 == -1 || gameObject.layer != firstLayerFromMask2)
					{
						gameObject.layer = firstLayerFromMask;
					}
				}
			}
		}
		if (collidersToChangeLayer != null && originalColliderLayers != null)
		{
			for (int j = 0; j < collidersToChangeLayer.Length && j < originalColliderLayers.Length; j++)
			{
				if (collidersToChangeLayer[j] != null)
				{
					GameObject gameObject2 = collidersToChangeLayer[j].gameObject;
					if (firstLayerFromMask2 == -1 || gameObject2.layer != firstLayerFromMask2)
					{
						gameObject2.layer = firstLayerFromMask;
					}
				}
			}
		}
		if (originalChildLayers == null)
		{
			return;
		}
		foreach (KeyValuePair<GameObject, int> originalChildLayer in originalChildLayers)
		{
			if (!(originalChildLayer.Key != null))
			{
				continue;
			}
			bool flag = false;
			if (previewRenderers != null)
			{
				Renderer[] array = previewRenderers;
				foreach (Renderer renderer2 in array)
				{
					if (renderer2 != null && renderer2.gameObject == originalChildLayer.Key)
					{
						flag = true;
						break;
					}
				}
			}
			bool flag2 = false;
			if (collidersToChangeLayer != null)
			{
				Collider[] array2 = collidersToChangeLayer;
				foreach (Collider collider in array2)
				{
					if (collider != null && collider.gameObject == originalChildLayer.Key)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (!(flag || flag2))
			{
				originalChildLayer.Key.layer = originalChildLayer.Value;
			}
		}
	}

	public void DisablePreviewMode()
	{
		if (!isInPreviewMode)
		{
			return;
		}
		if (base.isServer)
		{
			NetworkisInPreviewMode = false;
		}
		ApplyNormalModeVisuals();
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: false);
			if (stripesGameObject != null)
			{
				stripesGameObject.SetActive(value: true);
			}
		}
		if (previewCollider != null)
		{
			previewCollider.enabled = false;
		}
		RestoreOriginalMaterials();
	}

	public void UpdatePreviewValidity(bool isValid)
	{
		if (base.isOwned)
		{
			UpdatePreviewMaterials(isValid);
			bool num = isValid != lastNetworkedValidity;
			bool flag = Time.time - lastNetworkUpdateTime > 0.2f;
			if (num && flag)
			{
				CmdSetPreviewValidity(isValid);
				lastNetworkedValidity = isValid;
				lastNetworkUpdateTime = Time.time;
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetPreviewValidity(bool isValid)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetPreviewValidity__Boolean(isValid);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(isValid);
		SendCommandInternal("System.Void BuildingObject::CmdSetPreviewValidity(System.Boolean)", 1782523005, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnPreviewStateChanged(bool oldValue, bool newValue)
	{
		if (base.isOwned && isInPreviewMode)
		{
			UpdatePreviewMaterials(newValue);
		}
		else if (!base.isOwned)
		{
			UpdatePreviewMaterials(newValue);
		}
	}

	private void UpdatePreviewMaterials(bool isValid)
	{
		if (previewRenderers == null || previewRenderers.Length == 0)
		{
			return;
		}
		Material material = (isValid ? previewPositiveMaterial : previewNegativeMaterial);
		if (material == null)
		{
			Debug.LogWarning("[BuildingObject] Preview material null! isValid: " + isValid);
			return;
		}
		for (int i = 0; i < previewRenderers.Length; i++)
		{
			if (previewRenderers[i] != null)
			{
				previewRenderers[i].material = material;
			}
		}
	}

	private void RestoreOriginalMaterials()
	{
		if (previewRenderers == null || originalMaterials == null)
		{
			return;
		}
		for (int i = 0; i < previewRenderers.Length; i++)
		{
			if (previewRenderers[i] != null && i < originalMaterials.Length && originalMaterials[i] != null)
			{
				previewRenderers[i].material = originalMaterials[i];
			}
		}
	}

	public bool CheckCollision(T_Socket socketToIgnore = null, BuildingObject parentBuildingToIgnore = null)
	{
		if (previewCollider == null)
		{
			return false;
		}
		bool num = Vector3.Distance(base.transform.position, lastCheckedPosition) > 0.01f;
		bool flag = Quaternion.Angle(base.transform.rotation, lastCheckedRotation) > 0.1f;
		bool flag2 = Time.time - lastCollisionCheckTime > 0.1f;
		if (!num && !flag && !flag2 && socketToIgnore == null && parentBuildingToIgnore == null)
		{
			return lastCollisionResult;
		}
		if (cachedOwnCollidersSet == null)
		{
			CacheOwnColliders();
		}
		HashSet<Collider> hashSet = new HashSet<Collider>(cachedOwnCollidersSet);
		if (socketToIgnore != null)
		{
			Collider[] componentsInChildren = socketToIgnore.GetComponentsInChildren<Collider>();
			foreach (Collider item in componentsInChildren)
			{
				hashSet.Add(item);
			}
		}
		if (parentBuildingToIgnore != null)
		{
			Collider[] componentsInChildren2 = parentBuildingToIgnore.GetComponentsInChildren<Collider>();
			Collider[] componentsInChildren = componentsInChildren2;
			foreach (Collider item2 in componentsInChildren)
			{
				hashSet.Add(item2);
			}
			Debug.Log($"[BuildingObject] CheckCollision: Parent building ignore edildi - {parentBuildingToIgnore.name}, ColliderCount: {componentsInChildren2.Length}");
		}
		bool flag3 = false;
		LayerMask layerMask = ~(int)ignoreLayers;
		if (previewCollider is BoxCollider)
		{
			Vector3 center = previewCollider.bounds.center;
			Vector3 size = previewCollider.bounds.size;
			Collider[] componentsInChildren = Physics.OverlapBox(orientation: previewCollider.transform.rotation, center: center, halfExtents: size * 0.5f, layerMask: layerMask);
			foreach (Collider collider in componentsInChildren)
			{
				if (!hashSet.Contains(collider))
				{
					if (!flag3)
					{
						int layer = collider.gameObject.layer;
						Debug.Log($"[BuildingObject] Çarpışma tespit edildi: {collider.name} (Layer: {LayerMask.LayerToName(layer)}, IgnoreLayers: {ignoreLayers.value})");
					}
					flag3 = true;
					break;
				}
			}
		}
		else if (previewCollider is SphereCollider sphereCollider)
		{
			Vector3 center2 = previewCollider.bounds.center;
			float radius = sphereCollider.radius * Mathf.Max(previewCollider.transform.lossyScale.x, previewCollider.transform.lossyScale.y, previewCollider.transform.lossyScale.z);
			Collider[] componentsInChildren = Physics.OverlapSphere(center2, radius, layerMask);
			foreach (Collider collider2 in componentsInChildren)
			{
				if (!hashSet.Contains(collider2))
				{
					if (!flag3)
					{
						int layer2 = collider2.gameObject.layer;
						Debug.Log($"[BuildingObject] Çarpışma tespit edildi: {collider2.name} (Layer: {LayerMask.LayerToName(layer2)}, IgnoreLayers: {ignoreLayers.value})");
					}
					flag3 = true;
					break;
				}
			}
		}
		lastCollisionResult = flag3;
		lastCheckedPosition = base.transform.position;
		lastCheckedRotation = base.transform.rotation;
		lastCollisionCheckTime = Time.time;
		return flag3;
	}

	public void PlaceBuilding()
	{
		if (!base.isOwned)
		{
			return;
		}
		DebugLog(string.Format("PlaceBuilding called - Position: {0}, Rotation: {1}, SocketOnly: {2}, HybridMode: {3}, TargetSocket: {4}", base.transform.position, base.transform.rotation.eulerAngles, socketOnly, hybridMode, (targetSocket != null) ? targetSocket.gameObject.name : "null"));
		bool flag;
		if ((socketOnly || hybridMode) && targetSocket != null)
		{
			BuildingObject componentInParent = targetSocket.GetComponentInParent<BuildingObject>();
			flag = CheckCollision(targetSocket, componentInParent);
		}
		else
		{
			flag = CheckCollision();
		}
		if (flag)
		{
			Debug.LogWarning("BuildingObject: Yerleştirme başarısız - çarpışma tespit edildi!");
			return;
		}
		uint num = 0u;
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				NetworkIdentity component = pickupItem.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					num = component.netId;
				}
			}
		}
		if (num == 0)
		{
			num = pickupItemNetId;
		}
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
		}
		uint num2 = 0u;
		Vector3 vector = Vector3.zero;
		if ((socketOnly || hybridMode) && targetSocket != null)
		{
			NetworkIdentity networkIdentity = targetSocket.GetComponent<NetworkIdentity>();
			if (networkIdentity == null)
			{
				networkIdentity = targetSocket.GetComponentInParent<NetworkIdentity>();
			}
			if (networkIdentity != null)
			{
				num2 = networkIdentity.netId;
			}
			else
			{
				vector = targetSocket.transform.position;
				DebugLog($"PlaceBuilding: Socket has no NetworkIdentity, using position fallback: {vector}");
			}
		}
		DebugLog($"PlaceBuilding -> CmdPlaceBuilding: buildingBoxNetId={num}, socketNetId={num2}, source={buildingModeSource}");
		CmdPlaceBuilding(num, base.transform.position, base.transform.rotation, num2, vector);
	}

	[Command(requiresAuthority = false)]
	private void CmdPlaceBuilding(uint buildingBoxNetId, Vector3 clientFinalPosition, Quaternion clientFinalRotation, uint socketNetId, Vector3 socketPosition, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdPlaceBuilding__UInt32__Vector3__Quaternion__UInt32__Vector3__NetworkConnectionToClient(buildingBoxNetId, clientFinalPosition, clientFinalRotation, socketNetId, socketPosition, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(buildingBoxNetId);
		writer.WriteVector3(clientFinalPosition);
		writer.WriteQuaternion(clientFinalRotation);
		writer.WriteVarUInt(socketNetId);
		writer.WriteVector3(socketPosition);
		SendCommandInternal("System.Void BuildingObject::CmdPlaceBuilding(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion,System.UInt32,UnityEngine.Vector3,Mirror.NetworkConnectionToClient)", 879744197, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ApplyFinalTransformDelayed(Vector3 finalPosition, Quaternion finalRotation, NetworkConnectionToClient ownerConnection, T_Socket socket)
	{
		yield return null;
		base.transform.position = finalPosition;
		base.transform.rotation = finalRotation;
		Physics.SyncTransforms();
		if (networkTransform != null)
		{
			networkTransform.ResetState();
			networkTransform.ServerTeleport(finalPosition, finalRotation);
		}
		DisableNetworkTransformAfterPlacement();
		if ((socketOnly || hybridMode) && socket != null && buildingPrefab != null)
		{
			socket.OnBuildingPlaced(buildingPrefab, base.netId);
			targetSocket = socket;
			SetTargetSocketNetId(socket);
			DebugLog($"CmdPlaceBuilding: Socket updated successfully - Socket: {socket.gameObject.name}, TargetSocketNetId: {targetSocketNetId}");
			socket.LogSocketState("Server - Building placed");
		}
		else if ((socketOnly || hybridMode) && buildingPrefab != null)
		{
			targetSocket = null;
			NetworktargetSocketNetId = 0u;
			DebugLog($"CmdPlaceBuilding: Socket not found! socketOnly: {socketOnly}, hybridMode: {hybridMode}, buildingPrefab: {buildingPrefab.name}");
			Debug.LogWarning(string.Format("[BuildingObject] Socket güncellenemedi! socketOnly: {0}, hybridMode: {1}, socket: {2}, buildingPrefab: {3}", socketOnly, hybridMode, (socket != null) ? socket.gameObject.name : "null", (buildingPrefab != null) ? buildingPrefab.name : "null"));
		}
		RestoreChildSockets();
		if (buildingItemSO != null && TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && (buildingItemSO.isPallet || buildingItemSO.Name.ToLower().Contains("pallet")))
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PlacePallet, TutorialSubStepType.PlacePalletInFront);
			if (ownerConnection != null)
			{
				RpcStopBuildingModeForPalletTutorial(ownerConnection);
			}
		}
		if (ownerConnection != null && buildingModeSource == BuildingModeSource.BuildingBox)
		{
			RpcClearPlayerBuildingPickup(ownerConnection);
		}
		if ((socketOnly || hybridMode) && socket != null && buildingPrefab != null)
		{
			NetworkIdentity networkIdentity = socket.GetComponent<NetworkIdentity>();
			if (networkIdentity == null)
			{
				networkIdentity = socket.GetComponentInParent<NetworkIdentity>();
			}
			if (networkIdentity != null)
			{
				RpcUpdateSocketOnClients(networkIdentity.netId, buildingPrefab);
			}
			else
			{
				Vector3 position = socket.transform.position;
				Vector3 position2 = base.transform.position;
				RpcUpdateSocketOnClientsByPosition(position, position2, buildingPrefab);
			}
		}
		RpcOnBuildingPlaced(finalPosition, finalRotation);
	}

	[TargetRpc]
	private void RpcStopBuildingModeForPalletTutorial(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void BuildingObject::RpcStopBuildingModeForPalletTutorial(Mirror.NetworkConnection)", 2091401174, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcClearPlayerBuildingPickup(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void BuildingObject::RpcClearPlayerBuildingPickup(Mirror.NetworkConnection)", 1049756568, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdateSocketOnClients(uint socketNetId, GameObject buildingPrefab)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(socketNetId);
		writer.WriteGameObject(buildingPrefab);
		SendRPCInternal("System.Void BuildingObject::RpcUpdateSocketOnClients(System.UInt32,UnityEngine.GameObject)", -698170560, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdateSocketOnClientsByPosition(Vector3 socketPosition, Vector3 buildingPosition, GameObject buildingPrefab)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(socketPosition);
		writer.WriteVector3(buildingPosition);
		writer.WriteGameObject(buildingPrefab);
		SendRPCInternal("System.Void BuildingObject::RpcUpdateSocketOnClientsByPosition(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.GameObject)", 1295839142, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnBuildingPlaced(Vector3 finalPosition, Quaternion finalRotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(finalPosition);
		writer.WriteQuaternion(finalRotation);
		SendRPCInternal("System.Void BuildingObject::RpcOnBuildingPlaced(UnityEngine.Vector3,UnityEngine.Quaternion)", -1980279023, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void DisableNetworkTransformAfterPlacement(bool force = false)
	{
		if ((force || isPlaced) && networkTransform != null && networkTransform.enabled)
		{
			networkTransform.enabled = false;
		}
	}

	public override void OnStopAuthority()
	{
		base.OnStopAuthority();
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
		}
	}

	public void RequestReserveSocket(T_Socket socket)
	{
		if (!(socket == null))
		{
			NetworkIdentity componentInParent = socket.GetComponentInParent<NetworkIdentity>();
			if (!(componentInParent == null))
			{
				CmdReserveSocket(componentInParent.netId, base.netId);
			}
		}
	}

	public void RequestUnreserveSocket(T_Socket socket)
	{
		if (!(socket == null))
		{
			NetworkIdentity componentInParent = socket.GetComponentInParent<NetworkIdentity>();
			if (!(componentInParent == null))
			{
				CmdUnreserveSocket(componentInParent.netId, base.netId);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReserveSocket(uint socketParentNetId, uint buildingNetId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdReserveSocket__UInt32__UInt32(socketParentNetId, buildingNetId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(socketParentNetId);
		writer.WriteVarUInt(buildingNetId);
		SendCommandInternal("System.Void BuildingObject::CmdReserveSocket(System.UInt32,System.UInt32)", -1052084555, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdUnreserveSocket(uint socketParentNetId, uint buildingNetId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdUnreserveSocket__UInt32__UInt32(socketParentNetId, buildingNetId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(socketParentNetId);
		writer.WriteVarUInt(buildingNetId);
		SendCommandInternal("System.Void BuildingObject::CmdUnreserveSocket(System.UInt32,System.UInt32)", -1171249634, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void CancelBuilding()
	{
		if (base.isOwned)
		{
			if (buildingModeSource == BuildingModeSource.Relocate)
			{
				CmdCancelRelocate();
			}
			else
			{
				CmdCancelBuilding();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdCancelBuilding()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdCancelBuilding();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void BuildingObject::CmdCancelBuilding()", -309754236, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdCancelRelocate(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdCancelRelocate__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void BuildingObject::CmdCancelRelocate(Mirror.NetworkConnectionToClient)", 2013464844, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcRestorePlacedVisuals()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BuildingObject::RpcRestorePlacedVisuals()", -1076445727, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcRestorePlacedVisualsWithPosition(Vector3 originalPosition, Quaternion originalRotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(originalPosition);
		writer.WriteQuaternion(originalRotation);
		SendRPCInternal("System.Void BuildingObject::RpcRestorePlacedVisualsWithPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", 91414794, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SetRelocateObjectsActive(bool active)
	{
		if (objectsToHideOnRelocate == null)
		{
			return;
		}
		for (int i = 0; i < objectsToHideOnRelocate.Length; i++)
		{
			if (objectsToHideOnRelocate[i] != null)
			{
				objectsToHideOnRelocate[i].SetActive(active);
			}
		}
	}

	[ClientRpc]
	private void RpcSetRelocateObjectsActive(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendRPCInternal("System.Void BuildingObject::RpcSetRelocateObjectsActive(System.Boolean)", -749969053, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcEnableNetworkTransformForRelocate()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BuildingObject::RpcEnableNetworkTransformForRelocate()", -667924874, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (buildingPrefab == null && buildingItemSO != null && buildingItemSO.Prefab != null)
		{
			buildingPrefab = buildingItemSO.Prefab;
		}
		EnsureUniqueBuildingId();
		if (GameManager.Instance != null)
		{
			GameManager.Instance.RegisterBuilding(this);
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (GameManager.Instance != null)
		{
			GameManager.Instance.UnregisterBuilding(this);
		}
		if (targetSocketNetId != 0 && (socketOnly || hybridMode))
		{
			T_Socket targetSocketFromNetId = GetTargetSocketFromNetId();
			if (targetSocketFromNetId != null && targetSocketFromNetId.IsOccupied() && (targetSocketFromNetId.OccupantNetId == base.netId || targetSocketFromNetId.OccupantNetId == 0))
			{
				DebugLog("OnStopServer: Cleaning up socket on destroy - Socket: " + targetSocketFromNetId.gameObject.name + ", Building: " + base.gameObject.name);
				targetSocketFromNetId.OnBuildingRemoved(buildingPrefab);
			}
		}
	}

	[Server]
	public void ServerResaleBuilding(NetworkConnectionToClient ownerConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ServerResaleBuilding(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (!base.isServer)
		{
			Debug.LogError("[BuildingObject] ServerResaleBuilding: sadece server tarafında çağrılmalı!");
			return;
		}
		if (ownerConnection == null)
		{
			Debug.LogWarning("[BuildingObject] ServerResaleBuilding: ownerConnection null! Building: " + base.gameObject.name);
		}
		if (!isPlaced)
		{
			Debug.LogWarning("[BuildingObject] ServerResaleBuilding: Building henüz place edilmemiş! Building: " + base.gameObject.name);
			return;
		}
		if (buildingItemSO == null)
		{
			Debug.LogWarning("[BuildingObject] ServerResaleBuilding: BuildingItemSO null! Building: " + base.gameObject.name);
			return;
		}
		int price = buildingItemSO.Price;
		DebugLog($"ServerResaleBuilding: Building={base.gameObject.name}, RefundAmount={price}, SO={buildingItemSO.Name}, SocketNetId={targetSocketNetId}");
		RefundBuildingPrice(ownerConnection, price);
		ClearSocketOnResale();
		ClearChildSocketsOnRelocate();
		ClearExternalSocketsOnRelocate();
		ReturnMachineItemsToStorage();
		DebugLog("ServerResaleBuilding: Destroying building - " + base.gameObject.name);
		NetworkServer.Destroy(base.gameObject);
	}

	[Server]
	public void ServerRelocateBuilding(NetworkConnectionToClient ownerConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ServerRelocateBuilding(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (!base.isServer)
		{
			Debug.LogError("[BuildingObject] ServerRelocateBuilding: sadece server tarafında çağrılmalı!");
			return;
		}
		if (ownerConnection == null)
		{
			Debug.LogError("[BuildingObject] ServerRelocateBuilding: ownerConnection null! Building: " + base.gameObject.name);
			return;
		}
		if (!isPlaced)
		{
			Debug.LogWarning("[BuildingObject] ServerRelocateBuilding: Building henüz place edilmemiş! Building: " + base.gameObject.name);
			return;
		}
		relocateOriginalPosition = base.transform.position;
		relocateOriginalRotation = base.transform.rotation;
		DebugLog(string.Format("ServerRelocateBuilding: Building={0}, OriginalPos={1}, SocketNetId={2}, OriginalSocket={3}", base.gameObject.name, relocateOriginalPosition, targetSocketNetId, (targetSocket != null) ? targetSocket.gameObject.name : "null"));
		if (targetSocket != null)
		{
			relocateOriginalSocket = targetSocket;
		}
		else
		{
			relocateOriginalSocket = GetTargetSocketFromNetId();
		}
		T_Machine component = GetComponent<T_Machine>();
		if (component != null && !component.IsProductionPaused)
		{
			component.RequestStopProduction();
		}
		ClearChildSocketsOnRelocate();
		ClearExternalSocketsOnRelocate();
		NetworkbuildingModeSource = BuildingModeSource.Relocate;
		NetworkisPlaced = false;
		NetworkisInPreviewMode = true;
		NetworkIdentity component2 = GetComponent<NetworkIdentity>();
		if (component2 != null && ownerConnection != null)
		{
			DebugLog($"ServerRelocateBuilding: Assigning client authority - Connection: {ownerConnection}");
			component2.AssignClientAuthority(ownerConnection);
		}
		else
		{
			Debug.LogError($"[BuildingObject] ServerRelocateBuilding: NetworkIdentity veya ownerConnection null! NI null: {component2 == null}, Connection null: {ownerConnection == null}");
		}
		RpcEnableNetworkTransformForRelocate();
		if (component2 != null && ownerConnection != null)
		{
			RpcOnBuildingRelocated(ownerConnection);
		}
		RpcSetRelocateObjectsActive(active: false);
		DebugLog("ServerRelocateBuilding: Complete - Building=" + base.gameObject.name + ", now in preview mode");
	}

	private void RefundBuildingPrice(NetworkConnectionToClient ownerConnection, int refundAmount)
	{
		if (refundAmount <= 0)
		{
			Debug.LogWarning($"[BuildingObject] RefundBuildingPrice: Refund amount <= 0! Amount: {refundAmount}");
		}
		else if (GameManager.Instance != null && GameManager.Instance.factoryManager != null)
		{
			GameManager.Instance.factoryManager.AddMoney(refundAmount, EconomyType.EconomyType_Building);
		}
		else
		{
			Debug.LogError("[BuildingObject] RefundBuildingPrice: GameManager veya factoryManager null!");
		}
	}

	private void ClearSocketOnResale()
	{
		T_Socket targetSocketFromNetId = GetTargetSocketFromNetId();
		if (targetSocketFromNetId != null)
		{
			DebugLog("ClearSocketOnResale: Socket found via NetId - Socket: " + targetSocketFromNetId.gameObject.name);
			targetSocketFromNetId.OnBuildingRemoved(buildingPrefab);
			NetworktargetSocketNetId = 0u;
		}
		else if ((socketOnly || hybridMode) && buildingPrefab != null)
		{
			DebugLog($"ClearSocketOnResale: Socket not found via NetId ({targetSocketNetId}), falling back to Physics search");
			T_BuildingItemSO t_BuildingItemSO = null;
			BuildingObject component = buildingPrefab.GetComponent<BuildingObject>();
			t_BuildingItemSO = ((!(component != null) || !(component.buildingItemSO != null)) ? buildingItemSO : component.buildingItemSO);
			if (t_BuildingItemSO == null)
			{
				Debug.LogWarning("[BuildingObject] ClearSocketOnResale: BuildingItemSO bulunamadı! Building: " + base.gameObject.name);
				return;
			}
			Collider[] array = Physics.OverlapSphere(base.transform.position, 2f);
			T_Socket t_Socket = null;
			float num = float.MaxValue;
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				T_Socket component2 = array2[i].GetComponent<T_Socket>();
				if (component2 != null && component2.IsOccupied() && component2.SupportsBuildingType(t_BuildingItemSO))
				{
					float num2 = Vector3.Distance(base.transform.position, component2.transform.position);
					if (num2 < num)
					{
						num = num2;
						t_Socket = component2;
					}
				}
			}
			if (t_Socket != null)
			{
				t_Socket.OnBuildingRemoved(buildingPrefab);
				NetworktargetSocketNetId = 0u;
			}
			else
			{
				NetworktargetSocketNetId = 0u;
				Debug.LogWarning("[BuildingObject] ClearSocketOnResale: Uygun socket bulunamadı! Building: " + base.gameObject.name + ", BuildingSO: " + t_BuildingItemSO.Name);
			}
		}
		else
		{
			NetworktargetSocketNetId = 0u;
		}
	}

	[Server]
	private void ReturnMachineItemsToStorage()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ReturnMachineItemsToStorage()' called when server was not active");
			return;
		}
		T_Machine component = GetComponent<T_Machine>();
		if (component == null)
		{
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			return;
		}
		if (GameManager.Instance?.storageManager == null)
		{
			Debug.LogWarning($"[BuildingObject] ReturnMachineItemsToStorage: StorageManager null! Building: {base.gameObject.name}, {storedItemCounts.Count} item tipi kaybolacak!");
			return;
		}
		GameManager.Instance.storageManager.RequestAddItems(storedItemCounts);
		int num = 0;
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			num += item.Value;
		}
		DebugLog($"ReturnMachineItemsToStorage: {num} item ({storedItemCounts.Count} tip) StorageManager'a geri gönderildi - Building: {base.gameObject.name}");
	}

	private void ClearSocketOnRelocate()
	{
		if (relocateOriginalSocket != null)
		{
			relocateOriginalSocket.OnBuildingRemoved(buildingPrefab);
			NetworktargetSocketNetId = 0u;
			return;
		}
		T_Socket targetSocketFromNetId = GetTargetSocketFromNetId();
		if (targetSocketFromNetId != null)
		{
			DebugLog("ClearSocketOnRelocate: Socket found via NetId - Socket: " + targetSocketFromNetId.gameObject.name);
			targetSocketFromNetId.OnBuildingRemoved(buildingPrefab);
			NetworktargetSocketNetId = 0u;
			return;
		}
		DebugLog($"ClearSocketOnRelocate: No socket found via relocateOriginalSocket or NetId ({targetSocketNetId}), falling back to Physics search");
		if ((socketOnly || hybridMode) && buildingPrefab != null)
		{
			T_BuildingItemSO t_BuildingItemSO = null;
			BuildingObject component = buildingPrefab.GetComponent<BuildingObject>();
			t_BuildingItemSO = ((!(component != null) || !(component.buildingItemSO != null)) ? buildingItemSO : component.buildingItemSO);
			if (t_BuildingItemSO == null)
			{
				Debug.LogWarning("[BuildingObject] ClearSocketOnRelocate: BuildingItemSO bulunamadı! Building: " + base.gameObject.name);
				return;
			}
			Collider[] array = Physics.OverlapSphere(base.transform.position, 2f);
			T_Socket t_Socket = null;
			float num = float.MaxValue;
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				T_Socket component2 = array2[i].GetComponent<T_Socket>();
				if (component2 != null && component2.IsOccupied() && component2.SupportsBuildingType(t_BuildingItemSO))
				{
					float num2 = Vector3.Distance(base.transform.position, component2.transform.position);
					if (num2 < num)
					{
						num = num2;
						t_Socket = component2;
					}
				}
			}
			if (t_Socket != null)
			{
				t_Socket.OnBuildingRemoved(buildingPrefab);
				NetworktargetSocketNetId = 0u;
			}
			else
			{
				NetworktargetSocketNetId = 0u;
				Debug.LogWarning("[BuildingObject] ClearSocketOnRelocate: Uygun socket bulunamadı! Building: " + base.gameObject.name + ", BuildingSO: " + t_BuildingItemSO.Name);
			}
		}
		else
		{
			NetworktargetSocketNetId = 0u;
		}
	}

	[Server]
	private void ClearChildSocketsOnRelocate()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ClearChildSocketsOnRelocate()' called when server was not active");
			return;
		}
		T_Socket[] componentsInChildren = GetComponentsInChildren<T_Socket>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		T_Socket[] array = componentsInChildren;
		foreach (T_Socket t_Socket in array)
		{
			if (t_Socket != null && t_Socket.IsOccupied())
			{
				t_Socket.SetOccupied(occupied: false);
			}
		}
	}

	[Server]
	private void ClearExternalSocketsOnRelocate()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ClearExternalSocketsOnRelocate()' called when server was not active");
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, 3f);
		HashSet<T_Socket> hashSet = new HashSet<T_Socket>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider == null || collider.transform.IsChildOf(base.transform) || collider.transform == base.transform)
			{
				continue;
			}
			T_Socket t_Socket = collider.GetComponent<T_Socket>();
			if (t_Socket == null)
			{
				t_Socket = collider.GetComponentInParent<T_Socket>();
			}
			if (t_Socket != null && !hashSet.Contains(t_Socket))
			{
				hashSet.Add(t_Socket);
				if (t_Socket.IsOccupied() && t_Socket.OccupantNetId == base.netId)
				{
					t_Socket.OnBuildingRemoved(buildingPrefab);
					DebugLog($"ClearExternalSocketsOnRelocate: External socket temizlendi - Socket: {t_Socket.gameObject.name}, OccupantNetId: {base.netId}");
				}
			}
		}
	}

	[Server]
	private void RestoreChildSockets()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::RestoreChildSockets()' called when server was not active");
			return;
		}
		T_Socket[] componentsInChildren = GetComponentsInChildren<T_Socket>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		Vector3 position = base.transform.position;
		T_Socket[] array = componentsInChildren;
		foreach (T_Socket t_Socket in array)
		{
			if (t_Socket == null || t_Socket.IsOccupied())
			{
				continue;
			}
			Vector3 vector = t_Socket.transform.position - position;
			if (vector.sqrMagnitude < 0.001f)
			{
				continue;
			}
			float magnitude = vector.magnitude;
			RaycastHit[] array2 = Physics.RaycastAll(position, vector.normalized, magnitude);
			for (int j = 0; j < array2.Length; j++)
			{
				RaycastHit raycastHit = array2[j];
				BuildingObject componentInParent = raycastHit.collider.GetComponentInParent<BuildingObject>();
				if (componentInParent == null || !componentInParent.IsPlaced || componentInParent == this)
				{
					continue;
				}
				foreach (T_Socket.SocketableBuilding socketableBuilding in t_Socket.socketableBuildings)
				{
					if (socketableBuilding.buildingItemSO != null && socketableBuilding.buildingItemSO == componentInParent.buildingItemSO)
					{
						NetworkIdentity component = componentInParent.GetComponent<NetworkIdentity>();
						uint occupantNetId = ((component != null) ? component.netId : 0u);
						t_Socket.OnBuildingPlaced(socketableBuilding.buildingItemSO.Prefab, occupantNetId, isRestored: true);
						DebugLog($"RestoreChildSockets: Socket restored - Socket: {t_Socket.gameObject.name}, Occupant: {componentInParent.gameObject.name}, RayHitDist: {raycastHit.distance:F2}m");
						break;
					}
				}
				if (t_Socket.IsOccupied())
				{
					break;
				}
			}
		}
	}

	private T_Socket FindSocketAtPosition(Vector3 position)
	{
		if (buildingPrefab == null)
		{
			return null;
		}
		T_BuildingItemSO t_BuildingItemSO = null;
		BuildingObject component = buildingPrefab.GetComponent<BuildingObject>();
		t_BuildingItemSO = ((!(component != null) || !(component.buildingItemSO != null)) ? buildingItemSO : component.buildingItemSO);
		if (t_BuildingItemSO == null)
		{
			return null;
		}
		Collider[] array = Physics.OverlapSphere(position, 2f);
		T_Socket result = null;
		float num = float.MaxValue;
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			T_Socket component2 = array2[i].GetComponent<T_Socket>();
			if (component2 != null && component2.SupportsBuildingType(t_BuildingItemSO))
			{
				float num2 = Vector3.Distance(position, component2.transform.position);
				if (num2 < num)
				{
					num = num2;
					result = component2;
				}
			}
		}
		return result;
	}

	[ClientRpc]
	private void RpcOnBuildingResaled(int refundAmount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(refundAmount);
		SendRPCInternal("System.Void BuildingObject::RpcOnBuildingResaled(System.Int32)", -1406470491, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcOnBuildingRelocated(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void BuildingObject::RpcOnBuildingRelocated(Mirror.NetworkConnection)", 1169014590, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void HideCurrentTool(T_Equipments equipments)
	{
		if (equipments.equippedIndex >= 0 && equipments.equippedIndex < equipments.localTools.Count)
		{
			T_Tool t_Tool = equipments.localTools[equipments.equippedIndex];
			if (t_Tool != null)
			{
				ItemType itemType = t_Tool.itemType;
				equipments.SaveToolTypeForRelocate(itemType);
				equipments.TryUnequip();
			}
		}
	}

	[Server]
	public void ServerRebindSocketFromLoad()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ServerRebindSocketFromLoad()' called when server was not active");
			return;
		}
		T_Socket t_Socket = FindSocketAtPosition(base.transform.position);
		if (t_Socket == null)
		{
			Debug.LogWarning($"[BuildingObject] ServerRebindSocketFromLoad: Uygun socket bulunamadı! Building: {base.gameObject.name}, Position: {base.transform.position}");
			return;
		}
		t_Socket.OnBuildingPlaced(buildingPrefab, base.netId);
		targetSocket = t_Socket;
		SetTargetSocketNetId(t_Socket);
		DebugLog($"ServerRebindSocketFromLoad: Socket rebind başarılı - Socket: {t_Socket.gameObject.name}, Building: {base.gameObject.name}, SocketNetId: {targetSocketNetId}");
	}

	[Server]
	public void ServerSetPlacedFromLoad()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingObject::ServerSetPlacedFromLoad()' called when server was not active");
			return;
		}
		DebugLog($"ServerSetPlacedFromLoad: Building={base.gameObject.name}, UniqueId={uniqueBuildingId}, Position={base.transform.position}");
		NetworkisPlaced = true;
		NetworkisInPreviewMode = false;
		ApplyNormalModeVisuals();
		SetLayerToBuildingLayer();
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.enabled = false;
		}
		Physics.SyncTransforms();
		RpcOnBuildingPlacedFromLoad();
		DebugLog("ServerSetPlacedFromLoad: Complete - Building=" + base.gameObject.name);
	}

	[ClientRpc]
	private void RpcOnBuildingPlacedFromLoad()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BuildingObject::RpcOnBuildingPlacedFromLoad()", -88274627, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmos()
	{
		if (!showRestoreSocketGizmos)
		{
			return;
		}
		T_Socket[] componentsInChildren = GetComponentsInChildren<T_Socket>();
		if (componentsInChildren == null)
		{
			return;
		}
		T_Socket[] array = componentsInChildren;
		foreach (T_Socket t_Socket in array)
		{
			if (t_Socket == null)
			{
				continue;
			}
			Vector3 position = t_Socket.transform.position;
			Gizmos.color = Color.white;
			Gizmos.DrawSphere(position, 0.05f);
			Vector3 position2 = base.transform.position;
			if ((position - position2).sqrMagnitude > 0.001f)
			{
				if (t_Socket.IsOccupied())
				{
					Gizmos.color = new Color(1f, 0f, 0f, 0.8f);
				}
				else
				{
					Gizmos.color = new Color(0f, 1f, 0f, 0.8f);
				}
				Gizmos.DrawLine(position2, position);
				Gizmos.DrawWireSphere(position, 0.1f);
			}
		}
	}

	public BuildingObject()
	{
		_Mirror_SyncVarHookDelegate_isPreviewValid = OnPreviewStateChanged;
		_Mirror_SyncVarHookDelegate_isInPreviewMode = OnIsInPreviewModeChanged;
		_Mirror_SyncVarHookDelegate_buildingItemSOIndex = OnBuildingItemSOIndexChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetPreviewMode__Boolean(bool enabled)
	{
		NetworkisInPreviewMode = enabled;
	}

	protected static void InvokeUserCode_CmdSetPreviewMode__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPreviewMode called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdSetPreviewMode__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetPreviewValidity__Boolean(bool isValid)
	{
		NetworkisPreviewValid = isValid;
	}

	protected static void InvokeUserCode_CmdSetPreviewValidity__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPreviewValidity called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdSetPreviewValidity__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdPlaceBuilding__UInt32__Vector3__Quaternion__UInt32__Vector3__NetworkConnectionToClient(uint buildingBoxNetId, Vector3 clientFinalPosition, Quaternion clientFinalRotation, uint socketNetId, Vector3 socketPosition, NetworkConnectionToClient sender)
	{
		DebugLog($"CmdPlaceBuilding [Server] - Position: {clientFinalPosition}, BuildingBoxNetId: {buildingBoxNetId}, SocketNetId: {socketNetId}, Source: {buildingModeSource}");
		NetworkConnectionToClient ownerConnection = null;
		NetworkIdentity component = GetComponent<NetworkIdentity>();
		if (component != null && component.connectionToClient != null)
		{
			ownerConnection = component.connectionToClient;
		}
		else if (sender != null)
		{
			ownerConnection = sender;
		}
		T_Socket t_Socket = null;
		if ((socketOnly || hybridMode) && buildingPrefab != null)
		{
			if (socketNetId != 0 && NetworkServer.spawned.TryGetValue(socketNetId, out var value))
			{
				t_Socket = value.GetComponent<T_Socket>();
				if (t_Socket == null)
				{
					t_Socket = value.GetComponentInChildren<T_Socket>();
				}
			}
			if (t_Socket == null && socketPosition != Vector3.zero)
			{
				Collider[] array = Physics.OverlapSphere(socketPosition, 1f);
				float num = float.MaxValue;
				Collider[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					T_Socket component2 = array2[i].GetComponent<T_Socket>();
					if (component2 != null)
					{
						float num2 = Vector3.Distance(component2.transform.position, socketPosition);
						if (num2 < 0.5f && num2 < num)
						{
							num = num2;
							t_Socket = component2;
						}
					}
				}
			}
		}
		if (buildingModeSource == BuildingModeSource.BuildingBox)
		{
			if (buildingBoxNetId != 0 && NetworkServer.spawned.TryGetValue(buildingBoxNetId, out var value2))
			{
				NetworkServer.Destroy(value2.gameObject);
			}
		}
		else if (buildingModeSource == BuildingModeSource.Relocate)
		{
			if (relocateOriginalSocket != null && buildingPrefab != null)
			{
				relocateOriginalSocket.OnBuildingRemoved(buildingPrefab);
				DebugLog("CmdPlaceBuilding (Relocate): Eski socket serbest bırakıldı - Socket: " + relocateOriginalSocket.gameObject.name);
			}
			else if (targetSocket != null && buildingPrefab != null)
			{
				targetSocket.OnBuildingRemoved(buildingPrefab);
				DebugLog("CmdPlaceBuilding (Relocate): Eski targetSocket serbest bırakıldı - Socket: " + targetSocket.gameObject.name);
			}
			RpcSetRelocateObjectsActive(active: true);
			relocateOriginalPosition = Vector3.zero;
			relocateOriginalRotation = Quaternion.identity;
			relocateOriginalSocket = null;
		}
		if (base.isServer)
		{
			NetworkisInPreviewMode = false;
			NetworkisPlaced = true;
		}
		DisablePreviewMode();
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: false);
			if (stripesGameObject != null)
			{
				stripesGameObject.SetActive(value: true);
			}
		}
		SetLayerToBuildingLayer();
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
		}
		if (component != null && component.connectionToClient != null)
		{
			DebugLog($"CmdPlaceBuilding: Removing client authority - Connection: {component.connectionToClient}");
			component.RemoveClientAuthority();
		}
		StartCoroutine(ApplyFinalTransformDelayed(clientFinalPosition, clientFinalRotation, ownerConnection, t_Socket));
	}

	protected static void InvokeUserCode_CmdPlaceBuilding__UInt32__Vector3__Quaternion__UInt32__Vector3__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlaceBuilding called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdPlaceBuilding__UInt32__Vector3__Quaternion__UInt32__Vector3__NetworkConnectionToClient(reader.ReadVarUInt(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVarUInt(), reader.ReadVector3(), senderConnection);
		}
	}

	protected void UserCode_RpcStopBuildingModeForPalletTutorial__NetworkConnection(NetworkConnection target)
	{
		if (RadialBuildingManager.Instance != null)
		{
			RadialBuildingManager.Instance.CancelBuilding();
		}
		else if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.StopBuildingMode();
		}
	}

	protected static void InvokeUserCode_RpcStopBuildingModeForPalletTutorial__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcStopBuildingModeForPalletTutorial called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcStopBuildingModeForPalletTutorial__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcClearPlayerBuildingPickup__NetworkConnection(NetworkConnection target)
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			T_Equipments localEquipments = GameManager.Instance.localEquipments;
			localEquipments.ClearPickupItem();
			localEquipments.StopBuildingMode();
			localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_RpcClearPlayerBuildingPickup__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcClearPlayerBuildingPickup called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcClearPlayerBuildingPickup__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcUpdateSocketOnClients__UInt32__GameObject(uint socketNetId, GameObject buildingPrefab)
	{
		NetworkIdentity value;
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[BuildingObject] RpcUpdateSocketOnClients: buildingPrefab null!");
		}
		else if (NetworkClient.spawned.TryGetValue(socketNetId, out value))
		{
			T_Socket t_Socket = value.GetComponent<T_Socket>();
			if (t_Socket == null)
			{
				t_Socket = value.GetComponentInChildren<T_Socket>();
			}
			if (t_Socket != null)
			{
				t_Socket.LogSocketState("Client - RPC received");
			}
			else
			{
				Debug.LogWarning("[BuildingObject] RpcUpdateSocketOnClients: Socket component bulunamadı! GameObject: " + value.gameObject.name);
			}
		}
		else
		{
			Debug.LogWarning($"[BuildingObject] RpcUpdateSocketOnClients: Socket NetworkIdentity bulunamadı! NetId: {socketNetId}, BuildingPrefab: {buildingPrefab.name}");
		}
	}

	protected static void InvokeUserCode_RpcUpdateSocketOnClients__UInt32__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateSocketOnClients called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcUpdateSocketOnClients__UInt32__GameObject(reader.ReadVarUInt(), reader.ReadGameObject());
		}
	}

	protected void UserCode_RpcUpdateSocketOnClientsByPosition__Vector3__Vector3__GameObject(Vector3 socketPosition, Vector3 buildingPosition, GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[BuildingObject] RpcUpdateSocketOnClientsByPosition: buildingPrefab null!");
			return;
		}
		Collider[] array = Physics.OverlapSphere(socketPosition, 1f);
		T_Socket t_Socket = null;
		float num = float.MaxValue;
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			T_Socket component = array2[i].GetComponent<T_Socket>();
			if (!(component != null))
			{
				continue;
			}
			float num2 = Vector3.Distance(component.transform.position, socketPosition);
			float num3 = Vector3.Distance(component.transform.position, buildingPosition);
			if (num2 < 0.5f && num3 < 5f)
			{
				float num4 = num2 + num3 * 0.1f;
				if (num4 < num)
				{
					num = num4;
					t_Socket = component;
				}
			}
		}
		if (t_Socket == null)
		{
			Debug.LogWarning($"[BuildingObject] RpcUpdateSocketOnClientsByPosition: İlk aramada socket bulunamadı, geniş arama yapılıyor... SocketPosition: {socketPosition}, BuildingPosition: {buildingPosition}");
			array2 = Physics.OverlapSphere(buildingPosition, 5f);
			for (int i = 0; i < array2.Length; i++)
			{
				T_Socket component2 = array2[i].GetComponent<T_Socket>();
				if (component2 != null && (component2.CanPlaceBuilding(buildingPrefab, base.netId) || component2.IsOccupied()) && Vector3.Distance(component2.transform.position, socketPosition) < 2f)
				{
					t_Socket = component2;
					break;
				}
			}
		}
		if (t_Socket != null)
		{
			t_Socket.LogSocketState("Client - RPC received (by position)");
		}
		else
		{
			Debug.LogWarning($"[BuildingObject] RpcUpdateSocketOnClientsByPosition: Socket bulunamadı! SocketPosition: {socketPosition}, BuildingPosition: {buildingPosition}, BuildingPrefab: {buildingPrefab.name}");
		}
	}

	protected static void InvokeUserCode_RpcUpdateSocketOnClientsByPosition__Vector3__Vector3__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateSocketOnClientsByPosition called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcUpdateSocketOnClientsByPosition__Vector3__Vector3__GameObject(reader.ReadVector3(), reader.ReadVector3(), reader.ReadGameObject());
		}
	}

	protected void UserCode_RpcOnBuildingPlaced__Vector3__Quaternion(Vector3 finalPosition, Quaternion finalRotation)
	{
		ApplyNormalModeVisuals();
		SetLayerToBuildingLayer();
		if (!base.isServer)
		{
			base.transform.position = finalPosition;
			base.transform.rotation = finalRotation;
			Physics.SyncTransforms();
		}
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
		}
		OnBuildingPlaced?.Invoke();
		DisableNetworkTransformAfterPlacement(force: true);
	}

	protected static void InvokeUserCode_RpcOnBuildingPlaced__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnBuildingPlaced called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcOnBuildingPlaced__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdReserveSocket__UInt32__UInt32(uint socketParentNetId, uint buildingNetId)
	{
		if (NetworkServer.spawned.TryGetValue(socketParentNetId, out var value))
		{
			T_Socket t_Socket = value.GetComponent<T_Socket>();
			if (t_Socket == null)
			{
				t_Socket = value.GetComponentInChildren<T_Socket>();
			}
			if (!(t_Socket == null) && t_Socket.CanReserve(buildingNetId))
			{
				t_Socket.ReserveSocket(buildingNetId);
			}
		}
	}

	protected static void InvokeUserCode_CmdReserveSocket__UInt32__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReserveSocket called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdReserveSocket__UInt32__UInt32(reader.ReadVarUInt(), reader.ReadVarUInt());
		}
	}

	protected void UserCode_CmdUnreserveSocket__UInt32__UInt32(uint socketParentNetId, uint buildingNetId)
	{
		if (NetworkServer.spawned.TryGetValue(socketParentNetId, out var value))
		{
			T_Socket t_Socket = value.GetComponent<T_Socket>();
			if (t_Socket == null)
			{
				t_Socket = value.GetComponentInChildren<T_Socket>();
			}
			if (!(t_Socket == null))
			{
				t_Socket.UnreserveSocket(buildingNetId);
			}
		}
	}

	protected static void InvokeUserCode_CmdUnreserveSocket__UInt32__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUnreserveSocket called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdUnreserveSocket__UInt32__UInt32(reader.ReadVarUInt(), reader.ReadVarUInt());
		}
	}

	protected void UserCode_CmdCancelBuilding()
	{
		NetworkServer.Destroy(base.gameObject);
	}

	protected static void InvokeUserCode_CmdCancelBuilding(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCancelBuilding called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdCancelBuilding();
		}
	}

	protected void UserCode_CmdCancelRelocate__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (!base.isServer)
		{
			return;
		}
		DebugLog(string.Format("CmdCancelRelocate: Building={0}, RestoringTo={1}, OriginalSocket={2}", base.gameObject.name, relocateOriginalPosition, (relocateOriginalSocket != null) ? relocateOriginalSocket.gameObject.name : "null"));
		NetworkIdentity component = GetComponent<NetworkIdentity>();
		if (component != null && component.connectionToClient != null)
		{
			component.RemoveClientAuthority();
		}
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
		}
		base.transform.position = relocateOriginalPosition;
		base.transform.rotation = relocateOriginalRotation;
		Physics.SyncTransforms();
		if (networkTransform != null)
		{
			networkTransform.ServerTeleport(relocateOriginalPosition, relocateOriginalRotation);
			networkTransform.enabled = false;
		}
		if (relocateOriginalSocket != null)
		{
			targetSocket = relocateOriginalSocket;
			SetTargetSocketNetId(relocateOriginalSocket);
		}
		else if ((socketOnly || hybridMode) && buildingPrefab != null)
		{
			T_Socket t_Socket = FindSocketAtPosition(relocateOriginalPosition);
			if (t_Socket != null)
			{
				targetSocket = t_Socket;
				SetTargetSocketNetId(t_Socket);
			}
			else
			{
				Debug.LogWarning($"[BuildingObject] CmdCancelRelocate: Eski pozisyonda socket bulunamadı! Building: {base.gameObject.name}, Position: {relocateOriginalPosition}");
			}
		}
		NetworkisPlaced = true;
		NetworkisInPreviewMode = false;
		NetworkbuildingModeSource = BuildingModeSource.None;
		RestoreChildSockets();
		RpcRestorePlacedVisualsWithPosition(relocateOriginalPosition, relocateOriginalRotation);
	}

	protected static void InvokeUserCode_CmdCancelRelocate__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCancelRelocate called on client.");
		}
		else
		{
			((BuildingObject)obj).UserCode_CmdCancelRelocate__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcRestorePlacedVisuals()
	{
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: false);
		}
		if (stripesGameObject != null)
		{
			stripesGameObject.SetActive(value: false);
		}
		SetRelocateObjectsActive(active: true);
	}

	protected static void InvokeUserCode_RpcRestorePlacedVisuals(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRestorePlacedVisuals called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcRestorePlacedVisuals();
		}
	}

	protected void UserCode_RpcRestorePlacedVisualsWithPosition__Vector3__Quaternion(Vector3 originalPosition, Quaternion originalRotation)
	{
		base.transform.SetPositionAndRotation(originalPosition, originalRotation);
		Physics.SyncTransforms();
		if (networkTransform != null)
		{
			networkTransform.syncDirection = SyncDirection.ServerToClient;
			networkTransform.ResetState();
			networkTransform.enabled = false;
		}
		if (previewGameObject != null)
		{
			previewGameObject.SetActive(value: false);
		}
		if (stripesGameObject != null)
		{
			stripesGameObject.SetActive(value: false);
		}
		SetRelocateObjectsActive(active: true);
	}

	protected static void InvokeUserCode_RpcRestorePlacedVisualsWithPosition__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRestorePlacedVisualsWithPosition called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcRestorePlacedVisualsWithPosition__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcSetRelocateObjectsActive__Boolean(bool active)
	{
		SetRelocateObjectsActive(active);
	}

	protected static void InvokeUserCode_RpcSetRelocateObjectsActive__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetRelocateObjectsActive called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcSetRelocateObjectsActive__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcEnableNetworkTransformForRelocate()
	{
		if (networkTransform != null)
		{
			networkTransform.enabled = true;
			networkTransform.syncDirection = SyncDirection.ClientToServer;
			networkTransform.ResetState();
		}
	}

	protected static void InvokeUserCode_RpcEnableNetworkTransformForRelocate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEnableNetworkTransformForRelocate called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcEnableNetworkTransformForRelocate();
		}
	}

	protected void UserCode_RpcOnBuildingResaled__Int32(int refundAmount)
	{
	}

	protected static void InvokeUserCode_RpcOnBuildingResaled__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnBuildingResaled called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcOnBuildingResaled__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcOnBuildingRelocated__NetworkConnection(NetworkConnection target)
	{
		targetSocket = null;
		if (buildingPrefab == null && buildingItemSO != null && buildingItemSO.Prefab != null)
		{
			buildingPrefab = buildingItemSO.Prefab;
		}
		ApplyPreviewModeVisuals();
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			T_Equipments localEquipments = GameManager.Instance.localEquipments;
			HideCurrentTool(localEquipments);
			if (localEquipments.buildingInteractionManager != null)
			{
				localEquipments.buildingInteractionManager.SetInputActive(input: true);
				localEquipments.buildingInteractionManager.SetBuildingObject(this, buildingPrefab, buildingItemSO, BuildingModeSource.Relocate);
				if (GameManager.Instance != null && GameManager.Instance.UImanager != null && buildingItemSO != null)
				{
					UIManager uImanager = GameManager.Instance.UImanager;
					uImanager.SetBuildingBoxUI(buildingItemSO);
					uImanager.StartBuildingBoxPlaceMode(buildingItemSO);
				}
				localEquipments.SetCurrentBuildingSource(BuildingModeSource.Relocate);
			}
		}
		if (GameManager.Instance != null)
		{
			_ = GameManager.Instance.notificationManager != null;
		}
	}

	protected static void InvokeUserCode_RpcOnBuildingRelocated__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcOnBuildingRelocated called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcOnBuildingRelocated__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcOnBuildingPlacedFromLoad()
	{
		ApplyNormalModeVisuals();
		SetLayerToBuildingLayer();
		if (networkTransform != null)
		{
			networkTransform.enabled = false;
		}
		OnBuildingPlaced?.Invoke();
	}

	protected static void InvokeUserCode_RpcOnBuildingPlacedFromLoad(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnBuildingPlacedFromLoad called on server.");
		}
		else
		{
			((BuildingObject)obj).UserCode_RpcOnBuildingPlacedFromLoad();
		}
	}

	static BuildingObject()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdSetPreviewMode(System.Boolean)", InvokeUserCode_CmdSetPreviewMode__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdSetPreviewValidity(System.Boolean)", InvokeUserCode_CmdSetPreviewValidity__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdPlaceBuilding(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion,System.UInt32,UnityEngine.Vector3,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdPlaceBuilding__UInt32__Vector3__Quaternion__UInt32__Vector3__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdReserveSocket(System.UInt32,System.UInt32)", InvokeUserCode_CmdReserveSocket__UInt32__UInt32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdUnreserveSocket(System.UInt32,System.UInt32)", InvokeUserCode_CmdUnreserveSocket__UInt32__UInt32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdCancelBuilding()", InvokeUserCode_CmdCancelBuilding, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingObject), "System.Void BuildingObject::CmdCancelRelocate(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdCancelRelocate__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcUpdateSocketOnClients(System.UInt32,UnityEngine.GameObject)", InvokeUserCode_RpcUpdateSocketOnClients__UInt32__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcUpdateSocketOnClientsByPosition(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.GameObject)", InvokeUserCode_RpcUpdateSocketOnClientsByPosition__Vector3__Vector3__GameObject);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcOnBuildingPlaced(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcOnBuildingPlaced__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcRestorePlacedVisuals()", InvokeUserCode_RpcRestorePlacedVisuals);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcRestorePlacedVisualsWithPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcRestorePlacedVisualsWithPosition__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcSetRelocateObjectsActive(System.Boolean)", InvokeUserCode_RpcSetRelocateObjectsActive__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcEnableNetworkTransformForRelocate()", InvokeUserCode_RpcEnableNetworkTransformForRelocate);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcOnBuildingResaled(System.Int32)", InvokeUserCode_RpcOnBuildingResaled__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcOnBuildingPlacedFromLoad()", InvokeUserCode_RpcOnBuildingPlacedFromLoad);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcStopBuildingModeForPalletTutorial(Mirror.NetworkConnection)", InvokeUserCode_RpcStopBuildingModeForPalletTutorial__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcClearPlayerBuildingPickup(Mirror.NetworkConnection)", InvokeUserCode_RpcClearPlayerBuildingPickup__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingObject), "System.Void BuildingObject::RpcOnBuildingRelocated(Mirror.NetworkConnection)", InvokeUserCode_RpcOnBuildingRelocated__NetworkConnection);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(uniqueBuildingId);
			writer.WriteBool(isPreviewValid);
			writer.WriteBool(isInPreviewMode);
			writer.WriteBool(isPlaced);
			writer.WriteVarInt(buildingItemSOIndex);
			writer.WriteVarUInt(pickupItemNetId);
			GeneratedNetworkCode._Write_BuildingModeSource(writer, buildingModeSource);
			writer.WriteVarUInt(targetSocketNetId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(uniqueBuildingId);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isPreviewValid);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isInPreviewMode);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(isPlaced);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteVarInt(buildingItemSOIndex);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteVarUInt(pickupItemNetId);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			GeneratedNetworkCode._Write_BuildingModeSource(writer, buildingModeSource);
		}
		if ((syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteVarUInt(targetSocketNetId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref uniqueBuildingId, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref isPreviewValid, _Mirror_SyncVarHookDelegate_isPreviewValid, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isInPreviewMode, _Mirror_SyncVarHookDelegate_isInPreviewMode, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isPlaced, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref buildingItemSOIndex, _Mirror_SyncVarHookDelegate_buildingItemSOIndex, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref pickupItemNetId, null, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref buildingModeSource, null, GeneratedNetworkCode._Read_BuildingModeSource(reader));
			GeneratedSyncVarDeserialize(ref targetSocketNetId, null, reader.ReadVarUInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref uniqueBuildingId, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isPreviewValid, _Mirror_SyncVarHookDelegate_isPreviewValid, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInPreviewMode, _Mirror_SyncVarHookDelegate_isInPreviewMode, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isPlaced, null, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref buildingItemSOIndex, _Mirror_SyncVarHookDelegate_buildingItemSOIndex, reader.ReadVarInt());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref pickupItemNetId, null, reader.ReadVarUInt());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref buildingModeSource, null, GeneratedNetworkCode._Read_BuildingModeSource(reader));
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref targetSocketNetId, null, reader.ReadVarUInt());
		}
	}
}
