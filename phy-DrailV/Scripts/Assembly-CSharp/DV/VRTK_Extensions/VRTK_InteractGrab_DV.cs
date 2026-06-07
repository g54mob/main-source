using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_InteractGrab_DV : VRTK_InteractGrab
	{
		private VRTK_ControllerEvents.ButtonAlias dropItemButton;

		private bool canDoLazyGrab;

		private VRTK_InteractUse_DV interactUse;

		public event AboutToForceGrabDelegate AboutToForceGrab;

		public event ControllerInteractionEventHandler DropItemButtonPressed;

		public event ControllerInteractionEventHandler DropItemButtonReleased;

		protected override void Awake()
		{
			base.Awake();
			interactUse = GetComponent<VRTK_InteractUse_DV>();
			interactUse.InteractableObjectUsed += OnInteractableObjectUsed;
			SetupDropItemButton(VRTK_ControllerEvents.ButtonAlias.GripClick);
		}

		private void OnInteractableObjectUsed()
		{
			canDoLazyGrab = false;
		}

		public override void OnControllerUngrabInteractableObject(ObjectInteractEventArgs e)
		{
			base.OnControllerUngrabInteractableObject(e);
			canDoLazyGrab = false;
		}

		public void ForceGrabInteractable(GameObject interactable, bool usingGrabButton = false)
		{
			VRTK_InteractableObject interactable2 = interactable?.GetComponent<VRTK_InteractableObject>();
			ForceGrabInteractable(interactable2, usingGrabButton);
		}

		public void ForceGrabInteractable(VRTK_InteractableObject interactable, bool usingGrabButton = false)
		{
			if (interactable == null)
			{
				Debug.LogError("'VRTK_InteractGrab_DV' needs a valid 'VRTK_InteractableObject' reference. Force grab failed.", this);
				return;
			}
			if (grabbedObject != null)
			{
				if (!(interactable.gameObject != grabbedObject))
				{
					return;
				}
				ForceRelease();
			}
			this.AboutToForceGrab?.Invoke(interactable.GetComponent<IInteractionStyleTarget>() as Component != null, usingGrabButton);
			interactTouch.ForceStopTouching();
			interactTouch.ForceTouch(interactable.gameObject);
			AttemptGrab();
		}

		protected override void AttemptReleaseObject()
		{
			if (CanRelease() && IsObjectHoldOnGrab(grabbedObject))
			{
				InitUngrabbedObject(applyGrabbingObjectVelocity: true);
			}
		}

		protected override bool IsValidGrabAttempt(GameObject objectToGrab)
		{
			if (objectToGrab == null || interactTouch == null || grabbedObject != null)
			{
				return false;
			}
			if (Attempt(objectToGrab.GetComponent<VRTK_InteractableObject>(), out var result))
			{
				return result;
			}
			if (!base.controllerReference.IsWandOrUndefined() && Attempt(objectToGrab.transform.parent?.GetComponentInParent<VRTK_InteractableObject>(), out result))
			{
				return result;
			}
			return false;
			bool Attempt(VRTK_InteractableObject target, out bool reference)
			{
				reference = false;
				if (target == null)
				{
					return false;
				}
				if (!IsObjectGrabbable(target.gameObject) || !ScriptValidGrab(target))
				{
					return false;
				}
				InitGrabbedObject_DV(target.gameObject);
				if (!influencingGrabbedObject)
				{
					reference = target.grabAttachMechanicScript.StartGrab(base.gameObject, grabbedObject, controllerAttachPoint);
				}
				return true;
			}
		}

		private void InitGrabbedObject_DV(GameObject obj)
		{
			grabbedObject = obj;
			if (grabbedObject != null)
			{
				OnControllerStartGrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
				VRTK_InteractableObject component = grabbedObject.GetComponent<VRTK_InteractableObject>();
				ChooseGrabSequence(component);
				ToggleControllerVisibility(visible: false);
				OnControllerGrabInteractableObject(interactTouch.SetControllerInteractEvent(grabbedObject));
			}
		}

		public void SetupDropItemButton(VRTK_ControllerEvents.ButtonAlias desiredDropItemButton)
		{
			if (dropItemButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				if (desiredDropItemButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					Debug.LogError("'SetupDropItemButton' requires a defined button. Items will be undroppable.", this);
					return;
				}
				dropItemButton = desiredDropItemButton;
				controllerEvents.SubscribeToButtonAliasEvent(dropItemButton, startEvent: true, OnDropItemButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(dropItemButton, startEvent: false, OnDropItemButtonReleased);
			}
		}

		private void OnDropItemButtonPressed(object _, ControllerInteractionEventArgs e)
		{
			this.DropItemButtonPressed?.Invoke(this, e);
		}

		private void OnDropItemButtonReleased(object _, ControllerInteractionEventArgs e)
		{
			this.DropItemButtonReleased?.Invoke(this, e);
		}

		protected override void InitUngrabbedObject(bool applyGrabbingObjectVelocity)
		{
			GameObject gameObject = grabbedObject;
			grabbedObject = null;
			if (gameObject != null && interactTouch != null)
			{
				OnControllerStartUngrabInteractableObject(interactTouch.SetControllerInteractEvent(gameObject));
				VRTK_InteractableObject component = gameObject.GetComponent<VRTK_InteractableObject>();
				if (component != null)
				{
					if (!influencingGrabbedObject)
					{
						component.grabAttachMechanicScript.StopGrab(applyGrabbingObjectVelocity);
					}
					component.Ungrabbed(this);
					ToggleControllerVisibility(visible: true);
					OnControllerUngrabInteractableObject(interactTouch.SetControllerInteractEvent(gameObject));
				}
			}
			CheckInfluencingObjectOnRelease();
			grabEnabledState = 0;
		}

		public override void OnGrabButtonPressed(ControllerInteractionEventArgs e)
		{
			base.OnGrabButtonPressed(e);
			canDoLazyGrab = true;
		}

		protected override void ControllerTouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			base.ControllerTouchInteractableObject(sender, e);
			if (!canDoLazyGrab || e.target == null)
			{
				return;
			}
			VRTK_InteractableObject component = e.target.GetComponent<VRTK_InteractableObject>();
			if (component.IsGrabbed())
			{
				return;
			}
			VRTK_ControllerEvents.ButtonAlias button = ((component.grabOverrideButton == VRTK_ControllerEvents.ButtonAlias.Undefined) ? grabButton : component.grabOverrideButton);
			if (controllerEvents.IsButtonPressed(button) && !(grabbedObject != null))
			{
				Telegrabbable componentInParent = e.target.GetComponentInParent<Telegrabbable>();
				if (componentInParent != null && componentInParent.IsBeingTelegrabbed)
				{
					canDoLazyGrab = false;
				}
				else
				{
					AttemptGrab();
				}
			}
		}

		protected override void ControllerUntouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			if (savedGrabButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				grabButton = savedGrabButton;
				savedGrabButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				ManageGrabListener(state: true);
			}
		}

		public void StopInfluencingObject()
		{
			influencingGrabbedObject = false;
		}
	}
}
