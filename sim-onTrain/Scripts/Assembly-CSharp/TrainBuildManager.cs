using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TrainBuildManager : NetworkBehaviour
{
	[Header("References")]
	public TrainController trainController;

	public CollectableItemData groundData;

	[Header("Networked Build Objects")]
	public readonly SyncList<NetworkBuildData> networkBuildObjects = new SyncList<NetworkBuildData>();

	public readonly SyncDictionary<string, uint> uniqueIdToNetId = new SyncDictionary<string, uint>();

	[Header("Local References")]
	private List<GameObject> spawnedObjects = new List<GameObject>();

	private bool isInitialized;

	private CollectableItemData[] allCollectableItems;

	private bool isSaving;

	public static TrainBuildManager Instance { get; private set; }

	public bool isBuildObjectsLoaded { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		if (trainController == null)
		{
			trainController = GetComponent<TrainController>();
		}
		networkBuildObjects.Callback += OnBuildObjectsChanged;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer)
		{
			StartCoroutine(SpawnExistingObjectsOnClient());
		}
	}

	private IEnumerator SyncExistingWagonsForClient()
	{
		yield return new WaitForSeconds(3f);
		ClearAllObjectsLocally();
		foreach (NetworkBuildData networkBuildObject in networkBuildObjects)
		{
			CollectableItemData collectableItemData = FindItemDataByName(networkBuildObject.itemName);
			if (collectableItemData != null && collectableItemData.itemType == ItemType.Wagon)
			{
				SpawnObjectLocally(networkBuildObject);
			}
			else if (networkBuildObject.itemName == "Wagon")
			{
				SpawnObjectLocally(networkBuildObject);
			}
			else
			{
				SpawnObjectLocally(networkBuildObject);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestSync()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainBuildManager::CmdRequestSync()", 1501949844, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcForceSync(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void TrainBuildManager::RpcForceSync(Mirror.NetworkConnectionToClient)", -160448638, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ForceClientResync()
	{
		yield return new WaitForSeconds(0.5f);
		ClearAllObjectsLocally();
		foreach (NetworkBuildData networkBuildObject in networkBuildObjects)
		{
			SpawnObjectLocally(networkBuildObject);
		}
	}

	private void SetParentForClientNetworkObject()
	{
	}

	private void SpawnNetworkObjcet(NetworkBuildData buildObj, CollectableItemData itemData)
	{
		if (!base.isServer)
		{
			StartCoroutine(TryFindNetworkObjectLater(buildObj, itemData));
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(itemData.itemPrefab);
		ApplyBuildParenting(gameObject.transform, buildObj, itemData.itemType);
		PropBase propBase = gameObject.GetComponent<PropBase>();
		if (propBase == null)
		{
			propBase = gameObject.AddComponent<PropBase>();
		}
		propBase.data = itemData;
		propBase.assignedWagonID = buildObj.wagonID;
		propBase.health = buildObj.health;
		propBase.uniqueID = buildObj.itemID;
		NetworkIdentity component = gameObject.GetComponent<NetworkIdentity>();
		if (component != null)
		{
			NetworkServer.Spawn(gameObject);
			if (!string.IsNullOrEmpty(buildObj.itemID))
			{
				uniqueIdToNetId[buildObj.itemID] = component.netId;
			}
		}
		spawnedObjects.Add(gameObject);
		if (!string.IsNullOrEmpty(buildObj.stateData))
		{
			Debug.LogWarning("[TRAINBUILD_NETWORK] \ud83d\udd04 Network object '" + buildObj.itemName + "' has stateData, starting LoadState coroutine");
			StartCoroutine(LoadStateAfterNetworkInit(gameObject, buildObj.stateData, buildObj.itemName));
		}
	}

	private IEnumerator TryFindNetworkObjectLater(NetworkBuildData buildObj, CollectableItemData itemData)
	{
		int attempts = 0;
		while (attempts < 100)
		{
			yield return new WaitForSeconds(0.1f);
			attempts++;
			if (!networkBuildObjects.Any((NetworkBuildData x) => x.itemID == buildObj.itemID))
			{
				yield break;
			}
			if (!uniqueIdToNetId.ContainsKey(buildObj.itemID))
			{
				continue;
			}
			uint num = uniqueIdToNetId[buildObj.itemID];
			if (!NetworkClient.spawned.ContainsKey(num))
			{
				continue;
			}
			NetworkIdentity networkIdentity = NetworkClient.spawned[num];
			if (networkIdentity == null)
			{
				continue;
			}
			GameObject gameObject = networkIdentity.gameObject;
			PropBase propBase = gameObject.GetComponent<PropBase>();
			if (propBase == null)
			{
				propBase = gameObject.AddComponent<PropBase>();
			}
			if (!networkBuildObjects.Any((NetworkBuildData x) => x.itemID == buildObj.itemID))
			{
				Debug.Log("[CLIENT] Network object bulundu ama listeden silinmiş, işlem iptal: " + buildObj.itemName);
				yield break;
			}
			ApplyBuildParenting(propBase.transform, buildObj, itemData.itemType);
			propBase.data = itemData;
			propBase.assignedWagonID = buildObj.wagonID;
			propBase.health = buildObj.health;
			propBase.uniqueID = buildObj.itemID;
			if (!spawnedObjects.Contains(propBase.gameObject))
			{
				spawnedObjects.Add(propBase.gameObject);
			}
			Debug.Log($"[CLIENT] Network object NetID ile bulundu: {buildObj.itemName} - UniqueID: {buildObj.itemID} - NetID: {num}");
			if (!string.IsNullOrEmpty(buildObj.stateData))
			{
				Debug.LogWarning("[TRAINBUILD_NETWORK_LATER] Network object '" + buildObj.itemName + "' found later, loading state");
				StartCoroutine(LoadStateAfterNetworkInit(propBase.gameObject, buildObj.stateData, buildObj.itemName));
			}
			yield break;
		}
		if (attempts >= 100)
		{
			Debug.LogError("[CLIENT] Network object bulunamadı 10 saniye sonra: " + buildObj.itemName + " (UniqueID: " + buildObj.itemID + ")");
		}
	}

	private void SpawnObjectLocally(NetworkBuildData buildObj)
	{
		if (buildObj.itemName == "Torch")
		{
			Debug.Log($"[TORCH] SpawnObjectLocally CALLED | localPos={buildObj.localPosition} | parentObjectID='{buildObj.parentObjectID}' | leafIndex={buildObj.parentLeafIndex} | uid={buildObj.itemID}");
		}
		if (DoesObjectAlreadyExist(buildObj))
		{
			if (buildObj.itemName == "Torch")
			{
				Debug.Log($"[TORCH] SpawnObjectLocally SKIPPED (already exists) | localPos={buildObj.localPosition} | uid={buildObj.itemID}");
			}
			return;
		}
		CollectableItemData collectableItemData = FindItemDataByName(buildObj.itemName);
		if (collectableItemData == null && groundData != null && (buildObj.itemName == groundData.itemName || buildObj.itemName == "Ground"))
		{
			collectableItemData = groundData;
			buildObj.itemName = groundData.itemName;
		}
		Debug.Log("[build] SpawnObjectLocally: '" + buildObj.itemName + "' | itemData: " + ((collectableItemData != null) ? collectableItemData.itemName : "NULL") + " | PoolingSystem: " + ((Singleton<PoolingSystem>.Instance != null) ? "OK" : "NULL"));
		if (collectableItemData != null && collectableItemData.isNetworkObject)
		{
			SpawnNetworkObjcet(buildObj, collectableItemData);
			return;
		}
		GameObject gameObject = null;
		if (collectableItemData != null && collectableItemData.itemPrefab != null)
		{
			if (Singleton<PoolingSystem>.Instance != null)
			{
				gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS(buildObj.itemName);
				Debug.Log("[build] Pool ile oluşturma (itemData var): '" + buildObj.itemName + "' | sonuç: " + ((gameObject != null) ? gameObject.name : "NULL"));
			}
			if (gameObject == null)
			{
				gameObject = UnityEngine.Object.Instantiate(collectableItemData.itemPrefab);
				Debug.Log("[build] Instantiate ile oluşturma: '" + buildObj.itemName + "' | sonuç: " + ((gameObject != null) ? gameObject.name : "NULL"));
			}
		}
		else if (collectableItemData == null && Singleton<PoolingSystem>.Instance != null)
		{
			gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS(buildObj.itemName);
			Debug.Log("[build] Pool ile oluşturma (itemData yok): '" + buildObj.itemName + "' | sonuç: " + ((gameObject != null) ? gameObject.name : "NULL"));
		}
		if (gameObject == null && buildObj.itemName == "Wagon" && trainController != null && trainController.vagonPrefab != null)
		{
			gameObject = ((!(Singleton<PoolingSystem>.Instance != null)) ? UnityEngine.Object.Instantiate(trainController.vagonPrefab) : Singleton<PoolingSystem>.Instance.InstantiateAPS("Wagon"));
		}
		if (gameObject == null)
		{
			Debug.LogError("Obje oluşturulamadı: " + buildObj.itemName + " [TREN]");
			return;
		}
		PropBase propBase = gameObject.GetComponent<PropBase>();
		if (propBase == null)
		{
			propBase = gameObject.AddComponent<PropBase>();
		}
		propBase.data = collectableItemData;
		propBase.assignedWagonID = buildObj.wagonID;
		propBase.health = buildObj.health;
		propBase.uniqueID = buildObj.itemID;
		if (((object)collectableItemData != null && collectableItemData.itemType == ItemType.Wagon) || buildObj.itemName == "Wagon")
		{
			WagonController wagonController = gameObject.GetComponent<WagonController>();
			if (wagonController == null)
			{
				wagonController = gameObject.AddComponent<WagonController>();
			}
			wagonController.InitializeWagon(buildObj.wagonID);
			wagonController.data = collectableItemData;
			if (trainController != null)
			{
				gameObject.transform.SetParent(trainController.transform, worldPositionStays: false);
				gameObject.transform.localPosition = buildObj.localPosition;
				gameObject.transform.localEulerAngles = buildObj.localEulerAngles;
				if (!trainController.wagonControllers.Any((WagonController w) => w.wagonID == buildObj.wagonID))
				{
					trainController.wagonControllers.Add(wagonController);
					if (wagonController.animator != null && !trainController.animators.Contains(wagonController.animator))
					{
						trainController.animators.Add(wagonController.animator);
					}
				}
			}
		}
		else
		{
			ApplyBuildParenting(gameObject.transform, buildObj, collectableItemData.itemType);
		}
		if (collectableItemData.itemType == ItemType.Placeable)
		{
			StartCoroutine(TemporaryIgnorePlayerCollision(gameObject));
		}
		if (!string.IsNullOrEmpty(buildObj.stateData))
		{
			StartCoroutine(LoadStateAfterNetworkInit(gameObject, buildObj.stateData, buildObj.itemName));
		}
		else
		{
			spawnedObjects.Add(gameObject);
		}
	}

	private IEnumerator TemporaryIgnorePlayerCollision(GameObject spawnedObj)
	{
		if (TrainGameManager.Instance == null || TrainGameManager.Instance.mainPlayer == null)
		{
			yield break;
		}
		CharacterController playerCC = TrainGameManager.Instance.mainPlayer.GetComponent<CharacterController>();
		if (playerCC == null)
		{
			yield break;
		}
		Collider[] objColliders = spawnedObj.GetComponentsInChildren<Collider>();
		if (objColliders.Length == 0)
		{
			yield break;
		}
		Collider[] array = objColliders;
		foreach (Collider collider in array)
		{
			if (collider != null)
			{
				Physics.IgnoreCollision(playerCC, collider, ignore: true);
			}
		}
		yield return new WaitForSeconds(0.5f);
		array = objColliders;
		foreach (Collider collider2 in array)
		{
			if (collider2 != null && spawnedObj != null)
			{
				Physics.IgnoreCollision(playerCC, collider2, ignore: false);
			}
		}
	}

	[Server]
	public void SpawnBuildObjectOnServer(Vector3 localPos, Vector3 localEuler, string itemID, int targetWagonID, string parentObjectID = "", int parentLeafIndex = -1)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::SpawnBuildObjectOnServer(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32,System.String,System.Int32)' called when server was not active");
			return;
		}
		string text = Guid.NewGuid().ToString() + itemID + localPos.normalized.ToString("0.00") + targetWagonID;
		if (itemID == "Torch")
		{
			Debug.Log($"[TORCH] SpawnBuildObjectOnServer ADD | localPos={localPos} | parentObjectID='{parentObjectID}' | leafIndex={parentLeafIndex} | uid={text} | networkObjCount(before)={networkBuildObjects.Count}");
		}
		CollectableItemData collectableItemData = FindItemDataByName(itemID);
		if (collectableItemData == null && groundData != null && itemID == groundData.itemName)
		{
			collectableItemData = groundData;
		}
		bool isNetwork = collectableItemData != null && collectableItemData.isNetworkObject;
		float hp = 100f;
		if (collectableItemData != null && collectableItemData.itemPrefab != null)
		{
			PropBase component = collectableItemData.itemPrefab.GetComponent<PropBase>();
			if (component != null)
			{
				if (component.maxHealth > 0f)
				{
					hp = component.maxHealth;
				}
				else if (component.health > 0f)
				{
					hp = component.health;
				}
			}
		}
		NetworkBuildData item = new NetworkBuildData(itemID, localPos, localEuler, hp, targetWagonID, text, "", isNetwork, parentObjectID, parentLeafIndex);
		networkBuildObjects.Add(item);
		if (collectableItemData == null || collectableItemData.itemPrefab == null)
		{
			Debug.LogWarning("ItemData bulunamadı veya prefab yok: " + itemID + " [TREN]");
		}
	}

	[Server]
	public void MoveBuildObjectOnServer(Vector3 oldLocalPosition, string itemName, int oldWagonID, Vector3 newLocalPosition, Vector3 newLocalEuler, int newWagonID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::MoveBuildObjectOnServer(UnityEngine.Vector3,System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)' called when server was not active");
			return;
		}
		for (int i = 0; i < networkBuildObjects.Count; i++)
		{
			NetworkBuildData obj = networkBuildObjects[i];
			if (!(obj.itemName == itemName) || obj.wagonID != oldWagonID || !(Vector3.Distance(obj.localPosition, oldLocalPosition) < 0.5f))
			{
				continue;
			}
			NetworkBuildData value = obj;
			value.localPosition = newLocalPosition;
			value.localEulerAngles = newLocalEuler;
			value.wagonID = newWagonID;
			GameObject gameObject = spawnedObjects.FirstOrDefault(delegate(GameObject so)
			{
				if (so == null)
				{
					return false;
				}
				PropBase component = so.GetComponent<PropBase>();
				return component != null && !string.IsNullOrEmpty(obj.itemID) && component.uniqueID == obj.itemID;
			});
			if (gameObject != null)
			{
				string componentState = GetComponentState(gameObject);
				if (!string.IsNullOrEmpty(componentState))
				{
					value.stateData = componentState;
				}
			}
			networkBuildObjects[i] = value;
			Debug.Log($"[TrainBuildManager] Object moved: {itemName} from Wagon {oldWagonID} to Wagon {newWagonID}");
			return;
		}
		Debug.LogWarning($"[TrainBuildManager] Object NOT found for move: {itemName}, WagonID: {oldWagonID}, LocalPos: {oldLocalPosition}");
	}

	[Server]
	public void DestroyBuildObjectOnServer(Vector3 localPosition, string itemName, int wagonID, string uniqueID = "")
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::DestroyBuildObjectOnServer(UnityEngine.Vector3,System.String,System.Int32,System.String)' called when server was not active");
			return;
		}
		Debug.Log($"[TrainBuildManager] DestroyBuildObjectOnServer called - Item: {itemName}, WagonID: {wagonID}, LocalPos: {localPosition}, uid: {uniqueID}");
		for (int num = networkBuildObjects.Count - 1; num >= 0; num--)
		{
			NetworkBuildData networkBuildData = networkBuildObjects[num];
			bool flag = !string.IsNullOrEmpty(uniqueID) && networkBuildData.itemID == uniqueID;
			if (!flag && networkBuildData.itemName == itemName && networkBuildData.wagonID == wagonID && Vector3.Distance(networkBuildData.localPosition, localPosition) < 0.5f)
			{
				flag = true;
			}
			if (flag)
			{
				if (!string.IsNullOrEmpty(networkBuildData.itemID) && uniqueIdToNetId.ContainsKey(networkBuildData.itemID))
				{
					uniqueIdToNetId.Remove(networkBuildData.itemID);
					Debug.Log("[SERVER] UniqueID-NetID mapping silindi: " + networkBuildData.itemID);
				}
				Debug.Log($"[TrainBuildManager] Removing object from networkBuildObjects: {itemName} at index {num}");
				networkBuildObjects.RemoveAt(num);
				return;
			}
		}
		Debug.LogWarning($"[TrainBuildManager] Object NOT found for removal: {itemName}, WagonID: {wagonID}, LocalPos: {localPosition}");
	}

	private Vector3 ConvertLocalToWorldPosition(Vector3 localPosition, int wagonID)
	{
		if (trainController == null)
		{
			return localPosition;
		}
		WagonController wagonByID = trainController.GetWagonByID(wagonID);
		if (wagonByID == null)
		{
			return localPosition;
		}
		return wagonByID.transform.TransformPoint(localPosition);
	}

	[Command(requiresAuthority = false)]
	public void CmdDestroyBuildObject(Vector3 worldPosition, string itemName, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(worldPosition);
		writer.WriteString(itemName);
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void TrainBuildManager::CmdDestroyBuildObject(UnityEngine.Vector3,System.String,System.Int32)", 1973443373, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void DestroyObjectLocally(NetworkBuildData buildObj)
	{
		CollectableItemData collectableItemData = FindItemDataByName(buildObj.itemName);
		bool flag = collectableItemData != null && collectableItemData.isNetworkObject;
		if (flag && !base.isServer)
		{
			Debug.Log("[CLIENT] Network object destruction handled by Mirror: " + buildObj.itemName + " (UniqueID: " + buildObj.itemID + ")");
			for (int num = spawnedObjects.Count - 1; num >= 0; num--)
			{
				GameObject gameObject = spawnedObjects[num];
				if (gameObject == null)
				{
					spawnedObjects.RemoveAt(num);
				}
				else
				{
					PropBase component = gameObject.GetComponent<PropBase>();
					if (component != null && component.uniqueID == buildObj.itemID)
					{
						spawnedObjects.RemoveAt(num);
						break;
					}
				}
			}
			return;
		}
		GameObject gameObject2 = null;
		for (int num2 = spawnedObjects.Count - 1; num2 >= 0; num2--)
		{
			GameObject gameObject3 = spawnedObjects[num2];
			if (gameObject3 == null)
			{
				spawnedObjects.RemoveAt(num2);
			}
			else
			{
				PropBase component2 = gameObject3.GetComponent<PropBase>();
				if (component2 != null)
				{
					if (flag && !string.IsNullOrEmpty(buildObj.itemID) && component2.uniqueID == buildObj.itemID)
					{
						gameObject2 = gameObject3;
						break;
					}
					if (!flag && component2.data != null && component2.data.itemName == buildObj.itemName && component2.assignedWagonID == buildObj.wagonID && Vector3.Distance(gameObject3.transform.localPosition, buildObj.localPosition) < 0.1f)
					{
						gameObject2 = gameObject3;
					}
				}
			}
		}
		if (gameObject2 != null)
		{
			spawnedObjects.Remove(gameObject2);
			WagonController component3 = gameObject2.GetComponent<WagonController>();
			if (component3 != null && trainController != null)
			{
				trainController.wagonControllers.Remove(component3);
			}
			if (gameObject2.GetComponent<NetworkIdentity>() != null && base.isServer)
			{
				NetworkServer.Destroy(gameObject2);
				Debug.Log("[SERVER] NetworkServer.Destroy called for: " + buildObj.itemName + " (UniqueID: " + buildObj.itemID + ")");
			}
			else if (Singleton<PoolingSystem>.Instance != null)
			{
				Singleton<PoolingSystem>.Instance.DestroyAPS(gameObject2);
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject2);
			}
		}
	}

	private void ClearAllObjectsLocally()
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject != null)
			{
				if (Singleton<PoolingSystem>.Instance != null)
				{
					Singleton<PoolingSystem>.Instance.DestroyAPS(spawnedObject);
				}
				else
				{
					UnityEngine.Object.Destroy(spawnedObject);
				}
			}
		}
		spawnedObjects.Clear();
	}

	private void SetCorrectParent(Transform objTransform, int wagonID, ItemType itemType)
	{
		if (trainController == null)
		{
			Debug.LogWarning("TrainController referansı bulunamadı!");
			return;
		}
		WagonController wagonByID = trainController.GetWagonByID(wagonID);
		if (wagonByID != null)
		{
			switch (itemType)
			{
			case ItemType.Placeable:
				if (wagonByID.propParent != null)
				{
					objTransform.SetParent(wagonByID.propParent, worldPositionStays: false);
				}
				else
				{
					objTransform.SetParent(wagonByID.transform, worldPositionStays: false);
				}
				break;
			case ItemType.BuildItem:
				if (wagonByID.buildParent != null)
				{
					objTransform.SetParent(wagonByID.buildParent, worldPositionStays: false);
				}
				else
				{
					objTransform.SetParent(wagonByID.transform, worldPositionStays: false);
				}
				break;
			default:
				objTransform.SetParent(wagonByID.transform, worldPositionStays: false);
				break;
			}
		}
		else
		{
			objTransform.SetParent(trainController.transform, worldPositionStays: false);
			Debug.LogWarning($"Wagon ID {wagonID} bulunamadı! Ana train'e parent edildi.");
		}
	}

	private void ApplyBuildParenting(Transform t, NetworkBuildData buildObj, ItemType itemType)
	{
		if (!string.IsNullOrEmpty(buildObj.parentObjectID))
		{
			StartCoroutine(AttachToDoorWhenReady(t, buildObj.parentObjectID, buildObj.parentLeafIndex, buildObj.localPosition, buildObj.localEulerAngles, buildObj.wagonID, itemType));
			return;
		}
		SetCorrectParent(t, buildObj.wagonID, itemType);
		t.localPosition = buildObj.localPosition;
		t.localEulerAngles = buildObj.localEulerAngles;
	}

	private IEnumerator AttachToDoorWhenReady(Transform t, string doorID, int leafIndex, Vector3 leafLocalPos, Vector3 leafLocalEuler, int wagonID, ItemType itemType)
	{
		SetCorrectParent(t, wagonID, itemType);
		t.localPosition = leafLocalPos;
		t.localEulerAngles = leafLocalEuler;
		float waited = 0f;
		Transform leaf = null;
		for (; waited < 5f; waited += 0.1f)
		{
			if (t == null)
			{
				yield break;
			}
			DoorBase doorBase = FindDoorByKey(doorID);
			if (doorBase != null)
			{
				leaf = doorBase.GetMovingPart(leafIndex);
				if (leaf != null)
				{
					break;
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
		if (!(t == null))
		{
			if (leaf != null)
			{
				t.SetParent(leaf, worldPositionStays: false);
				t.localPosition = leafLocalPos;
				t.localEulerAngles = leafLocalEuler;
				Debug.Log($"[TORCH][DOORPROP] Attached '{t.name}' to leaf '{leaf.name}' (doorKey={doorID}) after {waited:F1}s | worldPos={t.position}");
			}
			else
			{
				Debug.LogWarning($"[TORCH][DOORPROP] Kapi/yaprak BULUNAMADI (doorKey={doorID}, leafIndex={leafIndex}); '{t.name}' wagonda kaldi | worldPos={t.position}");
			}
		}
	}

	private DoorBase FindDoorByKey(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		DoorBase[] array;
		if (key.StartsWith("scene:") || key.StartsWith("owner:"))
		{
			array = UnityEngine.Object.FindObjectsOfType<DoorBase>();
			foreach (DoorBase doorBase in array)
			{
				if (DoorBase.GetStableDoorKey(doorBase) == key)
				{
					return doorBase;
				}
			}
			return null;
		}
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject == null)
			{
				continue;
			}
			DoorBase component = spawnedObject.GetComponent<DoorBase>();
			if (!(component == null))
			{
				PropBase component2 = spawnedObject.GetComponent<PropBase>();
				if (component2 != null && component2.uniqueID == key)
				{
					return component;
				}
			}
		}
		array = UnityEngine.Object.FindObjectsOfType<DoorBase>();
		foreach (DoorBase doorBase2 in array)
		{
			PropBase component3 = doorBase2.GetComponent<PropBase>();
			if (component3 != null && component3.uniqueID == key)
			{
				return doorBase2;
			}
		}
		return null;
	}

	private CollectableItemData FindItemDataByName(string itemName)
	{
		if (Singleton<DataManager>.Instance != null)
		{
			foreach (CollectableItemData collectableData in Singleton<DataManager>.Instance.collectableDatas)
			{
				if (collectableData.itemName == itemName)
				{
					return collectableData;
				}
			}
		}
		if (allCollectableItems == null)
		{
			allCollectableItems = Resources.LoadAll<CollectableItemData>("");
		}
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData.itemName == itemName)
			{
				return collectableItemData;
			}
		}
		return null;
	}

	[Server]
	public void UpdateObjectHealth(Vector3 localPosition, string itemName, int wagonID, float newHealth)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::UpdateObjectHealth(UnityEngine.Vector3,System.String,System.Int32,System.Single)' called when server was not active");
			return;
		}
		for (int i = 0; i < networkBuildObjects.Count; i++)
		{
			NetworkBuildData networkBuildData = networkBuildObjects[i];
			if (networkBuildData.itemName == itemName && networkBuildData.wagonID == wagonID && Vector3.Distance(networkBuildData.localPosition, localPosition) < 0.1f)
			{
				NetworkBuildData value = networkBuildData;
				value.health = newHealth;
				networkBuildObjects[i] = value;
				UpdateLocalObjectHealth(localPosition, itemName, wagonID, newHealth);
				break;
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdUpdateObjectHealth(Vector3 localPosition, string itemName, int wagonID, float newHealth)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPosition);
		writer.WriteString(itemName);
		writer.WriteInt(wagonID);
		writer.WriteFloat(newHealth);
		SendCommandInternal("System.Void TrainBuildManager::CmdUpdateObjectHealth(UnityEngine.Vector3,System.String,System.Int32,System.Single)", 254111363, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateLocalObjectHealth(Vector3 localPosition, string itemName, int wagonID, float newHealth)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPosition);
		writer.WriteString(itemName);
		writer.WriteInt(wagonID);
		writer.WriteFloat(newHealth);
		SendRPCInternal("System.Void TrainBuildManager::UpdateLocalObjectHealth(UnityEngine.Vector3,System.String,System.Int32,System.Single)", -1533795838, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void LoadAllDataFromSave()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::LoadAllDataFromSave()' called when server was not active");
			return;
		}
		ClearAllExistingObjects();
		if (!Singleton<ES3SaveManager>.Instance.KeyExists("PropCount"))
		{
			CreateDefaultWagon();
			if (ScreenFader.Instance != null)
			{
				ScreenFader.Instance.FadeIn();
			}
			return;
		}
		int num = Singleton<ES3SaveManager>.Instance.LoadData("PropCount", 0);
		if (num == 0)
		{
			CreateDefaultWagon();
			if (ScreenFader.Instance != null)
			{
				ScreenFader.Instance.FadeIn();
			}
			return;
		}
		if (networkBuildObjects != null)
		{
			try
			{
				networkBuildObjects.Clear();
			}
			catch (Exception ex)
			{
				Debug.LogWarning("NetworkBuildObjects temizlenirken hata: " + ex.Message + " [TREN]");
			}
		}
		new List<NetworkBuildData>();
		List<NetworkBuildData> list = new List<NetworkBuildData>();
		List<NetworkBuildData> list2 = new List<NetworkBuildData>();
		for (int i = 0; i < num; i++)
		{
			string key = "PropData_" + i;
			if (Singleton<ES3SaveManager>.Instance.KeyExists(key))
			{
				PropSaveSystem.PropSaveData propSaveData = Singleton<ES3SaveManager>.Instance.LoadData<PropSaveSystem.PropSaveData>(key);
				NetworkBuildData item = NetworkBuildData.FromPropSaveData(propSaveData);
				if (!string.IsNullOrEmpty(item.stateData))
				{
					Debug.LogWarning("[TRAINBUILD_LOAD] \ud83d\udce5 Item '" + propSaveData.itemName + "' has stateData: " + item.stateData);
				}
				CollectableItemData collectableItemData = FindItemDataByName(propSaveData.itemName);
				if (collectableItemData != null && collectableItemData.itemType == ItemType.Wagon)
				{
					list.Add(item);
				}
				else
				{
					list2.Add(item);
				}
			}
		}
		list = list.OrderBy((NetworkBuildData w) => w.wagonID).ToList();
		bool num2 = list.Count > 0;
		Debug.Log($"Toplam wagon sayısı: {list.Count}, Diğer obje: {list2.Count} [TREN]");
		if (!num2)
		{
			CreateDefaultWagon();
			if (list2.Count > 0)
			{
				StartCoroutine(LoadOtherObjectsAfterWagons(list2));
				return;
			}
			isBuildObjectsLoaded = true;
			if (ScreenFader.Instance != null)
			{
				ScreenFader.Instance.FadeIn();
			}
		}
		else
		{
			StartCoroutine(LoadWagonsThenObjects(list, list2));
		}
	}

	private IEnumerator LoadWagonsThenObjects(List<NetworkBuildData> wagonData, List<NetworkBuildData> otherData)
	{
		foreach (NetworkBuildData wagonDatum in wagonData)
		{
			if (networkBuildObjects != null)
			{
				try
				{
					networkBuildObjects.Add(wagonDatum);
					SpawnObjectLocally(wagonDatum);
				}
				catch (Exception ex)
				{
					Debug.LogWarning("Wagon yüklenirken hata: " + ex.Message + " [TREN]");
				}
			}
			yield return null;
		}
		yield return StartCoroutine(LoadOtherObjectsAfterWagons(otherData));
	}

	private IEnumerator LoadOtherObjectsAfterWagons(List<NetworkBuildData> otherData)
	{
		yield return new WaitForSeconds(0.5f);
		int spawnCount = 0;
		foreach (NetworkBuildData otherDatum in otherData)
		{
			if (networkBuildObjects != null)
			{
				try
				{
					networkBuildObjects.Add(otherDatum);
					SpawnObjectLocally(otherDatum);
				}
				catch (Exception ex)
				{
					Debug.LogWarning("Obje yüklenirken hata: " + ex.Message);
				}
			}
			spawnCount++;
			if (spawnCount % 3 == 0)
			{
				yield return null;
			}
		}
		isBuildObjectsLoaded = true;
		if (ScreenFader.Instance != null)
		{
			ScreenFader.Instance.FadeIn();
		}
	}

	[Server]
	private void ClearAllExistingObjects()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::ClearAllExistingObjects()' called when server was not active");
			return;
		}
		PropBase[] array = UnityEngine.Object.FindObjectsOfType<PropBase>();
		foreach (PropBase propBase in array)
		{
			if (propBase != null)
			{
				if (Singleton<PoolingSystem>.Instance != null)
				{
					Singleton<PoolingSystem>.Instance.DestroyAPS(propBase.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(propBase.gameObject);
				}
			}
		}
		if (trainController != null)
		{
			trainController.wagonControllers.Clear();
		}
		spawnedObjects.Clear();
		Debug.Log("Mevcut tüm objeler temizlendi.");
	}

	private void CreateDefaultWagon()
	{
		Debug.Log("=== CreateDefaultWagon ÇAĞRILDI === [TREN]");
		if (trainController == null)
		{
			Debug.LogError("TrainController NULL! [TREN]");
			return;
		}
		if (trainController.firstWagonConnectionPoint == null)
		{
			Debug.LogError("firstWagonConnectionPoint NULL! [TREN]");
			return;
		}
		Debug.Log("Default wagon LOCAL değerlerle oluşturuluyor... [TREN]");
		NetworkBuildData networkBuildData = new NetworkBuildData("Wagon", Vector3.zero, Vector3.zero, 100f, 0, "");
		if (networkBuildObjects != null)
		{
			Debug.Log($"NetworkBuildObjects mevcut, wagon ekleniyor... (Mevcut obje sayısı: {networkBuildObjects.Count}) [TREN]");
			try
			{
				networkBuildObjects.Add(networkBuildData);
				Debug.Log($"Default wagon networkBuildObjects'e eklendi! Yeni sayı: {networkBuildObjects.Count} [TREN]");
				Debug.Log("Server'da direkt wagon spawn ediliyor... [TREN]");
				SpawnObjectLocally(networkBuildData);
				Debug.Log("SpawnDefaultGroundsAfterWagon coroutine başlatılıyor... [TREN]");
				StartCoroutine(SpawnDefaultGroundsAfterWagon());
				return;
			}
			catch (Exception ex)
			{
				Debug.LogError("Default wagon oluşturulamadı: " + ex.Message + " [TREN]");
				Debug.Log("Manuel wagon oluşturma başlatılıyor... [TREN]");
				CreateDefaultWagonManually();
				return;
			}
		}
		Debug.LogWarning("NetworkBuildObjects NULL! Manuel oluşturma başlatılıyor... [TREN]");
		CreateDefaultWagonManually();
	}

	private IEnumerator SpawnDefaultGroundsAfterWagon()
	{
		Debug.Log("=== SpawnDefaultGroundsAfterWagon BAŞLADI === [TREN]");
		Debug.Log("Default wagon spawn edilmesini bekliyorum... [TREN]");
		float waitTime = 0f;
		float maxWaitTime = 5f;
		WagonController wagonController = null;
		while (waitTime < maxWaitTime)
		{
			yield return new WaitForSeconds(0.1f);
			waitTime += 0.1f;
			Debug.Log($"Bekleme süresi: {waitTime:F1}s, wagonControllers sayısı: {trainController.wagonControllers.Count} [TREN]");
			wagonController = trainController.wagonControllers.FirstOrDefault((WagonController w) => w.wagonID == 0);
			if (wagonController != null)
			{
				Debug.Log($"Default wagon bulundu! Bekleme süresi: {waitTime:F1}s [TREN]");
				break;
			}
		}
		if (wagonController == null)
		{
			Debug.LogError($"Default wagon {maxWaitTime} saniye sonra hala bulunamadı! wagonControllers listesinde ID=0 yok! [TREN]");
			isBuildObjectsLoaded = true;
			yield break;
		}
		Debug.Log("Default wagon: " + wagonController.name + " [TREN]");
		if (wagonController.snapPoints == null || wagonController.snapPoints.Count == 0)
		{
			Debug.LogWarning($"Default wagon snap points yok! snapPoints={wagonController.snapPoints}, Count={wagonController.snapPoints?.Count ?? 0} [TREN]");
			isBuildObjectsLoaded = true;
			yield break;
		}
		Debug.Log($"SnapPoints sayısı: {wagonController.snapPoints.Count} [TREN]");
		if (groundData == null)
		{
			Debug.LogWarning("TrainBuildManager groundData yok! [TREN]");
			isBuildObjectsLoaded = true;
			yield break;
		}
		int num = 0;
		foreach (Transform snapPoint in wagonController.snapPoints)
		{
			if (snapPoint == null)
			{
				Debug.LogWarning($"SnapPoint {num} NULL! [TREN]");
				continue;
			}
			Vector3 localPosition = snapPoint.localPosition;
			Vector3 localEulerAngles = snapPoint.localEulerAngles;
			SpawnBuildObjectOnServer(localPosition, localEulerAngles, groundData.itemName, 0);
			num++;
		}
		isBuildObjectsLoaded = true;
	}

	private void CreateDefaultWagonManually()
	{
		if (trainController == null)
		{
			Debug.LogError("TrainController NULL! [TREN]");
			return;
		}
		if (trainController.firstWagonConnectionPoint == null)
		{
			Debug.LogError("firstWagonConnectionPoint NULL! [TREN]");
			return;
		}
		GameObject gameObject = null;
		if (trainController.vagonPrefab != null)
		{
			Debug.Log("VagonPrefab mevcut [TREN]");
			gameObject = ((!(Singleton<PoolingSystem>.Instance != null)) ? UnityEngine.Object.Instantiate(trainController.vagonPrefab) : Singleton<PoolingSystem>.Instance.InstantiateAPS("Wagon"));
		}
		else
		{
			Debug.LogError("VagonPrefab NULL! [TREN]");
		}
		if (gameObject == null)
		{
			Debug.LogError("Default wagon instantiate edilemedi! [TREN]");
			return;
		}
		WagonController wagonController = gameObject.GetComponent<WagonController>();
		if (wagonController == null)
		{
			wagonController = gameObject.AddComponent<WagonController>();
		}
		wagonController.data = null;
		wagonController.assignedWagonID = 0;
		wagonController.health = 100f;
		wagonController.InitializeWagon(0);
		gameObject.transform.SetParent(trainController.transform, worldPositionStays: false);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localEulerAngles = Vector3.zero;
		if (!trainController.wagonControllers.Any((WagonController w) => w.wagonID == 0))
		{
			trainController.wagonControllers.Add(wagonController);
		}
		else
		{
			Debug.LogWarning("Wagon zaten wagonControllers'da mevcut! [TREN]");
		}
		spawnedObjects.Add(gameObject);
		wagonController.CreateDefaultWagon();
		isBuildObjectsLoaded = true;
	}

	private string GetComponentState(GameObject obj)
	{
		FurnaceController component = obj.GetComponent<FurnaceController>();
		if (component != null)
		{
			return component.SaveState();
		}
		GrillController component2 = obj.GetComponent<GrillController>();
		if (component2 != null)
		{
			return component2.SaveState();
		}
		BasicWaterPurifierController component3 = obj.GetComponent<BasicWaterPurifierController>();
		if (component3 != null)
		{
			return component3.SaveState();
		}
		PlantPotController component4 = obj.GetComponent<PlantPotController>();
		if (component4 != null)
		{
			return component4.SaveState();
		}
		ChestController component5 = obj.GetComponent<ChestController>();
		if (component5 != null)
		{
			return component5.SaveState();
		}
		SignController component6 = obj.GetComponent<SignController>();
		if (component6 != null)
		{
			return component6.SaveState();
		}
		return "";
	}

	[Server]
	public void SaveAllData()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::SaveAllData()' called when server was not active");
			return;
		}
		isSaving = true;
		if (networkBuildObjects.Count == 0)
		{
			Debug.Log("Kaydedilecek data bulunamadı.");
			Singleton<ES3SaveManager>.Instance.SaveData("PropCount", 0);
			isSaving = false;
			return;
		}
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (!(spawnedObject != null))
			{
				continue;
			}
			PropBase component = spawnedObject.GetComponent<PropBase>();
			if (component != null)
			{
				if (component.data == null)
				{
					Debug.LogWarning(string.Format("[SaveAllData] DATA NULL! Object: '{0}', PropType: {1}, WagonID: {2}, LocalPos: {3}, Parent: '{4}', Scene: {5}", spawnedObject.name, component.propType, component.assignedWagonID, spawnedObject.transform.localPosition, (spawnedObject.transform.parent != null) ? spawnedObject.transform.parent.name : "none", spawnedObject.scene.name));
				}
				if (string.IsNullOrEmpty(component.uniqueID))
				{
					component.SetID();
				}
			}
		}
		List<NetworkBuildData> list = new List<NetworkBuildData>();
		for (int i = 0; i < networkBuildObjects.Count; i++)
		{
			NetworkBuildData dataCopy;
			NetworkBuildData item = (dataCopy = networkBuildObjects[i]);
			GameObject gameObject = spawnedObjects.FirstOrDefault(delegate(GameObject obj)
			{
				if (obj == null)
				{
					return false;
				}
				PropBase component3 = obj.GetComponent<PropBase>();
				if (component3 == null)
				{
					return false;
				}
				if (!string.IsNullOrEmpty(dataCopy.itemID) && component3.uniqueID == dataCopy.itemID)
				{
					return true;
				}
				return component3.data?.itemName == dataCopy.itemName && component3.assignedWagonID == dataCopy.wagonID && Vector3.Distance(obj.transform.localPosition, dataCopy.localPosition) < 0.1f;
			});
			if (gameObject != null)
			{
				PropBase component2 = gameObject.GetComponent<PropBase>();
				if (component2 != null && !string.IsNullOrEmpty(component2.uniqueID))
				{
					item.itemID = component2.uniqueID;
					if (component2.data != null)
					{
						item.isNetworkObject = component2.data.isNetworkObject;
					}
					item.stateData = GetComponentState(gameObject);
				}
			}
			if (item.itemName == "Torch")
			{
				Debug.Log(string.Format("[TORCH] SAVE entry[{0}] | localPos={1} | parentObjectID='{2}' | leafIndex={3} | uid={4} | matched={5}", i, item.localPosition, item.parentObjectID, item.parentLeafIndex, item.itemID, (gameObject != null) ? gameObject.name : "NULL"));
			}
			list.Add(item);
		}
		Debug.LogWarning($"[TRAINBUILD] SaveAllData - Updating networkBuildObjects: {networkBuildObjects.Count} → {list.Count}");
		for (int num = 0; num < list.Count; num++)
		{
			if (num < networkBuildObjects.Count)
			{
				networkBuildObjects[num] = list[num];
			}
			else
			{
				networkBuildObjects.Add(list[num]);
			}
		}
		while (networkBuildObjects.Count > list.Count)
		{
			networkBuildObjects.RemoveAt(networkBuildObjects.Count - 1);
		}
		Debug.LogWarning($"[TRAINBUILD] SaveAllData - networkBuildObjects updated: {networkBuildObjects.Count} items");
		Singleton<ES3SaveManager>.Instance.SaveData("PropCount", networkBuildObjects.Count);
		for (int num2 = 0; num2 < networkBuildObjects.Count; num2++)
		{
			string key = "PropData_" + num2;
			PropSaveSystem.PropSaveData value = networkBuildObjects[num2].ToPropSaveData();
			Singleton<ES3SaveManager>.Instance.SaveData(key, value);
		}
		isSaving = false;
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestAddWagon(string wagonItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(wagonItemName);
		SendCommandInternal("System.Void TrainBuildManager::CmdRequestAddWagon(System.String)", -682584786, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddWagon(string wagonItemName, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(wagonItemName);
		writer.WriteVector3(localPosition);
		writer.WriteVector3(localEulerAngles);
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void TrainBuildManager::CmdAddWagon(System.String,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", 1725204834, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddWagonToParent(string itemName, int parentWagonID, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(parentWagonID);
		writer.WriteVector3(localPosition);
		writer.WriteVector3(localEulerAngles);
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void TrainBuildManager::CmdAddWagonToParent(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", 345213220, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcAddWagonToParent(string itemName, int parentWagonID, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(parentWagonID);
		writer.WriteVector3(localPosition);
		writer.WriteVector3(localEulerAngles);
		writer.WriteInt(wagonID);
		SendRPCInternal("System.Void TrainBuildManager::RpcAddWagonToParent(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", 2043816409, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private Transform FindParentByWagonID(int parentWagonID)
	{
		if (trainController != null)
		{
			return trainController.transform;
		}
		Debug.LogError("TrainController null!");
		return null;
	}

	private void CreateAndSetupWagon(string itemName, int wagonID, Transform parent, Vector3 localPos, Vector3 localEuler)
	{
		CollectableItemData collectableItemData = FindItemDataByName(itemName);
		GameObject gameObject = CreateWagonObject(collectableItemData);
		if (gameObject == null)
		{
			Debug.LogError("Wagon oluşturulamadı: " + itemName);
			return;
		}
		WagonController wagonController = gameObject.GetComponent<WagonController>();
		if (wagonController == null)
		{
			wagonController = gameObject.AddComponent<WagonController>();
		}
		PropBase propBase = gameObject.GetComponent<PropBase>();
		if (propBase == null)
		{
			propBase = gameObject.AddComponent<PropBase>();
		}
		propBase.data = collectableItemData;
		propBase.assignedWagonID = wagonID;
		propBase.health = 100f;
		wagonController.InitializeWagon(wagonID);
		wagonController.data = collectableItemData;
		gameObject.transform.SetParent(parent, worldPositionStays: false);
		gameObject.transform.localPosition = localPos;
		gameObject.transform.localEulerAngles = localEuler;
		if (trainController != null && !trainController.wagonControllers.Any((WagonController w) => w.wagonID == wagonID))
		{
			trainController.wagonControllers.Add(wagonController);
			if (wagonController.animator != null && !trainController.animators.Contains(wagonController.animator))
			{
				trainController.animators.Add(wagonController.animator);
			}
		}
		spawnedObjects.Add(gameObject);
		if (trainController != null)
		{
			trainController.OnWagonAdded.Invoke(wagonController);
		}
		NetworkBuildData item = new NetworkBuildData(itemName, localPos, localEuler, 100f, wagonID, "");
		if (base.isServer && networkBuildObjects != null && !networkBuildObjects.Any((NetworkBuildData x) => x.wagonID == wagonID && x.itemName == itemName))
		{
			networkBuildObjects.Add(item);
		}
	}

	private GameObject CreateWagonObject(CollectableItemData wagonItemData)
	{
		GameObject gameObject = null;
		if (wagonItemData != null && wagonItemData.itemPrefab != null)
		{
			if (Singleton<PoolingSystem>.Instance != null)
			{
				gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS(wagonItemData.itemName);
			}
			if (gameObject == null)
			{
				gameObject = UnityEngine.Object.Instantiate(wagonItemData.itemPrefab);
			}
		}
		else if (trainController != null && trainController.vagonPrefab != null)
		{
			if (Singleton<PoolingSystem>.Instance != null)
			{
				gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS("Wagon");
			}
			if (gameObject == null)
			{
				gameObject = UnityEngine.Object.Instantiate(trainController.vagonPrefab);
			}
		}
		return gameObject;
	}

	private Transform FindCorrectParentForWagon(int wagonID)
	{
		return trainController.transform;
	}

	private Transform FindTransformByInstanceID(int instanceID)
	{
		WagonController[] array = UnityEngine.Object.FindObjectsOfType<WagonController>();
		foreach (WagonController wagonController in array)
		{
			if (wagonController.nextWagonSpawnPoint != null && wagonController.nextWagonSpawnPoint.GetInstanceID() == instanceID)
			{
				return wagonController.nextWagonSpawnPoint;
			}
		}
		if (trainController != null)
		{
			foreach (WagonController wagonController2 in trainController.wagonControllers)
			{
				if (wagonController2.nextWagonSpawnPoint != null && wagonController2.nextWagonSpawnPoint.GetInstanceID() == instanceID)
				{
					return wagonController2.nextWagonSpawnPoint;
				}
			}
		}
		Debug.LogError($"Instance ID {instanceID} ile transform bulunamadı!");
		return null;
	}

	[Command(requiresAuthority = false)]
	public void CmdRemoveWagon(int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void TrainBuildManager::CmdRemoveWagon(System.Int32)", -393882637, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void AddWagonOnServer(string wagonItemName, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::AddWagonOnServer(System.String,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)' called when server was not active");
			return;
		}
		NetworkBuildData item = new NetworkBuildData(wagonItemName, localPosition, localEulerAngles, 100f, wagonID, "");
		networkBuildObjects.Add(item);
	}

	[Server]
	public void RemoveWagonOnServer(int wagonID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::RemoveWagonOnServer(System.Int32)' called when server was not active");
			return;
		}
		for (int num = networkBuildObjects.Count - 1; num >= 0; num--)
		{
			NetworkBuildData networkBuildData = networkBuildObjects[num];
			if (networkBuildData.wagonID == wagonID)
			{
				CollectableItemData collectableItemData = FindItemDataByName(networkBuildData.itemName);
				if (collectableItemData != null && collectableItemData.itemType == ItemType.Wagon)
				{
					networkBuildObjects.RemoveAt(num);
					break;
				}
			}
		}
	}

	[Server]
	public void SyncDataToNewPlayer(TSPlayerController newPlayer)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::SyncDataToNewPlayer(TSPlayerController)' called when server was not active");
		}
		else
		{
			if (newPlayer == null)
			{
				return;
			}
			foreach (NetworkBuildData networkBuildObject in networkBuildObjects)
			{
				_ = networkBuildObject;
			}
		}
	}

	[Server]
	public void OnPlayerConnected(TSPlayerController player)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainBuildManager::OnPlayerConnected(TSPlayerController)' called when server was not active");
		}
		else
		{
			StartCoroutine(SyncAfterDelay(player));
		}
	}

	private IEnumerator SyncAfterDelay(TSPlayerController player)
	{
		yield return new WaitForSeconds(1f);
	}

	private IEnumerator LoadStateAfterNetworkInit(GameObject spawnedObj, string stateData, string itemName)
	{
		if (spawnedObj == null)
		{
			Debug.LogWarning("[TRAINBUILD_LOAD] ⚠\ufe0f Object was destroyed before state could be loaded!");
			yield break;
		}
		NetworkBehaviour netBehaviour = spawnedObj.GetComponent<FurnaceController>();
		if (netBehaviour == null)
		{
			netBehaviour = spawnedObj.GetComponent<GrillController>();
		}
		if (netBehaviour == null)
		{
			netBehaviour = spawnedObj.GetComponent<BasicWaterPurifierController>();
		}
		if (netBehaviour == null)
		{
			netBehaviour = spawnedObj.GetComponent<PlantPotController>();
		}
		if (netBehaviour == null)
		{
			netBehaviour = spawnedObj.GetComponent<ChestController>();
		}
		if (netBehaviour == null)
		{
			netBehaviour = spawnedObj.GetComponent<SignController>();
		}
		float waitTime = 0f;
		float maxWaitTime = 3f;
		while (netBehaviour != null && !netBehaviour.isServer && waitTime < maxWaitTime)
		{
			yield return new WaitForSeconds(0.1f);
			waitTime += 0.1f;
		}
		if (waitTime >= maxWaitTime)
		{
			Debug.LogWarning($"[TRAINBUILD_LOAD] ⚠\ufe0f Network initialization timed out for '{itemName}' after {maxWaitTime}s!");
		}
		if (spawnedObj == null)
		{
			Debug.LogWarning("[TRAINBUILD_LOAD] ⚠\ufe0f Object was destroyed while waiting for network init!");
			yield break;
		}
		Debug.LogWarning($"[TRAINBUILD_LOAD] \ud83d\udd04 Loading state for '{itemName}' after {waitTime:F1}s: {stateData}");
		FurnaceController component = spawnedObj.GetComponent<FurnaceController>();
		if (component != null)
		{
			Debug.LogWarning($"[TRAINBUILD_LOAD] \ud83d\udd25 Calling FurnaceController.LoadState() - isServer={component.isServer}");
			component.LoadState(stateData);
			yield break;
		}
		GrillController component2 = spawnedObj.GetComponent<GrillController>();
		if (component2 != null)
		{
			Debug.LogWarning($"[TRAINBUILD_LOAD] \ud83c\udf56 Calling GrillController.LoadState() - isServer={component2.isServer}");
			component2.LoadState(stateData);
			yield break;
		}
		BasicWaterPurifierController component3 = spawnedObj.GetComponent<BasicWaterPurifierController>();
		if (component3 != null)
		{
			Debug.LogWarning($"[TRAINBUILD_LOAD] \ud83d\udca7 Calling WaterPurifier.LoadState() - isServer={component3.isServer}");
			component3.LoadState(stateData);
			yield break;
		}
		PlantPotController component4 = spawnedObj.GetComponent<PlantPotController>();
		if (component4 != null)
		{
			Debug.LogWarning($"[TRAINBUILD_LOAD] \ud83c\udf31 Calling PlantPotController.LoadState() - isServer={component4.isServer}");
			component4.LoadState(stateData);
			yield break;
		}
		ChestController component5 = spawnedObj.GetComponent<ChestController>();
		if (component5 != null)
		{
			component5.LoadState(stateData);
			yield break;
		}
		SignController component6 = spawnedObj.GetComponent<SignController>();
		if (component6 != null)
		{
			component6.LoadState(stateData);
		}
		else
		{
			Debug.LogWarning("[TRAINBUILD_LOAD] ⚠\ufe0f No saveable component found on '" + itemName + "'!");
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdSpawnBuildObject(Vector3 localPos, Vector3 localEuler, string itemID, int targetWagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPos);
		writer.WriteVector3(localEuler);
		writer.WriteString(itemID);
		writer.WriteInt(targetWagonID);
		SendCommandInternal("System.Void TrainBuildManager::CmdSpawnBuildObject(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32)", -413253415, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdNotifyPlayerConnected()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainBuildManager::CmdNotifyPlayerConnected()", 1499418601, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetForceClientSync(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void TrainBuildManager::TargetForceClientSync(Mirror.NetworkConnection)", 1210360609, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ForceClientResyncDelayed()
	{
		yield return new WaitForSeconds(1f);
		if (networkBuildObjects.Count <= spawnedObjects.Count)
		{
			yield break;
		}
		ClearAllObjectsLocally();
		foreach (NetworkBuildData networkBuildObject in networkBuildObjects)
		{
			SpawnObjectLocally(networkBuildObject);
		}
	}

	private void OnBuildObjectsChanged(SyncList<NetworkBuildData>.Operation op, int itemIndex, NetworkBuildData oldItem, NetworkBuildData newItem)
	{
		if (!isInitialized && !base.isServer)
		{
			Debug.Log($"Client henüz hazır değil, callback atlandı: {op} [TREN]");
		}
		else if (!isSaving)
		{
			switch (op)
			{
			case SyncList<NetworkBuildData>.Operation.OP_ADD:
				SpawnObjectLocallyWithDuplicateCheck(newItem);
				break;
			case SyncList<NetworkBuildData>.Operation.OP_REMOVEAT:
				DestroyObjectLocally(oldItem);
				break;
			case SyncList<NetworkBuildData>.Operation.OP_SET:
				MoveObjectLocally(oldItem, newItem);
				break;
			case SyncList<NetworkBuildData>.Operation.OP_CLEAR:
				ClearAllObjectsLocally();
				break;
			case SyncList<NetworkBuildData>.Operation.OP_INSERT:
				break;
			}
		}
	}

	private IEnumerator SpawnExistingObjectsOnClient()
	{
		yield return new WaitForSeconds(1f);
		ClearAllObjectsLocally();
		isInitialized = true;
		if (networkBuildObjects.Count > 0)
		{
			int processed = 0;
			for (int i = 0; i < networkBuildObjects.Count; i++)
			{
				SpawnObjectLocally(networkBuildObjects[i]);
				int num = processed + 1;
				processed = num;
				if (num >= 16)
				{
					processed = 0;
					yield return null;
				}
			}
		}
		RefreshAllPlayerParents();
		isBuildObjectsLoaded = true;
		if (ScreenFader.Instance != null)
		{
			ScreenFader.Instance.FadeIn();
		}
	}

	private void RefreshAllPlayerParents()
	{
		TSPlayerController[] array = UnityEngine.Object.FindObjectsOfType<TSPlayerController>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].RefreshNetworkParent();
		}
	}

	private bool DoesObjectAlreadyExist(NetworkBuildData buildObj)
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (!(spawnedObject != null))
			{
				continue;
			}
			PropBase component = spawnedObject.GetComponent<PropBase>();
			if (!(component != null) || component.assignedWagonID != buildObj.wagonID)
			{
				continue;
			}
			bool flag = false;
			flag = ((!(component.data != null)) ? spawnedObject.name.Contains(buildObj.itemName) : (component.data.itemName == buildObj.itemName));
			if (flag && Vector3.Distance(spawnedObject.transform.localPosition, buildObj.localPosition) < 0.1f)
			{
				if (buildObj.itemName == "Torch")
				{
					Debug.Log(string.Format("[TORCH] DoesObjectAlreadyExist=TRUE | buildPos={0} | existingObjLocalPos={1} | existingParent={2}", buildObj.localPosition, spawnedObject.transform.localPosition, (spawnedObject.transform.parent != null) ? spawnedObject.transform.parent.name : "null"));
				}
				return true;
			}
		}
		return false;
	}

	private void MoveObjectLocally(NetworkBuildData oldData, NetworkBuildData newData)
	{
		GameObject gameObject = null;
		for (int num = spawnedObjects.Count - 1; num >= 0; num--)
		{
			if (spawnedObjects[num] == null)
			{
				spawnedObjects.RemoveAt(num);
			}
			else
			{
				PropBase component = spawnedObjects[num].GetComponent<PropBase>();
				if (component != null && !string.IsNullOrEmpty(oldData.itemID) && component.uniqueID == oldData.itemID)
				{
					gameObject = spawnedObjects[num];
					break;
				}
			}
		}
		if (gameObject == null)
		{
			for (int i = 0; i < spawnedObjects.Count; i++)
			{
				if (!(spawnedObjects[i] == null))
				{
					PropBase component2 = spawnedObjects[i].GetComponent<PropBase>();
					if (component2 != null && component2.data != null && component2.data.itemName == oldData.itemName && component2.assignedWagonID == oldData.wagonID)
					{
						gameObject = spawnedObjects[i];
						break;
					}
				}
			}
		}
		if (gameObject == null)
		{
			Debug.LogWarning("[TrainBuildManager] MoveObjectLocally: Object not found: " + oldData.itemName + ". Spawning fresh.");
			SpawnObjectLocally(newData);
			return;
		}
		CollectableItemData collectableItemData = FindItemDataByName(newData.itemName);
		if (collectableItemData != null)
		{
			SetCorrectParent(gameObject.transform, newData.wagonID, collectableItemData.itemType);
		}
		gameObject.transform.localPosition = newData.localPosition;
		gameObject.transform.localEulerAngles = newData.localEulerAngles;
		PropBase component3 = gameObject.GetComponent<PropBase>();
		if (component3 != null)
		{
			component3.assignedWagonID = newData.wagonID;
		}
	}

	private void SpawnObjectLocallyWithDuplicateCheck(NetworkBuildData buildObj)
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (!(spawnedObject != null))
			{
				continue;
			}
			PropBase component = spawnedObject.GetComponent<PropBase>();
			if (component != null && component.assignedWagonID == buildObj.wagonID)
			{
				bool flag = false;
				flag = ((!(component.data != null)) ? spawnedObject.name.Contains(buildObj.itemName) : (component.data.itemName == buildObj.itemName));
				if (flag && Vector3.Distance(spawnedObject.transform.localPosition, buildObj.localPosition) < 0.1f)
				{
					Debug.Log("Obje zaten mevcut, duplicate spawn önlendi: " + buildObj.itemName);
					return;
				}
			}
		}
		SpawnObjectLocally(buildObj);
	}

	public TrainBuildManager()
	{
		InitSyncObject(networkBuildObjects);
		InitSyncObject(uniqueIdToNetId);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestSync()
	{
		RpcForceSync(base.connectionToClient);
	}

	protected static void InvokeUserCode_CmdRequestSync(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSync called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdRequestSync();
		}
	}

	protected void UserCode_RpcForceSync__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		StartCoroutine(ForceClientResync());
	}

	protected static void InvokeUserCode_RpcForceSync__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcForceSync called on server.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_RpcForceSync__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_CmdDestroyBuildObject__Vector3__String__Int32(Vector3 worldPosition, string itemName, int wagonID)
	{
		DestroyBuildObjectOnServer(worldPosition, itemName, wagonID);
	}

	protected static void InvokeUserCode_CmdDestroyBuildObject__Vector3__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDestroyBuildObject called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdDestroyBuildObject__Vector3__String__Int32(reader.ReadVector3(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdUpdateObjectHealth__Vector3__String__Int32__Single(Vector3 localPosition, string itemName, int wagonID, float newHealth)
	{
		UpdateObjectHealth(localPosition, itemName, wagonID, newHealth);
	}

	protected static void InvokeUserCode_CmdUpdateObjectHealth__Vector3__String__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateObjectHealth called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdUpdateObjectHealth__Vector3__String__Int32__Single(reader.ReadVector3(), reader.ReadString(), reader.ReadInt(), reader.ReadFloat());
		}
	}

	protected void UserCode_UpdateLocalObjectHealth__Vector3__String__Int32__Single(Vector3 localPosition, string itemName, int wagonID, float newHealth)
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject != null)
			{
				PropBase component = spawnedObject.GetComponent<PropBase>();
				if (component != null && component.data != null && component.data.itemName == itemName && component.assignedWagonID == wagonID && Vector3.Distance(spawnedObject.transform.localPosition, localPosition) < 0.1f)
				{
					component.health = newHealth;
					break;
				}
			}
		}
	}

	protected static void InvokeUserCode_UpdateLocalObjectHealth__Vector3__String__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateLocalObjectHealth called on server.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_UpdateLocalObjectHealth__Vector3__String__Int32__Single(reader.ReadVector3(), reader.ReadString(), reader.ReadInt(), reader.ReadFloat());
		}
	}

	protected void UserCode_CmdRequestAddWagon__String(string wagonItemName)
	{
		if (trainController != null)
		{
			CollectableItemData wagonItemData = FindItemDataByName(wagonItemName);
			trainController.AddWagon(wagonItemData);
		}
	}

	protected static void InvokeUserCode_CmdRequestAddWagon__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAddWagon called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdRequestAddWagon__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddWagon__String__Vector3__Vector3__Int32(string wagonItemName, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		AddWagonOnServer(wagonItemName, localPosition, localEulerAngles, wagonID);
	}

	protected static void InvokeUserCode_CmdAddWagon__String__Vector3__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddWagon called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdAddWagon__String__Vector3__Vector3__Int32(reader.ReadString(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdAddWagonToParent__String__Int32__Vector3__Vector3__Int32(string itemName, int parentWagonID, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		RpcAddWagonToParent(itemName, parentWagonID, localPosition, localEulerAngles, wagonID);
	}

	protected static void InvokeUserCode_CmdAddWagonToParent__String__Int32__Vector3__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddWagonToParent called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdAddWagonToParent__String__Int32__Vector3__Vector3__Int32(reader.ReadString(), reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcAddWagonToParent__String__Int32__Vector3__Vector3__Int32(string itemName, int parentWagonID, Vector3 localPosition, Vector3 localEulerAngles, int wagonID)
	{
		Transform transform = FindParentByWagonID(parentWagonID);
		if (transform == null)
		{
			Debug.LogError($"Parent transform bulunamadı! Parent Wagon ID: {parentWagonID}");
			return;
		}
		Vector3 localPos = Vector3.zero;
		Vector3 localEuler = Vector3.zero;
		if (parentWagonID >= 0 && trainController != null)
		{
			WagonController wagonController = trainController.wagonControllers.FirstOrDefault((WagonController w) => w.wagonID == parentWagonID);
			if (wagonController != null && wagonController.nextWagonSpawnPoint != null)
			{
				localPos = trainController.transform.InverseTransformPoint(wagonController.nextWagonSpawnPoint.position);
				localEuler = (Quaternion.Inverse(trainController.transform.rotation) * wagonController.nextWagonSpawnPoint.rotation).eulerAngles;
			}
		}
		CreateAndSetupWagon(itemName, wagonID, transform, localPos, localEuler);
	}

	protected static void InvokeUserCode_RpcAddWagonToParent__String__Int32__Vector3__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddWagonToParent called on server.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_RpcAddWagonToParent__String__Int32__Vector3__Vector3__Int32(reader.ReadString(), reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdRemoveWagon__Int32(int wagonID)
	{
		RemoveWagonOnServer(wagonID);
	}

	protected static void InvokeUserCode_CmdRemoveWagon__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveWagon called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdRemoveWagon__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdSpawnBuildObject__Vector3__Vector3__String__Int32(Vector3 localPos, Vector3 localEuler, string itemID, int targetWagonID)
	{
		SpawnBuildObjectOnServer(localPos, localEuler, itemID, targetWagonID);
	}

	protected static void InvokeUserCode_CmdSpawnBuildObject__Vector3__Vector3__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBuildObject called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdSpawnBuildObject__Vector3__Vector3__String__Int32(reader.ReadVector3(), reader.ReadVector3(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdNotifyPlayerConnected()
	{
		Debug.Log($"Client'dan oyuncu bağlantı bildirimi alındı. Mevcut obje sayısı: {networkBuildObjects.Count}");
		NetworkConnectionToClient networkConnectionToClient = base.connectionToClient;
		if (networkConnectionToClient != null && networkBuildObjects.Count > 0)
		{
			Debug.Log($"Client'a force sync gönderiliyor: {networkBuildObjects.Count} obje");
			TargetForceClientSync(networkConnectionToClient);
		}
		else if (networkBuildObjects.Count == 0)
		{
			Debug.Log("Server'da henüz obje yok, sync gerekmiyor.");
		}
	}

	protected static void InvokeUserCode_CmdNotifyPlayerConnected(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdNotifyPlayerConnected called on client.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_CmdNotifyPlayerConnected();
		}
	}

	protected void UserCode_TargetForceClientSync__NetworkConnection(NetworkConnection target)
	{
		Debug.Log("Server'dan force sync komutu alındı");
		StartCoroutine(ForceClientResyncDelayed());
	}

	protected static void InvokeUserCode_TargetForceClientSync__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetForceClientSync called on server.");
		}
		else
		{
			((TrainBuildManager)obj).UserCode_TargetForceClientSync__NetworkConnection(null);
		}
	}

	static TrainBuildManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdRequestSync()", InvokeUserCode_CmdRequestSync, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdDestroyBuildObject(UnityEngine.Vector3,System.String,System.Int32)", InvokeUserCode_CmdDestroyBuildObject__Vector3__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdUpdateObjectHealth(UnityEngine.Vector3,System.String,System.Int32,System.Single)", InvokeUserCode_CmdUpdateObjectHealth__Vector3__String__Int32__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdRequestAddWagon(System.String)", InvokeUserCode_CmdRequestAddWagon__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdAddWagon(System.String,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", InvokeUserCode_CmdAddWagon__String__Vector3__Vector3__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdAddWagonToParent(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", InvokeUserCode_CmdAddWagonToParent__String__Int32__Vector3__Vector3__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdRemoveWagon(System.Int32)", InvokeUserCode_CmdRemoveWagon__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdSpawnBuildObject(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32)", InvokeUserCode_CmdSpawnBuildObject__Vector3__Vector3__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainBuildManager), "System.Void TrainBuildManager::CmdNotifyPlayerConnected()", InvokeUserCode_CmdNotifyPlayerConnected, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainBuildManager), "System.Void TrainBuildManager::UpdateLocalObjectHealth(UnityEngine.Vector3,System.String,System.Int32,System.Single)", InvokeUserCode_UpdateLocalObjectHealth__Vector3__String__Int32__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainBuildManager), "System.Void TrainBuildManager::RpcAddWagonToParent(System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", InvokeUserCode_RpcAddWagonToParent__String__Int32__Vector3__Vector3__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainBuildManager), "System.Void TrainBuildManager::RpcForceSync(Mirror.NetworkConnectionToClient)", InvokeUserCode_RpcForceSync__NetworkConnectionToClient);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainBuildManager), "System.Void TrainBuildManager::TargetForceClientSync(Mirror.NetworkConnection)", InvokeUserCode_TargetForceClientSync__NetworkConnection);
	}
}
