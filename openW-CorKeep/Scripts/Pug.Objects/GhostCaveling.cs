public class GhostCaveling : EntityMonoBehaviour
{
	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770 && hasShadow)
		{
			shadow.SetActive(value: false);
		}
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.CavelingAnticipation, base.transform.position, 0.5f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	private void AE_AttackSound()
	{
		AudioManager.Sfx(SfxID.CavelingAttack, base.transform.position, 0.5f, 0.9f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.whip, base.transform.position, 0.8f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}
}
