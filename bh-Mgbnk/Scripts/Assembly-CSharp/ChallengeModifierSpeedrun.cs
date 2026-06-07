using UnityEngine;

[CreateAssetMenu(menuName = "Me/Progression/Challenge/ChallengeModifiers/Speedrun", order = 1)]
public class ChallengeModifierSpeedrun : ChallengeModifier
{
	public float timeLimitMinutes;

	private bool isFinalBossKilled;

	public float timeLeftOnStage { get; private set; }

	public override void Init(ChallengeData challengeData)
	{
	}

	public override void Cleanup()
	{
	}

	private void OnFinalBossDefeated(bool obj)
	{
	}

	private void OnStageBossDied(bool obj)
	{
	}

	private void OnStageStarted()
	{
	}

	public override void Tick()
	{
	}
}
