using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Quest Completed")]
public class QuestCompletedAchievement : AchievementBase
{
	[Header("Quest Completed")]
	[SerializeField]
	private QuestProperties _questProperties;

	protected override void Initialize()
	{
		if (!StoryManager.IsQuestCompleted(_questProperties) || !UnlockAchievement())
		{
			GameEventDispatcher.AddListener(GameEventType.QuestCompleted, OnQuestCompleted);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnQuestCompleted);
	}

	private void OnQuestCompleted(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && questEvent.Quest.Properties == _questProperties && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
