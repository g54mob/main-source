using System.Collections.Generic;
using UnityEngine;

public class BladeOfGodEventController : BaseEventController
{
	private int part2EnemiesKilledCount;

	private float realtimeAbilityActivatedWithStonescript;

	private static BladeOfGodEventController instance;

	public static BladeOfGodEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new BladeOfGodEventController();
				instance.Init();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "titan_trial_2".ToString();
	}

	public override int[] GetProgressThresholds()
	{
		return new int[10] { 10, 0, 0, 35, 0, 1000, 0, 1000000, 0, 3000000 };
	}

	protected override void IncreaseRarityBonus()
	{
		if (base.rarityBonus == 1)
		{
			base.rarityBonus = 4;
			base.part = 2;
		}
		else if (base.rarityBonus == 4)
		{
			base.rarityBonus = 6;
			base.part = 3;
			ClearAdditionalProgressMemory();
		}
		else if (base.rarityBonus == 6)
		{
			base.rarityBonus = 8;
			base.part = 4;
		}
		else if (base.rarityBonus == 8)
		{
			base.rarityBonus = 10;
			base.part = 5;
		}
		else if (base.rarityBonus == 10)
		{
			base.rarityBonus = 11;
			base.part = 6;
		}
	}

	protected override string GetRewardItemId()
	{
		return "treasure_delta_no_rainbow";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_titanic_title";
	}

	public void ReportEpicQuestCompleted(Data.CustomQuestInstance quest)
	{
		if (base.part == 0 && EventController.singleton.IsEventActiveAndStarted("titan_trial_2") && !(quest.customQuestId != "epic_titanic_accord"))
		{
			base.part = 1;
		}
	}

	public void ReportEnemyKilled(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (base.part == 1 && EventController.singleton.IsEventActiveAndStarted("titan_trial_2") && !(c == null) && c.id != null && c.id.StartsWith("spider_boss") && dmg != null && dmg.bullet != null && dmg.bullet.weapon != null && dmg.bullet.weapon.id == "blade_of_god")
		{
			ImproveReward();
		}
	}

	public List<string> GetUniqueFoeNames()
	{
		return null;
	}

	private void ClearAdditionalProgressMemory()
	{
	}

	public void ReportEnemyKilledWithBladeSuperAttack(Character c)
	{
	}

	public void ReportAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (base.part == 3 && withStonescript && EventController.singleton.IsEventActiveAndStarted("titan_trial_2") && provider.GetId() == "blade")
		{
			realtimeAbilityActivatedWithStonescript = Time.realtimeSinceStartup;
		}
	}

	public void ReportSmiteGained(int count)
	{
		if (base.part == 2 && part2EnemiesKilledCount > 0)
		{
			ImproveReward(part2EnemiesKilledCount);
			part2EnemiesKilledCount = 0;
		}
		if ((base.part == 3 || count <= 0) && !(Time.realtimeSinceStartup - realtimeAbilityActivatedWithStonescript > 4f))
		{
			ImproveReward(count);
		}
	}

	public void ReportSmiteDamage(int damageAmount, Damage dmg, int foeHealthBeforeSmite, Character c)
	{
		if ((base.part == 4 || base.part == 5) && EventController.singleton.IsEventActiveAndStarted("titan_trial_2") && dmg.startHitpoints > 0)
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			ImproveReward(num);
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
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem("treasure_4") as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.signature = "TT21";
		Data.ItemInTreasure[] collection = TreasureFactory.singleton.MakeShinyItemsInTreasure(base.rarityBonus);
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>(collection);
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("ki_crystal", 1, 5, null);
		list.Add(item);
		collection = list.ToArray();
		treasureItem.itemsInTreasure = collection;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
		ClearAdditionalProgressMemory();
	}

	private void Init()
	{
		CustomQuestsController.Singleton.OnQuestCompleted += ReportEpicQuestCompleted;
		GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated;
		Character.OnCharacterDied += ReportEnemyKilled;
	}
}
