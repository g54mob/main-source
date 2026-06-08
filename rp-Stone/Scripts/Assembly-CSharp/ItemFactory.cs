using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemFactory : MonoBehaviour
{
	public class Result
	{
		public enum Outcome
		{
			None = 0,
			Fused = 1,
			Boosted = 2,
			ItemNotFound = 3,
			CannotFuse = 4,
			TooComplexToBoost = 5,
			CantBoostWithElement = 6
		}

		public Outcome outcome;

		public Item itemA;

		public Item itemB;

		public int itemA_count;

		public int itemB_count;

		public Item resultingItem;

		public int itemB_remainder;
	}

	public class FuseResult
	{
		public enum Outcome
		{
			None = 0,
			AlreadyMax = 1,
			Fused = 2
		}

		public Outcome outcome;

		public Item primaryItem;

		public Item boostItemA;

		public Item boostItemB;

		public Item boostItemC;

		public Item resultPrimaryItem;

		public Item resultBoostItemA;

		public Item resultBoostItemB;

		public Item resultBoostItemC;
	}

	public static int MAX_DISPLAY_LEVEL = 11;

	public TextAsset listOfItems;

	public TextAsset itemAbilities;

	private float maxLevelDistanceToCombine = 0.999999f;

	private List<string> itemPrefabPaths;

	private Dictionary<string, Item> itemPrefabsDict;

	private ItemCombination[] allCombinations;

	private Dictionary<string, ItemCombination> combinationsDict;

	private ItemData.Ability[] allAbilities;

	private Dictionary<string, ItemData.Ability> abilitiesDict;

	private string[] baseStats1;

	private string[] baseStats2;

	private string[] passiveAbilities;

	public Action<FuseResult> OnFuse;

	public List<string> uniqueIds = new List<string>();

	private int pendingLoads;

	public CraftPage[] craftBookPages { get; private set; }

	public static ItemFactory singleton { get; private set; }

	public string ItemToString(Item item)
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("id", item.id);
		if (item.count != 1)
		{
			SlimJson.AddProperty("co", item.count);
		}
		SlimJson.AddProperty("da", item.SerializeData());
		return SlimJson.EndSerialization();
	}

	public Item ItemFromString(string itemSjson)
	{
		string itemId = SlimJson.Parse(itemSjson, "id");
		int count = SlimJson.ParseInt(itemSjson, "co", 1);
		Item item = MakeItem(itemId);
		if (item == null)
		{
			return null;
		}
		string text = SlimJson.Parse(itemSjson, "da");
		if (text != null)
		{
			item.ParseData(text);
		}
		ItemAbilityPatch.ApplyPatches(item);
		item.LoadAbilities();
		item.count = count;
		return item;
	}

	private void LoadItemDataFromText()
	{
		string[] collection = SlimJson.ParseArray(listOfItems.text, "filePaths");
		itemPrefabPaths = new List<string>(collection);
		itemPrefabsDict = new Dictionary<string, Item>(itemPrefabPaths.Count);
		allCombinations = SlimJson.ParseArray(listOfItems.text, "combinations", ItemCombination.FromString);
		combinationsDict = new Dictionary<string, ItemCombination>();
		for (int i = 0; i < allCombinations.Length; i++)
		{
			ItemCombination itemCombination = allCombinations[i];
			string text = GenerateCombinedKey(itemCombination.itemA, itemCombination.itemB);
			if (!combinationsDict.ContainsKey(text))
			{
				combinationsDict.Add(text, itemCombination);
			}
			else
			{
				Utils.LogError("Duplicate item combination key '" + text + "'. Already in dictionary.");
			}
		}
		craftBookPages = SlimJson.ParseArray(listOfItems.text, "craft_book", CraftPage.FromString);
		allAbilities = SlimJson.ParseArray(itemAbilities.text, "abilities", ItemData.Ability.FromString);
		abilitiesDict = new Dictionary<string, ItemData.Ability>();
		for (int j = 0; j < allAbilities.Length; j++)
		{
			ItemData.Ability ability = allAbilities[j];
			if (!abilitiesDict.ContainsKey(ability.id))
			{
				abilitiesDict.Add(ability.id, ability);
			}
			else
			{
				Utils.LogError("Duplicate item ability entry '" + ability.id + "'. Already in dictionary.");
			}
		}
		baseStats1 = SlimJson.ParseArray(itemAbilities.text, "base_stats_1");
		baseStats2 = SlimJson.ParseArray(itemAbilities.text, "base_stats_2");
		passiveAbilities = SlimJson.ParseArray(itemAbilities.text, "passive");
	}

	public bool HasLoadedAllPrefabs()
	{
		if (itemPrefabPaths.Count <= 0)
		{
			return pendingLoads <= 0;
		}
		return false;
	}

	private void Update()
	{
		if (itemPrefabPaths.Count <= 0 || pendingLoads >= 4)
		{
			return;
		}
		string path = itemPrefabPaths[0];
		itemPrefabPaths.RemoveAt(0);
		pendingLoads++;
		_LoadItemAtPath(path, delegate(string text, bool success)
		{
			pendingLoads--;
			if (!success)
			{
				itemPrefabPaths.Add(text);
				GameplayActionMessages.SetMessage("Couldn't load " + text + ", trying again.", ColorConstants.white, 7f);
			}
		});
	}

	private void _LoadItemAtPath(string path, Action<string, bool> callback, int attemptCount = 0)
	{
		GameObject gameObject = Resources.Load(path) as GameObject;
		if (gameObject != null)
		{
			AddPrefab(gameObject, path);
			callback(path, arg2: true);
			return;
		}
		AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>(path);
		LoadingAccountant.Add(loadHandler, path);
		loadHandler.Completed += delegate
		{
			if (loadHandler.Status == AsyncOperationStatus.Succeeded)
			{
				AddPrefab(loadHandler.Result, path);
				Utils.PreloadAsyncPrefab(loadHandler.Result.GetComponent<Item>().iconPath);
				callback(path, arg2: true);
			}
			else
			{
				Addressables.Release(loadHandler);
				callback(path, arg2: false);
			}
		};
	}

	public void AddPrefab(GameObject go, string path)
	{
		Item component = go.GetComponent<Item>();
		AddPrefab(component, path);
	}

	public void AddPrefab(Item itemPrefab, string path)
	{
		if (itemPrefab == null)
		{
			Utils.LogError("Loaded " + path + " but it is not an item.");
			return;
		}
		if (itemPrefabsDict.ContainsKey(itemPrefab.id))
		{
			Utils.LogError("Duplicate item with id " + itemPrefab.id + ". Replacing.");
			itemPrefabsDict[itemPrefab.id] = itemPrefab;
			return;
		}
		itemPrefabsDict.Add(itemPrefab.id, itemPrefab);
		if (itemPrefab.isLost && itemPrefab.appearInDrops)
		{
			uniqueIds.Add(itemPrefab.id);
		}
	}

	public Item GetPrefabForId(string itemId)
	{
		if (itemPrefabsDict.ContainsKey(itemId))
		{
			return itemPrefabsDict[itemId];
		}
		Utils.LogError("Could not find item prefab with id " + itemId);
		return null;
	}

	public bool IsTreasure(string itemId)
	{
		if (itemPrefabsDict.ContainsKey(itemId))
		{
			return itemPrefabsDict[itemId] is TreasureItem;
		}
		Utils.LogError("IsTreasure() Could not find item prefab with id " + itemId);
		return false;
	}

	public Item MakeItem(string itemId)
	{
		if (itemPrefabsDict.ContainsKey(itemId))
		{
			return UnityEngine.Object.Instantiate(itemPrefabsDict[itemId], base.transform);
		}
		Utils.LogError("Could not find item prefab with id " + itemId);
		return null;
	}

	public Item MakeItemWithLevel(string itemId, int level, ItemData.Rarity rarity = null)
	{
		Item item = MakeItem(itemId);
		if (item != null)
		{
			item.level = level * ComputeComplexityMultiplier(item.complexity);
		}
		if (rarity != null && rarity.type != ItemData.Rarity.Type.Common)
		{
			item.rarity = rarity;
		}
		return item;
	}

	public Item MakeItemWithLevelAndAbilities(string itemId, int level, ItemData.Element element, int rngSeed = -1, ItemData.Rarity rarity = null, List<string> extraAbilityIds = null)
	{
		Item item = MakeItemWithLevel(itemId, level, rarity);
		if (item == null)
		{
			return null;
		}
		if (element != ItemData.Element.Stone && !item.isSocketed)
		{
			Utils.LogWarningIfEditor("Tried to make item " + itemId + " with element " + element.ToString() + ", but it is not socketed. Changing to Stone.");
			element = ItemData.Element.Stone;
		}
		item.element = element;
		item.level = level * ComputeComplexityMultiplier(item.complexity, element);
		item.rngSeed = rngSeed;
		if (extraAbilityIds != null)
		{
			item.extraAbilityIds = new List<string>(extraAbilityIds);
		}
		else if (element != ItemData.Element.Stone && item.procGenAbilities)
		{
			item.extraAbilityIds = new List<string>();
			System.Random rng = ((rngSeed >= 0) ? new System.Random(rngSeed) : new System.Random());
			switch (rngSeed % 2)
			{
			case 0:
				Utils.LogIfEditor("Abilities from group 0, rngSeed = " + rngSeed);
				AddAbilityIdFromGroup(item, baseStats2, rng);
				break;
			case 1:
				Utils.LogIfEditor("Abilities from group 1, rngSeed = " + rngSeed);
				AddAbilityIdFromGroup(item, baseStats1, rng);
				AddAbilityIdFromGroup(item, passiveAbilities, rng);
				break;
			}
		}
		item.LoadAbilities();
		return item;
	}

	private void AddAbilityIdFromGroup(Item item, string[] abilityGroup, System.Random rng)
	{
		List<string> list = new List<string>();
		string value = item.element.ToString().ToLowerInvariant();
		foreach (string text in abilityGroup)
		{
			ItemData.Ability abilityById = GetAbilityById(text);
			if (Array.IndexOf(abilityById.elements, value) < 0)
			{
				continue;
			}
			for (int j = 0; j < item.tags.Count; j++)
			{
				string value2 = item.tags[j];
				if (Array.IndexOf(abilityById.items, value2) >= 0)
				{
					list.Add(text);
					Utils.LogIfEditor("Valid ability '" + text + "' for item '" + item.id + "'");
					break;
				}
			}
		}
		if (list.Count > 0)
		{
			int index = rng.Next(0, list.Count);
			string text2 = list[index];
			item.extraAbilityIds.Add(text2);
			Utils.LogIfEditor("Selected ability '" + text2 + "' for item '" + item.id + "'");
		}
		else
		{
			Utils.LogError("Couldn't find a valid ability for item " + item.id);
		}
	}

	public Item CloneItem(Item item)
	{
		ItemData.Rarity rarity = ((item.rarity != null) ? item.rarity.Clone() : null);
		Item item2 = MakeItemWithLevel(item.id, item.level, rarity);
		item2.level = item.level;
		item2.element = item.element;
		item2.rngSeed = item.rngSeed;
		item2.extraAbilityIds = item.extraAbilityIds;
		item2.isShiny = item.isShiny;
		item2.nameTag = item.nameTag;
		item2.signature = item.signature;
		item2.cosmeticId = item.cosmeticId;
		item2.cosmetic = item.cosmetic;
		if (item.isLost)
		{
			item2.isLost = true;
			item2.lostCount = item.lostCount;
			item2.lostBoostsUsed = item.lostBoostsUsed;
		}
		return item2;
	}

	public int ComputeComplexityMultiplier(int complexity, ItemData.Element element = ItemData.Element.Stone)
	{
		if (element != ItemData.Element.Stone)
		{
			complexity++;
		}
		return (int)Mathf.Pow(2f, complexity);
	}

	public Result CombineItems(Item itemA, Item itemB, int itemA_count = 1, int itemB_count = 1)
	{
		Item item = itemA;
		Item item2 = itemB;
		if (itemB.level > itemA.level)
		{
			Item item3 = itemA;
			itemA = itemB;
			itemB = item3;
			int num = itemA_count;
			itemA_count = itemB_count;
			itemB_count = num;
		}
		Result result = new Result();
		result.itemA = itemA;
		result.itemB = itemB;
		result.itemA_count = itemA_count;
		result.itemB_count = itemB_count;
		if (itemA_count > 1)
		{
			result.outcome = Result.Outcome.None;
			return result;
		}
		if (itemA.id == itemB.id && GetLevelDisplayIntegerForItem(itemA) >= MAX_DISPLAY_LEVEL)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		bool flag = itemA.id == "enchantment";
		bool flag2 = itemB.id == "enchantment";
		if (flag && flag2)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.isSigned && itemB.isSigned)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		bool flag3 = itemA.id == "shiny";
		bool flag4 = itemB.id == "shiny";
		if ((flag4 && !itemA.isShiny && !flag && !flag3) || (flag3 && !itemB.isShiny && !flag2 && !flag4))
		{
			if (flag4)
			{
				result.resultingItem = CloneItem(itemA);
			}
			else
			{
				result.resultingItem = CloneItem(itemB);
			}
			result.outcome = Result.Outcome.Fused;
			result.resultingItem.LoadAbilities();
			result.resultingItem.isShiny = true;
			if (itemA.isSigned)
			{
				result.resultingItem.signature = itemA.signature;
			}
			else if (itemB.isSigned)
			{
				result.resultingItem.signature = itemB.signature;
			}
			UpdateCosmeticReference(result.resultingItem);
			result.itemB_remainder = itemB_count - 1;
			return result;
		}
		if (flag3 || flag4)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.isShiny && itemB.isShiny)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.id != itemB.id && ((itemA.isShiny && !flag2) || (itemB.isShiny && !flag)))
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.isNamed && itemB.isNamed)
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.id != itemB.id && ((itemA.isNamed && !flag2) || (itemB.isNamed && !flag)))
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (itemA.id == itemB.id && itemA.element == itemB.element)
		{
			int num2 = itemA.level + itemB.level * itemB_count;
			float f = Mathf.Log(num2, 2f);
			int num3 = num2 - Mathf.RoundToInt(Mathf.Pow(2f, Mathf.Floor(f)));
			num2 -= num3;
			int num4 = Mathf.RoundToInt(Mathf.Pow(2f, MAX_DISPLAY_LEVEL - 1));
			int num5 = ComputeComplexityMultiplier(itemA.complexity, itemA.element);
			num4 *= num5;
			if (num2 > num4)
			{
				num3 += num2 - num4;
				num2 = num4;
			}
			result.itemB_remainder = num3 / itemB.level;
			if (num2 == itemA.level)
			{
				result.outcome = Result.Outcome.CannotFuse;
			}
			else
			{
				ItemData.Rarity rarity = CombinedRarityForItems(itemA, itemB);
				num2 /= num5;
				result.resultingItem = MakeItemWithLevelAndAbilities(itemA.id, num2, itemA.element, itemA.rngSeed, rarity, itemA.extraAbilityIds);
				result.outcome = Result.Outcome.Boosted;
				CopyAdditionalProperties(result.resultingItem, itemA, itemB);
			}
			return result;
		}
		if ((itemA.id == "runestone" && itemB.element != ItemData.Element.Stone) || (itemB.id == "runestone" && itemA.element != ItemData.Element.Stone))
		{
			result.outcome = Result.Outcome.CannotFuse;
			return result;
		}
		if (flag || flag2)
		{
			if ((flag && itemA.GetRarityBonus() > itemB.GetRarityBonus()) || (flag2 && itemA.GetRarityBonus() < itemB.GetRarityBonus()))
			{
				Item item4 = (flag ? itemB : itemA);
				string id = item4.id;
				int level = item4.level;
				ItemData.Element element = item4.element;
				int rngSeed = item4.rngSeed;
				ItemData.Rarity rarity2 = CombinedRarityForItems(itemA, itemB);
				List<string> extraAbilityIds = item4.extraAbilityIds;
				int num6 = ComputeComplexityMultiplier(item4.complexity, element);
				level /= num6;
				result.resultingItem = MakeItemWithLevelAndAbilities(id, level, element, rngSeed, rarity2, extraAbilityIds);
				if (itemB_count > 1)
				{
					result.itemB_remainder = itemB_count - 1;
				}
				result.outcome = Result.Outcome.Fused;
				if (itemA.isLost)
				{
					result.resultingItem.lostBoostsUsed = itemA.lostBoostsUsed;
					result.resultingItem.lostCount = itemA.lostCount;
				}
				CopyAdditionalProperties(result.resultingItem, itemA, itemB);
			}
			else
			{
				result.outcome = Result.Outcome.CannotFuse;
			}
			return result;
		}
		ItemCombination combinationForItems = GetCombinationForItems(itemA, itemB);
		if (combinationForItems != null)
		{
			int num7 = itemA.rngSeed;
			if (item.element != ItemData.Element.Stone)
			{
				num7 = item.rngSeed;
				if (num7 < 0)
				{
					num7 = 1;
				}
				if (num7 % 2 == 0)
				{
					num7++;
				}
			}
			else if (item2.element != ItemData.Element.Stone)
			{
				num7 = item2.rngSeed;
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num7 % 2 == 1)
				{
					num7++;
				}
			}
			ItemData.Element element2 = ((itemA.element != ItemData.Element.Stone) ? itemA.element : itemB.element);
			int num8 = itemA.level * itemA_count + itemB.level * itemB_count;
			ItemData.Rarity rarity3 = CombinedRarityForItems(itemA, itemB);
			int num9 = ComputeComplexityMultiplier(itemA.complexity, itemA.element);
			num8 /= num9;
			result.resultingItem = MakeItemWithLevelAndAbilities(combinationForItems.result, num8, element2, num7, rarity3);
			if (result.resultingItem == null)
			{
				Utils.LogError("Combination of items " + itemA.id + " and " + itemB.id + " resulted in " + combinationForItems.result + ". However, no prototype item was found with that ID.");
				result.outcome = Result.Outcome.ItemNotFound;
			}
			else
			{
				float levelDisplayValueForItem = GetLevelDisplayValueForItem(itemA);
				SetItemLevelByDisplayLevel(result.resultingItem, levelDisplayValueForItem);
				result.outcome = Result.Outcome.Fused;
				if (itemA.isSigned)
				{
					result.resultingItem.signature = itemA.signature;
				}
				else if (itemB.isSigned)
				{
					result.resultingItem.signature = itemB.signature;
				}
				ClearCosmetic(itemA);
				ClearCosmetic(itemB);
			}
			return result;
		}
		result.outcome = Result.Outcome.CannotFuse;
		return result;
	}

	private void CopyAdditionalProperties(Item resultingItem, Item itemA, Item itemB)
	{
		if (itemA.isShiny || itemB.isShiny)
		{
			resultingItem.isShiny = true;
		}
		if (itemA.isNamed)
		{
			resultingItem.nameTag = itemA.nameTag;
		}
		else if (itemB.isNamed)
		{
			resultingItem.nameTag = itemB.nameTag;
		}
		if (itemA.isSigned)
		{
			resultingItem.signature = itemA.signature;
		}
		else if (itemB.isSigned)
		{
			resultingItem.signature = itemB.signature;
		}
		if (itemA.cosmeticId != null)
		{
			resultingItem.cosmeticId = itemA.cosmeticId;
			resultingItem.cosmetic = itemA.cosmetic;
			itemA.cosmeticId = null;
			itemA.cosmetic = null;
		}
		else if (itemB.cosmeticId != null)
		{
			resultingItem.cosmeticId = itemB.cosmeticId;
			resultingItem.cosmetic = itemB.cosmetic;
			itemB.cosmeticId = null;
			itemB.cosmetic = null;
		}
		UpdateCosmeticReference(resultingItem);
	}

	public void ClearCosmetic(Item item)
	{
		if (item.cosmeticId != null)
		{
			CosmeticController.ItemEntry ownedCosmeticItemEntry = CosmeticController.singleton.GetOwnedCosmeticItemEntry(item.cosmeticId, item.id, item.element);
			if (ownedCosmeticItemEntry != null)
			{
				ownedCosmeticItemEntry.appliedGroupId = null;
			}
			item.cosmeticId = null;
			item.cosmetic = null;
		}
	}

	public void UpdateCosmeticReference(Item item)
	{
		if (item.cosmeticId != null)
		{
			CosmeticController.singleton.GetOwnedCosmeticItemEntry(item.cosmeticId, item.id, item.element).appliedGroupId = item.GetGroupId();
		}
	}

	private ItemCombination GetCombinationForItems(Item itemA, Item itemB)
	{
		float levelDisplayValueForItem = GetLevelDisplayValueForItem(itemA);
		float levelDisplayValueForItem2 = GetLevelDisplayValueForItem(itemB);
		if (Mathf.Abs(levelDisplayValueForItem - levelDisplayValueForItem2) > maxLevelDistanceToCombine)
		{
			return null;
		}
		string key = GenerateCombinedKey(itemA.id, itemB.id);
		if (combinationsDict.ContainsKey(key))
		{
			ItemCombination itemCombination = combinationsDict[key];
			if (itemCombination.IsEnabled())
			{
				return itemCombination;
			}
		}
		return null;
	}

	private ItemData.Rarity CombinedRarityForItems(Item itemA, Item itemB)
	{
		return ((itemA.GetRarityBonus() >= itemB.GetRarityBonus()) ? itemA.rarity : itemB.rarity)?.Clone();
	}

	public Result SplitItem(Item item, int count)
	{
		if (item == null || !CanSplitApart(item))
		{
			return null;
		}
		Result result = new Result();
		result.resultingItem = item;
		result.itemA_count = count;
		result.itemB_count = count;
		string id = item.id;
		int level = item.level;
		ItemData.Element element = item.element;
		int rngSeed = item.rngSeed;
		int num = ComputeComplexityMultiplier(item.complexity, element);
		level /= num;
		if (item.GetRarityType() != ItemData.Rarity.Type.Common)
		{
			ItemData.Rarity rarity = item.rarity;
			List<string> extraAbilityIds = item.extraAbilityIds;
			result.itemA = MakeItemWithLevelAndAbilities(id, level, element, rngSeed, null, extraAbilityIds);
			result.itemB = MakeItemWithLevel("enchantment", 1, rarity);
			result.itemA.isShiny = item.isShiny;
			if (item.isLost)
			{
				result.itemA.lostBoostsUsed = item.lostBoostsUsed;
				result.itemA.lostCount = item.lostCount;
			}
			result.itemA.nameTag = item.nameTag;
			result.itemA.signature = item.signature;
			if (item.cosmeticId != null)
			{
				result.itemA.cosmeticId = item.cosmeticId;
				result.itemA.cosmetic = item.cosmetic;
				UpdateCosmeticReference(result.itemA);
			}
			return result;
		}
		if (item.isLost)
		{
			return null;
		}
		ClearCosmetic(item);
		if (element != ItemData.Element.Stone && item.isSocketed && id != "runestone")
		{
			ItemData.Rarity rarity2 = item.rarity;
			result.itemA = MakeItemWithLevelAndAbilities(id, level, ItemData.Element.Stone, rngSeed);
			result.itemB = MakeItemWithLevelAndAbilities("runestone", level, element, rngSeed, rarity2);
			return result;
		}
		if (item.complexity > 0)
		{
			for (int i = 0; i < allCombinations.Length; i++)
			{
				ItemCombination itemCombination = allCombinations[i];
				if (itemCombination.result == id && itemCombination.IsEnabled())
				{
					result.itemA = MakeItemWithLevelAndAbilities(itemCombination.itemA, level, element, rngSeed);
					result.itemB = MakeItemWithLevelAndAbilities(itemCombination.itemB, level, element, rngSeed);
					return result;
				}
			}
		}
		if (level <= 1)
		{
			Utils.LogErrorIfEditor("Combination not found for splitting item " + item);
			return null;
		}
		int num2 = level;
		int num3 = count;
		while (num2 > 2)
		{
			num2 /= 2;
			num3 *= 2;
		}
		result.itemA = MakeItemWithLevelAndAbilities(id, 1, element, rngSeed, null, item.extraAbilityIds);
		result.itemB = result.itemA;
		result.itemA_count = num3;
		result.itemB_count = num3;
		return result;
	}

	public static bool CanSplitApart(Item item)
	{
		if (item == null)
		{
			return false;
		}
		if ((item.isShiny || item.isLost || item.isNamed || item.isSigned) && item.GetRarityType() == ItemData.Rarity.Type.Common)
		{
			return false;
		}
		if (item.complexity <= 0 && item.level <= 1 && (item.GetRarityBonus() <= 0 || !(item.id != "enchantment")))
		{
			if (item.element != ItemData.Element.Stone && item.isSocketed)
			{
				return item.id != "runestone";
			}
			return false;
		}
		return true;
	}

	public FuseResult FuseEnchantments(Item primaryItem, Item boostItemA, Item boostItemB, Item boostItemC)
	{
		FuseResult fuseResult = new FuseResult();
		fuseResult.primaryItem = primaryItem;
		fuseResult.boostItemA = boostItemA;
		fuseResult.boostItemB = boostItemB;
		fuseResult.boostItemC = boostItemC;
		fuseResult.resultPrimaryItem = primaryItem;
		fuseResult.resultBoostItemA = boostItemA;
		fuseResult.resultBoostItemB = boostItemB;
		fuseResult.resultBoostItemC = boostItemC;
		if (primaryItem == null || boostItemA == null || boostItemB == null || boostItemC == null || primaryItem.rarity == null || boostItemA.rarity == null || boostItemB.rarity == null || boostItemC.rarity == null)
		{
			fuseResult.outcome = FuseResult.Outcome.None;
			return fuseResult;
		}
		if (primaryItem.GetRarityBonus() == 21)
		{
			fuseResult.outcome = FuseResult.Outcome.AlreadyMax;
			return fuseResult;
		}
		int totalQuality = primaryItem.rarity.quality;
		fuseResult.resultBoostItemA = ProcessEnchantmentBoost(boostItemA, ref totalQuality);
		fuseResult.resultBoostItemB = ProcessEnchantmentBoost(boostItemB, ref totalQuality);
		fuseResult.resultBoostItemC = ProcessEnchantmentBoost(boostItemC, ref totalQuality);
		int bonusForQuality = ItemData.Rarity.GetBonusForQuality(totalQuality);
		fuseResult.resultPrimaryItem = CloneWithNewQualityValues(primaryItem, totalQuality, bonusForQuality);
		fuseResult.outcome = FuseResult.Outcome.Fused;
		return fuseResult;
	}

	private Item ProcessEnchantmentBoost(Item boostItem, ref int totalQuality)
	{
		int qualityThreshold = ItemData.Rarity.GetQualityThreshold(21);
		if (totalQuality < qualityThreshold)
		{
			totalQuality += boostItem.rarity.quality;
			if (totalQuality > qualityThreshold)
			{
				int quality = totalQuality - qualityThreshold;
				int bonusForQuality = ItemData.Rarity.GetBonusForQuality(quality);
				totalQuality = qualityThreshold;
				return CloneWithNewQualityValues(boostItem, quality, bonusForQuality);
			}
			if (boostItem.id == "enchantment")
			{
				return null;
			}
			return MakeCommonVersionOfItem(boostItem);
		}
		return boostItem;
	}

	private Item CloneWithNewQualityValues(Item sourceItem, int quality, int rarityBonus)
	{
		Item item = CloneItem(sourceItem);
		item.rarity.quality = quality;
		item.rarity.levelBonus = rarityBonus;
		item.rarity.type = ItemData.Rarity.GetTypeForBonus(rarityBonus);
		item.rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(rarityBonus);
		item.LoadAbilities();
		UpdateCosmeticReference(item);
		return item;
	}

	private Item MakeCommonVersionOfItem(Item sourceItem)
	{
		Item item = CloneItem(sourceItem);
		item.rarity = null;
		item.LoadAbilities();
		UpdateCosmeticReference(item);
		return item;
	}

	public static int CalculateItemLevelFromDisplayLevel(float itemLevel)
	{
		return Mathf.CeilToInt(Mathf.Pow(2f, itemLevel - 1f));
	}

	public static float GetLevelDisplayValueForItem(Item item, bool subtractComplexity = true)
	{
		float num = item.level;
		if (subtractComplexity)
		{
			int num2 = item.complexity;
			if (item.element != ItemData.Element.Stone)
			{
				num2++;
			}
			num /= Mathf.Pow(2f, num2);
		}
		return 1f + Mathf.Log(num, 2f);
	}

	public static void SetItemLevelByDisplayLevel(Item item, float displayLevel)
	{
		int num = item.complexity;
		if (item.element != ItemData.Element.Stone)
		{
			num++;
		}
		displayLevel += (float)num;
		int level = Mathf.CeilToInt(Mathf.Pow(2f, displayLevel - 1f));
		item.level = level;
	}

	public static string GetLevelDisplayStringForItem(Item item)
	{
		if (item.level == 0)
		{
			return "0";
		}
		float levelDisplayValueForItem = GetLevelDisplayValueForItem(item);
		if (levelDisplayValueForItem - Mathf.Floor(levelDisplayValueForItem) < 0.01f)
		{
			return Mathf.FloorToInt(levelDisplayValueForItem).ToString();
		}
		return levelDisplayValueForItem.ToString("n2");
	}

	public static int GetLevelDisplayIntegerForItem(Item item)
	{
		if (item.level == 0)
		{
			return 0;
		}
		return Mathf.FloorToInt(GetLevelDisplayValueForItem(item));
	}

	public static string GetStarRatingStringForItem(Item item)
	{
		int levelDisplayIntegerForItem = GetLevelDisplayIntegerForItem(item);
		if (item.isLost && levelDisplayIntegerForItem < 11)
		{
			return "☆" + (levelDisplayIntegerForItem - 1) + "☆";
		}
		return GetStarRatingStringForDisplayLevel(levelDisplayIntegerForItem);
	}

	public static string GetStarRatingStringForDisplayLevel(int displayLevel)
	{
		return displayLevel switch
		{
			2 => "☆", 
			3 => "☆☆", 
			4 => "☆☆☆", 
			5 => "☆☆☆☆", 
			6 => "☆☆☆☆☆", 
			7 => "☆·6·☆", 
			8 => "☆·7·☆", 
			9 => "☆·8·☆", 
			10 => "☆·9·☆", 
			11 => Te.xt("☆MAX☆"), 
			_ => "", 
		};
	}

	public ItemData.Ability GetAbilityById(string abilityId)
	{
		if (abilitiesDict.ContainsKey(abilityId))
		{
			return abilitiesDict[abilityId];
		}
		if (abilityId.Contains("+"))
		{
			string[] array = abilityId.Split(new char[1] { '+' });
			string text = array[0];
			ItemData.Ability abilityById = singleton.GetAbilityById(text);
			if (abilityById != null)
			{
				string text2 = array[1];
				ItemData.Ability abilityById2 = singleton.GetAbilityById(text2);
				if (abilityById2 != null)
				{
					abilityById = abilityById.Clone();
					abilityById.id = abilityId;
					abilitiesDict.Add(abilityId, abilityById);
					abilityById.subAbility = abilityById2;
					return abilityById;
				}
				Utils.LogError("Could not find sub-ability " + text2);
			}
			else
			{
				Utils.LogError("Could not find parent ability " + text);
			}
		}
		Utils.LogError("Could not find ability with id '" + abilityId + "'");
		return null;
	}

	private string GenerateCombinedKey(string itemA_id, string itemB_id)
	{
		if (string.Compare(itemA_id, itemB_id) < 0)
		{
			return itemA_id + "_" + itemB_id;
		}
		return itemB_id + "_" + itemA_id;
	}

	public Item RerollEnchantment(Item item)
	{
		Item item2 = CloneItem(item);
		int selectedStatSeed = item2.rarity.selectedStatSeed;
		int num = new System.Random(selectedStatSeed).Next(0, 999999);
		int totalAbilityCount = item.GetTotalAbilityCount();
		if (totalAbilityCount >= 1 && num % totalAbilityCount == selectedStatSeed % totalAbilityCount)
		{
			num++;
		}
		item2.rarity.selectedStatSeed = num;
		item2.LoadAbilities();
		UpdateCosmeticReference(item2);
		return item2;
	}

	public Item MakeEnchantmentWithBonus(int rarityBonus)
	{
		ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.GetTypeForBonus(rarityBonus));
		rarity.levelBonus = rarityBonus;
		rarity.quality = ItemData.Rarity.GetQualityThreshold(rarityBonus);
		rarity.isPerfect = ItemData.Rarity.IsBonusPerfect(rarityBonus);
		return MakeItemWithLevel("enchantment", 1, rarity);
	}

	public Item ApplyNameTag(Item item, string newNameTag)
	{
		Item item2 = CloneItem(item);
		item2.nameTag = newNameTag;
		item2.hasInteracted = false;
		item2.LoadAbilities();
		UpdateCosmeticReference(item2);
		return item2;
	}

	private void Awake()
	{
		singleton = this;
		try
		{
			LoadItemDataFromText();
		}
		catch (Exception ex)
		{
			Utils.LogError(ex.StackTrace);
		}
	}
}
