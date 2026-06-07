using Localization;

namespace App.Data
{
	public class ConstructionQuest : BaseGameQuest
	{
		public int RevealScore;

		public int RNNBatch;

		public int IsTask;

		public int RNNCapacity;

		public int OldId;

		public int Acсuracy;

		public int MaxBlock;

		public string Data0;

		public string Data1;

		public string Data2;

		public string Data3;

		public string Data4;

		public string Res0;

		public string Res1;

		public string Res2;

		public string Res3;

		public string Res4;

		public int MinScore;

		public int MaxScore;

		public bool TrainTest;

		public int Deadline;

		public int OnlyColor;

		public int OnlyAcc;

		public int OnlyShape;

		public float TimeTrueAcc;

		public float MinError;

		public float MaxError;

		public override void InitTaskController(TaskController taskController)
		{
			taskController.Speed.gameObject.SetActive(value: false);
			taskController.Time.text = Logic.MinMaxEqualValueStringForCondition(((QuestCondition)GetCondition(0)).Time, ((QuestCondition)GetCondition(2)).Time, " " + TextResources.GetString("SEC"), "TIME");
		}

		public override BaseCondition GetCondition(int i)
		{
			int num = i;
			if (num == 0)
			{
				if (ConditionBronze != "-")
				{
					return Logic.GetConditionByKeyName(ConditionBronze);
				}
				num++;
			}
			if (num == 1)
			{
				if (ConditionSilver != "-")
				{
					return Logic.GetConditionByKeyName(ConditionSilver);
				}
				num++;
			}
			if (num == 2 && ConditionGold != "-")
			{
				return Logic.GetConditionByKeyName(ConditionGold);
			}
			return new QuestCondition();
		}

		public override int GetRewardFromMedal(int medal)
		{
			return Reward + GetCondition(medal).ExtraMoney;
		}

		public override void ReInitConstructionArea(bool resetInOut = true)
		{
			Logic.GetController().construction.ReInitConstructionArea(this, resetInOut);
		}
	}
}
