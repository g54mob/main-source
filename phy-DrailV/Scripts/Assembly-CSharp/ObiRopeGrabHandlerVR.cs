using DV.CabControls;
using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ObiRopeGrabHandlerVR : MonoBehaviour, IGrabPoseProvider
{
	public VRTK_InteractableObject interactable;

	public ObiRopeGrabArea grabArea;

	private bool touchedByLeft;

	private bool touchedByRight;

	private Transform grabbedByController;

	private Transform controllerAnchor;

	private VRTK_InteractGrab_DV grabLeft;

	private VRTK_InteractGrab_DV grabRight;

	private VRTK_ControllerEvents_LateUpdate controllerEventsLeft;

	private VRTK_ControllerEvents_LateUpdate controllerEventsRight;

	private VRTK_ControllerEvents.ButtonAlias currentGrabButtonLeft;

	private VRTK_ControllerEvents.ButtonAlias currentGrabButtonRight;

	private bool initializedLeft;

	private bool initializedRight;

	private Vector3 initialPosition;

	private Quaternion initialRotaton;

	public HandPose GrabPose => HandPose.Grab;

	private void Awake()
	{
		initialPosition = base.transform.localPosition;
		initialRotaton = base.transform.localRotation;
	}

	private void OnEnable()
	{
		interactable.InteractableObjectTouched += OnTouched;
		interactable.InteractableObjectUntouched += OnUntouched;
		bool flag = false;
		if (SetupDeviceSpecificControls.AreControlsSetLeft)
		{
			InitializeAndSetupGrab(isLeft: true);
		}
		else
		{
			flag = true;
		}
		if (SetupDeviceSpecificControls.AreControlsSetRight)
		{
			InitializeAndSetupGrab(isLeft: false);
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnDeviceSpecificControlsSet);
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			interactable.InteractableObjectTouched -= OnTouched;
			interactable.InteractableObjectUntouched -= OnUntouched;
			SetupGrab(left: true, on: false, currentGrabButtonLeft);
			SetupGrab(left: false, on: false, currentGrabButtonRight);
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnDeviceSpecificControlsSet);
		}
	}

	private void InitializeAndSetupGrab(bool isLeft)
	{
		if (isLeft && !initializedLeft)
		{
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			grabLeft = controllerLeftHand.GetComponent<VRTK_InteractGrab_DV>();
			controllerEventsLeft = controllerLeftHand.GetComponent<VRTK_ControllerEvents_LateUpdate>();
			currentGrabButtonLeft = ResolveGrabButtonAlias(left: true, interactable.grabOverrideButton);
			initializedLeft = true;
			SetupGrab(isLeft, on: true, currentGrabButtonLeft);
		}
		else if (!isLeft && !initializedRight)
		{
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			grabRight = controllerRightHand.GetComponent<VRTK_InteractGrab_DV>();
			controllerEventsRight = controllerRightHand.GetComponent<VRTK_ControllerEvents_LateUpdate>();
			currentGrabButtonRight = ResolveGrabButtonAlias(left: false, interactable.grabOverrideButton);
			initializedRight = true;
			SetupGrab(isLeft, on: true, currentGrabButtonRight);
		}
	}

	private void OnDeviceSpecificControlsSet(SDK_BaseController.ControllerHand hand)
	{
		bool flag = hand == SDK_BaseController.ControllerHand.Left;
		if (flag && !initializedLeft)
		{
			InitializeAndSetupGrab(isLeft: true);
		}
		else if (!flag && !initializedRight)
		{
			InitializeAndSetupGrab(isLeft: false);
		}
		if (initializedLeft && initializedRight)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnDeviceSpecificControlsSet);
		}
	}

	private VRTK_ControllerEvents.ButtonAlias ResolveGrabButtonAlias(bool left, VRTK_ControllerEvents.ButtonAlias givenOverrideButtonAlias)
	{
		if (givenOverrideButtonAlias != VRTK_ControllerEvents.ButtonAlias.Undefined)
		{
			return givenOverrideButtonAlias;
		}
		if (!left)
		{
			return grabRight.grabButton;
		}
		return grabLeft.grabButton;
	}

	private void SetupGrab(bool left, bool on, VRTK_ControllerEvents.ButtonAlias desiredGrabButton)
	{
		if ((left && !initializedLeft) || (!left && !initializedRight))
		{
			return;
		}
		VRTK_ControllerEvents vRTK_ControllerEvents;
		VRTK_ControllerEvents.ButtonAlias givenButton;
		if (left)
		{
			vRTK_ControllerEvents = controllerEventsLeft;
			givenButton = currentGrabButtonLeft;
		}
		else
		{
			vRTK_ControllerEvents = controllerEventsRight;
			givenButton = currentGrabButtonRight;
		}
		vRTK_ControllerEvents.UnsubscribeToButtonAliasEvent(givenButton, startEvent: true, OnGrabPressed);
		vRTK_ControllerEvents.UnsubscribeToButtonAliasEvent(givenButton, startEvent: false, OnGrabReleased);
		if (on)
		{
			vRTK_ControllerEvents.SubscribeToButtonAliasEvent(desiredGrabButton, startEvent: true, OnGrabPressed);
			vRTK_ControllerEvents.SubscribeToButtonAliasEvent(desiredGrabButton, startEvent: false, OnGrabReleased);
			if (left)
			{
				currentGrabButtonLeft = desiredGrabButton;
			}
			else
			{
				currentGrabButtonRight = desiredGrabButton;
			}
		}
	}

	private void OnGrabPressed(object sender, ControllerInteractionEventArgs e)
	{
		if (!grabbedByController && ((e.controllerReference.hand == SDK_BaseController.ControllerHand.Left && touchedByLeft) || (e.controllerReference.hand == SDK_BaseController.ControllerHand.Right && touchedByRight)) && grabArea.CanGrab())
		{
			grabbedByController = e.controllerReference.actual.transform;
			string n = "HandRoot/PipaAnchors/Idle";
			controllerAnchor = grabbedByController.GetComponentInChildren<VRTK_SDKTransformModify_DV>()?.transform.Find(n);
			grabArea.StartGrab(grabbedByController.position);
		}
	}

	private void OnGrabReleased(object sender, ControllerInteractionEventArgs e)
	{
		if ((bool)grabbedByController && e.controllerReference.actual.transform == grabbedByController)
		{
			grabbedByController = null;
			controllerAnchor = null;
			grabArea.EndGrab();
			interactable.ForceStopInteracting();
			base.transform.localPosition = initialPosition;
			base.transform.localRotation = initialRotaton;
		}
	}

	private void OnTouched(object sender, InteractableObjectEventArgs e)
	{
		HandleTouched(e, on: true);
	}

	private void OnUntouched(object sender, InteractableObjectEventArgs e)
	{
		HandleTouched(e, on: false);
	}

	private void HandleTouched(InteractableObjectEventArgs e, bool on)
	{
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetActualController(e.interactingObject));
		switch (controllerReference.hand)
		{
		case SDK_BaseController.ControllerHand.Left:
			touchedByLeft = on;
			break;
		case SDK_BaseController.ControllerHand.Right:
			touchedByRight = on;
			break;
		default:
			Debug.LogError(string.Format("{0} got unexpected hand {1}, on: {2}", "ObiRopeGrabHandlerVR", controllerReference.hand, on));
			break;
		}
		HapticUtils.DoHapticPulse(controllerReference, HapticIntensityType.Normal, 0.1f, 0.1f);
	}

	private void Update()
	{
		if ((bool)grabbedByController)
		{
			grabArea.FeedPosition((controllerAnchor != null) ? controllerAnchor.position : grabbedByController.position);
		}
	}
}
