using System.Collections.Generic;
using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

public class Drill : EntityMonoBehaviour
{
	public List<ParticleEffectSpawner> DrillParticles;

	private int prevVariation;

	private int drillingState;

	private AttackContinuouslyCD attackContinuously;

	private float lastTriggerTime;

	private float timeBetweenAttacks;

	private PoolableAudioSource drillAudioLoop;

	public TimerSimple drillEffectCheckTimer = new TimerSimple(0.5f);

	private CollisionFilter collisionFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 1u
	};

	public override void OnOccupied()
	{
		base.OnOccupied();
		attackContinuously = EntityUtility.GetComponentData<AttackContinuouslyCD>(base.entity, base.world);
		timeBetweenAttacks = attackContinuously.attackTime + attackContinuously.cooldown;
		prevVariation = -1;
		drillingState = -1;
		drillEffectCheckTimer.Stop();
		foreach (ParticleEffectSpawner drillParticle in DrillParticles)
		{
			drillParticle.enabled = false;
		}
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		if (drillAudioLoop != null)
		{
			drillAudioLoop.FadeOutAndStop();
			drillAudioLoop = null;
		}
		base.OnHide();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == 1203776827)
		{
			lastTriggerTime = Time.time;
		}
		base.HandleAnimationTrigger(animID);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		int num = base.variation;
		if (num != prevVariation)
		{
			XScaler.localScale = new Vector3((num != 3) ? 1 : (-1), 1f, 1f);
			switch (num)
			{
			case 0:
				SetOrientation(Vector3.forward);
				break;
			case 1:
				SetOrientation(Vector3.right);
				break;
			case 2:
				SetOrientation(Vector3.back);
				break;
			case 3:
				SetOrientation(Vector3.left);
				break;
			}
			prevVariation = num;
		}
		int num2 = (EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world).hasEnoughElectricityToPowerStuff ? 1 : 0);
		if (drillingState != num2)
		{
			drillingState = num2;
			if (drillingState == 0)
			{
				spriteObjects[0].PlayAnimation(-1949102368, m_spriteObjectOrientationHash);
				if (drillAudioLoop != null)
				{
					drillAudioLoop.FadeOutAndStop();
					drillAudioLoop = null;
				}
			}
			else
			{
				spriteObjects[0].PlayAnimation(1260321794, m_spriteObjectOrientationHash);
				if (drillAudioLoop == null)
				{
					drillAudioLoop = AudioManager.SfxFollowTransform(SfxID.minecart, base.transform, 0.5f, 1.2f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 4f, 4f);
				}
			}
		}
		bool flag = false;
		if (drillEffectCheckTimer.isRunning && !drillEffectCheckTimer.isTimerElapsed)
		{
			return;
		}
		drillEffectCheckTimer.Start();
		if (drillingState == 1)
		{
			int2 directionFromVariation = DirectionBasedOnVariationCD.GetDirectionFromVariation(num);
			flag = PhysicsManager.GetCollisionWorld().CheckSphere(base.WorldPosition + new Vector3(directionFromVariation.x, 0.25f, directionFromVariation.y), 0f, collisionFilter);
		}
		if (flag && !DrillParticles[0].enabled)
		{
			foreach (ParticleEffectSpawner drillParticle in DrillParticles)
			{
				drillParticle.enabled = true;
			}
			return;
		}
		if (flag || !DrillParticles[0].enabled)
		{
			return;
		}
		foreach (ParticleEffectSpawner drillParticle2 in DrillParticles)
		{
			drillParticle2.enabled = false;
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (animID != 1203776827)
		{
			return base.ShouldPlayAnimTrigger(animID);
		}
		return false;
	}
}
