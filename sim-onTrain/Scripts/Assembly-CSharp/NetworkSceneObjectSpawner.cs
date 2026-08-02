using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DG.Tweening;
using GPUInstancerPro.PrefabModule;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkSceneObjectSpawner : NetworkBehaviour
{
	public static NetworkSceneObjectSpawner Instance;

	public GameObject bulletPrefab;

	public GameObject plankPrefab;

	public GameObject treeDestroyingParticle;

	public GameObject treeHitParticle;

	public GameObject oreHitParticle;

	public GameObject dropPrefab;

	public GameObject zombieDropPrefab;

	public GameObject generalDropPrefab;

	[Header("Build Particles")]
	public GameObject buildPlaceParticle;

	public GameObject buildRemoveParticle;

	[Header("Zombie Hit Particles")]
	public GameObject zombieWallHitParticle;

	public GameObject zombiePropHitParticle;

	public GameObject trainObjectDestroyingParticle;

	[SyncVar]
	public NetworkIdentity objectOwner;

	public GameObject woodDestroyingEffect;

	public SyncList<ObjectServerData> changedObjectServerDatas = new SyncList<ObjectServerData>();

	private CollectableItemData[] allCollectableItems;

	private const string WORLD_OBJECTS_SAVE_KEY = "WorldObjectStates";

	private Dictionary<long, WorldObjectSaveData> savedObjectStates = new Dictionary<long, WorldObjectSaveData>();

	private bool saveDataLoaded;

	protected uint ___objectOwnerNetId;

	public bool IsSaveDataLoaded => saveDataLoaded;

	public NetworkIdentity NetworkobjectOwner
	{
		get
		{
			return GetSyncVarNetworkIdentity(___objectOwnerNetId, ref objectOwner);
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter_NetworkIdentity(value, ref objectOwner, 1uL, null, ref ___objectOwnerNetId);
		}
	}

	private void Awake()
	{
		Instance = this;
		LoadAllCollectableItems();
	}

	private void Start()
	{
		ConnectSaveListeners();
	}

	private void ConnectSaveListeners()
	{
		if (Singleton<ES3SaveManager>.Instance != null && base.isServer)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveWorldObjectStates);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.RemoveListener(LoadWorldObjectStates);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.RemoveListener(LoadWorldObjectStates);
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveWorldObjectStates);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadWorldObjectStates);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.AddListener(LoadWorldObjectStates);
			Debug.Log("[WorldObjectSave] Save/Load listeners connected to ES3SaveManager");
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		StartCoroutine(InitializeSaveSystem());
	}

	private IEnumerator InitializeSaveSystem()
	{
		yield return new WaitUntil(() => Singleton<ES3SaveManager>.Instance != null);
		yield return null;
		yield return null;
		ConnectSaveListeners();
		LoadWorldObjectStates();
	}

	[Server]
	private void SaveWorldObjectStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneObjectSpawner::SaveWorldObjectStates()' called when server was not active");
			return;
		}
		List<WorldObjectSaveData> list = new List<WorldObjectSaveData>();
		foreach (ObjectServerData changedObjectServerData in changedObjectServerDatas)
		{
			list.Add(new WorldObjectSaveData
			{
				health = changedObjectServerData.health,
				cellID = changedObjectServerData.cellID,
				objectID = changedObjectServerData.objectID,
				isDestroyed = changedObjectServerData.isDestroyed,
				isLootable = changedObjectServerData.isLootable
			});
		}
		Singleton<ES3SaveManager>.Instance.SaveData("WorldObjectStates", list);
		Debug.Log($"[WorldObjectSave] Saved {list.Count} world object states");
	}

	[Server]
	public void LoadWorldObjectStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneObjectSpawner::LoadWorldObjectStates()' called when server was not active");
			return;
		}
		savedObjectStates.Clear();
		if (Singleton<ES3SaveManager>.Instance == null)
		{
			Debug.LogWarning("[WorldObjectSave] ES3SaveManager.Instance is null, cannot load");
			saveDataLoaded = true;
			return;
		}
		Debug.Log(string.Format("[WorldObjectSave] Loading... KeyExists={0}", Singleton<ES3SaveManager>.Instance.KeyExists("WorldObjectStates")));
		List<WorldObjectSaveData> list = Singleton<ES3SaveManager>.Instance.LoadData("WorldObjectStates", new List<WorldObjectSaveData>());
		Debug.Log($"[WorldObjectSave] LoadData returned {list.Count} items");
		foreach (WorldObjectSaveData item in list)
		{
			long saveKey = GetSaveKey(item.cellID, item.objectID);
			savedObjectStates[saveKey] = item;
		}
		saveDataLoaded = true;
		Debug.Log($"[WorldObjectSave] Loaded {savedObjectStates.Count} world object states from disk");
	}

	private static long GetSaveKey(int cellID, int objectID)
	{
		return ((long)cellID << 32) | (uint)objectID;
	}

	public WorldObjectSaveData GetSavedObjectState(int cellID, int objectID)
	{
		long saveKey = GetSaveKey(cellID, objectID);
		savedObjectStates.TryGetValue(saveKey, out var value);
		return value;
	}

	private void LoadAllCollectableItems()
	{
		allCollectableItems = Resources.LoadAll<CollectableItemData>("");
	}

	public CollectableItemData GetCollectableItemFromName(string itemName)
	{
		if (allCollectableItems == null || allCollectableItems.Length == 0)
		{
			LoadAllCollectableItems();
		}
		CollectableItemData collectableItemData = allCollectableItems.FirstOrDefault((CollectableItemData x) => x != null && x.itemName == itemName);
		if (collectableItemData == null)
		{
			Debug.LogWarning("[CollectableItemData] '" + itemName + "' bulunamadı!");
		}
		return collectableItemData;
	}

	[Command(requiresAuthority = false)]
	public void CmdSpawnDropItem(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(count);
		writer.WriteVector3(spawnPoint);
		writer.WriteVector3(spawnForward);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CmdSpawnDropItem(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", -1716417466, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnDropItemClient(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward)
	{
		CmdSpawnDropItem(itemName, count, spawnPoint, spawnForward);
	}

	[Command(requiresAuthority = false)]
	public void CmdSpawnDropItemWithDurability(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward, float durability)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(count);
		writer.WriteVector3(spawnPoint);
		writer.WriteVector3(spawnForward);
		writer.WriteFloat(durability);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CmdSpawnDropItemWithDurability(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Single)", -543100166, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnDropItemClientWithDurability(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward, float durability)
	{
		CmdSpawnDropItemWithDurability(itemName, count, spawnPoint, spawnForward, durability);
	}

	[Server]
	public void SpawnZombieDropItem(Vector3 spawnPoint, List<LootableItemEntry> items)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneObjectSpawner::SpawnZombieDropItem(UnityEngine.Vector3,System.Collections.Generic.List`1<LootableItemEntry>)' called when server was not active");
		}
		else if (zombieDropPrefab == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] zombieDropPrefab is not assigned!");
		}
		else if (items != null && items.Count != 0)
		{
			GameObject obj = Object.Instantiate(zombieDropPrefab, spawnPoint, Quaternion.identity);
			MultipleLootableItem component = obj.GetComponent<MultipleLootableItem>();
			if (component != null)
			{
				component.SetDroppedItems(items);
			}
			NetworkServer.Spawn(obj);
			Rigidbody component2 = obj.GetComponent<Rigidbody>();
			if (component2 != null)
			{
				Vector3 vector = new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f));
				component2.AddForce(vector * 2f, ForceMode.Impulse);
			}
		}
	}

	[Server]
	public void SpawnAnimalDropItem(Vector3 spawnPoint, List<LootableItemEntry> items)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneObjectSpawner::SpawnAnimalDropItem(UnityEngine.Vector3,System.Collections.Generic.List`1<LootableItemEntry>)' called when server was not active");
		}
		else if (generalDropPrefab == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] generalDropPrefab is not assigned!");
		}
		else if (items != null && items.Count != 0)
		{
			GameObject obj = Object.Instantiate(generalDropPrefab, spawnPoint, Quaternion.identity);
			MultipleLootableItem component = obj.GetComponent<MultipleLootableItem>();
			if (component != null)
			{
				component.SetDroppedItems(items);
			}
			NetworkServer.Spawn(obj);
			Rigidbody component2 = obj.GetComponent<Rigidbody>();
			if (component2 != null)
			{
				Vector3 vector = new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f));
				component2.AddForce(vector * 2f, ForceMode.Impulse);
			}
		}
	}

	private IEnumerator ApplyForceAfterSpawn(GameObject dropObj, Vector3 spawnPoint, Vector3 spawnForward)
	{
		yield return new WaitForFixedUpdate();
		Rigidbody component = dropObj.GetComponent<Rigidbody>();
		if (component != null)
		{
			Vector3 normalized = (spawnForward - spawnPoint).normalized;
			component.AddForce(normalized * 5f, ForceMode.Impulse);
		}
	}

	public override void OnStartClient()
	{
		changedObjectServerDatas.Callback += OnObjectServerDataChanged;
		StartCoroutine(ProcessExistingDestroyedObjects());
	}

	private IEnumerator ProcessExistingDestroyedObjects()
	{
		yield return new WaitForSeconds(0.5f);
		int count = changedObjectServerDatas.Count;
		Debug.Log($"[NetworkSceneObjectSpawner] Processing {count} existing objects for late joiner");
		int processed = 0;
		for (int i = 0; i < changedObjectServerDatas.Count; i++)
		{
			ObjectServerData objectServerData = changedObjectServerDatas[i];
			GameObject gameObject = FindObjectByCellAndObjectID(objectServerData.cellID, objectServerData.objectID);
			if (gameObject != null)
			{
				if (objectServerData.isDestroyed || objectServerData.health <= 0f)
				{
					GPUIPrefab component = gameObject.GetComponent<GPUIPrefab>();
					if (component != null)
					{
						GPUIPrefabAPI.RemovePrefabInstance(component);
					}
					Object.Destroy(gameObject);
				}
				else
				{
					BreakableObject component2 = gameObject.GetComponent<BreakableObject>();
					if (component2 != null)
					{
						component2.objectServerData = objectServerData;
						TreeCollectable component3 = gameObject.GetComponent<TreeCollectable>();
						if (component3 != null)
						{
							component3.UpdateHealthFromServer(objectServerData.health);
						}
						OreCollectable component4 = gameObject.GetComponent<OreCollectable>();
						if (component4 != null)
						{
							component4.UpdateHealthFromServer(objectServerData.health);
						}
						LootableTerrainItemProgressive component5 = gameObject.GetComponent<LootableTerrainItemProgressive>();
						if (component5 != null)
						{
							component5.UpdateHealthFromServer(objectServerData.health);
						}
					}
				}
			}
			int num = processed + 1;
			processed = num;
			if (num >= 32)
			{
				processed = 0;
				yield return null;
			}
		}
	}

	[ClientRpc]
	private void RPCInstantiateObjectOnServer()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RPCInstantiateObjectOnServer()", -197387922, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CMDInstantitateObjectOnServer()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDInstantitateObjectOnServer()", -1472039333, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnObjectOnScene()
	{
		CMDInstantitateObjectOnServer();
	}

	[Command(requiresAuthority = false)]
	public void CmdDestroyObject(GameObject obj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(obj);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CmdDestroyObject(UnityEngine.GameObject)", 1001382175, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnDestroyingParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnDestroyingParticle(UnityEngine.Vector3)", -1858713982, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnHitParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnHitParticle(UnityEngine.Vector3)", 1884913095, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnObject(GameObject gameobject, Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(gameobject);
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnObject(UnityEngine.GameObject,UnityEngine.Vector3)", -1270696525, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RPCInstantiateObjectOnServer(GameObject gameobject, Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(gameobject);
		writer.WriteVector3(pos);
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RPCInstantiateObjectOnServer(UnityEngine.GameObject,UnityEngine.Vector3)", -2140940039, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnObject(GameObject gameobject, Vector3 pos)
	{
		CMDSpawnObject(gameobject, pos);
	}

	public void SpawnHitParticle(Vector3 pos)
	{
		CMDSpawnHitParticle(pos);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnOreHitParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnOreHitParticle(UnityEngine.Vector3)", -1535544455, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnOreHitParticle(Vector3 pos)
	{
		CMDSpawnOreHitParticle(pos);
	}

	public void SpawnDestroyingParticle(Vector3 pos)
	{
		CMDSpawnDestroyingParticle(pos);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnBuildPlaceParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnBuildPlaceParticle(UnityEngine.Vector3)", 441606801, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSpawnBuildPlaceParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RpcSpawnBuildPlaceParticle(UnityEngine.Vector3)", 290097852, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnBuildPlaceParticle(Vector3 pos)
	{
		CMDSpawnBuildPlaceParticle(pos);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnBuildRemoveParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnBuildRemoveParticle(UnityEngine.Vector3)", -944227032, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSpawnBuildRemoveParticle(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RpcSpawnBuildRemoveParticle(UnityEngine.Vector3)", -1346037155, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnBuildRemoveParticle(Vector3 pos)
	{
		CMDSpawnBuildRemoveParticle(pos);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnZombieWallHitParticle(Vector3 pos, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnZombieWallHitParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", -864086790, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnZombieWallHitParticle(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] SpawnZombieWallHitParticle çağrıldı! Pos: {pos}");
		CMDSpawnZombieWallHitParticle(pos, rotation);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnZombiePropHitParticle(Vector3 pos, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnZombiePropHitParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", 685402945, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnZombiePropHitParticle(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] SpawnZombiePropHitParticle çağrıldı! Pos: {pos}");
		CMDSpawnZombiePropHitParticle(pos, rotation);
	}

	[Command(requiresAuthority = false)]
	private void CMDSpawnTrainObjectDestroyingParticle(Vector3 pos, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CMDSpawnTrainObjectDestroyingParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", 998401798, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnTrainObjectDestroyingParticle(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] SpawnTrainObjectDestroyingParticle çağrıldı! Pos: {pos}");
		CMDSpawnTrainObjectDestroyingParticle(pos, rotation);
	}

	public void AddOrUpdateObject(ObjectServerData data)
	{
		if (base.isServer)
		{
			AddOrUpdateObjectOnServer(data);
		}
		else if (base.isClient)
		{
			CmdAddOrUpdateObject(data);
		}
		else
		{
			Debug.LogError("Bu işlem ne istemcide ne de sunucuda gerçekleştirilebiliyor!");
		}
	}

	[Server]
	public void AddOrUpdateObjectOnServer(ObjectServerData objectServerData)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneObjectSpawner::AddOrUpdateObjectOnServer(ObjectServerData)' called when server was not active");
			return;
		}
		int num = changedObjectServerDatas.FindIndex((ObjectServerData x) => x.cellID == objectServerData.cellID && x.objectID == objectServerData.objectID);
		if (num >= 0)
		{
			ObjectServerData objectServerData2 = changedObjectServerDatas[num];
			objectServerData2.health = objectServerData.health;
			objectServerData2.isDestroyed = objectServerData.isDestroyed;
			objectServerData2.isLootable = objectServerData.isLootable;
			if (objectServerData2.isDestroyed || objectServerData2.health <= 0f)
			{
				objectServerData2.isDestroyed = true;
				changedObjectServerDatas[num] = objectServerData2;
				RpcDestroyObject(objectServerData2.cellID, objectServerData2.objectID);
			}
			else
			{
				changedObjectServerDatas[num] = objectServerData;
				RpcUpdateObject(objectServerData);
			}
		}
		else if (objectServerData.health > 0f || objectServerData.isLootable)
		{
			if (objectServerData.isLootable && objectServerData.isDestroyed)
			{
				objectServerData.isDestroyed = true;
				changedObjectServerDatas.Add(objectServerData);
				RpcDestroyObject(objectServerData.cellID, objectServerData.objectID);
			}
			else
			{
				changedObjectServerDatas.Add(objectServerData);
			}
		}
		else
		{
			objectServerData.isDestroyed = true;
			changedObjectServerDatas.Add(objectServerData);
			RpcDestroyObject(objectServerData.cellID, objectServerData.objectID);
		}
	}

	[ClientRpc]
	private void RpcUpdateObject(ObjectServerData updatedData)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ObjectServerData(writer, updatedData);
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RpcUpdateObject(ObjectServerData)", -876890853, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcDestroyObject(int cellID, int objectID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(cellID);
		writer.WriteInt(objectID);
		SendRPCInternal("System.Void NetworkSceneObjectSpawner::RpcDestroyObject(System.Int32,System.Int32)", 909516234, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private GameObject FindObjectByCellAndObjectID(int cellID, int objectID)
	{
		BreakableObject breakableObject = BreakableObject.Find(cellID, objectID);
		if (!(breakableObject != null))
		{
			return null;
		}
		return breakableObject.gameObject;
	}

	public ObjectServerData GetNetworkObjectState(int cellID, int objectID)
	{
		foreach (ObjectServerData changedObjectServerData in changedObjectServerDatas)
		{
			if (changedObjectServerData.cellID == cellID && changedObjectServerData.objectID == objectID)
			{
				return changedObjectServerData;
			}
		}
		return null;
	}

	[Command(requiresAuthority = false)]
	private void CmdAddOrUpdateObject(ObjectServerData data)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ObjectServerData(writer, data);
		SendCommandInternal("System.Void NetworkSceneObjectSpawner::CmdAddOrUpdateObject(ObjectServerData)", -1253307154, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnObjectServerDataChanged(SyncList<ObjectServerData>.Operation op, int index, ObjectServerData oldItem, ObjectServerData newItem)
	{
		switch (op)
		{
		case SyncList<ObjectServerData>.Operation.OP_ADD:
			HandleNewObject(newItem);
			break;
		case SyncList<ObjectServerData>.Operation.OP_REMOVEAT:
			HandleRemovedObject(oldItem);
			break;
		case SyncList<ObjectServerData>.Operation.OP_SET:
			HandleUpdatedObject(oldItem, newItem);
			break;
		case SyncList<ObjectServerData>.Operation.OP_CLEAR:
		case SyncList<ObjectServerData>.Operation.OP_INSERT:
			break;
		}
	}

	private void HandleNewObject(ObjectServerData newItem)
	{
		if (!newItem.isDestroyed && newItem.health > 0f)
		{
			return;
		}
		GameObject gameObject = FindObjectByCellAndObjectID(newItem.cellID, newItem.objectID);
		if (!(gameObject == null))
		{
			GPUIPrefab component = gameObject.GetComponent<GPUIPrefab>();
			if (component != null)
			{
				GPUIPrefabAPI.RemovePrefabInstance(component);
			}
			Object.Destroy(gameObject);
		}
	}

	private void HandleRemovedObject(ObjectServerData removedItem)
	{
		GameObject gameObject = FindObjectByCellAndObjectID(removedItem.cellID, removedItem.objectID);
		if (!(gameObject == null))
		{
			GPUIPrefab component = gameObject.GetComponent<GPUIPrefab>();
			if (component != null)
			{
				GPUIPrefabAPI.RemovePrefabInstance(component);
			}
			Object.Destroy(gameObject);
		}
	}

	private void HandleUpdatedObject(ObjectServerData oldItem, ObjectServerData newItem)
	{
		GameObject gameObject = FindObjectByCellAndObjectID(newItem.cellID, newItem.objectID);
		if (gameObject == null)
		{
			return;
		}
		BreakableObject component = gameObject.GetComponent<BreakableObject>();
		if (component == null)
		{
			return;
		}
		component.objectServerData = newItem;
		TreeCollectable component2 = gameObject.GetComponent<TreeCollectable>();
		if (component2 != null)
		{
			component2.UpdateHealthFromServer(newItem.health);
		}
		LootableTerrainItemProgressive component3 = gameObject.GetComponent<LootableTerrainItemProgressive>();
		if (component3 != null)
		{
			component3.UpdateHealthFromServer(newItem.health);
		}
		if (newItem.isDestroyed || newItem.health <= 0f)
		{
			GPUIPrefab component4 = gameObject.GetComponent<GPUIPrefab>();
			if (component4 != null)
			{
				GPUIPrefabAPI.RemovePrefabInstance(component4);
			}
			Object.Destroy(gameObject);
		}
	}

	public NetworkSceneObjectSpawner()
	{
		InitSyncObject(changedObjectServerDatas);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSpawnDropItem__String__Int32__Vector3__Vector3(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward)
	{
		if (!string.IsNullOrEmpty(itemName) && count > 0)
		{
			GameObject gameObject = Object.Instantiate(dropPrefab, spawnPoint, Quaternion.identity);
			CollectableItemBase component = gameObject.GetComponent<CollectableItemBase>();
			if (component != null)
			{
				component.SetItemData(itemName, count);
			}
			NetworkServer.Spawn(gameObject);
			StartCoroutine(ApplyForceAfterSpawn(gameObject, spawnPoint, spawnForward));
		}
	}

	protected static void InvokeUserCode_CmdSpawnDropItem__String__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnDropItem called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CmdSpawnDropItem__String__Int32__Vector3__Vector3(reader.ReadString(), reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3());
		}
	}

	protected void UserCode_CmdSpawnDropItemWithDurability__String__Int32__Vector3__Vector3__Single(string itemName, int count, Vector3 spawnPoint, Vector3 spawnForward, float durability)
	{
		if (!string.IsNullOrEmpty(itemName) && count > 0)
		{
			GameObject gameObject = Object.Instantiate(dropPrefab, spawnPoint, Quaternion.identity);
			CollectableItemBase component = gameObject.GetComponent<CollectableItemBase>();
			if (component != null)
			{
				component.SetItemDataWithDurability(itemName, count, durability);
			}
			NetworkServer.Spawn(gameObject);
			StartCoroutine(ApplyForceAfterSpawn(gameObject, spawnPoint, spawnForward));
		}
	}

	protected static void InvokeUserCode_CmdSpawnDropItemWithDurability__String__Int32__Vector3__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnDropItemWithDurability called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CmdSpawnDropItemWithDurability__String__Int32__Vector3__Vector3__Single(reader.ReadString(), reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadFloat());
		}
	}

	protected void UserCode_RPCInstantiateObjectOnServer()
	{
		NetworkServer.Spawn(bulletPrefab);
	}

	protected static void InvokeUserCode_RPCInstantiateObjectOnServer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCInstantiateObjectOnServer called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RPCInstantiateObjectOnServer();
		}
	}

	protected void UserCode_CMDInstantitateObjectOnServer()
	{
		RPCInstantiateObjectOnServer();
	}

	protected static void InvokeUserCode_CMDInstantitateObjectOnServer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDInstantitateObjectOnServer called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDInstantitateObjectOnServer();
		}
	}

	protected void UserCode_CmdDestroyObject__GameObject(GameObject obj)
	{
		if ((bool)obj)
		{
			NetworkServer.Destroy(obj);
		}
	}

	protected static void InvokeUserCode_CmdDestroyObject__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDestroyObject called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CmdDestroyObject__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_CMDSpawnDestroyingParticle__Vector3(Vector3 pos)
	{
		GameObject obj = Object.Instantiate(treeDestroyingParticle, pos, Quaternion.identity);
		NetworkServer.Spawn(obj);
		DOVirtual.DelayedCall(3f, delegate
		{
			NetworkServer.Destroy(obj);
		});
	}

	protected static void InvokeUserCode_CMDSpawnDestroyingParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnDestroyingParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnDestroyingParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnHitParticle__Vector3(Vector3 pos)
	{
		GameObject obj = Object.Instantiate(treeHitParticle, pos, Quaternion.identity);
		NetworkServer.Spawn(obj);
		DOVirtual.DelayedCall(3f, delegate
		{
			NetworkServer.Destroy(obj);
		});
	}

	protected static void InvokeUserCode_CMDSpawnHitParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnHitParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnHitParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnObject__GameObject__Vector3(GameObject gameobject, Vector3 pos)
	{
		RPCInstantiateObjectOnServer(gameobject, pos);
	}

	protected static void InvokeUserCode_CMDSpawnObject__GameObject__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnObject called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnObject__GameObject__Vector3(reader.ReadGameObject(), reader.ReadVector3());
		}
	}

	protected void UserCode_RPCInstantiateObjectOnServer__GameObject__Vector3(GameObject gameobject, Vector3 pos)
	{
		Object.Instantiate(gameobject, pos, Quaternion.identity);
		NetworkServer.Spawn(bulletPrefab);
	}

	protected static void InvokeUserCode_RPCInstantiateObjectOnServer__GameObject__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCInstantiateObjectOnServer called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RPCInstantiateObjectOnServer__GameObject__Vector3(reader.ReadGameObject(), reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnOreHitParticle__Vector3(Vector3 pos)
	{
		if (oreHitParticle == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] oreHitParticle prefab is not assigned!");
			return;
		}
		GameObject obj = Object.Instantiate(oreHitParticle, pos, Quaternion.identity);
		NetworkServer.Spawn(obj);
		DOVirtual.DelayedCall(3f, delegate
		{
			if (obj != null)
			{
				NetworkServer.Destroy(obj);
			}
		});
	}

	protected static void InvokeUserCode_CMDSpawnOreHitParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnOreHitParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnOreHitParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnBuildPlaceParticle__Vector3(Vector3 pos)
	{
		if (!(buildPlaceParticle == null))
		{
			RpcSpawnBuildPlaceParticle(pos);
		}
	}

	protected static void InvokeUserCode_CMDSpawnBuildPlaceParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnBuildPlaceParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnBuildPlaceParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_RpcSpawnBuildPlaceParticle__Vector3(Vector3 pos)
	{
		Object.Destroy(Object.Instantiate(buildPlaceParticle, pos, Quaternion.identity), 3f);
	}

	protected static void InvokeUserCode_RpcSpawnBuildPlaceParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSpawnBuildPlaceParticle called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RpcSpawnBuildPlaceParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnBuildRemoveParticle__Vector3(Vector3 pos)
	{
		if (!(buildRemoveParticle == null))
		{
			RpcSpawnBuildRemoveParticle(pos);
		}
	}

	protected static void InvokeUserCode_CMDSpawnBuildRemoveParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnBuildRemoveParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnBuildRemoveParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_RpcSpawnBuildRemoveParticle__Vector3(Vector3 pos)
	{
		Object.Destroy(Object.Instantiate(buildRemoveParticle, pos, Quaternion.identity), 3f);
	}

	protected static void InvokeUserCode_RpcSpawnBuildRemoveParticle__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSpawnBuildRemoveParticle called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RpcSpawnBuildRemoveParticle__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CMDSpawnZombieWallHitParticle__Vector3__Quaternion(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] CMDSpawnZombieWallHitParticle çağrıldı! Pos: {pos}");
		if (zombieWallHitParticle == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] zombieWallHitParticle prefab is not assigned!");
			return;
		}
		GameObject obj = Object.Instantiate(zombieWallHitParticle, pos, rotation);
		NetworkServer.Spawn(obj);
		Debug.Log("[NetworkSceneObjectSpawner] Wall hit particle spawn edildi: " + obj.name);
		DOVirtual.DelayedCall(3f, delegate
		{
			if (obj != null)
			{
				NetworkServer.Destroy(obj);
			}
		});
	}

	protected static void InvokeUserCode_CMDSpawnZombieWallHitParticle__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnZombieWallHitParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnZombieWallHitParticle__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CMDSpawnZombiePropHitParticle__Vector3__Quaternion(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] CMDSpawnZombiePropHitParticle çağrıldı! Pos: {pos}");
		if (zombiePropHitParticle == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] zombiePropHitParticle prefab is not assigned!");
			return;
		}
		GameObject obj = Object.Instantiate(zombiePropHitParticle, pos, rotation);
		NetworkServer.Spawn(obj);
		Debug.Log("[NetworkSceneObjectSpawner] Prop hit particle spawn edildi: " + obj.name);
		DOVirtual.DelayedCall(3f, delegate
		{
			if (obj != null)
			{
				NetworkServer.Destroy(obj);
			}
		});
	}

	protected static void InvokeUserCode_CMDSpawnZombiePropHitParticle__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnZombiePropHitParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnZombiePropHitParticle__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CMDSpawnTrainObjectDestroyingParticle__Vector3__Quaternion(Vector3 pos, Quaternion rotation)
	{
		Debug.Log($"[NetworkSceneObjectSpawner] CMDSpawnTrainObjectDestroyingParticle çağrıldı! Pos: {pos}");
		if (trainObjectDestroyingParticle == null)
		{
			Debug.LogWarning("[NetworkSceneObjectSpawner] trainObjectDestroyingParticle prefab is not assigned!");
			return;
		}
		GameObject obj = Object.Instantiate(trainObjectDestroyingParticle, pos, rotation);
		NetworkServer.Spawn(obj);
		Debug.Log("[NetworkSceneObjectSpawner] Train destroy particle spawn edildi: " + obj.name);
		DOVirtual.DelayedCall(5f, delegate
		{
			if (obj != null)
			{
				NetworkServer.Destroy(obj);
			}
		});
	}

	protected static void InvokeUserCode_CMDSpawnTrainObjectDestroyingParticle__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CMDSpawnTrainObjectDestroyingParticle called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CMDSpawnTrainObjectDestroyingParticle__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcUpdateObject__ObjectServerData(ObjectServerData updatedData)
	{
		GameObject gameObject = FindObjectByCellAndObjectID(updatedData.cellID, updatedData.objectID);
		if (!(gameObject != null))
		{
			return;
		}
		BreakableObject component = gameObject.GetComponent<BreakableObject>();
		if (component != null)
		{
			component.objectServerData = updatedData;
			TreeCollectable component2 = gameObject.GetComponent<TreeCollectable>();
			if (component2 != null)
			{
				component2.UpdateHealthFromServer(updatedData.health);
			}
			LootableTerrainItemProgressive component3 = gameObject.GetComponent<LootableTerrainItemProgressive>();
			if (component3 != null)
			{
				component3.UpdateHealthFromServer(updatedData.health);
			}
		}
	}

	protected static void InvokeUserCode_RpcUpdateObject__ObjectServerData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateObject called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RpcUpdateObject__ObjectServerData(GeneratedNetworkCode._Read_ObjectServerData(reader));
		}
	}

	protected void UserCode_RpcDestroyObject__Int32__Int32(int cellID, int objectID)
	{
		GameObject gameObject = FindObjectByCellAndObjectID(cellID, objectID);
		if (!(gameObject == null))
		{
			GPUIPrefab component = gameObject.GetComponent<GPUIPrefab>();
			if (component != null)
			{
				GPUIPrefabAPI.RemovePrefabInstance(component);
			}
			Object.Destroy(gameObject);
		}
	}

	protected static void InvokeUserCode_RpcDestroyObject__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcDestroyObject called on server.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_RpcDestroyObject__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdAddOrUpdateObject__ObjectServerData(ObjectServerData data)
	{
		AddOrUpdateObjectOnServer(data);
	}

	protected static void InvokeUserCode_CmdAddOrUpdateObject__ObjectServerData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddOrUpdateObject called on client.");
		}
		else
		{
			((NetworkSceneObjectSpawner)obj).UserCode_CmdAddOrUpdateObject__ObjectServerData(GeneratedNetworkCode._Read_ObjectServerData(reader));
		}
	}

	static NetworkSceneObjectSpawner()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CmdSpawnDropItem(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_CmdSpawnDropItem__String__Int32__Vector3__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CmdSpawnDropItemWithDurability(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Single)", InvokeUserCode_CmdSpawnDropItemWithDurability__String__Int32__Vector3__Vector3__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDInstantitateObjectOnServer()", InvokeUserCode_CMDInstantitateObjectOnServer, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CmdDestroyObject(UnityEngine.GameObject)", InvokeUserCode_CmdDestroyObject__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnDestroyingParticle(UnityEngine.Vector3)", InvokeUserCode_CMDSpawnDestroyingParticle__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnHitParticle(UnityEngine.Vector3)", InvokeUserCode_CMDSpawnHitParticle__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnObject(UnityEngine.GameObject,UnityEngine.Vector3)", InvokeUserCode_CMDSpawnObject__GameObject__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnOreHitParticle(UnityEngine.Vector3)", InvokeUserCode_CMDSpawnOreHitParticle__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnBuildPlaceParticle(UnityEngine.Vector3)", InvokeUserCode_CMDSpawnBuildPlaceParticle__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnBuildRemoveParticle(UnityEngine.Vector3)", InvokeUserCode_CMDSpawnBuildRemoveParticle__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnZombieWallHitParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CMDSpawnZombieWallHitParticle__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnZombiePropHitParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CMDSpawnZombiePropHitParticle__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CMDSpawnTrainObjectDestroyingParticle(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CMDSpawnTrainObjectDestroyingParticle__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::CmdAddOrUpdateObject(ObjectServerData)", InvokeUserCode_CmdAddOrUpdateObject__ObjectServerData, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RPCInstantiateObjectOnServer()", InvokeUserCode_RPCInstantiateObjectOnServer);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RPCInstantiateObjectOnServer(UnityEngine.GameObject,UnityEngine.Vector3)", InvokeUserCode_RPCInstantiateObjectOnServer__GameObject__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RpcSpawnBuildPlaceParticle(UnityEngine.Vector3)", InvokeUserCode_RpcSpawnBuildPlaceParticle__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RpcSpawnBuildRemoveParticle(UnityEngine.Vector3)", InvokeUserCode_RpcSpawnBuildRemoveParticle__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RpcUpdateObject(ObjectServerData)", InvokeUserCode_RpcUpdateObject__ObjectServerData);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneObjectSpawner), "System.Void NetworkSceneObjectSpawner::RpcDestroyObject(System.Int32,System.Int32)", InvokeUserCode_RpcDestroyObject__Int32__Int32);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteNetworkIdentity(NetworkobjectOwner);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteNetworkIdentity(NetworkobjectOwner);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize_NetworkIdentity(ref objectOwner, null, reader, ref ___objectOwnerNetId);
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize_NetworkIdentity(ref objectOwner, null, reader, ref ___objectOwnerNetId);
		}
	}
}
