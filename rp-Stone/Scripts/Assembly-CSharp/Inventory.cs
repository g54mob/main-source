using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<Item> items = new List<Item>();

	private List<Weapon> weapons = new List<Weapon>();

	private List<Item> craftableItems = new List<Item>();

	private List<Item> breakableItems = new List<Item>();

	private List<Item> enchantableItems = new List<Item>();

	private List<Item> enchantBoostItems = new List<Item>();

	private List<Item> mutatableItems = new List<Item>();

	private List<Item> lostItemBoostItems = new List<Item>();

	private List<Item> shinyItems = new List<Item>();

	private List<Item> nameTaggable = new List<Item>();

	private List<HarvestTool> harvestItems = new List<HarvestTool>();

	private List<TreasureItem> treasures = new List<TreasureItem>();

	private List<Cosmetic> cosmetics = new List<Cosmetic>();

	private Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

	private List<string> groupIdsWeHaveSeen = new List<string>();

	private int bestRarityBonus;

	private int _cachedTotalGearPoints = -1;

	private List<Item> scheduledItemsToDestroy = new List<Item>();

	private List<string> itemDataWhichFailedToLoad = new List<string>();

	private static Inventory _instance;

	private bool weaponSearchNeedsClear = true;

	private Dictionary<string, Weapon> cachedWeaponSearchResults = new Dictionary<string, Weapon>();

	private Dictionary<string, Weapon> dictDescriptionsToWeapons = new Dictionary<string, Weapon>();

	private List<string> allWeaponDescriptions = new List<string>();

	private List<string> allWeaponNameTags = new List<string>();

	private Dictionary<string, string[]> splitCriteria = new Dictionary<string, string[]>();

	public int lockItemDestruction { get; set; }

	public static Inventory Singleton => _instance;

	public event Action<Item, int> OnItemAdded;

	public event Action<Item, int> OnItemGained;

	public void ClearProgress()
	{
		InventoryResources.singleton.ClearProgress();
		ClearLists();
		GameStates.Singleton.hero.RightHand = null;
		GameStates.Singleton.hero.LeftHand = null;
		ClearWeaponSearchResults();
	}

	private void ClearLists()
	{
		for (int i = 0; i < items.Count; i++)
		{
			UnityEngine.Object.Destroy(items[i].gameObject);
		}
		items.Clear();
		weapons.Clear();
		craftableItems.Clear();
		breakableItems.Clear();
		enchantableItems.Clear();
		enchantBoostItems.Clear();
		mutatableItems.Clear();
		lostItemBoostItems.Clear();
		shinyItems.Clear();
		nameTaggable.Clear();
		harvestItems.Clear();
		treasures.Clear();
		cosmetics.Clear();
		itemDict.Clear();
		groupIdsWeHaveSeen.Clear();
		ClearGearPointsCache();
	}

	public List<Item> GetAllItems()
	{
		return items;
	}

	public List<Weapon> GetAllWeapons()
	{
		return weapons;
	}

	public List<Item> GetCraftableItems()
	{
		return craftableItems;
	}

	public List<Item> GetBreakableItems()
	{
		return breakableItems;
	}

	public Item GetFirstZeroStarBreakableItem()
	{
		for (int i = 0; i < breakableItems.Count; i++)
		{
			Item item = breakableItems[i];
			if (!(item == null) && ItemFactory.CanSplitApart(item) && ItemFactory.GetLevelDisplayIntegerForItem(item) == 1)
			{
				return item;
			}
		}
		return null;
	}

	public int GetZeroStarBreakableItemCount()
	{
		int num = 0;
		for (int i = 0; i < breakableItems.Count; i++)
		{
			Item item = breakableItems[i];
			if (!(item == null) && ItemFactory.CanSplitApart(item) && ItemFactory.GetLevelDisplayIntegerForItem(item) == 1)
			{
				num++;
			}
		}
		return num;
	}

	public List<Item> GetEnchantableItems()
	{
		return enchantableItems;
	}

	public List<Item> GetEnchantBoostItems()
	{
		return enchantBoostItems;
	}

	public List<Item> GetMutatableItems()
	{
		return mutatableItems;
	}

	public List<Item> GetLostItemBoostItems()
	{
		return lostItemBoostItems;
	}

	public List<Item> GetShinyItems()
	{
		return shinyItems;
	}

	public List<Item> GetNameTaggableItems()
	{
		return nameTaggable;
	}

	public List<TreasureItem> GetTreasures()
	{
		return treasures;
	}

	public List<Cosmetic> GetCosmetics()
	{
		return cosmetics;
	}

	public List<string> GetGroupIDsWeHaveSeen()
	{
		return groupIdsWeHaveSeen;
	}

	public List<Item> FindItems(string itemId, ItemData.Element element)
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < weapons.Count; i++)
		{
			Item item = weapons[i];
			if (item != null && item.id == itemId && item.element == element)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public static void Sort(List<Item> itemsToSort)
	{
		itemsToSort.Sort(CompareItems);
	}

	public static void Sort(List<Weapon> weaponsToSort)
	{
		weaponsToSort.Sort(CompareItems);
	}

	private static int CompareItems(Item itemA, Item itemB)
	{
		if (itemA.sortValue > 30 && itemB.sortValue > 30)
		{
			if (itemA.sortValue != itemB.sortValue)
			{
				return itemA.sortValue.CompareTo(itemB.sortValue);
			}
			Cosmetic cosmetic = itemA as Cosmetic;
			Cosmetic cosmetic2 = itemB as Cosmetic;
			if (cosmetic != null && cosmetic2 != null)
			{
				return cosmetic.targetItem.GetDictionaryKey().CompareTo(cosmetic2.targetItem.GetDictionaryKey());
			}
		}
		int num = CalculateSortValueForItem(itemA);
		int num2 = CalculateSortValueForItem(itemB);
		if (num == num2)
		{
			if (itemA.id == itemB.id)
			{
				if (itemA.element == itemB.element)
				{
					return itemA.GetGroupId().CompareTo(itemB.GetGroupId());
				}
				return ElementSortValue(itemA.element) - ElementSortValue(itemB.element);
			}
			return itemA.id.CompareTo(itemB.id);
		}
		return num - num2;
	}

	private static int CalculateSortValueForItem(Item item)
	{
		int num = item.sortValue;
		int num2 = Mathf.Max(0, item.complexity);
		int num3 = ((!item.showLevelInTitle) ? 1 : ItemFactory.GetLevelDisplayIntegerForItem(item));
		int rarityBonus = item.GetRarityBonus();
		if (item.element == ItemData.Element.Stone)
		{
			num += 2;
		}
		int num4 = num - (num2 << 11) - (num3 << 15) - (rarityBonus << 20);
		if (item.isNamed)
		{
			num4 -= 82000000;
		}
		return num4;
	}

	private static int ElementSortValue(ItemData.Element e)
	{
		return e switch
		{
			ItemData.Element.Poison => 1, 
			ItemData.Element.Vigor => 2, 
			ItemData.Element.AEther => 3, 
			ItemData.Element.Fire => 4, 
			ItemData.Element.Ice => 5, 
			ItemData.Element.Air => 6, 
			_ => 0, 
		};
	}

	public bool HasItemByGroupId(string groupId)
	{
		if (itemDict.ContainsKey(groupId) && itemDict[groupId] != null)
		{
			return true;
		}
		if (PortGroupIdFrom170ToKnownItem(groupId) != null)
		{
			return true;
		}
		return false;
	}

	public bool HasItemById(string id)
	{
		for (int i = 0; i < items.Count; i++)
		{
			Item item = items[i];
			if (item != null && item.id == id)
			{
				return true;
			}
		}
		return false;
	}

	public Item GetItem(string groupId)
	{
		if (itemDict.ContainsKey(groupId) && itemDict[groupId] != null)
		{
			return itemDict[groupId];
		}
		string text = PortGroupIdFrom170ToKnownItem(groupId);
		if (text != null)
		{
			return itemDict[text];
		}
		Utils.LogError("Inventory does not contain item " + groupId);
		return null;
	}

	private string PortGroupIdFrom170ToKnownItem(string groupId)
	{
		if (Features.PREV_VERSION < new Version(1, 8, 0))
		{
			foreach (KeyValuePair<string, Item> item in itemDict)
			{
				if (!(item.Value == null) && item.Value.rarity != null)
				{
					string key = item.Key;
					if (key.StartsWith(groupId) && key.Length > groupId.Length && key[groupId.Length] == 'q' && key == groupId + "q" + item.Value.rarity.quality)
					{
						Utils.LogWarningIfEditor("Porting group id " + groupId + " -> " + key);
						return key;
					}
				}
			}
		}
		return null;
	}

	public Item GetFirstItemWithId(string id)
	{
		for (int i = 0; i < items.Count; i++)
		{
			Item item = items[i];
			if (item != null && item.id == id)
			{
				return item;
			}
		}
		return null;
	}

	public Weapon GetWeapon(string groupId)
	{
		Item item = GetItem(groupId);
		if (item != null)
		{
			Weapon obj = item as Weapon;
			if (obj == null)
			{
				Utils.LogError("Inventory contain item " + groupId + " but it's not a weapon.");
			}
			return obj;
		}
		return null;
	}

	public Item GainItem(Item item, int count = 1, bool updateAchievements = true)
	{
		item = AddItem(item, count, updateAchievements);
		this.OnItemGained?.Invoke(item, count);
		return item;
	}

	public Item AddItem(Item item, int count = 1, bool updateAchievements = true)
	{
		if (item == null)
		{
			Utils.LogError("Cannot add NULL item.");
			return null;
		}
		bool flag = item.id == "ki";
		if (!SaveFiles.singleton.isLoading && (flag || item.id == "ki_crystal") && EventController.singleton.IsEventActive("2xKi"))
		{
			count *= 2;
		}
		if (flag)
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, count);
			return item;
		}
		if (item.id == "stone")
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Stone, count);
			return item;
		}
		if (item.id == "wood")
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Wood, count);
			return item;
		}
		if (item.id == "tar")
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Tar, count);
			return item;
		}
		if (item.id == "bronze")
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Bronze, count);
			return item;
		}
		UnscheduleDestruction(item);
		string groupId = item.GetGroupId();
		if (itemDict.ContainsKey(groupId) && itemDict[groupId] == null)
		{
			itemDict.Remove(groupId);
		}
		if (itemDict.ContainsKey(groupId))
		{
			Item item2 = itemDict[groupId];
			if (item2.isLost)
			{
				item2.lostCount++;
				if (string.IsNullOrEmpty(item2.signature) && !string.IsNullOrEmpty(item.signature))
				{
					item2.signature = item.signature;
				}
			}
			else
			{
				item2.count += count;
			}
			if (item2 != item)
			{
				item2.rngSeed = item.rngSeed;
				if (item2.rarity != null && item.rarity != null)
				{
					item2.rarity.selectedStatSeed = item.rarity.selectedStatSeed;
				}
				UnityEngine.Object.Destroy(item.gameObject);
			}
			item = item2;
		}
		else
		{
			if (count > 1)
			{
				item.count = count;
			}
			items.Add(item);
			itemDict.Add(groupId, item);
			Weapon weapon = item as Weapon;
			if (weapon != null)
			{
				weapons.Add(weapon);
				if (item.canCraftOnAnvil && weapon.handType != Weapon.HandType.CannotEquip && ItemFactory.GetLevelDisplayIntegerForItem(item) > 1)
				{
					nameTaggable.Add(item);
				}
				ClearWeaponSearchResults();
			}
			if (item.canCraftOnAnvil)
			{
				craftableItems.Add(item);
				breakableItems.Add(item);
			}
			TreasureItem treasureItem = item as TreasureItem;
			bool flag2 = treasureItem != null;
			ItemData.Rarity.Type rarityType = item.GetRarityType();
			if ((rarityType != ItemData.Rarity.Type.Common && !flag2) || (item.canMutateOnMoondial && (item.complexity <= 0 || item.element != ItemData.Element.Stone)))
			{
				mutatableItems.Add(item);
			}
			if (item.canBoostLostItem && item.level == 1 && rarityType == ItemData.Rarity.Type.Common)
			{
				lostItemBoostItems.Add(item);
			}
			if (rarityType != ItemData.Rarity.Type.Common && !flag2)
			{
				enchantableItems.Add(item);
				if (!item.isShiny && !item.isLost)
				{
					enchantBoostItems.Add(item);
				}
			}
			if (item.isShiny)
			{
				shinyItems.Add(item);
			}
			HarvestTool component = item.GetComponent<HarvestTool>();
			if (component != null)
			{
				harvestItems.Add(component);
			}
			if (flag2)
			{
				treasures.Add(treasureItem);
			}
			else if (groupIdsWeHaveSeen.Contains(groupId))
			{
				item.hasInteracted = true;
			}
			else if (item.level < 64 && item.GetRarityType() == ItemData.Rarity.Type.Common)
			{
				groupIdsWeHaveSeen.Add(groupId);
			}
			bestRarityBonus = Mathf.Max(bestRarityBonus, item.GetRarityBonus());
		}
		QuestExceptions.AfterItemAdded(item);
		if (updateAchievements)
		{
			AchievementController.singleton.ReportItemAcquired(item);
		}
		this.OnItemAdded?.Invoke(item, count);
		ClearGearPointsCache();
		return item;
	}

	public void RemoveItemById(string itemId)
	{
		Item firstItemWithId = GetFirstItemWithId(itemId);
		if (firstItemWithId != null)
		{
			RemoveItem(firstItemWithId);
		}
	}

	public void RemoveItemById(string itemId, int amount)
	{
		Item firstItemWithId = GetFirstItemWithId(itemId);
		if (firstItemWithId != null)
		{
			RemoveItem(firstItemWithId, amount);
		}
	}

	public void RemoveItem(Item item, int amount)
	{
		if (item.count <= amount)
		{
			RemoveItem(item);
			ScheduleDestruction(item);
		}
		else
		{
			item.count -= amount;
		}
	}

	public void RemoveItem(Item item)
	{
		if (item == null)
		{
			Utils.LogError("Cannot remove NULL item");
			return;
		}
		string groupId = item.GetGroupId();
		if (!itemDict.ContainsKey(groupId))
		{
			Utils.Log("Tried to remove item " + groupId + " but we don't have that in the inventory.", item.gameObject);
			return;
		}
		items.Remove(item);
		itemDict.Remove(groupId);
		Weapon weapon = item as Weapon;
		if (weapon != null)
		{
			weapons.Remove(weapon);
			nameTaggable.Remove(item);
			ClearWeaponSearchResults();
		}
		if (item.canCraftOnAnvil)
		{
			craftableItems.Remove(item);
			breakableItems.Remove(item);
		}
		ItemData.Rarity.Type rarityType = item.GetRarityType();
		if (rarityType != ItemData.Rarity.Type.Common || (item.canMutateOnMoondial && (item.complexity <= 0 || item.element != ItemData.Element.Stone)))
		{
			mutatableItems.Remove(item);
		}
		if (item.canBoostLostItem && item.level == 1)
		{
			lostItemBoostItems.Remove(item);
		}
		if (rarityType != ItemData.Rarity.Type.Common)
		{
			enchantableItems.Remove(item);
			enchantBoostItems.Remove(item);
		}
		if (item.isShiny)
		{
			shinyItems.Remove(item);
		}
		HarvestTool component = item.GetComponent<HarvestTool>();
		if (component != null)
		{
			harvestItems.Remove(component);
		}
		TreasureItem treasureItem = item as TreasureItem;
		if (treasureItem != null)
		{
			treasures.Remove(treasureItem);
		}
		ClearGearPointsCache();
	}

	public int GetItemCount()
	{
		return items.Count;
	}

	public Item MakeReward(string itemId, int level)
	{
		string groupId = itemId + "_lv" + level;
		if (Singleton.HasItemByGroupId(groupId))
		{
			return Singleton.GetItem(groupId);
		}
		Item item = ItemFactory.singleton.MakeItemWithLevel(itemId, level);
		ItemFactory.SetItemLevelByDisplayLevel(item, level);
		item.LoadAbilities();
		return item;
	}

	public Item MakeReward(string itemId, int level, ItemData.Element element, int rngSeed)
	{
		Item item = ((element != ItemData.Element.Stone) ? ItemFactory.singleton.MakeItemWithLevelAndAbilities(itemId, level, element, rngSeed) : MakeReward(itemId, level));
		ItemFactory.SetItemLevelByDisplayLevel(item, level);
		return item;
	}

	public Item MakeReward(Data.ItemInTreasure itemData)
	{
		itemData.level = Mathf.Clamp(itemData.level, 1, 11);
		Item item;
		if (itemData.rarityType != ItemData.Rarity.Type.Common)
		{
			ItemData.Rarity rarity = new ItemData.Rarity(itemData.rarityType);
			rarity.Roll(itemData.rngSeed);
			if (itemData.rarityBonus > 0 && rarity.levelBonus != itemData.rarityBonus)
			{
				rarity.levelBonus = itemData.rarityBonus;
				rarity.quality = ItemData.Rarity.GetQualityThreshold(itemData.rarityBonus);
			}
			item = ItemFactory.singleton.MakeItemWithLevelAndAbilities(itemData.id, itemData.level, itemData.element, itemData.rngSeed, rarity);
			ItemFactory.SetItemLevelByDisplayLevel(item, itemData.level);
		}
		else
		{
			item = MakeReward(itemData.id, itemData.level, itemData.element, itemData.rngSeed);
		}
		return item;
	}

	public Item ReplaceItem(string itemToReplaceId, string replaceWithItemId)
	{
		Item item;
		if (HasItemById(replaceWithItemId))
		{
			item = GetFirstItemWithId(replaceWithItemId);
		}
		else
		{
			item = ItemFactory.singleton.MakeItem(replaceWithItemId);
			item.LoadAbilities();
		}
		Item firstItemWithId = GetFirstItemWithId(itemToReplaceId);
		if (firstItemWithId != null && item != null)
		{
			int count = firstItemWithId.count;
			bool flag = GameStates.Singleton.hero.LeftHand == firstItemWithId;
			bool flag2 = GameStates.Singleton.hero.RightHand == firstItemWithId;
			RemoveItem(firstItemWithId);
			Weapon weapon = firstItemWithId as Weapon;
			if (weapon != null && (flag || flag2))
			{
				GameStates.Singleton.hero.Unequip(weapon);
			}
			item = AddItem(item, count);
			weapon = item as Weapon;
			if (weapon != null)
			{
				if (flag)
				{
					GameStates.Singleton.hero.EquipLeft(weapon);
				}
				if (flag2)
				{
					GameStates.Singleton.hero.EquipRight(weapon);
				}
			}
		}
		return item;
	}

	public int GetWeaponCount()
	{
		return weapons.Count;
	}

	public bool HasToolToHarvest(Data.Resource resourceType)
	{
		for (int i = 0; i < harvestItems.Count; i++)
		{
			if (harvestItems[i] != null && harvestItems[i].resourceType == resourceType)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsToolToHarvestEquipped(Data.Resource resourceType)
	{
		HarvestTool toolToHarvest = Singleton.GetToolToHarvest(resourceType);
		if (toolToHarvest != null)
		{
			Hero hero = GameStates.Singleton.hero;
			if ((hero.LeftHand != null && hero.LeftHand.gameObject == toolToHarvest.gameObject) || (hero.RightHand != null && hero.RightHand.gameObject == toolToHarvest.gameObject))
			{
				return true;
			}
		}
		return false;
	}

	public HarvestTool GetToolToHarvest(Data.Resource resourceType)
	{
		for (int i = 0; i < harvestItems.Count; i++)
		{
			HarvestTool harvestTool = harvestItems[i];
			if (harvestTool != null && harvestTool.resourceType == resourceType)
			{
				return harvestTool;
			}
		}
		return null;
	}

	public bool HasMultipleTreasures()
	{
		int num = 0;
		for (int i = 0; i < items.Count; i++)
		{
			Item item = items[i];
			if (item != null && item is TreasureItem)
			{
				num++;
				if (num >= 2)
				{
					return true;
				}
			}
		}
		return false;
	}

	public TreasureItem GetFirstTreasure()
	{
		for (int i = 0; i < items.Count; i++)
		{
			TreasureItem treasureItem = items[i] as TreasureItem;
			if (treasureItem != null)
			{
				return treasureItem;
			}
		}
		return null;
	}

	public TreasureItem GetLastTreasure()
	{
		for (int num = items.Count - 1; num >= 0; num--)
		{
			TreasureItem treasureItem = items[num] as TreasureItem;
			if (treasureItem != null)
			{
				return treasureItem;
			}
		}
		return null;
	}

	public bool IsAtTreasurelimit()
	{
		return Singleton.GetTreasures().Count >= GetTreasurePickupLimit();
	}

	public int GetTreasurePickupLimit()
	{
		return 100 + 5 * XPController.singleton.currentLevel;
	}

	public int GetBestRarityBonus()
	{
		return bestRarityBonus;
	}

	public bool HasRunestoneMaterial(ItemData.Element element, int amount = 1)
	{
		for (int i = 0; i < lostItemBoostItems.Count; i++)
		{
			Item item = lostItemBoostItems[i];
			if (item.element == element && item.count >= amount && item.id == "runestone")
			{
				return true;
			}
		}
		return false;
	}

	public int GetRunestoneMaterialCount(ItemData.Element element)
	{
		for (int i = 0; i < lostItemBoostItems.Count; i++)
		{
			Item item = lostItemBoostItems[i];
			if (item.element == element && item.id == "runestone")
			{
				return item.count;
			}
		}
		return 0;
	}

	public void RemoveRunestoneMaterial(ItemData.Element element, int amount = 1)
	{
		for (int i = 0; i < lostItemBoostItems.Count; i++)
		{
			Item item = lostItemBoostItems[i];
			if (item.element == element && item.id == "runestone")
			{
				RemoveItem(item, amount);
				break;
			}
		}
	}

	public bool EvaluateRequiredAndBlockedBy(string requiresItem, string blockedByItem)
	{
		if (string.IsNullOrEmpty(requiresItem) || HasItemById(requiresItem))
		{
			if (!string.IsNullOrEmpty(blockedByItem))
			{
				return !HasItemById(blockedByItem);
			}
			return true;
		}
		return false;
	}

	public int GetTotalGearPoints()
	{
		if (_cachedTotalGearPoints >= 0)
		{
			return _cachedTotalGearPoints;
		}
		int num = 0;
		int num2 = 0;
		List<Item> allItems = GetAllItems();
		for (int i = 0; i < allItems.Count; i++)
		{
			Item item = allItems[i];
			if (!(item == null))
			{
				int levelDisplayIntegerForItem = ItemFactory.GetLevelDisplayIntegerForItem(item);
				if (levelDisplayIntegerForItem > num2)
				{
					num2 = levelDisplayIntegerForItem;
				}
				else if (num2 - levelDisplayIntegerForItem >= 4)
				{
					continue;
				}
				num += item.ComputeGearPoints();
			}
		}
		_cachedTotalGearPoints = num;
		return num;
	}

	private void ClearGearPointsCache()
	{
		_cachedTotalGearPoints = -1;
	}

	private void ScheduleDestruction(Item item)
	{
		if (!scheduledItemsToDestroy.Contains(item))
		{
			scheduledItemsToDestroy.Add(item);
		}
	}

	private void UnscheduleDestruction(Item item)
	{
		if (scheduledItemsToDestroy.Count > 0)
		{
			scheduledItemsToDestroy.Remove(item);
		}
	}

	private void FixedUpdate()
	{
		if (scheduledItemsToDestroy.Count > 0 && lockItemDestruction == 0)
		{
			for (int i = 0; i < scheduledItemsToDestroy.Count; i++)
			{
				UnityEngine.Object.Destroy(scheduledItemsToDestroy[i].gameObject);
			}
			scheduledItemsToDestroy.Clear();
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		InventoryResources.singleton.Serialize();
		List<string> list = new List<string>();
		for (int i = 0; i < items.Count; i++)
		{
			Item item = items[i];
			if (!(item == null) && !(item is Cosmetic))
			{
				string item2 = ItemFactory.singleton.ItemToString(item);
				list.Add(item2);
			}
		}
		list.AddRange(itemDataWhichFailedToLoad);
		SlimJson.AddProperty("itms", list.ToArray());
		Hero hero = GameStates.Singleton.hero;
		Weapon rightHand = hero.RightHand;
		Weapon leftHand = hero.LeftHand;
		if (rightHand != null)
		{
			SlimJson.AddProperty("rightH", rightHand.GetGroupId());
		}
		if (leftHand != null)
		{
			SlimJson.AddProperty("leftH", leftHand.GetGroupId());
		}
		SlimJson.AddProperty("itmsSeen", groupIdsWeHaveSeen.ToArray());
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		InventoryResources.singleton.Parse(sjson);
		ClearLists();
		itemDataWhichFailedToLoad.Clear();
		ClearWeaponSearchResults();
		if (SlimJson.HasKey(sjson, "items"))
		{
			string[] array = SlimJson.ParseArray(sjson, "items");
			foreach (string text in array)
			{
				string text2 = SlimJson.Parse(text, "item_id");
				int count = SlimJson.ParseInt(text, "count");
				Item item = ItemFactory.singleton.MakeItem(text2);
				if (item == null)
				{
					itemDataWhichFailedToLoad.Add(text);
					Utils.LogError("Item " + text2 + " failed to load.");
					continue;
				}
				string text3 = SlimJson.Parse(text, "data");
				if (text3 != null)
				{
					item.ParseData(text3);
				}
				ItemAbilityPatch.ApplyPatches(item);
				item.LoadAbilities();
				AddItem(item, count, updateAchievements: false);
			}
			GameStates.Singleton.hero.RightHand = null;
			GameStates.Singleton.hero.LeftHand = null;
			string text4 = SlimJson.Parse(sjson, "right_hand_item_group_id");
			string text5 = SlimJson.Parse(sjson, "left_hand_item_group_id");
			if (text4 != null)
			{
				GameStates.Singleton.hero.EquipRight(GetWeapon(text4));
			}
			if (text5 != null)
			{
				GameStates.Singleton.hero.EquipLeft(GetWeapon(text5));
			}
			if (SlimJson.HasKey(sjson, "items_we_have_seen"))
			{
				groupIdsWeHaveSeen = new List<string>(SlimJson.ParseArray(sjson, "items_we_have_seen"));
			}
			return;
		}
		string[] array2 = SlimJson.ParseArray(sjson, "itms");
		foreach (string text6 in array2)
		{
			Item item2 = ItemFactory.singleton.ItemFromString(text6);
			if (item2 == null)
			{
				itemDataWhichFailedToLoad.Add(text6);
				string text7 = SlimJson.Parse(text6, "id");
				Utils.LogError("Item " + text7 + " failed to load.");
			}
			else if (item2.id == "ouroboros_stone" && HasItemById("ouroboros_stone"))
			{
				Item firstItemWithId = GetFirstItemWithId("ouroboros_stone");
				firstItemWithId.level = Mathf.Max(item2.level, firstItemWithId.level);
				OuroborosWeapon.singleton = firstItemWithId as OuroborosWeapon;
			}
			else
			{
				AddItem(item2, item2.count, updateAchievements: false);
			}
		}
		GameStates.Singleton.hero.RightHand = null;
		GameStates.Singleton.hero.LeftHand = null;
		string text8 = SlimJson.Parse(sjson, "rightH");
		string text9 = SlimJson.Parse(sjson, "leftH");
		if (text8 != null)
		{
			GameStates.Singleton.hero.EquipRight(GetWeapon(text8));
		}
		if (text9 != null)
		{
			GameStates.Singleton.hero.EquipLeft(GetWeapon(text9));
		}
		if (SlimJson.HasKey(sjson, "itmsSeen"))
		{
			groupIdsWeHaveSeen = new List<string>(SlimJson.ParseArray(sjson, "itmsSeen"));
		}
	}

	private void Awake()
	{
		_instance = this;
	}

	private void ClearWeaponSearchResults()
	{
		weaponSearchNeedsClear = true;
	}

	public void CacheWeaponDescriptions()
	{
		if (!weaponSearchNeedsClear)
		{
			return;
		}
		weaponSearchNeedsClear = false;
		cachedWeaponSearchResults.Clear();
		dictDescriptionsToWeapons.Clear();
		allWeaponDescriptions.Clear();
		allWeaponNameTags.Clear();
		List<Weapon> allWeapons = GetAllWeapons();
		Sort(allWeapons);
		for (int i = 0; i < allWeapons.Count; i++)
		{
			Weapon weapon = allWeapons[i];
			if (weapon == null || weapon.handType == Weapon.HandType.CannotEquip)
			{
				continue;
			}
			string newValue = Te.xt(ItemData.ReplacementTidForElement(weapon.element));
			string text = Te.xt(weapon.displayName);
			text = text.Replace("<element>", newValue);
			text = text + " " + weapon.element;
			string text2 = " *";
			int levelDisplayIntegerForItem = ItemFactory.GetLevelDisplayIntegerForItem(weapon);
			text2 = ((levelDisplayIntegerForItem != ItemFactory.MAX_DISPLAY_LEVEL) ? (text2 + (levelDisplayIntegerForItem - 1) + "*") : (text2 + "10*max*"));
			string text3 = text + " " + weapon.id + text2 + " +" + weapon.GetRarityBonus() + " ";
			if (weapon.abilities != null && weapon.procGenAbilities)
			{
				for (int j = 0; j < weapon.abilities.Count; j++)
				{
					ItemData.Ability ability = weapon.abilities[j];
					if (ability.abbreviation != null && ability.abbreviation.Length > 0)
					{
						text3 += ability.abbreviation[0];
					}
				}
			}
			if (weapon.isShiny)
			{
				text3 += " shiny";
			}
			if (weapon.isLost)
			{
				text3 += " lost";
			}
			if (weapon.isNamed)
			{
				text3 = weapon.nameTag + " " + text3;
			}
			if (weapon.cosmeticId != null)
			{
				text3 = text3 + " " + weapon.cosmeticId;
			}
			if (!dictDescriptionsToWeapons.ContainsKey(text3))
			{
				dictDescriptionsToWeapons.Add(text3, weapon);
				allWeaponDescriptions.Add(text3);
				allWeaponNameTags.Add(weapon.nameTag);
				weapon.cachedSearchDescription = text3;
			}
		}
	}

	public Weapon FindBestWeapon(string criteria, Weapon.HandType targetHand)
	{
		CacheWeaponDescriptions();
		string[] criteria2 = SplitTheCriteria(criteria);
		int num = 0;
		Weapon result = null;
		for (int i = 0; i < allWeaponDescriptions.Count; i++)
		{
			string text = allWeaponDescriptions[i];
			string text2 = allWeaponNameTags[i];
			if (string.Equals(text2, criteria, StringComparison.OrdinalIgnoreCase))
			{
				return dictDescriptionsToWeapons[text];
			}
			int num2 = ScoreWeaponDescriptionForSearchCriteria(text, text2, criteria2);
			if (num2 > num)
			{
				Weapon weapon = dictDescriptionsToWeapons[text];
				if ((weapon.handType != Weapon.HandType.DoubleHanded || (targetHand != Weapon.HandType.LeftOnly && targetHand != Weapon.HandType.RightOnly)) && (targetHand == Weapon.HandType.LeftOrRight || weapon.handType == Weapon.HandType.LeftOrRight || weapon.handType == Weapon.HandType.DoubleHanded || weapon.handType == targetHand))
				{
					num = num2;
					result = weapon;
				}
			}
		}
		return result;
	}

	private int ScoreWeaponDescriptionForSearchCriteria(string description, string nameTag, string[] criteria)
	{
		int num = 0;
		for (int i = 0; i < criteria.Length && i <= 11; i++)
		{
			string text = criteria[i];
			if (text.Length >= 2 && text[0] == '-')
			{
				text = text.Substring(1);
				if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(description, text, CompareOptions.IgnoreCase) >= 0)
				{
					return 0;
				}
				continue;
			}
			if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(description, text, CompareOptions.IgnoreCase) >= 0)
			{
				num += 10;
				if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(description, text) >= 0)
				{
					num += 10;
				}
				if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(description, " " + text) >= 0)
				{
					num += 10;
				}
			}
			else
			{
				num -= 10;
			}
			if (!string.IsNullOrEmpty(nameTag) && CultureInfo.InvariantCulture.CompareInfo.IndexOf(nameTag, text, CompareOptions.IgnoreCase) < 0)
			{
				num -= 11;
			}
		}
		return num;
	}

	private string[] SplitTheCriteria(string criteria)
	{
		if (splitCriteria.ContainsKey(criteria))
		{
			return splitCriteria[criteria];
		}
		if (string.IsNullOrEmpty(criteria))
		{
			splitCriteria[criteria] = new string[0];
			return splitCriteria[criteria];
		}
		criteria = InsertSpaceInFrontOfGlyph(criteria, '*');
		criteria = InsertSpaceInFrontOfGlyph(criteria, '+');
		string[] array = criteria.Split(new char[1] { ' ' });
		splitCriteria[criteria] = array;
		return array;
	}

	private string InsertSpaceInFrontOfGlyph(string criteria, char searchGlyph)
	{
		int num = criteria.IndexOf(searchGlyph);
		if (num > 0)
		{
			switch (criteria[num - 1])
			{
			default:
				criteria = criteria.Insert(num, " ");
				break;
			case ' ':
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				break;
			}
		}
		return criteria;
	}
}
