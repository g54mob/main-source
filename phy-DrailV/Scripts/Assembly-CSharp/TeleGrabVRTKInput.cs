using System;
using DV;
using DV.CabControls;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class TeleGrabVRTKInput : MonoBehaviour
{
	public bool telegrabDisabled;

	private VRTK_InteractGrab_DV grab;

	private VRTK_InteractUse use;

	private TeleGrab teleGrab;

	private VRTK_TrackedController trackedController;

	private SDK_BaseHeadset.HeadsetType headset;

	private void Awake()
	{
		VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
	}

	private void OnDestroy()
	{
		VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		SetupListeners(on: false);
	}

	private void Start()
	{
		trackedController = GetComponentInParent<VRTK_TrackedController>();
		grab = GetComponentInParent<VRTK_InteractGrab_DV>();
		use = GetComponentInParent<VRTK_InteractUse>();
		teleGrab = GetComponent<TeleGrab>();
		if (grab == null)
		{
			throw new Exception("TeleGrabVRTKInput couldn't find a VRTK_InteractGrab instance");
		}
		if (use == null)
		{
			throw new Exception("TeleGrabVRTKInput couldn't find a VRTK_InteractUse instance");
		}
		if (teleGrab == null)
		{
			throw new Exception("TeleGrabVRTKInput couldn't find a TeleGrab instance");
		}
		InitializeControls();
	}

	private void InitializeControls(object _, VRTKTrackedControllerEventArgs __)
	{
		InitializeControls();
	}

	private void InitializeControls()
	{
		if (trackedController == null)
		{
			Debug.LogError("VRTK_TrackedController not found. TeleGrabVRTKInput control initialization failed. Turn on your controller or restart it.", this);
			trackedController.ControllerModelAvailable += InitializeControls;
			return;
		}
		trackedController.ControllerModelAvailable -= InitializeControls;
		trackedController.ControllerDisabled += OnControllerUnavailable;
		bool flag = VRTK_DeviceFinder.IsControllerRightHand(trackedController.gameObject);
		VRTK_ControllerReference controllerReference = (flag ? VRTK_DeviceFinder.GetControllerReferenceRightHand() : VRTK_DeviceFinder.GetControllerReferenceLeftHand());
		teleGrab.SetHandiness(flag);
		SetupListeners(on: true, controllerReference.GetControllerTypeDV());
	}

	private void OnControllerUnavailable(object sender, VRTKTrackedControllerEventArgs e)
	{
		trackedController.ControllerModelAvailable += InitializeControls;
		trackedController.ControllerDisabled -= OnControllerUnavailable;
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on, ControllerType_DV controllerType = ControllerType_DV.Undefined)
	{
		if (on)
		{
			grab.GrabButtonPressed += OnGrabStart;
			grab.GrabButtonReleased += OnGrabEnd;
			grab.ControllerGrabInteractableObject += ChangeTelegrabStateToHolding;
			grab.ControllerUngrabInteractableObject += ChangeTelegrabStateToIdle;
			use.UseButtonPressed += OnUseStart;
			use.UseButtonReleased += OnUseEnd;
			teleGrab.TeleGrabbed += OnTeleGrabbed;
			SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
			return;
		}
		grab.GrabButtonPressed -= OnGrabStart;
		grab.GrabButtonReleased -= OnGrabEnd;
		grab.ControllerGrabInteractableObject -= ChangeTelegrabStateToHolding;
		grab.ControllerUngrabInteractableObject -= ChangeTelegrabStateToIdle;
		use.UseButtonPressed -= OnUseStart;
		use.UseButtonReleased -= OnUseEnd;
		teleGrab.TeleGrabbed -= OnTeleGrabbed;
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
		}
	}

	private void OnGamePaused()
	{
		teleGrab.scanButtonPressed = false;
		teleGrab.AbortTelegrab();
	}

	private void ChangeTelegrabStateToHolding(object sender, ObjectInteractEventArgs e)
	{
		teleGrab.ChangeStateToHoldAndTurnOffVisuals();
	}

	private void ChangeTelegrabStateToIdle(object sender, ObjectInteractEventArgs e)
	{
		teleGrab.ChangeStateToIdleAndTurnOffVisuals();
	}

	private void OnGrabStart(object _, ControllerInteractionEventArgs __)
	{
		if ((!SingletonBehaviour<AppUtil>.Instance || !SingletonBehaviour<AppUtil>.Instance.IsTimePaused) && !telegrabDisabled && grab.interactTouch.GetTouchedObject() == null)
		{
			teleGrab.scanButtonPressed = true;
			SingletonBehaviour<HighlightNearbyItems>.Instance.Ping();
		}
	}

	private void OnGrabEnd(object _, ControllerInteractionEventArgs __)
	{
		if (!SingletonBehaviour<AppUtil>.Instance || !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
		{
			teleGrab.scanButtonPressed = false;
		}
	}

	private void OnUseStart(object _, ControllerInteractionEventArgs __)
	{
		if ((!SingletonBehaviour<AppUtil>.Instance || !SingletonBehaviour<AppUtil>.Instance.IsTimePaused) && !telegrabDisabled && grab.interactTouch.GetTouchedObject() == null)
		{
			teleGrab.attractButtonPressed = true;
		}
	}

	private void OnUseEnd(object _, ControllerInteractionEventArgs __)
	{
		if (!SingletonBehaviour<AppUtil>.Instance || !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
		{
			teleGrab.attractButtonPressed = false;
		}
	}

	private void OnTeleGrabbed(Telegrabbable obj)
	{
		ItemBase component = obj.GetComponent<ItemBase>();
		if (component != null)
		{
			PipaUtils.AlignItemToControllersPipa(component, grab.gameObject);
		}
		grab.ForceGrabInteractable(obj.gameObject);
	}
}
