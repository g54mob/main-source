using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class VehicleJump : MonoBehaviour
	{
		private Vehicle vehicle;

		public float JumpForce = 100f;

		public bool UseDefaultInput = true;

		private void Start()
		{
			vehicle = GetComponent<Vehicle>();
		}

		private void Update()
		{
			if (UseDefaultInput && JUInput.GetButtonDown(JUInput.Buttons.JumpButton))
			{
				Jump(JumpForce);
			}
		}

		public void Jump(float jumpForce)
		{
			if (!(vehicle == null) && vehicle.IsOn)
			{
				vehicle.Jump(jumpForce, vehicle.GroundCheck.IsGrounded);
			}
		}
	}
}
