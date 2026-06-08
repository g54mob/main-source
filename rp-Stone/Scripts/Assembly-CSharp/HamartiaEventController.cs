using System;
using System.Collections.Generic;
using UnityEngine;

public class HamartiaEventController : BaseEventController
{
	private List<List<string>> enemyGroups;

	private HashSet<string> validEnemies;

	private Dictionary<string, int> enemyRngSeeds;

	private List<string> WEAKNESS_ORDER = new List<string>(new string[8] { "fungus_forest", "icy_ridge", "caustic_caves", "undead_crypt", "temple", "deadwood_valley", "bronze_mine", "rocky_plateau" });

	private string[] IMMUNITIES = new string[12]
	{
		"ranged", "melee", "magic", "physical", "critical", "debuff_damage", "debuff_chill", "Poison", "Vigor", "AEther",
		"Fire", "Ice"
	};

	private string[] WEAKNESSES = new string[10] { "ranged", "melee", "magic", "physical", "critical", "Poison", "Vigor", "AEther", "Fire", "Ice" };

	private const float WEAKNESS_DAMAGE_MULTIPLY = 2f;

	private static HamartiaEventController instance;

	public static HamartiaEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new HamartiaEventController();
			}
			return instance;
		}
	}

	public static bool IsEventActive()
	{
		if (EventController.singleton.CanPlayerSeeEvents())
		{
			return EventController.singleton.IsEventActiveAndStarted("hamartia");
		}
		return false;
	}

	public override string GetEventId()
	{
		return "hamartia";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[12]
		{
			10, 250, 1500, 1500, 1500, 6000, 6000, 6000, 6000, 30000,
			30000, 30000
		};
	}

	protected override string GetRewardItemId()
	{
		return "treasure_3";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_hamartia_title";
	}

	private void InitEnemyData()
	{
		if (enemyGroups != null)
		{
			return;
		}
		enemyGroups = new List<List<string>>();
		validEnemies = new HashSet<string>();
		enemyRngSeeds = new Dictionary<string, int>();
		enemyGroups.Add(new List<string>(new string[3] { "mushroom_boss", "mushroom_boss_hard", "mushroom_boss_harder" }));
		enemyGroups.Add(new List<string>(new string[1] { "mushroom_boss_fat" }));
		enemyGroups.Add(new List<string>(new string[1] { "mushroom_boss_skinny" }));
		enemyGroups.Add(new List<string>(new string[1] { "yeti" }));
		enemyGroups.Add(new List<string>(new string[5] { "spider_boss", "spider_boss_hard", "spider_boss_harder", "spider_boss_web", "spider_boss_cacoon" }));
		enemyGroups.Add(new List<string>(new string[3] { "skeleton_boss", "skeleton_boss_hard", "skeleton_boss_harder" }));
		enemyGroups.Add(new List<string>(new string[2] { "skeleton_boss_stage_2_hard", "skeleton_boss_stage_2_harder" }));
		enemyGroups.Add(new List<string>(new string[1] { "nagaraja" }));
		enemyGroups.Add(new List<string>(new string[3] { "tree_boss", "tree_boss_hard", "tree_boss_harder" }));
		enemyGroups.Add(new List<string>(new string[1] { "bronze_guardian" }));
		enemyGroups.Add(new List<string>(new string[1] { "dysangelos_bearer" }));
		enemyGroups.Add(new List<string>(new string[1] { "dysangelos_elementalist" }));
		enemyGroups.Add(new List<string>(new string[1] { "dysangelos_perfected" }));
		int num = 0;
		foreach (List<string> enemyGroup in enemyGroups)
		{
			num++;
			foreach (string item in enemyGroup)
			{
				if (!validEnemies.Contains(item))
				{
					validEnemies.Add(item);
					enemyRngSeeds.Add(item, num);
				}
			}
		}
	}

	private int GetLocationIndex()
	{
		string id = GameStates.Singleton.level.QuestData.id;
		int num = 0;
		using (List<Data.Quest>.Enumerator enumerator = QuestController.singleton.AllQuestData.GetEnumerator())
		{
			while (enumerator.MoveNext() && !(enumerator.Current.id == id))
			{
				num++;
			}
		}
		return num;
	}

	private int GetEnemyRNGSeed(string characterId)
	{
		if (enemyRngSeeds.ContainsKey(characterId))
		{
			return enemyRngSeeds[characterId];
		}
		return GetLocationIndex();
	}

	private int GetChallengeDayIndex()
	{
		EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
		if (activeAndStartedEvent == null)
		{
			return 0;
		}
		DateTime dateTimeStart = EventSchedules.singleton.GetDateTimeStart(activeAndStartedEvent.id);
		TimeSpan timeSpan = new TimeSpan(12, 0, 0);
		double totalDays = (DateTime.Now - dateTimeStart - timeSpan).TotalDays;
		return Mathf.Max(0, Mathf.FloorToInt((float)totalDays));
	}

	public int ProcessEnemy(Character character, int proposedLevel)
	{
		if (!IsEventActive())
		{
			return proposedLevel;
		}
		InitEnemyData();
		if (!IsValidEnemy(character.id))
		{
			return proposedLevel;
		}
		int level = GameStates.Singleton.level.QuestData.level;
		if (level <= 5 && !Inventory.Singleton.HasItemById("moon_stone"))
		{
			return proposedLevel;
		}
		if (IsStrongQuest())
		{
			if (level > 10)
			{
				AddImmunities(character, 2);
			}
			else if (level > 5)
			{
				AddImmunities(character, 1);
			}
			if (!character.tags.Contains("phase2") && !character.tags.Contains("phase3"))
			{
				return proposedLevel + 5;
			}
		}
		if (IsWeakQuest())
		{
			if (level > 10)
			{
				AddWeaknesses(character, 2);
			}
			else if (level > 5)
			{
				AddWeaknesses(character, 1);
			}
		}
		return proposedLevel;
	}

	private bool IsValidEnemy(string characterId)
	{
		return validEnemies.Contains(characterId);
	}

	private bool IsStrongQuest()
	{
		return IsStrongQuest(GetCurrentQuestId());
	}

	private bool IsWeakQuest()
	{
		return IsWeakQuest(GetCurrentQuestId());
	}

	public bool IsStrongQuest(string questId)
	{
		if (WEAKNESS_ORDER.Contains(questId))
		{
			return !IsWeakQuest(questId);
		}
		return false;
	}

	public bool IsWeakQuest(string questId)
	{
		int index = GetChallengeDayIndex() % WEAKNESS_ORDER.Count;
		return WEAKNESS_ORDER[index] == questId;
	}

	private string GetCurrentQuestId()
	{
		Data.Quest parentQuest = GameStates.Singleton.parentQuest;
		if (parentQuest != null)
		{
			return parentQuest.id;
		}
		return GameStates.Singleton.level.QuestData.id;
	}

	private void AddImmunities(Character character, int amount)
	{
		System.Random random = new System.Random(GetEnemyRNGSeed(character.id) + GetChallengeDayIndex());
		int num = 0;
		for (int i = 0; i < amount; i++)
		{
			if (num >= 8)
			{
				break;
			}
			int num2 = random.Next(IMMUNITIES.Length - 1);
			string text = IMMUNITIES[num2];
			if (character.immuneTo.Contains(text) || (text == "physical" && character.immuneTo.Contains("magic")) || (text == "magic" && character.immuneTo.Contains("physical")))
			{
				i--;
				num++;
			}
			else
			{
				character.immuneTo.Add(text);
			}
		}
	}

	private void AddWeaknesses(Character character, int amount)
	{
		System.Random random = new System.Random(GetEnemyRNGSeed(character.id) + GetChallengeDayIndex());
		string text = null;
		ItemData.Element element = character.GetElement();
		if (element != ItemData.Element.Stone)
		{
			text = ItemData.NameForElement(ItemData.CounteredBy(element));
		}
		List<string> list = new List<string>();
		int num = 0;
		for (int i = 0; i < amount; i++)
		{
			if (num >= 8)
			{
				break;
			}
			int num2 = random.Next(WEAKNESSES.Length - 1);
			string text2 = WEAKNESSES[num2];
			if (text2 == text || character.immuneTo.Contains(text2) || list.Contains(text2))
			{
				i--;
				num++;
				continue;
			}
			list.Add(text2);
			MultiplyDamageFromMagic multiplyDamageFromMagic = character.gameObject.AddComponent<MultiplyDamageFromMagic>();
			multiplyDamageFromMagic.multiplier = 2f;
			multiplyDamageFromMagic.singleTag = text2;
		}
	}

	public void ReportLocationVictory()
	{
		if (IsEventActive())
		{
			int level = GameStates.Singleton.level.QuestData.level;
			ImproveReward(level, showStars: true);
		}
	}

	protected override Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != base.rarityBonus)
		{
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardItemId()) as TreasureItem;
			treasureItem.isShiny = true;
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.id = "sword";
			itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(base.rarityBonus);
			itemInTreasure.rarityBonus = base.rarityBonus;
			itemInTreasure.showTreasureColor = true;
			treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { itemInTreasure };
			rewardItem = treasureItem;
		}
		return rewardItem;
	}

	public override void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem("treasure_3") as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.signature = "Ham" + Utils.GetYearAbbreviated(DateTime.Now);
		Data.ItemInTreasure[] collection = TreasureFactory.singleton.MakeShinyItemsInTreasure(base.rarityBonus);
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>(collection);
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("ki_crystal", 1, base.rarityBonus, null);
		list.Add(item);
		collection = list.ToArray();
		treasureItem.itemsInTreasure = collection;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}
}
