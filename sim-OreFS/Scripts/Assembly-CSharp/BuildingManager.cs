using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class BuildingManager : NetworkBehaviour
{
	[Header("Building Box Spawn (Test)")]
	[Tooltip("Building Kutusu prefab'ı - U tuşuna basınca spawn edilecek (test için)")]
	public GameObject buildingBoxPrefab;

	private IReadOnlyList<T_BuildingItemSO> buildingItemSOList => ScriptableListManager.Instance.AllBuildingItemSOs;

	private void Update()
	{
	}

	private void TrySpawnBuildingBox()
	{
		if (buildingBoxPrefab == null)
		{
			Debug.LogWarning("[BuildingManager] Building Box prefab atanmamış! Test spawn için buildingBoxPrefab referansını atamalısın.");
			return;
		}
		if (GameManager.Instance == null || GameManager.Instance.localBag == null)
		{
			Debug.LogWarning("[BuildingManager] Local bag bulunamadı!");
			return;
		}
		T_Bag localBag = GameManager.Instance.localBag;
		if (NetworkServer.active)
		{
			ServerSpawnBuildingBox(localBag);
		}
		else
		{
			CmdSpawnBuildingBox();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSpawnBuildingBox(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSpawnBuildingBox__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void BuildingManager::CmdSpawnBuildingBox(Mirror.NetworkConnectionToClient)", 1423063609, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSpawnBuildingBox(T_Bag bag)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BuildingManager::ServerSpawnBuildingBox(T_Bag)' called when server was not active");
			return;
		}
		if (buildingBoxPrefab == null)
		{
			Debug.LogError("[BuildingManager] ServerSpawnBuildingBox: Building Box prefab null!");
			return;
		}
		if (bag == null)
		{
			Debug.LogError("[BuildingManager] ServerSpawnBuildingBox: T_Bag null!");
			return;
		}
		Transform transform = ((bag.throwPoint != null) ? bag.throwPoint : bag.transform);
		Vector3 vector = transform.position + transform.forward * bag.spawnForwardOffset;
		Vector3 forward = transform.forward;
		Vector3 vector2 = new Vector3(forward.x, 0f, forward.z);
		if (vector2.sqrMagnitude < 0.01f)
		{
			forward = bag.transform.forward;
			vector2 = new Vector3(forward.x, 0f, forward.z);
			Debug.LogWarning("[BuildingManager] throwPoint.forward yatay bileşeni çok küçük, transform.forward kullanılıyor");
		}
		if (vector2.sqrMagnitude > 0.01f)
		{
			vector2 = vector2.normalized;
		}
		else
		{
			vector2 = Vector3.forward;
			Debug.LogWarning("[BuildingManager] Yatay yön hesaplanamadı, varsayılan olarak Vector3.forward kullanılıyor");
		}
		if (Physics.Raycast(vector + Vector3.up * bag.raycastStartHeight, Vector3.down, out var hitInfo, bag.raycastDistance))
		{
			vector = hitInfo.point + Vector3.up * bag.groundOffset;
			Debug.Log($"[BuildingManager] Terrain bulundu - Spawn pozisyonu: {vector}, Terrain yüksekliği: {hitInfo.point.y}");
		}
		else
		{
			vector = transform.position + transform.forward * bag.spawnForwardOffset + Vector3.up * bag.groundOffset;
			Debug.LogWarning($"[BuildingManager] Terrain bulunamadı! Throw point pozisyonuna göre spawn: {vector}");
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(buildingBoxPrefab, vector, Quaternion.identity);
		if (gameObject == null)
		{
			Debug.LogError("[BuildingManager] ServerSpawnBuildingBox: Instantiate başarısız!");
			return;
		}
		NetworkIdentity component = gameObject.GetComponent<NetworkIdentity>();
		if (component == null)
		{
			Debug.LogError("[BuildingManager] ServerSpawnBuildingBox: Building Box prefab'ında NetworkIdentity component'i yok!");
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		NetworkServer.Spawn(gameObject);
		Debug.Log($"[BuildingManager] Building Box spawn edildi. Pozisyon: {vector}, NetId: {component.netId}");
		T_Building component2 = gameObject.GetComponent<T_Building>();
		if (component2 != null)
		{
			List<T_BuildingItemSO> list = new List<T_BuildingItemSO>();
			for (int i = 0; i < buildingItemSOList.Count; i++)
			{
				if (buildingItemSOList[i] != null && !buildingItemSOList[i].excludeFromBoxSpawn)
				{
					list.Add(buildingItemSOList[i]);
				}
			}
			if (list.Count > 0)
			{
				int num = UnityEngine.Random.Range(0, list.Count);
				T_BuildingItemSO t_BuildingItemSO = list[num];
				int num2 = -1;
				for (int j = 0; j < buildingItemSOList.Count; j++)
				{
					if (buildingItemSOList[j] == t_BuildingItemSO)
					{
						num2 = j;
						break;
					}
				}
				if (t_BuildingItemSO != null && num2 >= 0)
				{
					component2.SetBuildingItemSO(t_BuildingItemSO);
					component2.SetBuildingItemSOIndex(num2);
					Debug.Log(string.Format("[BuildingManager] BuildingItemSO set edildi: {0}, Prefab: {1}, ActualIndex: {2}", t_BuildingItemSO.Name, (t_BuildingItemSO.Prefab != null) ? t_BuildingItemSO.Prefab.name : "null", num2));
					RpcSetBuildingItemSO(gameObject, num2);
				}
				else
				{
					Debug.LogWarning($"[BuildingManager] Seçilen BuildingItemSO null veya index bulunamadı! FilteredIndex: {num}");
				}
			}
			else
			{
				Debug.LogWarning("[BuildingManager] Kutu olarak spawn edilebilir BuildingItemSO bulunamadı! (Tüm SO'lar excludeFromBoxSpawn = true olabilir)");
			}
		}
		if (component2 != null)
		{
			Rigidbody component3 = gameObject.GetComponent<Rigidbody>();
			if (component3 != null)
			{
				component3.isKinematic = false;
				component3.useGravity = true;
				component3.linearDamping = 0.5f;
			}
			else
			{
				Debug.LogWarning("[BuildingManager] Building Box prefab'inde Rigidbody bulunamadı! Fiziksel tepkime olmayabilir.");
			}
			Collider component4 = gameObject.GetComponent<Collider>();
			if (component4 == null)
			{
				gameObject.AddComponent<BoxCollider>();
				Debug.LogWarning("[BuildingManager] Building Box prefab'inde Collider yok! Otomatik BoxCollider eklendi.");
			}
			else if (!component4.enabled)
			{
				component4.enabled = true;
				Debug.LogWarning("[BuildingManager] Building Box prefab'indeki Collider kapalıydı! Aktif edildi.");
			}
			Vector3 normalized;
			if (bag.useThrowAngle)
			{
				float f = bag.throwAngle * (MathF.PI / 180f);
				Vector3 vector3 = vector2;
				float num3 = Mathf.Cos(f);
				float num4 = Mathf.Sin(f);
				Vector3 vector4 = vector3 * num3;
				Vector3 vector5 = Vector3.up * num4;
				normalized = (vector4 + vector5).normalized;
				Debug.Log($"[BuildingManager] Bombeli fırlatma - Açı: {bag.throwAngle}°, Yön: {normalized}, Kuvvet: {bag.throwForce}");
			}
			else
			{
				normalized = (vector2 + Vector3.up * bag.throwUpwardForce).normalized;
				Debug.Log($"[BuildingManager] Fırlatma (eski yöntem) - Yön: {normalized}, Kuvvet: {bag.throwForce}");
			}
			StartCoroutine(DelayedThrow(component2, vector, normalized, bag.throwForce));
		}
		else
		{
			Debug.LogError("[BuildingManager] Building Box prefab'inde T_Building component'i bulunamadı!");
		}
	}

	[ClientRpc]
	private void RpcSetBuildingItemSO(GameObject buildingBoxInstance, int soIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(buildingBoxInstance);
		writer.WriteVarInt(soIndex);
		SendRPCInternal("System.Void BuildingManager::RpcSetBuildingItemSO(UnityEngine.GameObject,System.Int32)", -220027427, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator DelayedThrow(T_Building buildingComponent, Vector3 position, Vector3 direction, float force)
	{
		yield return new WaitForFixedUpdate();
		if (buildingComponent != null)
		{
			buildingComponent.ServerThrow(position, direction, force);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSpawnBuildingBox__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender == null || sender.identity == null)
		{
			Debug.LogWarning("[BuildingManager] CmdSpawnBuildingBox: Sender veya identity null!");
			return;
		}
		T_Bag component = sender.identity.gameObject.GetComponent<T_Bag>();
		if (component == null)
		{
			Debug.LogWarning("[BuildingManager] CmdSpawnBuildingBox: Sender player'ında T_Bag component'i bulunamadı!");
		}
		else
		{
			ServerSpawnBuildingBox(component);
		}
	}

	protected static void InvokeUserCode_CmdSpawnBuildingBox__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBuildingBox called on client.");
		}
		else
		{
			((BuildingManager)obj).UserCode_CmdSpawnBuildingBox__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcSetBuildingItemSO__GameObject__Int32(GameObject buildingBoxInstance, int soIndex)
	{
		if (buildingBoxInstance == null)
		{
			Debug.LogWarning("[BuildingManager] RpcSetBuildingItemSO: buildingBoxInstance null!");
			return;
		}
		if (soIndex < 0 || soIndex >= buildingItemSOList.Count)
		{
			Debug.LogWarning($"[BuildingManager] RpcSetBuildingItemSO: Geçersiz SO index! Index: {soIndex}, List Count: {buildingItemSOList.Count}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = buildingItemSOList[soIndex];
		if (t_BuildingItemSO == null)
		{
			Debug.LogWarning($"[BuildingManager] RpcSetBuildingItemSO: Seçilen SO null! Index: {soIndex}");
			return;
		}
		T_Building component = buildingBoxInstance.GetComponent<T_Building>();
		if (component != null)
		{
			component.SetBuildingItemSO(t_BuildingItemSO);
			Debug.Log("[BuildingManager] RpcSetBuildingItemSO: BuildingItemSO set edildi: " + t_BuildingItemSO.Name);
			component.SetIcon(t_BuildingItemSO.Icon);
		}
	}

	protected static void InvokeUserCode_RpcSetBuildingItemSO__GameObject__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetBuildingItemSO called on server.");
		}
		else
		{
			((BuildingManager)obj).UserCode_RpcSetBuildingItemSO__GameObject__Int32(reader.ReadGameObject(), reader.ReadVarInt());
		}
	}

	static BuildingManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BuildingManager), "System.Void BuildingManager::CmdSpawnBuildingBox(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSpawnBuildingBox__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(BuildingManager), "System.Void BuildingManager::RpcSetBuildingItemSO(UnityEngine.GameObject,System.Int32)", InvokeUserCode_RpcSetBuildingItemSO__GameObject__Int32);
	}
}
