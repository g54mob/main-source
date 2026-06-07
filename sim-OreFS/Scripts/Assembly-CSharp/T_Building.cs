using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using UnityEngine;

public class T_Building : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class BuildingBoxSaveData
	{
		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public int buildingItemSOIndex;
	}

	[Header("Building Item SO")]
	[Tooltip("Building Item ScriptableObject - Building verilerini tutar (Name, Description, Icon, Price, Prefab, Level)")]
	[SerializeField]
	private T_BuildingItemSO buildingItemSO;

	[Header("Network")]
	[SyncVar(hook = "OnBuildingItemSOIndexChanged")]
	private int buildingItemSOIndex = -1;

	[SyncVar]
	private string uniqueId;

	[Header("Icon")]
	[Tooltip("Icon SpriteRenderer component'i - BuildingItemSO'dan icon gösterilecek (3D obje üzerinde)")]
	[SerializeField]
	private SpriteRenderer iconRenderer;

	[Header("Interactable")]
	[Tooltip("Interactable component'i - Building kutusu için interactable özellikleri")]
	[SerializeField]
	private Interactable interactable;

	[Header("Building Settings")]
	[SerializeField]
	private GameObject buildingVisual;

	[SerializeField]
	private Collider buildingCollider;

	[Header("Physics")]
	[SerializeField]
	private Rigidbody rb;

	[SerializeField]
	private float throwForce = 10f;

	[SerializeField]
	private Vector3 throwDirection = Vector3.forward;

	[Header("Pickup Settings")]
	[SerializeField]
	private float pickupRadius = 2f;

	public Action<int, int> _Mirror_SyncVarHookDelegate_buildingItemSOIndex;

	public T_BuildingItemSO BuildingItemSO => buildingItemSO;

	public string UniqueId => uniqueId;

	public string SaveID => "building-box-" + uniqueId;

	public bool IsShared => false;

	public Type SaveType => typeof(BuildingBoxSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public int NetworkbuildingItemSOIndex
	{
		get
		{
			return buildingItemSOIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref buildingItemSOIndex, 1uL, _Mirror_SyncVarHookDelegate_buildingItemSOIndex);
		}
	}

	public string NetworkuniqueId
	{
		get
		{
			return uniqueId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref uniqueId, 2uL, null);
		}
	}

	public void SetUniqueId(string id)
	{
		NetworkuniqueId = id;
	}

	public void SetBuildingItemSO(T_BuildingItemSO so)
	{
		buildingItemSO = so;
		string text = ((so != null) ? so.Name : "null");
		Debug.Log("[T_Building] SetBuildingItemSO: " + text + " set edildi.");
		if (interactable != null && so != null)
		{
			interactable.interactableName = so.Name;
			Debug.Log("[T_Building] Interactable name set edildi: " + so.Name);
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
			Debug.LogWarning($"[T_Building] OnBuildingItemSOIndexChanged: Geçersiz SO index! Index: {newIndex}, List Count: {allBuildingItemSOs.Count}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = allBuildingItemSOs[newIndex];
		if (t_BuildingItemSO != null)
		{
			SetBuildingItemSO(t_BuildingItemSO);
			SetIcon(t_BuildingItemSO.Icon);
			Debug.Log("[T_Building] OnBuildingItemSOIndexChanged: BuildingItemSO set edildi (sonradan bağlanan client için): " + t_BuildingItemSO.Name);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (buildingItemSOIndex != -1)
		{
			OnBuildingItemSOIndexChanged(-1, buildingItemSOIndex);
		}
	}

	private void Awake()
	{
		EnsureRefs();
		if (string.IsNullOrEmpty(uniqueId))
		{
			NetworkuniqueId = Guid.NewGuid().ToString();
		}
	}

	private void EnsureRefs()
	{
		if (!rb)
		{
			rb = GetComponent<Rigidbody>();
		}
		if (!buildingCollider)
		{
			buildingCollider = GetComponent<Collider>();
		}
		if (!buildingVisual)
		{
			buildingVisual = base.gameObject;
		}
		if (!iconRenderer)
		{
			iconRenderer = GetComponentInChildren<SpriteRenderer>();
		}
		if (!interactable)
		{
			interactable = GetComponent<Interactable>();
		}
	}

	public GameObject GetBuildingPrefab()
	{
		if (buildingItemSO != null && buildingItemSO.Prefab != null)
		{
			Debug.Log("[T_Building] GetBuildingPrefab: BuildingItemSO'dan prefab döndürülüyor. SO: " + buildingItemSO.Name + ", Prefab: " + buildingItemSO.Prefab.name);
			return buildingItemSO.Prefab;
		}
		Debug.LogError("[T_Building] GetBuildingPrefab: buildingItemSO null veya Prefab null! BuildingItemSO set edilmemiş olabilir.");
		return null;
	}

	public void SetIcon(Sprite icon)
	{
		if (iconRenderer != null && icon != null)
		{
			iconRenderer.sprite = icon;
			iconRenderer.enabled = true;
			Debug.Log("[T_Building] Icon set edildi: " + icon.name);
		}
		else if (iconRenderer == null)
		{
			Debug.LogWarning("[T_Building] SetIcon: iconRenderer component'i bulunamadı!");
		}
		else if (icon == null && iconRenderer != null)
		{
			iconRenderer.enabled = false;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		EnsureRefs();
		if ((bool)rb)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.linearDamping = 0.5f;
		}
		if (buildingCollider != null && !buildingCollider.enabled)
		{
			buildingCollider.enabled = true;
			Debug.LogWarning("T_Building: Collider kapalıydı! Aktif edildi.");
		}
		else if (buildingCollider == null)
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			buildingCollider = boxCollider;
			Debug.LogWarning("T_Building: Collider yok! Otomatik BoxCollider eklendi.");
		}
		DynamicObjectSpawner.Instance?.RegisterBuildingBox(this);
		SaveLoadManager.Subscribe(this, 60);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		DynamicObjectSpawner.Instance?.UnregisterBuildingBox(uniqueId);
		SaveLoadManager.Unsubscribe(this);
	}

	[Server]
	public void ServerThrow(Vector3 position, Vector3 direction, float force)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Building::ServerThrow(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)' called when server was not active");
			return;
		}
		if (rb == null)
		{
			EnsureRefs();
		}
		base.transform.position = position;
		if ((bool)rb)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.AddForce(direction * force, ForceMode.VelocityChange);
			Debug.Log($"T_Building: Building kutusu fırlatıldı - Yön: {direction}, Force: {force}, Velocity: {rb.linearVelocity}");
		}
		else
		{
			Debug.LogError("T_Building: ServerThrow - Rigidbody bulunamadı! Fiziksel tepkime olmayacak!");
		}
	}

	public void OnBuildingPickupSuccess()
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && buildingItemSO != null)
		{
			GameManager.Instance.UImanager.SetBuildingBoxUI(buildingItemSO);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, pickupRadius);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		Vector3 vector = ((rb != null) ? rb.position : base.transform.position);
		Quaternion quaternion = ((rb != null) ? rb.rotation : base.transform.rotation);
		BuildingBoxSaveData result = new BuildingBoxSaveData
		{
			posX = vector.x,
			posY = vector.y,
			posZ = vector.z,
			rotX = quaternion.x,
			rotY = quaternion.y,
			rotZ = quaternion.z,
			rotW = quaternion.w,
			buildingItemSOIndex = buildingItemSOIndex
		};
		Debug.Log($"[T_Building] GetSaveData - ID: {uniqueId}, SOIndex: {buildingItemSOIndex}");
		return result;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is BuildingBoxSaveData buildingBoxSaveData))
		{
			Debug.LogWarning("[T_Building] OnLoad - Invalid data type for building: " + uniqueId);
			return Task.CompletedTask;
		}
		Vector3 position = new Vector3(buildingBoxSaveData.posX, buildingBoxSaveData.posY, buildingBoxSaveData.posZ);
		Quaternion rotation = new Quaternion(buildingBoxSaveData.rotX, buildingBoxSaveData.rotY, buildingBoxSaveData.rotZ, buildingBoxSaveData.rotW);
		if (rb != null)
		{
			SaveLoadGameManager.RegisterKinematicForLoad(rb);
			rb.position = position;
			rb.rotation = rotation;
		}
		base.transform.SetPositionAndRotation(position, rotation);
		if (buildingBoxSaveData.buildingItemSOIndex >= 0)
		{
			SetBuildingItemSOIndex(buildingBoxSaveData.buildingItemSOIndex);
			IReadOnlyList<T_BuildingItemSO> readOnlyList = ScriptableListManager.Instance?.AllBuildingItemSOs;
			if (readOnlyList != null && buildingBoxSaveData.buildingItemSOIndex < readOnlyList.Count)
			{
				T_BuildingItemSO t_BuildingItemSO = readOnlyList[buildingBoxSaveData.buildingItemSOIndex];
				if (t_BuildingItemSO != null)
				{
					SetBuildingItemSO(t_BuildingItemSO);
					SetIcon(t_BuildingItemSO.Icon);
				}
			}
		}
		Debug.Log($"[T_Building] OnLoad - ID: {uniqueId}, SOIndex: {buildingItemSOIndex}");
		return Task.CompletedTask;
	}

	public T_Building()
	{
		_Mirror_SyncVarHookDelegate_buildingItemSOIndex = OnBuildingItemSOIndexChanged;
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
			writer.WriteVarInt(buildingItemSOIndex);
			writer.WriteString(uniqueId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(buildingItemSOIndex);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteString(uniqueId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref buildingItemSOIndex, _Mirror_SyncVarHookDelegate_buildingItemSOIndex, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref uniqueId, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref buildingItemSOIndex, _Mirror_SyncVarHookDelegate_buildingItemSOIndex, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref uniqueId, null, reader.ReadString());
		}
	}
}
