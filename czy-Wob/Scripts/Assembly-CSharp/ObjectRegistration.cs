using System.Collections.Generic;
using UnityEngine;

public class ObjectRegistration : MonoBehaviour
{
	private static ObjectRegistration registryRef;

	public const string OBJECT_REGISTRATION_TAG = "ObjectRegistration";

	private ulong IDCounter = 1000uL;

	private int numberOfTemporaryIDs = 1000;

	private List<ulong> availableTemporaryIDs;

	public SaveLoadManager saveLoadManager;

	public GameObject objectIndicatorPrefab;

	private bool isShuttingDown;

	private bool shouldLoadPenData;

	private bool loadingFromMainMenu;

	private Dictionary<ulong, GameObject> UIDObjectCache = new Dictionary<ulong, GameObject>();

	private Dictionary<ulong, GameObject> UIDPlaceableObjectCache = new Dictionary<ulong, GameObject>();

	private Dictionary<TagsEnum, List<ulong>> registeredTagsObjects = new Dictionary<TagsEnum, List<ulong>>();

	private Dictionary<TagsEnum, List<ulong>> registeredPlaceableTagsObjects = new Dictionary<TagsEnum, List<ulong>>();

	private Dictionary<GlobalObject, GameObject> registeredGlobalObjects = new Dictionary<GlobalObject, GameObject>();

	private ulong reservableObjectIDCounter;

	private Dictionary<ulong, ReservableObject> UIDReservableObjectCache = new Dictionary<ulong, ReservableObject>();

	private Dictionary<ReservableObjectType, List<ulong>> registeredReservableObjects = new Dictionary<ReservableObjectType, List<ulong>>();

	public static ObjectRegistration GetRegistrationScript()
	{
		return registryRef;
	}

	private void Awake()
	{
		foreach (TagsEnum value in EnumUtils.GetValues<TagsEnum>())
		{
			if (value != TagsEnum.ALL)
			{
				registeredTagsObjects[value] = new List<ulong>();
				registeredPlaceableTagsObjects[value] = new List<ulong>();
			}
		}
		availableTemporaryIDs = new List<ulong>();
		for (int i = 0; i < numberOfTemporaryIDs; i++)
		{
			availableTemporaryIDs.Add((ulong)i);
		}
	}

	private void OnApplicationQuit()
	{
		isShuttingDown = true;
	}

	public void PrepareForTravel()
	{
		for (int i = 0; i < registeredPlaceableTagsObjects[TagsEnum.HOLE].Count; i++)
		{
			GameObject placeableObjectForUID = GetPlaceableObjectForUID(registeredPlaceableTagsObjects[TagsEnum.HOLE][i]);
			if (placeableObjectForUID != null)
			{
				placeableObjectForUID.GetComponent<Hole>().MarkForTravel();
			}
		}
		for (int j = 0; j < registeredPlaceableTagsObjects[TagsEnum.STORAGE_CHEST].Count; j++)
		{
			GameObject placeableObjectForUID2 = GetPlaceableObjectForUID(registeredPlaceableTagsObjects[TagsEnum.STORAGE_CHEST][j]);
			if (placeableObjectForUID2 != null)
			{
				placeableObjectForUID2.GetComponent<StorageChest>().MarkForTravel();
			}
		}
	}

	public SaveableTaggedObjects GetSavedTaggedObjects()
	{
		InventoryManager globalComponent = GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		SaveableTaggedObjects saveableTaggedObjects = new SaveableTaggedObjects();
		foreach (TagsEnum value in EnumUtils.GetValues<TagsEnum>())
		{
			if (value == TagsEnum.DOG || !registeredTagsObjects.ContainsKey(value))
			{
				continue;
			}
			for (int i = 0; i < registeredTagsObjects[value].Count; i++)
			{
				GameObject gameObject = UIDObjectCache[registeredTagsObjects[value][i]];
				if (gameObject.GetComponent<ObjectID>() == null)
				{
					continue;
				}
				SaveableTaggedObject saveableTaggedObject = (SaveableTaggedObject)GetSaveableTaggedObjectForObject(globalComponent, gameObject);
				if (saveableTaggedObject != null)
				{
					if (value == TagsEnum.COCOON)
					{
						saveableTaggedObjects.cocoons.Add(saveableTaggedObject);
					}
					else
					{
						saveableTaggedObjects.objects.Add(saveableTaggedObject);
					}
				}
			}
		}
		return saveableTaggedObjects;
	}

	public SaveableTaggedObjectNoDepth GetSaveableTaggedObjectForObject(InventoryManager invRef, GameObject obj, bool saveGameObjectInfo = true)
	{
		SaveableTaggedObject sa = new SaveableTaggedObject();
		string itemName = obj.name;
		ObjectID component = obj.GetComponent<ObjectID>();
		InventoryItem inventoryItem = component.item;
		bool flag = ObjectConnectionsManager.IsObjectConsumedByAnyGhost(obj);
		RegisterTaggedObject component2 = obj.GetComponent<RegisterTaggedObject>();
		if (!component2.canSaveLoad)
		{
			return null;
		}
		InventoryItem inventoryItem2 = null;
		if (component2 != null && (bool)component2.saveAsAlternativeItem)
		{
			inventoryItem = component2.saveAsAlternativeItem;
			itemName = inventoryItem.itemName;
			inventoryItem2 = inventoryItem;
		}
		sa.savedName = itemName;
		sa.objID = component.GetUID();
		sa.itemPath = invRef.GetPathForItem(inventoryItem);
		SaveComponents(obj, ref sa);
		if (saveGameObjectInfo)
		{
			if (flag && inventoryItem2 == null)
			{
				ulong iD = ObjectConnectionsManager.consumedObjectToDogMap[sa.objID];
				GameObject dogFromID = GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDogFromID(iD);
				sa.gameObject = dogFromID.GetComponent<GhostEatBehavior>().GetSaveableEatenObject(obj);
			}
			else
			{
				sa.gameObject = new SerializableGameObject(obj, inventoryItem2);
			}
			if (inventoryItem2 != null)
			{
				sa.gameObject.transform.position = new SerializableVector3(obj.GetComponent<BoundingBoxComponent>().GetBoxCenter());
				sa.gameObject.transform.localScale = new SerializableVector3(inventoryItem2.itemPrefab.transform.localScale);
				sa.gameObject.transform.rotation = new SerializableQuaternion(Quaternion.identity);
			}
		}
		else
		{
			sa.objectScale = new SerializableVector3(obj.transform.localScale);
		}
		return sa;
	}

	public void SaveComponents(GameObject obj, ref SaveableTaggedObject sa)
	{
		Eatable component = obj.GetComponent<Eatable>();
		if (component != null)
		{
			sa.eatable = new SaveableEatable(component);
		}
		PlantController component2 = obj.GetComponent<PlantController>();
		if (component2 != null)
		{
			sa.plant = new SaveablePlant(component2);
		}
		Cocoon component3 = obj.GetComponent<Cocoon>();
		if (component3 != null)
		{
			sa.cocoon = new SaveableCocoon(component3);
		}
		Pill component4 = obj.GetComponent<Pill>();
		if (component4 != null)
		{
			sa.pill = new SaveablePill(component4);
		}
		DogCore component5 = obj.GetComponent<DogCore>();
		if (component5 != null)
		{
			sa.core = new SaveableDogCore(component5);
		}
		CrackedDogCore component6 = obj.GetComponent<CrackedDogCore>();
		if (component6 != null)
		{
			sa.crackedCore = new SaveableCrackedCore(component6);
		}
		DogEgg component7 = obj.GetComponent<DogEgg>();
		if (component7 != null && component7.fertilized)
		{
			sa.fertilizedEgg = new SaveableFertilizedDogEgg(component7);
		}
	}

	public void LoadComponents(GameObject obj, SaveableTaggedObjectNoDepth sa)
	{
		Eatable component = obj.GetComponent<Eatable>();
		if (component != null)
		{
			sa.eatable.Load(component);
		}
		PlantController component2 = obj.GetComponent<PlantController>();
		if (component2 != null)
		{
			sa.plant.Load(component2);
		}
		Cocoon component3 = obj.GetComponent<Cocoon>();
		if (component3 != null)
		{
			sa.cocoon.Load(component3);
		}
		Pill component4 = obj.GetComponent<Pill>();
		if (component4 != null)
		{
			sa.pill.Load(component4);
		}
		DogCore component5 = obj.GetComponent<DogCore>();
		if (component5 != null)
		{
			sa.core.Load(component5);
		}
		CrackedDogCore component6 = obj.GetComponent<CrackedDogCore>();
		if (component6 != null)
		{
			sa.crackedCore.Load(component6);
		}
		DogEgg component7 = obj.GetComponent<DogEgg>();
		if (component7 != null && sa.fertilizedEgg != null)
		{
			sa.fertilizedEgg.Load(component7);
		}
	}

	public void SaveIDCounter(PlayerData data)
	{
		data.IDCounter = IDCounter;
	}

	public void LoadIDCounter(PlayerData data)
	{
		if (data != null)
		{
			IDCounter = data.IDCounter;
			if (IDCounter < (ulong)numberOfTemporaryIDs)
			{
				IDCounter = (ulong)numberOfTemporaryIDs;
			}
		}
	}

	public ulong GetNewIDForBrokenDog()
	{
		ulong iDCounter = IDCounter;
		IDCounter++;
		return iDCounter;
	}

	public void LoadTaggedObjects(SaveableTaggedObjects objs)
	{
		if (objs == null)
		{
			return;
		}
		InventoryManager globalComponent = GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		for (int i = 0; i < objs.objects.Count; i++)
		{
			if (objs.objects[i] != null)
			{
				LoadTaggedObject(globalComponent, objs.objects[i].GetCopy());
			}
		}
	}

	public void LoadCocoons(SaveableTaggedObjects objs)
	{
		if (objs == null || objs.cocoons == null)
		{
			return;
		}
		InventoryManager globalComponent = GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		List<SaveableTaggedObject> list = new List<SaveableTaggedObject>();
		for (int i = 0; i < objs.cocoons.Count; i++)
		{
			if (objs.cocoons[i] != null)
			{
				list.Add(objs.cocoons[i].GetCopy());
			}
		}
		bool flag = true;
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j].cocoon != null && IsIDTemporary(list[j].cocoon.associatedDogID))
			{
				flag = false;
			}
			else
			{
				LoadTaggedObject(globalComponent, list[j], loadComponents: false);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			if (list[k].cocoon != null && IsIDTemporary(list[k].cocoon.associatedDogID))
			{
				flag = false;
			}
			else
			{
				LoadComponents(GetObjectForUID(list[k].objID), list[k]);
			}
		}
		DogRegistration globalComponent2 = GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		List<SaveableDog> allOwnedDogs = globalComponent2.GetAllOwnedDogs();
		for (int l = 0; l < allOwnedDogs.Count; l++)
		{
			if (!allOwnedDogs[l].inWorld || !allOwnedDogs[l].inCocoon)
			{
				continue;
			}
			if (!flag && globalComponent2.GetDogFromID(allOwnedDogs[l].dogID) == null)
			{
				globalComponent2.RemoveUnlinkedCocoon(allOwnedDogs[l].dogID);
				continue;
			}
			bool flag2 = false;
			for (int m = 0; m < list.Count; m++)
			{
				if (list[m].cocoon.associatedDogID == allOwnedDogs[l].dogID)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				globalComponent2.RemoveUnlinkedCocoon(allOwnedDogs[l].dogID);
				Debug.LogError("Dog: " + allOwnedDogs[l].dogID + " was saved as being inside of a cocoon but no associated cocoon was found. Moving to storage.");
			}
		}
		int num = globalComponent2.GetAllInWorldOwnedDogs().Count + list.Count - globalComponent2.GetMaxDogs();
		if (!(num > 0 && flag))
		{
			return;
		}
		Debug.LogError("Game was saved with too many dogs out. Removing cocoons to compensate.");
		int num2 = list.Count - 1;
		while (num2 >= 0)
		{
			GameObject objectForUID = GetObjectForUID(list[num2].objID);
			if (objectForUID != null)
			{
				Object.Destroy(objectForUID);
			}
			num--;
			if (num > 0)
			{
				num2--;
				continue;
			}
			break;
		}
	}

	public GameObject LoadTaggedObject(InventoryManager invRef, SaveableTaggedObjectNoDepth obj, bool loadComponents = true, bool tryLoadFullObject = true)
	{
		InventoryItem itemForPath = invRef.GetItemForPath(obj.itemPath);
		if (itemForPath == null)
		{
			Debug.LogError("No valid matching Inventory Item found for: " + obj.itemPath);
			return null;
		}
		GameObject gameObject = Object.Instantiate(itemForPath.itemPrefab);
		if (tryLoadFullObject && ((SaveableTaggedObject)obj).gameObject != null)
		{
			((SaveableTaggedObject)obj).gameObject.Load(gameObject);
		}
		else
		{
			gameObject.transform.localScale = obj.objectScale.Load();
		}
		ObjectID objectID = gameObject.AddComponent<ObjectID>();
		objectID.SetUID(obj.objID);
		objectID.item = itemForPath;
		gameObject.name = obj.savedName;
		if (loadComponents)
		{
			LoadComponents(gameObject, obj);
		}
		return gameObject;
	}

	public void StoreRegistryRef()
	{
		registryRef = this;
	}

	public void InitializeSaveLoadManager()
	{
		saveLoadManager = new SaveLoadManager();
		saveLoadManager.InitializeLoadedControls();
	}

	public void LoadData(bool loadPenData, bool fromMainMenu)
	{
		shouldLoadPenData = loadPenData;
		loadingFromMainMenu = fromMainMenu;
		saveLoadManager.LoadData(DataLoadedCallback, fromMainMenu);
	}

	private void DataLoadedCallback(bool result)
	{
		if (loadingFromMainMenu)
		{
			GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION).OnAllDogsLoaded(loadingFromMainMenu);
		}
		else
		{
			saveLoadManager.LoadNonDependentData(shouldLoadPenData);
		}
	}

	public void RegisterTaggedObject(GameObject objectRef, TagsEnum tagType)
	{
		AddRegisteredComponents(objectRef);
		ObjectID component = objectRef.GetComponent<ObjectID>();
		if (!(component == null))
		{
			ulong uID = component.GetUID();
			registeredTagsObjects[tagType].Add(uID);
		}
	}

	public void RegisterPlaceableObject(GameObject objectRef, TagsEnum tagType)
	{
		AddRegisteredComponents(objectRef, placeableObject: true);
		ulong uID = objectRef.GetComponent<PlacedObjectID>().GetUID();
		if (UIDPlaceableObjectCache.ContainsKey(uID))
		{
			Debug.LogError("Attempting to double-register UID: " + uID);
			Debug.LogError("Object already registered: " + UIDPlaceableObjectCache[uID]);
			Debug.LogError("New object: " + objectRef);
			Object.Destroy(UIDPlaceableObjectCache[uID]);
		}
		UIDPlaceableObjectCache[uID] = objectRef;
		registeredPlaceableTagsObjects[tagType].Add(uID);
	}

	public void AssignID(GameObject obj, InventoryItem itemType, bool useTemporaryID = false)
	{
		ObjectID objectID = obj.AddComponent<ObjectID>();
		objectID.item = itemType;
		if (!useTemporaryID || availableTemporaryIDs.Count == 0)
		{
			objectID.SetUID(IDCounter);
			IDCounter++;
		}
		else
		{
			objectID.SetUID(availableTemporaryIDs[0]);
			availableTemporaryIDs.RemoveAt(0);
		}
	}

	public void RegisterID(ulong UID, GameObject obj)
	{
		UIDObjectCache[UID] = obj;
	}

	public void UnregisterID(ulong UID)
	{
		UIDObjectCache.Remove(UID);
		if (IsIDTemporary(UID))
		{
			availableTemporaryIDs.Add(UID);
		}
	}

	public bool IsIDTemporary(ulong UID)
	{
		if ((int)UID < numberOfTemporaryIDs)
		{
			return true;
		}
		return false;
	}

	public GameObject GetPlaceableObjectForUID(ulong UID)
	{
		if (!UIDPlaceableObjectCache.ContainsKey(UID))
		{
			return null;
		}
		return UIDPlaceableObjectCache[UID];
	}

	public GameObject GetObjectForUID(ulong UID)
	{
		if (!UIDObjectCache.ContainsKey(UID))
		{
			return null;
		}
		return UIDObjectCache[UID];
	}

	public ulong GetUIDForObject(GameObject obj)
	{
		return obj.GetComponent<ObjectID>().GetUID();
	}

	public static void AddRegisteredComponents(GameObject obj, bool placeableObject = false)
	{
		if (obj.GetComponent<OOBDestroy>() == null)
		{
			obj.AddComponent<OOBDestroy>();
		}
		if (obj.CompareTag(Tags.DOG))
		{
			obj.AddComponent<GravboostDog>();
			AddComponentToAllRigidbodiesDog<UnbouncableDog>(obj);
			obj.AddComponent<DustBurstController>();
			obj.AddComponent<ObjectIndicatorController>();
			AddComponentToAllRigidbodiesDog<DustBurst>(obj);
			AddComponentToAllRigidbodies<CollisionSound>(obj);
			return;
		}
		InteractableBase component = obj.GetComponent<InteractableBase>();
		if (!(component == null))
		{
			if (component.applyRegisteredComponentsToChildren)
			{
				AddComponentToAllRigidbodies<Gravboost>(obj);
				AddComponentToAllRigidbodies<Unbouncable>(obj);
				AddComponentToAllRigidbodies<CollisionSound>(obj);
				obj.AddComponent<DustBurstController>();
				AddComponentToAllRigidbodies<DustBurst>(obj);
			}
			component.OnRegisteredComponentsAdded();
			if (!placeableObject && obj.GetComponent<ObjectIndicatorController>() == null)
			{
				obj.AddComponent<ObjectIndicatorController>();
			}
		}
	}

	private static void AddComponentToAllRigidbodies<T>(GameObject obj) where T : Component
	{
		if (obj.GetComponent<Rigidbody>() != null && !obj.GetComponent<T>())
		{
			obj.AddComponent<T>();
		}
		Rigidbody[] componentsInChildren = obj.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (rigidbody.gameObject.GetComponent<T>() == null)
			{
				rigidbody.gameObject.AddComponent<T>();
			}
		}
	}

	private static void AddComponentToAllRigidbodiesDog<T>(GameObject obj) where T : Component
	{
		LegController component = obj.GetComponent<LegController>();
		if (component.bodyBack.GetComponent<T>() == null)
		{
			component.bodyBack.AddComponent<T>();
		}
		if (component.bodyFront.GetComponent<T>() == null)
		{
			component.bodyFront.AddComponent<T>();
		}
		List<GameObject> allLegs = component.GetAllLegs();
		for (int i = 0; i < allLegs.Count; i++)
		{
			for (int j = 0; j < allLegs[i].transform.parent.childCount; j++)
			{
				if (allLegs[i].transform.parent.GetChild(j).gameObject.GetComponent<T>() == null)
				{
					allLegs[i].transform.parent.GetChild(j).gameObject.AddComponent<T>();
				}
			}
		}
	}

	public void UnregisterTaggedObject(GameObject objectRef, TagsEnum tagType)
	{
		ObjectID component = objectRef.GetComponent<ObjectID>();
		if (!(component == null))
		{
			ulong uID = component.GetUID();
			registeredTagsObjects[tagType].Remove(uID);
		}
	}

	public void UnregisterPlaceableObject(GameObject objectRef, TagsEnum tagType)
	{
		PlacedObjectID component = objectRef.GetComponent<PlacedObjectID>();
		if (!(component == null))
		{
			ulong uID = component.GetUID();
			UIDPlaceableObjectCache.Remove(uID);
			registeredPlaceableTagsObjects[tagType].Remove(uID);
		}
	}

	public bool DoObjectsExistForTag(TagsEnum tag)
	{
		if ((registeredTagsObjects.ContainsKey(tag) && registeredTagsObjects[tag].Count > 0) || (registeredPlaceableTagsObjects.ContainsKey(tag) && registeredPlaceableTagsObjects[tag].Count > 0))
		{
			return true;
		}
		return false;
	}

	public bool DoFreeObjectsExistForTag(TagsEnum tag, ulong existingDogUID)
	{
		if (!DoObjectsExistForTag(tag))
		{
			return false;
		}
		if (registeredTagsObjects.ContainsKey(tag))
		{
			for (int i = 0; i < registeredTagsObjects[tag].Count; i++)
			{
				if (!GetObjectForUID(registeredTagsObjects[tag][i]).GetComponent<InteractableBase>().IsObjectInUseByAnotherDog(existingDogUID))
				{
					return true;
				}
			}
		}
		if (registeredPlaceableTagsObjects.ContainsKey(tag))
		{
			for (int j = 0; j < registeredPlaceableTagsObjects[tag].Count; j++)
			{
				if (!GetPlaceableObjectForUID(registeredPlaceableTagsObjects[tag][j]).GetComponent<InteractableBase>().IsObjectInUseByAnotherDog(existingDogUID))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool DoObjectsExistForTags(List<TagsEnum> tagsList)
	{
		for (int i = 0; i < tagsList.Count; i++)
		{
			if (!DoObjectsExistForTag(tagsList[i]))
			{
				return false;
			}
		}
		return true;
	}

	public List<GameObject> GetAllObjectsForTag(TagsEnum tagType)
	{
		List<GameObject> list = new List<GameObject>();
		if (isShuttingDown)
		{
			return list;
		}
		if (tagType == TagsEnum.ALL)
		{
			foreach (TagsEnum key in registeredTagsObjects.Keys)
			{
				for (int i = 0; i < registeredTagsObjects[key].Count; i++)
				{
					list.Add(UIDObjectCache[registeredTagsObjects[key][i]]);
				}
			}
			foreach (TagsEnum key2 in registeredPlaceableTagsObjects.Keys)
			{
				for (int j = 0; j < registeredPlaceableTagsObjects[key2].Count; j++)
				{
					list.Add(UIDPlaceableObjectCache[registeredPlaceableTagsObjects[key2][j]]);
				}
			}
		}
		else
		{
			for (int k = 0; k < registeredTagsObjects[tagType].Count; k++)
			{
				list.Add(UIDObjectCache[registeredTagsObjects[tagType][k]]);
			}
			for (int l = 0; l < registeredPlaceableTagsObjects[tagType].Count; l++)
			{
				list.Add(UIDPlaceableObjectCache[registeredPlaceableTagsObjects[tagType][l]]);
			}
		}
		return list;
	}

	public void RegisterGlobalObject(GameObject objectRef, GlobalObject objectType)
	{
		registeredGlobalObjects[objectType] = objectRef;
	}

	public GameObject GetGlobalObject(GlobalObject objectType, bool nullAllowed = false)
	{
		return GetGlobalObjectForType(objectType, nullAllowed);
	}

	public T GetGlobalComponent<T>(GlobalObject objectType, bool nullAllowed = false)
	{
		GameObject globalObjectForType = GetGlobalObjectForType(objectType, nullAllowed);
		if (globalObjectForType == null)
		{
			return default(T);
		}
		return globalObjectForType.GetComponent<T>();
	}

	private GameObject GetGlobalObjectForType(GlobalObject objectType, bool nullAllowed)
	{
		if (!registeredGlobalObjects.ContainsKey(objectType))
		{
			if (!nullAllowed)
			{
				Debug.LogError("No registered object for type: " + objectType);
			}
			return null;
		}
		return registeredGlobalObjects[objectType];
	}

	public void RegisterReservableObject(ReservableObject obj)
	{
		ulong num = reservableObjectIDCounter;
		obj.SetUID(num);
		reservableObjectIDCounter++;
		UIDReservableObjectCache[num] = obj;
		if (!registeredReservableObjects.ContainsKey(obj.objectType))
		{
			registeredReservableObjects[obj.objectType] = new List<ulong>();
		}
		registeredReservableObjects[obj.objectType].Add(num);
	}

	public void UnregisterReservableObject(ReservableObject obj)
	{
		UIDReservableObjectCache.Remove(obj.GetUID());
		registeredReservableObjects[obj.objectType].Remove(obj.GetUID());
	}

	public bool DoReservableObjectsExistForType(ReservableObjectType wantedType)
	{
		if (!registeredReservableObjects.ContainsKey(wantedType) || registeredReservableObjects[wantedType].Count == 0)
		{
			return false;
		}
		return true;
	}

	public List<ReservableObject> GetAllReservableObjectsOfType(ReservableObjectType wantedType)
	{
		List<ReservableObject> list = new List<ReservableObject>();
		for (int i = 0; i < registeredReservableObjects[wantedType].Count; i++)
		{
			list.Add(UIDReservableObjectCache[registeredReservableObjects[wantedType][i]]);
		}
		return list;
	}
}
