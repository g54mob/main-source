using UnityEngine;

public class MetalGrate : MonoBehaviour
{
	public float impulseForceToPryOpen = 10f;

	public Transform impulsePosition;

	public float openingForce = 1000f;

	public float massAfterOpening;

	public float limitAfterOpening;

	public float massWhenClosed;

	public float limitWhenClosed;

	private Rigidbody rigidBody;

	private HingeJoint hinge;

	public void OpenGrate()
	{
		rigidBody.AddForceAtPosition(openingForce * Vector3.up, impulsePosition.position, ForceMode.Impulse);
		rigidBody.mass = massAfterOpening;
		JointLimits limits = new JointLimits
		{
			min = limitAfterOpening,
			max = hinge.limits.max,
			bounciness = hinge.limits.bounciness,
			contactDistance = hinge.limits.contactDistance,
			bounceMinVelocity = hinge.limits.bounceMinVelocity
		};
		hinge.SetLimits(limits);
	}

	public void ResetGrate()
	{
		rigidBody.mass = massWhenClosed;
		JointLimits limits = new JointLimits
		{
			min = limitWhenClosed,
			max = hinge.limits.max,
			bounciness = hinge.limits.bounciness,
			contactDistance = hinge.limits.contactDistance,
			bounceMinVelocity = hinge.limits.bounceMinVelocity
		};
		hinge.SetLimits(limits);
	}

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		hinge = GetComponent<HingeJoint>();
	}
}
