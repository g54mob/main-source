using UnityEngine;

public class TutorialEvent_SetRewardSystemConfiguration : TutorialEvent
{
	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private RewardSystemConfiguration targetConfiguration;

	public override void Begin()
	{
		rewardSystem.SetConfiguration(targetConfiguration);
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
		Begin();
	}
}
