using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class RigidBodyPlaceholder : MonoBehaviour
	{
		[SerializeField]
		private float _mass;

		public Rigidbody CreateRigidBody()
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = _mass;
			return rigidbody;
		}
	}
}
