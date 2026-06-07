using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
	public int curDay;

	public int curDifficulty;

	public float money;

	public int tokens;

	public List<string> spawnedBefore;

	public List<string> npcsKilled;

	public List<int> instantiablesID;

	public List<int> instantiablesShiftsAlive;

	public List<string> instantiablesAssociatedTexts;

	public List<float> instantiablesPosX;

	public List<float> instantiablesPosY;

	public List<float> instantiablesPosZ;

	public List<float> instantiablesRotX;

	public List<float> instantiablesRotY;

	public List<float> instantiablesRotZ;

	public List<float> instantiablesRotW;

	public int seed;

	public List<int> seedForEvents;

	public List<int> dayObjsSpawnedBefore;

	public int[] maxShelfItems;

	public int[] curShelfItems;

	public bool endlessMode;

	public int maxInventorySpace;

	public int refreshes;

	public List<int> storeUpgradesPurchased = new List<int>();

	public List<int> weaponsPurchased = new List<int>();

	public List<ulong> steamIds;

	public List<List<int>> inventoryIds = new List<List<int>>();

	public List<List<int>> inventoryAmounts = new List<List<int>>();

	public List<List<int>> boxStorages = new List<List<int>>();

	public List<List<int>> trashAmounts = new List<List<int>>();

	public int huntsDone;

	public List<int> customizablesUnlocked = new List<int>();

	public SaveData(SaveManager saveMan)
	{
		curDay = saveMan.curDay;
		curDifficulty = saveMan.curDifficulty;
		spawnedBefore = saveMan.spawnedBefore;
		instantiablesID = saveMan.instantiablesID;
		instantiablesPosX = saveMan.instantiablesPosX;
		instantiablesPosY = saveMan.instantiablesPosY;
		instantiablesPosZ = saveMan.instantiablesPosZ;
		instantiablesRotX = saveMan.instantiablesRotX;
		instantiablesRotY = saveMan.instantiablesRotY;
		instantiablesRotZ = saveMan.instantiablesRotZ;
		instantiablesRotW = saveMan.instantiablesRotW;
		instantiablesShiftsAlive = saveMan.instantiablesShiftsAlive;
		instantiablesAssociatedTexts = saveMan.instantiablesAssociatedTexts;
		tokens = saveMan.tokens;
		money = saveMan.money;
		seedForEvents = saveMan.seedForEvents;
		maxShelfItems = saveMan.maxShelfItems;
		curShelfItems = saveMan.curShelfItems;
		seed = saveMan.seed;
		dayObjsSpawnedBefore = saveMan.dayObjsSpawnedBefore;
		npcsKilled = saveMan.npcsKilled;
		maxInventorySpace = saveMan.maxInventorySpace;
		steamIds = saveMan.steamIds;
		inventoryIds = saveMan.inventoryIds;
		inventoryAmounts = saveMan.inventoryAmounts;
		boxStorages = saveMan.boxStorages;
		trashAmounts = saveMan.trashAmounts;
		refreshes = saveMan.refreshes;
		storeUpgradesPurchased = saveMan.storeUpgradesPurchased;
		weaponsPurchased = saveMan.weaponsPurchased;
		huntsDone = saveMan.huntsDone;
		customizablesUnlocked = saveMan.customizablesUnlocked;
	}
}
