using System.Collections;
using UnityEngine;

namespace VRTK
{
	public class VRTK_AvatarHandController : MonoBehaviour
	{
		protected enum OverrideState
		{
			NoOverride = 0,
			IsOverriding = 1,
			WasOverring = 2,
			KeepOverring = 3
		}

		[Header("Hand Settings")]
		[Tooltip("The controller type to use for default finger settings.")]
		public SDK_BaseController.ControllerType controllerType;

		[Tooltip("Determines whether the Finger and State settings are auto set based on the connected controller type.")]
		public bool setFingersForControllerType = true;

		[Tooltip("If this is checked then the model will be mirrored, tick this if the avatar hand is for the left hand controller.")]
		public bool mirrorModel;

		[Tooltip("The speed in which a finger will transition to it's destination position if the finger state is `Digital`.")]
		public float animationSnapSpeed = 0.1f;

		[Header("Digital Finger Settings")]
		[Tooltip("The button alias to control the thumb if the thumb state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias thumbButton = VRTK_ControllerEvents.ButtonAlias.TouchpadTouch;

		[Tooltip("The button alias to control the index finger if the index finger state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias indexButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;

		[Tooltip("The button alias to control the middle finger if the middle finger state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias middleButton;

		[Tooltip("The button alias to control the ring finger if the ring finger state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias ringButton;

		[Tooltip("The button alias to control the pinky finger if the pinky finger state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias pinkyButton;

		[Tooltip("The button alias to control the middle, ring and pinky finger if the three finger state is `Digital`.")]
		public VRTK_ControllerEvents.ButtonAlias threeFingerButton = VRTK_ControllerEvents.ButtonAlias.GripPress;

		[Header("Axis Finger Settings")]
		[Tooltip("The button type to listen for axis changes to control the thumb.")]
		public SDK_BaseController.ButtonTypes thumbAxisButton = SDK_BaseController.ButtonTypes.Touchpad;

		[Tooltip("The button type to listen for axis changes to control the index finger.")]
		public SDK_BaseController.ButtonTypes indexAxisButton = SDK_BaseController.ButtonTypes.Trigger;

		[Tooltip("The button type to listen for axis changes to control the middle finger.")]
		public SDK_BaseController.ButtonTypes middleAxisButton = SDK_BaseController.ButtonTypes.MiddleFinger;

		[Tooltip("The button type to listen for axis changes to control the ring finger.")]
		public SDK_BaseController.ButtonTypes ringAxisButton = SDK_BaseController.ButtonTypes.RingFinger;

		[Tooltip("The button type to listen for axis changes to control the pinky finger.")]
		public SDK_BaseController.ButtonTypes pinkyAxisButton = SDK_BaseController.ButtonTypes.PinkyFinger;

		[Tooltip("The button type to listen for axis changes to control the middle, ring and pinky finger.")]
		public SDK_BaseController.ButtonTypes threeFingerAxisButton = SDK_BaseController.ButtonTypes.Grip;

		[Header("Finger State Settings")]
		[Tooltip("The Axis Type to utilise when dealing with the thumb state. Not all controllers support all axis types on all of the available buttons.")]
		public VRTK_ControllerEvents.AxisType thumbState;

		public VRTK_ControllerEvents.AxisType indexState;

		public VRTK_ControllerEvents.AxisType middleState;

		public VRTK_ControllerEvents.AxisType ringState;

		public VRTK_ControllerEvents.AxisType pinkyState;

		public VRTK_ControllerEvents.AxisType threeFingerState;

		[Header("Finger Axis Overrides")]
		[Tooltip("Finger axis overrides on an Interact NearTouch event.")]
		public AxisOverrides nearTouchOverrides;

		[Tooltip("Finger axis overrides on an Interact Touch event.")]
		public AxisOverrides touchOverrides;

		[Tooltip("Finger axis overrides on an Interact Grab event.")]
		public AxisOverrides grabOverrides;

		[Tooltip("Finger axis overrides on an Interact Use event.")]
		public AxisOverrides useOverrides;

		[Header("Custom Settings")]
		[Tooltip("The Transform that contains the avatar hand model. If this is left blank then a child GameObject named `Model` will be searched for to use as the Transform.")]
		public Transform handModel;

		[Tooltip("The controller to listen for the events on. If this is left blank as it will be auto populated by finding the Controller Events script on the parent GameObject.")]
		public VRTK_ControllerEvents controllerEvents;

		[Tooltip("An optional Interact NearTouch to listen for near touch events on. If this is left blank as it will attempt to be auto populated by finding the Interact NearTouch script on the parent GameObject.")]
		public VRTK_InteractNearTouch interactNearTouch;

		[Tooltip("An optional Interact Touch to listen for touch events on. If this is left blank as it will attempt to be auto populated by finding the Interact Touch script on the parent GameObject.")]
		public VRTK_InteractTouch interactTouch;

		[Tooltip("An optional Interact Grab to listen for grab events on. If this is left blank as it will attempt to be auto populated by finding the Interact Grab script on the parent GameObject.")]
		public VRTK_InteractGrab interactGrab;

		[Tooltip("An optional Interact Use to listen for use events on. If this is left blank as it will attempt to be auto populated by finding the Interact Use script on the parent GameObject.")]
		public VRTK_InteractUse interactUse;

		protected Animator animator;

		protected bool[] fingerStates = new bool[5];

		protected bool[] fingerChangeStates = new bool[5];

		protected float[] fingerAxis = new float[5];

		protected float[] fingerRawAxis = new float[5];

		protected float[] fingerUntouchedAxis = new float[5];

		protected float[] fingerSaveAxis = new float[5];

		protected float[] fingerForceAxis = new float[5];

		protected OverrideState[] overrideAxisValues = new OverrideState[5];

		protected VRTK_ControllerEvents.AxisType[] axisTypes = new VRTK_ControllerEvents.AxisType[5];

		protected Coroutine[] fingerAnimationRoutine = new Coroutine[5];

		protected VRTK_ControllerEvents.ButtonAlias savedThumbButtonState;

		protected VRTK_ControllerEvents.ButtonAlias savedIndexButtonState;

		protected VRTK_ControllerEvents.ButtonAlias savedMiddleButtonState;

		protected VRTK_ControllerEvents.ButtonAlias savedRingButtonState;

		protected VRTK_ControllerEvents.ButtonAlias savedPinkyButtonState;

		protected VRTK_ControllerEvents.ButtonAlias savedThreeFingerButtonState;

		protected SDK_BaseController.ButtonTypes savedThumbAxisButtonState;

		protected SDK_BaseController.ButtonTypes savedIndexAxisButtonState;

		protected SDK_BaseController.ButtonTypes savedMiddleAxisButtonState;

		protected SDK_BaseController.ButtonTypes savedRingAxisButtonState;

		protected SDK_BaseController.ButtonTypes savedPinkyAxisButtonState;

		protected SDK_BaseController.ButtonTypes savedThreeFingerAxisButtonState;

		protected VRTK_ControllerReference controllerReference;

		protected virtual void OnEnable()
		{
			animator = GetComponent<Animator>();
			controllerEvents = ((controllerEvents != null) ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
			interactNearTouch = ((interactNearTouch != null) ? interactNearTouch : GetComponentInParent<VRTK_InteractNearTouch>());
			interactTouch = ((interactTouch != null) ? interactTouch : GetComponentInParent<VRTK_InteractTouch>());
			interactGrab = ((interactGrab != null) ? interactGrab : GetComponentInParent<VRTK_InteractGrab>());
			interactUse = ((interactUse != null) ? interactUse : GetComponentInParent<VRTK_InteractUse>());
			controllerReference = VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject);
		}

		protected virtual void OnDisable()
		{
			UnsubscribeEvents();
			controllerType = SDK_BaseController.ControllerType.Undefined;
			for (int i = 0; i < fingerAnimationRoutine.Length; i++)
			{
				if (fingerAnimationRoutine[i] != null)
				{
					fingerAnimationRoutine[i] = null;
				}
			}
		}

		protected virtual void Update()
		{
			if (controllerType == SDK_BaseController.ControllerType.Undefined)
			{
				DetectController();
			}
			if (animator != null)
			{
				ProcessFinger(thumbState, 0);
				ProcessFinger(indexState, 1);
				ProcessFinger(middleState, 2);
				ProcessFinger(ringState, 3);
				ProcessFinger(pinkyState, 4);
			}
		}

		protected virtual void SubscribeButtonEvent(VRTK_ControllerEvents.ButtonAlias buttonType, ref VRTK_ControllerEvents.ButtonAlias saveType, ControllerInteractionEventHandler eventHandler)
		{
			if (buttonType != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				saveType = buttonType;
				controllerEvents.SubscribeToButtonAliasEvent(buttonType, startEvent: true, eventHandler);
				controllerEvents.SubscribeToButtonAliasEvent(buttonType, startEvent: false, eventHandler);
			}
		}

		protected virtual void UnsubscribeButtonEvent(VRTK_ControllerEvents.ButtonAlias buttonType, ControllerInteractionEventHandler eventHandler)
		{
			if (buttonType != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(buttonType, startEvent: true, eventHandler);
				controllerEvents.UnsubscribeToButtonAliasEvent(buttonType, startEvent: false, eventHandler);
			}
		}

		protected virtual void SubscribeButtonAxisEvent(SDK_BaseController.ButtonTypes buttonType, ref SDK_BaseController.ButtonTypes saveType, VRTK_ControllerEvents.AxisType axisType, ControllerInteractionEventHandler eventHandler)
		{
			saveType = buttonType;
			controllerEvents.SubscribeToAxisAliasEvent(buttonType, axisType, eventHandler);
		}

		protected virtual void UnsubscribeButtonAxisEvent(SDK_BaseController.ButtonTypes buttonType, VRTK_ControllerEvents.AxisType axisType, ControllerInteractionEventHandler eventHandler)
		{
			controllerEvents.UnsubscribeToAxisAliasEvent(buttonType, axisType, eventHandler);
		}

		protected virtual void SubscribeEvents()
		{
			if (controllerEvents != null)
			{
				SubscribeButtonEvent(thumbButton, ref savedThumbButtonState, DoThumbEvent);
				SubscribeButtonEvent(indexButton, ref savedIndexButtonState, DoIndexEvent);
				SubscribeButtonEvent(middleButton, ref savedMiddleButtonState, DoMiddleEvent);
				SubscribeButtonEvent(ringButton, ref savedRingButtonState, DoRingEvent);
				SubscribeButtonEvent(pinkyButton, ref savedPinkyButtonState, DoPinkyEvent);
				SubscribeButtonEvent(threeFingerButton, ref savedThreeFingerButtonState, DoThreeFingerEvent);
				SubscribeButtonAxisEvent(thumbAxisButton, ref savedThumbAxisButtonState, thumbState, DoThumbAxisEvent);
				SubscribeButtonAxisEvent(indexAxisButton, ref savedIndexAxisButtonState, indexState, DoIndexAxisEvent);
				SubscribeButtonAxisEvent(middleAxisButton, ref savedMiddleAxisButtonState, middleState, DoMiddleAxisEvent);
				SubscribeButtonAxisEvent(ringAxisButton, ref savedRingAxisButtonState, ringState, DoRingAxisEvent);
				SubscribeButtonAxisEvent(pinkyAxisButton, ref savedPinkyAxisButtonState, pinkyState, DoPinkyAxisEvent);
				SubscribeButtonAxisEvent(threeFingerAxisButton, ref savedThreeFingerAxisButtonState, threeFingerState, DoThreeFingerAxisEvent);
			}
			if (interactNearTouch != null)
			{
				interactNearTouch.ControllerNearTouchInteractableObject += DoControllerNearTouch;
				interactNearTouch.ControllerNearUntouchInteractableObject += DoControllerNearUntouch;
			}
			if (interactTouch != null)
			{
				interactTouch.ControllerTouchInteractableObject += DoControllerTouch;
				interactTouch.ControllerUntouchInteractableObject += DoControllerUntouch;
			}
			if (interactGrab != null)
			{
				interactGrab.ControllerGrabInteractableObject += DoControllerGrab;
				interactGrab.ControllerUngrabInteractableObject += DoControllerUngrab;
			}
			if (interactUse != null)
			{
				interactUse.ControllerUseInteractableObject += DoControllerUse;
				interactUse.ControllerUnuseInteractableObject += DoControllerUnuse;
			}
		}

		protected virtual void UnsubscribeEvents()
		{
			if (controllerEvents != null)
			{
				UnsubscribeButtonEvent(savedThumbButtonState, DoThumbEvent);
				UnsubscribeButtonEvent(savedIndexButtonState, DoIndexEvent);
				UnsubscribeButtonEvent(savedMiddleButtonState, DoMiddleEvent);
				UnsubscribeButtonEvent(savedRingButtonState, DoRingEvent);
				UnsubscribeButtonEvent(savedPinkyButtonState, DoPinkyEvent);
				UnsubscribeButtonEvent(savedThreeFingerButtonState, DoThreeFingerEvent);
				UnsubscribeButtonAxisEvent(savedThumbAxisButtonState, thumbState, DoThumbAxisEvent);
				UnsubscribeButtonAxisEvent(savedIndexAxisButtonState, indexState, DoIndexAxisEvent);
				UnsubscribeButtonAxisEvent(savedMiddleAxisButtonState, middleState, DoMiddleAxisEvent);
				UnsubscribeButtonAxisEvent(savedRingAxisButtonState, ringState, DoRingAxisEvent);
				UnsubscribeButtonAxisEvent(savedPinkyAxisButtonState, pinkyState, DoPinkyAxisEvent);
				UnsubscribeButtonAxisEvent(savedThreeFingerAxisButtonState, threeFingerState, DoThreeFingerAxisEvent);
			}
			if (interactNearTouch != null)
			{
				interactNearTouch.ControllerNearTouchInteractableObject -= DoControllerNearTouch;
				interactNearTouch.ControllerNearUntouchInteractableObject -= DoControllerNearUntouch;
			}
			if (interactTouch != null)
			{
				interactTouch.ControllerTouchInteractableObject -= DoControllerTouch;
				interactTouch.ControllerUntouchInteractableObject -= DoControllerUntouch;
			}
			if (interactGrab != null)
			{
				interactGrab.ControllerGrabInteractableObject -= DoControllerGrab;
				interactGrab.ControllerUngrabInteractableObject -= DoControllerUngrab;
			}
			if (interactUse != null)
			{
				interactUse.ControllerUseInteractableObject -= DoControllerUse;
				interactUse.ControllerUnuseInteractableObject -= DoControllerUnuse;
			}
		}

		protected virtual void SetFingerEvent(int fingerIndex, ControllerInteractionEventArgs e)
		{
			if (overrideAxisValues[fingerIndex] == OverrideState.NoOverride)
			{
				fingerChangeStates[fingerIndex] = true;
				fingerStates[fingerIndex] = ((e.buttonPressure != 0f) ? true : false);
			}
		}

		protected virtual void SetFingerAxisEvent(int fingerIndex, ControllerInteractionEventArgs e)
		{
			fingerRawAxis[fingerIndex] = e.buttonPressure;
			if (overrideAxisValues[fingerIndex] == OverrideState.NoOverride)
			{
				fingerAxis[fingerIndex] = e.buttonPressure;
			}
		}

		protected virtual void DoThumbEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(0, e);
		}

		protected virtual void DoIndexEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(1, e);
		}

		protected virtual void DoMiddleEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(2, e);
		}

		protected virtual void DoRingEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(3, e);
		}

		protected virtual void DoPinkyEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(4, e);
		}

		protected virtual void DoThreeFingerEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerEvent(2, e);
			SetFingerEvent(3, e);
			SetFingerEvent(4, e);
		}

		protected virtual void DoThumbAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(0, e);
		}

		protected virtual void DoIndexAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(1, e);
		}

		protected virtual void DoMiddleAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(2, e);
		}

		protected virtual void DoRingAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(3, e);
		}

		protected virtual void DoPinkyAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(4, e);
		}

		protected virtual void DoThreeFingerAxisEvent(object sender, ControllerInteractionEventArgs e)
		{
			SetFingerAxisEvent(2, e);
			SetFingerAxisEvent(3, e);
			SetFingerAxisEvent(4, e);
		}

		protected virtual bool IsButtonPressed(int arrayIndex)
		{
			float num = ((axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.SenseAxis && controllerEvents != null) ? controllerEvents.senseAxisPressThreshold : 0f);
			if (!fingerStates[arrayIndex])
			{
				return fingerRawAxis[arrayIndex] > num;
			}
			return true;
		}

		protected virtual void SaveFingerAxis(int arrayIndex, float updateAxis)
		{
			fingerSaveAxis[arrayIndex] = ((fingerSaveAxis[arrayIndex] != fingerForceAxis[arrayIndex]) ? updateAxis : fingerSaveAxis[arrayIndex]);
		}

		protected virtual void HandleOverrideOn(bool ignoreAllOverrides, float[] givenFingerAxis, bool[] overridePermissions, float[] overrideValues)
		{
			if (ignoreAllOverrides)
			{
				return;
			}
			for (int i = 0; i < overrideAxisValues.Length; i++)
			{
				if (overridePermissions[i] && !IsButtonPressed(i) && overrideAxisValues[i] != OverrideState.WasOverring)
				{
					SetOverrideValue(i, ref overrideAxisValues, OverrideState.IsOverriding);
					if (overrideAxisValues[i] == OverrideState.NoOverride)
					{
						fingerUntouchedAxis[i] = givenFingerAxis[i];
					}
					SaveFingerAxis(i, givenFingerAxis[i]);
					fingerForceAxis[i] = overrideValues[i];
				}
			}
		}

		protected virtual void HandleOverrideOff(bool ignoreAllOverrides, bool[] overridePermissions, bool keepOverriding)
		{
			if (ignoreAllOverrides)
			{
				return;
			}
			for (int i = 0; i < fingerAxis.Length; i++)
			{
				if (overridePermissions[i] && !IsButtonPressed(i) && overrideAxisValues[i] == OverrideState.IsOverriding)
				{
					SetOverrideValue(i, ref overrideAxisValues, keepOverriding ? OverrideState.KeepOverring : OverrideState.WasOverring);
					fingerAxis[i] = fingerForceAxis[i];
					fingerForceAxis[i] = fingerSaveAxis[i];
				}
			}
		}

		protected virtual float CorrectOverrideValue(float givenOverride)
		{
			if (givenOverride != 0f)
			{
				return givenOverride;
			}
			return 0.0001f;
		}

		protected virtual bool ApplyFingerOverrides(AxisOverrides.ApplyOverrideType overrideType, int arrayIndex)
		{
			if (overrideType == AxisOverrides.ApplyOverrideType.Always || (overrideType == AxisOverrides.ApplyOverrideType.DigitalState && axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.Digital) || (overrideType == AxisOverrides.ApplyOverrideType.AxisState && axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.Axis) || (overrideType == AxisOverrides.ApplyOverrideType.SenseAxisState && axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.SenseAxis) || (overrideType == AxisOverrides.ApplyOverrideType.AxisAndSenseAxisState && (axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.Axis || axisTypes[arrayIndex] == VRTK_ControllerEvents.AxisType.SenseAxis)))
			{
				return true;
			}
			return false;
		}

		protected virtual bool[] GetOverridePermissions(AxisOverrides overrideType)
		{
			return new bool[5]
			{
				ApplyFingerOverrides(overrideType.applyThumbOverride, 0),
				ApplyFingerOverrides(overrideType.applyIndexOverride, 1),
				ApplyFingerOverrides(overrideType.applyMiddleOverride, 2),
				ApplyFingerOverrides(overrideType.applyRingOverride, 3),
				ApplyFingerOverrides(overrideType.applyPinkyOverride, 4)
			};
		}

		protected virtual float[] GetOverrideValues(AxisOverrides overrideType)
		{
			return new float[5]
			{
				CorrectOverrideValue(overrideType.thumbOverride),
				CorrectOverrideValue(overrideType.indexOverride),
				CorrectOverrideValue(overrideType.middleOverride),
				CorrectOverrideValue(overrideType.ringOverride),
				CorrectOverrideValue(overrideType.pinkyOverride)
			};
		}

		protected virtual void SetAnimatorStateOn(string state, AxisOverrides overrides)
		{
			animator.SetFloat(state, overrides.ignoreAllOverrides ? (-1f) : overrides.stateValue);
		}

		protected virtual void SetAnimatorStateOff(string state)
		{
			animator.SetFloat(state, -1f);
		}

		protected virtual void DoControllerNearTouch(object sender, ObjectInteractEventArgs e)
		{
			if (interactTouch != null && interactTouch.GetTouchedObject() == null)
			{
				SetAnimatorStateOn("NearTouchState", nearTouchOverrides);
				HandleOverrideOn(nearTouchOverrides.ignoreAllOverrides, fingerAxis, GetOverridePermissions(nearTouchOverrides), GetOverrideValues(nearTouchOverrides));
			}
		}

		protected virtual void DoControllerNearUntouch(object sender, ObjectInteractEventArgs e)
		{
			if (interactNearTouch.GetNearTouchedObjects().Count != 0 || (!(interactTouch == null) && !(interactTouch.GetTouchedObject() == null)))
			{
				return;
			}
			for (int i = 0; i < fingerUntouchedAxis.Length; i++)
			{
				if (!IsButtonPressed(i))
				{
					SetOverrideValue(i, ref overrideAxisValues, OverrideState.WasOverring);
					fingerForceAxis[i] = fingerUntouchedAxis[i];
				}
			}
			SetAnimatorStateOff("NearTouchState");
			HandleOverrideOff(nearTouchOverrides.ignoreAllOverrides, GetOverridePermissions(nearTouchOverrides), keepOverriding: false);
		}

		protected virtual void DoControllerTouch(object sender, ObjectInteractEventArgs e)
		{
			SetAnimatorStateOn("TouchState", touchOverrides);
			HandleOverrideOn(touchOverrides.ignoreAllOverrides, fingerAxis, GetOverridePermissions(touchOverrides), GetOverrideValues(touchOverrides));
		}

		protected virtual void DoControllerUntouch(object sender, ObjectInteractEventArgs e)
		{
			if (interactNearTouch == null || nearTouchOverrides.ignoreAllOverrides)
			{
				for (int i = 0; i < fingerUntouchedAxis.Length; i++)
				{
					if (!IsButtonPressed(i))
					{
						SetOverrideValue(i, ref overrideAxisValues, OverrideState.WasOverring);
						fingerForceAxis[i] = fingerUntouchedAxis[i];
					}
				}
			}
			SetAnimatorStateOff("TouchState");
			HandleOverrideOff(touchOverrides.ignoreAllOverrides, GetOverridePermissions(touchOverrides), keepOverriding: false);
		}

		protected virtual void DoControllerGrab(object sender, ObjectInteractEventArgs e)
		{
			bool flag = interactUse != null && interactUse.GetUsingObject() != null;
			float[] overrideValues = GetOverrideValues(flag ? useOverrides : grabOverrides);
			float[] givenFingerAxis = (flag ? GetOverrideValues(grabOverrides) : fingerAxis);
			SetAnimatorStateOn("GrabState", grabOverrides);
			HandleOverrideOn(grabOverrides.ignoreAllOverrides, givenFingerAxis, GetOverridePermissions(grabOverrides), overrideValues);
		}

		protected virtual void DoControllerUngrab(object sender, ObjectInteractEventArgs e)
		{
			SetAnimatorStateOff("GrabState");
			HandleOverrideOff(grabOverrides.ignoreAllOverrides, GetOverridePermissions(touchOverrides), keepOverriding: false);
		}

		protected virtual void DoControllerUse(object sender, ObjectInteractEventArgs e)
		{
			float[] givenFingerAxis = ((interactGrab != null && interactGrab.GetGrabbedObject() != null) ? GetOverrideValues(grabOverrides) : fingerAxis);
			SetAnimatorStateOn("UseState", useOverrides);
			HandleOverrideOn(useOverrides.ignoreAllOverrides, givenFingerAxis, GetOverridePermissions(useOverrides), GetOverrideValues(useOverrides));
		}

		protected virtual void DoControllerUnuse(object sender, ObjectInteractEventArgs e)
		{
			SetAnimatorStateOff("UseState");
			HandleOverrideOff(useOverrides.ignoreAllOverrides, GetOverridePermissions(useOverrides), keepOverriding: true);
		}

		protected virtual void DetectController()
		{
			controllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
			if (controllerType == SDK_BaseController.ControllerType.Undefined)
			{
				return;
			}
			if (setFingersForControllerType)
			{
				switch (controllerType)
				{
				case SDK_BaseController.ControllerType.SteamVR_ViveWand:
				case SDK_BaseController.ControllerType.WindowsMR_MotionController:
				case SDK_BaseController.ControllerType.SteamVR_WindowsMRController:
					thumbState = VRTK_ControllerEvents.AxisType.Digital;
					indexState = VRTK_ControllerEvents.AxisType.Axis;
					middleState = VRTK_ControllerEvents.AxisType.Digital;
					ringState = VRTK_ControllerEvents.AxisType.Digital;
					pinkyState = VRTK_ControllerEvents.AxisType.Digital;
					threeFingerState = VRTK_ControllerEvents.AxisType.Digital;
					break;
				case SDK_BaseController.ControllerType.SteamVR_OculusTouch:
				case SDK_BaseController.ControllerType.Oculus_OculusTouch:
					thumbState = VRTK_ControllerEvents.AxisType.Digital;
					indexState = VRTK_ControllerEvents.AxisType.Axis;
					middleState = VRTK_ControllerEvents.AxisType.Digital;
					ringState = VRTK_ControllerEvents.AxisType.Digital;
					pinkyState = VRTK_ControllerEvents.AxisType.Digital;
					threeFingerState = VRTK_ControllerEvents.AxisType.Axis;
					break;
				case SDK_BaseController.ControllerType.SteamVR_ValveKnuckles:
					thumbState = VRTK_ControllerEvents.AxisType.Digital;
					indexState = VRTK_ControllerEvents.AxisType.SenseAxis;
					middleState = VRTK_ControllerEvents.AxisType.SenseAxis;
					ringState = VRTK_ControllerEvents.AxisType.SenseAxis;
					pinkyState = VRTK_ControllerEvents.AxisType.SenseAxis;
					threeFingerState = VRTK_ControllerEvents.AxisType.SenseAxis;
					threeFingerAxisButton = SDK_BaseController.ButtonTypes.StartMenu;
					break;
				default:
					thumbState = VRTK_ControllerEvents.AxisType.Digital;
					indexState = VRTK_ControllerEvents.AxisType.Digital;
					middleState = VRTK_ControllerEvents.AxisType.Digital;
					ringState = VRTK_ControllerEvents.AxisType.Digital;
					pinkyState = VRTK_ControllerEvents.AxisType.Digital;
					threeFingerState = VRTK_ControllerEvents.AxisType.Digital;
					break;
				}
			}
			UnsubscribeEvents();
			SubscribeEvents();
			if (mirrorModel)
			{
				mirrorModel = false;
				MirrorHand();
			}
		}

		protected virtual void MirrorHand()
		{
			Transform transform = ((handModel != null) ? handModel : base.transform.Find("Model"));
			if (transform != null)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
			}
		}

		protected virtual void SetOverrideValue(int stateIndex, ref OverrideState[] overrideState, OverrideState stateValue)
		{
			overrideState[stateIndex] = stateValue;
		}

		protected virtual void ProcessFinger(VRTK_ControllerEvents.AxisType state, int arrayIndex)
		{
			axisTypes[arrayIndex] = state;
			if (overrideAxisValues[arrayIndex] != OverrideState.NoOverride)
			{
				if (fingerAxis[arrayIndex] != fingerForceAxis[arrayIndex])
				{
					LerpChangePosition(arrayIndex, fingerAxis[arrayIndex], fingerForceAxis[arrayIndex], animationSnapSpeed);
				}
				else if (overrideAxisValues[arrayIndex] == OverrideState.WasOverring)
				{
					SetOverrideValue(arrayIndex, ref overrideAxisValues, OverrideState.NoOverride);
				}
			}
			else if (state == VRTK_ControllerEvents.AxisType.Digital)
			{
				if (fingerChangeStates[arrayIndex])
				{
					fingerChangeStates[arrayIndex] = false;
					float startPosition = (fingerStates[arrayIndex] ? 0f : 1f);
					float targetPosition = (fingerStates[arrayIndex] ? 1f : 0f);
					LerpChangePosition(arrayIndex, startPosition, targetPosition, animationSnapSpeed);
				}
			}
			else
			{
				SetFingerPosition(arrayIndex, fingerAxis[arrayIndex]);
			}
			if (((interactTouch == null && interactNearTouch == null) || (interactNearTouch == null && interactTouch.GetTouchedObject() == null) || (interactNearTouch != null && interactNearTouch.GetNearTouchedObjects().Count == 0)) && overrideAxisValues[arrayIndex] != OverrideState.NoOverride)
			{
				SetOverrideValue(arrayIndex, ref overrideAxisValues, OverrideState.NoOverride);
			}
		}

		protected virtual void LerpChangePosition(int arrayIndex, float startPosition, float targetPosition, float speed)
		{
			fingerAnimationRoutine[arrayIndex] = StartCoroutine(ChangePosition(arrayIndex, startPosition, targetPosition, speed));
		}

		protected virtual IEnumerator ChangePosition(int arrayIndex, float startAxis, float targetAxis, float time)
		{
			float elapsedTime = 0f;
			while (elapsedTime < time)
			{
				elapsedTime += Time.deltaTime;
				float axis = Mathf.Lerp(startAxis, targetAxis, elapsedTime / time);
				SetFingerPosition(arrayIndex, axis);
				yield return null;
			}
			SetFingerPosition(arrayIndex, targetAxis);
			fingerAnimationRoutine[arrayIndex] = null;
		}

		protected virtual void SetFingerPosition(int arrayIndex, float axis)
		{
			int layerIndex = arrayIndex + 1;
			animator.SetLayerWeight(layerIndex, axis);
			fingerAxis[arrayIndex] = axis;
			if (overrideAxisValues[arrayIndex] == OverrideState.WasOverring)
			{
				SetOverrideValue(arrayIndex, ref overrideAxisValues, OverrideState.NoOverride);
			}
		}
	}
}
