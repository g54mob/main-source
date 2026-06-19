using System.Collections.Generic;
using UnityEngine;

public class LarvaHiveBoss : EntityMonoBehaviour
{
	public ManagedLight bossLight;

	public Color enragedColor;

	public List<SpriteRenderer> srs;

	public PugText nameText;

	private const string names = "Names/";

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (bossLight != null)
		{
			bossLight.gameObject.SetActive(value: true);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			foreach (SpriteRenderer sr in srs)
			{
				sr.color = enragedColor;
			}
		}
		else
		{
			foreach (SpriteRenderer sr2 in srs)
			{
				sr2.color = Color.white;
			}
		}
		ObjectID objectID = base.objectData.objectID;
		nameText.Render("Names/" + objectID);
	}

	protected override bool AnimationHasHigherOrSamePrioAsTakeDamage(int animID)
	{
		if (animID != 1203776827)
		{
			return base.AnimationHasHigherOrSamePrioAsTakeDamage(animID);
		}
		return true;
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (lastAnim == -414722770 && animID == 910517187)
		{
			return false;
		}
		return true;
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.hiveMotherAnticipation, base.transform.position, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
	}

	private void AE_AttackSound()
	{
		AudioManager.Sfx(SfxID.hiveMotherShoot, base.transform.position, 1f, 1f, 0.15f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
	}

	private void AE_WakeUpSound()
	{
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
		Manager.effects.PlayPuff(PuffID.HiveMotherDeathCarapace, position);
		Manager.effects.PlayPuff(PuffID.HiveMotherDeathFlesh, position);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.Hive_Mother_Enrage, base.transform.position, 0.5f, 0.9f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
	}

	protected override void DeathEffect()
	{
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}
}
