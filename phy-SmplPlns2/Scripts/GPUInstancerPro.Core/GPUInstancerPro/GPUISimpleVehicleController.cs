using UnityEngine;

namespace GPUInstancerPro
{
	[RequireComponent(typeof(Rigidbody))]
	public class GPUISimpleVehicleController : GPUIInputHandler
	{
		public float engineTorque = 3500f;

		public float enginePower = 4000f;

		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			_rigidbody.AddRelativeTorque(Vector3.up * GetAxis("Horizontal") * engineTorque * Time.deltaTime);
			_rigidbody.AddRelativeForce(Vector3.forward * GetAxis("Vertical") * enginePower * Time.deltaTime);
		}
	}
}
