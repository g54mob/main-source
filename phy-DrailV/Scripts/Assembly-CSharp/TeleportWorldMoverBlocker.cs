using System.Collections;
using DV.Utils;
using UnityEngine;
using VRTK;

public class TeleportWorldMoverBlocker : MonoBehaviour
{
	private const float REENABLE_DELAY = 1f;

	private Coroutine teleportCoro;

	private VRTK_Pointer leftTeleportPointer;

	private VRTK_Pointer rightTeleportPointer;

	private void Start()
	{
		if (!SingletonBehaviour<WorldMover>.Instance)
		{
			Debug.Log("TeleportWorldMoverBlocker couldn't find a WorldMover instance, destroying self.", base.gameObject);
			Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		leftTeleportPointer = VRTK_DeviceFinder.GetControllerLeftHand().GetComponentInChildren<VRTK_Pointer>(includeInactive: true);
		rightTeleportPointer = VRTK_DeviceFinder.GetControllerRightHand().GetComponentInChildren<VRTK_Pointer>(includeInactive: true);
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			PlayerManager.PlayerTeleportFinished += OnTeleported;
			leftTeleportPointer.ActivationButtonPressed += OnAboutToTeleport;
			rightTeleportPointer.ActivationButtonPressed += OnAboutToTeleport;
		}
		else
		{
			PlayerManager.PlayerTeleportFinished -= OnTeleported;
			leftTeleportPointer.ActivationButtonPressed -= OnAboutToTeleport;
			rightTeleportPointer.ActivationButtonPressed -= OnAboutToTeleport;
		}
	}

	private void OnAboutToTeleport(object sender, ControllerInteractionEventArgs e)
	{
		if (teleportCoro != null)
		{
			StopCoroutine(teleportCoro);
			teleportCoro = null;
		}
		SingletonBehaviour<WorldMover>.Instance.movingEnabled = false;
	}

	private void OnTeleported()
	{
		if (teleportCoro != null)
		{
			StopCoroutine(teleportCoro);
		}
		teleportCoro = StartCoroutine(ReEnableOriginShift());
	}

	private IEnumerator ReEnableOriginShift()
	{
		yield return WaitFor.Seconds(1f);
		SingletonBehaviour<WorldMover>.Instance.movingEnabled = true;
		teleportCoro = null;
	}
}
