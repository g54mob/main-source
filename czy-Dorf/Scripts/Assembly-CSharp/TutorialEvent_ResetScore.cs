using UnityEngine;

public class TutorialEvent_ResetScore : TutorialEvent
{
	[SerializeField]
	private RewardSystem rewardSystem;

	public override void Begin()
	{
		rewardSystem.ResetScore(0);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
		Begin();
	}
}
