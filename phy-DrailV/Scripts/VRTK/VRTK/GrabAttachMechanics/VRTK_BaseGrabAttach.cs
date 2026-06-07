using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public abstract class VRTK_BaseGrabAttach : MonoBehaviour
	{
		[Header("Base Settings", order = 1)]
		[Tooltip("If this is checked then when the Interact Grab grabs the Interactable Object, it will grab it with precision and pick it up at the particular point on the Interactable Object that the Interact Touch is touching.")]
		public bool precisionGrab;

		[Tooltip("A Transform provided as an empty GameObject which must be the child of the Interactable Object being grabbed and serves as an orientation point to rotate and position the grabbed Interactable Object in relation to the right handed Interact Grab. If no Right Snap Handle is provided but a Left Snap Handle is provided, then the Left Snap Handle will be used in place. If no Snap Handle is provided then the Interactable Object will be grabbed at its central point. Not required for `Precision Grab`.")]
		public Transform rightSnapHandle;

		[Tooltip("A Transform provided as an empty GameObject which must be the child of the Interactable Object being grabbed and serves as an orientation point to rotate and position the grabbed Interactable Object in relation to the left handed Interact Grab. If no Left Snap Handle is provided but a Right Snap Handle is provided, then the Right Snap Handle will be used in place. If no Snap Handle is provided then the Interactable Object will be grabbed at its central point. Not required for `Precision Grab`.")]
		public Transform leftSnapHandle;

		[Tooltip("If checked then when the Interactable Object is thrown, the distance between the Interactable Object's attach point and the Interact Grab's attach point will be used to calculate a faster throwing velocity.")]
		public bool throwVelocityWithAttachDistance;

		[Tooltip("An amount to multiply the velocity of the given Interactable Object when it is thrown. This can also be used in conjunction with the Interact Grab Throw Multiplier to have certain Interactable Objects be thrown even further than normal (or thrown a shorter distance if a number below 1 is entered).")]
		public float throwMultiplier = 1f;

		[Tooltip("The amount of time to delay collisions affecting the Interactable Object when it is first grabbed. This is useful if the Interactable Object could get stuck inside another GameObject when it is being grabbed.")]
		public float onGrabCollisionDelay;

		protected bool tracked;

		protected bool climbable;

		protected bool kinematic;

		protected GameObject grabbedObject;

		protected Rigidbody grabbedObjectRigidBody;

		protected VRTK_InteractableObject grabbedObjectScript;

		protected Transform trackPoint;

		protected Transform grabbedSnapHandle;

		protected Transform initialAttachPoint;

		protected Rigidbody controllerAttachPoint;

		public virtual bool IsTracked()
		{
			return tracked;
		}

		public virtual bool IsClimbable()
		{
			return climbable;
		}

		public virtual bool IsKinematic()
		{
			return kinematic;
		}

		public virtual bool ValidGrab(Rigidbody checkAttachPoint)
		{
			return true;
		}

		public virtual void SetTrackPoint(Transform givenTrackPoint)
		{
			trackPoint = givenTrackPoint;
		}

		public virtual void SetInitialAttachPoint(Transform givenInitialAttachPoint)
		{
			initialAttachPoint = givenInitialAttachPoint;
		}

		public virtual bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
		{
			grabbedObject = givenGrabbedObject;
			if (grabbedObject == null)
			{
				return false;
			}
			grabbedObjectScript = grabbedObject.GetComponent<VRTK_InteractableObject>();
			grabbedObjectRigidBody = grabbedObject.GetComponent<Rigidbody>();
			controllerAttachPoint = givenControllerAttachPoint;
			grabbedSnapHandle = GetSnapHandle(grabbingObject);
			ProcessSDKTransformModify(VRTK_ControllerReference.GetControllerReference(grabbingObject));
			grabbedObjectScript.PauseCollisions(onGrabCollisionDelay);
			return true;
		}

		public virtual void StopGrab(bool applyGrabbingObjectVelocity)
		{
			grabbedObject = null;
			grabbedObjectScript = null;
			trackPoint = null;
			grabbedSnapHandle = null;
			initialAttachPoint = null;
			controllerAttachPoint = null;
		}

		public virtual Transform CreateTrackPoint(Transform controllerPoint, GameObject currentGrabbedObject, GameObject currentGrabbingObject, ref bool customTrackPoint)
		{
			customTrackPoint = false;
			return controllerPoint;
		}

		public virtual void ProcessUpdate()
		{
		}

		public virtual void ProcessFixedUpdate()
		{
		}

		public virtual void ResetState()
		{
			Initialise();
		}

		protected virtual void Awake()
		{
			ResetState();
		}

		protected abstract void Initialise();

		protected virtual Rigidbody ReleaseFromController(bool applyGrabbingObjectVelocity)
		{
			return grabbedObjectRigidBody;
		}

		protected virtual void ForceReleaseGrab()
		{
			if (!grabbedObjectScript)
			{
				return;
			}
			GameObject grabbingObject = grabbedObjectScript.GetGrabbingObject();
			if (grabbingObject != null)
			{
				VRTK_InteractGrab componentInChildren = grabbingObject.GetComponentInChildren<VRTK_InteractGrab>();
				if (componentInChildren != null)
				{
					componentInChildren.ForceRelease();
				}
			}
		}

		protected virtual void ReleaseObject(bool applyGrabbingObjectVelocity)
		{
			Rigidbody rigidbody = ReleaseFromController(applyGrabbingObjectVelocity);
			if (rigidbody != null && applyGrabbingObjectVelocity)
			{
				ThrowReleasedObject(rigidbody);
			}
		}

		protected virtual void ThrowReleasedObject(Rigidbody objectRigidbody)
		{
			if (!(grabbedObjectScript != null))
			{
				return;
			}
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(grabbedObjectScript.GetGrabbingObject());
			if (!VRTK_ControllerReference.IsValid(controllerReference) || !(controllerReference.scriptAlias != null))
			{
				return;
			}
			VRTK_InteractGrab componentInChildren = controllerReference.scriptAlias.GetComponentInChildren<VRTK_InteractGrab>();
			if (!(componentInChildren != null))
			{
				return;
			}
			Transform controllerOrigin = VRTK_DeviceFinder.GetControllerOrigin(controllerReference);
			Vector3 controllerVelocity = VRTK_DeviceFinder.GetControllerVelocity(controllerReference);
			Vector3 controllerAngularVelocity = VRTK_DeviceFinder.GetControllerAngularVelocity(controllerReference);
			float num = componentInChildren.throwMultiplier;
			if (controllerOrigin != null)
			{
				objectRigidbody.velocity = controllerOrigin.TransformVector(controllerVelocity) * (num * throwMultiplier);
				objectRigidbody.angularVelocity = controllerOrigin.TransformDirection(controllerAngularVelocity);
			}
			else
			{
				objectRigidbody.velocity = controllerVelocity * (num * throwMultiplier);
				objectRigidbody.angularVelocity = controllerAngularVelocity;
			}
			if (throwVelocityWithAttachDistance)
			{
				Collider componentInChildren2 = objectRigidbody.GetComponentInChildren<Collider>();
				if (componentInChildren2 != null)
				{
					Vector3 center = componentInChildren2.bounds.center;
					objectRigidbody.velocity = objectRigidbody.GetPointVelocity(center + (center - base.transform.position));
				}
				else
				{
					objectRigidbody.velocity = objectRigidbody.GetPointVelocity(objectRigidbody.position + (objectRigidbody.position - base.transform.position));
				}
			}
		}

		protected virtual Transform GetSnapHandle(GameObject grabbingObject)
		{
			if (rightSnapHandle == null && leftSnapHandle != null)
			{
				rightSnapHandle = leftSnapHandle;
			}
			if (leftSnapHandle == null && rightSnapHandle != null)
			{
				leftSnapHandle = rightSnapHandle;
			}
			if (VRTK_DeviceFinder.IsControllerRightHand(grabbingObject))
			{
				return rightSnapHandle;
			}
			if (VRTK_DeviceFinder.IsControllerLeftHand(grabbingObject))
			{
				return leftSnapHandle;
			}
			return null;
		}

		protected virtual void ProcessSDKTransformModify(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				VRTK_SDKTransformModify componentInChildren = ((grabbedSnapHandle != null) ? grabbedSnapHandle.gameObject : grabbedObject).GetComponentInChildren<VRTK_SDKTransformModify>();
				if (componentInChildren != null)
				{
					componentInChildren.UpdateTransform(controllerReference);
				}
			}
		}
	}
}
