using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Brewery.Vehicle
{
	public class MopedController : NetworkBehaviour, IVehicleController
	{
		[CompilerGenerated]
		private sealed class _003CMonitorPhysicsState_003Ed__196 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MopedController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CMonitorPhysicsState_003Ed__196(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("References")]
		public Rigidbody vehicleRB;

		public WheelCollider frontWheelCollider;

		public WheelCollider rearWheelCollider;

		[SerializeField]
		private Transform frontWheelMesh;

		[SerializeField]
		private Transform rearWheelMesh;

		[SerializeField]
		private Transform frontFender;

		[SerializeField]
		private Transform handlebar;

		[Header("Lean Settings")]
		[Tooltip("The visual body that rotates for leaning effect")]
		[SerializeField]
		private Transform leanBody;

		[SerializeField]
		private float maxLeanAngle;

		[Tooltip("How quickly the lean responds (lower = smoother, higher = snappier)")]
		[SerializeField]
		private float leanSmoothTime;

		[Tooltip("Maximum lean change rate (degrees/second)")]
		[SerializeField]
		private float maxLeanSpeed;

		[Tooltip("Extra smoothing for the visual lean only (seconds)")]
		[SerializeField]
		private float visualLeanSmoothTime;

		[Tooltip("Visual lean rotation smoothing speed")]
		[SerializeField]
		private float visualLeanSlerpSpeed;

		[Header("Seat Configuration")]
		[Tooltip("Driver seat position")]
		public Transform driverSeatPosition;

		private bool hasDriver;

		private ulong driverClientId;

		[Header("Settings")]
		public float maxForwardSpeed;

		public float maxReverseSpeed;

		public float brakePower;

		public float maxSteerAngle;

		public float steeringSpeed;

		public float stopThreshold;

		[Header("Arcade Drive")]
		[Tooltip("Forward acceleration (m/s^2). Higher = snappier takeoff.")]
		[SerializeField]
		private float driveAcceleration;

		[Tooltip("Reverse acceleration (m/s^2). Keep low — mopeds reverse slowly.")]
		[SerializeField]
		private float reverseAcceleration;

		[Tooltip("Braking deceleration (m/s^2).")]
		[SerializeField]
		private float brakeDeceleration;

		[Tooltip("Coasting deceleration (m/s^2) when no input.")]
		[SerializeField]
		private float coastingDeceleration;

		[Tooltip("Extra headroom on speed cap to prevent jitter.")]
		[SerializeField]
		private float speedCapBuffer;

		[Tooltip("Wheel torque used for RPM/feel (Nm).")]
		[SerializeField]
		private float motorTorque;

		[Tooltip("Torque falloff by speed (0-1 normalized speed).")]
		[SerializeField]
		private AnimationCurve torqueBySpeed;

		[Tooltip("Speed (km/h) below which reverse can engage.")]
		[SerializeField]
		private float reverseEngageSpeed;

		[Tooltip("Hold brake this long before reverse engages.")]
		[SerializeField]
		private float reverseEngageDelay;

		[Header("Input Ramping (Weighty Feel)")]
		[Tooltip("Seconds for throttle to ramp 0→1 when holding W. Higher = weightier, slower spool-up.")]
		[Range(0.05f, 1.5f)]
		[SerializeField]
		private float throttleRampUpTime;

		[Tooltip("Seconds for throttle to fall to 0 when releasing W.")]
		[Range(0.05f, 1f)]
		[SerializeField]
		private float throttleRampDownTime;

		[Tooltip("Seconds for reverse input to ramp 0→1 once reverse has engaged. Stops rocket-like reverse.")]
		[Range(0.1f, 2f)]
		[SerializeField]
		private float reverseRampUpTime;

		[Tooltip("Seconds for brake input to ramp 0→1 when braking from forward speed.")]
		[Range(0.05f, 1f)]
		[SerializeField]
		private float brakeRampUpTime;

		[Header("Arcade Steering")]
		[Tooltip("Steer boost at low speed.")]
		[SerializeField]
		private float lowSpeedSteerMultiplier;

		[Tooltip("Steer reduction at high speed.")]
		[SerializeField]
		private float highSpeedSteerMultiplier;

		[Tooltip("Yaw torque applied for quick turning (m/s^2).")]
		[SerializeField]
		private float yawTorque;

		[Tooltip("Yaw torque when airborne (m/s^2).")]
		[SerializeField]
		private float yawTorqueInAir;

		[Header("Arcade Stability")]
		[Tooltip("Sideways velocity damping (higher = tighter handling).")]
		[SerializeField]
		private float lateralGrip;

		[Tooltip("Sideways grip multiplier while handbraking.")]
		[SerializeField]
		private float handbrakeGripMultiplier;

		[Tooltip("Upright stabilizing torque (m/s^2).")]
		[SerializeField]
		private float uprightTorque;

		[Tooltip("Upright stabilizing torque while airborne (m/s^2).")]
		[SerializeField]
		private float uprightTorqueInAir;

		[Tooltip("Do not apply upright torque below this tilt angle (degrees).")]
		[SerializeField]
		private float uprightDeadzoneAngle;

		[Tooltip("Tilt angle (degrees) at which full upright torque is applied.")]
		[SerializeField]
		private float uprightMaxAngle;

		[Tooltip("Upright torque smoothing speed (higher = snappier, lower = smoother).")]
		[SerializeField]
		private float uprightSmoothingSpeed;

		[Header("Air Control (Anti-Bump-Spin)")]
		[Tooltip("Per-second damping of yaw angular velocity while airborne (0 = none, 5+ = aggressive).")]
		[SerializeField]
		private float airYawDamping;

		[Tooltip("Per-second damping of pitch/roll angular velocity while airborne.")]
		[SerializeField]
		private float airTiltDamping;

		[Tooltip("Multiplier applied to steering input while airborne (1 = full, 0 = no air steering).")]
		[Range(0f, 1f)]
		[SerializeField]
		private float airSteeringMultiplier;

		[Tooltip("Downforce applied while airborne to keep the moped grounded (m/s^2).")]
		[SerializeField]
		private float airDownforce;

		[Header("Stuck Detection (Driver-Only Notification)")]
		[Tooltip("If on, notifies the local driver (only) when the wheels are spinning hard but the moped isn't moving — telling them they can hold left-click on the map to reset.")]
		[SerializeField]
		private bool enableStuckNotification;

		[Tooltip("Moped counts as 'not moving' below this speed (km/h).")]
		[Range(0f, 5f)]
		[SerializeField]
		private float stuckSpeedThreshold;

		[Tooltip("A wheel is 'spinning hard' above this absolute RPM.")]
		[Range(50f, 1000f)]
		[SerializeField]
		private float stuckWheelRpmThreshold;

		[Tooltip("Stuck-with-spinning-wheels: how long the wheels must spin while not moving before the notification fires (clear-cut stuck signal, can be short).")]
		[Range(1f, 15f)]
		[SerializeField]
		private float stuckDetectionTime;

		[Tooltip("Stuck-without-spinning-wheels (wedged/upside down): how long to wait before notifying. Longer than the spinning case so we don't false-positive at intersections or behind blocked traffic.")]
		[Range(2f, 30f)]
		[SerializeField]
		private float stuckDetectionTimeWedged;

		[Tooltip("Cooldown between stuck notifications (seconds).")]
		[Range(5f, 120f)]
		[SerializeField]
		private float stuckNotificationCooldown;

		private float _stuckStartTime;

		private float _lastStuckNotificationTime;

		[Header("Rigidbody Settings")]
		[SerializeField]
		private float rigidbodyMass;

		[SerializeField]
		private float rigidbodyDrag;

		[SerializeField]
		private float rigidbodyAngularDrag;

		[SerializeField]
		private Vector3 centerOfMassOffset;

		[Header("Collision Safety")]
		[Tooltip("Maximum velocity (m/s) the moped can reach. Prevents extreme physics from collisions.")]
		[SerializeField]
		private float maxVelocity;

		[Tooltip("Maximum angular velocity (rad/s) to prevent tumbling from collisions.")]
		[SerializeField]
		private float maxAngularVelocity;

		[Header("WheelCollider Physics (Feel)")]
		[SerializeField]
		private float suspensionDistance;

		[SerializeField]
		private float suspensionSpring;

		[SerializeField]
		private float suspensionDamper;

		[SerializeField]
		private float suspensionTargetPosition;

		[SerializeField]
		private float forwardFrictionStiffness;

		[SerializeField]
		private float sidewaysFrictionStiffness;

		[Header("Drift Settings (Spacebar)")]
		[SerializeField]
		private bool enableDrifting;

		[Tooltip("Brake torque applied to rear wheel when handbrake is held (higher = stronger brake)")]
		[Range(500f, 10000f)]
		[SerializeField]
		private float handbrakePower;

		[Tooltip("Multiplier for sideways slip during drift (higher = more slide)")]
		[SerializeField]
		private float driftExtremumSlipMultiplier;

		[Tooltip("Multiplier for sideways grip during drift (lower = less grip)")]
		[SerializeField]
		private float driftExtremumValueMultiplier;

		[Tooltip("Default extremum slip when not drifting")]
		[SerializeField]
		private float normalExtremumSlip;

		[Tooltip("Default extremum value when not drifting")]
		[SerializeField]
		private float normalExtremumValue;

		[Header("Debug Info")]
		[SerializeField]
		private float currentSpeed;

		[SerializeField]
		private float currentAccelerationValue;

		[SerializeField]
		private float currentBrakeValue;

		[SerializeField]
		private float currentHandbrakeValue;

		[SerializeField]
		private float currentSteerAngle;

		[SerializeField]
		private float targetSteerAngle;

		[SerializeField]
		private float currentLeanAngle;

		[SerializeField]
		private bool isDrifting;

		[SerializeField]
		private bool showDebugLogs;

		[Header("Wheel Smoothing (Non-Owner)")]
		[SerializeField]
		private float wheelRotationSmoothSpeed;

		[SerializeField]
		private float wheelSuspensionSmoothSpeed;

		[SerializeField]
		private float wheelSteerSmoothSpeed;

		[Header("Custom Position Smoothing (Non-Owner)")]
		[Tooltip("Adds extra smoothing layer on top of CNT interpolation")]
		[SerializeField]
		private bool useCustomPositionSmoothing;

		[Tooltip("Time to reach target position (lower = faster response). 0.05-0.15 recommended.")]
		[SerializeField]
		private float positionSmoothTime;

		[Tooltip("Time to reach target rotation (lower = faster response). 0.05-0.15 recommended.")]
		[SerializeField]
		private float rotationSmoothTime;

		[Tooltip("How far ahead to predict vehicle position (compensates for smoothing lag). 0 = no prediction.")]
		[SerializeField]
		private float predictionTime;

		private WheelFrictionCurve rearWheelSidewaysFriction;

		private float leanVelocity;

		private float visualLeanAngle;

		private float visualLeanVelocity;

		private Vector3 smoothedUprightTorque;

		private float reverseRequestTimer;

		private bool reverseEngaged;

		private float effectiveThrottle;

		private float effectiveBrake;

		private NetworkVariable<float> netCurrentSteerAngle;

		private NetworkVariable<float> netCurrentSpeed;

		private NetworkVariable<float> netYawRate;

		private NetworkVariable<float> netLeanAngle;

		private NetworkVariable<bool> netHasDriver;

		private NetworkVariable<bool> netIsEngineStarted;

		private NetworkVariable<float> netFrontWheelRotation;

		private NetworkVariable<float> netRearWheelRotation;

		private NetworkVariable<float> netFrontSuspension;

		private NetworkVariable<float> netRearSuspension;

		private float localFrontRotation;

		private float localRearRotation;

		private float smoothedFrontRotation;

		private float smoothedRearRotation;

		private float smoothedFrontSuspension;

		private float smoothedRearSuspension;

		private float smoothedSteerAngle;

		private Vector3 customSmoothedPosition;

		private Quaternion customSmoothedRotation;

		private Vector3 positionSmoothVelocity;

		private float rotVelX;

		private float rotVelY;

		private float rotVelZ;

		private bool customSmoothingInitialized;

		private Vector3 lastTargetPosition;

		private Vector3 targetVelocity;

		private Quaternion lastTargetRotation;

		private Vector3 targetAngularVelocity;

		private bool isEngineStarted;

		private bool _isLocalOwner;

		private bool _exitAcknowledgedByClient;

		private float _originalDrag;

		private const float PARKED_DRAG = 2f;

		private float _lastVehiclePushTime;

		private const float VEHICLE_PUSH_COOLDOWN = 0.5f;

		private Vector3 _clientExitPosition;

		private Quaternion _clientExitRotation;

		private bool _hasClientExitPosition;

		public bool ExitAcknowledged => false;

		public Vector3 ClientExitPosition => default(Vector3);

		public Quaternion ClientExitRotation => default(Quaternion);

		public bool HasClientExitPosition => false;

		public float CurrentSpeed => 0f;

		public float NetworkedSpeed => 0f;

		public bool IsEngineStarted => false;

		bool IVehicleController.HasDriver => false;

		public float AccelerationValue => 0f;

		public float BrakeValue => 0f;

		public float HandbrakeValue => 0f;

		public int WheelCount => 0;

		bool IVehicleController.IsDrifting => false;

		public bool IsReversing => false;

		public float CurrentSteerAngle => 0f;

		public float NetworkedSteerAngle => 0f;

		public float NetworkedYawRate => 0f;

		public bool IsGrounded => false;

		public VehicleType VehicleType => default(VehicleType);

		public Rigidbody VehicleRigidbody => null;

		public void ResetExitAcknowledgment()
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnGainedOwnership()
		{
		}

		public override void OnLostOwnership()
		{
		}

		private void OnDriverStateChanged(bool previousValue, bool newValue)
		{
		}

		private void OnLeanAngleChanged(float previousValue, float newValue)
		{
		}

		private void OnEngineStateChanged(bool previousValue, bool newValue)
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnAccelerate(InputValue accelerationValue)
		{
		}

		private void OnBrake(InputValue brakeValue)
		{
		}

		private void OnSteer(InputValue turnValue)
		{
		}

		private void OnHandbrake(InputValue handbrakeValue)
		{
		}

		private void FixedUpdate()
		{
		}

		private void ApplyLeanVisual()
		{
		}

		private void UpdateSpeed()
		{
		}

		private float GetLocalYawRate()
		{
			return 0f;
		}

		private void TickStuckDetection()
		{
		}

		private void ApplyDrive()
		{
		}

		private void ApplyCoast()
		{
		}

		private void ApplySteering()
		{
		}

		private void ApplyLean()
		{
		}

		private void ApplyLateralGrip()
		{
		}

		private void ApplyStability()
		{
		}

		private Vector3 GetUprightReference()
		{
			return default(Vector3);
		}

		private void ApplyHandbrake()
		{
		}

		private void StartDrifting(float handbrakeAmount)
		{
		}

		private void StopDrifting()
		{
		}

		private void UpdateWheelMeshes()
		{
		}

		private void UpdateFrontFender()
		{
		}

		private void UpdateWheel(WheelCollider col, Transform mesh)
		{
		}

		private float GetWheelSuspensionOffset(WheelCollider col)
		{
			return 0f;
		}

		private void UpdateWheelFromNetwork(Transform mesh, WheelCollider col, float rotationAngle, float steerAngle, float suspensionOffset)
		{
		}

		private void SmoothWheelValuesForNonOwner()
		{
		}

		private void SetWheelCollidersEnabled(bool enabled)
		{
		}

		private void LateUpdate()
		{
		}

		private void ApplyCustomPositionSmoothing()
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void UpdateLeanAngleServerRpc(float leanAngle)
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		public void SetDriverRpc(ulong clientId, bool isDriver)
		{
		}

		[ClientRpc]
		public void PrepareToExitVehicleClientRpc(ulong targetClientId)
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void AcknowledgeExitReadyServerRpc(Vector3 clientPosition, Quaternion clientRotation, RpcParams rpcParams = default(RpcParams))
		{
		}

		public bool HasDriver()
		{
			return false;
		}

		public ulong GetDriverClientId()
		{
			return 0uL;
		}

		public Transform GetDriverSeatPosition()
		{
			return null;
		}

		[ContextMenu("Apply Arcade Preset")]
		public void ApplyArcadePreset()
		{
		}

		private void ConfigureWheelCollider(WheelCollider wheel, string wheelName)
		{
		}

		private void UpdateAuthorityState()
		{
		}

		private bool ValidateInput(string inputType)
		{
			return false;
		}

		private void ValidatePhysicsSettings()
		{
		}

		[IteratorStateMachine(typeof(_003CMonitorPhysicsState_003Ed__196))]
		private IEnumerator MonitorPhysicsState()
		{
			return null;
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void RequestVehiclePushRpc(ulong targetVehicleNetId, Vector3 impactVelocity, float hitterMass)
		{
		}

		public WheelCollider GetWheelCollider(int index)
		{
			return null;
		}

		public float GetWheelRPM(int index)
		{
			return 0f;
		}

		public Transform[] GetWheelMeshTransforms()
		{
			return null;
		}

		private bool IsWheelGrounded(WheelCollider wheel)
		{
			return false;
		}

		public void StartEngine()
		{
		}

		public void NotifyLocalPlayerEntered()
		{
		}

		public void StopEngine()
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void StartEngineServerRpc()
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void StopEngineServerRpc()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_5889103(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3063006195(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3223288705(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3853790334(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3597536050(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4280916709(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2406470603(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
