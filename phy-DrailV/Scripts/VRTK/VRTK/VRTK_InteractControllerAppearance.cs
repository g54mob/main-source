using System;
using System.Collections;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/VRTK_InteractControllerAppearance")]
	[Obsolete("`VRTK_InteractControllerAppearance` has been replaced with `VRTK_InteractObjectAppearance`. This script will be removed in a future version of VRTK.")]
	public class VRTK_InteractControllerAppearance : MonoBehaviour
	{
		[Header("Touch Visibility")]
		[Tooltip("Hides the controller model when a valid touch occurs.")]
		public bool hideControllerOnTouch;

		[Tooltip("The amount of seconds to wait before hiding the controller on touch.")]
		public float hideDelayOnTouch;

		[Header("Grab Visibility")]
		[Tooltip("Hides the controller model when a valid grab occurs.")]
		public bool hideControllerOnGrab;

		[Tooltip("The amount of seconds to wait before hiding the controller on grab.")]
		public float hideDelayOnGrab;

		[Header("Use Visibility")]
		[Tooltip("Hides the controller model when a valid use occurs.")]
		public bool hideControllerOnUse;

		[Tooltip("The amount of seconds to wait before hiding the controller on use.")]
		public float hideDelayOnUse;

		protected bool touchControllerShow = true;

		protected bool grabControllerShow = true;

		protected Coroutine hideControllerRoutine;

		public event InteractControllerAppearanceEventHandler ControllerHidden;

		public event InteractControllerAppearanceEventHandler ControllerVisible;

		public event InteractControllerAppearanceEventHandler HiddenOnTouch;

		public event InteractControllerAppearanceEventHandler VisibleOnTouch;

		public event InteractControllerAppearanceEventHandler HiddenOnGrab;

		public event InteractControllerAppearanceEventHandler VisibleOnGrab;

		public event InteractControllerAppearanceEventHandler HiddenOnUse;

		public event InteractControllerAppearanceEventHandler VisibleOnUse;

		public virtual void OnControllerHidden(InteractControllerAppearanceEventArgs e)
		{
			if (this.ControllerHidden != null)
			{
				this.ControllerHidden(this, e);
			}
		}

		public virtual void OnControllerVisible(InteractControllerAppearanceEventArgs e)
		{
			if (this.ControllerVisible != null)
			{
				this.ControllerVisible(this, e);
			}
		}

		public virtual void OnHiddenOnTouch(InteractControllerAppearanceEventArgs e)
		{
			if (this.HiddenOnTouch != null)
			{
				this.HiddenOnTouch(this, e);
			}
		}

		public virtual void OnVisibleOnTouch(InteractControllerAppearanceEventArgs e)
		{
			if (this.VisibleOnTouch != null)
			{
				this.VisibleOnTouch(this, e);
			}
		}

		public virtual void OnHiddenOnGrab(InteractControllerAppearanceEventArgs e)
		{
			if (this.HiddenOnGrab != null)
			{
				this.HiddenOnGrab(this, e);
			}
		}

		public virtual void OnVisibleOnGrab(InteractControllerAppearanceEventArgs e)
		{
			if (this.VisibleOnGrab != null)
			{
				this.VisibleOnGrab(this, e);
			}
		}

		public virtual void OnHiddenOnUse(InteractControllerAppearanceEventArgs e)
		{
			if (this.HiddenOnUse != null)
			{
				this.HiddenOnUse(this, e);
			}
		}

		public virtual void OnVisibleOnUse(InteractControllerAppearanceEventArgs e)
		{
			if (this.VisibleOnUse != null)
			{
				this.VisibleOnUse(this, e);
			}
		}

		public virtual void ToggleControllerOnTouch(bool showController, GameObject touchingObject, GameObject ignoredObject)
		{
			if (hideControllerOnTouch)
			{
				touchControllerShow = showController;
				ToggleController(showController, touchingObject, ignoredObject, hideDelayOnTouch);
				if (showController)
				{
					OnVisibleOnTouch(SetEventPayload(touchingObject, ignoredObject));
				}
				else
				{
					OnHiddenOnTouch(SetEventPayload(touchingObject, ignoredObject));
				}
			}
		}

		public virtual void ToggleControllerOnGrab(bool showController, GameObject grabbingObject, GameObject ignoredObject)
		{
			if (!hideControllerOnGrab)
			{
				return;
			}
			VRTK_InteractableObject vRTK_InteractableObject = ((ignoredObject != null) ? ignoredObject.GetComponentInParent<VRTK_InteractableObject>() : null);
			if (!showController || touchControllerShow || !vRTK_InteractableObject || !vRTK_InteractableObject.IsTouched())
			{
				grabControllerShow = showController;
				ToggleController(showController, grabbingObject, ignoredObject, hideDelayOnGrab);
				if (showController)
				{
					OnVisibleOnGrab(SetEventPayload(grabbingObject, ignoredObject));
				}
				else
				{
					OnHiddenOnGrab(SetEventPayload(grabbingObject, ignoredObject));
				}
			}
		}

		public virtual void ToggleControllerOnUse(bool showController, GameObject usingObject, GameObject ignoredObject)
		{
			if (!hideControllerOnUse)
			{
				return;
			}
			VRTK_InteractableObject vRTK_InteractableObject = ((ignoredObject != null) ? ignoredObject.GetComponentInParent<VRTK_InteractableObject>() : null);
			if (!showController || ((grabControllerShow || !vRTK_InteractableObject || !vRTK_InteractableObject.IsGrabbed()) && (touchControllerShow || !vRTK_InteractableObject || !vRTK_InteractableObject.IsTouched())))
			{
				ToggleController(showController, usingObject, ignoredObject, hideDelayOnUse);
				if (showController)
				{
					OnVisibleOnUse(SetEventPayload(usingObject, ignoredObject));
				}
				else
				{
					OnHiddenOnUse(SetEventPayload(usingObject, ignoredObject));
				}
			}
		}

		protected virtual void OnEnable()
		{
			if (!GetComponent<VRTK_InteractableObject>())
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_InteractControllerAppearance", "VRTK_InteractableObject", "the same"));
			}
		}

		protected virtual void OnDisable()
		{
			if (hideControllerRoutine != null)
			{
				StopCoroutine(hideControllerRoutine);
			}
		}

		protected virtual void ToggleController(bool showController, GameObject interactingObject, GameObject ignoredObject, float delayTime)
		{
			if (showController)
			{
				ShowController(interactingObject, ignoredObject);
			}
			else
			{
				hideControllerRoutine = StartCoroutine(HideController(interactingObject, ignoredObject, delayTime));
			}
		}

		protected virtual void ShowController(GameObject interactingObject, GameObject ignoredObject)
		{
			if (hideControllerRoutine != null)
			{
				StopCoroutine(hideControllerRoutine);
			}
			VRTK_ObjectAppearance.SetRendererVisible(interactingObject, ignoredObject);
			OnControllerVisible(SetEventPayload(interactingObject, ignoredObject));
		}

		protected virtual IEnumerator HideController(GameObject interactingObject, GameObject ignoredObject, float delayTime)
		{
			yield return new WaitForSeconds(delayTime);
			VRTK_ObjectAppearance.SetRendererHidden(interactingObject, ignoredObject);
			OnControllerHidden(SetEventPayload(interactingObject, ignoredObject));
		}

		protected virtual InteractControllerAppearanceEventArgs SetEventPayload(GameObject interactingObject, GameObject ignroedObject)
		{
			InteractControllerAppearanceEventArgs result = default(InteractControllerAppearanceEventArgs);
			result.interactingObject = interactingObject;
			result.ignoredObject = ignroedObject;
			return result;
		}
	}
}
