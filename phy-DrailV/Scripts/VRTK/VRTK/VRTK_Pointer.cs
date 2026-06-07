using System;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Pointers/VRTK_Pointer")]
	public class VRTK_Pointer : VRTK_DestinationMarker
	{
		[Header("Pointer Activation Settings")]
		[Tooltip("The specific renderer to use when the pointer is activated. The renderer also determines how the pointer reaches it's destination (e.g. straight line, bezier curve).")]
		public VRTK_BasePointerRenderer pointerRenderer;

		[Tooltip("The button used to activate/deactivate the pointer.")]
		public VRTK_ControllerEvents.ButtonAlias activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

		[Tooltip("If this is checked then the Activation Button needs to be continuously held down to keep the pointer active. If this is unchecked then the Activation Button works as a toggle, the first press/release enables the pointer and the second press/release disables the pointer.")]
		public bool holdButtonToActivate = true;

		[Tooltip("If this is checked then the pointer will be toggled on when the script is enabled.")]
		public bool activateOnEnable;

		[Tooltip("The time in seconds to delay the pointer being able to be active again.")]
		public float activationDelay;

		[Header("Pointer Selection Settings")]
		[Tooltip("The button used to execute the select action at the pointer's target position.")]
		public VRTK_ControllerEvents.ButtonAlias selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

		[Tooltip("If this is checked then the pointer selection action is executed when the Selection Button is pressed down. If this is unchecked then the selection action is executed when the Selection Button is released.")]
		public bool selectOnPress;

		[Tooltip("The time in seconds to delay the pointer being able to execute the select action again.")]
		public float selectionDelay;

		[Tooltip("The amount of time the pointer can be over the same collider before it automatically attempts to select it. 0f means no selection attempt will be made.")]
		public float selectAfterHoverDuration;

		[Header("Pointer Interaction Settings")]
		[Tooltip("If this is checked then the pointer will be an extension of the controller and able to interact with Interactable Objects.")]
		public bool interactWithObjects;

		[Tooltip("If `Interact With Objects` is checked and this is checked then when an object is grabbed with the pointer touching it, the object will attach to the pointer tip and not snap to the controller.")]
		public bool grabToPointerTip;

		[Header("Pointer Customisation Settings")]
		[Tooltip("An optional GameObject that determines what the pointer is to be attached to. If this is left blank then the GameObject the script is on will be used.")]
		public GameObject attachedTo;

		[Tooltip("An optional Controller Events that will be used to toggle the pointer. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_ControllerEvents controllerEvents;

		[Tooltip("An optional InteractUse script that will be used when using interactable objects with pointer. If this is left blank then it will attempt to get the InteractUse script from the same GameObject and if it cannot find one then it will attempt to get it from the attached controller.")]
		public VRTK_InteractUse interactUse;

		[Tooltip("A custom transform to use as the origin of the pointer. If no pointer origin transform is provided then the transform the script is attached to is used.")]
		public Transform customOrigin;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_Pointer.controller` has been replaced with `VRTK_Pointer.controllerEvents`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public VRTK_ControllerEvents controller;

		protected VRTK_ControllerEvents.ButtonAlias subscribedActivationButton;

		protected VRTK_ControllerEvents.ButtonAlias subscribedSelectionButton;

		protected bool currentSelectOnPress;

		protected float activateDelayTimer;

		protected float selectDelayTimer;

		protected float hoverDurationTimer;

		protected int currentActivationState;

		protected bool willDeactivate;

		protected bool wasActivated;

		protected VRTK_ControllerReference controllerReference;

		protected VRTK_InteractableObject pointerInteractableObject;

		protected Collider currentCollider;

		protected bool canClickOnHover;

		protected bool activationButtonPressed;

		protected bool selectionButtonPressed;

		protected bool attemptControllerSetup;

		protected VRTK_StraightPointerRenderer autogenPointerRenderer;

		public event ControllerInteractionEventHandler ActivationButtonPressed;

		public event ControllerInteractionEventHandler ActivationButtonReleased;

		public event ControllerInteractionEventHandler SelectionButtonPressed;

		public event ControllerInteractionEventHandler SelectionButtonReleased;

		public event DestinationMarkerEventHandler PointerStateValid;

		public event DestinationMarkerEventHandler PointerStateInvalid;

		public virtual void OnActivationButtonPressed(ControllerInteractionEventArgs e)
		{
			if (this.ActivationButtonPressed != null)
			{
				this.ActivationButtonPressed(this, e);
			}
		}

		public virtual void OnActivationButtonReleased(ControllerInteractionEventArgs e)
		{
			if (this.ActivationButtonReleased != null)
			{
				this.ActivationButtonReleased(this, e);
			}
		}

		public virtual void OnSelectionButtonPressed(ControllerInteractionEventArgs e)
		{
			if (this.SelectionButtonPressed != null)
			{
				this.SelectionButtonPressed(this, e);
			}
		}

		public virtual void OnSelectionButtonReleased(ControllerInteractionEventArgs e)
		{
			if (this.SelectionButtonReleased != null)
			{
				this.SelectionButtonReleased(this, e);
			}
		}

		public virtual void OnPointerStateValid()
		{
			if (this.PointerStateValid != null)
			{
				this.PointerStateValid(this, GetStateEventPayload());
			}
		}

		public virtual void OnPointerStateInvalid()
		{
			if (this.PointerStateInvalid != null)
			{
				this.PointerStateInvalid(this, GetStateEventPayload());
			}
		}

		public virtual bool IsActivationButtonPressed()
		{
			return activationButtonPressed;
		}

		public virtual bool IsSelectionButtonPressed()
		{
			return selectionButtonPressed;
		}

		public virtual void PointerEnter(RaycastHit givenHit)
		{
			if (base.enabled && givenHit.transform != null && (!ControllerRequired() || VRTK_ControllerReference.IsValid(controllerReference)))
			{
				SetHoverSelectionTimer(givenHit.collider);
				DestinationMarkerEventArgs e = SetDestinationMarkerEvent(givenHit.distance, givenHit.transform, givenHit, givenHit.point, controllerReference, forceDestinationPosition: false, GetCursorRotation());
				if (pointerRenderer != null && givenHit.collider != pointerRenderer.GetDestinationHit().collider)
				{
					OnDestinationMarkerEnter(e);
				}
				else
				{
					OnDestinationMarkerHover(e);
				}
				StartUseAction(givenHit.transform);
			}
		}

		public virtual void PointerExit(RaycastHit givenHit)
		{
			ResetHoverSelectionTimer(givenHit.collider);
			if (givenHit.transform != null && (!ControllerRequired() || VRTK_ControllerReference.IsValid(controllerReference)))
			{
				OnDestinationMarkerExit(SetDestinationMarkerEvent(givenHit.distance, givenHit.transform, givenHit, givenHit.point, controllerReference, forceDestinationPosition: false, GetCursorRotation()));
				StopUseAction();
			}
		}

		public virtual bool CanActivate()
		{
			return Time.time >= activateDelayTimer;
		}

		public virtual bool CanSelect()
		{
			return Time.time >= selectDelayTimer;
		}

		public virtual bool IsPointerActive()
		{
			return currentActivationState != 0;
		}

		public virtual void ResetActivationTimer(bool forceZero = false)
		{
			activateDelayTimer = (forceZero ? 0f : (Time.time + activationDelay));
		}

		public virtual void ResetSelectionTimer(bool forceZero = false)
		{
			selectDelayTimer = (forceZero ? 0f : (Time.time + selectionDelay));
		}

		public virtual void Toggle(bool state)
		{
			if (CanActivate() && !NoPointerRenderer() && !CanActivateOnToggleButton(state) && (!state || !IsPointerActive()) && (state || IsPointerActive()))
			{
				ManageActivationState(willDeactivate || state);
				pointerRenderer.Toggle(IsPointerActive(), state);
				willDeactivate = false;
				if (!state)
				{
					StopUseAction();
				}
			}
		}

		public virtual bool IsStateValid()
		{
			if (EnabledPointerRenderer())
			{
				return pointerRenderer.IsValidCollision();
			}
			return false;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected override void OnEnable()
		{
			controllerEvents = ((controller != null && controllerEvents == null) ? controller : controllerEvents);
			base.OnEnable();
			attachedTo = ((attachedTo == null) ? base.gameObject : attachedTo);
			if (!VRTK_PlayerObject.IsPlayerObject(base.gameObject))
			{
				VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.Pointer);
			}
			SetDefaultValues();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Toggle(state: false);
			if (pointerRenderer != null)
			{
				pointerRenderer.Toggle(pointerState: false, actualState: false);
			}
			UnsubscribeActivationButton();
			UnsubscribeSelectionButton();
			if (autogenPointerRenderer != null)
			{
				UnityEngine.Object.Destroy(autogenPointerRenderer);
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			AttemptControllerSetup();
			CheckButtonSubscriptions();
			HandleEnabledPointer();
		}

		protected virtual void SetDefaultValues()
		{
			SetupRenderer();
			activateDelayTimer = 0f;
			selectDelayTimer = 0f;
			hoverDurationTimer = 0f;
			currentActivationState = 0;
			wasActivated = false;
			willDeactivate = false;
			canClickOnHover = false;
			attemptControllerSetup = true;
		}

		protected virtual void AttemptControllerSetup()
		{
			if (attemptControllerSetup && FindController())
			{
				attemptControllerSetup = false;
				SetupController();
				SetupRenderer();
				if (activateOnEnable)
				{
					Toggle(state: true);
				}
			}
		}

		protected virtual void HandleEnabledPointer()
		{
			if (EnabledPointerRenderer())
			{
				pointerRenderer.InitalizePointer(this, targetListPolicy, navmeshData, headsetPositionCompensation);
				pointerRenderer.UpdateRenderer();
				if (!IsPointerActive())
				{
					bool state = pointerRenderer.IsVisible();
					pointerRenderer.ToggleInteraction(state);
				}
				CheckHoverSelect();
			}
			else
			{
				Toggle(state: false);
				currentActivationState = 0;
			}
		}

		protected virtual Quaternion? GetCursorRotation()
		{
			if (EnabledPointerRenderer() && pointerRenderer.directionIndicator != null && pointerRenderer.directionIndicator.gameObject.activeInHierarchy)
			{
				return pointerRenderer.directionIndicator.GetRotation();
			}
			return null;
		}

		protected virtual bool EnabledPointerRenderer()
		{
			if (pointerRenderer != null)
			{
				return pointerRenderer.enabled;
			}
			return false;
		}

		protected virtual bool NoPointerRenderer()
		{
			if (!(pointerRenderer == null))
			{
				return !pointerRenderer.enabled;
			}
			return true;
		}

		protected virtual bool CanActivateOnToggleButton(bool state)
		{
			int num;
			if (state && !holdButtonToActivate)
			{
				num = (IsPointerActive() ? 1 : 0);
				if (num != 0)
				{
					willDeactivate = true;
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		protected virtual bool ControllerRequired()
		{
			if (activationButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				return selectionButton != VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			return true;
		}

		protected virtual bool FindController()
		{
			controllerEvents = ((controllerEvents == null) ? GetComponentInParent<VRTK_ControllerEvents>() : controllerEvents);
			controllerReference = VRTK_ControllerReference.GetControllerReference((controllerEvents != null) ? controllerEvents.gameObject : null);
			if (ControllerRequired() && controllerEvents == null)
			{
				VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_Pointer", "VRTK_ControllerEvents", "the Controller Alias", ". To omit this warning, set the `Activation Button` and `Selection Button` to `Undefined`"));
				return false;
			}
			GetInteractUse();
			return true;
		}

		protected virtual void GetInteractUse()
		{
			interactUse = ((interactUse != null) ? interactUse : GetComponentInChildren<VRTK_InteractUse>());
			interactUse = ((interactUse == null && controllerEvents != null) ? controllerEvents.GetComponentInChildren<VRTK_InteractUse>() : interactUse);
		}

		protected virtual void SetupController()
		{
			if (controllerEvents != null)
			{
				CheckButtonMappingConflict();
				SubscribeSelectionButton();
				SubscribeActivationButton();
			}
		}

		protected virtual void SetupRenderer()
		{
			if (pointerRenderer == null)
			{
				pointerRenderer = GeneratePointerRenderer();
			}
			if (EnabledPointerRenderer())
			{
				pointerRenderer.InitalizePointer(this, targetListPolicy, navmeshData, headsetPositionCompensation);
			}
		}

		protected virtual VRTK_BasePointerRenderer GeneratePointerRenderer()
		{
			VRTK_BasePointerRenderer vRTK_BasePointerRenderer = GetComponentInChildren<VRTK_BasePointerRenderer>();
			if (vRTK_BasePointerRenderer == null)
			{
				vRTK_BasePointerRenderer = base.gameObject.AddComponent<VRTK_StraightPointerRenderer>();
				autogenPointerRenderer = (VRTK_StraightPointerRenderer)vRTK_BasePointerRenderer;
			}
			return vRTK_BasePointerRenderer;
		}

		protected virtual bool ButtonMappingIsUndefined(VRTK_ControllerEvents.ButtonAlias givenButton, VRTK_ControllerEvents.ButtonAlias givenSubscribedButton)
		{
			if (givenSubscribedButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				return givenButton == VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			return false;
		}

		protected virtual void CheckButtonMappingConflict()
		{
			if (activationButton == selectionButton)
			{
				if (selectOnPress && holdButtonToActivate)
				{
					VRTK_Logger.Warn("`Hold Button To Activate` and `Select On Press` cannot both be checked when using the same button for Activation and Selection. Fixing by setting `Select On Press` to `false`.");
				}
				if (!selectOnPress && !holdButtonToActivate)
				{
					VRTK_Logger.Warn("`Hold Button To Activate` and `Select On Press` cannot both be unchecked when using the same button for Activation and Selection. Fixing by setting `Select On Press` to `true`.");
				}
				selectOnPress = !holdButtonToActivate;
			}
		}

		protected virtual void CheckButtonSubscriptions()
		{
			CheckButtonMappingConflict();
			if (ButtonMappingIsUndefined(selectionButton, subscribedSelectionButton) || selectOnPress != currentSelectOnPress)
			{
				UnsubscribeSelectionButton();
			}
			if (selectionButton != subscribedSelectionButton)
			{
				SubscribeSelectionButton();
				UnsubscribeActivationButton();
			}
			if (ButtonMappingIsUndefined(activationButton, subscribedActivationButton))
			{
				UnsubscribeActivationButton();
			}
			if (activationButton != subscribedActivationButton)
			{
				SubscribeActivationButton();
			}
		}

		protected virtual void SubscribeActivationButton()
		{
			if (subscribedActivationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				UnsubscribeActivationButton();
			}
			if (controllerEvents != null)
			{
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, DoActivationButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, DoActivationButtonReleased);
				subscribedActivationButton = activationButton;
			}
		}

		protected virtual void UnsubscribeActivationButton()
		{
			if (controllerEvents != null && subscribedActivationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: true, DoActivationButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: false, DoActivationButtonReleased);
				subscribedActivationButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
		}

		protected virtual void PointerActivated()
		{
			if (EnabledPointerRenderer())
			{
				Toggle(state: true);
			}
		}

		protected virtual void PointerDeactivated()
		{
			if (EnabledPointerRenderer() && IsPointerActive())
			{
				Toggle(state: false);
			}
		}

		protected virtual void DoActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			controllerReference = e.controllerReference;
			OnActivationButtonPressed(controllerEvents.SetControllerEvent(ref activationButtonPressed, value: true));
			PointerActivated();
		}

		protected virtual void DoActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			controllerReference = e.controllerReference;
			PointerDeactivated();
			OnActivationButtonReleased(controllerEvents.SetControllerEvent(ref activationButtonPressed));
		}

		protected virtual void SubscribeSelectionButton()
		{
			if (subscribedSelectionButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				UnsubscribeSelectionButton();
			}
			if (controllerEvents != null)
			{
				controllerEvents.SubscribeToButtonAliasEvent(selectionButton, startEvent: true, DoSelectionButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(selectionButton, startEvent: false, DoSelectionButtonReleased);
				controllerEvents.SubscribeToButtonAliasEvent(selectionButton, selectOnPress, SelectionButtonAction);
				subscribedSelectionButton = selectionButton;
				currentSelectOnPress = selectOnPress;
			}
		}

		protected virtual void UnsubscribeSelectionButton()
		{
			if (controllerEvents != null && subscribedSelectionButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(selectionButton, startEvent: true, DoSelectionButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(selectionButton, startEvent: false, DoSelectionButtonReleased);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedSelectionButton, currentSelectOnPress, SelectionButtonAction);
				subscribedSelectionButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
		}

		protected virtual void DoSelectionButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			OnSelectionButtonPressed(controllerEvents.SetControllerEvent(ref selectionButtonPressed, value: true));
		}

		protected virtual void DoSelectionButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			OnSelectionButtonReleased(controllerEvents.SetControllerEvent(ref selectionButtonPressed));
		}

		protected virtual void SelectionButtonAction(object sender, ControllerInteractionEventArgs e)
		{
			controllerReference = e.controllerReference;
			ExecuteSelectionButtonAction();
		}

		protected virtual void ExecuteSelectionButtonAction()
		{
			if (EnabledPointerRenderer() && CanSelect() && (IsPointerActive() || wasActivated))
			{
				wasActivated = false;
				RaycastHit destinationHit = pointerRenderer.GetDestinationHit();
				AttemptUseOnSet(destinationHit.transform);
				if ((bool)destinationHit.transform && IsPointerActive() && pointerRenderer.ValidPlayArea() && !PointerActivatesUseAction(pointerInteractableObject) && pointerRenderer.IsValidCollision())
				{
					ResetHoverSelectionTimer(destinationHit.collider);
					ResetSelectionTimer();
					OnDestinationMarkerSet(SetDestinationMarkerEvent(destinationHit.distance, destinationHit.transform, destinationHit, destinationHit.point, controllerReference, forceDestinationPosition: false, GetCursorRotation()));
				}
			}
		}

		protected virtual bool CanResetActivationState(bool givenState)
		{
			if (givenState || !holdButtonToActivate)
			{
				if (givenState && !holdButtonToActivate)
				{
					return currentActivationState >= 2;
				}
				return false;
			}
			return true;
		}

		protected virtual void ManageActivationState(bool state)
		{
			if (state)
			{
				currentActivationState++;
			}
			wasActivated = currentActivationState == 2;
			if (CanResetActivationState(state))
			{
				currentActivationState = 0;
			}
		}

		protected virtual bool PointerActivatesUseAction(VRTK_InteractableObject givenInteractableObject)
		{
			if (givenInteractableObject != null && givenInteractableObject.pointerActivatesUseAction)
			{
				if (ControllerRequired())
				{
					return givenInteractableObject.IsValidInteractableController(controllerEvents.gameObject, givenInteractableObject.allowedUseControllers);
				}
				return true;
			}
			return false;
		}

		protected virtual void StartUseAction(Transform target)
		{
			pointerInteractableObject = target.GetComponent<VRTK_InteractableObject>();
			bool flag = (bool)pointerInteractableObject && pointerInteractableObject.useOnlyIfGrabbed && !pointerInteractableObject.IsGrabbed();
			if (interactUse != null && PointerActivatesUseAction(pointerInteractableObject) && pointerInteractableObject.holdButtonToUse && !flag && pointerInteractableObject.usingState == 0)
			{
				pointerInteractableObject.StartUsing(interactUse);
				pointerInteractableObject.usingState++;
			}
		}

		protected virtual void StopUseAction()
		{
			if (interactUse != null && PointerActivatesUseAction(pointerInteractableObject) && pointerInteractableObject.holdButtonToUse && pointerInteractableObject.IsUsing())
			{
				pointerInteractableObject.StopUsing(interactUse);
				pointerInteractableObject.usingState = 0;
			}
		}

		protected virtual void AttemptUseOnSet(Transform target)
		{
			if (pointerInteractableObject != null && target != null && interactUse != null && PointerActivatesUseAction(pointerInteractableObject))
			{
				if (pointerInteractableObject.IsUsing())
				{
					pointerInteractableObject.StopUsing(interactUse);
					pointerInteractableObject.usingState = 0;
				}
				else if (!pointerInteractableObject.holdButtonToUse)
				{
					pointerInteractableObject.StartUsing(interactUse);
					pointerInteractableObject.usingState++;
				}
			}
		}

		protected virtual void SetHoverSelectionTimer(Collider collider)
		{
			if (collider != currentCollider)
			{
				hoverDurationTimer = 0f;
			}
			if (selectAfterHoverDuration > 0f && hoverDurationTimer <= 0f)
			{
				canClickOnHover = true;
				hoverDurationTimer = selectAfterHoverDuration;
			}
			currentCollider = collider;
		}

		protected virtual void ResetHoverSelectionTimer(Collider collider)
		{
			canClickOnHover = false;
			hoverDurationTimer = ((collider == currentCollider) ? 0f : hoverDurationTimer);
		}

		protected virtual void CheckHoverSelect()
		{
			if (hoverDurationTimer > 0f)
			{
				hoverDurationTimer -= Time.deltaTime;
			}
			if (canClickOnHover && hoverDurationTimer <= 0f)
			{
				canClickOnHover = false;
				ExecuteSelectionButtonAction();
			}
		}

		protected virtual DestinationMarkerEventArgs GetStateEventPayload()
		{
			DestinationMarkerEventArgs result = default(DestinationMarkerEventArgs);
			if (EnabledPointerRenderer())
			{
				RaycastHit destinationHit = pointerRenderer.GetDestinationHit();
				return SetDestinationMarkerEvent(destinationHit.distance, destinationHit.transform, destinationHit, destinationHit.point, controllerReference, forceDestinationPosition: false, GetCursorRotation());
			}
			return result;
		}
	}
}
