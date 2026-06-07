using UnityEngine;

[CreateAssetMenu(fileName = "TutorialQuest_resources", menuName = "Tower Factory/Tutorial/Resources Quest")]
public class TutorialQuestData_resources : TutorialQuestData
{
	[SerializeField]
	private Cost[] resourcesToComplete;

	private Cost[] currentProgress;

	public override string GetObjectiveText()
	{
		string text = "";
		bool flag = false;
		for (int i = 0; i < currentProgress.Length; i++)
		{
			flag = currentProgress[i].Amount >= resourcesToComplete[i].Amount;
			if (i > 0)
			{
				text += "\n";
			}
			if (flag)
			{
				text += "<s>";
			}
			text = text + currentProgress[i].Resource.DisplayName + ": " + currentProgress[i].Amount + "/" + resourcesToComplete[i].Amount;
			if (flag)
			{
				text += "</s>";
			}
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		currentProgress = new Cost[resourcesToComplete.Length];
		for (int i = 0; i < resourcesToComplete.Length; i++)
		{
			currentProgress[i] = new Cost(resourcesToComplete[i].Resource, 0);
		}
	}

	public override bool UpdateQuest()
	{
		int num = 0;
		bool result = false;
		Cost[] array = currentProgress;
		foreach (Cost cost in array)
		{
			num = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount(cost.Resource.Id);
			if (cost.Amount != num)
			{
				cost.Amount = num;
				result = true;
			}
		}
		return result;
	}

	public override bool IsComplete()
	{
		for (int i = 0; i < resourcesToComplete.Length; i++)
		{
			if (currentProgress[i].Amount < resourcesToComplete[i].Amount)
			{
				return false;
			}
		}
		return true;
	}
}
