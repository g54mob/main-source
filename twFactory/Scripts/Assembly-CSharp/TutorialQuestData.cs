using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_default", menuName = "Tower Factory/Tutorial/Default Quest", order = 0)]
public class TutorialQuestData : ScriptableObject
{
	[SerializeField]
	private LocalizedString mainQuestText;

	[SerializeField]
	private LocalizedString secondaryQuestText;

	[SerializeField]
	private Sprite questSprite;

	[SerializeField]
	private bool increaseSpawnersCycle;

	[SerializeField]
	private bool atQuestEnd;

	public string MainQuestText => mainQuestText.GetLocalizedString();

	public string SecondaryQuestText
	{
		get
		{
			if (secondaryQuestText != null && !secondaryQuestText.IsEmpty)
			{
				return secondaryQuestText.GetLocalizedString();
			}
			return "";
		}
	}

	public Sprite QuestSprite => questSprite;

	public virtual string GetObjectiveText()
	{
		return "";
	}

	public virtual void StartQuest()
	{
		if (increaseSpawnersCycle && !atQuestEnd)
		{
			(LTFunctionLibrary.GetLTGameManager() as TutorialGameManager).TutorialSpawnersManager.NextCycle();
		}
	}

	public virtual void EndQuest()
	{
		if (increaseSpawnersCycle && atQuestEnd)
		{
			(LTFunctionLibrary.GetLTGameManager() as TutorialGameManager).TutorialSpawnersManager.NextCycle();
		}
	}

	public virtual bool UpdateQuest()
	{
		return false;
	}

	public virtual bool IsComplete()
	{
		return true;
	}
}
