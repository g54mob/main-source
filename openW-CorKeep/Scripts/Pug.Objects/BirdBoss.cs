using System.Collections.Generic;
using Pug.Sprite;
using Unity.Entities;
using UnityEngine;

public class BirdBoss : EntityMonoBehaviour
{
	public GameObject flyingSRPivot;

	public ParticleSystem TeleportEffects;

	[ColorUsage(false, true)]
	public Color emissiveMaxColor = Color.white;

	public Color enragedColor;

	public ParticleSystem dustCircleParticles;

	public SpriteObject bodySprite;

	public SpriteObject wingLeftSprite;

	public SpriteObject wingRightSprite;

	public List<DataBlockRef<GradientMapDataBlock>> bodyAltPalettes;

	public List<DataBlockRef<GradientMapDataBlock>> wingAltPalettes;

	private int randSkin;

	private const int randSkinChance = 1000000;

	public SpriteSkinFromEntityAndSeason spriteSkinFromEntityAndSeason;

	protected override bool hideDirectlyOnDeath => false;

	public override Vector3 center => base.center + Vector3.up * 1.75f + Vector3.right * 0.5f + Vector3.back * 0.25f;

	public override void OnOccupied()
	{
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			spriteObject.emissiveColor = emissiveMaxColor;
		}
		base.OnOccupied();
		spriteSkinFromEntityAndSeason.UpdateGraphicsFromObjectInfo(base.objectInfo);
		UpdateSkin();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.GetComponentData<EnrageStateCD>(base.entity, base.world).isEnraged)
		{
			bodySprite.color = enragedColor;
			wingLeftSprite.color = enragedColor;
			wingRightSprite.color = enragedColor;
		}
		else
		{
			bodySprite.color = Color.white;
			wingLeftSprite.color = Color.white;
			wingRightSprite.color = Color.white;
		}
		UpdateSkin();
	}

	private void UpdateSkin()
	{
		int num = randSkin;
		if (num == 1 || num == 2 || num == 3)
		{
			int index = randSkin - 1;
			bodySprite.primaryGradientMapRef = bodyAltPalettes[index];
			wingLeftSprite.primaryGradientMapRef = wingAltPalettes[index];
			wingRightSprite.primaryGradientMapRef = wingAltPalettes[index];
		}
		ApplyVisualChange();
	}

	private void ApplyVisualChange()
	{
		bodySprite.ApplyVisualChange();
		wingLeftSprite.ApplyVisualChange();
		wingRightSprite.ApplyVisualChange();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		switch (animID)
		{
		case 1244953283:
			flyingSRPivot.transform.localEulerAngles = new Vector3(0f, Random.Range(0, 360), 0f);
			break;
		case -1476340264:
			spriteSkinFromEntityAndSeason.UpdateGraphicsFromObjectInfo(base.objectInfo);
			randSkin = Random.Range(0, 1000000);
			UpdateSkin();
			break;
		default:
			flyingSRPivot.transform.localEulerAngles = Vector3.zero;
			break;
		}
		base.HandleAnimationTrigger(animID);
	}

	public void AE_TeleportEffect()
	{
		AudioManager.Sfx(SfxID.Bird_Boss_Teleport, base.transform.position, 1f, 1f, 0.05f);
		TeleportEffects.Clear(withChildren: true);
		TeleportEffects.Play(withChildren: true);
	}

	public void AE_Spark()
	{
		AudioManager.Sfx(SfxTableID.azeosSpark, base.transform.position);
	}

	public void AE_DustCircle()
	{
		dustCircleParticles.Play();
	}

	public void AE_FlyAboveScreech()
	{
		AudioManager.Sfx(SfxID.birdScreech, base.transform.position, 0.2f, 1.05f, 0.085f);
	}

	public void AE_CameraShake(int type)
	{
		switch (type)
		{
		case 1:
			Manager.camera.ShakeCameraNow(0.4f, 0.1f, 0.5f);
			return;
		case 2:
			Manager.camera.ShakeCameraNow(0.7f, 0.4f);
			return;
		}
		PlayerController player = Manager.main.player;
		if (player != null && Vector3.Distance(player.RenderPosition, base.RenderPosition) < 20f)
		{
			Manager.camera.ShakeCameraNow(0.6f);
		}
	}

	public void AE_WingWhoosh()
	{
		AudioManager.Sfx(SfxTableID.azeosWingWhoosh, base.transform.position);
	}

	public void AE_Getup()
	{
		AudioManager.Sfx(SfxTableID.azeosWingWhooshSmall, base.transform.position);
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
		Manager.effects.PlayPuff(PuffID.AzeosDeathBlue, position, 30);
		Manager.effects.PlayPuff(PuffID.BigBlueFur, position, 30);
		Manager.effects.PlayPuff(PuffID.AzeosDeathYellow, position);
		Manager.effects.PlayPuff(PuffID.BigYellowFur, position, 30);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position, 30f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
	}

	public void PlayAnimation(int animNumb)
	{
		int num = -601574123;
		num = animNumb switch
		{
			1 => -568891545, 
			2 => 46335079, 
			3 => -1476340264, 
			4 => 1819704882, 
			_ => -601574123, 
		};
		if (bodySprite.currentAnimationHash != num)
		{
			bodySprite.PlayAnimation(num);
			bodySprite.ApplyVisualChange();
		}
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

	public override void Spawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.ReserveObjects(ObjectID.BirdBossBeam, 50);
		base.Spawn(entity, entityManager);
	}

	public override void Despawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.UnreserveObjects(ObjectID.BirdBossBeam);
		base.Despawn(entity, entityManager);
	}
}
