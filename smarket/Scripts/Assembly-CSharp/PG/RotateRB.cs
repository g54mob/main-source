using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(Rigidbody))]
	public class RotateRB : MonoBehaviour
	{
		public Vector3 RotateVelocity;

		private Rigidbody RB;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
