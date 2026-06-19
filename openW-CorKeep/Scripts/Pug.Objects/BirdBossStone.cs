using System;
using System.Collections.Generic;
using PlayerEquipment;
using Pug.Sprite;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

public class BirdBossStone : EntityMonoBehaviour
{
	[Serializable]
	public class Beams
	{
		public List<LineRenderer> beamRenderers;
	}

	public List<Beams> beams;

	public ParticleEffectSpawner particleSystems;

	public ParticleSystem energyShockwave;

	private int crystalState;

	private bool chargedThisFrame;

	private bool chargeEffectHasPlayed;

	public SpriteObject crystalSprite;

	private PoolableAudioSource audioLoop;

	private PugQuerySystem _querySystem;

	public AnimationCurve activeFlashCurve;

	public override void OnOccupied()
	{
		base.OnOccupied();
		crystalState = 0;
		_querySystem = base.world.GetExistingSystemManaged<PugQuerySystem>();
		particleSystems.enabled = false;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		HealNearbyEntitiesCD componentData = EntityUtility.GetComponentData<HealNearbyEntitiesCD>(base.entity, base.world);
		chargedThisFrame = crystalState == 0 && componentData.isActive;
		crystalState = (componentData.isActive ? 1 : 0);
		if (chargedThisFrame)
		{
			particleSystems.enabled = true;
			crystalSprite.PlayAnimation(1260321794);
			if (!chargeEffectHasPlayed)
			{
				chargeEffectHasPlayed = true;
				Manager.effects.PlayPuff(PuffID.EnergyExplosion, base.RenderPosition + new Vector3(0.5f, 0.2f, 0f));
				AudioManager.Sfx(SfxID.ElectricShock1, base.RenderPosition, 0.2f, 1.4f, 0.1f, reuse: true);
				flashable.Flash(activeFlashCurve, Color.white, 1f);
			}
		}
		foreach (Beams beam in beams)
		{
			foreach (LineRenderer beamRenderer in beam.beamRenderers)
			{
				beamRenderer.gameObject.SetActive(value: false);
			}
		}
		bool flag = false;
		if (componentData.isActive && !base.isHidden)
		{
			CollisionWorld collisionWorld = PhysicsManager.GetCollisionWorld();
			NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			ColliderCacheCD singleton = _querySystem.GetSingleton<ColliderCacheCD>();
			PhysicsCollider sphereCollider = PhysicsManager.GetSphereCollider(new float3(0f, 0f, 0f), componentData.radius, 16u, singleton);
			Vector3 worldPosition = base.WorldPosition;
			collisionWorld.CastCollider(PhysicsManager.GetColliderCastInput(worldPosition, worldPosition, sphereCollider), ref allHits);
			int num = 0;
			foreach (ColliderCastHit item in allHits)
			{
				if (num >= beams.Count)
				{
					break;
				}
				Entity entityToHeal = item.Entity;
				if (!CanHealEntity(entityToHeal, componentData))
				{
					continue;
				}
				EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(entityToHeal);
				if (!(entityMono != null))
				{
					continue;
				}
				Vector3 position = entityMono.center + new Vector3(0f, 0.25f, 0f);
				foreach (LineRenderer beamRenderer2 in beams[num].beamRenderers)
				{
					beamRenderer2.gameObject.SetActive(value: true);
					beamRenderer2.SetPosition(0, center);
					beamRenderer2.SetPosition(1, position);
					flag = true;
				}
				num++;
				if (!energyShockwave.isPlaying)
				{
					energyShockwave.Play(withChildren: true);
				}
			}
			if (allHits.IsEmpty)
			{
				energyShockwave.Stop(withChildren: true);
			}
			allHits.Dispose();
		}
		if (!audioLoop && flag)
		{
			audioLoop = AudioManager.SfxFollowTransform(SfxID.Bird_Boss_Heal1, base.transform, 0.3f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true);
		}
		else if (!flag)
		{
			FadeOutAudioLoop();
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			OnDeath();
		}
	}

	private bool CanHealEntity(Entity entityToHeal, HealNearbyEntitiesCD healInfo)
	{
		if (!EntityUtility.HasComponentData<IsBeingBeHealedByOtherEntitiesCD>(entityToHeal, base.world))
		{
			return false;
		}
		FactionID factionID = (EntityUtility.HasComponentData<FactionCD>(entityToHeal, base.world) ? EntityUtility.GetComponentData<FactionCD>(entityToHeal, base.world).faction : FactionID.None);
		if (healInfo.healsTargetsOfFaction != factionID)
		{
			return false;
		}
		if ((EntityUtility.HasComponentData<LocalTransform>(entityToHeal, base.world) ? math.distance(EntityUtility.GetComponentData<LocalTransform>(entityToHeal, base.world).Position, base.WorldPosition) : 10000f) > healInfo.radius)
		{
			return false;
		}
		return true;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position + new Vector3(0.5f, 0.2f, 0f);
		Manager.effects.PlayPuff(PuffID.CrystalDebris, position);
		AudioManager.Sfx(SfxID.wall, position, 1f, 1.5f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		particleSystems.enabled = false;
		energyShockwave.Stop(withChildren: true);
		if ((bool)audioLoop)
		{
			audioLoop.StopNow();
			audioLoop = null;
		}
	}

	private void FadeOutAudioLoop()
	{
		if ((bool)audioLoop)
		{
			audioLoop.FadeOutAndStop(0.2f);
			audioLoop = null;
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		FadeOutAudioLoop();
	}

	public override void OnFree()
	{
		base.OnFree();
		FadeOutAudioLoop();
	}

	protected override void OnTakeDamage()
	{
		AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform);
		TryAddWaterImpulse();
	}
}
