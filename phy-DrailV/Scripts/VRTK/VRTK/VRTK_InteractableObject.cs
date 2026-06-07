using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.Highlighters;
using VRTK.SecondaryControllerGrabActions;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/VRTK_InteractableObject")]
	public class VRTK_InteractableObject : MonoBehaviour
	{
		public enum InteractionType
		{
			None = 0,
			NearTouch = 1,
			NearUntouch = 2,
			Touch = 3,
			Untouch = 4,
			Grab = 5,
			Ungrab = 6,
			Use = 7,
			Unuse = 8
		}

		public enum AllowedController
		{
			Both = 0,
			LeftOnly = 1,
			RightOnly = 2
		}

		public enum ValidDropTypes
		{
			NoDrop = 0,
			DropAnywhere = 1,
			DropValidSnapDropZone = 2
		}

		[Header("General Settings")]
		[Tooltip("If this is checked then the Interactable Object component will be disabled when the Interactable Object is not being interacted with.")]
		public bool disableWhenIdle = true;

		[Header("Near Touch Settings")]
		[Tooltip("Determines which controller can initiate a near touch action.")]
		public AllowedController allowedNearTouchControllers;

		[Header("Touch Settings")]
		[Tooltip("Determines which controller can initiate a touch action.")]
		public AllowedController allowedTouchControllers;

		[Tooltip("An array of colliders on the GameObject to ignore when being touched.")]
		public Collider[] ignoredColliders;

		[Header("Grab Settings")]
		[Tooltip("Determines if the Interactable Object can be grabbed.")]
		public bool isGrabbable;

		[Tooltip("If this is checked then the grab button on the controller needs to be continually held down to keep grabbing. If this is unchecked the grab button toggles the grab action with one button press to grab and another to release.")]
		public bool holdButtonToGrab = true;

		[Tooltip("If this is checked then the Interactable Object will stay grabbed to the controller when a teleport occurs. If it is unchecked then the Interactable Object will be released when a teleport occurs.")]
		public bool stayGrabbedOnTeleport = true;

		[Tooltip("Determines in what situation the Interactable Object can be dropped by the controller grab button.")]
		public ValidDropTypes validDrop = ValidDropTypes.DropAnywhere;

		[Tooltip("Setting to a button will ensure the override button is used to grab this specific Interactable Object. Setting to `Undefined` will mean the `Grab Button` on the Interact Grab script will grab the object.")]
		public VRTK_ControllerEvents.ButtonAlias grabOverrideButton;

		[Tooltip("Determines which controller can initiate a grab action.")]
		public AllowedController allowedGrabControllers;

		[Tooltip("This determines how the grabbed Interactable Object will be attached to the controller when it is grabbed. If one isn't provided then the first Grab Attach script on the GameObject will be used, if one is not found and the object is grabbable then a Fixed Joint Grab Attach script will be created at runtime.")]
		public VRTK_BaseGrabAttach grabAttachMechanicScript;

		[Tooltip("The script to utilise when processing the secondary controller action on a secondary grab attempt. If one isn't provided then the first Secondary Controller Grab Action script on the GameObject will be used, if one is not found then no action will be taken on secondary grab.")]
		public VRTK_BaseGrabAction secondaryGrabActionScript;

		[Header("Use Settings")]
		[Tooltip("Determines if the Interactable Object can be used.")]
		public bool isUsable;

		[Tooltip("If this is checked then the use button on the controller needs to be continually held down to keep using. If this is unchecked the the use button toggles the use action with one button press to start using and another to stop using.")]
		public bool holdButtonToUse = true;

		[Tooltip("If this is checked the Interactable Object can be used only if it is currently being grabbed.")]
		public bool useOnlyIfGrabbed;

		[Tooltip("If this is checked then when a Pointer collides with the Interactable Object it will activate it's use action. If the the `Hold Button To Use` parameter is unchecked then whilst the Pointer is collising with the Interactable Object it will run the `Using` method. If `Hold Button To Use` is unchecked then the `Using` method will be run when the Pointer is deactivated. The Pointer will not emit the `Destination Set` event if it is affecting an Interactable Object with this setting checked as this prevents unwanted teleporting from happening when using an Interactable Object with a pointer.")]
		public bool pointerActivatesUseAction;

		[Tooltip("Setting to a button will ensure the override button is used to use this specific Interactable Object. Setting to `Undefined` will mean the `Use Button` on the Interact Use script will use the object.")]
		public VRTK_ControllerEvents.ButtonAlias useOverrideButton;

		[Tooltip("Determines which controller can initiate a use action.")]
		public AllowedController allowedUseControllers;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_InteractableObject.objectHighlighter` has been replaced with `VRTK_InteractObjectHighlighter.objectHighlighter`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public VRTK_BaseHighlighter objectHighlighter;

		[Obsolete("`VRTK_InteractableObject.touchHighlightColor` has been replaced with `VRTK_InteractObjectHighlighter.touchHighlight`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public Color touchHighlightColor = Color.clear;

		protected Rigidbody interactableRigidbody;

		protected HashSet<GameObject> currentIgnoredColliders = new HashSet<GameObject>();

		protected HashSet<GameObject> hoveredSnapObjects = new HashSet<GameObject>();

		protected HashSet<GameObject> nearTouchingObjects = new HashSet<GameObject>();

		protected HashSet<GameObject> touchingObjects = new HashSet<GameObject>();

		protected List<GameObject> grabbingObjects = new List<GameObject>();

		protected VRTK_InteractUse usingObject;

		protected Transform trackPoint;

		protected bool customTrackPoint;

		protected Transform primaryControllerAttachPoint;

		protected Transform secondaryControllerAttachPoint;

		protected Transform previousParent;

		protected bool previousKinematicState;

		protected bool previousIsGrabbable;

		protected bool forcedDropped;

		protected bool forceDisabled;

		protected bool hoveredOverSnapDropZone;

		protected bool snappedInSnapDropZone;

		protected VRTK_SnapDropZone storedSnapDropZone;

		protected Vector3 previousLocalScale = Vector3.zero;

		protected bool startDisabled;

		[HideInInspector]
		public int usingState;

		public bool isKinematic
		{
			get
			{
				if (interactableRigidbody != null)
				{
					return interactableRigidbody.isKinematic;
				}
				return true;
			}
			set
			{
				if (interactableRigidbody != null)
				{
					interactableRigidbody.isKinematic = value;
				}
			}
		}

		public event InteractableObjectEventHandler InteractableObjectEnabled;

		public event InteractableObjectEventHandler InteractableObjectDisabled;

		public event InteractableObjectEventHandler InteractableObjectNearTouched;

		public event InteractableObjectEventHandler InteractableObjectNearUntouched;

		public event InteractableObjectEventHandler InteractableObjectTouched;

		public event InteractableObjectEventHandler InteractableObjectUntouched;

		public event InteractableObjectEventHandler InteractableObjectGrabbed;

		public event InteractableObjectEventHandler InteractableObjectUngrabbed;

		public event InteractableObjectEventHandler InteractableObjectUsed;

		public event InteractableObjectEventHandler InteractableObjectUnused;

		public event InteractableObjectEventHandler InteractableObjectEnteredSnapDropZone;

		public event InteractableObjectEventHandler InteractableObjectExitedSnapDropZone;

		public event InteractableObjectEventHandler InteractableObjectSnappedToDropZone;

		public event InteractableObjectEventHandler InteractableObjectUnsnappedFromDropZone;

		public virtual void OnInteractableObjectEnabled(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectEnabled != null)
			{
				this.InteractableObjectEnabled(this, e);
			}
		}

		public virtual void OnInteractableObjectDisabled(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectDisabled != null)
			{
				this.InteractableObjectDisabled(this, e);
			}
		}

		public virtual void OnInteractableObjectNearTouched(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectNearTouched != null)
			{
				this.InteractableObjectNearTouched(this, e);
			}
		}

		public virtual void OnInteractableObjectNearUntouched(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectNearUntouched != null)
			{
				this.InteractableObjectNearUntouched(this, e);
			}
		}

		public virtual void OnInteractableObjectTouched(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectTouched != null)
			{
				this.InteractableObjectTouched(this, e);
			}
		}

		public virtual void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectUntouched != null)
			{
				this.InteractableObjectUntouched(this, e);
			}
		}

		public virtual void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectGrabbed != null)
			{
				this.InteractableObjectGrabbed(this, e);
			}
		}

		public virtual void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectUngrabbed != null)
			{
				this.InteractableObjectUngrabbed(this, e);
			}
		}

		public virtual void OnInteractableObjectUsed(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectUsed != null)
			{
				this.InteractableObjectUsed(this, e);
			}
		}

		public virtual void OnInteractableObjectUnused(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectUnused != null)
			{
				this.InteractableObjectUnused(this, e);
			}
		}

		public virtual void OnInteractableObjectEnteredSnapDropZone(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectEnteredSnapDropZone != null)
			{
				this.InteractableObjectEnteredSnapDropZone(this, e);
			}
		}

		public virtual void OnInteractableObjectExitedSnapDropZone(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectExitedSnapDropZone != null)
			{
				this.InteractableObjectExitedSnapDropZone(this, e);
			}
		}

		public virtual void OnInteractableObjectSnappedToDropZone(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectSnappedToDropZone != null)
			{
				this.InteractableObjectSnappedToDropZone(this, e);
			}
		}

		public virtual void OnInteractableObjectUnsnappedFromDropZone(InteractableObjectEventArgs e)
		{
			if (this.InteractableObjectUnsnappedFromDropZone != null)
			{
				this.InteractableObjectUnsnappedFromDropZone(this, e);
			}
		}

		public InteractableObjectEventArgs SetInteractableObjectEvent(GameObject interactingObject)
		{
			InteractableObjectEventArgs result = default(InteractableObjectEventArgs);
			result.interactingObject = interactingObject;
			return result;
		}

		public virtual bool IsNearTouched()
		{
			if (!IsTouched())
			{
				return nearTouchingObjects.Count > 0;
			}
			return false;
		}

		public virtual bool IsTouched()
		{
			return touchingObjects.Count > 0;
		}

		public virtual bool IsGrabbed(GameObject grabbedBy = null)
		{
			if (grabbingObjects.Count > 0 && grabbedBy != null)
			{
				return grabbingObjects.Contains(grabbedBy);
			}
			return grabbingObjects.Count > 0;
		}

		public virtual bool IsUsing(GameObject usedBy = null)
		{
			if (usingObject != null && usedBy != null)
			{
				return usingObject.gameObject == usedBy;
			}
			return usingObject != null;
		}

		public virtual void StartNearTouching(VRTK_InteractNearTouch currentNearTouchingObject = null)
		{
			GameObject gameObject = ((currentNearTouchingObject != null) ? currentNearTouchingObject.gameObject : null);
			if (gameObject != null && nearTouchingObjects.Add(gameObject))
			{
				ToggleEnableState(state: true);
				OnInteractableObjectNearTouched(SetInteractableObjectEvent(gameObject));
			}
		}

		public virtual void StopNearTouching(VRTK_InteractNearTouch previousNearTouchingObject = null)
		{
			GameObject gameObject = ((previousNearTouchingObject != null) ? previousNearTouchingObject.gameObject : null);
			if (gameObject != null && nearTouchingObjects.Remove(gameObject))
			{
				OnInteractableObjectNearUntouched(SetInteractableObjectEvent(gameObject));
			}
		}

		public virtual void StartTouching(VRTK_InteractTouch currentTouchingObject = null)
		{
			GameObject gameObject = ((currentTouchingObject != null) ? currentTouchingObject.gameObject : null);
			if (gameObject != null)
			{
				IgnoreColliders(gameObject);
				if (touchingObjects.Add(gameObject))
				{
					ToggleEnableState(state: true);
					OnInteractableObjectTouched(SetInteractableObjectEvent(gameObject));
				}
			}
		}

		public virtual void StopTouching(VRTK_InteractTouch previousTouchingObject = null)
		{
			GameObject gameObject = ((previousTouchingObject != null) ? previousTouchingObject.gameObject : null);
			if (gameObject != null && touchingObjects.Remove(gameObject))
			{
				ResetUseState(gameObject);
				OnInteractableObjectUntouched(SetInteractableObjectEvent(gameObject));
			}
		}

		public virtual void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
		{
			GameObject gameObject = ((currentGrabbingObject != null) ? currentGrabbingObject.gameObject : null);
			ToggleEnableState(state: true);
			if (!IsGrabbed() || IsSwappable())
			{
				PrimaryControllerGrab(gameObject);
			}
			else
			{
				SecondaryControllerGrab(gameObject);
			}
			OnInteractableObjectGrabbed(SetInteractableObjectEvent(gameObject));
		}

		public virtual void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null)
		{
			GameObject gameObject = ((previousGrabbingObject != null) ? previousGrabbingObject.gameObject : null);
			GameObject secondaryGrabbingObject = GetSecondaryGrabbingObject();
			if (secondaryGrabbingObject == null || secondaryGrabbingObject != gameObject)
			{
				SecondaryControllerUngrab(secondaryGrabbingObject);
				PrimaryControllerUngrab(gameObject, secondaryGrabbingObject);
			}
			else
			{
				SecondaryControllerUngrab(gameObject);
			}
			OnInteractableObjectUngrabbed(SetInteractableObjectEvent(gameObject));
		}

		public virtual void StartUsing(VRTK_InteractUse currentUsingObject = null)
		{
			GameObject gameObject = ((currentUsingObject != null) ? currentUsingObject.gameObject : null);
			ToggleEnableState(state: true);
			if (IsUsing() && !IsUsing(gameObject))
			{
				ResetUsingObject();
			}
			OnInteractableObjectUsed(SetInteractableObjectEvent(gameObject));
			usingObject = currentUsingObject;
		}

		public virtual void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
		{
			GameObject interactableObjectEvent = ((previousUsingObject != null) ? previousUsingObject.gameObject : null);
			OnInteractableObjectUnused(SetInteractableObjectEvent(interactableObjectEvent));
			if (resetUsingObjectState)
			{
				ResetUsingObject();
			}
			usingState = 0;
			usingObject = null;
		}

		[Obsolete("`VRTK_InteractableObject.ToggleHighlight` has been replaced with `VRTK_InteractableObject.Highlight` and `VRTK_InteractableObject.Unhighlight`. This method will be removed in a future version of VRTK.")]
		public virtual void ToggleHighlight(bool toggle, Color? highlightColor = null)
		{
			if (toggle)
			{
				Highlight(highlightColor.HasValue ? highlightColor.Value : Color.clear);
			}
			else
			{
				Unhighlight();
			}
		}

		[Obsolete("`VRTK_InteractableObject.Highlight` has been replaced with `VRTK_InteractObjectHighlighter.Highlight`. This method will be removed in a future version of VRTK.")]
		public virtual void Highlight(Color highlightColor)
		{
			VRTK_InteractObjectHighlighter componentInChildren = GetComponentInChildren<VRTK_InteractObjectHighlighter>();
			if (componentInChildren != null)
			{
				componentInChildren.Highlight(highlightColor);
			}
		}

		[Obsolete("`VRTK_InteractableObject.Unhighlight` has been replaced with `VRTK_InteractObjectHighlighter.Unhighlight`. This method will be removed in a future version of VRTK.")]
		public virtual void Unhighlight()
		{
			VRTK_InteractObjectHighlighter componentInChildren = GetComponentInChildren<VRTK_InteractObjectHighlighter>();
			if (componentInChildren != null)
			{
				componentInChildren.Unhighlight();
			}
		}

		[Obsolete("`VRTK_InteractableObject.ResetHighlighter` has been replaced with `VRTK_InteractObjectHighlighter.ResetHighlighter`. This method will be removed in a future version of VRTK.")]
		public virtual void ResetHighlighter()
		{
			VRTK_InteractObjectHighlighter componentInChildren = GetComponentInChildren<VRTK_InteractObjectHighlighter>();
			if (componentInChildren != null)
			{
				componentInChildren.ResetHighlighter();
			}
		}

		public virtual void PauseCollisions(float delay)
		{
			if (delay > 0f)
			{
				Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].detectCollisions = false;
				}
				Invoke("UnpauseCollisions", delay);
			}
		}

		public virtual void ZeroVelocity()
		{
			if (interactableRigidbody != null)
			{
				interactableRigidbody.velocity = Vector3.zero;
				interactableRigidbody.angularVelocity = Vector3.zero;
			}
		}

		public virtual void SaveCurrentState()
		{
			if (!IsGrabbed() && !snappedInSnapDropZone)
			{
				previousParent = base.transform.parent;
				if (!IsSwappable())
				{
					previousIsGrabbable = isGrabbable;
				}
				if (interactableRigidbody != null)
				{
					previousKinematicState = interactableRigidbody.isKinematic;
				}
			}
		}

		public virtual void GetPreviousState(out Transform previousParent, out bool previousKinematic, out bool previousGrabbable)
		{
			previousParent = this.previousParent;
			previousKinematic = previousKinematicState;
			previousGrabbable = previousIsGrabbable;
		}

		public virtual void OverridePreviousState(Transform previousParent, bool previousKinematic, bool previousGrabbable)
		{
			this.previousParent = previousParent;
			previousKinematicState = previousKinematic;
			previousIsGrabbable = previousGrabbable;
		}

		public virtual List<GameObject> GetNearTouchingObjects()
		{
			return new List<GameObject>(nearTouchingObjects);
		}

		public virtual List<GameObject> GetTouchingObjects()
		{
			return new List<GameObject>(touchingObjects);
		}

		public virtual GameObject GetGrabbingObject()
		{
			if (!IsGrabbed())
			{
				return null;
			}
			return grabbingObjects[0];
		}

		public virtual GameObject GetSecondaryGrabbingObject()
		{
			if (grabbingObjects.Count <= 1)
			{
				return null;
			}
			return grabbingObjects[1];
		}

		public virtual GameObject GetUsingObject()
		{
			return usingObject.gameObject;
		}

		public virtual VRTK_InteractUse GetUsingScript()
		{
			return usingObject;
		}

		public virtual bool IsValidInteractableController(GameObject actualController, AllowedController controllerCheck)
		{
			if (controllerCheck == AllowedController.Both)
			{
				return true;
			}
			SDK_BaseController.ControllerHand controllerHandType = VRTK_DeviceFinder.GetControllerHandType(controllerCheck.ToString().Replace("Only", ""));
			return VRTK_DeviceFinder.IsControllerOfHand(actualController, controllerHandType);
		}

		public virtual void ForceStopInteracting()
		{
			if (base.gameObject.activeInHierarchy)
			{
				forceDisabled = false;
				StartCoroutine(ForceStopInteractingAtEndOfFrame());
			}
			if (!base.gameObject.activeInHierarchy && forceDisabled)
			{
				ForceStopAllInteractions();
				forceDisabled = false;
			}
		}

		public virtual void ForceStopSecondaryGrabInteraction()
		{
			GameObject secondaryGrabbingObject = GetSecondaryGrabbingObject();
			if (secondaryGrabbingObject != null)
			{
				secondaryGrabbingObject.GetComponentInChildren<VRTK_InteractGrab>().ForceRelease();
			}
		}

		public virtual void RegisterTeleporters()
		{
			StartCoroutine(RegisterTeleportersAtEndOfFrame());
		}

		public virtual void UnregisterTeleporters()
		{
			for (int i = 0; i < VRTK_ObjectCache.registeredTeleporters.Count; i++)
			{
				VRTK_BasicTeleport vRTK_BasicTeleport = VRTK_ObjectCache.registeredTeleporters[i];
				vRTK_BasicTeleport.Teleporting -= OnTeleporting;
				vRTK_BasicTeleport.Teleported -= OnTeleported;
			}
		}

		public virtual void StoreLocalScale()
		{
			previousLocalScale = base.transform.localScale;
		}

		public virtual void ToggleSnapDropZone(VRTK_SnapDropZone snapDropZone, bool state)
		{
			snappedInSnapDropZone = state;
			if (state)
			{
				storedSnapDropZone = snapDropZone;
				OnInteractableObjectSnappedToDropZone(SetInteractableObjectEvent(snapDropZone.gameObject));
				return;
			}
			if (interactableRigidbody != null)
			{
				interactableRigidbody.WakeUp();
			}
			ResetDropSnapType();
			OnInteractableObjectUnsnappedFromDropZone(SetInteractableObjectEvent(snapDropZone.gameObject));
		}

		public virtual bool IsInSnapDropZone()
		{
			return snappedInSnapDropZone;
		}

		public virtual void SetSnapDropZoneHover(VRTK_SnapDropZone snapDropZone, bool state)
		{
			if (state)
			{
				if (hoveredSnapObjects.Add(snapDropZone.gameObject))
				{
					OnInteractableObjectEnteredSnapDropZone(SetInteractableObjectEvent(snapDropZone.gameObject));
				}
			}
			else if (hoveredSnapObjects.Remove(snapDropZone.gameObject))
			{
				OnInteractableObjectExitedSnapDropZone(SetInteractableObjectEvent(snapDropZone.gameObject));
			}
			hoveredOverSnapDropZone = hoveredSnapObjects.Count > 0;
		}

		public virtual VRTK_SnapDropZone GetStoredSnapDropZone()
		{
			return storedSnapDropZone;
		}

		public virtual bool IsHoveredOverSnapDropZone()
		{
			return hoveredOverSnapDropZone;
		}

		public virtual bool IsDroppable()
		{
			switch (validDrop)
			{
			case ValidDropTypes.NoDrop:
				return false;
			case ValidDropTypes.DropAnywhere:
				return true;
			case ValidDropTypes.DropValidSnapDropZone:
				return hoveredOverSnapDropZone;
			default:
				return false;
			}
		}

		public virtual bool IsSwappable()
		{
			if (!(secondaryGrabActionScript != null))
			{
				return false;
			}
			return secondaryGrabActionScript.IsSwappable();
		}

		public virtual bool PerformSecondaryAction()
		{
			if (!(GetGrabbingObject() != null) || !(GetSecondaryGrabbingObject() == null) || !(secondaryGrabActionScript != null))
			{
				return false;
			}
			return secondaryGrabActionScript.IsActionable();
		}

		public virtual void ResetIgnoredColliders()
		{
			foreach (GameObject item in new HashSet<GameObject>(currentIgnoredColliders))
			{
				if (!(item != null))
				{
					continue;
				}
				Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
				if (ignoredColliders == null)
				{
					continue;
				}
				for (int i = 0; i < ignoredColliders.Length; i++)
				{
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						Physics.IgnoreCollision(componentsInChildren[j], ignoredColliders[i], ignore: false);
					}
				}
			}
			currentIgnoredColliders.Clear();
		}

		public virtual void SubscribeToInteractionEvent(InteractionType givenType, InteractableObjectEventHandler methodCallback)
		{
			ManageInteractionEvent(givenType, state: true, methodCallback);
		}

		public virtual void UnsubscribeFromInteractionEvent(InteractionType givenType, InteractableObjectEventHandler methodCallback)
		{
			ManageInteractionEvent(givenType, state: false, methodCallback);
		}

		public virtual Transform GetPrimaryAttachPoint()
		{
			return primaryControllerAttachPoint;
		}

		public virtual Transform GetSecondaryAttachPoint()
		{
			return secondaryControllerAttachPoint;
		}

		protected virtual void Awake()
		{
			interactableRigidbody = GetComponent<Rigidbody>();
			if (interactableRigidbody != null)
			{
				interactableRigidbody.maxAngularVelocity = float.MaxValue;
			}
			if (disableWhenIdle && base.enabled && IsIdle())
			{
				startDisabled = true;
				base.enabled = false;
			}
			if (touchHighlightColor != Color.clear && !GetComponent<VRTK_InteractObjectHighlighter>())
			{
				VRTK_InteractObjectHighlighter vRTK_InteractObjectHighlighter = base.gameObject.AddComponent<VRTK_InteractObjectHighlighter>();
				vRTK_InteractObjectHighlighter.touchHighlight = touchHighlightColor;
				vRTK_InteractObjectHighlighter.objectHighlighter = ((objectHighlighter == null) ? VRTK_BaseHighlighter.GetActiveHighlighter(base.gameObject) : objectHighlighter);
			}
		}

		protected virtual void OnEnable()
		{
			RegisterTeleporters();
			forceDisabled = false;
			if (forcedDropped)
			{
				LoadPreviousState();
			}
			forcedDropped = false;
			startDisabled = false;
			OnInteractableObjectEnabled(SetInteractableObjectEvent(null));
		}

		protected virtual void OnDisable()
		{
			UnregisterTeleporters();
			if (!startDisabled)
			{
				forceDisabled = true;
				ForceStopInteracting();
			}
			OnInteractableObjectDisabled(SetInteractableObjectEvent(null));
		}

		protected virtual void FixedUpdate()
		{
			if (trackPoint != null && grabAttachMechanicScript != null)
			{
				grabAttachMechanicScript.ProcessFixedUpdate();
			}
			if (secondaryGrabActionScript != null)
			{
				secondaryGrabActionScript.ProcessFixedUpdate();
			}
		}

		protected virtual void Update()
		{
			AttemptSetGrabMechanic();
			AttemptSetSecondaryGrabAction();
			if (trackPoint != null && grabAttachMechanicScript != null)
			{
				grabAttachMechanicScript.ProcessUpdate();
			}
			if (secondaryGrabActionScript != null)
			{
				secondaryGrabActionScript.ProcessUpdate();
			}
		}

		protected virtual bool IsIdle()
		{
			if (!IsNearTouched() && !IsTouched() && !IsGrabbed())
			{
				return !IsUsing();
			}
			return false;
		}

		protected virtual void LateUpdate()
		{
			if (disableWhenIdle && IsIdle())
			{
				ToggleEnableState(state: false);
			}
		}

		protected virtual void LoadPreviousState()
		{
			if (base.gameObject.activeInHierarchy)
			{
				base.transform.SetParent(previousParent);
				forcedDropped = false;
			}
			if (interactableRigidbody != null)
			{
				interactableRigidbody.isKinematic = previousKinematicState;
			}
			if (!IsSwappable())
			{
				isGrabbable = previousIsGrabbable;
			}
		}

		protected virtual void IgnoreColliders(GameObject touchingObject)
		{
			if (ignoredColliders == null || currentIgnoredColliders.Contains(touchingObject))
			{
				return;
			}
			bool flag = false;
			Collider[] componentsInChildren = touchingObject.GetComponentsInChildren<Collider>();
			for (int i = 0; i < ignoredColliders.Length; i++)
			{
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					Physics.IgnoreCollision(componentsInChildren[j], ignoredColliders[i]);
					flag = true;
				}
			}
			if (flag)
			{
				currentIgnoredColliders.Add(touchingObject);
			}
		}

		protected virtual void ToggleEnableState(bool state)
		{
			if (disableWhenIdle)
			{
				base.enabled = state;
			}
		}

		protected virtual void AttemptSetGrabMechanic()
		{
			if (isGrabbable && grabAttachMechanicScript == null)
			{
				VRTK_BaseGrabAttach vRTK_BaseGrabAttach = GetComponent<VRTK_BaseGrabAttach>();
				if (vRTK_BaseGrabAttach == null)
				{
					vRTK_BaseGrabAttach = base.gameObject.AddComponent<VRTK_FixedJointGrabAttach>();
				}
				grabAttachMechanicScript = vRTK_BaseGrabAttach;
			}
		}

		protected virtual void AttemptSetSecondaryGrabAction()
		{
			if (isGrabbable && secondaryGrabActionScript == null)
			{
				secondaryGrabActionScript = GetComponent<VRTK_BaseGrabAction>();
			}
		}

		protected virtual void ForceReleaseGrab()
		{
			GameObject grabbingObject = GetGrabbingObject();
			if (grabbingObject != null)
			{
				grabbingObject.GetComponentInChildren<VRTK_InteractGrab>().ForceRelease();
			}
		}

		protected virtual void PrimaryControllerGrab(GameObject currentGrabbingObject)
		{
			if (snappedInSnapDropZone)
			{
				ToggleSnapDropZone(storedSnapDropZone, state: false);
			}
			ForceReleaseGrab();
			RemoveTrackPoint();
			VRTK_SharedMethods.AddListValue(grabbingObjects, currentGrabbingObject, preventDuplicates: true);
			SetTrackPoint(currentGrabbingObject);
			if (!IsSwappable())
			{
				previousIsGrabbable = isGrabbable;
				isGrabbable = false;
			}
		}

		protected virtual void SecondaryControllerGrab(GameObject currentGrabbingObject)
		{
			if (VRTK_SharedMethods.AddListValue(grabbingObjects, currentGrabbingObject, preventDuplicates: true))
			{
				secondaryControllerAttachPoint = CreateAttachPoint(currentGrabbingObject.name, "Secondary", currentGrabbingObject.transform);
				if (secondaryGrabActionScript != null)
				{
					secondaryGrabActionScript.Initialise(this, GetGrabbingObject().GetComponentInChildren<VRTK_InteractGrab>(), GetSecondaryGrabbingObject().GetComponentInChildren<VRTK_InteractGrab>(), primaryControllerAttachPoint, secondaryControllerAttachPoint);
				}
			}
		}

		protected virtual void PrimaryControllerUngrab(GameObject previousGrabbingObject, GameObject previousSecondaryGrabbingObject)
		{
			UnpauseCollisions();
			RemoveTrackPoint();
			ResetUseState(previousGrabbingObject);
			grabbingObjects.Clear();
			if (secondaryGrabActionScript != null && previousSecondaryGrabbingObject != null)
			{
				secondaryGrabActionScript.OnDropAction();
				previousSecondaryGrabbingObject.GetComponentInChildren<VRTK_InteractGrab>().ForceRelease();
			}
			LoadPreviousState();
		}

		protected virtual void SecondaryControllerUngrab(GameObject previousGrabbingObject)
		{
			if (grabbingObjects.Remove(previousGrabbingObject))
			{
				UnityEngine.Object.Destroy(secondaryControllerAttachPoint.gameObject);
				secondaryControllerAttachPoint = null;
				if (secondaryGrabActionScript != null)
				{
					secondaryGrabActionScript.ResetAction();
				}
			}
		}

		protected virtual void UnpauseCollisions()
		{
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].detectCollisions = true;
			}
		}

		protected virtual void SetTrackPoint(GameObject currentGrabbingObject)
		{
			AddTrackPoint(currentGrabbingObject);
			primaryControllerAttachPoint = CreateAttachPoint(GetGrabbingObject().name, "Original", trackPoint);
			if (grabAttachMechanicScript != null)
			{
				grabAttachMechanicScript.SetTrackPoint(trackPoint);
				grabAttachMechanicScript.SetInitialAttachPoint(primaryControllerAttachPoint);
			}
		}

		protected virtual Transform CreateAttachPoint(string namePrefix, string nameSuffix, Transform origin)
		{
			Transform obj = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, namePrefix, nameSuffix, "Controller", "AttachPoint")).transform;
			obj.SetParent(base.transform);
			obj.position = origin.position;
			obj.rotation = origin.rotation;
			obj.localScale = Vector3.one;
			return obj;
		}

		protected virtual void AddTrackPoint(GameObject currentGrabbingObject)
		{
			VRTK_InteractGrab componentInChildren = currentGrabbingObject.GetComponentInChildren<VRTK_InteractGrab>();
			Transform controllerPoint = (((bool)componentInChildren && (bool)componentInChildren.controllerAttachPoint) ? componentInChildren.controllerAttachPoint.transform : currentGrabbingObject.transform);
			if (grabAttachMechanicScript != null)
			{
				trackPoint = grabAttachMechanicScript.CreateTrackPoint(controllerPoint, base.gameObject, currentGrabbingObject, ref customTrackPoint);
			}
		}

		protected virtual void RemoveTrackPoint()
		{
			if (customTrackPoint && trackPoint != null)
			{
				UnityEngine.Object.Destroy(trackPoint.gameObject);
			}
			else
			{
				trackPoint = null;
			}
			if (primaryControllerAttachPoint != null)
			{
				UnityEngine.Object.Destroy(primaryControllerAttachPoint.gameObject);
			}
		}

		protected virtual void OnTeleporting(object sender, DestinationMarkerEventArgs e)
		{
			if (!stayGrabbedOnTeleport)
			{
				ZeroVelocity();
				ForceStopAllInteractions();
			}
		}

		protected virtual void OnTeleported(object sender, DestinationMarkerEventArgs e)
		{
			if (grabAttachMechanicScript != null && grabAttachMechanicScript.IsTracked() && stayGrabbedOnTeleport && trackPoint != null)
			{
				GameObject actualController = VRTK_DeviceFinder.GetActualController(GetGrabbingObject());
				base.transform.position = (actualController ? actualController.transform.position : base.transform.position);
			}
		}

		protected virtual IEnumerator RegisterTeleportersAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			for (int i = 0; i < VRTK_ObjectCache.registeredTeleporters.Count; i++)
			{
				VRTK_BasicTeleport vRTK_BasicTeleport = VRTK_ObjectCache.registeredTeleporters[i];
				vRTK_BasicTeleport.Teleporting += OnTeleporting;
				vRTK_BasicTeleport.Teleported += OnTeleported;
			}
		}

		protected virtual void ResetUseState(GameObject checkObject)
		{
			if (checkObject != null)
			{
				VRTK_InteractUse componentInChildren = checkObject.GetComponentInChildren<VRTK_InteractUse>();
				if (componentInChildren != null && holdButtonToUse)
				{
					componentInChildren.ForceStopUsing();
				}
			}
		}

		protected virtual IEnumerator ForceStopInteractingAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			ForceStopAllInteractions();
		}

		protected virtual void ForceStopAllInteractions()
		{
			if (touchingObjects != null)
			{
				StopTouchingInteractions();
				StopGrabbingInteractions();
				StopUsingInteractions();
			}
		}

		protected virtual void StopTouchingInteractions()
		{
			foreach (GameObject item in new HashSet<GameObject>(touchingObjects))
			{
				if (item.activeInHierarchy || forceDisabled)
				{
					item.GetComponentInChildren<VRTK_InteractTouch>().ForceStopTouching();
				}
			}
		}

		protected virtual void StopGrabbingInteractions()
		{
			if (!IsDroppable())
			{
				return;
			}
			GameObject grabbingObject = GetGrabbingObject();
			if (grabbingObject != null && (grabbingObject.activeInHierarchy || forceDisabled))
			{
				VRTK_InteractGrab componentInChildren = grabbingObject.GetComponentInChildren<VRTK_InteractGrab>();
				if (componentInChildren != null && componentInChildren.interactTouch != null)
				{
					componentInChildren.interactTouch.ForceStopTouching();
					componentInChildren.ForceRelease();
					forcedDropped = true;
				}
			}
		}

		protected virtual void StopUsingInteractions()
		{
			if (usingObject != null && usingObject.interactTouch != null && (usingObject.gameObject.activeInHierarchy || forceDisabled))
			{
				usingObject.interactTouch.ForceStopTouching();
				usingObject.ForceStopUsing();
			}
		}

		protected virtual void ResetDropSnapType()
		{
			switch (storedSnapDropZone.snapType)
			{
			case VRTK_SnapDropZone.SnapTypes.UseKinematic:
			case VRTK_SnapDropZone.SnapTypes.UseParenting:
				LoadPreviousState();
				break;
			case VRTK_SnapDropZone.SnapTypes.UseJoint:
			{
				Joint component = storedSnapDropZone.GetComponent<Joint>();
				if ((bool)component)
				{
					component.connectedBody = null;
				}
				break;
			}
			}
			if (!previousLocalScale.Equals(Vector3.zero))
			{
				base.transform.localScale = previousLocalScale;
			}
			storedSnapDropZone.OnObjectUnsnappedFromDropZone(storedSnapDropZone.SetSnapDropZoneEvent(base.gameObject));
			storedSnapDropZone = null;
		}

		protected virtual void ResetUsingObject()
		{
			if (usingObject != null)
			{
				usingObject.ForceResetUsing();
			}
		}

		protected virtual void ManageInteractionEvent(InteractionType givenType, bool state, InteractableObjectEventHandler methodCallback)
		{
			switch (givenType)
			{
			case InteractionType.NearTouch:
				ManageNearTouchSubscriptions(state, methodCallback);
				break;
			case InteractionType.Touch:
				ManageTouchSubscriptions(state, methodCallback);
				break;
			case InteractionType.Grab:
				ManageGrabSubscriptions(state, methodCallback);
				break;
			case InteractionType.Use:
				ManageUseSubscriptions(state, methodCallback);
				break;
			case InteractionType.NearUntouch:
				ManageNearUntouchSubscriptions(state, methodCallback);
				break;
			case InteractionType.Untouch:
				ManageUntouchSubscriptions(state, methodCallback);
				break;
			case InteractionType.Ungrab:
				ManageUngrabSubscriptions(state, methodCallback);
				break;
			case InteractionType.Unuse:
				ManageUnuseSubscriptions(state, methodCallback);
				break;
			}
		}

		protected virtual void ManageNearTouchSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectNearTouched -= methodCallback;
			}
			if (register)
			{
				InteractableObjectNearTouched += methodCallback;
			}
		}

		protected virtual void ManageTouchSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectTouched -= methodCallback;
			}
			if (register)
			{
				InteractableObjectTouched += methodCallback;
			}
		}

		protected virtual void ManageGrabSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectGrabbed -= methodCallback;
			}
			if (register)
			{
				InteractableObjectGrabbed += methodCallback;
			}
		}

		protected virtual void ManageUseSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectUsed -= methodCallback;
			}
			if (register)
			{
				InteractableObjectUsed += methodCallback;
			}
		}

		protected virtual void ManageNearUntouchSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectNearUntouched -= methodCallback;
			}
			if (register)
			{
				InteractableObjectNearUntouched += methodCallback;
			}
		}

		protected virtual void ManageUntouchSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectUntouched -= methodCallback;
			}
			if (register)
			{
				InteractableObjectUntouched += methodCallback;
			}
		}

		protected virtual void ManageUngrabSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectUngrabbed -= methodCallback;
			}
			if (register)
			{
				InteractableObjectUngrabbed += methodCallback;
			}
		}

		protected virtual void ManageUnuseSubscriptions(bool register, InteractableObjectEventHandler methodCallback)
		{
			if (!register)
			{
				InteractableObjectUnused -= methodCallback;
			}
			if (register)
			{
				InteractableObjectUnused += methodCallback;
			}
		}
	}
}
