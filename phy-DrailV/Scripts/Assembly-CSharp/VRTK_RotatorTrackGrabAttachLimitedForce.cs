using UnityEngine;
using VRTK.GrabAttachMechanics;

public class VRTK_RotatorTrackGrabAttachLimitedForce : VRTK_RotatorTrackGrabAttach
{
	public float maxForceMagnitude = 1f;

	public float forceMultiplier = 1f;

	public override void ProcessFixedUpdate()
	{
		Vector3 vector = trackPoint.position - initialAttachPoint.position;
		vector = Vector3.ClampMagnitude(vector, maxForceMagnitude);
		grabbedObjectRigidBody.AddForceAtPosition(vector * forceMultiplier, initialAttachPoint.position, ForceMode.VelocityChange);
	}
}
