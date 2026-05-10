using System;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(WheelCollider))]
	public class Wheel : MonoBehaviour
	{
		[Range(-1f, 1f)]
		public float SteerPercent;

		public bool DriveWheel;

		public float MaxBrakeTorque;

		public bool HandBrakeWheel;

		public Transform WheelView;

		public Transform WheelHub;

		public float MaxVisualDamageAngle;

		[Range(0f, 1f)]
		public float AntiRollBar;

		public Wheel AntiRollWheel;

		[Tooltip("The angle at which the wheel leans at the extreme points of the suspension (Only visual effect)")]
		public float MaxSuspensionWheelAngle;

		[Tooltip("If the suspension is dependent, then the angle of the wheel depends on the opposite wheel (Only visual effect)")]
		public bool DependentSuspension;

		private Transform[] ViewChilds;

		private Dictionary<Transform, Quaternion> InitialChildRotations;

		private Transform InitialParent;

		[NonSerialized]
		public Vector3 Position;

		[NonSerialized]
		public Quaternion Rotation;

		public bool IsFreeWheel;

		private Vector3 LocalPosition;

		protected VehicleController Vehicle;

		protected WheelHit Hit;

		protected float CurrentRotateAngle;

		private const float TemperatureChangeSpeed = 0.1f;

		private float GroundStiffness;

		private float BrakeSpeed;

		private float CurrentBrakeTorque;

		private GroundConfig _CurrentGroundConfig;

		public float RPM => 0f;

		public float CurrentMaxSlip => 0f;

		public float CurrentForwardSlip { get; private set; }

		public float CurrentSidewaysSlip { get; private set; }

		public float SlipNormalized { get; private set; }

		public float ForwardSlipNormalized { get; private set; }

		public float SidewaysSlipNormalized { get; private set; }

		public float SuspensionPos { get; private set; }

		public float PrevSuspensionPos { get; private set; }

		public float SuspensionPosDiff { get; private set; }

		public float WheelTemperature { get; private set; }

		public bool HasForwardSlip => false;

		public bool HasSideSlip => false;

		public WheelHit GetHit => default(WheelHit);

		public Vector3 HitPoint { get; private set; }

		public bool IsGrounded => false;

		public bool StopEmitFX { get; set; }

		public float Radius => 0f;

		public Vector3 LocalPositionOnAwake { get; private set; }

		public bool IsSteeringWheel => false;

		public WheelCollider WheelCollider { get; protected set; }

		private GroundConfig DefaultGroundConfig => null;

		public GroundConfig CurrentGroundConfig
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void FixedUpdate()
		{
		}

		private void ApplyStiffness()
		{
		}

		private void ApplyBrake()
		{
		}

		private void ApplyAntiRollForce()
		{
		}

		public virtual void LateUpdate()
		{
		}

		public void SetMotorTorque(float motorTorque, bool forceSetTroque = false)
		{
		}

		public void SetSteerAngle(float steerAngle)
		{
		}

		public void SetHandBrake(bool handBrake)
		{
		}

		public void SetBrakeTorque(float brakeTorque)
		{
		}

		private void OnResetAction()
		{
		}
	}
}
