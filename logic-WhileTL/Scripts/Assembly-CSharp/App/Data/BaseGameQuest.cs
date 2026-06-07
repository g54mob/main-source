using System.Collections.Generic;

namespace App.Data
{
	public class BaseGameQuest : BaseQuest
	{
		public string ConditionBronze;

		public string ConditionSilver;

		public string ConditionGold;

		public string UnlockedBlocks;

		public virtual BaseCondition GetCondition(int i)
		{
			return new QuestCondition();
		}

		public virtual void InitTaskController(TaskController taskController)
		{
		}

		public List<bool> GetListValidConditions()
		{
			return new List<bool>
			{
				ConditionBronze != "-",
				ConditionSilver != "-",
				ConditionGold != "-"
			};
		}

		public int GetMinExistentCondition()
		{
			if (ConditionBronze != "-")
			{
				return 0;
			}
			if (ConditionSilver != "-")
			{
				return 1;
			}
			if (ConditionGold != "-")
			{
				return 2;
			}
			return 0;
		}

		public int GetMaxExistentCondition()
		{
			if (ConditionGold != "-")
			{
				return 2;
			}
			if (ConditionSilver != "-")
			{
				return 1;
			}
			_ = ConditionBronze != "-";
			return 0;
		}

		public override void Start()
		{
			QuestLine.Quest quest = QuestLine.UpdateOrAddQuest(this);
			TreeController treeController = Logic.TreeController;
			QuestLine.SetCurrentQuest(this);
			if (quest.IsTaskOpened())
			{
				treeController.OpenConstruction(KeyName);
			}
			else
			{
				treeController.BaseGameQuestOpenTask(quest, KeyName);
			}
		}
	}
}
