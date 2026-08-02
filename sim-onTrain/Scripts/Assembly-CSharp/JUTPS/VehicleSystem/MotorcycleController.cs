using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	[AddComponentMenu("JU TPS/Vehicle System/Motorcycle Controller")]
	public class MotorcycleController : Vehicle
	{
		[HideInInspector]
		public float InclinationValue;

		[Header("Physic Settings")]
		[Range(0f, 60f)]
		public float MaxLeanAngle = 45f;

		public WheelCollider FrontWheel;

		public WheelCollider BackWheel;

		public Transform FrontWheelModel;

		public Transform BackWheelModel;

		[Header("Anti Overturn")]
		public VehicleOverturnCheck OverturnCheck;

		[Header("Looping")]
		public bool EnableLooping;

		public string LoopTag = "Loop";

		public bool IsLooping;

		[Header("Settings")]
		public bool UseDefaultInputs = true;

		private Transform RotationPivotParent;

		private Transform RotationPivotChild;

		private void Start()
		{
			CreateSteeringWheelRotationPivot(SteeringWheel);
			SetVehicleCenterOfMass(VehicleEngine.CenterOfMass);
			if (FrontWheelModel.parent != SteeringWheel)
			{
				FrontWheelModel.parent = SteeringWheel.transform;
			}
			RotationPivotParent = new GameObject("Motorcycle Lean Angle Pivot").transform;
			RotationPivotChild = new GameObject("Motorcycle Lean Angle Z").transform;
			RotationPivotChild.SetParent(RotationPivotParent);
			RotationPivotParent.position = base.transform.position;
			RotationPivotParent.hideFlags = HideFlags.HideInHierarchy;
			RotationPivotChild.SetParent(RotationPivotChild);
			RotationPivotParent.position = base.transform.position;
			RotationPivotParent.hideFlags = HideFlags.HideInHierarchy;
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
			UpdateWheelModelTransformation(FrontWheel, FrontWheelModel, JustRotateOnXAxist: true);
			UpdateWheelModelTransformation(BackWheel, BackWheelModel);
			SteeringWheel.transform.localEulerAngles = SteeringWheelRotation(SteeringWheel, FrontWheel).eulerAngles;
		}

		protected override void VehiclePhysicsUpdate()
		{
			if (!IsOn)
			{
				WheelBrake(FrontWheel);
				WheelBrake(BackWheel);
				return;
			}
			if (GroundCheck.IsGrounded)
			{
				WheelTorque(BackWheel);
				WheelTorque(FrontWheel);
			}
			WheelBrake(FrontWheel);
			WheelBrake(BackWheel);
			float num = Mathf.Lerp(GetSmoothedHorizontalMovement(), GetSmoothedHorizontalMovement() / 2.5f, GetVehicleCurrentSpeed(0.1f));
			WheelSteerAngle(FrontWheel, num * MaxSteerAngle, MaxSteerAngle);
			if (GetVehicleCurrentSpeed() > 1f)
			{
				InclinationValue = GetHorizontalMovement() * GetVehicleCurrentSpeed(2f);
			}
			else
			{
				InclinationValue = Mathf.Lerp(InclinationValue, 25f, Time.deltaTime);
			}
			InclinationValue = Mathf.Clamp(InclinationValue, 0f - MaxLeanAngle, MaxLeanAngle);
			if (!IsLooping)
			{
				MotorcycleLeanSystem();
			}
			if (!GroundCheck.IsGrounded)
			{
				Align(Vector3.up, 0.5f);
			}
			LimitVehicleSpeed(GroundCheck.IsGrounded);
			LoopSystem();
		}

		public Vector3 GetMotorcycleGroundAngle(Vector3 FrontWheelHitNormal, Vector3 BackWheelHitNormal)
		{
			return new Vector3((FrontWheelHitNormal.x + BackWheelHitNormal.x) / 2f, (FrontWheelHitNormal.y + BackWheelHitNormal.y) / 2f, (FrontWheelHitNormal.z + BackWheelHitNormal.z) / 2f);
		}

		protected virtual void MotorcycleLeanSystem()
		{
			Physics.Raycast(FrontWheelModel.position, -base.transform.up, out var hitInfo, FrontWheel.radius + 0.05f, GroundCheck.RaycastLayerMask);
			Physics.Raycast(BackWheelModel.position, -base.transform.up, out var hitInfo2, BackWheel.radius + 0.05f, GroundCheck.RaycastLayerMask);
			Vector3 zero = Vector3.zero;
			SimulateVehicleInclination(GroundAligment: (!(hitInfo.normal != Vector3.zero) || !(hitInfo2.normal != Vector3.zero)) ? Vector3.zero : GetMotorcycleGroundAngle(hitInfo.normal, hitInfo2.normal), InclinationValue: InclinationValue, MaxInclinationAngle: MaxLeanAngle, RotationPivotParent: RotationPivotParent, RotationPivotChild: RotationPivotChild, FreezeRotationToBetterSimulation: true, SimulationForce: 3f);
		}

		protected virtual void LoopSystem()
		{
			if (EnableLooping && !(GroundCheck.GroundHit.point == Vector3.zero))
			{
				IsLooping = GroundCheck.GroundHit.collider.tag == LoopTag;
				if (IsLooping)
				{
					Debug.Log("IS LOOPING");
					SimulateGroundAlignment();
				}
			}
		}

		private void OnDrawGizmos()
		{
			VehicleGizmo.DrawVector3Position(CharacterExitingPosition, base.transform, "Exit Position", Color.green);
			VehicleGizmo.DrawVehicleInclination(RotationPivotParent, RotationPivotChild);
			VehicleGizmo.DrawOverturnCheck(OverturnCheck, base.transform);
		}
	}
}
