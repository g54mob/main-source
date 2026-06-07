using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_TrackObjectGrabAttach")]
	public class VRTK_TrackObjectGrabAttach : VRTK_BaseGrabAttach
	{
		[Header("Track Settings", order = 2)]
		[Tooltip("The maximum distance the grabbing object is away from the Interactable Object before it is automatically dropped.")]
		public float detachDistance = 1f;

		[Tooltip("The maximum amount of velocity magnitude that can be applied to the Interactable Object. Lowering this can prevent physics glitches if Interactable Objects are moving too fast.")]
		public float velocityLimit = float.PositiveInfinity;

		[Tooltip("The maximum amount of angular velocity magnitude that can be applied to the Interactable Object. Lowering this can prevent physics glitches if Interactable Objects are moving too fast.")]
		public float angularVelocityLimit = float.PositiveInfinity;

		[Tooltip("The maximum difference in distance to the tracked position.")]
		public float maxDistanceDelta = 10f;

		protected bool isReleasable = true;

		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			if (isReleasable)
			{
				ReleaseObject(applyGrabbingObjectVelocity);
			}
			base.StopGrab(applyGrabbingObjectVelocity);
		}

		public override Transform CreateTrackPoint(Transform controllerPoint, GameObject currentGrabbedObject, GameObject currentGrabbingObject, ref bool customTrackPoint)
		{
			Transform transform = null;
			if (precisionGrab)
			{
				transform = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, currentGrabbedObject.name, "TrackObject", "PrecisionSnap", "AttachPoint")).transform;
				transform.SetParent(currentGrabbingObject.transform);
				transform = SetTrackPointOrientation(transform, currentGrabbedObject.transform, controllerPoint);
				customTrackPoint = true;
			}
			else
			{
				transform = base.CreateTrackPoint(controllerPoint, currentGrabbedObject, currentGrabbingObject, ref customTrackPoint);
			}
			return transform;
		}

		public override void ProcessUpdate()
		{
			if (trackPoint != null && grabbedObjectScript.IsDroppable() && Vector3.Distance(trackPoint.position, initialAttachPoint.position) > detachDistance)
			{
				ForceReleaseGrab();
			}
		}

		public override void ProcessFixedUpdate()
		{
			if (grabbedObject == null)
			{
				return;
			}
			Vector3 vector = trackPoint.position - ((grabbedSnapHandle != null) ? grabbedSnapHandle.position : grabbedObject.transform.position);
			(trackPoint.rotation * Quaternion.Inverse((grabbedSnapHandle != null) ? grabbedSnapHandle.rotation : grabbedObject.transform.rotation)).ToAngleAxis(out var angle, out var axis);
			angle = ((!(angle > 180f)) ? angle : (angle -= 360f));
			if (angle != 0f)
			{
				Vector3 angularVelocity = Vector3.MoveTowards(target: angle * axis, current: grabbedObjectRigidBody.angularVelocity, maxDistanceDelta: maxDistanceDelta);
				if (angularVelocityLimit == float.PositiveInfinity || angularVelocity.sqrMagnitude < angularVelocityLimit)
				{
					grabbedObjectRigidBody.angularVelocity = angularVelocity;
				}
			}
			Vector3 target = vector / Time.fixedDeltaTime;
			Vector3 velocity = Vector3.MoveTowards(grabbedObjectRigidBody.velocity, target, maxDistanceDelta);
			if (velocityLimit == float.PositiveInfinity || velocity.sqrMagnitude < velocityLimit)
			{
				grabbedObjectRigidBody.velocity = velocity;
			}
		}

		protected override void Initialise()
		{
			tracked = true;
			climbable = false;
			kinematic = false;
		}

		protected virtual Transform SetTrackPointOrientation(Transform givenTrackPoint, Transform currentGrabbedObject, Transform controllerPoint)
		{
			givenTrackPoint.position = currentGrabbedObject.position;
			givenTrackPoint.rotation = currentGrabbedObject.rotation;
			return givenTrackPoint;
		}
	}
}
