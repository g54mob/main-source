using Ezereal;
using UnityEngine;

namespace Brewery.Vehicle
{
	[RequireComponent(typeof(EzerealCarController))]
	public class EzerealCarControllerAdapter : MonoBehaviour, IVehicleController
	{
		private EzerealCarController car;

		private EzerealWheelFrictionController frictionController;

		public float CurrentSpeed => 0f;

		public bool IsEngineStarted => false;

		public bool HasDriver => false;

		public float AccelerationValue => 0f;

		public float BrakeValue => 0f;

		public float HandbrakeValue => 0f;

		public int WheelCount => 0;

		public bool IsDrifting => false;

		public bool IsReversing => false;

		public bool IsGrounded => false;

		public VehicleType VehicleType => default(VehicleType);

		public Rigidbody VehicleRigidbody => null;

		public WheelCollider GetWheelCollider(int index)
		{
			return null;
		}

		public float GetWheelRPM(int index)
		{
			return 0f;
		}

		private void Awake()
		{
		}
	}
}
