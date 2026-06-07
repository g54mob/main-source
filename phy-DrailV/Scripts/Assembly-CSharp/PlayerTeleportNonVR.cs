using System.Collections;
using DV;
using DV.DopplerEffects;
using DV.Utils;
using UnityEngine;

public class PlayerTeleportNonVR : APlayerTeleport
{
	public CameraSmoothing cameraSmoothing;

	public CharacterController characterCollider;

	public CharacterReparenting characterReparenting;

	public CustomFirstPersonController charController;

	public CharacterControllerMover characterControllerMover;

	private Coroutine ReactivateCoro;

	private int walkableLayer;

	public override void TeleportPlayer(Vector3 worldPosition, Quaternion worldRotation, Transform target, bool useRotation, bool playFootstepSound)
	{
		charController.isRepositioning = true;
		cameraSmoothing.canSmooth = false;
		charController.transform.position = worldPosition;
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
		characterReparenting.ReparentTo(target2, forceReparent: true, characterReparentTarget);
		if (useRotation)
		{
			charController.ForceLookRotationNoTilt(worldRotation);
		}
		if (playFootstepSound)
		{
			charController.RequestFootstepSound();
		}
		SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
		CleanupAfterFinishedTeleport();
	}

	protected override void Awake()
	{
		base.Awake();
		walkableLayer = LayerMask.NameToLayer("Train_Walkable");
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		_ = UnloadWatcher.isUnloading;
	}

	private void CleanupAfterFinishedTeleport()
	{
		SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.Cleared);
		if (ReactivateCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(ReactivateCoro);
		}
		ReactivateCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Reactivate());
	}

	private IEnumerator Reactivate()
	{
		charController.isRepositioning = false;
		cameraSmoothing.UpdateImmediately();
		yield return null;
		yield return WaitFor.EndOfFrame;
		cameraSmoothing.canSmooth = true;
		ReactivateCoro = null;
	}
}
