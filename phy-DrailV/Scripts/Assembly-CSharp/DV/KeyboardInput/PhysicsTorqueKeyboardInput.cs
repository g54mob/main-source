using UnityEngine;

namespace DV.KeyboardInput
{
	public class PhysicsTorqueKeyboardInput : PhysicsForceKeyboardInput
	{
		protected override void Apply(Vector3 force)
		{
			GetComponent<Rigidbody>()?.AddRelativeTorque(force);
		}
	}
}
