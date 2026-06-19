using Pug.UnityExtensions;
using UnityEngine;

public class GiantCicadaSandExplosion : EntityMonoBehaviour
{
	public ParticleEffectSpawner sandParticles;

	public ParticleSystem sandExplosionParticles;

	public ParticleSystem sandDebrisParticles;

	public ParticleSystem shockwaveParticles;

	public ParticleSystem circularSmokeParticles;

	private TimerSimple anticipationSoundTimer;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth <= 0)
		{
			sandParticles.enabled = false;
		}
		else
		{
			sandParticles.enabled = true;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (currentHealth <= 0)
		{
			sandParticles.enabled = false;
		}
		else if (!anticipationSoundTimer.isRunning || anticipationSoundTimer.isTimerElapsed)
		{
			AudioManager.Sfx(SfxID.fireball, base.transform.position, 0.05f, 1.6f, 0.2f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
			anticipationSoundTimer.Start(0.2f);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			sandParticles.enabled = false;
			sandExplosionParticles.Play(withChildren: true);
			AudioManager.Sfx(SfxID.fireball, base.transform.position, 0.4f, 2f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		}
	}
}
