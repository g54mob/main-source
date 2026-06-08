using UnityEngine;

public abstract class BaseEventController
{
	protected Item rewardItem;

	private int lastPart = -99999;

	protected int progress
	{
		get
		{
			return EventController.singleton.GetProgress(GetProgressKey(), 0);
		}
		set
		{
			EventController.singleton.SetProgress(GetProgressKey(), value);
			PlayerPrefs.SetInt(GetBonusKey(), rarityBonus);
		}
	}

	public int rarityBonus
	{
		get
		{
			string bonusKey = GetBonusKey();
			if (EventController.singleton.IsProgressLoaded())
			{
				int num = EventController.singleton.GetProgress(bonusKey, 1);
				PlayerPrefs.SetInt(bonusKey, num);
				return num;
			}
			return PlayerPrefs.GetInt(bonusKey, 1);
		}
		set
		{
			EventController.singleton.SetProgress(GetBonusKey(), value);
			EventController.singleton.SetReward(GetRewardKey());
			PlayerPrefs.SetInt(GetBonusKey(), value);
		}
	}

	public int part
	{
		get
		{
			string partKey = GetPartKey();
			if (EventController.singleton.IsProgressLoaded())
			{
				int num = EventController.singleton.GetProgress(partKey, 0);
				PlayerPrefs.SetInt(partKey, num);
				return num;
			}
			return PlayerPrefs.GetInt(partKey, 0);
		}
		set
		{
			EventController.singleton.SetProgress(GetPartKey(), value);
			PlayerPrefs.SetInt(GetPartKey(), value);
			UpdateForPartChanged();
		}
	}

	public abstract string GetEventId();

	public abstract int[] GetProgressThresholds();

	public virtual string GetRewardKey()
	{
		return GetEventId();
	}

	public virtual string GetProgressKey()
	{
		return GetEventId() + "_progress";
	}

	public virtual string GetBonusKey()
	{
		return GetEventId() + "_bonus";
	}

	public virtual string GetPartKey()
	{
		return GetEventId() + "_part";
	}

	protected virtual string GetRewardTreasureData()
	{
		return "treasure_3";
	}

	protected abstract string GetRewardItemId();

	protected abstract string GetRewardTitleTID();

	private Data.ItemInTreasure MakeItemData()
	{
		return new Data.ItemInTreasure
		{
			id = GetRewardItemId(),
			rarityType = ItemData.Rarity.GetTypeForBonus(rarityBonus),
			rarityBonus = rarityBonus,
			showTreasureColor = true
		};
	}

	protected virtual Item GetRewardItem()
	{
		if (rewardItem == null || rewardItem.GetRarityBonus() != rarityBonus)
		{
			Data.ItemInTreasure itemData = MakeItemData();
			rewardItem = Inventory.Singleton.MakeReward(itemData);
			rewardItem.isShiny = true;
		}
		return rewardItem;
	}

	protected virtual void ImproveReward()
	{
		ImproveReward(1);
	}

	protected virtual void ImproveReward(int pointsGained, bool showStars = false)
	{
		int[] progressThresholds = GetProgressThresholds();
		int num = progressThresholds[^1];
		if (rarityBonus < progressThresholds.Length)
		{
			num = progressThresholds[rarityBonus - 1];
		}
		int currentProgress = progress;
		progress += pointsGained;
		if (progress > num)
		{
			progress = num;
		}
		int showStars2 = 0;
		if (showStars && rarityBonus <= progressThresholds.Length)
		{
			showStars2 = pointsGained;
		}
		GameStates.Singleton.rewardProgressCard.Setup(GetRewardItem(), currentProgress, progress, num, showStars2);
		if (progress == num && rarityBonus <= progressThresholds.Length)
		{
			IncreaseRarityBonus();
			if (rarityBonus <= progressThresholds.Length)
			{
				progress = 0;
				num = progressThresholds[rarityBonus - 1];
			}
			GameStates.Singleton.rewardProgressCard.SetupNext(GetRewardItem(), progress, num);
		}
	}

	protected virtual void IncreaseRarityBonus()
	{
		rarityBonus++;
	}

	public virtual void ProcessReward()
	{
		TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardTreasureData()) as TreasureItem;
		treasureItem.isShiny = true;
		treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { MakeItemData() };
		Inventory.Singleton.AddItem(treasureItem);
		ShowRewardDialog(treasureItem);
	}

	protected virtual void ShowRewardDialog(Item rewardItem)
	{
		string titleStr = Te.xt(GetRewardTitleTID());
		AsciiSprite icon = rewardItem.GetIcon();
		SequentialPopupManager.singleton.ScheduleEventReward(titleStr, icon);
	}

	protected virtual void HandlePartEnded(int partEnded)
	{
	}

	protected virtual void HandlePartStarted(int partStarted)
	{
	}

	public virtual void UpdateForPartChanged()
	{
		int num = part;
		if (lastPart != num)
		{
			if (lastPart >= 0)
			{
				HandlePartEnded(lastPart);
			}
			HandlePartStarted(num);
			lastPart = num;
		}
	}
}
