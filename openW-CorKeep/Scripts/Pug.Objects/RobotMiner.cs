using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotMiner : EntityMonoBehaviour, IProjectileShooter
{
	[Header("Energy shielid settings")]
	public EnergyShield energyShield;

	public Vector3 shieldSideFacingPosition;

	public Vector3 shieldForwardFacingPosition;

	public Vector3 shieldSideFacingScale;

	public Vector3 shieldForwardFacingScale;

	[Header("Particle settings")]
	public ParticleEffectSpawner runParticles;

	public ParticleSystem burnoutParticles;

	public ParticleSystem chargeUpChargeParticles;

	public List<ParticleEffectSpawner> miningParticles;

	public Transform miningParticlesParent;

	public List<GameObject> objectsToRotate;

	[FormerlySerializedAs("shootFromUpTransform")]
	public Vector3 shootFromUpOffset;

	[FormerlySerializedAs("shootFromDownTransform")]
	public Vector3 shootFromDownOffset;

	[FormerlySerializedAs("shootFromSideTransform")]
	public Vector3 shootFromSideOffset;

	private bool wasShieldDeployed;

	private List<AudioManager.RunningSfxReference> idleLoopingSfx = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> chargeSfx = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> chargeStartSfx = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> chargeStartSpecialSfx = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> shieldSfx = new List<AudioManager.RunningSfxReference>();

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void OnShow()
	{
		base.OnShow();
		foreach (AudioManager.RunningSfxReference item in idleLoopingSfx)
		{
			item.FadeOutAndStop();
		}
		idleLoopingSfx.Clear();
		AudioManager.SfxFollowTransform(SfxTableID.robotMinerIdleSfx, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, idleLoopingSfx);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateGraphicsFromObjectInfo(base.objectInfo);
		UpdateEnergyShieldScaling();
		wasShieldDeployed = false;
		energyShield.deployed = false;
		ShieldSfx();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1634423587)
		{
			chargeUpChargeParticles.Play();
		}
		else
		{
			chargeUpChargeParticles.Stop();
		}
		runParticles.enabled = animID == 1433117748;
		switch (animID)
		{
		case -1634423587:
			foreach (AudioManager.RunningSfxReference item in chargeStartSpecialSfx)
			{
				item.FadeOutAndStop();
			}
			chargeStartSpecialSfx.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotMinerChargeStartSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, chargeStartSpecialSfx);
			foreach (AudioManager.RunningSfxReference item2 in chargeStartSpecialSfx)
			{
				if (item2.IsValid)
				{
					item2.FadeIn(0.8f, startVolumeAtZero: true);
				}
			}
			foreach (AudioManager.RunningSfxReference item3 in chargeStartSfx)
			{
				item3.FadeOutAndStop();
			}
			chargeStartSfx.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotEnemyAnticipation1Sfx, base.transform, 2.2f, 0.85f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, chargeStartSfx);
			break;
		case 1433117748:
			if (chargeStartSfx != null)
			{
				foreach (AudioManager.RunningSfxReference item4 in chargeStartSfx)
				{
					item4.FadeOutAndStop(2f);
				}
				chargeStartSfx.Clear();
			}
			if (chargeStartSpecialSfx != null)
			{
				foreach (AudioManager.RunningSfxReference item5 in chargeStartSpecialSfx)
				{
					item5.FadeOutAndStop(1f);
				}
				chargeStartSpecialSfx.Clear();
			}
			foreach (AudioManager.RunningSfxReference item6 in chargeSfx)
			{
				item6.FadeOutAndStop();
			}
			chargeSfx.Clear();
			AudioManager.SfxFollowTransform(SfxTableID.robotMinerChargeSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, chargeSfx);
			burnoutParticles.Play();
			break;
		case 198769013:
			animID = -601574123;
			if (chargeSfx == null)
			{
				break;
			}
			foreach (AudioManager.RunningSfxReference item7 in chargeSfx)
			{
				item7.FadeOutAndStop();
			}
			chargeSfx.Clear();
			break;
		case -1997722203:
			Manager.camera.ShakeCameraNow(0.3f, 0.3f, 0.3f);
			Manager.effects.PlayPuff(PuffID.WhiteSmoke, base.transform.position + Vector3.up * 0.6f, 50);
			break;
		}
		if (animID == 1203776827)
		{
			EntityUtility.TryGetComponentData<DamageObjectStateCD>(base.entity, base.world, out var value);
			Vector3 forward = (Vector3)value.position.ToFloat3() - base.WorldPosition;
			forward.y = 0f;
			miningParticlesParent.localRotation = Quaternion.LookRotation(forward);
			foreach (ParticleEffectSpawner miningParticle in miningParticles)
			{
				miningParticle.enabled = true;
			}
		}
		else
		{
			foreach (ParticleEffectSpawner miningParticle2 in miningParticles)
			{
				miningParticle2.enabled = false;
			}
		}
		base.HandleAnimationTrigger(animID);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		runParticles.enabled = false;
		chargeUpChargeParticles.Stop();
		foreach (ParticleEffectSpawner miningParticle in miningParticles)
		{
			miningParticle.enabled = false;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<ChargeAttackStateCD>(base.entity, base.world, out var value) && math.any(value.targetDirection != float3.zero))
		{
			Quaternion localRotation = Quaternion.LookRotation(value.targetDirection);
			foreach (GameObject item in objectsToRotate)
			{
				item.transform.localRotation = localRotation;
			}
		}
		ShieldSfx();
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (idleLoopingSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item in idleLoopingSfx)
			{
				item.FadeOutAndStop();
			}
			idleLoopingSfx.Clear();
		}
		if (shieldSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item2 in shieldSfx)
			{
				item2.FadeOutAndStop();
			}
			shieldSfx.Clear();
		}
		if (chargeSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item3 in chargeSfx)
			{
				item3.FadeOutAndStop();
			}
			chargeSfx.Clear();
		}
		if (chargeStartSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item4 in chargeStartSfx)
			{
				item4.FadeOutAndStop();
			}
			chargeStartSfx.Clear();
		}
		if (chargeStartSpecialSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item5 in chargeStartSpecialSfx)
		{
			item5.FadeOutAndStop();
		}
		chargeStartSpecialSfx.Clear();
	}

	protected override void UpdateSpriteObjectsOrientation()
	{
		SpriteObjectOrientation prevSpriteObjectOrientation = m_prevSpriteObjectOrientation;
		base.UpdateSpriteObjectsOrientation();
		if (m_spriteObjectOrientation != prevSpriteObjectOrientation)
		{
			UpdateEnergyShieldScaling();
		}
	}

	private void UpdateEnergyShieldScaling()
	{
		if (m_spriteObjectOrientation == SpriteObjectOrientation.Side)
		{
			energyShield.transform.localScale = shieldSideFacingScale;
			energyShield.transform.localPosition = shieldSideFacingPosition;
		}
		else
		{
			energyShield.transform.localScale = shieldForwardFacingScale;
			energyShield.transform.localPosition = shieldForwardFacingPosition;
		}
	}

	public Vector3 GetNextProjectileStartWorldPosition()
	{
		return EntityMonoBehaviour.ToWorldFromRender(m_spriteObjectOrientation switch
		{
			SpriteObjectOrientation.Down => base.transform.position + shootFromDownOffset, 
			SpriteObjectOrientation.Up => base.transform.position + shootFromUpOffset, 
			_ => base.transform.position + new Vector3(XScaler.localScale.x * shootFromSideOffset.x, shootFromSideOffset.y, shootFromSideOffset.z), 
		});
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(base.transform.position + shootFromUpOffset, 0.1f);
		Gizmos.DrawSphere(base.transform.position + shootFromDownOffset, 0.1f);
		Gizmos.DrawSphere(base.transform.position + shootFromSideOffset, 0.1f);
	}

	private void ShieldSfx()
	{
		ShieldCD componentData = EntityUtility.GetComponentData<ShieldCD>(base.entity, base.world);
		AnimationOrientationCD componentData2 = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world);
		if (componentData.active)
		{
			energyShield.facingDirection = componentData2.facingDirection.f2;
			energyShield.arc = (float)componentData.shieldWidthDegrees / 2f;
			energyShield.deployed = true;
			if (!wasShieldDeployed)
			{
				shieldSfx.Clear();
				AudioManager.SfxFollowTransform(SfxTableID.robotMinerShieldSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, shieldSfx);
			}
			wasShieldDeployed = true;
		}
		else
		{
			energyShield.deployed = false;
			wasShieldDeployed = false;
		}
	}
}
