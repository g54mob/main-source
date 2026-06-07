using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/VRTK_ObjectTouchAutoInteract")]
	public class VRTK_ObjectTouchAutoInteract : VRTK_InteractableListener
	{
		public enum AutoInteractions
		{
			Never = 0,
			NoButtonHeld = 1,
			ButtonHeld = 2
		}

		[Header("Auto Grab")]
		[Tooltip("Determines when a grab on touch should occur.")]
		public AutoInteractions grabOnTouchWhen;

		[Tooltip("After being ungrabbed, another auto grab on touch can only occur after this time.")]
		public float regrabDelay = 0.1f;

		[Tooltip("If this is checked then the grab on touch check will happen every frame and not only on the first touch of the Interactable Object.")]
		public bool continuousGrabCheck;

		[Header("Auto Use")]
		[Tooltip("Determines when a use on touch should occur.")]
		public AutoInteractions useOnTouchWhen;

		[Tooltip("After being unused, another auto use on touch can only occur after this time.")]
		public float reuseDelay = 0.1f;

		[Tooltip("If this is checked then the use on touch check will happen every frame and not only on the first touch of the Interactable Object.")]
		public bool continuousUseCheck;

		[Header("Custom Settings")]
		[Tooltip("The Interactable Object that the auto interaction will occur on. If this is blank then the script must be on the same GameObject as the Interactable Object script.")]
		public VRTK_InteractableObject interactableObject;

		protected float regrabTimer;

		protected float reuseTimer;

		protected List<GameObject> touchers = new List<GameObject>();

		protected virtual void OnEnable()
		{
			regrabTimer = 0f;
			reuseTimer = 0f;
			touchers.Clear();
			EnableListeners();
		}

		protected virtual void OnDisable()
		{
			TearDownListeners();
		}

		protected virtual void Update()
		{
			if (!(interactableObject != null) || (!continuousGrabCheck && !continuousUseCheck))
			{
				return;
			}
			for (int i = 0; i < touchers.Count; i++)
			{
				if (continuousGrabCheck)
				{
					CheckGrab(touchers[i]);
				}
				if (continuousUseCheck)
				{
					CheckUse(touchers[i]);
				}
			}
		}

		protected override bool SetupListeners(bool throwError)
		{
			interactableObject = ((interactableObject != null) ? interactableObject : GetComponentInParent<VRTK_InteractableObject>());
			if (interactableObject != null)
			{
				interactableObject.InteractableObjectTouched += InteractableObjectTouched;
				interactableObject.InteractableObjectUntouched += InteractableObjectUntouched;
				interactableObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
				interactableObject.InteractableObjectUnused += InteractableObjectUnused;
				return true;
			}
			if (throwError)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ObjectTouchAutoInteract", "VRTK_InteractableObject", "the same or parent"));
			}
			return false;
		}

		protected override void TearDownListeners()
		{
			if (interactableObject != null)
			{
				interactableObject.InteractableObjectTouched -= InteractableObjectTouched;
				interactableObject.InteractableObjectUntouched -= InteractableObjectUntouched;
				interactableObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
				interactableObject.InteractableObjectUnused -= InteractableObjectUnused;
			}
		}

		protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			ManageTouchers(e.interactingObject, add: true);
			CheckGrab(e.interactingObject);
			CheckUse(e.interactingObject);
		}

		protected virtual void InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
		{
			ManageTouchers(e.interactingObject, add: false);
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			regrabTimer = regrabDelay + Time.time;
		}

		protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
		{
			reuseTimer = reuseDelay + Time.time;
		}

		protected virtual void ManageTouchers(GameObject interactingObject, bool add)
		{
			if (add)
			{
				VRTK_SharedMethods.AddListValue(touchers, interactingObject, preventDuplicates: true);
			}
			else
			{
				touchers.Remove(interactingObject);
			}
		}

		protected virtual void CheckGrab(GameObject interactingObject)
		{
			if (grabOnTouchWhen != AutoInteractions.Never && regrabTimer < Time.time)
			{
				VRTK_InteractGrab componentInChildren = interactingObject.GetComponentInChildren<VRTK_InteractGrab>();
				if (componentInChildren != null && (grabOnTouchWhen == AutoInteractions.NoButtonHeld || (grabOnTouchWhen == AutoInteractions.ButtonHeld && componentInChildren.IsGrabButtonPressed())))
				{
					componentInChildren.AttemptGrab();
				}
			}
		}

		protected virtual void CheckUse(GameObject interactingObject)
		{
			if (useOnTouchWhen == AutoInteractions.Never || !(reuseTimer < Time.time))
			{
				return;
			}
			VRTK_InteractUse componentInChildren = interactingObject.GetComponentInChildren<VRTK_InteractUse>();
			if (componentInChildren != null && (useOnTouchWhen == AutoInteractions.NoButtonHeld || (useOnTouchWhen == AutoInteractions.ButtonHeld && componentInChildren.IsUseButtonPressed())))
			{
				if (!interactableObject.holdButtonToUse && interactableObject.IsUsing())
				{
					interactableObject.ForceStopInteracting();
				}
				else
				{
					componentInChildren.AttemptUse();
				}
			}
		}
	}
}
