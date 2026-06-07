using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_InteractNearTouch_DV : VRTK_InteractNearTouch
	{
		private struct NTEntry
		{
			public VRTK_InteractableObject_DV obj;

			public Collider collider;

			public Transform origin;

			public Vector3 point;

			public float distance;

			public NTEntry(VRTK_InteractableObject_DV obj, Collider collider, Transform origin, Vector3 point, float distance)
			{
				this.obj = obj;
				this.collider = collider;
				this.origin = origin;
				this.point = point;
				this.distance = distance;
			}
		}

		private HashSet<VRTK_InteractableObject_DV> nearTouchedInteractables = new HashSet<VRTK_InteractableObject_DV>();

		private Dictionary<Collider, VRTK_InteractableObject_DV> interactableColliders = new Dictionary<Collider, VRTK_InteractableObject_DV>();

		private VRTK_TrackedController trackedController;

		public Transform rayOrigin;

		private Transform raycastPoint;

		private bool initialized;

		private float closestDistance;

		private float realClosestDistance;

		private static readonly NTEntry NullEntry = new NTEntry(null, null, null, Vector3.zero, 0f);

		private NTEntry pickedEntry = NullEntry;

		private Dictionary<VRTK_InteractableObject_DV, NTEntry> cache = new Dictionary<VRTK_InteractableObject_DV, NTEntry>();

		private List<VRTK_InteractableObject_DV> toRemoveList = new List<VRTK_InteractableObject_DV>();

		private HighlightTag highlightedTag;

		public Color highlightColor = new Color(0f, 1f, 0.7f, 1f);

		public GameObject NearTouchedObject { get; private set; }

		public VRTK_InteractableObject_DV CurrentObject { get; private set; }

		public int NearCount => nearTouchedInteractables.Count;

		public float ClosestDistance => realClosestDistance;

		protected override void OnEnable()
		{
			if (!initialized)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
				return;
			}
			trackedController = GetComponentInParent<VRTK_TrackedController>();
			trackedController.ControllerModelAvailable += DoControllerModelAvailable;
		}

		protected override void OnDisable()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			if (interactTouch != null)
			{
				interactTouch.ControllerStartTouchInteractableObject -= ControllerStartTouchInteractableObject;
				interactTouch.ControllerUntouchInteractableObject -= ControllerUntouchInteractableObject;
			}
			if (trackedController != null)
			{
				trackedController.ControllerModelAvailable -= DoControllerModelAvailable;
			}
			if (CurrentObject != null)
			{
				CurrentObject.InteractableObjectAboutToBeDestroyed -= InteractableObjectAboutToBeDestroyed;
			}
		}

		private void CleanStaleState()
		{
			foreach (VRTK_InteractableObject_DV nearTouchedInteractable in nearTouchedInteractables)
			{
				if (!nearTouchedInteractable.gameObject.activeInHierarchy)
				{
					toRemoveList.Add(nearTouchedInteractable);
				}
			}
			foreach (VRTK_InteractableObject_DV toRemove in toRemoveList)
			{
				StopNearTouching(toRemove);
				nearTouchedInteractables.Remove(toRemove);
			}
			toRemoveList.Clear();
		}

		private void Update()
		{
			if (!initialized)
			{
				return;
			}
			VRTK_InteractableObject_DV currentObject = CurrentObject;
			CleanStaleState();
			closestDistance = float.MaxValue;
			realClosestDistance = float.MaxValue;
			NearTouchedObject = null;
			CurrentObject = null;
			pickedEntry = NullEntry;
			cache.Clear();
			foreach (KeyValuePair<Collider, VRTK_InteractableObject_DV> interactableCollider in interactableColliders)
			{
				VRTK_InteractableObject_DV value = interactableCollider.Value;
				Collider key = interactableCollider.Key;
				if (!value.InteractionAllowed || !nearTouchedInteractables.Contains(value))
				{
					continue;
				}
				Transform transform = raycastPoint;
				Vector3 position = transform.position;
				Vector3 vector = key.ClosestPoint(position);
				float num2;
				float num = (num2 = Vector3.Distance(vector, position));
				float num3 = 1f / (1f + (float)value.priority * 0.2f);
				num2 *= num3;
				if (cache.TryGetValue(value, out var value2))
				{
					if (num2 < value2.distance)
					{
						value2.collider = key;
						value2.distance = num2;
						value2.origin = transform;
						value2.point = vector;
						cache[value] = value2;
					}
				}
				else
				{
					NTEntry value3 = new NTEntry(value, key, transform, vector, num2);
					cache.Add(value, value3);
				}
				if (num2 < closestDistance)
				{
					closestDistance = num2;
					realClosestDistance = num;
					if (CurrentObject != null)
					{
						CurrentObject.InteractableObjectAboutToBeDestroyed -= InteractableObjectAboutToBeDestroyed;
					}
					CurrentObject = value;
					if (CurrentObject != null)
					{
						CurrentObject.InteractableObjectAboutToBeDestroyed += InteractableObjectAboutToBeDestroyed;
					}
					NearTouchedObject = value.gameObject;
					pickedEntry = value2;
				}
			}
			if (CurrentObject != currentObject)
			{
				if ((bool)currentObject)
				{
					StopNearTouching(currentObject.gameObject);
				}
				if ((bool)CurrentObject)
				{
					StartNearTouching(CurrentObject);
				}
			}
		}

		private void InteractableObjectAboutToBeDestroyed(VRTK_InteractableObject_DV interactable)
		{
			nearTouchedInteractables.Remove(interactable);
			Collider componentInChildren = interactable.GetComponentInChildren<Collider>();
			if ((bool)componentInChildren)
			{
				interactableColliders.Remove(componentInChildren);
			}
			interactable.InteractableObjectAboutToBeDestroyed -= InteractableObjectAboutToBeDestroyed;
		}

		private void OnDrawGizmosSelected()
		{
			foreach (KeyValuePair<VRTK_InteractableObject_DV, NTEntry> item in cache)
			{
				if (item.Value.obj == pickedEntry.obj && item.Value.collider == pickedEntry.collider)
				{
					Gizmos.color = Color.green;
				}
				else
				{
					Gizmos.color = Color.red;
				}
				Gizmos.DrawLine(item.Value.origin.position, item.Value.point);
				Gizmos.DrawWireCube(item.Value.collider.bounds.center, item.Value.collider.bounds.size);
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			if (VRTK_DeviceFinder.GetControllerHand(base.gameObject) == hand)
			{
				Initialize(reinitialize: false);
			}
		}

		protected void DoControllerModelAvailable(object _, VRTKTrackedControllerEventArgs __)
		{
			Initialize(reinitialize: true);
		}

		private void Initialize(bool reinitialize)
		{
			if (!reinitialize)
			{
				trackedController = GetComponentInParent<VRTK_TrackedController>();
				GameObject gameObject = base.transform.Find("[pipa]").gameObject;
				Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
				if (rigidbody == null)
				{
					rigidbody = gameObject.AddComponent<Rigidbody>();
					rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				}
				SetNearTouchRigidbodyValues(rigidbody);
				if (gameObject.GetComponent<VRTK_TouchTriggerDetector>() == null)
				{
					gameObject.AddComponent<VRTK_TouchTriggerDetector>().pipaExclusive = true;
				}
				raycastPoint = gameObject.transform;
			}
			CreateNearTouchCollider();
			CreateNearTouchRigidBody();
			VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.Controller);
			initialized = true;
		}

		protected void CreateNearTouchRigidBody()
		{
			Rigidbody componentInChildren = neartouchColliderContainer.GetComponentInChildren<Rigidbody>();
			Rigidbody nearTouchRigidbodyValues = ((componentInChildren != null) ? componentInChildren : neartouchColliderContainer.gameObject.AddComponent<Rigidbody>());
			SetNearTouchRigidbodyValues(nearTouchRigidbodyValues);
		}

		private void SetNearTouchRigidbodyValues(Rigidbody rb)
		{
			rb.isKinematic = true;
			rb.useGravity = false;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		}

		private void StartNearTouching(VRTK_InteractableObject_DV nearTouched)
		{
			if (!(nearTouched == null))
			{
				nearTouched.StartNearTouching(this);
				OnControllerNearTouchInteractableObject(interactTouch.SetControllerInteractEvent(nearTouched.gameObject));
				Highlight(NearTouchedObject);
			}
		}

		protected void StopNearTouching(GameObject nearUntouched)
		{
			VRTK_InteractableObject_DV nearUntouched2 = ((nearUntouched != null) ? nearUntouched.GetComponent<VRTK_InteractableObject_DV>() : null);
			StopNearTouching(nearUntouched2);
		}

		private void StopNearTouching(VRTK_InteractableObject_DV nearUntouched)
		{
			if (!(nearUntouched == null))
			{
				Collider componentInChildren = nearUntouched.GetComponentInChildren<Collider>();
				nearUntouched.StopNearTouching(this);
				if ((bool)componentInChildren)
				{
					interactableColliders.Remove(componentInChildren);
				}
				OnControllerNearUntouchInteractableObject(interactTouch.SetControllerInteractEvent(nearUntouched.gameObject));
				Unhighlight();
			}
		}

		public override void ForceStopNearTouching(GameObject obj = null)
		{
			if (!(obj == null))
			{
				VRTK_InteractableObject_DV componentInParent = obj.GetComponentInParent<VRTK_InteractableObject_DV>();
				if (!(componentInParent == null))
				{
					componentInParent.InteractableObjectAboutToBeDestroyed -= InteractableObjectAboutToBeDestroyed;
					nearTouchedInteractables.Remove(componentInParent);
					base.ForceStopNearTouching(obj);
				}
			}
		}

		public override void ForceNearTouch(GameObject interactableGameObject)
		{
			if (interactableGameObject == null)
			{
				return;
			}
			VRTK_InteractableObject_DV componentInParent = interactableGameObject.GetComponentInParent<VRTK_InteractableObject_DV>();
			if (componentInParent == null)
			{
				return;
			}
			if (nearTouchedInteractables.Add(componentInParent))
			{
				Collider componentInChildren = componentInParent.GetComponentInChildren<Collider>();
				if ((bool)componentInChildren)
				{
					interactableColliders[componentInChildren] = componentInParent;
				}
			}
			StartNearTouching(componentInParent);
		}

		protected override void CreateNearTouchCollider()
		{
			if (customColliderContainer == null)
			{
				neartouchColliderContainer = new GameObject();
				neartouchColliderContainer.transform.SetParent(interactTouch.transform);
				neartouchColliderContainer.transform.localPosition = Vector3.zero;
				neartouchColliderContainer.transform.localRotation = Quaternion.identity;
				neartouchColliderContainer.transform.localScale = interactTouch.transform.localScale;
			}
			else
			{
				neartouchColliderContainer = Object.Instantiate(customColliderContainer, interactTouch.transform);
				neartouchColliderContainer.transform.localPosition = Vector3.zero;
				neartouchColliderContainer.transform.localRotation = Quaternion.identity;
				neartouchColliderContainer.transform.localScale = customColliderContainer.transform.localScale;
			}
			neartouchColliderContainer.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "Controller", "NearTouch", "CollidersContainer");
			Rigidbody rigidbody = neartouchColliderContainer.GetComponentInChildren<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = neartouchColliderContainer.AddComponent<Rigidbody>();
			}
			rigidbody.isKinematic = true;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			Collider componentInChildren = neartouchColliderContainer.GetComponentInChildren<Collider>();
			if (componentInChildren == null)
			{
				SphereCollider sphereCollider = neartouchColliderContainer.AddComponent<SphereCollider>();
				sphereCollider.isTrigger = true;
				sphereCollider.radius = colliderRadius;
			}
			else
			{
				componentInChildren.isTrigger = true;
			}
			neartouchColliderContainer.GetComponent<VRTK_NearTouchTriggerDetector>().nearTouch = this;
			TransmogrifyControllers.FinalizeInteractionColliders(neartouchColliderContainer.transform, VRTK_ControllerReference.GetControllerReference(trackedController.index));
			neartouchColliderContainer.SetActive(value: true);
		}

		protected void Highlight(GameObject target)
		{
			if (target == null)
			{
				return;
			}
			highlightedTag = target.GetComponentInChildren<HighlightTag>();
			if (highlightedTag == null)
			{
				return;
			}
			foreach (Renderer renderer in highlightedTag.renderers)
			{
				VRTK_ObjectAppearance.HighlightObject(renderer.gameObject, highlightColor);
			}
		}

		protected void Unhighlight()
		{
			if (highlightedTag == null)
			{
				return;
			}
			foreach (Renderer renderer in highlightedTag.renderers)
			{
				VRTK_ObjectAppearance.UnhighlightObject(renderer.gameObject);
			}
			highlightedTag = null;
		}

		public void UpdateNearTouchCollectionsExternal(bool add, VRTK_InteractableObject_DV interactableObject, Collider collider)
		{
			if (!(interactableObject == null) && (!add || !interactableColliders.ContainsKey(collider)))
			{
				interactableObject.InteractableObjectAboutToBeDestroyed -= InteractableObjectAboutToBeDestroyed;
				if (add)
				{
					interactableColliders[collider] = interactableObject;
					nearTouchedInteractables.Add(interactableObject);
					interactableObject.InteractableObjectAboutToBeDestroyed += InteractableObjectAboutToBeDestroyed;
				}
				else
				{
					interactableColliders.Remove(collider);
					nearTouchedInteractables.Remove(interactableObject);
				}
			}
		}
	}
}
