using UnityEngine;

public class TutorialWatcher_OnQuestFulfilled : TutorialWatcher
{
	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TutorialPhase onFailedPhase;

	public QuestFailedReason questFailedReason;

	public override void StartWatching()
	{
		rewardSystem.OnQuestCompleted += QuestFulfilled;
		rewardSystem.OnQuestFailed += QuestFailed;
	}

	public void QuestFailed(QuestWatcher failedQuest, QuestFailedReason questFailedReason)
	{
		rewardSystem.OnQuestCompleted -= QuestFulfilled;
		rewardSystem.OnQuestFailed -= QuestFailed;
		this.questFailedReason = questFailedReason;
		tutorialPhase.Finish(startNextPhase: false);
		onFailedPhase.gameObject.SetActive(value: true);
		onFailedPhase.Begin();
	}

	private void QuestFulfilled(QuestWatcher fulfilledQuest)
	{
		rewardSystem.OnQuestCompleted -= QuestFulfilled;
		rewardSystem.OnQuestFailed -= QuestFailed;
		ConditionFulfilled();
	}

	private void OnDestroy()
	{
		rewardSystem.OnQuestCompleted -= QuestFulfilled;
		rewardSystem.OnQuestFailed -= QuestFailed;
	}
}
