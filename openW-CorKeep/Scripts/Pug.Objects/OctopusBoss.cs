using Unity.Entities;
using UnityEngine;

public class OctopusBoss : EntityMonoBehaviour
{
	public Color enragedColor;

	public SpriteRenderer sr;

	public WaterSimAffector waterSimAffector;

	protected override bool hideDirectlyOnDeath => false;

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1819704882 || animID == -1518581387 || animID == -1065991089)
		{
			AudioManager.Sfx(SfxID.splash, base.transform.position, 1f, 0.6f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 30f);
			AudioManager.Sfx(SfxID.splash2, base.transform.position, 1f, 0.5f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 30f);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			sr.color = enragedColor;
		}
		else
		{
			sr.color = Color.white;
		}
		waterSimAffector.bobAmplitudeStill = ((sr.enabled && sr.gameObject.activeInHierarchy && sr.sprite != null && waterSimAffector.transform.position.y > 0f) ? 25 : 0);
	}

	private void AE_AttackSound()
	{
		AudioManager.Sfx(SfxID.hiveMotherwakeUp, base.transform.position, 1f, 0.75f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.slimeBossEnrage, base.transform.position, 1f, 0.8f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
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
		Manager.effects.PlayPuff(PuffID.OmorothDeathCarapace, position);
		Manager.effects.PlayPuff(PuffID.OmorothDeathFlesh, position);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
	}

	protected override void DeathEffect()
	{
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}

	public override void Spawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.ReserveObjects(ObjectID.OctopusBossProjectile, 36);
		base.Spawn(entity, entityManager);
	}

	public override void Despawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.UnreserveObjects(ObjectID.OctopusTentacle);
		Manager.memory.UnreserveObjects(ObjectID.OctopusBossProjectile);
		base.Despawn(entity, entityManager);
	}
}
