using System.Collections;
using DV;
using DV.DopplerEffects;
using DV.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class PlayerTeleportVR : APlayerTeleport
{
	public enum TeleportOrientation
	{
		Off = 0,
		PlayerForward = 1,
		PlayAreaForward = 2,
		PlayAreaForwardWithReposition = 3
	}

	public Transform smoothLocoRig;

	[SerializeField]
	private FootstepsAudioPlayer footstepsAudio;

	private CameraSmoothing cSmoothing;

	private CharacterController cCollider;

	private CharacterReparenting cReparenting;

	private CustomFirstPersonController cController;

	private CharacterControllerMover cMover;

	private Coroutine ReactivateCoro;

	private int lastTeleportFrame;

	private int walkableLayer;

	private float FloorOffsetSeated => GamePreferences.Get<float>(Preferences.PlayerSeatedHeight) + 1.62f;

	private float FloorOffsetRoomscale => GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight);

	private bool IsSeated => GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);

	private bool IsSmoothLocomotion => LocomotionType.Smooth == LocomotionSetup.CurrentLocomotion;

	protected override void Awake()
	{
		base.Awake();
		walkableLayer = LayerMask.NameToLayer("Train_Walkable");
	}

	public override void TeleportPlayer(Vector3 worldPosition, Quaternion worldRotation, Transform target, bool useRotation, bool playFootstepSound)
	{
		int num = lastTeleportFrame;
		lastTeleportFrame = Time.frameCount;
		if (lastTeleportFrame - num >= 2)
		{
			switch (LocomotionSetup.CurrentLocomotion)
			{
			case LocomotionType.Smooth:
				DoSmoothLocomotionTeleport(worldPosition, worldRotation, target, useRotation, playFootstepSound);
				break;
			case LocomotionType.Teleport:
				DoTeleportLocomotionTeleport(worldPosition, worldRotation, target, useRotation, playFootstepSound);
				break;
			default:
				Debug.LogError($"Unhandled locomotion type '{LocomotionSetup.CurrentLocomotion}'");
				break;
			}
		}
	}

	private void DoTeleportLocomotionTeleport(Vector3 worldPosition, Quaternion worldRotation, Transform target, bool useRotation, bool playFootstepSound)
	{
		Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
		float num = (IsSeated ? FloorOffsetSeated : FloorOffsetRoomscale);
		transform.position = worldPosition + Vector3.up * num;
		TrainCar trainCar = TrainCar.Resolve(target);
		Transform transform2 = null;
		if ((bool)trainCar)
		{
			transform2 = trainCar.interior;
		}
		else if ((bool)target && (target.gameObject.layer == walkableLayer || target.gameObject.CompareTag("ReparentTarget")))
		{
			CharacterReparentTarget componentInParent = target.GetComponentInParent<CharacterReparentTarget>();
			if ((bool)componentInParent)
			{
				transform2 = componentInParent.target;
			}
		}
		transform.SetParent(transform2);
		if (transform2 == null)
		{
			SceneManager.MoveGameObjectToScene(transform.gameObject, SceneManager.GetActiveScene());
		}
		transform.localScale = Vector3.one;
		PlayerManager.SetCar(trainCar);
		AdjustForRotationPreference(worldRotation, useRotation);
		SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
		if (playFootstepSound)
		{
			footstepsAudio.RequestPlayFootstepSound(FootstepsAudioScriptableObject.MovementType.Walking, worldPosition, 0f, 0.135f, transform);
		}
	}

	private void DoSmoothLocomotionTeleport(Vector3 worldPosition, Quaternion worldRotation, Transform target, bool useRotation, bool playFootstepSound)
	{
		CheckReferencesSmoothLocomotion();
		cController.isRepositioning = true;
		cSmoothing.canSmooth = false;
		cController.transform.position = worldPosition;
		TrainCar trainCar = TrainCar.Resolve(target);
		Transform target2 = null;
		CharacterReparentTarget characterReparentTarget = null;
		if ((bool)trainCar)
		{
			target2 = trainCar.interior;
		}
		else if ((bool)target && (target.gameObject.layer == walkableLayer || target.gameObject.CompareTag("ReparentTarget")))
		{
			characterReparentTarget = target.GetComponentInParent<CharacterReparentTarget>();
			if ((bool)characterReparentTarget)
			{
				target2 = characterReparentTarget.target;
			}
		}
		cReparenting.ReparentTo(target2, forceReparent: true, characterReparentTarget);
		AdjustForRotationPreference(worldRotation, useRotation);
		CleanupAfterFinishedTeleport();
		if (playFootstepSound)
		{
			cController.RequestFootstepSound();
		}
	}

	private void CheckReferencesSmoothLocomotion()
	{
		if (cMover == null)
		{
			cMover = smoothLocoRig.GetComponent<CharacterControllerMover>();
		}
		if (cCollider == null)
		{
			cCollider = smoothLocoRig.GetComponent<CharacterController>();
		}
		if (cSmoothing == null)
		{
			cSmoothing = smoothLocoRig.GetComponent<CameraSmoothing>();
		}
		if (cController == null)
		{
			cController = smoothLocoRig.GetComponent<CustomFirstPersonController>();
		}
		if (cReparenting == null)
		{
			cReparenting = smoothLocoRig.GetComponent<CharacterReparenting>();
		}
	}

	private void CleanupAfterFinishedTeleport()
	{
		if (ReactivateCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(ReactivateCoro);
		}
		ReactivateCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Reactivate());
	}

	private IEnumerator Reactivate()
	{
		cController.isRepositioning = false;
		cSmoothing.UpdateImmediately();
		yield return null;
		yield return WaitFor.EndOfFrame;
		cSmoothing.canSmooth = true;
		ReactivateCoro = null;
	}

	private void AdjustForRotationPreference(Quaternion targetRotation, bool reorient)
	{
		Transform transform = VRTK_DeviceFinder.HeadsetTransform();
		Transform transform2 = VRTK_DeviceFinder.PlayAreaTransform();
		TeleportOrientation teleportOrientation = (IsSeated ? TeleportOrientation.PlayAreaForward : ((TeleportOrientation)GamePreferences.Get<int>(Preferences.VRTeleportOrientation)));
		if (reorient)
		{
			Quaternion quaternion;
			switch (teleportOrientation)
			{
			case TeleportOrientation.PlayerForward:
				quaternion = targetRotation * Quaternion.Inverse(transform.localRotation);
				break;
			case TeleportOrientation.PlayAreaForward:
			case TeleportOrientation.PlayAreaForwardWithReposition:
				quaternion = targetRotation;
				break;
			case TeleportOrientation.Off:
				quaternion = transform2.rotation;
				break;
			default:
				quaternion = transform2.rotation;
				Debug.LogError($"Unhandled '{teleportOrientation}' orientation mode. Using current play area rotation.", this);
				break;
			}
			quaternion = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
			transform2.rotation = quaternion;
		}
		else
		{
			transform2.rotation = VectorUtils.GetCamForwardRotation(transform2.forward, transform2.up);
		}
		if (IsSmoothLocomotion)
		{
			smoothLocoRig.transform.rotation = transform2.rotation;
			if (IsSeated)
			{
				transform2.localPosition = Vector3.zero;
				return;
			}
			Vector3 vector = transform2.InverseTransformPoint(transform.position);
			vector.y = 0f;
			transform2.localPosition = -(transform2.localRotation * vector);
		}
		else if (!IsSeated)
		{
			Vector3 vector2 = transform2.InverseTransformPoint(transform.position);
			vector2.y = 0f;
			transform2.Translate(-vector2, Space.Self);
		}
	}
}
