using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class AddTorque2D : AddTorque
	{
		private Rigidbody2D rigidbody;

		protected override void Awake()
		{
			base.Awake();
			rigidbody = GetComponent<Rigidbody2D>();
		}

		protected override void AddTorqueToRigidbody()
		{
			rigidbody.AddTorque(torque.z);
			rigidbody.angularVelocity = Mathf.Clamp(rigidbody.angularVelocity, 0f - maxAngularVelocity, maxAngularVelocity);
		}
	}
}
