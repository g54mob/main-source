using System.Collections.Generic;
using UnityEngine;

public class WildRideEventController : BaseEventController
{
	private float realtimeAbilityActivatedWithStonescript;

	private static WildRideEventController instance;

	public static WildRideEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new WildRideEventController();
				instance.Init();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "wild_ride";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[8] { 15, 0, 10, 0, 5, 0, 0, 500 };
	}

	protected override void IncreaseRarityBonus()
	{
		if (base.rarityBonus == 1)
		{
			base.rarityBonus = 3;
			base.part = 2;
		}
		else if (base.rarityBonus == 3)
		{
			base.rarityBonus = 5;
			base.part = 3;
		}
		else if (base.rarityBonus == 5)
		{
			base.rarityBonus = 8;
			base.part = 4;
		}
		else if (base.rarityBonus == 8)
		{
			base.rarityBonus = 11;
			base.part = 5;
		}
	}

	protected override string GetRewardItemId()
	{
		return "treasure_delta_no_rainbow";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_wild_ride_title";
	}

	private void ReportEpicQuestCompleted(Data.CustomQuestInstance quest)
	{
		if (base.part == 0 && EventController.singleton.IsEventActiveAndStarted("wild_ride") && !(quest.customQuestId != "epic_wild_ride"))
		{
			base.part = 1;
		}
	}

	public void ReportPickPocketGained()
	{
		if (base.part == 1 && EventController.singleton.IsEventActiveAndStarted("wild_ride"))
		{
			ImproveReward();
		}
	}

	public void ReportEvaded(Character c, Bullet b)
	{
		if (base.part != 2 || !EventController.singleton.IsEventActiveAndStarted("wild_ride") || c != GameStates.Singleton.hero || c.statModController == null || c.statModController.debuffs == null || b.Owner == null || !b.Owner.tags.Contains("boss"))
		{
			return;
		}
		bool flag = false;
		List<List<StatModifier>> debuffs = c.statModController.debuffs;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count > 0 && list[0].id == "pick_pocket")
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			ImproveReward();
		}
	}

	public void ReportItemStolen(Item item)
	{
		if (base.part == 3 && EventController.singleton.IsEventActiveAndStarted("wild_ride") && !(item.id != "runestone"))
		{
			int num = 0;
			if (item.element == ItemData.Element.Vigor)
			{
				num = 1;
			}
			else if (item.element == ItemData.Element.AEther)
			{
				num = 2;
			}
			else if (item.element == ItemData.Element.Fire)
			{
				num = 3;
			}
			else if (item.element == ItemData.Element.Ice)
			{
				num = 4;
			}
			int num2 = 1 << num;
			string key = "custom_progress_mask";
			int num3 = EventController.singleton.GetProgress(key, 0);
			if ((num3 & num2) == 0)
			{
				num3 |= num2;
				EventController.singleton.SetProgress(key, num3);
				ImproveReward();
			}
		}
	}

	private void ReportAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (base.part == 4 && withStonescript && EventController.singleton.IsEventActiveAndStarted("wild_ride") && provider.GetId() == "skeleton_arm")
		{
			realtimeAbilityActivatedWithStonescript = Time.realtimeSinceStartup;
		}
	}

	public void ReportEnemyKilled(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (base.part == 4 && EventController.singleton.IsEventActiveAndStarted("wild_ride") && !(Time.realtimeSinceStartup - realtimeAbilityActivatedWithStonescript > 4f) && dmg != null && dmg.bullet != null && dmg.bullet.tags.Contains("pick_pocket") && dmg.bullet.tags.Contains("activated_ability"))
		{
			ImproveReward();
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
		treasureItem.signature = "WR21";
		Data.ItemInTreasure[] collection = TreasureFactory.singleton.MakeShinyItemsInTreasure(base.rarityBonus);
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>(collection);
		Data.ItemInTreasure item = TreasureFactory.singleton.MakeOneItemForTreasure("ki_crystal", 1, 5, null);
		list.Add(item);
		collection = list.ToArray();
		treasureItem.itemsInTreasure = collection;
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}

	private void Init()
	{
		CustomQuestsController.Singleton.OnQuestCompleted += ReportEpicQuestCompleted;
		GameStates.Singleton.abilityActivationHUD.OnActivated += ReportAbilityActivated;
		Character.OnCharacterEvaded += ReportEvaded;
		Character.OnCharacterDied += ReportEnemyKilled;
	}
}
