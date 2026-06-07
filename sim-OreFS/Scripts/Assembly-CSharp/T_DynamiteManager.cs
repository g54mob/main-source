using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_DynamiteManager : NetworkBehaviour
{
	[SerializeField]
	public int dynamiteCost = 50;

	[Header("Prefab")]
	[SerializeField]
	private GameObject dynamitePrefab;

	[Header("Throw Settings")]
	[SerializeField]
	private Transform throwPoint;

	[SerializeField]
	private Camera playerCamera;

	[SerializeField]
	private float throwForwardOffset = 1f;

	[SerializeField]
	private float throwUpwardAngle = 15f;

	[Header("Limits")]
	[SerializeField]
	public int maxDynamites = 5;

	[Header("Debug")]
	[SerializeField]
	private bool verboseLogging = true;

	private readonly List<T_Dynamite> myDynamites = new List<T_Dynamite>();

	public readonly List<T_Dynamite> localDynamiteRefs = new List<T_Dynamite>();

	public int ActiveDynamiteCount
	{
		get
		{
			if (!base.isServer)
			{
				return localDynamiteRefs.Count;
			}
			return myDynamites.Count;
		}
	}

	private IEnumerator SetBuildingCostActions(bool isActive)
	{
		yield return new WaitForSeconds(0.5f);
		if (isActive)
		{
			GameManager.Instance.UImanager.SetBuildingCost(50);
		}
		else
		{
			GameManager.Instance.UImanager.CloseBuildingCost();
		}
	}

	public void SpawnDynamite()
	{
		if (!base.isLocalPlayer)
		{
			if (verboseLogging)
			{
				Debug.LogWarning("T_DynamiteManager: SpawnDynamite called but not local player!");
			}
			return;
		}
		Vector3 throwPosition = GetThrowPosition();
		Vector3 throwDirection = GetThrowDirection();
		if (verboseLogging)
		{
			Debug.Log($"T_DynamiteManager: SpawnDynamite requested - Pos: {throwPosition}, Dir: {throwDirection}");
		}
		CmdSpawnDynamite(throwPosition, throwDirection);
	}

	public void DetonateAll()
	{
		if (!base.isLocalPlayer)
		{
			if (verboseLogging)
			{
				Debug.LogWarning("T_DynamiteManager: DetonateAll called but not local player!");
			}
			return;
		}
		if (verboseLogging)
		{
			Debug.Log("T_DynamiteManager: DetonateAll requested");
		}
		foreach (T_Dynamite localDynamiteRef in localDynamiteRefs)
		{
			if (localDynamiteRef != null)
			{
				localDynamiteRef.PlayExplosionEffectsLocal(localDynamiteRef.transform.position);
			}
		}
		localDynamiteRefs.Clear();
		float dynamiteSizeFromLevel = GetDynamiteSizeFromLevel();
		CmdDetonateAll(dynamiteSizeFromLevel);
	}

	private float GetDynamiteSizeFromLevel()
	{
		if (UpgradeManager.Instance == null || PlayerProgressManager.Instance == null)
		{
			return 2.5f;
		}
		int level = PlayerProgressManager.Instance.GetLevel(ItemType.Dynamite);
		return UpgradeManager.Instance.GetDynamiteStats(level).size;
	}

	private Vector3 GetThrowPosition()
	{
		if (throwPoint != null)
		{
			return throwPoint.position;
		}
		return base.transform.position + base.transform.forward * throwForwardOffset + Vector3.up * 1.5f;
	}

	private Vector3 GetThrowDirection()
	{
		Camera main = playerCamera;
		if (main == null)
		{
			main = Camera.main;
		}
		Vector3 vector = ((!(main != null)) ? base.transform.forward : main.transform.forward);
		if (throwUpwardAngle > 0f)
		{
			Vector3 axis = ((main != null) ? main.transform.right : base.transform.right);
			vector = Quaternion.AngleAxis(0f - throwUpwardAngle, axis) * vector;
		}
		return vector.normalized;
	}

	[Command]
	private void CmdSpawnDynamite(Vector3 position, Vector3 direction)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSpawnDynamite__Vector3__Vector3(position, direction);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteVector3(direction);
		SendCommandInternal("System.Void T_DynamiteManager::CmdSpawnDynamite(UnityEngine.Vector3,UnityEngine.Vector3)", 695602624, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdDetonateAll(float size)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdDetonateAll__Single(size);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(size);
		SendCommandInternal("System.Void T_DynamiteManager::CmdDetonateAll(System.Single)", -1350987670, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSpawnDynamite(Vector3 position, Vector3 direction)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DynamiteManager::ServerSpawnDynamite(UnityEngine.Vector3,UnityEngine.Vector3)' called when server was not active");
			return;
		}
		if (dynamitePrefab == null)
		{
			Debug.LogError("T_DynamiteManager: dynamitePrefab is null!");
			return;
		}
		GameObject gameObject = Object.Instantiate(dynamitePrefab, position, Quaternion.LookRotation(direction));
		NetworkServer.Spawn(gameObject);
		T_Dynamite component = gameObject.GetComponent<T_Dynamite>();
		if (component != null)
		{
			component.ServerSetOwner(base.netId);
			myDynamites.Add(component);
			if (verboseLogging)
			{
				Debug.Log($"T_DynamiteManager: Dynamite spawned for player {base.netId} - Total active: {myDynamites.Count}");
			}
			TargetOnDynamiteSpawned(base.connectionToClient, component.netId, direction);
		}
		else
		{
			Debug.LogError("T_DynamiteManager: Spawned object doesn't have T_Dynamite component!");
			NetworkServer.Destroy(gameObject);
		}
	}

	[Server]
	private void ServerDetonateAll(float size)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DynamiteManager::ServerDetonateAll(System.Single)' called when server was not active");
			return;
		}
		if (myDynamites.Count == 0)
		{
			if (verboseLogging)
			{
				Debug.Log($"T_DynamiteManager: No dynamites to detonate for player {base.netId}");
			}
			return;
		}
		if (verboseLogging)
		{
			Debug.Log($"T_DynamiteManager: Detonating {myDynamites.Count} dynamites for player {base.netId}");
		}
		size = Mathf.Clamp(size, 1f, 6f);
		foreach (T_Dynamite item in new List<T_Dynamite>(myDynamites))
		{
			if (item != null)
			{
				item.ServerDetonate(size);
			}
		}
		myDynamites.Clear();
		localDynamiteRefs.Clear();
	}

	[Server]
	public void ServerRemoveDynamite(T_Dynamite dynamite)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DynamiteManager::ServerRemoveDynamite(T_Dynamite)' called when server was not active");
		}
		else if (myDynamites.Contains(dynamite))
		{
			myDynamites.Remove(dynamite);
			if (verboseLogging)
			{
				Debug.Log($"T_DynamiteManager: Dynamite removed for player {base.netId} - Remaining: {myDynamites.Count}");
			}
		}
	}

	[TargetRpc]
	private void TargetOnDynamiteSpawned(NetworkConnectionToClient target, uint dynamiteNetId, Vector3 throwDirection)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(dynamiteNetId);
		writer.WriteVector3(throwDirection);
		SendTargetRPCInternal(target, "System.Void T_DynamiteManager::TargetOnDynamiteSpawned(Mirror.NetworkConnectionToClient,System.UInt32,UnityEngine.Vector3)", 19514419, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator WaitAndThrowDynamite(uint dynamiteNetId, Vector3 throwDirection)
	{
		float timeout = 2f;
		float elapsed = 0f;
		while (!NetworkClient.spawned.ContainsKey(dynamiteNetId) && elapsed < timeout)
		{
			elapsed += Time.deltaTime;
			yield return null;
		}
		if (!NetworkClient.spawned.TryGetValue(dynamiteNetId, out var value))
		{
			yield break;
		}
		T_Dynamite component = value.GetComponent<T_Dynamite>();
		if (component != null && !localDynamiteRefs.Contains(component))
		{
			localDynamiteRefs.Add(component);
			component.ClientThrow(throwDirection);
			if (verboseLogging)
			{
				Debug.Log($"T_DynamiteManager: Local dynamite ref added and thrown - Count: {localDynamiteRefs.Count}");
			}
		}
	}

	private void OnDestroy()
	{
		if (base.isServer)
		{
			foreach (T_Dynamite myDynamite in myDynamites)
			{
				if (myDynamite != null)
				{
					NetworkServer.Destroy(myDynamite.gameObject);
				}
			}
			myDynamites.Clear();
		}
		localDynamiteRefs.Clear();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSpawnDynamite__Vector3__Vector3(Vector3 position, Vector3 direction)
	{
		ServerSpawnDynamite(position, direction);
	}

	protected static void InvokeUserCode_CmdSpawnDynamite__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnDynamite called on client.");
		}
		else
		{
			((T_DynamiteManager)obj).UserCode_CmdSpawnDynamite__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_CmdDetonateAll__Single(float size)
	{
		ServerDetonateAll(size);
	}

	protected static void InvokeUserCode_CmdDetonateAll__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDetonateAll called on client.");
		}
		else
		{
			((T_DynamiteManager)obj).UserCode_CmdDetonateAll__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_TargetOnDynamiteSpawned__NetworkConnectionToClient__UInt32__Vector3(NetworkConnectionToClient target, uint dynamiteNetId, Vector3 throwDirection)
	{
		StartCoroutine(WaitAndThrowDynamite(dynamiteNetId, throwDirection));
	}

	protected static void InvokeUserCode_TargetOnDynamiteSpawned__NetworkConnectionToClient__UInt32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetOnDynamiteSpawned called on server.");
		}
		else
		{
			((T_DynamiteManager)obj).UserCode_TargetOnDynamiteSpawned__NetworkConnectionToClient__UInt32__Vector3(null, reader.ReadVarUInt(), reader.ReadVector3());
		}
	}

	static T_DynamiteManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_DynamiteManager), "System.Void T_DynamiteManager::CmdSpawnDynamite(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CmdSpawnDynamite__Vector3__Vector3, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_DynamiteManager), "System.Void T_DynamiteManager::CmdDetonateAll(System.Single)", InvokeUserCode_CmdDetonateAll__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(T_DynamiteManager), "System.Void T_DynamiteManager::TargetOnDynamiteSpawned(Mirror.NetworkConnectionToClient,System.UInt32,UnityEngine.Vector3)", InvokeUserCode_TargetOnDynamiteSpawned__NetworkConnectionToClient__UInt32__Vector3);
	}
}
