using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class CustomVehicleExample : Vehicle
	{
		[Header("Custom Vehicle Parameters")]
		public float UpForce = 100f;

		public bool UseDefaultInputs;

		private void Start()
		{
			SetVehicleCenterOfMass(VehicleEngine.CenterOfMass);
		}

		protected override void VehicleUpdate()
		{
			GroundCheck.GroundCheck(base.transform);
			if (UseDefaultInputs)
			{
				SetEngineInputs(JUInput.GetAxis(JUInput.Axis.MoveHorizontal), JUInput.GetAxis(JUInput.Axis.MoveVertical), JUInput.GetButton(JUInput.Buttons.JumpButton));
			}
		}

		protected override void VehiclePhysicsUpdate()
		{
			if (IsOn)
			{
				AddForwardAcceleration(_vertical * VehicleEngine.TorqueForce);
				base.transform.Rotate(0f, _horizontal * 130f * Time.deltaTime, 0f);
				if (GroundCheck.IsGrounded)
				{
					float num = Mathf.Lerp(1f, 0f, Vector3.Distance(GroundCheck.GroundHit.point, base.transform.position) / GroundCheck.RaycastDistance);
					rb.AddForceAtPosition(GroundCheck.GroundHit.normal * UpForce * num, GroundCheck.GroundHit.point);
					SimulateGroundAlignment(1f);
				}
				else
				{
					Align(Vector3.up, 0.5f);
				}
				LimitVehicleSpeed(GroundCheck.IsGrounded);
			}
		}

		private void OnDrawGizmos()
		{
			VehicleGizmo.DrawVehicleGroundCheck(GroundCheck, base.transform);
		}
	}
}
