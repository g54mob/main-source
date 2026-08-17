namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierInvertedControls : ChallengeModifier
{
	public static bool disableInvertedControlsOptions;

	public override void Init(ChallengeData challengeData)
	{
		disableInvertedControlsOptions = true;
	}

	public override void Cleanup()
	{
	}
}
