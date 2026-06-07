using System.Collections.Generic;
using DV.CabControls.VRTK;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_InteractTouch_DV : VRTK_InteractTouch
	{
		public HashSet<VRTK_InteractableObject_DV> touchedInteractables = new HashSet<VRTK_InteractableObject_DV>();

		private List<VRTK_InteractableObject_DV> topPriorityObjects = new List<VRTK_InteractableObject_DV>();

		private VRTK_InteractGrab_DV grab;

		private VRTK_InteractNearTouch_DV nearTouch;

		private bool initialized;

		protected override void OnEnable()
		{
			if (!initialized)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			}
			else
			{
				trackedController.ControllerModelAvailable += DoControllerModelAvailable;
			}
		}

		protected override void OnDisable()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			if (!UnloadWatcher.isUnloading)
			{
				base.OnDisable();
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			if (VRTK_DeviceFinder.GetControllerHand(base.gameObject) == hand)
			{
				Initialize(reinitialize: false);
			}
		}

		protected override void DoControllerModelAvailable(object _, VRTKTrackedControllerEventArgs __)
		{
			Initialize(reinitialize: true);
		}

		private void Initialize(bool reinitialize)
		{
			if (!reinitialize)
			{
				grab = GetComponent<VRTK_InteractGrab_DV>();
				nearTouch = GetComponent<VRTK_InteractNearTouch_DV>();
				trackedController = GetComponentInParent<VRTK_TrackedController>();
				GameObject gameObject = base.transform.Find("[pipa]").gameObject;
				Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
				if (rigidbody == null)
				{
					rigidbody = gameObject.AddComponent<Rigidbody>();
					rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				}
				SetTouchRigidbodyValues(rigidbody);
				if (gameObject.GetComponent<VRTK_TouchTriggerDetector>() == null)
				{
					gameObject.AddComponent<VRTK_TouchTriggerDetector>().pipaExclusive = true;
				}
			}
			destroyColliderOnDisable = false;
			controllerCollisionDetector = ((customColliderContainer != null) ? customColliderContainer : controllerCollisionDetector);
			CreateTouchCollider();
			CreateTouchRigidBody();
			VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.Controller);
			controllerCollisionDetector.AddComponent<VRTK_TouchTriggerDetector>();
			controllerCollisionDetector.SetActive(value: false);
			VRTK_DeviceFinder.GetModelAliasController(base.gameObject).SetActive(value: false);
			initialized = true;
		}

		protected override void CreateTouchCollider()
		{
			base.CreateTouchCollider();
			TransmogrifyControllers.FinalizeInteractionColliders(controllerCollisionDetector.transform, base.controllerReference);
		}

		protected override void CreateTouchRigidBody()
		{
			Rigidbody component = controllerCollisionDetector.GetComponent<Rigidbody>();
			touchRigidBody = ((component != null) ? GetComponent<Rigidbody>() : controllerCollisionDetector.AddComponent<Rigidbody>());
			SetTouchRigidbodyValues(touchRigidBody);
		}

		private void SetTouchRigidbodyValues(Rigidbody rb)
		{
			rb.isKinematic = true;
			rb.useGravity = false;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		}

		private void StartTouching(VRTK_InteractableObject_DV touched)
		{
			if (!(touched == null))
			{
				OnControllerStartTouchInteractableObject(SetControllerInteractEvent(touched.gameObject));
				ToggleControllerVisibility(visible: false);
				touched.StartTouching(this);
				touchedObject = touched.gameObject;
				OnControllerTouchInteractableObject(SetControllerInteractEvent(touched.gameObject));
			}
		}

		protected override void StopTouching(GameObject untouched)
		{
			VRTK_InteractableObject_DV vRTK_InteractableObject_DV = ((untouched != null) ? untouched.GetComponent<VRTK_InteractableObject_DV>() : null);
			if (!(vRTK_InteractableObject_DV == null))
			{
				StopTouching(vRTK_InteractableObject_DV);
			}
		}

		private void StopTouching(VRTK_InteractableObject_DV untouched)
		{
			if (!(untouched == null))
			{
				OnControllerStartUntouchInteractableObject(SetControllerInteractEvent(untouched.gameObject));
				untouched.StopTouching(this);
				ToggleControllerVisibility(visible: true);
				OnControllerUntouchInteractableObject(SetControllerInteractEvent(untouched.gameObject));
				touchedObject = null;
				touchedInteractables.Remove(untouched);
				StartTouching(GetTouchedInteractableByPriority());
			}
		}

		private GameObject ObjectToIgnoreBasedOnNearTouch()
		{
			if (nearTouch == null || !nearTouch.enabled)
			{
				return null;
			}
			GameObject nearTouchedObject = nearTouch.NearTouchedObject;
			ItemVRTK itemVRTK = ((nearTouchedObject != null) ? nearTouchedObject.GetComponentInParent<ItemVRTK>() : null);
			if (!(itemVRTK != null) || !(itemVRTK.gameObject != nearTouchedObject))
			{
				return null;
			}
			return itemVRTK.gameObject;
		}

		private VRTK_InteractableObject_DV GetTouchedInteractableByPriority()
		{
			GameObject gameObject = ((grab != null) ? grab.GetGrabbedObject() : null);
			if (gameObject != null)
			{
				return gameObject.GetComponent<VRTK_InteractableObject_DV>();
			}
			touchedInteractables.RemoveWhere(IsInteractableNull);
			GameObject gameObject2 = ObjectToIgnoreBasedOnNearTouch();
			if (gameObject2 != null)
			{
				VRTK_InteractableObject_DV component = gameObject2.GetComponent<VRTK_InteractableObject_DV>();
				touchedInteractables.Remove(component);
			}
			if (touchedInteractables.Count <= 0)
			{
				return null;
			}
			int num = int.MinValue;
			foreach (VRTK_InteractableObject_DV touchedInteractable in touchedInteractables)
			{
				int priority = touchedInteractable.priority;
				if (IsObjectInteractable(touchedInteractable) && priority > num)
				{
					num = priority;
				}
			}
			topPriorityObjects.Clear();
			foreach (VRTK_InteractableObject_DV touchedInteractable2 in touchedInteractables)
			{
				if (touchedInteractable2.priority == num && IsObjectInteractable(touchedInteractable2))
				{
					topPriorityObjects.Add(touchedInteractable2);
				}
			}
			int num2 = PriorityTieBreakerIndex(topPriorityObjects);
			if (num2 < 0)
			{
				return null;
			}
			return topPriorityObjects[num2];
		}

		private bool IsInteractableNull(VRTK_InteractableObject_DV interactable)
		{
			return interactable == null;
		}

		private int PriorityTieBreakerIndex(List<VRTK_InteractableObject_DV> topPriorityObjects)
		{
			int count = topPriorityObjects.Count;
			if (count <= 0)
			{
				return -1;
			}
			if (count == 1)
			{
				return 0;
			}
			int result = 0;
			float num = float.PositiveInfinity;
			Vector3 vector = PipaUtils.PipaPosition(base.gameObject);
			for (int i = 0; i < count; i++)
			{
				float sqrMagnitude = (topPriorityObjects[i].GetInteractionPoint(vector) - vector).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = i;
				}
			}
			return result;
		}

		protected override void FixedUpdate()
		{
			CheckTouch();
		}

		private void CheckTouch()
		{
			if (initialized)
			{
				GameObject gameObject = touchedObject;
				VRTK_InteractableObject_DV touchedInteractableByPriority = GetTouchedInteractableByPriority();
				GameObject gameObject2 = touchedInteractableByPriority?.gameObject;
				if (gameObject != null && gameObject2 != gameObject)
				{
					StopTouching(gameObject);
				}
				else if (gameObject == null && touchedInteractableByPriority != null)
				{
					StartTouching(touchedInteractableByPriority);
				}
			}
		}

		protected override void LateUpdate()
		{
			CheckTouch();
		}

		public bool IsObjectInteractable(VRTK_InteractableObject_DV interactableVr)
		{
			if (!IsInteractableNull(interactableVr))
			{
				if (!interactableVr.InteractionAllowed)
				{
					return false;
				}
				if (!interactableVr.IsValidInteractableController(base.gameObject, interactableVr.allowedTouchControllers))
				{
					return false;
				}
				if (interactableVr.disableWhenIdle && !interactableVr.enabled)
				{
					return true;
				}
				return interactableVr.enabled;
			}
			return false;
		}

		public override bool IsObjectInteractable(GameObject go)
		{
			if (go == null)
			{
				return false;
			}
			return IsObjectInteractable(go.GetComponent<VRTK_InteractableObject_DV>());
		}

		public override void ForceStopTouching()
		{
			touchedInteractables.Clear();
			base.ForceStopTouching();
		}

		public override void ForceTouch(GameObject interactableGameObject)
		{
			if (!(interactableGameObject == null))
			{
				VRTK_InteractableObject_DV componentInParent = interactableGameObject.GetComponentInParent<VRTK_InteractableObject_DV>();
				if (!(componentInParent == null))
				{
					StartTouching(componentInParent);
				}
			}
		}

		protected override void CleanupEndTouch()
		{
		}

		protected override void OnTriggerEnter(Collider collider)
		{
		}

		protected override void OnTriggerExit(Collider collider)
		{
		}

		protected override void OnTriggerStay(Collider collider)
		{
		}
	}
}
