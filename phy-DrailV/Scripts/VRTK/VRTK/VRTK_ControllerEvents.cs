using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_ControllerEvents")]
	public class VRTK_ControllerEvents : MonoBehaviour
	{
		public enum ButtonAlias
		{
			Undefined = 0,
			TriggerHairline = 1,
			TriggerTouch = 2,
			TriggerPress = 3,
			TriggerClick = 4,
			GripHairline = 5,
			GripTouch = 6,
			GripPress = 7,
			GripClick = 8,
			TouchpadTouch = 9,
			TouchpadPress = 10,
			TouchpadTwoTouch = 11,
			TouchpadTwoPress = 12,
			ButtonOneTouch = 13,
			ButtonOnePress = 14,
			ButtonTwoTouch = 15,
			ButtonTwoPress = 16,
			StartMenuPress = 17,
			TouchpadSense = 18,
			TriggerSense = 19,
			MiddleFingerSense = 20,
			RingFingerSense = 21,
			PinkyFingerSense = 22,
			GripSense = 23,
			GripSensePress = 24
		}

		public enum Vector2AxisAlias
		{
			Undefined = 0,
			Touchpad = 1,
			TouchpadTwo = 2
		}

		public enum AxisType
		{
			Digital = 0,
			Axis = 1,
			SenseAxis = 2
		}

		[Header("Axis Refinement Settings")]
		[Tooltip("The amount of fidelity in the changes on the axis, which is defaulted to 1. Any number higher than 2 will probably give too sensitive results.")]
		public int axisFidelity = 1;

		[Tooltip("The level on a sense axis to reach before the sense axis is forced to 0f")]
		[Range(0f, 1f)]
		public float senseAxisForceZeroThreshold = 0.15f;

		[Tooltip("The amount of pressure required to be applied to a sense button before considering the sense button pressed.")]
		[Range(0f, 1f)]
		public float senseAxisPressThreshold = 0.95f;

		[Header("Trigger Refinement Settings")]
		[Tooltip("The level on the trigger axis to reach before a click is registered.")]
		public float triggerClickThreshold = 1f;

		[Tooltip("The level on the trigger axis to reach before the axis is forced to 0f.")]
		public float triggerForceZeroThreshold = 0.01f;

		[Tooltip("If this is checked then the trigger axis will be forced to 0f when the trigger button reports an untouch event.")]
		public bool triggerAxisZeroOnUntouch;

		[Header("Grip Refinement Settings")]
		[Tooltip("The level on the grip axis to reach before a click is registered.")]
		public float gripClickThreshold = 1f;

		[Tooltip("The level on the grip axis to reach before the axis is forced to 0f.")]
		public float gripForceZeroThreshold = 0.01f;

		[Tooltip("If this is checked then the grip axis will be forced to 0f when the grip button reports an untouch event.")]
		public bool gripAxisZeroOnUntouch;

		[HideInInspector]
		public bool triggerPressed;

		[HideInInspector]
		public bool triggerTouched;

		[HideInInspector]
		public bool triggerHairlinePressed;

		[HideInInspector]
		public bool triggerClicked;

		[HideInInspector]
		public bool triggerAxisChanged;

		[HideInInspector]
		public bool triggerSenseAxisChanged;

		[HideInInspector]
		public bool gripPressed;

		[HideInInspector]
		public bool gripTouched;

		[HideInInspector]
		public bool gripHairlinePressed;

		[HideInInspector]
		public bool gripClicked;

		[HideInInspector]
		public bool gripAxisChanged;

		[HideInInspector]
		public bool touchpadPressed;

		[HideInInspector]
		public bool touchpadTouched;

		[HideInInspector]
		public bool touchpadAxisChanged;

		[HideInInspector]
		public bool touchpadSenseAxisChanged;

		[HideInInspector]
		public bool touchpadTwoTouched;

		[HideInInspector]
		public bool touchpadTwoPressed;

		[HideInInspector]
		public bool touchpadTwoAxisChanged;

		[HideInInspector]
		public bool buttonOnePressed;

		[HideInInspector]
		public bool buttonOneTouched;

		[HideInInspector]
		public bool buttonTwoPressed;

		[HideInInspector]
		public bool buttonTwoTouched;

		[HideInInspector]
		public bool startMenuPressed;

		[HideInInspector]
		public bool middleFingerSenseAxisChanged;

		[HideInInspector]
		public bool ringFingerSenseAxisChanged;

		[HideInInspector]
		public bool pinkyFingerSenseAxisChanged;

		[HideInInspector]
		public bool gripSenseAxisChanged;

		[HideInInspector]
		public bool gripSensePressed;

		[HideInInspector]
		public bool controllerVisible = true;

		protected Vector2 touchpadAxis = Vector2.zero;

		protected Vector2 touchpadTwoAxis = Vector2.zero;

		protected Vector2 triggerAxis = Vector2.zero;

		protected Vector2 gripAxis = Vector2.zero;

		protected float touchpadSenseAxis;

		protected float triggerSenseAxis;

		protected float middleFingerSenseAxis;

		protected float ringFingerSenseAxis;

		protected float pinkyFingerSenseAxis;

		protected float gripSenseAxis;

		protected float hairTriggerDelta;

		protected float hairGripDelta;

		protected VRTK_TrackedController trackedController;

		public event ControllerInteractionEventHandler TriggerPressed;

		public event ControllerInteractionEventHandler TriggerReleased;

		public event ControllerInteractionEventHandler TriggerTouchStart;

		public event ControllerInteractionEventHandler TriggerTouchEnd;

		public event ControllerInteractionEventHandler TriggerHairlineStart;

		public event ControllerInteractionEventHandler TriggerHairlineEnd;

		public event ControllerInteractionEventHandler TriggerClicked;

		public event ControllerInteractionEventHandler TriggerUnclicked;

		public event ControllerInteractionEventHandler TriggerAxisChanged;

		public event ControllerInteractionEventHandler TriggerSenseAxisChanged;

		public event ControllerInteractionEventHandler GripPressed;

		public event ControllerInteractionEventHandler GripReleased;

		public event ControllerInteractionEventHandler GripTouchStart;

		public event ControllerInteractionEventHandler GripTouchEnd;

		public event ControllerInteractionEventHandler GripHairlineStart;

		public event ControllerInteractionEventHandler GripHairlineEnd;

		public event ControllerInteractionEventHandler GripClicked;

		public event ControllerInteractionEventHandler GripUnclicked;

		public event ControllerInteractionEventHandler GripAxisChanged;

		public event ControllerInteractionEventHandler TouchpadPressed;

		public event ControllerInteractionEventHandler TouchpadReleased;

		public event ControllerInteractionEventHandler TouchpadTouchStart;

		public event ControllerInteractionEventHandler TouchpadTouchEnd;

		public event ControllerInteractionEventHandler TouchpadAxisChanged;

		public event ControllerInteractionEventHandler TouchpadSenseAxisChanged;

		public event ControllerInteractionEventHandler TouchpadTwoPressed;

		public event ControllerInteractionEventHandler TouchpadTwoReleased;

		public event ControllerInteractionEventHandler TouchpadTwoTouchStart;

		public event ControllerInteractionEventHandler TouchpadTwoTouchEnd;

		public event ControllerInteractionEventHandler TouchpadTwoAxisChanged;

		public event ControllerInteractionEventHandler ButtonOneTouchStart;

		public event ControllerInteractionEventHandler ButtonOneTouchEnd;

		public event ControllerInteractionEventHandler ButtonOnePressed;

		public event ControllerInteractionEventHandler ButtonOneReleased;

		public event ControllerInteractionEventHandler ButtonTwoTouchStart;

		public event ControllerInteractionEventHandler ButtonTwoTouchEnd;

		public event ControllerInteractionEventHandler ButtonTwoPressed;

		public event ControllerInteractionEventHandler ButtonTwoReleased;

		public event ControllerInteractionEventHandler StartMenuPressed;

		public event ControllerInteractionEventHandler StartMenuReleased;

		public event ControllerInteractionEventHandler MiddleFingerSenseAxisChanged;

		public event ControllerInteractionEventHandler RingFingerSenseAxisChanged;

		public event ControllerInteractionEventHandler PinkyFingerSenseAxisChanged;

		public event ControllerInteractionEventHandler GripSenseAxisChanged;

		public event ControllerInteractionEventHandler GripSensePressed;

		public event ControllerInteractionEventHandler GripSenseReleased;

		public event ControllerInteractionEventHandler ControllerEnabled;

		public event ControllerInteractionEventHandler ControllerDisabled;

		public event ControllerInteractionEventHandler ControllerIndexChanged;

		public event ControllerInteractionEventHandler ControllerModelAvailable;

		public event ControllerInteractionEventHandler ControllerVisible;

		public event ControllerInteractionEventHandler ControllerHidden;

		public virtual void OnTriggerPressed(ControllerInteractionEventArgs e)
		{
			if (this.TriggerPressed != null)
			{
				this.TriggerPressed(this, e);
			}
		}

		public virtual void OnTriggerReleased(ControllerInteractionEventArgs e)
		{
			if (this.TriggerReleased != null)
			{
				this.TriggerReleased(this, e);
			}
		}

		public virtual void OnTriggerTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.TriggerTouchStart != null)
			{
				this.TriggerTouchStart(this, e);
			}
		}

		public virtual void OnTriggerTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.TriggerTouchEnd != null)
			{
				this.TriggerTouchEnd(this, e);
			}
		}

		public virtual void OnTriggerHairlineStart(ControllerInteractionEventArgs e)
		{
			if (this.TriggerHairlineStart != null)
			{
				this.TriggerHairlineStart(this, e);
			}
		}

		public virtual void OnTriggerHairlineEnd(ControllerInteractionEventArgs e)
		{
			if (this.TriggerHairlineEnd != null)
			{
				this.TriggerHairlineEnd(this, e);
			}
		}

		public virtual void OnTriggerClicked(ControllerInteractionEventArgs e)
		{
			if (this.TriggerClicked != null)
			{
				this.TriggerClicked(this, e);
			}
		}

		public virtual void OnTriggerUnclicked(ControllerInteractionEventArgs e)
		{
			if (this.TriggerUnclicked != null)
			{
				this.TriggerUnclicked(this, e);
			}
		}

		public virtual void OnTriggerAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.TriggerAxisChanged != null)
			{
				this.TriggerAxisChanged(this, e);
			}
		}

		public virtual void OnTriggerSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.TriggerSenseAxisChanged != null)
			{
				this.TriggerSenseAxisChanged(this, e);
			}
		}

		public virtual void OnGripPressed(ControllerInteractionEventArgs e)
		{
			if (this.GripPressed != null)
			{
				this.GripPressed(this, e);
			}
		}

		public virtual void OnGripReleased(ControllerInteractionEventArgs e)
		{
			if (this.GripReleased != null)
			{
				this.GripReleased(this, e);
			}
		}

		public virtual void OnGripTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.GripTouchStart != null)
			{
				this.GripTouchStart(this, e);
			}
		}

		public virtual void OnGripTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.GripTouchEnd != null)
			{
				this.GripTouchEnd(this, e);
			}
		}

		public virtual void OnGripHairlineStart(ControllerInteractionEventArgs e)
		{
			if (this.GripHairlineStart != null)
			{
				this.GripHairlineStart(this, e);
			}
		}

		public virtual void OnGripHairlineEnd(ControllerInteractionEventArgs e)
		{
			if (this.GripHairlineEnd != null)
			{
				this.GripHairlineEnd(this, e);
			}
		}

		public virtual void OnGripClicked(ControllerInteractionEventArgs e)
		{
			if (this.GripClicked != null)
			{
				this.GripClicked(this, e);
			}
		}

		public virtual void OnGripUnclicked(ControllerInteractionEventArgs e)
		{
			if (this.GripUnclicked != null)
			{
				this.GripUnclicked(this, e);
			}
		}

		public virtual void OnGripAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.GripAxisChanged != null)
			{
				this.GripAxisChanged(this, e);
			}
		}

		public virtual void OnTouchpadPressed(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadPressed != null)
			{
				this.TouchpadPressed(this, e);
			}
		}

		public virtual void OnTouchpadReleased(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadReleased != null)
			{
				this.TouchpadReleased(this, e);
			}
		}

		public virtual void OnTouchpadTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTouchStart != null)
			{
				this.TouchpadTouchStart(this, e);
			}
		}

		public virtual void OnTouchpadTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTouchEnd != null)
			{
				this.TouchpadTouchEnd(this, e);
			}
		}

		public virtual void OnTouchpadAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadAxisChanged != null)
			{
				this.TouchpadAxisChanged(this, e);
			}
		}

		public virtual void OnTouchpadSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadSenseAxisChanged != null)
			{
				this.TouchpadSenseAxisChanged(this, e);
			}
		}

		public virtual void OnTouchpadTwoPressed(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTwoPressed != null)
			{
				this.TouchpadTwoPressed(this, e);
			}
		}

		public virtual void OnTouchpadTwoReleased(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTwoReleased != null)
			{
				this.TouchpadTwoReleased(this, e);
			}
		}

		public virtual void OnTouchpadTwoTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTwoTouchStart != null)
			{
				this.TouchpadTwoTouchStart(this, e);
			}
		}

		public virtual void OnTouchpadTwoTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTwoTouchEnd != null)
			{
				this.TouchpadTwoTouchEnd(this, e);
			}
		}

		public virtual void OnTouchpadTwoAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.TouchpadTwoAxisChanged != null)
			{
				this.TouchpadTwoAxisChanged(this, e);
			}
		}

		public virtual void OnButtonOneTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.ButtonOneTouchStart != null)
			{
				this.ButtonOneTouchStart(this, e);
			}
		}

		public virtual void OnButtonOneTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.ButtonOneTouchEnd != null)
			{
				this.ButtonOneTouchEnd(this, e);
			}
		}

		public virtual void OnButtonOnePressed(ControllerInteractionEventArgs e)
		{
			if (this.ButtonOnePressed != null)
			{
				this.ButtonOnePressed(this, e);
			}
		}

		public virtual void OnButtonOneReleased(ControllerInteractionEventArgs e)
		{
			if (this.ButtonOneReleased != null)
			{
				this.ButtonOneReleased(this, e);
			}
		}

		public virtual void OnButtonTwoTouchStart(ControllerInteractionEventArgs e)
		{
			if (this.ButtonTwoTouchStart != null)
			{
				this.ButtonTwoTouchStart(this, e);
			}
		}

		public virtual void OnButtonTwoTouchEnd(ControllerInteractionEventArgs e)
		{
			if (this.ButtonTwoTouchEnd != null)
			{
				this.ButtonTwoTouchEnd(this, e);
			}
		}

		public virtual void OnButtonTwoPressed(ControllerInteractionEventArgs e)
		{
			if (this.ButtonTwoPressed != null)
			{
				this.ButtonTwoPressed(this, e);
			}
		}

		public virtual void OnButtonTwoReleased(ControllerInteractionEventArgs e)
		{
			if (this.ButtonTwoReleased != null)
			{
				this.ButtonTwoReleased(this, e);
			}
		}

		public virtual void OnStartMenuPressed(ControllerInteractionEventArgs e)
		{
			if (this.StartMenuPressed != null)
			{
				this.StartMenuPressed(this, e);
			}
		}

		public virtual void OnStartMenuReleased(ControllerInteractionEventArgs e)
		{
			if (this.StartMenuReleased != null)
			{
				this.StartMenuReleased(this, e);
			}
		}

		public virtual void OnMiddleFingerSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.MiddleFingerSenseAxisChanged != null)
			{
				this.MiddleFingerSenseAxisChanged(this, e);
			}
		}

		public virtual void OnRingFingerSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.RingFingerSenseAxisChanged != null)
			{
				this.RingFingerSenseAxisChanged(this, e);
			}
		}

		public virtual void OnPinkyFingerSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.PinkyFingerSenseAxisChanged != null)
			{
				this.PinkyFingerSenseAxisChanged(this, e);
			}
		}

		public virtual void OnGripSenseAxisChanged(ControllerInteractionEventArgs e)
		{
			if (this.GripSenseAxisChanged != null)
			{
				this.GripSenseAxisChanged(this, e);
			}
		}

		public virtual void OnGripSensePressed(ControllerInteractionEventArgs e)
		{
			if (this.GripSensePressed != null)
			{
				this.GripSensePressed(this, e);
			}
		}

		public virtual void OnGripSenseReleased(ControllerInteractionEventArgs e)
		{
			if (this.GripSenseReleased != null)
			{
				this.GripSenseReleased(this, e);
			}
		}

		public virtual void OnControllerEnabled(ControllerInteractionEventArgs e)
		{
			if (this.ControllerEnabled != null)
			{
				this.ControllerEnabled(this, e);
			}
		}

		public virtual void OnControllerDisabled(ControllerInteractionEventArgs e)
		{
			if (this.ControllerDisabled != null)
			{
				this.ControllerDisabled(this, e);
			}
		}

		public virtual void OnControllerIndexChanged(ControllerInteractionEventArgs e)
		{
			if (this.ControllerIndexChanged != null)
			{
				this.ControllerIndexChanged(this, e);
			}
		}

		public virtual void OnControllerModelAvailable(ControllerInteractionEventArgs e)
		{
			if (this.ControllerModelAvailable != null)
			{
				this.ControllerModelAvailable(this, e);
			}
		}

		public virtual void OnControllerVisible(ControllerInteractionEventArgs e)
		{
			controllerVisible = true;
			if (this.ControllerVisible != null)
			{
				this.ControllerVisible(this, e);
			}
		}

		public virtual void OnControllerHidden(ControllerInteractionEventArgs e)
		{
			controllerVisible = false;
			if (this.ControllerHidden != null)
			{
				this.ControllerHidden(this, e);
			}
		}

		public virtual ControllerInteractionEventArgs SetControllerEvent()
		{
			bool buttonBool = false;
			return SetControllerEvent(ref buttonBool);
		}

		public virtual ControllerInteractionEventArgs SetControllerEvent(ref bool buttonBool, bool value = false, float buttonPressure = 0f)
		{
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
			buttonBool = value;
			ControllerInteractionEventArgs result = default(ControllerInteractionEventArgs);
			result.controllerReference = controllerReference;
			result.buttonPressure = buttonPressure;
			result.touchpadAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference);
			result.touchpadAngle = CalculateVector2AxisAngle(result.touchpadAxis);
			result.touchpadTwoAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.TouchpadTwo, controllerReference);
			result.touchpadTwoAngle = CalculateVector2AxisAngle(result.touchpadTwoAxis);
			return result;
		}

		public virtual SDK_BaseController.ControllerType GetControllerType()
		{
			if (!(trackedController != null))
			{
				return SDK_BaseController.ControllerType.Undefined;
			}
			return trackedController.GetControllerType();
		}

		public virtual Vector2 GetAxis(Vector2AxisAlias vector2AxisType)
		{
			switch (vector2AxisType)
			{
			case Vector2AxisAlias.Touchpad:
				return GetTouchpadAxis();
			case Vector2AxisAlias.TouchpadTwo:
				return GetTouchpadTwoAxis();
			default:
				return Vector2.zero;
			}
		}

		public virtual Vector2 GetTouchpadAxis()
		{
			return touchpadAxis;
		}

		public virtual Vector2 GetTouchpadTwoAxis()
		{
			return touchpadTwoAxis;
		}

		public virtual float GetAxisAngle(Vector2AxisAlias vector2AxisType)
		{
			switch (vector2AxisType)
			{
			case Vector2AxisAlias.Touchpad:
				return GetTouchpadAxisAngle();
			case Vector2AxisAlias.TouchpadTwo:
				return GetTouchpadTwoAxisAngle();
			default:
				return 0f;
			}
		}

		public virtual float GetTouchpadAxisAngle()
		{
			return CalculateVector2AxisAngle(touchpadAxis);
		}

		public virtual float GetTouchpadTwoAxisAngle()
		{
			return CalculateVector2AxisAngle(touchpadTwoAxis);
		}

		public virtual float GetTriggerAxis()
		{
			return triggerAxis.x;
		}

		public virtual float GetGripAxis()
		{
			return gripAxis.x;
		}

		public virtual float GetHairTriggerDelta()
		{
			return hairTriggerDelta;
		}

		public virtual float GetHairGripDelta()
		{
			return hairGripDelta;
		}

		public virtual float GetTouchpadSenseAxis()
		{
			return touchpadSenseAxis;
		}

		public virtual float GetTriggerSenseAxis()
		{
			return triggerSenseAxis;
		}

		public virtual float GetMiddleFingerSenseAxis()
		{
			return middleFingerSenseAxis;
		}

		public virtual float GetRingFingerSenseAxis()
		{
			return ringFingerSenseAxis;
		}

		public virtual float GetPinkyFingerSenseAxis()
		{
			return pinkyFingerSenseAxis;
		}

		public virtual float GetGripSenseAxis()
		{
			return gripSenseAxis;
		}

		public virtual bool AnyButtonPressed()
		{
			if (!triggerPressed && !gripPressed && !touchpadPressed && !touchpadTwoPressed && !buttonOnePressed && !buttonTwoPressed && !startMenuPressed)
			{
				return gripSensePressed;
			}
			return true;
		}

		public virtual bool GetAxisState(Vector2AxisAlias axis, SDK_BaseController.ButtonPressTypes pressType)
		{
			switch (pressType)
			{
			case SDK_BaseController.ButtonPressTypes.Press:
			case SDK_BaseController.ButtonPressTypes.PressDown:
			case SDK_BaseController.ButtonPressTypes.PressUp:
				switch (axis)
				{
				case Vector2AxisAlias.Touchpad:
					return touchpadPressed;
				case Vector2AxisAlias.TouchpadTwo:
					return touchpadTwoPressed;
				default:
					return false;
				}
			case SDK_BaseController.ButtonPressTypes.Touch:
			case SDK_BaseController.ButtonPressTypes.TouchDown:
			case SDK_BaseController.ButtonPressTypes.TouchUp:
				switch (axis)
				{
				case Vector2AxisAlias.Touchpad:
					return touchpadTouched;
				case Vector2AxisAlias.TouchpadTwo:
					return touchpadTwoTouched;
				default:
					return false;
				}
			default:
				return false;
			}
		}

		public virtual bool IsButtonPressed(ButtonAlias button)
		{
			switch (button)
			{
			case ButtonAlias.TriggerHairline:
				return triggerHairlinePressed;
			case ButtonAlias.TriggerTouch:
				return triggerTouched;
			case ButtonAlias.TriggerPress:
				return triggerPressed;
			case ButtonAlias.TriggerClick:
				return triggerClicked;
			case ButtonAlias.TriggerSense:
				return triggerSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.GripHairline:
				return gripHairlinePressed;
			case ButtonAlias.GripTouch:
				return gripTouched;
			case ButtonAlias.GripPress:
				return gripPressed;
			case ButtonAlias.GripClick:
				return gripClicked;
			case ButtonAlias.TouchpadTouch:
				return touchpadTouched;
			case ButtonAlias.TouchpadPress:
				return touchpadPressed;
			case ButtonAlias.TouchpadTwoTouch:
				return touchpadTwoTouched;
			case ButtonAlias.TouchpadTwoPress:
				return touchpadTwoPressed;
			case ButtonAlias.TouchpadSense:
				return touchpadSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.ButtonOnePress:
				return buttonOnePressed;
			case ButtonAlias.ButtonOneTouch:
				return buttonOneTouched;
			case ButtonAlias.ButtonTwoPress:
				return buttonTwoPressed;
			case ButtonAlias.ButtonTwoTouch:
				return buttonTwoTouched;
			case ButtonAlias.StartMenuPress:
				return startMenuPressed;
			case ButtonAlias.MiddleFingerSense:
				return middleFingerSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.RingFingerSense:
				return ringFingerSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.PinkyFingerSense:
				return pinkyFingerSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.GripSense:
				return gripSenseAxis >= senseAxisPressThreshold;
			case ButtonAlias.GripSensePress:
				return gripSensePressed;
			default:
				return false;
			}
		}

		public virtual void SubscribeToButtonAliasEvent(ButtonAlias givenButton, bool startEvent, ControllerInteractionEventHandler callbackMethod)
		{
			ButtonAliasEventSubscription(subscribe: true, givenButton, startEvent, callbackMethod);
		}

		public virtual void UnsubscribeToButtonAliasEvent(ButtonAlias givenButton, bool startEvent, ControllerInteractionEventHandler callbackMethod)
		{
			ButtonAliasEventSubscription(subscribe: false, givenButton, startEvent, callbackMethod);
		}

		public virtual void SubscribeToAxisAliasEvent(SDK_BaseController.ButtonTypes buttonType, AxisType axisType, ControllerInteractionEventHandler callbackMethod)
		{
			AxisAliasEventSubscription(subscribe: true, buttonType, axisType, callbackMethod);
		}

		public virtual void UnsubscribeToAxisAliasEvent(SDK_BaseController.ButtonTypes buttonType, AxisType axisType, ControllerInteractionEventHandler callbackMethod)
		{
			AxisAliasEventSubscription(subscribe: false, buttonType, axisType, callbackMethod);
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			GameObject actualController = VRTK_DeviceFinder.GetActualController(base.gameObject);
			if (actualController != null)
			{
				trackedController = actualController.GetComponentInParent<VRTK_TrackedController>();
				if (trackedController != null)
				{
					trackedController.ControllerEnabled += TrackedControllerEnabled;
					trackedController.ControllerDisabled += TrackedControllerDisabled;
					trackedController.ControllerIndexChanged += TrackedControllerIndexChanged;
					trackedController.ControllerModelAvailable += TrackedControllerModelAvailable;
				}
			}
		}

		protected virtual void OnDisable()
		{
			Invoke("DisableEvents", 0f);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				CheckTriggerEvents(controllerReference);
				CheckGripEvents(controllerReference);
				CheckTouchpadEvents(controllerReference);
				CheckTouchpadTwoEvents(controllerReference);
				CheckButtonOneEvents(controllerReference);
				CheckButtonTwoEvents(controllerReference);
				CheckStartMenuEvents(controllerReference);
				CheckExtraFingerEvents(controllerReference);
			}
		}

		protected virtual float ProcessSenseAxis(float axisValue)
		{
			if (!(axisValue >= senseAxisForceZeroThreshold))
			{
				return 0f;
			}
			return axisValue;
		}

		protected virtual void CheckTriggerEvents(VRTK_ControllerReference controllerReference)
		{
			Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Trigger, controllerReference);
			float num = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Trigger, controllerReference));
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnTriggerTouchStart(SetControllerEvent(ref triggerTouched, value: true, controllerAxis.x));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TriggerHairline, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnTriggerHairlineStart(SetControllerEvent(ref triggerHairlinePressed, value: true, controllerAxis.x));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnTriggerPressed(SetControllerEvent(ref triggerPressed, value: true, controllerAxis.x));
			}
			if (!triggerClicked && controllerAxis.x >= triggerClickThreshold)
			{
				OnTriggerClicked(SetControllerEvent(ref triggerClicked, value: true, controllerAxis.x));
			}
			else if (triggerClicked && controllerAxis.x < triggerClickThreshold)
			{
				OnTriggerUnclicked(SetControllerEvent(ref triggerClicked));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnTriggerReleased(SetControllerEvent(ref triggerPressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TriggerHairline, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnTriggerHairlineEnd(SetControllerEvent(ref triggerHairlinePressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnTriggerTouchEnd(SetControllerEvent(ref triggerTouched));
			}
			controllerAxis.x = (((!triggerTouched && triggerAxisZeroOnUntouch) || controllerAxis.x < triggerForceZeroThreshold) ? 0f : controllerAxis.x);
			if (VRTK_SharedMethods.Vector2ShallowCompare(triggerAxis, controllerAxis, axisFidelity))
			{
				triggerAxisChanged = false;
			}
			else
			{
				OnTriggerAxisChanged(SetControllerEvent(ref triggerAxisChanged, value: true, controllerAxis.x));
			}
			if (VRTK_SharedMethods.RoundFloat(triggerSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num, axisFidelity))
			{
				triggerSenseAxisChanged = false;
			}
			else
			{
				OnTriggerSenseAxisChanged(SetControllerEvent(ref triggerSenseAxisChanged, value: true, num));
			}
			triggerAxis = (triggerAxisChanged ? new Vector2(controllerAxis.x, controllerAxis.y) : triggerAxis);
			triggerSenseAxis = (triggerSenseAxisChanged ? num : triggerSenseAxis);
			hairTriggerDelta = VRTK_SDK_Bridge.GetControllerHairlineDelta(SDK_BaseController.ButtonTypes.TriggerHairline, controllerReference);
		}

		protected virtual void CheckGripEvents(VRTK_ControllerReference controllerReference)
		{
			Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Grip, controllerReference);
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnGripTouchStart(SetControllerEvent(ref gripTouched, value: true, controllerAxis.x));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.GripHairline, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnGripHairlineStart(SetControllerEvent(ref gripHairlinePressed, value: true, controllerAxis.x));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnGripPressed(SetControllerEvent(ref gripPressed, value: true, controllerAxis.x));
			}
			if (!gripClicked && controllerAxis.x >= gripClickThreshold)
			{
				OnGripClicked(SetControllerEvent(ref gripClicked, value: true, controllerAxis.x));
			}
			else if (gripClicked && controllerAxis.x < gripClickThreshold)
			{
				OnGripUnclicked(SetControllerEvent(ref gripClicked));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnGripReleased(SetControllerEvent(ref gripPressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.GripHairline, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnGripHairlineEnd(SetControllerEvent(ref gripHairlinePressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnGripTouchEnd(SetControllerEvent(ref gripTouched));
			}
			controllerAxis.x = (((!gripTouched && gripAxisZeroOnUntouch) || controllerAxis.x < gripForceZeroThreshold) ? 0f : controllerAxis.x);
			if (VRTK_SharedMethods.Vector2ShallowCompare(gripAxis, controllerAxis, axisFidelity))
			{
				gripAxisChanged = false;
			}
			else
			{
				OnGripAxisChanged(SetControllerEvent(ref gripAxisChanged, value: true, controllerAxis.x));
			}
			gripAxis = (gripAxisChanged ? new Vector2(controllerAxis.x, controllerAxis.y) : gripAxis);
			hairGripDelta = VRTK_SDK_Bridge.GetControllerHairlineDelta(SDK_BaseController.ButtonTypes.GripHairline, controllerReference);
		}

		protected virtual void CheckTouchpadEvents(VRTK_ControllerReference controllerReference)
		{
			Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference);
			float num = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference));
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnTouchpadTouchStart(SetControllerEvent(ref touchpadTouched, value: true, 1f));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnTouchpadPressed(SetControllerEvent(ref touchpadPressed, value: true, 1f));
			}
			else if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnTouchpadReleased(SetControllerEvent(ref touchpadPressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnTouchpadTouchEnd(SetControllerEvent(ref touchpadTouched));
				touchpadAxis = Vector2.zero;
			}
			if (VRTK_SDK_Bridge.IsTouchpadStatic(touchpadTouched, touchpadAxis, controllerAxis, axisFidelity))
			{
				touchpadAxisChanged = false;
			}
			else
			{
				OnTouchpadAxisChanged(SetControllerEvent(ref touchpadAxisChanged, value: true, 1f));
			}
			if (VRTK_SharedMethods.RoundFloat(touchpadSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num, axisFidelity))
			{
				touchpadSenseAxisChanged = false;
			}
			else
			{
				OnTouchpadSenseAxisChanged(SetControllerEvent(ref touchpadSenseAxisChanged, value: true, num));
			}
			touchpadAxis = (touchpadAxisChanged ? new Vector2(controllerAxis.x, controllerAxis.y) : touchpadAxis);
			touchpadSenseAxis = (touchpadSenseAxisChanged ? num : touchpadSenseAxis);
			if (!touchpadTouched && touchpadAxis != Vector2.zero && touchpadAxis.sqrMagnitude < 0.0072250003f)
			{
				touchpadAxis = Vector2.zero;
			}
		}

		protected virtual void CheckTouchpadTwoEvents(VRTK_ControllerReference controllerReference)
		{
			Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.TouchpadTwo, controllerReference);
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TouchpadTwo, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnTouchpadTwoTouchStart(SetControllerEvent(ref touchpadTwoTouched, value: true, 1f));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TouchpadTwo, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnTouchpadTwoPressed(SetControllerEvent(ref touchpadTwoPressed, value: true, 1f));
			}
			else if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TouchpadTwo, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnTouchpadTwoReleased(SetControllerEvent(ref touchpadTwoPressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.TouchpadTwo, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnTouchpadTwoTouchEnd(SetControllerEvent(ref touchpadTwoTouched));
				touchpadTwoAxis = Vector2.zero;
			}
			if (VRTK_SDK_Bridge.IsTouchpadStatic(isTouched: true, touchpadTwoAxis, controllerAxis, axisFidelity))
			{
				touchpadTwoAxisChanged = false;
			}
			else
			{
				OnTouchpadTwoAxisChanged(SetControllerEvent(ref touchpadTwoAxisChanged, value: true, 1f));
			}
			touchpadTwoAxis = (touchpadTwoAxisChanged ? new Vector2(controllerAxis.x, controllerAxis.y) : touchpadTwoAxis);
			if (touchpadTwoAxis.magnitude < 0.0072250003f)
			{
				touchpadTwoAxis = Vector2.zero;
				return;
			}
			float x = Mathf.InverseLerp(0.0072250003f, 1f, Mathf.Abs(touchpadTwoAxis.x)) * Mathf.Sign(touchpadTwoAxis.x);
			float y = Mathf.InverseLerp(0.0072250003f, 1f, Mathf.Abs(touchpadTwoAxis.y)) * Mathf.Sign(touchpadTwoAxis.y);
			touchpadTwoAxis = new Vector2(x, y);
		}

		protected virtual void CheckButtonOneEvents(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnButtonOneTouchStart(SetControllerEvent(ref buttonOneTouched, value: true, 1f));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnButtonOnePressed(SetControllerEvent(ref buttonOnePressed, value: true, 1f));
			}
			else if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnButtonOneReleased(SetControllerEvent(ref buttonOnePressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnButtonOneTouchEnd(SetControllerEvent(ref buttonOneTouched));
			}
		}

		protected virtual void CheckButtonTwoEvents(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
			{
				OnButtonTwoTouchStart(SetControllerEvent(ref buttonTwoTouched, value: true, 1f));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnButtonTwoPressed(SetControllerEvent(ref buttonTwoPressed, value: true, 1f));
			}
			else if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnButtonTwoReleased(SetControllerEvent(ref buttonTwoPressed));
			}
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
			{
				OnButtonTwoTouchEnd(SetControllerEvent(ref buttonTwoTouched));
			}
		}

		protected virtual void CheckStartMenuEvents(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.StartMenu, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
			{
				OnStartMenuPressed(SetControllerEvent(ref startMenuPressed, value: true, 1f));
			}
			else if (VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.StartMenu, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
			{
				OnStartMenuReleased(SetControllerEvent(ref startMenuPressed));
			}
		}

		protected virtual void CheckExtraFingerEvents(VRTK_ControllerReference controllerReference)
		{
			float num = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.MiddleFinger, controllerReference));
			float num2 = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.RingFinger, controllerReference));
			float num3 = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.PinkyFinger, controllerReference));
			float num4 = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Grip, controllerReference));
			if (VRTK_SharedMethods.RoundFloat(middleFingerSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num, axisFidelity))
			{
				middleFingerSenseAxisChanged = false;
			}
			else
			{
				OnMiddleFingerSenseAxisChanged(SetControllerEvent(ref middleFingerSenseAxisChanged, value: true, num));
			}
			if (VRTK_SharedMethods.RoundFloat(ringFingerSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num2, axisFidelity))
			{
				ringFingerSenseAxisChanged = false;
			}
			else
			{
				OnRingFingerSenseAxisChanged(SetControllerEvent(ref ringFingerSenseAxisChanged, value: true, num2));
			}
			if (VRTK_SharedMethods.RoundFloat(pinkyFingerSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num3, axisFidelity))
			{
				pinkyFingerSenseAxisChanged = false;
			}
			else
			{
				OnPinkyFingerSenseAxisChanged(SetControllerEvent(ref pinkyFingerSenseAxisChanged, value: true, num3));
			}
			if (gripSenseAxisChanged && gripSensePressed && !IsButtonPressed(ButtonAlias.GripSense))
			{
				OnGripSenseReleased(SetControllerEvent(ref gripSensePressed));
			}
			else if (gripSenseAxisChanged && !gripSensePressed && IsButtonPressed(ButtonAlias.GripSense))
			{
				OnGripSensePressed(SetControllerEvent(ref gripSensePressed, value: true, 1f));
			}
			if (VRTK_SharedMethods.RoundFloat(gripSenseAxis, axisFidelity) == VRTK_SharedMethods.RoundFloat(num4, axisFidelity))
			{
				gripSenseAxisChanged = false;
			}
			else
			{
				OnGripSenseAxisChanged(SetControllerEvent(ref gripSenseAxisChanged, value: true, num4));
			}
			middleFingerSenseAxis = (middleFingerSenseAxisChanged ? num : middleFingerSenseAxis);
			ringFingerSenseAxis = (ringFingerSenseAxisChanged ? num2 : ringFingerSenseAxis);
			pinkyFingerSenseAxis = (pinkyFingerSenseAxisChanged ? num3 : pinkyFingerSenseAxis);
			gripSenseAxis = (gripSenseAxisChanged ? num4 : gripSenseAxis);
		}

		protected virtual void ButtonAliasEventSubscription(bool subscribe, ButtonAlias givenButton, bool startEvent, ControllerInteractionEventHandler callbackMethod)
		{
			switch (givenButton)
			{
			case ButtonAlias.TriggerClick:
				if (subscribe)
				{
					if (startEvent)
					{
						TriggerClicked += callbackMethod;
					}
					else
					{
						TriggerUnclicked += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TriggerClicked -= callbackMethod;
				}
				else
				{
					TriggerUnclicked -= callbackMethod;
				}
				break;
			case ButtonAlias.TriggerHairline:
				if (subscribe)
				{
					if (startEvent)
					{
						TriggerHairlineStart += callbackMethod;
					}
					else
					{
						TriggerHairlineEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TriggerHairlineStart -= callbackMethod;
				}
				else
				{
					TriggerHairlineEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.TriggerPress:
				if (subscribe)
				{
					if (startEvent)
					{
						TriggerPressed += callbackMethod;
					}
					else
					{
						TriggerReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TriggerPressed -= callbackMethod;
				}
				else
				{
					TriggerReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.TriggerTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						TriggerTouchStart += callbackMethod;
					}
					else
					{
						TriggerTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TriggerTouchStart -= callbackMethod;
				}
				else
				{
					TriggerTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.GripClick:
				if (subscribe)
				{
					if (startEvent)
					{
						GripClicked += callbackMethod;
					}
					else
					{
						GripUnclicked += callbackMethod;
					}
				}
				else if (startEvent)
				{
					GripClicked -= callbackMethod;
				}
				else
				{
					GripUnclicked -= callbackMethod;
				}
				break;
			case ButtonAlias.GripHairline:
				if (subscribe)
				{
					if (startEvent)
					{
						GripHairlineStart += callbackMethod;
					}
					else
					{
						GripHairlineEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					GripHairlineStart -= callbackMethod;
				}
				else
				{
					GripHairlineEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.GripPress:
				if (subscribe)
				{
					if (startEvent)
					{
						GripPressed += callbackMethod;
					}
					else
					{
						GripReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					GripPressed -= callbackMethod;
				}
				else
				{
					GripReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.GripTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						GripTouchStart += callbackMethod;
					}
					else
					{
						GripTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					GripTouchStart -= callbackMethod;
				}
				else
				{
					GripTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.TouchpadPress:
				if (subscribe)
				{
					if (startEvent)
					{
						TouchpadPressed += callbackMethod;
					}
					else
					{
						TouchpadReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TouchpadPressed -= callbackMethod;
				}
				else
				{
					TouchpadReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.TouchpadTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						TouchpadTouchStart += callbackMethod;
					}
					else
					{
						TouchpadTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TouchpadTouchStart -= callbackMethod;
				}
				else
				{
					TouchpadTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.TouchpadTwoPress:
				if (subscribe)
				{
					if (startEvent)
					{
						TouchpadTwoPressed += callbackMethod;
					}
					else
					{
						TouchpadTwoReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TouchpadTwoPressed -= callbackMethod;
				}
				else
				{
					TouchpadTwoReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.TouchpadTwoTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						TouchpadTwoTouchStart += callbackMethod;
					}
					else
					{
						TouchpadTwoTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					TouchpadTwoTouchStart -= callbackMethod;
				}
				else
				{
					TouchpadTwoTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.ButtonOnePress:
				if (subscribe)
				{
					if (startEvent)
					{
						ButtonOnePressed += callbackMethod;
					}
					else
					{
						ButtonOneReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					ButtonOnePressed -= callbackMethod;
				}
				else
				{
					ButtonOneReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.ButtonOneTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						ButtonOneTouchStart += callbackMethod;
					}
					else
					{
						ButtonOneTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					ButtonOneTouchStart -= callbackMethod;
				}
				else
				{
					ButtonOneTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.ButtonTwoPress:
				if (subscribe)
				{
					if (startEvent)
					{
						ButtonTwoPressed += callbackMethod;
					}
					else
					{
						ButtonTwoReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					ButtonTwoPressed -= callbackMethod;
				}
				else
				{
					ButtonTwoReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.ButtonTwoTouch:
				if (subscribe)
				{
					if (startEvent)
					{
						ButtonTwoTouchStart += callbackMethod;
					}
					else
					{
						ButtonTwoTouchEnd += callbackMethod;
					}
				}
				else if (startEvent)
				{
					ButtonTwoTouchStart -= callbackMethod;
				}
				else
				{
					ButtonTwoTouchEnd -= callbackMethod;
				}
				break;
			case ButtonAlias.StartMenuPress:
				if (subscribe)
				{
					if (startEvent)
					{
						StartMenuPressed += callbackMethod;
					}
					else
					{
						StartMenuReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					StartMenuPressed -= callbackMethod;
				}
				else
				{
					StartMenuReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.GripSensePress:
				if (subscribe)
				{
					if (startEvent)
					{
						GripSensePressed += callbackMethod;
					}
					else
					{
						GripSenseReleased += callbackMethod;
					}
				}
				else if (startEvent)
				{
					GripSensePressed -= callbackMethod;
				}
				else
				{
					GripSenseReleased -= callbackMethod;
				}
				break;
			case ButtonAlias.TouchpadSense:
			case ButtonAlias.TriggerSense:
			case ButtonAlias.MiddleFingerSense:
			case ButtonAlias.RingFingerSense:
			case ButtonAlias.PinkyFingerSense:
			case ButtonAlias.GripSense:
				break;
			}
		}

		protected virtual void AxisAliasEventSubscription(bool subscribe, SDK_BaseController.ButtonTypes buttonType, AxisType axisType, ControllerInteractionEventHandler callbackMethod)
		{
			switch (buttonType)
			{
			case SDK_BaseController.ButtonTypes.Trigger:
				switch (axisType)
				{
				case AxisType.Axis:
					if (subscribe)
					{
						TriggerAxisChanged += callbackMethod;
					}
					else
					{
						TriggerAxisChanged -= callbackMethod;
					}
					break;
				case AxisType.SenseAxis:
					if (subscribe)
					{
						TriggerSenseAxisChanged += callbackMethod;
					}
					else
					{
						TriggerSenseAxisChanged -= callbackMethod;
					}
					break;
				}
				break;
			case SDK_BaseController.ButtonTypes.Grip:
				switch (axisType)
				{
				case AxisType.Axis:
					if (subscribe)
					{
						GripAxisChanged += callbackMethod;
					}
					else
					{
						GripAxisChanged -= callbackMethod;
					}
					break;
				case AxisType.SenseAxis:
					if (subscribe)
					{
						GripSenseAxisChanged += callbackMethod;
					}
					else
					{
						GripSenseAxisChanged -= callbackMethod;
					}
					break;
				}
				break;
			case SDK_BaseController.ButtonTypes.Touchpad:
				switch (axisType)
				{
				case AxisType.Axis:
					if (subscribe)
					{
						TouchpadAxisChanged += callbackMethod;
					}
					else
					{
						TouchpadAxisChanged -= callbackMethod;
					}
					break;
				case AxisType.SenseAxis:
					if (subscribe)
					{
						TouchpadSenseAxisChanged += callbackMethod;
					}
					else
					{
						TouchpadSenseAxisChanged -= callbackMethod;
					}
					break;
				}
				break;
			case SDK_BaseController.ButtonTypes.TouchpadTwo:
				if (subscribe)
				{
					TouchpadTwoAxisChanged += callbackMethod;
				}
				else
				{
					TouchpadTwoAxisChanged -= callbackMethod;
				}
				break;
			case SDK_BaseController.ButtonTypes.MiddleFinger:
				if (axisType == AxisType.SenseAxis)
				{
					if (subscribe)
					{
						MiddleFingerSenseAxisChanged += callbackMethod;
					}
					else
					{
						MiddleFingerSenseAxisChanged -= callbackMethod;
					}
				}
				break;
			case SDK_BaseController.ButtonTypes.RingFinger:
				if (axisType == AxisType.SenseAxis)
				{
					if (subscribe)
					{
						RingFingerSenseAxisChanged += callbackMethod;
					}
					else
					{
						RingFingerSenseAxisChanged -= callbackMethod;
					}
				}
				break;
			case SDK_BaseController.ButtonTypes.PinkyFinger:
				if (axisType == AxisType.SenseAxis)
				{
					if (subscribe)
					{
						PinkyFingerSenseAxisChanged += callbackMethod;
					}
					else
					{
						PinkyFingerSenseAxisChanged -= callbackMethod;
					}
				}
				break;
			case SDK_BaseController.ButtonTypes.GripHairline:
			case SDK_BaseController.ButtonTypes.StartMenu:
			case SDK_BaseController.ButtonTypes.TriggerHairline:
				break;
			}
		}

		protected virtual void TrackedControllerEnabled(object sender, VRTKTrackedControllerEventArgs e)
		{
			OnControllerEnabled(SetControllerEvent());
		}

		protected virtual void TrackedControllerDisabled(object sender, VRTKTrackedControllerEventArgs e)
		{
			DisableEvents();
			OnControllerDisabled(SetControllerEvent());
		}

		protected virtual void TrackedControllerIndexChanged(object sender, VRTKTrackedControllerEventArgs e)
		{
			OnControllerIndexChanged(SetControllerEvent());
		}

		protected virtual void TrackedControllerModelAvailable(object sender, VRTKTrackedControllerEventArgs e)
		{
			OnControllerModelAvailable(SetControllerEvent());
		}

		protected virtual float CalculateVector2AxisAngle(Vector2 axis)
		{
			float num = Mathf.Atan2(axis.y, axis.x) * 57.29578f;
			num = 90f - num;
			if (num < 0f)
			{
				num += 360f;
			}
			return num;
		}

		protected virtual void DisableEvents()
		{
			if (VRTK_DeviceFinder.GetActualController(base.gameObject) != null && trackedController != null)
			{
				trackedController.ControllerEnabled -= TrackedControllerEnabled;
				trackedController.ControllerDisabled -= TrackedControllerDisabled;
				trackedController.ControllerIndexChanged -= TrackedControllerIndexChanged;
				trackedController.ControllerModelAvailable -= TrackedControllerModelAvailable;
			}
			if (triggerPressed)
			{
				OnTriggerReleased(SetControllerEvent(ref triggerPressed));
			}
			if (triggerTouched)
			{
				OnTriggerTouchEnd(SetControllerEvent(ref triggerTouched));
			}
			if (triggerHairlinePressed)
			{
				OnTriggerHairlineEnd(SetControllerEvent(ref triggerHairlinePressed));
			}
			if (triggerClicked)
			{
				OnTriggerUnclicked(SetControllerEvent(ref triggerClicked));
			}
			if (gripPressed)
			{
				OnGripReleased(SetControllerEvent(ref gripPressed));
			}
			if (gripTouched)
			{
				OnGripTouchEnd(SetControllerEvent(ref gripTouched));
			}
			if (gripHairlinePressed)
			{
				OnGripHairlineEnd(SetControllerEvent(ref gripHairlinePressed));
			}
			if (gripClicked)
			{
				OnGripUnclicked(SetControllerEvent(ref gripClicked));
			}
			if (touchpadPressed)
			{
				OnTouchpadReleased(SetControllerEvent(ref touchpadPressed));
			}
			if (touchpadTouched)
			{
				OnTouchpadTouchEnd(SetControllerEvent(ref touchpadTouched));
			}
			if (touchpadTwoPressed)
			{
				OnTouchpadTwoReleased(SetControllerEvent(ref touchpadTwoPressed));
			}
			if (touchpadTwoTouched)
			{
				OnTouchpadTwoTouchEnd(SetControllerEvent(ref touchpadTwoTouched));
			}
			if (buttonOnePressed)
			{
				OnButtonOneReleased(SetControllerEvent(ref buttonOnePressed));
			}
			if (buttonOneTouched)
			{
				OnButtonOneTouchEnd(SetControllerEvent(ref buttonOneTouched));
			}
			if (buttonTwoPressed)
			{
				OnButtonTwoReleased(SetControllerEvent(ref buttonTwoPressed));
			}
			if (buttonTwoTouched)
			{
				OnButtonTwoTouchEnd(SetControllerEvent(ref buttonTwoTouched));
			}
			if (startMenuPressed)
			{
				OnStartMenuReleased(SetControllerEvent(ref startMenuPressed));
			}
			if (gripSensePressed)
			{
				OnGripSenseReleased(SetControllerEvent(ref gripSensePressed));
			}
			triggerAxisChanged = false;
			gripAxisChanged = false;
			touchpadAxisChanged = false;
			touchpadTwoAxisChanged = false;
			triggerSenseAxisChanged = false;
			touchpadSenseAxisChanged = false;
			middleFingerSenseAxisChanged = false;
			ringFingerSenseAxisChanged = false;
			pinkyFingerSenseAxisChanged = false;
			gripSenseAxisChanged = false;
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				Vector2 controllerAxis = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Trigger, controllerReference);
				Vector2 controllerAxis2 = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Grip, controllerReference);
				Vector2 controllerAxis3 = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference);
				Vector2 controllerAxis4 = VRTK_SDK_Bridge.GetControllerAxis(SDK_BaseController.ButtonTypes.TouchpadTwo, controllerReference);
				touchpadAxis = new Vector2(controllerAxis3.x, controllerAxis3.y);
				touchpadTwoAxis = new Vector2(controllerAxis4.x, controllerAxis4.y);
				triggerAxis = new Vector2(controllerAxis.x, controllerAxis.y);
				gripAxis = new Vector2(controllerAxis2.x, controllerAxis2.y);
				hairTriggerDelta = VRTK_SDK_Bridge.GetControllerHairlineDelta(SDK_BaseController.ButtonTypes.TriggerHairline, controllerReference);
				hairGripDelta = VRTK_SDK_Bridge.GetControllerHairlineDelta(SDK_BaseController.ButtonTypes.GripHairline, controllerReference);
				triggerSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Trigger, controllerReference));
				touchpadSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Touchpad, controllerReference));
				middleFingerSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.MiddleFinger, controllerReference));
				ringFingerSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.RingFinger, controllerReference));
				pinkyFingerSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.PinkyFinger, controllerReference));
				gripSenseAxis = ProcessSenseAxis(VRTK_SDK_Bridge.GetControllerSenseAxis(SDK_BaseController.ButtonTypes.Grip, controllerReference));
			}
		}
	}
}
