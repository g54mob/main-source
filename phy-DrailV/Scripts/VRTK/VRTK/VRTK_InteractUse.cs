using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_InteractUse")]
	public class VRTK_InteractUse : MonoBehaviour
	{
		[Header("Use Settings")]
		[Tooltip("The button used to use/unuse a touched Interactable Object.")]
		public VRTK_ControllerEvents.ButtonAlias useButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;

		[Header("Custom Settings")]
		[Tooltip("The Controller Events to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_ControllerEvents controllerEvents;

		[Tooltip("The Interact Touch to listen for touches on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractTouch interactTouch;

		[Tooltip("The Interact Grab to listen for grab actions on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractGrab interactGrab;

		protected VRTK_ControllerEvents.ButtonAlias subscribedUseButton;

		protected VRTK_ControllerEvents.ButtonAlias savedUseButton;

		protected bool usePressed;

		protected GameObject usingObject;

		protected VRTK_ControllerReference controllerReference => VRTK_ControllerReference.GetControllerReference((interactTouch != null) ? interactTouch.gameObject : null);

		public event ControllerInteractionEventHandler UseButtonPressed;

		public event ControllerInteractionEventHandler UseButtonReleased;

		public event ObjectInteractEventHandler ControllerStartUseInteractableObject;

		public event ObjectInteractEventHandler ControllerUseInteractableObject;

		public event ObjectInteractEventHandler ControllerStartUnuseInteractableObject;

		public event ObjectInteractEventHandler ControllerUnuseInteractableObject;

		public virtual void OnControllerStartUseInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartUseInteractableObject != null)
			{
				this.ControllerStartUseInteractableObject(this, e);
			}
		}

		public virtual void OnControllerUseInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerUseInteractableObject != null)
			{
				this.ControllerUseInteractableObject(this, e);
			}
		}

		public virtual void OnControllerStartUnuseInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartUnuseInteractableObject != null)
			{
				this.ControllerStartUnuseInteractableObject(this, e);
			}
		}

		public virtual void OnControllerUnuseInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerUnuseInteractableObject != null)
			{
				this.ControllerUnuseInteractableObject(this, e);
			}
		}

		public virtual void OnUseButtonPressed(ControllerInteractionEventArgs e)
		{
			if (this.UseButtonPressed != null)
			{
				this.UseButtonPressed(this, e);
			}
		}

		public virtual void OnUseButtonReleased(ControllerInteractionEventArgs e)
		{
			if (this.UseButtonReleased != null)
			{
				this.UseButtonReleased(this, e);
			}
		}

		public virtual bool IsUseButtonPressed()
		{
			return usePressed;
		}

		public virtual GameObject GetUsingObject()
		{
			return usingObject;
		}

		public virtual void ForceStopUsing()
		{
			if (usingObject != null)
			{
				StopUsing();
			}
		}

		public virtual void ForceResetUsing()
		{
			if (usingObject != null)
			{
				UnuseInteractedObject(completeStop: false);
			}
		}

		public virtual void AttemptUse()
		{
			AttemptUseObject();
		}

		protected virtual void OnEnable()
		{
			controllerEvents = ((controllerEvents != null) ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
			interactTouch = ((interactTouch != null) ? interactTouch : GetComponentInParent<VRTK_InteractTouch>());
			interactGrab = ((interactGrab != null) ? interactGrab : GetComponentInParent<VRTK_InteractGrab>());
			if (interactTouch == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_InteractUse", "VRTK_InteractTouch", "interactTouch", "the same or parent"));
			}
			ManageUseListener(state: true);
			ManageInteractTouchListener(state: true);
		}

		protected virtual void OnDisable()
		{
			ForceResetUsing();
			ManageUseListener(state: false);
			ManageInteractTouchListener(state: false);
		}

		protected virtual void Update()
		{
			ManageUseListener(state: true);
		}

		protected virtual void ManageInteractTouchListener(bool state)
		{
			if (interactTouch != null && !state)
			{
				interactTouch.ControllerTouchInteractableObject -= ControllerTouchInteractableObject;
				interactTouch.ControllerUntouchInteractableObject -= ControllerUntouchInteractableObject;
			}
			if (interactTouch != null && state)
			{
				interactTouch.ControllerTouchInteractableObject += ControllerTouchInteractableObject;
				interactTouch.ControllerUntouchInteractableObject += ControllerUntouchInteractableObject;
			}
		}

		protected virtual void ControllerTouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			if (e.target != null)
			{
				VRTK_InteractableObject component = e.target.GetComponent<VRTK_InteractableObject>();
				if (component != null && component.useOverrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					savedUseButton = subscribedUseButton;
					useButton = component.useOverrideButton;
					ManageUseListener(state: true);
				}
			}
		}

		protected virtual void ControllerUntouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			if (e.target != null)
			{
				VRTK_InteractableObject component = e.target.GetComponent<VRTK_InteractableObject>();
				if (component != null && !component.IsUsing() && savedUseButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					useButton = savedUseButton;
					savedUseButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
					ManageUseListener(state: true);
				}
			}
		}

		protected virtual void ManageUseListener(bool state)
		{
			if (controllerEvents != null && subscribedUseButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || useButton != subscribedUseButton))
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedUseButton, startEvent: true, DoStartUseObject);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedUseButton, startEvent: false, DoStopUseObject);
				subscribedUseButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			if (controllerEvents != null && state && useButton != VRTK_ControllerEvents.ButtonAlias.Undefined && useButton != subscribedUseButton)
			{
				controllerEvents.SubscribeToButtonAliasEvent(useButton, startEvent: true, DoStartUseObject);
				controllerEvents.SubscribeToButtonAliasEvent(useButton, startEvent: false, DoStopUseObject);
				subscribedUseButton = useButton;
			}
		}

		protected virtual bool IsObjectUsable(GameObject obj)
		{
			VRTK_InteractableObject vRTK_InteractableObject = ((obj != null) ? obj.GetComponent<VRTK_InteractableObject>() : null);
			if (obj != null && interactTouch != null && interactTouch.IsObjectInteractable(obj) && vRTK_InteractableObject != null)
			{
				return vRTK_InteractableObject.isUsable;
			}
			return false;
		}

		protected virtual bool IsObjectHoldOnUse(GameObject obj)
		{
			if (obj != null)
			{
				VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					return component.holdButtonToUse;
				}
				return false;
			}
			return false;
		}

		protected virtual int GetObjectUsingState(GameObject obj)
		{
			if (obj != null)
			{
				VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					return component.usingState;
				}
			}
			return 0;
		}

		protected virtual void SetObjectUsingState(GameObject obj, int value)
		{
			if (obj != null)
			{
				VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					component.usingState = value;
				}
			}
		}

		protected virtual void ToggleControllerVisibility(bool visible)
		{
			if (usingObject != null)
			{
				VRTK_InteractControllerAppearance[] componentsInParent = usingObject.GetComponentsInParent<VRTK_InteractControllerAppearance>(includeInactive: true);
				if (componentsInParent.Length != 0)
				{
					componentsInParent[0].ToggleControllerOnUse(visible, controllerReference.model, usingObject);
				}
			}
		}

		protected virtual void UseInteractedObject(GameObject touchedObject)
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
			}
		}

		protected virtual void UnuseInteractedObject(bool completeStop)
		{
			if (usingObject != null && interactTouch != null)
			{
				OnControllerStartUnuseInteractableObject(interactTouch.SetControllerInteractEvent(usingObject));
				VRTK_InteractableObject component = usingObject.GetComponent<VRTK_InteractableObject>();
				if (component != null && completeStop)
				{
					component.StopUsing(this, resetUsingObjectState: false);
				}
				ToggleControllerVisibility(visible: true);
				OnControllerUnuseInteractableObject(interactTouch.SetControllerInteractEvent(usingObject));
				usingObject = null;
			}
		}

		protected virtual GameObject GetFromGrab()
		{
			if (interactGrab != null)
			{
				return interactGrab.GetGrabbedObject();
			}
			return null;
		}

		protected virtual void StopUsing()
		{
			SetObjectUsingState(usingObject, 0);
			UnuseInteractedObject(completeStop: true);
		}

		protected virtual void AttemptUseObject()
		{
			GameObject gameObject = ((interactTouch != null) ? interactTouch.GetTouchedObject() : null);
			if (gameObject == null)
			{
				gameObject = GetFromGrab();
			}
			if (!(gameObject != null) || !(interactTouch != null) || !interactTouch.IsObjectInteractable(gameObject))
			{
				return;
			}
			VRTK_InteractableObject component = gameObject.GetComponent<VRTK_InteractableObject>();
			if (!(component != null) || !component.useOnlyIfGrabbed || component.IsGrabbed())
			{
				UseInteractedObject(gameObject);
				if (usingObject != null && !IsObjectHoldOnUse(usingObject))
				{
					SetObjectUsingState(usingObject, GetObjectUsingState(usingObject) + 1);
				}
			}
		}

		protected virtual void DoStartUseObject(object sender, ControllerInteractionEventArgs e)
		{
			OnUseButtonPressed(controllerEvents.SetControllerEvent(ref usePressed, value: true));
			AttemptUseObject();
		}

		protected virtual void DoStopUseObject(object sender, ControllerInteractionEventArgs e)
		{
			if (IsObjectHoldOnUse(usingObject) || GetObjectUsingState(usingObject) >= 2)
			{
				StopUsing();
			}
			OnUseButtonReleased(controllerEvents.SetControllerEvent(ref usePressed));
		}
	}
}
