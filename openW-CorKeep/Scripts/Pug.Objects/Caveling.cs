public class Caveling : EntityMonoBehaviour
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

	private void AE_ChatSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingChat, base.transform.position);
	}

	private void AE_ScreamSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingScream, base.transform.position);
	}

	private void AE_SleepSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingSleep, base.transform.position);
	}

	private void AE_TauntSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingTaunt, base.transform.position);
	}

	private void AE_WakeupSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingWakeup, base.transform.position);
	}

	private void AE_YawnSound()
	{
		AudioManager.Sfx(SfxTableID.cavelingYawn, base.transform.position);
	}

	protected override void OnTakeDamage()
	{
		soundOptions.takeDamageSfx.value = ((base.objectData.objectID == ObjectID.VoidCaveling) ? SfxTableID.voidCavelingTakeDamageSfx : SfxTableID.cavelingTakeDamage);
		base.OnTakeDamage();
	}

	protected override void OnDeath()
	{
		soundOptions.deathSfx.value = ((base.objectData.objectID == ObjectID.VoidCaveling) ? SfxTableID.voidCavelingDeathSfx : SfxTableID.cavelingDeath);
		base.OnDeath();
	}
}
