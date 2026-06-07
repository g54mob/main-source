using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_RotatorTrackGrabAttach")]
	public class VRTK_RotatorTrackGrabAttach : VRTK_TrackObjectGrabAttach
	{
		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			isReleasable = false;
			base.StopGrab(applyGrabbingObjectVelocity);
		}

		public override void ProcessFixedUpdate()
		{
			Vector3 force = trackPoint.position - initialAttachPoint.position;
			grabbedObjectRigidBody.AddForceAtPosition(force, initialAttachPoint.position, ForceMode.VelocityChange);
		}

		protected override Transform SetTrackPointOrientation(Transform givenTrackPoint, Transform currentGrabbedObject, Transform controllerPoint)
		{
			givenTrackPoint.position = controllerPoint.position;
			givenTrackPoint.rotation = controllerPoint.rotation;
			return givenTrackPoint;
		}
	}
}
