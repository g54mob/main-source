using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GravityScript : MonoBehaviour
	{
		private Rigidbody _rigidBody;

		public Vector3 GravityForce { get; set; }

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
			_rigidBody.useGravity = false;
		}

		private void FixedUpdate()
		{
			_rigidBody.AddForce(GravityForce);
		}

		private void OnCollisionEnter(Collision collision)
		{
		}
	}
}
