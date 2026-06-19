using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ScarabBoss : EntityMonoBehaviour
{
	public Color enragedColor;

	public SpriteRenderer sr;

	public List<SpriteRenderer> SRsToEnrage;

	public ParticleSystem explodeParticles;

	private PoolableAudioSource digAudioLoop;

	public List<ParticleSystem> particlesToReduceOnLowQuality;

	private List<int> particlesMaxCount;

	private const float particleReductionMultiplier = 0.2f;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		InitParticlesQuality();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateParticlesQuality();
	}

	private void InitParticlesQuality()
	{
		particlesMaxCount = new List<int>(particlesToReduceOnLowQuality.Count);
		for (int i = 0; i < particlesToReduceOnLowQuality.Count; i++)
		{
			particlesMaxCount.Add(particlesToReduceOnLowQuality[i].main.maxParticles);
		}
	}

	private void UpdateParticlesQuality()
	{
		bool flag = Manager.prefs.particleQuality == 0;
		for (int i = 0; i < particlesToReduceOnLowQuality.Count; i++)
		{
			ParticleSystem.MainModule main = particlesToReduceOnLowQuality[i].main;
			main.maxParticles = (int)math.round(flag ? ((float)particlesMaxCount[i] * 0.2f) : ((float)particlesMaxCount[i]));
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool isEnraged = EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged;
		foreach (SpriteRenderer item in SRsToEnrage)
		{
			item.color = (isEnraged ? enragedColor : Color.white);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1664757979)
		{
			explodeParticles.Play(withChildren: true);
		}
		if (animID == 1819704882)
		{
			explodeParticles.Play(withChildren: true);
		}
		if (animID == 1433117748 && !digAudioLoop)
		{
			digAudioLoop = AudioManager.SfxFollowTransform(SfxID.Scarab_Titan_burrow_loop, base.transform, 0.6f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 30f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
		if (animID == -1664757979 && (bool)digAudioLoop)
		{
			digAudioLoop.FadeOutAndStop(0.25f);
			digAudioLoop = null;
		}
		if (animID == -1014102059)
		{
			AudioManager.Sfx(SfxID.MagicBuildup, base.transform.position, 0.5f, 1.2f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 20f);
		}
	}

	private void AE_AttackSound()
	{
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			AudioManager.Sfx(SfxID.scarabBossAttack, base.transform.position, 0.5f, 0.85f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
		}
		else
		{
			AudioManager.Sfx(SfxID.scarabBossAttack, base.transform.position, 0.3f, 1.1f, 0.15f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
		}
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.scarabBossAttack, base.transform.position, 1f, 0.8f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	private void AE_PlayDigSound()
	{
		AudioManager.SfxFollowTransform(SfxID.snowfootstep, base.transform, 0.35f, 0.25f, 0.1f);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)digAudioLoop)
		{
			digAudioLoop.StopNow();
			digAudioLoop = null;
		}
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}

	public void AE_StartDeathExplosion()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.BossExplosionBlue, position);
		AudioManager.Sfx(SfxTableID.bossDeathAnticipation, position);
	}

	public void AE_DeathBurst()
	{
		Manager.camera.ShakeCameraNow(0.5f, 3f, 3f);
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.RaAkarDeathGreen, position, 15);
		Manager.effects.PlayPuff(PuffID.RaAkarDeathOrange, position, 15);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
	}
}
