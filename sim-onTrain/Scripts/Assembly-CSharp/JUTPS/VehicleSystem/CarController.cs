using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	[AddComponentMenu("JU TPS/Vehicle System/Car Controller")]
	public class CarController : Vehicle
	{
		[Header("Wheels")]
		public WheelCollider[] WheelColliders;

		public Transform[] WheelModels;

		[Header("Anti Overturn")]
		public VehicleOverturnCheck OverturnCheck;

		[Header("Settings")]
		public bool UseDefaultInputs = true;

		private void Start()
		{
			CreateSteeringWheelRotationPivot(SteeringWheel);
			SetVehicleCenterOfMass(VehicleEngine.CenterOfMass);
		}

		protected override void VehicleUpdate()
		{
			GroundCheck.GroundCheck(base.transform);
			if (UseDefaultInputs)
			{
				SetEngineInputs(JUInput.GetAxis(JUInput.Axis.MoveHorizontal), JUInput.GetAxis(JUInput.Axis.MoveVertical), JUInput.GetButton(JUInput.Buttons.JumpButton));
			}
			OverturnCheck.OverturnCheck(base.transform);
			OverturnCheck.AntiOverturn(base.transform);
			for (int i = 0; i < WheelColliders.Length; i++)
			{
				UpdateWheelModelTransformation(WheelColliders[i], WheelModels[i]);
			}
			SteeringWheel.transform.localEulerAngles = SteeringWheelRotation(SteeringWheel, WheelColliders[0], 2f).eulerAngles;
		}

		protected override void VehiclePhysicsUpdate()
		{
			if (!IsOn)
			{
				for (int i = 0; i < WheelColliders.Length; i++)
				{
					WheelBrake(WheelColliders[i]);
				}
				return;
			}
			for (int j = 0; j < WheelColliders.Length; j++)
			{
				WheelTorque(WheelColliders[j]);
				WheelBrake(WheelColliders[j]);
			}
			float num = Mathf.Lerp(GetSmoothedHorizontalMovement(), GetSmoothedHorizontalMovement() / 4f, GetSmoothedForwardMovement() * GetVehicleCurrentSpeed(0.1f));
			WheelSteerAngle(WheelColliders[0], num * MaxSteerAngle, MaxSteerAngle);
			WheelSteerAngle(WheelColliders[1], num * MaxSteerAngle, MaxSteerAngle);
			if (!GroundCheck.IsGrounded)
			{
				Align(Vector3.up, 0.5f);
			}
			LimitVehicleSpeed(GroundCheck.IsGrounded);
		}

		private void OnDrawGizmos()
		{
			VehicleGizmo.DrawVector3Position(CharacterExitingPosition, base.transform, "Exit Position", Color.green);
			VehicleGizmo.DrawOverturnCheck(OverturnCheck, base.transform);
			VehicleGizmo.DrawVehicleGroundCheck(GroundCheck, base.transform);
		}
	}
}
