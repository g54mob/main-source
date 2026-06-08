public class SummerBashingEventController : BaseEventController
{
	private static SummerBashingEventController instance;

	public static SummerBashingEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new SummerBashingEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "summer_bash";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[1] { 10 };
	}

	protected override string GetRewardItemId()
	{
		return "bashing_shield";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_unique_item_event_title";
	}

	protected override Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != base.rarityBonus)
		{
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.level = 6;
			itemInTreasure.id = GetRewardItemId();
			rewardItem = Inventory.Singleton.MakeReward(itemInTreasure);
		}
		return rewardItem;
	}

	public override void ProcessReward()
	{
		Item item = GetRewardItem();
		Inventory.Singleton.AddItem(item);
		ShowRewardDialog(item);
	}

	protected override void ShowRewardDialog(Item rewardItem)
	{
		string text = Te.xt("tid_info_unique_item_event_title");
		text = text + "\n" + Te.xt("tid_item_23") + "\n";
		AsciiSprite icon = rewardItem.GetIcon();
		SequentialPopupManager.singleton.ScheduleEventReward(text, icon);
	}

	public void ReportFinalBossDefeated()
	{
		if (EventController.singleton.IsEventActiveAndStarted("summer_bash"))
		{
			int level = GameStates.Singleton.level.QuestData.level;
			ImproveReward(level, showStars: true);
		}
	}
}
