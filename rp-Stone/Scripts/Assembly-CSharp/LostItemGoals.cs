using System.Collections.Generic;

public class LostItemGoals : BaseGoals
{
	public string goalItemId;

	public string goalQuestId;

	public override List<string> GetTexts()
	{
		string arg = Te.xt(CustomQuestsController.Singleton.GetQuestDefinitionById(goalQuestId).title);
		Item prefabForId = ItemFactory.singleton.GetPrefabForId(goalItemId);
		string text;
		if (prefabForId != null)
		{
			text = prefabForId.GetName();
		}
		else
		{
			text = Te.xt("tid_anvil_11");
			if (text.Length >= 6)
			{
				text = text.Substring(2, text.Length - 4);
			}
		}
		return new List<string> { string.Format(Te.xt("tid_info_goal_quest_item"), arg, text) };
	}

	public override void SetGoal(int newGoal)
	{
		int value = base.goal.GetValue();
		switch (value)
		{
		case -1:
			CustomQuestsController.Singleton.OnQuestStarted -= ReportEpicQuestStarted;
			break;
		case 0:
			Inventory.Singleton.OnItemGained -= ReportItemGained;
			break;
		default:
			if (value == base.goalCount - 1)
			{
				CustomQuestsController.Singleton.OnQuestCompleted -= ReportEpicQuestCompleted;
			}
			break;
		}
		base.SetGoal(newGoal);
		switch (newGoal)
		{
		case -1:
			if (CustomQuestsController.Singleton.GetCompletedCount(goalQuestId) > 0 || CustomQuestsController.Singleton.IsActive(goalQuestId))
			{
				SetGoal(0);
			}
			else
			{
				CustomQuestsController.Singleton.OnQuestStarted += ReportEpicQuestStarted;
			}
			break;
		case 0:
			if (Inventory.Singleton.HasItemById(goalItemId))
			{
				SetGoal(1);
			}
			else
			{
				Inventory.Singleton.OnItemGained += ReportItemGained;
			}
			break;
		}
	}

	private void ReportEpicQuestStarted(Data.CustomQuestInstance quest)
	{
		if (quest.customQuestId == goalQuestId)
		{
			SetGoal(0);
		}
	}

	private void ReportEpicQuestCompleted(Data.CustomQuestInstance quest)
	{
		if (quest.customQuestId == goalQuestId && Inventory.Singleton.GetFirstItemWithId("cult_mask") != null)
		{
			CustomQuestsController.Singleton.OnQuestCompleted -= ReportEpicQuestCompleted;
			GoalBookScreen.singleton.ScheduleShowGoals(this);
		}
	}

	private void ReportItemGained(Item item, int amount)
	{
		if (item.id == goalItemId)
		{
			SetGoal(1);
		}
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		if (base.goal.GetValue() < base.goalCount)
		{
			CustomQuestsController.Singleton.OnQuestCompleted += ReportEpicQuestCompleted;
		}
		else
		{
			CustomQuestsController.Singleton.OnQuestCompleted -= ReportEpicQuestCompleted;
		}
	}
}
