using Unity.Entities;
using UnityEngine;

public class SlimeBoss : EntityMonoBehaviour
{
	public SpriteRenderer sr;

	public ParticleSystem landingExplosion;

	public ManagedLight bossLight;

	public Color enragedColor;

	public GameObject slimeMerchant;

	private EntityQuery worldInfoQuery;

	protected override bool hideDirectlyOnDeath => false;

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
		if (slimeMerchant != null)
		{
			slimeMerchant.SetActive(!worldInfoQuery.IsEmpty && !worldInfoQuery.GetSingleton<WorldInfoCD>().slimeMerchantExists);
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (bossLight != null)
		{
			bossLight.gameObject.SetActive(value: true);
		}
		worldInfoQuery = Manager.ecs.GetClientEntityQuery(typeof(WorldInfoCD));
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		bool flag = true;
		if (lastAnim == -1476340264 && animID == -601574123)
		{
			flag = false;
		}
		return base.ShouldPlayAnimTrigger(animID) && flag;
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.slimeAnticipation, base.transform.position, 0.8f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
	}

	private void AE_AttackSound()
	{
		AudioManager.Sfx(SfxID.jump2, base.transform.position, 0.8f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.slimeBossEnrage, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	public void AE_LandingEffect()
	{
		if (!(Manager.main.player == null))
		{
			landingExplosion.Play();
			AudioManager.Sfx(SfxID.SlimeBossImpact, base.transform.position, 1f, 1f, 0.2f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 52f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			float num = 50f;
			float num2 = Mathf.Clamp((Manager.main.player.transform.position - base.transform.position).magnitude, 0f, num);
			float num3 = 4f * (1f - num2 / num);
			Manager.camera.ShakeCameraNow(0.2f, num3, num3);
		}
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
		DeathParticles();
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position);
	}

	protected virtual void DeathParticles()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.OrangeSlime, position);
		Manager.effects.PlayPuff(PuffID.OrangeSlimeSmall, position);
	}

	public void AE_BossEnding()
	{
		_ = GetVariationsParticleSpawnLocation().position;
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}

	protected override void DeathEffect()
	{
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}
}
