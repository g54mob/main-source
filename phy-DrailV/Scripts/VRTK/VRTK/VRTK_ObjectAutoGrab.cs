using System.Collections;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_ObjectAutoGrab")]
	public class VRTK_ObjectAutoGrab : MonoBehaviour
	{
		[Tooltip("The Interactable Object that will be grabbed by the Interact Grab.")]
		public VRTK_InteractableObject objectToGrab;

		[Tooltip("If the `Object To Grab` is a prefab then this needs to be checked, if the `Object To Grab` already exists in the scene then this needs to be unchecked.")]
		public bool objectIsPrefab;

		[Tooltip("If this is checked then the `Object To Grab` will be cloned into a new Interactable Object and grabbed by the Interact Grab leaving the existing Interactable Object in the scene. This is required if the same Interactable Object is to be grabbed to multiple instances of Interact Grab. It is also required to clone a grabbed Interactable Object if it is a prefab as it needs to exist within the scene to be grabbed.")]
		public bool cloneGrabbedObject;

		[Tooltip("If `Clone Grabbed Object` is checked and this is checked, then whenever this script is disabled and re-enabled, it will always create a new clone of the Interactable Object to grab. If this is unchecked then the original cloned Interactable Object will attempt to be grabbed again. If the original cloned object no longer exists then a new clone will be created.")]
		public bool alwaysCloneOnEnable;

		[Tooltip("If this is checked then the `Object To Grab` will attempt to be secondary grabbed as well as primary grabbed.")]
		public bool attemptSecondaryGrab;

		[Header("Custom Settings")]
		[Tooltip("The Interact Touch to listen for touches on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractTouch interactTouch;

		[Tooltip("The Interact Grab to listen for grab actions on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractGrab interactGrab;

		[Tooltip("The secondary controller Interact Touch to listen for touches on. If this field is left blank then it will be looked up on the opposite controller script alias at runtime.")]
		public VRTK_InteractTouch secondaryInteractTouch;

		[Tooltip("The secondary controller Interact Grab to listen for grab actions on. If this field is left blank then it will be looked up on the opposite controller script alias at runtime.")]
		public VRTK_InteractGrab secondaryInteractGrab;

		protected VRTK_InteractableObject previousClonedObject;

		protected Coroutine autoGrabRoutine;

		public event ObjectAutoGrabEventHandler ObjectAutoGrabCompleted;

		public virtual void OnObjectAutoGrabCompleted()
		{
			if (this.ObjectAutoGrabCompleted != null)
			{
				this.ObjectAutoGrabCompleted(this);
			}
		}

		public virtual void ClearPreviousClone()
		{
			previousClonedObject = null;
		}

		protected virtual void OnEnable()
		{
			if (objectIsPrefab)
			{
				cloneGrabbedObject = true;
			}
			autoGrabRoutine = StartCoroutine(AutoGrab());
		}

		protected virtual void OnDisable()
		{
			if (autoGrabRoutine != null)
			{
				StopCoroutine(autoGrabRoutine);
			}
		}

		protected virtual IEnumerator AutoGrab()
		{
			yield return new WaitForEndOfFrame();
			interactTouch = ((interactTouch != null) ? interactTouch : GetComponentInParent<VRTK_InteractTouch>());
			interactGrab = ((interactGrab != null) ? interactGrab : GetComponentInParent<VRTK_InteractGrab>());
			if (interactTouch == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_ObjectAutoGrab", "VRTK_InteractTouch", "interactTouch", "the same or parent"));
			}
			if (interactGrab == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_ObjectAutoGrab", "VRTK_InteractGrab", "interactGrab", "the same or parent"));
			}
			if (objectToGrab == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.NOT_DEFINED, "objectToGrab"));
				yield break;
			}
			while (interactGrab.controllerAttachPoint == null)
			{
				yield return true;
			}
			bool disableWhenIdle = objectToGrab.disableWhenIdle;
			if (objectIsPrefab)
			{
				objectToGrab.disableWhenIdle = false;
			}
			VRTK_InteractableObject vRTK_InteractableObject = objectToGrab;
			if (alwaysCloneOnEnable)
			{
				ClearPreviousClone();
			}
			if (!interactGrab.GetGrabbedObject())
			{
				if (cloneGrabbedObject)
				{
					vRTK_InteractableObject = ((!(previousClonedObject == null)) ? previousClonedObject : (previousClonedObject = Object.Instantiate(objectToGrab)));
				}
				if (vRTK_InteractableObject.isGrabbable && !vRTK_InteractableObject.IsGrabbed())
				{
					vRTK_InteractableObject.transform.position = base.transform.position;
					interactTouch.ForceStopTouching();
					interactTouch.ForceTouch(vRTK_InteractableObject.gameObject);
					interactGrab.AttemptGrab();
					AttemptSecondaryGrab(vRTK_InteractableObject);
					OnObjectAutoGrabCompleted();
				}
			}
			objectToGrab.disableWhenIdle = disableWhenIdle;
			vRTK_InteractableObject.disableWhenIdle = disableWhenIdle;
		}

		protected virtual void AttemptSecondaryGrab(VRTK_InteractableObject grabbableObject)
		{
			if (attemptSecondaryGrab)
			{
				VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetOppositeHand(VRTK_DeviceFinder.GetControllerHand(interactTouch.gameObject)));
				if (VRTK_ControllerReference.IsValid(controllerReference))
				{
					secondaryInteractTouch = ((secondaryInteractTouch == null) ? controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractTouch>() : secondaryInteractTouch);
					secondaryInteractGrab = ((secondaryInteractGrab == null) ? controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractGrab>() : secondaryInteractGrab);
					secondaryInteractTouch.ForceStopTouching();
					secondaryInteractTouch.ForceTouch(grabbableObject.gameObject);
					secondaryInteractGrab.AttemptGrab();
				}
			}
		}
	}
}
