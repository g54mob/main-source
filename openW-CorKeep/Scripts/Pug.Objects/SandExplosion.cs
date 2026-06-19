using Pug.UnityExtensions;
using UnityEngine;

public class SandExplosion : EntityMonoBehaviour
{
	public ParticleEffectSpawner sandParticles;

	public ParticleSystem sandExplosionParticles;

	public ParticleSystem sandDebrisParticles;

	public PlatformDependentValue<OptionalValue<int>> limitSandDebrisBurst;

	public ParticleSystem shockwaveParticles;

	public PlatformDependentValue<OptionalValue<int>> limitShockwaveBurst;

	public ParticleSystem circularSmokeParticles;

	public PlatformDependentValue<OptionalValue<int>> limitCircularSmokeBurst;

	private TimerSimple anticipationSoundTimer;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		OptionalValue<int> valueForCurrentPlatform = limitSandDebrisBurst.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform.hasValue)
		{
			sandDebrisParticles.emission.SetBurst(0, new ParticleSystem.Burst(0f, valueForCurrentPlatform.value));
		}
		OptionalValue<int> valueForCurrentPlatform2 = limitShockwaveBurst.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform2.hasValue)
		{
			shockwaveParticles.emission.SetBurst(0, new ParticleSystem.Burst(0f, valueForCurrentPlatform2.value));
		}
		OptionalValue<int> valueForCurrentPlatform3 = limitCircularSmokeBurst.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform3.hasValue)
		{
			circularSmokeParticles.emission.SetBurst(0, new ParticleSystem.Burst(0f, valueForCurrentPlatform3.value));
		}
	}

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
