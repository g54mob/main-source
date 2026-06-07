using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class T_Socket : NetworkBehaviour
{
	[Serializable]
	public class SocketableBuilding
	{
		[Tooltip("Yerleştirilebilecek Building'in ScriptableObject referansı (Prefab yerine SO kullanılır - runtime clone sorununu önler)")]
		public T_BuildingItemSO buildingItemSO;

		[Tooltip("Bu building'in socket'e göre local pozisyonu (socket'in transform'una göre)")]
		public Vector3 localPosition;

		[Tooltip("Bu building'in socket'e göre local rotasyonu (socket'in transform'una göre)")]
		public Vector3 localRotation = Vector3.zero;

		[Tooltip("true ise tutorial esnasında bu building bu socket'e yerleştirilemez (yapışır ama place edilemez)")]
		public bool lockedInTutorial;

		public GameObject GetPrefab()
		{
			if (!(buildingItemSO != null))
			{
				return null;
			}
			return buildingItemSO.Prefab;
		}
	}

	private const bool ENABLE_DEBUG_LOGS = true;

	[Header("Socket Settings")]
	[Tooltip("Bu socket'e yerleştirilebilecek building'lerin listesi")]
	public List<SocketableBuilding> socketableBuildings = new List<SocketableBuilding>();

	[Header("Socket State")]
	[Tooltip("Bu socket dolu mu? (Herhangi bir building yerleştirilmiş mi?) - Network senkronize edilir")]
	[SyncVar]
	[SerializeField]
	private bool _isOccupied;

	[Tooltip("Socket'i işgal eden objenin network ID'si (0 = boş veya bilinmiyor)")]
	[SyncVar]
	private uint _occupantNetId;

	private bool _isRestoredOccupancy;

	[Header("Reservation State")]
	[Tooltip("Bu socket bir player tarafından preview modda reserve edilmiş mi? - Network senkronize edilir")]
	[SyncVar]
	[SerializeField]
	private bool _isReserved;

	[Tooltip("Socket'i reserve eden preview building'in network ID'si (0 = reserve yok)")]
	[SyncVar]
	private uint _reservedByNetId;

	private const float VALIDATION_INTERVAL = 5f;

	[Header("Debug")]
	[Tooltip("Socket pozisyonunu görselleştirmek için gizmo göster")]
	public bool showGizmos = true;

	public float gizmoSize = 0.5f;

	public uint OccupantNetId => _occupantNetId;

	public bool IsReserved => _isReserved;

	public uint ReservedByNetId => _reservedByNetId;

	public bool Network_isOccupied
	{
		get
		{
			return _isOccupied;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isOccupied, 1uL, null);
		}
	}

	public uint Network_occupantNetId
	{
		get
		{
			return _occupantNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _occupantNetId, 2uL, null);
		}
	}

	public bool Network_isReserved
	{
		get
		{
			return _isReserved;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isReserved, 4uL, null);
		}
	}

	public uint Network_reservedByNetId
	{
		get
		{
			return _reservedByNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _reservedByNetId, 8uL, null);
		}
	}

	public bool CanPlaceBuilding(GameObject buildingPrefab, uint relocatingNetId = 0u, uint callerNetId = 0u)
	{
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[T_Socket] CanPlaceBuilding: buildingPrefab null! Socket: " + base.gameObject.name);
			return false;
		}
		if (_isReserved && _reservedByNetId != 0 && (callerNetId == 0 || _reservedByNetId != callerNetId) && (relocatingNetId == 0 || _reservedByNetId != relocatingNetId))
		{
			Debug.LogWarning($"[T_Socket] CanPlaceBuilding: Socket başka bir building tarafından reserve edilmiş! Socket: {base.gameObject.name}, ReservedBy: {_reservedByNetId}, CallerNetId: {callerNetId}");
			return false;
		}
		if (_isOccupied)
		{
			if (relocatingNetId != 0 && _occupantNetId == relocatingNetId)
			{
				Debug.Log($"[T_Socket] CanPlaceBuilding: Socket occupied ama occupant relocate eden building'in kendisi. Socket: {base.gameObject.name}, RelocatingNetId: {relocatingNetId}");
			}
			else
			{
				if (base.isServer && _occupantNetId != 0)
				{
					NetworkIdentity value;
					if (!NetworkServer.spawned.ContainsKey(_occupantNetId))
					{
						Debug.Log($"[T_Socket] CanPlaceBuilding: Stale occupant tespit edildi (destroyed). occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
						Network_isOccupied = false;
						Network_occupantNetId = 0u;
					}
					else if (NetworkServer.spawned.TryGetValue(_occupantNetId, out value) && value != null)
					{
						T_Pallet component = value.GetComponent<T_Pallet>();
						if (component != null && component.IsLifted)
						{
							Debug.Log("[T_Socket] CanPlaceBuilding: Occupant pallet forklift üzerinde. Socket: " + base.gameObject.name + ". Socket serbest bırakılıyor.");
							Network_isOccupied = false;
							Network_occupantNetId = 0u;
						}
						else
						{
							T_DeliveryPallet component2 = value.GetComponent<T_DeliveryPallet>();
							if (component2 != null && component2.IsLifted)
							{
								Debug.Log("[T_Socket] CanPlaceBuilding: Occupant delivery pallet forklift üzerinde. Socket: " + base.gameObject.name + ". Socket serbest bırakılıyor.");
								Network_isOccupied = false;
								Network_occupantNetId = 0u;
							}
						}
					}
				}
				if (_isOccupied)
				{
					Debug.LogWarning("[T_Socket] CanPlaceBuilding: Socket dolu! Başka bir item yerleştirilemez. Socket: " + base.gameObject.name);
					return false;
				}
			}
		}
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		if (buildingItemSOFromPrefab == null)
		{
			Debug.LogWarning("[T_Socket] CanPlaceBuilding: SO bulunamadı! BuildingPrefab: " + buildingPrefab.name + ", Socket: " + base.gameObject.name);
			return false;
		}
		Debug.Log($"[T_Socket] CanPlaceBuilding: SO bulundu - {buildingItemSOFromPrefab.Name}, Socket: {base.gameObject.name}, SocketableCount: {socketableBuildings.Count}");
		foreach (SocketableBuilding socketableBuilding in socketableBuildings)
		{
			if (socketableBuilding.buildingItemSO == null)
			{
				Debug.Log("[T_Socket] CanPlaceBuilding: Socketable'da SO null!");
				continue;
			}
			bool flag = socketableBuilding.buildingItemSO == buildingItemSOFromPrefab;
			Debug.Log($"[T_Socket] CanPlaceBuilding: Socketable kontrolü - SO: {socketableBuilding.buildingItemSO.Name}, Eşit mi: {flag}");
			if (!flag)
			{
				continue;
			}
			Debug.Log("[T_Socket] CanPlaceBuilding: Eşleşme bulundu! Building: " + buildingItemSOFromPrefab.Name + ", Socket: " + base.gameObject.name);
			return true;
		}
		Debug.LogWarning("[T_Socket] CanPlaceBuilding: Eşleşme bulunamadı! Building SO: " + buildingItemSOFromPrefab.Name + ", Socket: " + base.gameObject.name);
		return false;
	}

	private T_BuildingItemSO GetBuildingItemSOFromPrefab(GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			return null;
		}
		BuildingObject component = buildingPrefab.GetComponent<BuildingObject>();
		if (component != null && component.buildingItemSO != null)
		{
			Debug.Log("[T_Socket] GetBuildingItemSOFromPrefab: SO BuildingObject'ten alındı - " + component.buildingItemSO.Name);
			return component.buildingItemSO;
		}
		GameObject prefabReference = GetPrefabReference(buildingPrefab);
		if (prefabReference != null)
		{
			BuildingObject component2 = prefabReference.GetComponent<BuildingObject>();
			if (component2 != null)
			{
				if (component2.buildingItemSO != null)
				{
					Debug.Log("[T_Socket] GetBuildingItemSOFromPrefab: SO prefab BuildingObject'ten alındı - " + component2.buildingItemSO.Name);
					return component2.buildingItemSO;
				}
				if (component2.buildingPrefab != null)
				{
					T_Building component3 = component2.buildingPrefab.GetComponent<T_Building>();
					if (component3 != null && component3.BuildingItemSO != null)
					{
						Debug.Log("[T_Socket] GetBuildingItemSOFromPrefab: SO prefab buildingPrefab'dan alındı - " + component3.BuildingItemSO.Name);
						return component3.BuildingItemSO;
					}
				}
			}
		}
		if (prefabReference != null)
		{
			T_Building component4 = prefabReference.GetComponent<T_Building>();
			if (component4 != null && component4.BuildingItemSO != null)
			{
				Debug.Log("[T_Socket] GetBuildingItemSOFromPrefab: SO direkt prefab'dan alındı - " + component4.BuildingItemSO.Name);
				return component4.BuildingItemSO;
			}
		}
		Debug.LogWarning("[T_Socket] GetBuildingItemSOFromPrefab: SO bulunamadı! BuildingPrefab: " + buildingPrefab.name);
		return null;
	}

	private GameObject GetPrefabReference(GameObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return obj;
	}

	public bool GetSocketPosition(GameObject buildingPrefab, out Vector3 position, out Quaternion rotation)
	{
		position = Vector3.zero;
		rotation = Quaternion.identity;
		if (buildingPrefab == null)
		{
			return false;
		}
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		if (buildingItemSOFromPrefab == null)
		{
			return false;
		}
		foreach (SocketableBuilding socketableBuilding in socketableBuildings)
		{
			if (!(socketableBuilding.buildingItemSO == null) && socketableBuilding.buildingItemSO == buildingItemSOFromPrefab)
			{
				position = base.transform.TransformPoint(socketableBuilding.localPosition);
				rotation = base.transform.rotation * Quaternion.Euler(socketableBuilding.localRotation);
				return true;
			}
		}
		return false;
	}

	public void OnBuildingPlaced(GameObject buildingPrefab, uint occupantNetId, bool isRestored = false)
	{
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[T_Socket] OnBuildingPlaced: buildingPrefab null! Socket: " + base.gameObject.name);
			return;
		}
		if (!base.isServer)
		{
			Debug.LogWarning("[T_Socket] OnBuildingPlaced: Client tarafında çağrıldı! SyncVar değişikliği çalışmayacak. Socket: " + base.gameObject.name + ", Building: " + buildingPrefab.name);
			return;
		}
		bool isOccupied = _isOccupied;
		Network_isOccupied = true;
		Network_occupantNetId = occupantNetId;
		_isRestoredOccupancy = isRestored;
		Network_isReserved = false;
		Network_reservedByNetId = 0u;
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		string text = ((buildingItemSOFromPrefab != null) ? buildingItemSOFromPrefab.Name : "Unknown");
		Debug.Log($"[T_Socket] OnBuildingPlaced (SERVER): Building yerleştirildi - Building: {buildingPrefab.name}, Socket: {base.gameObject.name}, SO: {text}, OccupantNetId: {occupantNetId}, WasOccupied: {isOccupied}, NowOccupied: {_isOccupied}");
	}

	public void OnBuildingPlaced(GameObject buildingPrefab)
	{
		OnBuildingPlaced(buildingPrefab, 0u);
	}

	public void OnBuildingRemoved(GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			Debug.LogWarning("[T_Socket] OnBuildingRemoved: buildingPrefab null! Socket: " + base.gameObject.name);
			return;
		}
		if (!base.isServer)
		{
			Debug.LogWarning("[T_Socket] OnBuildingRemoved: Client tarafında çağrıldı! SyncVar değişikliği çalışmayacak. Socket: " + base.gameObject.name + ", Building: " + buildingPrefab.name);
			return;
		}
		bool isOccupied = _isOccupied;
		uint occupantNetId = _occupantNetId;
		Network_isOccupied = false;
		Network_occupantNetId = 0u;
		_isRestoredOccupancy = false;
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		string text = ((buildingItemSOFromPrefab != null) ? buildingItemSOFromPrefab.Name : "Unknown");
		Debug.Log($"[T_Socket] OnBuildingRemoved (SERVER): Building kaldırıldı - Building: {buildingPrefab.name}, Socket: {base.gameObject.name}, SO: {text}, OccupantNetId: {occupantNetId}, WasOccupied: {isOccupied}, NowOccupied: {_isOccupied}");
	}

	[Server]
	public void ReserveSocket(uint buildingNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Socket::ReserveSocket(System.UInt32)' called when server was not active");
			return;
		}
		if (_isOccupied)
		{
			Debug.LogWarning($"[T_Socket] ReserveSocket: Socket zaten occupied! Reserve yapılamaz. Socket: {base.gameObject.name}, BuildingNetId: {buildingNetId}");
			return;
		}
		if (_isReserved && _reservedByNetId != buildingNetId)
		{
			Debug.LogWarning($"[T_Socket] ReserveSocket: Socket zaten başka bir building tarafından reserve edilmiş! Socket: {base.gameObject.name}, MevcutReserve: {_reservedByNetId}, YeniTalep: {buildingNetId}");
			return;
		}
		Network_isReserved = true;
		Network_reservedByNetId = buildingNetId;
		Debug.Log($"[T_Socket] ReserveSocket (SERVER): Socket reserve edildi - Socket: {base.gameObject.name}, BuildingNetId: {buildingNetId}");
	}

	[Server]
	public void UnreserveSocket(uint buildingNetId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Socket::UnreserveSocket(System.UInt32)' called when server was not active");
		}
		else if (_isReserved)
		{
			if (buildingNetId != 0 && _reservedByNetId != buildingNetId)
			{
				Debug.LogWarning($"[T_Socket] UnreserveSocket: Bu building reserve sahibi değil! Socket: {base.gameObject.name}, ReservedBy: {_reservedByNetId}, Requester: {buildingNetId}");
				return;
			}
			Debug.Log($"[T_Socket] UnreserveSocket (SERVER): Reserve kaldırıldı - Socket: {base.gameObject.name}, BuildingNetId: {_reservedByNetId}");
			Network_isReserved = false;
			Network_reservedByNetId = 0u;
		}
	}

	public bool CanReserve(uint buildingNetId)
	{
		if (_isOccupied)
		{
			return false;
		}
		if (!_isReserved)
		{
			return true;
		}
		return _reservedByNetId == buildingNetId;
	}

	public bool IsOccupied()
	{
		return _isOccupied;
	}

	public bool IsLockedInTutorial(GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			return false;
		}
		if (TutorialManager.Instance == null || !TutorialManager.Instance.IsTutorialRunning)
		{
			return false;
		}
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		if (buildingItemSOFromPrefab == null)
		{
			return false;
		}
		foreach (SocketableBuilding socketableBuilding in socketableBuildings)
		{
			if (socketableBuilding.buildingItemSO == buildingItemSOFromPrefab && socketableBuilding.lockedInTutorial)
			{
				return true;
			}
		}
		return false;
	}

	public bool SupportsBuildingType(T_BuildingItemSO buildingItemSO)
	{
		if (buildingItemSO == null)
		{
			return false;
		}
		foreach (SocketableBuilding socketableBuilding in socketableBuildings)
		{
			if (socketableBuilding.buildingItemSO == buildingItemSO)
			{
				return true;
			}
		}
		return false;
	}

	public bool SupportsBuildingPrefab(GameObject buildingPrefab)
	{
		if (buildingPrefab == null)
		{
			return false;
		}
		T_BuildingItemSO buildingItemSOFromPrefab = GetBuildingItemSOFromPrefab(buildingPrefab);
		return SupportsBuildingType(buildingItemSOFromPrefab);
	}

	public void SetOccupied(bool occupied)
	{
		if (!base.isServer)
		{
			Debug.LogWarning($"[T_Socket] SetOccupied: Client tarafında çağrıldı! SyncVar değişikliği çalışmayacak. Socket: {base.gameObject.name}, Occupied: {occupied}");
			return;
		}
		Network_isOccupied = occupied;
		if (!occupied)
		{
			Network_occupantNetId = 0u;
		}
	}

	public void LogSocketState(string context = "")
	{
		bool active = NetworkServer.active;
		bool active2 = NetworkClient.active;
		string text = (active ? "SERVER" : (active2 ? "CLIENT" : "LOCAL"));
		Debug.Log($"[T_Socket] LogSocketState ({text}) - Socket: {base.gameObject.name}, Context: {context}, TotalSocketables: {socketableBuildings.Count}, IsOccupied: {_isOccupied}, IsReserved: {_isReserved}, ReservedByNetId: {_reservedByNetId}");
		for (int i = 0; i < socketableBuildings.Count; i++)
		{
			SocketableBuilding socketableBuilding = socketableBuildings[i];
			string arg = ((socketableBuilding.buildingItemSO != null) ? socketableBuilding.buildingItemSO.Name : "null");
			Debug.Log($"[T_Socket]   Socketable[{i}]: SO={arg}");
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		InvokeRepeating("ServerValidateOccupancy", 5f, 5f);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		CancelInvoke("ServerValidateOccupancy");
	}

	[Server]
	private void ServerValidateOccupancy()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Socket::ServerValidateOccupancy()' called when server was not active");
			return;
		}
		if (_isReserved && _reservedByNetId != 0)
		{
			if (!NetworkServer.spawned.TryGetValue(_reservedByNetId, out var value) || value == null)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: Reserve eden building yok olmuş! reservedByNetId: {_reservedByNetId}, Socket: {base.gameObject.name}. Reserve kaldırılıyor.");
				Network_isReserved = false;
				Network_reservedByNetId = 0u;
			}
			else
			{
				BuildingObject component = value.GetComponent<BuildingObject>();
				if (component == null || component.IsPlaced)
				{
					Debug.Log($"[T_Socket] ServerValidateOccupancy: Reserve eden building artık preview modda değil! reservedByNetId: {_reservedByNetId}, Socket: {base.gameObject.name}. Reserve kaldırılıyor.");
					Network_isReserved = false;
					Network_reservedByNetId = 0u;
				}
			}
		}
		if (!_isOccupied)
		{
			return;
		}
		if (_occupantNetId != 0)
		{
			if (!NetworkServer.spawned.TryGetValue(_occupantNetId, out var value2) || value2 == null)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: Occupant yok olmuş! occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
				Network_isOccupied = false;
				Network_occupantNetId = 0u;
				return;
			}
			T_Pallet component2 = value2.GetComponent<T_Pallet>();
			if (component2 != null && component2.IsLifted)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: Pallet forklift üzerinde! occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
				Network_isOccupied = false;
				Network_occupantNetId = 0u;
				return;
			}
			T_DeliveryPallet component3 = value2.GetComponent<T_DeliveryPallet>();
			if (component3 != null && component3.IsLifted)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: DeliveryPallet forklift üzerinde! occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
				Network_isOccupied = false;
				Network_occupantNetId = 0u;
				return;
			}
			if (!_isRestoredOccupancy)
			{
				BuildingObject component4 = value2.GetComponent<BuildingObject>();
				if (component4 != null && component4.TargetSocketNetId != 0)
				{
					NetworkIdentity componentInParent = GetComponentInParent<NetworkIdentity>();
					uint num = ((componentInParent != null) ? componentInParent.netId : 0u);
					if (num != 0 && component4.TargetSocketNetId != num)
					{
						Debug.Log($"[T_Socket] ServerValidateOccupancy: Occupant başka bir socket'e bağlı! occupantNetId: {_occupantNetId}, occupant targetSocketNetId: {component4.TargetSocketNetId}, myNetId: {num}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
						Network_isOccupied = false;
						Network_occupantNetId = 0u;
					}
				}
				return;
			}
			BuildingObject component5 = value2.GetComponent<BuildingObject>();
			if (!(component5 != null))
			{
				return;
			}
			if (!component5.IsPlaced)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: Restored occupant artık placed değil (relocate?). occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
				Network_isOccupied = false;
				Network_occupantNetId = 0u;
				_isRestoredOccupancy = false;
				return;
			}
			float num2 = Vector3.Distance(base.transform.position, value2.transform.position);
			if (num2 > 5f)
			{
				Debug.Log($"[T_Socket] ServerValidateOccupancy: Restored occupant çok uzakta ({num2:F1}m). occupantNetId: {_occupantNetId}, Socket: {base.gameObject.name}. Socket serbest bırakılıyor.");
				Network_isOccupied = false;
				Network_occupantNetId = 0u;
				_isRestoredOccupancy = false;
			}
			return;
		}
		bool flag = false;
		NetworkIdentity componentInParent2 = GetComponentInParent<NetworkIdentity>();
		uint num3 = ((componentInParent2 != null) ? componentInParent2.netId : 0u);
		Collider[] array = Physics.OverlapSphere(base.transform.position, 1.5f);
		foreach (Collider collider in array)
		{
			if (collider == null)
			{
				continue;
			}
			BuildingObject componentInParent3 = collider.GetComponentInParent<BuildingObject>();
			if (componentInParent3 != null && componentInParent3.IsPlaced)
			{
				NetworkIdentity component6 = componentInParent3.GetComponent<NetworkIdentity>();
				if (component6 != null && num3 != 0 && componentInParent3.TargetSocketNetId == num3)
				{
					flag = true;
					Network_occupantNetId = component6.netId;
					break;
				}
			}
		}
		if (!flag)
		{
			Debug.Log("[T_Socket] ServerValidateOccupancy: occupantNetId bilinmiyor ve yakınlarda uygun building yok! Socket: " + base.gameObject.name + ". Socket serbest bırakılıyor.");
			Network_isOccupied = false;
			Network_occupantNetId = 0u;
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (!showGizmos)
		{
			return;
		}
		Gizmos.color = (_isOccupied ? Color.red : (_isReserved ? Color.yellow : Color.cyan));
		Gizmos.DrawWireSphere(base.transform.position, gizmoSize);
		foreach (SocketableBuilding socketableBuilding in socketableBuildings)
		{
			if (!(socketableBuilding.buildingItemSO == null))
			{
				Vector3 vector = base.transform.TransformPoint(socketableBuilding.localPosition);
				Gizmos.color = (_isOccupied ? Color.red : Color.green);
				Gizmos.DrawWireSphere(vector, gizmoSize * 0.5f);
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(base.transform.position, vector);
			}
		}
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
			writer.WriteBool(_isOccupied);
			writer.WriteVarUInt(_occupantNetId);
			writer.WriteBool(_isReserved);
			writer.WriteVarUInt(_reservedByNetId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_isOccupied);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarUInt(_occupantNetId);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(_isReserved);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarUInt(_reservedByNetId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _isOccupied, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _occupantNetId, null, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref _isReserved, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _reservedByNetId, null, reader.ReadVarUInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isOccupied, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _occupantNetId, null, reader.ReadVarUInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isReserved, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _reservedByNetId, null, reader.ReadVarUInt());
		}
	}
}
