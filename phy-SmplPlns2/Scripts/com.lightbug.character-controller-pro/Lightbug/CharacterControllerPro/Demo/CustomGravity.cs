using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[RequireComponent(typeof(Rigidbody))]
	public class CustomGravity : MonoBehaviour
	{
		public Transform planet;

		public float gravity = 10f;

		private Rigidbody rigidbody;

		private void Awake()
		{
			if (planet == null)
			{
				base.enabled = false;
				return;
			}
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.useGravity = false;
		}

		private void FixedUpdate()
		{
			Vector3 normalized = (planet.position - base.transform.position).normalized;
			rigidbody.linearVelocity += normalized * gravity * Time.deltaTime;
		}
	}
}
