using Pug.UnityExtensions;
using UnityEngine;

public class HydraBossSpawnNilipedeMortarProjectile : EntityMonoBehaviour
{
	public ParticleSystem sandParticles;

	public ParticleSystem explodeParticles;

	private TimerSimple anticipationSoundTimer;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth <= 0)
		{
			sandParticles.Stop(withChildren: true);
		}
		else
		{
			sandParticles.Play(withChildren: true);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.entityExist)
		{
			if (currentHealth <= 0)
			{
				sandParticles.Stop(withChildren: true);
			}
			else if (!anticipationSoundTimer.isRunning || anticipationSoundTimer.isTimerElapsed)
			{
				AudioManager.Sfx(SfxTableID.hydraBossEmergeFromGround, base.transform.position, 0.5f, 2f);
				anticipationSoundTimer.Start(0.3f);
			}
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			sandParticles.Stop(withChildren: true);
			explodeParticles.Play(withChildren: true);
			AudioManager.Sfx(SfxTableID.hydraBossEmergeFromGround, base.transform.position);
			AudioManager.Sfx(SfxTableID.fireballProjectileSpawn, base.transform.position);
		}
	}
}
