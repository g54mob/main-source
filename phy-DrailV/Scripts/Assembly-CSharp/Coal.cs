using System.Collections;
using DV.CabControls.VRTK;
using UnityEngine;

public class Coal : MonoBehaviour
{
	public float value = 15f;

	[HideInInspector]
	public float jointSpring;

	[HideInInspector]
	public float jointBreakForce;

	[HideInInspector]
	public Collider coalCollider;

	private CabItemRigidbody cabItemForces;

	private SpringJoint joint;

	private CarryItemAfterTeleportVRTK carry;

	private IEnumerator Start()
	{
		coalCollider = GetComponentInChildren<Collider>(includeInactive: true);
		yield return null;
		cabItemForces = GetComponent<CabItemRigidbody>();
		carry = GetComponent<CarryItemAfterTeleportVRTK>();
		ToggleCarry(on: false);
	}

	private void OnEnable()
	{
		ToggleCarry(on: false);
	}

	private void ToggleCarry(bool on)
	{
		if (!(carry == null))
		{
			carry.overrideShouldAllowAdjustment = on;
			carry.overrideShouldAllowAdjustmentValue = on;
		}
	}

	private void MakeJoint()
	{
		joint = base.gameObject.AddComponent<SpringJoint>();
		joint.enableCollision = false;
	}

	public void UpdateJoint(Rigidbody shovelRigidBody)
	{
		if (joint == null)
		{
			MakeJoint();
		}
		joint.connectedBody = shovelRigidBody;
		joint.spring = jointSpring;
		joint.breakForce = jointBreakForce;
		joint.enableCollision = true;
	}

	private void OnJointBreak(float _)
	{
		CarryItemAfterTeleportVRTK component = GetComponent<CarryItemAfterTeleportVRTK>();
		if ((bool)component)
		{
			component.overrideShouldAllowAdjustment = false;
		}
		if ((bool)cabItemForces)
		{
			cabItemForces.receiveForces = true;
		}
		joint.enableCollision = false;
	}
}
