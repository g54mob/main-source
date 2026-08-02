using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class VehicleAirRotation : MonoBehaviour
	{
		private Vehicle vehicle;

		public bool UseDefaultInputs = true;

		public float Force = 200f;

		public bool X = true;

		public bool Y = true;

		public bool Z = true;

		private void Start()
		{
			vehicle = GetComponent<Vehicle>();
		}

		private void Update()
		{
			if (UseDefaultInputs)
			{
				float axis = JUInput.GetAxis(JUInput.Axis.MoveVertical);
				float axis2 = JUInput.GetAxis(JUInput.Axis.MoveHorizontal);
				RotateVehicle(new Vector3(axis, axis2, 0f), vehicle.GroundCheck.IsGrounded);
			}
		}

		public void RotateVehicle(Vector3 Torque, bool IsGrounded)
		{
			if (!IsGrounded && vehicle.IsOn)
			{
				Vector3 vector = Torque;
				if (!X)
				{
					vector.x = 0f;
				}
				if (!Y)
				{
					vector.y = 0f;
				}
				if (!Z)
				{
					vector.z = 0f;
				}
				vehicle.rb.AddRelativeTorque(vector * Force, ForceMode.Acceleration);
			}
		}
	}
}
