using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Minecart : EntityMonoBehaviour
{
	private const float MAX_ANIM_SPEED = 1.6f;

	public float QUICK_TURN_SPEED_THRESHOLD = 1f;

	public float QUICK_STOP_SPEED_DIFF = 0.6f;

	public ParticleSystem brakeParticles1;

	public ParticleSystem brakeParticles2;

	private float previousAnimSpeed;

	private Vector3 previousOrientation;

	public SfxUnityInspectorFriendlyID loopSound;

	public SfxUnityInspectorFriendlyID loopBrakeSound;

	private PoolableAudioSource minecartAudioLoop;

	private PoolableAudioSource brakeAudioLoop;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override float GetAnimSpeed()
	{
		float num = 0f;
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null && Manager.memory.GetEntityMono(componentData.controlledByEntity) is PlayerController playerController && playerController != null && EntityUtility.TryGetComponentData<MinecartRidingStateCD>(playerController.entity, playerController.world, out var value))
		{
			num = math.length(value.activeVelocity) / 500f;
		}
		if (num > 0.01f)
		{
			num = math.max(num, 0.3f);
		}
		return num;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		previousAnimSpeed = GetAnimSpeed();
	}

	public override void OnFree()
	{
		StopLoopingSounds();
		base.OnFree();
	}

	private void StopLoopingSounds()
	{
		if (minecartAudioLoop != null)
		{
			minecartAudioLoop.FadeOutAndStop();
			minecartAudioLoop = null;
		}
		if (brakeAudioLoop != null)
		{
			brakeAudioLoop.FadeOutAndStop();
			brakeAudioLoop = null;
		}
	}

	protected override Vector3 GetAnimOrientationVec3()
	{
		ControlledByOtherEntityCD componentData = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		if (componentData.controlledByEntity != Entity.Null)
		{
			PlayerController playerController = Manager.memory.GetEntityMono(componentData.controlledByEntity) as PlayerController;
			if (playerController != null && playerController == Manager.main.player)
			{
				float2 activeVelocity = EntityUtility.GetComponentData<MinecartRidingStateCD>(playerController.entity, playerController.world).activeVelocity;
				return new float3(activeVelocity.x, 0f, activeVelocity.y);
			}
		}
		return EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world).facingDirection.vec3;
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
		Vector3 animOrientationVec = GetAnimOrientationVec3();
		MinecartCD componentData = EntityUtility.GetComponentData<MinecartCD>(base.entity, base.world);
		ControlledByOtherEntityCD componentData2 = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(base.entity, base.world);
		bool isBreaking = componentData.isBreaking;
		bool flag = false;
		if (componentData2.controlledByEntity != Entity.Null && !base.isHidden)
		{
			PlayerController playerController = Manager.memory.GetEntityMono(componentData2.controlledByEntity) as PlayerController;
			if (playerController != null && playerController == Manager.main.player)
			{
				isBreaking = EntityUtility.GetComponentData<MinecartRidingStateCD>(playerController.entity, playerController.world).isBreaking;
				flag = true;
			}
			if (minecartAudioLoop == null)
			{
				minecartAudioLoop = AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(loopSound), base.transform, 0f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: true);
			}
			if (brakeAudioLoop == null)
			{
				brakeAudioLoop = AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(loopBrakeSound), base.transform, 0f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: true);
			}
		}
		else
		{
			StopLoopingSounds();
		}
		if ((bool)minecartAudioLoop)
		{
			minecartAudioLoop.SetVolume(animSpeed / 1.6f);
		}
		Breaking(isBreaking, animSpeed);
		if (flag)
		{
			bool flag2 = Direction.FromVector(animOrientationVec, 0f) == Direction.FromVector(previousOrientation, 0f) || Direction.FromVector(animOrientationVec, 0f) == Direction.zero;
			if (previousAnimSpeed - animSpeed > QUICK_STOP_SPEED_DIFF && flag2)
			{
				Crash();
			}
			if (Direction.FromVector(animOrientationVec, 0f) != Direction.FromVector(previousOrientation, 0f) && animSpeed > QUICK_TURN_SPEED_THRESHOLD)
			{
				QuickTurn();
			}
		}
		previousAnimSpeed = animSpeed;
		previousOrientation = animOrientationVec;
	}

	private void Breaking(bool isBreaking, float animSpeed)
	{
		if (isBreaking)
		{
			if (!brakeParticles1.isPlaying)
			{
				brakeParticles1.Play();
				brakeParticles2.Play();
			}
			if ((bool)brakeAudioLoop)
			{
				brakeAudioLoop.SetVolume(animSpeed / 1.6f);
			}
		}
		else
		{
			brakeParticles1.Stop();
			brakeParticles2.Stop();
			if ((bool)brakeAudioLoop)
			{
				brakeAudioLoop.SetVolume(0f);
			}
		}
	}

	private void Crash()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.MinecartCrash,
			entity = base.entity
		});
	}

	private void QuickTurn()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.MinecartQuickTurn,
			entity = base.entity
		});
	}
}
