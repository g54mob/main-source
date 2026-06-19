using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageChest : MonoBehaviour
{
	public GameObject storageChestGUI;

	public Transform spawnTransform;

	[HideInInspector]
	public float expelForce = 25f;

	[HideInInspector]
	public float expelTorque = 25f;

	private List<InventoryItem> containedItemKeys = new List<InventoryItem>();

	private Dictionary<InventoryItem, int> containedItems = new Dictionary<InventoryItem, int>();

	private List<SaveableTaggedObjectNoDepth> containedObjects = new List<SaveableTaggedObjectNoDepth>();

	private List<SaveableTaggedObjectNoDepth> inWorldQueueObjects = new List<SaveableTaggedObjectNoDepth>();

	private List<InventoryItem> inWorldQueueInventoryItemKeys = new List<InventoryItem>();

	private Dictionary<InventoryItem, int> inWorldQueueInventoryItems = new Dictionary<InventoryItem, int>();

	private bool isShuttingDown;

	private bool markedForDestroyFromTravel;

	private Coroutine currentSpawnItemsRoutine;

	private string spewItemSound = "chest_spew";

	private RoomBase associatedRoom;

	private InventoryManager invRef;

	private ObjectRegistration regRef;

	private void Awake()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
		invRef = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	private void Start()
	{
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		ulong? num = component.GetRoomUID();
		if (!num.HasValue)
		{
			Debug.LogError("No valid room found for Storage Chest.");
			num = 0uL;
		}
		associatedRoom = globalComponent.GetRoomForUID(num.Value);
	}

	private void OnApplicationQuit()
	{
		isShuttingDown = true;
	}

	public bool IsEmpty()
	{
		if (containedItemKeys.Count == 0 && containedObjects.Count == 0 && inWorldQueueInventoryItemKeys.Count == 0 && inWorldQueueObjects.Count == 0)
		{
			return true;
		}
		return false;
	}

	public void MarkForTravel()
	{
		markedForDestroyFromTravel = true;
		if (currentSpawnItemsRoutine != null)
		{
			StopCoroutine(currentSpawnItemsRoutine);
			currentSpawnItemsRoutine = null;
		}
	}

	public void SaveObject(SaveablePlacedObject data)
	{
		data.objectList.Clear();
		data.objectList.AddRange(containedObjects);
		data.objectListB.Clear();
		data.objectListB.AddRange(inWorldQueueObjects);
		data.intList.Clear();
		data.stringList.Clear();
		for (int i = 0; i < containedItemKeys.Count; i++)
		{
			data.intList.Add(containedItems[containedItemKeys[i]]);
			data.stringList.Add(invRef.GetPathForItem(containedItemKeys[i]));
		}
		data.intListB.Clear();
		data.stringListB.Clear();
		for (int j = 0; j < inWorldQueueInventoryItemKeys.Count; j++)
		{
			data.intListB.Add(inWorldQueueInventoryItems[inWorldQueueInventoryItemKeys[j]]);
			data.stringListB.Add(invRef.GetPathForItem(inWorldQueueInventoryItemKeys[j]));
		}
	}

	public void LoadObject(SaveablePlacedObject data)
	{
		containedObjects.Clear();
		if (data.objectList != null && data.objectList.Count > 0)
		{
			containedObjects.AddRange(data.objectList);
		}
		inWorldQueueObjects.Clear();
		if (data.objectListB != null && data.objectListB.Count > 0)
		{
			inWorldQueueObjects.AddRange(data.objectListB);
		}
		containedItems.Clear();
		containedItemKeys.Clear();
		if (data.stringList != null && data.intList != null && data.stringList.Count > 0)
		{
			for (int i = 0; i < data.stringList.Count; i++)
			{
				InventoryItem itemForPath = invRef.GetItemForPath(data.stringList[i]);
				containedItemKeys.Add(itemForPath);
				containedItems[itemForPath] = data.intList[i];
			}
		}
		inWorldQueueInventoryItems.Clear();
		inWorldQueueInventoryItemKeys.Clear();
		if (data.stringListB != null && data.intListB != null && data.stringListB.Count > 0)
		{
			for (int j = 0; j < data.stringListB.Count; j++)
			{
				InventoryItem itemForPath2 = invRef.GetItemForPath(data.stringListB[j]);
				inWorldQueueInventoryItemKeys.Add(itemForPath2);
				inWorldQueueInventoryItems[itemForPath2] = data.intListB[j];
			}
		}
		if (inWorldQueueObjects.Count > 0 || inWorldQueueInventoryItemKeys.Count > 0)
		{
			SpawnQueuedObjects();
		}
	}

	private void OnDestroy()
	{
		if (!isShuttingDown && !markedForDestroyFromTravel)
		{
			if (currentSpawnItemsRoutine != null)
			{
				StopCoroutine(currentSpawnItemsRoutine);
				currentSpawnItemsRoutine = null;
			}
			DestroyAllContainedObjects();
		}
	}

	public void OnClick()
	{
		if (currentSpawnItemsRoutine != null)
		{
			StopCoroutine(currentSpawnItemsRoutine);
			currentSpawnItemsRoutine = null;
		}
		Object.Instantiate(storageChestGUI, Vector3.zero, Quaternion.identity).GetComponent<StorageChestGUIController>().SetStorageRef(this);
	}

	public List<SaveableTaggedObjectNoDepth> GetinWorldQueueObjects()
	{
		return inWorldQueueObjects;
	}

	public List<InventoryItem> GetinWorldQueueInventoryItemKeys()
	{
		return inWorldQueueInventoryItemKeys;
	}

	public int GetNumberOfHeldInventoryItemsOfType(InventoryItem itemRef)
	{
		return inWorldQueueInventoryItems[itemRef];
	}

	public void RemoveInventoryItemFromQueue(InventoryItem itemRef, int numberToRemove)
	{
		inWorldQueueInventoryItems[itemRef] -= numberToRemove;
		if (inWorldQueueInventoryItems[itemRef] <= 0)
		{
			inWorldQueueInventoryItems.Remove(itemRef);
			inWorldQueueInventoryItemKeys.Remove(itemRef);
		}
	}

	public void RemoveSavedObjectFromQueue(SaveableTaggedObjectNoDepth objectRef)
	{
		inWorldQueueObjects.Remove(objectRef);
	}

	public void AddInventoryItemToQueue(InventoryItem itemRef, int numberToAdd)
	{
		if (!inWorldQueueInventoryItemKeys.Contains(itemRef))
		{
			inWorldQueueInventoryItems[itemRef] = 0;
			inWorldQueueInventoryItemKeys.Add(itemRef);
		}
		inWorldQueueInventoryItems[itemRef] += numberToAdd;
	}

	public void AddSavedObjectToQueue(SaveableTaggedObjectNoDepth objectRef)
	{
		inWorldQueueObjects.Add(objectRef);
	}

	public void AddObject(SaveableTaggedObjectNoDepth newObj)
	{
		containedObjects.Add(newObj);
	}

	public void RemoveObject(SaveableTaggedObjectNoDepth obj)
	{
		containedObjects.Remove(obj);
	}

	public List<SaveableTaggedObjectNoDepth> GetAllContainedObjects()
	{
		return containedObjects;
	}

	public void AddItem(InventoryItem newItem, int num)
	{
		if (!containedItemKeys.Contains(newItem))
		{
			containedItemKeys.Add(newItem);
			containedItems[newItem] = 0;
		}
		containedItems[newItem] += num;
	}

	public void RemoveItem(InventoryItem itemRef, int num)
	{
		if (!containedItemKeys.Contains(itemRef) || containedItems[itemRef] < num)
		{
			Debug.LogError("Attempting to remove an item from storage that isn't stored.");
			return;
		}
		containedItems[itemRef] -= num;
		if (containedItems[itemRef] <= 0)
		{
			containedItems.Remove(itemRef);
			containedItemKeys.Remove(itemRef);
		}
	}

	public List<InventoryItem> GetAllContainedItemKeys()
	{
		return containedItemKeys;
	}

	public int GetNumberOfItemStored(InventoryItem itemRef)
	{
		if (!containedItemKeys.Contains(itemRef))
		{
			return 0;
		}
		return containedItems[itemRef];
	}

	public Dictionary<InventoryItem, int> GetAllContainedItems()
	{
		return containedItems;
	}

	public RoomBase GetAssociatedRoom()
	{
		return associatedRoom;
	}

	private void DestroyAllContainedObjects()
	{
		for (int i = 0; i < containedItemKeys.Count; i++)
		{
			for (int j = 0; j < containedItems[containedItemKeys[i]]; j++)
			{
				SafelyRemoveStoredItem(containedItemKeys[i]);
			}
		}
		for (int k = 0; k < containedObjects.Count; k++)
		{
			SafelyRemoveStoredObject(containedObjects[k]);
		}
		for (int l = 0; l < inWorldQueueInventoryItemKeys.Count; l++)
		{
			for (int m = 0; m < inWorldQueueInventoryItems[inWorldQueueInventoryItemKeys[l]]; m++)
			{
				SafelyRemoveStoredItem(inWorldQueueInventoryItemKeys[l]);
			}
		}
		for (int n = 0; n < inWorldQueueObjects.Count; n++)
		{
			SafelyRemoveStoredObject(inWorldQueueObjects[n]);
		}
	}

	private void SafelyRemoveStoredItem(InventoryItem itemRef)
	{
		if (itemRef.itemPrefab.CompareTag(Tags.TOY) || itemRef.itemPrefab.CompareTag(Tags.SEED_PACKET) || itemRef.itemPrefab.CompareTag(Tags.DEN_UPGRADE) || itemRef.itemPrefab.CompareTag(Tags.VACUUM) || itemRef.itemPrefab.CompareTag(Tags.GIFT))
		{
			invRef.playerInventory.AddObjectToIventory(itemRef);
		}
		else if (itemRef.itemPrefab.CompareTag(Tags.EGG))
		{
			SaveableDogEgg egg = new SaveableDogEgg(null, null, fertilizedStatus: false, null, newEmptyGut: false);
			invRef.playerInventory.AddEggToInventory(egg);
			GoalsController.ReportGoalEvent(GoalCondition.COLLECT_EGG);
		}
	}

	private void SafelyRemoveStoredObject(SaveableTaggedObjectNoDepth objectRef)
	{
		if (objectRef.core != null)
		{
			invRef.playerInventory.AddDogCoreToInventory(objectRef.core);
		}
	}

	public void SpawnQueuedObjects()
	{
		if (currentSpawnItemsRoutine == null)
		{
			currentSpawnItemsRoutine = ObjectRegistration.GetRegistrationScript().StartCoroutine(SpawnQueuedObjectsRoutine());
		}
	}

	private IEnumerator SpawnQueuedObjectsRoutine()
	{
		WaitForSeconds spawnWait = new WaitForSeconds(0.05f);
		DogHome homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		for (int i = inWorldQueueInventoryItemKeys.Count - 1; i >= 0; i--)
		{
			if (isShuttingDown)
			{
				yield break;
			}
			for (int c = inWorldQueueInventoryItems[inWorldQueueInventoryItemKeys[i]] - 1; c >= 0; c--)
			{
				try
				{
					SpawnItem(inWorldQueueInventoryItemKeys[i], homeRef);
					RemoveInventoryItemFromQueue(inWorldQueueInventoryItemKeys[i], 1);
					AudioController.Play(spewItemSound, base.transform.position);
				}
				catch
				{
					Debug.LogError("Error with spawning chest item.");
				}
				yield return spawnWait;
			}
		}
		for (int i = inWorldQueueObjects.Count - 1; i >= 0; i--)
		{
			if (isShuttingDown)
			{
				yield break;
			}
			try
			{
				SpawnTaggedObject(inWorldQueueObjects[i], homeRef);
				RemoveSavedObjectFromQueue(inWorldQueueObjects[i]);
				AudioController.Play(spewItemSound, base.transform.position);
			}
			catch
			{
				Debug.LogError("Error with spawning chest object.");
			}
			yield return spawnWait;
		}
		currentSpawnItemsRoutine = null;
		if (inWorldQueueObjects.Count > 0 || inWorldQueueInventoryItemKeys.Count > 0)
		{
			SpawnQueuedObjects();
		}
	}

	private void SpawnItem(InventoryItem item, DogHome homeRef)
	{
		if (isShuttingDown)
		{
			return;
		}
		GameObject gameObject = homeRef.TrySpawnItem(item, spawnTransform.position, null, moveToGoodLocation: false);
		if (!(gameObject == null))
		{
			gameObject.transform.rotation = Random.rotation;
			BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
			if (boundingBoxComponent == null)
			{
				boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
			}
			Vector3 boxSize = boundingBoxComponent.GetBoxSize();
			gameObject.transform.position += boxSize.y * Vector3.up;
			Rigidbody componentInChildren = gameObject.GetComponentInChildren<Rigidbody>();
			componentInChildren.AddForce(expelForce * Vector3.up, ForceMode.VelocityChange);
			componentInChildren.AddRelativeTorque(expelTorque * Random.rotation.eulerAngles, ForceMode.VelocityChange);
		}
	}

	private void SpawnTaggedObject(SaveableTaggedObjectNoDepth savedObj, DogHome homeRef)
	{
		if (isShuttingDown)
		{
			return;
		}
		GameObject gameObject = regRef.LoadTaggedObject(invRef, savedObj.GetCopy(), loadComponents: true, tryLoadFullObject: false);
		if (!(gameObject == null))
		{
			gameObject.transform.position = spawnTransform.position;
			gameObject.transform.rotation = Random.rotation;
			BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
			if (boundingBoxComponent == null)
			{
				boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
			}
			Vector3 boxSize = boundingBoxComponent.GetBoxSize();
			gameObject.transform.position += boxSize.y * Vector3.up;
			Rigidbody componentInChildren = gameObject.GetComponentInChildren<Rigidbody>();
			componentInChildren.AddForce(expelForce * Vector3.up, ForceMode.VelocityChange);
			componentInChildren.AddRelativeTorque(expelTorque * Random.rotation.eulerAngles, ForceMode.VelocityChange);
		}
	}
}
