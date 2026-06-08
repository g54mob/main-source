using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class BaseGoals : MonoBehaviour
{
	public string id;

	public string displayName;

	public int[] progressThresholds;

	public string iconPath;

	public ItemData.Element iconElement;

	public int rewardEnchantBonus;

	public AsciiSpriteRow[] doodles;

	protected Item rewardItem;

	public int goalCount => progressThresholds.Length;

	public SafeInt goal { get; set; }

	public SafeInt progress { get; set; }

	private void Start()
	{
	}

	public virtual List<string> GetTexts()
	{
		return null;
	}

	public virtual AsciiObject GetSupportingUIElement(int goalNumber)
	{
		return null;
	}

	public virtual void SetGoal(int value)
	{
		goal = new SafeInt(value);
		progress = new SafeInt(0);
	}

	public void ImproveProgress()
	{
		ImproveProgress(1);
	}

	public void ImproveProgress(int pointsGained)
	{
		int num = 1;
		int value = goal.GetValue();
		if (value < progressThresholds.Length)
		{
			num = progressThresholds[value];
		}
		int value2 = progress.GetValue();
		int num2 = value2 + pointsGained;
		if (num2 > num)
		{
			num2 = num;
		}
		progress = new SafeInt(num2);
		GameStates.Singleton.rewardProgressCard.Setup(GetRewardItem(), value2, num2, num);
		if (num2 == num && value < progressThresholds.Length)
		{
			SetGoal(value + 1);
			if (value + 1 < goalCount)
			{
				value2 = 0;
				num = progressThresholds[value + 1];
				GameStates.Singleton.rewardProgressCard.SetupNext(GetRewardItem(), value2, num);
				GoalController.singleton.ShowGreenNotificationOnBook();
				GoalBookScreen.singleton.ScheduleShowGoals(this);
			}
			else
			{
				GoalController.singleton.HideGreenNotificationOnBook();
				ProcessReward();
			}
		}
	}

	protected virtual Item GetRewardItem()
	{
		if (rewardItem == null)
		{
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardItemId()) as TreasureItem;
			treasureItem.isShiny = true;
			Data.ItemInTreasure itemInTreasure = new Data.ItemInTreasure();
			itemInTreasure.id = "sword";
			itemInTreasure.rarityType = ItemData.Rarity.GetTypeForBonus(rewardEnchantBonus);
			itemInTreasure.rarityBonus = rewardEnchantBonus;
			itemInTreasure.showTreasureColor = true;
			treasureItem.itemsInTreasure = new Data.ItemInTreasure[1] { itemInTreasure };
			rewardItem = treasureItem;
		}
		return rewardItem;
	}

	protected virtual string GetRewardItemId()
	{
		return "treasure_ki_no_jewel";
	}

	protected void FormatProgressThresholds(List<string> texts)
	{
		for (int i = 0; i < texts.Count && i < progressThresholds.Length; i++)
		{
			texts[i] = string.Format(texts[i], progressThresholds[i]);
		}
	}

	public bool IsComplete()
	{
		return goal.GetValue() >= goalCount;
	}

	public void ProcessReward()
	{
		int value = goal.GetValue();
		if (value == goalCount)
		{
			SetGoal(value + 1);
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(GetRewardItemId()) as TreasureItem;
			ItemData.Rarity.Type typeForBonus = ItemData.Rarity.GetTypeForBonus(rewardEnchantBonus);
			Data.ItemInTreasure itemInTreasure = TreasureFactory.singleton.MakeOneItemForTreasure("enchantment", 1, 1, null, typeForBonus);
			itemInTreasure.rarityBonus = rewardEnchantBonus;
			itemInTreasure.showTreasureColor = true;
			int count = rewardEnchantBonus + 4;
			Data.ItemInTreasure itemInTreasure2 = TreasureFactory.singleton.MakeOneItemForTreasure("ki_crystal", 1, count, null);
			treasureItem.itemsInTreasure = new Data.ItemInTreasure[2] { itemInTreasure, itemInTreasure2 };
			Inventory.Singleton.AddItem(treasureItem);
			ShowRewardDialog(treasureItem);
		}
	}

	protected virtual void ShowRewardDialog(Item rewardItem)
	{
		string titleStr = Te.xt(displayName);
		AsciiSprite icon = rewardItem.GetIcon();
		SequentialPopupManager.singleton.ScheduleEventReward(titleStr, icon);
	}

	public static AsciiObject MakeHyperlinkUIElement(string label, string url)
	{
		HyperlinkButton hyperlinkButton = GoalBookScreen.singleton.hyperlinkButton;
		int num = (hyperlinkButton.Width = label.Length + 2);
		hyperlinkButton.PositionX = (24 - num) / 2;
		hyperlinkButton.label.SetValue(label);
		hyperlinkButton.label.PositionX = num / 2;
		hyperlinkButton.url = url;
		return hyperlinkButton;
	}

	public virtual void ClearProgress()
	{
		SetGoal(-1);
	}

	public virtual void SerializeMore()
	{
	}

	public virtual void ParseMore(string sjson)
	{
	}

	public virtual string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("goal", goal.GetValue());
		SlimJson.AddProperty("progress", progress.GetValue());
		SerializeMore();
		return SlimJson.EndSerialization();
	}

	public virtual void Parse(string sjson)
	{
		if (sjson != null)
		{
			int num = SlimJson.ParseInt(sjson, "goal");
			SetGoal(num);
			progress = new SafeInt(SlimJson.ParseInt(sjson, "progress"));
			if (num >= 0 && num <= goalCount)
			{
				GoalBookScreen.singleton.ScheduleShowGoals(this);
			}
			ParseMore(sjson);
		}
		else
		{
			ClearProgress();
		}
	}
}
