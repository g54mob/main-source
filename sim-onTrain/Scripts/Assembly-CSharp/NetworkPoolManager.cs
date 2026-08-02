using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkPoolManager : NetworkBehaviour
{
	public static NetworkPoolManager Instance;

	[Header("Pool Configuration")]
	public List<PoolData> poolDataList = new List<PoolData>();

	private Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();

	private List<PoolData> bloodPools = new List<PoolData>();

	[Header("Blood Effect Settings")]
	public Vector2 randomOffsetRange = new Vector2(0.15f, 0.35f);

	public int randomBloodCount = 3;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public override void OnStartServer()
	{
		StartCoroutine(InitializeServerPoolsAsync());
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer)
		{
			StartCoroutine(InitializeClientPoolsAsync());
		}
	}

	private IEnumerator InitializeServerPoolsAsync()
	{
		int frameBudget = 0;
		foreach (PoolData poolData in poolDataList)
		{
			Queue<GameObject> pool = new Queue<GameObject>();
			for (int i = 0; i < poolData.poolSize; i++)
			{
				GameObject gameObject = Object.Instantiate(poolData.prefab);
				gameObject.transform.SetParent(base.transform);
				gameObject.transform.localScale = poolData.prefab.transform.localScale;
				if (!poolData.isBlood)
				{
					NetworkServer.Spawn(gameObject);
				}
				gameObject.SetActive(value: false);
				pool.Enqueue(gameObject);
				int num = frameBudget + 1;
				frameBudget = num;
				if (num >= 8)
				{
					frameBudget = 0;
					yield return null;
				}
			}
			pools.Add(poolData.poolName, pool);
			if (poolData.isBlood)
			{
				bloodPools.Add(poolData);
			}
		}
		Debug.Log($"[SERVER] Initialized {pools.Count} pools, {bloodPools.Count} blood pools");
	}

	private IEnumerator InitializeClientPoolsAsync()
	{
		int frameBudget = 0;
		foreach (PoolData poolData in poolDataList)
		{
			Queue<GameObject> pool = new Queue<GameObject>();
			for (int i = 0; i < poolData.poolSize; i++)
			{
				GameObject gameObject = Object.Instantiate(poolData.prefab);
				gameObject.transform.SetParent(base.transform);
				gameObject.transform.localScale = poolData.prefab.transform.localScale;
				gameObject.SetActive(value: false);
				pool.Enqueue(gameObject);
				int num = frameBudget + 1;
				frameBudget = num;
				if (num >= 16)
				{
					frameBudget = 0;
					yield return null;
				}
			}
			pools.Add(poolData.poolName, pool);
			if (poolData.isBlood)
			{
				bloodPools.Add(poolData);
			}
		}
		Debug.Log($"[CLIENT] Initialized {pools.Count} pools, {bloodPools.Count} blood pools");
	}

	public void RequestBloodEffects(Vector3 position, Vector3 direction, uint zombieNetId = 0u, BodyHitPart hitPart = BodyHitPart.Spine)
	{
		int bloodCount = 1;
		if (base.isServer)
		{
			RpcSpawnBloodEffectsLocal(position, direction, bloodCount, zombieNetId, (int)hitPart);
		}
		else
		{
			CmdRequestBloodEffects(position, direction, bloodCount, zombieNetId, (int)hitPart);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestBloodEffects(Vector3 position, Vector3 direction, int bloodCount, uint zombieNetId, int hitPart)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteVector3(direction);
		writer.WriteInt(bloodCount);
		writer.WriteUInt(zombieNetId);
		writer.WriteInt(hitPart);
		SendCommandInternal("System.Void NetworkPoolManager::CmdRequestBloodEffects(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32,System.UInt32,System.Int32)", -1498345101, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcSpawnBloodEffectsLocal(Vector3 centerPosition, Vector3 hitDirection, int bloodCount, uint zombieNetId, int hitPart)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(centerPosition);
		writer.WriteVector3(hitDirection);
		writer.WriteInt(bloodCount);
		writer.WriteUInt(zombieNetId);
		writer.WriteInt(hitPart);
		SendRPCInternal("System.Void NetworkPoolManager::RpcSpawnBloodEffectsLocal(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32,System.UInt32,System.Int32)", -1293484623, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private Transform FindHitPartTransform(uint zombieNetId, BodyHitPart hitPart)
	{
		if (zombieNetId == 0)
		{
			return null;
		}
		if (!NetworkClient.spawned.TryGetValue(zombieNetId, out var value))
		{
			return null;
		}
		ZombieBodyHitter[] componentsInChildren = value.GetComponentsInChildren<ZombieBodyHitter>();
		foreach (ZombieBodyHitter zombieBodyHitter in componentsInChildren)
		{
			if (zombieBodyHitter.hitPart == hitPart)
			{
				return zombieBodyHitter.transform;
			}
		}
		return null;
	}

	private void SpawnBloodEffectsLocal(Vector3 centerPosition, Vector3 hitDirection, int bloodCount, uint zombieNetId, BodyHitPart hitPart)
	{
		if (bloodPools.Count == 0)
		{
			Debug.LogWarning("[LOCAL] No blood pools available!");
			return;
		}
		Transform transform = FindHitPartTransform(zombieNetId, hitPart);
		for (int i = 0; i < bloodCount; i++)
		{
			if (TryGetFromLocalPool(out var obj, out var poolName))
			{
				Vector3 vector = new Vector3(Random.Range(0f - randomOffsetRange.x, randomOffsetRange.x), Random.Range(0f - randomOffsetRange.y, randomOffsetRange.y), Random.Range(0f - randomOffsetRange.x, randomOffsetRange.x));
				Vector3 position = centerPosition + vector;
				Quaternion rotation = Quaternion.LookRotation(hitDirection) * Quaternion.Euler(0f, 180f, 0f) * Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f));
				obj.transform.position = position;
				obj.transform.rotation = rotation;
				if (transform != null)
				{
					obj.transform.SetParent(transform, worldPositionStays: true);
				}
				obj.SetActive(value: true);
				ParticleSystem[] componentsInChildren = obj.GetComponentsInChildren<ParticleSystem>();
				foreach (ParticleSystem obj2 in componentsInChildren)
				{
					obj2.Stop();
					obj2.Clear();
					obj2.Play();
				}
				float delay = Random.Range(3f, 6f);
				string pn = poolName;
				GameObject bo = obj;
				DOVirtual.DelayedCall(delay, delegate
				{
					if (bo != null)
					{
						bo.transform.SetParent(base.transform);
						ReturnToLocalPool(pn, bo);
					}
				});
			}
			else
			{
				Debug.LogWarning("[LOCAL] No available blood objects in pool!");
			}
		}
	}

	private bool TryGetFromLocalPool(out GameObject obj, out string poolName)
	{
		obj = null;
		poolName = "";
		foreach (PoolData bloodPool in bloodPools)
		{
			if (pools.ContainsKey(bloodPool.poolName) && pools[bloodPool.poolName].Count > 0)
			{
				obj = pools[bloodPool.poolName].Dequeue();
				poolName = bloodPool.poolName;
				return true;
			}
		}
		return false;
	}

	private void ReturnToLocalPool(string poolName, GameObject obj)
	{
		if (obj != null && pools.ContainsKey(poolName))
		{
			obj.SetActive(value: false);
			pools[poolName].Enqueue(obj);
		}
	}

	public GameObject GetFromLocalPool(string poolName)
	{
		if (pools.ContainsKey(poolName) && pools[poolName].Count > 0)
		{
			return pools[poolName].Dequeue();
		}
		return null;
	}

	public void ReturnToLocalPoolPublic(string poolName, GameObject obj)
	{
		if (obj != null && pools.ContainsKey(poolName))
		{
			obj.SetActive(value: false);
			pools[poolName].Enqueue(obj);
		}
		else
		{
			Debug.LogWarning("[LOCAL] Cannot return object to pool '" + poolName + "' - pool doesn't exist or object is null");
		}
	}

	[Server]
	public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation, float duration = 4f)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'UnityEngine.GameObject NetworkPoolManager::SpawnFromPool(System.String,UnityEngine.Vector3,UnityEngine.Quaternion,System.Single)' called when server was not active");
			return null;
		}
		if (!pools.ContainsKey(poolName) || pools[poolName].Count == 0)
		{
			Debug.LogWarning("Pool " + poolName + " is empty or doesn't exist!");
			return null;
		}
		GameObject obj = pools[poolName].Dequeue();
		obj.transform.position = position;
		obj.transform.rotation = rotation;
		obj.SetActive(value: true);
		RpcActivatePoolObject(obj.GetComponent<NetworkIdentity>().netId, position, rotation);
		if (duration > 0f)
		{
			DOVirtual.DelayedCall(duration, delegate
			{
				ReturnToPool(poolName, obj);
			});
		}
		return obj;
	}

	[Server]
	public void ReturnToPool(string poolName, GameObject obj)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPoolManager::ReturnToPool(System.String,UnityEngine.GameObject)' called when server was not active");
		}
		else if (obj != null && pools.ContainsKey(poolName))
		{
			obj.SetActive(value: false);
			pools[poolName].Enqueue(obj);
			RpcDeactivatePoolObject(obj.GetComponent<NetworkIdentity>().netId);
		}
	}

	[Server]
	public void SpawnRandomBloodEffects(Vector3 centerPosition, Vector3 hitDirection, int count = -1)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPoolManager::SpawnRandomBloodEffects(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)' called when server was not active");
			return;
		}
		if (bloodPools.Count == 0)
		{
			Debug.LogWarning("[SERVER] No blood pools available!");
			return;
		}
		int num = ((count > 0) ? count : randomBloodCount);
		for (int i = 0; i < num; i++)
		{
			PoolData poolData = bloodPools[Random.Range(0, bloodPools.Count)];
			Vector3 vector = new Vector3(Random.Range(0f - randomOffsetRange.x, randomOffsetRange.x), Random.Range(0f - randomOffsetRange.y, randomOffsetRange.y), Random.Range(0f - randomOffsetRange.x, randomOffsetRange.x));
			Vector3 position = centerPosition + vector;
			Quaternion rotation = Quaternion.LookRotation(hitDirection) * Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f));
			float duration = Random.Range(3f, 6f);
			SpawnFromPool(poolData.poolName, position, rotation, duration);
		}
	}

	[Server]
	public void SpawnBloodSplash(Vector3 position, Vector3 direction, float duration = 4f)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPoolManager::SpawnBloodSplash(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)' called when server was not active");
		}
		else if (bloodPools.Count > 0)
		{
			PoolData poolData = bloodPools[Random.Range(0, bloodPools.Count)];
			Quaternion rotation = Quaternion.LookRotation(direction);
			SpawnFromPool(poolData.poolName, position, rotation, duration);
		}
	}

	[Server]
	public void SpawnBloodTrail(Vector3 startPosition, Vector3 endPosition, int trailCount = 5)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkPoolManager::SpawnBloodTrail(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)' called when server was not active");
		}
		else
		{
			if (bloodPools.Count == 0)
			{
				return;
			}
			for (int i = 0; i < trailCount; i++)
			{
				float t = (float)i / (float)(trailCount - 1);
				Vector3 position = Vector3.Lerp(startPosition, endPosition, t);
				Vector3 normalized = (endPosition - startPosition).normalized;
				Quaternion rotation = Quaternion.LookRotation(normalized);
				PoolData randomBloodPool = bloodPools[Random.Range(0, bloodPools.Count)];
				DOVirtual.DelayedCall((float)i * 0.1f, delegate
				{
					SpawnFromPool(randomBloodPool.poolName, position, rotation, Random.Range(2f, 5f));
				});
			}
		}
	}

	[ClientRpc]
	private void RpcActivatePoolObject(uint netId, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteUInt(netId);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendRPCInternal("System.Void NetworkPoolManager::RpcActivatePoolObject(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion)", 311396305, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcDeactivatePoolObject(uint netId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteUInt(netId);
		SendRPCInternal("System.Void NetworkPoolManager::RpcDeactivatePoolObject(System.UInt32)", 84690444, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public int GetPoolCount(string poolName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 NetworkPoolManager::GetPoolCount(System.String)' called when server was not active");
			return default(int);
		}
		if (!pools.ContainsKey(poolName))
		{
			return 0;
		}
		return pools[poolName].Count;
	}

	[ContextMenu("Test Blood Effects")]
	public void TestBloodEffects()
	{
		Vector3 position = base.transform.position + Vector3.up * 2f;
		Vector3 forward = Vector3.forward;
		RequestBloodEffects(position, forward);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestBloodEffects__Vector3__Vector3__Int32__UInt32__Int32(Vector3 position, Vector3 direction, int bloodCount, uint zombieNetId, int hitPart)
	{
		RpcSpawnBloodEffectsLocal(position, direction, bloodCount, zombieNetId, hitPart);
	}

	protected static void InvokeUserCode_CmdRequestBloodEffects__Vector3__Vector3__Int32__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestBloodEffects called on client.");
		}
		else
		{
			((NetworkPoolManager)obj).UserCode_CmdRequestBloodEffects__Vector3__Vector3__Int32__UInt32__Int32(reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt(), reader.ReadUInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcSpawnBloodEffectsLocal__Vector3__Vector3__Int32__UInt32__Int32(Vector3 centerPosition, Vector3 hitDirection, int bloodCount, uint zombieNetId, int hitPart)
	{
		SpawnBloodEffectsLocal(centerPosition, hitDirection, bloodCount, zombieNetId, (BodyHitPart)hitPart);
	}

	protected static void InvokeUserCode_RpcSpawnBloodEffectsLocal__Vector3__Vector3__Int32__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSpawnBloodEffectsLocal called on server.");
		}
		else
		{
			((NetworkPoolManager)obj).UserCode_RpcSpawnBloodEffectsLocal__Vector3__Vector3__Int32__UInt32__Int32(reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt(), reader.ReadUInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcActivatePoolObject__UInt32__Vector3__Quaternion(uint netId, Vector3 position, Quaternion rotation)
	{
		if (NetworkClient.spawned.TryGetValue(netId, out var value))
		{
			GameObject gameObject = value.gameObject;
			if (gameObject.transform.parent != base.transform)
			{
				gameObject.transform.SetParent(base.transform);
			}
			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;
			if (gameObject.transform.localScale.sqrMagnitude < 0.0001f)
			{
				gameObject.transform.localScale = Vector3.one;
			}
			gameObject.SetActive(value: true);
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Stop();
				componentsInChildren[i].Clear();
				componentsInChildren[i].Play();
			}
			Renderer[] componentsInChildren2 = gameObject.GetComponentsInChildren<Renderer>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].enabled = true;
			}
		}
	}

	protected static void InvokeUserCode_RpcActivatePoolObject__UInt32__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcActivatePoolObject called on server.");
		}
		else
		{
			((NetworkPoolManager)obj).UserCode_RpcActivatePoolObject__UInt32__Vector3__Quaternion(reader.ReadUInt(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcDeactivatePoolObject__UInt32(uint netId)
	{
		if (NetworkClient.spawned.TryGetValue(netId, out var value))
		{
			value.gameObject.SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_RpcDeactivatePoolObject__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcDeactivatePoolObject called on server.");
		}
		else
		{
			((NetworkPoolManager)obj).UserCode_RpcDeactivatePoolObject__UInt32(reader.ReadUInt());
		}
	}

	static NetworkPoolManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkPoolManager), "System.Void NetworkPoolManager::CmdRequestBloodEffects(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32,System.UInt32,System.Int32)", InvokeUserCode_CmdRequestBloodEffects__Vector3__Vector3__Int32__UInt32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkPoolManager), "System.Void NetworkPoolManager::RpcSpawnBloodEffectsLocal(UnityEngine.Vector3,UnityEngine.Vector3,System.Int32,System.UInt32,System.Int32)", InvokeUserCode_RpcSpawnBloodEffectsLocal__Vector3__Vector3__Int32__UInt32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkPoolManager), "System.Void NetworkPoolManager::RpcActivatePoolObject(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcActivatePoolObject__UInt32__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkPoolManager), "System.Void NetworkPoolManager::RpcDeactivatePoolObject(System.UInt32)", InvokeUserCode_RpcDeactivatePoolObject__UInt32);
	}
}
