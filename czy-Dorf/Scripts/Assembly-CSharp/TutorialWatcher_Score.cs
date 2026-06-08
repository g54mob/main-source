using UnityEngine;

public class TutorialWatcher_Score : TutorialWatcher
{
	[SerializeField]
	private int targetScore = 300;

	[SerializeField]
	private RewardSystem rewardSystem;

	public override void StartWatching()
	{
		rewardSystem.OnScoreChanged += CheckScore;
	}

	private void CheckScore(int updatedScore)
	{
		if (rewardSystem.Score >= targetScore)
		{
			rewardSystem.OnScoreChanged -= CheckScore;
			ConditionFulfilled();
		}
	}
}
