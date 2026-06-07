using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class AddTorque3D : AddTorque
	{
		private Rigidbody rigidbody;

		protected override void Awake()
		{
			base.Awake();
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.maxAngularVelocity = maxAngularVelocity;
		}

		protected override void AddTorqueToRigidbody()
		{
			rigidbody.AddRelativeTorque(torque);
		}
	}
}
