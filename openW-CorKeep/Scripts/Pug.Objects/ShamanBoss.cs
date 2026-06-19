using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class ShamanBoss : EntityMonoBehaviour
{
	public ParticleSystem TeleportEffects;

	public ManagedLight bossLight;

	private int _currentPhase;

	private static int _attackEffectsEvent = SpriteAsset.StringToHash("attackEffects");

	protected override bool hideDirectlyOnDeath => false;

	protected override bool updateAnimOrientation => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAttackEffectsEvent;
	}

	private void HandleAttackEffectsEvent(int hash)
	{
		if (hash == _attackEffectsEvent)
		{
			AE_AttackEffects();
			AE_AttackSound();
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.HasComponentData<PhaseTransitionStateCD>(base.entity, base.world))
		{
			PhaseTransitionStateCD componentData = EntityUtility.GetComponentData<PhaseTransitionStateCD>(base.entity, base.world);
			animator.SetInteger(_currentPhase, componentData.currentSyncedPhase);
			bool active = componentData.currentSyncedPhase == componentData.GetCurrentPhase((float)currentHealth / (float)GetMaxHealth()) && !componentData.isInvulnerable;
			optionalHealthBar.gameObject.SetActive(active);
			_currentPhase = componentData.currentSyncedPhase;
		}
	}

	protected override void DeathEffect()
	{
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1518581387 || animID == -1065991089 || animID == -1476340264)
		{
			AudioManager.Sfx(SfxID.fireball, base.transform.position, 0.8f, 1.5f, 0.1f);
			TeleportEffects.Play(withChildren: true);
		}
		if (animID == -33986332)
		{
			AudioManager.Sfx(SfxID.cavelingBruteDeath, base.transform.position, 1f, 1.4f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
		}
		if (animID == 1203776827 && _currentPhase == 0)
		{
			RandomChantSound();
			AudioManager.Sfx(SfxID.fireWhoosh, base.transform.position, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		}
		if (_currentPhase == 1)
		{
			switch (animID)
			{
			case -1065991089:
				base.HandleAnimationTrigger(16528305);
				break;
			case -601574123:
				base.HandleAnimationTrigger(-689712656);
				break;
			case 1203776827:
				base.HandleAnimationTrigger(-624168705);
				AE_AnticipationSound();
				break;
			default:
				base.HandleAnimationTrigger(animID);
				break;
			}
		}
		else
		{
			base.HandleAnimationTrigger(animID);
		}
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.CavelingAnticipation, base.transform.position, 0.5f, 0.4f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	private void AE_AttackSound()
	{
		AudioManager.Sfx(SfxID.CavelingAttack, base.transform.position, 0.5f, 0.4f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.whip, base.transform.position, 0.5f, 0.8f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	private void AE_AttackEffects()
	{
		AnimationOrientationCD componentData = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world);
		Vector3 position = base.transform.position + componentData.facingDirection.vec3 * 1.5f;
		if (componentData.facingDirection.vec3.z > -0.5f)
		{
			position += componentData.facingDirection.vec3 * 1f;
		}
		if (componentData.facingDirection.vec3.z > 0.5f)
		{
			position += componentData.facingDirection.vec3 * 0.35f;
		}
		AudioManager.Sfx(SfxID.CavelingAttack, base.transform.position, 0.5f, 0.6f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.whip, base.transform.position, 0.8f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.bomb2, base.transform.position, 0.75f, 1.2f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.wall, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.fireballImpact, base.transform.position, 1f, 1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		if (_currentPhase == 1)
		{
			RandomChantSound(0.95f);
		}
		if (Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2()).tileset == 1)
		{
			Manager.effects.PlayPuff(PuffID.StoneImpact, position);
		}
		else
		{
			Manager.effects.PlayPuff(PuffID.DirtImpact, position);
		}
		Manager.effects.PlayPuff(PuffID.Explosion_Medium, position);
	}

	public void AE_DeathFireWhoosh()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.FireFloaters, position, 20);
		AudioManager.Sfx(SfxTableID.shamanBossDeathFireWhoosh, position);
	}

	public void AE_StartDeathExplosion()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.BossExplosionRed, position);
		AudioManager.Sfx(SfxTableID.bossDeathAnticipation, position);
	}

	public void AE_DeathBurst()
	{
		Manager.camera.ShakeCameraNow(0.5f, 3f, 3f);
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.Explosion_Medium, position);
		AudioManager.Sfx(SfxTableID.bombDeath, position);
	}

	public void AE_PhaseTransition()
	{
		AudioManager.Sfx(SfxID.fireball, base.transform.position, 1f, 1.5f, 0.1f);
		AudioManager.Sfx(SfxID.slimeBossEnrage, base.transform.position, 0.8f, 1.3f);
		TeleportEffects.Play(withChildren: true);
	}

	public void AE_MagicBuildUpSFX()
	{
		AudioManager.Sfx(SfxID.MagicBuildup, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	protected override void OnTakeDamage()
	{
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.red);
		}
		AudioManager.SfxFollowTransform(Random.Range(0, 4) switch
		{
			0 => SfxID.Malguaz_Hurt1, 
			1 => SfxID.Malguaz_Hurt2, 
			2 => SfxID.Malguaz_Hurt3, 
			3 => SfxID.Malguaz_Hurt4, 
			_ => SfxID.Malguaz_Hurt2, 
		}, pitch: (_currentPhase != 1) ? 1f : 0.95f, transform: base.transform, volume: 1f, pitchDev: 0.1f, reuse: true, mixerGroup: AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	private void RandomChantSound(float chantPitch = 1f)
	{
		AudioManager.SfxFollowTransform(Random.Range(0, 5) switch
		{
			0 => SfxID.Malguaz_Chant1, 
			1 => SfxID.Malguaz_Chant2, 
			2 => SfxID.Malguaz_Chant3, 
			3 => SfxID.Malguaz_Chant4, 
			4 => SfxID.Malguaz_Chant5, 
			_ => SfxID.Malguaz_Chant5, 
		}, base.transform, 1f, chantPitch, 0.05f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}
}
