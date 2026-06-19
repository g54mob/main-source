using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
	private List<ulong> ownedDogIDs = new List<ulong>();

	private Dictionary<ulong, SaveableDog> dogByIDDict = new Dictionary<ulong, SaveableDog>();

	private List<ulong> ownedGhostIDs = new List<ulong>();

	private Dictionary<ulong, SaveableDog> ghostByIDDict = new Dictionary<ulong, SaveableDog>();

	private List<InventoryItem> newItems = new List<InventoryItem>();

	private Dictionary<InventoryItem, int> heldItems = new Dictionary<InventoryItem, int>();

	private Dictionary<ItemType, Dictionary<InventoryItem, int>> heldItemsByType = new Dictionary<ItemType, Dictionary<InventoryItem, int>>();

	private List<SaveableDogEgg> heldEggs = new List<SaveableDogEgg>();

	private List<SaveableDogCore> heldDogCores = new List<SaveableDogCore>();

	private Dictionary<string, bool> foodUnlockStatus = new Dictionary<string, bool>();

	private string toyStoreSound = "toybox_store";

	private DogRegistration dogRegRef;

	private InventoryManager managerRef;

	private GUIManagerPens guiManagerRef;

	public PlayerInventory()
	{
		InitInventory();
	}

	public InventoryManager GetManagerRef()
	{
		return managerRef;
	}

	public void SetManagerRef(InventoryManager newRef)
	{
		managerRef = newRef;
	}

	public SaveableInventory GetSavedInventory()
	{
		SaveableInventory saveableInventory = new SaveableInventory();
		List<InventoryItem> list = new List<InventoryItem>(heldItems.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			SaveableInventoryItem saveableInventoryItem = new SaveableInventoryItem();
			saveableInventoryItem.numHeld = heldItems[list[i]];
			saveableInventoryItem.itemPath = managerRef.GetPathForItem(list[i]);
			saveableInventory.heldItems.Add(saveableInventoryItem);
		}
		for (int j = 0; j < newItems.Count; j++)
		{
			SaveableInventoryItem saveableInventoryItem2 = new SaveableInventoryItem();
			saveableInventoryItem2.itemPath = managerRef.GetPathForItem(newItems[j]);
			saveableInventory.newItems.Add(saveableInventoryItem2);
		}
		saveableInventory.heldDogCores.AddRange(heldDogCores);
		saveableInventory.heldEggs.AddRange(heldEggs);
		List<string> list2 = new List<string>(foodUnlockStatus.Keys);
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		for (int k = 0; k < list2.Count; k++)
		{
			dictionary[list2[k]] = foodUnlockStatus[list2[k]];
		}
		saveableInventory.foodUnlockStatus = new SerializableDictionary<string, bool>(dictionary);
		return saveableInventory;
	}

	public void LoadSavedInventory(SaveableInventory savedInventory)
	{
		if (savedInventory == null)
		{
			Clear();
			return;
		}
		SaveableInventory copy = savedInventory.GetCopy();
		Clear();
		for (int i = 0; i < copy.heldItems.Count; i++)
		{
			AddObjectToIventory(managerRef.GetItemForPath(copy.heldItems[i].itemPath), copy.heldItems[i].numHeld, playSounds: false);
		}
		if (copy.heldDogCores != null)
		{
			for (int j = 0; j < copy.heldDogCores.Count; j++)
			{
				AddDogCoreToInventory(copy.heldDogCores[j], fromLoad: true);
			}
		}
		if (copy.heldEggs != null)
		{
			for (int k = 0; k < copy.heldEggs.Count; k++)
			{
				AddEggToInventory(copy.heldEggs[k], fromLoad: true);
			}
		}
		if (copy.newItems != null)
		{
			for (int l = 0; l < copy.newItems.Count; l++)
			{
				newItems.Add(managerRef.GetItemForPath(copy.newItems[l].itemPath));
			}
		}
		if (copy.foodUnlockStatus != null)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			copy.foodUnlockStatus.Load(dictionary);
			List<string> keys = copy.foodUnlockStatus.keys;
			for (int m = 0; m < keys.Count; m++)
			{
				foodUnlockStatus[keys[m]] = dictionary[keys[m]];
			}
		}
	}

	public void UnlockFood(InventoryItem foodToUnlock)
	{
		foodUnlockStatus[managerRef.GetPathForItem(foodToUnlock)] = true;
	}

	public bool GetUnlockStatusForFood(InventoryItem food)
	{
		return foodUnlockStatus[managerRef.GetPathForItem(food)];
	}

	private void InitFoodUnlocks()
	{
		foodUnlockStatus.Clear();
		List<InventoryItem> allItemsOfType = managerRef.GetAllItemsOfType(ItemType.FOOD);
		for (int i = 0; i < allItemsOfType.Count; i++)
		{
			foodUnlockStatus[managerRef.GetPathForItem(allItemsOfType[i])] = allItemsOfType[i].startUnlocked;
		}
	}

	public void InitInventory()
	{
		heldItems.Clear();
		foreach (ItemType value in EnumUtils.GetValues<ItemType>())
		{
			heldItemsByType[value] = new Dictionary<InventoryItem, int>();
		}
	}

	public void MarkItemAsNew(InventoryItem itemRef)
	{
		if (!newItems.Contains(itemRef))
		{
			newItems.Add(itemRef);
			guiManagerRef.OnNewObjectAddedToInventory();
		}
	}

	public bool DoesInventoryHaveNewItems()
	{
		return newItems.Count > 0;
	}

	public bool IsSpecificItemNew(InventoryItem itemRef)
	{
		return newItems.Contains(itemRef);
	}

	public List<InventoryItem> GetAllNewItems()
	{
		List<InventoryItem> list = new List<InventoryItem>();
		list.AddRange(newItems);
		return list;
	}

	public void ClearNewItems()
	{
		newItems.Clear();
	}

	public void AddObjectToIventory(InventoryItem objectToAdd, int num = 1, bool playSounds = true)
	{
		if (num <= 0)
		{
			Debug.LogError("Invalid number of objects (" + num + ") specified for AddObjectToIventory.");
		}
		else
		{
			if (objectToAdd == null || !heldItemsByType.ContainsKey(objectToAdd.type))
			{
				return;
			}
			if (!heldItemsByType[objectToAdd.type].ContainsKey(objectToAdd))
			{
				heldItems[objectToAdd] = 0;
				heldItemsByType[objectToAdd.type][objectToAdd] = 0;
			}
			heldItems[objectToAdd] += num;
			heldItemsByType[objectToAdd.type][objectToAdd] += num;
			if (!playSounds || objectToAdd.type != ItemType.TOY)
			{
				return;
			}
			if (guiManagerRef == null)
			{
				guiManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
				if (guiManagerRef == null)
				{
					return;
				}
			}
			AudioController.Play(toyStoreSound);
			guiManagerRef.OnObjectAddedToInventory(objectToAdd);
		}
	}

	public void RemoveObjectFromInventory(InventoryItem objectToRemove, int num = 1)
	{
		if (num <= 0)
		{
			Debug.LogError("Invalid number of objects (" + num + ") specified for RemoveObjectFromInventory.");
			return;
		}
		if (!heldItemsByType[objectToRemove.type].ContainsKey(objectToRemove))
		{
			Debug.LogError(string.Concat("Attempting to remove an object: ", objectToRemove, " from the inventory but the player doesn't have any."));
			return;
		}
		if (heldItems[objectToRemove] - num < 0)
		{
			Debug.LogError(string.Concat("Attempting to remove more objects of type: ", objectToRemove, " from our inventory than we currently own."));
		}
		heldItems[objectToRemove]--;
		heldItemsByType[objectToRemove.type][objectToRemove]--;
		if (heldItemsByType[objectToRemove.type][objectToRemove] == 0)
		{
			heldItems.Remove(objectToRemove);
			heldItemsByType[objectToRemove.type].Remove(objectToRemove);
		}
	}

	public SaveableDogCore GetFirstSavedDogCore()
	{
		return heldDogCores[0];
	}

	public List<SaveableDogCore> GetHeldDogCores()
	{
		List<SaveableDogCore> list = new List<SaveableDogCore>();
		list.AddRange(heldDogCores);
		return list;
	}

	public int GetNumberOfHeldDogCores()
	{
		return heldDogCores.Count;
	}

	public List<SaveableDogEgg> GetHeldEggs(bool fertilized)
	{
		List<SaveableDogEgg> list = new List<SaveableDogEgg>();
		for (int i = 0; i < heldEggs.Count; i++)
		{
			if (heldEggs[i].fertilized == fertilized)
			{
				list.Add(heldEggs[i]);
			}
		}
		return list;
	}

	public int GetNumberOfHeldEggs(bool fertilized)
	{
		int num = 0;
		for (int i = 0; i < heldEggs.Count; i++)
		{
			if (heldEggs[i].fertilized == fertilized)
			{
				num++;
			}
		}
		return num;
	}

	public Dictionary<InventoryItem, int> GetHeldItemsOfType(ItemType type)
	{
		return heldItemsByType[type];
	}

	public int GetNumberOfItemHeld(InventoryItem item)
	{
		if (!heldItems.ContainsKey(item))
		{
			return 0;
		}
		return heldItems[item];
	}

	public void AddDogCoreToInventory(SaveableDogCore core, bool fromLoad = false)
	{
		if (core != null)
		{
			heldDogCores.Add(core);
			if (fromLoad)
			{
				MasterDogGene.MigrateSaveableDogGene(core.dogGene);
			}
			if (core.thumbSet == null || core.thumbSet.defaultPortrait == null)
			{
				core.CacheThumbnail();
			}
			if (!fromLoad && guiManagerRef == null)
			{
				guiManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
				_ = guiManagerRef == null;
			}
		}
	}

	public void RemoveDogCoreFromInventory(SaveableDogCore core)
	{
		if (!heldDogCores.Contains(core))
		{
			Debug.LogError("Attempting to remove a dog core from our inventory but it doesn't look like it exists.");
			return;
		}
		int index = heldDogCores.IndexOf(core);
		heldDogCores.RemoveAt(index);
	}

	public void AddEggToInventory(SaveableDogEgg egg, bool fromLoad = false)
	{
		if (egg != null)
		{
			heldEggs.Add(egg);
			if (fromLoad && egg.fertilized)
			{
				MasterDogGene.MigrateSaveableDogGene(egg.associatedGene);
			}
		}
	}

	public void RemoveUnfertilizedEggFromInventory()
	{
		for (int i = 0; i < heldEggs.Count; i++)
		{
			if (!heldEggs[i].fertilized)
			{
				heldEggs.RemoveAt(i);
				return;
			}
		}
		Debug.LogError("No unfertilized egg found, so removal could not occur.");
	}

	public void RemoveEggFromInventory(SaveableDogEgg eggToRemove)
	{
		if (!heldEggs.Contains(eggToRemove))
		{
			Debug.LogError(string.Concat("Attempting to remove an egg: ", eggToRemove, " from the inventory but the player doesn't own it."));
		}
		else
		{
			heldEggs.Remove(eggToRemove);
		}
	}

	public void Clear()
	{
		InitInventory();
		newItems.Clear();
		heldEggs.Clear();
		ownedDogIDs.Clear();
		dogByIDDict.Clear();
		heldDogCores.Clear();
		ownedGhostIDs.Clear();
		ghostByIDDict.Clear();
		foodUnlockStatus.Clear();
		InitFoodUnlocks();
	}

	public List<SaveableDog> GetOwnedDogs()
	{
		List<SaveableDog> list = new List<SaveableDog>();
		for (int i = 0; i < ownedDogIDs.Count; i++)
		{
			list.Add(dogByIDDict[ownedDogIDs[i]].GetCopy());
		}
		return list;
	}

	public SaveableDog GetSaveableDogByID(ulong dogID)
	{
		if (!dogByIDDict.ContainsKey(dogID))
		{
			if (ghostByIDDict.ContainsKey(dogID))
			{
				return ghostByIDDict[dogID];
			}
			return null;
		}
		return dogByIDDict[dogID];
	}

	public List<GameObject> GetAllInWorldOwnedDogs(bool includeGhosts = true)
	{
		if (dogRegRef == null)
		{
			dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < ownedDogIDs.Count; i++)
		{
			if (dogByIDDict[ownedDogIDs[i]].inWorld)
			{
				GameObject dogFromID = dogRegRef.GetDogFromID(ownedDogIDs[i]);
				if (dogFromID != null)
				{
					list.Add(dogFromID);
				}
			}
		}
		if (includeGhosts)
		{
			for (int j = 0; j < ownedGhostIDs.Count; j++)
			{
				GameObject dogFromID2 = dogRegRef.GetDogFromID(ownedGhostIDs[j]);
				if (dogFromID2 != null)
				{
					list.Add(dogFromID2);
				}
			}
		}
		return list;
	}

	public void OnOwnedDogStored(SaveableDog storedDog)
	{
		if (ownedGhostIDs.Contains(storedDog.dogID))
		{
			Debug.LogError("Attempting to store a ghost!");
		}
		else if (!ownedDogIDs.Contains(storedDog.dogID))
		{
			Debug.LogError("Attempting to store an owned dog: " + storedDog.dogID + " but it is not in our list of owned dogs.");
		}
		else
		{
			ownedDogIDs.Remove(storedDog.dogID);
		}
		ownedDogIDs.Insert(0, storedDog.dogID);
	}

	public void AddOwnedDog(SaveableDog newDog)
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		if (registrationScript.IsIDTemporary(newDog.dogID) && !newDog.isGhost)
		{
			SceneManagerBase globalComponent = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER, nullAllowed: true);
			if (!(globalComponent != null) || globalComponent.GetGameMode() != GameMode.BREEDING)
			{
				Debug.LogError("Attempting to add a dog with a temporary ID to the player's inventory.");
				return;
			}
		}
		if (newDog.isGhost)
		{
			if (!ghostByIDDict.ContainsKey(newDog.dogID))
			{
				ownedGhostIDs.Insert(0, newDog.dogID);
				ghostByIDDict[newDog.dogID] = newDog;
			}
		}
		else if (!dogByIDDict.ContainsKey(newDog.dogID))
		{
			ownedDogIDs.Insert(0, newDog.dogID);
			dogByIDDict[newDog.dogID] = newDog;
		}
	}

	public void RemoveOwnedDog(SaveableDog dogToRemove)
	{
		if (dogToRemove.isGhost)
		{
			if (!ghostByIDDict.ContainsKey(dogToRemove.dogID))
			{
				Debug.LogError("Attempting to remove owned ghost: " + dogToRemove.dogID + " but it is not in the player's inventory.");
				return;
			}
			ownedGhostIDs.Remove(dogToRemove.dogID);
			ghostByIDDict.Remove(dogToRemove.dogID);
		}
		else if (!dogByIDDict.ContainsKey(dogToRemove.dogID))
		{
			Debug.LogError("Attempting to remove owned dog: " + dogToRemove.dogID + " but it is not in the player's inventory.");
		}
		else
		{
			ownedDogIDs.Remove(dogToRemove.dogID);
			dogByIDDict.Remove(dogToRemove.dogID);
		}
	}

	public bool IsDogUIDOwned(ulong dogID)
	{
		if (ghostByIDDict.ContainsKey(dogID))
		{
			return true;
		}
		return dogByIDDict.ContainsKey(dogID);
	}

	public void UpdateSaveableDog(SaveableDog dog)
	{
		if (dog.isGhost)
		{
			if (!ghostByIDDict.ContainsKey(dog.dogID))
			{
				Debug.LogError("Attempting to update saveableDog for ghost: " + dog.dogID + " but it is not in the player's inventory.");
			}
			else
			{
				ghostByIDDict[dog.dogID] = dog;
			}
		}
		else if (!dogByIDDict.ContainsKey(dog.dogID))
		{
			Debug.LogError("Attempting to update saveableDog for dog: " + dog.dogID + " but it is not in the player's inventory.");
		}
		else
		{
			dogByIDDict[dog.dogID] = dog;
		}
	}
}
