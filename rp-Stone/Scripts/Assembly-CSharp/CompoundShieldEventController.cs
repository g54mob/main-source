using UnityEngine;

public class CompoundShieldEventController
{
	private static readonly int[] thresholds = new int[12]
	{
		1, 5, 20, 50, 100, 200, 500, 1000, 2000, 5000,
		10000, 20000
	};

	public static readonly string REWARD_KEY = "CompoundShield";

	private static readonly string PROGRESS_KEY = "CompoundShield_progress";

	private static readonly string BONUS_KEY = "CompoundShield_bonus";

	private static readonly string REWARD_ITEM_ID = "compound_shield";

	private static readonly string REWARD_TREASURE_ID = "treasure_3";

	private static readonly string REWARD_TITLE_TID = "tid_info_unique_item_event_title";

	private static Item rewardItem;

	private static int progress
	{
		get
		{
			return EventController.singleton.GetProgress(PROGRESS_KEY, 0);
		}
		set
		{
			EventController.singleton.SetProgress(PROGRESS_KEY, value);
			PlayerPrefs.SetInt(BONUS_KEY, rarityBonus);
		}
	}

	public static int rarityBonus
	{
		get
		{
			if (EventController.singleton.IsProgressLoaded())
			{
				return EventController.singleton.GetProgress(BONUS_KEY, 1);
			}
			return PlayerPrefs.GetInt(BONUS_KEY, 1);
		}
		set
		{
			EventController.singleton.SetProgress(BONUS_KEY, value);
			EventController.singleton.SetReward(REWARD_KEY);
			PlayerPrefs.SetInt(BONUS_KEY, value);
		}
	}

	private static Data.ItemInTreasure MakeItemData()
	{
		return new Data.ItemInTreasure
		{
			id = REWARD_ITEM_ID,
			rarityType = ItemData.Rarity.GetTypeForBonus(rarityBonus),
			rarityBonus = rarityBonus,
			showTreasureColor = true
		};
	}

	private static Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != rarityBonus)
		{
			Data.ItemInTreasure itemData = MakeItemData();
			rewardItem = Inventory.Singleton.MakeReward(itemData);
			rewardItem.isShiny = true;
		}
		return rewardItem;
	}

	public static void ReportQuarterstaffStunned()
	{
		if (!EventController.singleton.IsEventActiveAndStarted("compound_shield"))
		{
			return;
		}
		int num = thresholds[thresholds.Length - 1];
		if (rarityBonus < thresholds.Length)
		{
			num = thresholds[rarityBonus - 1];
		}
		int currentProgress = progress;
		progress++;
		if (progress > num)
		{
			progress = num;
		}
		GameStates.Singleton.rewardProgressCard.Setup(GetRewardItem(), currentProgress, progress, num);
		if (progress == num && rarityBonus <= thresholds.Length)
		{
			rarityBonus++;
			if (rarityBonus <= thresholds.Length)
			{
				progress = 0;
				num = thresholds[rarityBonus - 1];
			}
			GameStates.Singleton.rewardProgressCard.SetupNext(GetRewardItem(), progress, num);
		}
	}

	public static void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem(REWARD_TREASURE_ID) as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { MakeItemData() };
		Inventory.Singleton.AddItem(treasureItem);
		string titleStr = Te.xt(REWARD_TITLE_TID);
		AsciiSprite icon = treasureItem.GetIcon();
		SequentialPopupManager.singleton.ScheduleEventReward(titleStr, icon);
	}
}
