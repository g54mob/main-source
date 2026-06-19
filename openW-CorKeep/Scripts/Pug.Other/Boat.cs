using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Boat : EntityMonoBehaviour
{
	[Serializable]
	public class BoatSkin
	{
		public ObjectID boatID;

		public Texture2D textureFront;

		public Texture2D textureBack;
	}

	public ParticleSystem waterParticles;

	public float waterParticlesEmissionRate;

	private PoolableAudioSource audioLoop;

	public List<BoatSkin> boatSkins;

	public SpriteSheetSkin spriteSheetSkinFront;

	public SpriteSheetSkin spriteSheetSkinBack;

	public Transform visualSitPosition;

	public WaterSimAffector waterSimAffector;

	[HideInInspector]
	public float prevSpeed;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateBoatSkin();
	}

	protected override Vector3 GetAnimOrientationVec3()
	{
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null && EntityUtility.TryGetComponentData<AnimationOrientationCD>(componentData.controlledByEntity, base.world, out var value))
		{
			return value.facingDirection.f3;
		}
		return Direction.FromVector(EntityUtility.GetComponentData<DirectionCD>(base.entity, base.world).direction).vec3;
	}

	protected override float GetAnimSpeed()
	{
		float result = 0f;
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (EntityUtility.HasComponentData<AnimationSpeedCD>(componentData.controlledByEntity, base.world))
		{
			result = EntityUtility.GetComponentData<AnimationSpeedCD>(componentData.controlledByEntity, base.world).speed - 1f;
		}
		return result;
	}

	public override void UpdatePosition(bool hasLocalToWorld, in LocalToWorld localToWorld)
	{
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity == Entity.Null || (EntityUtility.TryGetComponentData<ControllingOtherEntityCD>(componentData.controlledByEntity, base.world, out var value) && value.controlledEntity != base.entity))
		{
			base.UpdatePosition(hasLocalToWorld, in localToWorld);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		float animSpeed = GetAnimSpeed();
		UpdateBoatParticles(animSpeed);
		UpdateBoatSounds(componentData, animSpeed);
	}

	private void UpdateBoatParticles(float animationSpeed)
	{
		ParticleSystem.EmissionModule emission = waterParticles.emission;
		emission.rateOverTime = animationSpeed * waterParticlesEmissionRate;
	}

	private void UpdateBoatSounds(ControlledByOtherEntityCD controlledByCD, float animationSpeed)
	{
		animationSpeed = math.lerp(prevSpeed, animationSpeed, 3f * Time.deltaTime);
		prevSpeed = animationSpeed;
		if (!(controlledByCD.controlledByEntity != Entity.Null))
		{
			if (audioLoop != null)
			{
				audioLoop.FadeOutAndStop(0.5f);
				audioLoop = null;
			}
			return;
		}
		if (audioLoop == null)
		{
			audioLoop = AudioManager.SfxFollowTransform(SfxID.Motorboat, base.transform, 0.8f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 10f);
			if (audioLoop == null)
			{
				return;
			}
		}
		float volume = math.lerp(0.2f, 1f, animationSpeed);
		float num = math.lerp(0.7f, 1f, animationSpeed);
		if (base.objectData.objectID == ObjectID.SpeederBoat)
		{
			num *= 1.3f;
		}
		audioLoop.SetVolume(volume);
		audioLoop.SetPitch(num);
	}

	private void UpdateBoatSkin()
	{
		ObjectID objectID = base.objectData.objectID;
		foreach (BoatSkin boatSkin in boatSkins)
		{
			if (boatSkin.boatID == objectID)
			{
				spriteSheetSkinBack.SetSkin(boatSkin.textureBack);
				spriteSheetSkinFront.SetSkin(boatSkin.textureFront);
				break;
			}
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		if ((bool)audioLoop)
		{
			audioLoop.StopNow();
			audioLoop = null;
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		if ((bool)audioLoop)
		{
			audioLoop.StopNow();
			audioLoop = null;
		}
	}
}
