using UnityEngine;

namespace Player.Weapons
{
	[RequireComponent(typeof(Rigidbody))]
	public class ProjectileGravity : MonoBehaviour
	{
		[Tooltip("Множник гравітації. 0 = невагомість, 1 = стандарт, 2 = подвійна.")]
		[Range(0f, 5f)]
		public float gravityScale = 1f;

		private static readonly Vector3 BaseGravity = new Vector3(0f, -9.81f, 0f);

		private Rigidbody _rb;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			_rb.useGravity = false;
		}

		private void FixedUpdate()
		{
			_rb.AddForce(BaseGravity * (gravityScale * _rb.mass), ForceMode.Force);
		}
	}
}
