using System;
using System.Collections.Generic;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[Serializable]
public class SpecialWeaponHandler
{
	public ElectricBeamFX beamFx;

	public ElectricBeamFX lightningFx;

	public ElectricBeamFX[] chainLightningFx;

	public ElectricBeamFX flamethrowerFx;

	public MagicBeamFX magicBeam;

	private const float DRILL_START_SOUND_DURATION = 0.48f;

	private static readonly int Drilling = Animator.StringToHash("drilling");

	private static readonly int LoopRangedAttack = Animator.StringToHash("rangedAttackLooping");

	private readonly List<AudioManager.RunningSfxReference> drillSoundAudioSources = new List<AudioManager.RunningSfxReference>();

	private TimerSimple drillStartSoundTimer = new TimerSimple(0.48f);

	private bool drillIsLooping;

	private List<AudioManager.RunningSfxReference> beamSoundAudioSources = new List<AudioManager.RunningSfxReference>();

	private List<AudioManager.RunningSfxReference> beamSoundHittingAudioSources = new List<AudioManager.RunningSfxReference>();

	private TimerSimple beamStartSoundTimer = new TimerSimple(0.08f);

	private TimerSimple flamethrowerStartSoundTimer = new TimerSimple(0.08f);

	private bool beamIsLooping;

	private Transform transform;

	private Animator animator;

	private bool isLocal;

	private ObjectID previousEquippedObjectID;

	private ObjectID currentLoopingSfxObjectID;

	public void Initialize(Transform transform, Animator animator, bool isLocal)
	{
		this.transform = transform;
		this.animator = animator;
		this.isLocal = isLocal;
	}

	public void UpdateDrillTool(bool drillIsActive, bool drillToolEquipped, ContainedObjectsBuffer visuallyEquippedContainedObject)
	{
		if (drillIsActive)
		{
			if (drillIsLooping)
			{
				return;
			}
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(visuallyEquippedContainedObject.objectID);
			if (!drillStartSoundTimer.isRunning)
			{
				if (objectInfo == null || objectInfo.objectID != ObjectID.DrillToolScarlet)
				{
					AudioManager.SfxFollowTransform(SfxTableID.drillToolStart, transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, result: drillSoundAudioSources, playOnGamepad: isLocal);
				}
				else
				{
					AudioManager.SfxFollowTransform(SfxTableID.scarletDrillToolStart, transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, result: drillSoundAudioSources, playOnGamepad: isLocal);
				}
				drillStartSoundTimer.Start();
				ApplyGamepadRumble(0.3f, 0.48f, Manager.input.LinearAscendingAnimationCurve);
			}
			else if (drillStartSoundTimer.isRunning && drillStartSoundTimer.isTimerElapsed)
			{
				if (objectInfo.objectID != ObjectID.DrillToolScarlet)
				{
					AudioManager.SfxFollowTransform(SfxTableID.drillToolLoop, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, result: drillSoundAudioSources, playOnGamepad: isLocal);
				}
				else
				{
					AudioManager.SfxFollowTransform(SfxTableID.scarletDrillToolLoop, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, result: drillSoundAudioSources, playOnGamepad: isLocal);
				}
				drillStartSoundTimer.Stop();
				drillIsLooping = true;
				ApplyGamepadRumble(0.3f, float.PositiveInfinity, Manager.input.ConstantFullAnimationCurve, PlayerInput.RumbleInstanceId.DrillTools);
			}
		}
		else
		{
			if (drillSoundAudioSources.Count <= 0)
			{
				return;
			}
			ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(visuallyEquippedContainedObject.objectID);
			if (objectInfo2 != null && objectInfo2.objectID == ObjectID.DrillToolScarlet)
			{
				AudioManager.SfxFollowTransform(SfxTableID.scarletDrillToolJam, transform);
				if (drillToolEquipped)
				{
					AudioManager.SfxFollowTransform(SfxTableID.scarletDrillToolEnd, transform);
				}
			}
			else
			{
				AudioManager.SfxFollowTransform(SfxTableID.drillToolJam, transform);
				if (drillToolEquipped)
				{
					AudioManager.SfxFollowTransform(SfxTableID.drillToolEnd, transform);
				}
			}
			StopDrillSounds();
			StopGamepadRumble();
			ApplyGamepadRumble(0.3f, 0.24f, Manager.input.LinearDescendingAnimationCurve);
		}
	}

	private void ApplyGamepadRumble(float intensity, float duration, AnimationCurve curve = null, PlayerInput.RumbleInstanceId instanceId = PlayerInput.RumbleInstanceId.None)
	{
		if (isLocal)
		{
			Manager.input.singleplayerInputModule.RumbleNow(duration, intensity, curve, instanceId);
		}
	}

	private void StopGamepadRumble()
	{
		Manager.input.singleplayerInputModule.RemoveRumbleInstance(PlayerInput.RumbleInstanceId.DrillTools);
	}

	public void StopDrillSounds()
	{
		drillStartSoundTimer.Stop();
		drillIsLooping = false;
		foreach (AudioManager.RunningSfxReference drillSoundAudioSource in drillSoundAudioSources)
		{
			drillSoundAudioSource.FadeOutAndStop(0f);
		}
		drillSoundAudioSources.Clear();
	}

	public void StopBeamSounds()
	{
		beamStartSoundTimer.Stop();
		beamIsLooping = false;
		foreach (AudioManager.RunningSfxReference beamSoundAudioSource in beamSoundAudioSources)
		{
			beamSoundAudioSource.FadeOutAndStop(0.12f);
		}
		beamSoundAudioSources.Clear();
		StopBeamHittingSounds();
	}

	public void StopBeamHittingSounds()
	{
		foreach (AudioManager.RunningSfxReference beamSoundHittingAudioSource in beamSoundHittingAudioSources)
		{
			beamSoundHittingAudioSource.FadeOutAndStop(0f);
		}
		beamSoundHittingAudioSources.Clear();
	}

	public static bool IsTryingToUseBeamOrDrillTool(in ClientInput clientInput, in EquippedObjectCD equippedObjectCD, PugDatabase.DatabaseBankCD databaseBankCD)
	{
		ObjectType objectType = PugDatabase.GetEntityObjectInfo(equippedObjectCD.containedObject.objectID, databaseBankCD.databaseBankBlob, equippedObjectCD.containedObject.variation).objectType;
		if (equippedObjectCD.containedObject.objectData.amount > 0 && (objectType == ObjectType.DrillTool || objectType == ObjectType.BeamWeapon) && equippedObjectCD.containedObject.amount > 0)
		{
			return clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown);
		}
		return false;
	}

	public void UpdateBeamWeaponVisuals(bool beamIsActive, bool beamToolEquipped, ContainedObjectsBuffer visuallyEquippedContainedObject, PlayerAimPositionCD playerAimPosition, AnimationOrientationCD playerAnimationOrientationCD, PlayerStateCD playerStateCD, LocalTransform localTransform, DynamicBuffer<PlayerChainTargetsBuffer> chainTargetsBuffer, BeamWeaponCD beamWeaponCD)
	{
		if (beamIsLooping && visuallyEquippedContainedObject.objectID != currentLoopingSfxObjectID)
		{
			StopBeamSounds();
			beamIsLooping = false;
			currentLoopingSfxObjectID = ObjectID.None;
		}
		lightningFx.isOn = false;
		beamFx.isOn = false;
		flamethrowerFx.isOn = false;
		magicBeam.isOn = false;
		bool flag = visuallyEquippedContainedObject.objectID == ObjectID.Flamethrower;
		bool flag2 = visuallyEquippedContainedObject.objectID == ObjectID.LegendaryStaff;
		WeaponFX weaponFX;
		if (visuallyEquippedContainedObject.objectID == ObjectID.LightningGun)
		{
			weaponFX = lightningFx;
		}
		else if (flag)
		{
			weaponFX = flamethrowerFx;
		}
		else if (flag2)
		{
			weaponFX = magicBeam;
			magicBeam.SetStrengthFactor(playerAimPosition.beamStrength);
		}
		else
		{
			weaponFX = beamFx;
		}
		weaponFX.isConnected = playerAimPosition.isHittingSomething;
		GetBeamPoints(in playerAimPosition, in playerAnimationOrientationCD, in playerStateCD, in localTransform, out var fromWorldPos, out var toWorldPos, isVisual: true, beamWeaponCD.beamVisualFromCenter);
		weaponFX.originPointWorld = fromWorldPos;
		weaponFX.endPointWorld = toWorldPos;
		weaponFX.UpdatePosition();
		if (beamIsActive)
		{
			weaponFX.isOn = true;
			if (!beamIsLooping)
			{
				if (flag)
				{
					if (!flamethrowerStartSoundTimer.isRunning)
					{
						AudioManager.SfxFollowTransform(SfxTableID.flamethrowerStartSfx, transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources);
						flamethrowerStartSoundTimer.Start();
					}
					else if (flamethrowerStartSoundTimer.isRunning && flamethrowerStartSoundTimer.isTimerElapsed)
					{
						AudioManager.SfxFollowTransform(SfxTableID.flamethrowerLoopSfx, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources, 1f, 0f, 1f, 0.15f);
						beamIsLooping = true;
						currentLoopingSfxObjectID = visuallyEquippedContainedObject.objectID;
					}
				}
				else if (!beamStartSoundTimer.isRunning)
				{
					if (flag2)
					{
						AudioManager.SfxFollowTransform(SfxTableID.magicBeamStartSfx, transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources, 1f, 0f, 1f, 0.02f);
						beamStartSoundTimer.Start();
					}
					else
					{
						AudioManager.SfxFollowTransform(SfxTableID.laserDrillToolStart, transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources);
					}
					beamStartSoundTimer.Start();
				}
				else if (beamStartSoundTimer.isRunning && beamStartSoundTimer.isTimerElapsed)
				{
					if (flag2)
					{
						AudioManager.SfxFollowTransform(SfxTableID.magicBeamLoopSfx, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true, beamSoundAudioSources, 1f, 0f, 1f, 0.15f);
					}
					else
					{
						AudioManager.SfxFollowTransform(SfxTableID.laserDrillToolLoop, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true, beamSoundAudioSources);
					}
					beamStartSoundTimer.Stop();
					beamIsLooping = true;
					currentLoopingSfxObjectID = visuallyEquippedContainedObject.objectID;
				}
			}
			if (playerAimPosition.isHittingSomething && beamSoundHittingAudioSources.Count == 0)
			{
				if (!flag)
				{
					AudioManager.SfxFollowTransform(SfxTableID.laserDrillToolImpactLoop, transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true, beamSoundHittingAudioSources);
				}
			}
			else if (!playerAimPosition.isHittingSomething && beamSoundHittingAudioSources.Count != 0)
			{
				StopBeamHittingSounds();
			}
		}
		else
		{
			lightningFx.isOn = false;
			beamFx.isOn = false;
			flamethrowerFx.isOn = false;
			magicBeam.isOn = false;
			if (beamSoundAudioSources.Count > 0)
			{
				if (flag)
				{
					AudioManager.SfxFollowTransform(SfxTableID.flamethrowerEndSfx, transform);
					flamethrowerStartSoundTimer.Stop();
				}
				else if (flag2)
				{
					AudioManager.SfxFollowTransform(SfxTableID.magicBeamEndSfx, transform);
				}
				else
				{
					AudioManager.SfxFollowTransform(SfxTableID.laserDrillToolJam, transform);
					if (beamToolEquipped)
					{
						AudioManager.SfxFollowTransform(SfxTableID.laserDrillToolEnd, transform);
					}
				}
			}
			StopBeamSounds();
		}
		ElectricBeamFX[] array = chainLightningFx;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].isOn = false;
		}
		if (chainTargetsBuffer.Length > 1)
		{
			for (int j = 1; j < chainTargetsBuffer.Length; j++)
			{
				chainLightningFx[j].isOn = true;
				chainLightningFx[j].isConnected = true;
				GetChainPoints(in chainTargetsBuffer, j, out var fromWorldPos2, out var toWorldPos2);
				chainLightningFx[j].originPointWorld = fromWorldPos2;
				chainLightningFx[j].endPointWorld = toWorldPos2;
				chainLightningFx[j].UpdatePosition();
			}
		}
		else
		{
			array = chainLightningFx;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].isOn = false;
			}
		}
		previousEquippedObjectID = visuallyEquippedContainedObject.objectID;
	}

	public static bool GetBeamPoints(in PlayerAimPositionCD playerAimPositionCD, in AnimationOrientationCD animationOrientationCD, in PlayerStateCD playerStateCD, in LocalTransform localTransform, out float3 fromWorldPos, out float3 toWorldPos, bool isVisual, bool isCentered)
	{
		float3 beamStartPoint = GetBeamStartPoint(in animationOrientationCD, in playerStateCD, in localTransform, isVisual, isCentered);
		fromWorldPos = beamStartPoint.X0Z() + new float3(0f, 0.25f, 0f);
		toWorldPos = playerAimPositionCD.position.X0Z() + new float3(0f, 0.25f, 0f);
		return playerAimPositionCD.isHittingSomething;
	}

	public static float3 GetBeamStartPoint(in AnimationOrientationCD animationOrientationCD, in PlayerStateCD playerStateCD, in LocalTransform localTransform, bool isVisual, bool isCentered)
	{
		Direction facingDirection = animationOrientationCD.facingDirection;
		float num = 0.3f;
		float z = -0.45f;
		if (isCentered)
		{
			num = 0f;
			z = -0.25f;
		}
		float3 float5 = float3.zero;
		if (facingDirection.id == Direction.Id.forward)
		{
			float5 = new float3(num, 0.25f, 0f);
		}
		else if (facingDirection.id == Direction.Id.back)
		{
			float5 = new float3(0f - num, 0.25f, -0.45f);
		}
		else if (facingDirection.id == Direction.Id.left)
		{
			float5 = new float3(-0.25f, 0.25f, z);
		}
		else if (facingDirection.id == Direction.Id.right)
		{
			float5 = new float3(0.25f, 0.25f, z);
		}
		if (playerStateCD.HasAnyState(PlayerStateEnum.BoatRiding))
		{
			float5 += new float3(0f, 0f, -0.2f);
		}
		return localTransform.Position + (isVisual ? (facingDirection.f3 * 0.2f) : float3.zero) + float5;
	}

	private static void GetChainPoints(in DynamicBuffer<PlayerChainTargetsBuffer> playerChainTargetsBuffer, int index, out float3 fromWorldPos, out float3 toWorldPos)
	{
		fromWorldPos = playerChainTargetsBuffer[index - 1].targetPosition.X0Z() + new float3(0f, 0.25f, 0f);
		toWorldPos = playerChainTargetsBuffer[index].targetPosition.X0Z() + new float3(0f, 0.25f, 0f);
	}

	public void SetDrillingAnimation(bool value)
	{
		animator.SetBool(Drilling, value);
	}

	public void SetLoopRangedAnimation(bool value)
	{
		animator.SetBool(LoopRangedAttack, value);
	}
}
