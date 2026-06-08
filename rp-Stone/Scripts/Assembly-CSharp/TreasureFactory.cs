using System;
using System.Collections.Generic;
using UnityEngine;

public class TreasureFactory : MonoBehaviour
{
	public TextAsset treasureDescriptions;

	public string treasureDrop0;

	public string treasureDrop1;

	public string treasureDrop2;

	public string treasureDrop3;

	public string treasureDrop4;

	public string treasureDropGold;

	private Data.AllTreasureData treasureData;

	private Dictionary<string, Data.Treasure> treasuresById;

	private Dictionary<string, Data.TreasureDropCollection> treasureCollectionsById;

	private int[] rarityChancesFTUE;

	private int[] rarityChancesHumbleTreasure = new int[7] { 122880, 1024, 64, 0, 0, 0, 0 };

	private int[] rarityChancesCommonTreasure = new int[7] { 109600, 1024, 61, 11, 0, 0, 0 };

	private int[] rarityChancesGiantTreasure = new int[7] { 15800, 2180, 158, 32, 0, 0, 0 };

	private int[] rarityChancesRareTreasure = new int[7] { 1000, 530, 240, 27, 3, 0, 0 };

	private int[] rarityChancesEpicTreasure = new int[7] { 200, 26, 90, 69, 14, 1, 0 };

	private int[] rarityChancesSkullTreasure = new int[7] { 400, 50, 240, 101, 8, 1, 0 };

	public AnimationCurve uniqueP;

	public float uniqueCoeficient;

	public float goldCoeficient;

	private DateTime uniqueDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);

	private DateTime crystalDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);

	private DateTime goldDate = DateTime.Now - new TimeSpan(15, 0, 0, 0);

	private readonly bool UNIQUE_ENABLED = true;

	private static System.Random _random = new System.Random();

	public static TreasureFactory singleton { get; private set; }

	public TreasureItem MakeTreasureItem(string shopId, string treasureId, List<ItemData.Element> possibleElements, Data.ItemInTreasure[] itemsInTreasure = null)
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem(treasureId) as TreasureItem;
		switch (treasureId)
		{
		case "humble":
		case "treasure_0":
			treasureItem.type = TreasureItem.Type.Humble;
			break;
		case "giant":
		case "treasure_2":
			treasureItem.type = TreasureItem.Type.Giant;
			break;
		case "rare":
		case "treasure_3":
			treasureItem.type = TreasureItem.Type.Rare;
			break;
		case "epic":
		case "treasure_4":
			treasureItem.type = TreasureItem.Type.Epic;
			break;
		case "bone":
			treasureItem.type = TreasureItem.Type.Bone;
			break;
		case "lost":
			treasureItem.type = TreasureItem.Type.Lost;
			break;
		case "ki_treasure":
			treasureItem.type = TreasureItem.Type.Ki;
			break;
		case "treasure_gold":
			treasureItem.type = TreasureItem.Type.Gold;
			break;
		case "skullnata":
			treasureItem.type = TreasureItem.Type.Skullnata;
			break;
		case "emerald_egg":
			treasureItem.type = TreasureItem.Type.Emerald;
			break;
		case "sapphire_egg":
			treasureItem.type = TreasureItem.Type.Sapphire;
			break;
		case "ruby_egg":
			treasureItem.type = TreasureItem.Type.Ruby;
			break;
		case "treasure_prismatic":
			treasureItem.type = TreasureItem.Type.Prismatic;
			break;
		case "quest_aether_treasure":
			treasureItem.type = TreasureItem.Type.Element;
			possibleElements = new List<ItemData.Element> { ItemData.Element.AEther };
			break;
		case "quest_fire_treasure":
			treasureItem.type = TreasureItem.Type.Element;
			possibleElements = new List<ItemData.Element> { ItemData.Element.Fire };
			break;
		case "quest_ice_treasure":
			treasureItem.type = TreasureItem.Type.Element;
			possibleElements = new List<ItemData.Element> { ItemData.Element.Ice };
			break;
		case "quest_poison_treasure":
			treasureItem.type = TreasureItem.Type.Element;
			possibleElements = new List<ItemData.Element> { ItemData.Element.Poison };
			break;
		case "quest_vigor_treasure":
			treasureItem.type = TreasureItem.Type.Element;
			possibleElements = new List<ItemData.Element> { ItemData.Element.Vigor };
			break;
		default:
			treasureItem.type = TreasureItem.Type.Common;
			break;
		}
		if (itemsInTreasure != null)
		{
			treasureItem.itemsInTreasure = itemsInTreasure;
		}
		else
		{
			treasureItem.itemsInTreasure = MakeShopTreasureData(shopId, treasureItem.type, possibleElements);
		}
		return treasureItem;
	}

	public List<ItemData.Element> MakeListOfPossibleElements()
	{
		List<ItemData.Element> list = new List<ItemData.Element>();
		list.Add(ItemData.Element.Poison);
		if (QuestController.singleton.IsAvailable("fungus_forest"))
		{
			list.Add(ItemData.Element.Vigor);
		}
		if (QuestController.singleton.IsAvailable("undead_crypt"))
		{
			list.Add(ItemData.Element.AEther);
		}
		if (QuestController.singleton.IsAvailable("bronze_mine"))
		{
			list.Add(ItemData.Element.Fire);
		}
		if (QuestController.singleton.IsAvailable("mountain_climb"))
		{
			list.Add(ItemData.Element.Air);
		}
		if (QuestController.singleton.IsAvailable("icy_ridge"))
		{
			list.Add(ItemData.Element.Ice);
		}
		return list;
	}

	public Data.ItemInTreasure[] MakeShopTreasureData(string shopId, TreasureItem.Type type, List<ItemData.Element> possibleElements)
	{
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>();
		if (type >= TreasureItem.Type.Humble && type <= TreasureItem.Type.Element)
		{
			shopId = "mushroom_shop";
		}
		else if (type == TreasureItem.Type.Lost || type == TreasureItem.Type.Gold || type == TreasureItem.Type.Prismatic || type == TreasureItem.Type.Skullnata)
		{
			shopId = "uulaa_shop";
		}
		ShopData shopById = ShopController.singleton.GetShopById(shopId);
		int[] rarityChancesForTreasureType = GetRarityChancesForTreasureType(type);
		switch (type)
		{
		case TreasureItem.Type.Epic:
		{
			bool flag = false;
			if (EvalUnique())
			{
				Data.ItemInTreasure itemInTreasure = MakeRandomUniqueForTreasure();
				if (itemInTreasure != null)
				{
					flag = true;
					list.Add(itemInTreasure);
				}
			}
			else if (EvalCrystal())
			{
				flag = true;
				list.Add(MakeCrystalsForTreasure(5, 10));
				crystalDate = DateTime.Now;
			}
			if (!flag)
			{
				if (ABTesting.ItemDropSimpler())
				{
					list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_delta", rarityChancesForTreasureType, possibleElements));
				}
				else
				{
					list.AddRange(MakeItemsForTreasure(shopById, 1, "all", rarityChancesForTreasureType, possibleElements));
				}
			}
			break;
		}
		case TreasureItem.Type.Lost:
		{
			Data.ItemInTreasure itemInTreasure2 = MakeRandomUniqueForTreasure();
			if (itemInTreasure2 != null)
			{
				list.Add(itemInTreasure2);
			}
			else
			{
				list.Add(MakeCrystalsForTreasure(5, 10));
			}
			break;
		}
		case TreasureItem.Type.Skullnata:
			AddSkullnataItems(list, shopById, rarityChancesForTreasureType, possibleElements);
			break;
		case TreasureItem.Type.Gold:
		case TreasureItem.Type.Prismatic:
			list.Add(new Data.ItemInTreasure());
			break;
		case TreasureItem.Type.Ki:
			list.Add(MakeCrystalsForTreasure(5, 10));
			list.Add(MakeKiForTreasure());
			break;
		case TreasureItem.Type.Rare:
			if (ABTesting.ItemDropSimpler())
			{
				list.AddRange(MakeItemsForTreasure(shopById, 5, "v2_common", null, possibleElements));
				list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_complex", rarityChancesForTreasureType, possibleElements));
			}
			else
			{
				list.AddRange(MakeItemsForTreasure(shopById, 6, "all", rarityChancesForTreasureType, possibleElements));
			}
			break;
		case TreasureItem.Type.Giant:
			if (ABTesting.ItemDropSimpler())
			{
				if (RNG(0.05f))
				{
					list.AddRange(MakeItemsForTreasure(shopById, 11, "v2_common", null, possibleElements));
					list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_complex", rarityChancesForTreasureType, possibleElements));
				}
				else
				{
					list.AddRange(MakeItemsForTreasure(shopById, 12, "v2_common", rarityChancesForTreasureType, possibleElements));
				}
			}
			else
			{
				list.AddRange(MakeItemsForTreasure(shopById, 12, "all", rarityChancesForTreasureType, possibleElements));
			}
			break;
		case TreasureItem.Type.Bone:
			if (ABTesting.ItemDropSimpler())
			{
				if (RNG(0.05f))
				{
					list.AddRange(MakeItemsForTreasure(shopById, 15, "v2_common", null, possibleElements));
					list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_complex", rarityChancesForTreasureType, possibleElements));
				}
				else
				{
					list.AddRange(MakeItemsForTreasure(shopById, 16, "v2_common", rarityChancesForTreasureType, possibleElements));
				}
			}
			else
			{
				list.AddRange(MakeItemsForTreasure(shopById, 16, "all", rarityChancesForTreasureType, possibleElements));
			}
			break;
		case TreasureItem.Type.Humble:
			if (ABTesting.ItemDropSimpler())
			{
				if (RNG(0.3f))
				{
					list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_common", rarityChancesForTreasureType));
				}
				else
				{
					list.AddRange(MakeItemsForTreasure(shopById, 1, "v2_humble", rarityChancesForTreasureType));
				}
			}
			else if (RNG(0.1f))
			{
				list.AddRange(MakeItemsForTreasure(shopById, 1, "rare", rarityChancesForTreasureType, possibleElements));
			}
			else if (RNG(0.2f))
			{
				list.AddRange(MakeItemsForTreasure(shopById, 1, "uncommon", rarityChancesForTreasureType));
			}
			else
			{
				list.AddRange(MakeItemsForTreasure(shopById, 1, "common", rarityChancesForTreasureType));
			}
			break;
		case TreasureItem.Type.Element:
			list.AddRange(MakeItemsForTreasure(shopById, 4, "day0rune", null, possibleElements));
			list.AddRange(MakeItemsForTreasure(shopById, 2, "day0wand", null, possibleElements));
			list.AddRange(MakeItemsForTreasure(shopById, 2, "v2_complex", null, possibleElements));
			break;
		default:
			if (ABTesting.ItemDropSimpler())
			{
				list.AddRange(MakeItemsForTreasure(shopById, 3, "v2_common", rarityChancesForTreasureType, possibleElements));
			}
			else
			{
				list.AddRange(MakeItemsForTreasure(shopById, 3, "all", rarityChancesForTreasureType, possibleElements));
			}
			break;
		}
		if (type != TreasureItem.Type.Skullnata)
		{
			list.Sort((Data.ItemInTreasure a, Data.ItemInTreasure b) => a.rarityType.CompareTo(b.rarityType));
		}
		return list.ToArray();
	}

	private void AddSkullnataItems(List<Data.ItemInTreasure> items, ShopData shopData, int[] rarityChances, List<ItemData.Element> possibleElements)
	{
		string[] array = new string[5] { "ki", "stone", "wood", "tar", "bronze" };
		int num = Utils.random.Next(array.Length);
		int count = Utils.random.Next(10, 51);
		items.Add(MakeOneItemForTreasure(array[num], 1, count, null));
		count = Utils.random.Next(2, 6);
		if (Utils.random.Next(6) == 0)
		{
			items.Add(MakeOneItemForTreasure("wand", 1, count, null));
		}
		else
		{
			items.Add(MakeOneItemForTreasure("runestone", 1, count, possibleElements));
		}
		items.AddRange(MakeItemsForTreasure(shopData, 1, "skullnata", rarityChances));
		items.Add(MakeOneItemForTreasure("event_ticket", 1, 1, null));
		num = Utils.random.Next(9);
		if (num != 0)
		{
			if (num == 1)
			{
				items.Add(MakeOneItemForTreasure("moonbloom_petal", 1, 1, null));
			}
			else if (num == 2)
			{
				items.Add(MakeOneItemForTreasure("name_tag", 1, 1, null));
			}
			else if (num == 3 || num == 4)
			{
				items.Add(MakeOneItemForTreasure("ki_crystal", 1, 1, null));
			}
			else if (num >= 5)
			{
				count = Utils.random.Next(1, 5);
				items.Add(MakeOneItemForTreasure("crystal_powder", 1, count, null));
			}
		}
	}

	private Data.ItemInTreasure[] MakeItemsForTreasure(ShopData shopData, int itemCount, string permutableEntriesKey, int[] rarityChances, List<ItemData.Element> possibleElements = null)
	{
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>();
		string[] entries = shopData.permutableEntriesDict[permutableEntriesKey].entries;
		List<string> list2 = new List<string>(entries.Length);
		foreach (string text in entries)
		{
			if (shopData.entriesDict.ContainsKey(text))
			{
				if (shopData.entriesDict[text].EvaluateRequirements())
				{
					list2.Add(text);
				}
			}
			else
			{
				Utils.LogError("Treasure Factory wants to make item " + text + " but the shop is missing that entry.");
			}
		}
		if (list2.Count == 0)
		{
			Utils.LogError("Insufficient itemIds to make items for treasure");
		}
		else
		{
			int num = itemCount;
			ItemData.Rarity.Type type = SelectRarity(rarityChances);
			while (num > 0 && list2.Count > 0)
			{
				if (type != ItemData.Rarity.Type.Common)
				{
					num--;
					int index = _random.Next(0, list2.Count);
					string itemId = list2[index];
					list.Add(MakeOneItemForTreasure(itemId, 1, 1, possibleElements, type));
					type = ItemData.Rarity.Type.Common;
					continue;
				}
				int num2;
				if (list2.Count == 1 || num == 1 || num < itemCount / 5)
				{
					num2 = num;
					num = 0;
				}
				else
				{
					num2 = num / 2;
					if (RNG(0.5f))
					{
						num2++;
					}
					num -= num2;
				}
				int index2 = _random.Next(0, list2.Count);
				string text2 = list2[index2];
				while (list2.Contains(text2))
				{
					list2.Remove(text2);
				}
				list.Add(MakeOneItemForTreasure(text2, 1, num2, possibleElements));
			}
		}
		return list.ToArray();
	}

	public Data.ItemInTreasure MakeOneItemForTreasure(string itemId, int level, int count, List<ItemData.Element> possibleElements, ItemData.Rarity.Type rarity = ItemData.Rarity.Type.Common)
	{
		if (itemId == "runestone" && (possibleElements == null || possibleElements.Count == 0))
		{
			itemId = "wand";
		}
		Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
		itemInTreasure.id = itemId;
		itemInTreasure.level = level;
		itemInTreasure.countMin = count;
		itemInTreasure.countMax = count;
		itemInTreasure.rarityType = rarity;
		itemInTreasure.rngSeed = _random.Next(0, 999999);
		if (possibleElements != null && possibleElements.Count > 0)
		{
			int index = _random.Next(0, possibleElements.Count);
			itemInTreasure.element = possibleElements[index];
		}
		else
		{
			itemInTreasure.element = ItemData.Element.Stone;
		}
		return itemInTreasure;
	}

	public Data.ItemInTreasure MakeRandomUniqueForTreasure()
	{
		List<string> list = new List<string>(ItemFactory.singleton.uniqueIds);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			string text = list[num];
			Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(text);
			if (firstItemWithId != null)
			{
				int num2 = 32;
				if (firstItemWithId.lostCount >= num2)
				{
					list.RemoveAt(num);
					continue;
				}
			}
			ShopData shopById = ShopController.singleton.GetShopById("uulaa_shop");
			if (shopById.entriesDict.ContainsKey(text) && !shopById.entriesDict[text].EvaluateRequirements())
			{
				list.RemoveAt(num);
			}
		}
		uniqueDate = DateTime.Now;
		if (list.Count == 0)
		{
			return MakeCrystalsForTreasure(5, 10);
		}
		int index = Utils.random.Next(0, list.Count);
		string itemId = list[index];
		return MakeUniqueForTreasure(itemId);
	}

	public Data.ItemInTreasure MakeUniqueForTreasure(string itemId)
	{
		return new Data.ItemInTreasure
		{
			id = itemId,
			level = 6
		};
	}

	private Data.ItemInTreasure MakeCrystalsForTreasure(int minInclusive = 1, int maxExclusive = 5)
	{
		int count = Utils.random.Next(minInclusive, maxExclusive);
		return MakeOneItemForTreasure("ki_crystal", 1, count, null);
	}

	private Data.ItemInTreasure MakeKiForTreasure()
	{
		int count = Utils.random.Next(500, 5000);
		return MakeOneItemForTreasure("ki", 1, count, null);
	}

	private bool EvalUnique()
	{
		if (!UNIQUE_ENABLED)
		{
			return false;
		}
		float num = uniqueCoeficient;
		EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (activeAndStartedEvent != null && activeAndStartedEvent.uniqueCoeficient > 0f && (string.IsNullOrEmpty(activeAndStartedEvent.uniqueLocation) || (questData != null && questData.id.StartsWith(activeAndStartedEvent.uniqueLocation, StringComparison.InvariantCulture))))
		{
			num = activeAndStartedEvent.uniqueCoeficient;
		}
		double totalHours = (DateTime.Now - uniqueDate).TotalHours;
		return RNG(uniqueP.Evaluate((float)totalHours * num));
	}

	private bool EvalCrystal()
	{
		float num = uniqueCoeficient;
		double totalHours = (DateTime.Now - crystalDate).TotalHours;
		return RNG(uniqueP.Evaluate((float)totalHours * num));
	}

	private bool EvalGold()
	{
		float num = goldCoeficient;
		double totalHours = (DateTime.Now - goldDate).TotalHours;
		return RNG(uniqueP.Evaluate((float)totalHours * num));
	}

	private int[] GetRarityChancesForTreasureType(TreasureItem.Type treasureType)
	{
		switch (treasureType)
		{
		case TreasureItem.Type.Epic:
			return rarityChancesEpicTreasure;
		case TreasureItem.Type.Rare:
			return rarityChancesRareTreasure;
		default:
			if (!QuestController.singleton.IsAvailable("fungus_forest"))
			{
				return rarityChancesFTUE;
			}
			return treasureType switch
			{
				TreasureItem.Type.Bone => rarityChancesRareTreasure, 
				TreasureItem.Type.Giant => rarityChancesGiantTreasure, 
				TreasureItem.Type.Humble => rarityChancesHumbleTreasure, 
				TreasureItem.Type.Skullnata => rarityChancesSkullTreasure, 
				_ => rarityChancesCommonTreasure, 
			};
		}
	}

	private ItemData.Rarity.Type SelectRarity(int[] rarityChances)
	{
		if (rarityChances != null && rarityChances.Length != 0)
		{
			ItemData.Rarity.Type type = ItemData.Rarity.Type.Transcendent;
			int maxValue = rarityChances[0];
			int num = _random.Next(0, maxValue);
			int num2 = rarityChances.Length - 1;
			while (num2 >= 0 && type > ItemData.Rarity.Type.Common)
			{
				if (num < rarityChances[num2])
				{
					return type;
				}
				num -= rarityChances[num2];
				type--;
				num2--;
			}
		}
		return ItemData.Rarity.Type.Common;
	}

	private static bool RNG(float chance)
	{
		return _random.NextDouble() >= (double)(1f - chance);
	}

	public void SetSeed(int seed)
	{
		_random = new System.Random(seed);
	}

	public void SetRandom(System.Random randomObj)
	{
		_random = randomObj;
	}

	public float[] GetTreasureProbabilities(string treasureId, int starDifficulty, string questId)
	{
		float[] array = new float[6];
		if (treasureCollectionsById.ContainsKey(treasureId))
		{
			Data.TreasureDropCollection treasureDropCollection = treasureCollectionsById[treasureId];
			int num = 0;
			for (int i = 0; i < treasureDropCollection.drops.Length; i++)
			{
				num += treasureDropCollection.drops[i].incidence;
			}
			for (int j = 0; j < treasureDropCollection.drops.Length; j++)
			{
				float[] treasureProbabilities = GetTreasureProbabilities(treasureDropCollection.drops[j].treasureId, starDifficulty, questId);
				for (int k = 0; k < treasureProbabilities.Length; k++)
				{
					array[k] += treasureProbabilities[k] * (float)treasureDropCollection.drops[j].incidence / (float)num;
				}
			}
			return array;
		}
		Data.Treasure treasure = treasuresById[treasureId];
		if (treasure.chanceCommon == 0f && treasure.chanceGiant == 0f && treasure.chanceRare == 0f && treasure.chanceEpic == 0f)
		{
			array[(int)treasure.type] = 1f;
		}
		else
		{
			int num2 = (starDifficulty - 1) % 5 + 1;
			array[5] = treasure.chanceGold + treasure.chanceGoldPerStar * (float)num2;
			array[4] = treasure.chanceEpic + treasure.chanceEpicPerStar * (float)num2;
			array[3] = treasure.chanceRare + treasure.chanceRarePerStar * (float)num2;
			array[2] = treasure.chanceGiant + treasure.chanceGiantPerStar * (float)num2;
			array[1] = treasure.chanceCommon + treasure.chanceCommonPerStar * (float)num2;
			array[0] = 1f - array[1] - array[2] - array[3] - array[4] - array[5];
			float eventCoeficient = GetEventCoeficient(questId);
			if (eventCoeficient > 1f)
			{
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 1f / eventCoeficient;
				for (int num6 = array.Length - 1; num6 >= 0; num6--)
				{
					float num7 = array[num6];
					if (num4 + num7 > num5)
					{
						break;
					}
					float num8 = num7 * eventCoeficient;
					num4 += num7;
					num3 += num8 - num7;
					array[num6] = num8;
				}
				for (int l = 0; l < array.Length; l++)
				{
					if (array[l] <= num3)
					{
						num3 -= array[l];
						array[l] = 0f;
						continue;
					}
					array[l] -= num3;
					break;
				}
			}
		}
		return array;
	}

	public Data.Treasure GetTreasureWithId(string treasureId)
	{
		int level = GameStates.Singleton.level.QuestData.level;
		return GetTreasureWithId(treasureId, level);
	}

	public Data.Treasure GetTreasureWithId(string treasureId, int starDifficulty, string questId = null)
	{
		if (treasureCollectionsById.ContainsKey(treasureId))
		{
			Data.TreasureDropCollection treasureDropCollection = treasureCollectionsById[treasureId];
			int num = 0;
			for (int i = 0; i < treasureDropCollection.drops.Length; i++)
			{
				num += treasureDropCollection.drops[i].incidence;
			}
			int num2 = _random.Next(0, num);
			for (int j = 0; j < treasureDropCollection.drops.Length; j++)
			{
				if (num2 < treasureDropCollection.drops[j].incidence)
				{
					string treasureId2 = treasureDropCollection.drops[j].treasureId;
					if (treasuresById.ContainsKey(treasureId2))
					{
						return GetTreasureWithId(treasureId2, starDifficulty, questId);
					}
					Utils.LogError("Could not find treasure with id = " + treasureDropCollection.drops[j].treasureId + " from collection " + treasureDropCollection.collectionId);
					return null;
				}
				num2 -= treasureDropCollection.drops[j].incidence;
			}
		}
		else if (treasuresById.ContainsKey(treasureId))
		{
			Data.Treasure treasure = treasuresById[treasureId];
			if (treasure.items == null || treasure.items.Length == 0)
			{
				treasure = MakeRandomTreasureType(treasure, starDifficulty, questId);
			}
			return treasure;
		}
		Utils.LogError("Could not find treasure with id " + treasureId);
		return null;
	}

	private Data.Treasure MakeRandomTreasureType(Data.Treasure treasureData, int starDifficulty, string questId = null)
	{
		Data.Treasure treasure = new Data.Treasure();
		treasure.id = treasureData.id;
		int num = (starDifficulty - 1) % 5 + 1;
		double num2 = _random.NextDouble();
		float num3 = treasureData.chanceGold + treasureData.chanceGoldPerStar * (float)num;
		if (num2 < (double)num3 && EvalGold())
		{
			treasure.type = TreasureItem.Type.Gold;
			treasure.items = new Data.ItemInTreasure[1]
			{
				new Data.ItemInTreasure()
			};
			return treasure;
		}
		List<ItemData.Element> list = new List<ItemData.Element>();
		if (treasureData.elements != null)
		{
			list.AddRange(treasureData.elements);
		}
		else if (treasureData.element != ItemData.Element.Stone)
		{
			list.Add(treasureData.element);
		}
		if (questId == null && GameStates.Singleton.level.QuestData != null)
		{
			questId = GameStates.Singleton.level.QuestData.id;
		}
		if (questId != null)
		{
			num2 /= (double)GetEventCoeficient(questId);
		}
		float num4 = treasureData.chanceEpic + treasureData.chanceEpicPerStar * (float)num;
		if (num2 > (double)num4)
		{
			num2 -= (double)num4;
			float num5 = treasureData.chanceRare + treasureData.chanceRarePerStar * (float)num;
			if (num2 > (double)num5)
			{
				num2 -= (double)num5;
				float num6 = treasureData.chanceGiant + treasureData.chanceGiantPerStar * (float)num;
				if (num2 > (double)num6)
				{
					num2 -= (double)num6;
					float num7 = treasureData.chanceCommon + treasureData.chanceCommonPerStar * (float)num;
					if (num2 > (double)num7)
					{
						treasure.type = TreasureItem.Type.Humble;
					}
					else
					{
						treasure.type = TreasureItem.Type.Common;
					}
				}
				else
				{
					treasure.type = TreasureItem.Type.Giant;
				}
			}
			else
			{
				treasure.type = TreasureItem.Type.Rare;
			}
		}
		else
		{
			treasure.type = TreasureItem.Type.Epic;
		}
		treasure.items = MakeShopTreasureData("mushroom_shop", treasure.type, list);
		return treasure;
	}

	public CharacterBurstTreasureById AddTreasureToCharacter(string treasureId, Character character)
	{
		CharacterBurstTreasureById characterBurstTreasureById = character.gameObject.AddComponent<CharacterBurstTreasureById>();
		characterBurstTreasureById.lifecycleEvent = CharacterBurstSpawner.LifecycleEvent.Died;
		characterBurstTreasureById.ticDelay = 15;
		characterBurstTreasureById.positionOffset = new IntPosition(4, 0, 0);
		characterBurstTreasureById.treasureId = treasureId;
		return characterBurstTreasureById;
	}

	public CharacterTreasureSpawner GetTreasureSpawnerForType(TreasureItem.Type type)
	{
		string prefabPath = treasureDrop0;
		switch (type)
		{
		case TreasureItem.Type.Common:
			prefabPath = treasureDrop1;
			break;
		case TreasureItem.Type.Giant:
			prefabPath = treasureDrop2;
			break;
		case TreasureItem.Type.Rare:
			prefabPath = treasureDrop3;
			break;
		case TreasureItem.Type.Epic:
			prefabPath = treasureDrop4;
			break;
		case TreasureItem.Type.Gold:
			prefabPath = treasureDropGold;
			break;
		}
		return Utils.InstantiatePrefab(prefabPath).GetComponent<CharacterTreasureSpawner>();
	}

	public Data.ItemInTreasure[] MakeShinyItemsInTreasure(int rarityBonus, int itemLevel = 1)
	{
		string text = null;
		ItemData.Element element = ItemData.Element.Stone;
		List<string> list = MakeListOfPossibleShinyItemIds();
		List<ItemData.Element> list2 = MakeListOfPossibleElements();
		Shuffle(list);
		Shuffle(list2);
		List<Item> shinyItems = Inventory.Singleton.GetShinyItems();
		for (int i = 0; i < list2.Count; i++)
		{
			ItemData.Element element2 = list2[i];
			element = element2;
			for (int j = 0; j < list.Count; j++)
			{
				string text2 = list[j];
				text = text2;
				for (int k = 0; k < shinyItems.Count; k++)
				{
					Item item = shinyItems[k];
					if (item != null && item.id == text2)
					{
						if (!item.isSocketed)
						{
							text = null;
							break;
						}
						if (item.element == element2)
						{
							text = null;
							break;
						}
					}
				}
				if (text != null)
				{
					break;
				}
			}
			if (text != null)
			{
				break;
			}
		}
		if (text != null)
		{
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.id = text;
			itemInTreasure.level = itemLevel;
			itemInTreasure.element = element;
			itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(rarityBonus);
			itemInTreasure.rarityBonus = rarityBonus;
			itemInTreasure.showTreasureColor = true;
			return new Data.ItemInTreasure[1] { itemInTreasure };
		}
		Data.ItemInTreasure itemInTreasure2 = new Data.ItemInTreasure();
		itemInTreasure2.id = "shiny";
		if (rarityBonus > 0)
		{
			Data.ItemInTreasure itemInTreasure3 = new Data.ItemInTreasure();
			itemInTreasure3.id = "enchantment";
			itemInTreasure3.rarityType = ItemData.Rarity.GetTypeForBonus(rarityBonus);
			itemInTreasure3.rarityBonus = rarityBonus;
			itemInTreasure3.showTreasureColor = true;
			return new Data.ItemInTreasure[2] { itemInTreasure3, itemInTreasure2 };
		}
		return new Data.ItemInTreasure[1] { itemInTreasure2 };
	}

	public TreasureItem MakeShinyTreasure(int rarityBonus, int itemLevel = 1, string treasureId = "treasure_3")
	{
		TreasureItem obj = ItemFactory.singleton.MakeItem(treasureId) as TreasureItem;
		obj.isShiny = true;
		obj.itemsInTreasure = MakeShinyItemsInTreasure(rarityBonus, itemLevel);
		return obj;
	}

	private List<string> MakeListOfPossibleShinyItemIds()
	{
		return new List<string>
		{
			"wand", "socketed_sword", "socketed_shield", "socketed_long_sword", "socketed_crossbow", "dashing_shield", "socketed_hammer", "socketed_staff", "bardiche", "tower_shield",
			"compound_shield"
		};
	}

	private float GetEventCoeficient(string questId)
	{
		EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
		if (activeAndStartedEvent != null && activeAndStartedEvent.uniqueCoeficient > 0f && activeAndStartedEvent.qualityOverQuantity && activeAndStartedEvent.uniqueLocation == questId)
		{
			return activeAndStartedEvent.uniqueCoeficient / uniqueCoeficient;
		}
		return 1f;
	}

	private void Shuffle<T>(IList<T> list)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = Utils.random.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public void ClearProgress()
	{
		uniqueDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);
		crystalDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);
		goldDate = DateTime.Now - new TimeSpan(15, 0, 0, 0);
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		if (UNIQUE_ENABLED)
		{
			SlimJson.AddProperty("uniqueDate", uniqueDate);
			SlimJson.AddProperty("crystalDate", crystalDate);
			SlimJson.AddProperty("goldDate", goldDate);
		}
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			if (SlimJson.HasKey(sjson, "uniqueDate"))
			{
				uniqueDate = SlimJson.ParseDateTime(sjson, "uniqueDate");
			}
			if (SlimJson.HasKey(sjson, "crystalDate"))
			{
				crystalDate = SlimJson.ParseDateTime(sjson, "crystalDate");
			}
			if (SlimJson.HasKey(sjson, "goldDate"))
			{
				goldDate = SlimJson.ParseDateTime(sjson, "goldDate");
			}
		}
	}

	private void TestSelectRarity()
	{
		int[] rarityChances = rarityChancesEpicTreasure;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i <= 6; i++)
		{
			dictionary.Add(i, 0);
		}
		for (int j = 0; j < 30; j++)
		{
			dictionary[(int)SelectRarity(rarityChances)]++;
		}
		foreach (KeyValuePair<int, int> item in dictionary)
		{
			Utils.Log(((ItemData.Rarity.Type)item.Key/*cast due to .constrained prefix*/).ToString() + " = " + item.Value);
		}
	}

	private void Start()
	{
		try
		{
			LoadTreasureData();
		}
		catch (Exception e)
		{
			ExceptionHandlingUI.Report(e);
		}
	}

	private void LoadTreasureData()
	{
		treasureData = Data.AllTreasureData.FromString(treasureDescriptions.text);
		treasuresById = new Dictionary<string, Data.Treasure>();
		for (int i = 0; i < treasureData.treasures.Length; i++)
		{
			Data.Treasure treasure = treasureData.treasures[i];
			string id = treasure.id;
			treasuresById.Add(id, treasure);
		}
		treasureCollectionsById = new Dictionary<string, Data.TreasureDropCollection>();
		for (int j = 0; j < treasureData.dropCollections.Length; j++)
		{
			Data.TreasureDropCollection treasureDropCollection = treasureData.dropCollections[j];
			string collectionId = treasureDropCollection.collectionId;
			treasureCollectionsById.Add(collectionId, treasureDropCollection);
		}
		Utils.PreloadAsyncPrefab(treasureDrop0);
		Utils.PreloadAsyncPrefab(treasureDrop1);
		Utils.PreloadAsyncPrefab(treasureDrop2);
		Utils.PreloadAsyncPrefab(treasureDrop3);
		Utils.PreloadAsyncPrefab(treasureDrop4);
		Utils.PreloadAsyncPrefab(treasureDropGold);
	}

	private void Awake()
	{
		singleton = this;
	}
}
