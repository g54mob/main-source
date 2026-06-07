using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/UI/VRTK_UIPointer")]
	public class VRTK_UIPointer : MonoBehaviour
	{
		public enum ActivationMethods
		{
			HoldButton = 0,
			ToggleButton = 1,
			AlwaysOn = 2
		}

		public enum ClickMethods
		{
			ClickOnButtonUp = 0,
			ClickOnButtonDown = 1
		}

		[Header("Activation Settings")]
		[Tooltip("The button used to activate/deactivate the UI raycast for the pointer.")]
		public VRTK_ControllerEvents.ButtonAlias activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

		[Tooltip("Determines when the UI pointer should be active.")]
		public ActivationMethods activationMode;

		[Header("Selection Settings")]
		[Tooltip("The button used to execute the select action at the pointer's target position.")]
		public VRTK_ControllerEvents.ButtonAlias selectionButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;

		[Tooltip("Determines when the UI Click event action should happen.")]
		public ClickMethods clickMethod;

		[Tooltip("Determines whether the UI click action should be triggered when the pointer is deactivated. If the pointer is hovering over a clickable element then it will invoke the click action on that element. Note: Only works with `Click Method =  Click_On_Button_Up`")]
		public bool attemptClickOnDeactivate;

		[Tooltip("The amount of time the pointer can be over the same UI element before it automatically attempts to click it. 0f means no click attempt will be made.")]
		public float clickAfterHoverDuration;

		[Header("Customisation Settings")]
		[Tooltip("The maximum length the UI Raycast will reach.")]
		public float maximumLength = float.PositiveInfinity;

		[Tooltip("An optional GameObject that determines what the pointer is to be attached to. If this is left blank then the GameObject the script is on will be used.")]
		public GameObject attachedTo;

		[Tooltip("The Controller Events that will be used to toggle the pointer. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_ControllerEvents controllerEvents;

		[Tooltip("A custom transform to use as the origin of the pointer. If no pointer origin transform is provided then the transform the script is attached to is used.")]
		public Transform customOrigin;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_UIPointer.controller` has been replaced with `VRTK_UIPointer.controllerEvents`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public VRTK_ControllerEvents controller;

		[Obsolete("`VRTK_UIPointer.pointerOriginTransform` has been replaced with `VRTK_UIPointer.customOrigin`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public Transform pointerOriginTransform;

		[HideInInspector]
		public PointerEventData pointerEventData;

		[HideInInspector]
		public GameObject hoveringElement;

		[HideInInspector]
		public GameObject controllerRenderModel;

		[HideInInspector]
		public float hoverDurationTimer;

		[HideInInspector]
		public bool canClickOnHover;

		[HideInInspector]
		public GameObject autoActivatingCanvas;

		[HideInInspector]
		public bool collisionClick;

		protected static Dictionary<int, float> pointerLengths = new Dictionary<int, float>();

		protected bool pointerClicked;

		protected bool beamEnabledState;

		protected bool lastPointerPressState;

		protected bool lastPointerClickState;

		protected GameObject currentTarget;

		protected SDK_BaseController.ControllerHand cachedAttachedHand;

		protected Transform cachedPointerAttachPoint;

		protected EventSystem cachedEventSystem;

		protected VRTK_VRInputModule cachedVRInputModule;

		protected int enableFrameCount;

		protected bool ignoreNextSelectionButtonInteraction;

		public bool CanHover => enableFrameCount < Time.frameCount;

		public bool CanClickDown => !ignoreNextSelectionButtonInteraction;

		public bool CanClickUp => !ignoreNextSelectionButtonInteraction;

		public bool CanDrag => enableFrameCount < Time.frameCount;

		public bool CanScroll => enableFrameCount < Time.frameCount;

		public event ControllerInteractionEventHandler ActivationButtonPressed;

		public event ControllerInteractionEventHandler ActivationButtonReleased;

		public event ControllerInteractionEventHandler SelectionButtonPressed;

		public event ControllerInteractionEventHandler SelectionButtonReleased;

		public event UIPointerEventHandler UIPointerElementEnter;

		public event UIPointerEventHandler UIPointerElementExit;

		public event UIPointerEventHandler UIPointerElementClick;

		public event UIPointerEventHandler UIPointerElementDragStart;

		public event UIPointerEventHandler UIPointerElementDragEnd;

		public static float GetPointerLength(int pointerId)
		{
			return VRTK_SharedMethods.GetDictionaryValue(pointerLengths, pointerId, float.MaxValue);
		}

		public virtual void OnUIPointerElementEnter(UIPointerEventArgs e)
		{
			if (e.currentTarget != currentTarget)
			{
				ResetHoverTimer();
			}
			if (clickAfterHoverDuration > 0f && hoverDurationTimer <= 0f)
			{
				canClickOnHover = true;
				hoverDurationTimer = clickAfterHoverDuration;
			}
			currentTarget = e.currentTarget;
			if (this.UIPointerElementEnter != null)
			{
				this.UIPointerElementEnter(this, e);
			}
		}

		public virtual void OnUIPointerElementExit(UIPointerEventArgs e)
		{
			if (e.previousTarget == currentTarget)
			{
				ResetHoverTimer();
			}
			if (this.UIPointerElementExit != null)
			{
				this.UIPointerElementExit(this, e);
				if (attemptClickOnDeactivate && !e.isActive && (bool)e.previousTarget)
				{
					pointerEventData.pointerPress = e.previousTarget;
				}
			}
		}

		public virtual void OnUIPointerElementClick(UIPointerEventArgs e)
		{
			if (e.currentTarget == currentTarget)
			{
				ResetHoverTimer();
			}
			if (this.UIPointerElementClick != null)
			{
				this.UIPointerElementClick(this, e);
			}
		}

		public virtual void OnUIPointerElementDragStart(UIPointerEventArgs e)
		{
			if (this.UIPointerElementDragStart != null)
			{
				this.UIPointerElementDragStart(this, e);
			}
		}

		public virtual void OnUIPointerElementDragEnd(UIPointerEventArgs e)
		{
			if (this.UIPointerElementDragEnd != null)
			{
				this.UIPointerElementDragEnd(this, e);
			}
		}

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

		public virtual UIPointerEventArgs SetUIPointerEvent(RaycastResult currentRaycastResult, GameObject currentTarget, GameObject lastTarget = null)
		{
			UIPointerEventArgs result = default(UIPointerEventArgs);
			result.controllerReference = GetControllerReference();
			result.isActive = PointerActive();
			result.currentTarget = currentTarget;
			result.previousTarget = lastTarget;
			result.raycastResult = currentRaycastResult;
			return result;
		}

		public virtual VRTK_VRInputModule SetEventSystem(EventSystem eventSystem)
		{
			if (eventSystem == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_UIPointer", "EventSystem"));
				return null;
			}
			if (!(eventSystem is VRTK_EventSystem))
			{
				bool sendNavigationEvents = eventSystem.sendNavigationEvents;
				eventSystem = eventSystem.gameObject.AddComponent<VRTK_EventSystem>();
				eventSystem.sendNavigationEvents = sendNavigationEvents;
			}
			return eventSystem.GetComponent<VRTK_VRInputModule>();
		}

		public virtual void RemoveEventSystem()
		{
			VRTK_EventSystem vRTK_EventSystem = UnityEngine.Object.FindObjectOfType<VRTK_EventSystem>();
			if (vRTK_EventSystem == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_UIPointer", "EventSystem"));
			}
			else
			{
				UnityEngine.Object.Destroy(vRTK_EventSystem);
			}
		}

		public virtual bool PointerActive()
		{
			if (activationMode == ActivationMethods.AlwaysOn || autoActivatingCanvas != null)
			{
				return true;
			}
			if (activationMode == ActivationMethods.HoldButton)
			{
				return IsActivationButtonPressed();
			}
			pointerClicked = false;
			if (IsActivationButtonPressed() && !lastPointerPressState)
			{
				pointerClicked = true;
			}
			lastPointerPressState = controllerEvents != null && controllerEvents.IsButtonPressed(activationButton);
			if (pointerClicked)
			{
				beamEnabledState = !beamEnabledState;
			}
			return beamEnabledState;
		}

		public virtual bool IsActivationButtonPressed()
		{
			if (!(controllerEvents != null))
			{
				return false;
			}
			return controllerEvents.IsButtonPressed(activationButton);
		}

		public virtual bool IsSelectionButtonPressed()
		{
			if (!(controllerEvents != null))
			{
				return false;
			}
			return controllerEvents.IsButtonPressed(selectionButton);
		}

		public virtual bool ValidClick(bool checkLastClick, bool lastClickState = false)
		{
			bool flag = (collisionClick ? collisionClick : IsSelectionButtonPressed());
			bool result = ((!checkLastClick) ? flag : (flag && lastPointerClickState == lastClickState));
			lastPointerClickState = flag;
			return result;
		}

		public virtual Vector3 GetOriginPosition()
		{
			return ((customOrigin != null) ? customOrigin : GetPointerOriginTransform()).position;
		}

		public virtual Vector3 GetOriginForward()
		{
			return ((customOrigin != null) ? customOrigin : GetPointerOriginTransform()).forward;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			controllerEvents = ((controller != null && controllerEvents == null) ? controller : controllerEvents);
			customOrigin = ((pointerOriginTransform != null && customOrigin == null) ? pointerOriginTransform : customOrigin);
			attachedTo = ((attachedTo == null) ? base.gameObject : attachedTo);
			controllerEvents = ((controllerEvents != null) ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
			ConfigureEventSystem();
			pointerClicked = false;
			lastPointerPressState = false;
			lastPointerClickState = false;
			beamEnabledState = false;
			enableFrameCount = Time.frameCount;
			ignoreNextSelectionButtonInteraction = controllerEvents.IsButtonPressed(selectionButton);
			if (controllerEvents != null)
			{
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, DoActivationButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, DoActivationButtonReleased);
				controllerEvents.SubscribeToButtonAliasEvent(selectionButton, startEvent: true, DoSelectionButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(selectionButton, startEvent: false, DoSelectionButtonReleased);
			}
		}

		protected virtual void OnDisable()
		{
			if ((bool)cachedVRInputModule && cachedVRInputModule.pointers.Contains(this))
			{
				cachedVRInputModule.ClearPointerInteraction(this);
				cachedVRInputModule.pointers.Remove(this);
			}
			if (controllerEvents != null)
			{
				controllerEvents.UnsubscribeToButtonAliasEvent(activationButton, startEvent: true, DoActivationButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(activationButton, startEvent: false, DoActivationButtonReleased);
				controllerEvents.UnsubscribeToButtonAliasEvent(selectionButton, startEvent: true, DoSelectionButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(selectionButton, startEvent: false, DoSelectionButtonReleased);
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void LateUpdate()
		{
			if (controllerEvents != null)
			{
				pointerEventData.pointerId = (int)VRTK_ControllerReference.GetRealIndex(GetControllerReference());
				VRTK_SharedMethods.AddDictionaryValue(pointerLengths, pointerEventData.pointerId, maximumLength, overwriteExisting: true);
			}
			if (controllerRenderModel == null && VRTK_ControllerReference.IsValid(GetControllerReference()))
			{
				controllerRenderModel = VRTK_SDK_Bridge.GetControllerRenderModel(GetControllerReference());
			}
		}

		protected virtual void DoActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			OnActivationButtonPressed(controllerEvents.SetControllerEvent());
		}

		protected virtual void DoActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			OnActivationButtonReleased(controllerEvents.SetControllerEvent());
		}

		protected virtual void DoSelectionButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			OnSelectionButtonPressed(controllerEvents.SetControllerEvent());
		}

		protected virtual void DoSelectionButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			if (ignoreNextSelectionButtonInteraction)
			{
				StartCoroutine(AllowSelectionButtonReleased());
			}
			else
			{
				OnSelectionButtonReleased(controllerEvents.SetControllerEvent());
			}
		}

		private IEnumerator AllowSelectionButtonReleased()
		{
			yield return WaitFor.EndOfFrame;
			ignoreNextSelectionButtonInteraction = false;
		}

		protected virtual VRTK_ControllerReference GetControllerReference(GameObject reference = null)
		{
			reference = ((reference == null && controllerEvents != null) ? controllerEvents.gameObject : reference);
			return VRTK_ControllerReference.GetControllerReference(reference);
		}

		protected virtual Transform GetPointerOriginTransform()
		{
			VRTK_ControllerReference controllerReference = GetControllerReference(attachedTo);
			if (VRTK_ControllerReference.IsValid(controllerReference) && (cachedAttachedHand != controllerReference.hand || cachedPointerAttachPoint == null))
			{
				cachedPointerAttachPoint = controllerReference.model.transform.Find(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.AttachPoint, controllerReference.hand));
				cachedAttachedHand = controllerReference.hand;
			}
			if (!(cachedPointerAttachPoint != null))
			{
				return base.transform;
			}
			return cachedPointerAttachPoint;
		}

		protected virtual void ResetHoverTimer()
		{
			hoverDurationTimer = 0f;
			canClickOnHover = false;
		}

		protected virtual void ConfigureEventSystem()
		{
			if (cachedEventSystem == null)
			{
				cachedEventSystem = UnityEngine.Object.FindObjectOfType<EventSystem>();
			}
			if (cachedVRInputModule == null)
			{
				cachedVRInputModule = SetEventSystem(cachedEventSystem);
			}
			if (cachedEventSystem != null && cachedVRInputModule != null)
			{
				if (pointerEventData == null)
				{
					pointerEventData = new PointerEventData(cachedEventSystem);
				}
				if (!cachedVRInputModule.pointers.Contains(this))
				{
					cachedVRInputModule.pointers.Add(this);
				}
			}
		}
	}
}
