using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;

public class BirdBossBeam : EntityMonoBehaviour
{
	public PlatformDependentValue<OptionalValue<int>> limitConcurrentAudioSources;

	public ParticleEffectSpawner loopParticles;

	public float loopFXStartDelay;

	[ClearOnReload]
	private static int amountOfActiveAudioLoops;

	private PoolableAudioSource audioLoop;

	private int damage;

	public override void OnOccupied()
	{
		base.OnOccupied();
		loopParticles.enabled = false;
		damage = EntityUtility.GetComponentData<AttackContinuouslyCD>(base.entity, base.world).damage;
	}

	protected override void OnHide()
	{
		base.OnHide();
		StopAudioLoop();
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoop();
		StopAllCoroutines();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		FadeOutAudioLoop();
		loopParticles.enabled = false;
	}

	private void FadeOutAudioLoop()
	{
		if ((bool)audioLoop)
		{
			amountOfActiveAudioLoops--;
			audioLoop.FadeOutAndStop(0.2f);
			audioLoop = null;
		}
	}

	private void StopAudioLoop()
	{
		if ((bool)audioLoop)
		{
			amountOfActiveAudioLoops--;
			audioLoop.StopNow();
			audioLoop = null;
		}
	}

	protected override void HandleInitialAnimationTrigger(int animID)
	{
		base.HandleInitialAnimationTrigger(animID);
		HandleAnimationTrigger(animID);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1619438193 || animID == -1587601938)
		{
			StartCoroutine(LoopFX_Coroutine());
		}
		if (animID == -1587601938)
		{
			loopParticles.enabled = true;
		}
		if (animID != 16528305)
		{
			return;
		}
		FadeOutAudioLoop();
		loopParticles.enabled = false;
		_ = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			_ = particleOptions.particleSpawnLocations[0].position;
		}
		foreach (ParticlesToSpawn item in particleOptions.particlesToSpawn)
		{
			if (item.spawnOccasion != ParticleSpawnOccasion.OnDeath)
			{
				continue;
			}
			foreach (EntityMonoBehaviourPuffParams particle in item.particles)
			{
				if (particle.positionTransform.gameObject.activeInHierarchy)
				{
					Manager.effects.PlayPuff(new PuffParams
					{
						puff = particle.puff,
						particleCount = particle.particleCount
					}, particle.positionTransform.position);
				}
			}
		}
	}

	private IEnumerator LoopFX_Coroutine()
	{
		yield return new WaitForSeconds(loopFXStartDelay);
		if (!audioLoop)
		{
			OptionalValue<int> valueForCurrentPlatform = limitConcurrentAudioSources.GetValueForCurrentPlatform();
			if (!valueForCurrentPlatform.hasValue || amountOfActiveAudioLoops < valueForCurrentPlatform.value)
			{
				AudioManager.Sfx(SfxTableID.electricProjectileSpawnSfx, base.transform.position);
				audioLoop = AudioManager.SfxFollowTransform(SfxID.void_electricity_ball_loop_1_03, base.transform, 0.12f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: true, 7.5f, 6.5f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: false, isPartOfSfxTableElement: false, 0f, randomStartTime: false, 0, 2f);
				if ((bool)audioLoop)
				{
					amountOfActiveAudioLoops++;
				}
			}
		}
		loopParticles.enabled = true;
	}
}
