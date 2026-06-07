using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_storeResources", menuName = "Tower Factory/Tutorial/Store Resources Quest")]
public class TutorialQuestData_storeResources : TutorialQuestData
{
	[SerializeField]
	private Cost[] resourcesToComplete;

	private Cost[] currentProgress;

	private bool notifyUpdate;

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
			text = text + new LocalizedString("Tutorial", "Tutorial_text_automateProduction").GetLocalizedString() + " " + currentProgress[i].Resource.DisplayName + ": " + currentProgress[i].Amount + "/" + resourcesToComplete[i].Amount;
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
		LTFunctionLibrary.GetLTGameManager().PlayerTower.onBeltStoreResource += OnResourceStoredFromBelt;
	}

	public override void EndQuest()
	{
		base.EndQuest();
		LTFunctionLibrary.GetLTGameManager().PlayerTower.onBeltStoreResource -= OnResourceStoredFromBelt;
	}

	public override bool UpdateQuest()
	{
		if (notifyUpdate)
		{
			notifyUpdate = false;
			return true;
		}
		return false;
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

	private void OnResourceStoredFromBelt(ResourceData resourceData, int amount)
	{
		for (int i = 0; i < currentProgress.Length; i++)
		{
			if (currentProgress[i].Resource == resourceData)
			{
				currentProgress[i].Amount += amount;
				notifyUpdate = true;
				break;
			}
		}
	}
}
