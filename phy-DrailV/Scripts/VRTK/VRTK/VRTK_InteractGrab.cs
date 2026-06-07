using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_InteractGrab")]
	public class VRTK_InteractGrab : MonoBehaviour
	{
		[Header("Grab Settings")]
		[Tooltip("The button used to grab/release a touched Interactable Object.")]
		public VRTK_ControllerEvents.ButtonAlias grabButton = VRTK_ControllerEvents.ButtonAlias.GripPress;

		[Tooltip("An amount of time between when the grab button is pressed to when the controller is touching an Interactable Object to grab it.")]
		public float grabPrecognition;

		[Tooltip("An amount to multiply the velocity of any Interactable Object being thrown.")]
		public float throwMultiplier = 1f;

		[Tooltip("If this is checked and the Interact Touch is not touching an Interactable Object when the grab button is pressed then a Rigidbody is added to the interacting object to allow it to push other Rigidbody objects around.")]
		public bool createRigidBodyWhenNotTouching;

		[Header("Custom Settings")]
		[Tooltip("The rigidbody point on the controller model to snap the grabbed Interactable Object to. If blank it will be set to the SDK default.")]
		public Rigidbody controllerAttachPoint;

		[Tooltip("The Controller Events to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_ControllerEvents controllerEvents;

		[Tooltip("The Interact Touch to listen for touches on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractTouch interactTouch;

		protected VRTK_ControllerEvents.ButtonAlias subscribedGrabButton;

		protected VRTK_ControllerEvents.ButtonAlias savedGrabButton;

		protected bool grabPressed;

		protected GameObject grabbedObject;

		protected bool influencingGrabbedObject;

		protected int grabEnabledState;

		protected float grabPrecognitionTimer;

		protected GameObject undroppableGrabbedObject;

		protected Rigidbody originalControllerAttachPoint;

		protected VRTK_ControllerReference controllerReference => VRTK_ControllerReference.GetControllerReference((interactTouch != null) ? interactTouch.gameObject : null);

		public event ControllerInteractionEventHandler GrabButtonPressed;

		public event ControllerInteractionEventHandler GrabButtonReleased;

		public event ObjectInteractEventHandler ControllerStartGrabInteractableObject;

		public event ObjectInteractEventHandler ControllerGrabInteractableObject;

		public event ObjectInteractEventHandler ControllerStartUngrabInteractableObject;

		public event ObjectInteractEventHandler ControllerUngrabInteractableObject;

		public virtual void OnControllerStartGrabInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartGrabInteractableObject != null)
			{
				this.ControllerStartGrabInteractableObject(this, e);
			}
		}

		public virtual void OnControllerGrabInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerGrabInteractableObject != null)
			{
				this.ControllerGrabInteractableObject(this, e);
			}
		}

		public virtual void OnControllerStartUngrabInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartUngrabInteractableObject != null)
			{
				this.ControllerStartUngrabInteractableObject(this, e);
			}
		}

		public virtual void OnControllerUngrabInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerUngrabInteractableObject != null)
			{
				this.ControllerUngrabInteractableObject(this, e);
			}
		}

		public virtual void OnGrabButtonPressed(ControllerInteractionEventArgs e)
		{
			if (this.GrabButtonPressed != null)
			{
				this.GrabButtonPressed(this, e);
			}
		}

		public virtual void OnGrabButtonReleased(ControllerInteractionEventArgs e)
		{
			if (this.GrabButtonReleased != null)
			{
				this.GrabButtonReleased(this, e);
			}
		}

		public virtual bool IsGrabButtonPressed()
		{
			return grabPressed;
		}

		public virtual void ForceRelease(bool applyGrabbingObjectVelocity = false)
		{
			InitUngrabbedObject(applyGrabbingObjectVelocity);
		}

		public virtual void AttemptGrab()
		{
			AttemptGrabObject();
		}

		public virtual GameObject GetGrabbedObject()
		{
			return grabbedObject;
		}

		public virtual void ForceControllerAttachPoint(Rigidbody forcedAttachPoint)
		{
			originalControllerAttachPoint = forcedAttachPoint;
			controllerAttachPoint = forcedAttachPoint;
		}

		protected virtual void Awake()
		{
			originalControllerAttachPoint = controllerAttachPoint;
			controllerEvents = ((controllerEvents != null) ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
			interactTouch = ((interactTouch != null) ? interactTouch : GetComponentInParent<VRTK_InteractTouch>());
			if (interactTouch == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_InteractGrab", "VRTK_InteractTouch", "interactTouch", "the same or parent"));
			}
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			RegrabUndroppableObject();
			ManageGrabListener(state: true);
			ManageInteractTouchListener(state: true);
			if (controllerEvents != null)
			{
				controllerEvents.ControllerIndexChanged += DoControllerModelUpdate;
				controllerEvents.ControllerModelAvailable += DoControllerModelUpdate;
			}
			SetControllerAttachPoint();
		}

		protected virtual void OnDisable()
		{
			SetUndroppableObject();
			ForceRelease();
			ManageGrabListener(state: false);
			ManageInteractTouchListener(state: false);
			if (controllerEvents != null)
			{
				controllerEvents.ControllerIndexChanged -= DoControllerModelUpdate;
				controllerEvents.ControllerModelAvailable -= DoControllerModelUpdate;
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			ManageGrabListener(state: true);
			CheckControllerAttachPointSet();
			CreateNonTouchingRigidbody();
			CheckPrecognitionGrab();
		}

		protected virtual void DoControllerModelUpdate(object sender, ControllerInteractionEventArgs e)
		{
			SetControllerAttachPoint();
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
				if (component != null && component.grabOverrideButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					savedGrabButton = subscribedGrabButton;
					grabButton = component.grabOverrideButton;
					ManageGrabListener(state: true);
				}
			}
		}

		protected virtual void ControllerUntouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			if (e.target != null && !e.target.GetComponent<VRTK_InteractableObject>().IsGrabbed() && savedGrabButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				grabButton = savedGrabButton;
				savedGrabButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				ManageGrabListener(state: true);
			}
		}

		protected virtual void ManageGrabListener(bool state)
		{
			if (controllerEvents != null && subscribedGrabButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || grabButton != subscribedGrabButton))
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedGrabButton, startEvent: true, DoGrabObject);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedGrabButton, startEvent: false, DoReleaseObject);
				subscribedGrabButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			if (controllerEvents != null && state && grabButton != VRTK_ControllerEvents.ButtonAlias.Undefined && grabButton != subscribedGrabButton)
			{
				controllerEvents.SubscribeToButtonAliasEvent(grabButton, startEvent: true, DoGrabObject);
				controllerEvents.SubscribeToButtonAliasEvent(grabButton, startEvent: false, DoReleaseObject);
				subscribedGrabButton = grabButton;
			}
		}

		protected virtual void RegrabUndroppableObject()
		{
			if (undroppableGrabbedObject != null)
			{
				VRTK_InteractableObject component = undroppableGrabbedObject.GetComponent<VRTK_InteractableObject>();
				if (interactTouch != null && component != null && !component.IsGrabbed())
				{
					undroppableGrabbedObject.SetActive(value: true);
					interactTouch.ForceTouch(undroppableGrabbedObject);
					AttemptGrab();
				}
			}
			else
			{
				undroppableGrabbedObject = null;
			}
		}

		protected virtual void SetUndroppableObject()
		{
			if (undroppableGrabbedObject != null)
			{
				VRTK_InteractableObject component = undroppableGrabbedObject.GetComponent<VRTK_InteractableObject>();
				if (component != null && component.IsDroppable())
				{
					undroppableGrabbedObject = null;
				}
				else
				{
					undroppableGrabbedObject.SetActive(value: false);
				}
			}
		}

		protected virtual void SetControllerAttachPoint()
		{
			if (!(controllerReference.model != null) || !(originalControllerAttachPoint == null))
			{
				return;
			}
			SDK_BaseController.ControllerHand controllerHand = VRTK_DeviceFinder.GetControllerHand(interactTouch.gameObject);
			string controllerElementPath = VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.AttachPoint, controllerHand);
			Transform transform = controllerReference.model.transform.Find(controllerElementPath);
			if (transform != null)
			{
				controllerAttachPoint = transform.GetComponent<Rigidbody>();
				if (controllerAttachPoint == null)
				{
					Rigidbody rigidbody = transform.gameObject.AddComponent<Rigidbody>();
					rigidbody.isKinematic = true;
					controllerAttachPoint = rigidbody;
				}
			}
		}

		protected virtual bool IsObjectGrabbable(GameObject obj)
		{
			VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
			if (!component.IsValidInteractableController(base.gameObject, component.allowedGrabControllers))
			{
				return false;
			}
			if (interactTouch != null && interactTouch.IsObjectInteractable(obj) && component != null)
			{
				if (!component.isGrabbable)
				{
					return component.PerformSecondaryAction();
				}
				return true;
			}
			return false;
		}

		protected virtual bool IsObjectHoldOnGrab(GameObject obj)
		{
			if (obj != null)
			{
				VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					return component.holdButtonToGrab;
				}
				return false;
			}
			return false;
		}

		protected virtual void ChooseGrabSequence(VRTK_InteractableObject grabbedObjectScript)
		{
			if (!grabbedObjectScript.IsGrabbed() || grabbedObjectScript.IsSwappable())
			{
				InitPrimaryGrab(grabbedObjectScript);
			}
			else
			{
				InitSecondaryGrab(grabbedObjectScript);
			}
		}

		protected virtual void ToggleControllerVisibility(bool visible)
		{
			if (grabbedObject != null)
			{
				VRTK_InteractControllerAppearance[] componentsInParent = grabbedObject.GetComponentsInParent<VRTK_InteractControllerAppearance>(includeInactive: true);
				if (componentsInParent.Length != 0)
				{
					componentsInParent[0].ToggleControllerOnGrab(visible, controllerReference.model, grabbedObject);
				}
			}
			else if (visible)
			{
				VRTK_ObjectAppearance.SetRendererVisible(controllerReference.model, grabbedObject);
			}
		}

		protected virtual void InitGrabbedObject()
		{
			grabbedObject = ((interactTouch != null) ? interactTouch.GetTouchedObject() : null);
			if (grabbedObject != null)
			{
				OnControllerStartGrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
				VRTK_InteractableObject component = grabbedObject.GetComponent<VRTK_InteractableObject>();
				ChooseGrabSequence(component);
				ToggleControllerVisibility(visible: false);
				OnControllerGrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
			}
		}

		protected virtual void InitPrimaryGrab(VRTK_InteractableObject currentGrabbedObject)
		{
			if (!currentGrabbedObject.IsValidInteractableController(base.gameObject, currentGrabbedObject.allowedGrabControllers))
			{
				grabbedObject = null;
				if (interactTouch != null && currentGrabbedObject.IsGrabbed(base.gameObject))
				{
					interactTouch.ForceStopTouching();
				}
			}
			else
			{
				influencingGrabbedObject = false;
				currentGrabbedObject.SaveCurrentState();
				currentGrabbedObject.Grabbed(this);
				currentGrabbedObject.ZeroVelocity();
				currentGrabbedObject.isKinematic = false;
			}
		}

		protected virtual void InitSecondaryGrab(VRTK_InteractableObject currentGrabbedObject)
		{
			influencingGrabbedObject = true;
			currentGrabbedObject.Grabbed(this);
		}

		protected virtual void CheckInfluencingObjectOnRelease()
		{
			if (!influencingGrabbedObject && interactTouch != null)
			{
				interactTouch.ForceStopTouching();
				ToggleControllerVisibility(visible: true);
			}
			influencingGrabbedObject = false;
		}

		protected virtual void InitUngrabbedObject(bool applyGrabbingObjectVelocity)
		{
			if (grabbedObject != null && interactTouch != null)
			{
				OnControllerStartUngrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
				VRTK_InteractableObject component = grabbedObject.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					if (!influencingGrabbedObject)
					{
						component.grabAttachMechanicScript.StopGrab(applyGrabbingObjectVelocity);
					}
					component.Ungrabbed(this);
					ToggleControllerVisibility(visible: true);
					OnControllerUngrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
				}
			}
			CheckInfluencingObjectOnRelease();
			grabEnabledState = 0;
			grabbedObject = null;
		}

		protected virtual GameObject GetGrabbableObject()
		{
			GameObject gameObject = ((interactTouch != null) ? interactTouch.GetTouchedObject() : null);
			if (gameObject != null && interactTouch.IsObjectInteractable(gameObject))
			{
				return gameObject;
			}
			return grabbedObject;
		}

		protected virtual void IncrementGrabState()
		{
			if (interactTouch != null && !IsObjectHoldOnGrab(interactTouch.GetTouchedObject()))
			{
				grabEnabledState++;
			}
		}

		protected virtual GameObject GetUndroppableObject()
		{
			if (grabbedObject != null)
			{
				VRTK_InteractableObject component = grabbedObject.GetComponent<VRTK_InteractableObject>();
				if (!(component != null) || component.IsDroppable())
				{
					return null;
				}
				return grabbedObject;
			}
			return null;
		}

		protected virtual void AttemptGrabObject()
		{
			GameObject grabbableObject = GetGrabbableObject();
			if (grabbableObject != null)
			{
				PerformGrabAttempt(grabbableObject);
			}
			else
			{
				grabPrecognitionTimer = Time.time + grabPrecognition;
			}
		}

		protected virtual void PerformGrabAttempt(GameObject objectToGrab)
		{
			IncrementGrabState();
			IsValidGrabAttempt(objectToGrab);
			undroppableGrabbedObject = GetUndroppableObject();
		}

		protected virtual bool ScriptValidGrab(VRTK_InteractableObject objectToGrabScript)
		{
			if (objectToGrabScript != null && objectToGrabScript.grabAttachMechanicScript != null)
			{
				return objectToGrabScript.grabAttachMechanicScript.ValidGrab(controllerAttachPoint);
			}
			return false;
		}

		protected virtual bool IsValidGrabAttempt(GameObject objectToGrab)
		{
			bool result = false;
			VRTK_InteractableObject vRTK_InteractableObject = ((objectToGrab != null) ? objectToGrab.GetComponent<VRTK_InteractableObject>() : null);
			if (grabbedObject == null && interactTouch != null && IsObjectGrabbable(interactTouch.GetTouchedObject()) && ScriptValidGrab(vRTK_InteractableObject))
			{
				InitGrabbedObject();
				if (!influencingGrabbedObject)
				{
					result = vRTK_InteractableObject.grabAttachMechanicScript.StartGrab(base.gameObject, grabbedObject, controllerAttachPoint);
				}
			}
			return result;
		}

		protected virtual bool CanRelease()
		{
			if (grabbedObject != null)
			{
				VRTK_InteractableObject component = grabbedObject.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					return component.IsDroppable();
				}
				return false;
			}
			return false;
		}

		protected virtual void AttemptReleaseObject()
		{
			if (CanRelease() && (IsObjectHoldOnGrab(grabbedObject) || grabEnabledState >= 2))
			{
				InitUngrabbedObject(applyGrabbingObjectVelocity: true);
			}
		}

		protected virtual void DoGrabObject(object sender, ControllerInteractionEventArgs e)
		{
			OnGrabButtonPressed(controllerEvents.SetControllerEvent(ref grabPressed, value: true));
			AttemptGrabObject();
		}

		protected virtual void DoReleaseObject(object sender, ControllerInteractionEventArgs e)
		{
			AttemptReleaseObject();
			OnGrabButtonReleased(controllerEvents.SetControllerEvent(ref grabPressed));
		}

		protected virtual void CheckControllerAttachPointSet()
		{
			if (controllerAttachPoint == null)
			{
				SetControllerAttachPoint();
			}
		}

		protected virtual void CreateNonTouchingRigidbody()
		{
			if (createRigidBodyWhenNotTouching && grabbedObject == null && interactTouch != null && !interactTouch.IsRigidBodyForcedActive() && interactTouch.IsRigidBodyActive() != grabPressed)
			{
				interactTouch.ToggleControllerRigidBody(grabPressed);
			}
		}

		protected virtual void CheckPrecognitionGrab()
		{
			if (grabPrecognitionTimer >= Time.time && GetGrabbableObject() != null)
			{
				AttemptGrabObject();
				if (GetGrabbedObject() != null)
				{
					grabPrecognitionTimer = 0f;
				}
			}
		}
	}
}
