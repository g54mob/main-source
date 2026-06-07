using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_InteractNearTouch")]
	public class VRTK_InteractNearTouch : MonoBehaviour
	{
		[Tooltip("The radius of the auto generated collider if a `Custom Collider Container` is not supplied.")]
		public float colliderRadius = 0.2f;

		[Tooltip("An optional GameObject that contains the compound colliders to represent the near touching object. If this is empty then the collider will be auto generated at runtime.")]
		public GameObject customColliderContainer;

		[Tooltip("The Interact Touch script to associate the near touches with. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_InteractTouch interactTouch;

		protected GameObject neartouchColliderContainer;

		protected List<GameObject> nearTouchedObjects = new List<GameObject>();

		protected VRTK_InteractNearTouchCollider interactNearTouchColliderScript;

		public event ObjectInteractEventHandler ControllerNearTouchInteractableObject;

		public event ObjectInteractEventHandler ControllerNearUntouchInteractableObject;

		public virtual void OnControllerNearTouchInteractableObject(ObjectInteractEventArgs e)
		{
			VRTK_SharedMethods.AddListValue(nearTouchedObjects, e.target, preventDuplicates: true);
			if (this.ControllerNearTouchInteractableObject != null)
			{
				this.ControllerNearTouchInteractableObject(this, e);
			}
		}

		public virtual void OnControllerNearUntouchInteractableObject(ObjectInteractEventArgs e)
		{
			nearTouchedObjects.Remove(e.target);
			if (this.ControllerNearUntouchInteractableObject != null)
			{
				this.ControllerNearUntouchInteractableObject(this, e);
			}
		}

		public virtual List<GameObject> GetNearTouchedObjects()
		{
			return nearTouchedObjects;
		}

		public virtual void ForceNearTouch(GameObject obj)
		{
			Collider collider = ((obj != null) ? obj.GetComponentInChildren<Collider>() : null);
			if (collider != null)
			{
				interactNearTouchColliderScript.StartNearTouch(collider);
			}
		}

		public virtual void ForceStopNearTouching(GameObject obj = null)
		{
			if (obj != null)
			{
				Collider collider = ((obj != null) ? obj.GetComponentInChildren<Collider>() : null);
				if (collider != null)
				{
					interactNearTouchColliderScript.EndNearTouch(collider);
				}
			}
			else
			{
				for (int i = 0; i < nearTouchedObjects.Count; i++)
				{
					OnControllerNearUntouchInteractableObject(interactTouch.SetControllerInteractEvent(nearTouchedObjects[i]));
				}
			}
		}

		protected virtual void OnEnable()
		{
			nearTouchedObjects.Clear();
			interactTouch = ((interactTouch != null) ? interactTouch : GetComponentInParent<VRTK_InteractTouch>());
			if (interactTouch != null)
			{
				CreateNearTouchCollider();
				interactTouch.ControllerStartTouchInteractableObject += ControllerStartTouchInteractableObject;
				interactTouch.ControllerUntouchInteractableObject += ControllerUntouchInteractableObject;
			}
		}

		protected virtual void OnDisable()
		{
			Object.Destroy(neartouchColliderContainer);
			if (interactTouch != null)
			{
				interactTouch.ControllerStartTouchInteractableObject -= ControllerStartTouchInteractableObject;
				interactTouch.ControllerUntouchInteractableObject -= ControllerUntouchInteractableObject;
			}
		}

		protected virtual void ControllerStartTouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			ForceStopNearTouching(e.target);
		}

		protected virtual void ControllerUntouchInteractableObject(object sender, ObjectInteractEventArgs e)
		{
			if (interactNearTouchColliderScript.GetNearTouchedObjects().Contains(e.target))
			{
				ForceNearTouch(e.target);
			}
		}

		protected virtual void CreateNearTouchCollider()
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
				neartouchColliderContainer = Object.Instantiate(customColliderContainer);
				neartouchColliderContainer.transform.SetParent(interactTouch.transform);
				neartouchColliderContainer.transform.localPosition = customColliderContainer.transform.localPosition;
				neartouchColliderContainer.transform.localRotation = customColliderContainer.transform.localRotation;
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
			interactNearTouchColliderScript = neartouchColliderContainer.AddComponent<VRTK_InteractNearTouchCollider>();
			interactNearTouchColliderScript.SetInteractNearTouch(this);
			neartouchColliderContainer.SetActive(value: true);
		}
	}
}
