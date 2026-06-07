using UnityEngine;

namespace Brewery.Vehicle
{
	public interface IVehicleController
	{
		float CurrentSpeed { get; }

		bool IsEngineStarted { get; }

		bool HasDriver { get; }

		float AccelerationValue { get; }

		float BrakeValue { get; }

		float HandbrakeValue { get; }

		int WheelCount { get; }

		bool IsDrifting { get; }

		bool IsReversing { get; }

		bool IsGrounded { get; }

		VehicleType VehicleType { get; }

		Rigidbody VehicleRigidbody { get; }

		WheelCollider GetWheelCollider(int index);

		float GetWheelRPM(int index);
	}
}
