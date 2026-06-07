using System;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_InteractUse_DV : VRTK_InteractUse
	{
		private bool _useModified;

		public TouchpadInputInterpreter touchpadInputInterpreter;

		private VRTK_InteractableObject_DV cachedGrabbedInteractable;

		private GameObject onUsePressedGrabbedObject;

		private VRTK_InteractTouch_DV interactTouchDV;

		private ControllerType_DV controllerType;

		private bool ignoreWandUseButtonInput;

		private bool isWand;

		public bool UseModified
		{
			get
			{
				return _useModified;
			}
			private set
			{
				if (value != _useModified)
				{
					_useModified = value;
					if (value)
					{
						this.UseModifierEnabled?.Invoke();
						return;
					}
					this.UseModifierDisabled?.Invoke();
					touchpadInputInterpreter.DirectionalInputGiven -= OnAuxiliaryStartUse;
					touchpadInputInterpreter.DirectionalInputNeutral -= OnAuxiliaryEndUse;
				}
			}
		}

		public bool UsePressed => usePressed;

		public event Action UseModifierEnabled;

		public event Action UseModifierDisabled;

		public event Action InteractableObjectUsed;

		private void Awake()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			touchpadInputInterpreter = GetComponent<TouchpadInputInterpreter>();
		}

		private void OnDestroy()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			VRTK_ControllerReference vRTK_ControllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
			if (vRTK_ControllerReference.hand == hand)
			{
				controllerType = vRTK_ControllerReference.GetControllerTypeDV();
				isWand = controllerType == ControllerType_DV.ViveWand || controllerType == ControllerType_DV.Undefined;
				useButton = (isWand ? VRTK_ControllerEvents.ButtonAlias.TriggerClick : VRTK_ControllerEvents.ButtonAlias.TriggerPress);
				interactTouchDV = GetComponent<VRTK_InteractTouch_DV>();
				interactGrab.ControllerGrabInteractableObject += OnGrabbed;
				interactGrab.ControllerUngrabInteractableObject += OnUngrabbed;
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		private void OnUngrabbed(object sender, ObjectInteractEventArgs e)
		{
			UseModified = false;
			ignoreWandUseButtonInput = false;
			if (cachedGrabbedInteractable.continuousUse && cachedGrabbedInteractable.IsUsing())
			{
				StopUsing();
			}
			cachedGrabbedInteractable = null;
			onUsePressedGrabbedObject = null;
		}

		private void OnGrabbed(object sender, ObjectInteractEventArgs e)
		{
			cachedGrabbedInteractable = ((e.target != null) ? e.target.GetComponent<VRTK_InteractableObject_DV>() : null);
			ignoreWandUseButtonInput = isWand && interactGrab.IsGrabButtonPressed();
		}

		protected override void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				base.OnDisable();
				UseModified = false;
			}
		}

		protected override void DoStartUseObject(object _, ControllerInteractionEventArgs __)
		{
			AttemptUseObject();
		}

		protected override void UseInteractedObject(GameObject touchedObject)
		{
			if ((!(usingObject == null) && !(usingObject != touchedObject)) || !IsObjectUsable(touchedObject) || !(interactTouch != null))
			{
				return;
			}
			usingObject = touchedObject;
			OnControllerStartUseInteractableObject(interactTouch.SetControllerInteractEvent(usingObject));
			VRTK_InteractableObject vRTK_InteractableObject = ((usingObject != null) ? usingObject.GetComponent<VRTK_InteractableObject>() : null);
			if (vRTK_InteractableObject != null)
			{
				if (!vRTK_InteractableObject.IsValidInteractableController(base.gameObject, vRTK_InteractableObject.allowedUseControllers))
				{
					usingObject = null;
					return;
				}
				vRTK_InteractableObject.StartUsing(this);
				ToggleControllerVisibility(visible: false);
				OnControllerUseInteractableObject(interactTouch.SetControllerInteractEvent(usingObject));
				this.InteractableObjectUsed?.Invoke();
			}
		}

		protected override void DoStopUseObject(object _, ControllerInteractionEventArgs __)
		{
			if (IsObjectHoldOnUse(usingObject) || GetObjectUsingState(usingObject) >= 2)
			{
				StopUsing();
			}
		}

		protected override void ManageUseListener(bool state)
		{
			if (controllerEvents != null && subscribedUseButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || useButton != subscribedUseButton))
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedUseButton, startEvent: true, OnUseButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedUseButton, startEvent: false, OnUseButtonReleased);
				subscribedUseButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			if (controllerEvents != null && state && useButton != VRTK_ControllerEvents.ButtonAlias.Undefined && useButton != subscribedUseButton)
			{
				controllerEvents.SubscribeToButtonAliasEvent(useButton, startEvent: true, OnUseButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(useButton, startEvent: false, OnUseButtonReleased);
				subscribedUseButton = useButton;
			}
		}

		private void OnUseButtonPressed(object _, ControllerInteractionEventArgs __)
		{
			if (!ignoreWandUseButtonInput)
			{
				OnUseButtonPressed(controllerEvents.SetControllerEvent(ref usePressed, value: true));
				touchpadInputInterpreter.DirectionalInputGiven -= OnAuxiliaryStartUse;
				GameObject fromGrab = GetFromGrab();
				if (fromGrab == null || cachedGrabbedInteractable.continuousUse)
				{
					AttemptUseObject();
					return;
				}
				touchpadInputInterpreter.DirectionalInputGiven += OnAuxiliaryStartUse;
				onUsePressedGrabbedObject = fromGrab;
			}
		}

		private void DisableMainUse()
		{
			if (ValidGrabObjectForUse() || ValidGrabObjectForScrolling())
			{
				UseModified = true;
			}
		}

		public bool ValidGrabObjectForUse()
		{
			if (cachedGrabbedInteractable != null && interactTouchDV != null && interactTouchDV.IsObjectInteractable(cachedGrabbedInteractable) && cachedGrabbedInteractable.useOnlyIfGrabbed && cachedGrabbedInteractable.isUsable)
			{
				return true;
			}
			return false;
		}

		public bool ValidGrabObjectForScrolling()
		{
			if (cachedGrabbedInteractable != null)
			{
				return cachedGrabbedInteractable.isScrollable;
			}
			return false;
		}

		private void OnAuxiliaryStartUse(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference _)
		{
			DisableMainUse();
			if (direction == TouchpadInputDirection.Up)
			{
				AttemptUse();
				touchpadInputInterpreter.DirectionalInputNeutral += OnAuxiliaryEndUse;
			}
		}

		private void OnAuxiliaryEndUse(TouchpadInputDirection _, bool swiped, VRTK_ControllerReference __)
		{
			touchpadInputInterpreter.DirectionalInputNeutral -= OnAuxiliaryEndUse;
			StopUsing();
		}

		private void OnUseButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			if (ignoreWandUseButtonInput)
			{
				ignoreWandUseButtonInput = false;
				return;
			}
			OnUseButtonReleased(controllerEvents.SetControllerEvent(ref usePressed));
			GameObject fromGrab = GetFromGrab();
			touchpadInputInterpreter.DirectionalInputGiven -= OnAuxiliaryStartUse;
			if (UseModified)
			{
				UseModified = false;
			}
			else if (fromGrab != null && fromGrab == onUsePressedGrabbedObject && !cachedGrabbedInteractable.continuousUse)
			{
				DoStartUseObject(sender, e);
			}
			DoStopUseObject(sender, e);
			onUsePressedGrabbedObject = null;
		}

		protected override void ControllerUntouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			OnUseButtonReleased(sender, controllerEvents.SetControllerEvent(ref usePressed));
			if (savedUseButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				useButton = savedUseButton;
				savedUseButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				ManageUseListener(state: true);
			}
		}

		public GameObject GetObjectFromGrab()
		{
			return GetFromGrab();
		}
	}
}
