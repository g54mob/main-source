using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/VRTK_InteractObjectAppearance")]
	public class VRTK_InteractObjectAppearance : VRTK_InteractableListener
	{
		public enum ValidInteractingObject
		{
			Anything = 0,
			EitherController = 1,
			NeitherController = 2,
			LeftControllerOnly = 3,
			RightControllerOnly = 4
		}

		[Header("General Settings")]
		[Tooltip("The GameObject to affect the appearance of. If this is null then then the interacting object will be used (usually the controller).")]
		public GameObject objectToAffect;

		[SerializeField]
		[Tooltip("The Interactable Object to monitor for the interaction event (near touch/touch/grab/use).")]
		protected VRTK_InteractableObject objectToMonitor;

		[Header("Default Appearance Settings")]
		[Tooltip("If this is checked then the `Object To Affect` will be an active GameObject when the script is enabled. If it's unchecked then it will be disabled. This only takes effect if `Affect Interacting Object` is unticked.")]
		public bool gameObjectActiveByDefault = true;

		[Tooltip("If this is checked then the `Object To Affect` will have visible renderers when the script is enabled. If it's unchecked then it will have it's renderers disabled. This only takes effect if `Affect Interacting Object` is unticked.")]
		public bool rendererVisibleByDefault = true;

		[Header("Near Touch Appearance Settings")]
		[Tooltip("If this is checked then the `Object To Affect` will be an active GameObject when the `Object To Monitor` is near touched. If it's unchecked then it will be disabled on near touch.")]
		public bool gameObjectActiveOnNearTouch = true;

		[Tooltip("If this is checked then the `Object To Affect` will have visible renderers when the `Object To Monitor` is near touched. If it's unchecked then it will have it's renderers disabled on near touch.")]
		public bool rendererVisibleOnNearTouch = true;

		[Tooltip("The amount of time to wait before the near touch appearance settings are applied after the near touch event.")]
		public float nearTouchAppearanceDelay;

		[Tooltip("The amount of time to wait before the previous appearance settings are applied after the near untouch event.")]
		public float nearUntouchAppearanceDelay;

		[Tooltip("Determines what type of interacting object will affect the appearance of the `Object To Affect` after the near touch and near untouch event.")]
		public ValidInteractingObject validNearTouchInteractingObject;

		[Header("Touch Appearance Settings")]
		[Tooltip("If this is checked then the `Object To Affect` will be an active GameObject when the `Object To Monitor` is touched. If it's unchecked then it will be disabled on touch.")]
		public bool gameObjectActiveOnTouch = true;

		[Tooltip("If this is checked then the `Object To Affect` will have visible renderers when the `Object To Monitor` is touched. If it's unchecked then it will have it's renderers disabled on touch.")]
		public bool rendererVisibleOnTouch = true;

		[Tooltip("The amount of time to wait before the touch appearance settings are applied after the touch event.")]
		public float touchAppearanceDelay;

		[Tooltip("The amount of time to wait before the previous appearance settings are applied after the untouch event.")]
		public float untouchAppearanceDelay;

		[Tooltip("Determines what type of interacting object will affect the appearance of the `Object To Affect` after the touch/untouch event.")]
		public ValidInteractingObject validTouchInteractingObject;

		[Header("Grab Appearance Settings")]
		[Tooltip("If this is checked then the `Object To Affect` will be an active GameObject when the `Object To Monitor` is grabbed. If it's unchecked then it will be disabled on grab.")]
		public bool gameObjectActiveOnGrab = true;

		[Tooltip("If this is checked then the `Object To Affect` will have visible renderers when the `Object To Monitor` is grabbed. If it's unchecked then it will have it's renderers disabled on grab.")]
		public bool rendererVisibleOnGrab = true;

		[Tooltip("The amount of time to wait before the grab appearance settings are applied after the grab event.")]
		public float grabAppearanceDelay;

		[Tooltip("The amount of time to wait before the previous appearance settings are applied after the ungrab event.")]
		public float ungrabAppearanceDelay;

		[Tooltip("Determines what type of interacting object will affect the appearance of the `Object To Affect` after the grab/ungrab event.")]
		public ValidInteractingObject validGrabInteractingObject;

		[Header("Use Appearance Settings")]
		[Tooltip("If this is checked then the `Object To Affect` will be an active GameObject when the `Object To Monitor` is used. If it's unchecked then it will be disabled on use.")]
		public bool gameObjectActiveOnUse = true;

		[Tooltip("If this is checked then the `Object To Affect` will have visible renderers when the `Object To Monitor` is used. If it's unchecked then it will have it's renderers disabled on use.")]
		public bool rendererVisibleOnUse = true;

		[Tooltip("The amount of time to wait before the use appearance settings are applied after the use event.")]
		public float useAppearanceDelay;

		[Tooltip("The amount of time to wait before the previous appearance settings are applied after the unuse event.")]
		public float unuseAppearanceDelay;

		[Tooltip("Determines what type of interacting object will affect the appearance of the `Object To Affect` after the use/unuse event.")]
		public ValidInteractingObject validUseInteractingObject;

		protected Dictionary<GameObject, bool> currentRenderStates = new Dictionary<GameObject, bool>();

		protected Dictionary<GameObject, bool> currentGameObjectStates = new Dictionary<GameObject, bool>();

		protected Dictionary<GameObject, Coroutine> affectingRoutines = new Dictionary<GameObject, Coroutine>();

		protected HashSet<GameObject> nearTouchingObjects = new HashSet<GameObject>();

		protected HashSet<GameObject> touchingObjects = new HashSet<GameObject>();

		public event InteractObjectAppearanceEventHandler GameObjectEnabled;

		public event InteractObjectAppearanceEventHandler GameObjectDisabled;

		public event InteractObjectAppearanceEventHandler RenderersEnabled;

		public event InteractObjectAppearanceEventHandler RenderersDisabled;

		public virtual void OnGameObjectEnabled(InteractObjectAppearanceEventArgs e)
		{
			if (this.GameObjectEnabled != null)
			{
				this.GameObjectEnabled(this, e);
			}
		}

		public virtual void OnGameObjectDisabled(InteractObjectAppearanceEventArgs e)
		{
			if (this.GameObjectDisabled != null)
			{
				this.GameObjectDisabled(this, e);
			}
		}

		public virtual void OnRenderersEnabled(InteractObjectAppearanceEventArgs e)
		{
			if (this.RenderersEnabled != null)
			{
				this.RenderersEnabled(this, e);
			}
		}

		public virtual void OnRenderersDisabled(InteractObjectAppearanceEventArgs e)
		{
			if (this.RenderersDisabled != null)
			{
				this.RenderersDisabled(this, e);
			}
		}

		protected virtual void OnEnable()
		{
			currentRenderStates.Clear();
			currentGameObjectStates.Clear();
			affectingRoutines.Clear();
			nearTouchingObjects.Clear();
			touchingObjects.Clear();
			EnableListeners();
			if (objectToAffect != null)
			{
				ToggleState(objectToAffect, gameObjectActiveByDefault, rendererVisibleByDefault, VRTK_InteractableObject.InteractionType.None);
			}
		}

		protected virtual void OnDisable()
		{
			DisableListeners();
			CancelRoutines();
		}

		protected override bool SetupListeners(bool throwError)
		{
			objectToMonitor = ((objectToMonitor == null) ? GetComponentInParent<VRTK_InteractableObject>() : objectToMonitor);
			if (objectToMonitor != null)
			{
				objectToMonitor.InteractableObjectDisabled += InteractableObjectDisabled;
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.NearTouch, InteractableObjectNearTouched);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.NearUntouch, InteractableObjectNearUntouched);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, InteractableObjectTouched);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, InteractableObjectUntouched);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, InteractableObjectGrabbed);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, InteractableObjectUngrabbed);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Use, InteractableObjectUsed);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Unuse, InteractableObjectUnused);
				return true;
			}
			if (throwError)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_InteractObjectAppearance", "VRTK_InteractableObject", "objectToMonitor", "current or parent"));
			}
			return false;
		}

		protected override void TearDownListeners()
		{
			if (objectToMonitor != null)
			{
				RestoreDefaults();
				objectToMonitor.InteractableObjectDisabled -= InteractableObjectDisabled;
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, InteractableObjectTouched);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, InteractableObjectUntouched);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, InteractableObjectGrabbed);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, InteractableObjectUngrabbed);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Use, InteractableObjectUsed);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Unuse, InteractableObjectUnused);
			}
		}

		protected virtual InteractObjectAppearanceEventArgs SetPayload(GameObject affectingObject, VRTK_InteractableObject.InteractionType interactionType)
		{
			InteractObjectAppearanceEventArgs result = default(InteractObjectAppearanceEventArgs);
			result.affectingObject = affectingObject;
			result.monitoringObject = objectToMonitor;
			result.objectToIgnore = ObjectToIgnore();
			result.interactionType = interactionType;
			return result;
		}

		protected virtual void RestoreDefaults()
		{
			if (!(objectToMonitor != null) || !objectToMonitor.IsTouched())
			{
				return;
			}
			foreach (GameObject item in new HashSet<GameObject>(touchingObjects))
			{
				ToggleState(item, gameObjectActiveByDefault, rendererVisibleByDefault, VRTK_InteractableObject.InteractionType.None);
			}
			foreach (GameObject item2 in new HashSet<GameObject>(nearTouchingObjects))
			{
				ToggleState(item2, gameObjectActiveByDefault, rendererVisibleByDefault, VRTK_InteractableObject.InteractionType.None);
			}
		}

		protected virtual GameObject ObjectToIgnore()
		{
			if (!(objectToAffect == null))
			{
				return null;
			}
			return objectToMonitor.gameObject;
		}

		protected virtual void EmitRenderEvent(GameObject objectToToggle, bool rendererShow, VRTK_InteractableObject.InteractionType interactionType)
		{
			if (rendererShow)
			{
				OnRenderersEnabled(SetPayload(objectToToggle, interactionType));
			}
			else
			{
				OnRenderersDisabled(SetPayload(objectToToggle, interactionType));
			}
		}

		protected virtual void EmitGameObjectEvent(GameObject objectToToggle, bool gameObjectShow, VRTK_InteractableObject.InteractionType interactionType)
		{
			if (gameObjectShow)
			{
				OnGameObjectEnabled(SetPayload(objectToToggle, interactionType));
			}
			else
			{
				OnGameObjectDisabled(SetPayload(objectToToggle, interactionType));
			}
		}

		protected virtual void ToggleState(GameObject objectToToggle, bool gameObjectShow, bool rendererShow, VRTK_InteractableObject.InteractionType interactionType)
		{
			if (objectToToggle != null)
			{
				if (!currentRenderStates.ContainsKey(objectToToggle) || currentRenderStates[objectToToggle] != rendererShow)
				{
					VRTK_ObjectAppearance.ToggleRenderer(rendererShow, objectToToggle, ObjectToIgnore());
					EmitRenderEvent(objectToToggle, rendererShow, interactionType);
				}
				if (!currentGameObjectStates.ContainsKey(objectToToggle) || currentGameObjectStates[objectToToggle] != gameObjectShow)
				{
					objectToToggle.SetActive(gameObjectShow);
					EmitGameObjectEvent(objectToToggle, gameObjectShow, interactionType);
				}
				VRTK_SharedMethods.AddDictionaryValue(currentRenderStates, objectToToggle, rendererShow, overwriteExisting: true);
				VRTK_SharedMethods.AddDictionaryValue(currentGameObjectStates, objectToToggle, gameObjectShow, overwriteExisting: true);
			}
		}

		protected virtual IEnumerator ToggleStateAfterTime(GameObject objectToToggle, bool gameObjectShow, bool rendererShow, float delayTime, VRTK_InteractableObject.InteractionType interactionType)
		{
			yield return new WaitForSeconds(delayTime);
			ToggleState(objectToToggle, gameObjectShow, rendererShow, interactionType);
		}

		protected virtual void CancelRoutines(GameObject currentAffectingObject = null)
		{
			if (currentAffectingObject != null)
			{
				Coroutine dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(affectingRoutines, currentAffectingObject);
				if (dictionaryValue != null)
				{
					StopCoroutine(dictionaryValue);
				}
				return;
			}
			foreach (KeyValuePair<GameObject, Coroutine> affectingRoutine in affectingRoutines)
			{
				if (currentAffectingObject == affectingRoutine.Key && affectingRoutine.Value != null)
				{
					StopCoroutine(affectingRoutine.Value);
				}
			}
		}

		protected virtual GameObject GetActualController(GameObject givenObject)
		{
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(givenObject);
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				return controllerReference.actual;
			}
			return givenObject;
		}

		protected virtual void InteractableObjectDisabled(object sender, InteractableObjectEventArgs e)
		{
			if (objectToMonitor != null && !objectToMonitor.gameObject.activeInHierarchy)
			{
				RestoreDefaults();
			}
		}

		protected virtual bool IsValidInteractingObject(GameObject givenObject, ValidInteractingObject givenInteractingObjectValidType)
		{
			if (base.gameObject.activeInHierarchy)
			{
				VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(givenObject);
				switch (givenInteractingObjectValidType)
				{
				case ValidInteractingObject.Anything:
					return true;
				case ValidInteractingObject.EitherController:
					return VRTK_ControllerReference.IsValid(controllerReference);
				case ValidInteractingObject.NeitherController:
					return !VRTK_ControllerReference.IsValid(controllerReference);
				case ValidInteractingObject.LeftControllerOnly:
					if (VRTK_ControllerReference.IsValid(controllerReference))
					{
						return controllerReference.hand == SDK_BaseController.ControllerHand.Left;
					}
					return false;
				case ValidInteractingObject.RightControllerOnly:
					if (VRTK_ControllerReference.IsValid(controllerReference))
					{
						return controllerReference.hand == SDK_BaseController.ControllerHand.Right;
					}
					return false;
				}
			}
			return false;
		}

		protected virtual void InteractableObjectNearTouched(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validNearTouchInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				nearTouchingObjects.Add(gameObject);
				VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnNearTouch, rendererVisibleOnNearTouch, nearTouchAppearanceDelay, VRTK_InteractableObject.InteractionType.NearTouch)), overwriteExisting: true);
			}
		}

		protected virtual void InteractableObjectNearUntouched(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validNearTouchInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				nearTouchingObjects.Remove(gameObject);
				VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveByDefault, rendererVisibleByDefault, nearUntouchAppearanceDelay, VRTK_InteractableObject.InteractionType.NearUntouch)), overwriteExisting: true);
			}
		}

		protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validTouchInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				touchingObjects.Add(gameObject);
				VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnTouch, rendererVisibleOnTouch, touchAppearanceDelay, VRTK_InteractableObject.InteractionType.Touch)), overwriteExisting: true);
			}
		}

		protected virtual void InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validTouchInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				touchingObjects.Remove(gameObject);
				if (objectToMonitor.IsNearTouched())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnNearTouch, rendererVisibleOnNearTouch, untouchAppearanceDelay, VRTK_InteractableObject.InteractionType.NearTouch)), overwriteExisting: true);
				}
				else
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveByDefault, rendererVisibleByDefault, untouchAppearanceDelay, VRTK_InteractableObject.InteractionType.Untouch)), overwriteExisting: true);
				}
			}
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validGrabInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnGrab, rendererVisibleOnGrab, grabAppearanceDelay, VRTK_InteractableObject.InteractionType.Grab)), overwriteExisting: true);
			}
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validGrabInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				if (objectToMonitor.IsUsing())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnUse, rendererVisibleOnUse, ungrabAppearanceDelay, VRTK_InteractableObject.InteractionType.Ungrab)), overwriteExisting: true);
				}
				else if (objectToMonitor.IsTouched())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnTouch, rendererVisibleOnTouch, ungrabAppearanceDelay, VRTK_InteractableObject.InteractionType.Ungrab)), overwriteExisting: true);
				}
				else if (objectToMonitor.IsNearTouched())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnNearTouch, rendererVisibleOnNearTouch, ungrabAppearanceDelay, VRTK_InteractableObject.InteractionType.NearTouch)), overwriteExisting: true);
				}
				else
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveByDefault, rendererVisibleByDefault, ungrabAppearanceDelay, VRTK_InteractableObject.InteractionType.Ungrab)), overwriteExisting: true);
				}
			}
		}

		protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validUseInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnUse, rendererVisibleOnUse, useAppearanceDelay, VRTK_InteractableObject.InteractionType.Use)), overwriteExisting: true);
			}
		}

		protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
		{
			if (IsValidInteractingObject(e.interactingObject, validUseInteractingObject))
			{
				GameObject gameObject = ((objectToAffect == null) ? GetActualController(e.interactingObject) : objectToAffect);
				CancelRoutines(gameObject);
				if (objectToMonitor.IsGrabbed())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnGrab, rendererVisibleOnGrab, unuseAppearanceDelay, VRTK_InteractableObject.InteractionType.Unuse)), overwriteExisting: true);
				}
				else if (objectToMonitor.IsTouched())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnTouch, rendererVisibleOnTouch, unuseAppearanceDelay, VRTK_InteractableObject.InteractionType.Unuse)), overwriteExisting: true);
				}
				else if (objectToMonitor.IsNearTouched())
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveOnNearTouch, rendererVisibleOnNearTouch, unuseAppearanceDelay, VRTK_InteractableObject.InteractionType.NearTouch)), overwriteExisting: true);
				}
				else
				{
					VRTK_SharedMethods.AddDictionaryValue(affectingRoutines, gameObject, StartCoroutine(ToggleStateAfterTime(gameObject, gameObjectActiveByDefault, rendererVisibleByDefault, unuseAppearanceDelay, VRTK_InteractableObject.InteractionType.Unuse)), overwriteExisting: true);
				}
			}
		}
	}
}
