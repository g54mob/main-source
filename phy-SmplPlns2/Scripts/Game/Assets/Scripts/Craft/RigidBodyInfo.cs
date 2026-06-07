using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class RigidBodyInfo : MonoBehaviour
	{
		public float AngularDrag = 0.05f;

		public Vector3 CenterOfMass = Vector3.zero;

		public float Drag;

		public bool IsKinematic;

		public float Mass = 1f;

		public bool UseGravity = true;

		public void CreateRigidBody()
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = Mass;
			rigidbody.linearDamping = Drag;
			rigidbody.angularDamping = AngularDrag;
			rigidbody.useGravity = UseGravity;
			rigidbody.isKinematic = IsKinematic;
		}
	}
}
