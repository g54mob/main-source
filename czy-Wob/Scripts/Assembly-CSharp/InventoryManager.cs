using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<InventoryItem> debugStartingItems = new List<InventoryItem>();

	public List<SaveableDogEgg> debugStartingEggs = new List<SaveableDogEgg>();

	public InventoryItem dogCoreItem;

	private string basePath = "Items/";

	private string foodPath = "Food/";

	private string toysPath = "Toys/";

	private string eggsPath = "Eggs/";

	private string specialPath = "Special/";

	private string seedPacketsPath = "SeedPackets/";

	private string denUpgradesPath = "DenUpgrades/";

	private string roomCustomizationPath = "RoomCustomization/";

	private string toyPath = "Toys/";

	private string miscPath = "Misc/";

	private string wallsPath = "Walls/";

	private string carpetPath = "Carpet/";

	private string plantsPath = "Plants/";

	private string puddlesPath = "Puddles/";

	private string wavyWallpaperPath = "Wavy/";

	private string wallpaperPath = "Wallpaper/";

	private string gardeningPath = "Gardening/";

	private string decorationPath = "Decoration/";

	private string brickWallpaperPath = "Bricks/";

	private string zigzagWallpaperPath = "ZigZag/";

	private string hotdogWallpaperPath = "Hotdogs/";

	private string growableFoodPath = "GrowableObject/Food/";

	private List<InventoryItem> allItems = new List<InventoryItem>();

	private Dictionary<string, string> itemNameToPathDict = new Dictionary<string, string>();

	private List<GrowableObject> allGrowables = new List<GrowableObject>();

	private Dictionary<GrowableObject, string> growableToPathDict = new Dictionary<GrowableObject, string>();

	private List<RoomCustomizationObject> allCustomizationObjects = new List<RoomCustomizationObject>();

	private Dictionary<string, string> customizationObjectToPathDict = new Dictionary<string, string>();

	public PlayerInventory playerInventory;

	private DogHome homeRef;

	private FloraManager floraRef;

	private DogGutsManager dogGutsRef;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadInventoryObjects();
		playerInventory = new PlayerInventory();
		playerInventory.SetManagerRef(this);
		for (int i = 0; i < debugStartingItems.Count; i++)
		{
			playerInventory.AddObjectToIventory(debugStartingItems[i]);
		}
		for (int j = 0; j < debugStartingEggs.Count; j++)
		{
			playerInventory.AddEggToInventory(debugStartingEggs[j]);
		}
	}

	public InventoryItem GetRandomItemOfType(ItemType typeToSpawn, ItemSet category)
	{
		List<int> list = new List<int>();
		List<float> list2 = new List<float>();
		bool flag = false;
		bool flag2 = false;
		int month = DateTime.Now.Month;
		if (typeToSpawn == ItemType.TOY && category == ItemSet.SPOOKY && month == 10)
		{
			flag = true;
		}
		else if (typeToSpawn == ItemType.TOY && category == ItemSet.WINTER && month == 12)
		{
			flag2 = true;
		}
		for (int i = 0; i < allItems.Count; i++)
		{
			if (allItems[i].type == typeToSpawn && (allItems[i].setType == category || allItems[i].setType == ItemSet.NONE) && (!flag || allItems[i].setType == ItemSet.SPOOKY) && (!flag2 || allItems[i].setType == ItemSet.WINTER))
			{
				list.Add(i);
				if (allItems[i].setType == ItemSet.NONE && category != ItemSet.NONE)
				{
					list2.Add((float)allItems[i].rarity / 2f);
				}
				else
				{
					list2.Add((float)allItems[i].rarity);
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		int weightedRandom = ListUtil.GetWeightedRandom(list, list2);
		if (weightedRandom < 0)
		{
			return null;
		}
		return allItems[weightedRandom];
	}

	public void LoadInventory(SaveableInventory savedInventory)
	{
		playerInventory.LoadSavedInventory(savedInventory);
	}

	public InventoryItem GetItemByName(string itemName)
	{
		itemName = itemName.Replace('_', ' ');
		InventoryItem inventoryItem = null;
		for (int i = 0; i < allItems.Count; i++)
		{
			if (!(allItems[i].itemPrefab == null))
			{
				if (allItems[i].itemName.ToLowerInvariant() == itemName.ToLowerInvariant())
				{
					return allItems[i];
				}
				if (allItems[i].itemName.ToLowerInvariant().Contains(itemName.ToLowerInvariant()))
				{
					inventoryItem = allItems[i];
				}
			}
		}
		if (inventoryItem != null)
		{
			return inventoryItem;
		}
		Debug.LogError("No matching InventoryItem found for string: " + itemName);
		return null;
	}

	public RoomCustomizationObject GetCustomizationObjectByName(string objectName)
	{
		for (int i = 0; i < allCustomizationObjects.Count; i++)
		{
			if (allCustomizationObjects[i].GetName().ToLowerInvariant().Contains(objectName.ToLowerInvariant()))
			{
				return allCustomizationObjects[i];
			}
		}
		Debug.LogError("No matching RoomCustomizationObject found for string: " + objectName);
		return null;
	}

	public List<SaveableDogEgg> GetHeldEggs(bool fertilized)
	{
		return playerInventory.GetHeldEggs(fertilized);
	}

	public int GetNumberOfHeldEggs(bool fertilized)
	{
		return playerInventory.GetNumberOfHeldEggs(fertilized);
	}

	public bool GetUnlockStatusForFood(InventoryItem food)
	{
		return playerInventory.GetUnlockStatusForFood(food);
	}

	public List<GrowableObject> GetAllGrowables()
	{
		return allGrowables;
	}

	public List<InventoryItem> GetAllItemsOfType(ItemType neededType)
	{
		List<InventoryItem> list = new List<InventoryItem>();
		for (int i = 0; i < allItems.Count; i++)
		{
			if (allItems[i].type == neededType)
			{
				list.Add(allItems[i]);
			}
		}
		return list;
	}

	public void SpawnMultipleItems(InventoryItem item, int num, Vector3 pos)
	{
		StartCoroutine(SpawnMultipleItemsRoutine(item, num, pos));
	}

	public void SpawnItemList(List<InventoryItem> itemList, Vector3 pos)
	{
		StartCoroutine(SpawnItemListRoutine(itemList, pos));
	}

	private IEnumerator SpawnMultipleItemsRoutine(InventoryItem item, int num, Vector3 pos)
	{
		WaitForSeconds wait = new WaitForSeconds(GlobalProperties.standardTimeslice);
		playerInventory.AddObjectToIventory(item, num);
		for (int i = 0; i < num; i++)
		{
			UseItem(item, pos);
			yield return wait;
		}
	}

	private IEnumerator SpawnItemListRoutine(List<InventoryItem> itemList, Vector3 pos)
	{
		WaitForSeconds wait = new WaitForSeconds(GlobalProperties.standardTimeslice);
		for (int i = 0; i < itemList.Count; i++)
		{
			playerInventory.AddObjectToIventory(itemList[i]);
			UseItem(itemList[i], pos);
			yield return wait;
		}
	}

	public void UseItem(InventoryItem item, Vector3 placementPos)
	{
		playerInventory.RemoveObjectFromInventory(item);
		if (homeRef == null)
		{
			homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		}
		homeRef.TrySpawnItem(item, placementPos);
	}

	public void TossItem(InventoryItem item)
	{
		playerInventory.RemoveObjectFromInventory(item);
	}

	public List<InventoryItem> GetHeldItemsOfType(ItemType type)
	{
		List<InventoryItem> list = new List<InventoryItem>();
		list.AddRange(playerInventory.GetHeldItemsOfType(type).Keys);
		return list;
	}

	public List<SaveableDogCore> GetHeldDogCores()
	{
		return playerInventory.GetHeldDogCores();
	}

	public int GetNumberOfHeldDogCores()
	{
		return playerInventory.GetNumberOfHeldDogCores();
	}

	public int GetNumberOfItemHeld(InventoryItem item)
	{
		return playerInventory.GetNumberOfItemHeld(item);
	}

	public void LoadInventoryObjects()
	{
		LoadItemPath(basePath + foodPath);
		LoadItemPath(basePath + toysPath);
		LoadItemPath(basePath + eggsPath);
		LoadItemPath(basePath + specialPath);
		LoadItemPath(basePath + seedPacketsPath);
		LoadItemPath(basePath + denUpgradesPath);
		LoadGrowableFoodPath(basePath + growableFoodPath);
		LoadCustomizationPath(roomCustomizationPath + toyPath);
		LoadCustomizationPath(roomCustomizationPath + miscPath);
		LoadCustomizationPath(roomCustomizationPath + wallsPath);
		LoadCustomizationPath(roomCustomizationPath + carpetPath);
		LoadCustomizationPath(roomCustomizationPath + plantsPath);
		LoadCustomizationPath(roomCustomizationPath + puddlesPath);
		LoadCustomizationPath(roomCustomizationPath + gardeningPath);
		LoadCustomizationPath(roomCustomizationPath + decorationPath);
		LoadCustomizationPath(roomCustomizationPath + wallpaperPath);
		LoadCustomizationPath(roomCustomizationPath + wallpaperPath + wavyWallpaperPath);
		LoadCustomizationPath(roomCustomizationPath + wallpaperPath + brickWallpaperPath);
		LoadCustomizationPath(roomCustomizationPath + wallpaperPath + hotdogWallpaperPath);
		LoadCustomizationPath(roomCustomizationPath + wallpaperPath + zigzagWallpaperPath);
	}

	private void LoadGrowableFoodPath(string path)
	{
		UnityEngine.Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			GrowableObject growableObject = (GrowableObject)array[i];
			growableToPathDict[growableObject] = path + growableObject.name;
			allGrowables.Add(growableObject);
		}
	}

	private void LoadItemPath(string path)
	{
		UnityEngine.Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			InventoryItem inventoryItem = (InventoryItem)array[i];
			string value = path + inventoryItem.name;
			itemNameToPathDict[inventoryItem.itemName] = value;
			allItems.Add(inventoryItem);
		}
	}

	public void InitializeFloraUnlocks()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		floraRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		dogGutsRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		for (int i = 0; i < allItems.Count; i++)
		{
			if (allItems[i].itemPrefab == null)
			{
				continue;
			}
			Eatable component = allItems[i].itemPrefab.GetComponent<Eatable>();
			if (!(component == null))
			{
				for (int j = 0; j < component.gutFloraTypes.Count; j++)
				{
					floraRef.ReportFoodUnlock(dogGutsRef.GetPathForFlora(component.gutFloraTypes[j]), itemNameToPathDict[allItems[i].itemName], unlockStatus: false, fromConsumption: false);
				}
			}
		}
	}

	public string GetPathForItem(InventoryItem item)
	{
		if (item == null)
		{
			return "";
		}
		return itemNameToPathDict[item.itemName];
	}

	public InventoryItem GetItemForPath(string path)
	{
		return (InventoryItem)Resources.Load(path);
	}

	public string GetPathForGrowable(GrowableObject growable)
	{
		if (growable == null)
		{
			return "";
		}
		return growableToPathDict[growable];
	}

	public GrowableObject GetGrowableForPath(string path)
	{
		return (GrowableObject)Resources.Load(path);
	}

	private void LoadCustomizationPath(string path)
	{
		UnityEngine.Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			RoomCustomizationObject roomCustomizationObject = (RoomCustomizationObject)array[i];
			customizationObjectToPathDict[roomCustomizationObject.ToString()] = path + roomCustomizationObject.name;
			allCustomizationObjects.Add(roomCustomizationObject);
		}
	}

	public string GetPathForCustomizationObject(RoomCustomizationObject item)
	{
		if (item == null)
		{
			return "";
		}
		return customizationObjectToPathDict[item.ToString()];
	}

	public RoomCustomizationObject GetCustomizationObjectForPath(string path)
	{
		return (RoomCustomizationObject)Resources.Load(path);
	}
}
