using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_InteractTouch")]
	public class VRTK_InteractTouch : MonoBehaviour
	{
		[Tooltip("An optional GameObject that contains the compound colliders to represent the touching object. If this is empty then the collider will be auto generated at runtime to match the SDK default controller.")]
		public GameObject customColliderContainer;

		protected GameObject touchedObject;

		protected List<Collider> touchedObjectColliders = new List<Collider>();

		protected List<Collider> touchedObjectActiveColliders = new List<Collider>();

		protected GameObject controllerCollisionDetector;

		protected bool destroyColliderOnDisable;

		protected bool triggerIsColliding;

		protected bool triggerWasColliding;

		protected bool rigidBodyForcedActive;

		protected Rigidbody touchRigidBody;

		protected VRTK_TrackedController trackedController;

		protected VRTK_ControllerReference controllerReference => VRTK_ControllerReference.GetControllerReference(base.gameObject);

		public event ObjectInteractEventHandler ControllerStartTouchInteractableObject;

		public event ObjectInteractEventHandler ControllerTouchInteractableObject;

		public event ObjectInteractEventHandler ControllerStartUntouchInteractableObject;

		public event ObjectInteractEventHandler ControllerUntouchInteractableObject;

		public event ObjectInteractEventHandler ControllerRigidbodyActivated;

		public event ObjectInteractEventHandler ControllerRigidbodyDeactivated;

		public virtual void OnControllerStartTouchInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartTouchInteractableObject != null)
			{
				this.ControllerStartTouchInteractableObject(this, e);
			}
		}

		public virtual void OnControllerTouchInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerTouchInteractableObject != null)
			{
				this.ControllerTouchInteractableObject(this, e);
			}
		}

		public virtual void OnControllerStartUntouchInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerStartUntouchInteractableObject != null)
			{
				this.ControllerStartUntouchInteractableObject(this, e);
			}
		}

		public virtual void OnControllerUntouchInteractableObject(ObjectInteractEventArgs e)
		{
			if (this.ControllerUntouchInteractableObject != null)
			{
				this.ControllerUntouchInteractableObject(this, e);
			}
		}

		public virtual void OnControllerRigidbodyActivated(ObjectInteractEventArgs e)
		{
			if (this.ControllerRigidbodyActivated != null)
			{
				this.ControllerRigidbodyActivated(this, e);
			}
		}

		public virtual void OnControllerRigidbodyDeactivated(ObjectInteractEventArgs e)
		{
			if (this.ControllerRigidbodyDeactivated != null)
			{
				this.ControllerRigidbodyDeactivated(this, e);
			}
		}

		public virtual ObjectInteractEventArgs SetControllerInteractEvent(GameObject target)
		{
			ObjectInteractEventArgs result = default(ObjectInteractEventArgs);
			result.controllerReference = controllerReference;
			result.target = target;
			return result;
		}

		public virtual void ForceTouch(GameObject obj)
		{
			Collider collider = ((obj != null) ? obj.GetComponentInChildren<Collider>() : null);
			if (collider != null)
			{
				OnTriggerStay(collider);
			}
		}

		public virtual GameObject GetTouchedObject()
		{
			return touchedObject;
		}

		public virtual bool IsObjectInteractable(GameObject obj)
		{
			if (obj != null)
			{
				VRTK_InteractableObject componentInParent = obj.GetComponentInParent<VRTK_InteractableObject>();
				if (componentInParent != null)
				{
					if (componentInParent.disableWhenIdle && !componentInParent.enabled)
					{
						return true;
					}
					return componentInParent.enabled;
				}
			}
			return false;
		}

		public virtual void ToggleControllerRigidBody(bool state, bool forceToggle = false)
		{
			if (controllerCollisionDetector != null && touchRigidBody != null)
			{
				touchRigidBody.isKinematic = !state;
				rigidBodyForcedActive = forceToggle;
				Collider[] componentsInChildren = controllerCollisionDetector.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].isTrigger = !state;
				}
				EmitControllerRigidbodyEvent(state);
			}
		}

		public virtual bool IsRigidBodyActive()
		{
			return !touchRigidBody.isKinematic;
		}

		public virtual bool IsRigidBodyForcedActive()
		{
			if (IsRigidBodyActive())
			{
				return rigidBodyForcedActive;
			}
			return false;
		}

		public virtual void ForceStopTouching()
		{
			if (touchedObject != null)
			{
				StopTouching(touchedObject);
			}
		}

		public virtual Collider[] ControllerColliders()
		{
			if (!(controllerCollisionDetector != null))
			{
				return new Collider[0];
			}
			return controllerCollisionDetector.GetComponentsInChildren<Collider>();
		}

		public virtual SDK_BaseController.ControllerType GetControllerType()
		{
			if (!(trackedController != null))
			{
				return SDK_BaseController.ControllerType.Undefined;
			}
			return trackedController.GetControllerType();
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			destroyColliderOnDisable = false;
			controllerCollisionDetector = ((customColliderContainer != null) ? customColliderContainer : controllerCollisionDetector);
			VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.Controller);
			CreateTouchRigidBody();
			trackedController = GetComponentInParent<VRTK_TrackedController>();
			if (trackedController != null)
			{
				trackedController.ControllerModelAvailable += DoControllerModelAvailable;
			}
			CreateTouchCollider();
		}

		protected virtual void OnDisable()
		{
			ForceStopTouching();
			DestroyTouchCollider();
			if (trackedController != null)
			{
				trackedController.ControllerModelAvailable -= DoControllerModelAvailable;
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			GameObject gameObject = TriggerStart(collider);
			VRTK_InteractableObject vRTK_InteractableObject = ((touchedObject != null) ? touchedObject.GetComponent<VRTK_InteractableObject>() : null);
			if (touchedObject != null && gameObject != null && touchedObject != gameObject && vRTK_InteractableObject != null && !vRTK_InteractableObject.IsGrabbed())
			{
				ForceStopTouching();
				triggerIsColliding = true;
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			touchedObjectActiveColliders.Remove(collider);
		}

		protected virtual void OnTriggerStay(Collider collider)
		{
			GameObject gameObject = TriggerStart(collider);
			if (touchedObject == null || collider.transform.IsChildOf(touchedObject.transform))
			{
				triggerIsColliding = true;
			}
			bool flag = false;
			if ((bool)touchedObject)
			{
				VRTK_InteractableObject component = touchedObject.GetComponent<VRTK_InteractableObject>();
				flag = !component.IsValidInteractableController(base.gameObject, component.allowedTouchControllers);
			}
			if ((touchedObject == null || flag) && gameObject != null && IsObjectInteractable(collider.gameObject))
			{
				touchedObject = gameObject;
				VRTK_InteractableObject component2 = touchedObject.GetComponent<VRTK_InteractableObject>();
				if (component2 != null && !component2.IsValidInteractableController(base.gameObject, component2.allowedTouchControllers))
				{
					CleanupEndTouch();
					return;
				}
				OnControllerStartTouchInteractableObject(SetControllerInteractEvent(touchedObject));
				StoreTouchedObjectColliders(collider);
				ToggleControllerVisibility(visible: false);
				component2.StartTouching(this);
				OnControllerTouchInteractableObject(SetControllerInteractEvent(touchedObject));
			}
		}

		protected virtual void FixedUpdate()
		{
			if (!triggerIsColliding && !triggerWasColliding)
			{
				CheckStopTouching();
			}
			triggerWasColliding = triggerIsColliding;
			triggerIsColliding = false;
		}

		protected virtual void LateUpdate()
		{
			if (touchedObjectActiveColliders.Count == 0)
			{
				CheckStopTouching();
			}
		}

		protected virtual void DoControllerModelAvailable(object sender, VRTKTrackedControllerEventArgs e)
		{
			CreateTouchCollider();
		}

		protected virtual GameObject GetColliderInteractableObject(Collider collider)
		{
			VRTK_InteractableObject componentInParent = collider.GetComponentInParent<VRTK_InteractableObject>();
			if (!(componentInParent != null))
			{
				return null;
			}
			return componentInParent.gameObject;
		}

		protected virtual void AddActiveCollider(Collider collider)
		{
			if (touchedObject != null && touchedObjectColliders.Contains(collider))
			{
				VRTK_SharedMethods.AddListValue(touchedObjectActiveColliders, collider, preventDuplicates: true);
			}
		}

		protected virtual void StoreTouchedObjectColliders(Collider collider)
		{
			touchedObjectColliders.Clear();
			touchedObjectActiveColliders.Clear();
			Collider[] componentsInChildren = touchedObject.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				VRTK_SharedMethods.AddListValue(touchedObjectColliders, componentsInChildren[i], preventDuplicates: true);
			}
			VRTK_SharedMethods.AddListValue(touchedObjectActiveColliders, collider, preventDuplicates: true);
		}

		protected virtual void ToggleControllerVisibility(bool visible)
		{
			GameObject modelAliasController = VRTK_DeviceFinder.GetModelAliasController(base.gameObject);
			if (touchedObject != null)
			{
				VRTK_InteractControllerAppearance[] componentsInParent = touchedObject.GetComponentsInParent<VRTK_InteractControllerAppearance>(includeInactive: true);
				if (componentsInParent.Length != 0)
				{
					componentsInParent[0].ToggleControllerOnTouch(visible, modelAliasController, touchedObject);
				}
			}
			else if (visible)
			{
				VRTK_ObjectAppearance.SetRendererVisible(modelAliasController, touchedObject);
			}
		}

		protected virtual void CheckStopTouching()
		{
			if (touchedObject != null)
			{
				VRTK_InteractableObject component = touchedObject.GetComponent<VRTK_InteractableObject>();
				if (component != null && component.GetGrabbingObject() != base.gameObject)
				{
					StopTouching(touchedObject);
				}
			}
		}

		protected virtual GameObject TriggerStart(Collider collider)
		{
			if (IsSnapDropZone(collider))
			{
				return null;
			}
			AddActiveCollider(collider);
			return GetColliderInteractableObject(collider);
		}

		protected virtual bool IsSnapDropZone(Collider collider)
		{
			if ((bool)collider.GetComponent<VRTK_SnapDropZone>())
			{
				return true;
			}
			return false;
		}

		protected virtual void StopTouching(GameObject untouched)
		{
			OnControllerStartUntouchInteractableObject(SetControllerInteractEvent(untouched));
			if (IsObjectInteractable(untouched))
			{
				VRTK_InteractableObject vRTK_InteractableObject = ((untouched != null) ? untouched.GetComponent<VRTK_InteractableObject>() : null);
				if (vRTK_InteractableObject != null)
				{
					vRTK_InteractableObject.StopTouching(this);
				}
			}
			ToggleControllerVisibility(visible: true);
			OnControllerUntouchInteractableObject(SetControllerInteractEvent(untouched));
			CleanupEndTouch();
		}

		protected virtual void CleanupEndTouch()
		{
			touchedObject = null;
			touchedObjectActiveColliders.Clear();
			touchedObjectColliders.Clear();
		}

		protected virtual void DestroyTouchCollider()
		{
			if (destroyColliderOnDisable)
			{
				Object.Destroy(controllerCollisionDetector);
			}
		}

		protected virtual bool CustomRigidBodyIsChild()
		{
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (transform != base.transform && transform == customColliderContainer.transform)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void CreateTouchCollider()
		{
			string controllerDefaultColliderPath = VRTK_SDK_Bridge.GetControllerDefaultColliderPath(VRTK_DeviceFinder.GetControllerHand(base.gameObject));
			if (controllerDefaultColliderPath == "")
			{
				return;
			}
			Object obj = Resources.Load(controllerDefaultColliderPath);
			if (customColliderContainer == null)
			{
				if (obj == null)
				{
					VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.SDK_OBJECT_NOT_FOUND, "default collider prefab", "Controller SDK"));
					return;
				}
				if (destroyColliderOnDisable)
				{
					Object.Destroy(controllerCollisionDetector);
				}
				controllerCollisionDetector = Object.Instantiate(obj, base.transform.position, base.transform.rotation) as GameObject;
				controllerCollisionDetector.transform.SetParent(base.transform);
				controllerCollisionDetector.transform.localScale = base.transform.localScale;
				controllerCollisionDetector.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "Controller", "CollidersContainer");
				destroyColliderOnDisable = true;
			}
			else if (CustomRigidBodyIsChild())
			{
				controllerCollisionDetector = customColliderContainer;
				destroyColliderOnDisable = false;
			}
			else
			{
				controllerCollisionDetector = Object.Instantiate(customColliderContainer, base.transform.position, base.transform.rotation);
				controllerCollisionDetector.transform.SetParent(base.transform);
				controllerCollisionDetector.transform.localScale = base.transform.localScale;
				destroyColliderOnDisable = true;
			}
			controllerCollisionDetector.AddComponent<VRTK_PlayerObject>().objectType = VRTK_PlayerObject.ObjectTypes.Collider;
		}

		protected virtual void CreateTouchRigidBody()
		{
			touchRigidBody = ((GetComponent<Rigidbody>() != null) ? GetComponent<Rigidbody>() : base.gameObject.AddComponent<Rigidbody>());
			touchRigidBody.isKinematic = true;
			touchRigidBody.useGravity = false;
			touchRigidBody.constraints = RigidbodyConstraints.FreezeAll;
			touchRigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
		}

		protected virtual void EmitControllerRigidbodyEvent(bool state)
		{
			if (state)
			{
				OnControllerRigidbodyActivated(SetControllerInteractEvent(null));
			}
			else
			{
				OnControllerRigidbodyDeactivated(SetControllerInteractEvent(null));
			}
		}
	}
}
