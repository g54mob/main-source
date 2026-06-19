using System;
using System.Collections.Generic;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class GoKart : EntityMonoBehaviour
{
	[Serializable]
	public class VehicleSkin
	{
		public ObjectID vehicleID;

		public Texture2D textureFront;

		public Texture2D textureBack;
	}

	private enum VehicleState
	{
		UNDEFINED = 0,
		OFF = 1,
		IDLE = 2,
		MOVING = 3
	}

	public Transform effectsDirection;

	public ParticleSystem dirtParticles;

	public ParticleSystem smokeParticles;

	public ParticleSystem trackLParticles;

	public ParticleSystem trackRParticles;

	public SfxUnityInspectorFriendlyID motorSound;

	public float dirtParticlesEmissionRate;

	public float smokeParticlesEmissionRate;

	public float trackParticlesEmissionRate;

	protected PoolableAudioSource audioLoop;

	public List<VehicleSkin> vehicleSkins;

	public SpriteSheetSkin spriteSheetSkinFront1;

	public SpriteSheetSkin spriteSheetSkinFront2;

	public SpriteSheetSkin spriteSheetSkinBack1;

	public SpriteSheetSkin spriteSheetSkinBack2;

	private VehicleState currentState;

	protected override bool updateAnimOrientation => false;

	protected override bool updateAnimMovement => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		UpdateVehicleSkin();
		currentState = VehicleState.UNDEFINED;
		EnableOutlineController(value: true);
	}

	protected override Vector3 GetAnimOrientationVec3()
	{
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null && EntityUtility.TryGetComponentData<VehicleRidingStateCD>(componentData.controlledByEntity, base.world, out var value))
		{
			return value.drivingDirection;
		}
		return EntityUtility.GetComponentData<DirectionCD>(base.entity, base.world).direction;
	}

	protected override float GetAnimSpeed()
	{
		float result = 0f;
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null && EntityUtility.TryGetComponentData<AnimationSpeedCD>(componentData.controlledByEntity, base.world, out var value))
		{
			result = value.speed - 1f;
		}
		return result;
	}

	private float2 GetVelocity()
	{
		float2 result = float2.zero;
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null && EntityUtility.TryGetComponentData<EffectiveVelocityCD>(componentData.controlledByEntity, base.world, out var value))
		{
			result = value.Value;
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
		float animSpeed = GetAnimSpeed();
		float2 velocity = GetVelocity();
		float num = math.clamp(math.length(velocity) / 3f, 0f, 1f);
		if (currentState == VehicleState.OFF)
		{
			EnableOutlineController(value: true);
		}
		else
		{
			EnableOutlineController(value: false);
		}
		VehicleState vehicleState = VehicleState.OFF;
		if (EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world).controlledByEntity != Entity.Null)
		{
			vehicleState = ((!(num > 0.01f)) ? VehicleState.IDLE : VehicleState.MOVING);
			if (audioLoop == null)
			{
				audioLoop = AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(motorSound), base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 10f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
		}
		else if (audioLoop != null)
		{
			audioLoop.FadeOutAndStop(0.5f);
			audioLoop = null;
		}
		if (currentState != vehicleState)
		{
			currentState = vehicleState;
			switch (currentState)
			{
			case VehicleState.OFF:
				animator.SetTrigger(-568891545);
				break;
			case VehicleState.IDLE:
				animator.SetTrigger(-1458546703);
				break;
			case VehicleState.MOVING:
				animator.SetTrigger(806946379);
				break;
			}
		}
		effectsDirection.rotation = (math.any(velocity != float2.zero) ? Quaternion.LookRotation(-velocity.ToFloat3(), Vector3.up) : default(Quaternion));
		ParticleSystem.EmissionModule emission = dirtParticles.emission;
		float num2 = animSpeed * dirtParticlesEmissionRate;
		if (num2 < 1f)
		{
			num2 = 0f;
		}
		emission.rateOverTime = num2;
		ParticleSystem.EmissionModule emission2 = smokeParticles.emission;
		num2 = animSpeed * smokeParticlesEmissionRate;
		if (num2 < 1f)
		{
			num2 = 0f;
		}
		emission2.rateOverTime = num2;
		ParticleSystem.EmissionModule emission3 = trackLParticles.emission;
		ParticleSystem.EmissionModule emission4 = trackRParticles.emission;
		emission3.rateOverTime = num * trackParticlesEmissionRate;
		emission4.rateOverTime = num * trackParticlesEmissionRate;
		SetMotorValues(animSpeed);
	}

	private void EnableOutlineController(bool value)
	{
		if (interactable.optionalOutlineController.enabled == value)
		{
			return;
		}
		interactable.optionalOutlineController.enabled = value;
		if (!value)
		{
			interactable.optionalOutlineController.showOutline = false;
			interactable.optionalOutlineController.ManagedLateUpdate();
		}
		foreach (OutlineController additionalOutlineController in interactable.additionalOutlineControllers)
		{
			additionalOutlineController.enabled = value;
			if (!value)
			{
				additionalOutlineController.showOutline = false;
				additionalOutlineController.ManagedLateUpdate();
			}
		}
	}

	private void UpdateVehicleSkin()
	{
		ObjectID objectID = base.objectData.objectID;
		foreach (VehicleSkin vehicleSkin in vehicleSkins)
		{
			if (vehicleSkin.vehicleID == objectID)
			{
				spriteSheetSkinBack1.SetSkin(vehicleSkin.textureBack);
				spriteSheetSkinBack2.SetSkin(vehicleSkin.textureBack);
				spriteSheetSkinFront1.SetSkin(vehicleSkin.textureFront);
				spriteSheetSkinFront2.SetSkin(vehicleSkin.textureFront);
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

	protected virtual void SetMotorValues(float speed)
	{
		float volume = math.lerp(0.2f, 1f, speed);
		float pitch = math.lerp(0.7f, 1f, speed);
		if ((bool)audioLoop)
		{
			audioLoop.SetVolume(volume);
			audioLoop.SetPitch(pitch);
		}
	}
}
