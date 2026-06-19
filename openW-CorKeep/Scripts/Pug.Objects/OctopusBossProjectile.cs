using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class OctopusBossProjectile : Projectile
{
	public PlatformDependentValue<OptionalValue<int>> limitConcurrentAudioSources;

	public ParticleSystem WhirlwindParticles;

	public ParticleSystem brightSwirlParticles;

	public PlatformDependentValue<OptionalValue<int>> limitBrightSwirlRate;

	public ParticleSystem mainSwirlParticles;

	public PlatformDependentValue<OptionalValue<int>> limitMainSwirlRate;

	public ParticleSystem debrisFieldParticles;

	public PlatformDependentValue<OptionalValue<int>> limitDebrisFieldRate;

	public ParticleSystem starSparklesParticles;

	public PlatformDependentValue<OptionalValue<int>> limitStarSparklesRate;

	public SpriteObject shadowSO;

	public PlatformDependentValue<bool> disableShadow;

	private PoolableAudioSource audioLoop;

	[ClearOnReload]
	private static int amountOfActiveAudioLoops;

	protected override void Awake()
	{
		base.Awake();
		OptionalValue<int> valueForCurrentPlatform = limitBrightSwirlRate.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform.hasValue)
		{
			ParticleSystem.EmissionModule emission = brightSwirlParticles.emission;
			emission.rateOverTime = valueForCurrentPlatform.value;
		}
		OptionalValue<int> valueForCurrentPlatform2 = limitMainSwirlRate.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform2.hasValue)
		{
			ParticleSystem.EmissionModule emission2 = mainSwirlParticles.emission;
			emission2.rateOverTime = valueForCurrentPlatform2.value;
		}
		OptionalValue<int> valueForCurrentPlatform3 = limitDebrisFieldRate.GetValueForCurrentPlatform();
		if (valueForCurrentPlatform3.hasValue)
		{
			ParticleSystem.EmissionModule emission3 = debrisFieldParticles.emission;
			emission3.rateOverTime = valueForCurrentPlatform3.value;
		}
		if (starSparklesParticles != null)
		{
			OptionalValue<int> valueForCurrentPlatform4 = limitStarSparklesRate.GetValueForCurrentPlatform();
			if (valueForCurrentPlatform4.hasValue)
			{
				ParticleSystem.EmissionModule emission4 = starSparklesParticles.emission;
				emission4.rateOverTime = valueForCurrentPlatform4.value;
			}
		}
		if (disableShadow.GetValueForCurrentPlatform())
		{
			shadowSO.enabled = false;
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		OptionalValue<int> valueForCurrentPlatform = limitConcurrentAudioSources.GetValueForCurrentPlatform();
		if (!valueForCurrentPlatform.hasValue || amountOfActiveAudioLoops < valueForCurrentPlatform.value)
		{
			audioLoop = AudioManager.SfxFollowTransform(SfxID.windLoop, base.transform, 0.8f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 6f);
			if ((bool)audioLoop)
			{
				amountOfActiveAudioLoops++;
			}
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		WhirlwindParticles.Stop(withChildren: true);
		if ((bool)audioLoop)
		{
			amountOfActiveAudioLoops--;
			audioLoop.FadeOutAndStop(0.2f);
			audioLoop = null;
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		if ((bool)audioLoop)
		{
			amountOfActiveAudioLoops--;
			audioLoop.StopNow();
			audioLoop = null;
		}
	}
}
