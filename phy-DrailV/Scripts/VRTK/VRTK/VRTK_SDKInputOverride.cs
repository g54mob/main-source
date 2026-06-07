using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRTK
{
	public class VRTK_SDKInputOverride : VRTK_SDKControllerReady
	{
		[Header("Interact Grab")]
		[Tooltip("The Interact Grab script to override the controls on.")]
		public VRTK_InteractGrab interactGrabScript;

		[Tooltip("The list of overrides.")]
		public List<VRTK_SDKButtonInputOverrideType> interactGrabOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Interact Use")]
		[Tooltip("The Interact Use script to override the controls on.")]
		public VRTK_InteractUse interactUseScript;

		[Tooltip("The list of overrides.")]
		public List<VRTK_SDKButtonInputOverrideType> interactUseOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Pointer")]
		[Tooltip("The Pointer script to override the controls on.")]
		public VRTK_Pointer pointerScript;

		[Tooltip("The list of overrides for the activation button.")]
		public List<VRTK_SDKButtonInputOverrideType> pointerActivationOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the selection button.")]
		public List<VRTK_SDKButtonInputOverrideType> pointerSelectionOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("UI Pointer")]
		[Tooltip("The UI Pointer script to override the controls on.")]
		public VRTK_UIPointer uiPointerScript;

		[Tooltip("The list of overrides for the activation button.")]
		public List<VRTK_SDKButtonInputOverrideType> uiPointerActivationOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the selection button.")]
		public List<VRTK_SDKButtonInputOverrideType> uiPointerSelectionOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Pointer Direction Indicator")]
		[Tooltip("The Pointer Direction Indicator script to override the controls on.")]
		public VRTK_PointerDirectionIndicator pointerDirectionIndicatorScript;

		[Tooltip("The list of overrides for the coordinate axis.")]
		public List<VRTK_SDKVector2AxisInputOverrideType> directionIndicatorCoordinateOverrides = new List<VRTK_SDKVector2AxisInputOverrideType>();

		[Header("Touchpad Control")]
		[Tooltip("The Touchpad Control script to override the controls on.")]
		public VRTK_TouchpadControl touchpadControlScript;

		[Tooltip("The list of overrides for the Touchpad Control coordinate axis.")]
		public List<VRTK_SDKVector2AxisInputOverrideType> touchpadControlCoordinateOverrides = new List<VRTK_SDKVector2AxisInputOverrideType>();

		[Tooltip("The list of overrides for the activation button.")]
		public List<VRTK_SDKButtonInputOverrideType> touchpadControlActivationOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the modifier button.")]
		public List<VRTK_SDKButtonInputOverrideType> touchpadControlModifierOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Button Control")]
		[Tooltip("The ButtonControl script to override the controls on.")]
		public VRTK_ButtonControl buttonControlScript;

		[Tooltip("The list of overrides for the forward button.")]
		public List<VRTK_SDKButtonInputOverrideType> buttonControlForwardOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the backward button.")]
		public List<VRTK_SDKButtonInputOverrideType> buttonControlBackwardOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the left button.")]
		public List<VRTK_SDKButtonInputOverrideType> buttonControlLeftOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the right button.")]
		public List<VRTK_SDKButtonInputOverrideType> buttonControlRightOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Slingshot Jump")]
		[Tooltip("The SlingshotJump script to override the controls on.")]
		public VRTK_SlingshotJump slingshotJumpScript;

		[Tooltip("The list of overrides for the activation button.")]
		public List<VRTK_SDKButtonInputOverrideType> slingshotJumpActivationOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Tooltip("The list of overrides for the cancel button.")]
		public List<VRTK_SDKButtonInputOverrideType> slingshotJumpCancelOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Move In Place")]
		[Tooltip("The MoveInPlace script to override the controls on.")]
		public VRTK_MoveInPlace moveInPlaceScript;

		[Tooltip("The list of overrides for the engage button.")]
		public List<VRTK_SDKButtonInputOverrideType> moveInPlaceEngageOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		[Header("Step Multiplier")]
		[Tooltip("The Step Multiplier script to override the controls on.")]
		public VRTK_StepMultiplier stepMultiplierScript;

		[Tooltip("The list of overrides for the activation button.")]
		public List<VRTK_SDKButtonInputOverrideType> stepMultiplierActivationOverrides = new List<VRTK_SDKButtonInputOverrideType>();

		public virtual void ForceManage()
		{
			ManageInputs();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			ManageInputs();
		}

		protected override void OnDisable()
		{
			if (!base.gameObject.activeSelf)
			{
				base.OnDisable();
			}
		}

		protected override void ControllerReady(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_SDKManager.GetLoadedSDKSetup() != null && base.gameObject.activeInHierarchy)
			{
				ManageInputs();
			}
		}

		protected virtual VRTK_SDKButtonInputOverrideType GetSelectedModifier(List<VRTK_SDKButtonInputOverrideType> overrideTypes, VRTK_ControllerReference controllerReference)
		{
			VRTK_SDKButtonInputOverrideType vRTK_SDKButtonInputOverrideType = null;
			if (VRTK_SDKManager.GetLoadedSDKSetup() != null)
			{
				vRTK_SDKButtonInputOverrideType = overrideTypes.FirstOrDefault((VRTK_SDKButtonInputOverrideType item) => item.loadedSDKSetup == VRTK_SDKManager.GetLoadedSDKSetup());
			}
			if (vRTK_SDKButtonInputOverrideType == null)
			{
				SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
				vRTK_SDKButtonInputOverrideType = overrideTypes.FirstOrDefault((VRTK_SDKButtonInputOverrideType item) => item.controllerType == currentControllerType);
			}
			return vRTK_SDKButtonInputOverrideType;
		}

		protected virtual VRTK_SDKVector2AxisInputOverrideType GetSelectedModifier(List<VRTK_SDKVector2AxisInputOverrideType> overrideTypes, VRTK_ControllerReference controllerReference)
		{
			VRTK_SDKVector2AxisInputOverrideType vRTK_SDKVector2AxisInputOverrideType = overrideTypes.FirstOrDefault((VRTK_SDKVector2AxisInputOverrideType item) => item.loadedSDKSetup == VRTK_SDKManager.GetLoadedSDKSetup());
			if (vRTK_SDKVector2AxisInputOverrideType == null)
			{
				SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
				vRTK_SDKVector2AxisInputOverrideType = overrideTypes.FirstOrDefault((VRTK_SDKVector2AxisInputOverrideType item) => item.controllerType == currentControllerType);
			}
			return vRTK_SDKVector2AxisInputOverrideType;
		}

		protected virtual void ManageInputs()
		{
			ManageInteractGrab();
			ManageInteractUse();
			ManagePointer();
			ManageUIPointer();
			ManagePointerDirectionIndicator();
			ManageTouchpadControl();
			ManageButtonControl();
			ManageSlingshotJump();
			ManageMoveInPlace();
			ManageStepMultiplier();
		}

		protected virtual VRTK_ControllerReference GetReferenceFromEvents(VRTK_ControllerEvents controllerEvents)
		{
			return VRTK_ControllerReference.GetControllerReference((controllerEvents != null) ? controllerEvents.gameObject : null);
		}

		protected virtual VRTK_ControllerReference GetRightThenLeftReference()
		{
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right);
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left);
			}
			return controllerReference;
		}

		protected virtual void ManageInteractGrab()
		{
			if (interactGrabScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(interactGrabScript.controllerEvents);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(interactGrabOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					interactGrabScript.enabled = false;
					interactGrabScript.grabButton = selectedModifier.overrideButton;
					interactGrabScript.enabled = true;
				}
			}
		}

		protected virtual void ManageInteractUse()
		{
			if (interactUseScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(interactUseScript.controllerEvents);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(interactUseOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					interactUseScript.enabled = false;
					interactUseScript.useButton = selectedModifier.overrideButton;
					interactUseScript.enabled = true;
				}
			}
		}

		protected virtual void ManagePointer()
		{
			if (pointerScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(pointerScript.controllerEvents);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(pointerActivationOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					pointerScript.enabled = false;
					pointerScript.activationButton = selectedModifier.overrideButton;
					pointerScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier2 = GetSelectedModifier(pointerSelectionOverrides, referenceFromEvents);
				if (selectedModifier2 != null && selectedModifier2.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					pointerScript.enabled = false;
					pointerScript.selectionButton = selectedModifier2.overrideButton;
					pointerScript.enabled = true;
				}
			}
		}

		protected virtual void ManageUIPointer()
		{
			if (uiPointerScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(uiPointerScript.controllerEvents);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(uiPointerActivationOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					uiPointerScript.enabled = false;
					uiPointerScript.activationButton = selectedModifier.overrideButton;
					uiPointerScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier2 = GetSelectedModifier(uiPointerSelectionOverrides, referenceFromEvents);
				if (selectedModifier2 != null && selectedModifier2.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					uiPointerScript.enabled = false;
					uiPointerScript.selectionButton = selectedModifier2.overrideButton;
					uiPointerScript.enabled = true;
				}
			}
		}

		protected virtual void ManagePointerDirectionIndicator()
		{
			if (pointerDirectionIndicatorScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(pointerDirectionIndicatorScript.GetControllerEvents());
				VRTK_SDKVector2AxisInputOverrideType selectedModifier = GetSelectedModifier(directionIndicatorCoordinateOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideAxis != VRTK_ControllerEvents.Vector2AxisAlias.Undefined)
				{
					pointerDirectionIndicatorScript.enabled = false;
					pointerDirectionIndicatorScript.coordinateAxis = selectedModifier.overrideAxis;
					pointerDirectionIndicatorScript.enabled = true;
				}
			}
		}

		protected virtual void ManageTouchpadControl()
		{
			if (touchpadControlScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(touchpadControlScript.controller);
				VRTK_SDKVector2AxisInputOverrideType selectedModifier = GetSelectedModifier(touchpadControlCoordinateOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideAxis != VRTK_ControllerEvents.Vector2AxisAlias.Undefined)
				{
					touchpadControlScript.enabled = false;
					touchpadControlScript.coordinateAxis = selectedModifier.overrideAxis;
					touchpadControlScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier2 = GetSelectedModifier(touchpadControlActivationOverrides, referenceFromEvents);
				if (selectedModifier2 != null && selectedModifier2.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					touchpadControlScript.enabled = false;
					touchpadControlScript.primaryActivationButton = selectedModifier2.overrideButton;
					touchpadControlScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier3 = GetSelectedModifier(touchpadControlModifierOverrides, referenceFromEvents);
				if (selectedModifier3 != null && selectedModifier3.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					touchpadControlScript.enabled = false;
					touchpadControlScript.actionModifierButton = selectedModifier3.overrideButton;
					touchpadControlScript.enabled = true;
				}
			}
		}

		protected virtual void ManageButtonControl()
		{
			if (buttonControlScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(buttonControlScript.controller);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(buttonControlForwardOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					buttonControlScript.enabled = false;
					buttonControlScript.forwardButton = selectedModifier.overrideButton;
					buttonControlScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier2 = GetSelectedModifier(buttonControlBackwardOverrides, referenceFromEvents);
				if (selectedModifier2 != null && selectedModifier2.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					buttonControlScript.enabled = false;
					buttonControlScript.backwardButton = selectedModifier2.overrideButton;
					buttonControlScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier3 = GetSelectedModifier(buttonControlLeftOverrides, referenceFromEvents);
				if (selectedModifier3 != null && selectedModifier3.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					buttonControlScript.enabled = false;
					buttonControlScript.leftButton = selectedModifier3.overrideButton;
					buttonControlScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier4 = GetSelectedModifier(buttonControlRightOverrides, referenceFromEvents);
				if (selectedModifier4 != null && selectedModifier4.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					buttonControlScript.enabled = false;
					buttonControlScript.rightButton = selectedModifier4.overrideButton;
					buttonControlScript.enabled = true;
				}
			}
		}

		protected virtual void ManageSlingshotJump()
		{
			if (slingshotJumpScript != null)
			{
				VRTK_ControllerReference rightThenLeftReference = GetRightThenLeftReference();
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(slingshotJumpActivationOverrides, rightThenLeftReference);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					slingshotJumpScript.enabled = false;
					slingshotJumpScript.SetActivationButton(selectedModifier.overrideButton);
					slingshotJumpScript.enabled = true;
				}
				VRTK_SDKButtonInputOverrideType selectedModifier2 = GetSelectedModifier(slingshotJumpCancelOverrides, rightThenLeftReference);
				if (selectedModifier2 != null && selectedModifier2.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					slingshotJumpScript.enabled = false;
					slingshotJumpScript.SetCancelButton(selectedModifier2.overrideButton);
					slingshotJumpScript.enabled = true;
				}
			}
		}

		protected virtual void ManageMoveInPlace()
		{
			if (moveInPlaceScript != null)
			{
				VRTK_ControllerReference rightThenLeftReference = GetRightThenLeftReference();
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(moveInPlaceEngageOverrides, rightThenLeftReference);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					moveInPlaceScript.enabled = false;
					moveInPlaceScript.engageButton = selectedModifier.overrideButton;
					moveInPlaceScript.enabled = true;
				}
			}
		}

		protected virtual void ManageStepMultiplier()
		{
			if (stepMultiplierScript != null)
			{
				VRTK_ControllerReference referenceFromEvents = GetReferenceFromEvents(stepMultiplierScript.controllerEvents);
				VRTK_SDKButtonInputOverrideType selectedModifier = GetSelectedModifier(stepMultiplierActivationOverrides, referenceFromEvents);
				if (selectedModifier != null && selectedModifier.overrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					stepMultiplierScript.enabled = false;
					stepMultiplierScript.activationButton = selectedModifier.overrideButton;
					stepMultiplierScript.enabled = true;
				}
			}
		}
	}
}
