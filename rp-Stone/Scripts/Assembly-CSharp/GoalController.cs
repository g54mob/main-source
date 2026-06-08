using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
	public int totalGoals { get; private set; }

	public BaseGoals[] goalData { get; private set; }

	public static GoalController singleton { get; private set; }

	public int GetTotalCompleted()
	{
		int num = 0;
		for (int i = 0; i < goalData.Length; i++)
		{
			BaseGoals baseGoals = goalData[i];
			int num2 = baseGoals.goal.GetValue();
			if (num2 > baseGoals.goalCount)
			{
				num2 = baseGoals.goalCount;
			}
			if (num2 > 0)
			{
				num += num2;
			}
		}
		return num;
	}

	public void ProcessRewards()
	{
		for (int i = 0; i < goalData.Length; i++)
		{
			goalData[i].ProcessReward();
		}
	}

	public void ShowGreenNotificationOnBook()
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("goal_book");
		if ((bool)firstItemWithId)
		{
			firstItemWithId.hasInteracted = false;
		}
	}

	public void HideGreenNotificationOnBook()
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("goal_book");
		if ((bool)firstItemWithId)
		{
			firstItemWithId.hasInteracted = true;
		}
	}

	public void TryToUnlockWorkstationTask()
	{
		if (HasGoalBookAlready())
		{
			return;
		}
		List<Item> allItems = Inventory.Singleton.GetAllItems();
		for (int i = 0; i < allItems.Count; i++)
		{
			Item item = allItems[i];
			if (item != null && item.isLost)
			{
				MakeGoalBookCraftAvailable();
				break;
			}
		}
	}

	private bool HasGoalBookAlready()
	{
		return Inventory.Singleton.GetFirstItemWithId("goal_book") != null;
	}

	private void MakeGoalBookCraftAvailable()
	{
		QuestController.singleton.MakeAvailable("craft_goal_book");
	}

	private void HandleItemGained(Item item, int count)
	{
		if (item.isLost && !HasGoalBookAlready())
		{
			MakeGoalBookCraftAvailable();
		}
	}

	private void Start()
	{
		BaseGoals[] components = GetComponents<BaseGoals>();
		List<BaseGoals> list = new List<BaseGoals>();
		totalGoals = 0;
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].enabled)
			{
				list.Add(components[i]);
				totalGoals += components[i].goalCount;
			}
		}
		goalData = list.ToArray();
		Inventory.Singleton.OnItemGained += HandleItemGained;
	}

	public virtual void ClearProgress()
	{
		for (int i = 0; i < goalData.Length; i++)
		{
			goalData[i].ClearProgress();
		}
	}

	public virtual string Serialize()
	{
		SlimJson.BeginSerialization();
		for (int i = 0; i < goalData.Length; i++)
		{
			BaseGoals baseGoals = goalData[i];
			SlimJson.AddProperty(baseGoals.id, baseGoals.Serialize());
		}
		return SlimJson.EndSerialization();
	}

	public virtual void Parse(string sjson)
	{
		if (sjson != null)
		{
			for (int i = 0; i < goalData.Length; i++)
			{
				BaseGoals baseGoals = goalData[i];
				string text = SlimJson.Parse(sjson, baseGoals.id);
				if (text != null)
				{
					baseGoals.Parse(text);
				}
				else
				{
					baseGoals.ClearProgress();
				}
			}
		}
		else
		{
			ClearProgress();
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
