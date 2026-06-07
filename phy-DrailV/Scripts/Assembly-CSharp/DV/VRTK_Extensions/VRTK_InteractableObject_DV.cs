using System;
using DV.Interaction;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_InteractableObject_DV : VRTK_InteractableObject
	{
		public delegate Vector3 CustomInteractionPointDelegate(Vector3 pipaPosition);

		public int priority;

		public bool pipaExclusiveInteraction;

		public bool isScrollable;

		private AllowedController cachedAllowedUseControllers;

		public InteractionHandPoses interactionHandPoses;

		public bool continuousUse;

		public CustomInteractionPointDelegate CustomInteractionPoint;

		public virtual bool InteractionAllowed => true;

		public event Action<VRTK_InteractableObject_DV> InteractableObjectAboutToBeDestroyed;

		public void ForceStopAllInteractions_Public()
		{
			ForceStopAllInteractions();
		}

		protected override void ForceStopAllInteractions()
		{
			if (touchingObjects != null)
			{
				StopUsingInteractions();
				StopGrabbingInteractions();
				StopTouchingInteractions();
			}
		}

		protected override void Awake()
		{
			base.Awake();
			cachedAllowedUseControllers = allowedUseControllers;
		}

		protected override void StopGrabbingInteractions()
		{
			if (!IsDroppable())
			{
				return;
			}
			GameObject grabbingObject = GetGrabbingObject();
			if (grabbingObject == null || (!grabbingObject.activeInHierarchy && !forceDisabled))
			{
				return;
			}
			GameObject secondaryGrabbingObject = GetSecondaryGrabbingObject();
			if (secondaryGrabbingObject != null)
			{
				VRTK_InteractGrab componentInChildren = secondaryGrabbingObject.GetComponentInChildren<VRTK_InteractGrab>();
				if (componentInChildren != null && componentInChildren.interactTouch != null)
				{
					componentInChildren.ForceRelease();
					forcedDropped = true;
				}
			}
			VRTK_InteractGrab componentInChildren2 = grabbingObject.GetComponentInChildren<VRTK_InteractGrab>();
			if (componentInChildren2 != null && componentInChildren2.interactTouch != null)
			{
				componentInChildren2.ForceRelease();
				forcedDropped = true;
			}
		}

		protected override void StopUsingInteractions()
		{
			if (usingObject != null && usingObject.interactTouch != null && (usingObject.gameObject.activeInHierarchy || forceDisabled))
			{
				usingObject.ForceStopUsing();
			}
		}

		public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
		{
			base.OnInteractableObjectGrabbed(e);
			if (useOnlyIfGrabbed && allowedUseControllers == AllowedController.Both)
			{
				GameObject grabbingObject = GetGrabbingObject();
				GameObject secondaryGrabbingObject = GetSecondaryGrabbingObject();
				SDK_BaseController.ControllerHand controllerHand = VRTK_DeviceFinder.GetControllerHand(grabbingObject);
				if (secondaryGrabbingObject == null)
				{
					allowedUseControllers = ((controllerHand == SDK_BaseController.ControllerHand.Left) ? AllowedController.LeftOnly : AllowedController.RightOnly);
				}
			}
		}

		public override void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e)
		{
			base.OnInteractableObjectUngrabbed(e);
			if (useOnlyIfGrabbed)
			{
				allowedUseControllers = cachedAllowedUseControllers;
			}
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isQuitting)
			{
				this.InteractableObjectAboutToBeDestroyed?.Invoke(this);
			}
		}

		public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null)
		{
			GameObject gameObject = ((previousGrabbingObject != null) ? previousGrabbingObject.gameObject : null);
			GameObject secondaryGrabbingObject = GetSecondaryGrabbingObject();
			if (secondaryGrabbingObject == null || secondaryGrabbingObject != gameObject)
			{
				VRTK_BaseTwoHandedSecondaryGrab component = GetComponent<VRTK_BaseTwoHandedSecondaryGrab>();
				if (secondaryGrabbingObject != null && component != null && component.CanBecomePrimary)
				{
					PrimaryControllerUngrabTwoHanded(gameObject, secondaryGrabbingObject);
				}
				else
				{
					StandardControllerUngrab(gameObject, secondaryGrabbingObject);
				}
			}
			else
			{
				SecondaryControllerUngrab(gameObject);
			}
			OnInteractableObjectUngrabbed(SetInteractableObjectEvent(gameObject));
		}

		private void PrimaryControllerUngrabTwoHanded(GameObject previousGrabbingObject, GameObject previousSecondaryGrabbingObject)
		{
			UnpauseCollisions();
			RemoveTrackPoint();
			ResetUseState(previousGrabbingObject);
			grabbingObjects.Clear();
			LoadPreviousState();
			VRTK_BaseTwoHandedSecondaryGrab component = GetComponent<VRTK_BaseTwoHandedSecondaryGrab>();
			if (!(component == null) && component.CanBecomePrimary)
			{
				if (snappedInSnapDropZone)
				{
					ToggleSnapDropZone(storedSnapDropZone, state: false);
				}
				previousSecondaryGrabbingObject.GetComponentInChildren<VRTK_InteractGrab_DV>().StopInfluencingObject();
				VRTK_SharedMethods.AddListValue(grabbingObjects, previousSecondaryGrabbingObject, preventDuplicates: true);
				SetTrackPoint(previousSecondaryGrabbingObject);
				component.BecomePrimaryGrab();
			}
		}

		private void StandardControllerUngrab(GameObject previousGrabbingObject, GameObject previousSecondaryGrabbingObject)
		{
			SecondaryControllerUngrab(previousSecondaryGrabbingObject);
			PrimaryControllerUngrab(previousGrabbingObject, previousSecondaryGrabbingObject);
		}

		public Vector3 GetInteractionPoint(Vector3 pipaPosition)
		{
			if (CustomInteractionPoint == null)
			{
				return base.transform.position;
			}
			return CustomInteractionPoint(pipaPosition);
		}

		public void SetCustomInteractionPoint(CustomInteractionPointDelegate customInteractionPoint)
		{
			CustomInteractionPoint = customInteractionPoint;
		}
	}
}
