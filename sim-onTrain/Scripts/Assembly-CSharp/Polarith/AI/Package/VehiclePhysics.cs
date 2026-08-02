using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Vehicle Physics")]
	public class VehiclePhysics : MonoBehaviour
	{
		[Tooltip("All wheelCollider of the vehicle.")]
		public List<WheelCollider> WheelColliders = new List<WheelCollider>();

		[Tooltip("A subset of 'WheelColliders' containing all instances to which motor torque is applied.")]
		public List<WheelCollider> MotorWheels = new List<WheelCollider>();

		[Tooltip("A subset of 'WheelColliders' containing all instances to which brake torque is applied.")]
		public List<WheelCollider> BrakeWheels = new List<WheelCollider>();

		[Tooltip("A subset of 'WheelColliders' containing all instances that are able to steer.")]
		public List<WheelCollider> SteeringWheels = new List<WheelCollider>();

		[Tooltip("The mesh representation of the wheels. They are rotated according to the corresponding 'WheelColliders'")]
		public List<GameObject> WheelMeshes = new List<GameObject>();

		[Tooltip("Maximum possible angle for steering in degrees..")]
		public float MaximumSteerAngle = 25f;

		[Range(0f, 1f)]
		[Tooltip("Determines the magnitude of the applied steering helper. From 0 = raw physics to 1 the car will grip in the direction it is facing.")]
		public float SteerHelper;

		[Range(0f, 1f)]
		[Tooltip("The magnitude of the applied traction control. From 0 = no traction control to 1 = full interference.")]
		public float TractionControl;

		[Tooltip("The torque that is applied to all together over the motor wheels. Hence, the torque per wheel is FullTorqueOverAllWheels / MotorWheels.Count.")]
		public float FullTorqueOverAllWheels;

		[Tooltip("The torque for driving backwards.")]
		public float ReverseTorque;

		[Tooltip("Force to create more grip.")]
		public float Downforce = 100f;

		[Tooltip("The maximum speed of the vehicle in km/h.")]
		public float Topspeed = 200f;

		[Tooltip("A forward slip bigger than this will activate TractionControl.")]
		public float SlipLimit;

		[Tooltip("Brake torque for every BrakeWheel.")]
		public float BrakeTorque;

		private Rigidbody body;

		private float oldRotation;

		private float currentTorque;

		public void Move(float steering, float acceleration, float brake)
		{
			if (base.enabled)
			{
				steering = Mathf.Clamp(steering, -1f, 1f);
				acceleration = Mathf.Clamp(acceleration, 0f, 1f);
				brake = -1f * Mathf.Clamp(brake, -1f, 0f);
				ApplySteeringAngle(steering);
				ApplySteerHelper();
				ApplyDrive(acceleration, brake);
				CapSpeed();
				ApplyDownforce();
				ApplyTractionControl();
			}
		}

		private void Start()
		{
			body = GetComponent<Rigidbody>();
			currentTorque = FullTorqueOverAllWheels - TractionControl * FullTorqueOverAllWheels;
			WheelColliders[0].ConfigureVehicleSubsteps(1f, 12, 15);
		}

		private void Update()
		{
			for (int i = 0; i < WheelColliders.Count; i++)
			{
				WheelColliders[i].GetWorldPose(out var pos, out var quat);
				WheelMeshes[i].transform.position = pos;
				WheelMeshes[i].transform.rotation = quat;
			}
		}

		private void ApplyDrive(float acceleration, float brake)
		{
			float motorTorque = 0f;
			if (MotorWheels.Count > 0)
			{
				motorTorque = acceleration * (currentTorque / (float)MotorWheels.Count);
			}
			foreach (WheelCollider motorWheel in MotorWheels)
			{
				motorWheel.motorTorque = motorTorque;
			}
			foreach (WheelCollider brakeWheel in BrakeWheels)
			{
				brakeWheel.brakeTorque = 0f;
			}
			if (body.velocity.magnitude > 1f && Vector3.Angle(base.transform.forward, body.velocity) < 50f)
			{
				for (int i = 0; i < BrakeWheels.Count; i++)
				{
					BrakeWheels[i].brakeTorque = BrakeTorque * brake;
				}
			}
			else if (brake > 0f)
			{
				for (int j = 0; j < MotorWheels.Count; j++)
				{
					MotorWheels[j].motorTorque = (0f - ReverseTorque) * brake;
				}
			}
		}

		private void ApplySteeringAngle(float steeringAngle)
		{
			steeringAngle *= MaximumSteerAngle;
			foreach (WheelCollider steeringWheel in SteeringWheels)
			{
				steeringWheel.steerAngle = steeringAngle;
			}
		}

		private void ApplyDownforce()
		{
			body.AddForce(-base.transform.up * Downforce * body.velocity.magnitude);
		}

		private void ApplyTractionControl()
		{
			for (int i = 0; i < MotorWheels.Count; i++)
			{
				MotorWheels[0].GetGroundHit(out var hit);
				if (hit.forwardSlip >= SlipLimit && currentTorque >= 0f)
				{
					currentTorque -= 10f * TractionControl;
					continue;
				}
				currentTorque += 10f * TractionControl;
				if (currentTorque > FullTorqueOverAllWheels)
				{
					currentTorque = FullTorqueOverAllWheels;
				}
			}
		}

		private void ApplySteerHelper()
		{
			foreach (WheelCollider wheelCollider in WheelColliders)
			{
				wheelCollider.GetGroundHit(out var hit);
				if (hit.normal == Vector3.zero)
				{
					return;
				}
			}
			if (Mathf.Abs(oldRotation - base.transform.eulerAngles.y) < 10f)
			{
				Quaternion quaternion = Quaternion.AngleAxis((base.transform.eulerAngles.y - oldRotation) * SteerHelper, Vector3.up);
				body.velocity = quaternion * body.velocity;
			}
			oldRotation = base.transform.eulerAngles.y;
		}

		private void CapSpeed()
		{
			if (body.velocity.magnitude * 3.6f > Topspeed)
			{
				body.velocity = Topspeed / 3.6f * body.velocity.normalized;
			}
		}
	}
}
