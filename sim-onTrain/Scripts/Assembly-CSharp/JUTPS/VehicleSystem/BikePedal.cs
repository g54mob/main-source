using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class BikePedal : MonoBehaviour
	{
		[Header("Pedal Rotation")]
		public Vehicle Bike;

		public WheelCollider BackWheel;

		public float PedalRotateSpeed = 0.2f;

		public Transform RightPedal;

		public Transform LeftPedal;

		[Header("IK Targets")]
		public Transform FootUpOrientator;

		public Transform RightFootTarget;

		public Transform LeftFootTarget;

		private void Start()
		{
			Bike = GetComponentInParent<Vehicle>();
			if (FootUpOrientator == null && Bike != null)
			{
				FootUpOrientator = Bike.transform;
			}
		}

		private void Update()
		{
			if (!(BackWheel == null) && !(FootUpOrientator == null) && !(Bike == null) && !(LeftFootTarget == null) && !(RightFootTarget == null) && Bike.GroundCheck.IsGrounded)
			{
				base.transform.Rotate(BackWheel.motorTorque * (PedalRotateSpeed * Bike.GetVehicleCurrentSpeed() / Bike.VehicleEngine.MaxVelocity) * Time.deltaTime, 0f, 0f);
				Quaternion rotation = Quaternion.FromToRotation(RightPedal.up, FootUpOrientator.up) * RightPedal.rotation;
				RightPedal.rotation = rotation;
				Quaternion rotation2 = Quaternion.FromToRotation(LeftPedal.up, FootUpOrientator.up) * LeftPedal.rotation;
				LeftPedal.rotation = rotation2;
			}
		}
	}
}
