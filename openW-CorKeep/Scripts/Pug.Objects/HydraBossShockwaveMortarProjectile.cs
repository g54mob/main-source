using Pug.UnityExtensions;

public class HydraBossShockwaveMortarProjectile : EntityMonoBehaviour
{
	public NukeAttackFX nukeAttackFX;

	private TimerSimple anticipationSoundTimer;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			nukeAttackFX.Play();
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.entityExist && currentHealth > 0 && (!anticipationSoundTimer.isRunning || anticipationSoundTimer.isTimerElapsed))
		{
			AudioManager.Sfx(SfxTableID.hydraBossShockwaveAnticipation, base.transform.position);
			anticipationSoundTimer.Start(0.2f);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			AudioManager.Sfx(SfxTableID.hydraBossShockwaveDamage, base.transform.position);
		}
	}
}
