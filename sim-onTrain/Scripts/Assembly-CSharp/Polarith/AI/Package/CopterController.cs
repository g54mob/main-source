using System;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Copter Controller")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-coptercontroller.html")]
	[DisallowMultipleComponent]
	public sealed class CopterController : RpyController
	{
		public enum FlightMode
		{
			Direct = 0,
			Forward = 1,
			ObservationPoint = 2
		}

		[Tooltip("Target point to which the copter should look while flying. Only used in 'FlightMode.ObservationPoint'.")]
		[SerializeField]
		private Transform observationPoint;

		[Tooltip("'Direct' has no turn around the Y-Axis. 'Forward' turns the copter to its current movement direction. 'Observation Point' turns the copter to the given observation point while moving to the current target.")]
		[SerializeField]
		private FlightMode flightMode;

		[Tooltip("Typically roll ranges from -1 to 1. Use this factor to increase the desired maximum value.")]
		[SerializeField]
		private float rollFactor = 20f;

		[Tooltip("Typically pitch ranges from -1 to 1. Use this factor to increase the desired maximum value.")]
		[SerializeField]
		private float pitchFactor = 20f;

		[Tooltip("Typically yaw ranges from -1 to 1. Use this factor to increase the desired maximum value.")]
		[SerializeField]
		private float yawFactor = 5f;

		[Tooltip("Typically thrust ranges from -1 to 1. Use this factor to increase the desired maximum value.")]
		[SerializeField]
		private float thrustFactor = 30f;

		[SerializeField]
		private PidController thrustController;

		[Tooltip("Controls movement speed through pitch and roll. Thus, the agent moves faster but becomes physically more instable.")]
		[SerializeField]
		private float speedFactor = 5f;

		private static int decisionsSize = 100;

		private Vector3[] decisions = new Vector3[decisionsSize];

		private int decisionCounter;

		private Vector3 avgDecision;

		private float startingYaw;

		private CopterPhysics physics;

		private float currentRoll;

		private float currentPitch;

		private float angleToUp;

		public Transform ObservationPoint
		{
			get
			{
				return observationPoint;
			}
			set
			{
				observationPoint = value;
			}
		}

		public FlightMode FlightModus
		{
			get
			{
				return flightMode;
			}
			set
			{
				flightMode = value;
			}
		}

		public float RollFactor
		{
			get
			{
				return rollFactor;
			}
			set
			{
				rollFactor = value;
			}
		}

		public float PitchFactor
		{
			get
			{
				return pitchFactor;
			}
			set
			{
				pitchFactor = value;
			}
		}

		public float YawFactor
		{
			get
			{
				return yawFactor;
			}
			set
			{
				yawFactor = value;
			}
		}

		public float ThrustFactor
		{
			get
			{
				return thrustFactor;
			}
			set
			{
				thrustFactor = value;
			}
		}

		public PidController ThrustController
		{
			get
			{
				return thrustController;
			}
			set
			{
				thrustController = value;
			}
		}

		public float SpeedFactor
		{
			get
			{
				return speedFactor;
			}
			set
			{
				speedFactor = value;
			}
		}

		protected override void CalculatePitch()
		{
			Vector3 vector = avgDecision;
			Vector3 vector2 = Vector3.ProjectOnPlane(base.transform.right, Vector3.up);
			Vector3 to = Vector3.ProjectOnPlane(base.transform.up, vector2);
			currentPitch = SignedAngle(Vector3.up, to, vector2);
			float num = vector.normalized.z * SpeedFactor;
			pitch = num - currentPitch;
		}

		protected override void CalculateRoll()
		{
			Vector3 vector = avgDecision;
			Vector3 vector2 = Vector3.ProjectOnPlane(base.transform.forward, Vector3.up);
			Vector3 to = Vector3.ProjectOnPlane(base.transform.up, vector2);
			currentRoll = SignedAngle(Vector3.up, to, vector2);
			float num = (0f - vector.normalized.x) * SpeedFactor;
			roll = num - currentRoll;
		}

		protected override void CalculateForce()
		{
			Vector3 velocity = base.Body.velocity;
			Vector3 decidedDirection = base.Context.DecidedDirection;
			float value = Vector3.Angle(velocity, decidedDirection) * (MathF.PI / 180f);
			value = Mathf.Clamp(value, 0f, 1f);
			float num = ThrustFactor * Mathf.Cos(value) * decidedDirection.y - velocity.y;
			angleToUp = Vector3.Angle(base.transform.up, Vector3.up) * (MathF.PI / 180f);
			num /= Mathf.Cos(angleToUp);
			if (base.UsePidController)
			{
				num = ThrustController.GetOutput(num);
			}
			float num2 = (0f - Physics.gravity.y) * base.Body.mass;
			num = Mathf.Clamp(num, (0f - num2) / 2f, num2 / 2f);
			num += num2 / Mathf.Cos(angleToUp);
			if (num < 0f)
			{
				num = 0f;
			}
			force = num * base.transform.up;
		}

		protected override void CalculateYaw()
		{
			Vector3 vector = base.transform.forward;
			switch (flightMode)
			{
			case FlightMode.Direct:
			{
				float num = base.transform.eulerAngles.y;
				if (num > 180f)
				{
					num -= 360f;
				}
				float num2 = startingYaw - num;
				if (num2 > 180f)
				{
					num2 -= 360f;
				}
				yaw = num2 * YawFactor;
				return;
			}
			case FlightMode.Forward:
				vector = base.Context.DecidedDirection;
				break;
			case FlightMode.ObservationPoint:
				if (ObservationPoint == null)
				{
					Debug.LogWarning("Warning! No observation point given. This flight mode won\u00b4t work.");
					yaw = 0f;
					return;
				}
				vector = ObservationPoint.position - base.transform.position;
				break;
			}
			Vector3 vector2 = Vector3.ProjectOnPlane(vector, Vector3.up);
			float num3 = Mathf.Sign(Vector3.Cross(base.transform.forward, vector2).y);
			yaw = num3 * YawFactor * Vector3.Angle(vector2, Vector3.ProjectOnPlane(base.transform.forward, Vector3.up));
			yaw = ((Mathf.Abs(yaw) < 1f) ? 0f : yaw);
		}

		protected override void LimitControls()
		{
			rollLimit = RollFactor;
			pitchLimit = PitchFactor;
			yawLimit = YawFactor;
			if (Mathf.Abs(currentRoll + roll) > rollLimit)
			{
				roll = Mathf.Sign(roll) * rollLimit - currentRoll;
			}
			if (Mathf.Abs(currentPitch + pitch) > pitchLimit)
			{
				pitch = Mathf.Sign(pitch) * pitchLimit - currentPitch;
			}
			if (base.Context.DecidedDirection.normalized.y <= -0.95f)
			{
				pitch = 0f - currentPitch;
				roll = 0f - currentRoll;
			}
			yaw = Mathf.Clamp(yaw, 0f - yawLimit, yawLimit);
		}

		protected override void PreprocessData()
		{
			avgDecision -= decisions[decisionCounter] / decisionsSize;
			avgDecision += base.Context.LocalDecidedDirection / decisionsSize;
			decisions[decisionCounter] = base.Context.LocalDecidedDirection;
			decisionCounter = ++decisionCounter % decisionsSize;
		}

		private void Start()
		{
			Time.timeScale = 2.5f;
			startingYaw = base.transform.eulerAngles.y;
			avgDecision = Vector3.zero;
			if (base.Body == null)
			{
				base.Body = GetComponent<Rigidbody>();
				if (base.Body == null)
				{
					Debug.LogError("No Rigidbody attached");
				}
			}
			base.Body.maxAngularVelocity = 3f;
		}
	}
}
